
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MarsPolymarketClient.Components;
using MarsPolymarketClient.Global;
using MarsPolymarketClient.Models;

namespace MarsPolymarketClient.Containers.Main
{
    public partial class AnalysisPane : UserControl
    {
        Dictionary<int, bool> _sorts1 = new Dictionary<int, bool>();
        Dictionary<int, bool> _sorts2 = new Dictionary<int, bool>();
        Dictionary<int, bool> _sorts3 = new Dictionary<int, bool>();
        List<string> _slugs = new List<string>();
        string _slug = "";

        public AnalysisPane()
        {
            InitializeComponent();
        }

        private void AnalysisPane_Load(object sender, EventArgs e)
        {
            comboBoxSide.SelectedIndex = 0;
            comboBoxSide.Select();
            comboBoxUpDown.SelectedIndex = 0;
            comboBoxUpDown.Select();
        }

        public void UpdateEvent(string slug)
        {
            if (!DataCenter.Events.ContainsKey(slug))
            {
                MessageBox.Show($"Data does not exist by {slug}", "ERROR");
                return;
            }

            _slug = slug;

            var market = DataCenter.Events[slug].Market;
            var trades = DataCenter.Events[slug].Trades;
            var summaries = DataCenter.Events[slug].TradeSummaries;

            UpdateMarketInfo(market);
            UpdateTradeList(market, trades, summaries);
            UpdateTradeDetailsList(market, trades);
        }

        private void UpdateTradeList(Market market, List<Trade> trades, Dictionary<string, TradeSummary> summaries)
        {
            listViewTrade.Items.Clear();

            int outComeIndex = Math.Round(decimal.Parse(market.OutcomePrices[0])) == 1 ? 0 : 1;
            decimal totalTradeAmount = 0, totalWinAmount = 0, totalLossAmount = 0;

            foreach (var trade in trades)
            {
                totalTradeAmount += trade.Size * trade.Price;
            }

            foreach (var summary in summaries.Values)
            {
                if (summary.TotalProfit > 0)
                    totalWinAmount += summary.TotalProfit;
                else
                    totalLossAmount += summary.TotalProfit;

                var item = listViewTrade.Items.Add(new ListViewItem(new string[]
                {
                    summary.Name,
                    summary.ProxyWallet,
                    summary.UpBuy.ToString("0.0"),
                    summary.UpSell.ToString("0.0"),
                    summary.UpProfit.ToString("0.0"),
                    summary.DownBuy.ToString("0.0"),
                    summary.DownSell.ToString("0.0"),
                    summary.DownProfit.ToString("0.0"),
                    summary.TotalProfit.ToString("0.0"),
                    summary.TradeCount.ToString(),
                    summary.TotalAmount.ToString("0.0")
                }));
            }

            // show trade summary info
            string info = $"Total Trades = {trades.Count}\t\tTotal Trade Amount = {totalTradeAmount.ToString("0.0")}\r\n";
            info += $"Total User Count = {summaries.Count}\t\tTotal Profit = {(totalWinAmount + totalLossAmount).ToString("0.0")}\r\n";
            info += $"Total Win Amount = {totalWinAmount.ToString("0.0")}\tTotal Loss Amount = {totalLossAmount.ToString("0.0")}";

            richTextBoxTradeInfo.Text = info;
        }

        private void UpdateMarketInfo(Market market)
        {
            int index = Math.Round(decimal.Parse(market.OutcomePrices[0])) == 1 ? 0 : 1;
            string info = $"Question = {market.Question}\r\n";
            info += $"Start Time = {market.StartTime}\t\tEnd Time = {market.EndTime}\r\n";
            info += $"Outcome = {market.Outcomes[index]}\t\t\t\tSlug = {market.Slug}\r\n";
            info += $"Condition Id = {market.ConditionId}";

            richTextBoxEventInfo.Text = info;
        }

        private void UpdateTradeDetailsList(Market market, List<Trade> trades)
        {
            listViewTradeDetails.Items.Clear();

            var sorted = trades.OrderBy(t => t.Timestamp).ToList();

            decimal totalUpAmount = 0, totalDownAmount = 0, totalAmount = 0;
            foreach (var trade in sorted)
            {
                if (textBoxAddress.Text != "" && trade.ProxyWallet != textBoxAddress.Text)
                    continue;

                if (comboBoxSide.Text != "NONE" && trade.Side.ToLower() != comboBoxSide.Text.ToLower())
                    continue;

                if (comboBoxUpDown.Text != "NONE" && trade.Outcome.ToLower() != comboBoxUpDown.Text.ToLower())
                    continue;

                var seconds = DateTimeOffset.Parse(market.EndTime).ToUnixTimeSeconds();
                var time = seconds - trade.Timestamp;
                var amount = trade.Size * trade.Price;
                totalAmount += amount;

                if (trade.Outcome == Constants.UP)
                    totalUpAmount += trade.Side == Constants.BUY ? amount : -amount;
                else
                    totalDownAmount += trade.Side == Constants.BUY ? amount : -amount;

                var item = listViewTradeDetails.Items.Add(new ListViewItem(new string[]
                {
                    trade.TransactionHash,
                    $"{Math.Floor(time / 60.0)}m {time % 60}s",
                    trade.Name,
                    trade.Side,
                    trade.Outcome,
                    trade.Size.ToString("0.0"),
                    trade.Price.ToString("0.000"),
                    amount.ToString("0.0"),
                    totalUpAmount.ToString("0.0"),
                    totalDownAmount.ToString("0.0"),
                    totalAmount.ToString("0.0")
                }));
            }
        }

        private void listViewTrade_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _sorts1[e.Column] = _sorts1.ContainsKey(e.Column) ? !_sorts1[e.Column] : true;
            listViewTrade.ListViewItemSorter = new ListViewItemComparer(e.Column, _sorts1[e.Column]);
        }

        private void listViewTradeDetails_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _sorts2[e.Column] = _sorts2.ContainsKey(e.Column) ? !_sorts2[e.Column] : true;
            listViewTradeDetails.ListViewItemSorter = new ListViewItemComparer(e.Column, _sorts2[e.Column]);
        }

        private void listViewUser_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _sorts3[e.Column] = _sorts3.ContainsKey(e.Column) ? !_sorts3[e.Column] : true;
            listViewUser.ListViewItemSorter = new ListViewItemComparer(e.Column, _sorts3[e.Column]);
        }

        private void listViewTrade_DoubleClick(object sender, EventArgs e)
        {
            if (listViewTrade.SelectedItems.Count == 0)
                return;

            var address = listViewTrade.SelectedItems[0].SubItems[1].Text;
            textBoxAddress.Text = address;
        }

        private void listViewUser_DoubleClick(object sender, EventArgs e)
        {
            if (listViewUser.SelectedItems.Count == 0)
                return;

            var address = listViewUser.SelectedItems[0].SubItems[1].Text;
            textBoxAddress.Text = address;
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            if (!DataCenter.Events.ContainsKey(_slug))
                return;

            var market = DataCenter.Events[_slug].Market;
            var trades = DataCenter.Events[_slug].Trades;

            UpdateTradeDetailsList(market, trades);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxAddress.Text = "";
            comboBoxSide.SelectedIndex = 0;
            comboBoxSide.Select();
            comboBoxUpDown.SelectedIndex = 0;
            comboBoxUpDown.Select();
        }

        public void BulkAnalyze(List<string> slugs)
        {
            _slugs = slugs;

            var userSummaries = new Dictionary<string, UserSummary>();

            foreach (var slug in _slugs)
            {
                if (!DataCenter.Events.ContainsKey(slug) || !DataCenter.Events[slug].Analyzed)
                    continue;

                var tradeSummaries = DataCenter.Events[slug].TradeSummaries;

                foreach (var summary in tradeSummaries)
                {
                    if (!userSummaries.ContainsKey(summary.Key))
                    {
                        userSummaries[summary.Key] = new UserSummary()
                        {
                            Name = summary.Value.Name,
                            ProxyWallet = summary.Value.ProxyWallet
                        };
                    }

                    var userSummary = userSummaries[summary.Key];

                    userSummary.EventCount++;
                    if (summary.Value.TotalProfit > 0)
                    {
                        userSummary.WinCount++;
                        userSummary.WinAmount += summary.Value.TotalProfit;
                    }
                    else
                    {
                        userSummary.LoseCount++;
                        userSummary.LoseAmount += summary.Value.TotalProfit;
                    }
                    userSummary.TotalProfit += summary.Value.TotalProfit;
                }
            }

            listViewUser.Items.Clear();
            foreach (var userSummary in userSummaries)
            {
                var summary = userSummary.Value;
                var winRate = summary.WinCount * 100m / (summary.WinCount + summary.LoseCount);
                var item = listViewUser.Items.Add(new ListViewItem(new string[]
                {
                    summary.Name,
                    summary.ProxyWallet,
                    summary.EventCount.ToString(),
                    summary.WinCount.ToString(),
                    summary.LoseCount.ToString(),
                    winRate.ToString("0.00"),
                    summary.WinAmount.ToString("0.0"),
                    summary.LoseAmount.ToString("0.0"),
                    summary.TotalProfit.ToString("0.0"),
                }));
            }
        }
    }
}
