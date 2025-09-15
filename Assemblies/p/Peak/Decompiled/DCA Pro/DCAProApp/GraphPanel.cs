// Decompiled with JetBrains decompiler
// Type: DCAProApp.GraphPanel
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#nullable disable
namespace DCAProApp;

public class GraphPanel : Panel
{
  public GraphPanel()
  {
    this.DoubleBuffered = true;
    this.Rectangles = new GraphPanel.RectanglePlus[0];
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
  public GraphPanel.RectanglePlus[] Rectangles { get; set; }

  protected override void OnPaint(PaintEventArgs e)
  {
    base.OnPaint(e);
    foreach (GraphPanel.RectanglePlus rectangle in this.Rectangles)
    {
      SolidBrush solidBrush = new SolidBrush(rectangle.Color);
      GraphicsPath path = RoundedRectangle.Create(rectangle.Rectangle);
      e.Graphics.FillPath((Brush) solidBrush, path);
    }
  }

  public class RectanglePlus
  {
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Rectangle Rectangle { get; set; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public Color Color { get; set; }
  }
}
