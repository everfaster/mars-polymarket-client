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
            components = new System.ComponentModel.Container();
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
            richTextBoxAddress = new RichTextBox();
            buttonClear = new Button();
            buttonFilter = new Button();
            comboBoxUpDown = new ComboBox();
            labelStaticUpDown = new Label();
            comboBoxSide = new ComboBox();
            labelStaticSide = new Label();
            labelStaticAddress = new Label();
            panelMain = new Panel();
            panelUser = new Panel();
            tabControlTrade = new TabControl();
            tabPageUserSummary = new TabPage();
            listViewUser = new ListView();
            columnName3 = new ColumnHeader();
            columnAddress3 = new ColumnHeader();
            columnEventCount = new ColumnHeader();
            columnWinCount = new ColumnHeader();
            columnLossCount = new ColumnHeader();
            columnWinRate = new ColumnHeader();
            columnWinAmount = new ColumnHeader();
            columnLossAmount = new ColumnHeader();
            columnHeaderFee2 = new ColumnHeader();
            columnTotalProfit2 = new ColumnHeader();
            tabPageSumaryDetails = new TabPage();
            listViewSummaryDetails = new ListView();
            columnSlug = new ColumnHeader();
            columnAddress4 = new ColumnHeader();
            columnUpProfit2 = new ColumnHeader();
            columnDownProfit2 = new ColumnHeader();
            columnTradeCount2 = new ColumnHeader();
            columnTradeAmount2 = new ColumnHeader();
            columnFee3 = new ColumnHeader();
            columnTotalProfit3 = new ColumnHeader();
            panelControl = new Panel();
            checkBoxFee = new CheckBox();
            textBoxTotalProfit = new TextBox();
            textBoxWinRate = new TextBox();
            textBoxEventCount = new TextBox();
            labelStaticTotalProfit = new Label();
            buttonClear2 = new Button();
            buttonFilter2 = new Button();
            richTextBoxAddress2 = new RichTextBox();
            labelStaticWinRate = new Label();
            labelStaticEventcount = new Label();
            label3 = new Label();
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
            contextMenuStripTrade = new ContextMenuStrip(components);
            setAddressesToFilterToolStripMenuItem = new ToolStripMenuItem();
            addAddressesToFilterToolStripMenuItem = new ToolStripMenuItem();
            contextMenuStripUser = new ContextMenuStrip(components);
            toolStripMenuItemUserSetAddress = new ToolStripMenuItem();
            toolStripMenuItemUserAddAddress = new ToolStripMenuItem();
            copyAddressToolStripMenuItem = new ToolStripMenuItem();
            copyAddressToolStripMenuItem1 = new ToolStripMenuItem();
            panelRight.SuspendLayout();
            panelFilter.SuspendLayout();
            panelMain.SuspendLayout();
            panelUser.SuspendLayout();
            tabControlTrade.SuspendLayout();
            tabPageUserSummary.SuspendLayout();
            tabPageSumaryDetails.SuspendLayout();
            panelControl.SuspendLayout();
            panelTrades.SuspendLayout();
            panelEventInfo.SuspendLayout();
            contextMenuStripTrade.SuspendLayout();
            contextMenuStripUser.SuspendLayout();
            SuspendLayout();
            // 
            // panelRight
            // 
            panelRight.Controls.Add(listViewTradeDetails);
            panelRight.Controls.Add(panelFilter);
            panelRight.Dock = DockStyle.Right;
            panelRight.Location = new Point(800, 0);
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
            panelFilter.Controls.Add(richTextBoxAddress);
            panelFilter.Controls.Add(buttonClear);
            panelFilter.Controls.Add(buttonFilter);
            panelFilter.Controls.Add(comboBoxUpDown);
            panelFilter.Controls.Add(labelStaticUpDown);
            panelFilter.Controls.Add(comboBoxSide);
            panelFilter.Controls.Add(labelStaticSide);
            panelFilter.Controls.Add(labelStaticAddress);
            panelFilter.Dock = DockStyle.Top;
            panelFilter.Location = new Point(0, 0);
            panelFilter.Name = "panelFilter";
            panelFilter.Size = new Size(700, 80);
            panelFilter.TabIndex = 5;
            // 
            // richTextBoxAddress
            // 
            richTextBoxAddress.Location = new Point(79, 13);
            richTextBoxAddress.Name = "richTextBoxAddress";
            richTextBoxAddress.Size = new Size(304, 56);
            richTextBoxAddress.TabIndex = 8;
            richTextBoxAddress.Text = "";
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
            comboBoxUpDown.Location = new Point(479, 44);
            comboBoxUpDown.Name = "comboBoxUpDown";
            comboBoxUpDown.Size = new Size(100, 23);
            comboBoxUpDown.TabIndex = 5;
            // 
            // labelStaticUpDown
            // 
            labelStaticUpDown.AutoSize = true;
            labelStaticUpDown.Location = new Point(403, 47);
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
            comboBoxSide.Location = new Point(479, 14);
            comboBoxSide.Name = "comboBoxSide";
            comboBoxSide.Size = new Size(100, 23);
            comboBoxSide.TabIndex = 3;
            // 
            // labelStaticSide
            // 
            labelStaticSide.AutoSize = true;
            labelStaticSide.Location = new Point(402, 18);
            labelStaticSide.Name = "labelStaticSide";
            labelStaticSide.Size = new Size(35, 15);
            labelStaticSide.TabIndex = 2;
            labelStaticSide.Text = "Side :";
            // 
            // labelStaticAddress
            // 
            labelStaticAddress.AutoSize = true;
            labelStaticAddress.Location = new Point(18, 15);
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
            panelMain.Size = new Size(800, 900);
            panelMain.TabIndex = 3;
            // 
            // panelUser
            // 
            panelUser.Controls.Add(tabControlTrade);
            panelUser.Controls.Add(panelControl);
            panelUser.Dock = DockStyle.Fill;
            panelUser.Location = new Point(0, 450);
            panelUser.Name = "panelUser";
            panelUser.Size = new Size(800, 450);
            panelUser.TabIndex = 3;
            // 
            // tabControlTrade
            // 
            tabControlTrade.Controls.Add(tabPageUserSummary);
            tabControlTrade.Controls.Add(tabPageSumaryDetails);
            tabControlTrade.Dock = DockStyle.Fill;
            tabControlTrade.Location = new Point(0, 90);
            tabControlTrade.Name = "tabControlTrade";
            tabControlTrade.SelectedIndex = 0;
            tabControlTrade.Size = new Size(800, 360);
            tabControlTrade.TabIndex = 10;
            // 
            // tabPageUserSummary
            // 
            tabPageUserSummary.Controls.Add(listViewUser);
            tabPageUserSummary.Location = new Point(4, 24);
            tabPageUserSummary.Name = "tabPageUserSummary";
            tabPageUserSummary.Padding = new Padding(3);
            tabPageUserSummary.Size = new Size(792, 332);
            tabPageUserSummary.TabIndex = 0;
            tabPageUserSummary.Text = "User Summary";
            tabPageUserSummary.UseVisualStyleBackColor = true;
            // 
            // listViewUser
            // 
            listViewUser.Columns.AddRange(new ColumnHeader[] { columnName3, columnAddress3, columnEventCount, columnWinCount, columnLossCount, columnWinRate, columnWinAmount, columnLossAmount, columnHeaderFee2, columnTotalProfit2 });
            listViewUser.Dock = DockStyle.Fill;
            listViewUser.FullRowSelect = true;
            listViewUser.Location = new Point(3, 3);
            listViewUser.Name = "listViewUser";
            listViewUser.Size = new Size(786, 326);
            listViewUser.TabIndex = 9;
            listViewUser.UseCompatibleStateImageBehavior = false;
            listViewUser.View = View.Details;
            listViewUser.ColumnClick += listViewUser_ColumnClick;
            listViewUser.DoubleClick += listViewUser_DoubleClick;
            listViewUser.MouseUp += listViewUser_MouseUp;
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
            // columnHeaderFee2
            // 
            columnHeaderFee2.Text = "Fee";
            columnHeaderFee2.TextAlign = HorizontalAlignment.Right;
            // 
            // columnTotalProfit2
            // 
            columnTotalProfit2.Text = "Total Profit";
            columnTotalProfit2.TextAlign = HorizontalAlignment.Right;
            columnTotalProfit2.Width = 80;
            // 
            // tabPageSumaryDetails
            // 
            tabPageSumaryDetails.Controls.Add(listViewSummaryDetails);
            tabPageSumaryDetails.Location = new Point(4, 24);
            tabPageSumaryDetails.Name = "tabPageSumaryDetails";
            tabPageSumaryDetails.Padding = new Padding(3);
            tabPageSumaryDetails.Size = new Size(792, 332);
            tabPageSumaryDetails.TabIndex = 1;
            tabPageSumaryDetails.Text = "Summary Details";
            tabPageSumaryDetails.UseVisualStyleBackColor = true;
            // 
            // listViewSummaryDetails
            // 
            listViewSummaryDetails.Columns.AddRange(new ColumnHeader[] { columnSlug, columnAddress4, columnUpProfit2, columnDownProfit2, columnTradeCount2, columnTradeAmount2, columnFee3, columnTotalProfit3 });
            listViewSummaryDetails.Dock = DockStyle.Fill;
            listViewSummaryDetails.FullRowSelect = true;
            listViewSummaryDetails.Location = new Point(3, 3);
            listViewSummaryDetails.Name = "listViewSummaryDetails";
            listViewSummaryDetails.Size = new Size(786, 326);
            listViewSummaryDetails.TabIndex = 10;
            listViewSummaryDetails.UseCompatibleStateImageBehavior = false;
            listViewSummaryDetails.View = View.Details;
            listViewSummaryDetails.ColumnClick += listViewSummaryDetails_ColumnClick;
            listViewSummaryDetails.DoubleClick += listViewSummaryDetails_DoubleClick;
            // 
            // columnSlug
            // 
            columnSlug.Text = "Slug";
            columnSlug.Width = 180;
            // 
            // columnAddress4
            // 
            columnAddress4.Text = "Name";
            columnAddress4.Width = 100;
            // 
            // columnUpProfit2
            // 
            columnUpProfit2.Text = "Up Profit";
            columnUpProfit2.TextAlign = HorizontalAlignment.Right;
            columnUpProfit2.Width = 80;
            // 
            // columnDownProfit2
            // 
            columnDownProfit2.Text = "Down Profit";
            columnDownProfit2.TextAlign = HorizontalAlignment.Right;
            columnDownProfit2.Width = 80;
            // 
            // columnTradeCount2
            // 
            columnTradeCount2.Text = "Trade Count";
            columnTradeCount2.TextAlign = HorizontalAlignment.Right;
            columnTradeCount2.Width = 80;
            // 
            // columnTradeAmount2
            // 
            columnTradeAmount2.Text = "Trade Amount";
            columnTradeAmount2.TextAlign = HorizontalAlignment.Right;
            columnTradeAmount2.Width = 90;
            // 
            // columnFee3
            // 
            columnFee3.Text = "Fee";
            columnFee3.TextAlign = HorizontalAlignment.Right;
            // 
            // columnTotalProfit3
            // 
            columnTotalProfit3.Text = "Total Profit";
            columnTotalProfit3.TextAlign = HorizontalAlignment.Right;
            columnTotalProfit3.Width = 80;
            // 
            // panelControl
            // 
            panelControl.Controls.Add(checkBoxFee);
            panelControl.Controls.Add(textBoxTotalProfit);
            panelControl.Controls.Add(textBoxWinRate);
            panelControl.Controls.Add(textBoxEventCount);
            panelControl.Controls.Add(labelStaticTotalProfit);
            panelControl.Controls.Add(buttonClear2);
            panelControl.Controls.Add(buttonFilter2);
            panelControl.Controls.Add(richTextBoxAddress2);
            panelControl.Controls.Add(labelStaticWinRate);
            panelControl.Controls.Add(labelStaticEventcount);
            panelControl.Controls.Add(label3);
            panelControl.Dock = DockStyle.Top;
            panelControl.Location = new Point(0, 0);
            panelControl.Name = "panelControl";
            panelControl.Size = new Size(800, 90);
            panelControl.TabIndex = 7;
            // 
            // checkBoxFee
            // 
            checkBoxFee.AutoSize = true;
            checkBoxFee.Checked = true;
            checkBoxFee.CheckState = CheckState.Checked;
            checkBoxFee.Location = new Point(602, 9);
            checkBoxFee.Name = "checkBoxFee";
            checkBoxFee.Size = new Size(44, 19);
            checkBoxFee.TabIndex = 19;
            checkBoxFee.Text = "Fee";
            checkBoxFee.UseVisualStyleBackColor = true;
            // 
            // textBoxTotalProfit
            // 
            textBoxTotalProfit.Location = new Point(500, 56);
            textBoxTotalProfit.Name = "textBoxTotalProfit";
            textBoxTotalProfit.Size = new Size(80, 23);
            textBoxTotalProfit.TabIndex = 18;
            // 
            // textBoxWinRate
            // 
            textBoxWinRate.Location = new Point(500, 32);
            textBoxWinRate.Name = "textBoxWinRate";
            textBoxWinRate.Size = new Size(80, 23);
            textBoxWinRate.TabIndex = 17;
            // 
            // textBoxEventCount
            // 
            textBoxEventCount.Location = new Point(500, 8);
            textBoxEventCount.Name = "textBoxEventCount";
            textBoxEventCount.Size = new Size(80, 23);
            textBoxEventCount.TabIndex = 16;
            // 
            // labelStaticTotalProfit
            // 
            labelStaticTotalProfit.AutoSize = true;
            labelStaticTotalProfit.Location = new Point(401, 58);
            labelStaticTotalProfit.Name = "labelStaticTotalProfit";
            labelStaticTotalProfit.Size = new Size(84, 15);
            labelStaticTotalProfit.TabIndex = 15;
            labelStaticTotalProfit.Text = "Total Profit >=";
            // 
            // buttonClear2
            // 
            buttonClear2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonClear2.Location = new Point(712, 45);
            buttonClear2.Name = "buttonClear2";
            buttonClear2.Size = new Size(75, 30);
            buttonClear2.TabIndex = 14;
            buttonClear2.Text = "Clear";
            buttonClear2.UseVisualStyleBackColor = true;
            buttonClear2.Click += buttonClear2_Click;
            // 
            // buttonFilter2
            // 
            buttonFilter2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonFilter2.Location = new Point(712, 10);
            buttonFilter2.Name = "buttonFilter2";
            buttonFilter2.Size = new Size(75, 30);
            buttonFilter2.TabIndex = 13;
            buttonFilter2.Text = "Filter";
            buttonFilter2.UseVisualStyleBackColor = true;
            buttonFilter2.Click += buttonFilter2_Click;
            // 
            // richTextBoxAddress2
            // 
            richTextBoxAddress2.Location = new Point(68, 10);
            richTextBoxAddress2.Name = "richTextBoxAddress2";
            richTextBoxAddress2.Size = new Size(304, 70);
            richTextBoxAddress2.TabIndex = 12;
            richTextBoxAddress2.Text = "";
            // 
            // labelStaticWinRate
            // 
            labelStaticWinRate.AutoSize = true;
            labelStaticWinRate.Location = new Point(412, 34);
            labelStaticWinRate.Name = "labelStaticWinRate";
            labelStaticWinRate.Size = new Size(73, 15);
            labelStaticWinRate.TabIndex = 11;
            labelStaticWinRate.Text = "Win Rate >=";
            // 
            // labelStaticEventcount
            // 
            labelStaticEventcount.AutoSize = true;
            labelStaticEventcount.Location = new Point(394, 10);
            labelStaticEventcount.Name = "labelStaticEventcount";
            labelStaticEventcount.Size = new Size(91, 15);
            labelStaticEventcount.TabIndex = 10;
            labelStaticEventcount.Text = "Event Count >=";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(7, 12);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 9;
            label3.Text = "Address :";
            // 
            // panelTrades
            // 
            panelTrades.Controls.Add(listViewTrade);
            panelTrades.Controls.Add(panelEventInfo);
            panelTrades.Dock = DockStyle.Top;
            panelTrades.Location = new Point(0, 0);
            panelTrades.Name = "panelTrades";
            panelTrades.Size = new Size(800, 450);
            panelTrades.TabIndex = 1;
            // 
            // listViewTrade
            // 
            listViewTrade.Columns.AddRange(new ColumnHeader[] { columnName, columnAddress, columnUpBuy, columnUpSell, columnUpProfit, columnDownBuy, columnDownSell, columnDownProfit, columnTotalProfit, columnTradeCount, columnTotalAmount });
            listViewTrade.Dock = DockStyle.Fill;
            listViewTrade.FullRowSelect = true;
            listViewTrade.Location = new Point(0, 80);
            listViewTrade.Name = "listViewTrade";
            listViewTrade.Size = new Size(800, 370);
            listViewTrade.TabIndex = 4;
            listViewTrade.UseCompatibleStateImageBehavior = false;
            listViewTrade.View = View.Details;
            listViewTrade.ColumnClick += listViewTrade_ColumnClick;
            listViewTrade.DoubleClick += listViewTrade_DoubleClick;
            listViewTrade.MouseUp += listViewTrade_MouseUp;
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
            panelEventInfo.Size = new Size(800, 80);
            panelEventInfo.TabIndex = 3;
            // 
            // richTextBoxTradeInfo
            // 
            richTextBoxTradeInfo.Dock = DockStyle.Fill;
            richTextBoxTradeInfo.Location = new Point(500, 0);
            richTextBoxTradeInfo.Name = "richTextBoxTradeInfo";
            richTextBoxTradeInfo.ReadOnly = true;
            richTextBoxTradeInfo.Size = new Size(300, 80);
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
            // contextMenuStripTrade
            // 
            contextMenuStripTrade.Items.AddRange(new ToolStripItem[] { setAddressesToFilterToolStripMenuItem, addAddressesToFilterToolStripMenuItem, copyAddressToolStripMenuItem1 });
            contextMenuStripTrade.Name = "contextMenuStripTrade";
            contextMenuStripTrade.Size = new Size(196, 92);
            // 
            // setAddressesToFilterToolStripMenuItem
            // 
            setAddressesToFilterToolStripMenuItem.Name = "setAddressesToFilterToolStripMenuItem";
            setAddressesToFilterToolStripMenuItem.Size = new Size(195, 22);
            setAddressesToFilterToolStripMenuItem.Text = "Set Addresses to Filter";
            setAddressesToFilterToolStripMenuItem.Click += setAddressesToFilterToolStripMenuItem_Click;
            // 
            // addAddressesToFilterToolStripMenuItem
            // 
            addAddressesToFilterToolStripMenuItem.Name = "addAddressesToFilterToolStripMenuItem";
            addAddressesToFilterToolStripMenuItem.Size = new Size(195, 22);
            addAddressesToFilterToolStripMenuItem.Text = "Add Addresses to Filter";
            addAddressesToFilterToolStripMenuItem.Click += addAddressesToFilterToolStripMenuItem_Click;
            // 
            // contextMenuStripUser
            // 
            contextMenuStripUser.Items.AddRange(new ToolStripItem[] { toolStripMenuItemUserSetAddress, toolStripMenuItemUserAddAddress, copyAddressToolStripMenuItem });
            contextMenuStripUser.Name = "contextMenuStripTrade";
            contextMenuStripUser.Size = new Size(196, 70);
            // 
            // toolStripMenuItemUserSetAddress
            // 
            toolStripMenuItemUserSetAddress.Name = "toolStripMenuItemUserSetAddress";
            toolStripMenuItemUserSetAddress.Size = new Size(195, 22);
            toolStripMenuItemUserSetAddress.Text = "Set Addresses to Filter";
            toolStripMenuItemUserSetAddress.Click += toolStripMenuItemUserSetAddress_Click;
            // 
            // toolStripMenuItemUserAddAddress
            // 
            toolStripMenuItemUserAddAddress.Name = "toolStripMenuItemUserAddAddress";
            toolStripMenuItemUserAddAddress.Size = new Size(195, 22);
            toolStripMenuItemUserAddAddress.Text = "Add Addresses to Filter";
            toolStripMenuItemUserAddAddress.Click += toolStripMenuItemUserAddAddress_Click;
            // 
            // copyAddressToolStripMenuItem
            // 
            copyAddressToolStripMenuItem.Name = "copyAddressToolStripMenuItem";
            copyAddressToolStripMenuItem.Size = new Size(195, 22);
            copyAddressToolStripMenuItem.Text = "Copy Address";
            copyAddressToolStripMenuItem.Click += copyAddressToolStripMenuItem_Click;
            // 
            // copyAddressToolStripMenuItem1
            // 
            copyAddressToolStripMenuItem1.Name = "copyAddressToolStripMenuItem1";
            copyAddressToolStripMenuItem1.Size = new Size(195, 22);
            copyAddressToolStripMenuItem1.Text = "Copy Address";
            copyAddressToolStripMenuItem1.Click += copyAddressToolStripMenuItem1_Click;
            // 
            // AnalysisPane
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelMain);
            Controls.Add(panelRight);
            Name = "AnalysisPane";
            Size = new Size(1500, 900);
            Load += AnalysisPane_Load;
            panelRight.ResumeLayout(false);
            panelFilter.ResumeLayout(false);
            panelFilter.PerformLayout();
            panelMain.ResumeLayout(false);
            panelUser.ResumeLayout(false);
            tabControlTrade.ResumeLayout(false);
            tabPageUserSummary.ResumeLayout(false);
            tabPageSumaryDetails.ResumeLayout(false);
            panelControl.ResumeLayout(false);
            panelControl.PerformLayout();
            panelTrades.ResumeLayout(false);
            panelEventInfo.ResumeLayout(false);
            contextMenuStripTrade.ResumeLayout(false);
            contextMenuStripUser.ResumeLayout(false);
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
        private Button buttonClear;
        private Button buttonFilter;
        private ComboBox comboBoxUpDown;
        private Label labelStaticUpDown;
        private ComboBox comboBoxSide;
        private Panel panelControl;
        private TabControl tabControlTrade;
        private TabPage tabPageUserSummary;
        private TabPage tabPageSumaryDetails;
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
        private ListView listViewSummaryDetails;
        private ColumnHeader columnSlug;
        private ColumnHeader columnAddress4;
        private ColumnHeader columnUpProfit2;
        private ColumnHeader columnDownProfit2;
        private ColumnHeader columnTotalProfit3;
        private ColumnHeader columnTradeCount2;
        private ColumnHeader columnTradeAmount2;
        private RichTextBox richTextBoxAddress;
        private Label labelStaticTotalProfit;
        private Button buttonClear2;
        private Button buttonFilter2;
        private RichTextBox richTextBoxAddress2;
        private Label labelStaticWinRate;
        private Label labelStaticEventcount;
        private Label label3;
        private TextBox textBoxTotalProfit;
        private TextBox textBoxWinRate;
        private TextBox textBoxEventCount;
        private ContextMenuStrip contextMenuStripTrade;
        private ToolStripMenuItem setAddressesToFilterToolStripMenuItem;
        private ToolStripMenuItem addAddressesToFilterToolStripMenuItem;
        private ContextMenuStrip contextMenuStripUser;
        private ToolStripMenuItem toolStripMenuItemUserSetAddress;
        private ToolStripMenuItem toolStripMenuItemUserAddAddress;
        private ColumnHeader columnHeaderFee2;
        private ColumnHeader columnFee3;
        private CheckBox checkBoxFee;
        private ToolStripMenuItem copyAddressToolStripMenuItem1;
        private ToolStripMenuItem copyAddressToolStripMenuItem;
    }
}
