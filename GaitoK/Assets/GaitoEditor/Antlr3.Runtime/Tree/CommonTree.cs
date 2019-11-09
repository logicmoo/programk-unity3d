// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.CommonTree
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;

namespace Antlr.Runtime.Tree
{
  [Serializable]
  public class CommonTree : BaseTree
  {
    protected int startIndex = -1;
    protected int stopIndex = -1;
    private int childIndex = -1;
    [CLSCompliant(false)]
    public IToken token;
    private CommonTree parent;

    public CommonTree()
    {
    }

    public CommonTree(CommonTree node)
      : base((ITree) node)
    {
      if (node == null)
        throw new ArgumentNullException(nameof (node));
      this.token = node.token;
      this.startIndex = node.startIndex;
      this.stopIndex = node.stopIndex;
    }

    public CommonTree(IToken t)
    {
      this.token = t;
    }

    public override int CharPositionInLine
    {
      get
      {
        if (this.token != null && this.token.CharPositionInLine != -1)
          return this.token.CharPositionInLine;
        if (this.ChildCount > 0)
          return this.Children[0].CharPositionInLine;
        return 0;
      }
      set
      {
        base.CharPositionInLine = value;
      }
    }

    public override int ChildIndex
    {
      get
      {
        return this.childIndex;
      }
      set
      {
        this.childIndex = value;
      }
    }

    public override bool IsNil
    {
      get
      {
        return this.token == null;
      }
    }

    public override int Line
    {
      get
      {
        if (this.token != null && this.token.Line != 0)
          return this.token.Line;
        if (this.ChildCount > 0)
          return this.Children[0].Line;
        return 0;
      }
      set
      {
        base.Line = value;
      }
    }

    public override ITree Parent
    {
      get
      {
        return (ITree) this.parent;
      }
      set
      {
        this.parent = (CommonTree) value;
      }
    }

    public override string Text
    {
      get
      {
        if (this.token == null)
          return (string) null;
        return this.token.Text;
      }
      set
      {
      }
    }

    public virtual IToken Token
    {
      get
      {
        return this.token;
      }
      set
      {
        this.token = value;
      }
    }

    public override int TokenStartIndex
    {
      get
      {
        if (this.startIndex == -1 && this.token != null)
          return this.token.TokenIndex;
        return this.startIndex;
      }
      set
      {
        this.startIndex = value;
      }
    }

    public override int TokenStopIndex
    {
      get
      {
        if (this.stopIndex == -1 && this.token != null)
          return this.token.TokenIndex;
        return this.stopIndex;
      }
      set
      {
        this.stopIndex = value;
      }
    }

    public override int Type
    {
      get
      {
        if (this.token == null)
          return 0;
        return this.token.Type;
      }
      set
      {
      }
    }

    public override ITree DupNode()
    {
      return (ITree) new CommonTree(this);
    }

    public virtual void SetUnknownTokenBoundaries()
    {
      if (this.Children == null)
      {
        if (this.startIndex >= 0 && this.stopIndex >= 0)
          return;
        this.startIndex = this.stopIndex = this.token.TokenIndex;
      }
      else
      {
        for (int index = 0; index < this.Children.Count; ++index)
          ((CommonTree) this.Children[index]).SetUnknownTokenBoundaries();
        if (this.startIndex >= 0 && this.stopIndex >= 0 || this.Children.Count <= 0)
          return;
        CommonTree child1 = (CommonTree) this.Children[0];
        CommonTree child2 = (CommonTree) this.Children[this.Children.Count - 1];
        this.startIndex = child1.TokenStartIndex;
        this.stopIndex = child2.TokenStopIndex;
      }
    }

    public override string ToString()
    {
      if (this.IsNil)
        return "nil";
      if (this.Type == 0)
        return "<errornode>";
      if (this.token == null)
        return string.Empty;
      return this.token.Text;
    }
  }
}
