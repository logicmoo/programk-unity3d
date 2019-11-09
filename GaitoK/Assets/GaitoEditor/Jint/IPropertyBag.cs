// Decompiled with JetBrains decompiler
// Type: Jint.IPropertyBag
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Native;
using System.Collections;
using System.Collections.Generic;

namespace Jint
{
  public interface IPropertyBag : IEnumerable<KeyValuePair<string, Descriptor>>, IEnumerable
  {
    Descriptor Put(string name, Descriptor descriptor);

    void Delete(string name);

    Descriptor Get(string name);

    bool TryGet(string name, out Descriptor descriptor);

    int Count { get; }

    IEnumerable<Descriptor> Values { get; }
  }
}
