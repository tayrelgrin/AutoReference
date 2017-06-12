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
    public partial class ManualForm : Form
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        
        private string m_strRefPath;

        public ManualForm()
        {
            InitializeComponent();
            m_strRefPath = null;
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button_ReferenceInput_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();
            string strRefFilePath = null;
            string strItemVersionPath = null;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Ref, register file unifomity 확인

                m_strRefPath = ofd.SelectedPath.ToString();

                // Ref, register file path 
                GetRefItemversionFilePath(m_strRefPath, ref strRefFilePath, ref strItemVersionPath);

                ReadAndPrintNVMInformation(strRefFilePath);
                ReadAndPrintItemVersionINI(strItemVersionPath);

                m_strRefPath = ofd.SelectedPath;
            }

        }

        private void GetRefItemversionFilePath(string inRootPath, ref string outRefFilePath, ref string outItemFilePath)
        {
            string[] strDirArray = System.IO.Directory.GetDirectories(inRootPath);

            foreach (string strTemp in strDirArray)
            {
                string strTempItemPath = System.IO.Path.Combine(strTemp, "ItemVersion.ini");
                if (System.IO.File.Exists(strTempItemPath))
                {
                    outItemFilePath = strTempItemPath;
                    string[] strTempDirName = strTemp.Split('\\');
                    int nArrayIndex = strTempDirName.Length;
                    string strRefName = strTempDirName[nArrayIndex - 1];
                    outRefFilePath = System.IO.Path.Combine(strTemp, strRefName+".ini");
                    break;
                }
            }
        }

        private void ReadAndPrintNVMInformation(string inFilePath)
        {
             // ref file read
            StringBuilder temp = new StringBuilder(255);
            GetPrivateProfileString("OTP_WRITE", "NVM", "", temp, 255, inFilePath);
            NVMTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "ProjectID", "", temp, 255, inFilePath);
            ProjectIDTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "Project_Version", "", temp, 255, inFilePath);
            Project_VersionTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "Integrator", "", temp, 255, inFilePath);
            IntegratorTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "CameraBuild", "", temp, 255, inFilePath);
            CameraBuildTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "Config", "", temp, 255, inFilePath);
            ConfigTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "IRCF", "", temp, 255, inFilePath);
            IRCFTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "Substrate", "", temp, 255, inFilePath);
            SubstrateTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "SensorType", "", temp, 255, inFilePath);
            SensorTypeTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "Lens", "", temp, 255, inFilePath);
            LensTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "Flex", "", temp, 255, inFilePath);
            FlexTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "Stiffener", "", temp, 255, inFilePath);
            StiffenerTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "Carrier", "", temp, 255, inFilePath);
            CarrierTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "Process_Control_Plan_Revision", "", temp, 255, inFilePath);
            Process_ControlTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "Process_DOE_code", "", temp, 255, inFilePath);
            Process_DOE_codeTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "Sotfware", "", temp, 255, inFilePath);
            SotfwareTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "Waiver", "", temp, 255, inFilePath);
            WaiverTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "TestStation1", "", temp, 255, inFilePath);
            TestStation1TextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "TestStation2", "", temp, 255, inFilePath);
            TestStation2TextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "TestStation3", "", temp, 255, inFilePath);
            TestStation3TextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "TestStation4", "", temp, 255, inFilePath);
            TestStation4TextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "TestStation5", "", temp, 255, inFilePath);
            TestStation5TextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "LensComponent_Revision_Major", "", temp, 255, inFilePath);
            LensComponent_R_MajorTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "LensComponent_Revision_Minor", "", temp, 255, inFilePath);
            LensComponent_R_MinorTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "ColorShading_Revision", "", temp, 255, inFilePath);
            ColorShading_RevTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "Traceability_Version", "", temp, 255, inFilePath);
            Traceability_VersionTextBox.Text = temp.ToString();

            GetPrivateProfileString("OTP_WRITE", "CISMaskID", "", temp, 2, inFilePath);
            CISMaskIDTextBox.Text = temp.ToString();

            GetPrivateProfileString("LOG", "LAST_STRING", "", temp, 255, inFilePath);
            LAST_STRINGTextBox.Text = temp.ToString();

            GetPrivateProfileString("LOG", "FIRST_STRING", "", temp, 255, inFilePath);
            FIRST_STRINGTextBox.Text = temp.ToString();

            GetPrivateProfileString("LOG", "SERIAL_COUNT", "", temp, 255, inFilePath);
            SERIAL_COUNTTextBox.Text = temp.ToString();
            
        }

        private void ReadAndPrintItemVersionINI(string inFilePath)
        {
            StringBuilder temp = new StringBuilder(255);

            GetPrivateProfileString("LOG", "VERSION", "", temp, 255, inFilePath);
            ItemVERSIONtextBox.Text = temp.ToString();

            GetPrivateProfileString("LOG", "ers_ver", "", temp, 255, inFilePath);
            Ers_verTextBox.Text = temp.ToString();

            GetPrivateProfileString("LOG", "vsr_ver", "", temp, 255, inFilePath);
            Vsr_verTextBox.Text = temp.ToString();

            GetPrivateProfileString("LOG", "build_num", "", temp, 255, inFilePath);
            Build_numTextBox.Text = temp.ToString();

            GetPrivateProfileString("LOG", "Build_Config", "", temp, 255, inFilePath);
            Build_ConfigTextBox.Text = temp.ToString();

            GetPrivateProfileString("LOG", "Flex_Config", "", temp, 255, inFilePath);
            Flex_ConfigTextBox.Text = temp.ToString();

            GetPrivateProfileString("LOG", "Lens_Config", "", temp, 255, inFilePath);
            Lens_ConfigTextBox.Text = temp.ToString();

            GetPrivateProfileString("LOG", "Substrate_Config", "", temp, 255, inFilePath);
            Substrate_ConfigTextBox.Text = temp.ToString();

            GetPrivateProfileString("LOG", "IRCF_Config", "", temp, 255, inFilePath);
            IRCF_ConfigTextBox.Text = temp.ToString();

            GetPrivateProfileString("LOG", "Stiffener_Config", "", temp, 255, inFilePath);
            Stiffener_ConfigTextBox.Text = temp.ToString();

            GetPrivateProfileString("LOG", "AA_Machine", "", temp, 255, inFilePath);
            AA_MachineTextBox.Text = temp.ToString();
        }

        private void FileCopy(string inSourcePath, string inTargetPath)
        {
            string strFileName;
            string strDestFile;
            string strDestDir;

            if (!System.IO.Directory.Exists(inTargetPath))
            {
                System.IO.Directory.CreateDirectory(inTargetPath);
            }

            if (System.IO.Directory.Exists(inSourcePath))
            {
                string[] strDirArray = System.IO.Directory.GetDirectories(inSourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in strDirArray)
                {
                    if (!System.IO.Directory.Exists(s))
                    {
                        System.IO.Directory.CreateDirectory(s);
                    }

                    string[] strSubDirArray = System.IO.Directory.GetDirectories(s);

                    if (strSubDirArray.Length > 0)
                    {
                        foreach (string subs in strSubDirArray)
                        {
                            string[] strFiles = System.IO.Directory.GetFiles(subs);
                            // Use static Path methods to extract only the file name from the path.
                            strFileName = System.IO.Path.GetFileName(subs);
                            strDestFile = System.IO.Path.Combine(inTargetPath, strFileName);
                            System.IO.File.Copy(subs, strDestFile, true);
                        }
                    }
                    else
                    {
                        string[] strFiles = System.IO.Directory.GetFiles(s);
                        // Use static Path methods to extract only the file name from the path.
                        foreach (string filename in strFiles)
                        {
                           
                            strFileName = filename.Replace(inSourcePath + "\\", "");
                            string[] strTemp = strFileName.Split('\\');

                            int nSizeDestDir = strTemp.Length;

                            strDestDir = strFileName.Replace(strTemp[nSizeDestDir - 1], "");
                            strDestDir = System.IO.Path.Combine(inTargetPath, strDestDir);

                            if (!System.IO.Directory.Exists(strDestDir))
                            {
                                System.IO.Directory.CreateDirectory(strDestDir);
                            }

                            strDestFile = System.IO.Path.Combine(inTargetPath, strFileName);
                            System.IO.File.Copy(filename, strDestFile, true);
                        }                        
                    }                    
                }
            }
        }

        private void button_Make_Click(object sender, EventArgs e)
        {
            if (ReferenceNameTextBox.Text != "")
            {
                string strTemp = ReferenceNameTextBox.Text;
                string[] strTempSplit = strTemp.Split('_');

                string strNewDirName = System.IO.Directory.GetCurrentDirectory() + "\\Result\\" + strTempSplit[0] + "-"+ strTempSplit[4];

                if (m_strRefPath != null)
                {
                    FileCopy(m_strRefPath, strNewDirName);
                }
            }            
        }
    }
}
