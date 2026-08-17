using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MarsPolymarketClient.Containers.Events;
using MarsPolymarketClient.Containers.Main;
using MarsPolymarketClient.Global;
using MarsPolymarketClient.Helpers;
using MarsPolymarketClient.Models;
using MarsPolymarketClient.Services;

namespace MarsPolymarketClient.Forms
{
    public partial class MainForm : Form
    {
        private static MainForm? instance_ = null;

        public MainForm()
        {
            InitializeComponent();
        }

        public static MainForm GetInstance()
        {
            if (instance_ == null)
            {
                return CreateInstance();
            }

            return instance_;
        }

        private static MainForm CreateInstance()
        {
            instance_ = new MainForm();
            return instance_;
        }

        public TabControl GetTabControl()
        {
            return tabControlMain;
        }

        public EventsPanel GetEventsPanel()
        {
            return eventsPanel;
        }

        public AnalysisPane GetAnalysisPane()
        {
            return analysisPane;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PolymarketService.Initialize();

            if (AppSettings.ActiveSessionKey == null)
            {
                AccountSettingsForm accountSettingsForm = new AccountSettingsForm();
                accountSettingsForm.ShowDialog();

                if (accountSettingsForm.IsUpdated())
                {
                    tradePane.RefreshSessionList();
                }
            }
        }

        public void ShowAlert(string message, int timeout = 1000, bool invoke = false)
        {
            notifyIconAlert.Icon = SystemIcons.Information;
            notifyIconAlert.Visible = true;
            notifyIconAlert.BalloonTipText = message;

            if (invoke)
            {
                BeginInvoke(new MethodInvoker(delegate
                {
                    notifyIconAlert.ShowBalloonTip(timeout);
                    //SoundHelper.PlayAlertSound(soundType);
                }));
            }
            else
            {
                notifyIconAlert.ShowBalloonTip(timeout);
                //SoundHelper.PlayAlertSound(soundType);
            }
        }

        public void SetServerStatus(bool connected)
        {
            BeginInvoke(new MethodInvoker(delegate
            {
                panelServerStatus.BackColor = connected ? Color.DarkGreen : Color.DarkRed;
                panelStatus.BackColor = connected ? Color.Transparent : Color.LightCoral;
            }));
        }

        public void SetRequestStatus(bool connected)
        {
            panelRequestStatus.BackColor = connected ? Color.DarkGreen : Color.DarkRed;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            panelLeft.Visible = Width >= Screen.PrimaryScreen?.Bounds.Width / 2;
        }

        private void symbolListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panelLeft.Visible = !panelLeft.Visible;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountSettingsForm form = new AccountSettingsForm();
            form.ShowDialog();
        }
    }
}
