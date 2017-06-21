using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace AutoReference
{
    public partial class AutoRef : Form
    {
        private List<VSRData> DataList;
        VSRData m_AddVSR = new VSRData();
        private BaseData temp = new BaseData();
        private bool m_bAddResult;
        private ReferenceData m_cRefData = new ReferenceData(); // Ref 만들 때 넘길 객체

        private VSRData m_cSelectedData = new VSRData();

        public AutoRef()
        {
            InitializeComponent();

            Assembly assemObj = Assembly.GetExecutingAssembly();
            Version v = assemObj.GetName().Version;

            int nMajorV = v.Major;
            int nMinorV = v.Minor;
            int nBuildV = v.Build;
            int nRevisionV = v.Revision;

            this.Text += " " + nMajorV.ToString() + "." + nMinorV.ToString() + "." + nBuildV.ToString() + "." + nRevisionV.ToString();

            DataList = new List<VSRData>();

            DataFileLoad();
            initAllListViews();
            PrintProjectToListBox();
        }

        private void PrjAddButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "PDF 파일 (*.pdf) | *.pdf";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = ofd.FileName;
                AddPrjForm addDlg = new AddPrjForm(path);
                addDlg.SendAddResultEvent += new AddPrjForm.SendAddResult(GetAddResult);
                addDlg.ShowDialog();
            }
            if (m_bAddResult)
            {
                DataList.Add(m_AddVSR);
                DataFileSave();
                PrintProjectToListBox();
            }
        }

        private void PrjDeleteButton_Click(object sender, EventArgs e)
        {
            if (PrjListView.SelectedItems.Count > 0)
            {
                int nSelected = PrjListView.FocusedItem.Index;
                if (nSelected != -1)
                {
                    string strFilePath = DataList[nSelected].m_strFileName;
                    string temp = "Delete Project " + DataList[nSelected].m_strVSRVersion + "-" + DataList[nSelected].m_strPrjName + "?";
                    if (System.IO.File.Exists(strFilePath))
                    {
                        if (DialogResult.Yes == MessageBox.Show(temp, "Delete Project", MessageBoxButtons.YesNo))
                        {
                            DataList.Remove(DataList[nSelected]);
                        }

                        FileDelete(strFilePath);
                        PrintProjectToListBox();
                        CleanListBoxes();
                    }                    
                }
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            string selected = null;
            m_cRefData.m_strRefName = PrjTextBox.Text + "_" + FlexTextBox.Text + LensTextBox.Text + SubstrateTextBox.Text + "_" + IRCFTextBox.Text +
                                      StiffenerTextBox.Text + CarrierTextBox.Text + "_" + EEEETextBox.Text + "_" + BuildConfigTextBox.Text + "_TEST_"+RefVersion2TextBox.Text;

            if (CheckAllDataSelect() == true)
            {
                if (CheckCombination() == false)
                {
                    if (MessageBox.Show("Parts combination is not matched with config.\n Do you want continue?", "Warning", MessageBoxButtons.YesNo) != DialogResult.Yes)
                    {
                        return;
                    }
                }

                FolderBrowserDialog ofd = new FolderBrowserDialog();

                m_cRefData.m_strBuild_Config = BuildConfigTextBox.Text;
                m_cRefData.m_strBuild_num = m_cRefData.m_strPrjName + " " + BuildListView.FocusedItem.SubItems[1].Text;

                string strTemp = LenscomponentTextBox.Text;
                m_cRefData.LensComponent_Major.strVendorName = "LensComponent_Major";
                m_cRefData.LensComponent_Major.strHexValue = "0X" + strTemp[2].ToString();
                m_cRefData.LensComponent_Major.strBinaryValue = Convert.ToString(Convert.ToInt32(strTemp[2].ToString(), 16), 2);
                m_cRefData.LensComponent_Minor.strVendorName = "LensComponent_Minor";
                m_cRefData.LensComponent_Minor.strHexValue = "0X" + strTemp[3].ToString();
                m_cRefData.LensComponent_Minor.strBinaryValue = Convert.ToString(Convert.ToInt32(strTemp[3].ToString(), 16), 2);

                strTemp = BuildConfigTextBox.Text;
                m_cRefData.Config.strHexValue = strTemp[3] + strTemp[4].ToString();
                m_cRefData.Config.strBinaryValue = Convert.ToString(Convert.ToInt32(m_cRefData.Config.strHexValue, 16), 2);

                m_cRefData.m_strErs_ver = "ers_ver " + ERSVesionTextBox.Text;
                m_cRefData.m_strCISMask = CISMaskTextBox.Text;
                m_cRefData.m_strSWVersion = SWVersionTextBox.Text;
                int nIndex = PrjListView.FocusedItem.Index;
                m_cRefData.m_strVsr_ver = "vsr_ver " + PrjListView.Items[nIndex].SubItems[0].Text;
                if (InputRefCheckBox.Checked)
                    m_cRefData.m_strDOEBuild_Config = ManualBuildConfigTextBox.Text;
                m_cRefData.m_strEEEE = EEEETextBox.Text;

                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    selected = ofd.SelectedPath;

                    PrintMidResultForm midDlg = new PrintMidResultForm(selected, ref m_cRefData);

                    this.Hide();
                    midDlg.ShowDialog();
                    this.Show();
                }
            }
        }

        private bool CheckAllDataSelect()
        {
            bool bResult = true;

            if (SensorListView.SelectedItems.Count == 0)
            {
                bResult = false;
                MessageBox.Show("Sensor isn't inputed");
            }
            if(ConfigListView.SelectedItems.Count == 0)
            {
                bResult = false;
                MessageBox.Show("Config isn't inputed");
            }
            if (IRCFListView.SelectedItems.Count == 0)
            {
                bResult = false;
                MessageBox.Show("IRCF isn't inputed");
            }
            if (LensListView.SelectedItems.Count == 0)
            {
                bResult = false;
                MessageBox.Show("Lens isn't inputed");
            }
            if (StiffenerListView.SelectedItems.Count == 0)
            {
                bResult = false;
                MessageBox.Show("Stiffener isn't inputed");
            }
            if (SubstrateListView.SelectedItems.Count == 0)
            {
                bResult = false;
                MessageBox.Show("Substrate isn't inputed");
            }
            if (FlexListView.SelectedItems.Count == 0)
            {
                bResult = false;
                MessageBox.Show("Flex isn't inputed");
            }
            if (CarrierListView.SelectedItems.Count == 0 && m_cSelectedData.CarrierList.Count != 0)
            {
                bResult = false;
                MessageBox.Show("Carrier isn't inputed");
            }
            if (BuildListView.SelectedItems.Count == 0)
            {
                bResult = false;
                MessageBox.Show("Build isn't inputed");
            }


            if (BuildConfigTextBox.Text == "EX : C1010")
            {
                bResult = false;
                MessageBox.Show("Build_Config isn't inputed");
            }
            if (RefVersionTextBox.Text == "EX : E1")
            {
                bResult = false;
                MessageBox.Show("RefVersion isn't inputed");
            }
            if (LenscomponentTextBox.Text == "EX : 0X2A")
            {
                bResult = false;
                MessageBox.Show("Lens component isn't inputed");
            }
            if (ERSVesionTextBox.Text == "EX : A OR 10")
            {
                bResult = false;
                MessageBox.Show("ERS Version isn't inputed");
            }
            if (CISMaskTextBox.Text == "EX : 1")
            {
                bResult = false;
                MessageBox.Show("CIS Mask isn't inputed");
            }
            if (SWVersionTextBox.Text == "EX : ME 4.0.0.0")
            {
                bResult = false;
                MessageBox.Show("SW Version isn't inputed");
            }

            if (ManualBuildConfigTextBox.Text == "" && InputRefCheckBox.Checked)
            {
                bResult = false;
                MessageBox.Show("DOE Build_Config isn't inputed");
            }
            return bResult;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearTextBoxes()
        {
            PrjTextBox.Clear();
            EEEETextBox.Clear();
            IRCFTextBox.Clear();
            LensTextBox.Clear();
            StiffenerTextBox.Clear();
            SubstrateTextBox.Clear();
            FlexTextBox.Clear();
            CarrierTextBox.Clear();
        }

        private void initAllListViews()
        {
            InitPrjListView();
            InitListView(SensorListView);
            InitListView(ConfigListView);
            InitListView(IRCFListView);
            InitListView(LensListView);
            InitListView(StiffenerListView);
            InitListView(SubstrateListView);
            InitListView(FlexListView);
            InitListView(CarrierListView);
            InitListView(BuildListView);
        }

        private void InitPrjListView()
        {
            PrjListView.FullRowSelect = true;
            PrjListView.Columns.Add("VSR Ver.", 80);
            PrjListView.Columns.Add("Project Name", 90);
        }

        private void InitListView(ListView inListView)
        {
            inListView.Items.Clear();
            inListView.Columns.Clear();
            inListView.FullRowSelect = true;
            inListView.Columns.Add("", 0);
            
            if (inListView != ConfigListView)
            {
                inListView.Columns.Add("Item", 180);
                inListView.Columns.Add("Binary", 100);
                inListView.Columns.Add("Hex", 100);
            }
            else
            {
                inListView.Columns.Add("Item", 380);
            }
        }

        private void PrintItemToListView(List<BaseData> inData, ListView inListView)
        {
            inListView.Items.Clear();
            if (inListView == ConfigListView)
            {
                foreach (var temp in inData)
                {
                    ListViewItem lvi = new ListViewItem("");
                    lvi.SubItems.Add(temp.strVendorName);                    
                    inListView.Items.Add(lvi);
                }
            }
            else
            {
                foreach (var temp in inData)
                {
                    ListViewItem lvi = new ListViewItem("");
                    lvi.SubItems.Add(temp.strVendorName);
                    lvi.SubItems.Add(temp.strBinaryValue);
                    lvi.SubItems.Add(temp.strHexValue);
                    inListView.Items.Add(lvi);
                }
            }
        }

        private void PrintEEEEToTextBox(VSRData inData)
        {
            EEEETextBox.Clear();
            EEEETextBox.Text = inData.m_strEEEE;
        }

        void GetAddResult(bool inResult, VSRData inAddVSR)
        {
            m_AddVSR = inAddVSR;
            m_bAddResult = inResult;
        }

        private void PrintProjectToListBox()
        {
            PrjListView.Items.Clear();

            foreach (var temp in DataList)
            {
                ListViewItem lvi = new ListViewItem(temp.m_strVSRVersion);
                lvi.SubItems.Add(temp.m_strPrjName);
                PrjListView.Items.Add(lvi);
            }
        }

        private bool DataFileLoad()
        {
            string strFilePath;

            strFilePath = Application.StartupPath +"\\Data";

            if (System.IO.Directory.Exists(strFilePath))
            {
                System.IO.DirectoryInfo direc = new System.IO.DirectoryInfo(strFilePath);

                foreach (var fileItem in direc.GetFiles())
                {
                    VSRData AddVSRData = new VSRData();
                    // ini 확장자가 아닌 파일들 걸러 주기
                    if (fileItem.Name.IndexOf(".ini") == -1 || fileItem.Name.IndexOf("VendorName") != -1)
                    {
                        continue;
                    }
                    AddVSRData.LoadDataToFile(strFilePath + "\\" + fileItem.Name);
                    DataList.Add(AddVSRData);
                }
            }

            return true;
        }

        private bool DataFileSave()
        {
            foreach (VSRData saveVSRData in DataList)
            {
                saveVSRData.SaveDataToFile();
            }
            return true;
        }

        private void CleanListBoxes()
        {
            SensorListView.Clear();
            ConfigListView.Clear();
            IRCFListView.Clear();
            LensListView.Clear();
            StiffenerListView.Clear();
            SubstrateListView.Clear();
            FlexListView.Clear();
            CarrierListView.Clear();
            BuildListView.Clear();
            EEEETextBox.Clear();
        }

        private void AutoRef_FormClosing(object sender, FormClosingEventArgs e)
        {
            DataFileSave();
        }

        private bool FileDelete(string inDeleteFilePath)
        {
            FileInfo fileDel = new FileInfo(inDeleteFilePath);
            if (fileDel.Exists) //삭제할 파일이 있는지
            {
                fileDel.Delete(); //없어도 에러안남
            }

            return true;
        }

        private void button_Modify_Click(object sender, EventArgs e)
        {
            if (PrjListView.SelectedItems.Count > 0)
            {
                string strTemp = PrjListView.FocusedItem.ToString();
                VSRData m_cSelectedData = new VSRData();
                m_cSelectedData.SetFileName(strTemp);
                int nSelectIndex = -1;
                nSelectIndex = PrjListView.FocusedItem.Index;
                if (nSelectIndex != -1 && strTemp != "")
                {
                    m_cSelectedData = DataList[nSelectIndex];
                    AddPrjForm addDlg = new AddPrjForm(m_cSelectedData);
                    addDlg.SendAddResultEvent += new AddPrjForm.SendAddResult(GetAddResult);
                    addDlg.ShowDialog();
                    DataFileSave();
                }
            }
        }

        private void SensorListView_MouseClick(object sender, MouseEventArgs e)
        {
            int nSelecedIndex = -1;
            nSelecedIndex = SensorListView.FocusedItem.Index;
            if (nSelecedIndex != -1)
            {
                string strSelectdItem;
                strSelectdItem = SensorListView.FocusedItem.SubItems[1].Text.ToString();

                SelSensorTextBox.Text = SensorListView.FocusedItem.SubItems[1].Text;

                m_cRefData.Sensor.strVendorName = SensorListView.FocusedItem.SubItems[1].Text;
                m_cRefData.Sensor.strBinaryValue = SensorListView.FocusedItem.SubItems[2].Text;
                m_cRefData.Sensor.strHexValue = SensorListView.FocusedItem.SubItems[3].Text;
            }           
        }

        private void ConfigListView_Click(object sender, EventArgs e)
        {
            int nSelecedIndex = -1;
            nSelecedIndex = ConfigListView.FocusedItem.Index;
            if (nSelecedIndex != -1)
            {
                string strSelectdItem;
                strSelectdItem = ConfigListView.FocusedItem.SubItems[1].Text.ToString();

                string[] strTemp;
                strTemp = strSelectdItem.Split(',');

                int nIndex = strTemp[0].Count();
                string EeeeText = EEEETextBox.Text;
                if (EeeeText.Length > 4)
                {
                    EeeeText = EeeeText.Remove(4);
                }
                EEEETextBox.Text = EeeeText + strTemp[0][nIndex - 1];
                SelConfigTextBox.Text = ConfigListView.FocusedItem.SubItems[1].Text;
                m_cRefData.Config.strVendorName = m_cSelectedData.PartsList[nSelecedIndex].strVendorName;
            }           
        }

        private void IRCFListView_Click(object sender, EventArgs e)
        {
            int nSelecedIndex = -1;
            nSelecedIndex = IRCFListView.FocusedItem.Index;
            if (nSelecedIndex != -1)
            {
                string strSelectdItem;
                strSelectdItem = IRCFListView.FocusedItem.SubItems[1].Text;

                IRCFTextBox.Text = strSelectdItem[0].ToString();

                SelIRCFTextBox.Text = IRCFListView.FocusedItem.SubItems[1].Text;

                m_cRefData.IRCF.strVendorName   = IRCFListView.FocusedItem.SubItems[1].Text;
                m_cRefData.IRCF.strBinaryValue  = IRCFListView.FocusedItem.SubItems[2].Text;
                m_cRefData.IRCF.strHexValue     = IRCFListView.FocusedItem.SubItems[3].Text;
            }
        }

        private void LensListView_Click(object sender, EventArgs e)
        {
            int nSelecedIndex = -1;
            nSelecedIndex = LensListView.FocusedItem.Index;
            if (nSelecedIndex != -1)
            {
                string strSelectdItem;
                strSelectdItem = LensListView.FocusedItem.SubItems[1].Text.ToString();

                LensTextBox.Text = strSelectdItem[0].ToString();

                SelLensTextBox.Text = LensListView.FocusedItem.SubItems[1].Text;

                m_cRefData.Lens.strVendorName   = LensListView.FocusedItem.SubItems[1].Text.ToString();
                m_cRefData.Lens.strBinaryValue  = LensListView.FocusedItem.SubItems[2].Text.ToString();
                m_cRefData.Lens.strHexValue     = LensListView.FocusedItem.SubItems[3].Text.ToString();
            }
        }

        private void StiffenerListView_Click(object sender, EventArgs e)
        {
            int nSelecedIndex = -1;
            nSelecedIndex = StiffenerListView.FocusedItem.Index;
            if (nSelecedIndex != -1)
            {
                string strSelectdItem;
                strSelectdItem = StiffenerListView.FocusedItem.SubItems[1].Text.ToString();

                StiffenerTextBox.Text = strSelectdItem[0].ToString();

                SelStiffenerTextBox.Text = StiffenerListView.FocusedItem.SubItems[1].Text;

                m_cRefData.Stiffener.strVendorName  = StiffenerListView.FocusedItem.SubItems[1].Text.ToString();
                m_cRefData.Stiffener.strBinaryValue = StiffenerListView.FocusedItem.SubItems[2].Text.ToString();
                m_cRefData.Stiffener.strHexValue    = StiffenerListView.FocusedItem.SubItems[3].Text.ToString();
            }
        }

        private void SubstrateListView_Click(object sender, EventArgs e)
        {
            int nSelecedIndex = -1;
            nSelecedIndex = SubstrateListView.FocusedItem.Index;
            if (nSelecedIndex != -1)
            {
                string strSelectdItem;
                strSelectdItem = SubstrateListView.FocusedItem.SubItems[1].Text.ToString();

                SubstrateTextBox.Text = strSelectdItem[0].ToString();

                SelSubstrateTextBox.Text = SubstrateListView.FocusedItem.SubItems[1].Text;

                m_cRefData.Substrate.strVendorName  = SubstrateListView.FocusedItem.SubItems[1].Text.ToString();
                m_cRefData.Substrate.strBinaryValue = SubstrateListView.FocusedItem.SubItems[2].Text.ToString();
                m_cRefData.Substrate.strHexValue    = SubstrateListView.FocusedItem.SubItems[3].Text.ToString();
            }
        }

        private void FlexListView_Click(object sender, EventArgs e)
        {
            int nSelecedIndex = -1;
            nSelecedIndex = FlexListView.FocusedItem.Index;
            if (nSelecedIndex != -1)
            {
                string strSelectdItem;
                strSelectdItem = FlexListView.FocusedItem.SubItems[1].Text.ToString();

                FlexTextBox.Text = strSelectdItem[0].ToString();

                SelFlexTextBox.Text = FlexListView.FocusedItem.SubItems[1].Text;

                m_cRefData.Flex.strVendorName   = FlexListView.FocusedItem.SubItems[1].Text.ToString();
                m_cRefData.Flex.strBinaryValue  = FlexListView.FocusedItem.SubItems[2].Text.ToString();
                m_cRefData.Flex.strHexValue     = FlexListView.FocusedItem.SubItems[3].Text.ToString();
            }
        }

        private void CarrierListView_Click(object sender, EventArgs e)
        {
            int nSelecedIndex = -1;
            nSelecedIndex = CarrierListView.FocusedItem.Index;
            if (nSelecedIndex != -1)
            {
                string strSelectdItem;
                strSelectdItem = CarrierListView.FocusedItem.SubItems[1].Text.ToString();

                CarrierTextBox.Text = strSelectdItem[0].ToString();

                SelCarrierTextBox.Text = CarrierListView.FocusedItem.SubItems[1].Text;

                m_cRefData.Carrier.strVendorName    = CarrierListView.FocusedItem.SubItems[1].Text.ToString();
                m_cRefData.Carrier.strBinaryValue   = CarrierListView.FocusedItem.SubItems[2].Text.ToString();
                m_cRefData.Carrier.strHexValue      = CarrierListView.FocusedItem.SubItems[3].Text.ToString();
            }
        }

        private void BuildListView_Click(object sender, EventArgs e)
        {
            int nSelecedIndex = -1;
            nSelecedIndex = BuildListView.FocusedItem.Index;
            if (nSelecedIndex != -1)
            {
                m_cRefData.CameraBuild = m_cSelectedData.CameraBuildList[nSelecedIndex];

                SelBuildTextBox.Text = BuildListView.FocusedItem.SubItems[1].Text;
            }
        }

        private void PrjListView_Click(object sender, EventArgs e)
        {
            int nSelectIndex = -1;

            nSelectIndex = PrjListView.FocusedItem.Index;
            string strSelected;

            
            ClearTextBoxes();
            if (nSelectIndex != -1)
            {
                strSelected = PrjListView.FocusedItem.ToString();
                m_cSelectedData.SetFileName(strSelected);
                m_cSelectedData = DataList[nSelectIndex];
                PrintItemToListView(m_cSelectedData.SensorList, SensorListView);
                PrintItemToListView(m_cSelectedData.PartsList, ConfigListView);
                PrintItemToListView(m_cSelectedData.IRCFList, IRCFListView);
                PrintItemToListView(m_cSelectedData.LensList, LensListView);
                PrintItemToListView(m_cSelectedData.StiffenerList, StiffenerListView);
                PrintItemToListView(m_cSelectedData.SubstrateList, SubstrateListView);
                PrintItemToListView(m_cSelectedData.FlexList, FlexListView);
                PrintItemToListView(m_cSelectedData.CarrierList, CarrierListView);
                PrintItemToListView(m_cSelectedData.CameraBuildList, BuildListView);
                PrintEEEEToTextBox(m_cSelectedData);

                PrjTextBox.Text = PrjListView.FocusedItem.SubItems[1].Text;
                m_cRefData.m_strPrjName = PrjListView.FocusedItem.SubItems[1].Text;
                m_cRefData.NVM = m_cSelectedData.NVMList[0];
                m_cRefData.CameraPrj = m_cSelectedData.CameraPrjList[0];
                m_cRefData.ProgramVariant = m_cSelectedData.ProgramVariantList[0];
                m_cRefData.Intergrator = m_cSelectedData.IntegratorList[0];
                m_cRefData.SoftWare = m_cSelectedData.AlgorithmList[0];
                m_cRefData.ColorShading = m_cSelectedData.ColorShadingList[0];
                m_cRefData.Traceability = m_cSelectedData.TraceabilityRevList[0];
            }
        }

        private void BuildConfigTextBox_Enter(object sender, EventArgs e)
        {
            if (BuildConfigTextBox.Text == "EX : C1010")
            {
                BuildConfigTextBox.Text = "C";
            }
        }

        private void BuildConfigTextBox_Leave(object sender, EventArgs e)
        {
            if (BuildConfigTextBox.Text == "C" || BuildConfigTextBox.Text == "")
            {
                BuildConfigTextBox.Text = "EX : C1010";
            }
            else
            {
                m_cRefData.m_strBuild_Config = BuildConfigTextBox.Text;
            }
        }

        private void RefVersionTextBox_Enter(object sender, EventArgs e)
        {
            if (RefVersionTextBox.Text == "EX : E1")
            {
                RefVersionTextBox.Text = "";
            }
        }

        private void RefVersionTextBox_Leave(object sender, EventArgs e)
        {
            if (RefVersionTextBox.Text == "")
            {
                RefVersionTextBox.Text = "EX : E1";
            }
            else
            {
                m_cRefData.m_strRefVersion = RefVersionTextBox.Text;
            }
        }

        private void LenscomponentTextBox_Enter(object sender, EventArgs e)
        {
            if (LenscomponentTextBox.Text == "EX : 0X2A")
            {
                LenscomponentTextBox.Text = "0X";
                LenscomponentTextBox.Focus();
                LenscomponentTextBox.Select(LenscomponentTextBox.Text.Length, 0);
            }
        }

        private void LenscomponentTextBox_Leave(object sender, EventArgs e)
        {
            if (LenscomponentTextBox.Text == "0X" || LenscomponentTextBox.Text == "" || LenscomponentTextBox.Text == "0")
            {
                LenscomponentTextBox.Text = "EX : 0X2A";
            }
            else
            {
                m_cRefData.m_strLensConfig = LenscomponentTextBox.Text;
            }
        }

        private void ERSVesionTextBox_Enter(object sender, EventArgs e)
        {
            if (ERSVesionTextBox.Text == "EX : A OR 10")
            {
                ERSVesionTextBox.Text = "";
            }
        }

        private void ERSVesionTextBox_Leave(object sender, EventArgs e)
        {
            if (ERSVesionTextBox.Text == "")
            {
                ERSVesionTextBox.Text = "EX : A OR 10";
            }
        }

        private void CISMaskTextBox_Enter(object sender, EventArgs e)
        {
            if (CISMaskTextBox.Text == "EX : 1")
            {
                CISMaskTextBox.Text = "";
            }
        }

        private void CISMaskTextBox_Leave(object sender, EventArgs e)
        {
            if (CISMaskTextBox.Text == "")
            {
                CISMaskTextBox.Text = "EX : 1";
            }
        }

        private void SWVersionTextBox_Enter(object sender, EventArgs e)
        {
            if (SWVersionTextBox.Text == "EX : ME 4.0.0.0")
            {
                SWVersionTextBox.Text = "";
            }
        }

        private void SWVersionTextBox_Leave(object sender, EventArgs e)
        {
            if (SWVersionTextBox.Text == "")
            {
                SWVersionTextBox.Text = "EX : ME 4.0.0.0";
            }
        }

        private void BuildConfig2TextBox_Enter(object sender, EventArgs e)
        {
            if (BuildConfig2TextBox.Text == "EX : C1010")
            {
                BuildConfigTextBox.Text = "";
                BuildConfig2TextBox.Text = "";
            }
        }

        private void BuildConfig2TextBox_Leave(object sender, EventArgs e)
        {
            if (BuildConfig2TextBox.Text == "")
            {
                BuildConfig2TextBox.Text = "EX : C1010";
                BuildConfigTextBox.Text = "EX : C1010";
            }
        }

        private void RefVersion2TextBox_Enter(object sender, EventArgs e)
        {
            if (RefVersion2TextBox.Text == "EX : E1")
            {
                RefVersionTextBox.Text = "";
                RefVersion2TextBox.Text = "";
            }
        }

        private void RefVersion2TextBox_Leave(object sender, EventArgs e)
        {
            if (RefVersion2TextBox.Text == "")
            {
                RefVersion2TextBox.Text = "EX : E1";
                RefVersionTextBox.Text = "EX : E1";
            }
            else
            {
                m_cRefData.m_strRefVersion = RefVersionTextBox.Text;
            }
        }

        private void RefVersion2TextBox_TextChanged(object sender, EventArgs e)
        {
            RefVersionTextBox.Text = RefVersion2TextBox.Text;
        }

        private void BuildConfigTextBox_TextChanged(object sender, EventArgs e)
        {
            BuildConfig2TextBox.Text = BuildConfigTextBox.Text;
        }

        private void RefVersionTextBox_TextChanged(object sender, EventArgs e)
        {
            RefVersion2TextBox.Text = RefVersionTextBox.Text;
        }

        private void BuildConfig2TextBox_TextChanged(object sender, EventArgs e)
        {
            BuildConfigTextBox.Text = BuildConfig2TextBox.Text;
        }

        private void InputRefCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (InputRefCheckBox.Checked)
            {
                ManualBuildConfigTextBox.Enabled = true;
            }
            else
            {
                ManualBuildConfigTextBox.Text = "";
                ManualBuildConfigTextBox.Enabled = false;
            }
        }

        private void ManualBuildConfigTextBox_Leave(object sender, EventArgs e)
        {
            if (ManualBuildConfigTextBox.Text != "")
            {
                m_cRefData.m_strDOEBuild_Config = ManualBuildConfigTextBox.Text;
            }
        }

        private void PrjListView_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = PrjListView.FocusedItem.Index;

            if (nSelectIndex != -1)
            {
                string strTemp = PrjListView.FocusedItem.ToString();
                VSRData m_cSelectedData = new VSRData();
                m_cSelectedData.SetFileName(strTemp);
                if (strTemp != "")
                {
                    m_cSelectedData = DataList[nSelectIndex];
                    AddPrjForm addDlg = new AddPrjForm(m_cSelectedData);
                    addDlg.SendAddResultEvent += new AddPrjForm.SendAddResult(GetAddResult);
                    addDlg.ShowDialog();
                    DataFileSave();
                }
                initAllListViews();
            }
        }

        private bool CheckCombination()
        {
            bool bResult = false;
            string strSelConfig = ConfigListView.FocusedItem.SubItems[1].Text;
            string[] strConfigSplit = strSelConfig.Split(',');
            string strCombination = strConfigSplit[1];
            string[] strSelItems = new string[6];

            if (strCombination.IndexOf('/') != -1 && strCombination.IndexOf('(') != -1)
            {
                strCombination = strCombination.Replace("(", "");
                strCombination = strCombination.Replace(")", "");
                strCombination = strCombination.Trim();

                strConfigSplit = strCombination.Split('/');

                strSelItems[0] = IRCFListView.FocusedItem.SubItems[1].Text;
                strSelItems[1] = LensListView.FocusedItem.SubItems[1].Text;
                strSelItems[2] = StiffenerListView.FocusedItem.SubItems[1].Text;
                strSelItems[3] = SubstrateListView.FocusedItem.SubItems[1].Text;
                strSelItems[4] = FlexListView.FocusedItem.SubItems[1].Text;
                if (CarrierListView.FocusedItem!=null)
                    strSelItems[5] = CarrierListView.FocusedItem.SubItems[1].Text;

                int nCount = 0;

                foreach (string strTarget in strConfigSplit)
                {
                    foreach (string strTemp in strSelItems)
                    {
                        if (strTarget == strTemp)
                        {
                            nCount++;
                            break;
                        }
                    }
                }
                if (nCount == strConfigSplit.Length)
                    bResult = true;
            }
            else
            {
                bResult = true;
            }
            
            return bResult;
        }
    }
}
