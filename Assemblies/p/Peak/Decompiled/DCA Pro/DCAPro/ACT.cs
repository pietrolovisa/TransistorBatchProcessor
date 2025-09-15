// Decompiled with JetBrains decompiler
// Type: DCAPro.ACT
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

#nullable disable
namespace DCAPro;

internal enum ACT
{
  IDLE,
  IDENTIFY,
  GRAPH_PN,
  GRAPH_ICVCE,
  GRAPH_ICVBE,
  GRAPH_HFEIC,
  GRAPH_ICIB,
  GRAPH_HFEVCE,
  GRAPH_IDVDS,
  GRAPH_IDVGS,
  GRAPH_TICVCE,
  GRAPH_TICVGE,
  GRAPH_JIDVDS,
  GRAPH_JIDVGS,
  GRAPH_VREGOI,
  GRAB,
  BOOT_ENABLE,
  BOOT_GETFILE,
  BOOT_PROGRAM,
  BOOT_RESET,
  BOOT_PROGRAM_ERASE,
  BOOT_PROGRAM_PROG,
  CALIBRATE1,
  CALIBRATE2,
  CALCHECK1,
}
