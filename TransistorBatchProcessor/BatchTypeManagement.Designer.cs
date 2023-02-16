namespace TransistorBatchProcessor
{
    partial class BatchTypeManagement
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.batchTypeCtrl1 = new TransistorBatchProcessor.BatchTypeCtrl();
            this.commandAndControl1 = new TransistorBatchProcessor.CommandAndControl();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Location = new System.Drawing.Point(15, 15);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(525, 443);
            this.listView1.TabIndex = 5;
            this.listView1.TabStop = false;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // batchTypeCtrl1
            // 
            this.batchTypeCtrl1.Location = new System.Drawing.Point(558, 19);
            this.batchTypeCtrl1.Name = "batchTypeCtrl1";
            this.batchTypeCtrl1.Size = new System.Drawing.Size(268, 112);
            this.batchTypeCtrl1.TabIndex = 0;
            // 
            // commandAndControl1
            // 
            this.commandAndControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.commandAndControl1.Location = new System.Drawing.Point(661, 122);
            this.commandAndControl1.Name = "commandAndControl1";
            this.commandAndControl1.Size = new System.Drawing.Size(165, 340);
            this.commandAndControl1.TabIndex = 1;
            // 
            // BatchTypeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.commandAndControl1);
            this.Controls.Add(this.batchTypeCtrl1);
            this.Controls.Add(this.listView1);
            this.Name = "BatchTypeManagement";
            this.Size = new System.Drawing.Size(943, 476);
            this.ResumeLayout(false);

        }

        #endregion
        private ListView listView1;
        private BatchTypeCtrl batchTypeCtrl1;
        private CommandAndControl commandAndControl1;
    }
}
