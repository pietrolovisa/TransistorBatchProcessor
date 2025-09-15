// Decompiled with JetBrains decompiler
// Type: DCAPro.Hid
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace DCAPro;

internal sealed class Hid
{
  internal const short HidP_Input = 0;
  internal const short HidP_Output = 1;
  internal const short HidP_Feature = 2;
  private const string MODULE_NAME = "Hid";
  internal Hid.HIDP_CAPS Capabilities;
  internal Hid.HIDD_ATTRIBUTES DeviceAttributes;

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern void HidD_GetHidGuid(ref Guid HidGuid);

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern bool HidD_FlushQueue(SafeFileHandle HidDeviceObject);

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern bool HidD_FreePreparsedData(IntPtr PreparsedData);

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern bool HidD_GetAttributes(
    SafeFileHandle HidDeviceObject,
    ref Hid.HIDD_ATTRIBUTES Attributes);

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern bool HidD_GetFeature(
    SafeFileHandle HidDeviceObject,
    byte[] lpReportBuffer,
    int ReportBufferLength);

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern bool HidD_GetInputReport(
    SafeFileHandle HidDeviceObject,
    byte[] lpReportBuffer,
    int ReportBufferLength);

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern bool HidD_GetIndexedString(
    SafeFileHandle HidDeviceObject,
    int StringIdex,
    byte[] StringBuffer,
    int StringBufferLength);

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern bool HidD_GetNumInputBuffers(
    SafeFileHandle HidDeviceObject,
    ref int NumberBuffers);

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern bool HidD_GetPreparsedData(
    SafeFileHandle HidDeviceObject,
    ref IntPtr PreparsedData);

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern bool HidD_SetFeature(
    SafeFileHandle HidDeviceObject,
    byte[] lpReportBuffer,
    int ReportBufferLength);

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern bool HidD_SetNumInputBuffers(
    SafeFileHandle HidDeviceObject,
    int NumberBuffers);

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern bool HidD_SetOutputReport(
    SafeFileHandle HidDeviceObject,
    byte[] lpReportBuffer,
    int ReportBufferLength);

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern int HidP_GetCaps(IntPtr PreparsedData, ref Hid.HIDP_CAPS Capabilities);

  [DllImport("hid.dll", SetLastError = true)]
  internal static extern int HidP_GetValueCaps(
    int ReportType,
    byte[] ValueCaps,
    ref int ValueCapsLength,
    IntPtr PreparsedData);

  internal bool FlushQueue(SafeFileHandle hidHandle)
  {
    try
    {
      return Hid.HidD_FlushQueue(hidHandle);
    }
    catch (Exception ex)
    {
      Hid.DisplayException(nameof (Hid), ex);
      throw;
    }
  }

  internal Hid.HIDP_CAPS GetDeviceCapabilities(SafeFileHandle hidHandle)
  {
    IntPtr PreparsedData = new IntPtr();
    int num = 0;
    try
    {
      Hid.HidD_GetPreparsedData(hidHandle, ref PreparsedData);
      if (Hid.HidP_GetCaps(PreparsedData, ref this.Capabilities) != 0)
      {
        int numberInputValueCaps = (int) this.Capabilities.NumberInputValueCaps;
        num = Hid.HidP_GetValueCaps(0, new byte[numberInputValueCaps], ref numberInputValueCaps, PreparsedData);
      }
    }
    catch (Exception ex)
    {
      Hid.DisplayException(nameof (Hid), ex);
      throw;
    }
    finally
    {
      if (PreparsedData != IntPtr.Zero)
        Hid.HidD_FreePreparsedData(PreparsedData);
    }
    return this.Capabilities;
  }

  internal bool GetDeviceStrings(
    SafeFileHandle hidHandle,
    ref string ProductName,
    ref string SerialNum)
  {
    bool indexedString;
    try
    {
      byte[] numArray1 = new byte[256 /*0x0100*/];
      ProductName = !Hid.HidD_GetIndexedString(hidHandle, 2, numArray1, 256 /*0x0100*/) ? "" : Encoding.Unicode.GetString(numArray1).Trim(new char[1]);
      byte[] numArray2 = new byte[256 /*0x0100*/];
      indexedString = Hid.HidD_GetIndexedString(hidHandle, 3, numArray2, 256 /*0x0100*/);
      SerialNum = !indexedString ? "" : Encoding.Unicode.GetString(numArray2).Trim(new char[1]);
    }
    catch (Exception ex)
    {
      Hid.DisplayException(nameof (Hid), ex);
      throw;
    }
    return indexedString;
  }

  internal bool GetFeatureReport(SafeFileHandle hidHandle, ref byte[] inFeatureReportBuffer)
  {
    try
    {
      return Hid.HidD_GetFeature(hidHandle, inFeatureReportBuffer, inFeatureReportBuffer.Length);
    }
    catch (Exception ex)
    {
      Hid.DisplayException(nameof (Hid), ex);
      throw;
    }
  }

  internal bool SendFeatureReport(SafeFileHandle hidHandle, byte[] outFeatureReportBuffer)
  {
    try
    {
      return Hid.HidD_SetFeature(hidHandle, outFeatureReportBuffer, outFeatureReportBuffer.Length);
    }
    catch (Exception ex)
    {
      Hid.DisplayException(nameof (Hid), ex);
      throw;
    }
  }

  internal string GetHidUsage(Hid.HIDP_CAPS MyCapabilities)
  {
    string hidUsage = "";
    try
    {
      int num = (int) MyCapabilities.UsagePage * 256 /*0x0100*/ + (int) MyCapabilities.Usage;
      if (num == Convert.ToInt32(258))
        hidUsage = "mouse";
      if (num == Convert.ToInt32(262))
        hidUsage = "keyboard";
    }
    catch (Exception ex)
    {
      Hid.DisplayException(nameof (Hid), ex);
      throw;
    }
    return hidUsage;
  }

  internal bool GetNumberOfInputBuffers(
    SafeFileHandle hidDeviceObject,
    ref int numberOfInputBuffers)
  {
    try
    {
      bool numberOfInputBuffers1;
      if (!this.IsWindows98Gold())
      {
        numberOfInputBuffers1 = Hid.HidD_GetNumInputBuffers(hidDeviceObject, ref numberOfInputBuffers);
      }
      else
      {
        numberOfInputBuffers = 2;
        numberOfInputBuffers1 = true;
      }
      return numberOfInputBuffers1;
    }
    catch (Exception ex)
    {
      Hid.DisplayException(nameof (Hid), ex);
      throw;
    }
  }

  internal bool SetNumberOfInputBuffers(SafeFileHandle hidDeviceObject, int numberBuffers)
  {
    try
    {
      if (this.IsWindows98Gold())
        return false;
      Hid.HidD_SetNumInputBuffers(hidDeviceObject, numberBuffers);
      return true;
    }
    catch (Exception ex)
    {
      Hid.DisplayException(nameof (Hid), ex);
      throw;
    }
  }

  internal bool IsWindowsXpOrLater()
  {
    try
    {
      return Environment.OSVersion.Version >= new Version(5, 1);
    }
    catch (Exception ex)
    {
      Hid.DisplayException(nameof (Hid), ex);
      throw;
    }
  }

  internal bool IsWindows98Gold()
  {
    try
    {
      return Environment.OSVersion.Version < new Version(4, 10, 2183);
    }
    catch (Exception ex)
    {
      Hid.DisplayException(nameof (Hid), ex);
      throw;
    }
  }

  internal static void DisplayException(string moduleName, Exception e)
  {
    int num = (int) MessageBox.Show($"Exception: {e.Message}{Environment.NewLine}Module: {moduleName}{Environment.NewLine}Method: {e.TargetSite.Name}", "Unexpected Exception", MessageBoxButtons.OK);
  }

  internal struct HIDD_ATTRIBUTES
  {
    internal int Size;
    internal ushort VID;
    internal ushort PID;
    internal ushort VER;
  }

  internal struct HIDP_CAPS
  {
    internal short Usage;
    internal short UsagePage;
    internal short InputReportByteLength;
    internal short OutputReportByteLength;
    internal short FeatureReportByteLength;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 17)]
    internal short[] Reserved;
    internal short NumberLinkCollectionNodes;
    internal short NumberInputButtonCaps;
    internal short NumberInputValueCaps;
    internal short NumberInputDataIndices;
    internal short NumberOutputButtonCaps;
    internal short NumberOutputValueCaps;
    internal short NumberOutputDataIndices;
    internal short NumberFeatureButtonCaps;
    internal short NumberFeatureValueCaps;
    internal short NumberFeatureDataIndices;
  }

  internal abstract class ReportIn
  {
    internal abstract void Read(
      SafeFileHandle hidHandle,
      SafeFileHandle readHandle,
      SafeFileHandle writeHandle,
      ref bool myDeviceDetected,
      ref byte[] readBuffer,
      ref bool success);
  }

  internal class InFeatureReport : Hid.ReportIn
  {
    internal override void Read(
      SafeFileHandle hidHandle,
      SafeFileHandle readHandle,
      SafeFileHandle writeHandle,
      ref bool myDeviceDetected,
      ref byte[] inFeatureReportBuffer,
      ref bool success)
    {
      try
      {
        success = Hid.HidD_GetFeature(hidHandle, inFeatureReportBuffer, inFeatureReportBuffer.Length);
      }
      catch (Exception ex)
      {
        Hid.DisplayException(nameof (Hid), ex);
        throw;
      }
    }
  }

  internal class InputReportViaControlTransfer : Hid.ReportIn
  {
    internal override void Read(
      SafeFileHandle hidHandle,
      SafeFileHandle readHandle,
      SafeFileHandle writeHandle,
      ref bool myDeviceDetected,
      ref byte[] inputReportBuffer,
      ref bool success)
    {
      try
      {
        success = Hid.HidD_GetInputReport(hidHandle, inputReportBuffer, inputReportBuffer.Length + 1);
      }
      catch (Exception ex)
      {
        Hid.DisplayException(nameof (Hid), ex);
        throw;
      }
    }
  }

  internal class InputReportViaInterruptTransfer : Hid.ReportIn
  {
    internal void CancelTransfer(
      SafeFileHandle hidHandle,
      SafeFileHandle readHandle,
      SafeFileHandle writeHandle,
      IntPtr eventObject)
    {
      try
      {
        FileIO.CancelIo(readHandle);
        if (!hidHandle.IsInvalid)
          hidHandle.Close();
        if (!readHandle.IsInvalid)
          readHandle.Close();
        if (writeHandle.IsInvalid)
          return;
        writeHandle.Close();
      }
      catch (Exception ex)
      {
        Hid.DisplayException(nameof (Hid), ex);
        throw;
      }
    }

    internal void PrepareForOverlappedTransfer(
      ref NativeOverlapped hidOverlapped,
      ref IntPtr eventObject)
    {
      try
      {
        eventObject = FileIO.CreateEvent(IntPtr.Zero, false, false, "");
        hidOverlapped.OffsetLow = 0;
        hidOverlapped.OffsetHigh = 0;
        hidOverlapped.EventHandle = eventObject;
      }
      catch (Exception ex)
      {
        Hid.DisplayException(nameof (Hid), ex);
        throw;
      }
    }

    internal override void Read(
      SafeFileHandle hidHandle,
      SafeFileHandle readHandle,
      SafeFileHandle writeHandle,
      ref bool myDeviceDetected,
      ref byte[] inputReportBuffer,
      ref bool success)
    {
      IntPtr zero1 = IntPtr.Zero;
      NativeOverlapped hidOverlapped = new NativeOverlapped();
      IntPtr zero2 = IntPtr.Zero;
      IntPtr zero3 = IntPtr.Zero;
      int length = 0;
      try
      {
        this.PrepareForOverlappedTransfer(ref hidOverlapped, ref zero1);
        IntPtr num1 = Marshal.AllocHGlobal(inputReportBuffer.Length);
        IntPtr num2 = Marshal.AllocHGlobal(Marshal.SizeOf((object) hidOverlapped));
        Marshal.StructureToPtr((object) hidOverlapped, num2, false);
        success = FileIO.ReadFile(readHandle, num1, inputReportBuffer.Length, ref length, num2);
        if (!success)
        {
          switch (FileIO.WaitForSingleObject(zero1, 3000))
          {
            case 0:
              success = true;
              FileIO.GetOverlappedResult(readHandle, num2, ref length, false);
              break;
            case 258:
              this.CancelTransfer(hidHandle, readHandle, writeHandle, zero1);
              success = false;
              myDeviceDetected = false;
              break;
            default:
              this.CancelTransfer(hidHandle, readHandle, writeHandle, zero1);
              success = false;
              myDeviceDetected = false;
              break;
          }
        }
        if (success)
          Marshal.Copy(num1, inputReportBuffer, 0, length);
        Marshal.FreeHGlobal(num1);
        Marshal.FreeHGlobal(num2);
      }
      catch (Exception ex)
      {
        Hid.DisplayException(nameof (Hid), ex);
        throw;
      }
    }
  }

  internal abstract class ReportOut
  {
    internal abstract bool Write(byte[] reportBuffer, SafeFileHandle DeviceHandle);
  }

  internal class OutFeatureReport : Hid.ReportOut
  {
    internal override bool Write(byte[] outFeatureReportBuffer, SafeFileHandle hidHandle)
    {
      try
      {
        return Hid.HidD_SetFeature(hidHandle, outFeatureReportBuffer, outFeatureReportBuffer.Length);
      }
      catch (Exception ex)
      {
        Hid.DisplayException(nameof (Hid), ex);
        throw;
      }
    }
  }

  internal class OutputReportViaControlTransfer : Hid.ReportOut
  {
    internal override bool Write(byte[] outputReportBuffer, SafeFileHandle hidHandle)
    {
      try
      {
        return Hid.HidD_SetOutputReport(hidHandle, outputReportBuffer, outputReportBuffer.Length + 1);
      }
      catch (Exception ex)
      {
        Hid.DisplayException(nameof (Hid), ex);
        throw;
      }
    }
  }

  internal class OutputReportViaInterruptTransfer : Hid.ReportOut
  {
    internal override bool Write(byte[] outputReportBuffer, SafeFileHandle writeHandle)
    {
      try
      {
        int lpNumberOfBytesWritten = 0;
        return FileIO.WriteFile(writeHandle, outputReportBuffer, outputReportBuffer.Length, ref lpNumberOfBytesWritten, IntPtr.Zero);
      }
      catch (Exception ex)
      {
        Hid.DisplayException(nameof (Hid), ex);
        throw;
      }
    }
  }
}
