// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.ResReader
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.toolbox;
using System.Reflection;

namespace de.springwald.xml
{
  public class ResReader
  {
    private static string _ressourcenDatei = "de.springwald.xml.Resources.xml";
    private static RessourcenReader _reader = new RessourcenReader(ResReader._ressourcenDatei, Assembly.GetExecutingAssembly());

    public static RessourcenReader Reader
    {
      get
      {
        return ResReader._reader;
      }
    }
  }
}
