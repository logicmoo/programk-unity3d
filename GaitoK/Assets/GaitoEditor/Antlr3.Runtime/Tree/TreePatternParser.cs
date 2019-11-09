// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.TreePatternParser
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;

namespace Antlr.Runtime.Tree
{
  public class TreePatternParser
  {
    protected TreePatternLexer tokenizer;
    protected int ttype;
    protected TreeWizard wizard;
    protected ITreeAdaptor adaptor;

    public TreePatternParser(TreePatternLexer tokenizer, TreeWizard wizard, ITreeAdaptor adaptor)
    {
      this.tokenizer = tokenizer;
      this.wizard = wizard;
      this.adaptor = adaptor;
      this.ttype = tokenizer.NextToken();
    }

    public virtual object Pattern()
    {
      if (this.ttype == 1)
        return this.ParseTree();
      if (this.ttype != 3)
        return (object) null;
      object node = this.ParseNode();
      if (this.ttype == -1)
        return node;
      return (object) null;
    }

    public virtual object ParseTree()
    {
      if (this.ttype != 1)
        throw new InvalidOperationException("No beginning.");
      this.ttype = this.tokenizer.NextToken();
      object node1 = this.ParseNode();
      if (node1 == null)
        return (object) null;
      while (this.ttype == 1 || this.ttype == 3 || (this.ttype == 5 || this.ttype == 7))
      {
        if (this.ttype == 1)
        {
          object tree = this.ParseTree();
          this.adaptor.AddChild(node1, tree);
        }
        else
        {
          object node2 = this.ParseNode();
          if (node2 == null)
            return (object) null;
          this.adaptor.AddChild(node1, node2);
        }
      }
      if (this.ttype != 2)
        throw new InvalidOperationException("No end.");
      this.ttype = this.tokenizer.NextToken();
      return node1;
    }

    public virtual object ParseNode()
    {
      string str1 = (string) null;
      if (this.ttype == 5)
      {
        this.ttype = this.tokenizer.NextToken();
        if (this.ttype != 3)
          return (object) null;
        str1 = this.tokenizer.sval.ToString();
        this.ttype = this.tokenizer.NextToken();
        if (this.ttype != 6)
          return (object) null;
        this.ttype = this.tokenizer.NextToken();
      }
      if (this.ttype == 7)
      {
        this.ttype = this.tokenizer.NextToken();
        TreeWizard.TreePattern treePattern = (TreeWizard.TreePattern) new TreeWizard.WildcardTreePattern((IToken) new CommonToken(0, "."));
        if (str1 != null)
          treePattern.label = str1;
        return (object) treePattern;
      }
      if (this.ttype != 3)
        return (object) null;
      string tokenName = this.tokenizer.sval.ToString();
      this.ttype = this.tokenizer.NextToken();
      if (tokenName.Equals("nil"))
        return this.adaptor.Nil();
      string text = tokenName;
      string str2 = (string) null;
      if (this.ttype == 4)
      {
        str2 = this.tokenizer.sval.ToString();
        text = str2;
        this.ttype = this.tokenizer.NextToken();
      }
      int tokenType = this.wizard.GetTokenType(tokenName);
      if (tokenType == 0)
        return (object) null;
      object obj = this.adaptor.Create(tokenType, text);
      if (str1 != null && obj.GetType() == typeof (TreeWizard.TreePattern))
        ((TreeWizard.TreePattern) obj).label = str1;
      if (str2 != null && obj.GetType() == typeof (TreeWizard.TreePattern))
        ((TreeWizard.TreePattern) obj).hasTextArg = true;
      return obj;
    }
  }
}
