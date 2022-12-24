namespace TransistorBatchProcessor
{
    partial class BatchTypeCtrl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.Location = new System.Drawing.Point(106, 64);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(146, 27);
            this.textBoxDescription.TabIndex = 9;
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(106, 15);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(146, 27);
            this.textBoxName.TabIndex = 8;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(16, 67);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(85, 20);
            this.labelDescription.TabIndex = 7;
            this.labelDescription.Text = "Description";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(16, 18);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(49, 20);
            this.labelName.TabIndex = 6;
            this.labelName.Text = "Name";
            // 
            // BatchTypeCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelName);
            this.Name = "BatchTypeCtrl";
            this.Size = new System.Drawing.Size(262, 106);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxDescription;
        private TextBox textBoxName;
        private Label labelDescription;
        private Label labelName;
    }
}
