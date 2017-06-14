namespace AutoReference
{
    partial class AddPrjForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PrjListBox = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.AddCloseButton = new System.Windows.Forms.Button();
            this.AddOKbutton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.VersionListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.PartsListView = new System.Windows.Forms.ListView();
            this.NVMListView = new System.Windows.Forms.ListView();
            this.LensListView = new System.Windows.Forms.ListView();
            this.SubstrateListView = new System.Windows.Forms.ListView();
            this.CameraPrjListView = new System.Windows.Forms.ListView();
            this.ProgramVariantListView = new System.Windows.Forms.ListView();
            this.IntegratorListView = new System.Windows.Forms.ListView();
            this.IRCFListView = new System.Windows.Forms.ListView();
            this.SensorListView = new System.Windows.Forms.ListView();
            this.FlexListView = new System.Windows.Forms.ListView();
            this.StiffenerListView = new System.Windows.Forms.ListView();
            this.CameraListView = new System.Windows.Forms.ListView();
            this.AlgorithmListView = new System.Windows.Forms.ListView();
            this.ColorShadingListView = new System.Windows.Forms.ListView();
            this.TraceabilityRevListView = new System.Windows.Forms.ListView();
            this.EEEEListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "Project :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "NVM    :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "Lens    :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-4, 483);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "Camera Prj  :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 383);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 12);
            this.label6.TabIndex = 38;
            this.label6.Text = "Substrate :";
            // 
            // PrjListBox
            // 
            this.PrjListBox.FormattingEnabled = true;
            this.PrjListBox.ItemHeight = 12;
            this.PrjListBox.Location = new System.Drawing.Point(85, 25);
            this.PrjListBox.Name = "PrjListBox";
            this.PrjListBox.Size = new System.Drawing.Size(115, 28);
            this.PrjListBox.TabIndex = 39;
            this.PrjListBox.DoubleClick += new System.EventHandler(this.PrjListBox_DoubleClick);
            this.PrjListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PrjListBox_MouseDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(464, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 46;
            this.label10.Text = "Sensor :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(477, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 12);
            this.label11.TabIndex = 45;
            this.label11.Text = "IRCF :";
            // 
            // AddCloseButton
            // 
            this.AddCloseButton.Location = new System.Drawing.Point(760, 587);
            this.AddCloseButton.Name = "AddCloseButton";
            this.AddCloseButton.Size = new System.Drawing.Size(106, 35);
            this.AddCloseButton.TabIndex = 49;
            this.AddCloseButton.Text = "Cancel";
            this.AddCloseButton.UseVisualStyleBackColor = true;
            this.AddCloseButton.Click += new System.EventHandler(this.AddCloseButtonClick);
            // 
            // AddOKbutton
            // 
            this.AddOKbutton.Location = new System.Drawing.Point(648, 587);
            this.AddOKbutton.Name = "AddOKbutton";
            this.AddOKbutton.Size = new System.Drawing.Size(106, 35);
            this.AddOKbutton.TabIndex = 50;
            this.AddOKbutton.Text = "OK";
            this.AddOKbutton.UseVisualStyleBackColor = true;
            this.AddOKbutton.Click += new System.EventHandler(this.AddOKButtonClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 12);
            this.label8.TabIndex = 53;
            this.label8.Text = "Parts   :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 529);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 12);
            this.label9.TabIndex = 55;
            this.label9.Text = "Variant  :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 513);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 56;
            this.label12.Text = "Program";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 563);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 57;
            this.label13.Text = "Integrator :";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(459, 294);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 12);
            this.label14.TabIndex = 59;
            this.label14.Text = "Stiffener :";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(480, 223);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 12);
            this.label15.TabIndex = 61;
            this.label15.Text = "Flex :";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(476, 383);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 64;
            this.label16.Text = "Build :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(467, 365);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 12);
            this.label17.TabIndex = 65;
            this.label17.Text = "Camera";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(451, 427);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 12);
            this.label18.TabIndex = 66;
            this.label18.Text = "Algorithm :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(478, 457);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 12);
            this.label20.TabIndex = 70;
            this.label20.Text = "Color ";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(458, 473);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(59, 12);
            this.label21.TabIndex = 70;
            this.label21.Text = "Shading :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(456, 507);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(61, 12);
            this.label22.TabIndex = 73;
            this.label22.Text = "Revision :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(446, 495);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 12);
            this.label23.TabIndex = 72;
            this.label23.Text = "Traceability";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(472, 529);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(45, 12);
            this.label19.TabIndex = 75;
            this.label19.Text = "EEEE :";
            // 
            // VersionListBox
            // 
            this.VersionListBox.FormattingEnabled = true;
            this.VersionListBox.ItemHeight = 12;
            this.VersionListBox.Location = new System.Drawing.Point(299, 25);
            this.VersionListBox.Name = "VersionListBox";
            this.VersionListBox.Size = new System.Drawing.Size(115, 28);
            this.VersionListBox.TabIndex = 77;
            this.VersionListBox.DoubleClick += new System.EventHandler(this.VersionListBox_DoubleClick);
            this.VersionListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VersionListBox_MouseDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(241, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 12);
            this.label4.TabIndex = 78;
            this.label4.Text = "Version :";
            // 
            // PartsListView
            // 
            this.PartsListView.FullRowSelect = true;
            this.PartsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.PartsListView.HideSelection = false;
            this.PartsListView.Location = new System.Drawing.Point(85, 59);
            this.PartsListView.Name = "PartsListView";
            this.PartsListView.Size = new System.Drawing.Size(329, 122);
            this.PartsListView.TabIndex = 79;
            this.PartsListView.UseCompatibleStateImageBehavior = false;
            this.PartsListView.View = System.Windows.Forms.View.Details;
            this.PartsListView.DoubleClick += new System.EventHandler(this.PartsListView_DoubleClick);
            this.PartsListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PartsListView_MouseDown);
            // 
            // NVMListView
            // 
            this.NVMListView.FullRowSelect = true;
            this.NVMListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.NVMListView.HideSelection = false;
            this.NVMListView.Location = new System.Drawing.Point(85, 187);
            this.NVMListView.Name = "NVMListView";
            this.NVMListView.Size = new System.Drawing.Size(329, 36);
            this.NVMListView.TabIndex = 80;
            this.NVMListView.UseCompatibleStateImageBehavior = false;
            this.NVMListView.View = System.Windows.Forms.View.Details;
            this.NVMListView.DoubleClick += new System.EventHandler(this.NVMListView_DoubleClick);
            this.NVMListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NVMListView_MouseDown);
            // 
            // LensListView
            // 
            this.LensListView.FullRowSelect = true;
            this.LensListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LensListView.HideSelection = false;
            this.LensListView.Location = new System.Drawing.Point(85, 229);
            this.LensListView.Name = "LensListView";
            this.LensListView.Size = new System.Drawing.Size(329, 132);
            this.LensListView.TabIndex = 81;
            this.LensListView.UseCompatibleStateImageBehavior = false;
            this.LensListView.View = System.Windows.Forms.View.Details;
            this.LensListView.DoubleClick += new System.EventHandler(this.LensListView_DoubleClick);
            this.LensListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LensListView_MouseDown);
            // 
            // SubstrateListView
            // 
            this.SubstrateListView.FullRowSelect = true;
            this.SubstrateListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.SubstrateListView.HideSelection = false;
            this.SubstrateListView.Location = new System.Drawing.Point(85, 367);
            this.SubstrateListView.Name = "SubstrateListView";
            this.SubstrateListView.Size = new System.Drawing.Size(329, 102);
            this.SubstrateListView.TabIndex = 82;
            this.SubstrateListView.UseCompatibleStateImageBehavior = false;
            this.SubstrateListView.View = System.Windows.Forms.View.Details;
            this.SubstrateListView.DoubleClick += new System.EventHandler(this.SubstrateListView_DoubleClick);
            this.SubstrateListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SubstrateListView_MouseDown);
            // 
            // CameraPrjListView
            // 
            this.CameraPrjListView.FullRowSelect = true;
            this.CameraPrjListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.CameraPrjListView.HideSelection = false;
            this.CameraPrjListView.Location = new System.Drawing.Point(85, 473);
            this.CameraPrjListView.Name = "CameraPrjListView";
            this.CameraPrjListView.Size = new System.Drawing.Size(329, 34);
            this.CameraPrjListView.TabIndex = 83;
            this.CameraPrjListView.UseCompatibleStateImageBehavior = false;
            this.CameraPrjListView.View = System.Windows.Forms.View.Details;
            this.CameraPrjListView.DoubleClick += new System.EventHandler(this.CameraPrjListView_DoubleClick);
            this.CameraPrjListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CameraPrjListView_MouseDown);
            // 
            // ProgramVariantListView
            // 
            this.ProgramVariantListView.FullRowSelect = true;
            this.ProgramVariantListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ProgramVariantListView.HideSelection = false;
            this.ProgramVariantListView.Location = new System.Drawing.Point(85, 513);
            this.ProgramVariantListView.Name = "ProgramVariantListView";
            this.ProgramVariantListView.Size = new System.Drawing.Size(329, 34);
            this.ProgramVariantListView.TabIndex = 84;
            this.ProgramVariantListView.UseCompatibleStateImageBehavior = false;
            this.ProgramVariantListView.View = System.Windows.Forms.View.Details;
            this.ProgramVariantListView.DoubleClick += new System.EventHandler(this.ProgramVariantListView_DoubleClick);
            this.ProgramVariantListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProgramVariantListView_MouseDown);
            // 
            // IntegratorListView
            // 
            this.IntegratorListView.FullRowSelect = true;
            this.IntegratorListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.IntegratorListView.HideSelection = false;
            this.IntegratorListView.Location = new System.Drawing.Point(85, 553);
            this.IntegratorListView.Name = "IntegratorListView";
            this.IntegratorListView.Size = new System.Drawing.Size(329, 34);
            this.IntegratorListView.TabIndex = 85;
            this.IntegratorListView.UseCompatibleStateImageBehavior = false;
            this.IntegratorListView.View = System.Windows.Forms.View.Details;
            this.IntegratorListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IntegratorListView_MouseDown);
            // 
            // IRCFListView
            // 
            this.IRCFListView.FullRowSelect = true;
            this.IRCFListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.IRCFListView.HideSelection = false;
            this.IRCFListView.Location = new System.Drawing.Point(519, 25);
            this.IRCFListView.Name = "IRCFListView";
            this.IRCFListView.Size = new System.Drawing.Size(329, 79);
            this.IRCFListView.TabIndex = 86;
            this.IRCFListView.UseCompatibleStateImageBehavior = false;
            this.IRCFListView.View = System.Windows.Forms.View.Details;
            this.IRCFListView.DoubleClick += new System.EventHandler(this.IRCFListView_DoubleClick);
            this.IRCFListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.IRCFListView_MouseClick);
            this.IRCFListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IRCFListView_MouseDown);
            // 
            // SensorListView
            // 
            this.SensorListView.FullRowSelect = true;
            this.SensorListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.SensorListView.HideSelection = false;
            this.SensorListView.Location = new System.Drawing.Point(519, 110);
            this.SensorListView.Name = "SensorListView";
            this.SensorListView.Size = new System.Drawing.Size(329, 79);
            this.SensorListView.TabIndex = 87;
            this.SensorListView.UseCompatibleStateImageBehavior = false;
            this.SensorListView.View = System.Windows.Forms.View.Details;
            this.SensorListView.DoubleClick += new System.EventHandler(this.SensorListView_DoubleClick);
            this.SensorListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SensorListView_MouseDown_1);
            // 
            // FlexListView
            // 
            this.FlexListView.FullRowSelect = true;
            this.FlexListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.FlexListView.HideSelection = false;
            this.FlexListView.Location = new System.Drawing.Point(519, 195);
            this.FlexListView.Name = "FlexListView";
            this.FlexListView.Size = new System.Drawing.Size(329, 79);
            this.FlexListView.TabIndex = 88;
            this.FlexListView.UseCompatibleStateImageBehavior = false;
            this.FlexListView.View = System.Windows.Forms.View.Details;
            this.FlexListView.DoubleClick += new System.EventHandler(this.FlexListView_DoubleClick);
            this.FlexListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FlexListView_MouseDown);
            // 
            // StiffenerListView
            // 
            this.StiffenerListView.FullRowSelect = true;
            this.StiffenerListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.StiffenerListView.HideSelection = false;
            this.StiffenerListView.Location = new System.Drawing.Point(519, 280);
            this.StiffenerListView.Name = "StiffenerListView";
            this.StiffenerListView.Size = new System.Drawing.Size(329, 72);
            this.StiffenerListView.TabIndex = 89;
            this.StiffenerListView.UseCompatibleStateImageBehavior = false;
            this.StiffenerListView.View = System.Windows.Forms.View.Details;
            this.StiffenerListView.DoubleClick += new System.EventHandler(this.StiffenerListView_DoubleClick);
            this.StiffenerListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StiffenerListView_MouseDown);
            // 
            // CameraListView
            // 
            this.CameraListView.FullRowSelect = true;
            this.CameraListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.CameraListView.HideSelection = false;
            this.CameraListView.Location = new System.Drawing.Point(519, 358);
            this.CameraListView.Name = "CameraListView";
            this.CameraListView.Size = new System.Drawing.Size(329, 54);
            this.CameraListView.TabIndex = 90;
            this.CameraListView.UseCompatibleStateImageBehavior = false;
            this.CameraListView.View = System.Windows.Forms.View.Details;
            this.CameraListView.DoubleClick += new System.EventHandler(this.CameraListView_DoubleClick);
            this.CameraListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CameraListView_MouseDown);
            // 
            // AlgorithmListView
            // 
            this.AlgorithmListView.FullRowSelect = true;
            this.AlgorithmListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.AlgorithmListView.HideSelection = false;
            this.AlgorithmListView.Location = new System.Drawing.Point(519, 418);
            this.AlgorithmListView.Name = "AlgorithmListView";
            this.AlgorithmListView.Size = new System.Drawing.Size(329, 30);
            this.AlgorithmListView.TabIndex = 91;
            this.AlgorithmListView.UseCompatibleStateImageBehavior = false;
            this.AlgorithmListView.View = System.Windows.Forms.View.Details;
            this.AlgorithmListView.DoubleClick += new System.EventHandler(this.AlgorithmListView_DoubleClick);
            this.AlgorithmListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AlgorithmListView_MouseDown);
            // 
            // ColorShadingListView
            // 
            this.ColorShadingListView.FullRowSelect = true;
            this.ColorShadingListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ColorShadingListView.HideSelection = false;
            this.ColorShadingListView.Location = new System.Drawing.Point(519, 454);
            this.ColorShadingListView.Name = "ColorShadingListView";
            this.ColorShadingListView.Size = new System.Drawing.Size(329, 30);
            this.ColorShadingListView.TabIndex = 92;
            this.ColorShadingListView.UseCompatibleStateImageBehavior = false;
            this.ColorShadingListView.View = System.Windows.Forms.View.Details;
            this.ColorShadingListView.DoubleClick += new System.EventHandler(this.ColorShadingListView_DoubleClick);
            this.ColorShadingListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorShadingListView_MouseDown);
            // 
            // TraceabilityRevListView
            // 
            this.TraceabilityRevListView.FullRowSelect = true;
            this.TraceabilityRevListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.TraceabilityRevListView.HideSelection = false;
            this.TraceabilityRevListView.Location = new System.Drawing.Point(519, 490);
            this.TraceabilityRevListView.Name = "TraceabilityRevListView";
            this.TraceabilityRevListView.Size = new System.Drawing.Size(329, 30);
            this.TraceabilityRevListView.TabIndex = 93;
            this.TraceabilityRevListView.UseCompatibleStateImageBehavior = false;
            this.TraceabilityRevListView.View = System.Windows.Forms.View.Details;
            this.TraceabilityRevListView.DoubleClick += new System.EventHandler(this.TraceabilityRevListView_DoubleClick);
            this.TraceabilityRevListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TraceabilityRevListView_MouseDown);
            // 
            // EEEEListBox
            // 
            this.EEEEListBox.FormattingEnabled = true;
            this.EEEEListBox.ItemHeight = 12;
            this.EEEEListBox.Location = new System.Drawing.Point(519, 526);
            this.EEEEListBox.Name = "EEEEListBox";
            this.EEEEListBox.Size = new System.Drawing.Size(329, 28);
            this.EEEEListBox.TabIndex = 94;
            this.EEEEListBox.DoubleClick += new System.EventHandler(this.EEEEListBox_DoubleClick);
            this.EEEEListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EEEEListBox_MouseDown_1);
            // 
            // AddPrjForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 647);
            this.Controls.Add(this.EEEEListBox);
            this.Controls.Add(this.TraceabilityRevListView);
            this.Controls.Add(this.ColorShadingListView);
            this.Controls.Add(this.AlgorithmListView);
            this.Controls.Add(this.CameraListView);
            this.Controls.Add(this.StiffenerListView);
            this.Controls.Add(this.FlexListView);
            this.Controls.Add(this.SensorListView);
            this.Controls.Add(this.IRCFListView);
            this.Controls.Add(this.IntegratorListView);
            this.Controls.Add(this.ProgramVariantListView);
            this.Controls.Add(this.CameraPrjListView);
            this.Controls.Add(this.SubstrateListView);
            this.Controls.Add(this.LensListView);
            this.Controls.Add(this.NVMListView);
            this.Controls.Add(this.PartsListView);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.VersionListBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.AddOKbutton);
            this.Controls.Add(this.AddCloseButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.PrjListBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddPrjForm";
            this.Text = "AddPrjForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox PrjListBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button AddCloseButton;
        private System.Windows.Forms.Button AddOKbutton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ListBox VersionListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView PartsListView;
        private System.Windows.Forms.ListView NVMListView;
        private System.Windows.Forms.ListView LensListView;
        private System.Windows.Forms.ListView SubstrateListView;
        private System.Windows.Forms.ListView CameraPrjListView;
        private System.Windows.Forms.ListView ProgramVariantListView;
        private System.Windows.Forms.ListView IntegratorListView;
        private System.Windows.Forms.ListView IRCFListView;
        private System.Windows.Forms.ListView SensorListView;
        private System.Windows.Forms.ListView FlexListView;
        private System.Windows.Forms.ListView StiffenerListView;
        private System.Windows.Forms.ListView CameraListView;
        private System.Windows.Forms.ListView AlgorithmListView;
        private System.Windows.Forms.ListView ColorShadingListView;
        private System.Windows.Forms.ListView TraceabilityRevListView;
        private System.Windows.Forms.ListBox EEEEListBox;

    }
}