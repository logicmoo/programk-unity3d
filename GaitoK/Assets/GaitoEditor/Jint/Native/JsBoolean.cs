// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsBoolean
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;

namespace Jint.Native
{
  [Serializable]
  public sealed class JsBoolean : JsObject, ILiteral
  {
    private bool value;

    public override object Value
    {
      get
      {
        return (object) this.value;
      }
    }

    public JsBoolean(JsObject prototype)
      : this(false, prototype)
    {
      this.value = false;
    }

    public JsBoolean(bool boolean, JsObject prototype)
      : base(prototype)
    {
      this.value = boolean;
    }

    public override bool IsClr
    {
      get
      {
        return false;
      }
    }

    public override string Type
    {
      get
      {
        return "boolean";
      }
    }

    public override string Class
    {
      get
      {
        return "Boolean";
      }
    }

    public override bool ToBoolean()
    {
      return this.value;
    }

    public override string ToString()
    {
      return this.value ? "true" : "false";
    }

    public static double BooleanToNumber(bool value)
    {
      return value ? 1.0 : 0.0;
    }

    public override double ToNumber()
    {
      return JsBoolean.BooleanToNumber(this.value);
    }
  }
}
