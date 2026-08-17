namespace MarsPolymarketClient.Containers.Main
{
    partial class TradePane
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelAction = new Panel();
            buttonClaim = new Button();
            buttonStartRequest = new Button();
            buttonRefresh = new Button();
            buttonSettings = new Button();
            buttonStop = new Button();
            buttonRun = new Button();
            labelStaticSessions = new Label();
            panelLog = new Panel();
            listViewLog = new ListView();
            panelLogTop = new Panel();
            panelSession = new Panel();
            listViewSession = new ListView();
            columnKey = new ColumnHeader();
            columnNo = new ColumnHeader();
            columnAddress = new ColumnHeader();
            columnStatus = new ColumnHeader();
            columnEventCount = new ColumnHeader();
            columnTotalProfit = new ColumnHeader();
            columnBalance = new ColumnHeader();
            columnLastUpdated = new ColumnHeader();
            timerSession = new System.Windows.Forms.Timer(components);
            panelAction.SuspendLayout();
            panelLog.SuspendLayout();
            panelSession.SuspendLayout();
            SuspendLayout();
            // 
            // panelAction
            // 
            panelAction.Controls.Add(buttonClaim);
            panelAction.Controls.Add(buttonStartRequest);
            panelAction.Controls.Add(buttonRefresh);
            panelAction.Controls.Add(buttonSettings);
            panelAction.Controls.Add(buttonStop);
            panelAction.Controls.Add(buttonRun);
            panelAction.Controls.Add(labelStaticSessions);
            panelAction.Dock = DockStyle.Top;
            panelAction.Location = new Point(0, 0);
            panelAction.Name = "panelAction";
            panelAction.Size = new Size(1093, 45);
            panelAction.TabIndex = 0;
            // 
            // buttonClaim
            // 
            buttonClaim.Location = new Point(349, 7);
            buttonClaim.Name = "buttonClaim";
            buttonClaim.Size = new Size(75, 30);
            buttonClaim.TabIndex = 3;
            buttonClaim.Text = "Claim";
            buttonClaim.UseVisualStyleBackColor = true;
            buttonClaim.Click += buttonClaim_Click;
            // 
            // buttonStartRequest
            // 
            buttonStartRequest.Location = new Point(511, 7);
            buttonStartRequest.Name = "buttonStartRequest";
            buttonStartRequest.Size = new Size(97, 30);
            buttonStartRequest.TabIndex = 5;
            buttonStartRequest.Text = "Start Request";
            buttonStartRequest.UseVisualStyleBackColor = true;
            buttonStartRequest.Click += buttonStartRequest_Click;
            // 
            // buttonRefresh
            // 
            buttonRefresh.Location = new Point(430, 7);
            buttonRefresh.Name = "buttonRefresh";
            buttonRefresh.Size = new Size(75, 30);
            buttonRefresh.TabIndex = 4;
            buttonRefresh.Text = "Refresh";
            buttonRefresh.UseVisualStyleBackColor = true;
            buttonRefresh.Click += buttonRefresh_Click;
            // 
            // buttonSettings
            // 
            buttonSettings.Location = new Point(268, 7);
            buttonSettings.Name = "buttonSettings";
            buttonSettings.Size = new Size(75, 30);
            buttonSettings.TabIndex = 2;
            buttonSettings.Text = "Settings";
            buttonSettings.UseVisualStyleBackColor = true;
            buttonSettings.Click += buttonSettings_Click;
            // 
            // buttonStop
            // 
            buttonStop.Location = new Point(187, 7);
            buttonStop.Name = "buttonStop";
            buttonStop.Size = new Size(75, 30);
            buttonStop.TabIndex = 1;
            buttonStop.Text = "Stop";
            buttonStop.UseVisualStyleBackColor = true;
            buttonStop.Click += buttonStop_Click;
            // 
            // buttonRun
            // 
            buttonRun.Location = new Point(106, 7);
            buttonRun.Name = "buttonRun";
            buttonRun.Size = new Size(75, 30);
            buttonRun.TabIndex = 0;
            buttonRun.Text = "Run";
            buttonRun.UseVisualStyleBackColor = true;
            buttonRun.Click += buttonRun_Click;
            // 
            // labelStaticSessions
            // 
            labelStaticSessions.AutoSize = true;
            labelStaticSessions.Location = new Point(3, 15);
            labelStaticSessions.Name = "labelStaticSessions";
            labelStaticSessions.Size = new Size(51, 15);
            labelStaticSessions.TabIndex = 14;
            labelStaticSessions.Text = "Sessions";
            // 
            // panelLog
            // 
            panelLog.Controls.Add(listViewLog);
            panelLog.Controls.Add(panelLogTop);
            panelLog.Dock = DockStyle.Bottom;
            panelLog.Location = new Point(0, 281);
            panelLog.Name = "panelLog";
            panelLog.Size = new Size(1093, 400);
            panelLog.TabIndex = 2;
            // 
            // listViewLog
            // 
            listViewLog.Dock = DockStyle.Fill;
            listViewLog.FullRowSelect = true;
            listViewLog.Location = new Point(0, 45);
            listViewLog.Name = "listViewLog";
            listViewLog.Size = new Size(1093, 355);
            listViewLog.TabIndex = 0;
            listViewLog.UseCompatibleStateImageBehavior = false;
            listViewLog.View = View.Details;
            // 
            // panelLogTop
            // 
            panelLogTop.Dock = DockStyle.Top;
            panelLogTop.Location = new Point(0, 0);
            panelLogTop.Name = "panelLogTop";
            panelLogTop.Size = new Size(1093, 45);
            panelLogTop.TabIndex = 7;
            // 
            // panelSession
            // 
            panelSession.Controls.Add(listViewSession);
            panelSession.Dock = DockStyle.Fill;
            panelSession.Location = new Point(0, 45);
            panelSession.Name = "panelSession";
            panelSession.Size = new Size(1093, 236);
            panelSession.TabIndex = 3;
            // 
            // listViewSession
            // 
            listViewSession.Columns.AddRange(new ColumnHeader[] { columnKey, columnNo, columnAddress, columnStatus, columnEventCount, columnTotalProfit, columnBalance, columnLastUpdated });
            listViewSession.Dock = DockStyle.Fill;
            listViewSession.FullRowSelect = true;
            listViewSession.Location = new Point(0, 0);
            listViewSession.Name = "listViewSession";
            listViewSession.Size = new Size(1093, 236);
            listViewSession.TabIndex = 0;
            listViewSession.UseCompatibleStateImageBehavior = false;
            listViewSession.View = View.Details;
            // 
            // columnKey
            // 
            columnKey.Text = "Key";
            columnKey.Width = 0;
            // 
            // columnNo
            // 
            columnNo.Text = "No";
            columnNo.TextAlign = HorizontalAlignment.Right;
            columnNo.Width = 40;
            // 
            // columnAddress
            // 
            columnAddress.Text = "Address";
            columnAddress.Width = 180;
            // 
            // columnStatus
            // 
            columnStatus.Text = "Status";
            columnStatus.TextAlign = HorizontalAlignment.Center;
            columnStatus.Width = 100;
            // 
            // columnEventCount
            // 
            columnEventCount.Text = "Event Count";
            columnEventCount.TextAlign = HorizontalAlignment.Right;
            columnEventCount.Width = 100;
            // 
            // columnTotalProfit
            // 
            columnTotalProfit.Text = "Total Profit";
            columnTotalProfit.TextAlign = HorizontalAlignment.Right;
            columnTotalProfit.Width = 100;
            // 
            // columnBalance
            // 
            columnBalance.Text = "Balance";
            columnBalance.TextAlign = HorizontalAlignment.Right;
            columnBalance.Width = 100;
            // 
            // columnLastUpdated
            // 
            columnLastUpdated.Text = "Last Updated";
            columnLastUpdated.TextAlign = HorizontalAlignment.Center;
            columnLastUpdated.Width = 140;
            // 
            // timerSession
            // 
            timerSession.Enabled = true;
            timerSession.Interval = 1000;
            timerSession.Tick += timerSession_Tick;
            // 
            // TradePane
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelSession);
            Controls.Add(panelLog);
            Controls.Add(panelAction);
            Name = "TradePane";
            Size = new Size(1093, 681);
            Load += TradePane_Load;
            panelAction.ResumeLayout(false);
            panelAction.PerformLayout();
            panelLog.ResumeLayout(false);
            panelSession.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelAction;
        private Panel panelLog;
        private Panel panelSession;
        private Button buttonRun;
        private Label labelStaticSessions;
        private ListView listViewSession;
        private ColumnHeader columnKey;
        private ColumnHeader columnNo;
        private ColumnHeader columnAddress;
        private ColumnHeader columnStatus;
        private ColumnHeader columnEventCount;
        private ColumnHeader columnTotalProfit;
        private Button buttonSettings;
        private Button buttonStop;
        private ColumnHeader columnLastUpdated;
        private ListView listViewLog;
        private Panel panelLogTop;
        private Button buttonRefresh;
        private ColumnHeader columnBalance;
        private System.Windows.Forms.Timer timerSession;
        private Button buttonStartRequest;
        private Button buttonClaim;
    }
}
