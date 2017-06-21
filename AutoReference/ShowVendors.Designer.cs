namespace AutoReference
{
    partial class ShowVendors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowVendors));
            this.CloseButton = new System.Windows.Forms.Button();
            this.VendorListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(270, 245);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(116, 48);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // VendorListView
            // 
            this.VendorListView.GridLines = true;
            this.VendorListView.Location = new System.Drawing.Point(13, 13);
            this.VendorListView.Name = "VendorListView";
            this.VendorListView.Size = new System.Drawing.Size(373, 197);
            this.VendorListView.TabIndex = 1;
            this.VendorListView.UseCompatibleStateImageBehavior = false;
            this.VendorListView.View = System.Windows.Forms.View.Details;
            // 
            // ShowVendors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(410, 305);
            this.Controls.Add(this.VendorListView);
            this.Controls.Add(this.CloseButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ShowVendors";
            this.Text = "ShowVendors";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ListView VendorListView;
    }
}