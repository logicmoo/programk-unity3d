// Decompiled with JetBrains decompiler
// Type: Jint.DictionaryPropertyBag
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Native;
using System.Collections;
using System.Collections.Generic;

namespace Jint
{
  internal class DictionaryPropertyBag : IPropertyBag, IEnumerable<KeyValuePair<string, Descriptor>>, IEnumerable
  {
    private Dictionary<string, Descriptor> bag = new Dictionary<string, Descriptor>(5);

    public Descriptor Put(string name, Descriptor descriptor)
    {
      this.bag[name] = descriptor;
      return descriptor;
    }

    public void Delete(string name)
    {
      this.bag.Remove(name);
    }

    public Descriptor Get(string name)
    {
      Descriptor descriptor;
      this.TryGet(name, out descriptor);
      return descriptor;
    }

    public bool TryGet(string name, out Descriptor descriptor)
    {
      return this.bag.TryGetValue(name, out descriptor);
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
        return (IEnumerable<Descriptor>) this.bag.Values;
      }
    }

    public IEnumerator<KeyValuePair<string, Descriptor>> GetEnumerator()
    {
      return (IEnumerator<KeyValuePair<string, Descriptor>>) this.bag.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.GetEnumerator();
    }
  }
}
