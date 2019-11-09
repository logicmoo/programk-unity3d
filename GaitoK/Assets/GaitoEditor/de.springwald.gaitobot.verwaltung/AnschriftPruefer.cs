// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.verwaltung.AnschriftPruefer
// Assembly: de.springwald.gaitobot.verwaltung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5FCF1B98-3BF2-4EFC-858C-87D71088B318
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.verwaltung.dll

using MultiLang;
using System;
using System.Collections.Generic;
using System.Linq;

namespace de.springwald.gaitobot.verwaltung
{
  public class AnschriftPruefer
  {
    public AnschriftPruefer.Kontexte Kontext { get; private set; }

    public Anschrift Anschrift { get; private set; }

    public bool Gueltig
    {
      get
      {
        return this.UngueltigGruende.Length == 0;
      }
    }

    public string[] UngueltigGruende
    {
      get
      {
        List<string> gruende = new List<string>();
        this.CheckeInhalt(this.Anschrift.Anrede, ml.ml_string(1, "Bitte geben Sie eine gültige Anrede an. "), gruende, true);
        this.CheckeInhalt(this.Anschrift.Nachname, ml.ml_string(3, "Bitte geben Sie Ihren Nachnamen an."), gruende, true);
        this.CheckeInhalt(this.Anschrift.Vorname, ml.ml_string(4, "Bitte geben Sie Ihren Vornamen an."), gruende, true);
        this.CheckeInhalt(this.Anschrift.Adresse, ml.ml_string(11, "Bitte geben Sie Ihre Adresse an."), gruende, true);
        this.CheckeInhalt(this.Anschrift.PLZ, ml.ml_string(12, "Bitte geben Sie Ihre PLZ an."), gruende, false);
        this.CheckeInhalt(this.Anschrift.Ort, ml.ml_string(13, "Bitte geben Sie Ihren Ort an."), gruende, true);
        if (this.Anschrift.Land == Anschrift.Laender.___)
          gruende.Add(ml.ml_string(5, "Bitte wählen Sie das Land."));
        return gruende.ToArray();
      }
    }

    public AnschriftPruefer(AnschriftPruefer.Kontexte kontext, Anschrift anschrift)
    {
      this.Kontext = kontext;
      this.Anschrift = anschrift;
    }

    private void CheckeInhalt(
      string inhalt,
      string info,
      List<string> gruende,
      bool auchVokaleChecken)
    {
      bool flag = true;
      inhalt = inhalt.Trim().ToLower();
      if (inhalt == null || inhalt.Length < 2)
        flag = false;
      if (auchVokaleChecken)
      {
        char[] vokale = new char[8]
        {
          'a',
          'e',
          'i',
          'o',
          'u',
          'ü',
          'ö',
          'ä'
        };
        if (((IEnumerable<char>) inhalt.ToCharArray()).Where<char>((Func<char, bool>) (a => ((IEnumerable<char>) vokale).Contains<char>(a))).Count<char>() == 0)
          flag = false;
      }
      if (flag)
        return;
      gruende.Add(info);
    }

    public enum Kontexte
    {
      Anmeldung,
      Rechnung,
    }
  }
}
