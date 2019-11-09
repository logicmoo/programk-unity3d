// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.LizenzManager
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using System;
using System.Windows.Forms;

namespace GaitoBotEditorCore
{
  public abstract class LizenzManager
  {
    private static bool _bereitsErmittelt = false;
    private static string _warumDarfProgrammNichtGestartetWerden = (string) null;
    private static LizenzManager.LizenzArten _lizenzArt;
    private static string _lizenziertAuf;

    public static string ProgrammName
    {
      get
      {
        return Application.ProductName;
      }
    }

    public static string ProgrammLizenzName
    {
      get
      {
        LizenzManager.LizenzErmitteln();
        return LizenzManager._lizenzArt.ToString();
      }
    }

    public static string ProgrammVersionNummerAnzeige
    {
      get
      {
        Version version = new Version(Application.ProductVersion);
        return string.Format("{0}.{1}.{2} B{3}", (object) version.Major, (object) version.Minor, (object) version.Build, (object) version.Revision);
      }
    }

    public static string LizenziertAuf
    {
      get
      {
        LizenzManager.LizenzErmitteln();
        return LizenzManager._lizenziertAuf;
      }
    }

    public static LizenzManager.LizenzArten Lizenz
    {
      get
      {
        LizenzManager.LizenzErmitteln();
        return LizenzManager._lizenzArt;
      }
    }

    public static string WarumDarfProgrammNichtGestartetWerden
    {
      get
      {
        LizenzManager.LizenzErmitteln();
        return LizenzManager._warumDarfProgrammNichtGestartetWerden;
      }
    }

    public static bool DarfProgrammUeberhauptGestartetWerden
    {
      get
      {
        return LizenzManager.WarumDarfProgrammNichtGestartetWerden == null;
      }
    }

    private static void LizenzErmitteln()
    {
      if (LizenzManager._bereitsErmittelt)
        return;
      LizenzManager._warumDarfProgrammNichtGestartetWerden = (string) null;
      LizenzManager._lizenziertAuf = "-";
      LizenzManager._lizenzArt = LizenzManager.LizenzArten.Standard;
    }

    public enum LizenzArten
    {
      Betaversion,
      Standard,
    }
  }
}
