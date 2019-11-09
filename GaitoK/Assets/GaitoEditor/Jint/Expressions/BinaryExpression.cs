// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.BinaryExpression
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;
using System.Diagnostics;

namespace Jint.Expressions
{
  [Serializable]
  public class BinaryExpression : Expression
  {
    private Expression leftExpression;
    private Expression rightExpression;
    private BinaryExpressionType type;

    public BinaryExpression(
      BinaryExpressionType type,
      Expression leftExpression,
      Expression rightExpression)
    {
      this.type = type;
      this.leftExpression = leftExpression;
      this.rightExpression = rightExpression;
    }

    public Expression LeftExpression
    {
      get
      {
        return this.leftExpression;
      }
      set
      {
        this.leftExpression = value;
      }
    }

    public Expression RightExpression
    {
      get
      {
        return this.rightExpression;
      }
      set
      {
        this.rightExpression = value;
      }
    }

    public BinaryExpressionType Type
    {
      get
      {
        return this.type;
      }
      set
      {
        this.type = value;
      }
    }

    [DebuggerStepThrough]
    public override void Accept(IStatementVisitor visitor)
    {
      visitor.Visit(this);
    }

    public override string ToString()
    {
      return this.Type.ToString() + " (" + this.leftExpression.ToString() + ", " + this.rightExpression.ToString() + ")";
    }
  }
}
