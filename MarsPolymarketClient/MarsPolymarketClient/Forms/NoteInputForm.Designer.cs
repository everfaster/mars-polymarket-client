namespace MarsPolymarketClient.Forms
{
    partial class NoteInputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteInputForm));
            textBoxNote = new TextBox();
            labelStaticNote = new Label();
            buttonCancel = new Button();
            buttonOK = new Button();
            SuspendLayout();
            // 
            // textBoxNote
            // 
            textBoxNote.Location = new Point(97, 23);
            textBoxNote.Name = "textBoxNote";
            textBoxNote.Size = new Size(357, 31);
            textBoxNote.TabIndex = 23;
            // 
            // labelStaticNote
            // 
            labelStaticNote.AutoSize = true;
            labelStaticNote.Location = new Point(29, 23);
            labelStaticNote.Name = "labelStaticNote";
            labelStaticNote.Size = new Size(55, 25);
            labelStaticNote.TabIndex = 24;
            labelStaticNote.Text = "Note:";
            // 
            // buttonCancel
            // 
            buttonCancel.DialogResult = DialogResult.Cancel;
            buttonCancel.Location = new Point(334, 78);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new Size(120, 45);
            buttonCancel.TabIndex = 26;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            buttonOK.DialogResult = DialogResult.OK;
            buttonOK.Location = new Point(208, 78);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new Size(120, 45);
            buttonOK.TabIndex = 25;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // NoteInputForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 149);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(textBoxNote);
            Controls.Add(labelStaticNote);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "NoteInputForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Note Input Form";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxNote;
        private Label labelStaticNote;
        private Button buttonCancel;
        private Button buttonOK;
    }
}