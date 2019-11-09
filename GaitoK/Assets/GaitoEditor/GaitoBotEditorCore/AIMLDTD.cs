// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.AIMLDTD
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.xml.dtd;
using System.IO;
using System.Reflection;

namespace GaitoBotEditorCore
{
  public abstract class AIMLDTD
  {
    private static string _dtdInhalt;

    private static string DTDInhalt
    {
      get
      {
        if (AIMLDTD._dtdInhalt == null)
        {
          StreamReader streamReader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("GaitoBotEditorCore.Resources.aiml.dtd"));
          AIMLDTD._dtdInhalt = streamReader.ReadToEnd();
          streamReader.Close();
        }
        return AIMLDTD._dtdInhalt;
      }
    }

    public static DTD GetAIMLDTD()
    {
      return new DTDReaderDTD().GetDTDFromString(AIMLDTD.DTDInhalt);
    }
  }
}
