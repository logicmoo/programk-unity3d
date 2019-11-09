// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.RecognizerSharedState
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections.Generic;

namespace Antlr.Runtime
{
  public class RecognizerSharedState
  {
    public BitSet[] following;
    [CLSCompliant(false)]
    public int _fsp;
    public bool errorRecovery;
    public int lastErrorIndex;
    public bool failed;
    public int syntaxErrors;
    public int backtracking;
    public IDictionary<int, int>[] ruleMemo;
    public IToken token;
    public int tokenStartCharIndex;
    public int tokenStartLine;
    public int tokenStartCharPositionInLine;
    public int channel;
    public int type;
    public string text;

    public RecognizerSharedState()
    {
      this.following = new BitSet[100];
      this._fsp = -1;
      this.lastErrorIndex = -1;
      this.tokenStartCharIndex = -1;
    }

    public RecognizerSharedState(RecognizerSharedState state)
    {
      if (state == null)
        throw new ArgumentNullException(nameof (state));
      this.following = (BitSet[]) state.following.Clone();
      this._fsp = state._fsp;
      this.errorRecovery = state.errorRecovery;
      this.lastErrorIndex = state.lastErrorIndex;
      this.failed = state.failed;
      this.syntaxErrors = state.syntaxErrors;
      this.backtracking = state.backtracking;
      if (state.ruleMemo != null)
        this.ruleMemo = (IDictionary<int, int>[]) state.ruleMemo.Clone();
      this.token = state.token;
      this.tokenStartCharIndex = state.tokenStartCharIndex;
      this.tokenStartCharPositionInLine = state.tokenStartCharPositionInLine;
      this.channel = state.channel;
      this.type = state.type;
      this.text = state.text;
    }
  }
}
