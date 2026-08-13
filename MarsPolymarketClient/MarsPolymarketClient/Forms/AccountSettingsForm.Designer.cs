namespace MarsPolymarketClient.Forms
{
    partial class AccountSettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AccountSettingsForm));
            listViewAccount = new ListView();
            columnExchange = new ColumnHeader();
            columnSessionKey = new ColumnHeader();
            columnStatus = new ColumnHeader();
            buttonStart = new Button();
            textBoxAPISecret = new TextBox();
            labelStaticAPISecret = new Label();
            textBoxAPIKey = new TextBox();
            comboBoxExchange = new ComboBox();
            labelStaticAPIKey = new Label();
            labelStaticExchange = new Label();
            buttonRemove = new Button();
            buttonSwitch = new Button();
            labelStaticSessionList = new Label();
            labelStaticAPIPass = new Label();
            textBoxAPIPass = new TextBox();
            buttonClose = new Button();
            buttonExport = new Button();
            buttonImport = new Button();
            buttonCopy = new Button();
            SuspendLayout();
            // 
            // listViewAccount
            // 
            listViewAccount.BackColor = Color.White;
            listViewAccount.Columns.AddRange(new ColumnHeader[] { columnExchange, columnSessionKey, columnStatus });
            listViewAccount.ForeColor = Color.Black;
            listViewAccount.FullRowSelect = true;
            listViewAccount.Location = new Point(12, 133);
            listViewAccount.Margin = new Padding(4);
            listViewAccount.MultiSelect = false;
            listViewAccount.Name = "listViewAccount";
            listViewAccount.Size = new Size(479, 199);
            listViewAccount.TabIndex = 9;
            listViewAccount.UseCompatibleStateImageBehavior = false;
            listViewAccount.View = View.Details;
            // 
            // columnExchange
            // 
            columnExchange.Text = "Exchange";
            columnExchange.Width = 150;
            // 
            // columnSessionKey
            // 
            columnSessionKey.Text = "Session Key";
            columnSessionKey.Width = 120;
            // 
            // columnStatus
            // 
            columnStatus.Text = "Status";
            columnStatus.TextAlign = HorizontalAlignment.Center;
            columnStatus.Width = 100;
            // 
            // buttonStart
            // 
            buttonStart.Location = new Point(417, 21);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(75, 54);
            buttonStart.TabIndex = 4;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // textBoxAPISecret
            // 
            textBoxAPISecret.Location = new Point(81, 52);
            textBoxAPISecret.Name = "textBoxAPISecret";
            textBoxAPISecret.PasswordChar = '*';
            textBoxAPISecret.Size = new Size(120, 23);
            textBoxAPISecret.TabIndex = 2;
            // 
            // labelStaticAPISecret
            // 
            labelStaticAPISecret.AutoSize = true;
            labelStaticAPISecret.Location = new Point(12, 56);
            labelStaticAPISecret.Margin = new Padding(2, 0, 2, 0);
            labelStaticAPISecret.Name = "labelStaticAPISecret";
            labelStaticAPISecret.Size = new Size(60, 15);
            labelStaticAPISecret.TabIndex = 37;
            labelStaticAPISecret.Text = "API Secret";
            // 
            // textBoxAPIKey
            // 
            textBoxAPIKey.Location = new Point(290, 21);
            textBoxAPIKey.Name = "textBoxAPIKey";
            textBoxAPIKey.PasswordChar = '*';
            textBoxAPIKey.Size = new Size(120, 23);
            textBoxAPIKey.TabIndex = 1;
            // 
            // comboBoxExchange
            // 
            comboBoxExchange.FormattingEnabled = true;
            comboBoxExchange.Location = new Point(81, 21);
            comboBoxExchange.Margin = new Padding(2);
            comboBoxExchange.Name = "comboBoxExchange";
            comboBoxExchange.Size = new Size(120, 23);
            comboBoxExchange.TabIndex = 0;
            comboBoxExchange.SelectedIndexChanged += comboBoxExchange_SelectedIndexChanged;
            // 
            // labelStaticAPIKey
            // 
            labelStaticAPIKey.AutoSize = true;
            labelStaticAPIKey.Location = new Point(231, 25);
            labelStaticAPIKey.Margin = new Padding(2, 0, 2, 0);
            labelStaticAPIKey.Name = "labelStaticAPIKey";
            labelStaticAPIKey.Size = new Size(47, 15);
            labelStaticAPIKey.TabIndex = 34;
            labelStaticAPIKey.Text = "API Key";
            // 
            // labelStaticExchange
            // 
            labelStaticExchange.AutoSize = true;
            labelStaticExchange.Location = new Point(12, 24);
            labelStaticExchange.Margin = new Padding(2, 0, 2, 0);
            labelStaticExchange.Name = "labelStaticExchange";
            labelStaticExchange.Size = new Size(57, 15);
            labelStaticExchange.TabIndex = 33;
            labelStaticExchange.Text = "Exchange";
            // 
            // buttonRemove
            // 
            buttonRemove.Location = new Point(411, 96);
            buttonRemove.Name = "buttonRemove";
            buttonRemove.Size = new Size(80, 30);
            buttonRemove.TabIndex = 8;
            buttonRemove.Text = "Remove";
            buttonRemove.UseVisualStyleBackColor = true;
            buttonRemove.Click += buttonRemove_Click;
            // 
            // buttonSwitch
            // 
            buttonSwitch.Location = new Point(325, 96);
            buttonSwitch.Name = "buttonSwitch";
            buttonSwitch.Size = new Size(80, 30);
            buttonSwitch.TabIndex = 7;
            buttonSwitch.Text = "Switch";
            buttonSwitch.UseVisualStyleBackColor = true;
            buttonSwitch.Click += buttonSwitch_Click;
            // 
            // labelStaticSessionList
            // 
            labelStaticSessionList.AutoSize = true;
            labelStaticSessionList.Location = new Point(12, 102);
            labelStaticSessionList.Margin = new Padding(2, 0, 2, 0);
            labelStaticSessionList.Name = "labelStaticSessionList";
            labelStaticSessionList.Size = new Size(57, 15);
            labelStaticSessionList.TabIndex = 43;
            labelStaticSessionList.Text = "Accounts";
            // 
            // labelStaticAPIPass
            // 
            labelStaticAPIPass.AutoSize = true;
            labelStaticAPIPass.Location = new Point(231, 56);
            labelStaticAPIPass.Margin = new Padding(2, 0, 2, 0);
            labelStaticAPIPass.Name = "labelStaticAPIPass";
            labelStaticAPIPass.Size = new Size(51, 15);
            labelStaticAPIPass.TabIndex = 44;
            labelStaticAPIPass.Text = "API Pass";
            // 
            // textBoxAPIPass
            // 
            textBoxAPIPass.Location = new Point(290, 52);
            textBoxAPIPass.Name = "textBoxAPIPass";
            textBoxAPIPass.PasswordChar = '*';
            textBoxAPIPass.Size = new Size(120, 23);
            textBoxAPIPass.TabIndex = 3;
            // 
            // buttonClose
            // 
            buttonClose.DialogResult = DialogResult.OK;
            buttonClose.Location = new Point(411, 339);
            buttonClose.Name = "buttonClose";
            buttonClose.Size = new Size(80, 30);
            buttonClose.TabIndex = 10;
            buttonClose.Text = "Close";
            buttonClose.UseVisualStyleBackColor = true;
            // 
            // buttonExport
            // 
            buttonExport.Location = new Point(239, 96);
            buttonExport.Name = "buttonExport";
            buttonExport.Size = new Size(80, 30);
            buttonExport.TabIndex = 6;
            buttonExport.Text = "Export";
            buttonExport.UseVisualStyleBackColor = true;
            buttonExport.Click += buttonExport_Click;
            // 
            // buttonImport
            // 
            buttonImport.Location = new Point(153, 96);
            buttonImport.Name = "buttonImport";
            buttonImport.Size = new Size(80, 30);
            buttonImport.TabIndex = 5;
            buttonImport.Text = "Import";
            buttonImport.UseVisualStyleBackColor = true;
            buttonImport.Click += buttonImport_Click;
            // 
            // buttonCopy
            // 
            buttonCopy.Location = new Point(117, 96);
            buttonCopy.Name = "buttonCopy";
            buttonCopy.Size = new Size(30, 30);
            buttonCopy.TabIndex = 45;
            buttonCopy.Text = "📋";
            buttonCopy.UseVisualStyleBackColor = true;
            buttonCopy.Click += buttonCopy_Click;
            // 
            // AccountSettingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 381);
            Controls.Add(buttonCopy);
            Controls.Add(buttonImport);
            Controls.Add(buttonExport);
            Controls.Add(buttonClose);
            Controls.Add(textBoxAPIPass);
            Controls.Add(labelStaticAPIPass);
            Controls.Add(labelStaticSessionList);
            Controls.Add(buttonSwitch);
            Controls.Add(buttonRemove);
            Controls.Add(buttonStart);
            Controls.Add(textBoxAPISecret);
            Controls.Add(labelStaticAPISecret);
            Controls.Add(textBoxAPIKey);
            Controls.Add(comboBoxExchange);
            Controls.Add(labelStaticAPIKey);
            Controls.Add(labelStaticExchange);
            Controls.Add(listViewAccount);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "AccountSettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Account Settings";
            Load += SettingsForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ListView listViewAccount;
        private ColumnHeader columnExchange;
        private ColumnHeader columnSessionKey;
        private ColumnHeader columnStatus;
        private Button buttonStart;
        private TextBox textBoxAPISecret;
        private Label labelStaticAPISecret;
        private TextBox textBoxAPIKey;
        private ComboBox comboBoxExchange;
        private Label labelStaticAPIKey;
        private Label labelStaticExchange;
        private Button buttonRemove;
        private Button buttonSwitch;
        private Label labelStaticSessionList;
        private Label labelStaticAPIPass;
        private TextBox textBoxAPIPass;
        private Button buttonClose;
        private Button buttonExport;
        private Button buttonImport;
        private Button buttonCopy;
    }
}