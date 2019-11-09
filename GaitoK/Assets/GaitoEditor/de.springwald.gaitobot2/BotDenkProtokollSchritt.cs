// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.BotDenkProtokollSchritt
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

namespace de.springwald.gaitobot2
{
  public class BotDenkProtokollSchritt
  {
    private readonly string _meldung;
    private readonly BotDenkProtokollSchritt.SchrittArten _art;
    private readonly WissensCategory _category;

    public string Meldung
    {
      get
      {
        return this._meldung;
      }
    }

    public BotDenkProtokollSchritt.SchrittArten Art
    {
      get
      {
        return this._art;
      }
    }

    public WissensCategory Category
    {
      get
      {
        return this._category;
      }
    }

    public BotDenkProtokollSchritt(string meldung, BotDenkProtokollSchritt.SchrittArten art)
    {
      this._meldung = meldung;
      this._art = art;
    }

    public BotDenkProtokollSchritt(
      string meldung,
      BotDenkProtokollSchritt.SchrittArten art,
      WissensCategory category)
    {
      this._meldung = meldung;
      this._art = art;
      this._category = category;
    }

    public enum SchrittArten
    {
      Eingabe,
      Info,
      Warnung,
      PassendeKategorieGefunden,
    }
  }
}
