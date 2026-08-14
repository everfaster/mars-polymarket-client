namespace MarsPolymarketClient.Containers.Events
{
    partial class EventsPanel
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
            panelTop = new Panel();
            listBoxEvent = new ListBox();
            panelBottom = new Panel();
            listViewSlug = new ListView();
            columnSlug = new ColumnHeader();
            columnStatus = new ColumnHeader();
            panelSlug = new Panel();
            buttonBulkAnalyze = new Button();
            buttonNext = new Button();
            buttonPrev = new Button();
            textBoxCount = new TextBox();
            labelStaticCount = new Label();
            buttonAnalyze = new Button();
            textBoxSlug = new TextBox();
            labelSlug = new Label();
            timerEvent = new System.Windows.Forms.Timer(components);
            checkBoxAutoAnalyze = new CheckBox();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            panelSlug.SuspendLayout();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(listBoxEvent);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(260, 382);
            panelTop.TabIndex = 1;
            // 
            // listBoxEvent
            // 
            listBoxEvent.Dock = DockStyle.Fill;
            listBoxEvent.FormattingEnabled = true;
            listBoxEvent.Location = new Point(0, 0);
            listBoxEvent.Name = "listBoxEvent";
            listBoxEvent.Size = new Size(260, 382);
            listBoxEvent.TabIndex = 1;
            listBoxEvent.DoubleClick += listBoxEvent_DoubleClick;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(listViewSlug);
            panelBottom.Controls.Add(panelSlug);
            panelBottom.Dock = DockStyle.Fill;
            panelBottom.Location = new Point(0, 382);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(260, 194);
            panelBottom.TabIndex = 2;
            // 
            // listViewSlug
            // 
            listViewSlug.Columns.AddRange(new ColumnHeader[] { columnSlug, columnStatus });
            listViewSlug.Dock = DockStyle.Fill;
            listViewSlug.FullRowSelect = true;
            listViewSlug.Location = new Point(0, 105);
            listViewSlug.Name = "listViewSlug";
            listViewSlug.Size = new Size(260, 89);
            listViewSlug.TabIndex = 5;
            listViewSlug.UseCompatibleStateImageBehavior = false;
            listViewSlug.View = View.Details;
            listViewSlug.DoubleClick += listViewSlug_DoubleClick;
            // 
            // columnSlug
            // 
            columnSlug.Text = "Slug";
            columnSlug.Width = 170;
            // 
            // columnStatus
            // 
            columnStatus.Text = "Status";
            columnStatus.Width = 70;
            // 
            // panelSlug
            // 
            panelSlug.Controls.Add(checkBoxAutoAnalyze);
            panelSlug.Controls.Add(buttonBulkAnalyze);
            panelSlug.Controls.Add(buttonNext);
            panelSlug.Controls.Add(buttonPrev);
            panelSlug.Controls.Add(textBoxCount);
            panelSlug.Controls.Add(labelStaticCount);
            panelSlug.Controls.Add(buttonAnalyze);
            panelSlug.Controls.Add(textBoxSlug);
            panelSlug.Controls.Add(labelSlug);
            panelSlug.Dock = DockStyle.Top;
            panelSlug.Location = new Point(0, 0);
            panelSlug.Name = "panelSlug";
            panelSlug.Size = new Size(260, 105);
            panelSlug.TabIndex = 1;
            // 
            // buttonBulkAnalyze
            // 
            buttonBulkAnalyze.Location = new Point(92, 67);
            buttonBulkAnalyze.Name = "buttonBulkAnalyze";
            buttonBulkAnalyze.Size = new Size(75, 30);
            buttonBulkAnalyze.TabIndex = 10;
            buttonBulkAnalyze.Text = "Bulk Anal.";
            buttonBulkAnalyze.UseVisualStyleBackColor = true;
            buttonBulkAnalyze.Click += buttonBulkAnalyze_Click;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(132, 4);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(30, 30);
            buttonNext.TabIndex = 9;
            buttonNext.Text = ">";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // buttonPrev
            // 
            buttonPrev.Location = new Point(100, 4);
            buttonPrev.Name = "buttonPrev";
            buttonPrev.Size = new Size(30, 30);
            buttonPrev.TabIndex = 8;
            buttonPrev.Text = "<";
            buttonPrev.UseVisualStyleBackColor = true;
            buttonPrev.Click += buttonPrev_Click;
            // 
            // textBoxCount
            // 
            textBoxCount.Location = new Point(46, 8);
            textBoxCount.Name = "textBoxCount";
            textBoxCount.Size = new Size(50, 23);
            textBoxCount.TabIndex = 7;
            textBoxCount.Text = "300";
            textBoxCount.TextAlign = HorizontalAlignment.Right;
            // 
            // labelStaticCount
            // 
            labelStaticCount.AutoSize = true;
            labelStaticCount.Location = new Point(4, 11);
            labelStaticCount.Name = "labelStaticCount";
            labelStaticCount.Size = new Size(43, 15);
            labelStaticCount.TabIndex = 6;
            labelStaticCount.Text = "Count:";
            // 
            // buttonAnalyze
            // 
            buttonAnalyze.Location = new Point(173, 67);
            buttonAnalyze.Name = "buttonAnalyze";
            buttonAnalyze.Size = new Size(75, 30);
            buttonAnalyze.TabIndex = 5;
            buttonAnalyze.Text = "Analyze";
            buttonAnalyze.UseVisualStyleBackColor = true;
            buttonAnalyze.Click += buttonAnalyze_Click;
            // 
            // textBoxSlug
            // 
            textBoxSlug.Location = new Point(46, 38);
            textBoxSlug.Name = "textBoxSlug";
            textBoxSlug.Size = new Size(202, 23);
            textBoxSlug.TabIndex = 4;
            // 
            // labelSlug
            // 
            labelSlug.AutoSize = true;
            labelSlug.Location = new Point(4, 41);
            labelSlug.Name = "labelSlug";
            labelSlug.Size = new Size(33, 15);
            labelSlug.TabIndex = 3;
            labelSlug.Text = "Slug:";
            // 
            // timerEvent
            // 
            timerEvent.Enabled = true;
            timerEvent.Interval = 10000;
            timerEvent.Tick += timerEvent_Tick;
            // 
            // checkBoxAutoAnalyze
            // 
            checkBoxAutoAnalyze.AutoSize = true;
            checkBoxAutoAnalyze.Checked = true;
            checkBoxAutoAnalyze.CheckState = CheckState.Checked;
            checkBoxAutoAnalyze.Location = new Point(168, 10);
            checkBoxAutoAnalyze.Name = "checkBoxAutoAnalyze";
            checkBoxAutoAnalyze.Size = new Size(82, 19);
            checkBoxAutoAnalyze.TabIndex = 11;
            checkBoxAutoAnalyze.Text = "Auto Anal.";
            checkBoxAutoAnalyze.UseVisualStyleBackColor = true;
            checkBoxAutoAnalyze.CheckedChanged += checkBoxAutoAnalyze_CheckedChanged;
            // 
            // EventsPanel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Name = "EventsPanel";
            Size = new Size(260, 576);
            Load += EventsPanel_Load;
            panelTop.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelSlug.ResumeLayout(false);
            panelSlug.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelTop;
        private ListBox listBoxEvent;
        private Panel panelBottom;
        private Panel panelSlug;
        private Button buttonAnalyze;
        private TextBox textBoxSlug;
        private Label labelSlug;
        private ListView listViewSlug;
        private ColumnHeader columnSlug;
        private ColumnHeader columnStatus;
        private TextBox textBoxCount;
        private Label labelStaticCount;
        private Button buttonBulkAnalyze;
        private Button buttonNext;
        private Button buttonPrev;
        private System.Windows.Forms.Timer timerEvent;
        private CheckBox checkBoxAutoAnalyze;
    }
}
