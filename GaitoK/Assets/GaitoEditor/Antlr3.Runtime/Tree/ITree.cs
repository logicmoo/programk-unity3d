// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.ITree
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System.Collections.Generic;

namespace Antlr.Runtime.Tree
{
  public interface ITree
  {
    ITree GetChild(int i);

    int ChildCount { get; }

    ITree Parent { get; set; }

    bool HasAncestor(int ttype);

    ITree GetAncestor(int ttype);

    IList<ITree> GetAncestors();

    int ChildIndex { get; set; }

    void FreshenParentAndChildIndexes();

    void AddChild(ITree t);

    void SetChild(int i, ITree t);

    object DeleteChild(int i);

    void ReplaceChildren(int startChildIndex, int stopChildIndex, object t);

    bool IsNil { get; }

    int TokenStartIndex { get; set; }

    int TokenStopIndex { get; set; }

    ITree DupNode();

    int Type { get; }

    string Text { get; }

    int Line { get; }

    int CharPositionInLine { get; }

    string ToStringTree();

    string ToString();
  }
}
