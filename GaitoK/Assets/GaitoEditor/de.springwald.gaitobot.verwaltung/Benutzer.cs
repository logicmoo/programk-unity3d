// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.verwaltung.Benutzer
// Assembly: de.springwald.gaitobot.verwaltung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5FCF1B98-3BF2-4EFC-858C-87D71088B318
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.verwaltung.dll

using de.springwald.toolbox.Serialisierung;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace de.springwald.gaitobot.verwaltung
{
  [Serializable]
  public class Benutzer : IObjektSerialisierVerwaltbar
  {
    private string _verzeichnisDiesesBenutzers;

    [XmlAttribute]
    public string ID { get; set; }

    [XmlIgnore]
    public string EMail
    {
      get
      {
        return this.ID;
      }
    }

    [XmlAttribute]
    public bool EmailBestaetigt { get; set; }

    [XmlAttribute]
    public string KennwortHash { get; set; }

    [XmlAttribute]
    public string KennwortSalt { get; set; }

    [XmlAttribute]
    public string Sprache { get; set; }

    [XmlElement]
    public Anschrift Anschrift { get; set; }

    [XmlArray]
    public List<string> ChatbotIDs { get; set; }

    [XmlArray]
    public List<string> LizenzIDs { get; set; }

    [XmlAttribute]
    public DateTime ErzeugungsZeitpunkt { get; set; }

    [XmlAttribute]
    public DateTime LetzterBesuch { get; set; }

    [XmlAttribute]
    public bool Newsletter { get; set; }

    public Benutzer()
    {
      this.ChatbotIDs = new List<string>();
      this.LizenzIDs = new List<string>();
      this.EmailBestaetigt = false;
      this.KennwortSalt = DateTime.UtcNow.Millisecond.ToString((IFormatProvider) CultureInfo.InvariantCulture);
    }

    public static string GetKennwortHash(string kennwort, string salt)
    {
      string TextToHash = string.Format("{0}#{1}", (object) kennwort, (object) salt);
      for (int index = 0; index < 100; ++index)
        TextToHash = Benutzer.GetMD5Hash(TextToHash);
      return TextToHash;
    }

    public static string GetMD5Hash(string TextToHash)
    {
      if (string.IsNullOrEmpty(TextToHash))
        return string.Empty;
      return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(TextToHash)));
    }
  }
}
