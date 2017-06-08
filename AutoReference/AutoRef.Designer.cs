﻿namespace AutoReference
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
            this.PrjListBox = new System.Windows.Forms.ListBox();
            this.prjAddButton = new System.Windows.Forms.Button();
            this.prjDeleteButton = new System.Windows.Forms.Button();
            this.ConfigListBox = new System.Windows.Forms.ListBox();
            this.SensorListBox = new System.Windows.Forms.ListBox();
            this.LensListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IRCFListBox = new System.Windows.Forms.ListBox();
            this.SubstrateListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.StiffenerListBox = new System.Windows.Forms.ListBox();
            this.label11 = new System.Windows.Forms.Label();
            this.FlexListBox = new System.Windows.Forms.ListBox();
            this.nextButton = new System.Windows.Forms.Button();
            this.closelButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.InputRefCheckBox = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.EEEEListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // PrjListBox
            // 
            this.PrjListBox.FormattingEnabled = true;
            this.PrjListBox.ItemHeight = 12;
            this.PrjListBox.Location = new System.Drawing.Point(29, 39);
            this.PrjListBox.Name = "PrjListBox";
            this.PrjListBox.Size = new System.Drawing.Size(172, 172);
            this.PrjListBox.TabIndex = 0;
            this.PrjListBox.Click += new System.EventHandler(this.PjrListBox_Click);
            // 
            // prjAddButton
            // 
            this.prjAddButton.Location = new System.Drawing.Point(29, 230);
            this.prjAddButton.Name = "prjAddButton";
            this.prjAddButton.Size = new System.Drawing.Size(83, 44);
            this.prjAddButton.TabIndex = 1;
            this.prjAddButton.Text = "ADD";
            this.prjAddButton.UseVisualStyleBackColor = true;
            this.prjAddButton.Click += new System.EventHandler(this.PrjAddButton_Click);
            // 
            // prjDeleteButton
            // 
            this.prjDeleteButton.Location = new System.Drawing.Point(118, 230);
            this.prjDeleteButton.Name = "prjDeleteButton";
            this.prjDeleteButton.Size = new System.Drawing.Size(83, 44);
            this.prjDeleteButton.TabIndex = 2;
            this.prjDeleteButton.Text = "Delete";
            this.prjDeleteButton.UseVisualStyleBackColor = true;
            this.prjDeleteButton.Click += new System.EventHandler(this.prjDeleteButton_Click);
            // 
            // ConfigListBox
            // 
            this.ConfigListBox.FormattingEnabled = true;
            this.ConfigListBox.ItemHeight = 12;
            this.ConfigListBox.Location = new System.Drawing.Point(276, 97);
            this.ConfigListBox.Name = "ConfigListBox";
            this.ConfigListBox.Size = new System.Drawing.Size(410, 76);
            this.ConfigListBox.TabIndex = 3;
            // 
            // SensorListBox
            // 
            this.SensorListBox.FormattingEnabled = true;
            this.SensorListBox.ItemHeight = 12;
            this.SensorListBox.Location = new System.Drawing.Point(276, 39);
            this.SensorListBox.Name = "SensorListBox";
            this.SensorListBox.Size = new System.Drawing.Size(410, 52);
            this.SensorListBox.TabIndex = 4;
            // 
            // LensListBox
            // 
            this.LensListBox.FormattingEnabled = true;
            this.LensListBox.ItemHeight = 12;
            this.LensListBox.Location = new System.Drawing.Point(276, 237);
            this.LensListBox.Name = "LensListBox";
            this.LensListBox.Size = new System.Drawing.Size(410, 76);
            this.LensListBox.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(229, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "Config";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(229, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sensor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "Lens";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(732, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "Lens component";
            // 
            // IRCFListBox
            // 
            this.IRCFListBox.FormattingEnabled = true;
            this.IRCFListBox.ItemHeight = 12;
            this.IRCFListBox.Location = new System.Drawing.Point(276, 178);
            this.IRCFListBox.Name = "IRCFListBox";
            this.IRCFListBox.Size = new System.Drawing.Size(410, 52);
            this.IRCFListBox.TabIndex = 11;
            // 
            // SubstrateListBox
            // 
            this.SubstrateListBox.FormattingEnabled = true;
            this.SubstrateListBox.ItemHeight = 12;
            this.SubstrateListBox.Location = new System.Drawing.Point(276, 365);
            this.SubstrateListBox.Name = "SubstrateListBox";
            this.SubstrateListBox.Size = new System.Drawing.Size(410, 52);
            this.SubstrateListBox.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(238, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "IRCF";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(213, 378);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 12);
            this.label6.TabIndex = 14;
            this.label6.Text = "Substrate";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(220, 333);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 12);
            this.label10.TabIndex = 21;
            this.label10.Text = "Stiffener";
            // 
            // StiffenerListBox
            // 
            this.StiffenerListBox.FormattingEnabled = true;
            this.StiffenerListBox.ItemHeight = 12;
            this.StiffenerListBox.Location = new System.Drawing.Point(276, 319);
            this.StiffenerListBox.Name = "StiffenerListBox";
            this.StiffenerListBox.Size = new System.Drawing.Size(410, 40);
            this.StiffenerListBox.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(241, 434);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(29, 12);
            this.label11.TabIndex = 18;
            this.label11.Text = "Flex";
            // 
            // FlexListBox
            // 
            this.FlexListBox.FormattingEnabled = true;
            this.FlexListBox.ItemHeight = 12;
            this.FlexListBox.Location = new System.Drawing.Point(276, 423);
            this.FlexListBox.Name = "FlexListBox";
            this.FlexListBox.Size = new System.Drawing.Size(410, 40);
            this.FlexListBox.TabIndex = 17;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(717, 342);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(128, 48);
            this.nextButton.TabIndex = 22;
            this.nextButton.Text = "Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // closelButton
            // 
            this.closelButton.Location = new System.Drawing.Point(717, 408);
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
            this.textBox1.Location = new System.Drawing.Point(707, 173);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(146, 22);
            this.textBox1.TabIndex = 26;
            // 
            // InputRefCheckBox
            // 
            this.InputRefCheckBox.AutoSize = true;
            this.InputRefCheckBox.Font = new System.Drawing.Font("굴림", 12F);
            this.InputRefCheckBox.Location = new System.Drawing.Point(730, 302);
            this.InputRefCheckBox.Name = "InputRefCheckBox";
            this.InputRefCheckBox.Size = new System.Drawing.Size(91, 20);
            this.InputRefCheckBox.TabIndex = 27;
            this.InputRefCheckBox.Text = "Input Ref";
            this.InputRefCheckBox.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(93, 24);
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
            this.textBox2.Location = new System.Drawing.Point(707, 222);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(146, 22);
            this.textBox2.TabIndex = 30;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(745, 207);
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
            this.textBox3.Location = new System.Drawing.Point(707, 274);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(146, 22);
            this.textBox3.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(745, 259);
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
            this.textBox4.Location = new System.Drawing.Point(707, 123);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(146, 22);
            this.textBox4.TabIndex = 33;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(745, 158);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 12);
            this.label13.TabIndex = 34;
            this.label13.Text = "Build Version";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(757, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 12);
            this.label8.TabIndex = 36;
            this.label8.Text = "EEEE";
            // 
            // EEEEListBox
            // 
            this.EEEEListBox.FormattingEnabled = true;
            this.EEEEListBox.ItemHeight = 12;
            this.EEEEListBox.Location = new System.Drawing.Point(707, 39);
            this.EEEEListBox.Name = "EEEEListBox";
            this.EEEEListBox.Size = new System.Drawing.Size(146, 28);
            this.EEEEListBox.TabIndex = 35;
            // 
            // AutoRef
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 497);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.EEEEListBox);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.InputRefCheckBox);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.closelButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.StiffenerListBox);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.FlexListBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.SubstrateListBox);
            this.Controls.Add(this.IRCFListBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LensListBox);
            this.Controls.Add(this.SensorListBox);
            this.Controls.Add(this.ConfigListBox);
            this.Controls.Add(this.prjDeleteButton);
            this.Controls.Add(this.prjAddButton);
            this.Controls.Add(this.PrjListBox);
            this.Name = "AutoRef";
            this.Text = "AutoReference";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoRef_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox PrjListBox;
        private System.Windows.Forms.Button prjAddButton;
        private System.Windows.Forms.Button prjDeleteButton;
        private System.Windows.Forms.ListBox ConfigListBox;
        private System.Windows.Forms.ListBox SensorListBox;
        private System.Windows.Forms.ListBox LensListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox IRCFListBox;
        private System.Windows.Forms.ListBox SubstrateListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox StiffenerListBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox FlexListBox;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button closelButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.CheckBox InputRefCheckBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox EEEEListBox;
    }
}
