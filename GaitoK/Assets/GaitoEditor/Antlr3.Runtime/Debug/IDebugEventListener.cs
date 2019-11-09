// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Debug.IDebugEventListener
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

namespace Antlr.Runtime.Debug
{
  public interface IDebugEventListener
  {
    void Initialize();

    void EnterRule(string grammarFileName, string ruleName);

    void EnterAlt(int alt);

    void ExitRule(string grammarFileName, string ruleName);

    void EnterSubRule(int decisionNumber);

    void ExitSubRule(int decisionNumber);

    void EnterDecision(int decisionNumber, bool couldBacktrack);

    void ExitDecision(int decisionNumber);

    void ConsumeToken(IToken t);

    void ConsumeHiddenToken(IToken t);

    void LT(int i, IToken t);

    void Mark(int marker);

    void Rewind(int marker);

    void Rewind();

    void BeginBacktrack(int level);

    void EndBacktrack(int level, bool successful);

    void Location(int line, int pos);

    void RecognitionException(RecognitionException e);

    void BeginResync();

    void EndResync();

    void SemanticPredicate(bool result, string predicate);

    void Commence();

    void Terminate();

    void ConsumeNode(object t);

    void LT(int i, object t);

    void NilNode(object t);

    void ErrorNode(object t);

    void CreateNode(object t);

    void CreateNode(object node, IToken token);

    void BecomeRoot(object newRoot, object oldRoot);

    void AddChild(object root, object child);

    void SetTokenBoundaries(object t, int tokenStartIndex, int tokenStopIndex);
  }
}
