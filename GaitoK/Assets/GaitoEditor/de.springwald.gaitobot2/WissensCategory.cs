// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.WissensCategory
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System.Xml;

namespace de.springwald.gaitobot2
{
  public class WissensCategory
  {
    private readonly MatchString _pattern;
    private readonly MatchString _that;
    private readonly XmlNode _categoryNode;
    private readonly string _themaName;
    private readonly string _aimlDateiName;

    public bool IstSrai { get; private set; }

    public XmlNode CategoryNode
    {
      get
      {
        return this._categoryNode;
      }
    }

    public MatchString Pattern
    {
      get
      {
        return this._pattern;
      }
    }

    public MatchString That
    {
      get
      {
        return this._that;
      }
    }

    public string ThemaName
    {
      get
      {
        return this._themaName;
      }
    }

    public string AIMLDateiname
    {
      get
      {
        return this._aimlDateiName;
      }
    }

    public WissensCategory(
      Normalisierung normalisierung,
      XmlNode categoryNode,
      string themaName,
      string aimlDateiName,
      GaitoBotEigenschaften botEigenschaften)
    {
      this._categoryNode = categoryNode;
      this._aimlDateiName = aimlDateiName;
      this._themaName = themaName;
      XmlNode inhaltNode1 = this._categoryNode.SelectSingleNode("pattern");
      this._pattern = inhaltNode1 == null ? new MatchString("*") : new MatchString(MatchString.GetInhaltFromXmlNode(inhaltNode1, normalisierung, botEigenschaften));
      XmlNode inhaltNode2 = this._categoryNode.SelectSingleNode("that");
      this._that = inhaltNode2 == null ? new MatchString("*") : new MatchString(MatchString.GetInhaltFromXmlNode(inhaltNode2, normalisierung, botEigenschaften));
      this.ErmittleObSRAICategory();
    }

    private void ErmittleObSRAICategory()
    {
      this.IstSrai = this._categoryNode.OuterXml.IndexOf("<srai>") != -1;
    }
  }
}
