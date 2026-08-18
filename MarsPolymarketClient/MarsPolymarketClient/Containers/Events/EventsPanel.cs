using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MarsPolymarketClient.Forms;
using MarsPolymarketClient.Global;
using MarsPolymarketClient.Helpers;
using MarsPolymarketClient.Models;
using MarsPolymarketClient.Services;

namespace MarsPolymarketClient.Containers.Events
{
    public partial class EventsPanel : UserControl
    {
        string _prefix = "";
        int _offset = 0;
        int _timer = 0;
        int _eventIndex = 0;

        public EventsPanel()
        {
            InitializeComponent();
        }

        private void EventsPanel_Load(object sender, EventArgs e)
        {
            LoadEventListBox();
        }

        private void LoadEventListBox()
        {
            foreach (var item in Constants.EVENTS)
            {
                listBoxEvent.Items.Add(item.Item1);
            }

            UpdateSlugList(Constants.EVENTS[_eventIndex].Item2);
        }

        private void listBoxEvent_DoubleClick(object sender, EventArgs e)
        {
            _eventIndex = listBoxEvent.SelectedIndex;
            UpdateSlugList(Constants.EVENTS[_eventIndex].Item2);
        }

        private void UpdateSlugList(string prefix)
        {
            listViewSlug.BeginUpdate();

            listViewSlug.Items.Clear();

            int timeframe = Utils.GetTimeframeSeconds(prefix);
            long now = Utils.GetCurrentSlugTimeStamp(prefix) - timeframe * _offset;

            int count = int.Parse(textBoxCount.Text);

            for (int i = 2; i <= count; i++)
            {
                now = now - timeframe;
                string slug = Utils.GetFullSlugName(prefix, now);

                if (!DataCenter.Events.ContainsKey(slug))
                {
                    DataCenter.Events[slug] = new Event();

                    bool exists = PolymarketService.IsDataExists(slug);
                    if (exists)
                        UpdateEvent(slug, false);
                }

                var item = listViewSlug.Items.Add(new ListViewItem(new string[]
                {
                    slug,
                    DataCenter.Events[slug].Analyzed ? "Analyzed" : ""
                }));
            }

            _prefix = prefix;

            listViewSlug.EndUpdate();
        }

        public void UpdateEvent(string slug, bool update = true)
        {
            if (!DataCenter.Events.ContainsKey(slug))
                DataCenter.Events[slug] = new Event();

            var polyEvent = DataCenter.Events[slug];

            if (polyEvent.Analyzed)
            {
                if (update)
                {
                    var analysisPane = MainForm.GetInstance().GetAnalysisPane();
                    analysisPane.UpdateEvent(slug);
                }

                return;
            }

            HandleEventRequest(slug, update);
        }

        private void HandleEventRequest(string slug, bool update)
        {
            UpdateSlugListStatus(slug, "Loading");

            var task = Task.Run(() =>
            {
                try
                {
                    var market = PolymarketService.GetMarketBySlug(slug).Result;
                    var trades = PolymarketService.GetAllTrades(market.ConditionId).Result;

                    DataCenter.Events[slug].Market = market;
                    DataCenter.Events[slug].Trades = trades;
                    DataCenter.Events[slug].TradeSummaries = GetTradeSummaries(market, trades);
                    DataCenter.Events[slug].Analyzed = true;

                    BeginInvoke(new MethodInvoker(delegate
                    {
                        UpdateSlugListStatus(slug, "Analyzed");

                        if (update)
                        {
                            var analysisPane = MainForm.GetInstance().GetAnalysisPane();
                            analysisPane.UpdateEvent(slug);
                        }
                    }));
                }
                catch (Exception e)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        string message = $"HandleEventRequest Error. {e.Message}";
                        MainForm.GetInstance().ShowAlert(message);

                        UpdateSlugListStatus(slug, "Failed");

                        checkBoxAutoAnalyze.Checked = false;
                    }));
                }
            });
        }

        private void UpdateSlugListStatus(string slug, string status = "")
        {
            foreach (ListViewItem item in listViewSlug.Items)
            {
                if (item.SubItems[0].Text == slug)
                {
                    item.SubItems[1].Text = status;
                    break;
                }
            }
        }

        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            if (textBoxSlug.Text == "")
            {
                textBoxSlug.Focus();
                return;
            }

            UpdateEvent(textBoxSlug.Text);
        }

        private void listViewSlug_DoubleClick(object sender, EventArgs e)
        {
            if (listViewSlug.SelectedItems.Count == 0)
                return;

            var slug = listViewSlug.SelectedItems[0].SubItems[0].Text;
            textBoxSlug.Text = slug;

            UpdateEvent(slug);
        }

        private Dictionary<string, TradeSummary> GetTradeSummaries(Market market, List<Trade> trades)
        {
            var summaries = new Dictionary<string, TradeSummary>();

            if (trades.Count == 0)
                return summaries;

            int outComeIndex = Math.Round(decimal.Parse(market.OutcomePrices[0])) == 1 ? 0 : 1;
            int userCount = 0;

            foreach (var trade in trades)
            {
                if (!summaries.ContainsKey(trade.ProxyWallet))
                {
                    summaries[trade.ProxyWallet] = new TradeSummary
                    {
                        Name = trade.Name,
                        ProxyWallet = trade.ProxyWallet
                    };

                    userCount++;
                }

                var summary = summaries[trade.ProxyWallet];

                if (trade.Side == Constants.BUY)
                {
                    if (trade.OutcomeIndex == 0)
                    {
                        summary.UpBuy += trade.Size;
                        summary.UpProfit -= trade.Size * trade.Price;
                    }
                    else
                    {
                        summary.DownBuy += trade.Size;
                        summary.DownProfit -= trade.Size * trade.Price;
                    }
                }
                else
                {
                    if (trade.OutcomeIndex == 0)
                    {
                        summary.UpBuy -= trade.Size;
                        summary.UpProfit += trade.Size * trade.Price;
                    }
                    else
                    {
                        summary.DownBuy -= trade.Size;
                        summary.DownProfit += trade.Size * trade.Price;
                    }
                }

                summary.TradeCount++;
                summary.TotalAmount += trade.Size * trade.Price;
                summary.Fee += trade.Size * Constants.FEE_RATE * trade.Price * (1 - trade.Price);
            }

            foreach (var summary in summaries.Values)
            {
                if (outComeIndex == 0)
                {
                    summary.UpProfit += summary.UpBuy;
                }
                else
                {
                    summary.DownProfit += summary.DownBuy;
                }

                summary.TotalProfit = summary.UpProfit + summary.DownProfit;
            }

            return summaries;
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            _offset += int.Parse(textBoxCount.Text);

            UpdateSlugList(_prefix);
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (_offset == 0)
                return;

            _offset = Math.Min(0, _offset - int.Parse(textBoxCount.Text));

            UpdateSlugList(_prefix);
        }

        private void buttonBulkAnalyze_Click(object sender, EventArgs e)
        {
            if (listViewSlug.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select multiple items in slug list view.", "ERROR");
                return;
            }

            List<string> slugs = new List<string>();
            foreach (ListViewItem item in listViewSlug.SelectedItems)
                slugs.Add(item.SubItems[0].Text);

            var analysisPane = MainForm.GetInstance().GetAnalysisPane();
            analysisPane.BulkAnalyze(slugs);

            MainForm.GetInstance().GetAnalysisPane().SetTabIndex(0);
        }

        private void timerEvent_Tick(object sender, EventArgs e)
        {
            const int MAX_TIMER_VALUE = 10000;
            const int UPDATE_SLUG_LIST_INTERVAL = 5 * 60 * 3;
            const int UPDATE_SLUG_ITEM_INTERVAL = 20;

            if (_timer == MAX_TIMER_VALUE)
                _timer = 0;

            if (_timer % UPDATE_SLUG_LIST_INTERVAL == 0)
            {
                UpdateSlugList(Constants.EVENTS[_eventIndex].Item2);
            }

            if (_timer % UPDATE_SLUG_ITEM_INTERVAL == 0)
            {
                UpdateSlugItems();
            }

            _timer++;
        }

        private void UpdateSlugItems()
        {
            foreach (ListViewItem item in listViewSlug.Items)
            {
                if (item.SubItems[1].Text == "")
                {
                    var slug = item.SubItems[0].Text;
                    bool exists = PolymarketService.IsDataExists(slug);

                    UpdateEvent(slug, false);

                    if (!exists)
                        return;
                }
            }
        }

        private void checkBoxAutoAnalyze_CheckedChanged(object sender, EventArgs e)
        {
            timerEvent.Enabled = checkBoxAutoAnalyze.Checked;
        }
        
        private void listViewSlug_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSlug.SelectedItems.Count == 0)
                return;

            var slug = listViewSlug.SelectedItems[0].SubItems[0].Text;
            textBoxSlug.Text = slug;
        }
    }
}
