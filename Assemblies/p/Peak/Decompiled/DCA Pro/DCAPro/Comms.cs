// Decompiled with JetBrains decompiler
// Type: DCAPro.Comms
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace DCAPro;

internal class Comms
{
  internal const string WINUSB_PEAK_ATLAS_GUID_STRING = "{9B05F9EC-D9B6-43DC-A734-72D7CEA14190}";
  private Guid thisGuid = new Guid("{9B05F9EC-D9B6-43DC-A734-72D7CEA14190}");
  internal DeviceManagement myDeviceMan = new DeviceManagement();
  internal WinUsbDevice myWinUsbDevice = new WinUsbDevice();
  internal string DevicePathName = "";
  internal string ProductName = "";
  internal string SerialNum = "";
  internal string VersionNum = "";
  private Guid winUsbGuid = new Guid("{9B05F9EC-D9B6-43DC-A734-72D7CEA14190}");
  private DCAProUnit thisDCAPro;

  internal Comms(DCAProUnit Parent)
  {
    this.thisDCAPro = Parent;
    this.myDeviceMan.RegisterForDeviceNotifications(this.thisDCAPro.ParentHandle, this.thisGuid, ref this.myDeviceMan.deviceNotificationHandle);
  }

  public DCAProUnit.STATE FindTheDevice()
  {
    try
    {
      if (this.thisDCAPro.ConnectedState == DCAProUnit.STATE.PRESENT)
      {
        if (this.myWinUsbDevice.InitializeDevice(ref this.ProductName, ref this.VersionNum, ref this.SerialNum))
        {
          this.thisDCAPro.ConnectedState = DCAProUnit.STATE.CONNECTED;
          this.thisDCAPro.ProductName = this.ProductName;
          this.thisDCAPro.SerialNum = this.SerialNum;
          this.thisDCAPro.VersionNum = this.VersionNum;
        }
        else
          this.thisDCAPro.ConnectedState = DCAProUnit.STATE.UNCONNECTED;
      }
      if (this.thisDCAPro.ConnectedState == DCAProUnit.STATE.UNCONNECTED && this.myDeviceMan.FindDeviceFromGuid(this.winUsbGuid, ref this.DevicePathName))
      {
        if (this.myWinUsbDevice.GetDeviceHandle(this.DevicePathName))
        {
          this.thisDCAPro.ConnectedState = DCAProUnit.STATE.PRESENT;
        }
        else
        {
          this.myWinUsbDevice.CloseDeviceHandle();
          this.thisDCAPro.ConnectedState = DCAProUnit.STATE.UNCONNECTED;
        }
      }
      if (this.thisDCAPro.ConnectedState == DCAProUnit.STATE.PRESENT && this.myWinUsbDevice.InitializeDevice(ref this.ProductName, ref this.VersionNum, ref this.SerialNum))
      {
        this.thisDCAPro.ConnectedState = DCAProUnit.STATE.CONNECTED;
        this.thisDCAPro.ProductName = this.ProductName;
        this.thisDCAPro.SerialNum = this.SerialNum;
        this.thisDCAPro.VersionNum = this.VersionNum;
        if (this.myDeviceMan.deviceNotificationHandle != IntPtr.Zero)
        {
          this.myDeviceMan.StopReceivingDeviceNotifications(this.myDeviceMan.deviceNotificationHandle);
          this.myDeviceMan.deviceNotificationHandle = IntPtr.Zero;
        }
        this.myDeviceMan.RegisterForDeviceNotifications(this.thisDCAPro.ParentHandle, this.thisGuid, this.myWinUsbDevice.deviceHandle, ref this.myDeviceMan.deviceNotificationHandle);
      }
      return this.thisDCAPro.ConnectedState;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal void OnDeviceChange(Message m)
  {
    try
    {
      switch (m.WParam.ToInt32())
      {
        case 32768 /*0x8000*/:
          if (this.DevicePathName == null)
          {
            int theDevice = (int) this.FindTheDevice();
            break;
          }
          if (!this.myDeviceMan.DeviceMsgMatch(m, this.DevicePathName))
            break;
          int theDevice1 = (int) this.FindTheDevice();
          break;
        case 32772:
          if (!this.myDeviceMan.DeviceMsgMatch(m, this.DevicePathName))
            break;
          this.thisDCAPro.ConnectedState = DCAProUnit.STATE.UNCONNECTED;
          break;
      }
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal bool SendAndReceiveCommand(ref CMD.unCommand SendBuffer, ref CMD.unCommand ReceiveBuffer)
  {
    try
    {
      bool success = false;
      uint bytesRead = 0;
      byte[] numArray = new byte[64 /*0x40*/];
      uint num = 64 /*0x40*/;
      if (this.thisDCAPro.ConnectedState == DCAProUnit.STATE.CONNECTED)
      {
        byte[] byteArray = CMD.ObjectToByteArray(SendBuffer);
        if (this.thisDCAPro.ConnectedState == DCAProUnit.STATE.CONNECTED)
        {
          this.myWinUsbDevice.FlushPipe(Convert.ToByte(this.myWinUsbDevice.bulkInPipe), ref success);
          if (!success)
            Marshal.GetLastWin32Error();
          success = this.myWinUsbDevice.SendViaBulkTransfer(ref byteArray, num);
          if (!success)
            Marshal.GetLastWin32Error();
          if (success)
          {
            this.myWinUsbDevice.ReadViaBulkTransfer(Convert.ToByte(this.myWinUsbDevice.bulkInPipe), num, ref byteArray, ref bytesRead, ref success);
            ReceiveBuffer = CMD.ByteArrayToObject(byteArray);
          }
          if (!success)
          {
            Marshal.GetLastWin32Error();
            this.thisDCAPro.ConnectedState = DCAProUnit.STATE.PRESENT;
          }
        }
      }
      else
        success = false;
      return success;
    }
    catch (Exception ex)
    {
      throw;
    }
  }
}
