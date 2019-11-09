// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLElement_Kommentar
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System.Drawing;
using System.Xml;

namespace de.springwald.xml.editor
{
  internal class XMLElement_Kommentar : XMLElement_TextNode
  {
    public XMLElement_Kommentar(XmlNode xmlNode, XMLEditor xmlEditor)
      : base(xmlNode, xmlEditor)
    {
    }

    protected override void FarbenSetzen()
    {
      this._farbeHintergrund_ = Color.LightGray;
      if (this._drawBrush_ != null)
        this._drawBrush_.Dispose();
      this._drawBrush_ = new SolidBrush(Color.Black);
      this._farbeHintergrundInvertiert_ = Color.Black;
      if (this._drawBrushInvertiert_ != null)
        this._drawBrushInvertiert_.Dispose();
      this._drawBrushInvertiert_ = new SolidBrush(Color.Gray);
      this._farbeHintergrundInvertiertOhneFokus_ = Color.Gray;
      if (this._drawBrushInvertiertOhneFokus_ != null)
        this._drawBrushInvertiertOhneFokus_.Dispose();
      this._drawBrushInvertiertOhneFokus_ = new SolidBrush(Color.LightGray);
    }
  }
}
