// Decompiled with JetBrains decompiler
// Type: TD.SandDock.LayoutSettings
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.Configuration;

namespace TD.SandDock
{
  internal class LayoutSettings : ApplicationSettingsBase
  {
    public LayoutSettings(string key)
      : base(key)
    {
    }

    public override void Save()
    {
      this.IsDefault = false;
      base.Save();
    }

    [UserScopedSetting]
    public string LayoutXml
    {
      get
      {
        return (string) this[nameof (LayoutXml)];
      }
      set
      {
        this[nameof (LayoutXml)] = (object) value;
      }
    }

    [UserScopedSetting]
    [DefaultSettingValue("true")]
    public bool IsDefault
    {
      get
      {
        return (bool) this[nameof (IsDefault)];
      }
      set
      {
        this[nameof (IsDefault)] = (object) value;
      }
    }
  }
}
