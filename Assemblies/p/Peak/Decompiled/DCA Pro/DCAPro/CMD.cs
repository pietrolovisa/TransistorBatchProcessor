// Decompiled with JetBrains decompiler
// Type: DCAPro.CMD
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace DCAPro;

internal class CMD
{
  public const int BUFFER_SIZE = 64 /*0x40*/;
  public const byte SERIAL_NUM_LEN = 6;
  internal const byte CAL_WRITE = 92;

  internal static byte[] ObjectToByteArray(CMD.unCommand Obj)
  {
    try
    {
      byte[] byteArray = new byte[Marshal.SizeOf((object) Obj.CmdRawBytes)];
      GCHandle gcHandle = GCHandle.Alloc((object) byteArray, GCHandleType.Pinned);
      Marshal.StructureToPtr((object) Obj.CmdRawBytes, gcHandle.AddrOfPinnedObject(), false);
      gcHandle.Free();
      return byteArray;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  internal static CMD.unCommand ByteArrayToObject(byte[] Arry)
  {
    try
    {
      CMD.unCommand unCommand = new CMD.unCommand();
      GCHandle gcHandle = GCHandle.Alloc((object) Arry, GCHandleType.Pinned);
      unCommand.CmdRawBytes = (CMD.strCmdRawBytes) Marshal.PtrToStructure(gcHandle.AddrOfPinnedObject(), unCommand.CmdRawBytes.GetType());
      gcHandle.Free();
      return unCommand;
    }
    catch (Exception ex)
    {
      throw;
    }
  }

  public enum TYPE : byte
  {
    SERIAL = 130, // 0x82
    ADCS = 131, // 0x83
    CAL = 132, // 0x84
    TEST = 133, // 0x85
    STATE = 134, // 0x86
    LOCK = 135, // 0x87
    BOOTL = 136, // 0x88
    MESSAGE = 137, // 0x89
    BOOST = 138, // 0x8A
    BOOSTED = 139, // 0x8B
    BOOSTOFF = 140, // 0x8C
    LEADSAFE = 141, // 0x8D
    RGATE = 142, // 0x8E
    VOLTS = 143, // 0x8F
    ALLVOLTS = 144, // 0x90
    MATRIXRGB = 145, // 0x91
    MATRIXPLUS = 146, // 0x92
    MODE = 147, // 0x93
    CCGATE = 148, // 0x94
    CVGATE = 149, // 0x95
    CNTRST = 150, // 0x96
  }

  public enum TEST : byte
  {
    TEST = 1,
    READ = 2,
    WRITE = 3,
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmd
  {
    public CMD.TYPE Type;
    public byte Status;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdUChar
  {
    public CMD.TYPE Type;
    public byte Status;
    public byte Data;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdUShort
  {
    public CMD.TYPE Type;
    public byte Status;
    public ushort Data;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdFloat
  {
    public CMD.TYPE Type;
    public byte Status;
    public float Data;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdState
  {
    public CMD.TYPE Type;
    public byte Status;
    public Test.STATE State;
    public ushort HardType;
    public ushort FirmType;
    public ushort Serial1;
    public ushort Serial2;
    public ushort Serial3;
    public ushort Serial4;
    public ushort Serial5;
    public ushort Serial6;
    public float RMT2;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct stBitChar
  {
    public byte Byte;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdRADCS
  {
    public CMD.TYPE Type;
    public byte Status;
    public CMD.stBitChar ADCReq_Direct;
    public CMD.stBitChar ADCReq_Muxed;
    public CORE.REQBIT_M ADCBurst_Muxed;
    public float VBatt;
    public float BTest;
    public float V12V;
    public float VPrereg;
    public float VRef;
    public float VSetGate;
    public float VGate;
    public float VSetMT1;
    public float VSetMT2;
    public float VMT2;
    public float VRed;
    public float VGreen;
    public float VBlue;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct strCmdCAL
  {
    internal CMD.TYPE Type;
    internal byte Status;
    internal stROMCalData ROMCalData;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct strCmdSerial
  {
    internal CMD.TYPE Type;
    internal byte Status;
    internal stROMSerial ROMSerial;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdWVolts
  {
    public CMD.TYPE Type;
    public byte Status;
    public float Volts;
    public Test.DAC Channel;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdWAllVolts
  {
    public CMD.TYPE Type;
    public byte Status;
    public float MT1Volts;
    public float MT2Volts;
    public float GateVolts;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdWSetMatrixRGB
  {
    public CMD.TYPE Type;
    public byte Status;
    public byte Red;
    public byte Green;
    public byte Blue;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdWSetMatrixP
  {
    public CMD.TYPE Type;
    public byte Status;
    public Test.CONFIG MXConfig;
    public Test.TON SOnDOnGOn;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdGateRes
  {
    public CMD.TYPE Type;
    public byte Status;
    public Test.RGATE_IDX RIndex;
    public float Resistance;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdCCGate
  {
    public CMD.TYPE Type;
    public byte Status;
    public CORE.CxMODE Mode;
    public float Current;
    public ushort Timeout;
    public CORE.CxSTATE State;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdCVGate
  {
    public CMD.TYPE Type;
    public byte Status;
    public CORE.CxMODE Mode;
    public Test.CONFIG Config;
    public float Voltage;
    public ushort Timeout;
    public CORE.CxSTATE State;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdResult
  {
    public CMD.TYPE Type;
    public CMD.TEST Status;
    public Test.unResultDevice Result;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  public struct strCmdRawBytes
  {
    public unsafe fixed byte Bytes[64];
  }

  [StructLayout(LayoutKind.Explicit, Size = 64 /*0x40*/, Pack = 1)]
  internal struct unCommand
  {
    [FieldOffset(0)]
    internal CMD.strCmd Cmd;
    [FieldOffset(0)]
    internal CMD.strCmdUChar CmdUChar;
    [FieldOffset(0)]
    internal CMD.strCmdUShort CmdUShort;
    [FieldOffset(0)]
    internal CMD.strCmdFloat CmdFloat;
    [FieldOffset(0)]
    internal CMD.strCmdState CmdState;
    [FieldOffset(0)]
    internal CMD.strCmdRADCS CmdRADCS;
    [FieldOffset(0)]
    internal CMD.strCmdCAL CmdCAL;
    [FieldOffset(0)]
    internal CMD.strCmdSerial CmdSerial;
    [FieldOffset(0)]
    internal CMD.strCmdWVolts CmdWVolts;
    [FieldOffset(0)]
    internal CMD.strCmdWAllVolts CmdWAllVolts;
    [FieldOffset(0)]
    internal CMD.strCmdWSetMatrixRGB CmdWSetMatrixRGB;
    [FieldOffset(0)]
    internal CMD.strCmdWSetMatrixP CmdWSetMatrixP;
    [FieldOffset(0)]
    internal CMD.strCmdGateRes CmdWGateRes;
    [FieldOffset(0)]
    internal CMD.strCmdCCGate CmdWCCGate;
    [FieldOffset(0)]
    internal CMD.strCmdCVGate CmdWCVGate;
    [FieldOffset(0)]
    internal CMD.strCmdResult CmdResult;
    [FieldOffset(0)]
    internal CMD.strCmdRawBytes CmdRawBytes;
  }
}
