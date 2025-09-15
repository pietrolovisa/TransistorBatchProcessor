// Decompiled with JetBrains decompiler
// Type: DCAPro.DeviceManagement
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using Microsoft.Win32.SafeHandles;
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#nullable disable
namespace DCAPro;

internal sealed class DeviceManagement
{
  internal const int DBT_DEVNODES_CHANGED = 7;
  internal const int DBT_QUERYCHANGECONFIG = 23;
  internal const int DBT_CONFIGCHANGED = 24;
  internal const int DBT_CONFIGCHANGECANCELLED = 25;
  internal const int DBT_DEVICEARRIVAL = 32768 /*0x8000*/;
  internal const int DBT_DEVICEQUERYREMOVE = 32769;
  internal const int DBT_DEVICEQUERYREMOVEFAILED = 32770;
  internal const int DBT_DEVICEREMOVEPENDING = 32771;
  internal const int DBT_DEVICEREMOVECOMPLETE = 32772;
  internal const int DBT_DEVICETYPESPECIFIC = 32773;
  internal const int DBT_CUSTOMEVENT = 32774;
  internal const int DBT_DEVTYP_DEVICEINTERFACE = 5;
  internal const int DBT_DEVTYP_HANDLE = 6;
  internal const int DEVICE_NOTIFY_ALL_INTERFACE_CLASSES = 4;
  internal const int DEVICE_NOTIFY_SERVICE_HANDLE = 1;
  internal const int DEVICE_NOTIFY_WINDOW_HANDLE = 0;
  internal const int WM_DEVICECHANGE = 537;
  internal const int DIGCF_PRESENT = 2;
  internal const int DIGCF_DEVICEINTERFACE = 16 /*0x10*/;
  internal IntPtr deviceNotificationHandle = IntPtr.Zero;

  ~DeviceManagement()
  {
    try
    {
      if (!(this.deviceNotificationHandle != IntPtr.Zero))
        return;
      this.StopReceivingDeviceNotifications(this.deviceNotificationHandle);
      this.deviceNotificationHandle = IntPtr.Zero;
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

  internal bool DeviceMsgMatch(Message m, SafeFileHandle Handle)
  {
    try
    {
      DeviceManagement.DEV_BROADCAST_HANDLE structure1 = new DeviceManagement.DEV_BROADCAST_HANDLE();
      DeviceManagement.DEV_BROADCAST_HDR structure2 = new DeviceManagement.DEV_BROADCAST_HDR();
      Marshal.PtrToStructure(m.LParam, (object) structure2);
      if (structure2.dbch_devicetype == 6)
      {
        Marshal.PtrToStructure(m.LParam, (object) structure1);
        return structure1.dbch_handle == Handle.DangerousGetHandle();
      }
    }
    catch (Exception ex)
    {
      throw;
    }
    return false;
  }

  internal bool DeviceMsgMatch(Message m, string mydevicePathName)
  {
    try
    {
      DeviceManagement.DEV_BROADCAST_DEVICEINTERFACE_1 structure1 = new DeviceManagement.DEV_BROADCAST_DEVICEINTERFACE_1();
      DeviceManagement.DEV_BROADCAST_HDR structure2 = new DeviceManagement.DEV_BROADCAST_HDR();
      Marshal.PtrToStructure(m.LParam, (object) structure2);
      if (structure2.dbch_devicetype == 5)
      {
        int int32 = Convert.ToInt32((structure2.dbch_size - 32 /*0x20*/) / 2);
        structure1.dbcc_name = new char[int32 + 1];
        Marshal.PtrToStructure(m.LParam, (object) structure1);
        return string.Compare(new string(structure1.dbcc_name, 0, int32), mydevicePathName, true) == 0;
      }
    }
    catch (Exception ex)
    {
      throw;
    }
    return false;
  }

  internal bool FindDeviceFromGuid(Guid myGuid, ref string devicePathName)
  {
    int RequiredSize = 0;
    IntPtr num = IntPtr.Zero;
    IntPtr DeviceInfoSet = new IntPtr();
    bool flag = false;
    DeviceManagement.SP_DEVICE_INTERFACE_DATA DeviceInterfaceData = new DeviceManagement.SP_DEVICE_INTERFACE_DATA();
    try
    {
      DeviceInfoSet = DeviceManagement.SetupDiGetClassDevs(ref myGuid, IntPtr.Zero, IntPtr.Zero, 18);
      bool deviceFromGuid = false;
      int MemberIndex = 0;
      DeviceInterfaceData.cbSize = Marshal.SizeOf((object) DeviceInterfaceData);
      do
      {
        if (!DeviceManagement.SetupDiEnumDeviceInterfaces(DeviceInfoSet, IntPtr.Zero, ref myGuid, MemberIndex, ref DeviceInterfaceData))
        {
          flag = true;
        }
        else
        {
          bool deviceInterfaceDetail = DeviceManagement.SetupDiGetDeviceInterfaceDetail(DeviceInfoSet, ref DeviceInterfaceData, IntPtr.Zero, 0, ref RequiredSize, IntPtr.Zero);
          if (num != IntPtr.Zero)
          {
            Marshal.FreeHGlobal(num);
            num = IntPtr.Zero;
          }
          num = Marshal.AllocHGlobal(RequiredSize);
          Marshal.WriteInt32(num, IntPtr.Size == 4 ? 4 + Marshal.SystemDefaultCharSize : 8);
          deviceInterfaceDetail = DeviceManagement.SetupDiGetDeviceInterfaceDetail(DeviceInfoSet, ref DeviceInterfaceData, num, RequiredSize, ref RequiredSize, IntPtr.Zero);
          IntPtr ptr = new IntPtr(num.ToInt32() + 4);
          devicePathName = Marshal.PtrToStringAuto(ptr);
          deviceFromGuid = true;
        }
        ++MemberIndex;
      }
      while (!flag);
      return deviceFromGuid;
    }
    catch (Exception ex)
    {
      throw;
    }
    finally
    {
      if (num != IntPtr.Zero)
      {
        Marshal.FreeHGlobal(num);
        IntPtr zero = IntPtr.Zero;
      }
      if (DeviceInfoSet != IntPtr.Zero)
        DeviceManagement.SetupDiDestroyDeviceInfoList(DeviceInfoSet);
    }
  }

  internal bool FindDeviceFromGuid(Guid myGuid, ref string[] devicePathName)
  {
    int RequiredSize = 0;
    IntPtr num = IntPtr.Zero;
    IntPtr DeviceInfoSet = new IntPtr();
    bool flag = false;
    DeviceManagement.SP_DEVICE_INTERFACE_DATA DeviceInterfaceData = new DeviceManagement.SP_DEVICE_INTERFACE_DATA();
    try
    {
      DeviceInfoSet = DeviceManagement.SetupDiGetClassDevs(ref myGuid, IntPtr.Zero, IntPtr.Zero, 18);
      bool deviceFromGuid = false;
      int MemberIndex = 0;
      DeviceInterfaceData.cbSize = Marshal.SizeOf((object) DeviceInterfaceData);
      do
      {
        if (!DeviceManagement.SetupDiEnumDeviceInterfaces(DeviceInfoSet, IntPtr.Zero, ref myGuid, MemberIndex, ref DeviceInterfaceData))
        {
          flag = true;
        }
        else
        {
          bool deviceInterfaceDetail = DeviceManagement.SetupDiGetDeviceInterfaceDetail(DeviceInfoSet, ref DeviceInterfaceData, IntPtr.Zero, 0, ref RequiredSize, IntPtr.Zero);
          if (num != IntPtr.Zero)
          {
            Marshal.FreeHGlobal(num);
            num = IntPtr.Zero;
          }
          num = Marshal.AllocHGlobal(RequiredSize);
          Marshal.WriteInt32(num, IntPtr.Size == 4 ? 4 + Marshal.SystemDefaultCharSize : 8);
          deviceInterfaceDetail = DeviceManagement.SetupDiGetDeviceInterfaceDetail(DeviceInfoSet, ref DeviceInterfaceData, num, RequiredSize, ref RequiredSize, IntPtr.Zero);
          IntPtr ptr = new IntPtr(num.ToInt32() + 4);
          devicePathName[MemberIndex] = Marshal.PtrToStringAuto(ptr);
          deviceFromGuid = true;
        }
        ++MemberIndex;
      }
      while (!flag);
      return deviceFromGuid;
    }
    catch (Exception ex)
    {
      throw;
    }
    finally
    {
      if (num != IntPtr.Zero)
      {
        Marshal.FreeHGlobal(num);
        IntPtr zero = IntPtr.Zero;
      }
      if (DeviceInfoSet != IntPtr.Zero)
        DeviceManagement.SetupDiDestroyDeviceInfoList(DeviceInfoSet);
    }
  }

  internal bool RegisterForDeviceNotifications(
    IntPtr formHandle,
    Guid classGuid,
    ref IntPtr deviceNotificationHandle)
  {
    DeviceManagement.DEV_BROADCAST_DEVICEINTERFACE structure = new DeviceManagement.DEV_BROADCAST_DEVICEINTERFACE();
    IntPtr num = IntPtr.Zero;
    try
    {
      int cb = Marshal.SizeOf((object) structure);
      structure.dbcc_size = cb;
      structure.dbcc_devicetype = 5;
      structure.dbcc_reserved = 0;
      structure.dbcc_classguid = classGuid;
      num = Marshal.AllocHGlobal(cb);
      Marshal.StructureToPtr((object) structure, num, true);
      deviceNotificationHandle = DeviceManagement.RegisterDeviceNotification(formHandle, num, 0);
      Marshal.PtrToStructure(num, (object) structure);
      return deviceNotificationHandle.ToInt32() != IntPtr.Zero.ToInt32();
    }
    catch (Exception ex)
    {
      throw;
    }
    finally
    {
      if (num != IntPtr.Zero)
      {
        Marshal.FreeHGlobal(num);
        IntPtr zero = IntPtr.Zero;
      }
    }
  }

  internal bool RegisterForDeviceNotifications(
    IntPtr formHandle,
    Guid classGuid,
    SafeFileHandle hidHandle,
    ref IntPtr deviceNotificationHandle)
  {
    DeviceManagement.DEV_BROADCAST_HANDLE structure = new DeviceManagement.DEV_BROADCAST_HANDLE();
    IntPtr num = IntPtr.Zero;
    try
    {
      int cb = Marshal.SizeOf((object) structure);
      structure.dbch_size = cb;
      structure.dbch_devicetype = 6;
      structure.dbch_reserved = 0;
      structure.dbch_handle = hidHandle.DangerousGetHandle();
      structure.dbch_hdevnotify = deviceNotificationHandle;
      num = Marshal.AllocHGlobal(cb);
      structure.dbch_eventguid = Guid.Empty;
      structure.dbch_nameoffset = 0;
      structure.dbch_data = (byte) 0;
      Marshal.StructureToPtr((object) structure, num, true);
      deviceNotificationHandle = DeviceManagement.RegisterDeviceNotification(formHandle, num, 0);
      Marshal.PtrToStructure(num, (object) structure);
      return deviceNotificationHandle.ToInt32() != IntPtr.Zero.ToInt32();
    }
    catch (Exception ex)
    {
      throw;
    }
    finally
    {
      if (num != IntPtr.Zero)
      {
        Marshal.FreeHGlobal(num);
        IntPtr zero = IntPtr.Zero;
      }
    }
  }

  internal void StopReceivingDeviceNotifications(IntPtr deviceNotificationHandle)
  {
    try
    {
      DeviceManagement.UnregisterDeviceNotification(deviceNotificationHandle);
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  internal static extern IntPtr RegisterDeviceNotification(
    IntPtr hRecipient,
    IntPtr NotificationFilter,
    int Flags);

  [DllImport("setupapi.dll", SetLastError = true)]
  internal static extern int SetupDiCreateDeviceInfoList(ref Guid ClassGuid, int hwndParent);

  [DllImport("setupapi.dll", SetLastError = true)]
  internal static extern int SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

  [DllImport("setupapi.dll", SetLastError = true)]
  internal static extern bool SetupDiEnumDeviceInterfaces(
    IntPtr DeviceInfoSet,
    IntPtr DeviceInfoData,
    ref Guid InterfaceClassGuid,
    int MemberIndex,
    ref DeviceManagement.SP_DEVICE_INTERFACE_DATA DeviceInterfaceData);

  [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
  internal static extern IntPtr SetupDiGetClassDevs(
    ref Guid ClassGuid,
    IntPtr Enumerator,
    IntPtr hwndParent,
    int Flags);

  [DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
  internal static extern bool SetupDiGetDeviceInterfaceDetail(
    IntPtr DeviceInfoSet,
    ref DeviceManagement.SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
    IntPtr DeviceInterfaceDetailData,
    int DeviceInterfaceDetailDataSize,
    ref int RequiredSize,
    IntPtr DeviceInfoData);

  [DllImport("user32.dll", SetLastError = true)]
  internal static extern bool UnregisterDeviceNotification(IntPtr Handle);

  [StructLayout(LayoutKind.Sequential)]
  internal class DEV_BROADCAST_DEVICEINTERFACE
  {
    internal int dbcc_size;
    internal int dbcc_devicetype;
    internal int dbcc_reserved;
    internal Guid dbcc_classguid;
    internal short dbcc_name;
  }

  [StructLayout(LayoutKind.Sequential)]
  internal class DEV_BROADCAST_HANDLE
  {
    internal int dbch_size;
    internal int dbch_devicetype;
    internal int dbch_reserved;
    internal IntPtr dbch_handle;
    internal IntPtr dbch_hdevnotify;
    internal Guid dbch_eventguid;
    internal int dbch_nameoffset;
    internal byte dbch_data;
  }

  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  internal class DEV_BROADCAST_DEVICEINTERFACE_1
  {
    internal int dbcc_size;
    internal int dbcc_devicetype;
    internal int dbcc_reserved;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16 /*0x10*/, ArraySubType = UnmanagedType.U1)]
    internal byte[] dbcc_classguid;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 255 /*0xFF*/)]
    internal char[] dbcc_name;
  }

  [StructLayout(LayoutKind.Sequential)]
  internal class DEV_BROADCAST_HDR
  {
    internal int dbch_size;
    internal int dbch_devicetype;
    internal int dbch_reserved;
  }

  internal struct SP_DEVICE_INTERFACE_DATA
  {
    internal int cbSize;
    internal Guid InterfaceClassGuid;
    internal int Flags;
    internal IntPtr Reserved;
  }

  internal struct SP_DEVICE_INTERFACE_DETAIL_DATA
  {
    internal int cbSize;
    internal string DevicePath;
  }

  internal struct SP_DEVINFO_DATA
  {
    internal int cbSize;
    internal Guid ClassGuid;
    internal int DevInst;
    internal int Reserved;
  }
}
