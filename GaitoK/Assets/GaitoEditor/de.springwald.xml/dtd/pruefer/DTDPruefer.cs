// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.dtd.pruefer.DTDPruefer
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.xml.cursor;
using System.Text;
using System.Xml;

namespace de.springwald.xml.dtd.pruefer
{
  public class DTDPruefer
  {
    private DTD _dtd;
    private DTDNodeEditCheck _nodeCheckerintern;
    private StringBuilder _fehlermeldungen;

    private DTDNodeEditCheck NodeChecker
    {
      get
      {
        if (this._nodeCheckerintern == null)
          this._nodeCheckerintern = new DTDNodeEditCheck(this._dtd);
        return this._nodeCheckerintern;
      }
    }

    public string Fehlermeldungen
    {
      get
      {
        return this._fehlermeldungen.ToString();
      }
    }

    public DTDPruefer(DTD dtd)
    {
      this._dtd = dtd;
      this.Reset();
    }

    public bool IstXmlAttributOk(XmlAttribute xmlAttribut)
    {
      this.Reset();
      return this.PruefeAttribut(xmlAttribut);
    }

    public bool IstXmlNodeOk(XmlNode xmlNode, bool posBereitsAlsOKBestaetigt)
    {
      this.Reset();
      if (posBereitsAlsOKBestaetigt)
        return true;
      return this.PruefeNodePos(xmlNode);
    }

    private bool PruefeNodePos(XmlNode node)
    {
      if (node is XmlWhitespace)
        return true;
      if (this._dtd.IstDTDElementBekannt(DTD.GetElementNameFromNode(node)))
      {
        try
        {
          if (this.NodeChecker.IstDerNodeAnDieserStelleErlaubt(node))
            return true;
          this._fehlermeldungen.AppendFormat(ResReader.Reader.GetString("TagHierNichtErlaubt"), (object) node.Name);
          XMLCursorPos zuTestendeCursorPos = new XMLCursorPos();
          zuTestendeCursorPos.CursorSetzen(node, XMLCursorPositionen.CursorAufNodeSelbstVorderesTag);
          string[] strArray = this.NodeChecker.AnDieserStelleErlaubteTags_(zuTestendeCursorPos, false, false);
          if ((uint) strArray.Length > 0U)
          {
            this._fehlermeldungen.Append(ResReader.Reader.GetString("ErlaubteTags"));
            foreach (object obj in strArray)
              this._fehlermeldungen.AppendFormat("{0} ", obj);
          }
          else
            this._fehlermeldungen.Append(ResReader.Reader.GetString("AnDieserStelleKeineTagsErlaubt"));
          return false;
        }
        catch (DTD.XMLUnknownElementException ex)
        {
          this._fehlermeldungen.AppendFormat(ResReader.Reader.GetString("UnbekanntesElement"), (object) ex.ElementName);
          return false;
        }
      }
      else
      {
        this._fehlermeldungen.AppendFormat(ResReader.Reader.GetString("UnbekanntesElement"), (object) DTD.GetElementNameFromNode(node));
        return false;
      }
    }

    private bool PruefeAttribut(XmlAttribute attribut)
    {
      return false;
    }

    private void Reset()
    {
      this._fehlermeldungen = new StringBuilder();
    }
  }
}
