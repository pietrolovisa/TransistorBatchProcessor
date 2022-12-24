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
            this.buttonRemove = new System.Windows.Forms.Button();
            this.buttonAddOrUpdate = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.batchTypeCtrl1 = new TransistorBatchProcessor.BatchTypeCtrl();
            this.SuspendLayout();
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(730, 133);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(94, 29);
            this.buttonRemove.TabIndex = 8;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // buttonAddOrUpdate
            // 
            this.buttonAddOrUpdate.Location = new System.Drawing.Point(621, 133);
            this.buttonAddOrUpdate.Name = "buttonAddOrUpdate";
            this.buttonAddOrUpdate.Size = new System.Drawing.Size(94, 29);
            this.buttonAddOrUpdate.TabIndex = 7;
            this.buttonAddOrUpdate.Text = "Add";
            this.buttonAddOrUpdate.UseVisualStyleBackColor = true;
            this.buttonAddOrUpdate.Click += new System.EventHandler(this.AddOrUpdate_Click);
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Location = new System.Drawing.Point(15, 15);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(524, 345);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // batchTypeCtrl1
            // 
            this.batchTypeCtrl1.Location = new System.Drawing.Point(545, 15);
            this.batchTypeCtrl1.Name = "batchTypeCtrl1";
            this.batchTypeCtrl1.Size = new System.Drawing.Size(286, 112);
            this.batchTypeCtrl1.TabIndex = 9;
            // 
            // BatchTypeManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.batchTypeCtrl1);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAddOrUpdate);
            this.Controls.Add(this.listView1);
            this.Name = "BatchTypeManagement";
            this.Size = new System.Drawing.Size(834, 377);
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonRemove;
        private Button buttonAddOrUpdate;
        private ListView listView1;
        private BatchTypeCtrl batchTypeCtrl1;
    }
}
