
using MarsPolymarketClient.Global;
using MarsPolymarketClient.Services;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsPolymarketClient.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private string HashPassword(string password)
        {
            DateTime utcNow = DateTime.UtcNow; // UTC time
            long unixTimestamp = new DateTimeOffset(utcNow).ToUnixTimeSeconds();
            long rounded = unixTimestamp - (unixTimestamp % 300); // round by 5 minutes

            using (var pbkdf2 = new Rfc2898DeriveBytes(
                Encoding.UTF8.GetBytes(password),
                Encoding.UTF8.GetBytes(rounded.ToString()), 100000, HashAlgorithmName.SHA256))
            {
                byte[] hash = pbkdf2.GetBytes(32); // 256-bit hash
                return Convert.ToHexString(hash); // hexadecimal string
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // test code
            DialogResult = DialogResult.OK;
            Dispose();
            //

            string password = textBoxPassword.Text;
            if (password == "")
            {
                textBoxPassword.Focus();
                return;
            }

            buttonLogin.Enabled = false;

            var task = Task.Run(() =>
            {
                try
                {
                    var hash = HashPassword(password);
                    var result = PolymarketService.Login(hash).Result;
                    var jObject = JObject.Parse(result);

                    AppSettings.EncryptionKey = jObject["key"]?.ToString() ?? "";
                    AppSettings.EncryptionIv = textBoxPassword.Text;

                    BeginInvoke(new MethodInvoker(delegate
                    {
                        DialogResult = DialogResult.OK;
                        Dispose();
                    }));
                }
                catch (Exception e)
                {
                    MessageBox.Show($"Login failed! error={e.Message}", "ERROR");

                    BeginInvoke(new MethodInvoker(delegate
                    {
                        buttonLogin.Enabled = true;
                        textBoxPassword.SelectAll();
                    }));
                }
            });
        }

        private void textBoxPassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin_Click(sender, e);
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            textBoxPassword.Text = AppSettings.EncryptionIv;
        }
    }
}
