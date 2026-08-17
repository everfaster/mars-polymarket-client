namespace MarsPolymarketClient.Forms
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            textBoxPassword = new TextBox();
            buttonLogin = new Button();
            buttonOffline = new Button();
            SuspendLayout();
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(9, 12);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(155, 23);
            textBoxPassword.TabIndex = 0;
            textBoxPassword.KeyUp += textBoxPassword_KeyUp;
            // 
            // buttonLogin
            // 
            buttonLogin.Location = new Point(170, 9);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(75, 30);
            buttonLogin.TabIndex = 1;
            buttonLogin.Text = "Login";
            buttonLogin.UseVisualStyleBackColor = true;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // buttonOffline
            // 
            buttonOffline.Location = new Point(251, 9);
            buttonOffline.Name = "buttonOffline";
            buttonOffline.Size = new Size(75, 30);
            buttonOffline.TabIndex = 2;
            buttonOffline.Text = "Go Offline";
            buttonOffline.UseVisualStyleBackColor = true;
            buttonOffline.Click += buttonOffline_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 45);
            Controls.Add(buttonOffline);
            Controls.Add(buttonLogin);
            Controls.Add(textBoxPassword);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxPassword;
        private Button buttonLogin;
        private Button buttonOffline;
    }
}