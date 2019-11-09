// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.content.ContentElementInfo
// Assembly: de.springwald.gaitobot.content, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6ABB4B8A-B628-46F2-B20D-382FD07DEF81
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.content.dll

using de.springwald.toolbox.Serialisierung;
using System;
using System.Xml.Serialization;

namespace de.springwald.gaitobot.content
{
  [Serializable]
  public class ContentElementInfo
  {
    [XmlElement]
    public bool ReadOnly { get; set; }

    [XmlElement]
    public bool NurFuerGaitoBotExportieren { get; set; }

    [XmlElement]
    public string UniqueKey { get; set; }

    [XmlElement]
    public string SortKey { get; set; }

    [XmlElement]
    public string Beschreibung { get; set; }

    [XmlElement]
    public string Name { get; set; }

    [XmlElement]
    public string DateiPattern { get; set; }

    [XmlArray]
    public string[] AbhaengigkeitenUniqueIds { get; set; }

    public ContentElementInfo()
    {
      this.UniqueKey = Guid.NewGuid().ToString();
      this.AbhaengigkeitenUniqueIds = new string[0];
    }

    public static ContentElementInfo ReadFromXmlString(string xml)
    {
      return GenericSerializationHelperClass<ContentElementInfo>.FromXml(xml, false);
    }

    public static ContentElementInfo ReadFromFile(string dateiname)
    {
      return GenericSerializationHelperClass<ContentElementInfo>.FromXmlFile(dateiname, false);
    }

    public void WriteToFile(string dateiname)
    {
      GenericSerializationHelperClass<ContentElementInfo>.ToXmlFile(this, dateiname, false);
    }
  }
}
