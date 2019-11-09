// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsDate
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;
using System.Globalization;

namespace Jint.Native
{
  [Serializable]
  public sealed class JsDate : JsObject
  {
    internal static long OFFSET_1970 = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).Ticks;
    internal static int TICKSFACTOR = 10000;
    public static string FORMAT = "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'zzz";
    public static string FORMATUTC = "ddd, dd MMM yyyy HH':'mm':'ss 'UTC'";
    public static string DATEFORMAT = "ddd, dd MMM yyyy";
    public static string TIMEFORMAT = "HH':'mm':'ss 'GMT'zzz";
    private DateTime value;

    public override object Value
    {
      get
      {
        return (object) this.value;
      }
      set
      {
        if (value is DateTime)
        {
          this.value = (DateTime) value;
        }
        else
        {
          if (!(value is double))
            return;
          this.value = JsDateConstructor.CreateDateTime((double) value);
        }
      }
    }

    public JsDate(JsObject prototype)
      : base(prototype)
    {
      this.value = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    }

    public JsDate(DateTime date, JsObject prototype)
      : base(prototype)
    {
      this.value = date;
    }

    public JsDate(double value, JsObject prototype)
      : this(JsDateConstructor.CreateDateTime(value), prototype)
    {
    }

    public override bool IsClr
    {
      get
      {
        return false;
      }
    }

    public override double ToNumber()
    {
      return JsDate.DateToDouble(this.value);
    }

    public static double DateToDouble(DateTime date)
    {
      return (double) ((date.ToUniversalTime().Ticks - JsDate.OFFSET_1970) / (long) JsDate.TICKSFACTOR);
    }

    public override string ToString()
    {
      return this.value.ToLocalTime().ToString(JsDate.FORMAT, (IFormatProvider) CultureInfo.InvariantCulture);
    }

    public override object ToObject()
    {
      return (object) this.value;
    }

    public override string Class
    {
      get
      {
        return "Date";
      }
    }
  }
}
