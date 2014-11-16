// Decompiled with JetBrains decompiler
// Type: AddInSpy.Properties.Settings
// Assembly: AddInSpy, Version=1.5.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 348DAB18-01AB-4E5E-BAAD-807E7B0E72BC
// Assembly location: C:\Users\Jozef\Downloads\AddInSpy\AddInSpy.exe

using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace AddInSpy.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "9.0.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings settings = Settings.defaultInstance;
        return settings;
      }
    }
  }
}
