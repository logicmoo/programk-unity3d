// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.caching.ObjectCacheContainer`2
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.Collections.Generic;

namespace de.springwald.toolbox.caching
{
  public class ObjectCacheContainer<TObjektTyp, TKeyTyp> : IDisposable
  {
    private volatile Dictionary<TKeyTyp, TObjektTyp> _cacheInhalte;

    public long VerfallsZeitpunktTicks { get; private set; }

    public long AnzahlObjekte
    {
      get
      {
        return (long) this._cacheInhalte.Count;
      }
    }

    public ObjectCacheContainer(DateTime verfallszeitpunkt)
    {
      this.VerfallsZeitpunktTicks = verfallszeitpunkt.Ticks;
      this._cacheInhalte = new Dictionary<TKeyTyp, TObjektTyp>();
    }

    public void AddObjekt(TKeyTyp key, TObjektTyp objekt)
    {
      try
      {
        this._cacheInhalte.Add(key, objekt);
      }
      catch (Exception ex)
      {
      }
    }

    public void RemoveObjekt(TKeyTyp key)
    {
      try
      {
        if (!this._cacheInhalte.ContainsKey(key))
          return;
        lock (this._cacheInhalte)
          this._cacheInhalte.Remove(key);
      }
      catch (Exception ex)
      {
      }
    }

    public TObjektTyp GetObjekt(TKeyTyp key)
    {
      try
      {
        if (this._cacheInhalte.ContainsKey(key))
          return this._cacheInhalte[key];
      }
      catch (Exception ex)
      {
      }
      return default (TObjektTyp);
    }

    public void Dispose()
    {
      if (this._cacheInhalte != null)
        this._cacheInhalte.Clear();
      this._cacheInhalte = (Dictionary<TKeyTyp, TObjektTyp>) null;
    }
  }
}
