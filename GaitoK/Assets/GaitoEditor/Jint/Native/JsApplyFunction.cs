// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsApplyFunction
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Expressions;
using System;

namespace Jint.Native
{
  [Serializable]
  public class JsApplyFunction : JsFunction
  {
    public JsApplyFunction(JsFunctionConstructor constructor)
      : base(constructor.PrototypeProperty)
    {
      this.DefineOwnProperty("length", (JsInstance) constructor.Global.NumberClass.New(2.0), PropertyAttributes.ReadOnly);
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      JsFunction function = that as JsFunction;
      if (function == null)
        throw new ArgumentException("the target of call() must be a function");
      JsDictionaryObject _this = parameters.Length < 1 || parameters[0] == JsUndefined.Instance || parameters[0] == JsNull.Instance ? visitor.Global as JsDictionaryObject : parameters[0] as JsDictionaryObject;
      JsInstance[] _parameters;
      if (parameters.Length >= 2 && parameters[1] != JsNull.Instance)
      {
        JsObject parameter = parameters[1] as JsObject;
        if (parameter == null)
          throw new JsException((JsInstance) visitor.Global.TypeErrorClass.New("second argument must be an array"));
        _parameters = new JsInstance[parameter.Length];
        for (int index = 0; index < parameter.Length; ++index)
          _parameters[index] = parameter[index.ToString()];
      }
      else
        _parameters = JsInstance.EMPTY;
      visitor.ExecuteFunction(function, _this, _parameters);
      return visitor.Result;
    }
  }
}
