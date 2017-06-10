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
            this.FinalOKButton = new System.Windows.Forms.Button();
            this.FinalCancleButton = new System.Windows.Forms.Button();
            this.ValuesListView = new System.Windows.Forms.ListView();
            this.ItemversionListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // FinalOKButton
            // 
            this.FinalOKButton.Location = new System.Drawing.Point(567, 459);
            this.FinalOKButton.Name = "FinalOKButton";
            this.FinalOKButton.Size = new System.Drawing.Size(143, 52);
            this.FinalOKButton.TabIndex = 0;
            this.FinalOKButton.Text = "OK";
            this.FinalOKButton.UseVisualStyleBackColor = true;
            this.FinalOKButton.Click += new System.EventHandler(this.FinalOKButton_Click);
            // 
            // FinalCancleButton
            // 
            this.FinalCancleButton.Location = new System.Drawing.Point(716, 459);
            this.FinalCancleButton.Name = "FinalCancleButton";
            this.FinalCancleButton.Size = new System.Drawing.Size(143, 52);
            this.FinalCancleButton.TabIndex = 1;
            this.FinalCancleButton.Text = "Cancel";
            this.FinalCancleButton.UseVisualStyleBackColor = true;
            this.FinalCancleButton.Click += new System.EventHandler(this.FinalCancleBuitton_Click);
            // 
            // ValuesListView
            // 
            this.ValuesListView.Location = new System.Drawing.Point(28, 27);
            this.ValuesListView.Name = "ValuesListView";
            this.ValuesListView.Size = new System.Drawing.Size(682, 235);
            this.ValuesListView.TabIndex = 2;
            this.ValuesListView.UseCompatibleStateImageBehavior = false;
            this.ValuesListView.View = System.Windows.Forms.View.List;
            // 
            // ItemversionListView
            // 
            this.ItemversionListView.Location = new System.Drawing.Point(28, 279);
            this.ItemversionListView.Name = "ItemversionListView";
            this.ItemversionListView.Size = new System.Drawing.Size(517, 235);
            this.ItemversionListView.TabIndex = 3;
            this.ItemversionListView.UseCompatibleStateImageBehavior = false;
            this.ItemversionListView.View = System.Windows.Forms.View.List;
            // 
            // PrintMidResultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 526);
            this.Controls.Add(this.ItemversionListView);
            this.Controls.Add(this.ValuesListView);
            this.Controls.Add(this.FinalCancleButton);
            this.Controls.Add(this.FinalOKButton);
            this.Name = "PrintMidResultForm";
            this.Text = "PrintMidResultForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FinalOKButton;
        private System.Windows.Forms.Button FinalCancleButton;
        private System.Windows.Forms.ListView ValuesListView;
        private System.Windows.Forms.ListView ItemversionListView;
    }
}