// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.AntlrRuntime_BaseTreeDebugView
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System.Diagnostics;

namespace Antlr.Runtime.Tree
{
  internal sealed class AntlrRuntime_BaseTreeDebugView
  {
    private readonly BaseTree _tree;

    public AntlrRuntime_BaseTreeDebugView(BaseTree tree)
    {
      this._tree = tree;
    }

    [DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
    public ITree[] Children
    {
      get
      {
        if (this._tree == null || this._tree.Children == null)
          return (ITree[]) null;
        ITree[] array = new ITree[this._tree.Children.Count];
        this._tree.Children.CopyTo(array, 0);
        return array;
      }
    }
  }
}
