// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.MismatchedTokenException
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
  [Serializable]
  public class MismatchedTokenException : RecognitionException
  {
    private readonly int _expecting;
    private readonly ReadOnlyCollection<string> _tokenNames;

    public MismatchedTokenException()
    {
    }

    public MismatchedTokenException(string message)
      : base(message)
    {
    }

    public MismatchedTokenException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    public MismatchedTokenException(int expecting, IIntStream input)
      : this(expecting, input, (IList<string>) null)
    {
    }

    public MismatchedTokenException(int expecting, IIntStream input, IList<string> tokenNames)
      : base(input)
    {
      this._expecting = expecting;
      if (tokenNames == null)
        return;
      this._tokenNames = tokenNames.ToList<string>().AsReadOnly();
    }

    public MismatchedTokenException(
      string message,
      int expecting,
      IIntStream input,
      IList<string> tokenNames)
      : base(message, input)
    {
      this._expecting = expecting;
      if (tokenNames == null)
        return;
      this._tokenNames = tokenNames.ToList<string>().AsReadOnly();
    }

    public MismatchedTokenException(
      string message,
      int expecting,
      IIntStream input,
      IList<string> tokenNames,
      Exception innerException)
      : base(message, input, innerException)
    {
      this._expecting = expecting;
      if (tokenNames == null)
        return;
      this._tokenNames = tokenNames.ToList<string>().AsReadOnly();
    }

    protected MismatchedTokenException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      this._expecting = info.GetInt32(nameof (Expecting));
      this._tokenNames = new ReadOnlyCollection<string>((IList<string>) (string[]) info.GetValue(nameof (TokenNames), typeof (string[])));
    }

    public int Expecting
    {
      get
      {
        return this._expecting;
      }
    }

    public ReadOnlyCollection<string> TokenNames
    {
      get
      {
        return this._tokenNames;
      }
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      base.GetObjectData(info, context);
      info.AddValue("Expecting", this._expecting);
      info.AddValue("TokenNames", this._tokenNames != null ? (object) this._tokenNames.ToArray<string>() : (object) (string[]) null);
    }

    public override string ToString()
    {
      int unexpectedType = this.UnexpectedType;
      return "MismatchedTokenException(" + (this.TokenNames == null || unexpectedType < 0 || unexpectedType >= this.TokenNames.Count ? unexpectedType.ToString() : this.TokenNames[unexpectedType]) + "!=" + (this.TokenNames == null || this.Expecting < 0 || this.Expecting >= this.TokenNames.Count ? this.Expecting.ToString() : this.TokenNames[this.Expecting]) + ")";
    }
  }
}
