// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.MissingTokenException
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
  [Serializable]
  public class MissingTokenException : MismatchedTokenException
  {
    private readonly object _inserted;

    public MissingTokenException()
    {
    }

    public MissingTokenException(string message)
      : base(message)
    {
    }

    public MissingTokenException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    public MissingTokenException(int expecting, IIntStream input, object inserted)
      : this(expecting, input, inserted, (IList<string>) null)
    {
    }

    public MissingTokenException(
      int expecting,
      IIntStream input,
      object inserted,
      IList<string> tokenNames)
      : base(expecting, input, tokenNames)
    {
      this._inserted = inserted;
    }

    public MissingTokenException(
      string message,
      int expecting,
      IIntStream input,
      object inserted,
      IList<string> tokenNames)
      : base(message, expecting, input, tokenNames)
    {
      this._inserted = inserted;
    }

    public MissingTokenException(
      string message,
      int expecting,
      IIntStream input,
      object inserted,
      IList<string> tokenNames,
      Exception innerException)
      : base(message, expecting, input, tokenNames, innerException)
    {
      this._inserted = inserted;
    }

    protected MissingTokenException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public virtual int MissingType
    {
      get
      {
        return this.Expecting;
      }
    }

    public override string ToString()
    {
      if (this._inserted != null && this.Token != null)
        return "MissingTokenException(inserted " + this._inserted + " at " + this.Token.Text + ")";
      if (this.Token != null)
        return "MissingTokenException(at " + this.Token.Text + ")";
      return nameof (MissingTokenException);
    }
  }
}
