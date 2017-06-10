namespace AutoReference
{
    partial class AutoRef
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoRef));
            this.PrjListBox = new System.Windows.Forms.ListBox();
            this.prjAddButton = new System.Windows.Forms.Button();
            this.prjDeleteButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.closelButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.prjModifyButton = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.SensorListView = new System.Windows.Forms.ListView();
            this.ConfigListView = new System.Windows.Forms.ListView();
            this.IRCFListView = new System.Windows.Forms.ListView();
            this.LensListView = new System.Windows.Forms.ListView();
            this.StiffenerListView = new System.Windows.Forms.ListView();
            this.SubstrateListView = new System.Windows.Forms.ListView();
            this.FlexListView = new System.Windows.Forms.ListView();
            this.CarrierListView = new System.Windows.Forms.ListView();
            this.BuildListView = new System.Windows.Forms.ListView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.InputRefCheckBox = new System.Windows.Forms.CheckBox();
            this.EEEETextBox = new System.Windows.Forms.TextBox();
            this.PrjTextBox = new System.Windows.Forms.TextBox();
            this.FlexTextBox = new System.Windows.Forms.TextBox();
            this.LensTextBox = new System.Windows.Forms.TextBox();
            this.SubstrateTextBox = new System.Windows.Forms.TextBox();
            this.CarrierTextBox = new System.Windows.Forms.TextBox();
            this.StiffenerTextBox = new System.Windows.Forms.TextBox();
            this.IRCFTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrjListBox
            // 
            this.PrjListBox.FormattingEnabled = true;
            this.PrjListBox.ItemHeight = 12;
            this.PrjListBox.Location = new System.Drawing.Point(29, 26);
            this.PrjListBox.Name = "PrjListBox";
            this.PrjListBox.Size = new System.Drawing.Size(172, 172);
            this.PrjListBox.TabIndex = 0;
            this.PrjListBox.Click += new System.EventHandler(this.PjrListBox_Click);
            // 
            // prjAddButton
            // 
            this.prjAddButton.Location = new System.Drawing.Point(29, 217);
            this.prjAddButton.Name = "prjAddButton";
            this.prjAddButton.Size = new System.Drawing.Size(54, 44);
            this.prjAddButton.TabIndex = 1;
            this.prjAddButton.Text = "ADD";
            this.prjAddButton.UseVisualStyleBackColor = true;
            this.prjAddButton.Click += new System.EventHandler(this.PrjAddButton_Click);
            // 
            // prjDeleteButton
            // 
            this.prjDeleteButton.Location = new System.Drawing.Point(149, 217);
            this.prjDeleteButton.Name = "prjDeleteButton";
            this.prjDeleteButton.Size = new System.Drawing.Size(54, 44);
            this.prjDeleteButton.TabIndex = 2;
            this.prjDeleteButton.Text = "Delete";
            this.prjDeleteButton.UseVisualStyleBackColor = true;
            this.prjDeleteButton.Click += new System.EventHandler(this.PrjDeleteButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Config";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(225, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sensor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Lens";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lens component";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "IRCF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 440);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "Substrate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(220, 381);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "Stiffener";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 497);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "Flex";
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(717, 467);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(128, 48);
            this.nextButton.TabIndex = 22;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // closelButton
            // 
            this.closelButton.Location = new System.Drawing.Point(717, 530);
            this.closelButton.Name = "closelButton";
            this.closelButton.Size = new System.Drawing.Size(128, 48);
            this.closelButton.TabIndex = 23;
            this.closelButton.Text = "Close";
            this.closelButton.UseVisualStyleBackColor = true;
            this.closelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox1.Location = new System.Drawing.Point(15, 77);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 22);
            this.textBox1.TabIndex = 26;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 12);
            this.label7.TabIndex = 28;
            this.label7.Text = "Project";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox2.Location = new System.Drawing.Point(15, 37);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(146, 22);
            this.textBox2.TabIndex = 30;
            this.textBox2.Text = "ex : C1010";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(53, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 12);
            this.label9.TabIndex = 29;
            this.label9.Text = "Build Config";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Window;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox3.Location = new System.Drawing.Point(15, 160);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(146, 22);
            this.textBox3.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(53, 145);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 12);
            this.label12.TabIndex = 31;
            this.label12.Text = "ERS Version";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Window;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox4.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox4.Location = new System.Drawing.Point(15, 119);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(146, 22);
            this.textBox4.TabIndex = 33;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(53, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(70, 12);
            this.label13.TabIndex = 34;
            this.label13.Text = "Ref Version";
            // 
            // prjModifyButton
            // 
            this.prjModifyButton.Location = new System.Drawing.Point(89, 217);
            this.prjModifyButton.Name = "prjModifyButton";
            this.prjModifyButton.Size = new System.Drawing.Size(54, 44);
            this.prjModifyButton.TabIndex = 37;
            this.prjModifyButton.Text = "Modify";
            this.prjModifyButton.UseVisualStyleBackColor = true;
            this.prjModifyButton.Click += new System.EventHandler(this.button_Modify_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(227, 543);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 12);
            this.label14.TabIndex = 39;
            this.label14.Text = "Carrier";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(237, 584);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(33, 12);
            this.label15.TabIndex = 41;
            this.label15.Text = "Build";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(692, 57);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 272);
            this.groupBox1.TabIndex = 42;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input Data";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Window;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox6.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox6.Location = new System.Drawing.Point(15, 243);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(146, 22);
            this.textBox6.TabIndex = 38;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(53, 228);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(70, 12);
            this.label17.TabIndex = 37;
            this.label17.Text = "SW Version";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Window;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox5.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox5.Location = new System.Drawing.Point(15, 203);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(146, 22);
            this.textBox5.TabIndex = 36;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(53, 188);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(60, 12);
            this.label16.TabIndex = 35;
            this.label16.Text = "CIS Mask";
            // 
            // SensorListView
            // 
            this.SensorListView.FullRowSelect = true;
            this.SensorListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.SensorListView.HideSelection = false;
            this.SensorListView.Location = new System.Drawing.Point(276, 26);
            this.SensorListView.Name = "SensorListView";
            this.SensorListView.Size = new System.Drawing.Size(410, 122);
            this.SensorListView.TabIndex = 43;
            this.SensorListView.UseCompatibleStateImageBehavior = false;
            this.SensorListView.View = System.Windows.Forms.View.Details;
            this.SensorListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.SensorListView_MouseClick);
            // 
            // ConfigListView
            // 
            this.ConfigListView.FullRowSelect = true;
            this.ConfigListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ConfigListView.HideSelection = false;
            this.ConfigListView.Location = new System.Drawing.Point(276, 154);
            this.ConfigListView.Name = "ConfigListView";
            this.ConfigListView.Size = new System.Drawing.Size(410, 85);
            this.ConfigListView.TabIndex = 44;
            this.ConfigListView.UseCompatibleStateImageBehavior = false;
            this.ConfigListView.View = System.Windows.Forms.View.Details;
            // 
            // IRCFListView
            // 
            this.IRCFListView.FullRowSelect = true;
            this.IRCFListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.IRCFListView.HideSelection = false;
            this.IRCFListView.Location = new System.Drawing.Point(276, 245);
            this.IRCFListView.Name = "IRCFListView";
            this.IRCFListView.Size = new System.Drawing.Size(410, 45);
            this.IRCFListView.TabIndex = 45;
            this.IRCFListView.UseCompatibleStateImageBehavior = false;
            this.IRCFListView.View = System.Windows.Forms.View.Details;
            // 
            // LensListView
            // 
            this.LensListView.FullRowSelect = true;
            this.LensListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LensListView.HideSelection = false;
            this.LensListView.Location = new System.Drawing.Point(276, 296);
            this.LensListView.Name = "LensListView";
            this.LensListView.Size = new System.Drawing.Size(410, 57);
            this.LensListView.TabIndex = 46;
            this.LensListView.UseCompatibleStateImageBehavior = false;
            this.LensListView.View = System.Windows.Forms.View.Details;
            // 
            // StiffenerListView
            // 
            this.StiffenerListView.FullRowSelect = true;
            this.StiffenerListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.StiffenerListView.HideSelection = false;
            this.StiffenerListView.Location = new System.Drawing.Point(276, 359);
            this.StiffenerListView.Name = "StiffenerListView";
            this.StiffenerListView.Size = new System.Drawing.Size(410, 57);
            this.StiffenerListView.TabIndex = 47;
            this.StiffenerListView.UseCompatibleStateImageBehavior = false;
            this.StiffenerListView.View = System.Windows.Forms.View.Details;
            // 
            // SubstrateListView
            // 
            this.SubstrateListView.FullRowSelect = true;
            this.SubstrateListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.SubstrateListView.HideSelection = false;
            this.SubstrateListView.Location = new System.Drawing.Point(276, 422);
            this.SubstrateListView.Name = "SubstrateListView";
            this.SubstrateListView.Size = new System.Drawing.Size(410, 53);
            this.SubstrateListView.TabIndex = 48;
            this.SubstrateListView.UseCompatibleStateImageBehavior = false;
            this.SubstrateListView.View = System.Windows.Forms.View.Details;
            // 
            // FlexListView
            // 
            this.FlexListView.FullRowSelect = true;
            this.FlexListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.FlexListView.HideSelection = false;
            this.FlexListView.Location = new System.Drawing.Point(276, 481);
            this.FlexListView.Name = "FlexListView";
            this.FlexListView.Size = new System.Drawing.Size(410, 46);
            this.FlexListView.TabIndex = 49;
            this.FlexListView.UseCompatibleStateImageBehavior = false;
            this.FlexListView.View = System.Windows.Forms.View.Details;
            // 
            // CarrierListView
            // 
            this.CarrierListView.FullRowSelect = true;
            this.CarrierListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.CarrierListView.HideSelection = false;
            this.CarrierListView.Location = new System.Drawing.Point(276, 533);
            this.CarrierListView.Name = "CarrierListView";
            this.CarrierListView.Size = new System.Drawing.Size(410, 36);
            this.CarrierListView.TabIndex = 50;
            this.CarrierListView.UseCompatibleStateImageBehavior = false;
            this.CarrierListView.View = System.Windows.Forms.View.Details;
            // 
            // BuildListView
            // 
            this.BuildListView.FullRowSelect = true;
            this.BuildListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.BuildListView.HideSelection = false;
            this.BuildListView.Location = new System.Drawing.Point(276, 574);
            this.BuildListView.Name = "BuildListView";
            this.BuildListView.Size = new System.Drawing.Size(410, 36);
            this.BuildListView.TabIndex = 51;
            this.BuildListView.UseCompatibleStateImageBehavior = false;
            this.BuildListView.View = System.Windows.Forms.View.Details;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.InputRefCheckBox);
            this.groupBox2.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox2.Location = new System.Drawing.Point(693, 369);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 69);
            this.groupBox2.TabIndex = 52;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Build Config(ItemVersion.ini)";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.SystemColors.Window;
            this.textBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox7.Enabled = false;
            this.textBox7.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox7.Location = new System.Drawing.Point(14, 40);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(146, 22);
            this.textBox7.TabIndex = 39;
            // 
            // InputRefCheckBox
            // 
            this.InputRefCheckBox.AutoSize = true;
            this.InputRefCheckBox.Location = new System.Drawing.Point(20, 19);
            this.InputRefCheckBox.Name = "InputRefCheckBox";
            this.InputRefCheckBox.Size = new System.Drawing.Size(132, 15);
            this.InputRefCheckBox.TabIndex = 0;
            this.InputRefCheckBox.Text = "Manual Input (DOE)";
            this.InputRefCheckBox.UseVisualStyleBackColor = true;
            // 
            // EEEETextBox
            // 
            this.EEEETextBox.BackColor = System.Drawing.SystemColors.Window;
            this.EEEETextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.EEEETextBox.Enabled = false;
            this.EEEETextBox.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.EEEETextBox.Location = new System.Drawing.Point(434, 633);
            this.EEEETextBox.Name = "EEEETextBox";
            this.EEEETextBox.Size = new System.Drawing.Size(66, 22);
            this.EEEETextBox.TabIndex = 40;
            // 
            // PrjTextBox
            // 
            this.PrjTextBox.Enabled = false;
            this.PrjTextBox.Location = new System.Drawing.Point(238, 633);
            this.PrjTextBox.Name = "PrjTextBox";
            this.PrjTextBox.Size = new System.Drawing.Size(53, 21);
            this.PrjTextBox.TabIndex = 53;
            // 
            // FlexTextBox
            // 
            this.FlexTextBox.Enabled = false;
            this.FlexTextBox.Location = new System.Drawing.Point(298, 633);
            this.FlexTextBox.Name = "FlexTextBox";
            this.FlexTextBox.Size = new System.Drawing.Size(20, 21);
            this.FlexTextBox.TabIndex = 54;
            // 
            // LensTextBox
            // 
            this.LensTextBox.Enabled = false;
            this.LensTextBox.Location = new System.Drawing.Point(319, 633);
            this.LensTextBox.Name = "LensTextBox";
            this.LensTextBox.Size = new System.Drawing.Size(20, 21);
            this.LensTextBox.TabIndex = 55;
            // 
            // SubstrateTextBox
            // 
            this.SubstrateTextBox.Enabled = false;
            this.SubstrateTextBox.Location = new System.Drawing.Point(340, 633);
            this.SubstrateTextBox.Name = "SubstrateTextBox";
            this.SubstrateTextBox.Size = new System.Drawing.Size(20, 21);
            this.SubstrateTextBox.TabIndex = 56;
            // 
            // CarrierTextBox
            // 
            this.CarrierTextBox.Enabled = false;
            this.CarrierTextBox.Location = new System.Drawing.Point(408, 633);
            this.CarrierTextBox.Name = "CarrierTextBox";
            this.CarrierTextBox.Size = new System.Drawing.Size(20, 21);
            this.CarrierTextBox.TabIndex = 59;
            // 
            // StiffenerTextBox
            // 
            this.StiffenerTextBox.Enabled = false;
            this.StiffenerTextBox.Location = new System.Drawing.Point(387, 633);
            this.StiffenerTextBox.Name = "StiffenerTextBox";
            this.StiffenerTextBox.Size = new System.Drawing.Size(20, 21);
            this.StiffenerTextBox.TabIndex = 58;
            // 
            // IRCFTextBox
            // 
            this.IRCFTextBox.Enabled = false;
            this.IRCFTextBox.Location = new System.Drawing.Point(366, 633);
            this.IRCFTextBox.Name = "IRCFTextBox";
            this.IRCFTextBox.Size = new System.Drawing.Size(20, 21);
            this.IRCFTextBox.TabIndex = 57;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(442, 618);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(45, 12);
            this.label8.TabIndex = 60;
            this.label8.Text = "EEEER";
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.SystemColors.Window;
            this.textBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox14.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox14.Location = new System.Drawing.Point(506, 633);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(77, 22);
            this.textBox14.TabIndex = 61;
            this.textBox14.Text = "ex : C1010";
            // 
            // textBox15
            // 
            this.textBox15.Enabled = false;
            this.textBox15.Location = new System.Drawing.Point(589, 633);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(53, 21);
            this.textBox15.TabIndex = 62;
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.SystemColors.Window;
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox16.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.textBox16.Location = new System.Drawing.Point(648, 633);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(81, 22);
            this.textBox16.TabIndex = 63;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(507, 618);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 12);
            this.label18.TabIndex = 64;
            this.label18.Text = "Build Config";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(652, 618);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(70, 12);
            this.label19.TabIndex = 65;
            this.label19.Text = "Ref Version";
            // 
            // AutoRef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 663);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CarrierTextBox);
            this.Controls.Add(this.StiffenerTextBox);
            this.Controls.Add(this.IRCFTextBox);
            this.Controls.Add(this.SubstrateTextBox);
            this.Controls.Add(this.LensTextBox);
            this.Controls.Add(this.FlexTextBox);
            this.Controls.Add(this.PrjTextBox);
            this.Controls.Add(this.EEEETextBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.BuildListView);
            this.Controls.Add(this.CarrierListView);
            this.Controls.Add(this.FlexListView);
            this.Controls.Add(this.SubstrateListView);
            this.Controls.Add(this.StiffenerListView);
            this.Controls.Add(this.LensListView);
            this.Controls.Add(this.IRCFListView);
            this.Controls.Add(this.ConfigListView);
            this.Controls.Add(this.SensorListView);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.prjModifyButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.closelButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prjDeleteButton);
            this.Controls.Add(this.prjAddButton);
            this.Controls.Add(this.PrjListBox);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AutoRef";
            this.Text = "AutoReference";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoRef_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PrjListBox;
        private System.Windows.Forms.Button prjAddButton;
        private System.Windows.Forms.Button prjDeleteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button closelButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button prjModifyButton;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView SensorListView;
        private System.Windows.Forms.ListView ConfigListView;
        private System.Windows.Forms.ListView IRCFListView;
        private System.Windows.Forms.ListView LensListView;
        private System.Windows.Forms.ListView StiffenerListView;
        private System.Windows.Forms.ListView SubstrateListView;
        private System.Windows.Forms.ListView FlexListView;
        private System.Windows.Forms.ListView CarrierListView;
        private System.Windows.Forms.ListView BuildListView;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.CheckBox InputRefCheckBox;
        private System.Windows.Forms.TextBox EEEETextBox;
        private System.Windows.Forms.TextBox PrjTextBox;
        private System.Windows.Forms.TextBox FlexTextBox;
        private System.Windows.Forms.TextBox LensTextBox;
        private System.Windows.Forms.TextBox SubstrateTextBox;
        private System.Windows.Forms.TextBox CarrierTextBox;
        private System.Windows.Forms.TextBox StiffenerTextBox;
        private System.Windows.Forms.TextBox IRCFTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
    }
}

