// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.ParseTree
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections.Generic;
using System.Text;

namespace Antlr.Runtime.Tree
{
  [Serializable]
  public class ParseTree : BaseTree
  {
    public object payload;
    public List<IToken> hiddenTokens;

    public ParseTree(object label)
    {
      this.payload = label;
    }

    public override string Text
    {
      get
      {
        return this.ToString();
      }
      set
      {
      }
    }

    public override int TokenStartIndex
    {
      get
      {
        return 0;
      }
      set
      {
      }
    }

    public override int TokenStopIndex
    {
      get
      {
        return 0;
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

    public override ITree DupNode()
    {
      return (ITree) null;
    }

    public override string ToString()
    {
      if (!(this.payload is IToken))
        return this.payload.ToString();
      IToken payload = (IToken) this.payload;
      if (payload.Type == -1)
        return "<EOF>";
      return payload.Text;
    }

    public virtual string ToStringWithHiddenTokens()
    {
      StringBuilder stringBuilder = new StringBuilder();
      if (this.hiddenTokens != null)
      {
        for (int index = 0; index < this.hiddenTokens.Count; ++index)
        {
          IToken hiddenToken = this.hiddenTokens[index];
          stringBuilder.Append(hiddenToken.Text);
        }
      }
      string str = this.ToString();
      if (!str.Equals("<EOF>"))
        stringBuilder.Append(str);
      return stringBuilder.ToString();
    }

    public virtual string ToInputString()
    {
      StringBuilder buf = new StringBuilder();
      this.ToStringLeaves(buf);
      return buf.ToString();
    }

    protected virtual void ToStringLeaves(StringBuilder buf)
    {
      if (this.payload is IToken)
      {
        buf.Append(this.ToStringWithHiddenTokens());
      }
      else
      {
        for (int index = 0; this.Children != null && index < this.Children.Count; ++index)
          ((ParseTree) this.Children[index]).ToStringLeaves(buf);
      }
    }
  }
}
