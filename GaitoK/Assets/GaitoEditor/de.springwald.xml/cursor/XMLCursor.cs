// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.cursor.XMLCursor
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.toolbox;
using System;
using System.Text;
using System.Xml;

namespace de.springwald.xml.cursor
{
  public class XMLCursor
  {
    private bool _cursorWirdGeradeGesetzt = false;
    private XMLCursorPos _startPos;
    private XMLCursorPos _endPos;

    public event EventHandler ChangedEvent;

    protected virtual void Changed(EventArgs e)
    {
      if (this.ChangedEvent == null)
        return;
      this.ChangedEvent((object) this, e);
    }

    public XMLCursorPos StartPos
    {
      get
      {
        return this._startPos;
      }
    }

    public XMLCursorPos EndPos
    {
      get
      {
        return this._endPos;
      }
    }

    public XMLCursor()
    {
      this._endPos = new XMLCursorPos();
      this._startPos = new XMLCursorPos();
      this.UnterEventsAnmelden();
    }

    public XMLCursor Clone()
    {
      XMLCursor xmlCursor = new XMLCursor();
      xmlCursor.StartPos.CursorSetzen(this._startPos.AktNode, this._startPos.PosAmNode, this._startPos.PosImTextnode);
      xmlCursor.EndPos.CursorSetzen(this._endPos.AktNode, this._endPos.PosAmNode, this._endPos.PosImTextnode);
      return xmlCursor;
    }

    public void ErzwingeChanged()
    {
      this.Changed(EventArgs.Empty);
    }

    public void BeideCursorPosSetzen(
      XmlNode node,
      XMLCursorPositionen posAmNode,
      int posImTextnode)
    {
      bool flag = node != this._startPos.AktNode || (posAmNode != this._startPos.PosAmNode || posImTextnode != this._startPos.PosImTextnode);
      if (!flag)
        flag = node != this._endPos.AktNode || (posAmNode != this._endPos.PosAmNode || posImTextnode != this._endPos.PosImTextnode);
      this._cursorWirdGeradeGesetzt = true;
      this._startPos.CursorSetzen(node, posAmNode, posImTextnode);
      this._endPos.CursorSetzen(node, posAmNode, posImTextnode);
      this._cursorWirdGeradeGesetzt = false;
      if (!flag)
        return;
      this.Changed(EventArgs.Empty);
    }

    public void BeideCursorPosSetzen(XmlNode node, XMLCursorPositionen posAmNode)
    {
      this.BeideCursorPosSetzen(node, posAmNode, 0);
    }

    public void CursorPosSetzenDurchMausAktion(
      XmlNode xmlNode,
      XMLCursorPositionen cursorPos,
      int posInZeile,
      MausKlickAktionen aktion)
    {
      switch (aktion)
      {
        case MausKlickAktionen.MouseDown:
          this.BeideCursorPosSetzen(xmlNode, cursorPos, posInZeile);
          break;
        case MausKlickAktionen.MouseDownMove:
        case MausKlickAktionen.MouseUp:
          this.EndPos.CursorSetzen(xmlNode, cursorPos, posInZeile);
          break;
      }
    }

    public void CursorPosSetzenDurchMausAktion(
      XmlNode xmlNode,
      XMLCursorPositionen cursorPos,
      MausKlickAktionen aktion)
    {
      this.CursorPosSetzenDurchMausAktion(xmlNode, cursorPos, 0, aktion);
    }

    private void UnterEventsAnmelden()
    {
      this._endPos.PosChangedEvent += new EventHandler(this.endPos_ChangedEvent);
      this._startPos.PosChangedEvent += new EventHandler(this.startPos_ChangedEvent);
    }

    private void endPos_ChangedEvent(object sender, EventArgs e)
    {
      if (this._cursorWirdGeradeGesetzt)
        return;
      this.Changed(EventArgs.Empty);
    }

    private void startPos_ChangedEvent(object sender, EventArgs e)
    {
      if (this._cursorWirdGeradeGesetzt)
        return;
      this.Changed(EventArgs.Empty);
    }

    public void TextEinfuegen(string text, XMLRegelwerk regelwerk)
    {
      XMLCursor xmlCursor = this.Clone();
      xmlCursor.SelektionOptimieren();
      XMLCursorPos neueCursorPosNachLoeschen;
      XMLCursorPos xmlCursorPos = !xmlCursor.SelektionLoeschen(out neueCursorPosNachLoeschen) ? this.StartPos.Clone() : neueCursorPosNachLoeschen;
      XmlNode ersatzNode = (XmlNode) null;
      xmlCursorPos.TextEinfuegen(text, regelwerk, out ersatzNode);
      if (ersatzNode != null)
        xmlCursorPos.InsertXMLNode(ersatzNode, regelwerk, false);
      this.BeideCursorPosSetzen(xmlCursorPos.AktNode, xmlCursorPos.PosAmNode, xmlCursorPos.PosImTextnode);
    }

    public void XMLNodeEinfuegen(
      XmlNode node,
      XMLRegelwerk regelwerk,
      bool neueCursorPosAufJedenFallHinterDenEingefuegtenNodeSetzen)
    {
      XMLCursor xmlCursor = this.Clone();
      xmlCursor.SelektionOptimieren();
      XMLCursorPos neueCursorPosNachLoeschen;
      if (xmlCursor.SelektionLoeschen(out neueCursorPosNachLoeschen))
        this.BeideCursorPosSetzen(neueCursorPosNachLoeschen.AktNode, neueCursorPosNachLoeschen.PosAmNode, neueCursorPosNachLoeschen.PosImTextnode);
      if (!this._startPos.InsertXMLNode(node, regelwerk, neueCursorPosAufJedenFallHinterDenEingefuegtenNodeSetzen))
        return;
      this.EndPos.CursorSetzen(this.StartPos.AktNode, this.StartPos.PosAmNode, this.StartPos.PosImTextnode);
    }

    public bool IstEtwasSelektiert
    {
      get
      {
        return this._startPos.AktNode != null && (this._startPos.PosAmNode == XMLCursorPositionen.CursorAufNodeSelbstVorderesTag || this._startPos.PosAmNode == XMLCursorPositionen.CursorAufNodeSelbstHinteresTag || !this._startPos.Equals(this._endPos));
      }
    }

    public string SelektionAlsString
    {
      get
      {
        if (!this.IstEtwasSelektiert)
          return "";
        StringBuilder stringBuilder = new StringBuilder();
        XMLCursor xmlCursor = this.Clone();
        xmlCursor.SelektionOptimieren();
        XmlNode xmlNode = xmlCursor.StartPos.AktNode;
        switch (xmlCursor.StartPos.PosAmNode)
        {
          case XMLCursorPositionen.CursorVorDemNode:
          case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
          case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
            stringBuilder.Append(xmlNode.OuterXml);
            goto case XMLCursorPositionen.CursorInDemLeeremNode;
          case XMLCursorPositionen.CursorInDemLeeremNode:
          case XMLCursorPositionen.CursorHinterDemNode:
            if (xmlCursor.StartPos.AktNode != xmlCursor.EndPos.AktNode)
            {
              do
              {
                xmlNode = xmlNode.NextSibling;
                if (xmlNode != null)
                {
                  if (xmlNode == xmlCursor.EndPos.AktNode)
                  {
                    switch (xmlCursor.EndPos.PosAmNode)
                    {
                      case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
                      case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
                      case XMLCursorPositionen.CursorHinterDemNode:
                        stringBuilder.Append(xmlNode.OuterXml);
                        break;
                      case XMLCursorPositionen.CursorInDemLeeremNode:
                        throw new ApplicationException("XMLCursor.SelektionAlsString: unwahrscheinliche EndPos.PosAmNode '" + (object) xmlCursor.EndPos.PosAmNode + "' für StartPos.Node != EndPos.Node");
                      case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
                        string innerText = xmlNode.InnerText;
                        stringBuilder.Append(innerText.Substring(0, xmlCursor.EndPos.PosImTextnode + 1));
                        break;
                      default:
                        throw new ApplicationException("XMLCursor.SelektionAlsString: unbehandelte EndPos.PosAmNode'" + (object) xmlCursor.StartPos.PosAmNode + "' für StartPos.Node != EndPos.Node");
                    }
                  }
                  else
                    stringBuilder.Append(xmlNode.OuterXml);
                }
              }
              while (xmlNode != xmlCursor.EndPos.AktNode && xmlNode != null);
              if (xmlNode == null)
                throw new ApplicationException("Endnode war nicht als NextSibling von Startnode erreichbar");
            }
            return stringBuilder.ToString();
          case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
            string innerText1 = xmlNode.InnerText;
            int posImTextnode = xmlCursor.StartPos.PosImTextnode;
            int length = innerText1.Length - posImTextnode;
            if (xmlNode == xmlCursor.EndPos.AktNode)
            {
              switch (xmlCursor.EndPos.PosAmNode)
              {
                case XMLCursorPositionen.CursorVorDemNode:
                case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
                case XMLCursorPositionen.CursorInDemLeeremNode:
                  throw new ApplicationException("XMLCursor.SelektionAlsString: unwahrscheinliche EndPos.PosAmNode '" + (object) xmlCursor.EndPos.PosAmNode + "' für StartPos.CursorInnerhalbDesTextNodes");
                case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
                case XMLCursorPositionen.CursorHinterDemNode:
                  break;
                case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
                  if (xmlCursor.StartPos.PosImTextnode > xmlCursor.EndPos.PosImTextnode)
                    throw new ApplicationException("XMLCursor.SelektionAlsString: optimiert.StartPos.PosImTextnode > optimiert.EndPos.PosImTextnode");
                  length -= innerText1.Length - xmlCursor.EndPos.PosImTextnode;
                  goto case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag;
                default:
                  throw new ApplicationException("XMLCursor.SelektionAlsString: unbehandelte EndPos.PosAmNode'" + (object) xmlCursor.EndPos.PosAmNode + "' für StartPos.CursorInnerhalbDesTextNodes");
              }
            }
            string str = innerText1.Substring(posImTextnode, length);
            stringBuilder.Append(str);
            goto case XMLCursorPositionen.CursorInDemLeeremNode;
          default:
            throw new ApplicationException("XMLCursor.SelektionAlsString: unbehandelte StartPos.PosAmNode'" + (object) xmlCursor.StartPos.PosAmNode + "'");
        }
      }
    }

    public bool SelektionLoeschen(out XMLCursorPos neueCursorPosNachLoeschen)
    {
      if (!this.IstEtwasSelektiert)
      {
        neueCursorPosNachLoeschen = this.StartPos.Clone();
        return false;
      }
      if (this.StartPos.AktNode == this.EndPos.AktNode)
      {
        switch (this.StartPos.PosAmNode)
        {
          case XMLCursorPositionen.CursorVorDemNode:
            if (ToolboxXML.IstTextOderKommentarNode(this.StartPos.AktNode))
            {
              this.StartPos.CursorSetzen(this.StartPos.AktNode, XMLCursorPositionen.CursorInnerhalbDesTextNodes, 0);
              return this.SelektionLoeschen(out neueCursorPosNachLoeschen);
            }
            this.BeideCursorPosSetzen(this.StartPos.AktNode, XMLCursorPositionen.CursorAufNodeSelbstVorderesTag);
            return this.SelektionLoeschen(out neueCursorPosNachLoeschen);
          case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
          case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
            XmlNode aktNode = this.StartPos.AktNode;
            XmlNode previousSibling = aktNode.PreviousSibling;
            XmlNode nextSibling = aktNode.NextSibling;
            neueCursorPosNachLoeschen = new XMLCursorPos();
            if (previousSibling != null && nextSibling != null && (previousSibling is XmlText && nextSibling is XmlText))
            {
              neueCursorPosNachLoeschen.CursorSetzen(previousSibling, XMLCursorPositionen.CursorInnerhalbDesTextNodes, previousSibling.InnerText.Length);
              previousSibling.InnerText += nextSibling.InnerText;
              aktNode.ParentNode.RemoveChild(aktNode);
              nextSibling.ParentNode.RemoveChild(nextSibling);
              return true;
            }
            if (previousSibling != null)
              neueCursorPosNachLoeschen.CursorSetzen(previousSibling, XMLCursorPositionen.CursorHinterDemNode);
            else if (nextSibling != null)
              neueCursorPosNachLoeschen.CursorSetzen(nextSibling, XMLCursorPositionen.CursorVorDemNode);
            else
              neueCursorPosNachLoeschen.CursorSetzen(aktNode.ParentNode, XMLCursorPositionen.CursorInDemLeeremNode);
            aktNode.ParentNode.RemoveChild(aktNode);
            return true;
          case XMLCursorPositionen.CursorInDemLeeremNode:
            if (this.EndPos.PosAmNode != XMLCursorPositionen.CursorHinterDemNode && this.EndPos.PosAmNode != XMLCursorPositionen.CursorVorDemNode)
              throw new ApplicationException("AuswahlLoeschen:#6363S undefined Endpos " + (object) this.EndPos.PosAmNode + "!");
            XMLCursor xmlCursor1 = new XMLCursor();
            xmlCursor1.BeideCursorPosSetzen(this.StartPos.AktNode, XMLCursorPositionen.CursorAufNodeSelbstVorderesTag, 0);
            return xmlCursor1.SelektionLoeschen(out neueCursorPosNachLoeschen);
          case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
            int posImTextnode = this.StartPos.PosImTextnode;
            int num = this.EndPos.PosImTextnode;
            if (this.EndPos.PosAmNode == XMLCursorPositionen.CursorHinterDemNode)
              num = this.StartPos.AktNode.InnerText.Length;
            if (posImTextnode == 0 && num >= this.StartPos.AktNode.InnerText.Length)
            {
              XMLCursor xmlCursor2 = new XMLCursor();
              xmlCursor2.BeideCursorPosSetzen(this.StartPos.AktNode, XMLCursorPositionen.CursorAufNodeSelbstVorderesTag);
              return xmlCursor2.SelektionLoeschen(out neueCursorPosNachLoeschen);
            }
            this.StartPos.AktNode.InnerText = this.StartPos.AktNode.InnerText.Remove(posImTextnode, num - posImTextnode);
            neueCursorPosNachLoeschen = new XMLCursorPos();
            if (posImTextnode == 0)
              neueCursorPosNachLoeschen.CursorSetzen(this.StartPos.AktNode, XMLCursorPositionen.CursorVorDemNode);
            else
              neueCursorPosNachLoeschen.CursorSetzen(this.StartPos.AktNode, XMLCursorPositionen.CursorInnerhalbDesTextNodes, posImTextnode);
            return true;
          case XMLCursorPositionen.CursorHinterDemNode:
            if (ToolboxXML.IstTextOderKommentarNode(this.StartPos.AktNode))
            {
              this.StartPos.CursorSetzen(this.StartPos.AktNode, XMLCursorPositionen.CursorInnerhalbDesTextNodes, this.StartPos.AktNode.InnerText.Length);
              return this.SelektionLoeschen(out neueCursorPosNachLoeschen);
            }
            this.BeideCursorPosSetzen(this.StartPos.AktNode, XMLCursorPositionen.CursorAufNodeSelbstVorderesTag);
            return this.SelektionLoeschen(out neueCursorPosNachLoeschen);
          default:
            throw new ApplicationException("AuswahlLoeschen:#63346 StartPos.PosAmNode " + (object) this.StartPos.PosAmNode + " not allowed!");
        }
      }
      else
      {
        while (this.StartPos.AktNode.NextSibling != this.EndPos.AktNode)
          this.StartPos.AktNode.ParentNode.RemoveChild(this.StartPos.AktNode.NextSibling);
        XMLCursor xmlCursor2 = this.Clone();
        xmlCursor2.StartPos.CursorSetzen(this.EndPos.AktNode, XMLCursorPositionen.CursorVorDemNode);
        XMLCursorPos neueCursorPosNachLoeschen1;
        xmlCursor2.SelektionLoeschen(out neueCursorPosNachLoeschen1);
        this.EndPos.CursorSetzen(this.StartPos.AktNode, XMLCursorPositionen.CursorHinterDemNode);
        return this.SelektionLoeschen(out neueCursorPosNachLoeschen);
      }
    }

    public void SelektionOptimieren()
    {
      if (this._startPos.AktNode == null)
        return;
      if (this._startPos.AktNode == this._endPos.AktNode)
      {
        if (this._startPos.PosAmNode > this._endPos.PosAmNode)
        {
          XMLCursorPositionen posAmNode = this._startPos.PosAmNode;
          int posImTextnode = this._startPos.PosImTextnode;
          this._startPos.CursorSetzen(this._endPos.AktNode, this._endPos.PosAmNode, this._endPos.PosImTextnode);
          this._endPos.CursorSetzen(this._endPos.AktNode, posAmNode, posImTextnode);
        }
        else if (this._startPos.PosAmNode == XMLCursorPositionen.CursorInnerhalbDesTextNodes && this._endPos.PosAmNode == XMLCursorPositionen.CursorInnerhalbDesTextNodes && this._startPos.PosImTextnode > this._endPos.PosImTextnode)
        {
          int posImTextnode = this._startPos.PosImTextnode;
          this._startPos.CursorSetzen(this._startPos.AktNode, XMLCursorPositionen.CursorInnerhalbDesTextNodes, this._endPos.PosImTextnode);
          this._endPos.CursorSetzen(this._startPos.AktNode, XMLCursorPositionen.CursorInnerhalbDesTextNodes, posImTextnode);
        }
      }
      else
      {
        if (ToolboxXML.Node1LiegtVorNode2(this._endPos.AktNode, this._startPos.AktNode))
        {
          XMLCursorPos startPos = this._startPos;
          this._startPos = this._endPos;
          this._endPos = startPos;
        }
        if (ToolboxXML.IstChild(this._endPos.AktNode, this._startPos.AktNode))
          this.BeideCursorPosSetzen(this._startPos.AktNode, XMLCursorPositionen.CursorAufNodeSelbstVorderesTag);
        if (this._startPos.AktNode.ParentNode != this._endPos.AktNode.ParentNode)
        {
          XmlNode xmlNode = this.TiefsterGemeinsamerParent(this._startPos.AktNode, this._endPos.AktNode);
          XmlNode aktNode1 = this._startPos.AktNode;
          while (aktNode1.ParentNode != xmlNode)
            aktNode1 = aktNode1.ParentNode;
          XmlNode aktNode2 = this._endPos.AktNode;
          while (aktNode2.ParentNode != xmlNode)
            aktNode2 = aktNode2.ParentNode;
          this._startPos.CursorSetzen(aktNode1, XMLCursorPositionen.CursorAufNodeSelbstVorderesTag);
          this._endPos.CursorSetzen(aktNode2, XMLCursorPositionen.CursorAufNodeSelbstVorderesTag);
        }
      }
    }

    public XmlNode TiefsterGemeinsamerParent(XmlNode node1, XmlNode node2)
    {
      for (XmlNode parentNode1 = node1.ParentNode; parentNode1 != null; parentNode1 = parentNode1.ParentNode)
      {
        for (XmlNode parentNode2 = node2.ParentNode; parentNode2 != null; parentNode2 = parentNode2.ParentNode)
        {
          if (parentNode1 == parentNode2)
            return parentNode1;
        }
      }
      return (XmlNode) null;
    }

    public bool IstNodeInnerhalbDerSelektion(XmlNode node)
    {
      if (this._startPos.IstNodeInnerhalbDerSelektion(node) || this._endPos.IstNodeInnerhalbDerSelektion(node))
        return true;
      if (this._startPos.Equals(this._endPos))
        return this._startPos.IstNodeInnerhalbDerSelektion(node);
      if (this._startPos.AktNode == node || this._endPos.AktNode == node)
        return node is XmlText;
      return this._startPos.LiegtNodeHinterDieserPos(node) && this._endPos.LiegtNodeVorDieserPos(node);
    }
  }
}
