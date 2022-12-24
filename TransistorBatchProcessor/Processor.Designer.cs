namespace TransistorBatchProcessor
{
    partial class Processor
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
            this.buttonProcessBatch = new System.Windows.Forms.Button();
            this.comboBoxBatches = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // buttonProcessBatch
            // 
            this.buttonProcessBatch.Location = new System.Drawing.Point(35, 49);
            this.buttonProcessBatch.Name = "buttonProcessBatch";
            this.buttonProcessBatch.Size = new System.Drawing.Size(274, 29);
            this.buttonProcessBatch.TabIndex = 6;
            this.buttonProcessBatch.Text = "Process batch";
            this.buttonProcessBatch.UseVisualStyleBackColor = true;
            this.buttonProcessBatch.Click += new System.EventHandler(this.buttonProcessBatch_Click);
            // 
            // comboBoxBatches
            // 
            this.comboBoxBatches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBatches.FormattingEnabled = true;
            this.comboBoxBatches.Location = new System.Drawing.Point(35, 15);
            this.comboBoxBatches.Name = "comboBoxBatches";
            this.comboBoxBatches.Size = new System.Drawing.Size(274, 28);
            this.comboBoxBatches.TabIndex = 8;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Location = new System.Drawing.Point(35, 97);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(525, 521);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // Processor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.comboBoxBatches);
            this.Controls.Add(this.buttonProcessBatch);
            this.Name = "Processor";
            this.Size = new System.Drawing.Size(1106, 633);
            this.ResumeLayout(false);

        }

        #endregion

        private Button buttonProcessBatch;
        private ComboBox comboBoxBatches;
        private ListView listView1;
    }
}
