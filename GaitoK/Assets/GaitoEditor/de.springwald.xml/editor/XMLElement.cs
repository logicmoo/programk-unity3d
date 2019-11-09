// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLElement
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.toolbox;
using de.springwald.xml.cursor;
using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml;

namespace de.springwald.xml.editor
{
  public class XMLElement : IDisposable
  {
    private bool _disposed = false;
    protected int _startX = 0;
    protected int _startY = 0;
    protected ArrayList _childElemente = new ArrayList();
    protected RectangleCollection _klickBereiche = new RectangleCollection();
    protected XMLEditorPaintPos _paintPos;
    protected XMLEditorPaintPos _merkeStartPaintPos;
    protected Point _cursorStrichPos;
    protected XmlNode _xmlNode;
    protected XMLEditor _xmlEditor;
    protected bool _wirdGeradeGezeichnet;

    public XmlNode XMLNode
    {
      get
      {
        return this._xmlNode;
      }
    }

    public XMLEditorPaintPos PaintPos
    {
      set
      {
        this._paintPos = value;
      }
      get
      {
        return this._paintPos;
      }
    }

    protected virtual Point AnkerPos
    {
      get
      {
        return new Point(this._startX, this._startY);
      }
    }

    public XMLElement(XmlNode xmlNode, XMLEditor xmlEditor)
    {
      this._xmlNode = xmlNode;
      this._xmlEditor = xmlEditor;
      this._xmlEditor.CursorRoh.ChangedEvent += new EventHandler(this.Cursor_ChangedEvent);
      this._xmlEditor.MouseDownEvent += new MouseEventHandler(this._xmlEditor_MouseDownEvent);
      this._xmlEditor.MouseUpEvent += new MouseEventHandler(this._xmlEditor_MouseUpEvent);
      this._xmlEditor.MouseDownMoveEvent += new MouseEventHandler(this._xmlEditor_MouseDownMoveEvent);
      this._xmlEditor.xmlElementeAufraeumenEvent += new EventHandler(this._xmlEditor_xmlElementeAufraeumenEvent);
    }

    public virtual void Paint(XMLPaintArten paintArt, int offSetX, int offSetY, PaintEventArgs e)
    {
      if (this._disposed || this._xmlNode == null || this._xmlEditor == null)
        return;
      if (paintArt == XMLPaintArten.Vorberechnen)
        this._merkeStartPaintPos = this._paintPos.Clone();
      else
        this._paintPos = this._merkeStartPaintPos.Clone();
      this._startX = this._paintPos.PosX;
      this._startY = this._paintPos.PosY;
      if (paintArt == XMLPaintArten.Vorberechnen)
      {
        this.MausklickBereicheBufferLeeren();
        this._cursorStrichPos = new Point(this._startX, this._startY);
      }
      this._wirdGeradeGezeichnet = true;
      this.NodeZeichnenStart(paintArt, offSetX, offSetY, e);
      this.UnternodesZeichnen(paintArt, offSetX, offSetY, e);
      this.NodeZeichnenAbschluss(paintArt, offSetX, offSetY, e);
      this._wirdGeradeGezeichnet = false;
    }

    protected virtual void NodeZeichnenStart(
      XMLPaintArten paintArt,
      int offSetX,
      int offSetY,
      PaintEventArgs e)
    {
    }

    protected virtual void UnternodesZeichnen(
      XMLPaintArten paintArt,
      int offSetX,
      int offSetY,
      PaintEventArgs e)
    {
      if (this._xmlNode is XmlText)
        return;
      if (this._xmlNode == null)
        throw new ApplicationException("UnternodesZeichnen:XMLNode ist leer");
      this._paintPos.PosX += this._xmlEditor.Regelwerk.AbstandFliessElementeX;
      switch (this._xmlEditor.Regelwerk.DarstellungsArt(this._xmlNode))
      {
        case DarstellungsArten.EigeneZeile:
          this._paintPos.ZeilenStartX = this._paintPos.PosX;
          break;
      }
      for (int index = 0; index < this._xmlNode.ChildNodes.Count; ++index)
      {
        XMLElement element;
        if (index >= this._childElemente.Count)
        {
          element = this._xmlEditor.createElement(this._xmlNode.ChildNodes[index]);
          this._childElemente.Add((object) element);
        }
        else
        {
          element = (XMLElement) this._childElemente[index];
          if (element == null)
            throw new ApplicationException(string.Format("UnternodesZeichnen:childElement ist leer: PaintArt:{0} outerxml:{1} >> innerxml {2}", (object) paintArt, (object) this._xmlNode.OuterXml, (object) this._xmlNode.InnerXml));
          if (element.XMLNode != this._xmlNode.ChildNodes[index] && paintArt == XMLPaintArten.Vorberechnen)
          {
            element.Dispose();
            element = this._xmlEditor.createElement(this._xmlNode.ChildNodes[index]);
            this._childElemente[index] = (object) element;
          }
        }
        switch (this._xmlEditor.Regelwerk.DarstellungsArt(element.XMLNode))
        {
          case DarstellungsArten.Fliesselement:
            if (this._paintPos.PosX > this._paintPos.ZeilenEndeX)
            {
              this._paintPos.PosY += this._paintPos.HoeheAktZeile + this._xmlEditor.Regelwerk.AbstandYZwischenZeilen;
              this._paintPos.HoeheAktZeile = 0;
              this._paintPos.PosX = this._paintPos.ZeilenStartX;
            }
            XMLEditorPaintPos xmlEditorPaintPos1 = new XMLEditorPaintPos()
            {
              ZeilenStartX = this._paintPos.ZeilenStartX,
              ZeilenEndeX = this._paintPos.ZeilenEndeX,
              PosX = this._paintPos.PosX,
              PosY = this._paintPos.PosY,
              HoeheAktZeile = this._paintPos.HoeheAktZeile
            };
            element.PaintPos = xmlEditorPaintPos1;
            element.Paint(paintArt, offSetX, offSetY, e);
            break;
          case DarstellungsArten.EigeneZeile:
            this._paintPos.PosY += this._xmlEditor.Regelwerk.AbstandYZwischenZeilen + this._paintPos.HoeheAktZeile;
            this._paintPos.HoeheAktZeile = 0;
            this._paintPos.PosX = this._startX + this._xmlEditor.Regelwerk.ChildEinrueckungX;
            XMLEditorPaintPos xmlEditorPaintPos2 = new XMLEditorPaintPos()
            {
              ZeilenStartX = this._paintPos.ZeilenStartX,
              ZeilenEndeX = this._paintPos.ZeilenEndeX,
              PosX = this._paintPos.PosX,
              PosY = this._paintPos.PosY,
              HoeheAktZeile = this._paintPos.HoeheAktZeile
            };
            if ((uint) paintArt > 0U)
            {
              using (Pen pen1 = new Pen(Color.Gray, 1f))
              {
                pen1.DashStyle = DashStyle.Dash;
                pen1.StartCap = LineCap.SquareAnchor;
                pen1.EndCap = LineCap.NoAnchor;
                Graphics graphics1 = e.Graphics;
                Pen pen2 = pen1;
                Point ankerPos = this.AnkerPos;
                int x1 = ankerPos.X;
                ankerPos = this.AnkerPos;
                int y1 = ankerPos.Y;
                ankerPos = this.AnkerPos;
                int x2 = ankerPos.X;
                ankerPos = element.AnkerPos;
                int y2 = ankerPos.Y;
                graphics1.DrawLine(pen2, x1, y1, x2, y2);
                pen1.StartCap = LineCap.NoAnchor;
                pen1.EndCap = LineCap.SquareAnchor;
                Graphics graphics2 = e.Graphics;
                Pen pen3 = pen1;
                ankerPos = this.AnkerPos;
                int x3 = ankerPos.X;
                ankerPos = element.AnkerPos;
                int y3 = ankerPos.Y;
                ankerPos = element.AnkerPos;
                int x4 = ankerPos.X;
                ankerPos = element.AnkerPos;
                int y4 = ankerPos.Y;
                graphics2.DrawLine(pen3, x3, y3, x4, y4);
              }
            }
            element.PaintPos = xmlEditorPaintPos2;
            element.Paint(paintArt, offSetX, offSetY, e);
            break;
          default:
            int num = (int) MessageBox.Show("undefiniert");
            break;
        }
        this._paintPos.PosX = element.PaintPos.PosX;
        this._paintPos.PosY = element.PaintPos.PosY;
        this._paintPos.HoeheAktZeile = element.PaintPos.HoeheAktZeile;
        this._paintPos.BisherMaxX = Math.Max(this._paintPos.BisherMaxX, element.PaintPos.BisherMaxX);
      }
      while (this._xmlNode.ChildNodes.Count < this._childElemente.Count)
      {
        XMLElement xmlElement = (XMLElement) this._childElemente[this._childElemente.Count - 1];
        this._childElemente.Remove(this._childElemente[this._childElemente.Count - 1]);
        xmlElement.Dispose();
        this._childElemente.TrimToSize();
      }
    }

    protected virtual void NodeZeichnenAbschluss(
      XMLPaintArten paintArt,
      int offSetX,
      int offSetY,
      PaintEventArgs e)
    {
      this.ZeichneCursorStrich(e);
    }

    protected virtual void ZeichneCursorStrich(PaintEventArgs e)
    {
      if (this._xmlEditor.CursorRoh.IstEtwasSelektiert || this._xmlNode != this._xmlEditor.CursorOptimiert.StartPos.AktNode || (this._xmlEditor.CursorOptimiert.StartPos.PosAmNode == XMLCursorPositionen.CursorAufNodeSelbstVorderesTag || this._xmlEditor.CursorOptimiert.StartPos.PosAmNode == XMLCursorPositionen.CursorAufNodeSelbstHinteresTag))
        return;
      if (this._xmlEditor.CursorBlinkOn)
      {
        using (Pen pen = new Pen(Color.Black, 2f))
          e.Graphics.DrawLine(pen, this._cursorStrichPos.X, this._cursorStrichPos.Y + 1, this._cursorStrichPos.X, this._cursorStrichPos.Y + 20);
      }
      this._xmlEditor.AktScrollingCursorPos = this._cursorStrichPos;
    }

    private void KlickbereicheAnzeigen(PaintEventArgs e)
    {
      using (Pen pen = new Pen(Color.Red, 1f))
      {
        foreach (Rectangle rect in (CollectionBase) this._klickBereiche)
          e.Graphics.DrawRectangle(pen, rect);
      }
    }

    private void MausklickBereicheBufferLeeren()
    {
      this._klickBereiche.Clear();
    }

    private void _xmlEditor_xmlElementeAufraeumenEvent(object sender, EventArgs e)
    {
      if (this._xmlNode == null)
      {
        this.Dispose();
      }
      else
      {
        if (this._xmlNode.ParentNode != null)
          return;
        this.Dispose();
      }
    }

    protected virtual void WurdeAngeklickt(Point point, MausKlickAktionen aktion)
    {
      this._xmlEditor.CursorRoh.CursorPosSetzenDurchMausAktion(this._xmlNode, XMLCursorPositionen.CursorAufNodeSelbstVorderesTag, aktion);
    }

    private void _xmlEditor_MouseDownEvent(object sender, MouseEventArgs e)
    {
      Point point = new Point(e.X, e.Y);
      foreach (Rectangle rectangle in (CollectionBase) this._klickBereiche)
      {
        if (rectangle.Contains(point))
        {
          this.WurdeAngeklickt(point, MausKlickAktionen.MouseDown);
          break;
        }
      }
    }

    private void _xmlEditor_MouseUpEvent(object sender, MouseEventArgs e)
    {
      Point point = new Point(e.X, e.Y);
      foreach (Rectangle rectangle in (CollectionBase) this._klickBereiche)
      {
        if (rectangle.Contains(point))
        {
          this.WurdeAngeklickt(point, MausKlickAktionen.MouseUp);
          break;
        }
      }
    }

    private void _xmlEditor_MouseDownMoveEvent(object sender, MouseEventArgs e)
    {
      Point point = new Point(e.X, e.Y);
      foreach (Rectangle rectangle in (CollectionBase) this._klickBereiche)
      {
        if (rectangle.Contains(point))
        {
          this.WurdeAngeklickt(point, MausKlickAktionen.MouseDownMove);
          break;
        }
      }
    }

    private void Cursor_ChangedEvent(object sender, EventArgs e)
    {
      if (this._xmlNode.ParentNode == null)
        this.Dispose();
      else if (((XMLCursor) sender).StartPos.AktNode != this._xmlNode)
        ;
    }

    public void Dispose()
    {
      this.Dispose(true);
    }

    protected virtual void Dispose(bool disposing)
    {
      if (!this._disposed && disposing)
      {
        this._xmlEditor.CursorRoh.ChangedEvent -= new EventHandler(this.Cursor_ChangedEvent);
        this._xmlEditor.MouseDownEvent -= new MouseEventHandler(this._xmlEditor_MouseDownEvent);
        this._xmlEditor.MouseUpEvent -= new MouseEventHandler(this._xmlEditor_MouseUpEvent);
        this._xmlEditor.MouseDownMoveEvent -= new MouseEventHandler(this._xmlEditor_MouseDownMoveEvent);
        this._xmlEditor.xmlElementeAufraeumenEvent -= new EventHandler(this._xmlEditor_xmlElementeAufraeumenEvent);
        foreach (XMLElement xmlElement in this._childElemente)
        {
          if (xmlElement != null)
            xmlElement.Dispose();
        }
        this._paintPos = (XMLEditorPaintPos) null;
        this._xmlEditor = (XMLEditor) null;
      }
      this._disposed = true;
    }
  }
}
