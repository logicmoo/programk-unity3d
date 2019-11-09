// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsObjectConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;

namespace Jint.Native
{
  [Serializable]
  public class JsObjectConstructor : JsConstructor
  {
    public JsObjectConstructor(IGlobal global, JsObject prototype, JsObject rootPrototype)
      : base(global)
    {
      this.Name = "Object";
      this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) rootPrototype, PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
    }

    public override void InitPrototype(IGlobal global)
    {
      JsObject prototypeProperty = this.PrototypeProperty;
      prototypeProperty.DefineOwnProperty("constructor", (JsInstance) this, PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toLocaleString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("valueOf", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ValueOfImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("hasOwnProperty", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.HasOwnPropertyImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("isPrototypeOf", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.IsPrototypeOfImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("propertyIsEnumerable", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.PropertyIsEnumerableImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getPrototypeOf", (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.GetPrototypeOfImpl), global.FunctionClass.PrototypeProperty), PropertyAttributes.DontEnum);
      if (!global.HasOption(Options.Ecmascript5))
        return;
      prototypeProperty.DefineOwnProperty("defineProperty", (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.DefineProperty), global.FunctionClass.PrototypeProperty), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("__lookupGetter__", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(((JsDictionaryObject) this).GetGetFunction)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("__lookupSetter__", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(((JsDictionaryObject) this).GetSetFunction)), PropertyAttributes.DontEnum);
    }

    public JsObject New(JsFunction constructor)
    {
      JsObject jsObject1 = new JsObject(this.PrototypeProperty);
      JsObject jsObject2 = jsObject1;
      ValueDescriptor valueDescriptor = new ValueDescriptor((JsDictionaryObject) jsObject1, JsFunction.CONSTRUCTOR, (JsInstance) constructor);
      valueDescriptor.Enumerable = false;
      jsObject2.DefineOwnProperty((Descriptor) valueDescriptor);
      return jsObject1;
    }

    public JsObject New(JsFunction constructor, JsObject Prototype)
    {
      JsObject jsObject1 = new JsObject(Prototype);
      JsObject jsObject2 = jsObject1;
      ValueDescriptor valueDescriptor = new ValueDescriptor((JsDictionaryObject) jsObject1, JsFunction.CONSTRUCTOR, (JsInstance) constructor);
      valueDescriptor.Enumerable = false;
      jsObject2.DefineOwnProperty((Descriptor) valueDescriptor);
      return jsObject1;
    }

    public JsObject New(object value)
    {
      return new JsObject(value, this.PrototypeProperty);
    }

    public JsObject New(object value, JsObject prototype)
    {
      return new JsObject(value, prototype);
    }

    public JsObject New()
    {
      return this.New((object) null);
    }

    public JsObject New(JsObject prototype)
    {
      return new JsObject(prototype);
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      if ((uint) parameters.Length <= 0U)
        return (JsInstance) this.New((JsFunction) this);
      string str = parameters[0].Class;
      if (str == "String")
        return (JsInstance) this.Global.StringClass.New(parameters[0].ToString());
      if (str == "Number")
        return (JsInstance) this.Global.NumberClass.New(parameters[0].ToNumber());
      if (str == "Boolean")
        return (JsInstance) this.Global.BooleanClass.New(parameters[0].ToBoolean());
      return parameters[0];
    }

    public JsInstance ToStringImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      return (JsInstance) this.Global.StringClass.New("[object " + target.Class + "]");
    }

    public JsInstance ValueOfImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      return (JsInstance) target;
    }

    public JsInstance HasOwnPropertyImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      return (JsInstance) this.Global.BooleanClass.New(target.HasOwnProperty(parameters[0]));
    }

    public JsInstance IsPrototypeOfImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (target.Class != "Object")
        return (JsInstance) this.Global.BooleanClass.False;
      do
      {
        this.IsPrototypeOf(target);
        if (target == null)
          goto label_2;
      }
      while (target != this);
      goto label_4;
label_2:
      return (JsInstance) this.Global.BooleanClass.True;
label_4:
      return (JsInstance) this.Global.BooleanClass.True;
    }

    public JsInstance PropertyIsEnumerableImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (!this.HasOwnProperty(parameters[0]))
        return (JsInstance) this.Global.BooleanClass.False;
      return (JsInstance) this.Global.BooleanClass.New((target[parameters[0]].Attributes & PropertyAttributes.DontEnum) == PropertyAttributes.None);
    }

    public JsInstance GetPrototypeOfImpl(JsInstance[] parameters)
    {
      if (parameters[0].Class != "Object")
        throw new JsException((JsInstance) this.Global.TypeErrorClass.New());
      return ((parameters[0] as JsObject ?? (JsObject) JsUndefined.Instance)[JsFunction.CONSTRUCTOR] as JsObject ?? (JsObject) JsUndefined.Instance)[JsFunction.PROTOTYPE];
    }

    public JsInstance DefineProperty(JsInstance[] parameters)
    {
      JsInstance parameter = parameters[0];
      if (!(parameter is JsDictionaryObject))
        throw new JsException((JsInstance) this.Global.TypeErrorClass.New());
      string name = parameters[1].ToString();
      Descriptor propertyDesciptor = Descriptor.ToPropertyDesciptor(this.Global, (JsDictionaryObject) parameter, name, parameters[2]);
      ((JsDictionaryObject) parameter).DefineOwnProperty(propertyDesciptor);
      return parameter;
    }
  }
}
