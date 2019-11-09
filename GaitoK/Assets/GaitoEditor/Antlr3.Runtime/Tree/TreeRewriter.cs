// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.TreeRewriter
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;

namespace Antlr.Runtime.Tree
{
  public class TreeRewriter : TreeParser
  {
    protected bool showTransformations;
    protected ITokenStream originalTokenStream;
    protected ITreeAdaptor originalAdaptor;
    private Func<IAstRuleReturnScope> topdown_func;
    private Func<IAstRuleReturnScope> bottomup_func;

    public TreeRewriter(ITreeNodeStream input)
      : this(input, new RecognizerSharedState())
    {
    }

    public TreeRewriter(ITreeNodeStream input, RecognizerSharedState state)
      : base(input, state)
    {
      this.originalAdaptor = input.TreeAdaptor;
      this.originalTokenStream = input.TokenStream;
      this.topdown_func = (Func<IAstRuleReturnScope>) (() => this.Topdown());
      this.bottomup_func = (Func<IAstRuleReturnScope>) (() => this.Bottomup());
    }

    public virtual object ApplyOnce(object t, Func<IAstRuleReturnScope> whichRule)
    {
      if (t == null)
        return (object) null;
      try
      {
        this.state = new RecognizerSharedState();
        this.input = (ITreeNodeStream) new CommonTreeNodeStream(this.originalAdaptor, t);
        ((CommonTreeNodeStream) this.input).TokenStream = this.originalTokenStream;
        this.BacktrackingLevel = 1;
        IAstRuleReturnScope astRuleReturnScope = whichRule();
        this.BacktrackingLevel = 0;
        if (this.Failed)
          return t;
        if (this.showTransformations && astRuleReturnScope != null && (!t.Equals(astRuleReturnScope.Tree) && astRuleReturnScope.Tree != null))
          this.ReportTransformation(t, astRuleReturnScope.Tree);
        if (astRuleReturnScope != null && astRuleReturnScope.Tree != null)
          return astRuleReturnScope.Tree;
        return t;
      }
      catch (RecognitionException ex)
      {
      }
      return t;
    }

    public virtual object ApplyRepeatedly(object t, Func<IAstRuleReturnScope> whichRule)
    {
      bool flag = true;
      while (flag)
      {
        object obj = this.ApplyOnce(t, whichRule);
        flag = !t.Equals(obj);
        t = obj;
      }
      return t;
    }

    public virtual object Downup(object t)
    {
      return this.Downup(t, false);
    }

    public virtual object Downup(object t, bool showTransformations)
    {
      this.showTransformations = showTransformations;
      t = new TreeVisitor((ITreeAdaptor) new CommonTreeAdaptor()).Visit(t, (Func<object, object>) (o => this.ApplyOnce(o, this.topdown_func)), (Func<object, object>) (o => this.ApplyRepeatedly(o, this.bottomup_func)));
      return t;
    }

    public virtual IAstRuleReturnScope Topdown()
    {
      return (IAstRuleReturnScope) null;
    }

    public virtual IAstRuleReturnScope Bottomup()
    {
      return (IAstRuleReturnScope) null;
    }

    protected virtual void ReportTransformation(object oldTree, object newTree)
    {
      ITree tree1 = oldTree as ITree;
      ITree tree2 = newTree as ITree;
      Console.WriteLine("{0} -> {1}", tree1 != null ? (object) tree1.ToStringTree() : (object) "??", tree2 != null ? (object) tree2.ToStringTree() : (object) "??");
    }
  }
}
