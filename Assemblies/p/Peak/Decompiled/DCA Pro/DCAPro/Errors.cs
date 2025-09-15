// Decompiled with JetBrains decompiler
// Type: DCAPro.Errors
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

#nullable disable
namespace DCAPro;

public static class Errors
{
  public static string ErrorToString(Errors.Type Error)
  {
    string str;
    switch (Error)
    {
      case Errors.Type.ErrNone:
        str = "";
        break;
      case Errors.Type.ErrBoost_Not_On:
        str = "Boost Off";
        break;
      case Errors.Type.ErrBoost_Timeout:
        str = "Boost Timeout";
        break;
      case Errors.Type.ErrModeLocked:
        str = "Mode Locked";
        break;
      default:
        str = "Unknown";
        break;
    }
    return str;
  }

  public enum Type : ushort
  {
    ErrNone = 0,
    ErrBoost_Not_On = 1,
    ErrBoost_Timeout = 2,
    ErrModeLocked = 3,
    ErrCalFlashFail = 4,
    ErrCalFlashed = 5,
    ErrSerFlashFail = 6,
    ErrSerFlashed = 7,
    Temp = 257, // 0x0101
    CommsFailed = 258, // 0x0102
    CommsFailed_GetStateAck = 259, // 0x0103
    CommsFailed_InitiateTest = 260, // 0x0104
    CommsFailed_ReadTestResult = 261, // 0x0105
    CommsFailed_ReadType = 262, // 0x0106
    CommsFailed_ReadFirmware = 263, // 0x0107
    CommsFailed_ReadSerial = 264, // 0x0108
    CommsFailed_ReadCal = 265, // 0x0109
    CommsFailed_ReadADCS = 266, // 0x010A
    CommsFailed_ReadADCSBurst = 267, // 0x010B
    CommsFailed_ReadADCSDirect = 268, // 0x010C
    CommsFailed_BoostOnWait = 269, // 0x010D
    CommsFailed_BoostWait = 270, // 0x010E
    CommsFailed_BoostOff = 271, // 0x010F
    CommsFailed_LeadsSafe = 272, // 0x0110
    CommsFailed_SetRGate = 273, // 0x0111
    CommsFailed_WriteVolts = 274, // 0x0112
    CommsFailed_WriteAllVolts = 275, // 0x0113
    CommsFailed_WriteTestResult = 276, // 0x0114
    CommsFailed_MatrixRGB = 277, // 0x0115
    CommsFailed_MatrixPlus = 278, // 0x0116
    CommsFailed_Mode = 279, // 0x0117
    CommsFailed_CCGate = 280, // 0x0118
    CommsFailed_SetContrast = 281, // 0x0119
    CommsFailed_CVGate = 282, // 0x011A
    ErrUnknown = 65535, // 0xFFFF
  }
}
