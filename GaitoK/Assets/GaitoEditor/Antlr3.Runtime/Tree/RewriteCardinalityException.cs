// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.RewriteCardinalityException
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Runtime.Serialization;

namespace Antlr.Runtime.Tree
{
  [Serializable]
  public class RewriteCardinalityException : Exception
  {
    private readonly string _elementDescription;

    public RewriteCardinalityException()
    {
    }

    public RewriteCardinalityException(string elementDescription)
      : this(elementDescription, elementDescription)
    {
      this._elementDescription = elementDescription;
    }

    public RewriteCardinalityException(string elementDescription, Exception innerException)
      : this(elementDescription, elementDescription, innerException)
    {
    }

    public RewriteCardinalityException(string message, string elementDescription)
      : base(message)
    {
      this._elementDescription = elementDescription;
    }

    public RewriteCardinalityException(
      string message,
      string elementDescription,
      Exception innerException)
      : base(message, innerException)
    {
      this._elementDescription = elementDescription;
    }

    protected RewriteCardinalityException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      this._elementDescription = info.GetString("ElementDescription");
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      base.GetObjectData(info, context);
      info.AddValue("ElementDescription", (object) this._elementDescription);
    }
  }
}
