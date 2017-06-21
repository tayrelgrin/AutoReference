using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AutoReference
{
    public partial class ShowVendors : Form
    {
        
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public ShowVendors()
        {
            InitializeComponent();

            VendorListView.Columns.Add("Type", 180);
            VendorListView.Columns.Add("Vendor Name", 200);
            LoadDataFromFileAndPrint();
            
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void LoadDataFromFileAndPrint()
        {
            string strFilePath;
            strFilePath = Application.StartupPath + "\\Data\\VendorName.ini";

            PrintVendorNameToListView("Flex",       strFilePath);
            PrintVendorNameToListView("Lens",       strFilePath);
            PrintVendorNameToListView("Substrate",  strFilePath);
            PrintVendorNameToListView("IRCF",       strFilePath);
            PrintVendorNameToListView("Stiffener",  strFilePath);
            PrintVendorNameToListView("Carrier",    strFilePath);
        }

        private void PrintVendorNameToListView(string inBigItem, string strFilePath)
        {
            int nIndex = 0;
            StringBuilder strbReadValue = new StringBuilder();
            GetPrivateProfileString(inBigItem, "Count", "0", strbReadValue, 255, strFilePath);
            Int32.TryParse(strbReadValue.ToString(), out nIndex);

            ListViewItem lvi = new ListViewItem(inBigItem);

            for (int i = 0; i < nIndex; i++)
            {
                GetPrivateProfileString(inBigItem, i.ToString(), "0", strbReadValue, 255, strFilePath);
                if(lvi == null)
                    lvi = new ListViewItem("");
                lvi.SubItems.Add(strbReadValue.ToString());
                VendorListView.Items.Add(lvi);
                lvi = null;
            }
        }
    }
}
