// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.RewriteRuleElementStream
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace Antlr.Runtime.Tree
{
  [Serializable]
  public abstract class RewriteRuleElementStream
  {
    protected int cursor;
    protected object singleElement;
    protected IList elements;
    protected bool dirty;
    protected string elementDescription;
    protected ITreeAdaptor adaptor;

    public RewriteRuleElementStream(ITreeAdaptor adaptor, string elementDescription)
    {
      this.elementDescription = elementDescription;
      this.adaptor = adaptor;
    }

    public RewriteRuleElementStream(
      ITreeAdaptor adaptor,
      string elementDescription,
      object oneElement)
      : this(adaptor, elementDescription)
    {
      this.Add(oneElement);
    }

    public RewriteRuleElementStream(
      ITreeAdaptor adaptor,
      string elementDescription,
      IList elements)
      : this(adaptor, elementDescription)
    {
      this.singleElement = (object) null;
      this.elements = elements;
    }

    public virtual void Reset()
    {
      this.cursor = 0;
      this.dirty = true;
    }

    public virtual void Add(object el)
    {
      if (el == null)
        return;
      if (this.elements != null)
        this.elements.Add(el);
      else if (this.singleElement == null)
      {
        this.singleElement = el;
      }
      else
      {
        this.elements = (IList) new List<object>(5);
        this.elements.Add(this.singleElement);
        this.singleElement = (object) null;
        this.elements.Add(el);
      }
    }

    public virtual object NextTree()
    {
      int count = this.Count;
      if (this.dirty || this.cursor >= count && count == 1)
        return this.Dup(this.NextCore());
      return this.NextCore();
    }

    protected virtual object NextCore()
    {
      int count = this.Count;
      if (count == 0)
        throw new RewriteEmptyStreamException(this.elementDescription);
      if (this.cursor >= count)
      {
        if (count == 1)
          return this.ToTree(this.singleElement);
        throw new RewriteCardinalityException(this.elementDescription);
      }
      if (this.singleElement != null)
      {
        ++this.cursor;
        return this.ToTree(this.singleElement);
      }
      object tree = this.ToTree(this.elements[this.cursor]);
      ++this.cursor;
      return tree;
    }

    protected abstract object Dup(object el);

    protected virtual object ToTree(object el)
    {
      return el;
    }

    public virtual bool HasNext
    {
      get
      {
        if (this.singleElement != null && this.cursor < 1)
          return true;
        if (this.elements != null)
          return this.cursor < this.elements.Count;
        return false;
      }
    }

    public virtual int Count
    {
      get
      {
        int num = 0;
        if (this.singleElement != null)
          num = 1;
        if (this.elements != null)
          return this.elements.Count;
        return num;
      }
    }

    public virtual string Description
    {
      get
      {
        return this.elementDescription;
      }
    }
  }
}
