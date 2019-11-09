// Decompiled with JetBrains decompiler
// Type: Jint.PropertyBags.HashedPropertyBag
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Native;
using System.Collections;
using System.Collections.Generic;

namespace Jint.PropertyBags
{
  public class HashedPropertyBag : IPropertyBag, IEnumerable<KeyValuePair<string, Descriptor>>, IEnumerable
  {
    private Hashtable keys;

    public HashedPropertyBag()
    {
      this.keys = new Hashtable();
    }

    public Descriptor Put(string name, Descriptor descriptor)
    {
      this.keys.Add((object) name, (object) descriptor);
      return descriptor;
    }

    public void Delete(string name)
    {
      this.keys.Remove((object) name);
    }

    public Descriptor Get(string name)
    {
      return this.keys[(object) name] as Descriptor;
    }

    public bool TryGet(string name, out Descriptor descriptor)
    {
      descriptor = this.Get(name);
      return descriptor != null;
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
        foreach (DictionaryEntry key in this.keys)
        {
          DictionaryEntry de = key;
          yield return de.Value as Descriptor;
          de = new DictionaryEntry();
        }
      }
    }

    public IEnumerator<KeyValuePair<string, Descriptor>> GetEnumerator()
    {
      foreach (DictionaryEntry key in this.keys)
      {
        DictionaryEntry de = key;
        yield return new KeyValuePair<string, Descriptor>(de.Key as string, de.Value as Descriptor);
        de = new DictionaryEntry();
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.GetEnumerator();
    }
  }
}
