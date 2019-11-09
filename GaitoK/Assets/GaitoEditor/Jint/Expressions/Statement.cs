// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.Statement
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Debugger;
using System;

namespace Jint.Expressions
{
  [Serializable]
  public abstract class Statement
  {
    protected SourceCodeDescriptor source;

    public string Label { get; set; }

    public abstract void Accept(IStatementVisitor visitor);

    public SourceCodeDescriptor Source
    {
      get
      {
        return this.source;
      }
      set
      {
        this.source = value;
      }
    }

    public Statement()
    {
      this.Label = string.Empty;
    }
  }
}
