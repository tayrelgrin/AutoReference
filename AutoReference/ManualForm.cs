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
        private string m_strPreText;
        private bool m_bReadFlag;
        private List<string> m_FlexVendorList = new List<string>();
        private List<string> m_LensVendorList = new List<string>();
        private List<string> m_SubstrateVendorList = new List<string>();
        private List<string> m_IRCFVendorList = new List<string>();
        private List<string> m_StiffenerVendorList = new List<string>();

        public ManualForm()
        {
            InitializeComponent();
            m_strRefPath = null;
            m_bReadFlag = false;
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
                // Ref, register file uniformity 확인

                // Ref Dir 선택
                m_strRefPath = ofd.SelectedPath.ToString();

                // Ref, register file path 
                GetRefItemversionFilePath(m_strRefPath, ref strRefFilePath, ref strItemVersionPath);
                GetReferenceNameAndPrint(m_strRefPath, strRefFilePath);
                ReadAndPrintNVMInformation(strRefFilePath);
                ReadAndPrintItemVersionINI(strItemVersionPath);

                m_strRefPath = ofd.SelectedPath;
            }
        }

        private void GetReferenceNameAndPrint(string inRefRootPath, string inRefFilePath)
        {
            string strTemp = inRefFilePath.Replace(inRefRootPath+"\\", "");

            string[] strTempSplit = strTemp.Split('\\');
            string[] strRefSplit = strTempSplit[0].Split('_');
            int nCount = strRefSplit.Length;

            string strRefHead = strRefSplit[0] + "_" + strRefSplit[1] + "_" + strRefSplit[2] + "_" + strRefSplit[3] + "_" + strRefSplit[4];
            ReferenceNameTextBox.Text = strRefHead;
            string strRefTail = strTempSplit[0].Replace(strRefHead + "_" + strRefSplit[5] + "_", "");
            Reference_VersionTextBox.Text = strRefTail;
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
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            string strMessage = "Make Reference?";

            if (MessageBox.Show(strMessage, "", buttons) == System.Windows.Forms.DialogResult.Yes)
            {
                if (ReferenceNameTextBox.Text != "")
                {
                    string strTemp = ReferenceNameTextBox.Text;
                    string[] strTempSplit = strTemp.Split('_');

                    string strNewDirName = System.IO.Directory.GetCurrentDirectory() + "\\Result\\" + ReferenceNameTextBox.Text;
                    string strCheckExist = strNewDirName;

                    int nCount = 1;
                    while (true)
                    {
                        if (System.IO.Directory.Exists(strCheckExist))
                        {
                            strCheckExist = strNewDirName + "(" + nCount.ToString() + ")";
                            nCount++;
                        }
                        else
                        {
                            strNewDirName = strCheckExist;
                            break;
                        }
                    }

                    if (m_strRefPath != null)
                    {
                        // ref copy
                        FileCopy(m_strRefPath, strNewDirName);

                        // Dir Name Change
                        DirFileNameChange(strNewDirName);

                        InputDataToFile(strNewDirName);

                        strMessage = "Complete Reference Make.\n Open the Result folder?";
                        if (MessageBox.Show(strMessage, "", buttons) == System.Windows.Forms.DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(strNewDirName + "\\");
                        }

                        WriteTimeToFile();
                    }
                }
                else
                {
                    MessageBox.Show("Reference Name is Empty");
                }
            }
        }

        private void WriteTimeToFile()
        {
            string strData = System.DateTime.Now.ToString("yyyy/MM/dd, hh:mm:ss");

            string strFilePath;
            strFilePath = Application.StartupPath + "\\Data\\VendorName.ini";

            WritePrivateProfileString("Log", "Menual " + strData, "1", strFilePath);
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
                            string strNewRefFileName = ReferenceNameTextBox.Text + "_" + strTestName + "_" + Reference_VersionTextBox.Text + "_" + strTempArray[strTempArray.Length - 1] + ".ini";
                            string strNewRegisterName = ReferenceNameTextBox.Text + "_" + strTestName + "_" + Reference_VersionTextBox.Text + "_" + strTempArray[strTempArray.Length - 1] + "_Register.ini";
                            string strNewDirName = subs.Replace(strSplit_s[strSplit_s.Length - 1], ReferenceNameTextBox.Text + "_" + strTestName + "_" + Reference_VersionTextBox.Text)+"_" + strTempArray[strTempArray.Length - 1];

                            strRefFileName = System.IO.Path.Combine(subs, strRefFileName);
                            strRegisterName = System.IO.Path.Combine(subs, strRegisterName);
                            strNewRefFileName = System.IO.Path.Combine(subs, strNewRefFileName);
                            strNewRegisterName = System.IO.Path.Combine(subs, strNewRegisterName);
                            // ref 파일 
                            System.IO.File.Move(strRefFileName, strNewRefFileName);
                            System.IO.File.Move(strRegisterName, strNewRegisterName);
                            if (subs != strNewDirName)
                                System.IO.Directory.Move(subs,strNewDirName);
                        }
                    }
                    else
                    {
                        string[] strSplit_s = s.Split('\\');
                        string strRefFileName = strSplit_s[strSplit_s.Length - 1] + ".ini";
                        string strRegisterName = strSplit_s[strSplit_s.Length - 1] + "_Register.ini";
                        string[] strTempArray = strSplit_s[strSplit_s.Length - 1].Split('_');
                        string strTestName = strTempArray[5];
                        string strNewRefFileName = ReferenceNameTextBox.Text + "_" + strTestName + "_" + Reference_VersionTextBox.Text + ".ini";
                        string strNewRegisterName = ReferenceNameTextBox.Text + "_" + strTestName + "_" + Reference_VersionTextBox.Text + "_Register.ini";
                        string strNewDirName = s.Replace(strSplit_s[strSplit_s.Length - 1], ReferenceNameTextBox.Text + "_" + strTestName + "_" + Reference_VersionTextBox.Text);

                        strRefFileName = System.IO.Path.Combine(s, strRefFileName);
                        strRegisterName = System.IO.Path.Combine(s, strRegisterName);
                        strNewRefFileName = System.IO.Path.Combine(s, strNewRefFileName);
                        strNewRegisterName = System.IO.Path.Combine(s, strNewRegisterName);

                        System.IO.File.Move(strRefFileName, strNewRefFileName);
                        System.IO.File.Move(strRegisterName, strNewRegisterName);

                        if (s != strNewDirName)
                            System.IO.Directory.Move(s, strNewDirName);
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
            string temp = ItemVERSIONtextBox.Text;
            WritePrivateProfileString("LOG", "VERSION", temp, inFilePath);
            
            temp = Ers_verTextBox.Text;
            WritePrivateProfileString("LOG", "ers_ver", temp, inFilePath);
            
            temp = Vsr_verTextBox.Text;
            WritePrivateProfileString("LOG", "vsr_ver", temp, inFilePath);

            temp = Build_numTextBox.Text;
            WritePrivateProfileString("LOG", "build_num",temp, inFilePath);
             
            temp = Build_ConfigTextBox.Text;
            if (inFilePath.IndexOf("NO-SPEC") != -1)
                temp += "_NO-SPEC";
            if (inFilePath.IndexOf("REL") != -1)
                temp += "_POST-REL";
            WritePrivateProfileString("LOG", "Build_Config", temp,inFilePath);
           
            temp = Flex_ConfigTextBox.Text;
            WritePrivateProfileString("LOG", "Flex_Config", temp, inFilePath);
             
            temp = Lens_ConfigTextBox.Text;
            WritePrivateProfileString("LOG", "Lens_Config", temp, inFilePath);

            temp = Substrate_ConfigTextBox.Text;
            WritePrivateProfileString("LOG", "Substrate_Config", temp, inFilePath);

            temp = IRCF_ConfigTextBox.Text;
            WritePrivateProfileString("LOG", "IRCF_Config", temp, inFilePath);

            temp = Stiffener_ConfigTextBox.Text;
            WritePrivateProfileString("LOG", "Stiffener_Config", temp, inFilePath);
            
            temp = AA_MachineTextBox.Text;
            WritePrivateProfileString("LOG", "AA_Machine", temp, inFilePath);
            
        }

        private void InputNVMInfoToFile(string inFilePath)
        {
            string temp = NVMTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "NVM", temp, inFilePath);

            temp = ProjectIDTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "ProjectID", temp, inFilePath);
            
            temp = Project_VersionTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "Project_Version", temp, inFilePath);
            
            temp = IntegratorTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "Integrator", temp, inFilePath);
            
            temp = CameraBuildTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "CameraBuild", temp, inFilePath);
            
            temp = ConfigTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "Config", temp, inFilePath);
            
            temp = IRCFTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "IRCF", temp,inFilePath);
            
            temp = SubstrateTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "Substrate",  temp,inFilePath);
            
            temp = SensorTypeTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "SensorType", temp, inFilePath);
            
            temp = LensTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "Lens", temp, inFilePath);
            
            temp = FlexTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "Flex", temp, inFilePath);
            
            temp = StiffenerTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "Stiffener", temp, inFilePath);
            
            temp = CarrierTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "Carrier", temp, inFilePath);
            
            temp = Process_ControlTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "Process_Control_Plan_Revision",temp, inFilePath);
            
            temp = Process_DOE_codeTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "Process_DOE_code", temp, inFilePath);
            
            temp = SotfwareTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "Sotfware", temp, inFilePath);
            
            temp = WaiverTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "Waiver", temp, inFilePath);
            
            temp = LensComponent_R_MajorTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "LensComponent_Revision_Major", temp, inFilePath);
            
            temp = LensComponent_R_MinorTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "LensComponent_Revision_Minor", temp,  inFilePath);
            
            temp = ColorShading_RevTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "ColorShading_Revision", temp, inFilePath);
            
            temp = Traceability_VersionTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "Traceability_Version", temp, inFilePath);
            
            temp = CISMaskIDTextBox.Text;
            WritePrivateProfileString("OTP_WRITE", "CISMaskID", temp, inFilePath);
            
            temp = LAST_STRINGTextBox.Text;
            WritePrivateProfileString("LOG", "LAST_STRING",  temp, inFilePath);
            
            temp = FIRST_STRINGTextBox.Text;
            WritePrivateProfileString("LOG", "FIRST_STRING", temp,  inFilePath);
            
            temp = SERIAL_COUNTTextBox.Text;
            WritePrivateProfileString("LOG", "SERIAL_COUNT", temp, inFilePath);
        }

        private void NVMTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = NVMTextBox.Text;
        }

        private void NVMTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != NVMTextBox.Text)
                NVMTextBox.BackColor = Color.BurlyWood;
        }

        private void ItemVERSIONtextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = ItemVERSIONtextBox.Text;
        }

        private void ItemVERSIONtextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != ItemVERSIONtextBox.Text)
                ItemVERSIONtextBox.BackColor = Color.BurlyWood;
        }

        private void Ers_verTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = Ers_verTextBox.Text;
        }

        private void Ers_verTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != Ers_verTextBox.Text)
                Ers_verTextBox.BackColor = Color.BurlyWood;
        }

        private void Vsr_verTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = Vsr_verTextBox.Text;
        }

        private void Vsr_verTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != Vsr_verTextBox.Text)
                Vsr_verTextBox.BackColor = Color.BurlyWood;
        }

        private void Build_numTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = Build_numTextBox.Text;
        }

        private void Build_numTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != Build_numTextBox.Text)
                Build_numTextBox.BackColor = Color.BurlyWood;
        }

        private void Build_ConfigTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = Build_ConfigTextBox.Text;
        }

        private void Build_ConfigTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != Build_ConfigTextBox.Text)
                Build_ConfigTextBox.BackColor = Color.BurlyWood;
        }

        private void Flex_ConfigTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = Flex_ConfigTextBox.Text;
        }

        private void Flex_ConfigTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != Flex_ConfigTextBox.Text)
                Flex_ConfigTextBox.BackColor = Color.BurlyWood;

            if (VendorNamecheckBox.Checked)
            {
                bool bResult = false;
                foreach (string strCompareData in m_FlexVendorList)
                {
                    if (strCompareData == Flex_ConfigTextBox.Text)
                    {
                        bResult = true;
                        break;
                    }
                }

                if (bResult == false)
                {
                    Flex_ConfigTextBox.BackColor = Color.Red;
                }
            }
        }

        private void Lens_ConfigTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = Lens_ConfigTextBox.Text;
        }

        private void Lens_ConfigTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != Lens_ConfigTextBox.Text)
                Lens_ConfigTextBox.BackColor = Color.BurlyWood;

            if (VendorNamecheckBox.Checked)
            {
                bool bResult = false;
                foreach (string strCompareData in m_LensVendorList)
                {
                    if (strCompareData == Lens_ConfigTextBox.Text)
                    {
                        bResult = true;
                        break;
                    }
                }

                if (bResult == false)
                {
                    Lens_ConfigTextBox.BackColor = Color.Red;
                }
            }
        }

        private void Substrate_ConfigTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = Substrate_ConfigTextBox.Text;
        }

        private void Substrate_ConfigTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != Substrate_ConfigTextBox.Text)
                Substrate_ConfigTextBox.BackColor = Color.BurlyWood;

            if (VendorNamecheckBox.Checked)
            {
                bool bResult = false;
                foreach (string strCompareData in m_SubstrateVendorList)
                {
                    if (strCompareData == Substrate_ConfigTextBox.Text)
                    {
                        bResult = true;
                        break;
                    }
                }

                if (bResult == false)
                {
                    Substrate_ConfigTextBox.BackColor = Color.Red;
                }
            }
        }

        private void IRCF_ConfigTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = IRCF_ConfigTextBox.Text;
        }

        private void IRCF_ConfigTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != IRCF_ConfigTextBox.Text)
                IRCF_ConfigTextBox.BackColor = Color.BurlyWood;

            if (VendorNamecheckBox.Checked)
            {
                bool bResult = false;
                foreach (string strCompareData in m_IRCFVendorList)
                {
                    if (strCompareData == IRCF_ConfigTextBox.Text)
                    {
                        bResult = true;
                        break;
                    }
                }

                if (bResult == false)
                {
                    IRCF_ConfigTextBox.BackColor = Color.Red;
                }
            }
        }

        private void Stiffener_ConfigTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = Stiffener_ConfigTextBox.Text;
        }

        private void Stiffener_ConfigTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != Stiffener_ConfigTextBox.Text)
                Stiffener_ConfigTextBox.BackColor = Color.BurlyWood;

            if (VendorNamecheckBox.Checked)
            {
                bool bResult = false;
                foreach (string strCompareData in m_StiffenerVendorList)
                {
                    if (strCompareData == Stiffener_ConfigTextBox.Text)
                    {
                        bResult = true;
                        break;
                    }
                }

                if (bResult == false)
                {
                    Stiffener_ConfigTextBox.BackColor = Color.Red;
                }
            }
        }

        private void AA_MachineTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = AA_MachineTextBox.Text;
        }

        private void AA_MachineTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != AA_MachineTextBox.Text)
                AA_MachineTextBox.BackColor = Color.BurlyWood;
        }

        private void ProjectIDTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = ProjectIDTextBox.Text;
        }

        private void ProjectIDTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != ProjectIDTextBox.Text)
                ProjectIDTextBox.BackColor = Color.BurlyWood;
        }

        private void Project_VersionTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = Project_VersionTextBox.Text;
        }

        private void Project_VersionTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != Project_VersionTextBox.Text)
                Project_VersionTextBox.BackColor = Color.BurlyWood;
        }

        private void IntegratorTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = IntegratorTextBox.Text;
        }

        private void IntegratorTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != IntegratorTextBox.Text)
                IntegratorTextBox.BackColor = Color.BurlyWood;
        }

        private void CameraBuildTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = CameraBuildTextBox.Text;
        }

        private void CameraBuildTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != CameraBuildTextBox.Text)
                CameraBuildTextBox.BackColor = Color.BurlyWood;
        }

        private void ConfigTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = ConfigTextBox.Text;
        }

        private void ConfigTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != ConfigTextBox.Text)
                ConfigTextBox.BackColor = Color.BurlyWood;
        }

        private void IRCFTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = IRCFTextBox.Text;
        }

        private void IRCFTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != IRCFTextBox.Text)
                IRCFTextBox.BackColor = Color.BurlyWood;
        }

        private void SubstrateTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = SubstrateTextBox.Text;
        }

        private void SubstrateTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != SubstrateTextBox.Text)
                SubstrateTextBox.BackColor = Color.BurlyWood;
        }

        private void SensorTypeTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = SensorTypeTextBox.Text;
        }

        private void SensorTypeTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != SensorTypeTextBox.Text)
                SensorTypeTextBox.BackColor = Color.BurlyWood;
        }

        private void LensTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = LensTextBox.Text;
        }

        private void LensTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != LensTextBox.Text)
                LensTextBox.BackColor = Color.BurlyWood;
        }

        private void FlexTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = FlexTextBox.Text;
        }

        private void FlexTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != FlexTextBox.Text)
                FlexTextBox.BackColor = Color.BurlyWood;
        }

        private void StiffenerTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = StiffenerTextBox.Text;
        }

        private void StiffenerTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != StiffenerTextBox.Text)
                StiffenerTextBox.BackColor = Color.BurlyWood;
        }

        private void CarrierTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = CarrierTextBox.Text;
        }

        private void CarrierTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != CarrierTextBox.Text)
                CarrierTextBox.BackColor = Color.BurlyWood;
        }

        private void Process_ControlTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = Process_ControlTextBox.Text;
        }

        private void Process_ControlTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != Process_ControlTextBox.Text)
                Process_ControlTextBox.BackColor = Color.BurlyWood;
        }

        private void Process_DOE_codeTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = Process_DOE_codeTextBox.Text;
        }

        private void Process_DOE_codeTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != Process_DOE_codeTextBox.Text)
                Process_DOE_codeTextBox.BackColor = Color.BurlyWood;
        }

        private void SotfwareTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = SotfwareTextBox.Text;
        }

        private void SotfwareTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != SotfwareTextBox.Text)
                SotfwareTextBox.BackColor = Color.BurlyWood;
        }

        private void WaiverTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = WaiverTextBox.Text;
        }

        private void WaiverTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != WaiverTextBox.Text)
                WaiverTextBox.BackColor = Color.BurlyWood;
        }

        private void LensComponent_R_MajorTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = WaiverTextBox.Text;
        }

        private void LensComponent_R_MajorTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != WaiverTextBox.Text)
                WaiverTextBox.BackColor = Color.BurlyWood;
        }

        private void LensComponent_R_MinorTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = LensComponent_R_MinorTextBox.Text;
        }

        private void LensComponent_R_MinorTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != LensComponent_R_MinorTextBox.Text)
                LensComponent_R_MinorTextBox.BackColor = Color.BurlyWood;
        }

        private void ColorShading_RevTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = LensComponent_R_MinorTextBox.Text;
        }

        private void ColorShading_RevTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != LensComponent_R_MinorTextBox.Text)
                LensComponent_R_MinorTextBox.BackColor = Color.BurlyWood;
        }

        private void Traceability_VersionTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = Traceability_VersionTextBox.Text;
        }

        private void Traceability_VersionTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != Traceability_VersionTextBox.Text)
                Traceability_VersionTextBox.BackColor = Color.BurlyWood;
        }

        private void CISMaskIDTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = CISMaskIDTextBox.Text;
        }

        private void CISMaskIDTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != CISMaskIDTextBox.Text)
                CISMaskIDTextBox.BackColor = Color.BurlyWood;
        }

        private void LAST_STRINGTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = LAST_STRINGTextBox.Text;
        }

        private void LAST_STRINGTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != LAST_STRINGTextBox.Text)
                LAST_STRINGTextBox.BackColor = Color.BurlyWood;
        }

        private void FIRST_STRINGTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = FIRST_STRINGTextBox.Text;
        }

        private void FIRST_STRINGTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != FIRST_STRINGTextBox.Text)
                FIRST_STRINGTextBox.BackColor = Color.BurlyWood;
        }

        private void SERIAL_COUNTTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = SERIAL_COUNTTextBox.Text;
        }

        private void SERIAL_COUNTTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != SERIAL_COUNTTextBox.Text)
                SERIAL_COUNTTextBox.BackColor = Color.BurlyWood;
        }

        private void ShowVendorButton_Click(object sender, EventArgs e)
        {
            ShowVendors cShowVendor = new ShowVendors();

            cShowVendor.ShowDialog();
        }

        private void VendorNamecheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (VendorNamecheckBox.Checked)
            {
                if (m_bReadFlag == false)
                {
                    LoadVendorNameData();
                    Flex_ConfigTextBox.Focus();
                    Lens_ConfigTextBox.Focus();
                    Substrate_ConfigTextBox.Focus();
                    IRCF_ConfigTextBox.Focus();
                    Stiffener_ConfigTextBox.Focus();
                    ReferenceNameTextBox.Focus();
                }
            }
        }

        private void LoadVendorNameData()
        {
            string strFilePath;
            strFilePath = Application.StartupPath +"\\Data\\VendorName.ini";

            if (System.IO.File.Exists(strFilePath))
            {
                LoadINIFileAndSaveToList("Flex",        ref m_FlexVendorList,       strFilePath);
                LoadINIFileAndSaveToList("Lens",        ref m_LensVendorList,       strFilePath);
                LoadINIFileAndSaveToList("Substrate",   ref m_SubstrateVendorList,  strFilePath);
                LoadINIFileAndSaveToList("IRCF",        ref m_IRCFVendorList,       strFilePath);
                LoadINIFileAndSaveToList("Stiffener",   ref m_StiffenerVendorList,  strFilePath);
                m_bReadFlag = true;
            }
        }

        private void LoadINIFileAndSaveToList(string inBigItem, ref List<string> outList, string strFilePath)
        {
            int nIndex = 0;
            StringBuilder strbReadValue = new StringBuilder();
            GetPrivateProfileString(inBigItem, "Count", "0", strbReadValue, 255, strFilePath);
            Int32.TryParse(strbReadValue.ToString(), out nIndex);

            for (int i = 0; i < nIndex; i++)
            {
                GetPrivateProfileString(inBigItem, i.ToString(), "0", strbReadValue, 255, strFilePath);
                outList.Add(strbReadValue.ToString());
            }
        }

        private void ReferenceNameTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = ReferenceNameTextBox.Text;
        }

        private void ReferenceNameTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != ReferenceNameTextBox.Text)
                ReferenceNameTextBox.BackColor = Color.BurlyWood;
        }

        private void Reference_VersionTextBox_Enter(object sender, EventArgs e)
        {
            m_strPreText = Reference_VersionTextBox.Text;
        }

        private void Reference_VersionTextBox_Leave(object sender, EventArgs e)
        {
            if (m_strPreText != Reference_VersionTextBox.Text)
                Reference_VersionTextBox.BackColor = Color.BurlyWood;
        }
    }
}
