// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.XMLRegelwerk
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.xml.cursor;
using de.springwald.xml.dtd;
using de.springwald.xml.dtd.pruefer;
using de.springwald.xml.editor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace de.springwald.xml
{
  public class XMLRegelwerk
  {
    private DTD _dtd;
    private DTDPruefer _dtdPruefer;
    private DTDNodeEditCheck _checker;
    protected XMLElementGruppenListe _elementGruppen;

    public DTDPruefer DTDPruefer
    {
      get
      {
        if (this._dtdPruefer == null)
        {
          if (this._dtd == null)
            throw new ApplicationException("No DTD attached!");
          this._dtdPruefer = new DTDPruefer(this._dtd);
        }
        return this._dtdPruefer;
      }
    }

    public DTD DTD
    {
      get
      {
        return this._dtd;
      }
    }

    public virtual int ChildEinrueckungX
    {
      get
      {
        return 20;
      }
    }

    public virtual int AbstandYZwischenZeilen
    {
      get
      {
        return 5;
      }
    }

    public virtual int AbstandFliessElementeX
    {
      get
      {
        return 0;
      }
    }

    public virtual XMLElementGruppenListe ElementGruppen
    {
      get
      {
        if (this._elementGruppen == null)
          this._elementGruppen = new XMLElementGruppenListe();
        return this._elementGruppen;
      }
    }

    public XMLRegelwerk(DTD dtd)
    {
      this._dtd = dtd;
    }

    public XMLRegelwerk()
    {
      this._dtd = (DTD) null;
    }

    public virtual Color NodeFarbe(XmlNode node, bool selektiert)
    {
      if (selektiert)
        return Color.DarkBlue;
      return Color.FromArgb(245, 245, (int) byte.MaxValue);
    }

    public virtual XMLElement createPaintElementForNode(
      XmlNode xmlNode,
      XMLEditor xmlEditor)
    {
      if (xmlNode is XmlElement)
        return (XMLElement) new XMLElement_StandardNode(xmlNode, xmlEditor);
      if (xmlNode is XmlText)
        return (XMLElement) new XMLElement_TextNode(xmlNode, xmlEditor);
      if (xmlNode is XmlComment)
        return (XMLElement) new XMLElement_Kommentar(xmlNode, xmlEditor);
      return (XMLElement) new XMLElement_StandardNode(xmlNode, xmlEditor);
    }

    public virtual DarstellungsArten DarstellungsArt(XmlNode xmlNode)
    {
      return xmlNode is XmlText || xmlNode is XmlWhitespace || !(xmlNode is XmlComment) && !this.IstSchliessendesTagSichtbar(xmlNode) ? DarstellungsArten.Fliesselement : DarstellungsArten.EigeneZeile;
    }

    public virtual bool IstSchliessendesTagSichtbar(XmlNode xmlNode)
    {
      if (xmlNode is XmlText)
        return false;
      DTDElement dtdElement = this._dtd.DTDElementByNode_(xmlNode, false);
      return dtdElement == null || dtdElement.AlleElementNamenWelcheAlsDirektesChildZulaessigSind.Count > 1;
    }

    public bool IstDiesesTagAnDieserStelleErlaubt(string tagname, XMLCursorPos zielPunkt)
    {
      return ((IEnumerable<string>) this.ErlaubteEinfuegeElemente_(zielPunkt, true, true)).Where<string>((Func<string, bool>) (e => e == tagname)).Count<string>() > 0;
    }

    public virtual string[] ErlaubteEinfuegeElemente_(
      XMLCursorPos zielPunkt,
      bool pcDATAMitAuflisten,
      bool kommentareMitAuflisten)
    {
      if (zielPunkt.AktNode == null)
        return new string[0];
      if (this._dtd == null)
        return new string[1]{ "" };
      if (this._checker == null)
        this._checker = new DTDNodeEditCheck(this._dtd);
      return this._checker.AnDieserStelleErlaubteTags_(zielPunkt, pcDATAMitAuflisten, kommentareMitAuflisten);
    }

    public virtual bool PreviewKeyDown(
      PreviewKeyDownEventArgs e,
      out bool naechsteTasteBeiKeyPressAlsTextAufnehmen,
      XMLEditor editor)
    {
      naechsteTasteBeiKeyPressAlsTextAufnehmen = false;
      if (e.KeyData == (Keys.S | Keys.Control))
      {
        editor.AktionNeuesElementAnAktCursorPosEinfuegen("srai", XMLEditor.UndoSnapshotSetzenOptionen.ja, false);
        naechsteTasteBeiKeyPressAlsTextAufnehmen = false;
        return true;
      }
      naechsteTasteBeiKeyPressAlsTextAufnehmen = true;
      return false;
    }

    public virtual string EinfuegeTextPreProcessing(
      string einfuegeText,
      XMLCursorPos woEinfuegen,
      out XmlNode ersatzNode)
    {
      ersatzNode = (XmlNode) null;
      return einfuegeText;
    }
  }
}
