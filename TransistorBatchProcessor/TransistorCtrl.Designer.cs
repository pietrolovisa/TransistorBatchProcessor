namespace TransistorBatchProcessor
{
    partial class TransistorCtrl
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
            this.labelIdx = new System.Windows.Forms.Label();
            this.labelHEF = new System.Windows.Forms.Label();
            this.labelBeta = new System.Windows.Forms.Label();
            this.textBoxIdx = new System.Windows.Forms.TextBox();
            this.textBoxHEF = new System.Windows.Forms.TextBox();
            this.textBoxBeta = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelIdx
            // 
            this.labelIdx.AutoSize = true;
            this.labelIdx.Location = new System.Drawing.Point(9, 15);
            this.labelIdx.Name = "labelIdx";
            this.labelIdx.Size = new System.Drawing.Size(72, 20);
            this.labelIdx.TabIndex = 0;
            this.labelIdx.Text = "Transistor";
            // 
            // labelHEF
            // 
            this.labelHEF.AutoSize = true;
            this.labelHEF.Location = new System.Drawing.Point(9, 66);
            this.labelHEF.Name = "labelHEF";
            this.labelHEF.Size = new System.Drawing.Size(35, 20);
            this.labelHEF.TabIndex = 1;
            this.labelHEF.Text = "HEF";
            // 
            // labelBeta
            // 
            this.labelBeta.AutoSize = true;
            this.labelBeta.Location = new System.Drawing.Point(9, 115);
            this.labelBeta.Name = "labelBeta";
            this.labelBeta.Size = new System.Drawing.Size(39, 20);
            this.labelBeta.TabIndex = 2;
            this.labelBeta.Text = "Beta";
            // 
            // textBoxIdx
            // 
            this.textBoxIdx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxIdx.Location = new System.Drawing.Point(88, 12);
            this.textBoxIdx.Name = "textBoxIdx";
            this.textBoxIdx.Size = new System.Drawing.Size(125, 27);
            this.textBoxIdx.TabIndex = 3;
            // 
            // textBoxHEF
            // 
            this.textBoxHEF.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxHEF.Location = new System.Drawing.Point(88, 63);
            this.textBoxHEF.Name = "textBoxHEF";
            this.textBoxHEF.Size = new System.Drawing.Size(125, 27);
            this.textBoxHEF.TabIndex = 4;
            // 
            // textBoxBeta
            // 
            this.textBoxBeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBeta.Location = new System.Drawing.Point(88, 112);
            this.textBoxBeta.Name = "textBoxBeta";
            this.textBoxBeta.Size = new System.Drawing.Size(125, 27);
            this.textBoxBeta.TabIndex = 5;
            // 
            // TransistorCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxBeta);
            this.Controls.Add(this.textBoxHEF);
            this.Controls.Add(this.textBoxIdx);
            this.Controls.Add(this.labelBeta);
            this.Controls.Add(this.labelHEF);
            this.Controls.Add(this.labelIdx);
            this.Name = "TransistorCtrl";
            this.Size = new System.Drawing.Size(226, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelIdx;
        private Label labelHEF;
        private Label labelBeta;
        private TextBox textBoxIdx;
        private TextBox textBoxHEF;
        private TextBox textBoxBeta;
    }
}
