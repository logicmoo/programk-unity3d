// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLQuellcodeAlsRTF
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.xml.dtd.pruefer;
using System;
using System.Text;
using System.Xml;

namespace de.springwald.xml.editor
{
  public class XMLQuellcodeAlsRTF
  {
    private bool _zeilenNummernAnzeigen = true;
    private string _rtf_Header = "{\\rtf1\\ansi\\deff0\r\n{\\colortbl;\\red0\\green0\\blue0;\\red255\\green0\\blue0;\\red200\\green200\\blue200;}";
    private string _rtf_Footer = "\r\n}";
    private string _rtf_Umbruch = "\\line\r\n";
    private string _rtf_FarbeSchwarz = "\\cf1\r\n";
    private string _rtf_FarbeRot = "\\cf2\r\n";
    private string _rtf_FarbeGrau = "\\cf3\r\n";
    private bool _nochNichtGerendert = true;
    private XMLRegelwerk _regelwerk;
    private int _zeilenNummer;
    private XmlNode _rootnode;
    private StringBuilder _fehlerProtokollAlsText;
    private StringBuilder _quellcodeAlsRTF;

    public event EventHandler NodeWirdGeprueftEvent;

    protected virtual void ActivateNodeWirdGeprueft(EventArgs e)
    {
      if (this.NodeWirdGeprueftEvent == null)
        return;
      this.NodeWirdGeprueftEvent((object) this, e);
    }

    public XMLRegelwerk Regelwerk
    {
      set
      {
        this._regelwerk = value;
      }
    }

    public XmlNode Rootnode
    {
      set
      {
        this._rootnode = value;
        this._nochNichtGerendert = true;
      }
    }

    public void SetChanged()
    {
      this._nochNichtGerendert = true;
    }

    public void Rendern()
    {
      this.RenderIntern();
    }

    public string FehlerProtokollAlsText
    {
      get
      {
        if (this._nochNichtGerendert)
          this.RenderIntern();
        return this._fehlerProtokollAlsText.ToString();
      }
    }

    public string QuellCodeAlsRTF
    {
      get
      {
        if (this._nochNichtGerendert)
          this.RenderIntern();
        return this._quellcodeAlsRTF.ToString();
      }
    }

    public void QuellCodeUndFehlerInNeuemFormZeigen()
    {
      using (frmDokFehlerZeigen frmDokFehlerZeigen = new frmDokFehlerZeigen())
      {
        frmDokFehlerZeigen.Anzeigen(this.QuellCodeAlsRTF, this.FehlerProtokollAlsText);
        int num = (int) frmDokFehlerZeigen.ShowDialog();
      }
    }

    private void RenderIntern()
    {
      this._quellcodeAlsRTF = new StringBuilder();
      this._fehlerProtokollAlsText = new StringBuilder();
      if (this._regelwerk == null)
        this._fehlerProtokollAlsText.Append("Noch kein Regelwerk-Objekt zugewiesen");
      else if (this._rootnode == null)
      {
        this._fehlerProtokollAlsText.Append(ResReader.Reader.GetString("NochKeinRootNodeZugewiesen"));
      }
      else
      {
        bool nodeFehlerhaft = false;
        this._zeilenNummer = 0;
        this._quellcodeAlsRTF.Append(this._rtf_Header);
        this._quellcodeAlsRTF.AppendFormat("{0}\r\n", (object) this.GetNodeAlsQuellText(this._rootnode, "", false, false, false, ref nodeFehlerhaft));
        this._quellcodeAlsRTF.Append(this._rtf_Footer);
        this._nochNichtGerendert = false;
      }
    }

    private string GetNodeAlsQuellText(
      XmlNode node,
      string einzug,
      bool neueZeileNotwendig,
      bool parentWarFehlerhaft,
      bool posBereitsAlsOKGeprueft,
      ref bool nodeFehlerhaft)
    {
      this.ActivateNodeWirdGeprueft(EventArgs.Empty);
      if (node is XmlWhitespace)
        return "";
      if (node is XmlComment)
        return string.Format("<!--{0}-->", (object) node.InnerText);
      StringBuilder stringBuilder1 = new StringBuilder();
      string str1 = "    ";
      string str2;
      string str3;
      if (parentWarFehlerhaft)
      {
        nodeFehlerhaft = true;
        str2 = (string) null;
        str3 = "";
      }
      else
      {
        DTDPruefer dtdPruefer = this._regelwerk.DTDPruefer;
        if (dtdPruefer.IstXmlNodeOk(node, posBereitsAlsOKGeprueft))
        {
          nodeFehlerhaft = false;
          str2 = (string) null;
          str3 = this.RTFFarbe(XMLQuellcodeAlsRTF.RtfFarben.schwarz);
        }
        else
        {
          nodeFehlerhaft = true;
          str2 = dtdPruefer.Fehlermeldungen;
          str3 = this.RTFFarbe(XMLQuellcodeAlsRTF.RtfFarben.rot);
        }
      }
      if (node is XmlText)
      {
        if (neueZeileNotwendig)
          stringBuilder1.Append(this.GetNeueZeile() + einzug);
        stringBuilder1.Append(str3);
        StringBuilder stringBuilder2 = new StringBuilder(node.Value);
        stringBuilder2.Replace("\t", " ");
        stringBuilder2.Replace("\r\n", " ");
        stringBuilder2.Replace("  ", " ");
        stringBuilder1.Append(stringBuilder2.ToString());
      }
      else if (this._regelwerk.IstSchliessendesTagSichtbar(node))
      {
        switch (this._regelwerk.DarstellungsArt(node))
        {
          case DarstellungsArten.Fliesselement:
            if (neueZeileNotwendig)
              stringBuilder1.Append(this.GetNeueZeile() + einzug);
            stringBuilder1.AppendFormat("{0}<{1}{2}>", (object) str3, (object) node.Name, (object) this.GetAttributeAlsQuellText(node.Attributes));
            stringBuilder1.Append(this.GetChildrenAlsQuellText(node.ChildNodes, einzug + str1, true, nodeFehlerhaft, false));
            stringBuilder1.AppendFormat("{0}</{1}>", (object) str3, (object) node.Name);
            break;
          case DarstellungsArten.EigeneZeile:
            stringBuilder1.Append(this.GetNeueZeile());
            stringBuilder1.Append(str3);
            stringBuilder1.Append(einzug);
            stringBuilder1.AppendFormat("<{0}{1}>", (object) node.Name, (object) this.GetAttributeAlsQuellText(node.Attributes));
            if (str2 != null)
              this._fehlerProtokollAlsText.Append(this.GetZeilenNummerString(this._zeilenNummer) + ": " + str2 + "\r\n");
            stringBuilder1.Append(this.GetChildrenAlsQuellText(node.ChildNodes, einzug + str1, true, nodeFehlerhaft, false));
            stringBuilder1.Append(this.GetNeueZeile());
            stringBuilder1.Append(str3);
            stringBuilder1.Append(einzug);
            stringBuilder1.AppendFormat("</{0}>", (object) node.Name);
            break;
          default:
            throw new ApplicationException("Unbekannte Darstellungsart " + (object) this._regelwerk.DarstellungsArt(node));
        }
      }
      else
      {
        if (neueZeileNotwendig)
          stringBuilder1.Append(this.GetNeueZeile() + einzug);
        stringBuilder1.Append(str3);
        stringBuilder1.AppendFormat("<{0}{1}>", (object) node.Name, (object) this.GetAttributeAlsQuellText(node.Attributes));
      }
      return stringBuilder1.ToString();
    }

    private string GetNeueZeile()
    {
      if (!this._zeilenNummernAnzeigen)
        return this._rtf_Umbruch;
      ++this._zeilenNummer;
      StringBuilder stringBuilder = new StringBuilder(this._rtf_Umbruch);
      stringBuilder.Append(this.RTFFarbe(XMLQuellcodeAlsRTF.RtfFarben.schwarz));
      stringBuilder.AppendFormat("{0}: ", (object) this.GetZeilenNummerString(this._zeilenNummer));
      return stringBuilder.ToString();
    }

    private string GetZeilenNummerString(int nummer)
    {
      StringBuilder stringBuilder = new StringBuilder(nummer.ToString(), 6);
      while (stringBuilder.Length < 6)
        stringBuilder.Insert(0, "0");
      return stringBuilder.ToString();
    }

    private string RTFFarbe(XMLQuellcodeAlsRTF.RtfFarben farbe)
    {
      switch (farbe)
      {
        case XMLQuellcodeAlsRTF.RtfFarben.schwarz:
          return this._rtf_FarbeSchwarz;
        case XMLQuellcodeAlsRTF.RtfFarben.rot:
          return this._rtf_FarbeRot;
        case XMLQuellcodeAlsRTF.RtfFarben.grau:
          return this._rtf_FarbeGrau;
        default:
          throw new ApplicationException("Unbekannt Farbe '" + (object) farbe + "'");
      }
    }

    private string GetChildrenAlsQuellText(
      XmlNodeList children,
      string einzug,
      bool neueZeileNotwendig,
      bool parentNodeBereitsFehlerhaft,
      bool posBereitsAlsOKGeprueft)
    {
      StringBuilder stringBuilder = new StringBuilder();
      bool parentWarFehlerhaft = parentNodeBereitsFehlerhaft;
      bool nodeFehlerhaft = false;
      foreach (XmlNode child in children)
      {
        stringBuilder.Append(this.GetNodeAlsQuellText(child, einzug, neueZeileNotwendig, parentWarFehlerhaft, posBereitsAlsOKGeprueft, ref nodeFehlerhaft));
        if (nodeFehlerhaft)
        {
          nodeFehlerhaft = true;
          parentWarFehlerhaft = true;
        }
        else
          posBereitsAlsOKGeprueft = true;
        neueZeileNotwendig = false;
      }
      return stringBuilder.ToString();
    }

    private string GetAttributeAlsQuellText(XmlAttributeCollection attribute)
    {
      if (attribute == null)
        return "";
      StringBuilder stringBuilder = new StringBuilder();
      foreach (XmlAttribute xmlAttribute in (XmlNamedNodeMap) attribute)
        stringBuilder.AppendFormat(" {0}=\"{1}\"", (object) xmlAttribute.Name, (object) xmlAttribute.Value);
      return stringBuilder.ToString();
    }

    private enum RtfFarben
    {
      schwarz,
      rot,
      grau,
    }
  }
}
