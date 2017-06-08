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
            this.NVMListBox = new System.Windows.Forms.ListBox();
            this.LensListBox = new System.Windows.Forms.ListBox();
            this.StiffenerListBox = new System.Windows.Forms.ListBox();
            this.SubstrateListBox = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.IRCFListBox = new System.Windows.Forms.ListBox();
            this.ProgramVariantListBox = new System.Windows.Forms.ListBox();
            this.AddCloseButton = new System.Windows.Forms.Button();
            this.AddOKbutton = new System.Windows.Forms.Button();
            this.PartsListBox = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.CameraPrjListBox = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.IntegratorListBox = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.SensorListBox = new System.Windows.Forms.ListBox();
            this.label15 = new System.Windows.Forms.Label();
            this.FlexListBox = new System.Windows.Forms.ListBox();
            this.CameraListBox = new System.Windows.Forms.ListBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.AlgorithmListBox = new System.Windows.Forms.ListBox();
            this.ColorShadingListBox = new System.Windows.Forms.ListBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.TraceabilityRevListBox = new System.Windows.Forms.ListBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.EEEEListBox = new System.Windows.Forms.ListBox();
            this.label19 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 12);
            this.label1.TabIndex = 28;
            this.label1.Text = "Project :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 211);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 30;
            this.label2.Text = "NVM    :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 241);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 32;
            this.label3.Text = "Lens    :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-1, 483);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 12);
            this.label5.TabIndex = 36;
            this.label5.Text = "Camera Prj  :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 383);
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
            this.PrjListBox.Size = new System.Drawing.Size(329, 28);
            this.PrjListBox.TabIndex = 39;
            this.PrjListBox.DoubleClick += new System.EventHandler(this.PrjListBox_DoubleClick);
            this.PrjListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PrjListBox_MouseDown);
            // 
            // NVMListBox
            // 
            this.NVMListBox.FormattingEnabled = true;
            this.NVMListBox.ItemHeight = 12;
            this.NVMListBox.Location = new System.Drawing.Point(85, 204);
            this.NVMListBox.Name = "NVMListBox";
            this.NVMListBox.Size = new System.Drawing.Size(329, 28);
            this.NVMListBox.TabIndex = 40;
            this.NVMListBox.DoubleClick += new System.EventHandler(this.NVMListBox_DoubleClick);
            this.NVMListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.NVMListBox_MouseDown);
            // 
            // LensListBox
            // 
            this.LensListBox.FormattingEnabled = true;
            this.LensListBox.ItemHeight = 12;
            this.LensListBox.Location = new System.Drawing.Point(85, 238);
            this.LensListBox.Name = "LensListBox";
            this.LensListBox.Size = new System.Drawing.Size(329, 136);
            this.LensListBox.TabIndex = 41;
            this.LensListBox.DoubleClick += new System.EventHandler(this.LensListBox_DoubleClick);
            this.LensListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LensListBox_MouseDown);
            // 
            // StiffenerListBox
            // 
            this.StiffenerListBox.FormattingEnabled = true;
            this.StiffenerListBox.ItemHeight = 12;
            this.StiffenerListBox.Location = new System.Drawing.Point(522, 281);
            this.StiffenerListBox.Name = "StiffenerListBox";
            this.StiffenerListBox.Size = new System.Drawing.Size(328, 76);
            this.StiffenerListBox.TabIndex = 43;
            this.StiffenerListBox.DoubleClick += new System.EventHandler(this.StiffenerListBox_DoubleClick);
            this.StiffenerListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StiffenerListBox_MouseDown);
            // 
            // SubstrateListBox
            // 
            this.SubstrateListBox.FormattingEnabled = true;
            this.SubstrateListBox.ItemHeight = 12;
            this.SubstrateListBox.Location = new System.Drawing.Point(85, 380);
            this.SubstrateListBox.Name = "SubstrateListBox";
            this.SubstrateListBox.Size = new System.Drawing.Size(329, 88);
            this.SubstrateListBox.TabIndex = 44;
            this.SubstrateListBox.DoubleClick += new System.EventHandler(this.SubstrateListBox_DoubleClick);
            this.SubstrateListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SubstrateListBox_MouseDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(460, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 46;
            this.label10.Text = "Sensor :";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(460, 29);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 12);
            this.label11.TabIndex = 45;
            this.label11.Text = "IRCF :";
            // 
            // IRCFListBox
            // 
            this.IRCFListBox.FormattingEnabled = true;
            this.IRCFListBox.ItemHeight = 12;
            this.IRCFListBox.Location = new System.Drawing.Point(522, 23);
            this.IRCFListBox.Name = "IRCFListBox";
            this.IRCFListBox.Size = new System.Drawing.Size(328, 76);
            this.IRCFListBox.TabIndex = 48;
            this.IRCFListBox.DoubleClick += new System.EventHandler(this.IRCFListBox_DoubleClick);
            this.IRCFListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IRCFListBox_MouseDown);
            // 
            // ProgramVariantListBox
            // 
            this.ProgramVariantListBox.FormattingEnabled = true;
            this.ProgramVariantListBox.ItemHeight = 12;
            this.ProgramVariantListBox.Location = new System.Drawing.Point(85, 510);
            this.ProgramVariantListBox.Name = "ProgramVariantListBox";
            this.ProgramVariantListBox.Size = new System.Drawing.Size(329, 28);
            this.ProgramVariantListBox.TabIndex = 47;
            this.ProgramVariantListBox.DoubleClick += new System.EventHandler(this.ProgramVariantListBox_DoubleClick);
            this.ProgramVariantListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ProgramVariantListBox_MouseDown);
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
            // PartsListBox
            // 
            this.PartsListBox.FormattingEnabled = true;
            this.PartsListBox.ItemHeight = 12;
            this.PartsListBox.Location = new System.Drawing.Point(86, 62);
            this.PartsListBox.Name = "PartsListBox";
            this.PartsListBox.Size = new System.Drawing.Size(328, 136);
            this.PartsListBox.TabIndex = 52;
            this.PartsListBox.DoubleClick += new System.EventHandler(this.PartsListBox_DoubleClick);
            this.PartsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PartsListBox_MouseDown);
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
            // CameraPrjListBox
            // 
            this.CameraPrjListBox.FormattingEnabled = true;
            this.CameraPrjListBox.ItemHeight = 12;
            this.CameraPrjListBox.Location = new System.Drawing.Point(85, 476);
            this.CameraPrjListBox.Name = "CameraPrjListBox";
            this.CameraPrjListBox.Size = new System.Drawing.Size(329, 28);
            this.CameraPrjListBox.TabIndex = 54;
            this.CameraPrjListBox.DoubleClick += new System.EventHandler(this.CameraPrjListBox_DoubleClick);
            this.CameraPrjListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CameraPrjListBox_MouseDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 529);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 12);
            this.label9.TabIndex = 55;
            this.label9.Text = "Variant  :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(17, 513);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 12);
            this.label12.TabIndex = 56;
            this.label12.Text = "Program";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 551);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 12);
            this.label13.TabIndex = 57;
            this.label13.Text = "Integrator :";
            // 
            // IntegratorListBox
            // 
            this.IntegratorListBox.FormattingEnabled = true;
            this.IntegratorListBox.ItemHeight = 12;
            this.IntegratorListBox.Location = new System.Drawing.Point(85, 544);
            this.IntegratorListBox.Name = "IntegratorListBox";
            this.IntegratorListBox.Size = new System.Drawing.Size(329, 28);
            this.IntegratorListBox.TabIndex = 58;
            this.IntegratorListBox.DoubleClick += new System.EventHandler(this.IntegratorListBox_DoubleClick);
            this.IntegratorListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.IntegratorListBox_MouseDown);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(458, 294);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 12);
            this.label14.TabIndex = 59;
            this.label14.Text = "Stiffener :";
            // 
            // SensorListBox
            // 
            this.SensorListBox.FormattingEnabled = true;
            this.SensorListBox.ItemHeight = 12;
            this.SensorListBox.Location = new System.Drawing.Point(522, 105);
            this.SensorListBox.Name = "SensorListBox";
            this.SensorListBox.Size = new System.Drawing.Size(328, 100);
            this.SensorListBox.TabIndex = 60;
            this.SensorListBox.DoubleClick += new System.EventHandler(this.SensorListBox_DoubleClick);
            this.SensorListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SensorListBox_MouseDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(458, 223);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 12);
            this.label15.TabIndex = 61;
            this.label15.Text = "Flex :";
            // 
            // FlexListBox
            // 
            this.FlexListBox.FormattingEnabled = true;
            this.FlexListBox.ItemHeight = 12;
            this.FlexListBox.Location = new System.Drawing.Point(522, 211);
            this.FlexListBox.Name = "FlexListBox";
            this.FlexListBox.Size = new System.Drawing.Size(328, 64);
            this.FlexListBox.TabIndex = 62;
            this.FlexListBox.DoubleClick += new System.EventHandler(this.FlexListBox_DoubleClick);
            this.FlexListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FlexListBox_MouseDown);
            // 
            // CameraListBox
            // 
            this.CameraListBox.FormattingEnabled = true;
            this.CameraListBox.ItemHeight = 12;
            this.CameraListBox.Location = new System.Drawing.Point(522, 365);
            this.CameraListBox.Name = "CameraListBox";
            this.CameraListBox.Size = new System.Drawing.Size(328, 52);
            this.CameraListBox.TabIndex = 63;
            this.CameraListBox.DoubleClick += new System.EventHandler(this.CameraListBox_DoubleClick);
            this.CameraListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CameraListBox_MouseDown);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(459, 383);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(41, 12);
            this.label16.TabIndex = 64;
            this.label16.Text = "Build :";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(458, 365);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(50, 12);
            this.label17.TabIndex = 65;
            this.label17.Text = "Camera";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(457, 427);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 12);
            this.label18.TabIndex = 66;
            this.label18.Text = "Algorithm :";
            // 
            // AlgorithmListBox
            // 
            this.AlgorithmListBox.FormattingEnabled = true;
            this.AlgorithmListBox.ItemHeight = 12;
            this.AlgorithmListBox.Location = new System.Drawing.Point(522, 423);
            this.AlgorithmListBox.Name = "AlgorithmListBox";
            this.AlgorithmListBox.Size = new System.Drawing.Size(328, 28);
            this.AlgorithmListBox.TabIndex = 67;
            this.AlgorithmListBox.DoubleClick += new System.EventHandler(this.AlgorithmListBox_DoubleClick);
            this.AlgorithmListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AlgorithmListBox_MouseDown);
            // 
            // ColorShadingListBox
            // 
            this.ColorShadingListBox.FormattingEnabled = true;
            this.ColorShadingListBox.ItemHeight = 12;
            this.ColorShadingListBox.Location = new System.Drawing.Point(522, 457);
            this.ColorShadingListBox.Name = "ColorShadingListBox";
            this.ColorShadingListBox.Size = new System.Drawing.Size(328, 28);
            this.ColorShadingListBox.TabIndex = 71;
            this.ColorShadingListBox.DoubleClick += new System.EventHandler(this.ColorShadingListBox_DoubleClick);
            this.ColorShadingListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ColorShadingListBox_MouseDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(457, 457);
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
            // TraceabilityRevListBox
            // 
            this.TraceabilityRevListBox.FormattingEnabled = true;
            this.TraceabilityRevListBox.ItemHeight = 12;
            this.TraceabilityRevListBox.Location = new System.Drawing.Point(522, 491);
            this.TraceabilityRevListBox.Name = "TraceabilityRevListBox";
            this.TraceabilityRevListBox.Size = new System.Drawing.Size(328, 28);
            this.TraceabilityRevListBox.TabIndex = 74;
            this.TraceabilityRevListBox.DoubleClick += new System.EventHandler(this.TraceabilityRevListBox_DoubleClick);
            this.TraceabilityRevListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TraceabilityRevListBox_MouseDown);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(458, 507);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(61, 12);
            this.label22.TabIndex = 73;
            this.label22.Text = "Revision :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(442, 495);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(71, 12);
            this.label23.TabIndex = 72;
            this.label23.Text = "Traceability";
            // 
            // EEEEListBox
            // 
            this.EEEEListBox.FormattingEnabled = true;
            this.EEEEListBox.ItemHeight = 12;
            this.EEEEListBox.Location = new System.Drawing.Point(522, 525);
            this.EEEEListBox.Name = "EEEEListBox";
            this.EEEEListBox.Size = new System.Drawing.Size(328, 28);
            this.EEEEListBox.TabIndex = 76;
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
            // AddPrjForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 647);
            this.Controls.Add(this.EEEEListBox);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.TraceabilityRevListBox);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.ColorShadingListBox);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.AlgorithmListBox);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.CameraListBox);
            this.Controls.Add(this.FlexListBox);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.SensorListBox);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.IntegratorListBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.CameraPrjListBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.PartsListBox);
            this.Controls.Add(this.AddOKbutton);
            this.Controls.Add(this.AddCloseButton);
            this.Controls.Add(this.IRCFListBox);
            this.Controls.Add(this.ProgramVariantListBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.SubstrateListBox);
            this.Controls.Add(this.StiffenerListBox);
            this.Controls.Add(this.LensListBox);
            this.Controls.Add(this.NVMListBox);
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
        private System.Windows.Forms.ListBox NVMListBox;
        private System.Windows.Forms.ListBox LensListBox;
        private System.Windows.Forms.ListBox StiffenerListBox;
        private System.Windows.Forms.ListBox SubstrateListBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox IRCFListBox;
        private System.Windows.Forms.ListBox ProgramVariantListBox;
        private System.Windows.Forms.Button AddCloseButton;
        private System.Windows.Forms.Button AddOKbutton;
        private System.Windows.Forms.ListBox PartsListBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox CameraPrjListBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox IntegratorListBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ListBox SensorListBox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox FlexListBox;
        private System.Windows.Forms.ListBox CameraListBox;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ListBox AlgorithmListBox;
        private System.Windows.Forms.ListBox ColorShadingListBox;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ListBox TraceabilityRevListBox;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.ListBox EEEEListBox;
        private System.Windows.Forms.Label label19;

    }
}