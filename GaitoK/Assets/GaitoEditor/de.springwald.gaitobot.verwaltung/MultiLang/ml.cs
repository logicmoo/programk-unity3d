// Decompiled with JetBrains decompiler
// Type: MultiLang.ml
// Assembly: de.springwald.gaitobot.verwaltung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5FCF1B98-3BF2-4EFC-858C-87D71088B318
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.verwaltung.dll

using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace MultiLang
{
  internal class ml
  {
    private static string RootNamespace = "de.springwald.gaitobot.verwaltung";
    public static string[] SupportedCultures = new string[2]
    {
      "de",
      "en"
    };
    private static ResourceManager ResMgr = new ResourceManager(ml.RootNamespace + ".MultiLang", Assembly.GetExecutingAssembly());

    public static void ml_UseCulture(CultureInfo ci)
    {
      Thread.CurrentThread.CurrentUICulture = ci;
    }

    public static string ml_string(int StringID, string Text)
    {
      return ml.ml_resource(StringID);
    }

    public static string ml_resource(int StringID)
    {
      return ml.ResMgr.GetString("_" + StringID.ToString());
    }
  }
}
