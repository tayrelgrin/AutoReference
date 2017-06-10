using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace AutoReference
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            Assembly assemObj = Assembly.GetExecutingAssembly();
            Version v = assemObj.GetName().Version;
            
            int nMajorV = v.Major;
            int nMinorV = v.Minor;
            int nBuildV = v.Build;
            int nRevisionV = v.Revision;

            this.Text += " " + nMajorV.ToString() +"."+ nMinorV.ToString() +"."+ nBuildV.ToString() +"."+ nRevisionV.ToString();
        }

        private void button_MNR_Click(object sender, EventArgs e)
        {
            AutoRef cAuto = new AutoRef();
            this.Hide();
            cAuto.ShowDialog();
            Close();
        }

        private void button_MM_Click(object sender, EventArgs e)
        {
            ManualForm cManual = new ManualForm();
            this.Hide();
            cManual.ShowDialog();
            Close();
        }
    }
}
