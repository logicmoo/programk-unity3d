// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsFunction
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Expressions;
using System;
using System.Collections.Generic;

namespace Jint.Native
{
  [Serializable]
  public class JsFunction : JsObject
  {
    public static string CALL = "call";
    public static string APPLY = "apply";
    public static string CONSTRUCTOR = "constructor";
    public static string PROTOTYPE = "prototype";

    public string Name { get; set; }

    public Statement Statement { get; set; }

    public List<string> Arguments { get; set; }

    public JsScope Scope { get; set; }

    public JsFunction(IGlobal global, Statement statement)
      : this(global.FunctionClass.PrototypeProperty)
    {
      this.Statement = statement;
    }

    public JsFunction(IGlobal global)
      : this(global.FunctionClass.PrototypeProperty)
    {
    }

    public JsFunction(JsObject prototype)
      : base(prototype)
    {
      this.Arguments = new List<string>();
      this.Statement = (Statement) new EmptyStatement();
      this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) JsNull.Instance, PropertyAttributes.DontEnum);
    }

    public override int Length
    {
      get
      {
        return this.Arguments.Count;
      }
      set
      {
      }
    }

    public JsObject PrototypeProperty
    {
      get
      {
        return this[JsFunction.PROTOTYPE] as JsObject;
      }
      set
      {
        this[JsFunction.PROTOTYPE] = (JsInstance) value;
      }
    }

    public virtual bool HasInstance(JsObject inst)
    {
      if (inst != null && inst != JsNull.Instance && inst != JsNull.Instance)
        return this.PrototypeProperty.IsPrototypeOf((JsDictionaryObject) inst);
      return false;
    }

    public virtual JsObject Construct(
      JsInstance[] parameters,
      Type[] genericArgs,
      IJintVisitor visitor)
    {
      JsObject jsObject = visitor.Global.ObjectClass.New(this.PrototypeProperty);
      visitor.ExecuteFunction(this, (JsDictionaryObject) jsObject, parameters);
      return visitor.Result as JsObject ?? jsObject;
    }

    public override bool IsClr
    {
      get
      {
        return false;
      }
    }

    public override object Value
    {
      get
      {
        return (object) null;
      }
      set
      {
      }
    }

    public virtual JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      this.Statement.Accept((IStatementVisitor) visitor);
      return (JsInstance) that;
    }

    public virtual JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters,
      Type[] genericArguments)
    {
      throw new JintException("This method can't be called as a generic");
    }

    public override string Class
    {
      get
      {
        return "Function";
      }
    }

    public override string ToSource()
    {
      return string.Format("function {0} ( {1} ) {{ {2} }}", (object) this.Name, (object) string.Join(", ", this.Arguments.ToArray()), (object) this.GetBody());
    }

    public virtual string GetBody()
    {
      return "/* js code */";
    }

    public override string ToString()
    {
      return this.ToSource();
    }

    public override bool ToBoolean()
    {
      return true;
    }

    public override double ToNumber()
    {
      return 1.0;
    }
  }
}
