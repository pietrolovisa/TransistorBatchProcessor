// Decompiled with JetBrains decompiler
// Type: DCAProApp.ComboBoxCustom
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#nullable disable
namespace DCAProApp;

public class ComboBoxCustom : ComboBox
{
  public ComboBoxCustom() => this.DrawMode = DrawMode.OwnerDrawFixed;

  protected override void OnDrawItem(DrawItemEventArgs e)
  {
    base.OnDrawItem(e);
    if (e.Index < 0)
      return;
    if (this.Items[this.SelectedIndex].GetType() == typeof (ComboBoxItem))
    {
      e.DrawBackground();
      ComboBoxItem comboBoxItem = (ComboBoxItem) this.Items[e.Index];
      Brush brush = (Brush) new SolidBrush(comboBoxItem.ForeColor);
      if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
        this.ForeColor = comboBoxItem.ForeColor;
      e.Graphics.DrawString(comboBoxItem.Text, this.Font, brush, (float) e.Bounds.X, (float) e.Bounds.Y);
    }
    else
    {
      if (!(this.Items[this.SelectedIndex].GetType() == typeof (string)))
        return;
      e.DrawBackground();
      string input = (string) this.Items[e.Index];
      Color windowText = SystemColors.WindowText;
      RectangleF bounds = (RectangleF) e.Bounds;
      StringFormat stringFormat = new StringFormat();
      stringFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
      SizeF layoutArea1 = new SizeF(bounds.Width, bounds.Height);
      SizeF sizeF1 = e.Graphics.MeasureString(" ", this.Font, layoutArea1);
      foreach (string str in Regex.Split(input, "(Red|Green|Blue)"))
      {
        if (str.Length > 0)
        {
          Brush brush = (Brush) new SolidBrush(!str.Contains("Red") ? (!str.Contains("Green") ? (!str.Contains("Blue") ? SystemColors.WindowText : Display.MyBlue) : Display.MyGreen) : Display.MyRed);
          e.Graphics.DrawString(str, this.Font, brush, bounds, stringFormat);
          SizeF layoutArea2 = new SizeF(bounds.Width, bounds.Height);
          SizeF sizeF2 = e.Graphics.MeasureString(str, this.Font, layoutArea2, stringFormat);
          bounds.Width -= sizeF2.Width - sizeF1.Width;
          bounds.X += sizeF2.Width - sizeF1.Width;
        }
      }
      e.DrawFocusRectangle();
    }
  }
}
