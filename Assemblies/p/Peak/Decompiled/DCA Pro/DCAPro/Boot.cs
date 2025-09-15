// Decompiled with JetBrains decompiler
// Type: DCAPro.Boot
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

#nullable disable
namespace DCAPro;

internal class Boot
{
  private const int myVendorID = 1240;
  private const int myProductID = 60;
  private const byte PacketSize = 58;
  private const byte QUERY_DEVICE = 81;
  private const byte ERASE_DEVICE = 82;
  private const byte PROGRAM_DEVICE = 83;
  private const byte PROGRAM_COMPLETE = 84;
  private const byte RESET_DEVICE = 85;
  private const byte GET_ENCRYPTED_FF = 255 /*0xFF*/;
  private const byte HEX_FILE_EXTENDED_LINEAR_ADDRESS = 4;
  private const byte HEX_FILE_EOF = 1;
  private const byte HEX_FILE_DATA = 0;
  private byte progressStatus;
  private byte[] Buffer;
  private Boot.MEMORY_REGION memoryRegion;
  internal Hid MyHid = new Hid();
  internal string DevicePathName = "";
  internal string ProductName = "";
  internal string SerialNum = "";
  private SafeFileHandle ReadHandleToMyDevice = new SafeFileHandle(IntPtr.Zero, true);
  private SafeFileHandle WriteHandleToMyDevice = new SafeFileHandle(IntPtr.Zero, true);
  internal SafeFileHandle DeviceHandle = new SafeFileHandle(IntPtr.Zero, true);
  internal DeviceManagement myDeviceMan = new DeviceManagement();
  private bool Success;
  private DCAProUnit thisDCAPro;

  public Boot(DCAProUnit Parent)
  {
    this.thisDCAPro = Parent;
    this.Initialize();
  }

  ~Boot()
  {
    try
    {
      if (!this.DeviceHandle.IsClosed && !this.DeviceHandle.IsInvalid)
        this.DeviceHandle.Close();
      if (!this.ReadHandleToMyDevice.IsClosed && !this.ReadHandleToMyDevice.IsInvalid)
        this.ReadHandleToMyDevice.Close();
      if (this.WriteHandleToMyDevice.IsClosed || this.WriteHandleToMyDevice.IsInvalid)
        return;
      this.WriteHandleToMyDevice.Close();
    }
    catch (Exception ex)
    {
      throw;
    }
    finally
    {
      // ISSUE: explicit finalizer call
      base.Finalize();
    }
  }

  private void Initialize()
  {
    try
    {
      this.progressStatus = (byte) 0;
      this.memoryRegion = new Boot.MEMORY_REGION();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal unsafe Boot.RESULT ProgramStart(BackgroundWorker worker, WorkResult OldInfo)
  {
    try
    {
      bool flag1 = false;
      Boot.BOOTLOADER_COMMAND bootloaderCommand1 = new Boot.BOOTLOADER_COMMAND();
      bool myDeviceDetected = false;
      bool flag2 = false;
      Hid.OutputReportViaInterruptTransfer interruptTransfer1 = new Hid.OutputReportViaInterruptTransfer();
      Hid.InputReportViaInterruptTransfer interruptTransfer2 = new Hid.InputReportViaInterruptTransfer();
      WorkResult workResult1 = new WorkResult();
      WorkResult workResult2 = OldInfo.Clone();
      this.progressStatus = (byte) 0;
      workResult2.Progress = 0;
      workResult2.DoType = ACT.BOOT_PROGRAM;
      worker.ReportProgress((int) this.progressStatus, (object) workResult2.Clone());
      if (this.thisDCAPro.ConnectedState != DCAProUnit.STATE.BOOTCONNECTED && this.thisDCAPro.ConnectedState != DCAProUnit.STATE.UNCONNECTED)
      {
        int num1 = 30000;
        int num2 = num1;
        while (this.thisDCAPro.ConnectedState != DCAProUnit.STATE.BOOTCONNECTED && num2 > 0)
        {
          int num3 = (int) this.thisDCAPro.BootLoad();
          Thread.Sleep(100);
          num2 -= 100;
          workResult2.DoType = ACT.BOOT_PROGRAM;
          workResult2.Progress = 100 * (num1 - num2) / num1;
          worker.ReportProgress((int) this.progressStatus, (object) workResult2.Clone());
          if (worker.CancellationPending)
          {
            flag1 = true;
            break;
          }
        }
        if (flag1)
          return Boot.RESULT.FAILED;
      }
      if (this.thisDCAPro.ConnectedState != DCAProUnit.STATE.BOOTCONNECTED)
        return Boot.RESULT.FAILED;
      bootloaderCommand1.EraseDevice.WindowsReserved = (byte) 0;
      bootloaderCommand1.EraseDevice.Command = (byte) 82;
      this.Buffer = Boot.ObjectToByteArray(bootloaderCommand1);
      this.Success = interruptTransfer1.Write(this.Buffer, this.WriteHandleToMyDevice);
      if (!this.Success)
        return Boot.RESULT.FAILED_WRITEFILE;
      for (int index = 100; index > 1; --index)
      {
        workResult2.Progress = index;
        workResult2.DoType = ACT.BOOT_PROGRAM_ERASE;
        worker.ReportProgress((int) this.progressStatus, (object) workResult2.Clone());
        Thread.Sleep(20);
      }
      workResult2.Progress = 1;
      workResult2.DoType = ACT.BOOT_PROGRAM;
      worker.ReportProgress((int) this.progressStatus, (object) workResult2.Clone());
      bootloaderCommand1.QueryDevice.WindowsReserved = (byte) 0;
      bootloaderCommand1.QueryDevice.Command = (byte) 81;
      this.Buffer = Boot.ObjectToByteArray(bootloaderCommand1);
      for (int index = 50; index > 0; --index)
      {
        worker.ReportProgress((int) this.progressStatus, (object) workResult2.Clone());
        this.Success = interruptTransfer1.Write(this.Buffer, this.WriteHandleToMyDevice);
        if (!this.Success)
          Thread.Sleep(200);
        else
          break;
      }
      if (!this.Success)
        return Boot.RESULT.FAILED_WRITEFILE;
      this.Buffer = Boot.ObjectToByteArray(bootloaderCommand1);
      interruptTransfer2.Read(this.DeviceHandle, this.ReadHandleToMyDevice, this.WriteHandleToMyDevice, ref myDeviceDetected, ref this.Buffer, ref this.Success);
      if (!this.Success)
      {
        if (!myDeviceDetected)
          this.thisDCAPro.ConnectedState = DCAProUnit.STATE.UNCONNECTED;
        return Boot.RESULT.FAILED_READFILE;
      }
      Boot.BOOTLOADER_COMMAND bootloaderCommand2 = Boot.ByteArrayToObject(this.Buffer);
      for (; !flag2; flag2 = true)
      {
        uint address = this.memoryRegion.Address;
        uint index1 = 0;
        while (address < this.memoryRegion.Address + this.memoryRegion.Size)
        {
          bootloaderCommand2.ProgramDevice.WindowsReserved = (byte) 0;
          bootloaderCommand2.ProgramDevice.Command = (byte) 83;
          bootloaderCommand2.ProgramDevice.Address = address;
          workResult2.Progress = (int) ((uint) (100 * ((int) address - (int) this.memoryRegion.Address)) / this.memoryRegion.Size);
          workResult2.DoType = ACT.BOOT_PROGRAM_PROG;
          worker.ReportProgress((int) this.progressStatus, (object) workResult2.Clone());
          byte index2;
          for (index2 = (byte) 0; index2 < (byte) 58; ++index2)
          {
            byte num = this.memoryRegion.Data[(IntPtr) index1];
            bootloaderCommand2.ProgramDevice.Data[(int) index2] = num;
            ++index1;
            ++address;
            if (address >= this.memoryRegion.Address + this.memoryRegion.Size)
            {
              ++index2;
              for (byte index3 = 0; index3 < (byte) 58; ++index3)
                bootloaderCommand2.ProgramDevice.Data[58 - (int) index3 - 1] = (int) index3 >= (int) index2 ? (byte) 0 : bootloaderCommand2.ProgramDevice.Data[(int) index2 - (int) index3 - 1];
              break;
            }
          }
          bootloaderCommand2.ProgramDevice.BytesPerPacket = index2;
          this.Buffer = Boot.ObjectToByteArray(bootloaderCommand2);
          this.Success = interruptTransfer1.Write(this.Buffer, this.WriteHandleToMyDevice);
          if (!this.Success)
            return Boot.RESULT.FAILED_WRITEFILE;
        }
        workResult2.Progress = 100;
        workResult2.DoType = ACT.BOOT_PROGRAM_PROG;
        worker.ReportProgress((int) this.progressStatus, (object) workResult2.Clone());
        bootloaderCommand2.ProgramComplete.WindowsReserved = (byte) 0;
        bootloaderCommand2.ProgramComplete.Command = (byte) 84;
        this.Buffer = Boot.ObjectToByteArray(bootloaderCommand2);
        this.Success = interruptTransfer1.Write(this.Buffer, this.WriteHandleToMyDevice);
        if (!this.Success)
          return Boot.RESULT.FAILED_WRITEFILE;
        bootloaderCommand2.ResetDevice.WindowsReserved = (byte) 0;
        bootloaderCommand2.ResetDevice.Command = (byte) 85;
        this.Buffer = Boot.ObjectToByteArray(bootloaderCommand2);
        this.Success = interruptTransfer1.Write(this.Buffer, this.WriteHandleToMyDevice);
        if (!this.Success)
          return Boot.RESULT.FAILED_WRITEFILE;
      }
      return Boot.RESULT.SUCCESS;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal Boot.RESULT ResetStart(BackgroundWorker worker, WorkResult Info)
  {
    try
    {
      Boot.BOOTLOADER_COMMAND bootloaderCommand = new Boot.BOOTLOADER_COMMAND();
      Hid.OutputReportViaInterruptTransfer interruptTransfer = new Hid.OutputReportViaInterruptTransfer();
      if (this.WriteHandleToMyDevice.IsInvalid)
        return Boot.RESULT.FAILED;
      bootloaderCommand.ResetDevice.WindowsReserved = (byte) 0;
      bootloaderCommand.ResetDevice.Command = (byte) 85;
      Info.Progress = 100;
      Info.DoType = ACT.BOOT_RESET;
      worker.ReportProgress(100, (object) Info);
      this.Buffer = Boot.ObjectToByteArray(bootloaderCommand);
      this.Success = interruptTransfer.Write(this.Buffer, this.WriteHandleToMyDevice);
      return this.Success ? Boot.RESULT.SUCCESS : Boot.RESULT.FAILED_WRITEFILE;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal bool FindTheDevice(int Retries, int Timeout)
  {
    string[] devicePathName = new string[128 /*0x80*/];
    Guid empty = Guid.Empty;
    bool flag1 = false;
    try
    {
      while (this.thisDCAPro.ConnectedState != DCAProUnit.STATE.BOOTCONNECTED && Retries-- > 0)
      {
        Hid.HidD_GetHidGuid(ref empty);
        if (this.myDeviceMan.FindDeviceFromGuid(empty, ref devicePathName))
        {
          int index = 0;
          do
          {
            if (devicePathName[index] != null)
            {
              if (!this.DeviceHandle.IsClosed)
                this.DeviceHandle.Close();
              this.DeviceHandle = FileIO.CreateFile(devicePathName[index], 0U, 3, IntPtr.Zero, 3, 0, 0);
              if (!this.DeviceHandle.IsInvalid)
              {
                this.MyHid.DeviceAttributes.Size = Marshal.SizeOf((object) this.MyHid.DeviceAttributes);
                if (Hid.HidD_GetAttributes(this.DeviceHandle, ref this.MyHid.DeviceAttributes))
                {
                  if (this.MyHid.DeviceAttributes.VID == (ushort) 1240 && this.MyHid.DeviceAttributes.PID == (ushort) 60)
                  {
                    this.DevicePathName = devicePathName[index];
                    flag1 = this.MyHid.GetDeviceStrings(this.DeviceHandle, ref this.ProductName, ref this.SerialNum);
                    this.thisDCAPro.ConnectedState = DCAProUnit.STATE.BOOTCONNECTED;
                  }
                  else
                  {
                    this.thisDCAPro.ConnectedState = DCAProUnit.STATE.UNCONNECTED;
                    this.DeviceHandle.Close();
                  }
                }
                else
                {
                  this.thisDCAPro.ConnectedState = DCAProUnit.STATE.UNCONNECTED;
                  this.DeviceHandle.Close();
                }
              }
              else
              {
                this.thisDCAPro.ConnectedState = DCAProUnit.STATE.UNCONNECTED;
                this.DeviceHandle.Close();
              }
            }
            ++index;
          }
          while (this.thisDCAPro.ConnectedState != DCAProUnit.STATE.BOOTCONNECTED && index != devicePathName.Length);
        }
      }
      if (this.thisDCAPro.ConnectedState == DCAProUnit.STATE.BOOTCONNECTED)
      {
        if (this.myDeviceMan.deviceNotificationHandle != IntPtr.Zero)
        {
          this.myDeviceMan.StopReceivingDeviceNotifications(this.myDeviceMan.deviceNotificationHandle);
          this.myDeviceMan.deviceNotificationHandle = IntPtr.Zero;
        }
        bool flag2 = this.myDeviceMan.RegisterForDeviceNotifications(this.thisDCAPro.ParentHandle, empty, this.DeviceHandle, ref this.myDeviceMan.deviceNotificationHandle);
        this.MyHid.Capabilities = this.MyHid.GetDeviceCapabilities(this.DeviceHandle);
        if (flag2)
        {
          if (!this.ReadHandleToMyDevice.IsClosed)
            this.ReadHandleToMyDevice.Close();
          this.ReadHandleToMyDevice = FileIO.CreateFile(this.DevicePathName, 2147483648U /*0x80000000*/, 3, IntPtr.Zero, 3, 0, 0);
          if (this.ReadHandleToMyDevice.IsInvalid)
          {
            this.thisDCAPro.ConnectedState = DCAProUnit.STATE.UNCONNECTED;
            this.DeviceHandle.Close();
          }
          else
          {
            if (!this.WriteHandleToMyDevice.IsClosed)
              this.WriteHandleToMyDevice.Close();
            this.WriteHandleToMyDevice = FileIO.CreateFile(this.DevicePathName, 1073741824U /*0x40000000*/, 3, IntPtr.Zero, 3, 0, 0);
            this.MyHid.FlushQueue(this.ReadHandleToMyDevice);
          }
        }
        else
          this.thisDCAPro.ConnectedState = DCAProUnit.STATE.UNCONNECTED;
      }
      else
        this.thisDCAPro.ConnectedState = DCAProUnit.STATE.UNCONNECTED;
      return this.thisDCAPro.ConnectedState == DCAProUnit.STATE.BOOTCONNECTED;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void LoadHEXFile(string Filename)
  {
    try
    {
      using (StreamReader streamReader = new StreamReader(Filename))
      {
        this.memoryRegion = new Boot.MEMORY_REGION();
        bool flag = false;
        ulong num1 = 0;
        ulong num2 = 0;
        while (streamReader.Peek() >= 0)
        {
          string str1 = streamReader.ReadLine().Trim();
          if (str1.Length > 0)
          {
            if (str1[0] != ':')
              flag = true;
            else
              str1 = str1.Substring(1, str1.Length - 1);
            ulong num3 = (ulong) Convert.ToByte(str1.Substring(0, 2), 16 /*0x10*/);
            ulong uint16 = (ulong) Convert.ToUInt16(str1.Substring(2, 4), 16 /*0x10*/);
            ulong num4 = (ulong) Convert.ToByte(str1.Substring(6, 2), 16 /*0x10*/);
            string str2 = str1.Substring(8, (int) ((long) num3 * 2L));
            ulong num5 = (ulong) Convert.ToByte(str1.Substring((int) ((long) num3 * 2L + 8L), 2), 16 /*0x10*/);
            uint num6 = 0;
            for (byte index = 0; (ulong) index < num3 + 4UL; ++index)
              num6 += (uint) Convert.ToByte(str1.Substring((int) index * 2, 2), 16 /*0x10*/);
            if ((long) ((uint) (~(int) num6 + 1) & (uint) byte.MaxValue) != (long) num5)
              flag = true;
            if (!flag)
            {
              switch (num4)
              {
                case 0:
                  ulong num7 = (num1 << 16 /*0x10*/) + uint16;
                  ulong num8 = 0;
                  ulong num9 = num8 + (ulong) this.memoryRegion.Size;
                  if (num7 >= (ulong) this.memoryRegion.Address && num7 < (ulong) (this.memoryRegion.Address + this.memoryRegion.Size))
                  {
                    for (byte index1 = 0; (ulong) index1 < num3; ++index1)
                    {
                      ulong num10 = num7 - (ulong) this.memoryRegion.Address + (ulong) index1;
                      byte num11 = Convert.ToByte(str2.Substring((int) index1 * 2, 2), 16 /*0x10*/);
                      ulong index2 = num8 + (num7 - (ulong) this.memoryRegion.Address) + (ulong) index1;
                      if (index2 > num2)
                        num2 = index2;
                      if (index2 < num9)
                        this.memoryRegion.Data[index2] = num11;
                      else
                        break;
                    }
                    continue;
                  }
                  continue;
                case 4:
                  num1 = (ulong) Convert.ToUInt32(str2, 16 /*0x10*/);
                  continue;
                default:
                  continue;
              }
            }
          }
        }
        this.memoryRegion.Resize(this.memoryRegion.Address, (uint) num2 + 1U);
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public static byte[] ObjectToByteArray(Boot.BOOTLOADER_COMMAND Obj)
  {
    try
    {
      int length = Marshal.SizeOf((object) Obj);
      byte[] destination = new byte[length];
      IntPtr num = Marshal.AllocHGlobal(length);
      Marshal.StructureToPtr((object) Obj, num, false);
      Marshal.Copy(num, destination, 0, length);
      Marshal.FreeHGlobal(num);
      return destination;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public static Boot.BOOTLOADER_COMMAND ByteArrayToObject(byte[] Arry)
  {
    try
    {
      Boot.BOOTLOADER_COMMAND structure1 = new Boot.BOOTLOADER_COMMAND();
      int num1 = Marshal.SizeOf((object) structure1);
      IntPtr num2 = Marshal.AllocHGlobal(num1);
      Marshal.Copy(Arry, 0, num2, num1);
      Boot.BOOTLOADER_COMMAND structure2 = (Boot.BOOTLOADER_COMMAND) Marshal.PtrToStructure(num2, structure1.GetType());
      Marshal.FreeHGlobal(num2);
      return structure2;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal enum RESULT : byte
  {
    SUCCESS = 1,
    FAILED = 2,
    FAILED_READFILE = 3,
    FAILED_WRITEFILE = 4,
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct stQueryDevice
  {
    internal byte WindowsReserved;
    internal byte Command;
    internal byte PacketDataFieldSize;
    internal byte BytesPerAddress;
    internal byte Type1;
    internal uint Address1;
    internal uint Length1;
    internal byte Type2;
    internal uint Address2;
    internal uint Length2;
    internal byte EndOfTypes;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct stEraseDevice
  {
    internal byte WindowsReserved;
    internal byte Command;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct stProgramDevice
  {
    internal byte WindowsReserved;
    internal byte Command;
    internal uint Address;
    internal byte BytesPerPacket;
    internal unsafe fixed byte Data[58];
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct stProgramComplete
  {
    internal byte WindowsReserved;
    internal byte Command;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct stResetDevice
  {
    internal byte WindowsReserved;
    internal byte Command;
  }

  [StructLayout(LayoutKind.Explicit, Size = 65, Pack = 1)]
  public struct BOOTLOADER_COMMAND
  {
    [FieldOffset(0)]
    internal Boot.stQueryDevice QueryDevice;
    [FieldOffset(0)]
    internal Boot.stEraseDevice EraseDevice;
    [FieldOffset(0)]
    internal Boot.stProgramDevice ProgramDevice;
    [FieldOffset(0)]
    internal Boot.stProgramComplete ProgramComplete;
    [FieldOffset(0)]
    internal Boot.stResetDevice ResetDevice;
  }

  internal class MEMORY_REGION
  {
    internal uint Address;
    internal uint Size;
    internal byte[] Data;

    public MEMORY_REGION()
    {
      this.Address = 4096U /*0x1000*/;
      this.Size = 125952U;
      Array.Resize<byte>(ref this.Data, (int) this.Size);
      this.InitData(byte.MaxValue);
    }

    public MEMORY_REGION(uint TheAddress, uint TheSize, byte TheValue)
    {
      this.Address = TheAddress;
      this.Size = TheSize;
      Array.Resize<byte>(ref this.Data, (int) this.Size);
      this.InitData(TheValue);
    }

    public void Resize(uint TheAddress, uint TheSize)
    {
      this.Address = TheAddress;
      this.Size = TheSize;
      Array.Resize<byte>(ref this.Data, (int) this.Size);
    }

    internal void InitData(byte TheValue)
    {
      for (int index = 0; (long) index < (long) this.Size; ++index)
        this.Data[index] = TheValue;
    }
  }
}
