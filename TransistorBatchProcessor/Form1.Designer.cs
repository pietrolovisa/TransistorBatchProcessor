namespace TransistorBatchProcessor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            TransisterBatchCore.TransistorBatchLoadArgs transistorBatchLoadArgs2 = new TransisterBatchCore.TransistorBatchLoadArgs();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.buttonProcessBatch = new System.Windows.Forms.Button();
            this.batchLoadArgsSettingsCtrl1 = new TransistorBatchProcessor.BatchLoadArgsSettingsCtrl();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(26, 27);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(873, 27);
            this.textBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(914, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 60);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(244, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Try load from excel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(26, 344);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox2.Size = new System.Drawing.Size(970, 522);
            this.textBox2.TabIndex = 3;
            // 
            // buttonProcessBatch
            // 
            this.buttonProcessBatch.Location = new System.Drawing.Point(26, 309);
            this.buttonProcessBatch.Name = "buttonProcessBatch";
            this.buttonProcessBatch.Size = new System.Drawing.Size(244, 29);
            this.buttonProcessBatch.TabIndex = 5;
            this.buttonProcessBatch.Text = "Process batch";
            this.buttonProcessBatch.UseVisualStyleBackColor = true;
            this.buttonProcessBatch.Click += new System.EventHandler(this.button3_Click);
            // 
            // batchLoadArgsSettingsCtrl1
            // 
            transistorBatchLoadArgs2.BetaColumn = 3;
            transistorBatchLoadArgs2.BetaTolerance = 0.001D;
            transistorBatchLoadArgs2.HefColumn = 2;
            transistorBatchLoadArgs2.HefTolerance = 0;
            transistorBatchLoadArgs2.KeyColumn = 1;
            transistorBatchLoadArgs2.Name = null;
            transistorBatchLoadArgs2.StartRow = 2;
            this.batchLoadArgsSettingsCtrl1.BatchLoadArgs = transistorBatchLoadArgs2;
            this.batchLoadArgsSettingsCtrl1.Location = new System.Drawing.Point(26, 88);
            this.batchLoadArgsSettingsCtrl1.Name = "batchLoadArgsSettingsCtrl1";
            this.batchLoadArgsSettingsCtrl1.Size = new System.Drawing.Size(692, 215);
            this.batchLoadArgsSettingsCtrl1.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 878);
            this.Controls.Add(this.batchLoadArgsSettingsCtrl1);
            this.Controls.Add(this.buttonProcessBatch);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Thingy For Jeff";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private TextBox textBox2;
        private Button buttonProcessBatch;
        private BatchLoadArgsSettingsCtrl batchLoadArgsSettingsCtrl1;
    }
}