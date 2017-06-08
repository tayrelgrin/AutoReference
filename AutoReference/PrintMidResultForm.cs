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
    public partial class PrintMidResultForm : Form
    {
        public PrintMidResultForm()
        {
            InitializeComponent();
        }

        private void FinalCancleBuitton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void PrintMidResultForm_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FinalOKButton_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

    }
}
