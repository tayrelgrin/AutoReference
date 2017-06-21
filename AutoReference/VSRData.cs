using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace AutoReference
{
    public class VSRData
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public List<BaseData> PartsList;
        public List<BaseData> NVMList;
        public List<BaseData> LensList;
        public List<BaseData> SubstrateList;
        public List<BaseData> CameraPrjList;
        public List<BaseData> ProgramVariantList;
        public List<BaseData> IntegratorList;
        public List<BaseData> LensComponentList;
        public List<BaseData> IRCFList;
        public List<BaseData> SensorList;
        public List<BaseData> StiffenerList;
        public List<BaseData> FlexList;
        public List<BaseData> CameraBuildList;
        public List<BaseData> AlgorithmList;
        public List<BaseData> ColorCalList;
        public List<BaseData> ColorShadingList;
        public List<BaseData> TraceabilityRevList;
        public List<BaseData> CarrierList;
        public List<BaseData> ConfigList;
        public string m_strEEEE;
        public string m_strVSRVersion;
        public string m_strPrjName;
        public string m_strFileName;
        

        public VSRData()
        {
            m_strVSRVersion = null;
            m_strPrjName    = null;
            m_strEEEE       = "";
            m_strFileName   = "";
            PartsList           = new List<BaseData>();
            NVMList             = new List<BaseData>();
            LensList            = new List<BaseData>();
            SubstrateList       = new List<BaseData>();
            CameraPrjList       = new List<BaseData>();
            ProgramVariantList  = new List<BaseData>();
            IntegratorList      = new List<BaseData>();
            LensComponentList   = new List<BaseData>();
            IRCFList            = new List<BaseData>();
            SensorList          = new List<BaseData>();
            StiffenerList       = new List<BaseData>();
            FlexList            = new List<BaseData>();
            CameraBuildList     = new List<BaseData>();
            AlgorithmList       = new List<BaseData>();
            ColorCalList        = new List<BaseData>();
            ColorShadingList    = new List<BaseData>();
            TraceabilityRevList = new List<BaseData>();
            CarrierList         = new List<BaseData>();
            ConfigList          = new List<BaseData>();
        }

        private bool AddItem(BaseData inAddData,ref List<BaseData> ItemList)
        {
            ItemList.Add(inAddData);

            return true;
        }

        private bool DeleteItem(BaseData inTargetData, ref List<BaseData> ItemList)
        {
            foreach (var tempItem in ItemList)
            {
                if (tempItem == inTargetData)
                {
                    ItemList.Remove(tempItem);

                    return true;
                }
            }
            return false;
        }

        private bool ModifyItem(BaseData inTargetData, ref List<BaseData> ItemList)
        {
            foreach (var tempItem in ItemList)
            {
                if (tempItem == inTargetData)
                {
                    ItemList.Remove(tempItem);
                    ItemList.Add(inTargetData);

                    return true;
                }
            }
            return false;
        }

        public void SaveDataToFile()
        {
            string strFilePath;
            if (m_strFileName == "")
                strFilePath = Application.StartupPath + "\\Data\\" + m_strPrjName + m_strVSRVersion + ".ini";
            else
                strFilePath = m_strFileName;

            SaveVSRVersionToFile();
            SaveEEEEToFile();
            SaveListDataToFile( NVMList,             "NVM",              strFilePath);
            SaveListDataToFile( PartsList,           "Parts",            strFilePath);
            SaveListDataToFile( LensList,            "Lens",             strFilePath);
            SaveListDataToFile( SubstrateList,       "Substrate",        strFilePath);
            SaveListDataToFile( CameraPrjList,       "CameraPrj",        strFilePath);
            SaveListDataToFile( ProgramVariantList,  "ProgramVariant",   strFilePath);
            SaveListDataToFile( IntegratorList,      "Integrator",       strFilePath);
            SaveListDataToFile( LensComponentList,   "LensComponent",    strFilePath);
            SaveListDataToFile( IRCFList,            "IRCF",             strFilePath);
            SaveListDataToFile( SensorList,          "Sensor",           strFilePath);
            SaveListDataToFile( StiffenerList,       "Stiffener",        strFilePath);
            SaveListDataToFile( FlexList,            "Flex",             strFilePath);
            SaveListDataToFile( CameraBuildList,     "CameraBuild",      strFilePath);
            SaveListDataToFile( AlgorithmList,       "Algorithm",        strFilePath);
            SaveListDataToFile( ColorCalList,        "ColorCal",         strFilePath);
            SaveListDataToFile( ColorShadingList,    "ColorShading",     strFilePath);
            SaveListDataToFile( CarrierList,         "Carrier",          strFilePath);
            SaveListDataToFile( TraceabilityRevList, "TraceabilityRev",  strFilePath);
            SaveListDataToFile( ConfigList,          "Config",           strFilePath);

        }
        
        public void SaveVSRVersionToFile()
        {
            string strSection = "VSR";
            string strFilePath;
            if (m_strFileName == "")
                strFilePath = Application.StartupPath + "\\Data\\" + m_strPrjName + m_strVSRVersion + ".ini";
            else
                strFilePath = Application.StartupPath + "\\Data\\" + m_strFileName + ".ini";

            WritePrivateProfileString(strSection, "Version", m_strVSRVersion, strFilePath);
            WritePrivateProfileString(strSection, "PrjName", m_strPrjName, strFilePath);
        }

        public void SaveEEEEToFile()
        {
            string strSection = "EEEE";
            string strFilePath;
            if(m_strFileName == "")
                strFilePath = Application.StartupPath + "\\Data\\" + m_strPrjName + m_strVSRVersion + ".ini";
            else
                strFilePath = Application.StartupPath + "\\Data\\" + m_strFileName + ".ini";

            WritePrivateProfileString(strSection, "Code", m_strEEEE, strFilePath);
        }

        public void SaveListDataToFile(List<BaseData> inListData, string strSection, string strFilePath)
        {
            int nListCount = inListData.Count;          

            WritePrivateProfileString(strSection, "count", nListCount.ToString(), strFilePath);

            for (int i = 0; i < nListCount; i++)
            {
                inListData[i].writeInfoToFile(strFilePath, strSection, i.ToString());
            }
        }

        public void LoadDataToFile(string inFilePath)
        {
            m_strFileName = inFilePath;
            LoadVSRVersionFromFile(inFilePath);
            LoadEEEEFromFile(inFilePath);
            LoadDataFromFile( ref PartsList,            "Parts",            inFilePath);
            LoadDataFromFile( ref NVMList,              "NVM",              inFilePath);
            LoadDataFromFile( ref LensList,             "Lens",             inFilePath);
            LoadDataFromFile( ref SubstrateList,        "Substrate",        inFilePath);
            LoadDataFromFile( ref CameraPrjList,        "CameraPrj",        inFilePath);
            LoadDataFromFile( ref ProgramVariantList,   "ProgramVariant",   inFilePath);
            LoadDataFromFile( ref IntegratorList,       "Integrator",       inFilePath);
            LoadDataFromFile( ref LensComponentList,    "LensComponent",    inFilePath);
            LoadDataFromFile( ref IRCFList,             "IRCF",             inFilePath);
            LoadDataFromFile( ref SensorList,           "Sensor",           inFilePath);
            LoadDataFromFile( ref StiffenerList,        "Stiffener",        inFilePath);
            LoadDataFromFile( ref FlexList,             "Flex",             inFilePath);
            LoadDataFromFile( ref CameraBuildList,      "CameraBuild",      inFilePath);
            LoadDataFromFile( ref AlgorithmList,        "Algorithm",        inFilePath);
            LoadDataFromFile( ref ColorCalList,         "ColorCal",         inFilePath);
            LoadDataFromFile( ref ColorShadingList,     "ColorShading",     inFilePath);
            LoadDataFromFile( ref CarrierList,          "Carrier",          inFilePath);
            LoadDataFromFile( ref TraceabilityRevList,  "TraceabilityRev",  inFilePath);
            LoadDataFromFile( ref ConfigList,           "Config",           inFilePath);
            
        }

        public void LoadVSRVersionFromFile(string inFilePath)
        {
            string strSection = "VSR";
            
            StringBuilder strbReadValue = new StringBuilder();

            GetPrivateProfileString(strSection, "Version", "0", strbReadValue, 255, inFilePath);
            m_strVSRVersion = strbReadValue.ToString();
            GetPrivateProfileString(strSection, "PrjName", "0", strbReadValue, 255, inFilePath);
            m_strPrjName = strbReadValue.ToString();
        }
        public void LoadEEEEFromFile(string inFilePath)
        {
            string strSection = "EEEE";

            StringBuilder strbReadValue = new StringBuilder();

            GetPrivateProfileString(strSection, "code", "0", strbReadValue, 255, inFilePath);
            m_strEEEE = strbReadValue.ToString();
        }
        public void LoadDataFromFile(ref List<BaseData> inListData, string strSection, string inFilePath)
        {
            int nListCount = 0;
            StringBuilder strbRead = new StringBuilder();
            
            GetPrivateProfileString(strSection, "count", "0", strbRead, 255, inFilePath);
            nListCount = Int32.Parse(strbRead.ToString());

            for (int i = 0; i < nListCount; i++)
            {
                BaseData CAddData = new BaseData();
                CAddData.ReadInfoFromFile(inFilePath, strSection, i.ToString());
                inListData.Add(CAddData);
            }
        }

        public void SetFileName(string inData)
        {
            m_strFileName = inData;
        }
    }
}
