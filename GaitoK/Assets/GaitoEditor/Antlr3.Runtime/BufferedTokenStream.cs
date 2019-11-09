// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.BufferedTokenStream
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections.Generic;
using System.Text;

namespace Antlr.Runtime
{
  [Serializable]
  public class BufferedTokenStream : ITokenStream, IIntStream, ITokenStreamInformation
  {
    [CLSCompliant(false)]
    protected List<IToken> _tokens = new List<IToken>(100);
    [CLSCompliant(false)]
    protected int _p = -1;
    private ITokenSource _tokenSource;
    private int _lastMarker;

    public BufferedTokenStream()
    {
    }

    public BufferedTokenStream(ITokenSource tokenSource)
    {
      this._tokenSource = tokenSource;
    }

    public virtual ITokenSource TokenSource
    {
      get
      {
        return this._tokenSource;
      }
      set
      {
        this._tokenSource = value;
        this._tokens.Clear();
        this._p = -1;
      }
    }

    public virtual int Index
    {
      get
      {
        return this._p;
      }
    }

    public virtual int Range { get; protected set; }

    public virtual int Count
    {
      get
      {
        return this._tokens.Count;
      }
    }

    public virtual string SourceName
    {
      get
      {
        return this._tokenSource.SourceName;
      }
    }

    public virtual IToken LastToken
    {
      get
      {
        return this.LB(1);
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
          token = this.LB(k);
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

    public virtual int Mark()
    {
      if (this._p == -1)
        this.Setup();
      this._lastMarker = this.Index;
      return this._lastMarker;
    }

    public virtual void Release(int marker)
    {
    }

    public virtual void Rewind(int marker)
    {
      this.Seek(marker);
    }

    public virtual void Rewind()
    {
      this.Seek(this._lastMarker);
    }

    public virtual void Reset()
    {
      this._p = 0;
      this._lastMarker = 0;
    }

    public virtual void Seek(int index)
    {
      this._p = index;
    }

    public virtual void Consume()
    {
      if (this._p == -1)
        this.Setup();
      ++this._p;
      this.Sync(this._p);
    }

    protected virtual void Sync(int i)
    {
      int n = i - this._tokens.Count + 1;
      if (n <= 0)
        return;
      this.Fetch(n);
    }

    protected virtual void Fetch(int n)
    {
      for (int index = 0; index < n; ++index)
      {
        IToken token = this.TokenSource.NextToken();
        token.TokenIndex = this._tokens.Count;
        this._tokens.Add(token);
        if (token.Type == -1)
          break;
      }
    }

    public virtual IToken Get(int i)
    {
      if (i < 0 || i >= this._tokens.Count)
        throw new IndexOutOfRangeException("token index " + (object) i + " out of range 0.." + (object) (this._tokens.Count - 1));
      return this._tokens[i];
    }

    public virtual int LA(int i)
    {
      return this.LT(i).Type;
    }

    protected virtual IToken LB(int k)
    {
      if (this._p - k < 0)
        return (IToken) null;
      return this._tokens[this._p - k];
    }

    public virtual IToken LT(int k)
    {
      if (this._p == -1)
        this.Setup();
      if (k == 0)
        return (IToken) null;
      if (k < 0)
        return this.LB(-k);
      int i = this._p + k - 1;
      this.Sync(i);
      if (i >= this._tokens.Count)
        return this._tokens[this._tokens.Count - 1];
      if (i > this.Range)
        this.Range = i;
      return this._tokens[this._p + k - 1];
    }

    protected virtual void Setup()
    {
      this.Sync(0);
      this._p = 0;
    }

    public virtual List<IToken> GetTokens()
    {
      return this._tokens;
    }

    public virtual List<IToken> GetTokens(int start, int stop)
    {
      return this.GetTokens(start, stop, (BitSet) null);
    }

    public virtual List<IToken> GetTokens(int start, int stop, BitSet types)
    {
      if (this._p == -1)
        this.Setup();
      if (stop >= this._tokens.Count)
        stop = this._tokens.Count - 1;
      if (start < 0)
        start = 0;
      if (start > stop)
        return (List<IToken>) null;
      List<IToken> tokenList = new List<IToken>();
      for (int index = start; index <= stop; ++index)
      {
        IToken token = this._tokens[index];
        if (types == null || types.Member(token.Type))
          tokenList.Add(token);
      }
      if (tokenList.Count == 0)
        tokenList = (List<IToken>) null;
      return tokenList;
    }

    public virtual List<IToken> GetTokens(int start, int stop, IEnumerable<int> types)
    {
      return this.GetTokens(start, stop, new BitSet(types));
    }

    public virtual List<IToken> GetTokens(int start, int stop, int ttype)
    {
      return this.GetTokens(start, stop, BitSet.Of(ttype));
    }

    public override string ToString()
    {
      if (this._p == -1)
        this.Setup();
      this.Fill();
      return this.ToString(0, this._tokens.Count - 1);
    }

    public virtual string ToString(int start, int stop)
    {
      if (start < 0 || stop < 0)
        return (string) null;
      if (this._p == -1)
        this.Setup();
      if (stop >= this._tokens.Count)
        stop = this._tokens.Count - 1;
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = start; index <= stop; ++index)
      {
        IToken token = this._tokens[index];
        if (token.Type != -1)
          stringBuilder.Append(token.Text);
        else
          break;
      }
      return stringBuilder.ToString();
    }

    public virtual string ToString(IToken start, IToken stop)
    {
      if (start != null && stop != null)
        return this.ToString(start.TokenIndex, stop.TokenIndex);
      return (string) null;
    }

    public virtual void Fill()
    {
      if (this._p == -1)
        this.Setup();
      if (this._tokens[this._p].Type == -1)
        return;
      int i = this._p + 1;
      this.Sync(i);
      while (this._tokens[i].Type != -1)
      {
        ++i;
        this.Sync(i);
      }
    }
  }
}
