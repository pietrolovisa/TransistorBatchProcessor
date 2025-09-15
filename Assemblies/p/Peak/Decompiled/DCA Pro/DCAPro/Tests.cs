// Decompiled with JetBrains decompiler
// Type: DCAPro.Tests
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System;

#nullable disable
namespace DCAPro;

internal class Tests
{
  private DCAProUnit thisDCAPro;

  public Tests(DCAProUnit Parent) => this.thisDCAPro = Parent;

  internal bool IdentifyTests()
  {
    try
    {
      int num = (int) this.thisDCAPro.InitiateTest();
      return false;
    }
    catch (Exception ex)
    {
      throw;
    }
  }
}
