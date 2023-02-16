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
            this.comboBoxBatches = new System.Windows.Forms.ComboBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.numericUpDownHefTolerance = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownBetaTolerance = new System.Windows.Forms.NumericUpDown();
            this.labelBetaTolerance = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.labelShowMatchDetails = new System.Windows.Forms.Label();
            this.labelListDetails = new System.Windows.Forms.Label();
            this.commandAndControl1 = new TransistorBatchProcessor.CommandAndControl();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownGroupSize = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHefTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBetaTolerance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGroupSize)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxBatches
            // 
            this.comboBoxBatches.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBatches.FormattingEnabled = true;
            this.comboBoxBatches.Location = new System.Drawing.Point(35, 15);
            this.comboBoxBatches.Name = "comboBoxBatches";
            this.comboBoxBatches.Size = new System.Drawing.Size(274, 28);
            this.comboBoxBatches.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView1.Location = new System.Drawing.Point(35, 60);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(525, 495);
            this.listView1.TabIndex = 9;
            this.listView1.TabStop = false;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // numericUpDownHefTolerance
            // 
            this.numericUpDownHefTolerance.Location = new System.Drawing.Point(690, 67);
            this.numericUpDownHefTolerance.Name = "numericUpDownHefTolerance";
            this.numericUpDownHefTolerance.Size = new System.Drawing.Size(68, 27);
            this.numericUpDownHefTolerance.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(571, 69);
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
            this.numericUpDownBetaTolerance.Location = new System.Drawing.Point(690, 102);
            this.numericUpDownBetaTolerance.Name = "numericUpDownBetaTolerance";
            this.numericUpDownBetaTolerance.Size = new System.Drawing.Size(69, 27);
            this.numericUpDownBetaTolerance.TabIndex = 1;
            this.numericUpDownBetaTolerance.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            // 
            // labelBetaTolerance
            // 
            this.labelBetaTolerance.AutoSize = true;
            this.labelBetaTolerance.Location = new System.Drawing.Point(571, 104);
            this.labelBetaTolerance.Name = "labelBetaTolerance";
            this.labelBetaTolerance.Size = new System.Drawing.Size(107, 20);
            this.labelBetaTolerance.TabIndex = 12;
            this.labelBetaTolerance.Text = "Beta Tolerance";
            // 
            // listView2
            // 
            this.listView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listView2.Location = new System.Drawing.Point(768, 60);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(542, 495);
            this.listView2.TabIndex = 17;
            this.listView2.TabStop = false;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // labelShowMatchDetails
            // 
            this.labelShowMatchDetails.Location = new System.Drawing.Point(571, 325);
            this.labelShowMatchDetails.Name = "labelShowMatchDetails";
            this.labelShowMatchDetails.Size = new System.Drawing.Size(187, 230);
            this.labelShowMatchDetails.TabIndex = 19;
            this.labelShowMatchDetails.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelListDetails
            // 
            this.labelListDetails.AutoSize = true;
            this.labelListDetails.Location = new System.Drawing.Point(332, 18);
            this.labelListDetails.Name = "labelListDetails";
            this.labelListDetails.Size = new System.Drawing.Size(50, 20);
            this.labelListDetails.TabIndex = 20;
            this.labelListDetails.Text = "label1";
            // 
            // commandAndControl1
            // 
            this.commandAndControl1.Location = new System.Drawing.Point(571, 167);
            this.commandAndControl1.Name = "commandAndControl1";
            this.commandAndControl1.Size = new System.Drawing.Size(188, 141);
            this.commandAndControl1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(571, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 22;
            this.label2.Text = "Max Group Size";
            // 
            // numericUpDownGroupSize
            // 
            this.numericUpDownGroupSize.Location = new System.Drawing.Point(690, 135);
            this.numericUpDownGroupSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownGroupSize.Name = "numericUpDownGroupSize";
            this.numericUpDownGroupSize.Size = new System.Drawing.Size(69, 27);
            this.numericUpDownGroupSize.TabIndex = 2;
            this.numericUpDownGroupSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // Processor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDownGroupSize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.commandAndControl1);
            this.Controls.Add(this.labelListDetails);
            this.Controls.Add(this.labelShowMatchDetails);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.numericUpDownHefTolerance);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownBetaTolerance);
            this.Controls.Add(this.labelBetaTolerance);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.comboBoxBatches);
            this.Name = "Processor";
            this.Size = new System.Drawing.Size(1343, 577);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHefTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBetaTolerance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownGroupSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private ComboBox comboBoxBatches;
        private ListView listView1;
        private NumericUpDown numericUpDownHefTolerance;
        private Label label1;
        private NumericUpDown numericUpDownBetaTolerance;
        private Label labelBetaTolerance;
        private ListView listView2;
        private Label labelShowMatchDetails;
        private Label labelListDetails;
        private CommandAndControl commandAndControl1;
        private Label label2;
        private NumericUpDown numericUpDownGroupSize;
    }
}
