// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.StartupDateiDtd
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.xml.dtd;
using System.IO;
using System.Reflection;

namespace GaitoBotEditorCore
{
  internal class StartupDateiDtd
  {
    private static string _dtdInhalt;

    private static string DTDInhalt
    {
      get
      {
        if (StartupDateiDtd._dtdInhalt == null)
        {
          StreamReader streamReader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream("GaitoBotEditorCore.Resources.startup.dtd"));
          StartupDateiDtd._dtdInhalt = streamReader.ReadToEnd();
          streamReader.Close();
        }
        return StartupDateiDtd._dtdInhalt;
      }
    }

    public static DTD GetStartupDtd()
    {
      return new DTDReaderDTD().GetDTDFromString(StartupDateiDtd.DTDInhalt);
    }
  }
}
