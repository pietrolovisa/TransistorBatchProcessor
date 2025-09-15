// Decompiled with JetBrains decompiler
// Type: DCAPro.stROMCalDataUInt32s
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System.Runtime.InteropServices;

#nullable disable
namespace DCAPro;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct stROMCalDataUInt32s
{
  internal uint RGate_1k0;
  internal uint RGate_8k2;
  internal uint RGate_68k;
  internal uint RGate_470k;
  internal uint RMT2;
  internal uint MT1_Gain;
  internal uint MT2_Gain;
  internal uint Gate_Gain;
  internal uint VRead_Gain;
  internal uint Offsets;
}
