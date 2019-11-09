// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsNumber
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;
using System.Globalization;

namespace Jint.Native
{
  [Serializable]
  public sealed class JsNumber : JsObject, ILiteral
  {
    private double value;

    public override object Value
    {
      get
      {
        return (object) this.value;
      }
    }

    public JsNumber(JsObject prototype)
      : this(0.0, prototype)
    {
    }

    public JsNumber(double num, JsObject prototype)
      : base(prototype)
    {
      this.value = num;
    }

    public JsNumber(int num, JsObject prototype)
      : base(prototype)
    {
      this.value = (double) num;
    }

    public override bool IsClr
    {
      get
      {
        return false;
      }
    }

    public static bool NumberToBoolean(double value)
    {
      return value != 0.0;
    }

    public override bool ToBoolean()
    {
      return JsNumber.NumberToBoolean(this.value);
    }

    public override double ToNumber()
    {
      return this.value;
    }

    public override string ToString()
    {
      return this.value.ToString((IFormatProvider) CultureInfo.InvariantCulture).ToLower();
    }

    public override object ToObject()
    {
      return (object) this.value;
    }

    public override string Class
    {
      get
      {
        return "Number";
      }
    }

    public override string Type
    {
      get
      {
        return "number";
      }
    }
  }
}
