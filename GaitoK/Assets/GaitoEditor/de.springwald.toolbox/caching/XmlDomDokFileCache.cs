// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.caching.XmlDomDokFileCache
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using de.springwald.toolbox.Serialisierung;
using System;
using System.IO;
using System.Xml;

namespace de.springwald.toolbox.caching
{
  public class XmlDomDokFileCache : ICacheParameter
  {
    private ObjektCache<string, XmlDocument> _domCache;

    public long MaxObjekte
    {
      get
      {
        return this._domCache.MaxObjekte;
      }
      set
      {
        this._domCache.MaxObjekte = value;
      }
    }

    public TimeSpan MaxObjektLebensdauer
    {
      get
      {
        return this._domCache.MaxObjektLebensdauer;
      }
      set
      {
        this._domCache.MaxObjektLebensdauer = value;
      }
    }

    public XmlDomDokFileCache()
    {
      this._domCache = new ObjektCache<string, XmlDocument>();
      this._domCache.OnNeuesObjektWirdBenoetigt += new ObjektCache<string, XmlDocument>.NeuesObjektWirdBenoetigtEventHandler(this._domCache_OnNeuesObjektWirdBenoetigt);
    }

    public string GetStatus(string zeilenUmbruch)
    {
      return this._domCache.GetStatus(zeilenUmbruch);
    }

    public XmlDocument GetDokument(
      string filename,
      ObjektSerialisiererVerwaltung<XmlDocument>.WasTunWennObjektNichtVorhanden wasTunWennDateiNichtVorhanden)
    {
      filename = filename.Replace("/", "\\");
      filename = filename.Trim().ToLower();
      return this._domCache.GetCacheObjekt(filename, (object) null, wasTunWennDateiNichtVorhanden);
    }

    private void _domCache_OnNeuesObjektWirdBenoetigt(
      object sender,
      ObjektCache<string, XmlDocument>.NeuesObjektWirdBenoetigtEventArgs eventArgs)
    {
      string key = eventArgs.Key;
      if (!File.Exists(key))
        return;
      XmlDocument xmlDocument = new XmlDocument();
      xmlDocument.Load(key);
      eventArgs.Objekt = xmlDocument;
    }
  }
}
