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
            this.numericUpDownHefTolerance = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownBetaTolerance = new System.Windows.Forms.NumericUpDown();
            this.labelBetaTolerance = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHefTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBetaTolerance)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonProcessBatch
            // 
            this.buttonProcessBatch.Location = new System.Drawing.Point(35, 96);
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
            this.listView1.Location = new System.Drawing.Point(35, 139);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(525, 479);
            this.listView1.TabIndex = 9;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // numericUpDownHefTolerance
            // 
            this.numericUpDownHefTolerance.Location = new System.Drawing.Point(148, 58);
            this.numericUpDownHefTolerance.Name = "numericUpDownHefTolerance";
            this.numericUpDownHefTolerance.Size = new System.Drawing.Size(77, 27);
            this.numericUpDownHefTolerance.TabIndex = 15;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 14;
            this.label1.Text = "HEF Tolerance";
            // 
            // numericUpDownBetaTolerance
            // 
            this.numericUpDownBetaTolerance.DecimalPlaces = 3;
            this.numericUpDownBetaTolerance.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownBetaTolerance.Location = new System.Drawing.Point(359, 60);
            this.numericUpDownBetaTolerance.Name = "numericUpDownBetaTolerance";
            this.numericUpDownBetaTolerance.Size = new System.Drawing.Size(77, 27);
            this.numericUpDownBetaTolerance.TabIndex = 13;
            this.numericUpDownBetaTolerance.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // labelBetaTolerance
            // 
            this.labelBetaTolerance.AutoSize = true;
            this.labelBetaTolerance.Location = new System.Drawing.Point(246, 62);
            this.labelBetaTolerance.Name = "labelBetaTolerance";
            this.labelBetaTolerance.Size = new System.Drawing.Size(107, 20);
            this.labelBetaTolerance.TabIndex = 12;
            this.labelBetaTolerance.Text = "Beta Tolerance";
            // 
            // Processor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownHefTolerance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownBetaTolerance);
            this.Controls.Add(this.labelBetaTolerance);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.comboBoxBatches);
            this.Controls.Add(this.buttonProcessBatch);
            this.Name = "Processor";
            this.Size = new System.Drawing.Size(1106, 633);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHefTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBetaTolerance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button buttonProcessBatch;
        private ComboBox comboBoxBatches;
        private ListView listView1;
        private NumericUpDown numericUpDownHefTolerance;
        private Label label1;
        private NumericUpDown numericUpDownBetaTolerance;
        private Label labelBetaTolerance;
    }
}
