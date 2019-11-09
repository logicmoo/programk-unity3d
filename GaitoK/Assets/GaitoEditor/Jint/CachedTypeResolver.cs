// Decompiled with JetBrains decompiler
// Type: Jint.CachedTypeResolver
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace Jint
{
  public class CachedTypeResolver : ITypeResolver
  {
    private readonly Dictionary<string, Type> _cache = new Dictionary<string, Type>();
    private readonly ReaderWriterLock _lock = new ReaderWriterLock();
    private static CachedTypeResolver _default;

    public static CachedTypeResolver Default
    {
      get
      {
        lock (typeof (CachedTypeResolver))
          return CachedTypeResolver._default ?? (CachedTypeResolver._default = new CachedTypeResolver());
      }
    }

    public Type ResolveType(string fullname)
    {
      this._lock.AcquireReaderLock(-1);
      try
      {
        if (this._cache.ContainsKey(fullname))
          return this._cache[fullname];
        Type type = (Type) null;
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
          type = assembly.GetType(fullname, false, false);
          if (type != null)
            break;
        }
        this._lock.UpgradeToWriterLock(-1);
        this._cache.Add(fullname, type);
        return type;
      }
      finally
      {
        this._lock.ReleaseLock();
      }
    }
  }
}
