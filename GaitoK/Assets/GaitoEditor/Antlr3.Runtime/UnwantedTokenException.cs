// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.UnwantedTokenException
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
  [Serializable]
  public class UnwantedTokenException : MismatchedTokenException
  {
    public UnwantedTokenException()
    {
    }

    public UnwantedTokenException(string message)
      : base(message)
    {
    }

    public UnwantedTokenException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    public UnwantedTokenException(int expecting, IIntStream input)
      : base(expecting, input)
    {
    }

    public UnwantedTokenException(int expecting, IIntStream input, IList<string> tokenNames)
      : base(expecting, input, tokenNames)
    {
    }

    public UnwantedTokenException(
      string message,
      int expecting,
      IIntStream input,
      IList<string> tokenNames)
      : base(message, expecting, input, tokenNames)
    {
    }

    public UnwantedTokenException(
      string message,
      int expecting,
      IIntStream input,
      IList<string> tokenNames,
      Exception innerException)
      : base(message, expecting, input, tokenNames, innerException)
    {
    }

    protected UnwantedTokenException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public virtual IToken UnexpectedToken
    {
      get
      {
        return this.Token;
      }
    }

    public override string ToString()
    {
      string str = ", expected " + (this.TokenNames == null || this.Expecting < 0 || this.Expecting >= this.TokenNames.Count ? this.Expecting.ToString() : this.TokenNames[this.Expecting]);
      if (this.Expecting == 0)
        str = "";
      if (this.Token == null)
        return "UnwantedTokenException(found=" + str + ")";
      return "UnwantedTokenException(found=" + this.Token.Text + str + ")";
    }
  }
}
