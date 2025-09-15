// Decompiled with JetBrains decompiler
// Type: DCAProApp.AboutBox
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

#nullable disable
namespace DCAProApp;

internal class AboutBox : Form
{
  private IContainer components;
  private TableLayoutPanel tableLayoutPanel;
  private Label labelProductName;
  private Label labelVersion;
  private Label labelCopyright;
  private Label labelCompanyName;
  private PictureBox logoPictureBox;
  private Label label1;
  internal Label labelDevice;
  private Label label4;
  internal Label labelType;
  internal Label labelSerial;
  internal Label labelFirmType;
  private Label label3;
  private Label label2;

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AboutBox));
    this.tableLayoutPanel = new TableLayoutPanel();
    this.labelFirmType = new Label();
    this.label3 = new Label();
    this.label4 = new Label();
    this.labelType = new Label();
    this.label2 = new Label();
    this.labelSerial = new Label();
    this.labelDevice = new Label();
    this.label1 = new Label();
    this.logoPictureBox = new PictureBox();
    this.labelProductName = new Label();
    this.labelVersion = new Label();
    this.labelCopyright = new Label();
    this.labelCompanyName = new Label();
    this.tableLayoutPanel.SuspendLayout();
    ((ISupportInitialize) this.logoPictureBox).BeginInit();
    this.SuspendLayout();
    this.tableLayoutPanel.ColumnCount = 2;
    this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55.63549f));
    this.tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 44.36451f));
    this.tableLayoutPanel.Controls.Add((Control) this.labelFirmType, 1, 6);
    this.tableLayoutPanel.Controls.Add((Control) this.label3, 0, 7);
    this.tableLayoutPanel.Controls.Add((Control) this.label4, 0, 5);
    this.tableLayoutPanel.Controls.Add((Control) this.labelType, 1, 5);
    this.tableLayoutPanel.Controls.Add((Control) this.label2, 0, 6);
    this.tableLayoutPanel.Controls.Add((Control) this.labelSerial, 1, 7);
    this.tableLayoutPanel.Controls.Add((Control) this.labelDevice, 1, 4);
    this.tableLayoutPanel.Controls.Add((Control) this.label1, 0, 4);
    this.tableLayoutPanel.Controls.Add((Control) this.logoPictureBox, 0, 0);
    this.tableLayoutPanel.Controls.Add((Control) this.labelProductName, 1, 0);
    this.tableLayoutPanel.Controls.Add((Control) this.labelVersion, 1, 1);
    this.tableLayoutPanel.Controls.Add((Control) this.labelCopyright, 1, 2);
    this.tableLayoutPanel.Controls.Add((Control) this.labelCompanyName, 1, 3);
    this.tableLayoutPanel.Dock = DockStyle.Fill;
    this.tableLayoutPanel.Location = new Point(9, 9);
    this.tableLayoutPanel.Name = "tableLayoutPanel";
    this.tableLayoutPanel.RowCount = 8;
    this.tableLayoutPanel.RowStyles.Add(new RowStyle());
    this.tableLayoutPanel.RowStyles.Add(new RowStyle());
    this.tableLayoutPanel.RowStyles.Add(new RowStyle());
    this.tableLayoutPanel.RowStyles.Add(new RowStyle());
    this.tableLayoutPanel.RowStyles.Add(new RowStyle());
    this.tableLayoutPanel.RowStyles.Add(new RowStyle());
    this.tableLayoutPanel.RowStyles.Add(new RowStyle());
    this.tableLayoutPanel.RowStyles.Add(new RowStyle());
    this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
    this.tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
    this.tableLayoutPanel.Size = new Size(301, 153);
    this.tableLayoutPanel.TabIndex = 0;
    this.labelFirmType.Dock = DockStyle.Fill;
    this.labelFirmType.Location = new Point(173, 117);
    this.labelFirmType.Margin = new Padding(6, 0, 3, 0);
    this.labelFirmType.MaximumSize = new Size(0, 17);
    this.labelFirmType.Name = "labelFirmType";
    this.labelFirmType.Size = new Size(125, 17);
    this.labelFirmType.TabIndex = 34;
    this.labelFirmType.TextAlign = ContentAlignment.MiddleLeft;
    this.label3.Dock = DockStyle.Fill;
    this.label3.Location = new Point(6, 134);
    this.label3.Margin = new Padding(6, 0, 3, 0);
    this.label3.MaximumSize = new Size(0, 17);
    this.label3.Name = "label3";
    this.label3.Size = new Size(158, 17);
    this.label3.TabIndex = 33;
    this.label3.Text = "Serial No:";
    this.label3.TextAlign = ContentAlignment.MiddleRight;
    this.label4.Dock = DockStyle.Fill;
    this.label4.Location = new Point(6, 100);
    this.label4.Margin = new Padding(6, 0, 3, 0);
    this.label4.MaximumSize = new Size(0, 17);
    this.label4.Name = "label4";
    this.label4.Size = new Size(158, 17);
    this.label4.TabIndex = 32 /*0x20*/;
    this.label4.Text = "Type:";
    this.label4.TextAlign = ContentAlignment.MiddleRight;
    this.labelType.Dock = DockStyle.Fill;
    this.labelType.Location = new Point(173, 100);
    this.labelType.Margin = new Padding(6, 0, 3, 0);
    this.labelType.MaximumSize = new Size(0, 17);
    this.labelType.Name = "labelType";
    this.labelType.Size = new Size(125, 17);
    this.labelType.TabIndex = 31 /*0x1F*/;
    this.labelType.TextAlign = ContentAlignment.MiddleLeft;
    this.label2.Dock = DockStyle.Fill;
    this.label2.Location = new Point(6, 117);
    this.label2.Margin = new Padding(6, 0, 3, 0);
    this.label2.MaximumSize = new Size(0, 17);
    this.label2.Name = "label2";
    this.label2.Size = new Size(158, 17);
    this.label2.TabIndex = 30;
    this.label2.Text = "Version:";
    this.label2.TextAlign = ContentAlignment.MiddleRight;
    this.labelSerial.Dock = DockStyle.Fill;
    this.labelSerial.Location = new Point(173, 134);
    this.labelSerial.Margin = new Padding(6, 0, 3, 0);
    this.labelSerial.MaximumSize = new Size(0, 17);
    this.labelSerial.Name = "labelSerial";
    this.labelSerial.Size = new Size(125, 17);
    this.labelSerial.TabIndex = 29;
    this.labelSerial.TextAlign = ContentAlignment.MiddleLeft;
    this.labelDevice.Dock = DockStyle.Fill;
    this.labelDevice.Location = new Point(173, 83);
    this.labelDevice.Margin = new Padding(6, 0, 3, 0);
    this.labelDevice.MaximumSize = new Size(0, 17);
    this.labelDevice.Name = "labelDevice";
    this.labelDevice.Size = new Size(125, 17);
    this.labelDevice.TabIndex = 28;
    this.labelDevice.Text = "Not Connected";
    this.labelDevice.TextAlign = ContentAlignment.MiddleLeft;
    this.label1.Dock = DockStyle.Fill;
    this.label1.Location = new Point(6, 83);
    this.label1.Margin = new Padding(6, 0, 3, 0);
    this.label1.MaximumSize = new Size(0, 17);
    this.label1.Name = "label1";
    this.label1.Size = new Size(158, 17);
    this.label1.TabIndex = 26;
    this.label1.Text = "Device:";
    this.label1.TextAlign = ContentAlignment.MiddleRight;
    this.logoPictureBox.Cursor = Cursors.Hand;
    this.logoPictureBox.Image = (Image) componentResourceManager.GetObject("logoPictureBox.Image");
    this.logoPictureBox.Location = new Point(3, 3);
    this.logoPictureBox.Name = "logoPictureBox";
    this.tableLayoutPanel.SetRowSpan((Control) this.logoPictureBox, 4);
    this.logoPictureBox.Size = new Size(150, 77);
    this.logoPictureBox.TabIndex = 25;
    this.logoPictureBox.TabStop = false;
    this.logoPictureBox.Click += new EventHandler(this.logoPictureBox_Click);
    this.labelProductName.Dock = DockStyle.Fill;
    this.labelProductName.Location = new Point(173, 0);
    this.labelProductName.Margin = new Padding(6, 0, 3, 0);
    this.labelProductName.MaximumSize = new Size(0, 17);
    this.labelProductName.Name = "labelProductName";
    this.labelProductName.Size = new Size(125, 17);
    this.labelProductName.TabIndex = 19;
    this.labelProductName.Text = "Product Name";
    this.labelProductName.TextAlign = ContentAlignment.MiddleLeft;
    this.labelVersion.Dock = DockStyle.Fill;
    this.labelVersion.Location = new Point(173, 17);
    this.labelVersion.Margin = new Padding(6, 0, 3, 0);
    this.labelVersion.MaximumSize = new Size(0, 17);
    this.labelVersion.Name = "labelVersion";
    this.labelVersion.Size = new Size(125, 17);
    this.labelVersion.TabIndex = 0;
    this.labelVersion.Text = "Version";
    this.labelVersion.TextAlign = ContentAlignment.MiddleLeft;
    this.labelCopyright.Dock = DockStyle.Fill;
    this.labelCopyright.Location = new Point(173, 34);
    this.labelCopyright.Margin = new Padding(6, 0, 3, 0);
    this.labelCopyright.MaximumSize = new Size(0, 17);
    this.labelCopyright.Name = "labelCopyright";
    this.labelCopyright.Size = new Size(125, 17);
    this.labelCopyright.TabIndex = 21;
    this.labelCopyright.Text = "Copyright";
    this.labelCopyright.TextAlign = ContentAlignment.MiddleLeft;
    this.labelCompanyName.Dock = DockStyle.Fill;
    this.labelCompanyName.Location = new Point(173, 51);
    this.labelCompanyName.Margin = new Padding(6, 0, 3, 0);
    this.labelCompanyName.MaximumSize = new Size(0, 17);
    this.labelCompanyName.Name = "labelCompanyName";
    this.labelCompanyName.Size = new Size(125, 17);
    this.labelCompanyName.TabIndex = 22;
    this.labelCompanyName.Text = "Company Name";
    this.labelCompanyName.TextAlign = ContentAlignment.MiddleLeft;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(319, 171);
    this.Controls.Add((Control) this.tableLayoutPanel);
    this.FormBorderStyle = FormBorderStyle.FixedDialog;
    this.MaximizeBox = false;
    this.MinimizeBox = false;
    this.Name = nameof (AboutBox);
    this.Padding = new Padding(9);
    this.ShowIcon = false;
    this.ShowInTaskbar = false;
    this.StartPosition = FormStartPosition.CenterParent;
    this.Text = nameof (AboutBox);
    this.tableLayoutPanel.ResumeLayout(false);
    ((ISupportInitialize) this.logoPictureBox).EndInit();
    this.ResumeLayout(false);
  }

  public AboutBox()
  {
    this.InitializeComponent();
    this.Text = $"{this.AssemblyTitle}";
    this.labelProductName.Text = this.AssemblyProduct;
    this.labelVersion.Text = $"Version {this.AssemblyVersion}";
    this.labelCopyright.Text = this.AssemblyCopyright;
    this.labelCompanyName.Text = this.AssemblyCompany;
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

  private void logoPictureBox_Click(object sender, EventArgs e)
  {
    Process.Start("http://www.peakelec.co.uk/");
  }
}
