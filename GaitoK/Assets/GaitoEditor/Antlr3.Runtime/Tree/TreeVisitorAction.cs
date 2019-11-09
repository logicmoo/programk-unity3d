// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.TreeVisitorAction
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;

namespace Antlr.Runtime.Tree
{
  public class TreeVisitorAction : ITreeVisitorAction
  {
    private Func<object, object> _preAction;
    private Func<object, object> _postAction;

    public TreeVisitorAction(Func<object, object> preAction, Func<object, object> postAction)
    {
      this._preAction = preAction;
      this._postAction = postAction;
    }

    public object Pre(object t)
    {
      if (this._preAction != null)
        return this._preAction(t);
      return t;
    }

    public object Post(object t)
    {
      if (this._postAction != null)
        return this._postAction(t);
      return t;
    }
  }
}
