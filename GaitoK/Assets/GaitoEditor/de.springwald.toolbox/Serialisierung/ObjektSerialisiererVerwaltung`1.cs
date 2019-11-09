// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.Serialisierung.ObjektSerialisiererVerwaltung`1
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace de.springwald.toolbox.Serialisierung
{
  public class ObjektSerialisiererVerwaltung<objektTyp>
  {
    protected Random _rnd;

    protected string ObjektXMLVerzeichnis { get; set; }

    public virtual string[] AlleVorhandenenIDs
    {
      get
      {
        List<string> stringList = new List<string>();
        foreach (string file in Directory.GetFiles(this.ObjektXMLVerzeichnis, "chatbot.xml", SearchOption.AllDirectories))
        {
          char[] chArray = new char[1]{ '\\' };
          string[] strArray = file.Split(chArray);
          stringList.Add(strArray[strArray.Length - 2]);
        }
        return stringList.ToArray();
      }
    }

    public ObjektSerialisiererVerwaltung(string objektXMLVerzeichnis)
    {
      this.ObjektXMLVerzeichnis = objektXMLVerzeichnis;
      this.ZufallInitialisieren();
    }

    public bool ExistsID(string id)
    {
      if (string.IsNullOrEmpty(id))
        return false;
      return File.Exists(this.GetObjektDateiname(id));
    }

    public virtual string GetObjektDateiname(string id)
    {
      return Path.Combine(this.ObjektXMLVerzeichnis, string.Format("{0}.xml", (object) id));
    }

    public virtual string GetObjektBackupDateiname(string id, string kontextpostfix)
    {
      return Path.Combine(this.ObjektXMLVerzeichnis, string.Format("backup\\{0}_{1:s}_{2}.xml", (object) id, (object) DateTime.UtcNow, (object) kontextpostfix).Replace(":", "-"));
    }

    public virtual void SpeichereObjektToFile(
      objektTyp objekt,
      bool backup,
      string backupKontextpostfix)
    {
      this.IdWennNoetigVergeben(objekt);
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (objektTyp));
      StreamWriter text = File.CreateText(!backup ? this.GetObjektDateiname(((IObjektSerialisierVerwaltbar) (object) objekt).ID) : this.GetObjektBackupDateiname(((IObjektSerialisierVerwaltbar) (object) objekt).ID, backupKontextpostfix));
      xmlSerializer.Serialize((TextWriter) text, (object) objekt);
      text.Close();
    }

    public virtual void IdWennNoetigVergeben(objektTyp objekt)
    {
      if (((IObjektSerialisierVerwaltbar) (object) objekt).ID != null)
        return;
      ((IObjektSerialisierVerwaltbar) (object) objekt).ID = this.NaechsteFreieID();
    }

    public virtual objektTyp LadeObjektFromFile(
      string id,
      ObjektSerialisiererVerwaltung<objektTyp>.WasTunWennObjektNichtVorhanden wasTunWennObjektNichtVorhanden)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (objektTyp));
      string objektDateiname = this.GetObjektDateiname(id);
      if (!File.Exists(objektDateiname))
      {
        switch (wasTunWennObjektNichtVorhanden)
        {
          case ObjektSerialisiererVerwaltung<objektTyp>.WasTunWennObjektNichtVorhanden.FehlerWerfen:
            throw new ApplicationException("Objekt-Datei '" + objektDateiname + "' nicht vorhanden!");
          case ObjektSerialisiererVerwaltung<objektTyp>.WasTunWennObjektNichtVorhanden.NullZurueckgeben:
            return default (objektTyp);
          default:
            throw new ApplicationException("Unbehandelter WasTunWennObjektNichtVorhanden-Zustand '" + (object) wasTunWennObjektNichtVorhanden + "' nicht vorhanden!");
        }
      }
      else
      {
        StreamReader streamReader = File.OpenText(objektDateiname);
        objektTyp objektTyp = (objektTyp) xmlSerializer.Deserialize((TextReader) streamReader);
        streamReader.Close();
        return objektTyp;
      }
    }

    protected virtual string NaechsteFreieID()
    {
      string neueId = this.GetNeueID();
      while (this.ExistsID(neueId))
        neueId = this.GetNeueID();
      return neueId.ToString();
    }

    protected virtual void ZufallInitialisieren()
    {
      this._rnd = new Random(DateTime.UtcNow.Millisecond);
      for (int index = 0; index < DateTime.UtcNow.Minute; ++index)
        this._rnd.Next(DateTime.UtcNow.Second);
    }

    protected virtual string GetNeueID()
    {
      char[] chArray = new char[27]
      {
        'A',
        'C',
        'D',
        'E',
        'F',
        'G',
        'H',
        'K',
        'L',
        'P',
        'Q',
        'R',
        'S',
        'T',
        'U',
        'V',
        'W',
        'X',
        'Y',
        'Z',
        '2',
        '3',
        '4',
        '5',
        '6',
        '7',
        '9'
      };
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < 10; ++index)
      {
        char ch = chArray[this._rnd.Next(0, chArray.Length - 1)];
        stringBuilder.Append(ch);
      }
      return stringBuilder.ToString();
    }

    public enum WasTunWennObjektNichtVorhanden
    {
      FehlerWerfen,
      NullZurueckgeben,
    }
  }
}
