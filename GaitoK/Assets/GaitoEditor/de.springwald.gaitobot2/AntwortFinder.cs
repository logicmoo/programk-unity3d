// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.AntwortFinder
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Xml;

namespace de.springwald.gaitobot2
{
  internal class AntwortFinder
  {
    private readonly Wissen _wissen;
    private readonly Normalisierung _normalisierer;
    private readonly GaitoBotSession _session;
    private readonly GaitoBotEigenschaften _botEigenschaften;
    private readonly bool _beiEinwortEingabenOhneMatchAufSraiOnlyOneWordUmleiten;
    private readonly string[] _trenner;

    public AntwortFinder(
      string[] trenner,
      Normalisierung normalisierer,
      Wissen wissen,
      GaitoBotSession session,
      GaitoBotEigenschaften botEigenschaften,
      bool beiEinwortEingabenOhneMatchAufSraiOnlyOneWordUmleiten)
    {
      this._beiEinwortEingabenOhneMatchAufSraiOnlyOneWordUmleiten = beiEinwortEingabenOhneMatchAufSraiOnlyOneWordUmleiten;
      this._trenner = trenner;
      this._botEigenschaften = botEigenschaften;
      this._wissen = wissen;
      this._session = session;
      this._normalisierer = normalisierer;
    }

    public List<AntwortSatz> GetAntwortSaetze(string eingabe)
    {
      if (this._session == null)
        throw new ApplicationException("_session = null!");
      string empty = string.Empty;
      string aktuellesThema = this._session.AktuellesThema;
      string that = this._session.LetzterSchritt == null ? "*" : this._session.LetzterSchritt.BotAusgabe;
      this._session.Denkprotokoll.Add(new BotDenkProtokollSchritt(string.Format(ResReader.Reader(this._session.DenkprotokollKultur).GetString("ThatTopicImDenkprotokoll", this._session.DenkprotokollKultur), (object) aktuellesThema, (object) that), BotDenkProtokollSchritt.SchrittArten.Info));
      eingabe = this._normalisierer.StandardErsetzungenDurchfuehren(eingabe);
      string[] strArray = eingabe.Split(this._trenner, StringSplitOptions.RemoveEmptyEntries);
      List<AntwortSatz> antwortSatzList = new List<AntwortSatz>();
      bool flag = true;
      foreach (string einSatz in strArray)
      {
        if (einSatz != null && einSatz.Trim() != "")
        {
          AntwortSatz antwortSatz = this.GetQualifizierteAntwort_(einSatz, that, new ArrayList());
          if (antwortSatz != null)
          {
            if (this._beiEinwortEingabenOhneMatchAufSraiOnlyOneWordUmleiten && antwortSatz.IstNotfallAntwort && eingabe.Trim().IndexOf(" ") == -1)
            {
              antwortSatz = new AntwortSatz("TARGET ONLYONEWORD", true);
              antwortSatz.IstNotfallAntwort = true;
            }
            if (antwortSatz.IstNotfallAntwort)
            {
              if (flag)
              {
                antwortSatzList = new List<AntwortSatz>();
                antwortSatzList.Add(antwortSatz);
              }
            }
            else
            {
              if (flag)
                antwortSatzList = new List<AntwortSatz>();
              antwortSatzList.Add(antwortSatz);
              flag = false;
            }
          }
        }
      }
      if (flag && !this._session.BereitsEineNotfallAntwortGezeigt)
      {
        this._session.BereitsEineNotfallAntwortGezeigt = true;
        return this.GetAntwortSaetze("TARGET FIRSTBADANSWER");
      }
      foreach (AntwortSatz antwortSatz in antwortSatzList)
      {
        if (antwortSatz.IstNotfallAntwort && antwortSatz.Satz == "TARGET ONLYONEWORD")
        {
          AntwortSatz qualifizierteAntwort = this.GetQualifizierteAntwort_("TARGET ONLYONEWORD", "EMPTYTHAT", new ArrayList());
          if (qualifizierteAntwort != null)
            antwortSatz.Satz = qualifizierteAntwort.Satz;
        }
      }
      if (antwortSatzList.Count == 0)
        antwortSatzList = (List<AntwortSatz>) null;
      return antwortSatzList;
    }

    private AntwortSatz GetQualifizierteAntwort_(
      string einSatz,
      string that,
      ArrayList vorherigeSRAIs)
    {
      this._session.Denkprotokoll.Add(new BotDenkProtokollSchritt(einSatz, BotDenkProtokollSchritt.SchrittArten.Eingabe));
      if (vorherigeSRAIs.Count > 50)
        return new AntwortSatz(string.Format("SRAI-recursion at '{0}'", (object) einSatz), false);
      einSatz = this._normalisierer.StandardErsetzungenDurchfuehren(einSatz);
      einSatz = Normalisierung.EingabePatternOptimieren(einSatz, false).Trim();
      if (einSatz == "")
      {
        this._session.Denkprotokoll.Add(new BotDenkProtokollSchritt("Die Eingabe ist nach Normalisierung und Patternoptimierung leer", BotDenkProtokollSchritt.SchrittArten.Info));
        return (AntwortSatz) null;
      }
      string str = that;
      that = this._normalisierer.StandardErsetzungenDurchfuehren(that);
      if (that == "")
        that = str;
      else
        str = that;
      that = Normalisierung.EingabePatternOptimieren(that.Trim(), false);
      if (that == "")
        that = str;
      WissenThema thema1 = this._wissen.GetThema(this._session.AktuellesThema);
      AntwortSatz antwort;
      if (thema1 != null)
      {
        foreach (WissensCategory category in thema1.Categories)
        {
          if (category.Pattern.Inhalt != "*" && category.That.Inhalt != "*" && this.PasstCategory(category, einSatz, that, vorherigeSRAIs, out antwort))
            return antwort;
        }
      }
      WissenThema thema2 = this._wissen.GetThema(this._session.AktuellesThema);
      if (thema2 != null)
      {
        foreach (WissensCategory category in thema2.Categories)
        {
          if (category.Pattern.Inhalt != "*" && category.That.Inhalt == "*" && this.PasstCategory(category, einSatz, that, vorherigeSRAIs, out antwort))
            return antwort;
        }
      }
      for (int index = 1; index < this._session.LetzteThemen.Count; ++index)
      {
        WissenThema thema3 = this._wissen.GetThema(this._session.LetzteThemen[this._session.LetzteThemen.Count - 1 - index]);
        if (thema3 != null)
        {
          foreach (WissensCategory category in thema3.Categories)
          {
            if (category.IstSrai && category.Pattern.Inhalt != "*" && category.That.Inhalt != "*" && this.PasstCategory(category, einSatz, that, vorherigeSRAIs, out antwort))
              return antwort;
          }
        }
      }
      for (int index = 1; index < this._session.LetzteThemen.Count; ++index)
      {
        WissenThema thema3 = this._wissen.GetThema(this._session.LetzteThemen[this._session.LetzteThemen.Count - 1 - index]);
        if (thema3 != null)
        {
          foreach (WissensCategory category in thema3.Categories)
          {
            if (category.IstSrai && category.Pattern.Inhalt != "*" && category.That.Inhalt == "*" && this.PasstCategory(category, einSatz, that, vorherigeSRAIs, out antwort))
              return antwort;
          }
        }
      }
      WissenThema thema4 = this._wissen.GetThema(this._session.AktuellesThema);
      if (thema4 != null)
      {
        foreach (WissensCategory starCategory in thema4.StarCategories)
        {
          if (starCategory.That.Inhalt != "*" && this.PasstCategory(starCategory, einSatz, that, vorherigeSRAIs, out antwort))
            return antwort;
        }
      }
      for (int index = 1; index < this._session.LetzteThemen.Count; ++index)
      {
        WissenThema thema3 = this._wissen.GetThema(this._session.LetzteThemen[this._session.LetzteThemen.Count - 1 - index]);
        if (thema3 != null)
        {
          foreach (WissensCategory category in thema3.Categories)
          {
            if (category.That.Inhalt != "*" && this.PasstCategory(category, einSatz, that, vorherigeSRAIs, out antwort))
              return antwort;
          }
        }
      }
      WissenThema thema5 = this._wissen.GetThema(this._session.AktuellesThema);
      if (thema5 != null)
      {
        foreach (WissensCategory starCategory in thema5.StarCategories)
        {
          if (starCategory.That.Inhalt == "*" && this.PasstCategory(starCategory, einSatz, that, vorherigeSRAIs, out antwort))
            return antwort;
        }
      }
      for (int index = 1; index < this._session.LetzteThemen.Count; ++index)
      {
        WissenThema thema3 = this._wissen.GetThema(this._session.LetzteThemen[this._session.LetzteThemen.Count - 1 - index]);
        if (thema3 != null)
        {
          foreach (WissensCategory category in thema3.Categories)
          {
            if (category.That.Inhalt == "*" && this.PasstCategory(category, einSatz, that, vorherigeSRAIs, out antwort))
              return antwort;
          }
        }
      }
      return (AntwortSatz) null;
    }

    private bool PasstCategory(
      WissensCategory category,
      string eingabe,
      string that,
      ArrayList vorherigeSRAIs,
      out AntwortSatz antwort)
    {
      PatternMatcher thatMatch = new PatternMatcher(category.That.RegExObjekt, that);
      if (thatMatch.Erfolgreich)
      {
        PatternMatcher patternMatch = new PatternMatcher(category.Pattern.RegExObjekt, eingabe);
        if (patternMatch.Erfolgreich)
        {
          this._session.Denkprotokoll.Add(new BotDenkProtokollSchritt(string.Format(ResReader.Reader(this._session.DenkprotokollKultur).GetString("PassendeKategorieGefunden", this._session.DenkprotokollKultur)), BotDenkProtokollSchritt.SchrittArten.PassendeKategorieGefunden, category));
          AntwortSatz antwortSatz = this.InterpretiereCategory_(category, patternMatch, thatMatch, that, vorherigeSRAIs);
          if (antwortSatz.IstNotfallAntwort)
          {
            antwort = antwortSatz;
          }
          else
          {
            int num = !(category.Pattern.Inhalt == "*") ? 0 : (category.That.Inhalt == "*" ? 1 : 0);
            antwort = num == 0 ? new AntwortSatz(antwortSatz.Satz, false) : new AntwortSatz(antwortSatz.Satz, true);
          }
          return true;
        }
      }
      antwort = (AntwortSatz) null;
      return false;
    }

    private AntwortSatz InterpretiereCategory_(
      WissensCategory category,
      PatternMatcher patternMatch,
      PatternMatcher thatMatch,
      string that,
      ArrayList vorherigeSRAIs)
    {
      StringBuilder stringBuilder = new StringBuilder();
      bool istNotfallAntwort = true;
      XmlNode xmlNode = category.CategoryNode.SelectSingleNode("template");
      if (xmlNode == null)
        return new AntwortSatz("Error: NO TEMPLATE-NODE FOUND", true);
      foreach (XmlNode childNode in xmlNode.ChildNodes)
      {
        if (childNode is XmlText)
        {
          stringBuilder.Append(childNode.InnerText);
          istNotfallAntwort = false;
        }
        else
        {
          bool enthaeltAusschliesslichNotfallAntwort;
          string ausgabeDiesesTags = this.GetAusgabeDiesesTags((long) stringBuilder.Length, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort, vorherigeSRAIs);
          if (!enthaeltAusschliesslichNotfallAntwort)
            istNotfallAntwort = false;
          stringBuilder.Append(ausgabeDiesesTags);
        }
      }
      return new AntwortSatz(stringBuilder.ToString(), istNotfallAntwort);
    }

    private string GetAusgabeDiesesTags(
      long laengeBisherigeAntwort,
      XmlNode node,
      PatternMatcher patternMatch,
      PatternMatcher thatMatch,
      string that,
      out bool enthaeltAusschliesslichNotfallAntwort,
      ArrayList vorherigeSRAIs)
    {
      enthaeltAusschliesslichNotfallAntwort = false;
      if (node is XmlText)
        return node.InnerText;
      switch (node.Name)
      {
        case "bot":
          if (node.Attributes["name"] != null)
            return this._botEigenschaften.Lesen(node.Attributes["name"].Value);
          enthaeltAusschliesslichNotfallAntwort = true;
          return "NAMELESS-BOT-PROPERTY";
        case "condition":
          ConditionStatus conditionStatus1 = new ConditionStatus();
          conditionStatus1.AttributeAusNodeHinzufuegen(node);
          if (!conditionStatus1.KannSchonSchliessen || conditionStatus1.Erfuellt(this._session))
          {
            if (node.SelectNodes("li").Count == 0)
            {
              StringBuilder stringBuilder = new StringBuilder();
              enthaeltAusschliesslichNotfallAntwort = true;
              foreach (XmlNode childNode in node.ChildNodes)
              {
                bool enthaeltAusschliesslichNotfallAntwort1;
                stringBuilder.Append(this.GetAusgabeDiesesTags(laengeBisherigeAntwort + (long) stringBuilder.Length, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs));
                if (!enthaeltAusschliesslichNotfallAntwort1)
                  enthaeltAusschliesslichNotfallAntwort = false;
              }
              return stringBuilder.ToString();
            }
            foreach (XmlNode selectNode in node.SelectNodes("li"))
            {
              bool flag;
              if (selectNode.Attributes["name"] == null && selectNode.Attributes["value"] == null && selectNode.Attributes["contains"] == null && selectNode.Attributes["exists"] == null)
              {
                flag = true;
              }
              else
              {
                ConditionStatus conditionStatus2 = conditionStatus1.Clone();
                conditionStatus2.AttributeAusNodeHinzufuegen(selectNode);
                flag = conditionStatus2.KannSchonSchliessen && conditionStatus2.Erfuellt(this._session);
              }
              if (flag)
              {
                bool enthaeltAusschliesslichNotfallAntwort1;
                string ausgabeDiesesTags = this.GetAusgabeDiesesTags(laengeBisherigeAntwort, selectNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs);
                if (enthaeltAusschliesslichNotfallAntwort1)
                  enthaeltAusschliesslichNotfallAntwort = true;
                return ausgabeDiesesTags;
              }
            }
          }
          return "";
        case "formal":
          StringBuilder stringBuilder1 = new StringBuilder();
          enthaeltAusschliesslichNotfallAntwort = true;
          foreach (XmlNode childNode in node.ChildNodes)
          {
            bool enthaeltAusschliesslichNotfallAntwort1;
            stringBuilder1.Append(this.GetAusgabeDiesesTags(laengeBisherigeAntwort + (long) stringBuilder1.Length, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs));
            if (!enthaeltAusschliesslichNotfallAntwort1)
              enthaeltAusschliesslichNotfallAntwort = false;
          }
          char ch1 = ' ';
          StringBuilder stringBuilder2 = new StringBuilder();
          foreach (char ch2 in stringBuilder1.ToString())
          {
            if (ch1 == ' ')
              stringBuilder2.Append(ch2.ToString().ToUpper());
            else
              stringBuilder2.Append(ch2.ToString().ToLower());
            ch1 = ch2;
          }
          return stringBuilder2.ToString();
        case "gender":
          StringBuilder stringBuilder3 = new StringBuilder();
          enthaeltAusschliesslichNotfallAntwort = true;
          foreach (XmlNode childNode in node.ChildNodes)
          {
            bool enthaeltAusschliesslichNotfallAntwort1;
            stringBuilder3.Append(this.GetAusgabeDiesesTags(laengeBisherigeAntwort + (long) stringBuilder3.Length, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs));
            if (!enthaeltAusschliesslichNotfallAntwort1)
              enthaeltAusschliesslichNotfallAntwort = false;
          }
          return this._normalisierer.GeschlechtAustauschen(stringBuilder3.ToString());
        case "get":
          if (node.Attributes["name"] != null)
            return StandardGlobaleEigenschaften.GetStandardConditionContent(node.Attributes["name"].Value) ?? this._session.UserEigenschaften.Lesen(node.Attributes["name"].Value);
          return ResReader.Reader((CultureInfo) null).GetString("unbekannteEigenschaft");
        case "input":
          int result1 = 1;
          if (node.Attributes["index"] != null)
          {
            string str = node.Attributes["index"].Value;
            if (!string.IsNullOrEmpty(str))
            {
              if (!int.TryParse(str.Split(new char[1]{ ',' }, StringSplitOptions.RemoveEmptyEntries)[0], out result1))
                result1 = 1;
            }
          }
          if (result1 < 0)
            result1 = 1;
          if (result1 > this._session.LetzteSchritte.Count - 1)
            return "";
          string userEingabe = this._session.LetzteSchritte[this._session.LetzteSchritte.Count - result1].UserEingabe;
          if (userEingabe == "TARGET BOTSTART")
            return "";
          return userEingabe;
        case "li":
          StringBuilder stringBuilder4 = new StringBuilder();
          enthaeltAusschliesslichNotfallAntwort = true;
          foreach (XmlNode childNode in node.ChildNodes)
          {
            bool enthaeltAusschliesslichNotfallAntwort1;
            stringBuilder4.Append(this.GetAusgabeDiesesTags(laengeBisherigeAntwort + (long) stringBuilder4.Length, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs));
            if (!enthaeltAusschliesslichNotfallAntwort1)
              enthaeltAusschliesslichNotfallAntwort = false;
          }
          return stringBuilder4.ToString();
        case "lowercase":
          StringBuilder stringBuilder5 = new StringBuilder();
          enthaeltAusschliesslichNotfallAntwort = true;
          foreach (XmlNode childNode in node.ChildNodes)
          {
            bool enthaeltAusschliesslichNotfallAntwort1;
            stringBuilder5.Append(this.GetAusgabeDiesesTags(laengeBisherigeAntwort + (long) stringBuilder5.Length, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs));
            if (!enthaeltAusschliesslichNotfallAntwort1)
              enthaeltAusschliesslichNotfallAntwort = false;
          }
          return stringBuilder5.ToString().ToLower();
        case "person":
          StringBuilder stringBuilder6 = new StringBuilder();
          enthaeltAusschliesslichNotfallAntwort = true;
          foreach (XmlNode childNode in node.ChildNodes)
          {
            bool enthaeltAusschliesslichNotfallAntwort1;
            stringBuilder6.Append(this.GetAusgabeDiesesTags(laengeBisherigeAntwort + (long) stringBuilder6.Length, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs));
            if (!enthaeltAusschliesslichNotfallAntwort1)
              enthaeltAusschliesslichNotfallAntwort = false;
          }
          return this._normalisierer.PersonAustauschen(stringBuilder6.ToString());
        case "person2":
          StringBuilder stringBuilder7 = new StringBuilder();
          enthaeltAusschliesslichNotfallAntwort = true;
          foreach (XmlNode childNode in node.ChildNodes)
          {
            bool enthaeltAusschliesslichNotfallAntwort1;
            stringBuilder7.Append(this.GetAusgabeDiesesTags(laengeBisherigeAntwort + (long) stringBuilder7.Length, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs));
            if (!enthaeltAusschliesslichNotfallAntwort1)
              enthaeltAusschliesslichNotfallAntwort = false;
          }
          return this._normalisierer.Person2Austauschen(stringBuilder7.ToString());
        case "random":
          if (node.SelectNodes("li").Count == 0)
          {
            enthaeltAusschliesslichNotfallAntwort = true;
            return "NO LI-TAGS IN RANDOM-TAG";
          }
          XmlNode node1 = this.WaehleZufaelligenNode(node.SelectNodes("li"));
          bool enthaeltAusschliesslichNotfallAntwort2;
          string ausgabeDiesesTags1 = this.GetAusgabeDiesesTags(laengeBisherigeAntwort, node1, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort2, vorherigeSRAIs);
          if (enthaeltAusschliesslichNotfallAntwort2)
            enthaeltAusschliesslichNotfallAntwort = true;
          return ausgabeDiesesTags1;
        case "script":
          if (node.Attributes["language"] == null)
            return node.OuterXml;
          string str1 = node.Attributes["language"].Value;
          if (!(str1 == "gaitoscript"))
          {
            if (str1 == "javascript")
              ;
            XmlNode xmlNode = node.Clone();
            enthaeltAusschliesslichNotfallAntwort = true;
            foreach (XmlNode childNode in xmlNode.ChildNodes)
            {
              if (childNode.Name == "get")
              {
                bool enthaeltAusschliesslichNotfallAntwort1;
                string ausgabeDiesesTags2 = this.GetAusgabeDiesesTags(laengeBisherigeAntwort, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs);
                if (!enthaeltAusschliesslichNotfallAntwort1)
                  enthaeltAusschliesslichNotfallAntwort = false;
                XmlText textNode = childNode.OwnerDocument.CreateTextNode(ausgabeDiesesTags2);
                xmlNode.InsertBefore((XmlNode) textNode, childNode);
                xmlNode.RemoveChild(childNode);
              }
            }
            return xmlNode.OuterXml;
          }
          GaitoScriptInterpreter scriptInterpreter = new GaitoScriptInterpreter(this._session);
          scriptInterpreter.Execute(node.InnerText);
          if (scriptInterpreter.Fehler != null)
            return string.Format("GaitoScript-Error: {0}", (object) scriptInterpreter.Fehler);
          if (scriptInterpreter.Ausgabe == null)
            return "";
          return scriptInterpreter.Ausgabe;
        case "sentence":
          StringBuilder stringBuilder8 = new StringBuilder();
          enthaeltAusschliesslichNotfallAntwort = true;
          foreach (XmlNode childNode in node.ChildNodes)
          {
            bool enthaeltAusschliesslichNotfallAntwort1;
            stringBuilder8.Append(this.GetAusgabeDiesesTags(laengeBisherigeAntwort + (long) stringBuilder8.Length, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs));
            if (!enthaeltAusschliesslichNotfallAntwort1)
              enthaeltAusschliesslichNotfallAntwort = false;
          }
          bool flag1 = true;
          StringBuilder stringBuilder9 = new StringBuilder();
          foreach (char ch2 in stringBuilder8.ToString())
          {
            if (flag1)
            {
              stringBuilder9.Append(ch2.ToString().ToUpper());
              if (ch2 != ' ')
                flag1 = false;
            }
            else
              stringBuilder9.Append(ch2);
          }
          return stringBuilder9.ToString();
        case "set":
          StringBuilder stringBuilder10 = new StringBuilder();
          enthaeltAusschliesslichNotfallAntwort = true;
          foreach (XmlNode childNode in node.ChildNodes)
          {
            bool enthaeltAusschliesslichNotfallAntwort1;
            stringBuilder10.Append(this.GetAusgabeDiesesTags(laengeBisherigeAntwort + (long) stringBuilder10.Length, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs));
            if (!enthaeltAusschliesslichNotfallAntwort1)
              enthaeltAusschliesslichNotfallAntwort = false;
          }
          if (node.Attributes["name"] != null)
          {
            string name = node.Attributes["name"].Value;
            if (name.Trim().ToLower() == "topic")
              this._session.SetzeAktuellesThema(stringBuilder10.ToString());
            this._session.UserEigenschaften.Setzen(name, stringBuilder10.ToString());
          }
          return stringBuilder10.ToString();
        case "srai":
          vorherigeSRAIs.Add((object) node);
          StringBuilder stringBuilder11 = new StringBuilder();
          foreach (XmlNode childNode in node.ChildNodes)
          {
            bool enthaeltAusschliesslichNotfallAntwort1;
            stringBuilder11.Append(this.GetAusgabeDiesesTags(0L, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs));
          }
          StringBuilder stringBuilder12 = new StringBuilder();
          if (laengeBisherigeAntwort > 0L)
          {
            stringBuilder12.Append("|");
            that = "EMPTYTHAT";
          }
          AntwortSatz qualifizierteAntwort = this.GetQualifizierteAntwort_(stringBuilder11.ToString(), that, vorherigeSRAIs);
          if (qualifizierteAntwort == null)
          {
            enthaeltAusschliesslichNotfallAntwort = true;
          }
          else
          {
            stringBuilder12.Append(qualifizierteAntwort.Satz);
            enthaeltAusschliesslichNotfallAntwort = qualifizierteAntwort.IstNotfallAntwort;
          }
          return stringBuilder12.ToString();
        case "star":
          int result2 = 1;
          if (node.Attributes["index"] != null && !int.TryParse(node.Attributes["index"].Value, out result2))
            result2 = 1;
          return patternMatch.GetStarInhalt(result2);
        case nameof (that):
          int result3 = 1;
          if (node.Attributes["index"] != null)
          {
            string str2 = node.Attributes["index"].Value;
            if (!string.IsNullOrEmpty(str2))
            {
              if (!int.TryParse(str2.Split(new char[1]
              {
                ','
              }, StringSplitOptions.RemoveEmptyEntries)[0], out result3))
                result3 = 1;
            }
          }
          if (result3 < 0)
            result3 = 1;
          if (result3 == 1)
            return that;
          if (result3 > this._session.LetzteSchritte.Count - 1)
            return "";
          return this._session.LetzteSchritte[this._session.LetzteSchritte.Count - result3].BotAusgabe;
        case "thatstar":
          int result4 = 1;
          if (node.Attributes["index"] != null && !int.TryParse(node.Attributes["index"].Value, out result4))
            result4 = 1;
          return thatMatch.GetStarInhalt(result4);
        case "think":
          foreach (XmlNode childNode in node.ChildNodes)
          {
            bool enthaeltAusschliesslichNotfallAntwort1;
            this.GetAusgabeDiesesTags(laengeBisherigeAntwort, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs);
          }
          return "";
        case "uppercase":
          StringBuilder stringBuilder13 = new StringBuilder();
          enthaeltAusschliesslichNotfallAntwort = true;
          foreach (XmlNode childNode in node.ChildNodes)
          {
            bool enthaeltAusschliesslichNotfallAntwort1;
            stringBuilder13.Append(this.GetAusgabeDiesesTags(laengeBisherigeAntwort + (long) stringBuilder13.Length, childNode, patternMatch, thatMatch, that, out enthaeltAusschliesslichNotfallAntwort1, vorherigeSRAIs));
            if (!enthaeltAusschliesslichNotfallAntwort1)
              enthaeltAusschliesslichNotfallAntwort = false;
          }
          return stringBuilder13.ToString().ToUpper();
        default:
          return node.OuterXml;
      }
    }

    private XmlNode WaehleZufaelligenNode(XmlNodeList LiTags)
    {
      ArrayList arrayList = new ArrayList();
      int num1 = -1;
      foreach (XmlNode liTag in LiTags)
      {
        int num2 = !this._session.RandomHistory.Contains((object) liTag) ? 0 : this._session.RandomHistory.IndexOf((object) liTag) + 1;
        if (num1 == -1 || num2 < num1)
        {
          arrayList = new ArrayList();
          num1 = num2;
        }
        if (num2 == num1)
          arrayList.Add((object) liTag);
      }
      int index = new Random(this._session.ZufallsSeed).Next(0, arrayList.Count);
      XmlNode xmlNode = (XmlNode) arrayList[index];
      this._session.RandomHistory.Remove((object) xmlNode);
      this._session.RandomHistory.Add((object) xmlNode);
      return xmlNode;
    }
  }
}
