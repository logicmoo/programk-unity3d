// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.MismatchedSetException
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
  [Serializable]
  public class MismatchedSetException : RecognitionException
  {
    private readonly BitSet _expecting;

    public MismatchedSetException()
    {
    }

    public MismatchedSetException(string message)
      : base(message)
    {
    }

    public MismatchedSetException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    public MismatchedSetException(BitSet expecting, IIntStream input)
      : base(input)
    {
      this._expecting = expecting;
    }

    public MismatchedSetException(string message, BitSet expecting, IIntStream input)
      : base(message, input)
    {
      this._expecting = expecting;
    }

    public MismatchedSetException(
      string message,
      BitSet expecting,
      IIntStream input,
      Exception innerException)
      : base(message, input, innerException)
    {
      this._expecting = expecting;
    }

    protected MismatchedSetException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      this._expecting = (BitSet) info.GetValue(nameof (Expecting), typeof (BitSet));
    }

    public BitSet Expecting
    {
      get
      {
        return this._expecting;
      }
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      base.GetObjectData(info, context);
      info.AddValue("Expecting", (object) this._expecting);
    }

    public override string ToString()
    {
      return "MismatchedSetException(" + (object) this.UnexpectedType + "!=" + (object) this.Expecting + ")";
    }
  }
}
