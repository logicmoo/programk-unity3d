// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.verwaltung.Lizenz
// Assembly: de.springwald.gaitobot.verwaltung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5FCF1B98-3BF2-4EFC-858C-87D71088B318
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.verwaltung.dll

using de.springwald.toolbox.Serialisierung;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace de.springwald.gaitobot.verwaltung
{
  [Serializable]
  public class Lizenz : IObjektSerialisierVerwaltbar
  {
    [XmlAttribute]
    public string ID { get; set; }

    public Lizenz.LizenzArten LizenzArt { get; set; }

    [XmlElement]
    public List<string> ZugeordneteChatbotIDs { get; set; }

    [XmlElement]
    public string BenutzerID { get; set; }

    [XmlElement]
    public int GueltigFuerWieVieleBots { get; set; }

    [XmlIgnore]
    public bool IstNochGueltig
    {
      get
      {
        return true;
      }
    }

    [XmlElement]
    public DateTime GueltigBis { get; set; }

    public Lizenz()
    {
      this.ZugeordneteChatbotIDs = new List<string>();
      this.GueltigFuerWieVieleBots = 1;
      this.GueltigBis = new DateTime(DateTime.UtcNow.Year + 10, 12, 31);
    }

    public enum LizenzArten
    {
      Free,
      Silver,
      Gold,
      Platinum,
    }
  }
}
