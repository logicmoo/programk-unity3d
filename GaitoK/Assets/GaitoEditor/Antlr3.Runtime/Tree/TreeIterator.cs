// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.TreeIterator
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections;
using System.Collections.Generic;

namespace Antlr.Runtime.Tree
{
  public class TreeIterator : IEnumerator<object>, IDisposable, IEnumerator
  {
    protected bool firstTime = true;
    protected ITreeAdaptor adaptor;
    protected object root;
    protected object tree;
    public object up;
    public object down;
    public object eof;
    protected Queue<object> nodes;

    public TreeIterator(object tree)
      : this((ITreeAdaptor) new CommonTreeAdaptor(), tree)
    {
    }

    public TreeIterator(ITreeAdaptor adaptor, object tree)
    {
      this.adaptor = adaptor;
      this.tree = tree;
      this.root = tree;
      this.nodes = new Queue<object>();
      this.down = adaptor.Create(2, "DOWN");
      this.up = adaptor.Create(3, "UP");
      this.eof = adaptor.Create(-1, "EOF");
    }

    public object Current { get; private set; }

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
      if (this.firstTime)
      {
        this.firstTime = false;
        if (this.adaptor.GetChildCount(this.tree) == 0)
          this.nodes.Enqueue(this.eof);
        this.Current = this.tree;
      }
      else if (this.nodes != null && this.nodes.Count > 0)
        this.Current = this.nodes.Dequeue();
      else if (this.tree == null)
        this.Current = this.eof;
      else if (this.adaptor.GetChildCount(this.tree) > 0)
      {
        this.tree = this.adaptor.GetChild(this.tree, 0);
        this.nodes.Enqueue(this.tree);
        this.Current = this.down;
      }
      else
      {
        object parent;
        for (parent = this.adaptor.GetParent(this.tree); parent != null && this.adaptor.GetChildIndex(this.tree) + 1 >= this.adaptor.GetChildCount(parent); parent = this.adaptor.GetParent(this.tree))
        {
          this.nodes.Enqueue(this.up);
          this.tree = parent;
        }
        if (parent == null)
        {
          this.tree = (object) null;
          this.nodes.Enqueue(this.eof);
          this.Current = this.nodes.Dequeue();
        }
        else
        {
          int i = this.adaptor.GetChildIndex(this.tree) + 1;
          this.tree = this.adaptor.GetChild(parent, i);
          this.nodes.Enqueue(this.tree);
          this.Current = this.nodes.Dequeue();
        }
      }
      return this.Current != this.eof;
    }

    public void Reset()
    {
      this.firstTime = true;
      this.tree = this.root;
      this.nodes.Clear();
    }
  }
}
