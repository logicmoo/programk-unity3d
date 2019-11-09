// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.Config
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using MultiLang;
using System;
using System.IO;
using System.Windows.Forms;

namespace GaitoBotEditorCore
{
  public class Config : ConfigDatei
  {
    private static Config _globalConfig;

    private string SpeicherVerzeichnisRoh
    {
      get
      {
        string path = this.getWert("SaveDirectory");
        if (path != null && !File.Exists(path))
          path = (string) null;
        if (path == null)
          this.setWert("SaveDirectory", !ToolboxSonstiges.IstEntwicklungsmodus ? "[MyDocuments]\\" + Application.ProductName : "[StartupPath]\\..\\..\\_Speichern_");
        return this.getWert("SaveDirectory");
      }
    }

    private string ArbeitsbereicheSpeicherVerzeichnisRoh
    {
      get
      {
        if (this.getWert("WorkspaceDirectory") == null)
          this.setWert("WorkspaceDirectory", this.SpeicherVerzeichnisRoh + "\\workspaces");
        return this.getWert("WorkspaceDirectory");
      }
    }

    public bool ErsteSchritteLaden
    {
      set
      {
        this.setWert(nameof (ErsteSchritteLaden), value);
      }
      get
      {
        return this.getWert(nameof (ErsteSchritteLaden), true);
      }
    }

    public bool AktuelleInfosLaden
    {
      set
      {
        this.setWert(nameof (AktuelleInfosLaden), value);
      }
      get
      {
        return this.getWert(nameof (AktuelleInfosLaden), false);
      }
    }

    public string ProgrammSprache
    {
      set
      {
        this.setWert("language", value);
      }
      get
      {
        return this.getWert("language", "");
      }
    }

    public string EULABestaetigtFuer
    {
      set
      {
        this.setWert("EulaAccepted", value);
      }
      get
      {
        return this.getWert("EulaAccepted");
      }
    }

    public string SpeicherVerzeichnis
    {
      get
      {
        string path = this.VerzeichnisNameAufbereitet(this.SpeicherVerzeichnisRoh);
        if (!Directory.Exists(path))
        {
          try
          {
            Directory.CreateDirectory(path);
          }
          catch (Exception ex)
          {
            throw new ApplicationException(string.Format(ResReader.Reader.GetString("VerzeichnisErstellungFehlgeschlagen"), (object) path, (object) ex));
          }
          finally
          {
          }
        }
        return path;
      }
    }

    public string ArbeitsbereicheSpeicherVerzeichnis
    {
      get
      {
        string path = this.VerzeichnisNameAufbereitet(this.ArbeitsbereicheSpeicherVerzeichnisRoh);
        if (!Directory.Exists(path))
        {
          try
          {
            Directory.CreateDirectory(path);
          }
          catch (Exception ex)
          {
            throw new ApplicationException(string.Format(ResReader.Reader.GetString("VerzeichnisErstellungFehlgeschlagen"), (object) path, (object) ex));
          }
          finally
          {
          }
        }
        return path;
      }
    }

    public string SupportEmailAdresse
    {
      get
      {
        return "support@springwald.de";
      }
    }

    public string SupportWebScriptURL
    {
      get
      {
        return "http://www.springwald.de/web/support/error.aspx";
      }
    }

    public string FeedbackEmailAdresse
    {
      get
      {
        return "support@springwald.de";
      }
    }

    public string FeedbackWebScriptURL
    {
      get
      {
        return "http://www.springwald.de/web/support/feedback.aspx";
      }
    }

    public Config(string dateiname)
      : base(dateiname)
    {
    }

    private static string ConfigDateiname
    {
      get
      {
        string path = !ToolboxSonstiges.IstEntwicklungsmodus ? Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), Application.ProductName) : Path.Combine(Application.StartupPath, "..\\..\\_Speichern_");
        if (!Directory.Exists(path))
        {
          try
          {
            Directory.CreateDirectory(path);
          }
          catch (Exception ex)
          {
            throw new ApplicationException(string.Format(ResReader.Reader.GetString("VerzeichnisErstellungFehlgeschlagen"), (object) path, (object) ex));
          }
          finally
          {
          }
        }
        return path + "\\config.xml";
      }
    }

    public static Config GlobalConfig
    {
      get
      {
        if (Config._globalConfig == null)
          Config._globalConfig = new Config(Config.ConfigDateiname);
        return Config._globalConfig;
      }
    }

    public string URLAktuelleInformationen
    {
      get
      {
        return this.NewsWebAdresse();
      }
    }

    public string URLErsteSchritte
    {
      get
      {
        return this.WebDokumentAdresse("firststeps");
      }
    }

    public string URLHandbuch
    {
      get
      {
        return this.WebDokumentAdresse("manual");
      }
    }

    public string URLNochKeineGaitoBotID
    {
      get
      {
        return this.WebGoAdresse("keineGaitobotID");
      }
    }

    private string NewsWebAdresse()
    {
      return ml.ml_string(77, "http://www.gaitobot.de/gaitobot/EditorDocuments/news_de.aspx");
    }

    private string WebGoAdresse(string goName)
    {
      Version version = new Version(Application.ProductVersion);
      return string.Format(ResReader.Reader.GetString(nameof (WebGoAdresse)), (object) version.Major, (object) version.Minor, (object) version.Revision, (object) LizenzManager.ProgrammLizenzName, (object) goName);
    }

    private string WebDokumentAdresse(string dokumentKennung)
    {
      Version version = new Version(Application.ProductVersion);
      return string.Format(ResReader.Reader.GetString(nameof (WebDokumentAdresse)), (object) version.Major, (object) version.Minor, (object) version.Revision, (object) LizenzManager.ProgrammLizenzName, (object) dokumentKennung);
    }
  }
}
