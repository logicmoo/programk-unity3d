// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.dtd.DTDElement
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Text.RegularExpressions;

namespace de.springwald.xml.dtd
{
  public class DTDElement
  {
    private string _name;
    private DTDChildElemente _children;
    private Regex _childrenRegExObjekt;
    private StringCollection _alleElementNamenWelcheAlsDirektesChildZulaessigSind;

    public string Name
    {
      get
      {
        return this._name;
      }
      set
      {
        this._name = value;
      }
    }

    public DTDChildElemente ChildElemente
    {
      get
      {
        return this._children;
      }
      set
      {
        this._children = value;
      }
    }

    public StringCollection AlleElementNamenWelcheAlsDirektesChildZulaessigSind
    {
      get
      {
        if (this._alleElementNamenWelcheAlsDirektesChildZulaessigSind == null)
        {
          this._alleElementNamenWelcheAlsDirektesChildZulaessigSind = this.GetDTDElementeNamenAusChildElementen_(this._children);
          this._alleElementNamenWelcheAlsDirektesChildZulaessigSind.Add("#COMMENT");
        }
        return this._alleElementNamenWelcheAlsDirektesChildZulaessigSind;
      }
    }

    public List<DTDAttribut> Attribute { get; set; }

    public Regex ChildrenRegExObjekt
    {
      get
      {
        if (this._childrenRegExObjekt == null)
        {
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.Append(">");
          stringBuilder.Append(this._children.RegExAusdruck);
          stringBuilder.Append("<");
          this._childrenRegExObjekt = new Regex(stringBuilder.ToString());
        }
        return this._childrenRegExObjekt;
      }
    }

    private StringCollection GetDTDElementeNamenAusChildElementen_(
      DTDChildElemente children)
    {
      StringCollection stringCollection = new StringCollection();
      switch (children.Art)
      {
        case DTDChildElemente.DTDChildElementArten.EinzelChild:
          if (!stringCollection.Contains(children.ElementName))
          {
            stringCollection.Add(children.ElementName);
            goto case DTDChildElemente.DTDChildElementArten.Leer;
          }
          else
            goto case DTDChildElemente.DTDChildElementArten.Leer;
        case DTDChildElemente.DTDChildElementArten.Leer:
          return stringCollection;
        case DTDChildElemente.DTDChildElementArten.ChildListe:
          for (int index = 0; index < children.AnzahlChildren; ++index)
          {
            foreach (string str in this.GetDTDElementeNamenAusChildElementen_(children.Child(index)))
            {
              if (!stringCollection.Contains(str))
                stringCollection.Add(str);
            }
          }
          goto case DTDChildElemente.DTDChildElementArten.Leer;
        default:
          throw new ApplicationException(string.Format(ResReader.Reader.GetString("UnbekannteDTDChildElementArt"), (object) children.Art));
      }
    }
  }
}
