// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLElement_TextNode
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.toolbox;
using de.springwald.xml.cursor;
using de.springwald.xml.editor.textnode;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace de.springwald.xml.editor
{
  public class XMLElement_TextNode : XMLElement
  {
    private static Font _drawFont;
    private static float _breiteProBuchstabe;
    private static int _hoeheProBuchstabe;
    private static StringFormat _drawFormat;
    protected Color _farbeHintergrund_;
    protected Color _farbeHintergrundInvertiert_;
    protected Color _farbeHintergrundInvertiertOhneFokus_;
    protected SolidBrush _drawBrush_;
    protected SolidBrush _drawBrushInvertiert_;
    protected SolidBrush _drawBrushInvertiertOhneFokus_;
    private List<TextTeil> _textTeile;

    private string AktuellerInhalt
    {
      get
      {
        return ToolboxXML.TextAusTextNodeBereinigt(this.XMLNode);
      }
    }

    private Color GetHintergrundFarbe(bool invertiert)
    {
      if (!invertiert)
        return this._farbeHintergrund_;
      if (this._xmlEditor.HatFokus)
        return this._farbeHintergrundInvertiert_;
      return this._farbeHintergrundInvertiertOhneFokus_;
    }

    private SolidBrush GetZeichenFarbe(bool invertiert)
    {
      if (!invertiert)
        return this._drawBrush_;
      if (this._xmlEditor.HatFokus)
        return this._drawBrushInvertiert_;
      return this._drawBrushInvertiertOhneFokus_;
    }

    public char[] ZeichenZumUmbrechen { get; set; }

    public char[] ZeichenZumEinruecken { get; set; }

    public char[] ZeichenZumAusruecken { get; set; }

    public XMLElement_TextNode(XmlNode xmlNode, XMLEditor xmlEditor)
      : base(xmlNode, xmlEditor)
    {
      if (XMLElement_TextNode._drawFont == null)
      {
        XMLElement_TextNode._drawFormat = (StringFormat) StringFormat.GenericTypographic.Clone();
        XMLElement_TextNode._drawFormat.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
        XMLElement_TextNode._drawFormat.Trimming = StringTrimming.None;
        XMLElement_TextNode._drawFont = new Font("Courier New", 10f, GraphicsUnit.Point);
        XMLElement_TextNode._breiteProBuchstabe = ToolboxUsercontrols.MeasureDisplayStringWidth(xmlEditor.ZeichnungsSteuerelement.CreateGraphics(), "W", XMLElement_TextNode._drawFont, XMLElement_TextNode._drawFormat);
        XMLElement_TextNode._hoeheProBuchstabe = XMLElement_TextNode._drawFont.Height;
      }
      this.FarbenSetzen();
    }

    protected override void Dispose(bool disposing)
    {
      if (this._drawBrush_ != null)
        this._drawBrush_.Dispose();
      if (this._drawBrushInvertiert_ != null)
        this._drawBrushInvertiert_.Dispose();
      if (this._drawBrushInvertiertOhneFokus_ != null)
        this._drawBrushInvertiertOhneFokus_.Dispose();
      base.Dispose(disposing);
    }

    protected override void NodeZeichnenStart(
      XMLPaintArten paintArt,
      int offSetX,
      int offSetY,
      PaintEventArgs e)
    {
      int num1 = 2;
      int num2 = 0;
      if (paintArt == XMLPaintArten.Vorberechnen)
      {
        int selektionStart = -1;
        int selektionLaenge = 0;
        this.StartUndEndeDerSelektionBestimmen(ref selektionStart, ref selektionLaenge);
        int maxLaengeProZeile = (int) ((double) (this._paintPos.ZeilenEndeX - this._paintPos.ZeilenStartX) / (double) XMLElement_TextNode._breiteProBuchstabe);
        int bereitsLaengeDerZeile = (int) ((double) this._paintPos.PosX / (double) XMLElement_TextNode._breiteProBuchstabe);
        this._textTeile = new TextTeiler(this.AktuellerInhalt, selektionStart, selektionLaenge, maxLaengeProZeile, bereitsLaengeDerZeile, this.ZeichenZumUmbrechen).TextTeile;
      }
      else
      {
        foreach (TextTeil textTeil in this._textTeile)
        {
          using (SolidBrush solidBrush = new SolidBrush(this.GetHintergrundFarbe(textTeil.Invertiert)))
            e.Graphics.FillRectangle((Brush) solidBrush, textTeil.Rechteck);
        }
      }
      foreach (TextTeil textTeil in this._textTeile)
      {
        int num3 = (int) ((double) XMLElement_TextNode._breiteProBuchstabe * (double) textTeil.Text.Length);
        if (textTeil.IstNeueZeile)
        {
          this._paintPos.PosY += this._xmlEditor.Regelwerk.AbstandYZwischenZeilen + this._paintPos.HoeheAktZeile;
          this._paintPos.PosX = this._paintPos.ZeilenStartX;
          this._paintPos.HoeheAktZeile = XMLElement_TextNode._hoeheProBuchstabe + num1 * 2;
        }
        if (paintArt == XMLPaintArten.Vorberechnen)
        {
          textTeil.Rechteck = new Rectangle(this._paintPos.PosX, this._paintPos.PosY, (int) ((double) XMLElement_TextNode._breiteProBuchstabe * (double) textTeil.Text.Length), XMLElement_TextNode._hoeheProBuchstabe + num1 * 2);
          if (this._xmlNode == this._xmlEditor.CursorOptimiert.StartPos.AktNode && this._xmlEditor.CursorOptimiert.StartPos.PosAmNode == XMLCursorPositionen.CursorInnerhalbDesTextNodes && (this._xmlEditor.CursorOptimiert.StartPos.PosImTextnode >= num2 && this._xmlEditor.CursorOptimiert.StartPos.PosImTextnode <= num2 + textTeil.Text.Length))
            this._cursorStrichPos = new Point(Math.Max(this._paintPos.PosX, this._paintPos.PosX + (int) ((double) (this._xmlEditor.CursorOptimiert.StartPos.PosImTextnode - num2) * (double) XMLElement_TextNode._breiteProBuchstabe)), this._paintPos.PosY);
          num2 += textTeil.Text.Length;
          this._klickBereiche.Add(textTeil.Rechteck);
        }
        else
          e.Graphics.DrawString(textTeil.Text, XMLElement_TextNode._drawFont, (Brush) this.GetZeichenFarbe(textTeil.Invertiert), (float) textTeil.Rechteck.X, (float) (textTeil.Rechteck.Y + num1), XMLElement_TextNode._drawFormat);
        this._paintPos.BisherMaxX = Math.Max(this._paintPos.BisherMaxX, textTeil.Rechteck.X + textTeil.Rechteck.Width);
        this._paintPos.HoeheAktZeile = Math.Max(this._paintPos.HoeheAktZeile, XMLElement_TextNode._hoeheProBuchstabe + num1 + num1);
        this._paintPos.PosX += num3;
      }
      if (this._xmlNode != this._xmlEditor.CursorOptimiert.StartPos.AktNode || this._xmlEditor.CursorOptimiert.StartPos.PosAmNode != XMLCursorPositionen.CursorHinterDemNode)
        return;
      this._cursorStrichPos = new Point(this._paintPos.PosX - 1, this._paintPos.PosY);
    }

    protected override void WurdeAngeklickt(Point point, MausKlickAktionen aktion)
    {
      int posInZeile = 0;
      foreach (TextTeil textTeil in this._textTeile)
      {
        if (textTeil.Rechteck.Contains(point))
        {
          posInZeile += Math.Min(textTeil.Text.Length - 1, (int) ((double) (point.X - textTeil.Rechteck.X) / (double) XMLElement_TextNode._breiteProBuchstabe + 0.5));
          break;
        }
        posInZeile += textTeil.Text.Length;
      }
      this._xmlEditor.CursorRoh.CursorPosSetzenDurchMausAktion(this._xmlNode, XMLCursorPositionen.CursorInnerhalbDesTextNodes, posInZeile, aktion);
    }

    protected virtual void FarbenSetzen()
    {
      this._farbeHintergrund_ = this._xmlEditor.ZeichnungsSteuerelement.BackColor;
      if (this._drawBrush_ != null)
        this._drawBrush_.Dispose();
      this._drawBrush_ = new SolidBrush(Color.Black);
      this._farbeHintergrundInvertiert_ = Color.DarkBlue;
      if (this._drawBrushInvertiert_ != null)
        this._drawBrushInvertiert_.Dispose();
      this._drawBrushInvertiert_ = new SolidBrush(Color.White);
      this._farbeHintergrundInvertiertOhneFokus_ = Color.Gray;
      if (this._drawBrushInvertiertOhneFokus_ != null)
        this._drawBrushInvertiertOhneFokus_.Dispose();
      this._drawBrushInvertiertOhneFokus_ = new SolidBrush(Color.White);
    }

    private int LiegtInWelchemTextTeil(Point point)
    {
      for (int index = 0; index < this._textTeile.Count; ++index)
      {
        if (this._textTeile[index].Rechteck.Contains(point))
          return index;
      }
      throw new ApplicationException("Punkt liegt in keiner der bekannten Zeilen (XMLElement_Textnode.LiegtInWelcherZeile)");
    }

    private void StartUndEndeDerSelektionBestimmen(ref int selektionStart, ref int selektionLaenge)
    {
      XMLCursor cursorOptimiert = this._xmlEditor.CursorOptimiert;
      if (cursorOptimiert.StartPos.AktNode == this._xmlNode)
      {
        switch (cursorOptimiert.StartPos.PosAmNode)
        {
          case XMLCursorPositionen.CursorVorDemNode:
          case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
            selektionStart = cursorOptimiert.StartPos.PosAmNode != XMLCursorPositionen.CursorInnerhalbDesTextNodes ? 0 : Math.Max(0, cursorOptimiert.StartPos.PosImTextnode);
            if (cursorOptimiert.EndPos.AktNode == this._xmlNode)
            {
              switch (cursorOptimiert.EndPos.PosAmNode)
              {
                case XMLCursorPositionen.CursorVorDemNode:
                  selektionLaenge = 0;
                  return;
                case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
                case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
                case XMLCursorPositionen.CursorHinterDemNode:
                  selektionLaenge = Math.Max(0, this.AktuellerInhalt.Length - selektionStart);
                  return;
                case XMLCursorPositionen.CursorInDemLeeremNode:
                  selektionStart = -1;
                  selektionLaenge = 0;
                  return;
                case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
                  selektionLaenge = Math.Max(0, cursorOptimiert.EndPos.PosImTextnode - selektionStart);
                  return;
                default:
                  throw new ApplicationException("Unbekannte XMLCursorPosition.EndPos.PosAmNode '" + (object) cursorOptimiert.EndPos.PosAmNode + "'B");
              }
            }
            else
            {
              if (cursorOptimiert.EndPos.AktNode.ParentNode == cursorOptimiert.StartPos.AktNode.ParentNode)
              {
                selektionLaenge = Math.Max(0, this.AktuellerInhalt.Length - selektionStart);
              }
              else
              {
                selektionStart = 0;
                selektionLaenge = this.AktuellerInhalt.Length;
              }
              break;
            }
          case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
          case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
            selektionStart = 0;
            selektionLaenge = this.AktuellerInhalt.Length;
            break;
          case XMLCursorPositionen.CursorInDemLeeremNode:
          case XMLCursorPositionen.CursorHinterDemNode:
            selektionStart = -1;
            selektionLaenge = 0;
            break;
          default:
            throw new ApplicationException("Unbekannte XMLCursorPosition.StartPos.PosAmNode '" + (object) cursorOptimiert.StartPos.PosAmNode + "'A");
        }
      }
      else if (cursorOptimiert.EndPos.AktNode == this._xmlNode)
      {
        switch (cursorOptimiert.EndPos.PosAmNode)
        {
          case XMLCursorPositionen.CursorVorDemNode:
            selektionStart = -1;
            selektionLaenge = 0;
            break;
          case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
          case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
          case XMLCursorPositionen.CursorHinterDemNode:
            selektionStart = 0;
            selektionLaenge = this.AktuellerInhalt.Length;
            break;
          case XMLCursorPositionen.CursorInDemLeeremNode:
            selektionStart = -1;
            selektionLaenge = 0;
            break;
          case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
            if (cursorOptimiert.EndPos.AktNode.ParentNode == cursorOptimiert.StartPos.AktNode.ParentNode)
            {
              selektionStart = 0;
              selektionLaenge = Math.Max(0, cursorOptimiert.EndPos.PosImTextnode);
              break;
            }
            selektionStart = 0;
            selektionLaenge = this.AktuellerInhalt.Length;
            break;
          default:
            throw new ApplicationException("Unbekannte XMLCursorPosition.EndPos.PosAmNode '" + (object) cursorOptimiert.EndPos.PosAmNode + "'X");
        }
      }
      else if (this._xmlEditor.CursorOptimiert.IstNodeInnerhalbDerSelektion(this._xmlNode))
      {
        selektionStart = 0;
        selektionLaenge = this.AktuellerInhalt.Length;
      }
    }
  }
}
