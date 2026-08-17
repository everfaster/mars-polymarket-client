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
            SuspendLayout();
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(235, 223);
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
            buttonOK.Location = new Point(147, 223);
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
            richTextBoxSettings.Location = new Point(12, 12);
            richTextBoxSettings.Name = "richTextBoxSettings";
            richTextBoxSettings.Size = new Size(307, 206);
            richTextBoxSettings.TabIndex = 27;
            richTextBoxSettings.Text = "";
            // 
            // TradeSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 261);
            Controls.Add(richTextBoxSettings);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(2);
            Name = "TradeSettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trade Settings";
            ResumeLayout(false);
        }

        #endregion
        private Button buttonCancel;
        private Button buttonOK;
        private RichTextBox richTextBoxSettings;
    }
}