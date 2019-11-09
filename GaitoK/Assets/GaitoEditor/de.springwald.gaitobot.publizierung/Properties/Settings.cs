// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.publizierung.Properties.Settings
// Assembly: de.springwald.gaitobot.publizierung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6410624A-016E-45EA-823B-136F27836F7E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.publizierung.dll

using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace de.springwald.gaitobot.publizierung.Properties
{
  [CompilerGenerated]
  [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
  internal sealed class Settings : ApplicationSettingsBase
  {
    private static Settings defaultInstance = (Settings) SettingsBase.Synchronized((SettingsBase) new Settings());

    public static Settings Default
    {
      get
      {
        Settings defaultInstance = Settings.defaultInstance;
        return defaultInstance;
      }
    }

    [ApplicationScopedSetting]
    [DebuggerNonUserCode]
    [SpecialSetting(SpecialSetting.WebServiceUrl)]
    [DefaultSettingValue("http://localhost:55387/gaitobot/Webservices/Publizieren.asmx")]
    public string de_springwald_gaitobot_publizierung_Gaitobot_de_publizieren_Publizieren
    {
      get
      {
        return (string) this[nameof (de_springwald_gaitobot_publizierung_Gaitobot_de_publizieren_Publizieren)];
      }
    }
  }
}
