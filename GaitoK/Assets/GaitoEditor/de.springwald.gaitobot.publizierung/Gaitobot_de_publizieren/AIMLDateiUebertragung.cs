// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.publizierung.Gaitobot_de_publizieren.AIMLDateiUebertragung
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
  public class AIMLDateiUebertragung
  {
    private string inhaltField;
    private string checkStringField;
    private string dateinameField;

    public string Inhalt
    {
      get
      {
        return this.inhaltField;
      }
      set
      {
        this.inhaltField = value;
      }
    }

    public string CheckString
    {
      get
      {
        return this.checkStringField;
      }
      set
      {
        this.checkStringField = value;
      }
    }

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
  }
}
