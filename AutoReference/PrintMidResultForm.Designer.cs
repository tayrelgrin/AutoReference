namespace AutoReference
{
    partial class PrintMidResultForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrintMidResultForm));
            this.FinalOKButton = new System.Windows.Forms.Button();
            this.FinalCancleButton = new System.Windows.Forms.Button();
            this.NVMValuesListView = new System.Windows.Forms.ListView();
            this.ItemversionListView = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // FinalOKButton
            // 
            this.FinalOKButton.Location = new System.Drawing.Point(428, 620);
            this.FinalOKButton.Name = "FinalOKButton";
            this.FinalOKButton.Size = new System.Drawing.Size(143, 52);
            this.FinalOKButton.TabIndex = 0;
            this.FinalOKButton.Text = "OK";
            this.FinalOKButton.UseVisualStyleBackColor = true;
            this.FinalOKButton.Click += new System.EventHandler(this.FinalOKButton_Click);
            // 
            // FinalCancleButton
            // 
            this.FinalCancleButton.Location = new System.Drawing.Point(577, 620);
            this.FinalCancleButton.Name = "FinalCancleButton";
            this.FinalCancleButton.Size = new System.Drawing.Size(143, 52);
            this.FinalCancleButton.TabIndex = 1;
            this.FinalCancleButton.Text = "Cancel";
            this.FinalCancleButton.UseVisualStyleBackColor = true;
            this.FinalCancleButton.Click += new System.EventHandler(this.FinalCancleBuitton_Click);
            // 
            // NVMValuesListView
            // 
            this.NVMValuesListView.Location = new System.Drawing.Point(28, 55);
            this.NVMValuesListView.Name = "NVMValuesListView";
            this.NVMValuesListView.Size = new System.Drawing.Size(646, 376);
            this.NVMValuesListView.TabIndex = 2;
            this.NVMValuesListView.UseCompatibleStateImageBehavior = false;
            this.NVMValuesListView.View = System.Windows.Forms.View.Details;
            // 
            // ItemversionListView
            // 
            this.ItemversionListView.Location = new System.Drawing.Point(28, 437);
            this.ItemversionListView.Name = "ItemversionListView";
            this.ItemversionListView.Size = new System.Drawing.Size(389, 235);
            this.ItemversionListView.TabIndex = 3;
            this.ItemversionListView.UseCompatibleStateImageBehavior = false;
            this.ItemversionListView.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // PrintMidResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 683);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ItemversionListView);
            this.Controls.Add(this.NVMValuesListView);
            this.Controls.Add(this.FinalCancleButton);
            this.Controls.Add(this.FinalOKButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PrintMidResultForm";
            this.Text = "PrintMidResultForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button FinalOKButton;
        private System.Windows.Forms.Button FinalCancleButton;
        private System.Windows.Forms.ListView NVMValuesListView;
        private System.Windows.Forms.ListView ItemversionListView;
        private System.Windows.Forms.Label label1;
    }
}