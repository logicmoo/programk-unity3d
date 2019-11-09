// Decompiled with JetBrains decompiler
// Type: Jint.DoubleListPropertyBag
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Native;
using System.Collections;
using System.Collections.Generic;

namespace Jint
{
  internal class DoubleListPropertyBag : IPropertyBag, IEnumerable<KeyValuePair<string, Descriptor>>, IEnumerable
  {
    private IList<string> keys;
    private IList<Descriptor> values;

    public DoubleListPropertyBag()
    {
      this.keys = (IList<string>) new List<string>(5);
      this.values = (IList<Descriptor>) new List<Descriptor>(5);
    }

    public Descriptor Put(string name, Descriptor descriptor)
    {
      lock (this.keys)
      {
        this.keys.Add(name);
        this.values.Add(descriptor);
      }
      return descriptor;
    }

    public void Delete(string name)
    {
      int index = this.keys.IndexOf(name);
      this.keys.RemoveAt(index);
      this.values.RemoveAt(index);
    }

    public Descriptor Get(string name)
    {
      return this.values[this.keys.IndexOf(name)];
    }

    public bool TryGet(string name, out Descriptor descriptor)
    {
      int index = this.keys.IndexOf(name);
      if (index < 0)
      {
        descriptor = (Descriptor) null;
        return false;
      }
      descriptor = this.values[index];
      return true;
    }

    public int Count
    {
      get
      {
        return this.keys.Count;
      }
    }

    public IEnumerable<Descriptor> Values
    {
      get
      {
        return (IEnumerable<Descriptor>) this.values;
      }
    }

    public IEnumerator<KeyValuePair<string, Descriptor>> GetEnumerator()
    {
      for (int i = 0; i < this.keys.Count; ++i)
        yield return new KeyValuePair<string, Descriptor>(this.keys[i], this.values[i]);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.GetEnumerator();
    }
  }
}
