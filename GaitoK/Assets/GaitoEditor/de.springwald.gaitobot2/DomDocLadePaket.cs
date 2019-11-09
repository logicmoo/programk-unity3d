// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.DomDocLadePaket
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System.Xml;

namespace de.springwald.gaitobot2
{
  public class DomDocLadePaket
  {
    private readonly XmlDocument _doc;
    private readonly string _dateiname;

    public XmlDocument XmlDocument
    {
      get
      {
        return this._doc;
      }
    }

    public string Dateiname
    {
      get
      {
        return this._dateiname;
      }
    }

    public DomDocLadePaket(XmlDocument doc, string dateiname)
    {
      this._doc = doc;
      this._dateiname = dateiname;
    }
  }
}
