// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.EarlyExitException
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
  [Serializable]
  public class EarlyExitException : RecognitionException
  {
    private readonly int _decisionNumber;

    public EarlyExitException()
    {
    }

    public EarlyExitException(string message)
      : base(message)
    {
    }

    public EarlyExitException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    public EarlyExitException(int decisionNumber, IIntStream input)
      : base(input)
    {
      this._decisionNumber = decisionNumber;
    }

    public EarlyExitException(string message, int decisionNumber, IIntStream input)
      : base(message, input)
    {
      this._decisionNumber = decisionNumber;
    }

    public EarlyExitException(
      string message,
      int decisionNumber,
      IIntStream input,
      Exception innerException)
      : base(message, input, innerException)
    {
      this._decisionNumber = decisionNumber;
    }

    protected EarlyExitException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      this._decisionNumber = info.GetInt32(nameof (DecisionNumber));
    }

    public int DecisionNumber
    {
      get
      {
        return this._decisionNumber;
      }
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      base.GetObjectData(info, context);
      info.AddValue("DecisionNumber", this.DecisionNumber);
    }
  }
}
