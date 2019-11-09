// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsArguments
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using System;

namespace Jint.Native
{
  [Serializable]
  public class JsArguments : JsObject
  {
    public const string CALLEE = "callee";
    protected ValueDescriptor calleeDescriptor;
    private int length;
    private IGlobal global;

    protected JsFunction Callee
    {
      get
      {
        return this["callee"] as JsFunction;
      }
      set
      {
        this["callee"] = (JsInstance) value;
      }
    }

    public JsArguments(IGlobal global, JsFunction callee, JsInstance[] arguments)
      : base(global.ObjectClass.New())
    {
      this.global = global;
      for (int index = 0; index < arguments.Length; ++index)
      {
        ValueDescriptor valueDescriptor = new ValueDescriptor((JsDictionaryObject) this, index.ToString(), arguments[index]);
        valueDescriptor.Enumerable = false;
        this.DefineOwnProperty((Descriptor) valueDescriptor);
      }
      this.length = arguments.Length;
      ValueDescriptor valueDescriptor1 = new ValueDescriptor((JsDictionaryObject) this, nameof (callee), (JsInstance) callee);
      valueDescriptor1.Enumerable = false;
      this.calleeDescriptor = valueDescriptor1;
      this.DefineOwnProperty((Descriptor) this.calleeDescriptor);
      PropertyDescriptor<JsArguments> propertyDescriptor = new PropertyDescriptor<JsArguments>(global, (JsDictionaryObject) this, nameof (length), new Func<JsArguments, JsInstance>(this.GetLength));
      propertyDescriptor.Enumerable = false;
      this.DefineOwnProperty((Descriptor) propertyDescriptor);
    }

    public override bool IsClr
    {
      get
      {
        return false;
      }
    }

    public override bool ToBoolean()
    {
      return false;
    }

    public override double ToNumber()
    {
      return (double) this.Length;
    }

    public override int Length
    {
      get
      {
        return this.length;
      }
      set
      {
        this.length = value;
      }
    }

    public override string Class
    {
      get
      {
        return "Arguments";
      }
    }

    public JsInstance GetLength(JsArguments target)
    {
      return (JsInstance) this.global.NumberClass.New((double) target.length);
    }
  }
}
