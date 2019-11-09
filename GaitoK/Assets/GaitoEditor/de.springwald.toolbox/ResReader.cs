// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.ResReader
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System.Reflection;

namespace de.springwald.toolbox
{
  public abstract class ResReader
  {
    private static string _ressourcenDatei = "de.springwald.toolbox.Resources.xml";
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
