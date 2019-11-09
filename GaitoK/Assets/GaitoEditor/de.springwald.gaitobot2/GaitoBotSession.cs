// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.GaitoBotSession
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace de.springwald.gaitobot2
{
  public class GaitoBotSession
  {
    private int _zufallsSeed;
    private List<string> _letzteThemen;
    private readonly List<GaitoBotSessionSchritt> _letzteSchritte;
    private readonly CultureInfo _denkprotokollKultur;
    private readonly List<BotDenkProtokollSchritt> _denkProtokoll;
    private readonly UserEigenschaften _userEigenschaften;
    private ArrayList _randomHistory;

    public DateTime LastActivity { get; private set; } = DateTime.UtcNow;

    public ArrayList RandomHistory
    {
      get
      {
        if (this._randomHistory == null)
          this._randomHistory = new ArrayList();
        return this._randomHistory;
      }
    }

    public bool BereitsEineNotfallAntwortGezeigt { get; set; }

    public UserEigenschaften UserEigenschaften
    {
      get
      {
        return this._userEigenschaften;
      }
    }

    public int ZufallsSeed
    {
      get
      {
        ++this._zufallsSeed;
        if (this._zufallsSeed > 10000)
          this._zufallsSeed = 0;
        return this._zufallsSeed + DateTime.UtcNow.Millisecond;
      }
    }

    public List<string> LetzteThemen
    {
      get
      {
        return this._letzteThemen;
      }
    }

    public string AktuellesThema
    {
      get
      {
        return this._letzteThemen.LastOrDefault<string>();
      }
    }

    public GaitoBotSessionSchritt LetzterSchritt
    {
      get
      {
        return this._letzteSchritte.LastOrDefault<GaitoBotSessionSchritt>();
      }
    }

    public List<GaitoBotSessionSchritt> LetzteSchritte
    {
      get
      {
        return this._letzteSchritte;
      }
    }

    public List<BotDenkProtokollSchritt> Denkprotokoll
    {
      get
      {
        return this._denkProtokoll;
      }
    }

    public CultureInfo DenkprotokollKultur
    {
      get
      {
        return this._denkprotokollKultur;
      }
    }

    public GaitoBotSession(CultureInfo denkprotokollKultur)
    {
      this._zufallsSeed = DateTime.UtcNow.Millisecond;
      this._userEigenschaften = new UserEigenschaften();
      this._denkprotokollKultur = denkprotokollKultur;
      this._denkProtokoll = new List<BotDenkProtokollSchritt>();
      this._letzteThemen = new List<string>();
      this._letzteSchritte = new List<GaitoBotSessionSchritt>();
    }

    public void DenkprotokollLeeren()
    {
      this._denkProtokoll.Clear();
    }

    public void AddSchritt(GaitoBotSessionSchritt schritt)
    {
      this._letzteSchritte.Add(schritt);
      this.SetzeAktuellesThema(schritt.Topic);
      this.LastActivity = DateTime.UtcNow;
    }

    public void SetzeAktuellesThema(string thema)
    {
      if (string.IsNullOrEmpty(thema))
      {
        this._letzteThemen = new List<string>() { "*" };
      }
      else
      {
        if (this._letzteThemen.Count > 1000)
          this._letzteThemen = new List<string>();
        else if (this._letzteThemen.Contains(thema))
          this._letzteThemen.Remove(thema);
        this._letzteThemen.Add(thema);
      }
    }
  }
}
