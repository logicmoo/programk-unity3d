// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.Normalisierung
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using de.springwald.toolbox;
using System;
using System.Collections;
using System.Collections.Generic;

namespace de.springwald.gaitobot2
{
  public class Normalisierung
  {
    private const string Leer = "";

    public StartupInfos StartupInfos { get; private set; }

    public Normalisierung(StartupInfos startupInfos)
    {
      if (startupInfos == null)
        throw new ArgumentNullException(nameof (startupInfos));
      this.StartupInfos = startupInfos;
    }

    public string StandardErsetzungenDurchfuehren(string eingabe)
    {
      return this.ErsetzungenDurchfuehren(this.StartupInfos.Ersetzungen, eingabe.Replace("Ä", "Ae").Replace("ä", "ae").Replace("Ö", "Oe").Replace("ö", "oe").Replace("Ü", "Ue").Replace("ü", "ue").Replace("ß", "ss"), false);
    }

    public string PersonAustauschen(string eingabe)
    {
      return this.ErsetzungenDurchfuehren(this.StartupInfos.PersonAustauscher, eingabe, true);
    }

    public string Person2Austauschen(string eingabe)
    {
      return this.ErsetzungenDurchfuehren(this.StartupInfos.Person2Austauscher, eingabe, true);
    }

    public string GeschlechtAustauschen(string eingabe)
    {
      return this.ErsetzungenDurchfuehren(this.StartupInfos.GeschlechtsAustauscher, eingabe, true);
    }

    public static string EingabePatternOptimieren(string rohEingabe, bool sternErlaubt)
    {
      if (rohEingabe.Length == 0)
        return "";
      char[] charArray = rohEingabe.ToCharArray();
      ArrayList arrayList = new ArrayList();
      for (int index = 0; index < charArray.Length; ++index)
      {
        if (charArray[index] > '@' & charArray[index] < '[' || charArray[index] > '`' & charArray[index] < '{' || charArray[index] > '/' & charArray[index] < ':' || charArray[index] == ' ')
          arrayList.Add((object) charArray[index]);
        else if (sternErlaubt && charArray[index] == '*')
          arrayList.Add((object) charArray[index]);
      }
      char[] chArray = new char[arrayList.Count];
      for (int index = 0; index < arrayList.Count; ++index)
        chArray[index] = (char) arrayList[index];
      return ToolboxStrings.DoppelteLeerzeichenRaus(new string(chArray)).Trim();
    }

    private string ErsetzungenDurchfuehren(
      List<DictionaryEntry> ersetzungen,
      string rohEingabe,
      bool kreisUbersetzungenVermeiden)
    {
      Hashtable hashtable = (Hashtable) null;
      if (kreisUbersetzungenVermeiden)
        hashtable = new Hashtable();
      if (rohEingabe.Length < 1)
        return "";
      if (ersetzungen.Count < 1)
        return rohEingabe;
      string original = " " + rohEingabe + " ";
      foreach (DictionaryEntry dictionaryEntry in ersetzungen)
      {
        string key = (string) dictionaryEntry.Key;
        if (!kreisUbersetzungenVermeiden || !hashtable.Contains((object) key.ToLower()))
        {
          string replacement = (string) dictionaryEntry.Value;
          if (kreisUbersetzungenVermeiden)
          {
            string str = original;
            original = ToolboxStrings.ReplaceEx(original, key, replacement);
            if (str != original)
              hashtable.Add((object) replacement.ToLower(), (object) null);
          }
          else
            original = ToolboxStrings.ReplaceEx(original, key, replacement);
        }
      }
      return original.Trim();
    }
  }
}
