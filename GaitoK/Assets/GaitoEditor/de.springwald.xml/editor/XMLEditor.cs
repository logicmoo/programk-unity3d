// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLEditor
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.toolbox;
using de.springwald.xml.cursor;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace de.springwald.xml.editor
{
  public class XMLEditor : IDisposable
  {
    private bool _cursorBlinkOn = true;
    private bool _mausIstGedrueckt = false;
    private bool _naechsteTasteBeiKeyPressAlsTextAufnehmen = true;
    private bool _naechstesLostFokusVerhindern = false;
    private XMLCursor _cursor;
    private XmlNode _rootNode;
    private int _wunschUmbruchXBuffer;
    private Timer _timerCursorBlink;
    private bool _disposed;
    private int _virtuelleBreite;
    private int _virtuelleHoehe;
    private Point _aktScrollingCursorPos_;
    private VScrollBar _vScrollBar;
    private HScrollBar _hScrollBar;
    private XMLUndoHandler _undoHandler;
    private Control _zeichnungsSteuerelement;
    private XMLElement _rootElement;

    private bool AktionenMoeglich
    {
      get
      {
        if (this.ReadOnly)
          return false;
        return this._cursor.StartPos.AktNode != null;
      }
    }

    public virtual bool IstEtwasInZwischenablage
    {
      get
      {
        return Clipboard.ContainsText(TextDataFormat.Text);
      }
    }

    public virtual bool IstEtwasSelektiert
    {
      get
      {
        return this.CursorOptimiert.IstEtwasSelektiert;
      }
    }

    public virtual bool AktionPasteFromClipboard(
      XMLEditor.UndoSnapshotSetzenOptionen undoSnapshotSetzen)
    {
      if (!this.AktionenMoeglich)
        return false;
      string str = "";
      try
      {
        if (!Clipboard.ContainsText(TextDataFormat.Text))
          return false;
        if (this.IstRootNodeSelektiert)
          return this.AktionRootNodeDurchClipboardInhaltErsetzen(undoSnapshotSetzen);
        XMLCursorPos startPos;
        if (this.IstEtwasSelektiert)
        {
          if (!this.AktionDelete(XMLEditor.UndoSnapshotSetzenOptionen.nein))
            return false;
          startPos = this._cursor.StartPos;
        }
        else
          startPos = this.CursorOptimiert.StartPos;
        if (undoSnapshotSetzen == XMLEditor.UndoSnapshotSetzenOptionen.ja)
          this._undoHandler.SnapshotSetzen(de.springwald.xml.ResReader.Reader.GetString("AktionEinfuegen"), this._cursor);
        str = Clipboard.GetText(TextDataFormat.Text);
        str = str.Replace("\r\n", " ");
        str = str.Replace("\n\r", " ");
        str = str.Replace("\r", " ");
        str = str.Replace("\n", " ");
        str = str.Replace("\t", " ");
        XmlTextReader xmlTextReader = new XmlTextReader(string.Format("<paste>{0}</paste>", (object) str), XmlNodeType.Element, (XmlParserContext) null);
        int content = (int) xmlTextReader.MoveToContent();
        XmlNode xmlNode = this._rootNode.OwnerDocument.ReadNode((XmlReader) xmlTextReader);
        XMLCursorPos xmlCursorPos = startPos.Clone();
        foreach (XmlNode childNode in xmlNode.ChildNodes)
        {
          if (childNode is XmlText)
          {
            XmlNode ersatzNode = (XmlNode) null;
            xmlCursorPos.TextEinfuegen(childNode.Clone().Value, this.Regelwerk, out ersatzNode);
            if (ersatzNode != null)
              xmlCursorPos.InsertXMLNode(ersatzNode.Clone(), this.Regelwerk, true);
          }
          else
            xmlCursorPos.InsertXMLNode(childNode.Clone(), this.Regelwerk, true);
        }
        switch (this._cursor.EndPos.PosAmNode)
        {
          case XMLCursorPositionen.CursorVorDemNode:
          case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
            this._cursor.BeideCursorPosSetzen(xmlCursorPos.AktNode, xmlCursorPos.PosAmNode, xmlCursorPos.PosImTextnode);
            break;
          default:
            this._cursor.BeideCursorPosSetzen(xmlCursorPos.AktNode, XMLCursorPositionen.CursorHinterDemNode);
            break;
        }
        return true;
      }
      catch (Exception ex)
      {
        Debugger.GlobalDebugger.Protokolliere(string.Format("AktionPasteFromClipboard:Fehler für Einfügetext '{0}':{1}", (object) str, (object) ex.Message), Debugger.ProtokollTypen.Fehlermeldung);
        return false;
      }
    }

    private void AktionenEnterGedrueckt()
    {
    }

    private bool AktionRootNodeDurchClipboardInhaltErsetzen(
      XMLEditor.UndoSnapshotSetzenOptionen undoSnapshotSetzen)
    {
      if (!this.AktionenMoeglich)
        return false;
      string xmlFragment = "";
      try
      {
        xmlFragment = Clipboard.GetText(TextDataFormat.Text);
        XmlTextReader xmlTextReader = new XmlTextReader(xmlFragment, XmlNodeType.Element, (XmlParserContext) null);
        int content = (int) xmlTextReader.MoveToContent();
        XmlNode xmlNode = this._rootNode.OwnerDocument.ReadNode((XmlReader) xmlTextReader);
        if (xmlNode.Name != this._rootNode.Name)
          return false;
        if (undoSnapshotSetzen == XMLEditor.UndoSnapshotSetzenOptionen.ja)
          this._undoHandler.SnapshotSetzen(de.springwald.xml.ResReader.Reader.GetString("RootNodedurchZwischenablageersetzen"), this._cursor);
        this._rootNode.RemoveAll();
        while (xmlNode.Attributes.Count > 0)
          this._rootNode.Attributes.Append(xmlNode.Attributes.Remove(xmlNode.Attributes[0]));
        XMLCursorPos xmlCursorPos = new XMLCursorPos();
        xmlCursorPos.CursorSetzen(this._rootNode, XMLCursorPositionen.CursorInDemLeeremNode);
        xmlCursorPos.Clone();
        while (xmlNode.ChildNodes.Count > 0)
          this._rootNode.AppendChild(xmlNode.RemoveChild(xmlNode.FirstChild));
        this.ContentChanged();
        this._cursor.BeideCursorPosSetzen(this._rootNode, XMLCursorPositionen.CursorAufNodeSelbstVorderesTag);
        this._cursor.ErzwingeChanged();
        return true;
      }
      catch (Exception ex)
      {
        Debugger.GlobalDebugger.Protokolliere(string.Format("AktionRootNodeDurchClipboardInhaltErsetzen:Fehler für Einfügetext '{0}':{1}", (object) xmlFragment, (object) ex.Message), Debugger.ProtokollTypen.Fehlermeldung);
        return false;
      }
    }

    public virtual bool AktionCopyToClipboard()
    {
      if (!this.AktionenMoeglich)
        return false;
      string selektionAlsString = this._cursor.SelektionAlsString;
      if (string.IsNullOrEmpty(selektionAlsString))
        return false;
      try
      {
        Clipboard.Clear();
        Clipboard.SetText(selektionAlsString, TextDataFormat.Text);
      }
      catch (Exception ex)
      {
        return false;
      }
      return true;
    }

    public virtual bool AktionCursorAufPos1()
    {
      if (this._rootNode == null)
        return false;
      if (this._rootNode.FirstChild != null)
        this._cursor.BeideCursorPosSetzen(this._rootNode.FirstChild, XMLCursorPositionen.CursorVorDemNode);
      else
        this._cursor.BeideCursorPosSetzen(this._rootNode, XMLCursorPositionen.CursorInDemLeeremNode);
      return true;
    }

    public virtual bool AktionAllesMarkieren()
    {
      this._cursor.BeideCursorPosSetzen(this._rootNode, XMLCursorPositionen.CursorAufNodeSelbstVorderesTag);
      return true;
    }

    public virtual bool AktionCutToClipboard(
      XMLEditor.UndoSnapshotSetzenOptionen undoSnapshotSetzen)
    {
      if (!this.AktionenMoeglich)
        return false;
      if (this._cursor != this._cursor)
        ;
      return this.CursorOptimiert.StartPos.AktNode != this._rootNode && this.AktionCopyToClipboard() && this.AktionDelete(XMLEditor.UndoSnapshotSetzenOptionen.ja);
    }

    public virtual bool AktionDelete(
      XMLEditor.UndoSnapshotSetzenOptionen undoSnapshotSetzen)
    {
      if (!this.AktionenMoeglich || this.IstRootNodeSelektiert)
        return false;
      if (undoSnapshotSetzen == XMLEditor.UndoSnapshotSetzenOptionen.ja)
        this._undoHandler.SnapshotSetzen(de.springwald.xml.ResReader.Reader.GetString("AktionLoeschen"), this._cursor);
      XMLCursor cursor = this._cursor;
      cursor.SelektionOptimieren();
      XMLCursorPos neueCursorPosNachLoeschen;
      if (!cursor.SelektionLoeschen(out neueCursorPosNachLoeschen))
        return false;
      this._cursor.BeideCursorPosSetzen(neueCursorPosNachLoeschen.AktNode, neueCursorPosNachLoeschen.PosAmNode, neueCursorPosNachLoeschen.PosImTextnode);
      this.ContentChanged();
      return true;
    }

    public virtual bool AktionTextAnCursorPosEinfuegen(
      string einfuegeText,
      XMLEditor.UndoSnapshotSetzenOptionen undoSnapshotSetzen)
    {
      if (!this.AktionenMoeglich)
        return false;
      if (undoSnapshotSetzen == XMLEditor.UndoSnapshotSetzenOptionen.ja)
        this._undoHandler.SnapshotSetzen(string.Format(de.springwald.xml.ResReader.Reader.GetString("AktionSchreiben"), (object) einfuegeText), this._cursor);
      this._cursor.TextEinfuegen(einfuegeText, this.Regelwerk);
      this.ContentChanged();
      return true;
    }

    public virtual bool AktionAttributWertInNodeSetzen(
      XmlNode node,
      string attributName,
      string wert,
      XMLEditor.UndoSnapshotSetzenOptionen undoSnapshotSetzen)
    {
      if (!this.AktionenMoeglich)
        return false;
      XmlAttribute attribute1 = node.Attributes[attributName];
      if (wert == "")
      {
        if (attribute1 != null)
        {
          if (undoSnapshotSetzen == XMLEditor.UndoSnapshotSetzenOptionen.ja)
            this._undoHandler.SnapshotSetzen(string.Format(de.springwald.xml.ResReader.Reader.GetString("AktionAttributGeloescht"), (object) attributName, (object) node.Name), this._cursor);
          node.Attributes.Remove(attribute1);
        }
      }
      else if (attribute1 == null)
      {
        if (undoSnapshotSetzen == XMLEditor.UndoSnapshotSetzenOptionen.ja)
          this._undoHandler.SnapshotSetzen(string.Format(de.springwald.xml.ResReader.Reader.GetString("AktionAttributValueGeaendert"), (object) attributName, (object) node.Name, (object) wert), this._cursor);
        XmlAttribute attribute2 = node.OwnerDocument.CreateAttribute(attributName);
        node.Attributes.Append(attribute2);
        attribute2.Value = wert;
      }
      else if (attribute1.Value != wert)
      {
        if (undoSnapshotSetzen == XMLEditor.UndoSnapshotSetzenOptionen.ja)
          this._undoHandler.SnapshotSetzen(string.Format(de.springwald.xml.ResReader.Reader.GetString("AktionAttributValueGeaendert"), (object) attributName, (object) node.Name, (object) wert), this._cursor);
        attribute1.Value = wert;
      }
      this.ContentChanged();
      return true;
    }

    public bool AktionNodeOderZeichenVorDerCursorPosLoeschen(
      XMLCursorPos position,
      XMLEditor.UndoSnapshotSetzenOptionen undoSnapshotSetzen)
    {
      if (!this.AktionenMoeglich)
        return false;
      XMLCursor xmlCursor = new XMLCursor();
      xmlCursor.StartPos.CursorSetzen(position.AktNode, position.PosAmNode, position.PosImTextnode);
      XMLCursorPos xmlCursorPos = xmlCursor.StartPos.Clone();
      xmlCursorPos.MoveLeft(this._rootNode, this.Regelwerk);
      xmlCursor.EndPos.CursorSetzen(xmlCursorPos.AktNode, xmlCursorPos.PosAmNode, xmlCursorPos.PosImTextnode);
      xmlCursor.SelektionOptimieren();
      if (xmlCursor.StartPos.AktNode == this._rootNode)
        return false;
      if (undoSnapshotSetzen == XMLEditor.UndoSnapshotSetzenOptionen.ja)
        this._undoHandler.SnapshotSetzen(de.springwald.xml.ResReader.Reader.GetString("AktionLoeschen"), this._cursor);
      XMLCursorPos neueCursorPosNachLoeschen;
      if (!xmlCursor.SelektionLoeschen(out neueCursorPosNachLoeschen))
        return false;
      this._cursor.BeideCursorPosSetzen(neueCursorPosNachLoeschen.AktNode, neueCursorPosNachLoeschen.PosAmNode, neueCursorPosNachLoeschen.PosImTextnode);
      this.ContentChanged();
      return true;
    }

    public bool AktionNodeOderZeichenHinterCursorPosLoeschen(
      XMLCursorPos position,
      XMLEditor.UndoSnapshotSetzenOptionen undoSnapshotSetzen)
    {
      if (!this.AktionenMoeglich)
        return false;
      if (undoSnapshotSetzen == XMLEditor.UndoSnapshotSetzenOptionen.ja)
        this._undoHandler.SnapshotSetzen(de.springwald.xml.ResReader.Reader.GetString("AktionLoeschen"), this._cursor);
      XMLCursor xmlCursor = new XMLCursor();
      xmlCursor.StartPos.CursorSetzen(position.AktNode, position.PosAmNode, position.PosImTextnode);
      XMLCursorPos xmlCursorPos = xmlCursor.StartPos.Clone();
      xmlCursorPos.MoveRight(this._rootNode, this.Regelwerk);
      xmlCursor.EndPos.CursorSetzen(xmlCursorPos.AktNode, xmlCursorPos.PosAmNode, xmlCursorPos.PosImTextnode);
      xmlCursor.SelektionOptimieren();
      XMLCursorPos neueCursorPosNachLoeschen;
      if (xmlCursor.StartPos.AktNode == this._rootNode || !xmlCursor.SelektionLoeschen(out neueCursorPosNachLoeschen))
        return false;
      this._cursor.BeideCursorPosSetzen(neueCursorPosNachLoeschen.AktNode, neueCursorPosNachLoeschen.PosAmNode, neueCursorPosNachLoeschen.PosImTextnode);
      this._cursor.ErzwingeChanged();
      this.ContentChanged();
      return true;
    }

    public virtual XmlNode AktionNeuesElementAnAktCursorPosEinfuegen(
      string nodeName,
      XMLEditor.UndoSnapshotSetzenOptionen undoSnapshotSetzen,
      bool neueCursorPosAufJedenFallHinterDenEingefuegtenNodeSetzen)
    {
      if (!this.AktionenMoeglich)
        return (XmlNode) null;
      if (nodeName == "")
        throw new ApplicationException(de.springwald.xml.ResReader.Reader.GetString("KeinNodeNameAngegeben"));
      if (undoSnapshotSetzen == XMLEditor.UndoSnapshotSetzenOptionen.ja)
        this._undoHandler.SnapshotSetzen(string.Format(de.springwald.xml.ResReader.Reader.GetString("AktionInsertNode"), (object) nodeName), this._cursor);
      XmlNode node = !(nodeName == "#COMMENT") ? this._rootNode.OwnerDocument.CreateNode(XmlNodeType.Element, nodeName, (string) null) : (XmlNode) this._rootNode.OwnerDocument.CreateComment("NEW COMMENT");
      this._cursor.XMLNodeEinfuegen(node, this.Regelwerk, neueCursorPosAufJedenFallHinterDenEingefuegtenNodeSetzen);
      this.ContentChanged();
      return node;
    }

    public event EventHandler ContentChangedEvent;

    protected virtual void ContentChanged()
    {
      if (this.ContentChangedEvent != null)
        this.ContentChangedEvent((object) this, EventArgs.Empty);
      if (this._zeichnungsSteuerelement != null)
        this._zeichnungsSteuerelement.Invalidate();
      this.CursorBlinkOn = true;
      this.xmlElementeAufraeumen();
    }

    public bool ReadOnly { get; set; }

    public int WunschUmbruchX_
    {
      get
      {
        return this._zeichnungsSteuerelement.Width - 100;
      }
    }

    public XMLRegelwerk Regelwerk { get; set; }

    public XMLCursor CursorOptimiert
    {
      get
      {
        XMLCursor xmlCursor = this._cursor.Clone();
        xmlCursor.SelektionOptimieren();
        return xmlCursor;
      }
    }

    public XMLCursor CursorRoh
    {
      get
      {
        return this._cursor;
      }
    }

    public XmlNode RootNode
    {
      get
      {
        return this._rootNode;
      }
      set
      {
        this._rootNode = value;
        if (this._rootNode == null)
        {
          if (this._rootElement != null)
          {
            this._rootElement.Dispose();
            this._rootElement = (XMLElement) null;
          }
          this._zeichnungsSteuerelement.Enabled = false;
        }
        else
        {
          if (this._rootElement != null && this._rootElement.XMLNode != this._rootNode)
          {
            this._rootElement.Dispose();
            this._rootElement = (XMLElement) null;
          }
          if (this._rootElement == null)
            this._rootElement = this.createElement(this._rootNode);
          if (this._undoHandler != null && this._undoHandler.RootNode != this._rootNode)
          {
            this._undoHandler.Dispose();
            this._undoHandler = (XMLUndoHandler) null;
          }
          if (this._undoHandler == null)
            this._undoHandler = new XMLUndoHandler(this._rootNode);
          this._zeichnungsSteuerelement.Enabled = true;
        }
        this.ContentChanged();
      }
    }

    public bool IstRootNodeSelektiert
    {
      get
      {
        if (this.IstEtwasSelektiert)
        {
          XMLCursorPos startPos = this.CursorOptimiert.StartPos;
          if (startPos.AktNode == this.RootNode)
          {
            switch (startPos.PosAmNode)
            {
              case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
              case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
                return true;
            }
          }
        }
        return false;
      }
    }

    public XMLEditor(XMLRegelwerk regelwerk, Control zeichnungsSteuerelement)
    {
      this.Regelwerk = regelwerk;
      this._zeichnungsSteuerelement = zeichnungsSteuerelement;
      this._zeichnungsSteuerelement.Enabled = false;
      this._cursor = new XMLCursor();
      this._cursor.ChangedEvent += new EventHandler(this._cursor_ChangedEvent);
      this.MausEventsAnmelden();
      this.TastaturEventsAnmelden(zeichnungsSteuerelement);
      this.InitCursorBlink();
      this.InitScrolling();
    }

    public virtual XMLElement createElement(XmlNode xmlNode)
    {
      return this.Regelwerk.createPaintElementForNode(xmlNode, this);
    }

    private void _cursor_ChangedEvent(object sender, EventArgs e)
    {
      this.ScrollingNotwendig();
      if (this._zeichnungsSteuerelement != null)
        this._zeichnungsSteuerelement.Invalidate();
      this.CursorBlinkOn = true;
    }

    public bool HatFokus
    {
      get
      {
        if (this._zeichnungsSteuerelement == null)
          return false;
        return this._zeichnungsSteuerelement.Focused;
      }
    }

    public bool CursorBlinkOn
    {
      get
      {
        return this._cursorBlinkOn;
      }
      set
      {
        this._cursorBlinkOn = this._zeichnungsSteuerelement == null ? value : this._zeichnungsSteuerelement.Focused && value;
        this._timerCursorBlink.Enabled = false;
        this._timerCursorBlink.Enabled = true;
      }
    }

    private void InitCursorBlink()
    {
      this._timerCursorBlink = new Timer();
      this._timerCursorBlink.Enabled = this._cursorBlinkOn;
      this._timerCursorBlink.Interval = 600;
      this._timerCursorBlink.Tick += new EventHandler(this._timerCursorBlink_Tick);
    }

    private void _timerCursorBlink_Tick(object sender, EventArgs e)
    {
      if (this._zeichnungsSteuerelement == null)
        return;
      if (this.HatFokus)
      {
        this._cursorBlinkOn = !this._cursorBlinkOn;
        this._zeichnungsSteuerelement.Invalidate();
      }
      else if (this._cursorBlinkOn)
      {
        this._cursorBlinkOn = false;
        this._zeichnungsSteuerelement.Invalidate();
      }
    }

    public event EventHandler xmlElementeAufraeumenEvent;

    protected virtual void xmlElementeAufraeumen()
    {
      if (this.xmlElementeAufraeumenEvent == null)
        return;
      this.xmlElementeAufraeumenEvent((object) this, EventArgs.Empty);
    }

    public void Dispose()
    {
      if (this._disposed)
        return;
      this.xmlElementeAufraeumen();
      this._disposed = true;
    }

    public event MouseEventHandler MouseDownEvent;

    protected virtual void MouseDown(MouseEventArgs e)
    {
      if (this.MouseDownEvent == null)
        return;
      this.MouseDownEvent((object) this, e);
    }

    public event MouseEventHandler MouseUpEvent;

    protected virtual void MouseUp(MouseEventArgs e)
    {
      if (this.MouseUpEvent == null)
        return;
      this.MouseUpEvent((object) this, e);
    }

    public event MouseEventHandler MouseDownMoveEvent;

    protected virtual void MouseDownMove(MouseEventArgs e)
    {
      if (this.MouseDownMoveEvent == null)
        return;
      this.MouseDownMoveEvent((object) this, e);
    }

    private void MausEventsAnmelden()
    {
      this._zeichnungsSteuerelement.MouseDown += new MouseEventHandler(this._zeichnungsSteuerelement_MouseDown);
      this._zeichnungsSteuerelement.MouseMove += new MouseEventHandler(this._zeichnungsSteuerelement_MouseMove);
      this._zeichnungsSteuerelement.MouseUp += new MouseEventHandler(this._zeichnungsSteuerelement_MouseUp);
    }

    private void _zeichnungsSteuerelement_MouseDown(object sender, MouseEventArgs e)
    {
      this._mausIstGedrueckt = true;
      this.MouseDown(e);
    }

    private void _zeichnungsSteuerelement_MouseUp(object sender, MouseEventArgs e)
    {
      this._mausIstGedrueckt = false;
      this.MouseUp(e);
    }

    private void _zeichnungsSteuerelement_MouseMove(object sender, MouseEventArgs e)
    {
      if (!this._mausIstGedrueckt)
        return;
      this.MouseDownMove(e);
    }

    private int ZeichnungsOffsetY
    {
      get
      {
        if (this._vScrollBar.Visible)
          return -this._vScrollBar.Value;
        return 0;
      }
    }

    private int ZeichnungsOffsetX
    {
      get
      {
        if (this._hScrollBar.Visible)
          return -this._hScrollBar.Value;
        return 0;
      }
    }

    public Point AktScrollingCursorPos
    {
      set
      {
        this._aktScrollingCursorPos_ = value;
      }
      get
      {
        return this._aktScrollingCursorPos_;
      }
    }

    private void InitScrolling()
    {
      if (this._zeichnungsSteuerelement == null)
        return;
      this._vScrollBar = new VScrollBar();
      this._hScrollBar = new HScrollBar();
      this._zeichnungsSteuerelement.Controls.Add((Control) this._vScrollBar);
      this._zeichnungsSteuerelement.Controls.Add((Control) this._hScrollBar);
      this._vScrollBar.ValueChanged += new EventHandler(this._vScrollBar_ValueChanged);
      this._hScrollBar.ValueChanged += new EventHandler(this._hScrollBar_ValueChanged);
      this._zeichnungsSteuerelement.Resize += new EventHandler(this._zeichnungsSteuerelement_Resize);
      this._zeichnungsSteuerelement_Resize((object) null, (EventArgs) null);
      this._zeichnungsSteuerelement.MouseWheel += new MouseEventHandler(this._zeichnungsSteuerelement_MouseWheel);
    }

    private void ScrollingNotwendig()
    {
      this.DoTheScrollIntern();
    }

    private void DoTheScrollIntern()
    {
      this.ScrollbarsAnzeigen();
      this.CursorInSichtbarenBereichScrollen();
    }

    private void _hScrollBar_ValueChanged(object sender, EventArgs e)
    {
      this._zeichnungsSteuerelement.Invalidate();
    }

    private void _vScrollBar_ValueChanged(object sender, EventArgs e)
    {
      this._zeichnungsSteuerelement.Invalidate();
    }

    private void _zeichnungsSteuerelement_MouseWheel(object sender, MouseEventArgs e)
    {
      if (!this._vScrollBar.Visible)
        return;
      this._vScrollBar.Value = Math.Max(0, Math.Min(this._vScrollBar.Maximum - this._vScrollBar.LargeChange, Math.Max(0, this._vScrollBar.Value - e.Delta)));
    }

    private void ScrollbarsAnzeigen()
    {
      if (this._vScrollBar.Height > this._virtuelleHoehe + 20)
      {
        this._vScrollBar.Value = 0;
        this._vScrollBar.Visible = false;
      }
      else
      {
        this._vScrollBar.Visible = true;
        this._vScrollBar.Maximum = this._virtuelleHoehe;
        this._vScrollBar.LargeChange = this._zeichnungsSteuerelement.Height;
      }
      if (this._hScrollBar.Width > this._virtuelleBreite + 20)
      {
        this._hScrollBar.Value = 0;
        this._hScrollBar.Visible = false;
      }
      else
      {
        this._hScrollBar.Visible = true;
        this._hScrollBar.Maximum = this._virtuelleBreite;
        this._hScrollBar.LargeChange = this._zeichnungsSteuerelement.Width;
      }
      this._vScrollBar.Top = 0;
      this._vScrollBar.Left = this._zeichnungsSteuerelement.Width - this._vScrollBar.Width;
      if (this._hScrollBar.Visible)
        this._vScrollBar.Height = this._zeichnungsSteuerelement.Height - this._hScrollBar.Height;
      else
        this._vScrollBar.Height = this._zeichnungsSteuerelement.Height;
      this._hScrollBar.Left = 0;
      this._hScrollBar.Top = this._zeichnungsSteuerelement.Height - this._hScrollBar.Height;
      if (this._vScrollBar.Visible)
        this._hScrollBar.Width = this._zeichnungsSteuerelement.Width - this._vScrollBar.Width;
      else
        this._hScrollBar.Width = this._zeichnungsSteuerelement.Width;
    }

    public void CursorInSichtbarenBereichScrollen()
    {
      Point scrollingCursorPos;
      if (this._hScrollBar.Visible)
      {
        scrollingCursorPos = this.AktScrollingCursorPos;
        int x = scrollingCursorPos.X;
        if (x < 0)
        {
          this._hScrollBar.Value = Math.Max(0, this._hScrollBar.Value + x);
        }
        else
        {
          scrollingCursorPos = this.AktScrollingCursorPos;
          int num = scrollingCursorPos.X + -this._hScrollBar.Width;
          if (num > 0)
            this._hScrollBar.Value = Math.Max(0, Math.Min(this._virtuelleBreite - this._hScrollBar.LargeChange, this._hScrollBar.Value + num));
        }
      }
      if (!this._vScrollBar.Visible)
        return;
      scrollingCursorPos = this.AktScrollingCursorPos;
      int y = scrollingCursorPos.Y;
      if (y < 0)
      {
        this._vScrollBar.Value = Math.Max(0, this._vScrollBar.Value + y);
      }
      else
      {
        scrollingCursorPos = this.AktScrollingCursorPos;
        int num = scrollingCursorPos.Y + 20 + -this._vScrollBar.Height;
        if (num > 0)
          this._vScrollBar.Value = Math.Max(0, Math.Min(this._virtuelleHoehe - this._vScrollBar.LargeChange, this._vScrollBar.Value + num));
      }
    }

    private void _zeichnungsSteuerelement_Resize(object sender, EventArgs e)
    {
      this.ScrollbarsAnzeigen();
    }

    public event KeyEventHandler KeyDownEvent;

    protected virtual void KeyDown(KeyEventArgs e)
    {
      if (this.KeyDownEvent == null)
        return;
      this.KeyDownEvent((object) this, e);
    }

    public event KeyPressEventHandler KeyPressEvent;

    protected virtual void KeyPress(KeyPressEventArgs e)
    {
      if (this.KeyPressEvent == null)
        return;
      this.KeyPressEvent((object) this, e);
    }

    private void TastaturEventsAnmelden(Control zeichnungsSteuerelement)
    {
      zeichnungsSteuerelement.Leave += new EventHandler(this.zeichnungsSteuerelement_Leave);
      zeichnungsSteuerelement.PreviewKeyDown += new PreviewKeyDownEventHandler(this.zeichnungsSteuerelement_PreviewKeyDown);
      zeichnungsSteuerelement.KeyPress += new KeyPressEventHandler(this.zeichnungsSteuerelement_KeyPress);
    }

    private void zeichnungsSteuerelement_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
    {
      if (this.Regelwerk.PreviewKeyDown(e, out this._naechsteTasteBeiKeyPressAlsTextAufnehmen, this))
        return;
      this._naechsteTasteBeiKeyPressAlsTextAufnehmen = false;
      switch (e.KeyData)
      {
        case Keys.Back:
        case Keys.Back | Keys.Shift:
          if (this._cursor.IstEtwasSelektiert)
          {
            this.AktionDelete(XMLEditor.UndoSnapshotSetzenOptionen.ja);
            goto case Keys.Escape;
          }
          else
          {
            this.AktionNodeOderZeichenVorDerCursorPosLoeschen(this._cursor.StartPos, XMLEditor.UndoSnapshotSetzenOptionen.ja);
            goto case Keys.Escape;
          }
        case Keys.Tab:
          XmlNode node = this._cursor.StartPos.AktNode;
          bool flag = false;
          if (node.FirstChild != null)
            node = node.FirstChild;
          else if (node.NextSibling != null)
            node = node.NextSibling;
          else if (node.ParentNode.NextSibling != null)
            node = node.ParentNode.NextSibling;
          else
            flag = true;
          if (!flag)
            this._cursor.BeideCursorPosSetzen(node, XMLCursorPositionen.CursorInDemLeeremNode);
          this._naechstesLostFokusVerhindern = true;
          goto case Keys.Escape;
        case Keys.Return:
        case Keys.Return | Keys.Shift:
          this.AktionenEnterGedrueckt();
          goto case Keys.Escape;
        case Keys.Escape:
        case Keys.Control:
          break;
        case Keys.Home:
          this.AktionCursorAufPos1();
          goto case Keys.Escape;
        case Keys.Left:
          XMLCursorPos xmlCursorPos1 = this._cursor.StartPos.Clone();
          xmlCursorPos1.MoveLeft(this._rootNode, this.Regelwerk);
          this._cursor.BeideCursorPosSetzen(xmlCursorPos1.AktNode, xmlCursorPos1.PosAmNode, xmlCursorPos1.PosImTextnode);
          goto case Keys.Escape;
        case Keys.Right:
          XMLCursorPos xmlCursorPos2 = this._cursor.StartPos.Clone();
          xmlCursorPos2.MoveRight(this._rootNode, this.Regelwerk);
          this._cursor.BeideCursorPosSetzen(xmlCursorPos2.AktNode, xmlCursorPos2.PosAmNode, xmlCursorPos2.PosImTextnode);
          goto case Keys.Escape;
        case Keys.Delete:
        case Keys.Delete | Keys.Shift:
          if (this._cursor.IstEtwasSelektiert)
          {
            this.AktionDelete(XMLEditor.UndoSnapshotSetzenOptionen.ja);
            goto case Keys.Escape;
          }
          else
          {
            this.AktionNodeOderZeichenHinterCursorPosLoeschen(this._cursor.StartPos, XMLEditor.UndoSnapshotSetzenOptionen.ja);
            goto case Keys.Escape;
          }
        case Keys.Left | Keys.Shift:
          this._cursor.EndPos.MoveLeft(this._rootNode, this.Regelwerk);
          goto case Keys.Escape;
        case Keys.Right | Keys.Shift:
          this._cursor.EndPos.MoveRight(this._rootNode, this.Regelwerk);
          goto case Keys.Escape;
        case Keys.A | Keys.Control:
          this.AktionAllesMarkieren();
          goto case Keys.Escape;
        case Keys.C | Keys.Control:
          this.AktionCopyToClipboard();
          goto case Keys.Escape;
        case Keys.V | Keys.Control:
          this.AktionPasteFromClipboard(XMLEditor.UndoSnapshotSetzenOptionen.ja);
          goto case Keys.Escape;
        case Keys.X | Keys.Control:
          this.AktionCutToClipboard(XMLEditor.UndoSnapshotSetzenOptionen.ja);
          goto case Keys.Escape;
        case Keys.Z | Keys.Control:
          this.UnDo();
          goto case Keys.Escape;
        default:
          this._naechsteTasteBeiKeyPressAlsTextAufnehmen = true;
          goto case Keys.Escape;
      }
    }

    private void zeichnungsSteuerelement_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (this._naechsteTasteBeiKeyPressAlsTextAufnehmen)
        this.AktionTextAnCursorPosEinfuegen(e.KeyChar.ToString(), XMLEditor.UndoSnapshotSetzenOptionen.ja);
      this._naechsteTasteBeiKeyPressAlsTextAufnehmen = false;
    }

    private void zeichnungsSteuerelement_Leave(object sender, EventArgs e)
    {
      if (!this._naechstesLostFokusVerhindern)
        return;
      this._naechstesLostFokusVerhindern = false;
      this.ZeichnungsSteuerelement.Focus();
    }

    public string UndoSchrittName
    {
      get
      {
        if (this.UndoMoeglich)
          return this._undoHandler.NextUndoSnapshotName;
        return de.springwald.xml.ResReader.Reader.GetString("KeinUndoSchrittVerfuegbar");
      }
    }

    public bool UndoMoeglich
    {
      get
      {
        if (this._undoHandler == null)
          return false;
        return this._undoHandler.UndoMoeglich;
      }
    }

    public void UnDo()
    {
      if (this._undoHandler == null)
        throw new ApplicationException("No Undo-Handler attached, but Undo invoked!");
      XMLCursor xmlCursor = this._undoHandler.Undo();
      if (xmlCursor != null)
      {
        this._cursor.StartPos.CursorSetzen(xmlCursor.StartPos.AktNode, xmlCursor.StartPos.PosAmNode, xmlCursor.StartPos.PosImTextnode);
        this._cursor.EndPos.CursorSetzen(xmlCursor.EndPos.AktNode, xmlCursor.EndPos.PosAmNode, xmlCursor.EndPos.PosImTextnode);
      }
      this.ContentChanged();
    }

    public Control ZeichnungsSteuerelement
    {
      get
      {
        return this._zeichnungsSteuerelement;
      }
    }

    public void Paint(PaintEventArgs e)
    {
      if (this._rootElement == null)
        return;
      XMLEditorPaintPos xmlEditorPaintPos = new XMLEditorPaintPos();
      xmlEditorPaintPos.PosX = 10 + this.ZeichnungsOffsetX;
      xmlEditorPaintPos.PosY = 10 + this.ZeichnungsOffsetY;
      xmlEditorPaintPos.ZeilenStartX = 10 + this.ZeichnungsOffsetX;
      xmlEditorPaintPos.ZeilenEndeX = this.WunschUmbruchX_ - this.ZeichnungsOffsetX;
      this._rootElement.PaintPos = xmlEditorPaintPos.Clone();
      this._rootElement.Paint(XMLPaintArten.Vorberechnen, this.ZeichnungsOffsetX, this.ZeichnungsOffsetY, e);
      this._virtuelleBreite = this._rootElement.PaintPos.BisherMaxX + 50 - this.ZeichnungsOffsetX;
      this._virtuelleHoehe = this._rootElement.PaintPos.PosY + 50 - this.ZeichnungsOffsetY;
      this._rootElement.PaintPos = xmlEditorPaintPos;
      this._rootElement.Paint(XMLPaintArten.AllesNeuZeichnenMitFehlerHighlighting, this.ZeichnungsOffsetX, this.ZeichnungsOffsetY, e);
    }

    public void FokusAufEingabeFormularSetzen()
    {
      if (this._zeichnungsSteuerelement == null)
        return;
      this._zeichnungsSteuerelement.Focus();
    }

    public enum UndoSnapshotSetzenOptionen
    {
      ja,
      nein,
    }
  }
}
