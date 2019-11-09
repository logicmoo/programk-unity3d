// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.FailedPredicateException
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
  [Serializable]
  public class FailedPredicateException : RecognitionException
  {
    private readonly string _ruleName;
    private readonly string _predicateText;

    public FailedPredicateException()
    {
    }

    public FailedPredicateException(string message)
      : base(message)
    {
    }

    public FailedPredicateException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    public FailedPredicateException(IIntStream input, string ruleName, string predicateText)
      : base(input)
    {
      this._ruleName = ruleName;
      this._predicateText = predicateText;
    }

    public FailedPredicateException(
      string message,
      IIntStream input,
      string ruleName,
      string predicateText)
      : base(message, input)
    {
      this._ruleName = ruleName;
      this._predicateText = predicateText;
    }

    public FailedPredicateException(
      string message,
      IIntStream input,
      string ruleName,
      string predicateText,
      Exception innerException)
      : base(message, input, innerException)
    {
      this._ruleName = ruleName;
      this._predicateText = predicateText;
    }

    protected FailedPredicateException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      this._ruleName = info.GetString(nameof (RuleName));
      this._predicateText = info.GetString(nameof (PredicateText));
    }

    public string RuleName
    {
      get
      {
        return this._ruleName;
      }
    }

    public string PredicateText
    {
      get
      {
        return this._predicateText;
      }
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      base.GetObjectData(info, context);
      info.AddValue("RuleName", (object) this._ruleName);
      info.AddValue("PredicateText", (object) this._predicateText);
    }

    public override string ToString()
    {
      return "FailedPredicateException(" + this.RuleName + ",{" + this.PredicateText + "}?)";
    }
  }
}
