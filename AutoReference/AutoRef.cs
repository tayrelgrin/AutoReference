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
        private ReferenceData m_cRefData = new ReferenceData();
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
                PrintProjectToListBox();
            }
        }

        private void PrjDeleteButton_Click(object sender, EventArgs e)
        {
            int nSelected = PrjListBox.SelectedIndex;
            string strFilePath = Application.StartupPath + "\\Data\\" +DataList[nSelected].m_strPrjName + DataList[nSelected].m_strVSRVersion + ".ini";
            string temp = "Delete Project " + DataList[nSelected].m_strVSRVersion + "-" + DataList[nSelected].m_strPrjName+"?";
            if (DialogResult.Yes == MessageBox.Show(temp,"Delete Project", MessageBoxButtons.YesNo))
            {
                DataList.Remove(DataList[nSelected]);
            }

            FileDelete(strFilePath);
            PrintProjectToListBox();
            CleanListBoxes();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            string selected = null;

            FolderBrowserDialog ofd = new FolderBrowserDialog();

            ofd.ShowDialog();
            selected = ofd.SelectedPath;

            PrintMidResultForm midDlg = new PrintMidResultForm(selected,ref m_cRefData);

            this.Hide();
            midDlg.ShowDialog();
            this.Show();
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

        private void PjrListBox_Click(object sender, EventArgs e)
        {
            int nSelectIndex = -1;

            nSelectIndex = PrjListBox.SelectedIndex;
            string strSelected;

            VSRData CSelectedData = new VSRData();
            ClearTextBoxes();
            if (nSelectIndex != -1)
            {
                strSelected = PrjListBox.SelectedItem.ToString();
                CSelectedData.SetFileName(strSelected);
                CSelectedData = DataList[nSelectIndex];
                PrintItemToListView(CSelectedData.SensorList,       SensorListView);
                PrintItemToListView(CSelectedData.PartsList,        ConfigListView);
                PrintItemToListView(CSelectedData.IRCFList,         IRCFListView);
                PrintItemToListView(CSelectedData.LensList,         LensListView);
                PrintItemToListView(CSelectedData.StiffenerList,    StiffenerListView);
                PrintItemToListView(CSelectedData.SubstrateList,    SubstrateListView);
                PrintItemToListView(CSelectedData.FlexList,         FlexListView);
                PrintItemToListView(CSelectedData.CarrierList,      CarrierListView);
                PrintItemToListView(CSelectedData.CameraBuildList,  BuildListView);
                PrintEEEEToTextBox(CSelectedData);

                int nIndex = strSelected.IndexOf('-');

                PrjTextBox.Text = strSelected.Substring(nIndex+1);

                m_cRefData.m_strPrjName = strSelected.Substring(nIndex + 1);
            }
        }

        private void initAllListViews()
        {
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

        private void InitListView(ListView inListView)
        {
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
            PrjListBox.Items.Clear();

            foreach (var temp in DataList)
            {
                PrjListBox.Items.Add(temp.m_strVSRVersion + "-" + temp.m_strPrjName);
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
                    if (fileItem.Name.IndexOf(".ini")==-1)
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
            string strTemp = PrjListBox.SelectedItem.ToString();
            VSRData CSelectedData = new VSRData();
            CSelectedData.SetFileName(strTemp);
            int nSelectIndex = -1;
            nSelectIndex = PrjListBox.SelectedIndex;

            if (nSelectIndex != -1 && strTemp != "")
            {
                CSelectedData = DataList[nSelectIndex];
                AddPrjForm addDlg = new AddPrjForm(CSelectedData);
                addDlg.SendAddResultEvent += new AddPrjForm.SendAddResult(GetAddResult);
                addDlg.ShowDialog();
            }
        }

        private void SensorListView_MouseClick(object sender, MouseEventArgs e)
        {
            int nSelecedIndex = -1;
            if (nSelecedIndex != -1)
            {
                nSelecedIndex = SensorListView.FocusedItem.Index;
                string strSelectdItem;
                strSelectdItem = SensorListView.FocusedItem.SubItems[1].Text.ToString();

                m_cRefData.Sensor.strVendorName = SensorListView.FocusedItem.SubItems[1].Text.ToString();
                m_cRefData.Sensor.strBinaryValue = SensorListView.FocusedItem.SubItems[2].Text.ToString();
                m_cRefData.Sensor.strHexValue = SensorListView.FocusedItem.SubItems[3].Text.ToString();
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
            }           
        }

        private void IRCFListView_Click(object sender, EventArgs e)
        {
            int nSelecedIndex = -1;
            nSelecedIndex = IRCFListView.FocusedItem.Index;
            if (nSelecedIndex != -1)
            {
                string strSelectdItem;
                strSelectdItem = IRCFListView.FocusedItem.SubItems[1].Text.ToString();

                IRCFTextBox.Text = strSelectdItem[0].ToString();

                m_cRefData.IRCF.strVendorName   = IRCFListView.FocusedItem.SubItems[1].Text.ToString();
                m_cRefData.IRCF.strBinaryValue  = IRCFListView.FocusedItem.SubItems[2].Text.ToString();
                m_cRefData.IRCF.strHexValue     = IRCFListView.FocusedItem.SubItems[3].Text.ToString();
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

                m_cRefData.Carrier.strVendorName    = CarrierListView.FocusedItem.SubItems[1].Text.ToString();
                m_cRefData.Carrier.strBinaryValue   = CarrierListView.FocusedItem.SubItems[2].Text.ToString();
                m_cRefData.Carrier.strHexValue      = CarrierListView.FocusedItem.SubItems[3].Text.ToString();
            }
        }
    }
}
