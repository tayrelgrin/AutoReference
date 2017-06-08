﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutoReference
{
    public partial class ModifyForm : Form
    {
        public delegate void SendModifyResult(bool bResult, BaseData inCModiData);
        public event SendModifyResult SendModifyResultEvent;

        public ModifyForm(string inTargetName, BaseData inTargetData)
        {
            InitializeComponent();
            TargetItem.Text = inTargetName;
            TargetTextBox.Text  = inTargetData.strVendorName;
            BinaryTextBox.Text  = inTargetData.strBinaryValue;
            HexTextBox.Text     = inTargetData.strHexValue;
            ApplePNTextBox.Text = inTargetData.strApplePN;
            
        }

        private void ModiOKButton_Click(object sender, EventArgs e)
        {
            BaseData CModiData = new BaseData();
            CModiData.strVendorName     = TargetTextBox.Text;
            CModiData.strBinaryValue    = BinaryTextBox.Text;
            CModiData.strHexValue       = HexTextBox.Text;
            CModiData.strApplePN        = ApplePNTextBox.Text;
            this.SendModifyResultEvent(true, CModiData);
            Close();
        }

        private void ModiCancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

       
    }
}