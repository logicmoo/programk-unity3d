// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.cursor.XMLCursorPos
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.toolbox;
using System;
using System.Xml;

namespace de.springwald.xml.cursor
{
  public class XMLCursorPos
  {
    private XmlNode _aktNode;
    private XMLCursorPositionen _posAmNode;
    private int _posImTextnode;

    public event EventHandler PosChangedEvent;

    protected virtual void PosChanged(EventArgs e)
    {
      if (this.PosChangedEvent == null)
        return;
      this.PosChangedEvent((object) this, e);
    }

    public XmlNode AktNode
    {
      get
      {
        return this._aktNode;
      }
    }

    public int PosImTextnode
    {
      get
      {
        if (this._posAmNode == XMLCursorPositionen.CursorInnerhalbDesTextNodes)
          ;
        return this._posImTextnode;
      }
    }

    public XMLCursorPositionen PosAmNode
    {
      get
      {
        return this._posAmNode;
      }
    }

    public XMLCursorPos()
    {
      this._aktNode = (XmlNode) null;
      this._posAmNode = XMLCursorPositionen.CursorAufNodeSelbstVorderesTag;
      this._posImTextnode = 0;
    }

    public bool Equals(XMLCursorPos zweitePos)
    {
      return this.AktNode == zweitePos.AktNode && this.PosAmNode == zweitePos.PosAmNode && this._posImTextnode == zweitePos._posImTextnode;
    }

    public XMLCursorPos Clone()
    {
      XMLCursorPos xmlCursorPos = new XMLCursorPos();
      xmlCursorPos.CursorSetzen(this._aktNode, this._posAmNode, this._posImTextnode);
      return xmlCursorPos;
    }

    public bool LiegtNodeHinterDieserPos(XmlNode node)
    {
      return ToolboxXML.Node1LiegtVorNode2(this._aktNode, node);
    }

    public bool LiegtNodeVorDieserPos(XmlNode node)
    {
      return ToolboxXML.Node1LiegtVorNode2(node, this._aktNode);
    }

    public void ErzwingeChanged()
    {
      this.PosChanged(EventArgs.Empty);
    }

    public void TextEinfuegen(string rohText, XMLRegelwerk regelwerk, out XmlNode ersatzNode)
    {
      string text = regelwerk.EinfuegeTextPreProcessing(rohText, this, out ersatzNode);
      if (ersatzNode != null)
        return;
      switch (this.PosAmNode)
      {
        case XMLCursorPositionen.CursorVorDemNode:
          this.TextZwischenZweiNodesEinfuegen(this.AktNode.PreviousSibling, this.AktNode, text, regelwerk);
          break;
        case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
        case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
          if (regelwerk.IstDiesesTagAnDieserStelleErlaubt("#PCDATA", this))
          {
            XmlText textNode = this.AktNode.OwnerDocument.CreateTextNode(text);
            this.AktNode.ParentNode.ReplaceChild(this.AktNode, (XmlNode) textNode);
            this.CursorSetzen((XmlNode) textNode, XMLCursorPositionen.CursorHinterDemNode);
          }
          throw new ApplicationException(string.Format("TextEinfuegen: unbehandelte CursorPos {0}", (object) this.PosAmNode));
        case XMLCursorPositionen.CursorInDemLeeremNode:
          if (regelwerk.IstDiesesTagAnDieserStelleErlaubt("#PCDATA", this))
          {
            XmlText textNode = this.AktNode.OwnerDocument.CreateTextNode(text);
            this.AktNode.AppendChild((XmlNode) textNode);
            this.CursorSetzen((XmlNode) textNode, XMLCursorPositionen.CursorHinterDemNode);
            break;
          }
          break;
        case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
          string str1 = this.AktNode.InnerText.Substring(0, this.PosImTextnode);
          string str2 = this.AktNode.InnerText.Substring(this.PosImTextnode, this.AktNode.InnerText.Length - this.PosImTextnode);
          this.AktNode.InnerText = str1 + text + str2;
          this.CursorSetzen(this.AktNode, this.PosAmNode, this.PosImTextnode + text.Length);
          break;
        case XMLCursorPositionen.CursorHinterDemNode:
          this.TextZwischenZweiNodesEinfuegen(this.AktNode, this.AktNode.NextSibling, text, regelwerk);
          break;
        default:
          throw new ApplicationException(string.Format("TextEinfuegen: Unbekannte CursorPos {0}", (object) this.PosAmNode));
      }
    }

    public bool InsertXMLNode(
      XmlNode node,
      XMLRegelwerk regelwerk,
      bool neueCursorPosAufJedenFallHinterDenEingefuegtenNodeSetzen)
    {
      XmlNode parentNode = this.AktNode.ParentNode;
      switch (this.PosAmNode)
      {
        case XMLCursorPositionen.CursorVorDemNode:
          parentNode.InsertBefore(node, this.AktNode);
          break;
        case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
        case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
          parentNode.ReplaceChild(node, this.AktNode);
          break;
        case XMLCursorPositionen.CursorInDemLeeremNode:
          this.AktNode.AppendChild(node);
          break;
        case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
          string text1 = this.AktNode.InnerText.Substring(0, this.PosImTextnode);
          XmlNode textNode1 = (XmlNode) parentNode.OwnerDocument.CreateTextNode(text1);
          string text2 = this.AktNode.InnerText.Substring(this.PosImTextnode, this.AktNode.InnerText.Length - this.PosImTextnode);
          XmlNode textNode2 = (XmlNode) parentNode.OwnerDocument.CreateTextNode(text2);
          parentNode.ReplaceChild(textNode1, this.AktNode);
          parentNode.InsertAfter(node, textNode1);
          parentNode.InsertAfter(textNode2, node);
          break;
        case XMLCursorPositionen.CursorHinterDemNode:
          parentNode.InsertAfter(node, this.AktNode);
          break;
        default:
          throw new ApplicationException(string.Format("InsertElementAnCursorPos: Unbekannte PosAmNode {0}", (object) this.PosAmNode));
      }
      if (neueCursorPosAufJedenFallHinterDenEingefuegtenNodeSetzen)
        this.CursorSetzen(node, XMLCursorPositionen.CursorHinterDemNode);
      else if (regelwerk.IstSchliessendesTagSichtbar(node))
        this.CursorSetzen(node, XMLCursorPositionen.CursorInDemLeeremNode);
      else
        this.CursorSetzen(node, XMLCursorPositionen.CursorHinterDemNode);
      return true;
    }

    private void TextZwischenZweiNodesEinfuegen(
      XmlNode nodeVorher,
      XmlNode nodeNachher,
      string text,
      XMLRegelwerk regelwerk)
    {
      if (ToolboxXML.IstTextOderKommentarNode(nodeVorher))
      {
        nodeVorher.InnerText += text;
        this.CursorSetzen(nodeVorher, XMLCursorPositionen.CursorInnerhalbDesTextNodes, nodeVorher.InnerText.Length);
      }
      else if (ToolboxXML.IstTextOderKommentarNode(nodeNachher))
      {
        nodeNachher.InnerText = text + nodeNachher.InnerText;
        this.CursorSetzen(nodeNachher, XMLCursorPositionen.CursorInnerhalbDesTextNodes, text.Length);
      }
      else if (regelwerk.IstDiesesTagAnDieserStelleErlaubt("#PCDATA", this))
        this.InsertXMLNode((XmlNode) this.AktNode.OwnerDocument.CreateTextNode(text), regelwerk, false);
    }

    public bool MoveLeft(XmlNode rootnode, XMLRegelwerk regelwerk)
    {
      XmlNode aktNode = this.AktNode;
      switch (this.PosAmNode)
      {
        case XMLCursorPositionen.CursorVorDemNode:
          if (aktNode == rootnode)
            return false;
          if (aktNode.PreviousSibling != null)
          {
            this.CursorSetzen(aktNode.PreviousSibling, XMLCursorPositionen.CursorHinterDemNode);
            this.MoveLeft(rootnode, regelwerk);
            break;
          }
          this.CursorSetzen(aktNode.ParentNode, XMLCursorPositionen.CursorVorDemNode);
          break;
        case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
        case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
          this.CursorSetzen(this.AktNode, XMLCursorPositionen.CursorVorDemNode);
          break;
        case XMLCursorPositionen.CursorInDemLeeremNode:
          this.CursorSetzen(this.AktNode, XMLCursorPositionen.CursorVorDemNode);
          break;
        case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
          if (!ToolboxXML.IstTextOderKommentarNode(aktNode))
            throw new ApplicationException(string.Format("XMLCursorPos.MoveLeft: CursorPos ist XMLCursorPositionen.CursorInnerhalbDesTextNodes, es ist aber kein Textnode gewählt, sondern der Node {0}", (object) aktNode.OuterXml));
          if (this.PosImTextnode > 1)
          {
            this.CursorSetzen(this.AktNode, this.PosAmNode, this.PosImTextnode - 1);
            break;
          }
          this.CursorSetzen(this.AktNode, XMLCursorPositionen.CursorVorDemNode);
          break;
        case XMLCursorPositionen.CursorHinterDemNode:
          if (ToolboxXML.IstTextOderKommentarNode(aktNode))
          {
            this.CursorSetzen(aktNode, XMLCursorPositionen.CursorInnerhalbDesTextNodes, Math.Max(0, ToolboxXML.TextAusTextNodeBereinigt(aktNode).Length - 1));
            break;
          }
          if (aktNode.ChildNodes.Count < 1)
          {
            if (regelwerk.IstSchliessendesTagSichtbar(aktNode))
              this.CursorSetzen(this.AktNode, XMLCursorPositionen.CursorInDemLeeremNode);
            else
              this.CursorSetzen(this.AktNode, XMLCursorPositionen.CursorVorDemNode);
          }
          else
            this.CursorSetzen(aktNode.LastChild, XMLCursorPositionen.CursorHinterDemNode);
          break;
        default:
          throw new ApplicationException(string.Format("XMLCursorPos.MoveLeft: Unbekannte CursorPos {0}", (object) this.PosAmNode));
      }
      return true;
    }

    public bool MoveRight(XmlNode rootnode, XMLRegelwerk regelwerk)
    {
      XmlNode aktNode = this.AktNode;
      switch (this.PosAmNode)
      {
        case XMLCursorPositionen.CursorVorDemNode:
          if (ToolboxXML.IstTextOderKommentarNode(aktNode))
          {
            if (ToolboxXML.TextAusTextNodeBereinigt(aktNode).Length > 1)
            {
              this.CursorSetzen(this.AktNode, XMLCursorPositionen.CursorInnerhalbDesTextNodes, 1);
              break;
            }
            this.CursorSetzen(this.AktNode, XMLCursorPositionen.CursorHinterDemNode);
            break;
          }
          if (aktNode.ChildNodes.Count < 1)
          {
            if (!regelwerk.IstSchliessendesTagSichtbar(aktNode))
              this.CursorSetzen(this.AktNode, XMLCursorPositionen.CursorHinterDemNode);
            else
              this.CursorSetzen(this.AktNode, XMLCursorPositionen.CursorInDemLeeremNode);
          }
          else
            this.CursorSetzen(aktNode.FirstChild, XMLCursorPositionen.CursorVorDemNode);
          break;
        case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
        case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
          this.CursorSetzen(this.AktNode, XMLCursorPositionen.CursorHinterDemNode);
          break;
        case XMLCursorPositionen.CursorInDemLeeremNode:
          this.CursorSetzen(this.AktNode, XMLCursorPositionen.CursorHinterDemNode);
          break;
        case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
          if (!ToolboxXML.IstTextOderKommentarNode(aktNode))
            throw new ApplicationException(string.Format("XMLCurorPos.MoveRight: CursorPos ist XMLCursorPositionen.CursorInnerhalbDesTextNodes, es ist aber kein Textnode gewählt, sondern der Node {0}", (object) aktNode.OuterXml));
          if (ToolboxXML.TextAusTextNodeBereinigt(aktNode).Length > this.PosImTextnode + 1)
          {
            this.CursorSetzen(this.AktNode, this.PosAmNode, this.PosImTextnode + 1);
            break;
          }
          this.CursorSetzen(this.AktNode, XMLCursorPositionen.CursorHinterDemNode);
          break;
        case XMLCursorPositionen.CursorHinterDemNode:
          if (aktNode.NextSibling != null)
          {
            this.CursorSetzen(aktNode.NextSibling, XMLCursorPositionen.CursorVorDemNode);
            this.MoveRight(rootnode, regelwerk);
            break;
          }
          if (aktNode.ParentNode == rootnode)
            return false;
          this.CursorSetzen(aktNode.ParentNode, XMLCursorPositionen.CursorHinterDemNode);
          if (!regelwerk.IstSchliessendesTagSichtbar(aktNode.ParentNode))
            this.MoveRight(rootnode, regelwerk);
          break;
        default:
          throw new ApplicationException(string.Format("XMLCurorPos.MoveRight: Unbekannte CursorPos {0}", (object) this.PosAmNode));
      }
      return true;
    }

    public void CursorSetzen(XmlNode aktNode, XMLCursorPositionen posAmNode, int posImTextnode)
    {
      bool flag = aktNode != this._aktNode || (posAmNode != this._posAmNode || posImTextnode != this._posImTextnode);
      this._aktNode = aktNode;
      this._posAmNode = posAmNode;
      this._posImTextnode = posImTextnode;
      if (!flag)
        return;
      this.PosChanged(EventArgs.Empty);
    }

    public void CursorSetzen(XmlNode aktNode, XMLCursorPositionen posAmNode)
    {
      this.CursorSetzen(aktNode, posAmNode, 0);
    }

    public bool IstNodeInnerhalbDerSelektion(XmlNode node)
    {
      if (this._aktNode == null || node == null)
        return false;
      if (node == this._aktNode)
        return this._posAmNode == XMLCursorPositionen.CursorAufNodeSelbstVorderesTag || this._posAmNode == XMLCursorPositionen.CursorAufNodeSelbstHinteresTag;
      return this.IstNodeInnerhalbDerSelektion(node.ParentNode);
    }
  }
}
