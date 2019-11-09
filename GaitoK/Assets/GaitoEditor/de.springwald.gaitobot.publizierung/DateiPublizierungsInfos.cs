// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.publizierung.DateiPublizierungsInfos
// Assembly: de.springwald.gaitobot.publizierung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6410624A-016E-45EA-823B-136F27836F7E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.publizierung.dll

using de.springwald.toolbox.file;
using System;
using System.IO;
using System.Xml.Serialization;

namespace de.springwald.gaitobot.publizierung
{
  [Serializable]
  public class DateiPublizierungsInfos
  {
    [XmlAttribute]
    public string Dateiname { get; set; }

    [XmlAttribute]
    public ulong CRC32Checksumme { get; set; }

    [XmlAttribute]
    public long Groesse { get; set; }

    [XmlAttribute]
    public string GesamtCheckString { get; set; }

    public void SetzeWerte(string dateinameMitPfad)
    {
      this.CRC32Checksumme = (ulong) new DateiChecksumme().GetCRC32(dateinameMitPfad);
      this.Groesse = new FileInfo(dateinameMitPfad).Length;
      this.GesamtCheckString = string.Format("{0}-{1}", (object) this.CRC32Checksumme, (object) this.Groesse);
      this.Dateiname = new FileInfo(dateinameMitPfad).Name;
    }
  }
}
