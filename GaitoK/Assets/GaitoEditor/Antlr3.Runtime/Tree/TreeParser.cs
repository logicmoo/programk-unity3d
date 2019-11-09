// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.TreeParser
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Antlr.Runtime.Tree
{
  public class TreeParser : BaseRecognizer
  {
    private static string dotdot = ".*[^.]\\.\\.[^.].*";
    private static string doubleEtc = ".*\\.\\.\\.\\s+\\.\\.\\..*";
    private static Regex dotdotPattern = new Regex(TreeParser.dotdot, RegexOptions.Compiled);
    private static Regex doubleEtcPattern = new Regex(TreeParser.doubleEtc, RegexOptions.Compiled);
    public const int DOWN = 2;
    public const int UP = 3;
    protected ITreeNodeStream input;

    public TreeParser(ITreeNodeStream input)
    {
      this.SetTreeNodeStream(input);
    }

    public TreeParser(ITreeNodeStream input, RecognizerSharedState state)
      : base(state)
    {
      this.SetTreeNodeStream(input);
    }

    public override void Reset()
    {
      base.Reset();
      if (this.input == null)
        return;
      this.input.Seek(0);
    }

    public virtual void SetTreeNodeStream(ITreeNodeStream input)
    {
      this.input = input;
    }

    public virtual ITreeNodeStream GetTreeNodeStream()
    {
      return this.input;
    }

    public override string SourceName
    {
      get
      {
        return this.input.SourceName;
      }
    }

    protected override object GetCurrentInputSymbol(IIntStream input)
    {
      return ((ITreeNodeStream) input).LT(1);
    }

    protected override object GetMissingSymbol(
      IIntStream input,
      RecognitionException e,
      int expectedTokenType,
      BitSet follow)
    {
      string text = "<missing " + this.TokenNames[expectedTokenType] + ">";
      return ((ITreeNodeStream) e.Input).TreeAdaptor.Create((IToken) new CommonToken(expectedTokenType, text));
    }

    public override void MatchAny(IIntStream ignore)
    {
      this.state.errorRecovery = false;
      this.state.failed = false;
      this.input.Consume();
      if (this.input.LA(1) != 2)
        return;
      this.input.Consume();
      int num = 1;
      while (num > 0)
      {
        switch (this.input.LA(1))
        {
          case -1:
            return;
          case 2:
            ++num;
            break;
          case 3:
            --num;
            break;
        }
        this.input.Consume();
      }
    }

    protected override object RecoverFromMismatchedToken(
      IIntStream input,
      int ttype,
      BitSet follow)
    {
      throw new MismatchedTreeNodeException(ttype, (ITreeNodeStream) input);
    }

    public override string GetErrorHeader(RecognitionException e)
    {
      return this.GrammarFileName + ": node from " + (e.ApproximateLineInfo ? (object) "after " : (object) "") + "line " + (object) e.Line + ":" + (object) e.CharPositionInLine;
    }

    public override string GetErrorMessage(RecognitionException e, string[] tokenNames)
    {
      if (this != null)
      {
        ITreeAdaptor treeAdaptor = ((ITreeNodeStream) e.Input).TreeAdaptor;
        e.Token = treeAdaptor.GetToken(e.Node);
        if (e.Token == null)
          e.Token = (IToken) new CommonToken(treeAdaptor.GetType(e.Node), treeAdaptor.GetText(e.Node));
      }
      return base.GetErrorMessage(e, tokenNames);
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
