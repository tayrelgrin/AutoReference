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

        private void prjDeleteButton_Click(object sender, EventArgs e)
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

            PrintMidResultForm midDlg = new PrintMidResultForm();

            this.Hide();
            midDlg.ShowDialog();
            this.Show();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PjrListBox_Click(object sender, EventArgs e)
        {
            int nSelectIndex = -1;

            nSelectIndex = PrjListBox.SelectedIndex;
            string strTemp;

            VSRData CSelectedData = new VSRData();

            if (nSelectIndex != -1)
            {
                strTemp = PrjListBox.SelectedItem.ToString();
                CSelectedData.SetFileName(strTemp);
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

        private bool MakeDirectory(string inStrPath)
        {
            System.IO.Directory.CreateDirectory(inStrPath);

            return true;
        }

        private bool FileCopyToRefDir()
        {
            string path = @"xxxx.txt";
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                try
                {
                    file.CopyTo(@"xxx2.txt", false);
                }
                catch (FileLoadException fileNotFound)
                {
                    MessageBox.Show(fileNotFound.Message);
                    return false;
                }
            }
            return true;
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

            nSelecedIndex = SensorListView.FocusedItem.Index;
           // string strSelecteIndex = SensorListView.FocusedItem.Index;
            SensorListView.BeginUpdate();
            int nIndex = 0;
            foreach (ListViewItem item in SensorListView.Items)
            {
                if (nIndex == nSelecedIndex)
                {
                    item.BackColor = Color.Aqua;
                    item.Focused = true;
                }
                else
                {
                    item.BackColor = Color.White;
                    item.Focused = false;
                }
                nIndex++;
            }
            SensorListView.EndUpdate();
        }
    }
}
