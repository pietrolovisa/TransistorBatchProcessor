// Decompiled with JetBrains decompiler
// Type: DCAProApp.dialogLCDContrast
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DCAProApp;

internal class dialogLCDContrast : Form
{
  private IContainer components;
  private TrackBar trackBar1;
  private Timer timer1;
  internal frmDCAProApp thisfrmMainApp;
  internal ushort CurrentValue;
  internal ushort LastValue;

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.components = (IContainer) new System.ComponentModel.Container();
    this.trackBar1 = new TrackBar();
    this.timer1 = new Timer(this.components);
    this.trackBar1.BeginInit();
    this.SuspendLayout();
    this.trackBar1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.trackBar1.Location = new Point(0, 0);
    this.trackBar1.Maximum = 4095 /*0x0FFF*/;
    this.trackBar1.Name = "trackBar1";
    this.trackBar1.Size = new Size(327, 45);
    this.trackBar1.TabIndex = 0;
    this.trackBar1.TickFrequency = 10;
    this.trackBar1.TickStyle = TickStyle.None;
    this.trackBar1.Value = 2047 /*0x07FF*/;
    this.trackBar1.ValueChanged += new EventHandler(this.trackBar1_ValueChanged);
    this.timer1.Interval = 500;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(327, 34);
    this.Controls.Add((Control) this.trackBar1);
    this.Name = nameof (dialogLCDContrast);
    this.Text = "LCD Contrast";
    this.FormClosed += new FormClosedEventHandler(this.dialogUtilities_FormClosed);
    this.trackBar1.EndInit();
    this.ResumeLayout(false);
    this.PerformLayout();
  }

  public dialogLCDContrast(frmDCAProApp Parent)
  {
    this.thisfrmMainApp = Parent;
    this.InitializeComponent();
  }

  private void timer1_Tick(object sender, EventArgs e)
  {
    if ((int) (ushort) this.trackBar1.Value == (int) this.CurrentValue)
      return;
    this.CurrentValue = (ushort) this.trackBar1.Value;
    int num = (int) this.thisfrmMainApp.thisDCAPro.SetContrast(this.CurrentValue);
  }

  private void dialogUtilities_FormClosed(object sender, FormClosedEventArgs e)
  {
    this.timer1.Stop();
  }

  private void trackBar1_ValueChanged(object sender, EventArgs e) => this.timer1.Start();
}
