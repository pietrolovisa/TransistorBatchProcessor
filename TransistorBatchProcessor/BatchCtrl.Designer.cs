namespace TransistorBatchProcessor
{
    partial class BatchCtrl
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
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelName = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.labelType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxIdx
            // 
            this.textBoxName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxName.Location = new System.Drawing.Point(97, 14);
            this.textBoxName.Name = "textBoxIdx";
            this.textBoxName.Size = new System.Drawing.Size(125, 27);
            this.textBoxName.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(18, 17);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(49, 20);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Name";
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(95, 55);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(127, 28);
            this.comboBoxType.TabIndex = 6;
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(18, 58);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(40, 20);
            this.labelType.TabIndex = 7;
            this.labelType.Text = "Type";
            // 
            // BatchCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Name = "BatchCtrl";
            this.Size = new System.Drawing.Size(242, 98);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox textBoxName;
        private Label labelName;
        private ComboBox comboBoxType;
        private Label labelType;
    }
}
