﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoReference
{
    public class ReferenceData
    {
        // NVM info
        public BaseData Parts   = new BaseData();
        public BaseData NVM     = new BaseData();
        public BaseData Lens    = new BaseData();
        public BaseData Substrate = new BaseData();
        public BaseData CameraPrj = new BaseData();
        public BaseData ProgramVariant = new BaseData();
        public BaseData Intergrator = new BaseData();
        public BaseData IRCF = new BaseData();
        public BaseData Sensor = new BaseData();
        public BaseData LensComponent_Major = new BaseData();
        public BaseData LensComponent_Minor = new BaseData();
        public BaseData Stiffener = new BaseData();
        public BaseData Flex = new BaseData();
        public BaseData CameraBuild = new BaseData();
        public BaseData Algorithm = new BaseData();
        public BaseData ColorCal = new BaseData();
        public BaseData ColorShading = new BaseData();
        public BaseData Traceability = new BaseData();
        public BaseData Carrier = new BaseData();
        public BaseData Config = new BaseData();
        public BaseData SoftWare = new BaseData();
        public string m_strCISMask;

        // Itemversion.ini info
        public string m_strSWVersion;
        public string m_strErs_ver;
        public string m_strVsr_ver;
        public string m_strBuild_num;
        public string m_strBuild_Config;
        
        // Ref Naming
        public string m_strLensComponent;
        public string m_strRefVersion;
        public string m_strDOEBuild_Config;
        public string m_strLensConfig;

        public string m_strEEEE;
        public string m_strPrjName;
        public string m_strFileName;

        public string m_strRefName;
    }
}
