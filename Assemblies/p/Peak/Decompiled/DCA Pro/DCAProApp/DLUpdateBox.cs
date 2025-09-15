// Decompiled with JetBrains decompiler
// Type: DCAProApp.DLUpdateBox
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using DCAProApp.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

#nullable disable
namespace DCAProApp;

public class DLUpdateBox : Form
{
  public DialogResult Result;
  private WebClient myClient = new WebClient();
  private string DLPath = "";
  private IContainer components;
  private Button cancelButton;
  private Label labelTitle;
  private Label label1;
  private LinkLabel linkLabel1;
  public ProgressBar Progress;

  public DLUpdateBox()
  {
    this.InitializeComponent();
    this.myClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(this.DLUpdateProgressChanged);
    this.myClient.DownloadFileCompleted += new AsyncCompletedEventHandler(this.DLUpdateCompleted);
  }

  private void cancelButton_Click(object sender, EventArgs e)
  {
    this.Result = DialogResult.Cancel;
    this.myClient.CancelAsync();
  }

  private void DLUpdateProgressChanged(object sender, DownloadProgressChangedEventArgs e)
  {
    this.Progress.Value = e.ProgressPercentage;
  }

  private void DLUpdateCompleted(object sender, AsyncCompletedEventArgs e)
  {
    try
    {
      if (!e.Cancelled && e.Error == null && this.Result != DialogResult.Cancel)
      {
        if (this.DLPath != "" && System.IO.File.Exists(this.DLPath))
        {
          if (MessageBox.Show(string.Format("Run the new setup now?"), "DCA Pro update", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) != DialogResult.OK)
            return;
          Process.Start(this.DLPath);
        }
        else
        {
          int num1 = (int) MessageBox.Show(string.Format("Update failed.  Please download & update manually."), "DCA Pro update", MessageBoxButtons.OK);
        }
      }
      else
      {
        if (e.Error == null || e.Error.Message == null)
          return;
        if (e.Error.InnerException != null)
        {
          if (e.Error.InnerException.Message == null)
            return;
          int num2 = (int) MessageBox.Show(string.Format("Update failed.  Please download & update manually.{2}{2}Error:{2}{0}{2}{1}", (object) e.Error.Message, (object) e.Error.InnerException.Message, (object) Environment.NewLine), "DCA Pro update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        else
        {
          if (e.Cancelled)
            return;
          int num3 = (int) MessageBox.Show(string.Format("Update failed.  Please download & update manually.{1}{1}Error:{1}{0}", (object) e.Error.Message, (object) Environment.NewLine), "DCA Pro update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(string.Format("Update failed.  Please download & update manually.{1}{1}Error:{1}{0}", (object) ex.Message, (object) Environment.NewLine), "DCA Pro update", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
    }
    finally
    {
      this.Hide();
    }
  }

  private void DLUpdateBox_Shown(object sender, EventArgs e)
  {
    try
    {
      this.Result = DialogResult.None;
      this.DLPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Peak Electronic Design\\DCA Pro\\Installer";
      if (!Directory.Exists(this.DLPath))
        Directory.CreateDirectory(this.DLPath);
      this.DLPath += "\\DCAProSetup.exe";
      this.myClient.DownloadFileAsync(new Uri(Settings.Default.UpdateFileLocation), this.DLPath);
    }
    catch (ArgumentException ex)
    {
      this.Hide();
      throw;
    }
    catch (PlatformNotSupportedException ex)
    {
      this.Hide();
      throw;
    }
    catch (WebException ex)
    {
      int num = (int) MessageBox.Show(string.Format("Update failed.  Please download & update manually.{1}{1}{0}", (object) ex.Message, (object) Environment.NewLine), "DCA Pro update", MessageBoxButtons.OK);
      this.Hide();
    }
    catch (Exception ex)
    {
      this.Hide();
      throw;
    }
  }

  private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    Process.Start(Settings.Default.SupportPageLocation);
  }

  private void DLUpdateBox_FormClosing(object sender, FormClosingEventArgs e)
  {
    e.Cancel = true;
    this.Result = DialogResult.Cancel;
    this.myClient.CancelAsync();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.cancelButton = new Button();
    this.labelTitle = new Label();
    this.Progress = new ProgressBar();
    this.label1 = new Label();
    this.linkLabel1 = new LinkLabel();
    this.SuspendLayout();
    this.cancelButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.cancelButton.DialogResult = DialogResult.Cancel;
    this.cancelButton.Location = new Point(152, 148);
    this.cancelButton.Name = "cancelButton";
    this.cancelButton.Size = new Size(75, 23);
    this.cancelButton.TabIndex = 31 /*0x1F*/;
    this.cancelButton.Text = "&Cancel";
    this.cancelButton.Click += new EventHandler(this.cancelButton_Click);
    this.labelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.labelTitle.Location = new Point(5, 9);
    this.labelTitle.Margin = new Padding(6, 0, 3, 0);
    this.labelTitle.Name = "labelTitle";
    this.labelTitle.Size = new Size(362, 22);
    this.labelTitle.TabIndex = 32 /*0x20*/;
    this.labelTitle.Text = "Downloading update...";
    this.labelTitle.TextAlign = ContentAlignment.MiddleCenter;
    this.Progress.Location = new Point(29, 43);
    this.Progress.Name = "Progress";
    this.Progress.Size = new Size(321, 23);
    this.Progress.TabIndex = 33;
    this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.label1.Location = new Point(8, 78);
    this.label1.Margin = new Padding(6, 0, 3, 0);
    this.label1.Name = "label1";
    this.label1.Size = new Size(362, 19);
    this.label1.TabIndex = 36;
    this.label1.Text = "For more information go to:";
    this.label1.TextAlign = ContentAlignment.MiddleCenter;
    this.linkLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.linkLabel1.Location = new Point(16 /*0x10*/, 97);
    this.linkLabel1.Name = "linkLabel1";
    this.linkLabel1.Size = new Size(346, 17);
    this.linkLabel1.TabIndex = 35;
    this.linkLabel1.TabStop = true;
    this.linkLabel1.Text = " http://www.peakelec.co.uk/acatalog/dca75_support.html";
    this.linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
    this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(379, 187);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.linkLabel1);
    this.Controls.Add((Control) this.Progress);
    this.Controls.Add((Control) this.labelTitle);
    this.Controls.Add((Control) this.cancelButton);
    this.FormBorderStyle = FormBorderStyle.FixedDialog;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = nameof (DLUpdateBox);
    this.Padding = new Padding(9);
    this.ShowIcon = false;
    this.ShowInTaskbar = false;
    this.StartPosition = FormStartPosition.CenterParent;
    this.Text = "DCA Pro update";
    this.FormClosing += new FormClosingEventHandler(this.DLUpdateBox_FormClosing);
    this.Shown += new EventHandler(this.DLUpdateBox_Shown);
    this.ResumeLayout(false);
  }
}
