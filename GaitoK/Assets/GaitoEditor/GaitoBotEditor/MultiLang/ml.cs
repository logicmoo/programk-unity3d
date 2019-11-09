// Decompiled with JetBrains decompiler
// Type: MultiLang.ml
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;

namespace MultiLang
{
  internal class ml
  {
    private static string RootNamespace = "GaitoBotEditor";
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
