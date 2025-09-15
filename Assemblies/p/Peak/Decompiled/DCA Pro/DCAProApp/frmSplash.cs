// Decompiled with JetBrains decompiler
// Type: DCAProApp.frmSplash
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using AlphaForms;
using DCAProApp.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DCAProApp;

public class frmSplash : AlphaForm
{
  private IContainer components;

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.SuspendLayout();
    this.AutoScaleMode = AutoScaleMode.None;
    this.BackColor = Color.FromArgb((int) byte.MaxValue, 128 /*0x80*/, 0);
    this.BackgroundImageLayout = ImageLayout.Center;
    this.BlendedBackground = Resources.loading;
    this.ClientSize = new Size(400, 400);
    this.DoubleBuffered = true;
    this.ForeColor = Color.White;
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (frmSplash);
    this.ShowInTaskbar = false;
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "Hi";
    this.TopMost = true;
    this.TransparencyKey = Color.FromArgb((int) byte.MaxValue, 128 /*0x80*/, 0);
    this.Shown += new EventHandler(this.frmSplash_Shown);
    this.ResumeLayout(false);
  }

  public frmSplash() => this.InitializeComponent();

  private void frmSplash_Shown(object sender, EventArgs e)
  {
    int num = 1500;
    int steps = 50;
    Timer timer = new Timer();
    timer.Interval = num / steps;
    int currentStep = 400;
    int inc = currentStep / steps;
    timer.Tick += (EventHandler) ((arg1, arg2) =>
    {
      if ((double) currentStep / (double) steps <= 1.0)
      {
        this.SetOpacity((double) currentStep / (double) steps);
        this.Refresh();
      }
      if (currentStep <= 0)
      {
        this.SetOpacity(0.0);
        this.Refresh();
        timer.Stop();
        timer.Dispose();
      }
      else
        currentStep -= inc;
    });
    timer.Start();
  }
}
