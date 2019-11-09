// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.TreeFilter
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;

namespace Antlr.Runtime.Tree
{
  public class TreeFilter : TreeParser
  {
    protected ITokenStream originalTokenStream;
    protected ITreeAdaptor originalAdaptor;

    public TreeFilter(ITreeNodeStream input)
      : this(input, new RecognizerSharedState())
    {
    }

    public TreeFilter(ITreeNodeStream input, RecognizerSharedState state)
      : base(input, state)
    {
      this.originalAdaptor = input.TreeAdaptor;
      this.originalTokenStream = input.TokenStream;
    }

    public virtual void ApplyOnce(object t, Action whichRule)
    {
      if (t == null)
        return;
      try
      {
        this.state = new RecognizerSharedState();
        this.input = (ITreeNodeStream) new CommonTreeNodeStream(this.originalAdaptor, t);
        ((CommonTreeNodeStream) this.input).TokenStream = this.originalTokenStream;
        this.BacktrackingLevel = 1;
        whichRule();
        this.BacktrackingLevel = 0;
      }
      catch (RecognitionException ex)
      {
      }
    }

    public virtual void Downup(object t)
    {
      TreeVisitor treeVisitor = new TreeVisitor((ITreeAdaptor) new CommonTreeAdaptor());
      Func<object, object> preAction = (Func<object, object>) (o =>
      {
        this.ApplyOnce(o, new Action(this.Topdown));
        return o;
      });
      Func<object, object> postAction = (Func<object, object>) (o =>
      {
        this.ApplyOnce(o, new Action(this.Bottomup));
        return o;
      });
      treeVisitor.Visit(t, preAction, postAction);
    }

    protected virtual void Topdown()
    {
    }

    protected virtual void Bottomup()
    {
    }
  }
}
