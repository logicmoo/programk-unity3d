// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.JsonExpression
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Jint.Expressions
{
  [Serializable]
  public class JsonExpression : Expression
  {
    public JsonExpression()
    {
      this.Values = new Dictionary<string, Expression>();
    }

    public Dictionary<string, Expression> Values { get; set; }

    [DebuggerStepThrough]
    public override void Accept(IStatementVisitor visitor)
    {
      visitor.Visit(this);
    }

    internal void Push(PropertyDeclarationExpression propertyExpression)
    {
      if (propertyExpression.Name == null)
      {
        propertyExpression.Name = propertyExpression.Mode.ToString().ToLower();
        propertyExpression.Mode = PropertyExpressionType.Data;
      }
      if (this.Values.ContainsKey(propertyExpression.Name))
      {
        PropertyDeclarationExpression declarationExpression = this.Values[propertyExpression.Name] as PropertyDeclarationExpression;
        if (declarationExpression == null)
          throw new JintException("A property cannot be both an accessor and data");
        switch (propertyExpression.Mode)
        {
          case PropertyExpressionType.Data:
            if (propertyExpression.Mode != PropertyExpressionType.Data)
              throw new JintException("A property cannot be both an accessor and data");
            this.Values[propertyExpression.Name] = propertyExpression.Expression;
            break;
          case PropertyExpressionType.Get:
            declarationExpression.SetGet(propertyExpression);
            break;
          case PropertyExpressionType.Set:
            declarationExpression.SetSet(propertyExpression);
            break;
        }
      }
      else
      {
        this.Values.Add(propertyExpression.Name, (Expression) propertyExpression);
        switch (propertyExpression.Mode)
        {
          case PropertyExpressionType.Data:
            this.Values[propertyExpression.Name] = (Expression) propertyExpression;
            break;
          case PropertyExpressionType.Get:
            propertyExpression.SetGet(propertyExpression);
            break;
          case PropertyExpressionType.Set:
            propertyExpression.SetSet(propertyExpression);
            break;
        }
      }
    }
  }
}
