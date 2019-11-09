// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsComparer
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Expressions;
using System;
using System.Collections.Generic;

namespace Jint.Native
{
  [Serializable]
  public class JsComparer : IComparer<JsInstance>
  {
    public IJintVisitor Visitor { get; set; }

    public JsFunction Function { get; set; }

    public JsComparer(IJintVisitor visitor, JsFunction function)
    {
      this.Visitor = visitor;
      this.Function = function;
    }

    public int Compare(JsInstance x, JsInstance y)
    {
      this.Visitor.Result = (JsInstance) this.Function;
      new MethodCall(new List<Expression>()
      {
        (Expression) new ValueExpression((object) x, TypeCode.Object),
        (Expression) new ValueExpression((object) y, TypeCode.Object)
      }).Accept((IStatementVisitor) this.Visitor);
      return Math.Sign(this.Visitor.Result.ToNumber());
    }
  }
}
