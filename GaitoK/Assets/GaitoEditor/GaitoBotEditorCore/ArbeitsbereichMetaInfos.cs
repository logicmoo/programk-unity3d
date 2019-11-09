// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.ArbeitsbereichMetaInfos
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.gaitobot.content;
using System;
using System.IO;
using System.Xml.Serialization;

namespace GaitoBotEditorCore
{
  [Serializable]
  public class ArbeitsbereichMetaInfos
  {
    private string[] _contentElementUniqueIds;
    private string[] _nichtExportierenDateinamen;
    private string _name;
    private string _gaitoBotID;
    private string _exportVerzeichnis;
    private bool _exportVerzeichnisVorExportLeeren;
    private bool _alleStarTagsInExtraDateiExportieren;

    public event EventHandler Changed;

    protected virtual void ChangedEvent()
    {
      if (this.Changed == null)
        return;
      this.Changed((object) this, EventArgs.Empty);
    }

    [XmlArray]
    public string[] ContentElementUniqueIds
    {
      get
      {
        return this._contentElementUniqueIds;
      }
      set
      {
        this._contentElementUniqueIds = value;
        this.ChangedEvent();
      }
    }

    [XmlArray]
    public string[] NichtExportierenDateinamen
    {
      get
      {
        return this._nichtExportierenDateinamen;
      }
      set
      {
        this._nichtExportierenDateinamen = value;
        this.ChangedEvent();
      }
    }

    [XmlElement]
    public string Name
    {
      get
      {
        return this._name;
      }
      set
      {
        this._name = value;
        this.ChangedEvent();
      }
    }

    [XmlElement]
    public string GaitoBotID
    {
      get
      {
        return this._gaitoBotID;
      }
      set
      {
        this._gaitoBotID = value;
        this.ChangedEvent();
      }
    }

    [XmlElement]
    public string Exportverzeichnis
    {
      get
      {
        return this._exportVerzeichnis;
      }
      set
      {
        this._exportVerzeichnis = value;
        this.ChangedEvent();
      }
    }

    [XmlElement]
    public bool ExportverzeichnisVorExportLeeren
    {
      get
      {
        return this._exportVerzeichnisVorExportLeeren;
      }
      set
      {
        this._exportVerzeichnisVorExportLeeren = value;
        this.ChangedEvent();
      }
    }

    [XmlElement]
    public bool AlleStarTagsInExtraDateiExportieren
    {
      get
      {
        return this._alleStarTagsInExtraDateiExportieren;
      }
      set
      {
        this._alleStarTagsInExtraDateiExportieren = value;
        this.ChangedEvent();
      }
    }

    public ArbeitsbereichMetaInfos()
    {
      ContentManager contentManager = new ContentManager();
      this.GaitoBotID = string.Empty;
      this.NichtExportierenDateinamen = new string[0];
      this.ContentElementUniqueIds = new string[0];
      this.ExportverzeichnisVorExportLeeren = false;
      this.AlleStarTagsInExtraDateiExportieren = true;
      this.Name = ResReader.Reader.GetString("unbenannt");
      this.Exportverzeichnis = "C:\\AIML_EXPORT";
    }

    public static void SerialisiereInXMLDatei(string dateiname, ArbeitsbereichMetaInfos infos)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (ArbeitsbereichMetaInfos));
      StreamWriter text = File.CreateText(dateiname);
      xmlSerializer.Serialize((TextWriter) text, (object) infos);
      text.Close();
    }

    public static ArbeitsbereichMetaInfos DeSerialisiereAusXMLDatei(
      string dateiname)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (ArbeitsbereichMetaInfos));
      if (!File.Exists(dateiname))
        throw new ApplicationException("ArbeitsbereichMetaInfos-Datei '" + dateiname + "' nicht vorhanden!");
      StreamReader streamReader = File.OpenText(dateiname);
      ArbeitsbereichMetaInfos arbeitsbereichMetaInfos = (ArbeitsbereichMetaInfos) xmlSerializer.Deserialize((TextReader) streamReader);
      streamReader.Close();
      return arbeitsbereichMetaInfos;
    }
  }
}
