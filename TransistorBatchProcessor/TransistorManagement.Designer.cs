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
            this.transistorCtrl1 = new TransistorBatchProcessor.TransistorCtrl();
            this.listView1 = new System.Windows.Forms.ListView();
            this.comboBoxBatches = new System.Windows.Forms.ComboBox();
            this.comboBoxState = new System.Windows.Forms.ComboBox();
            this.commandAndControl1 = new TransistorBatchProcessor.CommandAndControl();
            this.SuspendLayout();
            // 
            // transistorCtrl1
            // 
            this.transistorCtrl1.Location = new System.Drawing.Point(558, 66);
            this.transistorCtrl1.Name = "transistorCtrl1";
            this.transistorCtrl1.Size = new System.Drawing.Size(268, 148);
            this.transistorCtrl1.TabIndex = 9;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Location = new System.Drawing.Point(15, 62);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(525, 395);
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
            // comboBoxState
            // 
            this.comboBoxState.FormattingEnabled = true;
            this.comboBoxState.Location = new System.Drawing.Point(295, 17);
            this.comboBoxState.Name = "comboBoxState";
            this.comboBoxState.Size = new System.Drawing.Size(245, 28);
            this.comboBoxState.TabIndex = 12;
            // 
            // commandAndControl1
            // 
            this.commandAndControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.commandAndControl1.Location = new System.Drawing.Point(661, 203);
            this.commandAndControl1.Name = "commandAndControl1";
            this.commandAndControl1.Size = new System.Drawing.Size(165, 254);
            this.commandAndControl1.TabIndex = 15;
            // 
            // TransistorManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.commandAndControl1);
            this.Controls.Add(this.comboBoxState);
            this.Controls.Add(this.transistorCtrl1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.comboBoxBatches);
            this.Name = "TransistorManagement";
            this.Size = new System.Drawing.Size(943, 476);
            this.ResumeLayout(false);

        }

        #endregion
        private TransistorCtrl transistorCtrl1;
        private ListView listView1;
        private ComboBox comboBoxBatches;
        private ComboBox comboBoxState;
        private CommandAndControl commandAndControl1;
    }
}
