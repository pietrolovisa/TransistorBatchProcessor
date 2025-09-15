// Decompiled with JetBrains decompiler
// Type: DCAPro.Test
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System.Runtime.InteropServices;

#nullable disable
namespace DCAPro;

public static class Test
{
  internal const float ADC_FS_BITS = 16383f;
  internal const float ADC_FS_VOLTS = 3.3f;
  internal const float ADC_VOLTS_BIT = 0.000201428309f;
  internal const float VRead_Gain = 4.5454545f;
  internal const float DAC_FS_BITS = 4095f;
  internal const float DAC_FS_VOLTS = 2.048f;
  internal const float DAC_BITS_VOLT = 1999.5116f;
  internal const float DAC_GAIN = 6.66666651f;
  public const float MT1_RESISTANCE = 0.0f;
  internal const float MIN_VOFFSET = 0.5f;
  internal const float BOOST_MAX_VOLTS = 15f;
  internal const float BOOST_HEADROOM = 3f;
  internal const float MAX_VOFFSET = 3f;
  internal const float MAX_V = 12f;
  internal const int BOOST_TIMEOUT = 300;
  internal const float MAX_CURRENT = 12f;
  internal const byte DIODE_SETTLING_MS = 20;
  internal const float PDIODE_VF_MAX = 3f;
  internal const float DIODE_VF_MAX = 10f;
  internal const float DIODE_IF_TEST = 5f;
  internal const float DIODE_VR_TEST = 5f;
  internal const float LED_VMIN = 1.5f;
  internal const float LED_VMAX = 4f;
  internal const float NOT_THRESH = 1E-05f;
  internal const float TRN_VOFFSET = 0.5f;
  internal const byte TRN_SETTLING_MS = 3;
  internal const float TRN_ISAFE = 5f;
  internal const float TRN_ICSAT = 5f;
  internal const float TRN_IBSAT = 1f;
  internal const float BJT_HFE_MIN_SAT = 10f;
  internal const byte SCR_SETTLING_MS = 2;
  internal const float PN_VSAFE = 5f;
  internal const float BJT_VMIN = 0.0f;
  internal const float BJT_VSPAN_LO = 5f;
  internal const float BJT_VSPAN_HI = 8f;
  internal const float BJT_VMAX = 10f;
  internal const float BJT_ILEAK_MIN = 0.01f;
  internal const float BJT_HFE_MIN = 2f;
  internal const float BJT_HFE_MAX = 32000f;
  internal const float BJT_RINPUT_MIN = 500f;
  internal const float MOSFET_VSPAN = 8f;
  internal const float MOSFET_VGATE_ON8 = 8f;
  internal const float MOSFET_VTH_MIN = 4f;
  internal const float MOSFET_ID_LEAK = 1f;
  internal const float IGBT_VSAT_THOLD = 0.2f;
  internal const float FET_ID_LIMIT = 0.5f;
  internal const float FET_IG_LIMIT = 0.01f;
  internal const float FET_IGOFF_LIMIT = 0.001f;
  internal const float FET_IDON_LIMIT = 5f;
  internal const float FET_IDON2 = 4f;
  internal const float FET_IDONLOW_LIMIT = 1f;
  internal const float FET_IDOFF_LIMIT = 0.001f;
  internal const float FET_VGS_LIMIT = 0.01f;
  internal const float FET_G_MAX = 100f;
  internal const float FET_ID_MAX = 12f;
  internal const float JFET_VGS_ZERO = 0.001f;
  internal const float JFET_VGS_MAX = 3f;
  internal const float JFET_VGS_MIN = 0.25f;
  internal const float JFET_IDSS_DVG = 0.01f;
  internal const float VBE_GERMANIUM = 0.55f;
  internal const float VBE_GERMANIUM_LOW = 0.5f;
  internal const float ICE_GERMANIUM_LOW = 0.01f;
  internal const float VBE_DIGITAL = 1.8f;
  internal const float VBE_DARLINGTON = 0.95f;
  internal const float VBE_DARLINGTON_R = 0.85f;
  internal const float VBE_DARLINGTON_RLOW = 0.8f;
  internal const float VBE_DARLINGTON_MAX = 1.8f;
  internal const float RSHUNT_MAX = 56000f;
  internal const float RSHUNT_LOW = 25000f;
  internal const float SILICON_LEAKY_mA = 0.2f;
  internal const float GERMANIUM_LEAKY_mA = 3f;
  internal const float SCR_LEAKY_mA = 0.2f;
  internal const float VREG_DVOUT_5 = 0.05f;
  internal const float VREG_DVOUT_10 = 0.1f;
  internal const float VREG_DVOUT_20 = 0.2f;
  internal const float VREG_VREG_10 = 0.1f;
  internal const float SHORT_RESISTANCE = 20f;

  internal static Test.CONFIG ConfigFrom12G(Test.LEAD[] RGB)
  {
    Test.CONFIG_RGB configRgb = Test.CONFIG_RGB.NONE;
    switch (RGB[0])
    {
      case Test.LEAD.RED:
        configRgb = RGB[1] == Test.LEAD.GREEN || RGB[2] == Test.LEAD.BLUE ? Test.CONFIG_RGB.MIN : Test.CONFIG_RGB._1G2;
        break;
      case Test.LEAD.GREEN:
        configRgb = RGB[1] == Test.LEAD.RED || RGB[2] == Test.LEAD.BLUE ? Test.CONFIG_RGB._21G : Test.CONFIG_RGB._G12;
        break;
      case Test.LEAD.BLUE:
        configRgb = RGB[1] == Test.LEAD.RED || RGB[2] == Test.LEAD.GREEN ? Test.CONFIG_RGB._2G1 : Test.CONFIG_RGB._G21;
        break;
      default:
        switch (RGB[1])
        {
          case Test.LEAD.RED:
            configRgb = RGB[2] != Test.LEAD.GREEN ? Test.CONFIG_RGB._21G : Test.CONFIG_RGB._2G1;
            break;
          case Test.LEAD.GREEN:
            configRgb = RGB[2] != Test.LEAD.RED ? Test.CONFIG_RGB.MIN : Test.CONFIG_RGB._G21;
            break;
          case Test.LEAD.BLUE:
            configRgb = RGB[2] != Test.LEAD.RED ? Test.CONFIG_RGB._1G2 : Test.CONFIG_RGB._G12;
            break;
        }
        break;
    }
    return (Test.CONFIG) configRgb;
  }

  internal static Test.CONFIG ConfigSwap12(Test.CONFIG OriginalConfig)
  {
    Test.CONFIG_TRN configTrn = Test.CONFIG_TRN.NONE;
    switch (OriginalConfig)
    {
      case Test.CONFIG._1:
        configTrn = Test.CONFIG_TRN.N_CEB;
        break;
      case Test.CONFIG._2:
        configTrn = Test.CONFIG_TRN.N_CBE;
        break;
      case Test.CONFIG._3:
        configTrn = Test.CONFIG_TRN.MIN;
        break;
      case Test.CONFIG._4:
        configTrn = Test.CONFIG_TRN.N_BCE;
        break;
      case Test.CONFIG._5:
        configTrn = Test.CONFIG_TRN.N_EBC;
        break;
      case Test.CONFIG._6:
        configTrn = Test.CONFIG_TRN.N_BEC;
        break;
      case Test.CONFIG.Ps:
        configTrn = Test.CONFIG_TRN.P_CEB;
        break;
      case Test.CONFIG._8:
        configTrn = Test.CONFIG_TRN.P_CBE;
        break;
      case Test.CONFIG._9:
        configTrn = Test.CONFIG_TRN.Ps;
        break;
      case Test.CONFIG._10:
        configTrn = Test.CONFIG_TRN.P_BCE;
        break;
      case Test.CONFIG._11:
        configTrn = Test.CONFIG_TRN.P_EBC;
        break;
      case Test.CONFIG._12:
        configTrn = Test.CONFIG_TRN.P_BEC;
        break;
    }
    return (Test.CONFIG) configTrn;
  }

  public enum MODE : byte
  {
    NONE,
    DISPLAY,
    ANALOG_LOCAL,
    ANALOG_USB,
  }

  internal enum STATE : byte
  {
    IDLE = 0,
    TESTING = 1,
    TESTED = 2,
    ACK = 128, // 0x80
    IDLE_ACK = 128, // 0x80
    TESTING_ACK = 129, // 0x81
    TESTED_ACK = 130, // 0x82
  }

  public enum TON : byte
  {
    B_OFF = 0,
    C_OFF = 0,
    D_OFF = 0,
    E_OFF = 0,
    G_OFF = 0,
    Gt_OFF = 0,
    M1_OFF = 0,
    M2_OFF = 0,
    S_OFF = 0,
    E_ON = 1,
    M1_ON = 1,
    S_ON = 1,
    C_ON = 2,
    D_ON = 2,
    M2_ON = 2,
    B_ON = 4,
    G_ON = 4,
    Gt_ON = 4,
  }

  public enum DAC : byte
  {
    MT1,
    MT2,
    GATE,
  }

  [StructLayout(LayoutKind.Sequential, Size = 1)]
  public struct CONSTS
  {
    public const float BOOST_MAX_VOLTS = 15f;
    public const float BOOST_HEADROOM = 3f;
    public const float MIN_VOFFSET = 0.5f;
    public const float MAX_VOFFSET = 3f;
    public const float MAX_V = 12f;
    public const float MAX_CURRENT = 12f;
    public const byte DIODE_SETTLING_MS = 20;
    public const float TRN_VOFFSET = 0.5f;
  }

  public enum RGATE_IDX : byte
  {
    MIN = 1,
    _1k0 = 1,
    _8k2 = 2,
    _68k = 3,
    MAX = 4,
    _470k = 4,
  }

  public enum TYPE : byte
  {
    NONE,
    BJT,
    MOSFET,
    IGBT,
    SCR,
    TRIAC,
    DIODE,
    SHORT,
    JFET,
    VREG,
    LOWBAT,
    USBVFAIL,
  }

  public enum LEAD : byte
  {
    NONE,
    RED,
    GREEN,
    BLUE,
  }

  public enum TERMINAL : byte
  {
    NONE,
    MT1,
    MT2,
    GATE,
  }

  public enum SHORT : byte
  {
    NONE = 0,
    RED = 1,
    GREEN = 2,
    BLUE = 4,
  }

  public enum DRIVE : byte
  {
    NONE,
    MT1,
    MT2,
    GATE,
  }

  public enum CONFIG : byte
  {
    NONE = 0,
    _1 = 1,
    _2 = 2,
    _3 = 3,
    _4 = 4,
    _5 = 5,
    Ns = 6,
    _6 = 6,
    Ps = 7,
    _7 = 7,
    _8 = 8,
    _9 = 9,
    _10 = 10, // 0x0A
    _11 = 11, // 0x0B
    _12 = 12, // 0x0C
  }

  public enum CONFIG_RGB : byte
  {
    NONE = 0,
    MIN = 1,
    _12G = 1,
    _1G2 = 2,
    _21G = 3,
    _G12 = 4,
    _2G1 = 5,
    MAX = 6,
    _G21 = 6,
  }

  public enum CONFIG_PN : byte
  {
    NONE,
    KOA,
    KAO,
    OKA,
    AKO,
    OAK,
    AOK,
  }

  public enum CONFIG_TRN : byte
  {
    NONE = 0,
    MIN = 1,
    N_ECB = 1,
    N_EBC = 2,
    N_CEB = 3,
    N_BEC = 4,
    N_CBE = 5,
    N_BCE = 6,
    Ns = 6,
    P_ECB = 7,
    Ps = 7,
    P_EBC = 8,
    P_CEB = 9,
    P_BEC = 10, // 0x0A
    P_CBE = 11, // 0x0B
    MAX = 12, // 0x0C
    P_BCE = 12, // 0x0C
  }

  public enum CONFIG_SCR : byte
  {
    NONE = 0,
    KAG = 1,
    MIN = 1,
    KGA = 2,
    AKG = 3,
    GKA = 4,
    AGK = 5,
    GAK = 6,
    MAX = 6,
  }

  public enum DIODE_PATTERN : byte
  {
    CC1 = 3,
    CA1 = 5,
    SER1 = 6,
    EXTRA1 = 7,
    SER2 = 9,
    PAR2 = 10, // 0x0A
    CC2 = 12, // 0x0C
    EXTRA2 = 13, // 0x0D
    SER3 = 17, // 0x11
    CA2 = 18, // 0x12
    EXTRA3 = 19, // 0x13
    PAR3 = 20, // 0x14
    SER4 = 24, // 0x18
    EXTRA7 = 25, // 0x19
    PAR1 = 33, // 0x21
    SER5 = 34, // 0x22
    SER6 = 36, // 0x24
    EXTRA8 = 38, // 0x26
    CA3 = 40, // 0x28
    EXTRA6 = 44, // 0x2C
    CC3 = 48, // 0x30
    EXTRA5 = 50, // 0x32
    EXTRA4 = 56, // 0x38
    MASK = 63, // 0x3F
  }

  public enum DIODE : byte
  {
    NONE,
    PN,
    LED,
    DUAL_LED,
    ZENER,
    OTHER,
  }

  public enum DIODES
  {
    NONE,
    SINGLE,
    SER,
    CC,
    CA,
    SINGLE_ZENER,
    SINGLE_LED,
    RP_LED,
    CC_LED,
    CA_LED,
  }

  public enum BJTFlags : byte
  {
    Valid = 1,
    Digital = 2,
    DiodeProt = 4,
    Darlington = 8,
    NPN = 16, // 0x10
    Germanium = 32, // 0x20
    Silicon = 64, // 0x40
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct stResultBJT
  {
    public Test.CONFIG Config;
    public Test.BJTFlags Flags;
    public float IcLeak;
    public float Vbe;
    public float ViOff;
    public float Ib;
    public float IcOn;
    public float IcOff;
    public float HFE;
    public float Ic;
    public float VceSat;
    public float IcSat;
    public float IbSat;
    public float Rshunt;
    public float Rinput;
    public Test.RGATE_IDX RBRange;
  }

  public enum MOSFETFlags : byte
  {
    Valid = 1,
    NCh = 2,
    DepletionMode = 4,
    DiodeProt = 8,
    GateProt = 16, // 0x10
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct stResultMOSFET
  {
    public Test.CONFIG Config;
    public Test.MOSFETFlags Flags;
    public float Vgth;
    public float IdOn;
    public float IgOn;
    public float IdOn2;
    public float VgOff;
    public float IdOff;
    public float gm;
    public float VdsSat;
    public float IdSat;
    public float VgSat;
    public float Rds;
  }

  public enum IGBTFlags : byte
  {
    Valid = 1,
    NCh = 2,
    DepletionMode = 4,
    DiodeProt = 8,
    GateProt = 16, // 0x10
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct stResultIGBT
  {
    public Test.CONFIG Config;
    public Test.IGBTFlags Flags;
    public float Vgth;
    public float IcOn;
    public float IgOn;
    public float IcOn2;
    public float VgOff;
    public float IcOff;
    public float gfe;
    public float VceSat;
    public float IcSat;
    public float VgSat;
    public float Rds;
  }

  public enum JFETFlags : byte
  {
    Valid = 1,
    MirroredDS = 2,
    NCh = 4,
    NormallyOff = 8,
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct stResultJFET
  {
    public Test.CONFIG Config;
    public Test.JFETFlags Flags;
    public float VgsOff;
    public float IdOff;
    public float VgsOn;
    public float IdOn;
    public float IdOn2;
    public float gfs;
    public float Idzero;
    public float Vgszero;
    public float Vdszero;
    public float VgsSat;
    public float IgSat;
    public float Rds;
    public float IdRds;
  }

  public enum SCRFlags : byte
  {
    Valid = 1,
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct stResultSCR
  {
    public Test.CONFIG Config;
    public Test.SCRFlags Flags;
    public float ILeak;
    public float VLeak;
    public float Igt;
    public float Vgt;
    public float IaL;
    public float IgL;
    public float IaH;
    public float IaOn;
    public float VakOn;
    public float VgkOn;
  }

  public enum TriacFlags : byte
  {
    Valid = 1,
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct stResultTriac
  {
    public Test.CONFIG Config;
    public Test.TriacFlags Flags;
    public float Ileak;
    public float V12Hold;
    public float V1gHold;
    public float V2gHold;
  }

  public enum VRegFlags : byte
  {
    Valid = 1,
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct stResultVReg
  {
    public Test.CONFIG Config;
    public Test.VRegFlags Flags;
    public float VReg;
    public float IReg;
    public float Iq;
    public float Vdo;
    public float dVOut;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct stResultShort
  {
    public Test.SHORT Shorts;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct stResultDiode
  {
    public Test.DIODE Type;
    public Test.CONFIG Config;
    public float Vf;
    public float If;
    public float Vr;
    public float Ir;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct stResultDiodes
  {
    public byte Number;
    public Test.DIODE_PATTERN DiodePattern;
    public Test.stResultDiode Diode1;
    public Test.stResultDiode Diode2;
    public Test.stResultDiode Diode3;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct stResultDEBUG
  {
    public byte DEBUG00;
    public byte DEBUG01;
    public byte DEBUG02;
    public byte DEBUG03;
    public byte DEBUG04;
    public byte DEBUG05;
    public byte DEBUG06;
    public byte DEBUG07;
    public byte DEBUG08;
    public byte DEBUG09;
    public byte DEBUG10;
    public byte DEBUG11;
    public byte DEBUG12;
    public byte DEBUG13;
    public byte DEBUG14;
    public byte DEBUG15;
    public byte DEBUG16;
    public byte DEBUG17;
    public byte DEBUG18;
    public byte DEBUG19;
    public byte DEBUG20;
    public byte DEBUG21;
    public byte DEBUG22;
    public byte DEBUG23;
    public byte DEBUG24;
    public byte DEBUG25;
    public byte DEBUG26;
    public byte DEBUG27;
    public byte DEBUG28;
    public byte DEBUG29;
    public byte DEBUG30;
    public byte DEBUG31;
    public byte DEBUG32;
    public byte DEBUG33;
    public byte DEBUG34;
    public byte DEBUG35;
    public byte DEBUG36;
    public byte DEBUG37;
    public byte DEBUG38;
    public byte DEBUG39;
    public byte DEBUG40;
    public byte DEBUG41;
    public byte DEBUG42;
    public byte DEBUG43;
    public byte DEBUG44;
    public byte DEBUG45;
    public byte DEBUG46;
    public byte DEBUG47;
    public byte DEBUG48;
    public byte DEBUG49;
    public byte DEBUG50;
    public byte DEBUG51;
    public byte DEBUG52;
    public byte DEBUG53;
    public byte DEBUG54;
    public byte DEBUG55;
    public byte DEBUG56;
    public byte DEBUG57;
    public byte DEBUG58;
    public byte DEBUG59;
    public byte DEBUG60;
  }

  [StructLayout(LayoutKind.Explicit, Pack = 1)]
  public struct unResultDevice
  {
    [FieldOffset(0)]
    public Test.TYPE Type;
    [FieldOffset(1)]
    public Test.stResultMOSFET MOSFET;
    [FieldOffset(1)]
    public Test.stResultIGBT IGBT;
    [FieldOffset(1)]
    public Test.stResultJFET JFET;
    [FieldOffset(1)]
    public Test.stResultBJT BJT;
    [FieldOffset(1)]
    public Test.stResultSCR SCR;
    [FieldOffset(1)]
    public Test.stResultTriac Triac;
    [FieldOffset(1)]
    public Test.stResultDiodes Diodes;
    [FieldOffset(1)]
    public Test.stResultVReg VReg;
    [FieldOffset(1)]
    public Test.stResultShort Short;
    [FieldOffset(1)]
    public Test.stResultDEBUG DEBUG;
  }
}
