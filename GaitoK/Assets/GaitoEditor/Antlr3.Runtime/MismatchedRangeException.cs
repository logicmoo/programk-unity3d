// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.MismatchedRangeException
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
  [Serializable]
  public class MismatchedRangeException : RecognitionException
  {
    private readonly int _a;
    private readonly int _b;

    public MismatchedRangeException()
    {
    }

    public MismatchedRangeException(string message)
      : base(message)
    {
    }

    public MismatchedRangeException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    public MismatchedRangeException(int a, int b, IIntStream input)
      : base(input)
    {
      this._a = a;
      this._b = b;
    }

    public MismatchedRangeException(string message, int a, int b, IIntStream input)
      : base(message, input)
    {
      this._a = a;
      this._b = b;
    }

    public MismatchedRangeException(
      string message,
      int a,
      int b,
      IIntStream input,
      Exception innerException)
      : base(message, input, innerException)
    {
      this._a = a;
      this._b = b;
    }

    protected MismatchedRangeException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      this._a = info.GetInt32(nameof (A));
      this._b = info.GetInt32(nameof (B));
    }

    public int A
    {
      get
      {
        return this._a;
      }
    }

    public int B
    {
      get
      {
        return this._b;
      }
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      base.GetObjectData(info, context);
      info.AddValue("A", this._a);
      info.AddValue("B", this._b);
    }

    public override string ToString()
    {
      return "MismatchedRangeException(" + (object) this.UnexpectedType + " not in [" + (object) this.A + "," + (object) this.B + "])";
    }
  }
}
