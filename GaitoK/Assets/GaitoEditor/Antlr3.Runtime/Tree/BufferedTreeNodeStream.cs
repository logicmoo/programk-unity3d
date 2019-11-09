// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.BufferedTreeNodeStream
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Antlr.Runtime.Tree
{
  public class BufferedTreeNodeStream : ITreeNodeStream, IIntStream, ITokenStreamInformation
  {
    protected int p = -1;
    public const int DEFAULT_INITIAL_BUFFER_SIZE = 100;
    public const int INITIAL_CALL_STACK_SIZE = 10;
    protected object down;
    protected object up;
    protected object eof;
    protected IList nodes;
    protected object root;
    protected ITokenStream tokens;
    private ITreeAdaptor adaptor;
    private bool uniqueNavigationNodes;
    protected int lastMarker;
    protected Stack<int> calls;

    public BufferedTreeNodeStream(object tree)
      : this((ITreeAdaptor) new CommonTreeAdaptor(), tree)
    {
    }

    public BufferedTreeNodeStream(ITreeAdaptor adaptor, object tree)
      : this(adaptor, tree, 100)
    {
    }

    public BufferedTreeNodeStream(ITreeAdaptor adaptor, object tree, int initialBufferSize)
    {
      this.root = tree;
      this.adaptor = adaptor;
      this.nodes = (IList) new List<object>(initialBufferSize);
      this.down = adaptor.Create(2, "DOWN");
      this.up = adaptor.Create(3, "UP");
      this.eof = adaptor.Create(-1, "EOF");
    }

    public virtual int Count
    {
      get
      {
        if (this.p == -1)
          throw new InvalidOperationException("Cannot determine the Count before the buffer is filled.");
        return this.nodes.Count;
      }
    }

    public virtual object TreeSource
    {
      get
      {
        return this.root;
      }
    }

    public virtual string SourceName
    {
      get
      {
        return this.TokenStream.SourceName;
      }
    }

    public virtual ITokenStream TokenStream
    {
      get
      {
        return this.tokens;
      }
      set
      {
        this.tokens = value;
      }
    }

    public virtual ITreeAdaptor TreeAdaptor
    {
      get
      {
        return this.adaptor;
      }
      set
      {
        this.adaptor = value;
      }
    }

    public virtual bool UniqueNavigationNodes
    {
      get
      {
        return this.uniqueNavigationNodes;
      }
      set
      {
        this.uniqueNavigationNodes = value;
      }
    }

    public virtual IToken LastToken
    {
      get
      {
        return this.TreeAdaptor.GetToken(this.LB(1));
      }
    }

    public virtual IToken LastRealToken
    {
      get
      {
        int k = 0;
        IToken token;
        do
        {
          ++k;
          token = this.TreeAdaptor.GetToken(this.LB(k));
        }
        while (token != null && token.Line <= 0);
        return token;
      }
    }

    public virtual int MaxLookBehind
    {
      get
      {
        return int.MaxValue;
      }
    }

    protected virtual void FillBuffer()
    {
      this.FillBuffer(this.root);
      this.p = 0;
    }

    public virtual void FillBuffer(object t)
    {
      bool flag = this.adaptor.IsNil(t);
      if (!flag)
        this.nodes.Add(t);
      int childCount = this.adaptor.GetChildCount(t);
      if (!flag && childCount > 0)
        this.AddNavigationNode(2);
      for (int i = 0; i < childCount; ++i)
        this.FillBuffer(this.adaptor.GetChild(t, i));
      if (flag || childCount <= 0)
        return;
      this.AddNavigationNode(3);
    }

    protected virtual int GetNodeIndex(object node)
    {
      if (this.p == -1)
        this.FillBuffer();
      for (int index = 0; index < this.nodes.Count; ++index)
      {
        if (this.nodes[index] == node)
          return index;
      }
      return -1;
    }

    protected virtual void AddNavigationNode(int ttype)
    {
      this.nodes.Add(ttype != 2 ? (!this.UniqueNavigationNodes ? this.up : this.adaptor.Create(3, "UP")) : (!this.UniqueNavigationNodes ? this.down : this.adaptor.Create(2, "DOWN")));
    }

    public virtual object this[int i]
    {
      get
      {
        if (this.p == -1)
          throw new InvalidOperationException("Cannot get the node at index i before the buffer is filled.");
        return this.nodes[i];
      }
    }

    public virtual object LT(int k)
    {
      if (this.p == -1)
        this.FillBuffer();
      if (k == 0)
        return (object) null;
      if (k < 0)
        return this.LB(-k);
      if (this.p + k - 1 >= this.nodes.Count)
        return this.eof;
      return this.nodes[this.p + k - 1];
    }

    public virtual object GetCurrentSymbol()
    {
      return this.LT(1);
    }

    protected virtual object LB(int k)
    {
      if (k == 0)
        return (object) null;
      if (this.p - k < 0)
        return (object) null;
      return this.nodes[this.p - k];
    }

    public virtual void Consume()
    {
      if (this.p == -1)
        this.FillBuffer();
      ++this.p;
    }

    public virtual int LA(int i)
    {
      return this.adaptor.GetType(this.LT(i));
    }

    public virtual int Mark()
    {
      if (this.p == -1)
        this.FillBuffer();
      this.lastMarker = this.Index;
      return this.lastMarker;
    }

    public virtual void Release(int marker)
    {
    }

    public virtual int Index
    {
      get
      {
        return this.p;
      }
    }

    public virtual void Rewind(int marker)
    {
      this.Seek(marker);
    }

    public virtual void Rewind()
    {
      this.Seek(this.lastMarker);
    }

    public virtual void Seek(int index)
    {
      if (this.p == -1)
        this.FillBuffer();
      this.p = index;
    }

    public virtual void Push(int index)
    {
      if (this.calls == null)
        this.calls = new Stack<int>();
      this.calls.Push(this.p);
      this.Seek(index);
    }

    public virtual int Pop()
    {
      int index = this.calls.Pop();
      this.Seek(index);
      return index;
    }

    public virtual void Reset()
    {
      this.p = 0;
      this.lastMarker = 0;
      if (this.calls == null)
        return;
      this.calls.Clear();
    }

    public virtual IEnumerator<object> Iterator()
    {
      if (this.p == -1)
        this.FillBuffer();
      return (IEnumerator<object>) new BufferedTreeNodeStream.StreamIterator(this);
    }

    public virtual void ReplaceChildren(
      object parent,
      int startChildIndex,
      int stopChildIndex,
      object t)
    {
      if (parent == null)
        return;
      this.adaptor.ReplaceChildren(parent, startChildIndex, stopChildIndex, t);
    }

    public virtual string ToTokenTypeString()
    {
      if (this.p == -1)
        this.FillBuffer();
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < this.nodes.Count; ++index)
      {
        object node = this.nodes[index];
        stringBuilder.Append(" ");
        stringBuilder.Append(this.adaptor.GetType(node));
      }
      return stringBuilder.ToString();
    }

    public virtual string ToTokenString(int start, int stop)
    {
      if (this.p == -1)
        this.FillBuffer();
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = start; index < this.nodes.Count && index <= stop; ++index)
      {
        object node = this.nodes[index];
        stringBuilder.Append(" ");
        stringBuilder.Append((object) this.adaptor.GetToken(node));
      }
      return stringBuilder.ToString();
    }

    public virtual string ToString(object start, object stop)
    {
      Console.Out.WriteLine("toString");
      if (start == null || stop == null)
        return (string) null;
      if (this.p == -1)
        throw new InvalidOperationException("Buffer is not yet filled.");
      if (start is CommonTree)
        Console.Out.Write("toString: " + (object) ((CommonTree) start).Token + ", ");
      else
        Console.Out.WriteLine(start);
      if (stop is CommonTree)
        Console.Out.WriteLine((object) ((CommonTree) stop).Token);
      else
        Console.Out.WriteLine(stop);
      if (this.tokens != null)
      {
        int tokenStartIndex = this.adaptor.GetTokenStartIndex(start);
        int stop1 = this.adaptor.GetTokenStopIndex(stop);
        if (this.adaptor.GetType(stop) == 3)
          stop1 = this.adaptor.GetTokenStopIndex(start);
        else if (this.adaptor.GetType(stop) == -1)
          stop1 = this.Count - 2;
        return this.tokens.ToString(tokenStartIndex, stop1);
      }
      int index = 0;
      while (index < this.nodes.Count && this.nodes[index] != start)
        ++index;
      StringBuilder stringBuilder = new StringBuilder();
      for (object node = this.nodes[index]; node != stop; node = this.nodes[index])
      {
        string str = this.adaptor.GetText(node) ?? " " + this.adaptor.GetType(node).ToString();
        stringBuilder.Append(str);
        ++index;
      }
      string str1 = this.adaptor.GetText(stop) ?? " " + this.adaptor.GetType(stop).ToString();
      stringBuilder.Append(str1);
      return stringBuilder.ToString();
    }

    protected sealed class StreamIterator : IEnumerator<object>, IDisposable, IEnumerator
    {
      private BufferedTreeNodeStream _outer;
      private int _index;

      public StreamIterator(BufferedTreeNodeStream outer)
      {
        this._outer = outer;
        this._index = -1;
      }

      public object Current
      {
        get
        {
          if (this._index < this._outer.nodes.Count)
            return this._outer.nodes[this._index];
          return this._outer.eof;
        }
      }

      public void Dispose()
      {
      }

      public bool MoveNext()
      {
        if (this._index < this._outer.nodes.Count)
          ++this._index;
        return this._index < this._outer.nodes.Count;
      }

      public void Reset()
      {
        this._index = -1;
      }
    }
  }
}
