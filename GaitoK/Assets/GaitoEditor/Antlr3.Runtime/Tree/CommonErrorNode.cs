// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.CommonErrorNode
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;

namespace Antlr.Runtime.Tree
{
  [Serializable]
  public class CommonErrorNode : CommonTree
  {
    public IIntStream input;
    public IToken start;
    public IToken stop;
    public RecognitionException trappedException;

    public CommonErrorNode(ITokenStream input, IToken start, IToken stop, RecognitionException e)
    {
      if (stop == null || stop.TokenIndex < start.TokenIndex && stop.Type != -1)
        stop = start;
      this.input = (IIntStream) input;
      this.start = start;
      this.stop = stop;
      this.trappedException = e;
    }

    public override bool IsNil
    {
      get
      {
        return false;
      }
    }

    public override string Text
    {
      get
      {
        string str;
        if (this.start != null)
        {
          int tokenIndex = this.start.TokenIndex;
          int stop = this.stop.TokenIndex;
          if (this.stop.Type == -1)
            stop = this.input.Count;
          str = ((ITokenStream) this.input).ToString(tokenIndex, stop);
        }
        else
          str = !(this.start is ITree) ? "<unknown>" : ((ITreeNodeStream) this.input).ToString((object) this.start, (object) this.stop);
        return str;
      }
      set
      {
      }
    }

    public override int Type
    {
      get
      {
        return 0;
      }
      set
      {
      }
    }

    public override string ToString()
    {
      if (this.trappedException is MissingTokenException)
        return "<missing type: " + (object) ((MissingTokenException) this.trappedException).MissingType + ">";
      if (this.trappedException is UnwantedTokenException)
        return "<extraneous: " + (object) ((UnwantedTokenException) this.trappedException).UnexpectedToken + ", resync=" + this.Text + ">";
      if (this.trappedException is MismatchedTokenException)
        return "<mismatched token: " + (object) this.trappedException.Token + ", resync=" + this.Text + ">";
      if (!(this.trappedException is NoViableAltException))
        return "<error: " + this.Text + ">";
      return "<unexpected: " + (object) this.trappedException.Token + ", resync=" + this.Text + ">";
    }
  }
}
