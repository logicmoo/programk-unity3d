// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.publizierung.Gaitobot_de_publizieren.DateiPublizierungsInfos
// Assembly: de.springwald.gaitobot.publizierung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6410624A-016E-45EA-823B-136F27836F7E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.publizierung.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace de.springwald.gaitobot.publizierung.Gaitobot_de_publizieren
{
  [GeneratedCode("System.Xml", "4.0.30319.33440")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  [XmlType(Namespace = "de.gaitobot_de.webservices")]
  [Serializable]
  public class DateiPublizierungsInfos
  {
    private string dateinameField;
    private ulong cRC32ChecksummeField;
    private long groesseField;
    private string gesamtCheckStringField;

    [XmlAttribute]
    public string Dateiname
    {
      get
      {
        return this.dateinameField;
      }
      set
      {
        this.dateinameField = value;
      }
    }

    [XmlAttribute]
    public ulong CRC32Checksumme
    {
      get
      {
        return this.cRC32ChecksummeField;
      }
      set
      {
        this.cRC32ChecksummeField = value;
      }
    }

    [XmlAttribute]
    public long Groesse
    {
      get
      {
        return this.groesseField;
      }
      set
      {
        this.groesseField = value;
      }
    }

    [XmlAttribute]
    public string GesamtCheckString
    {
      get
      {
        return this.gesamtCheckStringField;
      }
      set
      {
        this.gesamtCheckStringField = value;
      }
    }
  }
}
