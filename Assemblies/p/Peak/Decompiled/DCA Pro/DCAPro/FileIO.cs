// Decompiled with JetBrains decompiler
// Type: DCAPro.FileIO
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;

#nullable disable
namespace DCAPro;

internal sealed class FileIO
{
  internal const int FILE_ATTRIBUTE_NORMAL = 128 /*0x80*/;
  internal const int FILE_FLAG_OVERLAPPED = 1073741824 /*0x40000000*/;
  internal const int FILE_SHARE_READ = 1;
  internal const int FILE_SHARE_WRITE = 2;
  internal const uint GENERIC_READ = 2147483648 /*0x80000000*/;
  internal const uint GENERIC_WRITE = 1073741824 /*0x40000000*/;
  internal const int INVALID_HANDLE_VALUE = -1;
  internal const int OPEN_EXISTING = 3;
  internal const int WAIT_TIMEOUT = 258;
  internal const int WAIT_OBJECT_0 = 0;

  [DllImport("kernel32.dll", SetLastError = true)]
  internal static extern int CancelIo(SafeFileHandle hFile);

  [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  internal static extern IntPtr CreateEvent(
    IntPtr SecurityAttributes,
    bool bManualReset,
    bool bInitialState,
    string lpName);

  [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  internal static extern SafeFileHandle CreateFile(
    string lpFileName,
    uint dwDesiredAccess,
    int dwShareMode,
    IntPtr lpSecurityAttributes,
    int dwCreationDisposition,
    int dwFlagsAndAttributes,
    int hTemplateFile);

  [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  internal static extern bool GetOverlappedResult(
    SafeFileHandle hFile,
    IntPtr lpOverlapped,
    ref int lpNumberOfBytesTransferred,
    bool bWait);

  [DllImport("kernel32.dll", SetLastError = true)]
  internal static extern bool ReadFile(
    SafeFileHandle hFile,
    IntPtr lpBuffer,
    int nNumberOfBytesToRead,
    ref int lpNumberOfBytesRead,
    IntPtr lpOverlapped);

  [DllImport("kernel32.dll", SetLastError = true)]
  internal static extern int WaitForSingleObject(IntPtr hHandle, int dwMilliseconds);

  [DllImport("kernel32.dll", SetLastError = true)]
  internal static extern bool WriteFile(
    SafeFileHandle hFile,
    byte[] lpBuffer,
    int nNumberOfBytesToWrite,
    ref int lpNumberOfBytesWritten,
    IntPtr lpOverlapped);

  [StructLayout(LayoutKind.Sequential)]
  internal class SECURITY_ATTRIBUTES
  {
    internal int nLength;
    internal int lpSecurityDescriptor;
    internal int bInheritHandle;
  }
}
