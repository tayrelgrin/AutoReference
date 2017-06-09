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
        private List<string> strList = new List<string>();
        private BaseData CNewBaseData = new BaseData();
        private VSRData CNewVSRData = null;
        private ContextMenu CMenu = new ContextMenu();

        public delegate void SendAddResult(bool bResult, VSRData CVSRData);
        public event SendAddResult SendAddResultEvent;

        public AddPrjForm(string strPath)
        {
            m_strPartData = null;
            m_bParts = false;
            CNewVSRData = new VSRData();
            InitializeComponent();

            SetRightClickMenu();
            InitAllListViews();

            string strPDFPath = strPath;
            string strTXTPath = null;

            ExtractPDFtoText(strPDFPath, ref strTXTPath);
            DataTXTFileLoad(strTXTPath);
            ExtractPrjName(strTXTPath);
            DataParcingAndPrint();
            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
        }

        public AddPrjForm(VSRData inData)
        {
            InitializeComponent();
            CNewVSRData = inData;
            SetRightClickMenu();
            // Set cursor as default arrow
            Cursor.Current = Cursors.Default;
            
            InitAllListViews();
            PrintItemsToListBox();
        }

        private void SetRightClickMenu()
        {
            MenuItem m1 = new MenuItem("Add");
            MenuItem m2 = new MenuItem("Modify");
            MenuItem m3 = new MenuItem("Delete");
            CMenu.MenuItems.Add(m1);
            CMenu.MenuItems.Add(m2);
            CMenu.MenuItems.Add(m3);
        }

        private void AddCloseButtonClick(object sender, EventArgs e)
        {
            this.SendAddResultEvent(false, CNewVSRData);
            Close();
        }

        private bool DataTXTFileLoad(string strFilePath)
        {
            string strData;
            
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(strFilePath);

                while ((strData = file.ReadLine()) != null)
                {
                    System.Console.WriteLine(strData);
                   
                    strList.Add(strData);
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
            this.SendAddResultEvent(true, CNewVSRData);
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
                    System.IO.StreamReader file = new System.IO.StreamReader(fileItem.Name);

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

            CNewVSRData.m_strVSRVersion = strFileName[0].Substring(strFileName[0].Length - 2);

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
            CNewVSRData.m_strPrjName = strProjectName;
        }

        private void PrintItemsToListBox()
        {
            PrjListBox.Items.Clear();
            PrjListBox.Items.Add(CNewVSRData.m_strPrjName);

            VersionListBox.Items.Clear();
            VersionListBox.Items.Add(CNewVSRData.m_strVSRVersion);

            PrintToListView(PartsListView, ref CNewVSRData.PartsList);
            PrintToListView(NVMListView, ref CNewVSRData.NVMList);
            PrintToListView(CameraPrjListView, ref CNewVSRData.CameraPrjList);
            PrintToListView(ProgramVariantListView, ref CNewVSRData.ProgramVariantList);
            PrintToListView(IntegratorListView, ref CNewVSRData.IntegratorList);
            PrintToListView(LensListView, ref CNewVSRData.LensList);
            PrintToListView(IRCFListView, ref CNewVSRData.IRCFList);
            PrintToListView(SubstrateListView, ref CNewVSRData.SubstrateList);
            PrintToListView(SensorListView, ref CNewVSRData.SensorList);
            PrintToListView(FlexListView, ref CNewVSRData.FlexList);
            PrintToListView(StiffenerListView, ref CNewVSRData.StiffenerList);
            PrintToListView(CameraListView, ref CNewVSRData.CameraBuildList);
            PrintToListView(AlgorithmListView, ref CNewVSRData.AlgorithmList);
            PrintToListView(ColorShadingListView, ref CNewVSRData.ColorShadingList);
            PrintToListView(TraceabilityRevListView, ref CNewVSRData.TraceabilityRevList);

            EEEEListBox.Items.Clear();
            EEEEListBox.Items.Add(CNewVSRData.m_strEEEE);
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


            foreach (var temp in strList)
            {
                if (bFindPartsFlag)
                {
                    ParcingPartData(temp, ref CNewVSRData.PartsList);

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
                    ParcingData(temp, ref CNewVSRData.NVMList);
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
                    ParcingData(temp, ref CNewVSRData.CameraPrjList);
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
                    ParcingData(temp, ref CNewVSRData.ProgramVariantList);
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
                    if(ParcingData(temp, ref CNewVSRData.IntegratorList))
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
                    ParcingData(temp, ref CNewVSRData.LensList);
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
                    ParcingData(temp, ref CNewVSRData.IRCFList);
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
                    ParcingData(temp, ref CNewVSRData.SubstrateList);
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
                    ParcingData(temp, ref CNewVSRData.SensorList);
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
                    ParcingData(temp, ref CNewVSRData.FlexList);
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
                    ParcingData(temp, ref CNewVSRData.StiffenerList);
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
                    ParcingData(temp, ref CNewVSRData.CameraBuildList);
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
                    ParcingData(temp, ref CNewVSRData.AlgorithmList);
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
                    if(ParcingData(temp, ref CNewVSRData.ColorShadingList))
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
                    if(ParcingData(temp, ref CNewVSRData.TraceabilityRevList))
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
                PrintItemsToListBox();
            }
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
                    inTargetListView.Items.Add(lvi);
                }
            }
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
                CNewVSRData.m_strEEEE = inString.Substring(inString.LastIndexOf("F0W") + 3).Trim();
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
            m_CTempData.strVendorName   = CNewVSRData.m_strPrjName;
            m_CTempData.strBinaryValue  = CNewVSRData.m_strVSRVersion;

            ModifyForm Cmodify = new ModifyForm("Project", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();

            CNewVSRData.m_strPrjName = m_CTempData.strVendorName;
            CNewVSRData.m_strVSRVersion = m_CTempData.strBinaryValue;
            PrintItemsToListBox();
        }
      
        private void PrjListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(PrjListBox, new System.Drawing.Point(e.X, e.Y));
        }        

        private void SensorListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(SensorListView, new System.Drawing.Point(e.X, e.Y));
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
    }
}
