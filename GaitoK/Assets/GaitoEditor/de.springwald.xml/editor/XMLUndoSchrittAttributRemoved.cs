// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLUndoSchrittAttributRemoved
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System;
using System.Xml;

namespace de.springwald.xml.editor
{
  public class XMLUndoSchrittAttributRemoved : XMLUndoSchritt
  {
    private XmlAttribute _geloeschtesAttribut;
    private XmlNode _ownerElement;

    public XMLUndoSchrittAttributRemoved(XmlAttribute attributVorDemLoeschen)
    {
      this._geloeschtesAttribut = attributVorDemLoeschen;
      this._ownerElement = (XmlNode) attributVorDemLoeschen.OwnerElement;
      if (this._ownerElement == null)
        throw new ApplicationException("Löschen des Attributes kann nicht für Undo vermerkt werden, da es keinen Bezug hat '" + attributVorDemLoeschen.OuterXml + "'");
    }

    public override void UnDo()
    {
      this._ownerElement.Attributes.Append(this._geloeschtesAttribut);
    }
  }
}
