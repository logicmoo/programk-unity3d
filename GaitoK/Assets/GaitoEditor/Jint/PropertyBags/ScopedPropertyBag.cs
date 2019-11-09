// Decompiled with JetBrains decompiler
// Type: Jint.PropertyBags.ScopedPropertyBag
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Native;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Jint.PropertyBags
{
  public class ScopedPropertyBag : IPropertyBag, IEnumerable<KeyValuePair<string, Descriptor>>, IEnumerable
  {
    private Dictionary<string, Stack<Descriptor>> bag = new Dictionary<string, Stack<Descriptor>>();
    private Stack<List<Stack<Descriptor>>> scopes = new Stack<List<Stack<Descriptor>>>();
    private List<Stack<Descriptor>> currentScope;

    public void EnterScope()
    {
      this.currentScope = new List<Stack<Descriptor>>();
      this.scopes.Push(this.currentScope);
    }

    public void ExitScope()
    {
      foreach (Stack<Descriptor> descriptorStack in this.currentScope)
        descriptorStack.Pop();
      this.scopes.Pop();
      this.currentScope = this.scopes.Peek();
    }

    public Descriptor Put(string name, Descriptor descriptor)
    {
      Stack<Descriptor> descriptorStack;
      if (!this.bag.TryGetValue(name, out descriptorStack))
      {
        descriptorStack = new Stack<Descriptor>();
        this.bag.Add(name, descriptorStack);
      }
      descriptorStack.Push(descriptor);
      this.currentScope.Add(descriptorStack);
      return descriptor;
    }

    public void Delete(string name)
    {
      Stack<Descriptor> descriptorStack;
      if (!this.bag.TryGetValue(name, out descriptorStack) || !this.currentScope.Contains(descriptorStack))
        return;
      descriptorStack.Pop();
      this.currentScope.Remove(descriptorStack);
    }

    public Descriptor Get(string name)
    {
      Stack<Descriptor> descriptorStack;
      if (this.bag.TryGetValue(name, out descriptorStack))
        return descriptorStack.Count > 0 ? descriptorStack.Peek() : (Descriptor) null;
      return (Descriptor) null;
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
        return this.bag.Count;
      }
    }

    public IEnumerable<Descriptor> Values
    {
      get
      {
        throw new NotImplementedException();
      }
    }

    public IEnumerator<KeyValuePair<string, Descriptor>> GetEnumerator()
    {
      throw new NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      throw new NotImplementedException();
    }
  }
}
