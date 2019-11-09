// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.verwaltung.Anschrift
// Assembly: de.springwald.gaitobot.verwaltung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5FCF1B98-3BF2-4EFC-858C-87D71088B318
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.verwaltung.dll

using System;
using System.Xml.Serialization;

namespace de.springwald.gaitobot.verwaltung
{
  [Serializable]
  public class Anschrift
  {
    public event EventHandler<EventArgs> Changed;

    protected virtual void ChangedEventWerfen()
    {
      if (this.Changed == null)
        return;
      this.Changed((object) this, new EventArgs());
    }

    [XmlElement]
    public string Anrede { set; get; }

    [XmlElement]
    public string Nachname { set; get; }

    [XmlElement]
    public string Vorname { set; get; }

    [XmlElement]
    public string Firma { set; get; }

    [XmlElement]
    public string Adresse { set; get; }

    [XmlElement]
    public string Adresszusatz { set; get; }

    [XmlElement]
    public string PLZ { set; get; }

    [XmlElement]
    public string Ort { set; get; }

    [XmlElement]
    public Anschrift.Laender Land { set; get; }

    [XmlElement]
    public string Bundesland { set; get; }

    [XmlElement]
    public string Telefon { set; get; }

    [XmlIgnore]
    public string GesamtAnrede
    {
      get
      {
        return string.Format("{0} {1}", (object) this.Anrede, (object) this.Nachname);
      }
    }

    public void AutoKorrektur()
    {
      string lower = this.Anrede.Trim().ToLower();
      if (!(lower == "herrn"))
      {
        if (!(lower == "fr"))
        {
          if (!(lower == "hr"))
          {
            if (!(lower == "mr"))
              return;
            this.Anrede = "Mister";
          }
          else
            this.Anrede = "Herr";
        }
        else
          this.Anrede = "Frau";
      }
      else
        this.Anrede = "Herr";
    }

    public enum Laender
    {
      ___,
      Australia,
      Austria,
      Belgium,
      Brazil,
      Canada,
      Chile,
      China,
      Channel_Islands,
      Croatia,
      Cyprus,
      Czech_Republic,
      Denmark,
      Deutschland,
      Egypt,
      Estonia,
      Finland,
      France,
      Great_Britain,
      Greece,
      Guatemala,
      Hungary,
      Iceland,
      India,
      Ireland,
      Israel,
      Italy,
      Japan,
      Latvia,
      Luxembourg,
      Malaysia,
      Mexico,
      Monaco,
      Netherlands,
      New_Zealand,
      Norway,
      Poland,
      Portugal,
      Russia,
      Slovak_Republic,
      Spain,
      Sweden,
      Switzerland,
      Taiwan,
      Thailand,
      Turkey,
      Ukraine,
      USA,
    }
  }
}
