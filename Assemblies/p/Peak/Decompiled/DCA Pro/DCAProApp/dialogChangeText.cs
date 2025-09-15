// Decompiled with JetBrains decompiler
// Type: DCAProApp.dialogChangeText
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DCAProApp;

public class dialogChangeText : Form
{
  internal string TheText;
  internal Color TheColour;
  internal ColorDialog theColorDialog;
  private IContainer components;
  private Button butOK;
  private Button butCancel;
  private TextBox textBox;
  private Panel panelColour;

  public dialogChangeText(string GivenText, Color GivenColour, ColorDialog aColorDialog)
  {
    this.InitializeComponent();
    this.theColorDialog = aColorDialog;
    this.TheText = GivenText;
    this.TheColour = GivenColour;
    this.textBox.Text = this.TheText;
    this.panelColour.BackColor = this.TheColour;
  }

  private void textBox_KeyDown(object sender, KeyEventArgs e)
  {
    if (e.KeyCode != Keys.Return && e.KeyCode != Keys.Return)
      return;
    this.DialogResult = DialogResult.OK;
    this.TheText = this.textBox.Text;
  }

  private void butOK_Click(object sender, EventArgs e)
  {
    this.DialogResult = DialogResult.OK;
    this.TheText = this.textBox.Text;
    this.TheColour = this.panelColour.BackColor;
  }

  private void butCancel_Click(object sender, EventArgs e)
  {
    this.DialogResult = DialogResult.Cancel;
  }

  private void panelColour_Click(object sender, EventArgs e)
  {
    if (this.theColorDialog.ShowDialog() != DialogResult.OK)
      return;
    this.TheColour = this.theColorDialog.Color;
    this.panelColour.BackColor = this.TheColour;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.butOK = new Button();
    this.butCancel = new Button();
    this.textBox = new TextBox();
    this.panelColour = new Panel();
    Label label = new Label();
    this.SuspendLayout();
    label.AutoSize = true;
    label.Location = new Point(41, 43);
    label.Name = "label1";
    label.Size = new Size(40, 13);
    label.TabIndex = 4;
    label.Text = "Colour:";
    this.butOK.Location = new Point(12, 67);
    this.butOK.Name = "butOK";
    this.butOK.Size = new Size(75, 23);
    this.butOK.TabIndex = 0;
    this.butOK.Text = "OK";
    this.butOK.UseVisualStyleBackColor = true;
    this.butOK.Click += new EventHandler(this.butOK_Click);
    this.butCancel.Location = new Point(125, 67);
    this.butCancel.Name = "butCancel";
    this.butCancel.Size = new Size(75, 23);
    this.butCancel.TabIndex = 1;
    this.butCancel.Text = "Cancel";
    this.butCancel.UseVisualStyleBackColor = true;
    this.butCancel.Click += new EventHandler(this.butCancel_Click);
    this.textBox.Location = new Point(12, 12);
    this.textBox.Name = "textBox";
    this.textBox.Size = new Size(188, 20);
    this.textBox.TabIndex = 2;
    this.textBox.KeyDown += new KeyEventHandler(this.textBox_KeyDown);
    this.panelColour.BorderStyle = BorderStyle.Fixed3D;
    this.panelColour.Location = new Point(87, 41);
    this.panelColour.Name = "panelColour";
    this.panelColour.Size = new Size(35, 18);
    this.panelColour.TabIndex = 5;
    this.panelColour.Click += new EventHandler(this.panelColour_Click);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(212, 100);
    this.Controls.Add((Control) this.panelColour);
    this.Controls.Add((Control) label);
    this.Controls.Add((Control) this.textBox);
    this.Controls.Add((Control) this.butCancel);
    this.Controls.Add((Control) this.butOK);
    this.Name = nameof (dialogChangeText);
    this.Text = "Rename";
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
