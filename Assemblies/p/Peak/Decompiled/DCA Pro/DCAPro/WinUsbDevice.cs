// Decompiled with JetBrains decompiler
// Type: DCAPro.WinUsbDevice
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace DCAPro;

internal sealed class WinUsbDevice
{
  internal const uint DEVICE_SPEED = 1;
  internal const byte USB_ENDPOINT_DIRECTION_MASK = 128 /*0x80*/;
  internal SafeFileHandle deviceHandle = new SafeFileHandle(IntPtr.Zero, true);
  internal IntPtr winUsbHandle = IntPtr.Zero;
  internal ushort VID;
  internal ushort PID;
  internal ushort VER;
  internal byte bulkInPipe;
  internal byte bulkOutPipe;
  internal byte interruptInPipe;
  internal byte interruptOutPipe;
  internal uint devicespeed;

  [DllImport("winusb.dll", SetLastError = true)]
  internal static extern bool WinUsb_ControlTransfer(
    IntPtr InterfaceHandle,
    WinUsbDevice.WINUSB_SETUP_PACKET SetupPacket,
    byte[] Buffer,
    uint BufferLength,
    ref uint LengthTransferred,
    IntPtr Overlapped);

  [DllImport("winusb.dll", SetLastError = true)]
  internal static extern bool WinUsb_Free(IntPtr InterfaceHandle);

  [DllImport("winusb.dll", SetLastError = true)]
  internal static extern bool WinUsb_Initialize(
    SafeFileHandle DeviceHandle,
    ref IntPtr InterfaceHandle);

  [DllImport("winusb.dll", SetLastError = true)]
  internal static extern bool WinUsb_QueryDeviceInformation(
    IntPtr InterfaceHandle,
    uint InformationType,
    ref uint BufferLength,
    ref byte Buffer);

  [DllImport("winusb.dll", SetLastError = true)]
  internal static extern bool WinUsb_GetDescriptor(
    IntPtr InterfaceHandle,
    byte DescriptorType,
    byte Index,
    ushort LanguageID,
    byte[] Buffer,
    uint BufferLength,
    ref uint LengthTransferred);

  [DllImport("winusb.dll", SetLastError = true)]
  internal static extern bool WinUsb_QueryInterfaceSettings(
    IntPtr InterfaceHandle,
    byte AlternateInterfaceNumber,
    ref WinUsbDevice.USB_INTERFACE_DESCRIPTOR UsbAltInterfaceDescriptor);

  [DllImport("winusb.dll", SetLastError = true)]
  internal static extern bool WinUsb_QueryPipe(
    IntPtr InterfaceHandle,
    byte AlternateInterfaceNumber,
    byte PipeIndex,
    ref WinUsbDevice.WINUSB_PIPE_INFORMATION PipeInformation);

  [DllImport("winusb.dll", SetLastError = true)]
  internal static extern bool WinUsb_ReadPipe(
    IntPtr InterfaceHandle,
    byte PipeID,
    byte[] Buffer,
    uint BufferLength,
    ref uint LengthTransferred,
    IntPtr Overlapped);

  [DllImport("winusb.dll", SetLastError = true)]
  internal static extern bool WinUsb_SetPipePolicy(
    IntPtr InterfaceHandle,
    byte PipeID,
    uint PolicyType,
    uint ValueLength,
    ref byte Value);

  [DllImport("winusb.dll", EntryPoint = "WinUsb_SetPipePolicy", SetLastError = true)]
  internal static extern bool WinUsb_SetPipePolicy1(
    IntPtr InterfaceHandle,
    byte PipeID,
    uint PolicyType,
    uint ValueLength,
    ref uint Value);

  [DllImport("winusb.dll", SetLastError = true)]
  internal static extern bool WinUsb_WritePipe(
    IntPtr InterfaceHandle,
    byte PipeID,
    byte[] Buffer,
    uint BufferLength,
    ref uint LengthTransferred,
    IntPtr Overlapped);

  [DllImport("winusb.dll", SetLastError = true)]
  internal static extern bool WinUsb_FlushPipe(IntPtr InterfaceHandle, byte PipeID);

  internal void CloseDeviceHandle()
  {
    try
    {
      if (this.deviceHandle == null || this.deviceHandle.IsClosed || this.deviceHandle.IsInvalid)
        return;
      this.deviceHandle.Close();
      WinUsbDevice.WinUsb_Free(this.winUsbHandle);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal bool Do_Control_Read_Transfer(ref byte[] dataStage)
  {
    uint LengthTransferred = 0;
    bool flag = false;
    try
    {
      WinUsbDevice.WINUSB_SETUP_PACKET SetupPacket;
      SetupPacket.RequestType = (byte) 193;
      SetupPacket.Request = (byte) 2;
      SetupPacket.Index = (ushort) 0;
      SetupPacket.Length = Convert.ToUInt16(dataStage.Length);
      SetupPacket.Value = (ushort) 0;
      if (!this.deviceHandle.IsClosed)
        flag = WinUsbDevice.WinUsb_ControlTransfer(this.winUsbHandle, SetupPacket, dataStage, (uint) Convert.ToUInt16(dataStage.Length), ref LengthTransferred, IntPtr.Zero);
      return flag;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal bool Do_Control_Write_Transfer(byte[] dataStage)
  {
    uint LengthTransferred = 0;
    ushort uint16_1 = Convert.ToUInt16(0);
    bool flag = false;
    ushort uint16_2 = Convert.ToUInt16(0);
    try
    {
      WinUsbDevice.WINUSB_SETUP_PACKET SetupPacket;
      SetupPacket.RequestType = (byte) 65;
      SetupPacket.Request = (byte) 1;
      SetupPacket.Index = uint16_1;
      SetupPacket.Length = Convert.ToUInt16(dataStage.Length);
      SetupPacket.Value = uint16_2;
      if (!this.deviceHandle.IsClosed)
        flag = WinUsbDevice.WinUsb_ControlTransfer(this.winUsbHandle, SetupPacket, dataStage, (uint) Convert.ToUInt16(dataStage.Length), ref LengthTransferred, IntPtr.Zero);
      return flag;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal bool GetDeviceHandle(string devicePathName)
  {
    this.deviceHandle = FileIO.CreateFile(devicePathName, 3221225472U /*0xC0000000*/, 3, IntPtr.Zero, 3, 1073741952 /*0x40000080*/, 0);
    return !this.deviceHandle.IsInvalid;
  }

  internal bool InitializeDevice(ref string ProductName, ref string VersionNum, ref string Serial)
  {
    uint num1 = 2000;
    bool flag = false;
    try
    {
      WinUsbDevice.USB_INTERFACE_DESCRIPTOR UsbAltInterfaceDescriptor;
      UsbAltInterfaceDescriptor.bLength = (byte) 0;
      UsbAltInterfaceDescriptor.bDescriptorType = (byte) 0;
      UsbAltInterfaceDescriptor.bInterfaceNumber = (byte) 0;
      UsbAltInterfaceDescriptor.bAlternateSetting = (byte) 0;
      UsbAltInterfaceDescriptor.bNumEndpoints = (byte) 0;
      UsbAltInterfaceDescriptor.bInterfaceClass = (byte) 0;
      UsbAltInterfaceDescriptor.bInterfaceSubClass = (byte) 0;
      UsbAltInterfaceDescriptor.bInterfaceProtocol = (byte) 0;
      UsbAltInterfaceDescriptor.iInterface = (byte) 0;
      WinUsbDevice.WINUSB_PIPE_INFORMATION PipeInformation;
      PipeInformation.PipeType = WinUsbDevice.USBD_PIPE_TYPE.UsbdPipeTypeControl;
      PipeInformation.PipeId = (byte) 0;
      PipeInformation.MaximumPacketSize = (ushort) 0;
      PipeInformation.Interval = (byte) 0;
      if (!this.deviceHandle.IsClosed)
        flag = WinUsbDevice.WinUsb_Initialize(this.deviceHandle, ref this.winUsbHandle);
      if (flag)
      {
        if (WinUsbDevice.WinUsb_QueryInterfaceSettings(this.winUsbHandle, (byte) 0, ref UsbAltInterfaceDescriptor))
        {
          for (int index = 0; index <= (int) UsbAltInterfaceDescriptor.bNumEndpoints - 1; ++index)
          {
            WinUsbDevice.WinUsb_QueryPipe(this.winUsbHandle, (byte) 0, Convert.ToByte(index), ref PipeInformation);
            if (PipeInformation.PipeType == WinUsbDevice.USBD_PIPE_TYPE.UsbdPipeTypeBulk & this.UsbEndpointDirectionIn((int) PipeInformation.PipeId))
            {
              this.bulkInPipe = PipeInformation.PipeId;
              this.SetPipePolicy(this.bulkInPipe, Convert.ToUInt32((object) WinUsbDevice.POLICY_TYPE.IGNORE_SHORT_PACKETS), Convert.ToByte(false));
              this.SetPipePolicy(this.bulkInPipe, Convert.ToUInt32((object) WinUsbDevice.POLICY_TYPE.PIPE_TRANSFER_TIMEOUT), num1);
            }
            else if (PipeInformation.PipeType == WinUsbDevice.USBD_PIPE_TYPE.UsbdPipeTypeBulk & this.UsbEndpointDirectionOut((int) PipeInformation.PipeId))
            {
              this.bulkOutPipe = PipeInformation.PipeId;
              this.SetPipePolicy(this.bulkOutPipe, Convert.ToUInt32((object) WinUsbDevice.POLICY_TYPE.PIPE_TRANSFER_TIMEOUT), num1);
            }
            else if (PipeInformation.PipeType == WinUsbDevice.USBD_PIPE_TYPE.UsbdPipeTypeInterrupt & this.UsbEndpointDirectionIn((int) PipeInformation.PipeId))
            {
              this.interruptInPipe = PipeInformation.PipeId;
              this.SetPipePolicy(this.interruptInPipe, Convert.ToUInt32((object) WinUsbDevice.POLICY_TYPE.IGNORE_SHORT_PACKETS), Convert.ToByte(false));
              this.SetPipePolicy(this.interruptInPipe, Convert.ToUInt32((object) WinUsbDevice.POLICY_TYPE.PIPE_TRANSFER_TIMEOUT), num1);
            }
            else if (PipeInformation.PipeType == WinUsbDevice.USBD_PIPE_TYPE.UsbdPipeTypeInterrupt & this.UsbEndpointDirectionOut((int) PipeInformation.PipeId))
            {
              this.interruptOutPipe = PipeInformation.PipeId;
              this.SetPipePolicy(this.interruptOutPipe, Convert.ToUInt32((object) WinUsbDevice.POLICY_TYPE.PIPE_TRANSFER_TIMEOUT), num1);
            }
          }
          byte[] numArray = new byte[1024 /*0x0400*/];
          uint LengthTransferred = 0;
          int num2 = 5;
          do
          {
            flag = WinUsbDevice.WinUsb_GetDescriptor(this.winUsbHandle, (byte) 1, (byte) 0, (ushort) 0, numArray, 1024U /*0x0400*/, ref LengthTransferred);
          }
          while (LengthTransferred == 0U && num2-- > 0);
          if (flag)
          {
            if (LengthTransferred > 0U)
            {
              this.VID = (ushort) ((uint) numArray[8] + 256U /*0x0100*/ * (uint) numArray[9]);
              this.PID = (ushort) ((uint) numArray[10] + 256U /*0x0100*/ * (uint) numArray[11]);
              this.VER = (ushort) ((uint) numArray[12] + 256U /*0x0100*/ * (uint) numArray[13]);
              VersionNum = $"{this.VER:x04}";
            }
            int num3 = 5;
            do
            {
              flag = WinUsbDevice.WinUsb_GetDescriptor(this.winUsbHandle, (byte) 3, (byte) 1, (ushort) 0, numArray, 1024U /*0x0400*/, ref LengthTransferred);
            }
            while (LengthTransferred == 0U && num3-- > 0);
            if (flag)
            {
              if (LengthTransferred > 0U)
                Encoding.Unicode.GetString(numArray, 2, (int) LengthTransferred - 2);
              int num4 = 5;
              do
              {
                flag = WinUsbDevice.WinUsb_GetDescriptor(this.winUsbHandle, (byte) 3, (byte) 2, (ushort) 0, numArray, 1024U /*0x0400*/, ref LengthTransferred);
              }
              while (LengthTransferred == 0U && num4-- > 0);
              if (flag)
              {
                if (LengthTransferred > 0U)
                  ProductName = Encoding.Unicode.GetString(numArray, 2, (int) LengthTransferred - 2);
                int num5 = 5;
                do
                {
                  flag = WinUsbDevice.WinUsb_GetDescriptor(this.winUsbHandle, (byte) 3, (byte) 3, (ushort) 0, numArray, 1024U /*0x0400*/, ref LengthTransferred);
                }
                while (LengthTransferred == 0U && num5-- > 0);
                if (LengthTransferred > 0U)
                  Serial = Encoding.Unicode.GetString(numArray, 2, (int) LengthTransferred - 2);
              }
            }
          }
        }
        if (!flag)
          this.CloseDeviceHandle();
      }
      return flag;
    }
    catch (Exception ex)
    {
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
      throw;
    }
  }

  internal bool QueryDeviceSpeed()
  {
    uint BufferLength = 1;
    byte[] numArray = new byte[1];
    bool flag = false;
    if (!this.deviceHandle.IsClosed)
      flag = WinUsbDevice.WinUsb_QueryDeviceInformation(this.winUsbHandle, 1U, ref BufferLength, ref numArray[0]);
    if (flag)
      this.devicespeed = Convert.ToUInt32(numArray[0]);
    return flag;
  }

  internal void ReadViaBulkTransfer(
    byte pipeID,
    uint bytesToRead,
    ref byte[] buffer,
    ref uint bytesRead,
    ref bool success)
  {
    try
    {
      success = false;
      if (!this.deviceHandle.IsClosed)
        success = WinUsbDevice.WinUsb_ReadPipe(this.winUsbHandle, pipeID, buffer, bytesToRead, ref bytesRead, IntPtr.Zero);
      if (success)
        return;
      this.CloseDeviceHandle();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void FlushPipe(byte pipeID, ref bool success)
  {
    try
    {
      success = false;
      if (!this.deviceHandle.IsClosed)
        success = WinUsbDevice.WinUsb_FlushPipe(this.winUsbHandle, pipeID);
      if (success)
        return;
      this.CloseDeviceHandle();
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal bool SendViaBulkTransfer(ref byte[] buffer, uint bytesToWrite)
  {
    uint LengthTransferred = 0;
    bool flag = false;
    try
    {
      if (!this.deviceHandle.IsClosed)
        flag = WinUsbDevice.WinUsb_WritePipe(this.winUsbHandle, this.bulkOutPipe, buffer, bytesToWrite, ref LengthTransferred, IntPtr.Zero);
      if (!flag)
        this.CloseDeviceHandle();
      return flag;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private bool SetPipePolicy(byte pipeId, uint policyType, byte value)
  {
    bool flag = false;
    try
    {
      if (!this.deviceHandle.IsClosed)
        flag = WinUsbDevice.WinUsb_SetPipePolicy(this.winUsbHandle, pipeId, policyType, 1U, ref value);
      return flag;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private bool SetPipePolicy(byte pipeId, uint policyType, uint value)
  {
    bool flag = false;
    try
    {
      if (!this.deviceHandle.IsClosed)
        flag = WinUsbDevice.WinUsb_SetPipePolicy1(this.winUsbHandle, pipeId, policyType, 4U, ref value);
      return flag;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  private bool UsbEndpointDirectionIn(int addr)
  {
    bool flag;
    try
    {
      flag = (addr & 128 /*0x80*/) == 128 /*0x80*/;
    }
    catch (Exception ex)
    {
      throw;
    }
    return flag;
  }

  private bool UsbEndpointDirectionOut(int addr)
  {
    bool flag;
    try
    {
      flag = (addr & 128 /*0x80*/) == 0;
    }
    catch (Exception ex)
    {
      throw;
    }
    return flag;
  }

  internal enum POLICY_TYPE
  {
    SHORT_PACKET_TERMINATE = 1,
    AUTO_CLEAR_STALL = 2,
    PIPE_TRANSFER_TIMEOUT = 3,
    IGNORE_SHORT_PACKETS = 4,
    ALLOW_PARTIAL_READS = 5,
    AUTO_FLUSH = 6,
    RAW_IO = 7,
    MAXIMUM_TRANSFER_SIZE = 8,
    RESET_PIPE_ON_RESUME = 9,
  }

  internal enum USBD_PIPE_TYPE
  {
    UsbdPipeTypeControl,
    UsbdPipeTypeIsochronous,
    UsbdPipeTypeBulk,
    UsbdPipeTypeInterrupt,
  }

  internal enum USB_DEVICE_SPEED
  {
    UsbLowSpeed = 1,
    UsbFullSpeed = 2,
    UsbHighSpeed = 3,
  }

  internal struct USB_CONFIGURATION_DESCRIPTOR
  {
    internal byte bLength;
    internal byte bDescriptorType;
    internal ushort wTotalLength;
    internal byte bNumInterfaces;
    internal byte bConfigurationValue;
    internal byte iConfiguration;
    internal byte bmAttributes;
    internal byte MaxPower;
  }

  internal struct USB_INTERFACE_DESCRIPTOR
  {
    internal byte bLength;
    internal byte bDescriptorType;
    internal byte bInterfaceNumber;
    internal byte bAlternateSetting;
    internal byte bNumEndpoints;
    internal byte bInterfaceClass;
    internal byte bInterfaceSubClass;
    internal byte bInterfaceProtocol;
    internal byte iInterface;
  }

  internal struct WINUSB_PIPE_INFORMATION
  {
    internal WinUsbDevice.USBD_PIPE_TYPE PipeType;
    internal byte PipeId;
    internal ushort MaximumPacketSize;
    internal byte Interval;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct WINUSB_SETUP_PACKET
  {
    internal byte RequestType;
    internal byte Request;
    internal ushort Value;
    internal ushort Index;
    internal ushort Length;
  }
}
