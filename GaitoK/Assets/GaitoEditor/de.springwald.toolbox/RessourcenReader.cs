// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.RessourcenReader
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Text;

namespace de.springwald.toolbox
{
  public class RessourcenReader
  {
    private ResourceManager _manager;
    private string _sourceName;

    public string GetString(string key)
    {
      return (this._manager.GetString(key) ?? string.Format("ResNotFound:{0}({1})", (object) key, (object) this._sourceName)).Replace("\\n", "\n").Replace("\\\"", "\"");
    }

    public string GetRessourcenDateiInhalt(Assembly assembly, string ressourcenname)
    {
      Stream manifestResourceStream = assembly.GetManifestResourceStream(ressourcenname);
      if (manifestResourceStream == null)
        return string.Format("ResNotFound:{0}({1})", (object) ressourcenname, (object) this._sourceName);
      return new StreamReader(manifestResourceStream, Encoding.GetEncoding("ISO-8859-15")).ReadToEnd();
    }

    public string GetString(string key, CultureInfo culture)
    {
      return (this._manager.GetString(key, culture) ?? string.Format("ResNotFound:{0}({1})", (object) key, (object) this._sourceName)).Replace("\\n", "\n").Replace("\\\"", "\"");
    }

    public RessourcenReader(string resourceSource, Assembly assembly)
    {
      this._sourceName = resourceSource;
      this._manager = new ResourceManager(resourceSource, assembly);
    }
  }
}
