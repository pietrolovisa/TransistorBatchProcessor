// Decompiled with JetBrains decompiler
// Type: DCAPro.stROMCalDataValues
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System.Runtime.InteropServices;

#nullable disable
namespace DCAPro;

[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct stROMCalDataValues
{
  internal float RGate_1k0;
  internal float RGate_8k2;
  internal float RGate_68k;
  internal float RGate_470k;
  internal float RMT2;
  internal float MT1_Gain;
  internal float MT2_Gain;
  internal float Gate_Gain;
  internal float VRead_Gain;
  internal sbyte MT1_Offset;
  internal sbyte MT2_Offset;
  internal sbyte Gate_Offset;
  internal sbyte VRead_Offset;
}
