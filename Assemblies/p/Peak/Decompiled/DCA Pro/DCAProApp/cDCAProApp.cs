// Decompiled with JetBrains decompiler
// Type: DCAProApp.cDCAProApp
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System;
using System.Windows.Forms;

#nullable disable
namespace DCAProApp;

public class cDCAProApp
{
  [STAThread]
  public static void Main(string[] args)
  {
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);
    Application.Run((Form) new frmDCAProApp(args));
  }
}
