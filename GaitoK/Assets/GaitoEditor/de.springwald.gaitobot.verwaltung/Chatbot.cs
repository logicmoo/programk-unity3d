// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.verwaltung.Chatbot
// Assembly: de.springwald.gaitobot.verwaltung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5FCF1B98-3BF2-4EFC-858C-87D71088B318
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.verwaltung.dll

using de.springwald.toolbox.Serialisierung;
using MultiLang;
using System;
using System.Text;
using System.Xml.Serialization;

namespace de.springwald.gaitobot.verwaltung
{
  [Serializable]
  public class Chatbot : IObjektSerialisierVerwaltbar
  {
    private Random _rnd;

    [XmlIgnore]
    public bool NurHtml5DarstellerAnbieten
    {
      get
      {
        return this.DarstellerID.ToLower() == "linda" || this.DarstellerArt == Chatbot.DarstellerArten.Html5;
      }
    }

    [XmlAttribute]
    public string ID { get; set; }

    [XmlAttribute]
    public string DarstellerID { get; set; }

    [XmlAttribute]
    public string Html5DarstellerJsonSource { get; set; }

    [XmlAttribute]
    public string SprachausgabeId { get; set; }

    [XmlAttribute]
    public string Arbeitstitel { get; set; }

    [XmlAttribute]
    public string SendenButtonLabel { get; set; }

    [XmlAttribute]
    public string IhreEingabeLabel { get; set; }

    [XmlAttribute]
    public string GaitoBotEditorID { get; set; }

    [XmlElement]
    public string LizenzID { get; set; }

    [XmlElement]
    public bool IsPublic { get; set; }

    [XmlAttribute]
    public bool GespraechsProtokollPerEmail { get; set; }

    [XmlAttribute]
    public string BesitzerBenutzerID { get; set; }

    [XmlAttribute]
    public Chatbot.DarstellerArten DarstellerArt { get; set; }

    public string HTMLBackgroundColor { get; set; }

    public Chatbot()
    {
      this.Arbeitstitel = ml.ml_string(6, "kein Titel");
      this.GespraechsProtokollPerEmail = true;
      this.DarstellerID = "Linda";
      this.IsPublic = false;
      this.HTMLBackgroundColor = "FFFFFF";
      this.DarstellerArt = Chatbot.DarstellerArten.Flash;
      this.IhreEingabeLabel = "Your input";
      this.SendenButtonLabel = "Send";
    }

    public void ErzeugeGaitoBotEditorID()
    {
      if (this.ID == null)
        throw new ApplicationException(ml.ml_string(7, "Ohne vorhandene ID kann auch keine GaitoBotID ermittelt werden!"));
      this.GaitoBotEditorID = string.Format("{0}-{1}", (object) this.ID, (object) this.GetNeueChecksum()).ToUpper();
    }

    protected virtual void ZufallInitialisieren()
    {
      this._rnd = new Random(DateTime.UtcNow.Millisecond);
      for (int index = 0; index < DateTime.UtcNow.Minute; ++index)
        this._rnd.Next(DateTime.UtcNow.Second);
    }

    protected virtual string GetNeueChecksum()
    {
      this.ZufallInitialisieren();
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

    public enum DarstellerArten
    {
      Html5,
      Flash,
    }
  }
}
