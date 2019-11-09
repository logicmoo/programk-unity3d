// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.ITreeAdaptor
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

namespace Antlr.Runtime.Tree
{
  public interface ITreeAdaptor
  {
    object Create(IToken payload);

    object Create(int tokenType, IToken fromToken);

    object Create(int tokenType, IToken fromToken, string text);

    object Create(IToken fromToken, string text);

    object Create(int tokenType, string text);

    object DupNode(object treeNode);

    object DupNode(int type, object treeNode);

    object DupNode(object treeNode, string text);

    object DupNode(int type, object treeNode, string text);

    object DupTree(object tree);

    object Nil();

    object ErrorNode(ITokenStream input, IToken start, IToken stop, RecognitionException e);

    bool IsNil(object tree);

    void AddChild(object t, object child);

    object BecomeRoot(object newRoot, object oldRoot);

    object RulePostProcessing(object root);

    int GetUniqueID(object node);

    object BecomeRoot(IToken newRoot, object oldRoot);

    int GetType(object t);

    void SetType(object t, int type);

    string GetText(object t);

    void SetText(object t, string text);

    IToken GetToken(object t);

    void SetTokenBoundaries(object t, IToken startToken, IToken stopToken);

    int GetTokenStartIndex(object t);

    int GetTokenStopIndex(object t);

    object GetChild(object t, int i);

    void SetChild(object t, int i, object child);

    object DeleteChild(object t, int i);

    int GetChildCount(object t);

    object GetParent(object t);

    void SetParent(object t, object parent);

    int GetChildIndex(object t);

    void SetChildIndex(object t, int index);

    void ReplaceChildren(object parent, int startChildIndex, int stopChildIndex, object t);
  }
}
