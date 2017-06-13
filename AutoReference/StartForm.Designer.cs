namespace AutoReference
{
    partial class StartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.button_MNR = new System.Windows.Forms.Button();
            this.button_MM = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_MNR
            // 
            this.button_MNR.Location = new System.Drawing.Point(75, 133);
            this.button_MNR.Name = "button_MNR";
            this.button_MNR.Size = new System.Drawing.Size(95, 49);
            this.button_MNR.TabIndex = 0;
            this.button_MNR.Text = "With VSR Making";
            this.button_MNR.UseVisualStyleBackColor = true;
            this.button_MNR.Click += new System.EventHandler(this.button_MNR_Click);
            // 
            // button_MM
            // 
            this.button_MM.Location = new System.Drawing.Point(214, 133);
            this.button_MM.Name = "button_MM";
            this.button_MM.Size = new System.Drawing.Size(95, 49);
            this.button_MM.TabIndex = 1;
            this.button_MM.Text = "Manual Making";
            this.button_MM.UseVisualStyleBackColor = true;
            this.button_MM.Click += new System.EventHandler(this.button_MM_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(71, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "Auto Reference Maker V2.0";
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 211);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_MM);
            this.Controls.Add(this.button_MNR);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.Text = "Auto Reference Maker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_MNR;
        private System.Windows.Forms.Button button_MM;
        private System.Windows.Forms.Label label1;
    }
}