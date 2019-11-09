// Decompiled with JetBrains decompiler
// Type: GaitoBotEditor.ResReader
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using de.springwald.toolbox;
using System.Reflection;

namespace GaitoBotEditor
{
  public class ResReader
  {
    private static string _ressourcenDatei = "GaitoBotEditor.Resources.GaitoBotEditor";
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
