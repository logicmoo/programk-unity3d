// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.LegacyCommonTokenStream
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections.Generic;
using System.Text;

namespace Antlr.Runtime
{
  [Serializable]
  public class LegacyCommonTokenStream : ITokenStream, IIntStream
  {
    protected int p = -1;
    [NonSerialized]
    private ITokenSource _tokenSource;
    protected List<IToken> tokens;
    protected IDictionary<int, int> channelOverrideMap;
    protected HashSet<int> discardSet;
    protected int channel;
    protected bool discardOffChannelTokens;
    protected int lastMarker;

    public LegacyCommonTokenStream()
    {
      this.tokens = new List<IToken>(500);
    }

    public LegacyCommonTokenStream(ITokenSource tokenSource)
      : this()
    {
      this._tokenSource = tokenSource;
    }

    public LegacyCommonTokenStream(ITokenSource tokenSource, int channel)
      : this(tokenSource)
    {
      this.channel = channel;
    }

    public virtual int Index
    {
      get
      {
        return this.p;
      }
    }

    public virtual int Range { get; protected set; }

    public virtual void SetTokenSource(ITokenSource tokenSource)
    {
      this._tokenSource = tokenSource;
      this.tokens.Clear();
      this.p = -1;
      this.channel = 0;
    }

    public virtual void FillBuffer()
    {
      if (this.p != -1)
        return;
      int num1 = 0;
      for (IToken token = this._tokenSource.NextToken(); token != null && token.Type != -1; token = this._tokenSource.NextToken())
      {
        bool flag = false;
        int num2;
        if (this.channelOverrideMap != null && this.channelOverrideMap.TryGetValue(token.Type, out num2))
          token.Channel = num2;
        if (this.discardSet != null && this.discardSet.Contains(token.Type))
          flag = true;
        else if (this.discardOffChannelTokens && token.Channel != this.channel)
          flag = true;
        if (!flag)
        {
          token.TokenIndex = num1;
          this.tokens.Add(token);
          ++num1;
        }
      }
      this.p = 0;
      this.p = this.SkipOffTokenChannels(this.p);
    }

    public virtual void Consume()
    {
      if (this.p >= this.tokens.Count)
        return;
      ++this.p;
      this.p = this.SkipOffTokenChannels(this.p);
    }

    protected virtual int SkipOffTokenChannels(int i)
    {
      int count = this.tokens.Count;
      while (i < count && this.tokens[i].Channel != this.channel)
        ++i;
      return i;
    }

    protected virtual int SkipOffTokenChannelsReverse(int i)
    {
      while (i >= 0 && this.tokens[i].Channel != this.channel)
        --i;
      return i;
    }

    public virtual void SetTokenTypeChannel(int ttype, int channel)
    {
      if (this.channelOverrideMap == null)
        this.channelOverrideMap = (IDictionary<int, int>) new Dictionary<int, int>();
      this.channelOverrideMap[ttype] = channel;
    }

    public virtual void DiscardTokenType(int ttype)
    {
      if (this.discardSet == null)
        this.discardSet = new HashSet<int>();
      this.discardSet.Add(ttype);
    }

    public virtual void SetDiscardOffChannelTokens(bool discardOffChannelTokens)
    {
      this.discardOffChannelTokens = discardOffChannelTokens;
    }

    public virtual IList<IToken> GetTokens()
    {
      if (this.p == -1)
        this.FillBuffer();
      return (IList<IToken>) this.tokens;
    }

    public virtual IList<IToken> GetTokens(int start, int stop)
    {
      return this.GetTokens(start, stop, (BitSet) null);
    }

    public virtual IList<IToken> GetTokens(int start, int stop, BitSet types)
    {
      if (this.p == -1)
        this.FillBuffer();
      if (stop >= this.tokens.Count)
        stop = this.tokens.Count - 1;
      if (start < 0)
        start = 0;
      if (start > stop)
        return (IList<IToken>) null;
      IList<IToken> tokenList = (IList<IToken>) new List<IToken>();
      for (int index = start; index <= stop; ++index)
      {
        IToken token = this.tokens[index];
        if (types == null || types.Member(token.Type))
          tokenList.Add(token);
      }
      if (tokenList.Count == 0)
        tokenList = (IList<IToken>) null;
      return tokenList;
    }

    public virtual IList<IToken> GetTokens(int start, int stop, IList<int> types)
    {
      return this.GetTokens(start, stop, new BitSet((IEnumerable<int>) types));
    }

    public virtual IList<IToken> GetTokens(int start, int stop, int ttype)
    {
      return this.GetTokens(start, stop, BitSet.Of(ttype));
    }

    public virtual IToken LT(int k)
    {
      if (this.p == -1)
        this.FillBuffer();
      if (k == 0)
        return (IToken) null;
      if (k < 0)
        return this.LB(-k);
      if (this.p + k - 1 >= this.tokens.Count)
        return this.tokens[this.tokens.Count - 1];
      int index1 = this.p;
      for (int index2 = 1; index2 < k; ++index2)
        index1 = this.SkipOffTokenChannels(index1 + 1);
      if (index1 >= this.tokens.Count)
        return this.tokens[this.tokens.Count - 1];
      if (index1 > this.Range)
        this.Range = index1;
      return this.tokens[index1];
    }

    protected virtual IToken LB(int k)
    {
      if (this.p == -1)
        this.FillBuffer();
      if (k == 0)
        return (IToken) null;
      if (this.p - k < 0)
        return (IToken) null;
      int index1 = this.p;
      for (int index2 = 1; index2 <= k; ++index2)
        index1 = this.SkipOffTokenChannelsReverse(index1 - 1);
      if (index1 < 0)
        return (IToken) null;
      return this.tokens[index1];
    }

    public virtual IToken Get(int i)
    {
      return this.tokens[i];
    }

    public virtual int LA(int i)
    {
      return this.LT(i).Type;
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

    public virtual int Count
    {
      get
      {
        return this.tokens.Count;
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

    public virtual void Reset()
    {
      this.p = 0;
      this.lastMarker = 0;
    }

    public virtual void Seek(int index)
    {
      this.p = index;
    }

    public virtual ITokenSource TokenSource
    {
      get
      {
        return this._tokenSource;
      }
    }

    public virtual string SourceName
    {
      get
      {
        return this.TokenSource.SourceName;
      }
    }

    public override string ToString()
    {
      if (this.p == -1)
        throw new InvalidOperationException("Buffer is not yet filled.");
      return this.ToString(0, this.tokens.Count - 1);
    }

    public virtual string ToString(int start, int stop)
    {
      if (start < 0 || stop < 0)
        return (string) null;
      if (this.p == -1)
        throw new InvalidOperationException("Buffer is not yet filled.");
      if (stop >= this.tokens.Count)
        stop = this.tokens.Count - 1;
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = start; index <= stop; ++index)
      {
        IToken token = this.tokens[index];
        stringBuilder.Append(token.Text);
      }
      return stringBuilder.ToString();
    }

    public virtual string ToString(IToken start, IToken stop)
    {
      if (start != null && stop != null)
        return this.ToString(start.TokenIndex, stop.TokenIndex);
      return (string) null;
    }
  }
}
