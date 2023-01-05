namespace TransistorBatchProcessor
{
    partial class BatchManagement
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
            this.batchCtrl1 = new TransistorBatchProcessor.BatchCtrl();
            this.commandAndControl1 = new TransistorBatchProcessor.CommandAndControl();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Location = new System.Drawing.Point(15, 15);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(504, 402);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // batchCtrl1
            // 
            this.batchCtrl1.Location = new System.Drawing.Point(558, 19);
            this.batchCtrl1.Name = "batchCtrl1";
            this.batchCtrl1.Size = new System.Drawing.Size(308, 93);
            this.batchCtrl1.TabIndex = 7;
            // 
            // commandAndControl1
            // 
            this.commandAndControl1.Location = new System.Drawing.Point(653, 111);
            this.commandAndControl1.Name = "commandAndControl1";
            this.commandAndControl1.Size = new System.Drawing.Size(196, 188);
            this.commandAndControl1.TabIndex = 11;
            // 
            // BatchManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.commandAndControl1);
            this.Controls.Add(this.batchCtrl1);
            this.Controls.Add(this.listView1);
            this.Name = "BatchManagement";
            this.Size = new System.Drawing.Size(943, 436);
            this.ResumeLayout(false);

        }

        #endregion

        private ListView listView1;
        private BatchCtrl batchCtrl1;
        private CommandAndControl commandAndControl1;
    }
}
