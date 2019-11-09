// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLUndoSchrittNodeChanged
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System;
using System.Xml;

namespace de.springwald.xml.editor
{
  public class XMLUndoSchrittNodeChanged : XMLUndoSchritt
  {
    private XmlNode _geaenderterNode;
    private string _valueVorher;

    public XMLUndoSchrittNodeChanged(XmlNode geaenderterNode, string valueVorher)
    {
      this._geaenderterNode = geaenderterNode;
      this._valueVorher = valueVorher;
      if (geaenderterNode == null)
        throw new ApplicationException("Verändern des Nodes kann nicht für Undo vermerkt werden, da er NULL ist '" + this._geaenderterNode.OuterXml + "'");
    }

    public override void UnDo()
    {
      this._geaenderterNode.Value = this._valueVorher;
    }
  }
}
