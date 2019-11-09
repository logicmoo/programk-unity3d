// Decompiled with JetBrains decompiler
// Type: Jint.PropertyBags.MiniCachedPropertyBag
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Native;
using System.Collections;
using System.Collections.Generic;

namespace Jint.PropertyBags
{
  public class MiniCachedPropertyBag : IPropertyBag, IEnumerable<KeyValuePair<string, Descriptor>>, IEnumerable
  {
    private IPropertyBag bag;
    private Descriptor lastAccessed;

    public MiniCachedPropertyBag()
    {
      this.bag = (IPropertyBag) new DictionaryPropertyBag();
    }

    public Descriptor Put(string name, Descriptor descriptor)
    {
      this.bag.Put(name, descriptor);
      return this.lastAccessed = descriptor;
    }

    public void Delete(string name)
    {
      this.bag.Delete(name);
      if (this.lastAccessed == null || !(this.lastAccessed.Name == name))
        return;
      this.lastAccessed = (Descriptor) null;
    }

    public Descriptor Get(string name)
    {
      if (this.lastAccessed != null && this.lastAccessed.Name == name)
        return this.lastAccessed;
      Descriptor descriptor = this.bag.Get(name);
      if (descriptor != null)
        this.lastAccessed = descriptor;
      return descriptor;
    }

    public bool TryGet(string name, out Descriptor descriptor)
    {
      if (this.lastAccessed != null && this.lastAccessed.Name == name)
      {
        descriptor = this.lastAccessed;
        return true;
      }
      bool flag = this.bag.TryGet(name, out descriptor);
      if (flag)
        this.lastAccessed = descriptor;
      return flag;
    }

    public int Count
    {
      get
      {
        return this.bag.Count;
      }
    }

    public IEnumerable<Descriptor> Values
    {
      get
      {
        return this.bag.Values;
      }
    }

    public IEnumerator<KeyValuePair<string, Descriptor>> GetEnumerator()
    {
      return this.bag.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.GetEnumerator();
    }
  }
}
