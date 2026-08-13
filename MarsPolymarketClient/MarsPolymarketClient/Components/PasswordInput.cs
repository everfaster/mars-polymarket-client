using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsPolymarketClient.Components
{
    public static class PasswordInput
    {
        public static string Show(string title, string prompt)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();

            form.Text = title;
            form.Width = 300;
            form.Height = 150;
            form.StartPosition = FormStartPosition.CenterScreen;

            label.Text = prompt;
            label.Left = 10;
            label.Top = 10;
            label.Width = 260;

            textBox.Left = 10;
            textBox.Top = 35;
            textBox.Width = 260;
            textBox.UseSystemPasswordChar = true; // shows *

            buttonOk.Text = "OK";
            buttonOk.Left = 200;
            buttonOk.Top = 70;
            buttonOk.Click += (sender, e) => form.Close();

            form.AcceptButton = buttonOk;
            form.Controls.Add(label);
            form.Controls.Add(textBox);
            form.Controls.Add(buttonOk);

            form.ShowDialog();

            return textBox.Text;
        }
    }
}
