using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoReference
{
    public partial class ManualForm : Form
    {
        public ManualForm()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_ReferenceInput_Click(object sender, EventArgs e)
        {
            string selected = null;

            FolderBrowserDialog ofd = new FolderBrowserDialog();
            ofd.ShowDialog();
            selected = ofd.SelectedPath;
        }
    }
}
