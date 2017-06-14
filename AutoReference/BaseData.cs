using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;


namespace AutoReference
{
    public class BaseData
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public string   strDataType     { get; set; }
        public string   strVendorName   { get; set; }
        public string   strBinaryValue  { get; set; }
        public string   strHexValue     { get; set; }
        public string   strApplePN      { get; set; }
        public int      nDecValue       { get; set; }

        public BaseData()
        {
            strDataType     = null;
            strVendorName   = null;
            strBinaryValue  = null;
            strHexValue     = null;
            strApplePN      = null;
            nDecValue       = 0;
        }

        public static bool operator == (BaseData op1, BaseData op2)
        {
            return (op1.strVendorName == op2.strVendorName && op1.strApplePN == op2.strApplePN);
        }
        public static bool operator != (BaseData op1, BaseData op2)
        {
            return (op1.strVendorName != op2.strVendorName || op1.strApplePN != op2.strApplePN);
        }

        public void writeInfoToFile(string strFilePath, string strSection, string strKey)
        {
            WritePrivateProfileString(strSection, "VenderName"+strKey,  strVendorName,  strFilePath);
            WritePrivateProfileString(strSection, "Binary" + strKey,    strBinaryValue, strFilePath);
            WritePrivateProfileString(strSection, "Hex" + strKey,       strHexValue,    strFilePath);
        }

        public void ReadInfoFromFile(string strFilePath, string strSection, string strKey)
        {
            StringBuilder strbReadValue = new StringBuilder();
            GetPrivateProfileString(strSection, "VenderName" + strKey,  "0", strbReadValue, 255, strFilePath);
            strVendorName = strbReadValue.ToString();

            GetPrivateProfileString(strSection, "Binary" + strKey,      "0", strbReadValue, 255, strFilePath);
            strBinaryValue = strbReadValue.ToString();

            GetPrivateProfileString(strSection, "Hex" + strKey,         "0", strbReadValue, 255, strFilePath);
            strHexValue = strbReadValue.ToString();
        }

        public int stringHexToDec(string inHex)
        {
            inHex.Trim();   // 공백 제거

            if (inHex.Length % 2 == 1)
                throw new Exception("The Hex key cannot have an odd number of digits");

            int nDecValue = 0;

            for (int i = 2; i < inHex.Length; i++)
            {
                nDecValue += System.Convert.ToByte(GetHexVal(inHex[i]) * Math.Pow(10, (inHex.Length - (i + 1))));
            }

            return nDecValue;
        }

        public static int GetHexVal(char hex)
        {
            int val = (int)hex;

            if (47 < val && val <= 57)
            {
                val -= 48;
            }
            else if (64 < val && val < 71)
            {
                val -= 49;
            }
            else if (96 < val && val < 103)
            {
                val -= 81;
            }
            else
                return 0;
         
            return val;
        }
    }    
}

