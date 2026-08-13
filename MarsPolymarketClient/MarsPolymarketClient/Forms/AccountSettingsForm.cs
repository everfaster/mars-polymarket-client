
using MarsPolymarketClient.Components;
using MarsPolymarketClient.Global;
using MarsPolymarketClient.Helpers;
using MarsPolymarketClient.Models;
using MarsPolymarketClient.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsPolymarketClient.Forms
{
    public partial class AccountSettingsForm : Form
    {
        private int _count = 0;

        public AccountSettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            RefreshAccountList();
        }

        private void RefreshAccountList()
        {
            listViewAccount.Items.Clear();

            foreach (var account in AppSettings.ClientAccounts)
            {
                var item = listViewAccount.Items.Add(new ListViewItem(new string[]
                {
                    $"{account.SessionKey.Substring(0, 6)}******",
                    account.SessionKey == AppSettings.ActiveSessionKey ? "Activated": ""
                }));
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (textBoxAPIKey.Text == "")
            {
                textBoxAPIKey.Focus();
                return;
            }

            buttonStart.Enabled = false;
            buttonClose.Enabled = false;

            var task = Task.Run(() =>
            {
                try
                {
                    var sessionKey = PolymarketService.StartService(
                        textBoxAPIKey.Text, textBoxAPISecret.Text, textBoxAPIPass.Text).Result;

                    BeginInvoke(new MethodInvoker(delegate
                    {
                        if (AppSettings.GetClientAccount(sessionKey) == null)
                        {
                            ClientAccount newAccount = new ClientAccount();
                            newAccount.SessionKey = sessionKey;

                            AppSettings.ClientAccounts.Add(newAccount);
                        }

                        var account = AppSettings.GetClientAccount(sessionKey);
                        ActivateAccount(account);

                        MainForm.GetInstance().ShowAlert($"Starting Service Success!");
                        buttonStart.Enabled = true;
                        buttonClose.Enabled = true;
                    }));
                }
                catch (Exception e)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        MainForm.GetInstance().ShowAlert($"Starting service failed!\r\n{e.Message}");
                        buttonStart.Enabled = true;
                        buttonClose.Enabled = true;
                    }));
                }
            });
        }

        private void comboBoxExchange_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxExchange.SelectedIndex)
            {
                case 0: // binance
                    textBoxAPISecret.Enabled = true;
                    textBoxAPIPass.Enabled = false;
                    break;
                case 1: // okx
                    textBoxAPISecret.Enabled = true;
                    textBoxAPIPass.Enabled = true;
                    break;
                case 2: // hyperliquid
                    textBoxAPISecret.Enabled = false;
                    textBoxAPIPass.Enabled = false;
                    break;
            }
        }

        private void buttonSwitch_Click(object sender, EventArgs e)
        {
            if (listViewAccount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select one in the account list.", "WARNING");
                return;
            }

            var index = listViewAccount.SelectedItems[0].Index;
            if (AppSettings.ActiveSessionKey != AppSettings.ClientAccounts[index].SessionKey)
            {
                ActivateAccount(AppSettings.ClientAccounts[index]);
            }
        }

        private void ActivateAccount(ClientAccount account)
        {
            AppSettings.ActiveSessionKey = account.SessionKey;
            DataCenter.ActiveAccount = account;

            RefreshAccountList();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewAccount.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select one in the account list.", "WARNING");
                return;
            }

            buttonRemove.Enabled = false;
            var index = listViewAccount.SelectedItems[0].Index;
            var sessionKey = AppSettings.ClientAccounts[index].SessionKey;

            var task = Task.Run(() =>
            {
                try
                {
                    var result = PolymarketService.StopService(sessionKey).Result;

                    BeginInvoke(new MethodInvoker(delegate
                    {
                        AppSettings.ClientAccounts.RemoveAt(index);
                        if (AppSettings.ClientAccounts.Count > 0)
                        {
                            ActivateAccount(AppSettings.ClientAccounts[0]);
                        }
                        else
                        {
                            AppSettings.ActiveSessionKey = "";
                            RefreshAccountList();
                        }

                        buttonRemove.Enabled = true;
                    }));
                }
                catch (Exception e)
                {
                    BeginInvoke(new MethodInvoker(delegate
                    {
                        MainForm.GetInstance().ShowAlert($"Stopping session failed!\r\n{e.Message}");
                        buttonRemove.Enabled = true;
                    }));
                }
            });
        }

        private void buttonImport_Click(object sender, EventArgs e)
        {
            // show openfile dialog
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "MarsTrading Key Files (*.mtk)|*.mtk|All files (*.*)|*.*";
            dialog.Multiselect = false;

            // open dialog
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                string password = PasswordInput.Show("Input", "Enter decrypt password:");
                string jsonString = File.ReadAllText(dialog.FileName);
                string encoded = Utils.Decrypt(jsonString, password);
                var credential = JsonConvert.DeserializeObject<JObject>(encoded);

                textBoxAPIKey.Text = credential?["APIKey"]?.ToString();
                textBoxAPISecret.Text = credential?["APISecret"]?.ToString();
                textBoxAPIPass.Text = credential?["APIPass"]?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Invalid key file or encrypt password! {ex.Message}", "Error");
            }
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            JObject credential = new JObject();

            credential["APIKey"] = textBoxAPIKey.Text;
            credential["APISecret"] = textBoxAPISecret.Text;
            credential["APIPass"] = textBoxAPIPass.Text;

            string password = PasswordInput.Show("Input", "Enter encrypt password:");
            string encrypted = Utils.Encrypt(credential.ToString(), password);

            // show savefile dialog
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "MarsTrading Key Files (*.mtk)|*.mtk|All files (*.*)|*.*";
            dialog.FileName = "MarsTradingKey.mtk";

            // open dialog
            if (dialog.ShowDialog() != DialogResult.OK)
                return;

            try
            {
                var filePath = Path.GetDirectoryName(dialog.FileName);
                File.WriteAllText(dialog.FileName, encrypted);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export error! {ex.Message}", "Error");
            }
        }

        private void buttonCopy_Click(object sender, EventArgs e)
        {
            var selectedText = "";

            if (textBoxAPIKey.SelectedText.Length > 0)
                selectedText = textBoxAPIKey.Text;
            else if (textBoxAPISecret.SelectedText.Length > 0)
                selectedText = textBoxAPISecret.Text;
            else if (textBoxAPIPass.SelectedText.Length > 0)
                selectedText = textBoxAPIPass.Text;

            if (selectedText == "")
            {
                _count = 0;

                Clipboard.Clear();
                return;
            }

            int length = selectedText == "" ? 21 : selectedText.Length / 3;
            string text = "";
            if (_count == 1)
                text = selectedText.Substring(length, length);
            else if (_count == 3)
                text = selectedText.Substring(0, length);
            else if (_count == 5)
                text = selectedText.Substring(length * 2);
            else
                text = Utils.RandomHex(length);

            Clipboard.SetText(text);
            _count++;
        }
    }
}
