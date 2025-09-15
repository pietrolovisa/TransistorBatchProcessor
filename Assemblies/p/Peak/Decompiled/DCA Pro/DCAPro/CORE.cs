// Decompiled with JetBrains decompiler
// Type: DCAPro.CORE
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

#nullable disable
namespace DCAPro;

public class CORE
{
  internal const byte CxPHASE1 = 1;
  internal const byte CxPHASE2 = 2;

  public enum ACHAN : byte
  {
    Battery = 1,
    TestButton = 2,
    V12V = 3,
    PreReg = 4,
    Ref = 5,
    GateSet = 6,
    Gate = 7,
    MT1Set = 8,
    MT2Set = 9,
    MT2 = 10, // 0x0A
    Red = 11, // 0x0B
    Green = 12, // 0x0C
    Blue = 13, // 0x0D
  }

  internal enum BOOST
  {
    OFF,
    BATT,
    USB,
    TEST,
  }

  public enum REQBIT_D : byte
  {
    VBATT = 1,
    BTEST = 2,
    V12V = 4,
    VPREREG = 8,
    VREF = 16, // 0x10
  }

  public enum REQBIT_M : byte
  {
    VSET_GATE = 1,
    GATE = 2,
    VR_GATE = 3,
    VSET_MT1 = 4,
    VSET_MT2 = 8,
    MT2 = 16, // 0x10
    VR_MT2 = 24, // 0x18
    RED = 32, // 0x20
    GREEN = 64, // 0x40
    BLUE = 128, // 0x80
    RGB = 224, // 0xE0
  }

  public enum CxMODE : byte
  {
    OFF = 0,
    ON = 1,
    READ = 3,
    RESET_ACQ = 4,
    ONESHOT = 5,
    ONESHOT_BURST = 6,
  }

  public enum CxSTATE : byte
  {
    RUN = 1,
    RUNNING = 3,
    ACQUIRED = 4,
    FAILED = 8,
    TRIG = 16, // 0x10
    TRIG_BURST = 32, // 0x20
    TIMEDOUT = 64, // 0x40
  }
}
