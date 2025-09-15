// Decompiled with JetBrains decompiler
// Type: DCAPro.WorkResult
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

#nullable disable
namespace DCAPro;

internal class WorkResult
{
  internal int Progress;
  internal ACT DoType;
  internal object Data;

  public WorkResult()
  {
    this.Progress = 0;
    this.DoType = ACT.IDLE;
    this.Data = (object) null;
  }

  public WorkResult Clone() => (WorkResult) this.MemberwiseClone();
}
