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
        private string m_strFilePath;
        private ReferenceData m_cRefData;

        public PrintMidResultForm(string inPath,ref ReferenceData inData)
        {
            m_strFilePath = inPath;
            m_cRefData = inData;

            InitializeComponent();
            InitListView();
        }

        private void InitListView()
        {
            ItemversionListView.FullRowSelect = true;
            ItemversionListView.Columns.Add("Type", 200);
            ItemversionListView.Columns.Add("Item", 180);
            ItemversionListView.Columns.Add("Binary", 100);
            ItemversionListView.Columns.Add("Hex", 100);

            ValuesListView.FullRowSelect = true;
            ValuesListView.Columns.Add("Type", 200);
            ValuesListView.Columns.Add("Item", 180);
            ValuesListView.Columns.Add("Binary", 100);
            ValuesListView.Columns.Add("Hex", 100);
            ValuesListView.Columns.Add("Dec", 100);
        }

        private void FinalCancleBuitton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FinalOKButton_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
            Environment.Exit(0);
        }

    }
}
