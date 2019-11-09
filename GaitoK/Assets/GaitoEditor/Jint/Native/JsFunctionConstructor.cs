// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsFunctionConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;
using System.Collections.Generic;

namespace Jint.Native
{
  [Serializable]
  public class JsFunctionConstructor : JsConstructor
  {
    public JsFunctionConstructor(IGlobal global, JsObject prototype)
      : base(global, prototype)
    {
      this.Name = "Function";
      this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) prototype, PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
    }

    public override void InitPrototype(IGlobal global)
    {
      JsObject prototypeProperty = this.PrototypeProperty;
      prototypeProperty.DefineOwnProperty("constructor", (JsInstance) this, PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty(JsFunction.CALL.ToString(), (JsInstance) new JsCallFunction(this), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty(JsFunction.APPLY.ToString(), (JsInstance) new JsApplyFunction(this), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toString", (JsInstance) this.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToString2)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toLocaleString", (JsInstance) this.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToString2)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsObject>(global, (JsDictionaryObject) prototypeProperty, "length", new Func<JsObject, JsInstance>(this.GetLengthImpl), new Func<JsObject, JsInstance[], JsInstance>(this.SetLengthImpl)));
    }

    public JsInstance GetLengthImpl(JsDictionaryObject target)
    {
      return (JsInstance) this.Global.NumberClass.New((double) target.Length);
    }

    public JsInstance SetLengthImpl(JsInstance target, JsInstance[] parameters)
    {
      int number = (int) parameters[0].ToNumber();
      if (number < 0 || double.IsNaN((double) number) || double.IsInfinity((double) number))
        throw new JsException((JsInstance) this.Global.RangeErrorClass.New("invalid length"));
      ((JsDictionaryObject) target).Length = number;
      return parameters[0];
    }

    public JsInstance GetLength(JsDictionaryObject target)
    {
      return (JsInstance) this.Global.NumberClass.New((double) target.Length);
    }

    public JsFunction New()
    {
      JsFunction constructor = new JsFunction(this.PrototypeProperty);
      constructor.PrototypeProperty = this.Global.ObjectClass.New(constructor);
      return constructor;
    }

    public JsFunction New<T>(Func<T, JsInstance> impl) where T : JsInstance
    {
      JsFunction constructor = (JsFunction) new ClrImplDefinition<T>(impl, this.PrototypeProperty);
      constructor.PrototypeProperty = this.Global.ObjectClass.New(constructor);
      return constructor;
    }

    public JsFunction New<T>(Func<T, JsInstance> impl, int length) where T : JsInstance
    {
      JsFunction constructor = (JsFunction) new ClrImplDefinition<T>(impl, length, this.PrototypeProperty);
      constructor.PrototypeProperty = this.Global.ObjectClass.New(constructor);
      return constructor;
    }

    public JsFunction New<T>(Func<T, JsInstance[], JsInstance> impl) where T : JsInstance
    {
      JsFunction constructor = (JsFunction) new ClrImplDefinition<T>(impl, this.PrototypeProperty);
      constructor.PrototypeProperty = this.Global.ObjectClass.New(constructor);
      return constructor;
    }

    public JsFunction New<T>(Func<T, JsInstance[], JsInstance> impl, int length) where T : JsInstance
    {
      JsFunction constructor = (JsFunction) new ClrImplDefinition<T>(impl, length, this.PrototypeProperty);
      constructor.PrototypeProperty = this.Global.ObjectClass.New(constructor);
      return constructor;
    }

    public JsFunction New(Delegate d)
    {
      JsFunction constructor = (JsFunction) new ClrFunction(d, this.PrototypeProperty);
      constructor.PrototypeProperty = this.Global.ObjectClass.New(constructor);
      return constructor;
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      return visitor.Return((JsInstance) this.Construct(parameters, (Type[]) null, visitor));
    }

    public override JsObject Construct(
      JsInstance[] parameters,
      Type[] genericArgs,
      IJintVisitor visitor)
    {
      JsFunction jsFunction = this.New();
      jsFunction.Arguments = new List<string>();
      for (int index = 0; index < parameters.Length - 1; ++index)
      {
        string str1 = parameters[index].ToString();
        char[] chArray = new char[1]{ ',' };
        foreach (string str2 in str1.Split(chArray))
          jsFunction.Arguments.Add(str2.Trim());
      }
      if (parameters.Length >= 1)
      {
        Program program = JintEngine.Compile(parameters[parameters.Length - 1].Value.ToString(), visitor.DebugMode);
        jsFunction.Statement = (Statement) new BlockStatement()
        {
          Statements = program.Statements
        };
      }
      return (JsObject) jsFunction;
    }

    public JsInstance ToString2(JsDictionaryObject target, JsInstance[] parameters)
    {
      return (JsInstance) this.Global.StringClass.New(target.ToSource());
    }
  }
}
