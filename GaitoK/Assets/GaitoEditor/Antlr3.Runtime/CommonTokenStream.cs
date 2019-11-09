// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.CommonTokenStream
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;

namespace Antlr.Runtime
{
  [Serializable]
  public class CommonTokenStream : BufferedTokenStream
  {
    private int _channel;

    public CommonTokenStream()
    {
    }

    public CommonTokenStream(ITokenSource tokenSource)
      : this(tokenSource, 0)
    {
    }

    public CommonTokenStream(ITokenSource tokenSource, int channel)
      : base(tokenSource)
    {
      this._channel = channel;
    }

    public int Channel
    {
      get
      {
        return this._channel;
      }
    }

    public override ITokenSource TokenSource
    {
      get
      {
        return base.TokenSource;
      }
      set
      {
        base.TokenSource = value;
        this._channel = 0;
      }
    }

    public override void Consume()
    {
      if (this._p == -1)
        this.Setup();
      ++this._p;
      this._p = this.SkipOffTokenChannels(this._p);
    }

    protected override IToken LB(int k)
    {
      if (k == 0 || this._p - k < 0)
        return (IToken) null;
      int index1 = this._p;
      for (int index2 = 1; index2 <= k; ++index2)
        index1 = this.SkipOffTokenChannelsReverse(index1 - 1);
      if (index1 < 0)
        return (IToken) null;
      return this._tokens[index1];
    }

    public override IToken LT(int k)
    {
      if (this._p == -1)
        this.Setup();
      if (k == 0)
        return (IToken) null;
      if (k < 0)
        return this.LB(-k);
      int index1 = this._p;
      for (int index2 = 1; index2 < k; ++index2)
        index1 = this.SkipOffTokenChannels(index1 + 1);
      if (index1 > this.Range)
        this.Range = index1;
      return this._tokens[index1];
    }

    protected virtual int SkipOffTokenChannels(int i)
    {
      this.Sync(i);
      while (this._tokens[i].Channel != this._channel)
      {
        ++i;
        this.Sync(i);
      }
      return i;
    }

    protected virtual int SkipOffTokenChannelsReverse(int i)
    {
      while (i >= 0 && this._tokens[i].Channel != this._channel)
        --i;
      return i;
    }

    protected override void Setup()
    {
      this._p = 0;
      this._p = this.SkipOffTokenChannels(this._p);
    }
  }
}
