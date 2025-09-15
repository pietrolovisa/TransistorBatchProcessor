// Decompiled with JetBrains decompiler
// Type: DCAProApp.ComboBoxItem
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System.Drawing;

#nullable disable
namespace DCAProApp;

public class ComboBoxItem
{
  private string text = "";
  private Color foreColor = SystemColors.WindowText;

  public ComboBoxItem()
  {
  }

  public ComboBoxItem(string pText)
  {
    this.foreColor = SystemColors.WindowText;
    this.text = pText;
  }

  public ComboBoxItem(string pText, Color pColor)
  {
    this.text = pText;
    this.foreColor = pColor;
  }

  public string Text
  {
    get => this.text;
    set => this.text = value;
  }

  public Color ForeColor
  {
    get => this.foreColor;
    set => this.foreColor = value;
  }
}
