using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsPolymarketClient.Forms
{
    public partial class TradeSettingsForm : Form
    {
        string _settings = "";
        bool _updated = false;

        public TradeSettingsForm(string settings)
        {
            InitializeComponent();

            _settings = JToken.Parse(settings).ToString(Formatting.Indented);
            richTextBoxSettings.Text = _settings;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var settings = richTextBoxSettings.Text;

            try
            {
                JObject.Parse(settings);
                _updated = richTextBoxSettings.Text != _settings;
                _settings = richTextBoxSettings.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Settings json format: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        public string GetSettings() { return _settings; }

        public bool IsUpdated() { return _updated; }
    }
}
