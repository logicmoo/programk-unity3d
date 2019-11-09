// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsErrorConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;

namespace Jint.Native
{
  [Serializable]
  public class JsErrorConstructor : JsConstructor
  {
    private string errorType;

    public JsErrorConstructor(IGlobal global, string errorType)
      : base(global)
    {
      this.errorType = errorType;
      this.Name = errorType;
      this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) global.ObjectClass.New((JsFunction) this), PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
    }

    public override void InitPrototype(IGlobal global)
    {
      JsObject prototypeProperty = this.PrototypeProperty;
      prototypeProperty.DefineOwnProperty("name", (JsInstance) global.StringClass.New(this.errorType), PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
      prototypeProperty.DefineOwnProperty("toString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toLocaleString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
    }

    public JsError New(string message)
    {
      JsError jsError = new JsError(this.Global);
      jsError[nameof (message)] = (JsInstance) this.Global.StringClass.New(message);
      return jsError;
    }

    public JsError New()
    {
      return this.New(string.Empty);
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      if (that == null || that as IGlobal == visitor.Global)
      {
        visitor.Return(parameters.Length != 0 ? (JsInstance) this.New(parameters[0].ToString()) : (JsInstance) this.New());
      }
      else
      {
        if ((uint) parameters.Length > 0U)
          that.Value = (object) parameters[0].ToString();
        else
          that.Value = (object) string.Empty;
        visitor.Return((JsInstance) that);
      }
      return (JsInstance) that;
    }

    public JsInstance ToStringImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      return (JsInstance) this.Global.StringClass.New(target["name"].ToString() + ": " + (object) target["message"]);
    }

    public override JsObject Construct(
      JsInstance[] parameters,
      Type[] genericArgs,
      IJintVisitor visitor)
    {
      return parameters == null || parameters.Length == 0 ? (JsObject) visitor.Global.ErrorClass.New() : (JsObject) visitor.Global.ErrorClass.New(parameters[0].ToString());
    }
  }
}
