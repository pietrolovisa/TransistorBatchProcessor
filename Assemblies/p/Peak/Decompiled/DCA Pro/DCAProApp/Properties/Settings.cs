// Decompiled with JetBrains decompiler
// Type: DCAProApp.Properties.Settings
// Assembly: DCA Pro, Version=1.1.16.2446, Culture=neutral, PublicKeyToken=null
// MVID: B30FC952-F4AD-409C-88A2-0898085A21B1
// Assembly location: C:\Data\Source\Pietro\TransistorBatchProcessor\Assemblies\p\Peak\DCA Pro.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

#nullable disable
namespace DCAProApp.Properties;

[CompilerGenerated]
[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
internal sealed class Settings : ApplicationSettingsBase
{
  private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

  private void SettingChangingEventHandler(object sender, SettingChangingEventArgs e)
  {
  }

  private void SettingsSavingEventHandler(object sender, CancelEventArgs e)
  {
  }

  public static Settings Default => Settings.defaultInstance;

  [DefaultSettingValue("0021")]
  [ApplicationScopedSetting]
  [DebuggerNonUserCode]
  public string RequiredFWVersionNum => (string) this[nameof (RequiredFWVersionNum)];

  [DefaultSettingValue("0001")]
  [ApplicationScopedSetting]
  [DebuggerNonUserCode]
  public string RequiredProductType => (string) this[nameof (RequiredProductType)];

  [DebuggerNonUserCode]
  [DefaultSettingValue("True")]
  [UserScopedSetting]
  public bool CheckUpdates
  {
    get => (bool) this[nameof (CheckUpdates)];
    set => this[nameof (CheckUpdates)] = (object) value;
  }

  [DefaultSettingValue("1.0.0.0")]
  [UserScopedSetting]
  [DebuggerNonUserCode]
  public string IgnoredUpdate
  {
    get => (string) this[nameof (IgnoredUpdate)];
    set => this[nameof (IgnoredUpdate)] = (object) value;
  }

  [ApplicationScopedSetting]
  [DefaultSettingValue("DCAPro0021.hex")]
  [DebuggerNonUserCode]
  public string RequiredFWFile => (string) this[nameof (RequiredFWFile)];

  [DefaultSettingValue("http://www.peakelec.co.uk/downloads/dcaprosetup.exe")]
  [ApplicationScopedSetting]
  [DebuggerNonUserCode]
  public string UpdateFileLocation => (string) this[nameof (UpdateFileLocation)];

  [ApplicationScopedSetting]
  [DefaultSettingValue("http://www.peakelec.co.uk/acatalog/dca75_support.html")]
  [DebuggerNonUserCode]
  public string SupportPageLocation => (string) this[nameof (SupportPageLocation)];

  [DefaultSettingValue("http://www.peakelec.co.uk/dca75ver.txt")]
  [ApplicationScopedSetting]
  [DebuggerNonUserCode]
  public string VersionFileLocation => (string) this[nameof (VersionFileLocation)];
}
