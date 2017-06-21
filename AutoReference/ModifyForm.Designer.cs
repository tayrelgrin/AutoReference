namespace AutoReference
{
    partial class ModifyForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModifyForm));
            this.ModiOKButton = new System.Windows.Forms.Button();
            this.ModiCancelButton = new System.Windows.Forms.Button();
            this.TargetTextBox = new System.Windows.Forms.TextBox();
            this.TargetItem = new System.Windows.Forms.Label();
            this.label_Binary = new System.Windows.Forms.Label();
            this.BinaryTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.HexTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ApplePNTextBox = new System.Windows.Forms.TextBox();
            this.label_Vendor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ModiOKButton
            // 
            this.ModiOKButton.Location = new System.Drawing.Point(171, 198);
            this.ModiOKButton.Name = "ModiOKButton";
            this.ModiOKButton.Size = new System.Drawing.Size(86, 33);
            this.ModiOKButton.TabIndex = 0;
            this.ModiOKButton.Text = "OK";
            this.ModiOKButton.UseVisualStyleBackColor = true;
            this.ModiOKButton.Click += new System.EventHandler(this.ModiOKButton_Click);
            // 
            // ModiCancelButton
            // 
            this.ModiCancelButton.Location = new System.Drawing.Point(263, 198);
            this.ModiCancelButton.Name = "ModiCancelButton";
            this.ModiCancelButton.Size = new System.Drawing.Size(86, 33);
            this.ModiCancelButton.TabIndex = 1;
            this.ModiCancelButton.Text = "Cancel";
            this.ModiCancelButton.UseVisualStyleBackColor = true;
            this.ModiCancelButton.Click += new System.EventHandler(this.ModiCancelButton_Click);
            // 
            // TargetTextBox
            // 
            this.TargetTextBox.Location = new System.Drawing.Point(14, 41);
            this.TargetTextBox.Name = "TargetTextBox";
            this.TargetTextBox.Size = new System.Drawing.Size(335, 21);
            this.TargetTextBox.TabIndex = 2;
            // 
            // TargetItem
            // 
            this.TargetItem.AutoSize = true;
            this.TargetItem.Location = new System.Drawing.Point(12, 9);
            this.TargetItem.Name = "TargetItem";
            this.TargetItem.Size = new System.Drawing.Size(65, 12);
            this.TargetItem.TabIndex = 3;
            this.TargetItem.Text = "TargetItem";
            // 
            // label_Binary
            // 
            this.label_Binary.AutoSize = true;
            this.label_Binary.Location = new System.Drawing.Point(164, 65);
            this.label_Binary.Name = "label_Binary";
            this.label_Binary.Size = new System.Drawing.Size(41, 12);
            this.label_Binary.TabIndex = 5;
            this.label_Binary.Text = "Binary";
            // 
            // BinaryTextBox
            // 
            this.BinaryTextBox.Location = new System.Drawing.Point(14, 80);
            this.BinaryTextBox.Name = "BinaryTextBox";
            this.BinaryTextBox.Size = new System.Drawing.Size(335, 21);
            this.BinaryTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "Hex";
            // 
            // HexTextBox
            // 
            this.HexTextBox.Location = new System.Drawing.Point(14, 122);
            this.HexTextBox.Name = "HexTextBox";
            this.HexTextBox.Size = new System.Drawing.Size(335, 21);
            this.HexTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Apple PN";
            // 
            // ApplePNTextBox
            // 
            this.ApplePNTextBox.Location = new System.Drawing.Point(14, 162);
            this.ApplePNTextBox.Name = "ApplePNTextBox";
            this.ApplePNTextBox.Size = new System.Drawing.Size(335, 21);
            this.ApplePNTextBox.TabIndex = 8;
            // 
            // label_Vendor
            // 
            this.label_Vendor.AutoSize = true;
            this.label_Vendor.Location = new System.Drawing.Point(164, 26);
            this.label_Vendor.Name = "label_Vendor";
            this.label_Vendor.Size = new System.Drawing.Size(42, 12);
            this.label_Vendor.TabIndex = 10;
            this.label_Vendor.Text = "Verdor";
            // 
            // ModifyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 240);
            this.Controls.Add(this.label_Vendor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ApplePNTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HexTextBox);
            this.Controls.Add(this.label_Binary);
            this.Controls.Add(this.BinaryTextBox);
            this.Controls.Add(this.TargetItem);
            this.Controls.Add(this.TargetTextBox);
            this.Controls.Add(this.ModiCancelButton);
            this.Controls.Add(this.ModiOKButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ModifyForm";
            this.Text = "ModifyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ModiOKButton;
        private System.Windows.Forms.Button ModiCancelButton;
        private System.Windows.Forms.TextBox TargetTextBox;
        private System.Windows.Forms.Label TargetItem;
        private System.Windows.Forms.Label label_Binary;
        private System.Windows.Forms.TextBox BinaryTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox HexTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ApplePNTextBox;
        private System.Windows.Forms.Label label_Vendor;
    }
}