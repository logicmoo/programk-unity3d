// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Lexer
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System.Collections.Generic;
using System.Diagnostics;

namespace Antlr.Runtime
{
  public abstract class Lexer : BaseRecognizer, ITokenSource
  {
    protected ICharStream input;

    public Lexer()
    {
    }

    public Lexer(ICharStream input)
    {
      this.input = input;
    }

    public Lexer(ICharStream input, RecognizerSharedState state)
      : base(state)
    {
      this.input = input;
    }

    public string Text
    {
      get
      {
        if (this.state.text != null)
          return this.state.text;
        return this.input.Substring(this.state.tokenStartCharIndex, this.CharIndex - this.state.tokenStartCharIndex);
      }
      set
      {
        this.state.text = value;
      }
    }

    public int Line
    {
      get
      {
        return this.input.Line;
      }
      set
      {
        this.input.Line = value;
      }
    }

    public int CharPositionInLine
    {
      get
      {
        return this.input.CharPositionInLine;
      }
      set
      {
        this.input.CharPositionInLine = value;
      }
    }

    public override void Reset()
    {
      base.Reset();
      if (this.input != null)
        this.input.Seek(0);
      if (this.state == null)
        return;
      this.state.token = (IToken) null;
      this.state.type = 0;
      this.state.channel = 0;
      this.state.tokenStartCharIndex = -1;
      this.state.tokenStartCharPositionInLine = -1;
      this.state.tokenStartLine = -1;
      this.state.text = (string) null;
    }

    public virtual IToken NextToken()
    {
      while (true)
      {
        this.state.token = (IToken) null;
        this.state.channel = 0;
        this.state.tokenStartCharIndex = this.input.Index;
        this.state.tokenStartCharPositionInLine = this.input.CharPositionInLine;
        this.state.tokenStartLine = this.input.Line;
        this.state.text = (string) null;
        if (this.input.LA(1) != -1)
        {
          try
          {
            this.mTokens();
            if (this.state.token == null)
              this.Emit();
            else if (this.state.token == Tokens.Skip)
              continue;
            return this.state.token;
          }
          catch (NoViableAltException ex)
          {
            this.ReportError((RecognitionException) ex);
            this.Recover((RecognitionException) ex);
          }
          catch (RecognitionException ex)
          {
            this.ReportError(ex);
          }
        }
        else
          break;
      }
      IToken token = (IToken) new CommonToken(this.input, -1, 0, this.input.Index, this.input.Index);
      token.Line = this.Line;
      token.CharPositionInLine = this.CharPositionInLine;
      return token;
    }

    public virtual void Skip()
    {
      this.state.token = Tokens.Skip;
    }

    public abstract void mTokens();

    public virtual ICharStream CharStream
    {
      get
      {
        return this.input;
      }
      set
      {
        this.input = (ICharStream) null;
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

    public virtual void Emit(IToken token)
    {
      this.state.token = token;
    }

    public virtual IToken Emit()
    {
      IToken token = (IToken) new CommonToken(this.input, this.state.type, this.state.channel, this.state.tokenStartCharIndex, this.CharIndex - 1);
      token.Line = this.state.tokenStartLine;
      token.Text = this.state.text;
      token.CharPositionInLine = this.state.tokenStartCharPositionInLine;
      this.Emit(token);
      return token;
    }

    public virtual void Match(string s)
    {
      int index = 0;
      while (index < s.Length)
      {
        if (this.input.LA(1) != (int) s[index])
        {
          if (this.state.backtracking > 0)
          {
            this.state.failed = true;
            break;
          }
          MismatchedTokenException mismatchedTokenException = new MismatchedTokenException((int) s[index], (IIntStream) this.input, (IList<string>) this.TokenNames);
          this.Recover((RecognitionException) mismatchedTokenException);
          throw mismatchedTokenException;
        }
        ++index;
        this.input.Consume();
        this.state.failed = false;
      }
    }

    public virtual void MatchAny()
    {
      this.input.Consume();
    }

    public virtual void Match(int c)
    {
      if (this.input.LA(1) != c)
      {
        if (this.state.backtracking > 0)
        {
          this.state.failed = true;
        }
        else
        {
          MismatchedTokenException mismatchedTokenException = new MismatchedTokenException(c, (IIntStream) this.input, (IList<string>) this.TokenNames);
          this.Recover((RecognitionException) mismatchedTokenException);
          throw mismatchedTokenException;
        }
      }
      else
      {
        this.input.Consume();
        this.state.failed = false;
      }
    }

    public virtual void MatchRange(int a, int b)
    {
      if (this.input.LA(1) < a || this.input.LA(1) > b)
      {
        if (this.state.backtracking > 0)
        {
          this.state.failed = true;
        }
        else
        {
          MismatchedRangeException mismatchedRangeException = new MismatchedRangeException(a, b, (IIntStream) this.input);
          this.Recover((RecognitionException) mismatchedRangeException);
          throw mismatchedRangeException;
        }
      }
      else
      {
        this.input.Consume();
        this.state.failed = false;
      }
    }

    public virtual int CharIndex
    {
      get
      {
        return this.input.Index;
      }
    }

    public override void ReportError(RecognitionException e)
    {
      this.DisplayRecognitionError(this.TokenNames, e);
    }

    public override string GetErrorMessage(RecognitionException e, string[] tokenNames)
    {
      string str;
      if (e is MismatchedTokenException)
      {
        MismatchedTokenException mismatchedTokenException = (MismatchedTokenException) e;
        str = "mismatched character " + this.GetCharErrorDisplay(e.Character) + " expecting " + this.GetCharErrorDisplay(mismatchedTokenException.Expecting);
      }
      else if (e is NoViableAltException)
        str = "no viable alternative at character " + this.GetCharErrorDisplay(e.Character);
      else if (e is EarlyExitException)
        str = "required (...)+ loop did not match anything at character " + this.GetCharErrorDisplay(e.Character);
      else if (e is MismatchedNotSetException)
      {
        MismatchedNotSetException mismatchedNotSetException = (MismatchedNotSetException) e;
        str = "mismatched character " + this.GetCharErrorDisplay(e.Character) + " expecting set " + (object) mismatchedNotSetException.Expecting;
      }
      else if (e is MismatchedSetException)
      {
        MismatchedSetException mismatchedSetException = (MismatchedSetException) e;
        str = "mismatched character " + this.GetCharErrorDisplay(e.Character) + " expecting set " + (object) mismatchedSetException.Expecting;
      }
      else if (e is MismatchedRangeException)
      {
        MismatchedRangeException mismatchedRangeException = (MismatchedRangeException) e;
        str = "mismatched character " + this.GetCharErrorDisplay(e.Character) + " expecting set " + this.GetCharErrorDisplay(mismatchedRangeException.A) + ".." + this.GetCharErrorDisplay(mismatchedRangeException.B);
      }
      else
        str = base.GetErrorMessage(e, tokenNames);
      return str;
    }

    public virtual string GetCharErrorDisplay(int c)
    {
      string str = ((char) c).ToString();
      switch (c)
      {
        case -1:
          str = "<EOF>";
          break;
        case 9:
          str = "\\t";
          break;
        case 10:
          str = "\\n";
          break;
        case 13:
          str = "\\r";
          break;
      }
      return "'" + str + "'";
    }

    public virtual void Recover(RecognitionException re)
    {
      this.input.Consume();
    }

    [Conditional("ANTLR_TRACE")]
    public virtual void TraceIn(string ruleName, int ruleIndex)
    {
      ((int) (ushort) this.input.LT(1)).ToString() + " line=" + (object) this.Line + ":" + (object) this.CharPositionInLine;
    }

    [Conditional("ANTLR_TRACE")]
    public virtual void TraceOut(string ruleName, int ruleIndex)
    {
      ((int) (ushort) this.input.LT(1)).ToString() + " line=" + (object) this.Line + ":" + (object) this.CharPositionInLine;
    }
  }
}
