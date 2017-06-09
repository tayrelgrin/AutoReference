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
            PrjListBox.Items.Add(CNewVSRData.m_strVSRVersion + "-" + CNewVSRData.m_strPrjName);

//             PrintToListBox(PartsListBox, ref CNewVSRData.PartsList);
//             PrintToListBox(NVMListBox, ref CNewVSRData.NVMList);
//             PrintToListBox(CameraPrjListBox, ref CNewVSRData.CameraPrjList);
//             PrintToListBox(ProgramVariantListBox, ref CNewVSRData.ProgramVariantList);
//             PrintToListBox(IntegratorListBox, ref CNewVSRData.IntegratorList);
//             PrintToListBox(LensListBox, ref CNewVSRData.LensList);
//             PrintToListBox(IRCFListBox, ref CNewVSRData.IRCFList);
//             PrintToListBox(SubstrateListBox, ref CNewVSRData.SubstrateList);
//             PrintToListBox(SensorListBox, ref CNewVSRData.SensorList);
//             PrintToListBox(FlexListBox, ref CNewVSRData.FlexList);
//             PrintToListBox(StiffenerListBox, ref CNewVSRData.StiffenerList);
//             PrintToListBox(CameraListBox, ref CNewVSRData.CameraBuildList);
//             PrintToListBox(AlgorithmListBox, ref CNewVSRData.AlgorithmList);
//             PrintToListBox(ColorShadingListBox, ref CNewVSRData.ColorShadingList);
//             PrintToListBox(TraceabilityRevListBox, ref CNewVSRData.TraceabilityRevList);

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

        private void PartsListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = PartsListBox.SelectedIndex ;
            m_CTempData = CNewVSRData.PartsList[nSelectIndex];

            ModifyForm Cmodify = new ModifyForm("Parts", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.PartsList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void NVMListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = NVMListBox.SelectedIndex ;
            m_CTempData = CNewVSRData.NVMList[nSelectIndex];

            ModifyForm Cmodify = new ModifyForm("NVM", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.NVMList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void LensListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = LensListBox.SelectedIndex ;
            m_CTempData = CNewVSRData.LensList[nSelectIndex];
            ModifyForm Cmodify = new ModifyForm("Lens", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.LensList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void SubstrateListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = SubstrateListBox.SelectedIndex ;
            m_CTempData = CNewVSRData.SubstrateList[nSelectIndex];
            ModifyForm Cmodify = new ModifyForm("Substrate", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.SubstrateList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void CameraPrjListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = CameraPrjListBox.SelectedIndex;
            m_CTempData = CNewVSRData.CameraPrjList[nSelectIndex];
            ModifyForm Cmodify = new ModifyForm("Camera Project", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.CameraPrjList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void ProgramVariantListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = ProgramVariantListBox.SelectedIndex;
            m_CTempData = CNewVSRData.ProgramVariantList[nSelectIndex];
            ModifyForm Cmodify = new ModifyForm("Program Variant", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.ProgramVariantList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void IntegratorListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = IntegratorListBox.SelectedIndex;
            m_CTempData = CNewVSRData.IntegratorList[nSelectIndex];
            ModifyForm Cmodify = new ModifyForm("Integrator", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);
            
            Cmodify.ShowDialog();
            CNewVSRData.IntegratorList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void IRCFListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = IRCFListBox.SelectedIndex;
            m_CTempData = CNewVSRData.IRCFList[nSelectIndex];
            ModifyForm Cmodify = new ModifyForm("IRCF", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.IRCFList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void SensorListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = SensorListBox.SelectedIndex;
            m_CTempData = CNewVSRData.SensorList[nSelectIndex];
            ModifyForm Cmodify = new ModifyForm("Sensor", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.SensorList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void FlexListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = FlexListBox.SelectedIndex;
            m_CTempData = CNewVSRData.FlexList[nSelectIndex];
            ModifyForm Cmodify = new ModifyForm("Flex", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.FlexList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void StiffenerListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = StiffenerListBox.SelectedIndex;
            m_CTempData = CNewVSRData.StiffenerList[nSelectIndex];
            ModifyForm Cmodify = new ModifyForm("Stiffener", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.StiffenerList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void CameraListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = CameraListBox.SelectedIndex;
            m_CTempData = CNewVSRData.CameraBuildList[nSelectIndex];
            ModifyForm Cmodify = new ModifyForm("Camera Build", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.CameraBuildList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void AlgorithmListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = AlgorithmListBox.SelectedIndex;
            m_CTempData = CNewVSRData.AlgorithmList[nSelectIndex];
            ModifyForm Cmodify = new ModifyForm("Algorithm", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.AlgorithmList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void ColorCalListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = EEEEListBox.SelectedIndex;
          
        }

        private void ColorShadingListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = ColorShadingListBox.SelectedIndex;
            m_CTempData = CNewVSRData.ColorShadingList[nSelectIndex];
            ModifyForm Cmodify = new ModifyForm("Color Shading", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.ColorShadingList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void TraceabilityRevListBox_DoubleClick(object sender, EventArgs e)
        {
            int nSelectIndex = TraceabilityRevListBox.SelectedIndex;
            m_CTempData = CNewVSRData.TraceabilityRevList[nSelectIndex];
            ModifyForm Cmodify = new ModifyForm("Color Shading", m_CTempData);
            Cmodify.SendModifyResultEvent += new ModifyForm.SendModifyResult(GetModifyResult);

            Cmodify.ShowDialog();
            CNewVSRData.TraceabilityRevList[nSelectIndex] = m_CTempData;
            PrintItemsToListBox();
        }

        private void PrjListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(PrjListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void PartsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(PartsListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void NVMListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(NVMListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void LensListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(LensListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void SubstrateListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(SubstrateListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void CameraPrjListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(CameraPrjListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void ProgramVariantListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(ProgramVariantListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void IntegratorListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(ProgramVariantListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void IRCFListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(IRCFListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void SensorListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(SensorListBox, new System.Drawing.Point(e.X, e.Y));
        }
        
        private void FlexListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(FlexListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void StiffenerListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(StiffenerListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void CameraListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(CameraListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void AlgorithmListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(AlgorithmListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void EEEEListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(EEEEListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void ColorShadingListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(ColorShadingListBox, new System.Drawing.Point(e.X, e.Y));
        }

        private void TraceabilityRevListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                CMenu.Show(TraceabilityRevListBox, new System.Drawing.Point(e.X, e.Y));
        }
    }
}
