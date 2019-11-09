// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.dtd.DTD
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace de.springwald.xml.dtd
{
  public class DTD
  {
    private List<DTDElement> _elemente;
    private Hashtable _elementeNachNamen;
    private List<DTDEntity> _entities;

    public List<DTDElement> Elemente
    {
      get
      {
        return this._elemente;
      }
    }

    public List<DTDEntity> Entities
    {
      get
      {
        return this._entities;
      }
    }

    public DTD(List<DTDElement> elemente, List<DTDEntity> entities)
    {
      this._elemente = elemente;
      this._entities = entities;
      this._elementeNachNamen = new Hashtable();
    }

    public DTD()
    {
    }

    public bool IstDTDElementBekannt(string elementName)
    {
      return this.DTDElementByNameIntern_(elementName, false) != null;
    }

    public DTDElement DTDElementByNode_(XmlNode node, bool fehlerWennNichtVorhanden)
    {
      return this.DTDElementByNameIntern_(DTD.GetElementNameFromNode(node), fehlerWennNichtVorhanden);
    }

    public DTDElement DTDElementByName(string elementName, bool fehlerWennNichtVorhanden)
    {
      return this.DTDElementByNameIntern_(elementName, fehlerWennNichtVorhanden);
    }

    public static string GetElementNameFromNode(XmlNode node)
    {
      if (node == null)
        return "";
      if (node is XmlText)
        return "#PCDATA";
      if (node is XmlComment)
        return "#COMMENT";
      if (node is XmlWhitespace)
        return "#WHITESPACE";
      return node.Name;
    }

    public DTDElement DTDElementByNameIntern_(
      string elementName,
      bool fehlerWennNichtVorhanden)
    {
      DTDElement dtdElement1 = (DTDElement) this._elementeNachNamen[(object) elementName];
      if (dtdElement1 != null)
        return dtdElement1;
      foreach (DTDElement dtdElement2 in this._elemente)
      {
        if (elementName == dtdElement2.Name)
        {
          this._elementeNachNamen.Add((object) elementName, (object) dtdElement2);
          return dtdElement2;
        }
      }
      if (fehlerWennNichtVorhanden)
        throw new DTD.XMLUnknownElementException(elementName);
      return (DTDElement) null;
    }

    public class XMLUnknownElementException : Exception
    {
      private string _elementname;

      public XMLUnknownElementException(string elementname)
      {
        this._elementname = elementname;
      }

      public string ElementName
      {
        get
        {
          return this._elementname;
        }
      }
    }
  }
}
