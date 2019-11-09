// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.UnbufferedTokenStream
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using Antlr.Runtime.Misc;
using System;

namespace Antlr.Runtime
{
  public class UnbufferedTokenStream : LookaheadStream<IToken>, ITokenStream, IIntStream
  {
    [CLSCompliant(false)]
    protected ITokenSource tokenSource;
    protected int tokenIndex;
    protected int channel;

    public UnbufferedTokenStream(ITokenSource tokenSource)
    {
      this.tokenSource = tokenSource;
    }

    public ITokenSource TokenSource
    {
      get
      {
        return this.tokenSource;
      }
    }

    public string SourceName
    {
      get
      {
        return this.TokenSource.SourceName;
      }
    }

    public override IToken NextElement()
    {
      IToken token = this.tokenSource.NextToken();
      token.TokenIndex = this.tokenIndex++;
      return token;
    }

    public override bool IsEndOfFile(IToken o)
    {
      return o.Type == -1;
    }

    public IToken Get(int i)
    {
      throw new NotSupportedException("Absolute token indexes are meaningless in an unbuffered stream");
    }

    public int LA(int i)
    {
      return this.LT(i).Type;
    }

    public string ToString(int start, int stop)
    {
      return "n/a";
    }

    public string ToString(IToken start, IToken stop)
    {
      return "n/a";
    }
  }
}
