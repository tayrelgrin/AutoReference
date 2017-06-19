using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bytescout.PDFExtractor;


namespace AutoReference
{
    public partial class AddPrjForm : Form
    {
        
        private string m_strPartData;
        private bool m_bParts;

        private BaseData m_CTempData = new BaseData();        
        private List<string> m_strList = new List<string>();
        private List<BaseData>  m_SelectList;
        private int m_nSelectIndex = -1;
        private BaseData m_cNewBaseData = new BaseData();
        private string m_strNewBaseDataName = "";
        private VSRData m_cNewVSRData = null;
        private ContextMenu CMenu = new ContextMenu();

        public delegate void SendAddResult(bool bResult, VSRData CVSRData);

        public event SendAddResult SendAddResultEvent;

        public AddPrjForm(string strPath)
        {
            m_strPartData = null;
            m_bParts = false;
            m_cNewVSRData = new VSRData();
            InitializeComponent();
            SetRightClickMenu();
            InitAllListViews();

            string strPDFPath = strPath;
            string strTXTPath = null;

            ExtractPDFtoText(strPDFPath, ref strTXTPath);
            DataTXTFileLoad(strTXTPath);

            if (CheckVSRDoc())
            {
                ExtractPrjName(strTXTPath);
                DataParcingAndPrint();
            }
            else
            {
                MessageBox.Show("Input File isn't VSR");
            }
            System.IO.FileInfo fileDel = new System.IO.FileInfo(strTXTPath);
            fileDel.Delete();

            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
        }

        public AddPrjForm(VSRData inData)
        {
            InitializeComponent();
            m_cNewVSRData = inData;
            SetRightClickMenu();
            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
            
            InitAllListViews();
            PrintItemsToListBox();
        }

        private bool CheckVSRDoc()
        {
            bool bResult = false;

            foreach (string strLine in m_strList)
            {
                if (strLine.IndexOf("Title: VSR,") != -1)
                {
                    bResult = true;
                    break;
                }
            }

            return bResult;
        }

        private void SetRightClickMenu()
        {
            MenuItem m1 = new MenuItem("Add");
            MenuItem m2 = new MenuItem("Modify");
            MenuItem m3 = new MenuItem("Delete");
            CMenu.MenuItems.Add(m1);
            CMenu.MenuItems.Add(m2);
            CMenu.MenuItems.Add(m3);

            m1.Click += new System.EventHandler(this.RightItemAddClick);
            m2.Click += new System.EventHandler(this.RightItemModifyClick);
            m3.Click += new System.EventHandler(this.RightItemDeleteClick);
        }

        private void RightItemAddClick(object sender, System.EventArgs e)
        {
            BaseData cNewBaseData = new BaseData();
            ModifyForm cNewData = new ModifyForm(m_strNewBaseDataName, cNewBaseData);
            cNewData.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);
            cNewData.ShowDialog();
            cNewBaseData = m_CTempData;
            if (cNewBaseData.strVendorName != "" || cNewBaseData.strBinaryValue != "")
            {
                m_SelectList.Add(cNewBaseData);
            }
            PrintItemsToListBox();
        }

        private void RightItemModifyClick(object sender, System.EventArgs e)
        {
            int nSelectIndex = m_nSelectIndex;

            if (nSelectIndex > -1)
            {
                m_CTempData.strVendorName = m_SelectList[nSelectIndex].strVendorName;
                m_CTempData.strBinaryValue = m_SelectList[nSelectIndex].strBinaryValue;
                m_CTempData.strHexValue = m_SelectList[nSelectIndex].strHexValue;

                ModifyForm Cmodify = new ModifyForm(m_strNewBaseDataName, m_CTempData);
                Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

                Cmodify.ShowDialog();

                m_SelectList[nSelectIndex].strVendorName = m_CTempData.strVendorName;
                m_SelectList[nSelectIndex].strBinaryValue = m_CTempData.strBinaryValue;
                m_SelectList[nSelectIndex].strHexValue = m_CTempData.strHexValue;
                PrintItemsToListBox();
            }
        }

        private void RightItemDeleteClick(object sender, System.EventArgs e)
        {
             int nSelectIndex = m_nSelectIndex;

             if (nSelectIndex > -1)
             {
                 m_SelectList.RemoveAt(nSelectIndex);
                 PrintItemsToListBox();
             }
        }

        private void AddCloseButtonClick(object sender, EventArgs e)
        {
            this.SendAddResultEvent(false, m_cNewVSRData);
            Close();
        }

        private bool DataTXTFileLoad(string strFilePath)
        {
            string strData;
            
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(strFilePath, Encoding.Default);

                while ((strData = file.ReadLine()) != null)
                {
                    System.Console.WriteLine(strData);
                   
                    m_strList.Add(strData);
                }
                file.Close();
            }

            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            
            return true;
        }

        private void AddOKButtonClick(object sender, EventArgs e)
        {
            this.SendAddResultEvent(true, m_cNewVSRData);
            Close();
        }

        private bool ReadFileFromDirectory(System.IO.DirectoryInfo subDirec)
        {
            string strData;

            foreach (var fileItem in subDirec.GetFiles())
            {
                if (fileItem.Name.IndexOf(".txt") == -1)
                {
                    continue;
                }
                try
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(fileItem.Name, Encoding.Default);

                    while ((strData = file.ReadLine()) != null)
                    {
                        System.Console.WriteLine(strData);
                        if (strData != "")
                        {

                        }
                    }

                    file.Close();
                }
                catch (System.IO.FileNotFoundException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            return true;
        }

        private void ExtractPDFtoText(string inFilePath, ref string inTXTPath)
        {
            TextExtractor extractor = new TextExtractor();

            Cursor.Current = Cursors.WaitCursor;

            extractor.RegistrationName = "demo";
            extractor.RegistrationKey = "demo";

            // Load PDF document
            extractor.LoadDocumentFromFile(inFilePath);

            // Save extracted text to file
            inFilePath = inFilePath.Replace(".pdf", ".txt");
            extractor.SaveTextToFile(inFilePath);

            inTXTPath = inFilePath;
        }

        private void ExtractPrjName(string inFileName)
        {
            string[] strArray = inFileName.Split('\\');

            string[] strFileName = strArray[strArray.Length - 1].Split('_');
            string strProjectName = null;
            int nCowellIndex = 0;

            m_cNewVSRData.m_strVSRVersion = strFileName[0].Substring(strFileName[0].Length - 2);

            foreach (var temp in strFileName)
            {
                if (temp.IndexOf("Cowell") != -1)
                {
                    break;
                }
                nCowellIndex++;
            }
            for (int i = 0; i < nCowellIndex-1; i++)
            {
                strProjectName += strFileName[i + 1];
            }
            if (strProjectName != null)
            {
                m_cNewVSRData.m_strPrjName = strProjectName;
            }
            else
            {
                MessageBox.Show("VSR File Name isn't follow the naming rule");
                m_cNewVSRData.m_strPrjName = "";
            }
        }

        private void PrintItemsToListBox()
        {
            PrjListBox.Items.Clear();
            PrjListBox.Items.Add(m_cNewVSRData.m_strPrjName);

            VersionListBox.Items.Clear();
            VersionListBox.Items.Add(m_cNewVSRData.m_strVSRVersion);

            PrintToListView(PartsListView,          ref m_cNewVSRData.PartsList);
            PrintToListView(NVMListView,            ref m_cNewVSRData.NVMList);
            PrintToListView(CameraPrjListView,      ref m_cNewVSRData.CameraPrjList);
            PrintToListView(ProgramVariantListView, ref m_cNewVSRData.ProgramVariantList);
            PrintToListView(IntegratorListView,     ref m_cNewVSRData.IntegratorList);
            PrintToListView(LensListView,           ref m_cNewVSRData.LensList);
            PrintToListView(IRCFListView,           ref m_cNewVSRData.IRCFList);
            PrintToListView(SubstrateListView,      ref m_cNewVSRData.SubstrateList);
            PrintToListView(SensorListView,         ref m_cNewVSRData.SensorList);
            PrintToListView(FlexListView,           ref m_cNewVSRData.FlexList);
            PrintToListView(StiffenerListView,      ref m_cNewVSRData.StiffenerList);
            PrintToListView(CameraListView,         ref m_cNewVSRData.CameraBuildList);
            PrintToListView(AlgorithmListView,      ref m_cNewVSRData.AlgorithmList);
            PrintToListView(ColorShadingListView,   ref m_cNewVSRData.ColorShadingList);
            PrintToListView(TraceabilityRevListView,ref m_cNewVSRData.TraceabilityRevList);

            EEEEListBox.Items.Clear();
            EEEEListBox.Items.Add(m_cNewVSRData.m_strEEEE);
        }

        private void DataParcingAndPrint()
        {
            bool bFindPartsFlag         = false;
            bool bFindNVMFlag           = false;
            bool bFindCameraPrj         = false;
            bool bFindProgramVariant    = false;
            bool bFindIntegrator        = false;
            bool bFindLensvendor        = false;
            bool bFindIRCF              = false;
            bool bFindSubstrate         = false;
            bool bFindSensor            = false;
            bool bFindFlex              = false;
            bool bFindStiffener         = false;
            bool bFindCameraBuild       = false;
            bool bFindTSAR              = false;
            
            bool bFindColorShadingRev   = false;
            bool bFindTraceabilityRev   = false;


            foreach (var temp in m_strList)
            {
                if (bFindPartsFlag)
                {
                    ParcingPartData(temp, ref m_cNewVSRData.PartsList);

                    if (temp.Length == 0)
                    {
                        bFindPartsFlag = false;
                    }
                }
                if (temp.IndexOf("EEEE") != -1 && temp.IndexOf("EEEER") == -1)
                {
                    bFindPartsFlag = true;
                }

                if (bFindNVMFlag)
                {
                    ParcingData(temp, ref m_cNewVSRData.NVMList);
                    if (temp.Length == 0)
                    {
                        bFindNVMFlag = false;
                    }
                }
                if (temp.IndexOf("NVM Version") != -1 )
                {
                    bFindNVMFlag = true;
                }
                //
                if (bFindCameraPrj )
                {
                    ParcingData(temp, ref m_cNewVSRData.CameraPrjList);
                    if (temp.Length == 0)
                    {
                        bFindCameraPrj = false;
                    }
                }
                if (temp.IndexOf("Camera Project") != -1)
                {
                    bFindCameraPrj = true;
                }
                //
                if (bFindProgramVariant )
                {
                    ParcingData(temp, ref m_cNewVSRData.ProgramVariantList);
                    if (temp.Length == 0)
                    {
                        bFindProgramVariant = false;
                    }
                }
                if (temp.IndexOf("Program Variant") != -1)
                {
                    bFindProgramVariant = true;
                }
                //
                if (bFindIntegrator )
                {
                    if(ParcingData(temp, ref m_cNewVSRData.IntegratorList))
                    //if (temp.Length == 0)
                    {
                        bFindIntegrator = false;
                    }
                }
                if (temp.IndexOf("Integrator") != -1)
                {
                    bFindIntegrator = true;
                }
                //
                if (bFindLensvendor)
                {
                    ParcingData(temp, ref m_cNewVSRData.LensList);
                    if (temp.Length == 0)
                    {
                        bFindLensvendor = false;
                    }
                }
                if (temp.IndexOf("Lens vendor") != -1)
                {
                    bFindLensvendor = true;
                }
                //
                if (bFindIRCF)
                {
                    ParcingData(temp, ref m_cNewVSRData.IRCFList);
                    if (temp.Length==0)
                    {
                        bFindIRCF = false;
                    }
                }
                if (temp.IndexOf("IRCF") != -1)
                {
                    bFindIRCF = true;
                }
                //
                if (bFindSubstrate )
                {
                    ParcingData(temp, ref m_cNewVSRData.SubstrateList);
                    if (temp.Length == 0)
                    {
                        bFindSubstrate = false;
                    }
                }
                if (temp.IndexOf("Substrate") != -1)
                {
                    bFindSubstrate = true;
                }
                //
                if (bFindSensor )
                {
                    ParcingData(temp, ref m_cNewVSRData.SensorList);
                    if (temp.Length == 0)
                    {
                        bFindSensor = false;
                    }                    
                }
                if (temp.IndexOf("Sensor") != -1)
                {
                    bFindSensor = true;
                }
                //
                if (bFindFlex )
                {
                    ParcingData(temp, ref m_cNewVSRData.FlexList);
                    if (temp.Length == 0)
                    {
                        bFindFlex = false;
                    }
                }
                if (temp.IndexOf("Flex") != -1)
                {
                    bFindFlex = true;
                }
                //
                if (bFindStiffener )
                {
                    ParcingData(temp, ref m_cNewVSRData.StiffenerList);
                    if (temp.Length == 0)
                    {
                        bFindStiffener = false;
                    }
                }
                if (temp.IndexOf("Stiffener") != -1)
                {
                    bFindStiffener = true;
                }
                //
                if (bFindCameraBuild )
                {
                    ParcingData(temp, ref m_cNewVSRData.CameraBuildList);
                    if (temp.Length == 0)
                    {
                        bFindCameraBuild = false;
                    }
                }
                if (temp.IndexOf("Camera Build") != -1)
                {
                    bFindCameraBuild = true;
                }
                //
                if (bFindTSAR)
                {
                    ParcingData(temp, ref m_cNewVSRData.AlgorithmList);
                    if (temp.Length == 0)
                    {
                        bFindTSAR = false;
                    }
                }
                if (temp.IndexOf("Test Software") != -1)
                {
                    bFindTSAR = true;
                }
                //
                if (bFindColorShadingRev)
                {
                    if(ParcingData(temp, ref m_cNewVSRData.ColorShadingList))
                    //if (temp.Length == 0)
                    {
                        bFindColorShadingRev = false;
                    }
                }
                if (temp.IndexOf("Color Shading Revision") != -1)
                {
                    bFindColorShadingRev = true;
                }
                //
                if (bFindTraceabilityRev)
                {
                    if(ParcingData(temp, ref m_cNewVSRData.TraceabilityRevList))
                    //if (temp.Length == 0)
                    {
                        bFindTraceabilityRev = false;
                    }
                }
                if (temp.IndexOf("Traceability Revision") != -1)
                {
                    bFindTraceabilityRev = true;
                }
                //
            }
            PrintItemsToListBox();
        }

        private void PrintToListBox(ListBox inTargetListBox,ref List<BaseData> inList )
        {
            inTargetListBox.Items.Clear();

            foreach (var printData in inList)
            {
                inTargetListBox.Items.Add(printData.strVendorName + ", " + printData.strBinaryValue + ", " + printData.strHexValue);
            }
        }

        private void PrintToListView(ListView inTargetListView, ref List<BaseData> inList)
        {
            inTargetListView.Items.Clear();
            if (inTargetListView == PartsListView)
            {
                foreach (var printData in inList)
                {
                    ListViewItem lvi = new ListViewItem("");
                    lvi.SubItems.Add(printData.strVendorName);
                    inTargetListView.Items.Add(lvi);
                }
            }
            else
            {
                foreach (var printData in inList)
                {
                    ListViewItem lvi = new ListViewItem("");                    
                    lvi.SubItems.Add(printData.strVendorName);
                    lvi.SubItems.Add(printData.strBinaryValue);
                    lvi.SubItems.Add(printData.strHexValue);
                    if (CheckBinaryHex(printData.strBinaryValue, printData.strHexValue) == false)
                    {
                        lvi.BackColor = Color.Red;
                    }
                    else
                        lvi.BackColor = Color.White;
                    inTargetListView.Items.Add(lvi);
                }
            }
        }

        private bool CheckBinaryHex(string inBinary, string inHex)
        {
            bool bResult = true;
            string strConvert = "";
            inHex = inHex.Trim();
            inBinary = inBinary.Trim();
            string[] strBinarySplit = inBinary.Split(' ');
            
            string[] strHexSplit = inHex.Split(' ');
            string strHexTarget = "";

            if (strBinarySplit.Length > strHexSplit.Length)
            {
                string temp = inBinary.Replace(" ", "");
                inBinary = temp;
                strBinarySplit = inBinary.Split(' ');
            }
            int nCount = 0;
            foreach (string strBi in strBinarySplit)
            {
                try
                {
                    strHexTarget = strHexSplit[nCount++].Replace("0x","");
                    strConvert = Convert.ToInt32(strBi, 2).ToString("X");
                    if (strConvert.Length != strHexTarget.Length)
                    {
                        strConvert = "0" + strConvert;
                    }

                    if (strConvert != strHexTarget)
                    {
                        bResult = false;
                        break;
                    }
                }
                catch
                {
                    bResult = false;
                    break;
                }
            }

            return bResult;
        }

        private bool ParcingData(string inString, ref List<BaseData> inList)
        {
            BaseData CBaseData = new BaseData();

            int n0xIndex    = inString.IndexOf("0x");
            int n0Index     = inString.IndexOf("0");
            string[] strTempArray = inString.Split(' ');
            string strBinary = null;
            string strHex = null;
            int n0xCount = 0;
            int nBinaryCount = 0;
            int nInt0Index = inString.IndexOf("0");

            foreach (var temp in strTempArray)
            {
                int nDummy;
                if (Int32.TryParse(temp, out nDummy) && (temp.Length>1))
                {
                    strBinary = strBinary + " " + temp;
                    nBinaryCount++;
                }
                if (temp.IndexOf("0x") != -1)
                {
                    strHex = strHex + " " + temp;
                    n0xCount++;
                }
            }

            if (n0xIndex != -1)
            {
                CBaseData.strVendorName = inString.Substring(0, nInt0Index).Trim();
                CBaseData.strBinaryValue = strBinary;
                CBaseData.strHexValue = strHex;
                inList.Add(CBaseData);

                return true;
            }
            return false;
        }

        private void ParcingPartData(string inString, ref List<BaseData> inList)
        {
            BaseData CBaseData = new BaseData();

            if (inString.IndexOf("Config") != -1)
            {
                m_strPartData = inString.Trim();
                m_bParts = true;
            }
            else if (inString.IndexOf("F0W") != -1)
            {
                m_cNewVSRData.m_strEEEE = inString.Substring(inString.LastIndexOf("F0W") + 3).Trim();
            }
            else if (m_bParts)
            {
                CBaseData.strVendorName = m_strPartData +", "+ inString.Trim();
                inList.Add(CBaseData);
                m_bParts = false;
                m_strPartData = null;
            }
        }

        void GetModifyResult(bool inResult, BaseData inData)
        {
            if (inResult)
            {
                m_CTempData = inData;
            }
        }

        private void PrjListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = PrjListBox.SelectedIndex;
            m_CTempData.strVendorName   = m_cNewVSRData.m_strPrjName;
            m_CTempData.strBinaryValue  = m_cNewVSRData.m_strVSRVersion;

            ModifyForm Cmodify = new ModifyForm("Project", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();

            m_cNewVSRData.m_strPrjName = m_CTempData.strVendorName;
            m_cNewVSRData.m_strVSRVersion = m_CTempData.strBinaryValue;
            PrintItemsToListBox();
        }
      
        private void PrjListBox_MouseDown(object sender, MouseEventArgs e)
        {
//             if (e.Button == MouseButtons.Right)
//                 CMenu.Show(PrjListBox, new System.Drawing.Point(e.X, e.Y));
        }        

        private void EEEEListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(EEEEListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void InitAllListViews()
        {
            InitListView(PartsListView);
            InitListView(NVMListView);
            InitListView(LensListView);
            InitListView(SubstrateListView);
            InitListView(CameraPrjListView);
            InitListView(ProgramVariantListView);
            InitListView(IntegratorListView);
            
            InitListView(IRCFListView);
            InitListView(SensorListView);
            InitListView(FlexListView);
            InitListView(StiffenerListView);
            InitListView(CameraListView);
            InitListView(AlgorithmListView);
            InitListView(ColorShadingListView);
            InitListView(TraceabilityRevListView);
        }

        private void InitListView(ListView inListView)
        {
            inListView.FullRowSelect = true;
            inListView.Columns.Add("", 0);
            
            if (inListView != PartsListView)
            {
                inListView.Columns.Add("Item", 130);
                inListView.Columns.Add("Binary", 80);
                inListView.Columns.Add("Hex", 80);
            }
            else
            {
                inListView.Columns.Add("Item", 300);
            }
        }

        private void PartsListView_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = PartsListView.FocusedItem.Index;
            string strConfig = m_cNewVSRData.PartsList[nSelectIndex].strVendorName;
            string[] strConfigData = strConfig.Split(',');
            m_CTempData.strVendorName = strConfigData[0];
            m_CTempData.strBinaryValue = strConfigData[1];
            m_CTempData.strHexValue = m_cNewVSRData.PartsList[nSelectIndex].strHexValue;

            ModifyForm Cmodify = new ModifyForm("Parts", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();

            strConfigData[0] = m_CTempData.strVendorName;
            strConfigData[1] = m_CTempData.strBinaryValue;
            m_cNewVSRData.PartsList[nSelectIndex].strVendorName = strConfigData[0] + "," + strConfigData[1];
            m_cNewVSRData.PartsList[nSelectIndex].strHexValue = m_CTempData.strHexValue;
            PrintItemsToListBox();
        }

        private void NVMListView_DoubleClick(object sender, EventArgs e)
        {
            ModifyData("NVM", NVMListView, ref m_cNewVSRData.NVMList);           
            PrintItemsToListBox();
        }

        private void ModifyData(string inType, ListView inListView,ref List<BaseData> outList)
        {
            int nSelectIndex = inListView.FocusedItem.Index;       

            m_CTempData.strVendorName   = outList[nSelectIndex].strVendorName;
            m_CTempData.strBinaryValue  = outList[nSelectIndex].strBinaryValue;
            m_CTempData.strHexValue     = outList[nSelectIndex].strHexValue;

            ModifyForm Cmodify = new ModifyForm(inType, m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();

            outList[nSelectIndex].strVendorName     = m_CTempData.strVendorName;
            outList[nSelectIndex].strBinaryValue    = m_CTempData.strBinaryValue;
            outList[nSelectIndex].strHexValue       = m_CTempData.strHexValue;
        }

        private void LensListView_DoubleClick(object sender, EventArgs e)
        {
            ModifyData("Lens", LensListView, ref m_cNewVSRData.LensList);
            PrintItemsToListBox();
        }

        private void SubstrateListView_DoubleClick(object sender, EventArgs e)
        {
            ModifyData("Substrate", SubstrateListView, ref m_cNewVSRData.SubstrateList);
            PrintItemsToListBox();
        }

        private void CameraPrjListView_DoubleClick(object sender, EventArgs e)
        {
            ModifyData("CameraPrj", CameraPrjListView, ref m_cNewVSRData.CameraPrjList);
            PrintItemsToListBox();
        }

        private void ProgramVariantListView_DoubleClick(object sender, EventArgs e)
        {
            ModifyData("ProgramVariant", ProgramVariantListView, ref m_cNewVSRData.ProgramVariantList);
            PrintItemsToListBox();
        }

        private void IRCFListView_DoubleClick(object sender, EventArgs e)
        {
            ModifyData("IRCF", IRCFListView, ref m_cNewVSRData.IRCFList);
            PrintItemsToListBox();
        }

        private void SensorListView_DoubleClick(object sender, EventArgs e)
        {
            ModifyData("Sensor", SensorListView, ref m_cNewVSRData.SensorList);
            PrintItemsToListBox();
        }

        private void FlexListView_DoubleClick(object sender, EventArgs e)
        {
            ModifyData("Flex", FlexListView, ref m_cNewVSRData.FlexList);
            PrintItemsToListBox();
        }

        private void StiffenerListView_DoubleClick(object sender, EventArgs e)
        {
            ModifyData("Stiffener", StiffenerListView, ref m_cNewVSRData.StiffenerList);
            PrintItemsToListBox();
        }

        private void CameraListView_DoubleClick(object sender, EventArgs e)
        {
            ModifyData("Camera", CameraListView, ref m_cNewVSRData.CameraBuildList);
            PrintItemsToListBox();
        }

        private void AlgorithmListView_DoubleClick(object sender, EventArgs e)
        {
            ModifyData("Algorithm", AlgorithmListView, ref m_cNewVSRData.AlgorithmList);
            PrintItemsToListBox();
        }

        private void ColorShadingListView_DoubleClick(object sender, EventArgs e)
        {
            ModifyData("ColorShading", ColorShadingListView, ref m_cNewVSRData.ColorShadingList);
            PrintItemsToListBox();
        }

        private void TraceabilityRevListView_DoubleClick(object sender, EventArgs e)
        {
            ModifyData("TraceabilityRev", TraceabilityRevListView, ref m_cNewVSRData.TraceabilityRevList);
            PrintItemsToListBox();
        }

        private void VersionListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = PrjListBox.SelectedIndex;
            m_CTempData.strVendorName = m_cNewVSRData.m_strPrjName;
            m_CTempData.strBinaryValue = m_cNewVSRData.m_strVSRVersion;

            ModifyForm Cmodify = new ModifyForm("Project", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();

            m_cNewVSRData.m_strPrjName = m_CTempData.strVendorName;
            m_cNewVSRData.m_strVSRVersion = m_CTempData.strBinaryValue;
            PrintItemsToListBox();
        }

        private void IRCFListView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(IRCFListView, new System.Drawing.Point(e.X, e.Y));
        }

        private void VersionListBox_MouseDown(object sender, MouseEventArgs e)
        {
//             if (e.Button == MouseButtons.Right)
//                 CMenu.Show(VersionListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void PartsListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "Parts";
                int nIndex = PartsListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.PartsList[nIndex];
                m_SelectList = m_cNewVSRData.PartsList;
                CMenu.Show(PartsListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void NVMListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "NVM";
                int nIndex = NVMListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.NVMList[nIndex];
                m_SelectList = m_cNewVSRData.NVMList;
                CMenu.Show(NVMListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void LensListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "Lens";
                int nIndex = LensListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.LensList[nIndex];
                m_SelectList = m_cNewVSRData.LensList;
                CMenu.Show(LensListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void SubstrateListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "Substrate";
                int nIndex = SubstrateListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.SubstrateList[nIndex];
                m_SelectList = m_cNewVSRData.SubstrateList;
                CMenu.Show(SubstrateListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void CameraPrjListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "Camera Prj";
                int nIndex = CameraPrjListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.CameraPrjList[nIndex];
                m_SelectList = m_cNewVSRData.CameraPrjList;
                CMenu.Show(CameraPrjListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void ProgramVariantListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "Integrator";
                int nIndex = ProgramVariantListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.ProgramVariantList[nIndex];
                m_SelectList = m_cNewVSRData.ProgramVariantList;
                CMenu.Show(ProgramVariantListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void IntegratorListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "Integrator";
                int nIndex = IntegratorListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.IntegratorList[nIndex];
                m_SelectList = m_cNewVSRData.IntegratorList;
                CMenu.Show(IntegratorListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void IRCFListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "IRCF";
                int nIndex = IRCFListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.IRCFList[nIndex];
                m_SelectList = m_cNewVSRData.IRCFList;
                CMenu.Show(IRCFListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void SensorListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "Sensor";
                int nIndex = SensorListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.SensorList[nIndex];
                m_SelectList = m_cNewVSRData.SensorList;
                CMenu.Show(SensorListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void FlexListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "Flex";
                int nIndex = FlexListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.FlexList[nIndex];
                m_SelectList = m_cNewVSRData.FlexList;
                CMenu.Show(FlexListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void StiffenerListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "Stiffener";
                int nIndex = StiffenerListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.StiffenerList[nIndex];
                m_SelectList = m_cNewVSRData.StiffenerList;
                CMenu.Show(StiffenerListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void CameraListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "Camera Build";
                int nIndex = CameraListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.CameraBuildList[nIndex];
                m_SelectList = m_cNewVSRData.CameraBuildList;
                CMenu.Show(CameraListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void AlgorithmListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "Algorithm";
                int nIndex = AlgorithmListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.AlgorithmList[nIndex];
                m_SelectList = m_cNewVSRData.AlgorithmList;
                CMenu.Show(AlgorithmListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void ColorShadingListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "Color Shading";
                int nIndex = ColorShadingListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.ColorShadingList[nIndex];
                m_SelectList = m_cNewVSRData.ColorShadingList;
                CMenu.Show(ColorShadingListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void TraceabilityRevListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                m_strNewBaseDataName = "Traceability Rev";
                int nIndex = TraceabilityRevListView.FocusedItem.Index;
                m_cNewBaseData = m_cNewVSRData.TraceabilityRevList[nIndex];
                m_SelectList = m_cNewVSRData.TraceabilityRevList;
                CMenu.Show(TraceabilityRevListView, new System.Drawing.Point(e.X, e.Y));
                PrintItemsToListBox();
            }
        }

        private void EEEEListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = EEEEListBox.SelectedIndex;
            m_CTempData.strBinaryValue = m_cNewVSRData.m_strEEEE;

            ModifyForm Cmodify = new ModifyForm("EEEE", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();

            m_cNewVSRData.m_strEEEE = m_CTempData.strBinaryValue;
            PrintItemsToListBox();
        }
    }
}
