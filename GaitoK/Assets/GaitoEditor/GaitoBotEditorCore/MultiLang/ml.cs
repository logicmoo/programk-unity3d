// Decompiled with JetBrains decompiler
// Type: MultiLang.ml
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace MultiLang
{
  internal class ml
  {
    private static string RootNamespace = "GaitoBotEditorCore";
    public static string[] SupportedCultures = new string[2]{ "de", "en" };
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
