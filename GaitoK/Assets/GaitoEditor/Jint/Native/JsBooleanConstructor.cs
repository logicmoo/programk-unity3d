// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsBooleanConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;

namespace Jint.Native
{
  [Serializable]
  public class JsBooleanConstructor : JsConstructor
  {
    public JsBoolean False { get; private set; }

    public JsBoolean True { get; private set; }

    public JsBooleanConstructor(IGlobal global)
      : base(global)
    {
      this.Name = "Boolean";
      this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) global.ObjectClass.New((JsFunction) this), PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
      this.True = this.New(true);
      this.False = this.New(false);
    }

    public override void InitPrototype(IGlobal global)
    {
      JsObject prototypeProperty = this.PrototypeProperty;
      prototypeProperty.DefineOwnProperty("toString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToString2)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toLocaleString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToString2)), PropertyAttributes.DontEnum);
    }

    public JsBoolean New()
    {
      return this.New(false);
    }

    public JsBoolean New(bool value)
    {
      return new JsBoolean(value, this.PrototypeProperty);
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      if (that == null || that as IGlobal == visitor.Global)
      {
        visitor.Return(parameters.Length != 0 ? (JsInstance) new JsBoolean(parameters[0].ToBoolean(), this.PrototypeProperty) : (JsInstance) new JsBoolean(this.PrototypeProperty));
      }
      else
      {
        if ((uint) parameters.Length > 0U)
          that.Value = (object) parameters[0].ToBoolean();
        else
          that.Value = (object) false;
        visitor.Return((JsInstance) that);
      }
      return (JsInstance) that;
    }

    public JsInstance ToString2(JsDictionaryObject target, JsInstance[] parameters)
    {
      return (JsInstance) this.Global.StringClass.New(target.ToString());
    }
  }
}
