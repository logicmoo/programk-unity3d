// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.dtd.DTDReaderDTD
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace de.springwald.xml.dtd
{
  public class DTDReaderDTD
  {
    private string _rohinhalt;
    private string _workingInhalt;
    private List<DTDElement> _elemente;
    private List<DTDEntity> _entities;

    public string RohInhalt
    {
      get
      {
        return this._rohinhalt;
      }
    }

    public string WorkingInhalt
    {
      get
      {
        return this._workingInhalt;
      }
    }

    public DTD GetDTDFromFile(string dateiname)
    {
      string end;
      try
      {
        StreamReader streamReader = new StreamReader(dateiname, Encoding.GetEncoding("ISO-8859-15"));
        end = streamReader.ReadToEnd();
        streamReader.Close();
      }
      catch (FileNotFoundException ex)
      {
        throw new ApplicationException(string.Format(ResReader.Reader.GetString("KonnteDateiNichtEinlesen"), (object) dateiname, (object) ex.Message));
      }
      return this.GetDTDFromString(end);
    }

    public DTD GetDTDFromString(string inhalt)
    {
      inhalt = inhalt.Replace("\t", " ");
      this._rohinhalt = inhalt;
      this._workingInhalt = inhalt;
      this._elemente = new List<DTDElement>();
      this._entities = new List<DTDEntity>();
      this.InhaltAnalysieren();
      this._elemente.Add(this.CreateElementFromQuellcode("#PCDATA"));
      this._elemente.Add(this.CreateElementFromQuellcode("#COMMENT"));
      return new DTD(this._elemente, this._entities);
    }

    private void InhaltAnalysieren()
    {
      this.KommentareEntfernen();
      this.EntitiesAuslesen();
      this.EntitiesAustauschen();
      this.ElementeAuslesen();
    }

    private void KommentareEntfernen()
    {
      this._workingInhalt = Regex.Replace(this._workingInhalt, "<!--((?!-->|<!--)([\\t\\r\\n]|.))*-->", "");
    }

    private void ElementeAuslesen()
    {
      Match match = new Regex("(?<element><!ELEMENT[\\t\\r\\n ]+[^>]+>)").Match(this._workingInhalt);
      SortedList sortedList = new SortedList();
      for (; match.Success; match = match.NextMatch())
      {
        DTDElement elementFromQuellcode = this.CreateElementFromQuellcode(match.Groups["element"].Value);
        try
        {
          sortedList.Add((object) elementFromQuellcode.Name, (object) elementFromQuellcode);
        }
        catch (ArgumentException ex)
        {
          throw new ApplicationException(string.Format(ResReader.Reader.GetString("FehlerBeimLesenDesDTDELementes"), (object) elementFromQuellcode.Name, (object) ex.Message));
        }
      }
      for (int index = 0; index < sortedList.Count; ++index)
        this._elemente.Add((DTDElement) sortedList[sortedList.GetKey(index)]);
    }

    private DTDElement CreateElementFromQuellcode(string elementQuellcode)
    {
      if (elementQuellcode == "#PCDATA")
        return new DTDElement() { Name = "#PCDATA", ChildElemente = new DTDChildElemente("") };
      if (elementQuellcode == "#COMMENT")
        return new DTDElement() { Name = "#COMMENT", ChildElemente = new DTDChildElemente("") };
      Match match = new Regex("(?<element><!ELEMENT[\\t\\r\\n ]+(?<elementname>[\\w-_]+?)([\\t\\r\\n ]+(?<innerelements>[(]([\\t\\r\\n]|.)+?[)][*+]?)?)?(?<empty>[\\t\\r\\n ]+EMPTY)? *>)").Match(elementQuellcode);
      if (!match.Success)
        throw new ApplicationException(string.Format(ResReader.Reader.GetString("NichtsImElementCodeGefunden"), (object) elementQuellcode));
      DTDElement element = new DTDElement();
      if (!match.Groups["elementname"].Success)
        throw new ApplicationException(string.Format(ResReader.Reader.GetString("KeinNameInElementcodegefunden"), (object) elementQuellcode));
      element.Name = match.Groups["elementname"].Value;
      this.CreateDTDAttributesForElement(element);
      if (match.Groups["innerelements"].Success)
        this.ChildElementeAuslesen(element, match.Groups["innerelements"].Value);
      else
        this.ChildElementeAuslesen(element, "");
      if (match.NextMatch().Success)
        throw new ApplicationException(string.Format(ResReader.Reader.GetString("MehrAlsEinsImElementCodeGefunden"), (object) elementQuellcode));
      return element;
    }

    private void ChildElementeAuslesen(DTDElement element, string childElementeQuellcode)
    {
      element.ChildElemente = new DTDChildElemente(childElementeQuellcode);
    }

    private void EntitiesAustauschen()
    {
      string str = "";
      while (str != this._workingInhalt)
      {
        str = this._workingInhalt;
        foreach (DTDEntity entity in this._entities)
        {
          if (entity.IstErsetzungsEntity)
            this._workingInhalt = this._workingInhalt.Replace("%" + entity.Name + ";", entity.Inhalt);
        }
      }
    }

    private void EntitiesAuslesen()
    {
      for (Match match = new Regex("(?<entity><!ENTITY[\\t\\r\\n ]+[^>]+>)").Match(this._workingInhalt); match.Success; match = match.NextMatch())
        this._entities.Add(this.CreateEntityFromQuellcode(match.Groups["entity"].Value));
    }

    private DTDEntity CreateEntityFromQuellcode(string entityQuellcode)
    {
      Match match = new Regex("(?<entity><!ENTITY[\\t\\r\\n ]+(?:(?<prozent>%)[\\t\\r\\n ]+)?(?<entityname>[\\w-_]+?)[\\t\\r\\n ]+\"(?<inhalt>[^>]+)\"[\\t\\r\\n ]?>)").Match(entityQuellcode);
      if (!match.Success)
        throw new ApplicationException(string.Format(ResReader.Reader.GetString("NichtsImEntityCode"), (object) entityQuellcode));
      DTDEntity dtdEntity = new DTDEntity();
      dtdEntity.IstErsetzungsEntity = match.Groups["prozent"].Success;
      if (!match.Groups["entityname"].Success)
        throw new ApplicationException(string.Format(ResReader.Reader.GetString("KeinNameImEntityCode"), (object) entityQuellcode));
      dtdEntity.Name = match.Groups["entityname"].Value;
      if (!match.Groups["inhalt"].Success)
        throw new ApplicationException(string.Format(ResReader.Reader.GetString("KeinInhaltImEntityCode"), (object) entityQuellcode));
      dtdEntity.Inhalt = match.Groups["inhalt"].Value;
      if (match.NextMatch().Success)
        throw new ApplicationException(string.Format(ResReader.Reader.GetString("MehrAlsEinsImEntityQuellCode"), (object) entityQuellcode));
      return dtdEntity;
    }

    private void CreateDTDAttributesForElement(DTDElement element)
    {
      element.Attribute = new List<DTDAttribut>();
      Match match1 = new Regex("(?<attributliste><!ATTLIST " + element.Name + "[\\t\\r\\n ]+(?<attribute>[^>]+?)[\\t\\r\\n ]?>)").Match(this._workingInhalt);
      if (!match1.Success)
        return;
      string input = match1.Groups["attribute"].Value;
      Match match2 = new Regex("[\\t\\r\\n ]?(?<name>[\\w-_]+)[\\t\\r\\n ]+(?<typ>CDATA|ID|IDREF|IDREFS|NMTOKEN|NMTOKENS|ENTITY|ENTITIES|NOTATION|xml:|[(][|\\w-_ \\t\\r\\n]+[)])[\\t\\r\\n ]+(?:(?<anzahl>#REQUIRED|#IMPLIED|#FIXED)[\\t\\r\\n ]+)?(?:\"(?<vorgabewert>[\\w-_]+)\")?[\\t\\r\\n ]?").Match(input);
      if (!match2.Success)
        throw new ApplicationException(string.Format(ResReader.Reader.GetString("KeineAttributeInAttributListe"), (object) input));
      char[] charArray = "|".ToCharArray();
      for (; match2.Success; match2 = match2.NextMatch())
      {
        DTDAttribut dtdAttribut = new DTDAttribut();
        dtdAttribut.Name = match2.Groups["name"].Value;
        dtdAttribut.StandardWert = match2.Groups["vorgabewert"].Value;
        string str1 = match2.Groups["anzahl"].Value;
        if (!(str1 == "#REQUIRED"))
        {
          if (!(str1 == "#IMPLIED") && (str1 == null || str1.Length != 0))
          {
            if (!(str1 == "#FIXED"))
              throw new ApplicationException(string.Format(ResReader.Reader.GetString("UnbekannteAttributAnzahl"), (object) match2.Groups["anzahl"].Value, (object) match2.Value, (object) element.Name));
            dtdAttribut.Pflicht = DTDAttribut.PflichtArten.Konstante;
          }
          else
            dtdAttribut.Pflicht = DTDAttribut.PflichtArten.Optional;
        }
        else
          dtdAttribut.Pflicht = DTDAttribut.PflichtArten.Pflicht;
        string str2 = match2.Groups["typ"].Value.Trim();
        if (str2.StartsWith("("))
        {
          dtdAttribut.Typ = "";
          foreach (string str3 in str2.Replace("(", "").Replace(")", "").Replace(")", "").Split(charArray))
          {
            string str4 = str3.Replace("\n", " ").Trim();
            dtdAttribut.ErlaubteWerte.Add(str4);
          }
        }
        else
          dtdAttribut.Typ = str2;
        element.Attribute.Add(dtdAttribut);
      }
    }
  }
}
