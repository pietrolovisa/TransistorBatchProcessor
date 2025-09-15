// Decompiled with JetBrains decompiler
// Type: AlphaForms.LayeredWindow
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System;
using System.Drawing;
using System.Windows.Forms;

#nullable disable
namespace AlphaForms;

internal class LayeredWindow : Form
{
  private Rectangle m_rect;

  public Point LayeredPos
  {
    get => this.m_rect.Location;
    set => this.m_rect.Location = value;
  }

  public Size LayeredSize => this.m_rect.Size;

  public LayeredWindow()
  {
    this.ShowInTaskbar = false;
    this.FormBorderStyle = FormBorderStyle.None;
  }

  public void UpdateWindow(Bitmap image, byte opacity)
  {
    this.UpdateWindow(image, opacity, -1, -1, this.LayeredPos);
  }

  public void UpdateWindow(Bitmap image, byte opacity, int width, int height, Point pos)
  {
    IntPtr windowDc = Win32.GetWindowDC(this.Handle);
    IntPtr compatibleDc = Win32.CreateCompatibleDC(windowDc);
    IntPtr hbitmap = image.GetHbitmap(Color.FromArgb(0));
    IntPtr hObject = Win32.SelectObject(compatibleDc, hbitmap);
    Size psize = new Size(0, 0);
    Point pprSrc = new Point(0, 0);
    if (width == -1 || height == -1)
    {
      psize.Width = image.Width;
      psize.Height = image.Height;
    }
    else
    {
      psize.Width = Math.Min(image.Width, width);
      psize.Height = Math.Min(image.Height, height);
    }
    this.m_rect.Size = psize;
    this.m_rect.Location = pos;
    Win32.UpdateLayeredWindow(this.Handle, windowDc, ref pos, ref psize, compatibleDc, ref pprSrc, 0, ref new Win32.BLENDFUNCTION()
    {
      BlendOp = (byte) 0,
      SourceConstantAlpha = opacity,
      AlphaFormat = (byte) 1,
      BlendFlags = (byte) 0
    }, Win32.BlendFlags.ULW_ALPHA);
    Win32.SelectObject(compatibleDc, hObject);
    Win32.DeleteObject(hbitmap);
    Win32.DeleteDC(compatibleDc);
    Win32.ReleaseDC(this.Handle, windowDc);
  }

  protected override CreateParams CreateParams
  {
    get
    {
      CreateParams createParams = base.CreateParams;
      createParams.ExStyle |= 524288 /*0x080000*/;
      return createParams;
    }
  }
}
