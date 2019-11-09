// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.AimlXmlRegelwerk
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.xml;
using de.springwald.xml.cursor;
using de.springwald.xml.dtd;
using de.springwald.xml.editor;
using System.Collections;
using System.Drawing;
using System.Text;
using System.Xml;

namespace GaitoBotEditorCore
{
  public class AimlXmlRegelwerk : XMLRegelwerk
  {
    public override XMLElementGruppenListe ElementGruppen
    {
      get
      {
        if (this._elementGruppen == null)
        {
          this._elementGruppen = new XMLElementGruppenListe();
          XMLElementGruppe gruppe1 = new XMLElementGruppe(ResReader.Reader.GetString("GruppeStandard"), false);
          gruppe1.AddElementName("bot");
          gruppe1.AddElementName("get");
          gruppe1.AddElementName("li");
          gruppe1.AddElementName("pattern");
          gruppe1.AddElementName("random");
          gruppe1.AddElementName("set");
          gruppe1.AddElementName("srai");
          gruppe1.AddElementName("sr");
          gruppe1.AddElementName("star");
          gruppe1.AddElementName("template");
          gruppe1.AddElementName("that");
          gruppe1.AddElementName("thatstar");
          gruppe1.AddElementName("think");
          this._elementGruppen.Add(gruppe1);
          XMLElementGruppe gruppe2 = new XMLElementGruppe(ResReader.Reader.GetString("GruppeFortgeschritten"), true);
          gruppe2.AddElementName("condition");
          gruppe2.AddElementName("formal");
          gruppe2.AddElementName("gender");
          gruppe2.AddElementName("input");
          gruppe2.AddElementName("person");
          gruppe2.AddElementName("person2");
          gruppe2.AddElementName("sentence");
          this._elementGruppen.Add(gruppe2);
          XMLElementGruppe gruppe3 = new XMLElementGruppe(ResReader.Reader.GetString("GruppeHTML"), true);
          gruppe3.AddElementName("a");
          gruppe3.AddElementName("applet");
          gruppe3.AddElementName("br");
          gruppe3.AddElementName("em");
          gruppe3.AddElementName("img");
          gruppe3.AddElementName("p");
          gruppe3.AddElementName("table");
          gruppe3.AddElementName("ul");
          this._elementGruppen.Add(gruppe3);
          XMLElementGruppe gruppe4 = new XMLElementGruppe("GaitoBot", true);
          gruppe4.AddElementName("script");
          this._elementGruppen.Add(gruppe4);
        }
        return this._elementGruppen;
      }
    }

    public AimlXmlRegelwerk(DTD dtd)
      : base(dtd)
    {
    }

    public override Color NodeFarbe(XmlNode node, bool selektiert)
    {
      if (!selektiert)
      {
        string name1 = node.Name;
        if (name1 == "condition")
          return Color.FromArgb(150, 221, 220);
        if (!(name1 == "li"))
        {
          if (name1 == "random")
            return Color.FromArgb((int) byte.MaxValue, 211, 80);
          if (name1 == "think")
            return Color.FromArgb(200, 200, 200);
        }
        else
        {
          string name2 = node.ParentNode.Name;
          if (name2 == "random")
            return Color.FromArgb((int) byte.MaxValue, 243, 187);
          if (name2 == "condition")
            return Color.FromArgb(200, 250, 250);
        }
      }
      return base.NodeFarbe(node, selektiert);
    }

    public override bool IstSchliessendesTagSichtbar(XmlNode xmlNode)
    {
      if (!(xmlNode.Name == "that"))
        return base.IstSchliessendesTagSichtbar(xmlNode);
      return !(xmlNode.ParentNode.Name == "template");
    }

    public override DarstellungsArten DarstellungsArt(XmlNode xmlNode)
    {
      if (!(xmlNode is XmlElement))
        return base.DarstellungsArt(xmlNode);
      switch (xmlNode.Name)
      {
        case "a":
        case "bot":
        case "formal":
        case "gender":
        case "person":
        case "person2":
        case "set":
          return DarstellungsArten.Fliesselement;
        case "that":
          return xmlNode.ParentNode.Name == "template" ? DarstellungsArten.Fliesselement : DarstellungsArten.EigeneZeile;
        case "think":
          if (!(xmlNode.ParentNode.Name == "template") || xmlNode.PreviousSibling != null && !(xmlNode.PreviousSibling.Name == "think") && this.DarstellungsArt(xmlNode.PreviousSibling) == DarstellungsArten.Fliesselement)
            return DarstellungsArten.Fliesselement;
          return xmlNode.NextSibling != null && this.DarstellungsArt(xmlNode.NextSibling) == DarstellungsArten.Fliesselement ? DarstellungsArten.Fliesselement : DarstellungsArten.EigeneZeile;
        default:
          return base.DarstellungsArt(xmlNode);
      }
    }

    public override string EinfuegeTextPreProcessing(
      string einfuegeText,
      XMLCursorPos woEinfuegen,
      out XmlNode ersatzNode)
    {
      XmlNode xmlNode = !(woEinfuegen.AktNode is XmlText) ? woEinfuegen.AktNode : woEinfuegen.AktNode.ParentNode;
      if (einfuegeText == "*")
      {
        string name = xmlNode.Name;
        if (!(name == "pattern") && !(name == "that") && !(name == "script"))
        {
          ersatzNode = (XmlNode) woEinfuegen.AktNode.OwnerDocument.CreateElement("star");
          return "";
        }
      }
      string name1 = xmlNode.Name;
      if (!(name1 == "srai"))
      {
        if (!(name1 == "pattern"))
          return base.EinfuegeTextPreProcessing(einfuegeText, woEinfuegen, out ersatzNode);
        StringBuilder stringBuilder = new StringBuilder(einfuegeText.ToUpper());
        stringBuilder.Replace("Ä", "AE");
        stringBuilder.Replace("Ö", "OE");
        stringBuilder.Replace("Ü", "UE");
        stringBuilder.Replace("ß", "SS");
        char[] charArray = stringBuilder.ToString().ToCharArray();
        ArrayList arrayList = new ArrayList();
        for (int index = 0; index < charArray.Length; ++index)
        {
          if ((charArray[index] == '*' || charArray[index] == '_') && xmlNode.Name == "pattern")
            arrayList.Add((object) charArray[index]);
          else if (charArray[index] > '@' & charArray[index] < '[' || charArray[index] > '`' & charArray[index] < '{' || charArray[index] > '/' & charArray[index] < ':' || charArray[index] == ' ')
            arrayList.Add((object) charArray[index]);
        }
        char[] chArray = new char[arrayList.Count];
        for (int index = 0; index < arrayList.Count; ++index)
          chArray[index] = (char) arrayList[index];
        string str = new string(chArray);
        ersatzNode = (XmlNode) null;
        return str;
      }
      string str1 = einfuegeText.Replace("*", "").Replace("_", "");
      ersatzNode = (XmlNode) null;
      return str1;
    }

    public override string[] ErlaubteEinfuegeElemente_(
      XMLCursorPos zielPunkt,
      bool pcDATAMitAuflisten,
      bool kommentareMitAuflisten)
    {
      if (zielPunkt.AktNode != null && zielPunkt.AktNode.Name.ToLower() == "category")
        return new string[0];
      return base.ErlaubteEinfuegeElemente_(zielPunkt, pcDATAMitAuflisten, kommentareMitAuflisten);
    }

    public override XMLElement createPaintElementForNode(
      XmlNode xmlNode,
      XMLEditor xmlEditor)
    {
      if (!(xmlNode is XmlText) || xmlNode.ParentNode == null || !(xmlNode.ParentNode.Name.ToLower() == "script"))
        return base.createPaintElementForNode(xmlNode, xmlEditor);
      return (XMLElement) new XMLElement_TextNode(xmlNode, xmlEditor) { ZeichenZumUmbrechen = new char[3]{ '}', '{', ';' } };
    }
  }
}
