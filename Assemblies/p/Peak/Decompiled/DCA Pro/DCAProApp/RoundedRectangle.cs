// Decompiled with JetBrains decompiler
// Type: DCAProApp.RoundedRectangle
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System.Drawing;
using System.Drawing.Drawing2D;

#nullable disable
namespace DCAProApp;

public abstract class RoundedRectangle
{
  public static GraphicsPath Create(
    int x,
    int y,
    int width,
    int height,
    int radius,
    RoundedRectangle.RectangleCorners corners)
  {
    int num1 = x + width;
    int num2 = y + height;
    int num3 = num1 - radius;
    int num4 = num2 - radius;
    int num5 = x + radius;
    int num6 = y + radius;
    int num7 = radius * 2;
    int x1 = num1 - num7 - 1;
    int y1 = num2 - num7 - 1;
    GraphicsPath graphicsPath = new GraphicsPath();
    graphicsPath.StartFigure();
    if ((RoundedRectangle.RectangleCorners.TopLeft & corners) == RoundedRectangle.RectangleCorners.TopLeft)
    {
      graphicsPath.AddArc(x, y, num7, num7, 180f, 90f);
    }
    else
    {
      graphicsPath.AddLine(x, num6, x, y);
      graphicsPath.AddLine(x, y, num5, y);
    }
    graphicsPath.AddLine(num5, y, num3, y);
    if ((RoundedRectangle.RectangleCorners.TopRight & corners) == RoundedRectangle.RectangleCorners.TopRight)
    {
      graphicsPath.AddArc(x1, y, num7, num7, 270f, 90f);
    }
    else
    {
      graphicsPath.AddLine(num3, y, num1, y);
      graphicsPath.AddLine(num1, y, num1, num6);
    }
    graphicsPath.AddLine(num1, num6, num1, num4);
    if ((RoundedRectangle.RectangleCorners.BottomRight & corners) == RoundedRectangle.RectangleCorners.BottomRight)
    {
      graphicsPath.AddArc(x1, y1, num7, num7, 0.0f, 90f);
    }
    else
    {
      graphicsPath.AddLine(num1, num4, num1, num2);
      graphicsPath.AddLine(num1, num2, num3, num2);
    }
    graphicsPath.AddLine(num3, num2, num5, num2);
    if ((RoundedRectangle.RectangleCorners.BottomLeft & corners) == RoundedRectangle.RectangleCorners.BottomLeft)
    {
      graphicsPath.AddArc(x, y1, num7, num7, 90f, 90f);
    }
    else
    {
      graphicsPath.AddLine(num5, num2, x, num2);
      graphicsPath.AddLine(x, num2, x, num4);
    }
    graphicsPath.AddLine(x, num4, x, num6);
    graphicsPath.CloseFigure();
    return graphicsPath;
  }

  public static GraphicsPath Create(
    Rectangle rect,
    int radius,
    RoundedRectangle.RectangleCorners c)
  {
    return RoundedRectangle.Create(rect.X, rect.Y, rect.Width, rect.Height, radius, c);
  }

  public static GraphicsPath Create(int x, int y, int width, int height, int radius)
  {
    return RoundedRectangle.Create(x, y, width, height, radius, RoundedRectangle.RectangleCorners.All);
  }

  public static GraphicsPath Create(Rectangle rect, int radius)
  {
    return RoundedRectangle.Create(rect.X, rect.Y, rect.Width, rect.Height, radius);
  }

  public static GraphicsPath Create(int x, int y, int width, int height)
  {
    return RoundedRectangle.Create(x, y, width, height, 5);
  }

  public static GraphicsPath Create(Rectangle rect)
  {
    return RoundedRectangle.Create(rect.X, rect.Y, rect.Width, rect.Height);
  }

  public enum RectangleCorners
  {
    None = 0,
    TopLeft = 1,
    TopRight = 2,
    BottomLeft = 4,
    BottomRight = 8,
    All = 15, // 0x0000000F
  }
}
