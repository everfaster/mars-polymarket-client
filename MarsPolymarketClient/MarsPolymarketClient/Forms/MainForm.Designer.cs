namespace MarsPolymarketClient.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panelLeft = new Panel();
            eventsPanel = new MarsPolymarketClient.Containers.Events.EventsPanel();
            panelMain = new Panel();
            tabControlMain = new TabControl();
            tabPageAnalysis = new TabPage();
            analysisPane = new MarsPolymarketClient.Containers.Main.AnalysisPane();
            tabPageTrade = new TabPage();
            tradePane = new MarsPolymarketClient.Containers.Main.TradePane();
            notifyIconAlert = new NotifyIcon(components);
            panelStatus = new Panel();
            labelAccount = new Label();
            labelBetExecutionTime = new Label();
            panelServerStatus = new Panel();
            labelStaticServer = new Label();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            panelRequestStatus = new Panel();
            labelStaticRequest = new Label();
            panelLeft.SuspendLayout();
            panelMain.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageAnalysis.SuspendLayout();
            tabPageTrade.SuspendLayout();
            panelStatus.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(eventsPanel);
            panelLeft.Dock = DockStyle.Left;
            panelLeft.Location = new Point(0, 24);
            panelLeft.Margin = new Padding(2);
            panelLeft.Name = "panelLeft";
            panelLeft.Size = new Size(270, 590);
            panelLeft.TabIndex = 1;
            // 
            // eventsPanel
            // 
            eventsPanel.Dock = DockStyle.Fill;
            eventsPanel.Location = new Point(0, 0);
            eventsPanel.Name = "eventsPanel";
            eventsPanel.Size = new Size(270, 590);
            eventsPanel.TabIndex = 1;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(tabControlMain);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(270, 24);
            panelMain.Margin = new Padding(2);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(765, 590);
            panelMain.TabIndex = 1;
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageAnalysis);
            tabControlMain.Controls.Add(tabPageTrade);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Margin = new Padding(2);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(765, 590);
            tabControlMain.TabIndex = 0;
            // 
            // tabPageAnalysis
            // 
            tabPageAnalysis.Controls.Add(analysisPane);
            tabPageAnalysis.Location = new Point(4, 24);
            tabPageAnalysis.Margin = new Padding(2);
            tabPageAnalysis.Name = "tabPageAnalysis";
            tabPageAnalysis.Size = new Size(757, 562);
            tabPageAnalysis.TabIndex = 2;
            tabPageAnalysis.Text = "Analysis";
            tabPageAnalysis.UseVisualStyleBackColor = true;
            // 
            // analysisPane
            // 
            analysisPane.Dock = DockStyle.Fill;
            analysisPane.Location = new Point(0, 0);
            analysisPane.Name = "analysisPane";
            analysisPane.Size = new Size(757, 562);
            analysisPane.TabIndex = 1;
            // 
            // tabPageTrade
            // 
            tabPageTrade.Controls.Add(tradePane);
            tabPageTrade.Location = new Point(4, 24);
            tabPageTrade.Name = "tabPageTrade";
            tabPageTrade.Size = new Size(757, 562);
            tabPageTrade.TabIndex = 3;
            tabPageTrade.Text = "Trade";
            tabPageTrade.UseVisualStyleBackColor = true;
            // 
            // tradePane
            // 
            tradePane.Dock = DockStyle.Fill;
            tradePane.Location = new Point(0, 0);
            tradePane.Name = "tradePane";
            tradePane.Size = new Size(757, 562);
            tradePane.TabIndex = 0;
            // 
            // notifyIconAlert
            // 
            notifyIconAlert.BalloonTipIcon = ToolTipIcon.Info;
            notifyIconAlert.Icon = (Icon)resources.GetObject("notifyIconAlert.Icon");
            notifyIconAlert.Text = "Mars Trading Client Alert";
            notifyIconAlert.Visible = true;
            // 
            // panelStatus
            // 
            panelStatus.BackColor = Color.LightCoral;
            panelStatus.Controls.Add(panelRequestStatus);
            panelStatus.Controls.Add(labelStaticRequest);
            panelStatus.Controls.Add(labelAccount);
            panelStatus.Controls.Add(labelBetExecutionTime);
            panelStatus.Controls.Add(panelServerStatus);
            panelStatus.Controls.Add(labelStaticServer);
            panelStatus.Dock = DockStyle.Bottom;
            panelStatus.Location = new Point(0, 614);
            panelStatus.Margin = new Padding(3, 2, 3, 2);
            panelStatus.Name = "panelStatus";
            panelStatus.Size = new Size(1035, 23);
            panelStatus.TabIndex = 3;
            // 
            // labelAccount
            // 
            labelAccount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAccount.AutoSize = true;
            labelAccount.Location = new Point(969, 3);
            labelAccount.Name = "labelAccount";
            labelAccount.Size = new Size(0, 15);
            labelAccount.TabIndex = 7;
            // 
            // labelBetExecutionTime
            // 
            labelBetExecutionTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelBetExecutionTime.AutoSize = true;
            labelBetExecutionTime.Location = new Point(2818, 4);
            labelBetExecutionTime.Name = "labelBetExecutionTime";
            labelBetExecutionTime.Size = new Size(0, 15);
            labelBetExecutionTime.TabIndex = 6;
            labelBetExecutionTime.TextAlign = ContentAlignment.BottomLeft;
            // 
            // panelServerStatus
            // 
            panelServerStatus.BackColor = Color.DarkRed;
            panelServerStatus.Location = new Point(52, 7);
            panelServerStatus.Margin = new Padding(3, 2, 3, 2);
            panelServerStatus.Name = "panelServerStatus";
            panelServerStatus.Size = new Size(8, 7);
            panelServerStatus.TabIndex = 1;
            // 
            // labelStaticServer
            // 
            labelStaticServer.AutoSize = true;
            labelStaticServer.Location = new Point(6, 3);
            labelStaticServer.Name = "labelStaticServer";
            labelStaticServer.Size = new Size(39, 15);
            labelStaticServer.TabIndex = 0;
            labelStaticServer.Text = "Server";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, viewToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1035, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { settingsToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(116, 22);
            settingsToolStripMenuItem.Text = "&Settings";
            settingsToolStripMenuItem.Click += settingsToolStripMenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 20);
            viewToolStripMenuItem.Text = "&View";
            // 
            // panelRequestStatus
            // 
            panelRequestStatus.BackColor = Color.DarkRed;
            panelRequestStatus.Location = new Point(130, 7);
            panelRequestStatus.Margin = new Padding(3, 2, 3, 2);
            panelRequestStatus.Name = "panelRequestStatus";
            panelRequestStatus.Size = new Size(8, 7);
            panelRequestStatus.TabIndex = 9;
            // 
            // labelStaticRequest
            // 
            labelStaticRequest.AutoSize = true;
            labelStaticRequest.Location = new Point(76, 3);
            labelStaticRequest.Name = "labelStaticRequest";
            labelStaticRequest.Size = new Size(49, 15);
            labelStaticRequest.TabIndex = 8;
            labelStaticRequest.Text = "Request";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1035, 637);
            Controls.Add(panelMain);
            Controls.Add(panelLeft);
            Controls.Add(panelStatus);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(2);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Mars Polymarket Client";
            WindowState = FormWindowState.Maximized;
            Load += MainForm_Load;
            Resize += MainForm_Resize;
            panelLeft.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            tabControlMain.ResumeLayout(false);
            tabPageAnalysis.ResumeLayout(false);
            tabPageTrade.ResumeLayout(false);
            panelStatus.ResumeLayout(false);
            panelStatus.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panelLeft;
        private Panel panelMain;
        private Panel panelStatus;
        private TabControl tabControlMain;
        private TabPage tabPageAnalysis;
        private NotifyIcon notifyIconAlert;
        private Label labelBetExecutionTime;
        private Panel panelServerStatus;
        private Label labelStaticServer;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private Label labelAccount;
        private Containers.Events.EventsPanel eventsPanel;
        private Containers.Main.AnalysisPane analysisPane;
        private TabPage tabPageTrade;
        private Containers.Main.TradePane tradePane;
        private Panel panelRequestStatus;
        private Label labelStaticRequest;
    }
}
