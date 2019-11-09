// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.caching.ObjektCache`2
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using de.springwald.toolbox.Serialisierung;
using System;
using System.Collections.Generic;
using System.Text;

namespace de.springwald.toolbox.caching
{
  [Serializable]
  public class ObjektCache<KeyTyp, ObjektTyp> : ICacheParameter
  {
    private readonly object _cacheLock = new object();
    private long _maxContainer = 20;
    private volatile List<ObjectCacheContainer<ObjektTyp, KeyTyp>> _container;
    private long _maxObjekteProContainer;

    public event ObjektCache<KeyTyp, ObjektTyp>.NeuesObjektWirdBenoetigtEventHandler OnNeuesObjektWirdBenoetigt;

    private void NeuesObjektWirdBenoetigtEventWerfen(
      ObjektCache<KeyTyp, ObjektTyp>.NeuesObjektWirdBenoetigtEventArgs eventArgs)
    {
      if (this.OnNeuesObjektWirdBenoetigt == null)
        throw new ApplicationException("Es wurde kein Listener auf das 'NeuesObjektWirdBenötigt' Event registriert. Daher könnte *nie* ein Objekt aus dem ObjektCache geliefert werden.");
      this.OnNeuesObjektWirdBenoetigt((object) this, eventArgs);
    }

    public string GetStatus(string zeilenUmbruch)
    {
      StringBuilder stringBuilder = new StringBuilder();
      int num = 0;
      foreach (ObjectCacheContainer<ObjektTyp, KeyTyp> objectCacheContainer in this._container)
      {
        ++num;
        stringBuilder.AppendFormat("Container {0}:{1}{2}", (object) objectCacheContainer.VerfallsZeitpunktTicks, (object) objectCacheContainer.AnzahlObjekte, (object) zeilenUmbruch);
        stringBuilder.Append(zeilenUmbruch);
      }
      return stringBuilder.ToString();
    }

    public long MaxObjekte
    {
      get
      {
        return this._maxContainer * this._maxObjekteProContainer;
      }
      set
      {
        this._maxObjekteProContainer = value / this._maxContainer;
      }
    }

    public TimeSpan MaxObjektLebensdauer { get; set; }

    public bool NichtCachen { get; set; }

    public ObjektCache()
    {
      this._container = new List<ObjectCacheContainer<ObjektTyp, KeyTyp>>();
      this.MaxObjektLebensdauer = new TimeSpan(2, 0, 0);
      this.MaxObjekte = 10000L;
      this.NichtCachen = false;
    }

    public void VerwerfeObjekt(KeyTyp key)
    {
      try
      {
        for (int index = this._container.Count - 1; index >= 0; --index)
          this._container[index].RemoveObjekt(key);
      }
      catch (Exception ex)
      {
      }
    }

    public bool IstObjektImCache(KeyTyp key)
    {
      foreach (ObjectCacheContainer<ObjektTyp, KeyTyp> objectCacheContainer in this._container)
      {
        if ((object) objectCacheContainer.GetObjekt(key) != null)
          return true;
      }
      return false;
    }

    public void LeereCache()
    {
      try
      {
        lock (this._cacheLock)
        {
          while (this._container.Count > 0)
          {
            ObjectCacheContainer<ObjektTyp, KeyTyp> objectCacheContainer = this._container[0];
            this._container.Remove(objectCacheContainer);
            objectCacheContainer.Dispose();
          }
        }
      }
      catch (Exception ex)
      {
      }
    }

    public ObjektTyp GetCacheObjekt(
      KeyTyp key,
      object referenzObjekt,
      ObjektSerialisiererVerwaltung<ObjektTyp>.WasTunWennObjektNichtVorhanden wasTunWennNull)
    {
      ObjektTyp objekt1 = default (ObjektTyp);
      if (!this.NichtCachen)
      {
        try
        {
          for (int index = this._container.Count - 1; index >= 0; --index)
          {
            if (DateTime.UtcNow.Ticks > this._container[index].VerfallsZeitpunktTicks)
            {
              lock (this._cacheLock)
              {
                ObjectCacheContainer<ObjektTyp, KeyTyp> objectCacheContainer = this._container[index];
                this._container.Remove(objectCacheContainer);
                objectCacheContainer.Dispose();
              }
            }
          }
        }
        catch (Exception ex)
        {
        }
        foreach (ObjectCacheContainer<ObjektTyp, KeyTyp> objectCacheContainer in this._container)
        {
          ObjektTyp objekt2 = objectCacheContainer.GetObjekt(key);
          if ((object) objekt2 != null)
            return objekt2;
        }
      }
      ObjektCache<KeyTyp, ObjektTyp>.NeuesObjektWirdBenoetigtEventArgs eventArgs = new ObjektCache<KeyTyp, ObjektTyp>.NeuesObjektWirdBenoetigtEventArgs(key, referenzObjekt, objekt1, wasTunWennNull);
      this.NeuesObjektWirdBenoetigtEventWerfen(eventArgs);
      ObjektTyp objekt3 = eventArgs.Objekt;
      if (!this.NichtCachen && (object) objekt3 != null)
      {
        ObjectCacheContainer<ObjektTyp, KeyTyp> objectCacheContainer1 = (ObjectCacheContainer<ObjektTyp, KeyTyp>) null;
        if (this._container.Count == 0)
        {
          objectCacheContainer1 = new ObjectCacheContainer<ObjektTyp, KeyTyp>(DateTime.UtcNow + this.MaxObjektLebensdauer);
          this._container.Add(objectCacheContainer1);
        }
        else
        {
          int index = 0;
          try
          {
            for (; objectCacheContainer1 == null && index < this._container.Count; ++index)
            {
              objectCacheContainer1 = this._container[index];
              if (objectCacheContainer1.AnzahlObjekte >= this._maxObjekteProContainer)
                objectCacheContainer1 = (ObjectCacheContainer<ObjektTyp, KeyTyp>) null;
            }
          }
          catch (Exception ex)
          {
          }
          if (objectCacheContainer1 == null)
          {
            lock (this._cacheLock)
            {
              objectCacheContainer1 = new ObjectCacheContainer<ObjektTyp, KeyTyp>(DateTime.UtcNow + this.MaxObjektLebensdauer);
              this._container.Add(objectCacheContainer1);
              while ((long) this._container.Count > this._maxContainer)
              {
                ObjectCacheContainer<ObjektTyp, KeyTyp> objectCacheContainer2 = this._container[0];
                this._container.Remove(objectCacheContainer2);
                objectCacheContainer2.Dispose();
              }
            }
          }
        }
        objectCacheContainer1.AddObjekt(key, objekt3);
      }
      if ((object) objekt3 == null)
      {
        switch (wasTunWennNull)
        {
          case ObjektSerialisiererVerwaltung<ObjektTyp>.WasTunWennObjektNichtVorhanden.FehlerWerfen:
            throw new ApplicationException("Es konnte kein Objekt für den key '" + (object) key + "' bereitgestellt werden!");
          case ObjektSerialisiererVerwaltung<ObjektTyp>.WasTunWennObjektNichtVorhanden.NullZurueckgeben:
            break;
          default:
            throw new ApplicationException("Unbehandeltes ObjektCacheFehlerBeiNullObjekt '" + (object) wasTunWennNull + "' bei wasTunWennNull für key '" + (object) key + "'!");
        }
      }
      return objekt3;
    }

    public class NeuesObjektWirdBenoetigtEventArgs : EventArgs
    {
      public readonly KeyTyp Key;
      public ObjektTyp Objekt;
      public object HilfsdatenLieferungsObjekt;
      public ObjektSerialisiererVerwaltung<ObjektTyp>.WasTunWennObjektNichtVorhanden WasTunWennNichtVorhanden;

      public NeuesObjektWirdBenoetigtEventArgs(
        KeyTyp key,
        object hilfsdatenLieferungsObjekt,
        ObjektTyp objekt,
        ObjektSerialisiererVerwaltung<ObjektTyp>.WasTunWennObjektNichtVorhanden wasTunWennNichtVorhanden)
      {
        this.Key = key;
        this.Objekt = objekt;
        this.HilfsdatenLieferungsObjekt = hilfsdatenLieferungsObjekt;
        this.WasTunWennNichtVorhanden = wasTunWennNichtVorhanden;
      }
    }

    public delegate void NeuesObjektWirdBenoetigtEventHandler(
      object sender,
      ObjektCache<KeyTyp, ObjektTyp>.NeuesObjektWirdBenoetigtEventArgs eventArgs);
  }
}
