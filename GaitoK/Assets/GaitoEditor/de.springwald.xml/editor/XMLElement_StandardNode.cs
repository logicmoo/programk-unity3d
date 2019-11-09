// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLElement_StandardNode
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.toolbox;
using de.springwald.xml.cursor;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace de.springwald.xml.editor
{
  public class XMLElement_StandardNode : XMLElement
  {
    private int _ankerEinzugY = 0;
    private Color _farbeRahmenHintergrund;
    private Color _farbeRahmenRand;
    private Color _farbeNodeNameSchrift;
    private Color _farbePfeil;
    private Color _farbeAttributeHintergrund;
    private Color _farbeAttributeRand;
    private Color _farbeAttributeSchrift;
    private const int _randX = 4;
    private const int _randY = 2;
    private const int _rundung = 3;
    private const int _pfeilLaenge = 7;
    private const int _pfeilDicke = 7;
    private static StringFormat _drawFormat;
    private static Font _drawFontAttribute;
    private static float _breiteProBuchstabeAttribute;
    private static int _hoeheProBuchstabeAttribut;
    private static Font _drawFontNodeName;
    private static int _hoeheProBuchstabeNodeName;
    private Rectangle _pfeilBereichLinks;
    private Rectangle _pfeilBereichRechts;
    private Rectangle _tagBereichLinks;
    private Rectangle _tagBereichRechts;
    private int _rahmenBreite;
    private int _rahmenHoehe;

    protected override Point AnkerPos
    {
      get
      {
        return new Point(this._startX - 4, this._startY + this._ankerEinzugY);
      }
    }

    public XMLElement_StandardNode(XmlNode xmlNode, XMLEditor xmlEditor)
      : base(xmlNode, xmlEditor)
    {
      if (XMLElement_StandardNode._drawFontNodeName == null)
      {
        XMLElement_StandardNode._drawFormat = (StringFormat) StringFormat.GenericTypographic.Clone();
        XMLElement_StandardNode._drawFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
        XMLElement_StandardNode._drawFormat.Trimming = StringTrimming.None;
        XMLElement_StandardNode._drawFontNodeName = new Font("Arial", 10f, GraphicsUnit.Point);
        XMLElement_StandardNode._hoeheProBuchstabeNodeName = XMLElement_StandardNode._drawFontNodeName.Height;
        XMLElement_StandardNode._drawFontAttribute = new Font("Courier New", 8f, GraphicsUnit.Point);
        XMLElement_StandardNode._breiteProBuchstabeAttribute = ToolboxUsercontrols.MeasureDisplayStringWidth(xmlEditor.ZeichnungsSteuerelement.CreateGraphics(), "W", XMLElement_StandardNode._drawFontAttribute, XMLElement_StandardNode._drawFormat);
        XMLElement_StandardNode._hoeheProBuchstabeAttribut = XMLElement_StandardNode._drawFontAttribute.Height;
      }
      this._ankerEinzugY = XMLElement_StandardNode._hoeheProBuchstabeNodeName / 2 + 2;
    }

    protected override void NodeZeichnenStart(
      XMLPaintArten paintArt,
      int offSetX,
      int offSetY,
      PaintEventArgs e)
    {
      if (paintArt == XMLPaintArten.Vorberechnen && this._xmlEditor.CursorOptimiert.StartPos.AktNode == this._xmlNode && this._xmlEditor.CursorOptimiert.StartPos.PosAmNode == XMLCursorPositionen.CursorVorDemNode)
        this._cursorStrichPos = new Point(this._paintPos.PosX + 1, this._paintPos.PosY);
      int num = (int) ToolboxUsercontrols.MeasureDisplayStringWidth(e.Graphics, this._xmlNode.Name, XMLElement_StandardNode._drawFontNodeName, XMLElement_StandardNode._drawFormat);
      if (paintArt != XMLPaintArten.Vorberechnen)
      {
        this.FarbenSetzen(paintArt);
        this.zeichneRahmenNachGroesse(this._paintPos.PosX, this._paintPos.PosY, this._rahmenBreite, this._rahmenHoehe, 3, this._farbeRahmenHintergrund, this._farbeRahmenRand, e);
      }
      using (SolidBrush solidBrush1 = new SolidBrush(this._farbeNodeNameSchrift))
      {
        this._paintPos.PosX += 4;
        if (paintArt != XMLPaintArten.Vorberechnen)
          e.Graphics.DrawString(this._xmlNode.Name, XMLElement_StandardNode._drawFontNodeName, (Brush) solidBrush1, (float) this._paintPos.PosX, (float) (this._paintPos.PosY + 2), XMLElement_StandardNode._drawFormat);
        this._paintPos.PosX += num + 4;
        this.AttributeZeichnen(paintArt, e);
        this._rahmenBreite = this._paintPos.PosX - this._startX;
        this._rahmenHoehe = XMLElement_StandardNode._hoeheProBuchstabeNodeName + 2 + 2;
        ++this._paintPos.PosX;
        if (this._xmlEditor.Regelwerk.IstSchliessendesTagSichtbar(this._xmlNode))
        {
          if ((uint) paintArt > 0U)
          {
            using (SolidBrush solidBrush2 = new SolidBrush(this._farbePfeil))
            {
              int posX = this._paintPos.PosX;
              int y = this._paintPos.PosY + this._ankerEinzugY;
              Point[] points = new Point[3]
              {
                new Point(posX, y - 7),
                new Point(posX + 7, y),
                new Point(posX, y + 7)
              };
              e.Graphics.FillPolygon((Brush) solidBrush2, points);
              this._pfeilBereichLinks = new Rectangle(posX, y - 7, 7, 14);
            }
          }
          this._paintPos.PosX += 7;
        }
        else
          this._pfeilBereichLinks = new Rectangle(0, 0, 0, 0);
        if (paintArt == XMLPaintArten.Vorberechnen && this._xmlEditor.CursorOptimiert.StartPos.AktNode == this._xmlNode && this._xmlEditor.CursorOptimiert.StartPos.PosAmNode == XMLCursorPositionen.CursorInDemLeeremNode)
          this._cursorStrichPos = new Point(this._paintPos.PosX - 1, this._paintPos.PosY);
        this._paintPos.HoeheAktZeile = Math.Max(this._paintPos.HoeheAktZeile, this._rahmenHoehe);
        if (paintArt == XMLPaintArten.Vorberechnen)
        {
          this._tagBereichLinks = new Rectangle(this._startX, this._startY, this._paintPos.PosX - this._startX, this._rahmenHoehe);
          this._klickBereiche.Add(this._tagBereichLinks);
          if (!this._xmlEditor.Regelwerk.IstSchliessendesTagSichtbar(this._xmlNode) && this._xmlEditor.CursorOptimiert.StartPos.AktNode == this._xmlNode && this._xmlEditor.CursorOptimiert.StartPos.PosAmNode == XMLCursorPositionen.CursorHinterDemNode)
            this._cursorStrichPos = new Point(this._paintPos.PosX - 1, this._paintPos.PosY);
        }
        this._paintPos.BisherMaxX = Math.Max(this._paintPos.BisherMaxX, this._paintPos.PosX);
      }
    }

    protected override void NodeZeichnenAbschluss(
      XMLPaintArten paintArt,
      int offSetX,
      int offSetY,
      PaintEventArgs e)
    {
      if (e != null)
      {
        if (this._xmlEditor.Regelwerk.IstSchliessendesTagSichtbar(this._xmlNode))
        {
          int posX1 = this._paintPos.PosX;
          if ((uint) paintArt > 0U)
          {
            using (SolidBrush solidBrush = new SolidBrush(this._farbePfeil))
            {
              int posX2 = this._paintPos.PosX;
              int y = this._paintPos.PosY + this._ankerEinzugY;
              Point[] points = new Point[3]
              {
                new Point(posX2 + 7, y - 7),
                new Point(posX2, y),
                new Point(posX2 + 7, y + 7)
              };
              e.Graphics.FillPolygon((Brush) solidBrush, points);
              this._pfeilBereichRechts = new Rectangle(posX2, y - 7, 7, 14);
            }
          }
          this._paintPos.PosX += 7;
          int num = XMLElement_StandardNode._hoeheProBuchstabeNodeName + 4;
          int width = (int) e.Graphics.MeasureString(this._xmlNode.Name, XMLElement_StandardNode._drawFontNodeName, 64000, XMLElement_StandardNode._drawFormat).Width;
          if ((uint) paintArt > 0U)
            this.zeichneRahmenNachGroesse(this._paintPos.PosX, this._paintPos.PosY, width + 8, num, 3, this._farbeRahmenHintergrund, this._farbeRahmenRand, e);
          this._paintPos.PosX += 4;
          if ((uint) paintArt > 0U)
          {
            using (SolidBrush solidBrush = new SolidBrush(this._farbeNodeNameSchrift))
              e.Graphics.DrawString(this._xmlNode.Name, XMLElement_StandardNode._drawFontNodeName, (Brush) solidBrush, (float) this._paintPos.PosX, (float) (this._paintPos.PosY + 2), XMLElement_StandardNode._drawFormat);
          }
          this._paintPos.PosX += width + 4;
          ++this._paintPos.PosX;
          if (paintArt == XMLPaintArten.Vorberechnen)
          {
            this._tagBereichRechts = new Rectangle(posX1, this._paintPos.PosY, this._paintPos.PosX - posX1, num);
            this._klickBereiche.Add(this._tagBereichRechts);
            if (this._xmlEditor.CursorOptimiert.StartPos.AktNode == this._xmlNode && this._xmlEditor.CursorOptimiert.StartPos.PosAmNode == XMLCursorPositionen.CursorHinterDemNode)
              this._cursorStrichPos = new Point(this._paintPos.PosX - 1, this._paintPos.PosY);
          }
          this._paintPos.BisherMaxX = Math.Max(this._paintPos.BisherMaxX, this._paintPos.PosX);
        }
        else
        {
          this._pfeilBereichRechts = new Rectangle(0, 0, 0, 0);
          this._tagBereichRechts = new Rectangle(0, 0, 0, 0);
        }
      }
      base.NodeZeichnenAbschluss(paintArt, offSetX, offSetY, e);
    }

    private void AttributeZeichnen(XMLPaintArten paintArt, PaintEventArgs e)
    {
      XmlAttributeCollection attributes = this.XMLNode.Attributes;
      if (attributes == null || (uint) attributes.Count <= 0U)
        return;
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < attributes.Count; ++index)
        stringBuilder.AppendFormat(" {0}=\"{1}\"", (object) attributes[index].Name, (object) attributes[index].Value);
      int breite = (int) ((double) XMLElement_StandardNode._breiteProBuchstabeAttribute * (double) stringBuilder.Length);
      int buchstabeNodeName = XMLElement_StandardNode._hoeheProBuchstabeNodeName;
      if ((uint) paintArt > 0U)
      {
        this.zeichneRahmenNachGroesse(this._paintPos.PosX, this._paintPos.PosY + 2, breite, buchstabeNodeName, 2, this._farbeAttributeHintergrund, this._farbeAttributeRand, e);
        using (SolidBrush solidBrush = new SolidBrush(this._farbeAttributeSchrift))
          e.Graphics.DrawString(stringBuilder.ToString(), XMLElement_StandardNode._drawFontAttribute, (Brush) solidBrush, (float) (this._paintPos.PosX + 1), (float) (this._paintPos.PosY + 2), XMLElement_StandardNode._drawFormat);
      }
      this._paintPos.PosX += breite + 4;
    }

    private void zeichneRahmenNachKoordinaten(
      int x1,
      int y1,
      int x2,
      int y2,
      int rundung,
      Color fuellFarbe,
      Color rahmenFarbe,
      PaintEventArgs e)
    {
      using (GraphicsPath path = new GraphicsPath())
      {
        path.AddLine(x1 + rundung, y1, x2 - rundung, y1);
        path.AddLine(x2, y1 + rundung, x2, y2 - rundung);
        path.AddLine(x2 - rundung, y2, x1 + rundung, y2);
        path.AddLine(x1, y2 - rundung, x1, y1 + rundung);
        path.CloseFigure();
        if (fuellFarbe != Color.Transparent)
        {
          using (SolidBrush solidBrush = new SolidBrush(fuellFarbe))
            e.Graphics.FillPath((Brush) solidBrush, path);
        }
        using (Pen pen = new Pen(rahmenFarbe, 1f))
        {
          if (!(rahmenFarbe != Color.Transparent))
            return;
          e.Graphics.DrawPath(pen, path);
        }
      }
    }

    private void zeichneRahmenNachGroesse(
      int x,
      int y,
      int breite,
      int hoehe,
      int rundung,
      Color fuellFarbe,
      Color rahmenFarbe,
      PaintEventArgs e)
    {
      this.zeichneRahmenNachKoordinaten(x, y, x + breite, y + hoehe, rundung, fuellFarbe, rahmenFarbe, e);
    }

    protected override void WurdeAngeklickt(Point point, MausKlickAktionen aktion)
    {
      if (this._pfeilBereichLinks.Contains(point))
      {
        if (this._xmlNode.ChildNodes.Count > 0)
          this._xmlEditor.CursorRoh.CursorPosSetzenDurchMausAktion(this._xmlNode.FirstChild, XMLCursorPositionen.CursorVorDemNode, aktion);
        else
          this._xmlEditor.CursorRoh.CursorPosSetzenDurchMausAktion(this._xmlNode, XMLCursorPositionen.CursorInDemLeeremNode, aktion);
      }
      else if (this._pfeilBereichRechts.Contains(point))
      {
        if (this._xmlNode.ChildNodes.Count > 0)
          this._xmlEditor.CursorRoh.CursorPosSetzenDurchMausAktion(this._xmlNode.LastChild, XMLCursorPositionen.CursorHinterDemNode, aktion);
        else
          this._xmlEditor.CursorRoh.CursorPosSetzenDurchMausAktion(this._xmlNode, XMLCursorPositionen.CursorInDemLeeremNode, aktion);
      }
      else if (this._tagBereichLinks.Contains(point))
        this._xmlEditor.CursorRoh.CursorPosSetzenDurchMausAktion(this._xmlNode, XMLCursorPositionen.CursorAufNodeSelbstVorderesTag, aktion);
      else if (this._tagBereichRechts.Contains(point))
        this._xmlEditor.CursorRoh.CursorPosSetzenDurchMausAktion(this._xmlNode, XMLCursorPositionen.CursorAufNodeSelbstHinteresTag, aktion);
      else
        base.WurdeAngeklickt(point, aktion);
    }

    private void FarbenSetzen(XMLPaintArten paintArt)
    {
      if (this._xmlEditor.CursorOptimiert.IstNodeInnerhalbDerSelektion(this._xmlNode))
      {
        this._farbeRahmenHintergrund = this._xmlEditor.Regelwerk.NodeFarbe(this._xmlNode, true);
        this._farbeNodeNameSchrift = Color.White;
        this._farbePfeil = Color.Black;
        this._farbeAttributeHintergrund = Color.Transparent;
        this._farbeAttributeSchrift = Color.White;
      }
      else
      {
        this._farbeRahmenHintergrund = this._xmlEditor.Regelwerk.NodeFarbe(this._xmlNode, false);
        this._farbeNodeNameSchrift = Color.Black;
        this._farbePfeil = Color.LightGray;
        this._farbeAttributeHintergrund = Color.White;
        this._farbeAttributeSchrift = Color.Black;
      }
      this._farbeAttributeRand = Color.FromArgb(225, 225, 225);
      this._farbeRahmenRand = Color.FromArgb(100, 100, 150);
      if (paintArt != XMLPaintArten.AllesNeuZeichnenMitFehlerHighlighting || this._xmlEditor.Regelwerk.DTDPruefer.IstXmlNodeOk(this._xmlNode, false))
        return;
      this._farbeNodeNameSchrift = Color.Red;
      this._farbePfeil = Color.Red;
      this._farbeRahmenRand = Color.Red;
    }
  }
}
