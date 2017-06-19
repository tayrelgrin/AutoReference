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
    public partial class PrintMidResultForm : Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        
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
            ListViewItem lvi = new ListViewItem("Project ");
            lvi.SubItems.Add(m_cRefData.m_strPrjName);
            NVMValuesListView.Items.Add(lvi);

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

            PrintNVMItemToListVeiw("Lens Revision_Major", m_cRefData.LensComponent_Major);
            PrintNVMItemToListVeiw("Lens Revision_Minor", m_cRefData.LensComponent_Minor);
            PrintNVMItemToListVeiw("Color Shading",       m_cRefData.ColorShading);
            PrintNVMItemToListVeiw("TraceabliiltyRev",    m_cRefData.Traceability);

            lvi = new ListViewItem("CISMask ");
            lvi.SubItems.Add(m_cRefData.m_strCISMask);
            NVMValuesListView.Items.Add(lvi);

            NVMValuesListView.EndUpdate();
        }

        private void PrintNVMItemToListVeiw(string inItemName, BaseData inData)
        {
            ListViewItem lvi = new ListViewItem(inItemName);

            lvi.SubItems.Add(inData.strVendorName);
            lvi.SubItems.Add(inData.strBinaryValue);
            string strHexValue = inData.strHexValue;
            lvi.SubItems.Add(strHexValue);
            if (inData.strBinaryValue != null)
            {
                string strBinary = inData.strBinaryValue.Replace(" ", "");
                lvi.SubItems.Add(Convert.ToInt32(strBinary, 2).ToString());
            }
            
            NVMValuesListView.Items.Add(lvi);
        }

        private void PrintItemVersion()
        {
            PrintItemVersionItemToListView("Version",       m_cRefData.m_strSWVersion);
            PrintItemVersionItemToListView("ers_ver",       m_cRefData.m_strErs_ver);
            PrintItemVersionItemToListView("vsr_ver",       m_cRefData.m_strVsr_ver);
            PrintItemVersionItemToListView("build_num",     m_cRefData.m_strBuild_num);
            PrintItemVersionItemToListView("Build_Config",  m_cRefData.m_strBuild_Config);
            PrintItemVersionItemToListView("Flex_Config",   m_cRefData.Flex.strVendorName);
            PrintItemVersionItemToListView("Lens_Config",   m_cRefData.Lens.strVendorName);
            PrintItemVersionItemToListView("Substrate_Config", m_cRefData.Substrate.strVendorName);
            PrintItemVersionItemToListView("IRCF_Config", m_cRefData.IRCF.strVendorName);
            PrintItemVersionItemToListView("Stiffener_Config", m_cRefData.Stiffener.strVendorName);
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

            this.Dispose();
        }

        private void DirFileNameChange(string inRootPath)
        {
            if (!System.IO.Directory.Exists(inRootPath))
            {
                return;
            }

            if (System.IO.Directory.Exists(inRootPath))
            {
                string[] strDirArray = System.IO.Directory.GetDirectories(inRootPath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in strDirArray)
                {
                    string[] strSubDirArray = System.IO.Directory.GetDirectories(s);

                    if (strSubDirArray.Length > 0)
                    {
                        foreach (string subs in strSubDirArray)
                        {
                            string[] strSplit_s = subs.Split('\\');
                            string strRefFileName = strSplit_s[strSplit_s.Length - 1] + ".ini";
                            string strRegisterName = strSplit_s[strSplit_s.Length - 1] + "_Register.ini";
                            string[] strTempArray = strSplit_s[strSplit_s.Length - 1].Split('_');
                            string strTestName = strTempArray[5];
//                             string strNewRefFileName = ReferenceNameTextBox.Text + "_" + strTestName + "_" + Reference_VersionTextBox.Text + ".ini";
//                             string strNewRegisterName = ReferenceNameTextBox.Text + "_" + strTestName + "_" + Reference_VersionTextBox.Text + "_Register.ini";
//                             string strNewDirName = subs.Replace(strSplit_s[strSplit_s.Length - 1], ReferenceNameTextBox.Text + "_" + strTestName + "_" + Reference_VersionTextBox.Text);
//                             strRefFileName = System.IO.Path.Combine(subs, strRefFileName);
//                             strRegisterName = System.IO.Path.Combine(subs, strRegisterName);
//                             strNewRefFileName = System.IO.Path.Combine(subs, strNewRefFileName);
//                             strNewRegisterName = System.IO.Path.Combine(subs, strNewRegisterName);
//                             // ref 파일 
//                             System.IO.File.Move(strRefFileName, strNewRefFileName);
//                             System.IO.File.Move(strRegisterName, strNewRegisterName);
// 
//                             System.IO.Directory.Move(subs, strNewDirName);
                        }
                    }
                    else
                    {
                        string[] strSplit_s = s.Split('\\');
                        string strRefFileName = strSplit_s[strSplit_s.Length - 1] + ".ini";
                        string strRegisterName = strSplit_s[strSplit_s.Length - 1] + "_Register.ini";
                        string[] strTempArray = strSplit_s[strSplit_s.Length - 1].Split('_');
                        string strTestName = strTempArray[5];
//                         string strNewRefFileName = ReferenceNameTextBox.Text + "_" + strTestName + "_" + Reference_VersionTextBox.Text + ".ini";
//                         string strNewRegisterName = ReferenceNameTextBox.Text + "_" + strTestName + "_" + Reference_VersionTextBox.Text + "_Register.ini";
//                         string strNewDirName = s.Replace(strSplit_s[strSplit_s.Length - 1], ReferenceNameTextBox.Text + "_" + strTestName + "_" + Reference_VersionTextBox.Text);

//                         strRefFileName = System.IO.Path.Combine(s, strRefFileName);
//                         strRegisterName = System.IO.Path.Combine(s, strRegisterName);
//                         strNewRefFileName = System.IO.Path.Combine(s, strNewRefFileName);
//                         strNewRegisterName = System.IO.Path.Combine(s, strNewRegisterName);
// 
//                         System.IO.File.Move(strRefFileName, strNewRefFileName);
//                         System.IO.File.Move(strRegisterName, strNewRegisterName);
// 
//                         System.IO.Directory.Move(s, strNewDirName);
                    }
                }
            }
        }

        private void InputDataToFile(string inRootPath)
        {
            if (!System.IO.Directory.Exists(inRootPath))
            {
                return;
            }

            if (System.IO.Directory.Exists(inRootPath))
            {
                string[] strDirArray = System.IO.Directory.GetDirectories(inRootPath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in strDirArray)
                {
                    string[] strSubDirArray = System.IO.Directory.GetDirectories(s);
                    string[] strSplit_s = s.Split('\\');
                    string strRefFileName = strSplit_s[strSplit_s.Length - 1] + ".ini";

                    if (strSubDirArray.Length > 0)
                    {
                        foreach (string subs in strSubDirArray)
                        {
                            string[] strFiles = System.IO.Directory.GetFiles(subs);

                            foreach (string filename in strFiles)
                            {
                                if (filename.IndexOf("ItemVersion.ini") != -1)
                                {
                                    InputItemVersionInfoToFile(filename);
                                }
                                // ref 파일 
                                else if (filename.IndexOf(strRefFileName) != -1)
                                {
                                    InputNVMInfoToFile(filename);
                                }

                            }
                        }
                    }
                    else
                    {
                        string[] strFiles = System.IO.Directory.GetFiles(s);
                        // Use static Path methods to extract only the file name from the path.
                        foreach (string filename in strFiles)
                        {
                            if (filename.IndexOf("ItemVersion.ini") != -1)
                            {
                                InputItemVersionInfoToFile(filename);
                            }
                            // ref 파일
                            else if (filename.IndexOf(strRefFileName) != -1)
                            {
                                InputNVMInfoToFile(filename);
                            }
                        }
                    }
                }
            }
        }

        private void InputItemVersionInfoToFile(string inFilePath)
        {
            string temp = m_cRefData.m_strItemVersion;
            WritePrivateProfileString("LOG", "VERSION", temp, inFilePath);

            temp = m_cRefData.m_strErs_ver;            
            WritePrivateProfileString("LOG", "ers_ver", temp, inFilePath);

            temp = m_cRefData.m_strVsr_ver;
            WritePrivateProfileString("LOG", "vsr_ver", temp, inFilePath);

            temp = m_cRefData.m_strBuild_num;
            WritePrivateProfileString("LOG", "build_num", temp, inFilePath);

            temp = m_cRefData.m_strBuild_Config;
            WritePrivateProfileString("LOG", "Build_Config", temp, inFilePath);

            temp = m_cRefData.Flex.strVendorName;
            WritePrivateProfileString("LOG", "Flex_Config", temp, inFilePath);

            temp = m_cRefData.Lens.strVendorName;
            WritePrivateProfileString("LOG", "Lens_Config", temp, inFilePath);

            temp = m_cRefData.Substrate.strVendorName;
            WritePrivateProfileString("LOG", "Substrate_Config", temp, inFilePath);

            temp = m_cRefData.IRCF.strVendorName;
            WritePrivateProfileString("LOG", "IRCF_Config", temp, inFilePath);

            temp = m_cRefData.Stiffener.strVendorName;
            WritePrivateProfileString("LOG", "Stiffener_Config", temp, inFilePath);
        }

        private void InputNVMInfoToFile(string inFilePath)
        {
            string temp = m_cRefData.NVM.strBinaryValue;
            int nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "NVM", nValue.ToString(), inFilePath);

            temp = m_cRefData.CameraPrj.strBinaryValue;
            nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "ProjectID", nValue.ToString(), inFilePath);

            temp = m_cRefData.ProgramVariant.strBinaryValue;
            nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "Project_Version", nValue.ToString(), inFilePath);

            temp = m_cRefData.Intergrator.strBinaryValue;
            nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "Integrator", nValue.ToString(), inFilePath);

            temp = m_cRefData.CameraBuild.strBinaryValue;
            nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "CameraBuild", nValue.ToString(), inFilePath);

            temp = m_cRefData.Config.strBinaryValue;
            nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "Config", nValue.ToString(), inFilePath);

            temp = m_cRefData.IRCF.strBinaryValue;
            nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "IRCF", nValue.ToString(), inFilePath);

            temp = m_cRefData.Substrate.strBinaryValue;
            nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "Substrate", nValue.ToString(), inFilePath);

            temp = m_cRefData.Sensor.strBinaryValue;
            nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "SensorType", nValue.ToString(), inFilePath);

            temp = m_cRefData.Lens.strBinaryValue;
            nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "Lens", nValue.ToString(), inFilePath);

            temp = m_cRefData.Flex.strBinaryValue;
            nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "Flex", nValue.ToString(), inFilePath);

            temp = m_cRefData.Stiffener.strBinaryValue;
            nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "Stiffener", nValue.ToString(), inFilePath);

            temp = m_cRefData.Carrier.strBinaryValue;
            nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "Carrier", nValue.ToString(), inFilePath);


            temp = m_cRefData.m_strLensComponent;
            nValue = Convert.ToInt32(temp[2].ToString(), 16);

            WritePrivateProfileString("OTP_WRITE", "LensComponent_Revision_Major", nValue.ToString(), inFilePath);
            nValue = Convert.ToInt32(temp[3].ToString(), 16);
            WritePrivateProfileString("OTP_WRITE", "LensComponent_Revision_Minor", nValue.ToString(), inFilePath);

            temp = m_cRefData.ColorShading.strBinaryValue;
            nValue = Convert.ToInt32(temp.Replace(" ", ""), 2);
            WritePrivateProfileString("OTP_WRITE", "ColorShading_Revision", nValue.ToString(), inFilePath);

            temp = m_cRefData.m_strCISMask;
            WritePrivateProfileString("OTP_WRITE", "CISMaskID", nValue.ToString(), inFilePath);

            temp = m_cRefData.m_strEEEE;
            WritePrivateProfileString("LOG", "LAST_STRING", nValue.ToString(), inFilePath);
        }
    }
}
