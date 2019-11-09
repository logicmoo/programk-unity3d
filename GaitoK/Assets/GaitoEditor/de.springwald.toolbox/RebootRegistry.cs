// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.RebootRegistry
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using Microsoft.Win32;
using System;

namespace de.springwald.toolbox
{
  public class RebootRegistry
  {
    private static DateTime _letzteStarterMeldung;

    public static void RegelmaessigMelden()
    {
      if ((DateTime.UtcNow - RebootRegistry._letzteStarterMeldung).TotalSeconds <= 20.0)
        return;
      RebootRegistry._letzteStarterMeldung = DateTime.UtcNow;
      RebootRegistry.SetzeRegKey("Lebenszeichen", DateTime.UtcNow.ToBinary().ToString());
    }

    public static RegistryKey ConfigRegistryKey()
    {
      return Registry.CurrentUser.CreateSubKey("Software\\Springwald\\Game");
    }

    public static string ErmittleRegKey(string keyname, string vorgabeWennLeer)
    {
      RegistryKey registryKey = RebootRegistry.ConfigRegistryKey();
      string str = (string) null;
      try
      {
        str = (string) registryKey.GetValue(keyname, (object) vorgabeWennLeer);
      }
      finally
      {
        if (registryKey != null)
          registryKey.Close();
      }
      return str;
    }

    public static void SetzeRegKey(string keyname, string inhalt)
    {
      RegistryKey registryKey = RebootRegistry.ConfigRegistryKey();
      try
      {
        registryKey.SetValue(keyname, (object) inhalt);
      }
      finally
      {
        if (registryKey != null)
          registryKey.Close();
      }
    }
  }
}
