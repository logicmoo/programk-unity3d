// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.MismatchedNotSetException
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
  [Serializable]
  public class MismatchedNotSetException : MismatchedSetException
  {
    public MismatchedNotSetException()
    {
    }

    public MismatchedNotSetException(string message)
      : base(message)
    {
    }

    public MismatchedNotSetException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    public MismatchedNotSetException(BitSet expecting, IIntStream input)
      : base(expecting, input)
    {
    }

    public MismatchedNotSetException(string message, BitSet expecting, IIntStream input)
      : base(message, expecting, input)
    {
    }

    public MismatchedNotSetException(
      string message,
      BitSet expecting,
      IIntStream input,
      Exception innerException)
      : base(message, expecting, input, innerException)
    {
    }

    protected MismatchedNotSetException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    public override string ToString()
    {
      return "MismatchedNotSetException(" + (object) this.UnexpectedType + "!=" + (object) this.Expecting + ")";
    }
  }
}
