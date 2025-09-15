// Decompiled with JetBrains decompiler
// Type: DCAProApp.MyPanel
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System;
using System.Windows.Forms;

#nullable disable
namespace DCAProApp;

public class MyPanel : Panel
{
  protected override void OnSizeChanged(EventArgs e)
  {
    IntPtr handle = this.Handle;
    this.BeginInvoke((Delegate) (() => base.OnSizeChanged(e)));
  }
}
