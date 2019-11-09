// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLUndoSchrittNodeInserted
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System;
using System.Xml;

namespace de.springwald.xml.editor
{
  public class XMLUndoSchrittNodeInserted : XMLUndoSchritt
  {
    private XmlNode _eingefuegterNode;
    private XmlNode _parentNode;

    public XMLUndoSchrittNodeInserted(XmlNode eingefuegterNode, XmlNode parentNode)
    {
      this._eingefuegterNode = eingefuegterNode;
      this._parentNode = parentNode;
      if (eingefuegterNode == null)
        throw new ApplicationException("Einfügen des Nodes kann nicht für Undo vermerkt werden, da er NULL ist '" + this._eingefuegterNode.OuterXml + "'");
    }

    public override void UnDo()
    {
      if (this._eingefuegterNode is XmlAttribute)
        this._parentNode.Attributes.Remove((XmlAttribute) this._eingefuegterNode);
      else
        this._parentNode.RemoveChild(this._eingefuegterNode);
    }
  }
}
