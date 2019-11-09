// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.StartupDatei_XmlRegelwerk
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.xml;
using de.springwald.xml.cursor;
using de.springwald.xml.dtd;
using de.springwald.xml.editor;
using System.Drawing;
using System.Xml;

namespace GaitoBotEditorCore
{
  public class StartupDatei_XmlRegelwerk : XMLRegelwerk
  {
    public override XMLElementGruppenListe ElementGruppen
    {
      get
      {
        if (this._elementGruppen == null)
        {
          this._elementGruppen = new XMLElementGruppenListe();
          XMLElementGruppe gruppe = new XMLElementGruppe(ResReader.Reader.GetString("GruppeStandard"), false);
          gruppe.AddElementName("bot");
          gruppe.AddElementName("property");
          gruppe.AddElementName("predicates");
          gruppe.AddElementName("substitutions");
          gruppe.AddElementName("sentence-splitters");
          gruppe.AddElementName("input, gender, person, person");
          gruppe.AddElementName("gender");
          gruppe.AddElementName("person");
          gruppe.AddElementName("person2");
          gruppe.AddElementName("substitute");
          gruppe.AddElementName("splitter");
          this._elementGruppen.Add(gruppe);
        }
        return this._elementGruppen;
      }
    }

    public StartupDatei_XmlRegelwerk(DTD dtd)
      : base(dtd)
    {
    }

    public override Color NodeFarbe(XmlNode node, bool selektiert)
    {
      return base.NodeFarbe(node, selektiert);
    }

    public override bool IstSchliessendesTagSichtbar(XmlNode xmlNode)
    {
      return base.IstSchliessendesTagSichtbar(xmlNode);
    }

    public override DarstellungsArten DarstellungsArt(XmlNode xmlNode)
    {
      if (xmlNode is XmlElement)
      {
        switch (xmlNode.Name)
        {
          case "bot":
          case "input":
          case "predicate":
          case "predicates":
          case "property":
          case "sentence-splitters":
          case "splitter":
          case "substitute":
          case "substitutions":
            return DarstellungsArten.EigeneZeile;
        }
      }
      return base.DarstellungsArt(xmlNode);
    }

    public override string EinfuegeTextPreProcessing(
      string einfuegeText,
      XMLCursorPos woEinfuegen,
      out XmlNode ersatzNode)
    {
      return base.EinfuegeTextPreProcessing(einfuegeText, woEinfuegen, out ersatzNode);
    }

    public override string[] ErlaubteEinfuegeElemente_(
      XMLCursorPos zielPunkt,
      bool pcDATAMitAuflisten,
      bool kommentareMitAuflisten)
    {
      return base.ErlaubteEinfuegeElemente_(zielPunkt, pcDATAMitAuflisten, kommentareMitAuflisten);
    }

    public override XMLElement createPaintElementForNode(
      XmlNode xmlNode,
      XMLEditor xmlEditor)
    {
      return base.createPaintElementForNode(xmlNode, xmlEditor);
    }
  }
}
