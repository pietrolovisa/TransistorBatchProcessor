// Decompiled with JetBrains decompiler
// Type: DCAProApp.dialogRenameGraph
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace DCAProApp;

public class dialogRenameGraph : Form
{
  internal string TheText;
  internal Color TheColour;
  internal ColorDialog theColorDialog;
  private IContainer components;
  private Button butOK;
  private Button butCancel;
  private TextBox textBox;
  private Button butDefault;

  public dialogRenameGraph(string GivenText)
  {
    this.InitializeComponent();
    this.TheText = GivenText;
    this.textBox.Text = this.TheText;
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
  }

  private void butCancel_Click(object sender, EventArgs e)
  {
    this.DialogResult = DialogResult.Cancel;
  }

  private void butDefault_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.Yes;

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
    this.butDefault = new Button();
    this.SuspendLayout();
    this.butOK.Location = new Point(12, 38);
    this.butOK.Name = "butOK";
    this.butOK.Size = new Size(61, 23);
    this.butOK.TabIndex = 0;
    this.butOK.Text = "OK";
    this.butOK.UseVisualStyleBackColor = true;
    this.butOK.Click += new EventHandler(this.butOK_Click);
    this.butCancel.Location = new Point(188, 38);
    this.butCancel.Name = "butCancel";
    this.butCancel.Size = new Size(61, 23);
    this.butCancel.TabIndex = 1;
    this.butCancel.Text = "Cancel";
    this.butCancel.UseVisualStyleBackColor = true;
    this.butCancel.Click += new EventHandler(this.butCancel_Click);
    this.textBox.Location = new Point(12, 12);
    this.textBox.Name = "textBox";
    this.textBox.Size = new Size(237, 20);
    this.textBox.TabIndex = 2;
    this.textBox.KeyDown += new KeyEventHandler(this.textBox_KeyDown);
    this.butDefault.Location = new Point(79, 38);
    this.butDefault.Name = "butDefault";
    this.butDefault.Size = new Size(103, 23);
    this.butDefault.TabIndex = 3;
    this.butDefault.Text = "Reset to default";
    this.butDefault.UseVisualStyleBackColor = true;
    this.butDefault.Click += new EventHandler(this.butDefault_Click);
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.ClientSize = new Size(261, 71);
    this.Controls.Add((Control) this.butDefault);
    this.Controls.Add((Control) this.textBox);
    this.Controls.Add((Control) this.butCancel);
    this.Controls.Add((Control) this.butOK);
    this.Name = nameof (dialogRenameGraph);
    this.Text = "Rename Graph";
    this.ResumeLayout(false);
    this.PerformLayout();
  }
}
