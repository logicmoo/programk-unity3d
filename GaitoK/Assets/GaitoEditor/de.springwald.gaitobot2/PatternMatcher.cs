// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.PatternMatcher
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace de.springwald.gaitobot2
{
  public class PatternMatcher
  {
    private readonly string _eingabe;
    private readonly bool _erfolgreich;
    private readonly Match _match;

    public bool Erfolgreich
    {
      get
      {
        return this._erfolgreich;
      }
    }

    public PatternMatcher(Regex regExObjekt, string eingabe)
    {
      this._eingabe = eingabe;
      this._match = regExObjekt.Match(eingabe);
      this._erfolgreich = this._match.Success;
    }

    public string GetStarInhalt(int starNr)
    {
      if (!this._erfolgreich)
        throw new ApplicationException("Requested STAR for not succesfull match!");
      string index = string.Format("star{0}", (object) starNr);
      if (this._match.Groups[index] == null)
        throw new ApplicationException(string.Format(ResReader.Reader((CultureInfo) null).GetString("InputStarIndexUeberschritten"), (object) starNr, (object) this._eingabe));
      return this._match.Groups[index].Value;
    }
  }
}
