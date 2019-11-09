// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.MatchString
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

namespace de.springwald.gaitobot2
{
  public class MatchString
  {
    private readonly Regex _regExObjekt;
    private readonly string _inhalt;

    public string Inhalt
    {
      get
      {
        return this._inhalt;
      }
    }

    public Regex RegExObjekt
    {
      get
      {
        return this._regExObjekt;
      }
    }

    public MatchString(string inhalt)
    {
      this._inhalt = inhalt;
      this._regExObjekt = this.GetRegExObjekt(inhalt);
    }

    private Regex GetRegExObjekt(string inhalt)
    {
      string str1;
      if (inhalt == "*")
      {
        str1 = "\\A(?<star1>.+?)\\z";
      }
      else
      {
        int num = 0;
        string str2 = inhalt;
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("\\A");
        int startIndex;
        for (; str2.IndexOf("*") != -1; str2 = str2.Remove(startIndex, 1).Insert(startIndex, string.Format("(?<star{0}>.+?)", (object) num)))
        {
          ++num;
          startIndex = str2.IndexOf("*");
        }
        stringBuilder.Append(str2);
        stringBuilder.Append("\\z");
        str1 = stringBuilder.ToString();
      }
      int num1 = 0;
      StringBuilder stringBuilder1 = new StringBuilder();
      string str3 = str1;
      char[] chArray = new char[1]{ '_' };
      foreach (string str2 in str3.Split(chArray))
      {
        if (stringBuilder1.Length == 0)
        {
          stringBuilder1.Append(str2);
        }
        else
        {
          ++num1;
          stringBuilder1.AppendFormat("(?<slash{0}>.+?){1}", (object) num1, (object) str2);
        }
      }
      return new Regex(stringBuilder1.ToString(), RegexOptions.IgnoreCase);
    }

    public static string GetInhaltFromXmlNode(
      XmlNode inhaltNode,
      Normalisierung normalisierung,
      GaitoBotEigenschaften botEigenschaften)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      stringBuilder1.AppendFormat(" ");
      if (!inhaltNode.HasChildNodes)
      {
        stringBuilder1.Append(inhaltNode.Value);
      }
      else
      {
        foreach (XmlNode childNode in inhaltNode.ChildNodes)
        {
          if (childNode is XmlText)
          {
            stringBuilder1.Append(childNode.InnerText);
          }
          else
          {
            if (!(childNode is XmlElement))
              throw new ApplicationException(string.Format("Unbekannter XMLTyp '{0}' in Pattern '{1}'", (object) childNode.OuterXml, (object) inhaltNode.OuterXml));
            if (childNode.Name == "bot")
            {
              if (childNode.Attributes["name"] != null)
              {
                string name = childNode.Attributes["name"].Value;
                stringBuilder1.Append(botEigenschaften.Lesen(name));
              }
              else
                stringBuilder1.Append("BOT_UNKNOWN");
            }
            else
              stringBuilder1.AppendFormat("[[Unbekanntes Tag '{0}' in Pattern '{1}']]", (object) childNode.OuterXml, (object) inhaltNode.OuterXml);
          }
        }
      }
      stringBuilder1.AppendFormat(" ");
      string eingabe = stringBuilder1.ToString();
      string[] strArray = normalisierung.StandardErsetzungenDurchfuehren(eingabe).Split(" \r\n\t".ToCharArray());
      StringBuilder stringBuilder2 = new StringBuilder();
      foreach (string rohEingabe in strArray)
      {
        string str = !(rohEingabe == "*") && !(rohEingabe == "_") ? Normalisierung.EingabePatternOptimieren(rohEingabe, false) : rohEingabe;
        if (stringBuilder2.Length == 0)
          stringBuilder2.Append(str);
        else
          stringBuilder2.AppendFormat(" {0}", (object) str);
      }
      return stringBuilder2.ToString();
    }
  }
}
