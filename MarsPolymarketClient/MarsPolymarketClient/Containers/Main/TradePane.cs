using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MarsPolymarketClient.Forms;
using MarsPolymarketClient.Global;
using MarsPolymarketClient.Models;
using MarsPolymarketClient.Services;

namespace MarsPolymarketClient.Containers.Main
{
    public partial class TradePane : UserControl
    {
        Dictionary<int, bool> _sorts1 = new Dictionary<int, bool>();
        Dictionary<int, bool> _sorts2 = new Dictionary<int, bool>();

        int _timer = 0;
        bool _enableAllRequests = true;

        public TradePane()
        {
            InitializeComponent();
        }

        private void TradePane_Load(object sender, EventArgs e)
        {
            RefreshSessionList();
            //RefreshSessionStatus();
        }

        public void RefreshSessionList()
        {
            listViewSession.Items.Clear();

            var index = 0;
            foreach (var account in AppSettings.ClientAccounts)
            {
                var item = listViewSession.Items.Add(new ListViewItem(new string[]
                {
                    account.SessionKey,
                    (++index).ToString(),
                    account.Address,
                    account.Status.Running ? "RUNNING" : "STOPPED",
                    "",
                    account.Status.Profit.ToString("0.00"),
                    account.Status.Balance.ToString("0.00"),
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                }));

                item.UseItemStyleForSubItems = false;
                item.SubItems[3].ForeColor = account.Status.Running ? Color.Green : Color.Red;
            }
        }

        private void RefreshSessionStatus()
        {
            if (!PolymarketService.ServerConnected)
                return;

            var task = Task.Run(() =>
            {
                foreach (var account in AppSettings.ClientAccounts)
                {
                    try
                    {
                        var status = PolymarketService.GetTradeStatus(AppSettings.ActiveSessionKey).Result;
                        if (status != null)
                        {
                            if (status.Running)
                                account.Status = status;
                            else
                                account.Status.Balance = status.Balance;
                        }
                    }
                    catch (Exception e)
                    {
                        BeginInvoke(new MethodInvoker(delegate
                        {
                            MainForm.GetInstance().ShowAlert(e.Message);
                            EnableAllRequests(false);
                            return;
                        }));
                    }
                }

                BeginInvoke(new MethodInvoker(delegate
                {
                    RefreshSessionList();
                }));
            });
        }

        private void timerSession_Tick(object sender, EventArgs e)
        {
            if (!PolymarketService.ServerConnected || AppSettings.ActiveSessionKey == null)
                return;

            const int MAX_TIMER_VALUE = 10000;
            const int UPDATE_SESSION_INTERVAL = 2 * 60;

            if (_timer == MAX_TIMER_VALUE)
                _timer = 0;

            if (_timer % UPDATE_SESSION_INTERVAL == 0)
                RefreshSessionStatus();

            _timer++;
        }

        public void EnableTimer(bool enabled)
        {
            timerSession.Enabled = enabled && _enableAllRequests;
        }

        public void EnableAllRequests(bool enabled)
        {
            _enableAllRequests = enabled;

            EnableTimer(enabled);
            BackColor = enabled ? Color.FromArgb(249, 249, 249) : Color.LightCoral;
            MainForm.GetInstance().SetRequestStatus(enabled);

            buttonStartRequest.BackColor = enabled ? Color.FromArgb(249, 249, 249) : Color.Green;
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            if (listViewSession.SelectedItems.Count == 0)
                return;

            var sessionKey = listViewSession.SelectedItems[0].SubItems[0].Text;
            var account = AppSettings.GetClientAccount(sessionKey);

            if (account == null)
            {
                MessageBox.Show("Session does not exists!", "ERROR");
                return;
            }

            TradeSettingsForm form = new TradeSettingsForm(account.Status.TradeOptions);
            if (form.ShowDialog() == DialogResult.OK && form.IsUpdated())
            {
                account.Status.TradeOptions = form.GetSettings();

                if (account.Status.Running)
                    RequestSetTradeOptions(account);
            }
        }

        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (listViewSession.SelectedItems.Count == 0)
                return;

            var sessionKey = listViewSession.SelectedItems[0].SubItems[0].Text;
            var account = AppSettings.GetClientAccount(sessionKey);

            if (account == null)
            {
                MessageBox.Show("Session does not exists!", "ERROR");
                return;
            }

            RequestStartTrade(account);
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (listViewSession.SelectedItems.Count == 0)
                return;

            var sessionKey = listViewSession.SelectedItems[0].SubItems[0].Text;
            var account = AppSettings.GetClientAccount(sessionKey);

            if (account == null)
            {
                MessageBox.Show("Session does not exists!", "ERROR");
                return;
            }

            RequestStopTrade(account);
        }

        private void RequestStartTrade(ClientAccount account)
        {
            if (!PolymarketService.ServerConnected)
                return;

            var task = Task.Run(() =>
            {
                try
                {
                    var result = PolymarketService.StartTrade(account.SessionKey, account.Status.TradeOptions).Result;
                    if (result)
                    {
                        BeginInvoke(new MethodInvoker(delegate
                        {
                            account.Status.Running = true;
                            RefreshSessionList();
                        }));
                    }
                }
                catch (Exception e)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        MainForm.GetInstance().ShowAlert(e.Message);
                        return;
                    }));
                }
            });
        }

        private void RequestStopTrade(ClientAccount account)
        {
            if (!PolymarketService.ServerConnected)
                return;

            var task = Task.Run(() =>
            {
                try
                {
                    var result = PolymarketService.StopTrade(account.SessionKey).Result;
                    if (result)
                    {
                        BeginInvoke(new MethodInvoker(delegate
                        {
                            account.Status.Running = false;
                            RefreshSessionList();
                        }));
                    }
                }
                catch (Exception e)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        MainForm.GetInstance().ShowAlert(e.Message);
                        return;
                    }));
                }
            });
        }

        private void RequestSetTradeOptions(ClientAccount account)
        {
            if (!PolymarketService.ServerConnected)
                return;

            var task = Task.Run(() =>
            {
                try
                {
                    var result = PolymarketService.SetTradeOptions(account.SessionKey, account.Status.TradeOptions).Result;
                    if (result)
                    {
                        BeginInvoke(new MethodInvoker(delegate
                        {
                            MainForm.GetInstance().ShowAlert("Trade parameters has been successfully updated!");
                            return;
                        }));
                    }
                }
                catch (Exception e)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        MainForm.GetInstance().ShowAlert(e.Message);
                        return;
                    }));
                }
            });
        }

        private void ClaimTrade(string sessionKey)
        {
            if (!PolymarketService.ServerConnected)
                return;

            buttonClaim.Enabled = false;
            var task = Task.Run(() =>
            {
                try
                {
                    var result = PolymarketService.ClaimTrades(sessionKey).Result;

                    BeginInvoke(new MethodInvoker(delegate
                    {
                        MainForm.GetInstance().ShowAlert("Successfully Claimed!");
                        buttonClaim.Enabled = true;
                        return;
                    }));
                }
                catch (Exception e)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        MainForm.GetInstance().ShowAlert(e.Message);
                        buttonClaim.Enabled = true;
                        return;
                    }));
                }
            });
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshSessionStatus();
        }

        private void buttonStartRequest_Click(object sender, EventArgs e)
        {
            if (_enableAllRequests == false)
                RefreshSessionStatus();

            EnableAllRequests(true);
        }

        private void buttonClaim_Click(object sender, EventArgs e)
        {
            if (listViewSession.SelectedItems.Count == 0)
                return;

            var sessionKey = listViewSession.SelectedItems[0].SubItems[0].Text;

            ClaimTrade(sessionKey);
        }
    }
}
