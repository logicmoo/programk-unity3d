﻿// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.CaseClause
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;

namespace Jint.Expressions
{
  [Serializable]
  public class CaseClause
  {
    public Expression Expression { get; set; }

    public BlockStatement Statements { get; private set; }

    public CaseClause()
    {
      this.Statements = new BlockStatement();
    }
  }
}
