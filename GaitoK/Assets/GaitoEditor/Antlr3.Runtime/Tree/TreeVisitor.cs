// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.TreeVisitor
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;

namespace Antlr.Runtime.Tree
{
  public class TreeVisitor
  {
    protected ITreeAdaptor adaptor;

    public TreeVisitor(ITreeAdaptor adaptor)
    {
      this.adaptor = adaptor;
    }

    public TreeVisitor()
      : this((ITreeAdaptor) new CommonTreeAdaptor())
    {
    }

    public object Visit(object t, ITreeVisitorAction action)
    {
      bool flag = this.adaptor.IsNil(t);
      if (action != null && !flag)
        t = action.Pre(t);
      for (int i = 0; i < this.adaptor.GetChildCount(t); ++i)
        this.Visit(this.adaptor.GetChild(t, i), action);
      if (action != null && !flag)
        t = action.Post(t);
      return t;
    }

    public object Visit(object t, Func<object, object> preAction, Func<object, object> postAction)
    {
      return this.Visit(t, (ITreeVisitorAction) new TreeVisitorAction(preAction, postAction));
    }
  }
}
