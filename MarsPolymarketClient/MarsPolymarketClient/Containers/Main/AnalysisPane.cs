using ClosedXML.Excel;
using MarsPolymarketClient.Components;
using MarsPolymarketClient.Forms;
using MarsPolymarketClient.Global;
using MarsPolymarketClient.Models;
using SocketIOClient.Common.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MarsPolymarketClient.Containers.Main
{
    public partial class AnalysisPane : UserControl
    {
        Dictionary<int, bool> _sorts1 = new Dictionary<int, bool>();
        Dictionary<int, bool> _sorts2 = new Dictionary<int, bool>();
        Dictionary<int, bool> _sorts3 = new Dictionary<int, bool>();
        Dictionary<int, bool> _sorts4 = new Dictionary<int, bool>();

        Dictionary<string, UserSummary> _userSummaries = new Dictionary<string, UserSummary>();
        List<string> _slugs = new List<string>();
        string _slug = "", _selectedAddress = "";

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
            listViewTrade.BeginUpdate();

            listViewTrade.Items.Clear();

            int outComeIndex = Math.Round(decimal.Parse(market.OutcomePrices[0])) == 1 ? 0 : 1;
            decimal totalTradeAmount = 0, totalWinAmount = 0, totalLossAmount = 0;
            decimal maxPrice = MainForm.GetInstance().GetEventsPanel().GetMaxPrice();

            foreach (var trade in trades)
            {
                if (trade.Price >= maxPrice)
                    continue;

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

            listViewTrade.EndUpdate();

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
            listViewTradeDetails.BeginUpdate();

            listViewTradeDetails.Items.Clear();

            var sorted = trades.OrderBy(t => t.Timestamp).ToList();

            decimal totalUpAmount = 0, totalDownAmount = 0, totalAmount = 0;
            decimal totalUpSize = 0, totalDownSize = 0;
            var addresses = richTextBoxAddress.Text != "" ?
                richTextBoxAddress.Text.Split("\n").Select(a => a.ToLower()).ToArray() : [];
            decimal maxPrice = MainForm.GetInstance().GetEventsPanel().GetMaxPrice();

            foreach (var trade in sorted)
            {
                if (trade.Price >= maxPrice)
                    continue;

                if (addresses.Length > 0 && !addresses.Contains(trade.ProxyWallet.ToLower()))
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
                {
                    totalUpAmount += trade.Side == Constants.BUY ? amount : -amount;
                    totalUpSize += trade.Side == Constants.BUY ? trade.Size : -trade.Size;
                }
                else
                {
                    totalDownAmount += trade.Side == Constants.BUY ? amount : -amount;
                    totalDownSize += trade.Side == Constants.BUY ? trade.Size : -trade.Size;
                }

                var upProfit = totalUpSize * 1 - totalUpAmount - totalDownAmount;
                var downProfit = totalDownSize * 1 - totalUpAmount - totalDownAmount;

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
                    totalAmount.ToString("0.0"),
                    trade.IsTaker ? "Take" : "Make",
                    totalUpSize.ToString("0.0"),
                    totalDownSize.ToString("0.0"),
                    upProfit.ToString("0.0"),
                    downProfit.ToString("0.0"),

                }));
            }

            listViewTradeDetails.EndUpdate();
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

        private void listViewSummaryDetails_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            _sorts4[e.Column] = _sorts4.ContainsKey(e.Column) ? !_sorts4[e.Column] : true;
            listViewSummaryDetails.ListViewItemSorter = new ListViewItemComparer(e.Column, _sorts4[e.Column]);
        }

        private void listViewTrade_DoubleClick(object sender, EventArgs e)
        {
            if (listViewTrade.SelectedItems.Count == 0)
                return;

            var address = listViewTrade.SelectedItems[0].SubItems[1].Text;
            SetFilterAddress(address);
        }

        private void listViewUser_DoubleClick(object sender, EventArgs e)
        {
            if (listViewUser.SelectedItems.Count == 0)
                return;

            var address = listViewUser.SelectedItems[0].SubItems[1].Text;
            _selectedAddress = address;

            SetTabIndex(1);
            SetFilterAddress(_selectedAddress);
            UpdateSummaryDetails(_selectedAddress);
        }

        private void listViewSummaryDetails_DoubleClick(object sender, EventArgs e)
        {
            if (listViewSummaryDetails.SelectedItems.Count == 0)
                return;

            var slug = listViewSummaryDetails.SelectedItems[0].SubItems[0].Text;
            MainForm.GetInstance().GetEventsPanel().UpdateEvent(slug);
        }

        private void buttonFilter_Click(object sender, EventArgs e)
        {
            if (!DataCenter.Events.ContainsKey(_slug))
                return;

            var market = DataCenter.Events[_slug].Market;
            var trades = DataCenter.Events[_slug].Trades;

            UpdateTradeDetailsList(market, trades);
        }

        public void SetTabIndex(int index)
        {
            tabControlTrade.SelectedIndex = index;
        }

        private void SetFilterAddress(string address, bool append = false)
        {
            if (append)
            {
                var addresses = richTextBoxAddress.Text.Split("\n").Select(a => a.ToLower()).ToArray();
                if (!addresses.Contains(address.ToLower()))
                {
                    if (richTextBoxAddress.Text == "")
                        richTextBoxAddress.Text = address;
                    else
                        richTextBoxAddress.Text += $"\n{address}";
                }
            }
            else
            {
                richTextBoxAddress.Text = address;
            }
        }

        private void SetFilterAddress2(string address, bool append = false)
        {
            if (append)
            {
                var addresses = richTextBoxAddress2.Text.Split("\n").Select(a => a.ToLower()).ToArray();
                if (!addresses.Contains(address.ToLower()))
                {
                    if (richTextBoxAddress2.Text == "")
                        richTextBoxAddress2.Text = address;
                    else
                        richTextBoxAddress2.Text += $"\n{address}";
                }
            }
            else
            {
                richTextBoxAddress2.Text = address;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBoxAddress.Text = "";
            comboBoxSide.SelectedIndex = 0;
            comboBoxSide.Select();
            comboBoxUpDown.SelectedIndex = 0;
            comboBoxUpDown.Select();
        }

        public void BulkAnalyze(List<string> slugs)
        {
            _slugs = slugs;
            _userSummaries = new Dictionary<string, UserSummary>();

            foreach (var slug in _slugs)
            {
                if (!DataCenter.Events.ContainsKey(slug) || !DataCenter.Events[slug].Analyzed)
                    continue;

                var tradeSummaries = DataCenter.Events[slug].TradeSummaries;

                foreach (var summary in tradeSummaries)
                {
                    if (!_userSummaries.ContainsKey(summary.Key))
                    {
                        _userSummaries[summary.Key] = new UserSummary()
                        {
                            Name = summary.Value.Name,
                            ProxyWallet = summary.Value.ProxyWallet
                        };
                    }

                    var userSummary = _userSummaries[summary.Key];

                    userSummary.EventCount++;
                    if (summary.Value.TotalProfit > 0)
                    {
                        userSummary.WinCount++;
                        userSummary.WinAmount += summary.Value.TotalProfit;
                    }
                    else
                    {
                        userSummary.LoseCount++;
                        userSummary.LossAmount += summary.Value.TotalProfit;
                    }

                    userSummary.Fee += summary.Value.Fee;
                    userSummary.TotalProfit += summary.Value.TotalProfit;
                    userSummary.Slugs.Add(slug);
                }
            }

            UpdateUserListView();
        }

        private void UpdateSummaryDetails(string address)
        {
            if (!_userSummaries.ContainsKey(address))
                return;

            listViewSummaryDetails.BeginUpdate();

            listViewSummaryDetails.Items.Clear();

            var slugs = _userSummaries[address].Slugs;
            foreach (var slug in slugs)
            {
                var summary = DataCenter.Events[slug].TradeSummaries[address];
                var totalProfit = checkBoxFee.Checked ? summary.TotalProfit - summary.Fee : summary.TotalProfit;
                var item = listViewSummaryDetails.Items.Add(new ListViewItem(new string[]
                {
                    slug,
                    summary.Name,
                    summary.UpProfit.ToString("0.0"),
                    summary.DownProfit.ToString("0.0"),
                    summary.TradeCount.ToString(),
                    summary.TotalAmount.ToString("0.0"),
                    summary.Fee.ToString("0.0"),
                    totalProfit.ToString("0.0"),
                }));
            }

            listViewSummaryDetails.EndUpdate();
        }

        private void UpdateUserListView()
        {
            listViewUser.BeginUpdate();

            listViewUser.Items.Clear();

            var addresses = richTextBoxAddress2.Text != "" ?
                richTextBoxAddress2.Text.Split("\n").Select(a => a.ToLower()).ToArray() : [];
            int minEventCount = textBoxEventCount.Text == "" ? 0 : int.Parse(textBoxEventCount.Text);
            decimal minWinRate = textBoxWinRate.Text == "" ? 0 : decimal.Parse(textBoxWinRate.Text);
            decimal minTotalProfit = textBoxTotalProfit.Text == "" ? -100000000 : decimal.Parse(textBoxTotalProfit.Text);

            foreach (var userSummary in _userSummaries)
            {
                var summary = userSummary.Value;

                if (addresses.Length > 0 && !addresses.Contains(summary.ProxyWallet.ToLower()))
                    continue;

                if (summary.EventCount < minEventCount)
                    continue;

                if (checkBoxFee.Checked && summary.TotalProfit - summary.Fee < minTotalProfit ||
                    !checkBoxFee.Checked && summary.TotalProfit < minTotalProfit)
                    continue;

                var winRate = summary.WinCount * 100m / (summary.WinCount + summary.LoseCount);
                if (winRate < minWinRate)
                    continue;

                var totalProfit = checkBoxFee.Checked ? summary.TotalProfit - summary.Fee : summary.TotalProfit;
                var avgAmount = (summary.WinAmount - summary.LossAmount) / summary.EventCount;
                var avgProfit = totalProfit / summary.EventCount;
                var profitFactor = summary.LossAmount == 0 ? 999 : Math.Abs(summary.WinAmount / summary.LossAmount);
                var item = listViewUser.Items.Add(new ListViewItem(new string[]
                {
                    summary.Name,
                    summary.ProxyWallet,
                    summary.EventCount.ToString(),
                    summary.WinCount.ToString(),
                    summary.LoseCount.ToString(),
                    winRate.ToString("0.##"),
                    avgAmount.ToString("0.#"),
                    avgProfit.ToString("0.#"),
                    profitFactor.ToString("0.#"),
                    summary.Fee.ToString("0.#"),
                    totalProfit.ToString("0.#"),
                }));
            }

            listViewUser.EndUpdate();
        }

        private void buttonFilter2_Click(object sender, EventArgs e)
        {
            UpdateUserListView();
        }

        private void buttonClear2_Click(object sender, EventArgs e)
        {
            richTextBoxAddress2.Text = "";
            textBoxEventCount.Text = "";
            textBoxWinRate.Text = "";
            textBoxTotalProfit.Text = "";
        }

        private void toolStripMenuItemUserSetAddress_Click(object sender, EventArgs e)
        {
            if (listViewUser.SelectedItems.Count == 0)
                return;

            bool append = false;
            foreach (ListViewItem item in listViewUser.SelectedItems)
            {
                var address = item.SubItems[1].Text;
                SetFilterAddress2(address, append);
                append = true;
            }
        }

        private void toolStripMenuItemUserAddAddress_Click(object sender, EventArgs e)
        {
            if (listViewUser.SelectedItems.Count == 0)
                return;

            foreach (ListViewItem item in listViewUser.SelectedItems)
            {
                var address = item.SubItems[1].Text;
                SetFilterAddress2(address, true);
            }
        }

        private void setAddressesToFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewTrade.SelectedItems.Count == 0)
                return;

            bool append = false;
            foreach (ListViewItem item in listViewTrade.SelectedItems)
            {
                var address = item.SubItems[1].Text;
                SetFilterAddress(address, append);
                append = true;
            }
        }

        private void addAddressesToFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewTrade.SelectedItems.Count == 0)
                return;

            foreach (ListViewItem item in listViewTrade.SelectedItems)
            {
                var address = item.SubItems[1].Text;
                SetFilterAddress(address, true);
            }
        }

        private void listViewTrade_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // enable/disable menus
                var enabled = listViewTrade.SelectedItems.Count > 0;
                var enabled2 = listViewTrade.Items.Count > 0;

                contextMenuStripTrade.Items["setAddressesToFilterToolStripMenuItem"]!.Enabled = enabled;
                contextMenuStripTrade.Items["addAddressesToFilterToolStripMenuItem"]!.Enabled = enabled;
                contextMenuStripTrade.Items["exportToExcelFileToolStripMenuItem1"]!.Enabled = enabled2;

                // show menu
                contextMenuStripTrade.Show(Cursor.Position);
            }
        }

        private void listViewUser_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // enable/disable menus
                var enabled = listViewUser.SelectedItems.Count > 0;
                var enabled2 = listViewUser.Items.Count > 0;

                contextMenuStripUser.Items["toolStripMenuItemUserSetAddress"]!.Enabled = enabled;
                contextMenuStripUser.Items["toolStripMenuItemUserAddAddress"]!.Enabled = enabled;
                contextMenuStripUser.Items["exportToExcelFileToolStripMenuItem"]!.Enabled = enabled2;

                // show menu
                contextMenuStripUser.Show(Cursor.Position);
            }
        }

        private void listViewSummaryDetails_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // enable/disable menus
                var enabled = listViewSummaryDetails.Items.Count > 0;

                contextMenuSummaryDetails.Items["exportToExcelFileToolStripMenuItem2"]!.Enabled = enabled;

                // show menu
                contextMenuSummaryDetails.Show(Cursor.Position);
            }
        }

        private void listViewTradeDetails_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // enable/disable menus
                var enabled = listViewTradeDetails.Items.Count > 0;

                contextMenuStripTradeDetails.Items["exportToExcelFileToolStripMenuItem3"]!.Enabled = enabled;

                // show menu
                contextMenuStripTradeDetails.Show(Cursor.Position);
            }
        }

        private void copyAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listViewUser.SelectedItems.Count == 0)
                return;

            string addresses = "";
            foreach (ListViewItem item in listViewUser.SelectedItems)
            {
                if (addresses == "")
                    addresses = item.SubItems[1].Text;
                else
                    addresses += $",{item.SubItems[1].Text}";
            }

            Clipboard.SetText(addresses);
        }

        private void copyAddressToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (listViewTrade.SelectedItems.Count == 0)
                return;

            string addresses = "";
            foreach (ListViewItem item in listViewTrade.SelectedItems)
            {
                if (addresses == "")
                    addresses = item.SubItems[1].Text;
                else
                    addresses += $",{item.SubItems[1].Text}";
            }

            Clipboard.SetText(addresses);
        }

        private void ExportToExcelFile(System.Windows.Forms.ListView listView, string fileName = "NewFile")
        {
            using var dialog = new SaveFileDialog
            {
                Filter = "Excel files (*.xlsx)|*.xlsx",
                FileName = $"{fileName}.xlsx"
            };

            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Trades");

            // Headers
            for (int i = 0; i < listView.Columns.Count; i++)
            {
                worksheet.Cell(1, i + 1).Value = listView.Columns[i].Text;
            }

            // Data
            for (int row = 0; row < listView.Items.Count; row++)
            {
                var item = listView.Items[row];

                for (int col = 0; col < item.SubItems.Count; col++)
                {
                    worksheet.Cell(row + 2, col + 1).Value =
                        item.SubItems[col].Text;
                }
            }

            // Formatting
            worksheet.Columns().AdjustToContents();

            workbook.SaveAs(dialog.FileName);

            Process.Start(new ProcessStartInfo
            {
                FileName = dialog.FileName,
                UseShellExecute = true
            });
        }

        private void exportToExcelFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExportToExcelFile(listViewUser, "user_bulk_analysis");
        }

        private void exportToExcelFileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var slug = MainForm.GetInstance().GetEventsPanel().GetSelectedSlug();

            ExportToExcelFile(listViewTrade, $"user_summmary_{slug}");
        }

        private void exportToExcelFileToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ExportToExcelFile(listViewSummaryDetails, $"user_analysis_details");
        }

        private void exportToExcelFileToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ExportToExcelFile(listViewTradeDetails, $"user_trade_details");
        }
    }
}
