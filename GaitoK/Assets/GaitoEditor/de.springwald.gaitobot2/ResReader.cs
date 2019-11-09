// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.ResReader
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using de.springwald.toolbox;
using System.Globalization;
using System.Reflection;

namespace de.springwald.gaitobot2
{
  public static class ResReader
  {
    private static readonly RessourcenReader ReaderDe = new RessourcenReader("de.springwald.gaitobot2.Resources.gaitobot_de", Assembly.GetExecutingAssembly());
    private static readonly RessourcenReader ReaderNeutral = new RessourcenReader("de.springwald.gaitobot2.Resources.gaitobot", Assembly.GetExecutingAssembly());
    private const string RessourcenDateiDe = "de.springwald.gaitobot2.Resources.gaitobot_de";
    private const string RessourcenDatei = "de.springwald.gaitobot2.Resources.gaitobot";

    public static RessourcenReader Reader(CultureInfo culture)
    {
      if (culture != null && culture.ToString().ToLower() == "de")
        return ResReader.ReaderDe;
      return ResReader.ReaderNeutral;
    }
  }
}
