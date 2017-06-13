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
            PrintNVMInfo();
            PrintItemVersion();
        }

        private void InitListView()
        {
            NVMValuesListView.FullRowSelect = true;
            NVMValuesListView.Columns.Add("Type", 140);
            NVMValuesListView.Columns.Add("Item", 200);
            NVMValuesListView.Columns.Add("Binary", 110);
            NVMValuesListView.Columns.Add("Hex", 110);
            NVMValuesListView.Columns.Add("Dec", 70);

            ItemversionListView.FullRowSelect = true;
            ItemversionListView.Columns.Add("Type", 200);
            ItemversionListView.Columns.Add("Item", 180);
        }

        private void PrintNVMInfo()
        {
            NVMValuesListView.BeginUpdate();
            BaseData cTemp = new BaseData();
            PrintNVMItemToListVeiw(m_cRefData.m_strPrjName, cTemp);
            PrintNVMItemToListVeiw("NVM",               m_cRefData.NVM);
            PrintNVMItemToListVeiw("ProjectID",         m_cRefData.CameraBuild);
            PrintNVMItemToListVeiw("Program Variant",   m_cRefData.ProgramVariant);
            PrintNVMItemToListVeiw("Integrator",        m_cRefData.Intergrator);
            PrintNVMItemToListVeiw("CameraBuild",       m_cRefData.CameraBuild);
            PrintNVMItemToListVeiw("Config",            m_cRefData.Config);
            PrintNVMItemToListVeiw("IRCF",              m_cRefData.IRCF);
            PrintNVMItemToListVeiw("Substrate",         m_cRefData.Substrate);
            PrintNVMItemToListVeiw("Sensor",            m_cRefData.Sensor);
            PrintNVMItemToListVeiw("Lens",              m_cRefData.Lens);
            PrintNVMItemToListVeiw("Flex",              m_cRefData.Flex);
            PrintNVMItemToListVeiw("Stiffener",         m_cRefData.Stiffener);
            PrintNVMItemToListVeiw("Software",          m_cRefData.SoftWare);

            PrintNVMItemToListVeiw("Lens Revision_Major", m_cRefData.LensComponent);
            PrintNVMItemToListVeiw("Lens Revision_Minor", m_cRefData.LensComponent);
            PrintNVMItemToListVeiw("Color Shading",       m_cRefData.ColorShading);
            PrintNVMItemToListVeiw("TraceabliiltyRev",    m_cRefData.Traceability);

            ListViewItem lvi = new ListViewItem(m_cRefData.m_strCISMask);
            NVMValuesListView.Items.Add(lvi);

            NVMValuesListView.EndUpdate();
        }

        private void PrintNVMItemToListVeiw(string inItemName, BaseData inData)
        {
            ListViewItem lvi = new ListViewItem(inItemName);
            if (inItemName != "Config")
            {
                lvi.SubItems.Add(inData.strVendorName);
                lvi.SubItems.Add(inData.strBinaryValue);
                string strHexValue = inData.strHexValue;
                lvi.SubItems.Add(strHexValue);
                if (inData.strBinaryValue != null)
                {
                    string strBinary = inData.strBinaryValue.Replace(" ","");
                    lvi.SubItems.Add(Convert.ToInt32(strBinary,2).ToString());
                }
            }
            
            NVMValuesListView.Items.Add(lvi);
        }

        private void PrintItemVersion()
        {
            PrintItemVersionItemToListView("Version",       m_cRefData.m_strItemVersion);
            PrintItemVersionItemToListView("ers_ver",       m_cRefData.m_strErs_ver);
            PrintItemVersionItemToListView("vsr_ver",       m_cRefData.m_strVsr_ver);
            PrintItemVersionItemToListView("build_num",     m_cRefData.m_strBuild_num);
            PrintItemVersionItemToListView("Build_Config",  m_cRefData.m_strBuild_Config);
            PrintItemVersionItemToListView("Flex_Config",   m_cRefData.m_strFlex_Config);
            PrintItemVersionItemToListView("Lens_Config",   m_cRefData.m_strLens_Config);
            PrintItemVersionItemToListView("Substrate_Config", m_cRefData.m_strSubstrate_Config);
            PrintItemVersionItemToListView("IRCF_Config",   m_cRefData.m_strIRCF_Config);
            PrintItemVersionItemToListView("Stiffener_Config", m_cRefData.m_strStiffener_Config);
        }

        private void PrintItemVersionItemToListView(string inItemName, string inItemValue)
        {
            ListViewItem lvi = new ListViewItem(inItemName);
            lvi.SubItems.Add(inItemValue);
            ItemversionListView.Items.Add(lvi);
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
