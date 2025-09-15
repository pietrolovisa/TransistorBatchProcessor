// Decompiled with JetBrains decompiler
// Type: AlphaForms.AlphaForm
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace AlphaForms;

public class AlphaForm : Form
{
  private Bitmap m_background;
  private Bitmap m_backgroundEx;
  private Bitmap m_backgroundFull;
  private bool m_useBackgroundEx;
  private LayeredWindow m_layeredWnd;
  private int m_offX;
  private int m_offY;
  private bool m_renderCtrlBG;
  private bool m_enhanced;
  private AlphaForm.SizeModes m_sizeMode;
  private List<Control> m_hiddenControls;
  private Dictionary<Control, bool> m_controlDict;
  private bool m_moving;
  private bool m_initialised;
  private Win32.Win32WndProc m_customLayeredWindowProc;
  private IntPtr m_layeredWindowProc;
  private Point m_lockedPoint = new Point();
  private DateTime m_clickTime = DateTime.Now;
  private Win32.Message m_lastClickMsg;
  private AlphaForm.HeldButtons m_isDown;

  private bool dblClick(Point pos)
  {
    TimeSpan timeSpan = DateTime.Now - this.m_clickTime;
    Size size = new Size();
    size.Width = Math.Abs(this.m_lockedPoint.X - pos.X);
    size.Height = Math.Abs(this.m_lockedPoint.Y - pos.Y);
    return timeSpan.Milliseconds <= SystemInformation.DoubleClickTime && size.Width <= SystemInformation.DoubleClickSize.Width && size.Height <= SystemInformation.DoubleClickSize.Height;
  }

  protected override void WndProc(ref System.Windows.Forms.Message m)
  {
    if (this.DesignMode)
    {
      base.WndProc(ref m);
    }
    else
    {
      Win32.Message msg = (Win32.Message) m.Msg;
      bool flag = true;
      switch (msg)
      {
        case Win32.Message.WM_SIZE:
          this.updateLayeredSize(m.LParam.ToInt32() & (int) ushort.MaxValue, m.LParam.ToInt32() >> 16 /*0x10*/);
          break;
        case Win32.Message.WM_ACTIVATE:
          if (m.WParam != IntPtr.Zero)
          {
            IntPtr window = Win32.GetWindow(this.m_layeredWnd.Handle, Win32.GetWindow_Cmd.GW_HWNDPREV);
            while (window != IntPtr.Zero && !Win32.IsWindowVisible(window))
              window = Win32.GetWindow(window, Win32.GetWindow_Cmd.GW_HWNDPREV);
            if (window != this.Handle)
            {
              Win32.SetWindowPos(this.m_layeredWnd.Handle, this.Handle, 0, 0, 0, 0, 1043U);
              break;
            }
            break;
          }
          break;
        case Win32.Message.WM_WINDOWPOSCHANGING:
          Win32.WINDOWPOS structure = (Win32.WINDOWPOS) Marshal.PtrToStructure(m.LParam, typeof (Win32.WINDOWPOS));
          Win32.WindowPosFlags windowPosFlags = Win32.WindowPosFlags.SWP_NOSIZE | Win32.WindowPosFlags.SWP_NOMOVE;
          if ((structure.flags & windowPosFlags) != windowPosFlags)
          {
            if (structure.hwndInsertAfter != this.Handle)
            {
              IntPtr hWinPosInfo = Win32.BeginDeferWindowPos(2);
              if (hWinPosInfo != IntPtr.Zero)
                hWinPosInfo = Win32.DeferWindowPos(hWinPosInfo, this.m_layeredWnd.Handle, this.Handle, structure.x + this.m_offX, structure.y + this.m_offY, 0, 0, (uint) (structure.flags | Win32.WindowPosFlags.SWP_NOSIZE | Win32.WindowPosFlags.SWP_NOZORDER));
              if (hWinPosInfo != IntPtr.Zero)
                hWinPosInfo = Win32.DeferWindowPos(hWinPosInfo, this.Handle, this.Handle, structure.x, structure.y, structure.cx, structure.cy, (uint) (structure.flags | Win32.WindowPosFlags.SWP_NOZORDER));
              if (hWinPosInfo != IntPtr.Zero)
                Win32.EndDeferWindowPos(hWinPosInfo);
              this.m_layeredWnd.LayeredPos = new Point(structure.x + this.m_offX, structure.y + this.m_offY);
              structure.flags |= Win32.WindowPosFlags.SWP_NOMOVE;
              Marshal.StructureToPtr((object) structure, m.LParam, true);
            }
            if ((structure.flags & Win32.WindowPosFlags.SWP_NOSIZE) == Win32.WindowPosFlags.NONE)
            {
              int num1 = structure.cx - this.Size.Width;
              int num2 = structure.cy - this.Size.Height;
              if (num1 != 0 || num2 != 0)
                this.updateLayeredSize(this.ClientSize.Width + num1, this.ClientSize.Height + num2);
            }
            flag = false;
            break;
          }
          break;
      }
      if (!flag)
        return;
      base.WndProc(ref m);
    }
  }

  private int LayeredWindowWndProc(IntPtr hWnd, int Msg, int wParam, int lParam)
  {
    this.PointToClient(Cursor.Position);
    switch ((Win32.Message) Msg)
    {
      case Win32.Message.WM_SETCURSOR:
        Win32.SetCursor(Win32.LoadCursor(IntPtr.Zero, Win32.SystemCursor.IDC_NORMAL));
        MouseEventArgs mouseEventArgs = (MouseEventArgs) null;
        AlphaForm.delMouseEvent method1 = (AlphaForm.delMouseEvent) null;
        AlphaForm.delStdEvent method2 = (AlphaForm.delStdEvent) null;
        if (mouseEventArgs != null)
        {
          if (method1 != null)
            this.BeginInvoke((Delegate) method1, (object) mouseEventArgs);
          if (method2 != null)
            this.BeginInvoke((Delegate) method2, (object) mouseEventArgs);
        }
        return 0;
      case Win32.Message.WM_LBUTTONDOWN:
        Debugger.Break();
        break;
    }
    return Win32.CallWindowProc(this.m_layeredWindowProc, hWnd, Msg, wParam, lParam);
  }

  public AlphaForm()
  {
    if (!this.DesignMode)
      this.m_layeredWnd = new LayeredWindow();
    this.m_sizeMode = AlphaForm.SizeModes.None;
    this.m_background = (Bitmap) null;
    this.m_backgroundEx = (Bitmap) null;
    this.m_backgroundFull = (Bitmap) null;
    this.m_renderCtrlBG = false;
    this.m_enhanced = false;
    this.m_isDown.Left = false;
    this.m_isDown.Right = false;
    this.m_isDown.Middle = false;
    this.m_isDown.XBtn = false;
    this.m_moving = false;
    this.m_hiddenControls = new List<Control>();
    this.m_controlDict = new Dictionary<Control, bool>();
    this.m_initialised = false;
    this.SetStyle(ControlStyles.DoubleBuffer, true);
  }

  [Category("AlphaForm")]
  public Bitmap BlendedBackground
  {
    get => this.m_background;
    set
    {
      if (this.m_background == value)
        return;
      this.m_background = value;
      this.UpdateLayeredBackground();
    }
  }

  [Category("AlphaForm")]
  public bool DrawControlBackgrounds
  {
    get => this.m_renderCtrlBG;
    set
    {
      if (this.m_renderCtrlBG == value)
        return;
      this.m_renderCtrlBG = value;
      this.UpdateLayeredBackground();
    }
  }

  [Category("AlphaForm")]
  public bool EnhancedRendering
  {
    get => this.m_enhanced;
    set => this.m_enhanced = value;
  }

  [Category("AlphaForm")]
  public AlphaForm.SizeModes SizeMode
  {
    get => this.m_sizeMode;
    set
    {
      this.m_sizeMode = value;
      this.UpdateLayeredBackground();
    }
  }

  public void SetOpacity(double Opacity)
  {
    this.Opacity = Opacity;
    if (this.m_background == null)
      return;
    int width = this.ClientSize.Width;
    int height = this.ClientSize.Height;
    if (this.m_sizeMode == AlphaForm.SizeModes.None)
    {
      width = this.m_background.Width;
      height = this.m_background.Height;
    }
    byte opacity = (byte) (this.Opacity * (double) byte.MaxValue);
    if (this.m_useBackgroundEx)
      this.m_layeredWnd.UpdateWindow(this.m_backgroundEx, opacity, width, height, this.m_layeredWnd.LayeredPos);
    else
      this.m_layeredWnd.UpdateWindow(this.m_background, opacity, width, height, this.m_layeredWnd.LayeredPos);
  }

  public void UpdateLayeredBackground()
  {
    this.updateLayeredBackground(this.ClientSize.Width, this.ClientSize.Height);
  }

  public void DrawControlBackground(Control ctrl, bool drawBack)
  {
    if (!this.m_controlDict.ContainsKey(ctrl))
      return;
    this.m_controlDict[ctrl] = drawBack;
  }

  protected override void OnLoad(EventArgs e)
  {
    base.OnLoad(e);
    this.BackColor = Color.Fuchsia;
    this.TransparencyKey = Color.Fuchsia;
    this.AllowTransparency = true;
    Point screen = this.PointToScreen(new Point(0, 0));
    this.m_offX = screen.X - this.Location.X;
    this.m_offY = screen.Y - this.Location.Y;
    if (this.DesignMode)
      return;
    Point location = this.Location;
    location.X += this.m_offX;
    location.Y += this.m_offY;
    this.m_layeredWnd.Text = nameof (AlphaForm);
    this.m_initialised = true;
    this.updateLayeredBackground(this.ClientSize.Width, this.ClientSize.Height, location, true);
    this.m_layeredWnd.Show();
    this.m_layeredWnd.Enabled = false;
    this.m_customLayeredWindowProc = new Win32.Win32WndProc(this.LayeredWindowWndProc);
    this.m_layeredWindowProc = Win32.SetWindowLong(this.m_layeredWnd.Handle, 4294967292U, this.m_customLayeredWindowProc);
  }

  protected override void OnPaintBackground(PaintEventArgs e)
  {
    base.OnPaintBackground(e);
    if (this.m_background == null)
      return;
    if (this.DesignMode)
    {
      e.Graphics.DrawImage((Image) this.m_background, 0, 0, this.m_background.Width, this.m_background.Height);
    }
    else
    {
      if (this.m_moving || !this.m_renderCtrlBG)
        return;
      foreach (KeyValuePair<Control, bool> keyValuePair in this.m_controlDict)
      {
        Control key = keyValuePair.Key;
        if (keyValuePair.Value && key.BackColor == Color.Transparent)
        {
          Rectangle clientRectangle = key.ClientRectangle with
          {
            X = key.Left,
            Y = key.Top
          };
          if (this.m_useBackgroundEx)
            e.Graphics.DrawImage((Image) this.m_backgroundFull, clientRectangle, clientRectangle, GraphicsUnit.Pixel);
          else
            e.Graphics.DrawImage((Image) this.m_background, clientRectangle, clientRectangle, GraphicsUnit.Pixel);
        }
      }
    }
  }

  protected override void OnControlAdded(ControlEventArgs e)
  {
    base.OnControlAdded(e);
    if (this.m_controlDict.ContainsKey(e.Control))
      return;
    this.m_controlDict.Add(e.Control, true);
  }

  protected override void OnControlRemoved(ControlEventArgs e)
  {
    base.OnControlRemoved(e);
    if (!this.m_controlDict.ContainsKey(e.Control))
      return;
    this.m_controlDict.Remove(e.Control);
  }

  private void updateLayeredBackground(int width, int height, Point pos)
  {
    this.updateLayeredBackground(width, height, pos, true);
  }

  private void updateLayeredBackground(int width, int height)
  {
    this.updateLayeredBackground(width, height, this.m_layeredWnd.LayeredPos, true);
  }

  private void updateLayeredBackground(int width, int height, Point pos, bool Render)
  {
    this.m_useBackgroundEx = false;
    if (this.DesignMode || this.m_background == null || !this.m_initialised)
      return;
    switch (this.m_sizeMode)
    {
      case AlphaForm.SizeModes.None:
        width = this.m_background.Width;
        height = this.m_background.Height;
        break;
      case AlphaForm.SizeModes.Stretch:
        this.m_useBackgroundEx = true;
        break;
    }
    if ((this.m_renderCtrlBG || this.m_useBackgroundEx) && Render)
    {
      if (this.m_backgroundEx != null)
      {
        this.m_backgroundEx.Dispose();
        this.m_backgroundEx = (Bitmap) null;
      }
      if (this.m_backgroundFull != null)
      {
        this.m_backgroundFull.Dispose();
        this.m_backgroundFull = (Bitmap) null;
      }
      this.m_backgroundEx = this.m_sizeMode != AlphaForm.SizeModes.Clip ? new Bitmap((Image) this.m_background, width, height) : new Bitmap((Image) this.m_background);
      this.m_backgroundFull = new Bitmap((Image) this.m_backgroundEx);
    }
    if (this.m_renderCtrlBG)
    {
      if (Render)
      {
        Graphics graphics = Graphics.FromImage((Image) this.m_backgroundEx);
        foreach (KeyValuePair<Control, bool> keyValuePair in this.m_controlDict)
        {
          Control key = keyValuePair.Key;
          if (keyValuePair.Value && key.BackColor == Color.Transparent)
          {
            Rectangle clientRectangle = key.ClientRectangle with
            {
              X = key.Left,
              Y = key.Top
            };
            graphics.FillRectangle(Brushes.Fuchsia, clientRectangle);
          }
        }
        graphics.Dispose();
        this.m_backgroundEx.MakeTransparent(Color.Fuchsia);
      }
      this.m_useBackgroundEx = true;
    }
    byte opacity = (byte) (this.Opacity * (double) byte.MaxValue);
    if (this.m_useBackgroundEx)
      this.m_layeredWnd.UpdateWindow(this.m_backgroundEx, opacity, width, height, pos);
    else
      this.m_layeredWnd.UpdateWindow(this.m_background, opacity, width, height, pos);
  }

  private void updateLayeredSize(int width, int height)
  {
    this.updateLayeredSize(width, height, false);
  }

  private void updateLayeredSize(int width, int height, bool forceUpdate)
  {
    if (!this.m_initialised || !forceUpdate && width == this.m_layeredWnd.LayeredSize.Width && height == this.m_layeredWnd.LayeredSize.Height)
      return;
    switch (this.m_sizeMode)
    {
      case AlphaForm.SizeModes.Stretch:
        this.updateLayeredBackground(width, height);
        this.Invalidate(false);
        break;
      case AlphaForm.SizeModes.Clip:
        byte opacity = (byte) (this.Opacity * (double) byte.MaxValue);
        if (this.m_useBackgroundEx)
        {
          this.m_layeredWnd.UpdateWindow(this.m_backgroundEx, opacity, width, height, this.m_layeredWnd.LayeredPos);
          break;
        }
        this.m_layeredWnd.UpdateWindow(this.m_background, opacity, width, height, this.m_layeredWnd.LayeredPos);
        break;
    }
  }

  public enum SizeModes
  {
    None,
    Stretch,
    Clip,
  }

  private delegate void delMouseEvent(MouseEventArgs e);

  private delegate void delStdEvent(EventArgs e);

  private struct HeldButtons
  {
    public bool Left;
    public bool Middle;
    public bool Right;
    public bool XBtn;
  }
}
