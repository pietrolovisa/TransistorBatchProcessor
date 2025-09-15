// Decompiled with JetBrains decompiler
// Type: DCAProApp.UpdatePromptBox
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using DCAProApp.Properties;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace DCAProApp;

internal class UpdatePromptBox : Form
{
  internal bool FlagUpdateNow;
  private IContainer components;
  private Label labelTitle;
  private Button okButton;
  private LinkLabel linkLabel1;
  internal Label labelNewVersion;
  internal Label labelCurrentVersion;
  internal CheckBox checkBoxIgnoreThis;
  internal CheckBox checkBoxIgnoreAll;
  private Label label1;
  private Button bUpdateNow;

  public UpdatePromptBox()
  {
    this.InitializeComponent();
    this.FlagUpdateNow = false;
  }

  public string AssemblyTitle
  {
    get
    {
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyTitleAttribute), false);
      if (customAttributes.Length > 0)
      {
        AssemblyTitleAttribute assemblyTitleAttribute = (AssemblyTitleAttribute) customAttributes[0];
        if (assemblyTitleAttribute.Title != "")
          return assemblyTitleAttribute.Title;
      }
      return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
    }
  }

  public string AssemblyVersion => Assembly.GetExecutingAssembly().GetName().Version.ToString();

  public string AssemblyDescription
  {
    get
    {
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyDescriptionAttribute), false);
      return customAttributes.Length == 0 ? "" : ((AssemblyDescriptionAttribute) customAttributes[0]).Description;
    }
  }

  public string AssemblyProduct
  {
    get
    {
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyProductAttribute), false);
      return customAttributes.Length == 0 ? "" : ((AssemblyProductAttribute) customAttributes[0]).Product;
    }
  }

  public string AssemblyCopyright
  {
    get
    {
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCopyrightAttribute), false);
      return customAttributes.Length == 0 ? "" : ((AssemblyCopyrightAttribute) customAttributes[0]).Copyright;
    }
  }

  public string AssemblyCompany
  {
    get
    {
      object[] customAttributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof (AssemblyCompanyAttribute), false);
      return customAttributes.Length == 0 ? "" : ((AssemblyCompanyAttribute) customAttributes[0]).Company;
    }
  }

  private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
  {
    Process.Start(Settings.Default.SupportPageLocation);
  }

  private void bUpdateNow_Click(object sender, EventArgs e)
  {
    this.FlagUpdateNow = true;
    this.Close();
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.labelTitle = new Label();
    this.labelNewVersion = new Label();
    this.labelCurrentVersion = new Label();
    this.okButton = new Button();
    this.checkBoxIgnoreThis = new CheckBox();
    this.checkBoxIgnoreAll = new CheckBox();
    this.linkLabel1 = new LinkLabel();
    this.label1 = new Label();
    this.bUpdateNow = new Button();
    this.SuspendLayout();
    this.labelTitle.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.labelTitle.Location = new Point(5, 9);
    this.labelTitle.Margin = new Padding(6, 0, 3, 0);
    this.labelTitle.Name = "labelTitle";
    this.labelTitle.Size = new Size(362, 22);
    this.labelTitle.TabIndex = 26;
    this.labelTitle.Text = "A new software update is available.";
    this.labelTitle.TextAlign = ContentAlignment.MiddleCenter;
    this.labelNewVersion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.labelNewVersion.AutoSize = true;
    this.labelNewVersion.Location = new Point(16 /*0x10*/, 35);
    this.labelNewVersion.Margin = new Padding(6, 0, 3, 0);
    this.labelNewVersion.MaximumSize = new Size(0, 17);
    this.labelNewVersion.MinimumSize = new Size(72, 0);
    this.labelNewVersion.Name = "labelNewVersion";
    this.labelNewVersion.Size = new Size(72, 13);
    this.labelNewVersion.TabIndex = 25;
    this.labelNewVersion.Text = "New version: ";
    this.labelNewVersion.TextAlign = ContentAlignment.MiddleLeft;
    this.labelCurrentVersion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.labelCurrentVersion.AutoSize = true;
    this.labelCurrentVersion.Location = new Point(16 /*0x10*/, 55);
    this.labelCurrentVersion.Margin = new Padding(6, 0, 3, 0);
    this.labelCurrentVersion.MaximumSize = new Size(0, 17);
    this.labelCurrentVersion.MinimumSize = new Size(72, 0);
    this.labelCurrentVersion.Name = "labelCurrentVersion";
    this.labelCurrentVersion.Size = new Size(72, 13);
    this.labelCurrentVersion.TabIndex = 27;
    this.labelCurrentVersion.Text = "This version: ";
    this.labelCurrentVersion.TextAlign = ContentAlignment.MiddleLeft;
    this.okButton.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.okButton.DialogResult = DialogResult.Cancel;
    this.okButton.Location = new Point(292, 148);
    this.okButton.Name = "okButton";
    this.okButton.Size = new Size(75, 23);
    this.okButton.TabIndex = 30;
    this.okButton.Text = "&OK";
    this.checkBoxIgnoreThis.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.checkBoxIgnoreThis.AutoSize = true;
    this.checkBoxIgnoreThis.Location = new Point(15, 130);
    this.checkBoxIgnoreThis.Name = "checkBoxIgnoreThis";
    this.checkBoxIgnoreThis.Size = new Size(114, 17);
    this.checkBoxIgnoreThis.TabIndex = 31 /*0x1F*/;
    this.checkBoxIgnoreThis.Text = "Ignore this update.";
    this.checkBoxIgnoreThis.UseVisualStyleBackColor = true;
    this.checkBoxIgnoreAll.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.checkBoxIgnoreAll.AutoSize = true;
    this.checkBoxIgnoreAll.Location = new Point(15, 153);
    this.checkBoxIgnoreAll.Name = "checkBoxIgnoreAll";
    this.checkBoxIgnoreAll.Size = new Size(113, 17);
    this.checkBoxIgnoreAll.TabIndex = 32 /*0x20*/;
    this.checkBoxIgnoreAll.Text = "Ignore all updates.";
    this.checkBoxIgnoreAll.UseVisualStyleBackColor = true;
    this.linkLabel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.linkLabel1.Location = new Point(16 /*0x10*/, 97);
    this.linkLabel1.Name = "linkLabel1";
    this.linkLabel1.Size = new Size(346, 17);
    this.linkLabel1.TabIndex = 33;
    this.linkLabel1.TabStop = true;
    this.linkLabel1.Text = " http://www.peakelec.co.uk/acatalog/dca75_support.html";
    this.linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
    this.linkLabel1.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
    this.label1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.label1.Location = new Point(8, 78);
    this.label1.Margin = new Padding(6, 0, 3, 0);
    this.label1.Name = "label1";
    this.label1.Size = new Size(362, 19);
    this.label1.TabIndex = 34;
    this.label1.Text = "For more information go to:";
    this.label1.TextAlign = ContentAlignment.MiddleCenter;
    this.bUpdateNow.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.bUpdateNow.DialogResult = DialogResult.Cancel;
    this.bUpdateNow.Location = new Point(262, 42);
    this.bUpdateNow.Name = "bUpdateNow";
    this.bUpdateNow.Size = new Size(100, 23);
    this.bUpdateNow.TabIndex = 35;
    this.bUpdateNow.Text = "&Update now";
    this.bUpdateNow.Click += new EventHandler(this.bUpdateNow_Click);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(379, 187);
    this.Controls.Add((Control) this.bUpdateNow);
    this.Controls.Add((Control) this.label1);
    this.Controls.Add((Control) this.linkLabel1);
    this.Controls.Add((Control) this.checkBoxIgnoreAll);
    this.Controls.Add((Control) this.checkBoxIgnoreThis);
    this.Controls.Add((Control) this.labelTitle);
    this.Controls.Add((Control) this.labelNewVersion);
    this.Controls.Add((Control) this.labelCurrentVersion);
    this.Controls.Add((Control) this.okButton);
    this.FormBorderStyle = FormBorderStyle.FixedDialog;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = nameof (UpdatePromptBox);
    this.Padding = new Padding(9);
    this.ShowIcon = false;
    this.ShowInTaskbar = false;
    this.StartPosition = FormStartPosition.CenterParent;
    this.Text = "Update available";
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
