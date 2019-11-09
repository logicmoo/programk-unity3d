// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsString
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;
using System.Globalization;

namespace Jint.Native
{
  [Serializable]
  public sealed class JsString : JsObject, ILiteral
  {
    private string value;

    public override object Value
    {
      get
      {
        return (object) this.value;
      }
    }

    public JsString(JsObject prototype)
      : base(prototype)
    {
      this.value = string.Empty;
    }

    public JsString(string str, JsObject prototype)
      : base(prototype)
    {
      this.value = str;
    }

    public static bool StringToBoolean(string value)
    {
      return value != null && (value == "true" || value.Length > 0);
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
      return JsString.StringToBoolean(this.value);
    }

    public static double StringToNumber(string value)
    {
      double result;
      if (value == null || !double.TryParse(value, NumberStyles.AllowDecimalPoint, (IFormatProvider) CultureInfo.InvariantCulture, out result))
        return double.NaN;
      return result;
    }

    public override double ToNumber()
    {
      return JsString.StringToNumber(this.value);
    }

    public override string ToSource()
    {
      return this.value == null ? "null" : "'" + this.ToString() + "'";
    }

    public override string ToString()
    {
      return this.value.ToString();
    }

    public override string Class
    {
      get
      {
        return "String";
      }
    }

    public override string Type
    {
      get
      {
        return "string";
      }
    }

    public override int GetHashCode()
    {
      return this.value.GetHashCode();
    }
  }
}
