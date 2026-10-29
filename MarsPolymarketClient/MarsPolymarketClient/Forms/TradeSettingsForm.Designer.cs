namespace MarsPolymarketClient.Forms
{
    partial class TradeSettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TradeSettingsForm));
            buttonCancel = new Button();
            buttonOK = new Button();
            richTextBoxSettings = new RichTextBox();
            comboBoxStrategyType = new ComboBox();
            labelStaticStrategyType = new Label();
            buttonReload = new Button();
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(235, 367);
            buttonCancel.Margin = new Padding(2);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(84, 27);
            buttonCancel.TabIndex = 26;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(147, 367);
            buttonOK.Margin = new Padding(2);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(84, 27);
            buttonOK.TabIndex = 25;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // richTextBoxSettings
            // 
            richTextBoxSettings.Location = new Point(12, 43);
            richTextBoxSettings.Name = "richTextBoxSettings";
            richTextBoxSettings.Size = new Size(307, 319);
            richTextBoxSettings.TabIndex = 27;
            richTextBoxSettings.Text = "";
            // 
            // comboBoxStrategyType
            // 
            comboBoxStrategyType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxStrategyType.FormattingEnabled = true;
            comboBoxStrategyType.Location = new Point(99, 12);
            comboBoxStrategyType.Name = "comboBoxStrategyType";
            comboBoxStrategyType.Size = new Size(121, 23);
            comboBoxStrategyType.TabIndex = 28;
            comboBoxStrategyType.SelectedIndexChanged += comboBoxStrategyType_SelectedIndexChanged;
            // 
            // labelStaticStrategyType
            // 
            labelStaticStrategyType.AutoSize = true;
            labelStaticStrategyType.Location = new Point(12, 15);
            labelStaticStrategyType.Name = "labelStaticStrategyType";
            labelStaticStrategyType.Size = new Size(81, 15);
            labelStaticStrategyType.TabIndex = 29;
            labelStaticStrategyType.Text = "StrategyType :";
            // 
            // buttonReload
            // 
            buttonReload.Location = new Point(59, 367);
            buttonReload.Margin = new Padding(2);
            buttonReload.Name = "buttonReload";
            buttonReload.Size = new Size(84, 27);
            buttonReload.TabIndex = 30;
            buttonReload.Text = "Reload";
            buttonReload.UseVisualStyleBackColor = true;
            buttonReload.Click += buttonReload_Click;
            // 
            // TradeSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 411);
            Controls.Add(buttonReload);
            Controls.Add(labelStaticStrategyType);
            Controls.Add(comboBoxStrategyType);
            Controls.Add(richTextBoxSettings);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "TradeSettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trade Settings";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button buttonCancel;
        private Button buttonOK;
        private RichTextBox richTextBoxSettings;
        private ComboBox comboBoxStrategyType;
        private Label labelStaticStrategyType;
        private Button buttonReload;
    }
}