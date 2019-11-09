// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.ToolboxXML
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.Collections;
using System.Xml;

namespace de.springwald.toolbox
{
  public class ToolboxXML
  {
    public static bool Node1LiegtVorNode2(XmlNode node1, XmlNode node2)
    {
      if (node1 == null || node2 == null)
        throw new ApplicationException("Keiner der beiden zu vergleichenden Nodes darf NULL sein (Node1LiegtVorNode2)");
      if (node1.OwnerDocument != node2.OwnerDocument || node1 == node2)
        return false;
      return node1.CreateNavigator().ComparePosition(node2.CreateNavigator()) == XmlNodeOrder.Before;
    }

    public static bool IstChild(XmlNode child, XmlNode parent)
    {
      if (child.ParentNode == null)
        return false;
      if (child.ParentNode == parent)
        return true;
      return ToolboxXML.IstChild(child.ParentNode, parent);
    }

    public static string TextAusTextNodeBereinigt(XmlNode textNode)
    {
      if (!(textNode is XmlText) && !(textNode is XmlComment) && !(textNode is XmlWhitespace))
        throw new ApplicationException(string.Format("Received node is not a textnode  ({0})", (object) textNode.OuterXml));
      return textNode.Value.ToString().Replace(Environment.NewLine, "").Trim('\n', '\t', '\r', '\v');
    }

    public static bool IstTextOderKommentarNode(XmlNode node)
    {
      return node is XmlText || node is XmlComment;
    }

    public static void WhitespacesBereinigen(XmlNode node)
    {
      if (node == null)
        return;
      ArrayList arrayList1 = new ArrayList();
      ArrayList arrayList2 = new ArrayList();
      foreach (XmlNode childNode in node.ChildNodes)
      {
        if (childNode is XmlWhitespace)
          arrayList1.Add((object) childNode);
        else if (childNode is XmlElement)
          arrayList2.Add((object) childNode);
      }
      foreach (XmlWhitespace xmlWhitespace in arrayList1)
      {
        if (xmlWhitespace.Data.IndexOf(" ") != -1)
        {
          XmlText textNode = xmlWhitespace.OwnerDocument.CreateTextNode(" ");
          xmlWhitespace.ParentNode.ReplaceChild((XmlNode) textNode, (XmlNode) xmlWhitespace);
        }
        else
          xmlWhitespace.ParentNode.RemoveChild((XmlNode) xmlWhitespace);
      }
      foreach (XmlNode node1 in arrayList2)
        ToolboxXML.WhitespacesBereinigen(node1);
    }
  }
}
