using System;
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
            if (inTargetName == "Parts")
            {
                label_Vendor.Text = "Config";
                label_Binary.Text = "Parts Combination";
                Point TempPoint = new Point();
                TempPoint.X = 135;
                TempPoint.Y = 64;
                label_Binary.Location = TempPoint;
                label2.Visible = false;
                label3.Visible = false;
                HexTextBox.Visible = false;
                ApplePNTextBox.Visible = false;
            }

            if ( inTargetName == "Project")
            {
                label_Vendor.Text = "Project Name";
                label_Binary.Text = "VSR Version";
                Point TempPoint = new Point();
                TempPoint.X = 135;
                TempPoint.Y = 64;
                label2.Visible = false;
                label3.Visible = false;
                label_Binary.Location = TempPoint;
                HexTextBox.Visible = false;
                ApplePNTextBox.Visible = false;
            }

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
