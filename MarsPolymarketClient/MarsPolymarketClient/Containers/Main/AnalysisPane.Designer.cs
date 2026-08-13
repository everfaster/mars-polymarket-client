namespace MarsPolymarketClient.Containers.Main
{
    partial class AnalysisPane
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
            panelRight = new Panel();
            listViewTradeDetails = new ListView();
            columnHash = new ColumnHeader();
            columnTimestamp = new ColumnHeader();
            columnName2 = new ColumnHeader();
            columnSide = new ColumnHeader();
            columnUpDown = new ColumnHeader();
            columnSize = new ColumnHeader();
            columnPrice = new ColumnHeader();
            columnAmount = new ColumnHeader();
            columnTotalUpAmount = new ColumnHeader();
            columnTotalDownAmount = new ColumnHeader();
            columnTotalAmount2 = new ColumnHeader();
            panelFilter = new Panel();
            buttonClear = new Button();
            buttonFilter = new Button();
            comboBoxUpDown = new ComboBox();
            labelStaticUpDown = new Label();
            comboBoxSide = new ComboBox();
            labelStaticSide = new Label();
            textBoxAddress = new TextBox();
            labelStaticAddress = new Label();
            panelMain = new Panel();
            panelUser = new Panel();
            listViewUser = new ListView();
            columnName3 = new ColumnHeader();
            columnAddress3 = new ColumnHeader();
            columnEventCount = new ColumnHeader();
            columnWinCount = new ColumnHeader();
            columnLossCount = new ColumnHeader();
            columnWinRate = new ColumnHeader();
            columnWinAmount = new ColumnHeader();
            columnLossAmount = new ColumnHeader();
            columnTotalProfit2 = new ColumnHeader();
            panelControl = new Panel();
            panelTrades = new Panel();
            listViewTrade = new ListView();
            columnName = new ColumnHeader();
            columnAddress = new ColumnHeader();
            columnUpBuy = new ColumnHeader();
            columnUpSell = new ColumnHeader();
            columnUpProfit = new ColumnHeader();
            columnDownBuy = new ColumnHeader();
            columnDownSell = new ColumnHeader();
            columnDownProfit = new ColumnHeader();
            columnTotalProfit = new ColumnHeader();
            columnTradeCount = new ColumnHeader();
            columnTotalAmount = new ColumnHeader();
            panelEventInfo = new Panel();
            richTextBoxTradeInfo = new RichTextBox();
            richTextBoxEventInfo = new RichTextBox();
            panelRight.SuspendLayout();
            panelFilter.SuspendLayout();
            panelMain.SuspendLayout();
            panelUser.SuspendLayout();
            panelTrades.SuspendLayout();
            panelEventInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelRight
            // 
            panelRight.Controls.Add(listViewTradeDetails);
            panelRight.Controls.Add(panelFilter);
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(447, 0);
            panelRight.Name = "panelRight";
            panelRight.Size = new Size(700, 900);
            panelRight.TabIndex = 2;
            // 
            // listViewTradeDetails
            // 
            listViewTradeDetails.Columns.AddRange(new ColumnHeader[] { columnHash, columnTimestamp, columnName2, columnSide, columnUpDown, columnSize, columnPrice, columnAmount, columnTotalUpAmount, columnTotalDownAmount, columnTotalAmount2 });
            listViewTradeDetails.Dock = DockStyle.Fill;
            listViewTradeDetails.FullRowSelect = true;
            listViewTradeDetails.Location = new Point(0, 80);
            listViewTradeDetails.Name = "listViewTradeDetails";
            listViewTradeDetails.Size = new Size(700, 820);
            listViewTradeDetails.TabIndex = 6;
            listViewTradeDetails.UseCompatibleStateImageBehavior = false;
            listViewTradeDetails.View = View.Details;
            listViewTradeDetails.ColumnClick += listViewTradeDetails_ColumnClick;
            // 
            // columnHash
            // 
            columnHash.Text = "Address";
            columnHash.Width = 0;
            // 
            // columnTimestamp
            // 
            columnTimestamp.Text = "Time";
            columnTimestamp.TextAlign = HorizontalAlignment.Center;
            // 
            // columnName2
            // 
            columnName2.Text = "Name";
            columnName2.TextAlign = HorizontalAlignment.Center;
            columnName2.Width = 100;
            // 
            // columnSide
            // 
            columnSide.Text = "Side";
            columnSide.TextAlign = HorizontalAlignment.Center;
            // 
            // columnUpDown
            // 
            columnUpDown.Text = "Up/Down";
            columnUpDown.TextAlign = HorizontalAlignment.Center;
            columnUpDown.Width = 65;
            // 
            // columnSize
            // 
            columnSize.Text = "Size";
            columnSize.TextAlign = HorizontalAlignment.Right;
            // 
            // columnPrice
            // 
            columnPrice.Text = "Price";
            columnPrice.TextAlign = HorizontalAlignment.Right;
            // 
            // columnAmount
            // 
            columnAmount.Text = "Amount";
            columnAmount.TextAlign = HorizontalAlignment.Right;
            // 
            // columnTotalUpAmount
            // 
            columnTotalUpAmount.Text = "Up Amt";
            columnTotalUpAmount.TextAlign = HorizontalAlignment.Right;
            columnTotalUpAmount.Width = 70;
            // 
            // columnTotalDownAmount
            // 
            columnTotalDownAmount.Text = "Down Amt";
            columnTotalDownAmount.TextAlign = HorizontalAlignment.Right;
            columnTotalDownAmount.Width = 70;
            // 
            // columnTotalAmount2
            // 
            columnTotalAmount2.Text = "Total Amt";
            columnTotalAmount2.TextAlign = HorizontalAlignment.Right;
            columnTotalAmount2.Width = 80;
            // 
            // panelFilter
            // 
            panelFilter.Controls.Add(buttonClear);
            panelFilter.Controls.Add(buttonFilter);
            panelFilter.Controls.Add(comboBoxUpDown);
            panelFilter.Controls.Add(labelStaticUpDown);
            panelFilter.Controls.Add(comboBoxSide);
            panelFilter.Controls.Add(labelStaticSide);
            panelFilter.Controls.Add(textBoxAddress);
            panelFilter.Controls.Add(labelStaticAddress);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 0);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(700, 80);
            panelFilter.TabIndex = 5;
            // 
            // buttonClear
            // 
            buttonClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClear.Location = new Point(611, 41);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(75, 30);
            buttonClear.TabIndex = 7;
            buttonClear.Text = "Clear";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // buttonFilter
            // 
            buttonFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonFilter.Location = new Point(611, 10);
            buttonFilter.Name = "buttonFilter";
            buttonFilter.Size = new Size(75, 30);
            buttonFilter.TabIndex = 6;
            buttonFilter.Text = "Filter";
            buttonFilter.UseVisualStyleBackColor = true;
            buttonFilter.Click += buttonFilter_Click;
            // 
            // comboBoxUpDown
            // 
            comboBoxUpDown.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxUpDown.FormattingEnabled = true;
            comboBoxUpDown.Items.AddRange(new object[] { "NONE", "UP", "DOWN" });
            comboBoxUpDown.Location = new Point(285, 46);
            comboBoxUpDown.Name = "comboBoxUpDown";
            comboBoxUpDown.Size = new Size(100, 23);
            comboBoxUpDown.TabIndex = 5;
            // 
            // labelStaticUpDown
            // 
            labelStaticUpDown.AutoSize = true;
            labelStaticUpDown.Location = new Point(209, 49);
            labelStaticUpDown.Name = "labelStaticUpDown";
            labelStaticUpDown.Size = new Size(70, 15);
            labelStaticUpDown.TabIndex = 4;
            labelStaticUpDown.Text = "Up / Down :";
            // 
            // comboBoxSide
            // 
            comboBoxSide.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSide.FormattingEnabled = true;
            comboBoxSide.Items.AddRange(new object[] { "NONE", "BUY", "SELL" });
            comboBoxSide.Location = new Point(76, 46);
            comboBoxSide.Name = "comboBoxSide";
            comboBoxSide.Size = new Size(100, 23);
            comboBoxSide.TabIndex = 3;
            // 
            // labelStaticSide
            // 
            labelStaticSide.AutoSize = true;
            labelStaticSide.Location = new Point(38, 49);
            labelStaticSide.Name = "labelStaticSide";
            labelStaticSide.Size = new Size(35, 15);
            labelStaticSide.TabIndex = 2;
            labelStaticSide.Text = "Side :";
            // 
            // textBoxAddress
            // 
            textBoxAddress.Location = new Point(76, 10);
            textBoxAddress.Name = "textBoxAddress";
            textBoxAddress.Size = new Size(309, 23);
            textBoxAddress.TabIndex = 1;
            // 
            // labelStaticAddress
            // 
            labelStaticAddress.AutoSize = true;
            labelStaticAddress.Location = new Point(18, 13);
            labelStaticAddress.Name = "labelStaticAddress";
            labelStaticAddress.Size = new Size(55, 15);
            labelStaticAddress.TabIndex = 0;
            labelStaticAddress.Text = "Address :";
            // 
            // panelMain
            // 
            panelMain.Controls.Add(panelUser);
            panelMain.Controls.Add(panelTrades);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(447, 900);
            panelMain.TabIndex = 3;
            // 
            // panelUser
            // 
            panelUser.Controls.Add(listViewUser);
            panelUser.Controls.Add(panelControl);
            panelUser.Dock = DockStyle.Fill;
            panelUser.Location = new Point(0, 550);
            panelUser.Name = "panelUser";
            panelUser.Size = new Size(447, 350);
            panelUser.TabIndex = 3;
            // 
            // listViewUser
            // 
            listViewUser.Columns.AddRange(new ColumnHeader[] { columnName3, columnAddress3, columnEventCount, columnWinCount, columnLossCount, columnWinRate, columnWinAmount, columnLossAmount, columnTotalProfit2 });
            listViewUser.Dock = DockStyle.Fill;
            listViewUser.FullRowSelect = true;
            listViewUser.Location = new Point(0, 50);
            listViewUser.Name = "listViewUser";
            listViewUser.Size = new Size(447, 300);
            listViewUser.TabIndex = 8;
            listViewUser.UseCompatibleStateImageBehavior = false;
            listViewUser.View = View.Details;
            listViewUser.ColumnClick += listViewUser_ColumnClick;
            listViewUser.DoubleClick += listViewUser_DoubleClick;
            // 
            // columnName3
            // 
            columnName3.Text = "Name";
            columnName3.Width = 140;
            // 
            // columnAddress3
            // 
            columnAddress3.Text = "Address";
            columnAddress3.Width = 100;
            // 
            // columnEventCount
            // 
            columnEventCount.Text = "Event Count";
            columnEventCount.TextAlign = HorizontalAlignment.Right;
            columnEventCount.Width = 80;
            // 
            // columnWinCount
            // 
            columnWinCount.Text = "Win Count";
            columnWinCount.TextAlign = HorizontalAlignment.Right;
            columnWinCount.Width = 80;
            // 
            // columnLossCount
            // 
            columnLossCount.Text = "Loss Count";
            columnLossCount.TextAlign = HorizontalAlignment.Right;
            columnLossCount.Width = 80;
            // 
            // columnWinRate
            // 
            columnWinRate.Text = "Win Rate";
            columnWinRate.TextAlign = HorizontalAlignment.Right;
            columnWinRate.Width = 80;
            // 
            // columnWinAmount
            // 
            columnWinAmount.Text = "Win Amount";
            columnWinAmount.TextAlign = HorizontalAlignment.Right;
            columnWinAmount.Width = 80;
            // 
            // columnLossAmount
            // 
            columnLossAmount.Text = "Loss Amount";
            columnLossAmount.TextAlign = HorizontalAlignment.Right;
            columnLossAmount.Width = 85;
            // 
            // columnTotalProfit2
            // 
            columnTotalProfit2.Text = "Total Profit";
            columnTotalProfit2.TextAlign = HorizontalAlignment.Right;
            columnTotalProfit2.Width = 80;
            // 
            // panelControl
            // 
            panelControl.Dock = DockStyle.Top;
            panelControl.Location = new Point(0, 0);
            panelControl.Name = "panelControl";
            panelControl.Size = new Size(447, 50);
            panelControl.TabIndex = 7;
            // 
            // panelTrades
            // 
            panelTrades.Controls.Add(listViewTrade);
            panelTrades.Controls.Add(panelEventInfo);
            panelTrades.Dock = DockStyle.Top;
            panelTrades.Location = new Point(0, 0);
            panelTrades.Name = "panelTrades";
            panelTrades.Size = new Size(447, 550);
            panelTrades.TabIndex = 1;
            // 
            // listViewTrade
            // 
            listViewTrade.Columns.AddRange(new ColumnHeader[] { columnName, columnAddress, columnUpBuy, columnUpSell, columnUpProfit, columnDownBuy, columnDownSell, columnDownProfit, columnTotalProfit, columnTradeCount, columnTotalAmount });
            listViewTrade.Dock = DockStyle.Fill;
            listViewTrade.FullRowSelect = true;
            listViewTrade.Location = new Point(0, 80);
            listViewTrade.Name = "listViewTrade";
            listViewTrade.Size = new Size(447, 470);
            listViewTrade.TabIndex = 4;
            listViewTrade.UseCompatibleStateImageBehavior = false;
            listViewTrade.View = View.Details;
            listViewTrade.ColumnClick += listViewTrade_ColumnClick;
            listViewTrade.DoubleClick += listViewTrade_DoubleClick;
            // 
            // columnName
            // 
            columnName.Text = "Name";
            columnName.Width = 160;
            // 
            // columnAddress
            // 
            columnAddress.Text = "Address";
            columnAddress.Width = 80;
            // 
            // columnUpBuy
            // 
            columnUpBuy.Text = "Up Buy";
            columnUpBuy.TextAlign = HorizontalAlignment.Right;
            columnUpBuy.Width = 70;
            // 
            // columnUpSell
            // 
            columnUpSell.Text = "Up Sell";
            columnUpSell.TextAlign = HorizontalAlignment.Right;
            columnUpSell.Width = 70;
            // 
            // columnUpProfit
            // 
            columnUpProfit.Text = "Up Profit";
            columnUpProfit.TextAlign = HorizontalAlignment.Right;
            columnUpProfit.Width = 70;
            // 
            // columnDownBuy
            // 
            columnDownBuy.Text = "Down Buy";
            columnDownBuy.TextAlign = HorizontalAlignment.Right;
            columnDownBuy.Width = 70;
            // 
            // columnDownSell
            // 
            columnDownSell.Text = "Down Sell";
            columnDownSell.TextAlign = HorizontalAlignment.Right;
            columnDownSell.Width = 70;
            // 
            // columnDownProfit
            // 
            columnDownProfit.Text = "Down Profit";
            columnDownProfit.TextAlign = HorizontalAlignment.Right;
            columnDownProfit.Width = 80;
            // 
            // columnTotalProfit
            // 
            columnTotalProfit.Text = "Total Profit";
            columnTotalProfit.TextAlign = HorizontalAlignment.Right;
            columnTotalProfit.Width = 80;
            // 
            // columnTradeCount
            // 
            columnTradeCount.Text = "Trade Count";
            columnTradeCount.TextAlign = HorizontalAlignment.Right;
            columnTradeCount.Width = 80;
            // 
            // columnTotalAmount
            // 
            columnTotalAmount.Text = "Total Amount";
            columnTotalAmount.TextAlign = HorizontalAlignment.Right;
            columnTotalAmount.Width = 90;
            // 
            // panelEventInfo
            // 
            panelEventInfo.Controls.Add(richTextBoxTradeInfo);
            panelEventInfo.Controls.Add(richTextBoxEventInfo);
            panelEventInfo.Dock = DockStyle.Top;
            panelEventInfo.Location = new Point(0, 0);
            panelEventInfo.Name = "panelEventInfo";
            panelEventInfo.Size = new Size(447, 80);
            panelEventInfo.TabIndex = 3;
            // 
            // richTextBoxTradeInfo
            // 
            richTextBoxTradeInfo.Dock = DockStyle.Fill;
            richTextBoxTradeInfo.Location = new Point(500, 0);
            richTextBoxTradeInfo.Name = "richTextBoxTradeInfo";
            richTextBoxTradeInfo.ReadOnly = true;
            richTextBoxTradeInfo.Size = new Size(0, 80);
            richTextBoxTradeInfo.TabIndex = 2;
            richTextBoxTradeInfo.Text = "";
            // 
            // richTextBoxEventInfo
            // 
            richTextBoxEventInfo.Dock = DockStyle.Left;
            richTextBoxEventInfo.Location = new Point(0, 0);
            richTextBoxEventInfo.Name = "richTextBoxEventInfo";
            richTextBoxEventInfo.ReadOnly = true;
            richTextBoxEventInfo.Size = new Size(500, 80);
            richTextBoxEventInfo.TabIndex = 1;
            richTextBoxEventInfo.Text = "";
            // 
            // AnalysisPane
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMain);
            Controls.Add(panelRight);
            Name = "AnalysisPane";
            Size = new Size(1147, 900);
            Load += AnalysisPane_Load;
            panelRight.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelMain.ResumeLayout(false);
            panelUser.ResumeLayout(false);
            panelTrades.ResumeLayout(false);
            panelEventInfo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelRight;
        private Panel panelMain;
        private Panel panelUser;
        private Panel panelTrades;
        private Panel panelEventInfo;
        private ListView listViewTrade;
        private ColumnHeader columnName;
        private ColumnHeader columnAddress;
        private ColumnHeader columnUpBuy;
        private ColumnHeader columnUpSell;
        private ColumnHeader columnUpProfit;
        private ColumnHeader columnDownBuy;
        private ColumnHeader columnDownSell;
        private ColumnHeader columnDownProfit;
        private ColumnHeader columnTotalProfit;
        private ColumnHeader columnTradeCount;
        private RichTextBox richTextBoxEventInfo;
        private ColumnHeader columnTotalAmount;
        private RichTextBox richTextBoxTradeInfo;
        private ListView listViewTradeDetails;
        private ColumnHeader columnHash;
        private ColumnHeader columnTimestamp;
        private ColumnHeader columnName2;
        private ColumnHeader columnSide;
        private ColumnHeader columnUpDown;
        private ColumnHeader columnSize;
        private ColumnHeader columnPrice;
        private ColumnHeader columnAmount;
        private ColumnHeader columnTotalUpAmount;
        private ColumnHeader columnTotalDownAmount;
        private ColumnHeader columnTotalAmount2;
        private Panel panelFilter;
        private Label labelStaticAddress;
        private Label labelStaticSide;
        private TextBox textBoxAddress;
        private Button buttonClear;
        private Button buttonFilter;
        private ComboBox comboBoxUpDown;
        private Label labelStaticUpDown;
        private ComboBox comboBoxSide;
        private ListView listViewUser;
        private ColumnHeader columnName3;
        private ColumnHeader columnAddress3;
        private ColumnHeader columnEventCount;
        private ColumnHeader columnWinCount;
        private ColumnHeader columnLossCount;
        private ColumnHeader columnWinRate;
        private ColumnHeader columnWinAmount;
        private ColumnHeader columnLossAmount;
        private ColumnHeader columnTotalProfit2;
        private Panel panelControl;
    }
}
