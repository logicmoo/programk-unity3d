// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.MismatchedTreeNodeException
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using Antlr.Runtime.Tree;
using System;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
  [Serializable]
  public class MismatchedTreeNodeException : RecognitionException
  {
    private readonly int _expecting;

    public MismatchedTreeNodeException()
    {
    }

    public MismatchedTreeNodeException(string message)
      : base(message)
    {
    }

    public MismatchedTreeNodeException(string message, Exception innerException)
      : base(message, innerException)
    {
    }

    public MismatchedTreeNodeException(int expecting, ITreeNodeStream input)
      : base((IIntStream) input)
    {
      this._expecting = expecting;
    }

    public MismatchedTreeNodeException(string message, int expecting, ITreeNodeStream input)
      : base(message, (IIntStream) input)
    {
      this._expecting = expecting;
    }

    public MismatchedTreeNodeException(
      string message,
      int expecting,
      ITreeNodeStream input,
      Exception innerException)
      : base(message, (IIntStream) input, innerException)
    {
      this._expecting = expecting;
    }

    protected MismatchedTreeNodeException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      this._expecting = info.GetInt32(nameof (Expecting));
    }

    public int Expecting
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
      info.AddValue("Expecting", this._expecting);
    }

    public override string ToString()
    {
      return "MismatchedTreeNodeException(" + (object) this.UnexpectedType + "!=" + (object) this.Expecting + ")";
    }
  }
}
