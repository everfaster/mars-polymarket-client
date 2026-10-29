using MarsPolymarketClient.Global;
using MarsPolymarketClient.Models;
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
        string _strategyType = "", _options;
        bool _updated = false;

        public TradeSettingsForm(string strategyType, string options)
        {
            InitializeComponent();

            InitStrategyComboBox();

            _strategyType = strategyType;
            _options = JToken.Parse(options).ToString(Formatting.Indented);

            if (strategyType == string.Empty)
            {
                comboBoxStrategyType.SelectedIndex = 0;
                comboBoxStrategyType.Select();
            }
            else
            {
                comboBoxStrategyType.SelectedItem = _strategyType;
                comboBoxStrategyType.Select();
                richTextBoxSettings.Text = _options;
            }
        }

        private void InitStrategyComboBox()
        {
            foreach (var strategy in DataCenter.Strategies)
            {
                comboBoxStrategyType.Items.Add(strategy.StrategyType);
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var settings = richTextBoxSettings.Text;

            try
            {
                JObject.Parse(settings);
                _updated = richTextBoxSettings.Text != _options;
                _options = richTextBoxSettings.Text;
                _strategyType = comboBoxStrategyType.SelectedItem?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Settings json format: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
            }
        }

        public string GetOptions() { return _options; }
        public string GetStrategyType() { return _strategyType; }

        public bool IsUpdated() { return _updated; }

        private void comboBoxStrategyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var strategyType = comboBoxStrategyType.SelectedItem?.ToString();
            var options = 
                DataCenter.Strategies.FirstOrDefault(s => s.StrategyType == strategyType)?.DefaultOptions ?? string.Empty;

            richTextBoxSettings.Text = JToken.Parse(options).ToString(Formatting.Indented);
        }

        private void buttonReload_Click(object sender, EventArgs e)
        {
            richTextBoxSettings.Text = _options;
        }
    }
}
