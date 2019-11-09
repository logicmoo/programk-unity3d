// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLUndoSchrittNodeRemoved
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System;
using System.Xml;

namespace de.springwald.xml.editor
{
  public class XMLUndoSchrittNodeRemoved : XMLUndoSchritt
  {
    private XmlNode _geloeschterNode;
    private XmlNode _parentNode;
    private XmlNode _previousSibling;
    private XmlNode _nextSibling;

    public XMLUndoSchrittNodeRemoved(XmlNode nodeVorDemLoeschen)
    {
      this._geloeschterNode = nodeVorDemLoeschen;
      this._parentNode = nodeVorDemLoeschen.ParentNode;
      this._previousSibling = nodeVorDemLoeschen.PreviousSibling;
      this._nextSibling = nodeVorDemLoeschen.NextSibling;
      if (this._parentNode == null && this._previousSibling == null && this._nextSibling == null)
        throw new ApplicationException("Löschen des Nodes kann nicht für Undo vermerkt werden, da er keinen Bezug hat '" + nodeVorDemLoeschen.OuterXml + "'");
    }

    public override void UnDo()
    {
      if (this._previousSibling != null)
        this._previousSibling.ParentNode.InsertAfter(this._geloeschterNode, this._previousSibling);
      else if (this._nextSibling != null)
        this._nextSibling.ParentNode.InsertBefore(this._geloeschterNode, this._nextSibling);
      else
        this._parentNode.AppendChild(this._geloeschterNode);
    }
  }
}
