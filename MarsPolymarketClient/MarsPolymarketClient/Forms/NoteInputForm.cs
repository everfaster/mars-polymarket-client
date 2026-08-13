using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MarsPolymarketClient.Forms
{
    public partial class NoteInputForm : Form
    {
        string _note = "";

        public NoteInputForm()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            _note = textBoxNote.Text.Replace(";", "");
        }

        public string GetNote() { return _note; }
    }
}
