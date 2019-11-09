// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.NoViableAltException
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
  [Serializable]
  public class NoViableAltException : RecognitionException
  {
    private readonly string _grammarDecisionDescription;
    private readonly int _decisionNumber;
    private readonly int _stateNumber;

    public NoViableAltException()
    {
    }

    public NoViableAltException(string grammarDecisionDescription)
    {
      this._grammarDecisionDescription = grammarDecisionDescription;
    }

    public NoViableAltException(string message, string grammarDecisionDescription)
      : base(message)
    {
      this._grammarDecisionDescription = grammarDecisionDescription;
    }

    public NoViableAltException(
      string message,
      string grammarDecisionDescription,
      Exception innerException)
      : base(message, innerException)
    {
      this._grammarDecisionDescription = grammarDecisionDescription;
    }

    public NoViableAltException(
      string grammarDecisionDescription,
      int decisionNumber,
      int stateNumber,
      IIntStream input)
      : base(input)
    {
      this._grammarDecisionDescription = grammarDecisionDescription;
      this._decisionNumber = decisionNumber;
      this._stateNumber = stateNumber;
    }

    public NoViableAltException(
      string message,
      string grammarDecisionDescription,
      int decisionNumber,
      int stateNumber,
      IIntStream input)
      : base(message, input)
    {
      this._grammarDecisionDescription = grammarDecisionDescription;
      this._decisionNumber = decisionNumber;
      this._stateNumber = stateNumber;
    }

    public NoViableAltException(
      string message,
      string grammarDecisionDescription,
      int decisionNumber,
      int stateNumber,
      IIntStream input,
      Exception innerException)
      : base(message, input, innerException)
    {
      this._grammarDecisionDescription = grammarDecisionDescription;
      this._decisionNumber = decisionNumber;
      this._stateNumber = stateNumber;
    }

    protected NoViableAltException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      this._grammarDecisionDescription = info.GetString(nameof (GrammarDecisionDescription));
      this._decisionNumber = info.GetInt32(nameof (DecisionNumber));
      this._stateNumber = info.GetInt32(nameof (StateNumber));
    }

    public int DecisionNumber
    {
      get
      {
        return this._decisionNumber;
      }
    }

    public string GrammarDecisionDescription
    {
      get
      {
        return this._grammarDecisionDescription;
      }
    }

    public int StateNumber
    {
      get
      {
        return this._stateNumber;
      }
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      base.GetObjectData(info, context);
      info.AddValue("GrammarDecisionDescription", (object) this._grammarDecisionDescription);
      info.AddValue("DecisionNumber", this._decisionNumber);
      info.AddValue("StateNumber", this._stateNumber);
    }

    public override string ToString()
    {
      if (this.Input is ICharStream)
        return "NoViableAltException('" + (object) (char) this.UnexpectedType + "'@[" + this.GrammarDecisionDescription + "])";
      return "NoViableAltException(" + (object) this.UnexpectedType + "@[" + this.GrammarDecisionDescription + "])";
    }
  }
}
