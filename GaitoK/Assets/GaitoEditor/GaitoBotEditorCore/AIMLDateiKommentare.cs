// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.AIMLDateiKommentare
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using System.Xml;

namespace GaitoBotEditorCore
{
  internal class AIMLDateiKommentare
  {
    private XmlDocument _xmlDoc;

    public AIMLDateiKommentare(XmlDocument xmlDoc)
    {
      this._xmlDoc = xmlDoc;
    }

    public void SchreibeKommentarEintrag(string name, string wert)
    {
      this.GetKommentarNode(name, true).Value = string.Format("{0}: {1}", (object) name, (object) wert);
    }

    private XmlComment GetKommentarNode(string name, bool erzeugenWennNichtVorhanden)
    {
      foreach (XmlNode childNode in this._xmlDoc.DocumentElement.ChildNodes)
      {
        if (childNode is XmlComment && childNode.Value.Contains(string.Format("{0}: ", (object) name)))
          return (XmlComment) childNode;
      }
      if (!erzeugenWennNichtVorhanden)
        return (XmlComment) null;
      XmlComment comment = this._xmlDoc.CreateComment(string.Format("{0}: ", (object) name));
      if (this._xmlDoc.DocumentElement.FirstChild == null)
        this._xmlDoc.DocumentElement.AppendChild((XmlNode) comment);
      else
        this._xmlDoc.DocumentElement.InsertBefore((XmlNode) comment, this._xmlDoc.DocumentElement.FirstChild);
      return comment;
    }
  }
}
