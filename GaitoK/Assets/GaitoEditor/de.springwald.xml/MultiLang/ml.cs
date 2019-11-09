// Decompiled with JetBrains decompiler
// Type: MultiLang.ml
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace MultiLang
{
  internal class ml
  {
    private static string RootNamespace = "de.springwald.xml";
    public static string[] SupportedCultures = new string[1]{ "de" };
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
