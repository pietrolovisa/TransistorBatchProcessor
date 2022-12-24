namespace TransistorBatchProcessor
{
    partial class TransistorManagement
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
            this.transistorCtrl1 = new TransistorBatchProcessor.TransistorCtrl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.comboBoxBatches = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(720, 228);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(94, 29);
            this.buttonRemove.TabIndex = 11;
            this.buttonRemove.Text = "Remove";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // buttonAddOrUpdate
            // 
            this.buttonAddOrUpdate.Location = new System.Drawing.Point(611, 228);
            this.buttonAddOrUpdate.Name = "buttonAddOrUpdate";
            this.buttonAddOrUpdate.Size = new System.Drawing.Size(94, 29);
            this.buttonAddOrUpdate.TabIndex = 10;
            this.buttonAddOrUpdate.Text = "Add";
            this.buttonAddOrUpdate.UseVisualStyleBackColor = true;
            this.buttonAddOrUpdate.Click += new System.EventHandler(this.AddOrUpdate_Click);
            // 
            // transistorCtrl1
            // 
            this.transistorCtrl1.Location = new System.Drawing.Point(561, 66);
            this.transistorCtrl1.Name = "transistorCtrl1";
            this.transistorCtrl1.Size = new System.Drawing.Size(265, 148);
            this.transistorCtrl1.TabIndex = 9;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Location = new System.Drawing.Point(15, 62);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(525, 355);
            this.listView1.TabIndex = 8;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // comboBoxBatches
            // 
            this.comboBoxBatches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBatches.FormattingEnabled = true;
            this.comboBoxBatches.Location = new System.Drawing.Point(15, 17);
            this.comboBoxBatches.Name = "comboBoxBatches";
            this.comboBoxBatches.Size = new System.Drawing.Size(274, 28);
            this.comboBoxBatches.TabIndex = 7;
            // 
            // TransistorManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonAddOrUpdate);
            this.Controls.Add(this.transistorCtrl1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.comboBoxBatches);
            this.Name = "TransistorManagement";
            this.Size = new System.Drawing.Size(943, 436);
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonRemove;
        private Button buttonAddOrUpdate;
        private TransistorCtrl transistorCtrl1;
        private ListView listView1;
        private ComboBox comboBoxBatches;
    }
}
