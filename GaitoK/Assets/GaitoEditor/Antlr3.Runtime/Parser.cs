// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Parser
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System.Diagnostics;

namespace Antlr.Runtime
{
  public class Parser : BaseRecognizer
  {
    public ITokenStream input;

    public Parser(ITokenStream input)
    {
      this.TokenStream = input;
    }

    public Parser(ITokenStream input, RecognizerSharedState state)
      : base(state)
    {
      this.input = input;
    }

    public override void Reset()
    {
      base.Reset();
      if (this.input == null)
        return;
      this.input.Seek(0);
    }

    protected override object GetCurrentInputSymbol(IIntStream input)
    {
      return (object) ((ITokenStream) input).LT(1);
    }

    protected override object GetMissingSymbol(
      IIntStream input,
      RecognitionException e,
      int expectedTokenType,
      BitSet follow)
    {
      string text = expectedTokenType != -1 ? "<missing " + this.TokenNames[expectedTokenType] + ">" : "<missing EOF>";
      CommonToken commonToken = new CommonToken(expectedTokenType, text);
      IToken token = ((ITokenStream) input).LT(1);
      if (token.Type == -1)
        token = ((ITokenStream) input).LT(-1);
      commonToken.Line = token.Line;
      commonToken.CharPositionInLine = token.CharPositionInLine;
      commonToken.Channel = 0;
      return (object) commonToken;
    }

    public virtual ITokenStream TokenStream
    {
      get
      {
        return this.input;
      }
      set
      {
        this.input = (ITokenStream) null;
        this.Reset();
        this.input = value;
      }
    }

    public override string SourceName
    {
      get
      {
        return this.input.SourceName;
      }
    }

    [Conditional("ANTLR_TRACE")]
    public virtual void TraceIn(string ruleName, int ruleIndex)
    {
    }

    [Conditional("ANTLR_TRACE")]
    public virtual void TraceOut(string ruleName, int ruleIndex)
    {
    }
  }
}
