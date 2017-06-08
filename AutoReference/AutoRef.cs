using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

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

            DataList = new List<VSRData>();

            DataFileLoad();
            
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

            if (InputRefCheckBox.Checked)
            {
                FolderBrowserDialog ofd = new FolderBrowserDialog();

                ofd.ShowDialog();

                selected = ofd.SelectedPath;
            }

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
            VSRData CSelectedData = new VSRData();

            if (nSelectIndex != -1)
            {
                CSelectedData = DataList[nSelectIndex];

                PrintEEEEToListBox(CSelectedData);
                PrintToListBox(CSelectedData.PartsList, ConfigListBox);
                PrintToListBox(CSelectedData.IRCFList, IRCFListBox);
                PrintToListBox(CSelectedData.SensorList, SensorListBox);
                PrintToListBox(CSelectedData.StiffenerList, StiffenerListBox);
                PrintToListBox(CSelectedData.SubstrateList, SubstrateListBox);
                PrintToListBox(CSelectedData.LensList, LensListBox);
                PrintToListBox(CSelectedData.FlexList, FlexListBox);
            }
        }

        void GetAddResult(bool inResult, VSRData inAddVSR)
        {
            m_AddVSR = inAddVSR;
            m_bAddResult = inResult;
        }
        
        private void PrintConfigToListBox(List<BaseData> inData)
        {
            ConfigListBox.Items.Clear();
            VSRData aa = new VSRData();

            foreach (var temp in inData)
            {
                ConfigListBox.Items.Add(temp.strVendorName + " " + temp.strBinaryValue);
            }
        }

        private void PrintToListBox(List<BaseData> inData, ListBox inListBox)
        {
            inListBox.Items.Clear();
            foreach (var temp in inData)
            {
                inListBox.Items.Add(temp.strVendorName + " " + temp.strBinaryValue + " " + temp.strHexValue);
            }
        }

        private void PrintFlexToListBox(List<BaseData> inData)
        {
            FlexListBox.Items.Clear();
            foreach (var temp in inData)
            {
                FlexListBox.Items.Add(temp.strVendorName + " " + temp.strBinaryValue);
            }
        }

        private void PrintSubstrateToListBox(List<BaseData> inData)
        {
            SubstrateListBox.Items.Clear();
            foreach (var temp in inData)
            {
                SubstrateListBox.Items.Add(temp.strVendorName + " " + temp.strBinaryValue);
            }
        }

        private void PrintLensToListBox(List<BaseData> inData)
        {
            LensListBox.Items.Clear();
            foreach (var temp in inData)
            {
                LensListBox.Items.Add(temp.strVendorName + " " + temp.strBinaryValue);
            }
        }

        private void PrintEEEEToListBox(VSRData inData)
        {
            EEEEListBox.Items.Clear();
            EEEEListBox.Items.Add(inData.m_strEEEE);
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
            EEEEListBox.Items.Clear();
            ConfigListBox.Items.Clear();
            IRCFListBox.Items.Clear();
            SensorListBox.Items.Clear();
            StiffenerListBox.Items.Clear();
            SubstrateListBox.Items.Clear();
            LensListBox.Items.Clear();
            FlexListBox.Items.Clear();
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
    }
}
