// Decompiled with JetBrains decompiler
// Type: Win32
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
internal static class Win32
{
  [DllImport("user32.dll")]
  public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

  [DllImport("user32.dll")]
  public static extern bool ReleaseCapture();

  [DllImport("user32.dll")]
  public static extern void SetCapture(IntPtr hWnd);

  [DllImport("user32.dll")]
  public static extern IntPtr GetCapture();

  [DllImport("user32.dll")]
  [return: MarshalAs(UnmanagedType.Bool)]
  public static extern bool SetWindowPos(
    IntPtr hWnd,
    IntPtr hWndInsertAfter,
    int X,
    int Y,
    int cx,
    int cy,
    uint uFlags);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

  [DllImport("user32")]
  public static extern IntPtr SetWindowLong(IntPtr hWnd, int nIndex, long flags);

  [DllImport("user32")]
  public static extern IntPtr SetWindowLong(IntPtr hWnd, uint nIndex, Win32.Win32WndProc newProc);

  [DllImport("user32")]
  public static extern int CallWindowProc(
    IntPtr lpPrevWndFunc,
    IntPtr hWnd,
    int Msg,
    int wParam,
    int lParam);

  [DllImport("user32.dll")]
  public static extern bool LockWindowUpdate(IntPtr hWndLock);

  [DllImport("user32.dll")]
  public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern long GetWindowLong(IntPtr hWnd, uint nIndex);

  [DllImport("user32.dll")]
  public static extern IntPtr BeginDeferWindowPos(int nNumWindows);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern IntPtr DeferWindowPos(
    IntPtr hWinPosInfo,
    IntPtr hWnd,
    IntPtr hWndInsertAfter,
    int x,
    int y,
    int cx,
    int cy,
    uint uFlags);

  [DllImport("user32.dll")]
  public static extern bool EndDeferWindowPos(IntPtr hWinPosInfo);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern IntPtr GetWindow(IntPtr hWnd, Win32.GetWindow_Cmd uCmd);

  [DllImport("user32.dll")]
  public static extern bool EnableWindow(IntPtr hWnd, bool bEnable);

  [DllImport("user32.dll")]
  public static extern IntPtr SetFocus(IntPtr hWnd);

  [DllImport("user32.dll")]
  public static extern IntPtr SetCursor(IntPtr hcur);

  [DllImport("user32.dll")]
  public static extern IntPtr LoadCursor(IntPtr hInstcance, Win32.SystemCursor hcur);

  [DllImport("user32.dll")]
  public static extern IntPtr GetDC(IntPtr hWnd);

  [DllImport("gdi32.dll")]
  public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

  [DllImport("gdi32.dll")]
  public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

  [DllImport("gdi32.dll")]
  public static extern bool DeleteObject(IntPtr hObject);

  [DllImport("gdi32.dll")]
  public static extern bool DeleteDC(IntPtr hdc);

  [DllImport("user32.dll")]
  public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

  [DllImport("user32.dll", CharSet = CharSet.Auto)]
  public static extern int GetWindowTextLength(IntPtr hWnd);

  [DllImport("user32.dll", CharSet = CharSet.Auto)]
  public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

  [DllImport("user32.dll")]
  public static extern bool IsWindowVisible(IntPtr hWnd);

  [DllImport("user32.dll", SetLastError = true)]
  public static extern bool UpdateLayeredWindow(
    IntPtr hwnd,
    IntPtr hdcDst,
    ref Point pptDst,
    ref Size psize,
    IntPtr hdcSrc,
    ref Point pprSrc,
    int crKey,
    ref Win32.BLENDFUNCTION pblend,
    Win32.BlendFlags dwFlags);

  [DllImport("user32.dll")]
  public static extern IntPtr GetWindowDC(IntPtr hWnd);

  [DllImport("gdi32.dll")]
  [return: MarshalAs(UnmanagedType.Bool)]
  public static extern bool BitBlt(
    IntPtr hdc,
    int nXDest,
    int nYDest,
    int nWidth,
    int nHeight,
    IntPtr hdcSrc,
    int nXSrc,
    int nYSrc,
    Win32.TernaryRasterOperations dwRop);

  [DllImport("gdi32.dll")]
  public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

  [DllImport("gdi32.dll")]
  public static extern IntPtr CreateBitmap(
    int nWidth,
    int nHeight,
    uint cPlanes,
    uint cBitsPerPel,
    IntPtr lpvBits);

  [DllImport("gdi32.dll")]
  public static extern uint SetBkColor(IntPtr hdc, uint crColor);

  [DllImport("gdi32.dll")]
  public static extern IntPtr CreateSolidBrush(uint crColor);

  [DllImport("gdi32.dll")]
  public static extern uint GetPixel(IntPtr hdc, int nXPos, int nYPos);

  [DllImport("gdi32.dll")]
  public static extern bool MaskBlt(
    IntPtr hdcDest,
    int nXDest,
    int nYDest,
    int nWidth,
    int nHeight,
    IntPtr hdcSrc,
    int nXSrc,
    int nYSrc,
    IntPtr hbmMask,
    int xMask,
    int yMask,
    uint dwRop);

  public enum Message : uint
  {
    HWND_TOP = 0,
    HTCLIENT = 1,
    HTCAPTION = 2,
    WM_SIZE = 5,
    WM_ACTIVATE = 6,
    WM_SETFOCUS = 7,
    WM_PAINT = 15, // 0x0000000F
    WM_SETCURSOR = 32, // 0x00000020
    WM_WINDOWPOSCHANGING = 70, // 0x00000046
    WM_WINDOWPOSCHANGED = 71, // 0x00000047
    WM_NCHITTEST = 132, // 0x00000084
    WM_NCACTIVATE = 134, // 0x00000086
    WM_NCMOUSEMOVE = 160, // 0x000000A0
    WM_NCLBUTTONDOWN = 161, // 0x000000A1
    WM_NCLBUTTONUP = 162, // 0x000000A2
    WM_NCLBUTTONDBLCLK = 163, // 0x000000A3
    WM_SYSCOMMAND = 274, // 0x00000112
    WM_MOUSEMOVE = 512, // 0x00000200
    WM_LBUTTONDOWN = 513, // 0x00000201
    WM_LBUTTONUP = 514, // 0x00000202
    WM_LBUTTONDBLCLK = 515, // 0x00000203
    WM_RBUTTONDOWN = 516, // 0x00000204
    WM_RBUTTONUP = 517, // 0x00000205
    WM_RBUTTONDBLCLK = 518, // 0x00000206
    WM_MBUTTONDOWN = 519, // 0x00000207
    WM_MBUTTONUP = 520, // 0x00000208
    WM_MBUTTONDBLCLK = 521, // 0x00000209
    WM_MOUSEWHEEL = 522, // 0x0000020A
    WM_XBUTTONDOWN = 523, // 0x0000020B
    WM_XBUTTONUP = 524, // 0x0000020C
    WM_XBUTTONDBLCLK = 525, // 0x0000020D
    WM_ENTERSIZEMOVE = 561, // 0x00000231
    WM_EXITSIZEMOVE = 562, // 0x00000232
    WM_MOUSELEAVE = 675, // 0x000002A3
    SC_MINIMIZE = 61472, // 0x0000F020
    SC_MAXIMIZE = 61488, // 0x0000F030
    SC_RESTORE = 61728, // 0x0000F120
    GWL_EXSTYLE = 4294967276, // 0xFFFFFFEC
    GWL_WNDPROC = 4294967292, // 0xFFFFFFFC
    HTTRANSPARENT = 4294967295, // 0xFFFFFFFF
  }

  public struct WINDOWPOS
  {
    public IntPtr hwnd;
    public IntPtr hwndInsertAfter;
    public int x;
    public int y;
    public int cx;
    public int cy;
    public Win32.WindowPosFlags flags;
  }

  [Flags]
  public enum WindowPosFlags : uint
  {
    NONE = 0,
    SWP_NOSIZE = 1,
    SWP_NOMOVE = 2,
    SWP_NOZORDER = 4,
    SWP_NOREDRAW = 8,
    SWP_NOACTIVATE = 16, // 0x00000010
    SWP_FRAMECHANGED = 32, // 0x00000020
    SWP_SHOWWINDOW = 64, // 0x00000040
    SWP_HIDEWINDOW = 128, // 0x00000080
    SWP_NOCOPYBITS = 256, // 0x00000100
    SWP_NOOWNERZORDER = 512, // 0x00000200
    SWP_NOSENDCHANGING = 1024, // 0x00000400
    SWP_DEFERERASE = 8192, // 0x00002000
    SWP_ASYNCWINDOWPOS = 16384, // 0x00004000
    SWP_CUSTOMFLAG = 32768, // 0x00008000
  }

  public enum WindowStyles
  {
    WS_EX_LAYERED = 524288, // 0x00080000
  }

  public enum GetWindow_Cmd : uint
  {
    GW_HWNDFIRST,
    GW_HWNDLAST,
    GW_HWNDNEXT,
    GW_HWNDPREV,
    GW_OWNER,
    GW_CHILD,
    GW_ENABLEDPOPUP,
  }

  public enum SystemCursor
  {
    IDC_NORMAL = 32512, // 0x00007F00
    IDC_IBEAM = 32513, // 0x00007F01
    IDC_WAIT = 32514, // 0x00007F02
    IDC_CROSS = 32515, // 0x00007F03
    IDC_UP = 32516, // 0x00007F04
    IDC_SIZENWSE = 32642, // 0x00007F82
    IDC_SIZENESW = 32643, // 0x00007F83
    IDC_SIZEWE = 32644, // 0x00007F84
    IDC_SIZENS = 32645, // 0x00007F85
    IDC_SIZEALL = 32646, // 0x00007F86
    IDC_NO = 32648, // 0x00007F88
    IDC_HAND = 32649, // 0x00007F89
    IDC_APPSTARTING = 32650, // 0x00007F8A
    IDC_HELP = 32651, // 0x00007F8B
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct BLENDFUNCTION
  {
    public byte BlendOp;
    public byte BlendFlags;
    public byte SourceConstantAlpha;
    public byte AlphaFormat;
  }

  public enum BlendOps : byte
  {
    AC_SRC_OVER = 0,
    AC_SRC_ALPHA = 1,
    AC_SRC_NO_PREMULT_ALPHA = 1,
    AC_SRC_NO_ALPHA = 2,
    AC_DST_NO_PREMULT_ALPHA = 16, // 0x10
    AC_DST_NO_ALPHA = 32, // 0x20
  }

  public enum BlendFlags : uint
  {
    None = 0,
    ULW_COLORKEY = 1,
    ULW_ALPHA = 2,
    ULW_OPAQUE = 4,
  }

  public enum TernaryRasterOperations : uint
  {
    BLACKNESS = 66, // 0x00000042
    NOTSRCERASE = 1114278, // 0x001100A6
    NOTSRCCOPY = 3342344, // 0x00330008
    SRCERASE = 4457256, // 0x00440328
    DSTINVERT = 5570569, // 0x00550009
    PATINVERT = 5898313, // 0x005A0049
    SRCINVERT = 6684742, // 0x00660046
    SRCAND = 8913094, // 0x008800C6
    MERGEPAINT = 12255782, // 0x00BB0226
    MERGECOPY = 12583114, // 0x00C000CA
    SRCCOPY = 13369376, // 0x00CC0020
    SRCPAINT = 15597702, // 0x00EE0086
    PATCOPY = 15728673, // 0x00F00021
    PATPAINT = 16452105, // 0x00FB0A09
    WHITENESS = 16711778, // 0x00FF0062
  }

  public delegate int Win32WndProc(IntPtr hWnd, int Msg, int wParam, int lParam);
}
