// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsMathConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using System;

namespace Jint.Native
{
  [Serializable]
  public class JsMathConstructor : JsObject
  {
    public const string MathType = "object";

    public IGlobal Global { get; set; }

    public JsMathConstructor(IGlobal global)
      : base(global.ObjectClass.PrototypeProperty)
    {
      this.Global = global;
      Random random = new Random();
      this["abs"] = (JsInstance) global.FunctionClass.New((Delegate) (d => this.Global.NumberClass.New(Math.Abs(d))));
      this["acos"] = (JsInstance) global.FunctionClass.New((Delegate) (d => this.Global.NumberClass.New(Math.Acos(d))));
      this["asin"] = (JsInstance) global.FunctionClass.New((Delegate) (d => this.Global.NumberClass.New(Math.Asin(d))));
      this["atan"] = (JsInstance) global.FunctionClass.New((Delegate) (d => this.Global.NumberClass.New(Math.Atan(d))));
      this["atan2"] = (JsInstance) global.FunctionClass.New((Delegate) ((y, x) => this.Global.NumberClass.New(Math.Atan2(y, x))));
      this["ceil"] = (JsInstance) global.FunctionClass.New((Delegate) (d => this.Global.NumberClass.New(Math.Ceiling(d))));
      this["cos"] = (JsInstance) global.FunctionClass.New((Delegate) (d => this.Global.NumberClass.New(Math.Cos(d))));
      this["exp"] = (JsInstance) global.FunctionClass.New((Delegate) (d => this.Global.NumberClass.New(Math.Exp(d))));
      this["floor"] = (JsInstance) global.FunctionClass.New((Delegate) (d => this.Global.NumberClass.New(Math.Floor(d))));
      this["log"] = (JsInstance) global.FunctionClass.New((Delegate) (d => this.Global.NumberClass.New(Math.Log(d))));
      this["max"] = (JsInstance) global.FunctionClass.New((Delegate) ((a, b) => this.Global.NumberClass.New(Math.Max(a, b))));
      this["min"] = (JsInstance) global.FunctionClass.New((Delegate) ((a, b) => this.Global.NumberClass.New(Math.Min(a, b))));
      this["pow"] = (JsInstance) global.FunctionClass.New((Delegate) ((a, b) => this.Global.NumberClass.New(Math.Pow(a, b))));
      this["random"] = (JsInstance) global.FunctionClass.New((Delegate) new Func<double>(random.NextDouble));
      this["round"] = (JsInstance) global.FunctionClass.New((Delegate) (d => this.Global.NumberClass.New(Math.Round(d))));
      this["sin"] = (JsInstance) global.FunctionClass.New((Delegate) (d => this.Global.NumberClass.New(Math.Sin(d))));
      this["sqrt"] = (JsInstance) global.FunctionClass.New((Delegate) (d => this.Global.NumberClass.New(Math.Sqrt(d))));
      this["tan"] = (JsInstance) global.FunctionClass.New((Delegate) (d => this.Global.NumberClass.New(Math.Tan(d))));
      this["E"] = (JsInstance) global.NumberClass.New(Math.E);
      this["LN2"] = (JsInstance) global.NumberClass.New(Math.Log(2.0));
      this["LN10"] = (JsInstance) global.NumberClass.New(Math.Log(10.0));
      this["LOG2E"] = (JsInstance) global.NumberClass.New(Math.Log(Math.E, 2.0));
      this["PI"] = (JsInstance) global.NumberClass.New(Math.PI);
      this["SQRT1_2"] = (JsInstance) global.NumberClass.New(Math.Sqrt(0.5));
      this["SQRT2"] = (JsInstance) global.NumberClass.New(Math.Sqrt(2.0));
    }

    public override string Class
    {
      get
      {
        return "object";
      }
    }
  }
}
