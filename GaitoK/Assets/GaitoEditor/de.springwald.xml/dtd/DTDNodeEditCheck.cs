// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.dtd.DTDNodeEditCheck
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.xml.cursor;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Xml;

namespace de.springwald.xml.dtd
{
  public class DTDNodeEditCheck
  {
    private DTD _dtd;

    public string DenkProtokoll
    {
      get
      {
        return "DenkProtokoll istper Define deaktiviert (DTDNodeEditCheck.cs)";
      }
    }

    public DTDNodeEditCheck(DTD dtd)
    {
      this._dtd = dtd;
    }

    public string[] AnDieserStelleErlaubteTags_(
      XMLCursorPos zuTestendeCursorPos,
      bool pcDATAMitAuflisten,
      bool kommentareMitAufListen)
    {
      List<DTDTestmuster> alleTestmuster = this.GetAlleTestmuster(zuTestendeCursorPos.Clone());
      List<string> stringList = new List<string>();
      foreach (DTDTestmuster dtdTestmuster in alleTestmuster)
      {
        if (dtdTestmuster.Erfolgreich)
        {
          if (dtdTestmuster.ElementName == null)
          {
            stringList.Add("");
          }
          else
          {
            string lower = dtdTestmuster.ElementName.ToLower();
            if (!(lower == "#pcdata"))
            {
              if (lower == "#comment")
              {
                if (kommentareMitAufListen)
                  stringList.Add(dtdTestmuster.ElementName);
              }
              else
                stringList.Add(dtdTestmuster.ElementName);
            }
            else if (pcDATAMitAuflisten)
              stringList.Add(dtdTestmuster.ElementName);
          }
        }
      }
      return stringList.ToArray();
    }

    public bool IstDerNodeAnDieserStelleErlaubt(XmlNode node)
    {
      if (node.ParentNode is XmlDocument)
        return true;
      XMLCursorPos cursorPos = new XMLCursorPos();
      cursorPos.CursorSetzen(node, XMLCursorPositionen.CursorAufNodeSelbstVorderesTag);
      DTDTestmuster testMuster = this.CreateTestMuster(DTD.GetElementNameFromNode(node), cursorPos);
      this.PruefeAlleTestmuster(new List<DTDTestmuster>()
      {
        testMuster
      }, cursorPos);
      return testMuster.Erfolgreich;
    }

    private List<DTDTestmuster> GetAlleTestmuster(XMLCursorPos cursorPos)
    {
      List<DTDTestmuster> alleMuster = new List<DTDTestmuster>();
      if (cursorPos.AktNode == null)
        throw new ApplicationException("GetAlleTestmuster: cursorPos.AktNode=NULL!");
      switch (cursorPos.PosAmNode)
      {
        case XMLCursorPositionen.CursorVorDemNode:
        case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
        case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
        case XMLCursorPositionen.CursorInDemLeeremNode:
        case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
        case XMLCursorPositionen.CursorHinterDemNode:
          if (!(cursorPos.AktNode is XmlComment))
          {
            StringCollection stringCollection;
            if (cursorPos.PosAmNode == XMLCursorPositionen.CursorInDemLeeremNode)
            {
              DTDElement dtdElement = this._dtd.DTDElementByName(cursorPos.AktNode.Name, false);
              stringCollection = dtdElement != null ? dtdElement.AlleElementNamenWelcheAlsDirektesChildZulaessigSind : new StringCollection();
            }
            else if (cursorPos.AktNode.OwnerDocument == null)
              stringCollection = new StringCollection();
            else if (cursorPos.AktNode == cursorPos.AktNode.OwnerDocument.DocumentElement)
            {
              stringCollection = new StringCollection();
            }
            else
            {
              DTDElement dtdElement = this._dtd.DTDElementByName(cursorPos.AktNode.ParentNode.Name, false);
              stringCollection = dtdElement != null ? dtdElement.AlleElementNamenWelcheAlsDirektesChildZulaessigSind : new StringCollection();
            }
            foreach (string elementName in stringCollection)
            {
              DTDTestmuster testMuster = this.CreateTestMuster(elementName, cursorPos);
              alleMuster.Add(testMuster);
            }
          }
          if(!de.springwald.toolbox.Debugger.WORKAROUND) this.PruefeAlleTestmuster(alleMuster, cursorPos);
          return alleMuster;
        default:
          throw new ApplicationException(string.Format("unknown cursorPos.StartPos.PosAmNode '{0}' detected.", (object) cursorPos.PosAmNode));
      }
    }

    private void PruefeAlleTestmuster(List<DTDTestmuster> alleMuster, XMLCursorPos cursorPos)
    {
      XmlNode aktNode = cursorPos.AktNode;
      DTDElement element;
      if (cursorPos.PosAmNode == XMLCursorPositionen.CursorInDemLeeremNode)
      {
        element = this._dtd.DTDElementByName(DTD.GetElementNameFromNode(aktNode), false);
      }
      else
      {
        if (aktNode.OwnerDocument == null || aktNode.OwnerDocument.DocumentElement == null)
          return;
        if (aktNode == aktNode.OwnerDocument.DocumentElement)
        {
          using (List<DTDTestmuster>.Enumerator enumerator = alleMuster.GetEnumerator())
          {
            while (enumerator.MoveNext())
            {
              DTDTestmuster current = enumerator.Current;
              if (current.ElementName == aktNode.Name)
                current.Erfolgreich = true;
            }
            return;
          }
        }
        else
          element = this._dtd.DTDElementByName(DTD.GetElementNameFromNode(aktNode.ParentNode), false);
      }
      foreach (DTDTestmuster muster in alleMuster)
      {
        if (element == null)
          muster.Erfolgreich = false;
        else if (!muster.Erfolgreich)
          muster.Erfolgreich = this.PasstMusterInElement(muster, element);
      }
    }

    private bool PasstMusterInElement(DTDTestmuster muster, DTDElement element)
    {
      return element.ChildrenRegExObjekt.Match(muster.VergleichStringFuerRegEx).Success;
    }

    private DTDTestmuster CreateTestMuster(string elementName, XMLCursorPos cursorPos)
    {
      XmlNode aktNode = cursorPos.AktNode;
      DTDTestmuster dtdTestmuster;
      if (cursorPos.PosAmNode == XMLCursorPositionen.CursorInDemLeeremNode)
      {
        dtdTestmuster = new DTDTestmuster(elementName, DTD.GetElementNameFromNode(aktNode));
        dtdTestmuster.AddElement(elementName);
      }
      else
      {
        if (aktNode.ParentNode is XmlDocument)
          throw new ApplicationException(ResReader.Reader.GetString("FuerRootElementKeinTestmuster"));
        dtdTestmuster = new DTDTestmuster(elementName, DTD.GetElementNameFromNode(aktNode.ParentNode));
        for (XmlNode node = aktNode.ParentNode.FirstChild; node != null; node = node.NextSibling)
        {
          if (!(node is XmlWhitespace))
          {
            if (node == aktNode)
            {
              if (node is XmlComment)
                dtdTestmuster.AddElement("#COMMENT");
              else if (this._dtd.DTDElementByName(DTD.GetElementNameFromNode(aktNode), false) != null)
              {
                switch (cursorPos.PosAmNode)
                {
                  case XMLCursorPositionen.CursorVorDemNode:
                    if (elementName == null)
                      throw new ApplicationException("CreateTestMuster: Löschen darf bei XMLCursorPositionen.CursorVorDemNode nicht geprüft werden!");
                    dtdTestmuster.AddElement(elementName);
                    dtdTestmuster.AddElement(DTD.GetElementNameFromNode(aktNode));
                    break;
                  case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
                  case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
                    if (elementName != null)
                    {
                      dtdTestmuster.AddElement(elementName);
                      break;
                    }
                    break;
                  case XMLCursorPositionen.CursorInDemLeeremNode:
                    if (elementName == null)
                      throw new ApplicationException("CreateTestMuster: Löschen darf bei XMLCursorPositionen.CursorHinterDemNode nicht geprüft werden!");
                    throw new ApplicationException("CreateTestMuster: CursorInDemLeeremNode can´t be handled at this place!");
                  case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
                    if (elementName == null)
                      throw new ApplicationException("CreateTestMuster: Löschen darf bei XMLCursorPositionen.CursorInnerhalbDesTextNodes nicht geprüft werden!");
                    if (DTD.GetElementNameFromNode(aktNode) != "#PCDATA")
                      throw new ApplicationException("CreateTestMuster: CursorInnerhalbDesTextNodes angegeben, aber node.name=" + DTD.GetElementNameFromNode(aktNode));
                    dtdTestmuster.AddElement("#PCDATA");
                    dtdTestmuster.AddElement(elementName);
                    dtdTestmuster.AddElement("#PCDATA");
                    break;
                  case XMLCursorPositionen.CursorHinterDemNode:
                    if (elementName == null)
                      throw new ApplicationException("CreateTestMuster: Löschen darf bei XMLCursorPositionen.CursorHinterDemNode nicht geprüft werden!");
                    dtdTestmuster.AddElement(DTD.GetElementNameFromNode(aktNode));
                    dtdTestmuster.AddElement(elementName);
                    break;
                  default:
                    throw new ApplicationException("Unknown XMLCursorPositionen value:" + (object) cursorPos.PosAmNode);
                }
              }
            }
            else
              dtdTestmuster.AddElement(DTD.GetElementNameFromNode(node));
          }
        }
      }
      return dtdTestmuster;
    }

    private string ElementName(DTDElement element)
    {
      if (element == null)
        return "[null]";
      return element.Name;
    }
  }
}
