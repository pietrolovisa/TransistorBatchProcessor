// Decompiled with JetBrains decompiler
// Type: DCAPro.stROMCalData
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System.Runtime.InteropServices;

#nullable disable
namespace DCAPro;

[StructLayout(LayoutKind.Explicit, Pack = 1)]
internal struct stROMCalData
{
  [FieldOffset(0)]
  internal stROMCalDataValues Values;
  [FieldOffset(0)]
  internal stROMCalDataUInt32s UInt32s;
}
