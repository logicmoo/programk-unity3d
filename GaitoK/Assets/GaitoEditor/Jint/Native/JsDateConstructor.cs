// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsDateConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;
using System.Globalization;

namespace Jint.Native
{
  [Serializable]
  public class JsDateConstructor : JsConstructor
  {
    protected JsDateConstructor(IGlobal global, bool initializeUTC)
      : base(global)
    {
      this.Name = "Date";
      this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) global.ObjectClass.New((JsFunction) this), PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
      this.DefineOwnProperty("now", (JsInstance) new ClrFunction((Delegate) (() => this.Global.DateClass.New(DateTime.Now)), global.FunctionClass.PrototypeProperty), PropertyAttributes.DontEnum);
      this.DefineOwnProperty("parse", (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.ParseImpl), global.FunctionClass.PrototypeProperty), PropertyAttributes.DontEnum);
      this.DefineOwnProperty("parseLocale", (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.ParseLocaleImpl), global.FunctionClass.PrototypeProperty), PropertyAttributes.DontEnum);
      this.DefineOwnProperty("UTC", (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.UTCImpl), global.FunctionClass.PrototypeProperty), PropertyAttributes.DontEnum);
    }

    public override void InitPrototype(IGlobal global)
    {
      JsObject prototypeProperty = this.PrototypeProperty;
      prototypeProperty.DefineOwnProperty("UTC", (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.UTCImpl), global.FunctionClass.PrototypeProperty), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("now", (JsInstance) new ClrFunction((Delegate) (() => this.Global.DateClass.New(DateTime.Now)), global.FunctionClass.PrototypeProperty), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("parse", (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.ParseImpl), global.FunctionClass.PrototypeProperty), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("parseLocale", (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.ParseLocaleImpl), global.FunctionClass.PrototypeProperty), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toDateString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToDateStringImpl), 0), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toTimeString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToTimeStringImpl), 0), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toLocaleString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToLocaleStringImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toLocaleDateString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToLocaleDateStringImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toLocaleTimeString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToLocaleTimeStringImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("valueOf", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ValueOfImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getTime", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetTimeImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getFullYear", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetFullYearImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getUTCFullYear", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetUTCFullYearImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getMonth", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetMonthImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getUTCMonth", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetUTCMonthImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getDate", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetDateImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getUTCDate", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetUTCDateImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getDay", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetDayImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getUTCDay", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetUTCDayImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getHours", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetHoursImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getUTCHours", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetUTCHoursImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getMinutes", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetMinutesImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getUTCMinutes", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetUTCMinutesImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getSeconds", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetSecondsImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getUTCSeconds", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetUTCSecondsImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getMilliseconds", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetMillisecondsImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getUTCMilliseconds", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetUTCMillisecondsImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("getTimezoneOffset", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.GetTimezoneOffsetImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setTime", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetTimeImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setMilliseconds", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetMillisecondsImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setUTCMilliseconds", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetUTCMillisecondsImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setSeconds", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetSecondsImpl), 2), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setUTCSeconds", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetUTCSecondsImpl), 2), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setMinutes", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetMinutesImpl), 3), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setUTCMinutes", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetUTCMinutesImpl), 3), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setHours", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetHoursImpl), 4), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setUTCHours", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetUTCHoursImpl), 4), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setDate", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetDateImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setUTCDate", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetUTCDateImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setMonth", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetMonthImpl), 2), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setUTCMonth", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetUTCMonthImpl), 2), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setFullYear", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetFullYearImpl), 3), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("setUTCFullYear", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SetUTCFullYearImpl), 3), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toUTCString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToUTCStringImpl)), PropertyAttributes.DontEnum);
    }

    public JsDateConstructor(IGlobal global)
      : this(global, true)
    {
    }

    public JsDate New()
    {
      return new JsDate(this.PrototypeProperty);
    }

    public JsDate New(double value)
    {
      return new JsDate(value, this.PrototypeProperty);
    }

    public JsDate New(DateTime value)
    {
      return new JsDate(value.ToUniversalTime(), this.PrototypeProperty);
    }

    public JsDate New(DateTime value, JsObject prototype)
    {
      return new JsDate(value, prototype);
    }

    public JsDate Construct(JsInstance[] parameters)
    {
      JsDate jsDate;
      if (parameters.Length == 1)
      {
        double result;
        jsDate = !(parameters[0].Class == "Number") && !(parameters[0].Class == "Object") || !double.IsNaN(parameters[0].ToNumber()) ? (!(parameters[0].Class == "Number") ? (!this.ParseDate(parameters[0].ToString(), (IFormatProvider) CultureInfo.InvariantCulture, out result) ? (!this.ParseDate(parameters[0].ToString(), (IFormatProvider) CultureInfo.CurrentCulture, out result) ? this.New(0.0) : this.New(result)) : this.New(result)) : this.New(parameters[0].ToNumber())) : this.New(double.NaN);
      }
      else if (parameters.Length > 1)
      {
        DateTime dateTime = new DateTime(0L, DateTimeKind.Local);
        if ((uint) parameters.Length > 0U)
        {
          int num = (int) parameters[0].ToNumber() - 1;
          if (num < 100)
            num += 1900;
          dateTime = dateTime.AddYears(num);
        }
        if (parameters.Length > 1)
          dateTime = dateTime.AddMonths((int) parameters[1].ToNumber());
        if (parameters.Length > 2)
          dateTime = dateTime.AddDays((double) ((int) parameters[2].ToNumber() - 1));
        if (parameters.Length > 3)
          dateTime = dateTime.AddHours((double) (int) parameters[3].ToNumber());
        if (parameters.Length > 4)
          dateTime = dateTime.AddMinutes((double) (int) parameters[4].ToNumber());
        if (parameters.Length > 5)
          dateTime = dateTime.AddSeconds((double) (int) parameters[5].ToNumber());
        if (parameters.Length > 6)
          dateTime = dateTime.AddMilliseconds((double) (int) parameters[6].ToNumber());
        jsDate = this.New(dateTime);
      }
      else
        jsDate = this.New(DateTime.UtcNow);
      return jsDate;
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      JsDate jsDate = this.Construct(parameters);
      if (that == null || that as IGlobal == visitor.Global)
        return visitor.Return(this.ToStringImpl((JsDictionaryObject) jsDate, JsInstance.EMPTY));
      return (JsInstance) jsDate;
    }

    private bool ParseDate(string p, IFormatProvider culture, out double result)
    {
      DateTime result1 = new DateTime(0L, DateTimeKind.Utc);
      result = 0.0;
      if (DateTime.TryParse(p, culture, DateTimeStyles.None, out result1))
      {
        result = this.New(result1).ToNumber();
        return true;
      }
      if (DateTime.TryParseExact(p, JsDate.FORMAT, culture, DateTimeStyles.None, out result1))
      {
        result = this.New(result1).ToNumber();
        return true;
      }
      DateTime result2;
      if (DateTime.TryParseExact(p, JsDate.DATEFORMAT, culture, DateTimeStyles.None, out result2))
        result1 = result1.AddTicks(result2.Ticks);
      if (DateTime.TryParseExact(p, JsDate.TIMEFORMAT, culture, DateTimeStyles.None, out result2))
        result1 = result1.AddTicks(result2.Ticks);
      if (result1.Ticks <= 0L)
        return true;
      result = this.New(result1).ToNumber();
      return true;
    }

    public JsInstance ParseImpl(JsInstance[] parameters)
    {
      double result;
      if (this.ParseDate(parameters[0].ToString(), (IFormatProvider) CultureInfo.InvariantCulture, out result))
        return (JsInstance) this.Global.NumberClass.New(result);
      return this.Global.NaN;
    }

    public JsInstance ParseLocaleImpl(JsInstance[] parameters)
    {
      double result;
      if (this.ParseDate(parameters[0].ToString(), (IFormatProvider) CultureInfo.CurrentCulture, out result))
        return (JsInstance) this.Global.NumberClass.New(result);
      return this.Global.NaN;
    }

    internal static DateTime CreateDateTime(double number)
    {
      return new DateTime((long) (number * (double) JsDate.TICKSFACTOR + (double) JsDate.OFFSET_1970), DateTimeKind.Utc);
    }

    public JsInstance ToStringImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return (JsInstance) this.Global.StringClass.New(double.NaN.ToString());
      JsStringConstructor stringClass = this.Global.StringClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      string str = dateTime.ToString(JsDate.FORMAT, (IFormatProvider) CultureInfo.InvariantCulture);
      return (JsInstance) stringClass.New(str);
    }

    public JsInstance ToLocaleStringImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return (JsInstance) this.Global.StringClass.New(double.NaN.ToString());
      JsStringConstructor stringClass = this.Global.StringClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      string str = dateTime.ToString("F", (IFormatProvider) CultureInfo.CurrentCulture);
      return (JsInstance) stringClass.New(str);
    }

    public JsInstance ToDateStringImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return (JsInstance) this.Global.StringClass.New(double.NaN.ToString());
      JsStringConstructor stringClass = this.Global.StringClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      string str = dateTime.ToString(JsDate.DATEFORMAT, (IFormatProvider) CultureInfo.InvariantCulture);
      return (JsInstance) stringClass.New(str);
    }

    public JsInstance ToTimeStringImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return (JsInstance) this.Global.StringClass.New(double.NaN.ToString());
      JsStringConstructor stringClass = this.Global.StringClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      string str = dateTime.ToString(JsDate.TIMEFORMAT, (IFormatProvider) CultureInfo.InvariantCulture);
      return (JsInstance) stringClass.New(str);
    }

    public JsInstance ToLocaleDateStringImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return (JsInstance) this.Global.StringClass.New(double.NaN.ToString());
      JsStringConstructor stringClass = this.Global.StringClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      string str = dateTime.ToString(JsDate.DATEFORMAT);
      return (JsInstance) stringClass.New(str);
    }

    public JsInstance ToLocaleTimeStringImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return (JsInstance) this.Global.StringClass.New(double.NaN.ToString());
      JsStringConstructor stringClass = this.Global.StringClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      string str = dateTime.ToString(JsDate.TIMEFORMAT);
      return (JsInstance) stringClass.New(str);
    }

    public JsInstance ValueOfImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      return (JsInstance) this.Global.NumberClass.New(target.ToNumber());
    }

    public JsInstance GetTimeImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      return (JsInstance) this.Global.NumberClass.New(target.ToNumber());
    }

    public JsInstance GetFullYearImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      double year = (double) dateTime.Year;
      return (JsInstance) numberClass.New(year);
    }

    public JsInstance GetUTCFullYearImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToUniversalTime();
      double year = (double) dateTime.Year;
      return (JsInstance) numberClass.New(year);
    }

    public JsInstance GetMonthImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      double num = (double) (dateTime.Month - 1);
      return (JsInstance) numberClass.New(num);
    }

    public JsInstance GetUTCMonthImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToUniversalTime();
      double num = (double) (dateTime.Month - 1);
      return (JsInstance) numberClass.New(num);
    }

    public JsInstance GetDateImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      double day = (double) dateTime.Day;
      return (JsInstance) numberClass.New(day);
    }

    public JsInstance GetUTCDateImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToUniversalTime();
      double day = (double) dateTime.Day;
      return (JsInstance) numberClass.New(day);
    }

    public JsInstance GetDayImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      double dayOfWeek = (double) dateTime.DayOfWeek;
      return (JsInstance) numberClass.New(dayOfWeek);
    }

    public JsInstance GetUTCDayImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToUniversalTime();
      double dayOfWeek = (double) dateTime.DayOfWeek;
      return (JsInstance) numberClass.New(dayOfWeek);
    }

    public JsInstance GetHoursImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      double hour = (double) dateTime.Hour;
      return (JsInstance) numberClass.New(hour);
    }

    public JsInstance GetUTCHoursImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToUniversalTime();
      double hour = (double) dateTime.Hour;
      return (JsInstance) numberClass.New(hour);
    }

    public JsInstance GetMinutesImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      double minute = (double) dateTime.Minute;
      return (JsInstance) numberClass.New(minute);
    }

    public JsInstance GetUTCMinutesImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToUniversalTime();
      double minute = (double) dateTime.Minute;
      return (JsInstance) numberClass.New(minute);
    }

    public JsInstance ToUTCStringImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return (JsInstance) this.Global.StringClass.New(double.NaN.ToString());
      return (JsInstance) this.Global.StringClass.New(JsDateConstructor.CreateDateTime(target.ToNumber()).ToString(JsDate.FORMATUTC, (IFormatProvider) CultureInfo.InvariantCulture));
    }

    public JsInstance GetSecondsImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      double second = (double) dateTime.Second;
      return (JsInstance) numberClass.New(second);
    }

    public JsInstance GetUTCSecondsImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToUniversalTime();
      double second = (double) dateTime.Second;
      return (JsInstance) numberClass.New(second);
    }

    public JsInstance GetMillisecondsImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToLocalTime();
      double millisecond = (double) dateTime.Millisecond;
      return (JsInstance) numberClass.New(millisecond);
    }

    public JsInstance GetUTCMillisecondsImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (double.IsNaN(target.ToNumber()))
        return this.Global.NaN;
      JsNumberConstructor numberClass = this.Global.NumberClass;
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.ToUniversalTime();
      double millisecond = (double) dateTime.Millisecond;
      return (JsInstance) numberClass.New(millisecond);
    }

    public JsInstance GetTimezoneOffsetImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      return (JsInstance) this.Global.NumberClass.New(-TimeZone.CurrentTimeZone.GetUtcOffset(new DateTime()).TotalMinutes);
    }

    public JsInstance SetTimeImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no tiem specified");
      target.Value = (object) parameters[0].ToNumber();
      return (JsInstance) target;
    }

    public JsInstance SetMillisecondsImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no millisecond specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
      dateTime = dateTime.AddMilliseconds((double) -dateTime.Millisecond);
      dateTime = dateTime.AddMilliseconds(parameters[0].ToNumber());
      target.Value = (object) this.New(dateTime).ToNumber();
      return (JsInstance) target;
    }

    public JsInstance SetUTCMillisecondsImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no millisecond specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.AddMilliseconds((double) -dateTime.Millisecond);
      dateTime = dateTime.AddMilliseconds(parameters[0].ToNumber());
      target.Value = (object) this.New(dateTime).ToNumber();
      return (JsInstance) target;
    }

    public JsInstance SetSecondsImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no second specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
      dateTime = dateTime.AddSeconds((double) -dateTime.Second);
      dateTime = dateTime.AddSeconds(parameters[0].ToNumber());
      target.Value = (object) dateTime;
      if (parameters.Length > 1)
      {
        JsInstance[] parameters1 = new JsInstance[parameters.Length - 1];
        parameters.CopyTo((Array) parameters1, 1);
        target = (JsDictionaryObject) this.SetMillisecondsImpl(target, parameters1);
      }
      return (JsInstance) target;
    }

    public JsInstance SetUTCSecondsImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no second specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.AddSeconds((double) -dateTime.Second);
      dateTime = dateTime.AddSeconds(parameters[0].ToNumber());
      target.Value = (object) dateTime;
      if (parameters.Length > 1)
      {
        JsInstance[] parameters1 = new JsInstance[parameters.Length - 1];
        parameters.CopyTo((Array) parameters1, 1);
        target = (JsDictionaryObject) this.SetMillisecondsImpl(target, parameters1);
      }
      return (JsInstance) target;
    }

    public JsInstance SetMinutesImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no minute specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
      dateTime = dateTime.AddMinutes((double) -dateTime.Minute);
      dateTime = dateTime.AddMinutes(parameters[0].ToNumber());
      target.Value = (object) dateTime;
      if (parameters.Length > 1)
      {
        JsInstance[] parameters1 = new JsInstance[parameters.Length - 1];
        parameters.CopyTo((Array) parameters1, 1);
        target = (JsDictionaryObject) this.SetSecondsImpl(target, parameters1);
      }
      return (JsInstance) target;
    }

    public JsInstance SetUTCMinutesImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no minute specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.AddMinutes((double) -dateTime.Minute);
      dateTime = dateTime.AddMinutes(parameters[0].ToNumber());
      target.Value = (object) dateTime;
      if (parameters.Length > 1)
      {
        JsInstance[] parameters1 = new JsInstance[parameters.Length - 1];
        parameters.CopyTo((Array) parameters1, 1);
        target = (JsDictionaryObject) this.SetSecondsImpl(target, parameters1);
      }
      return (JsInstance) target;
    }

    public JsInstance SetHoursImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no hour specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
      dateTime = dateTime.AddHours((double) -dateTime.Hour);
      dateTime = dateTime.AddHours(parameters[0].ToNumber());
      target.Value = (object) dateTime;
      if (parameters.Length > 1)
      {
        JsInstance[] parameters1 = new JsInstance[parameters.Length - 1];
        parameters.CopyTo((Array) parameters1, 1);
        target = (JsDictionaryObject) this.SetMinutesImpl(target, parameters1);
      }
      return (JsInstance) target;
    }

    public JsInstance SetUTCHoursImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no hour specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.AddHours((double) -dateTime.Hour);
      dateTime = dateTime.AddHours(parameters[0].ToNumber());
      target.Value = (object) dateTime;
      if (parameters.Length > 1)
      {
        JsInstance[] parameters1 = new JsInstance[parameters.Length - 1];
        parameters.CopyTo((Array) parameters1, 1);
        target = (JsDictionaryObject) this.SetMinutesImpl(target, parameters1);
      }
      return (JsInstance) target;
    }

    public JsInstance SetDateImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no date specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
      dateTime = dateTime.AddDays((double) -dateTime.Day);
      dateTime = dateTime.AddDays(parameters[0].ToNumber());
      target.Value = (object) dateTime;
      return (JsInstance) target;
    }

    public JsInstance SetUTCDateImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no date specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.AddDays((double) -dateTime.Day);
      dateTime = dateTime.AddDays(parameters[0].ToNumber());
      target.Value = (object) dateTime;
      return (JsInstance) target;
    }

    public JsInstance SetMonthImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no month specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
      dateTime = dateTime.AddMonths(-dateTime.Month);
      dateTime = dateTime.AddMonths((int) parameters[0].ToNumber());
      target.Value = (object) dateTime;
      if (parameters.Length > 1)
      {
        JsInstance[] parameters1 = new JsInstance[parameters.Length - 1];
        parameters.CopyTo((Array) parameters1, 1);
        target = (JsDictionaryObject) this.SetDateImpl(target, parameters1);
      }
      return (JsInstance) target;
    }

    public JsInstance SetUTCMonthImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no month specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.AddMonths(-dateTime.Month);
      dateTime = dateTime.AddMonths((int) parameters[0].ToNumber());
      target.Value = (object) dateTime;
      if (parameters.Length > 1)
      {
        JsInstance[] parameters1 = new JsInstance[parameters.Length - 1];
        parameters.CopyTo((Array) parameters1, 1);
        target = (JsDictionaryObject) this.SetDateImpl(target, parameters1);
      }
      return (JsInstance) target;
    }

    public JsInstance SetFullYearImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no year specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber()).ToLocalTime();
      int num = dateTime.Year - (int) parameters[0].ToNumber();
      dateTime = dateTime.AddYears(-num);
      target.Value = (object) dateTime;
      if (parameters.Length > 1)
      {
        JsInstance[] parameters1 = new JsInstance[parameters.Length - 1];
        parameters.CopyTo((Array) parameters1, 1);
        target = (JsDictionaryObject) this.SetMonthImpl(target, parameters1);
      }
      return (JsInstance) target;
    }

    public JsInstance SetUTCFullYearImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("There was no year specified");
      DateTime dateTime = JsDateConstructor.CreateDateTime(target.ToNumber());
      dateTime = dateTime.AddYears(-dateTime.Year);
      dateTime = dateTime.AddYears((int) parameters[0].ToNumber());
      target.Value = (object) dateTime;
      if (parameters.Length > 1)
      {
        JsInstance[] parameters1 = new JsInstance[parameters.Length - 1];
        parameters.CopyTo((Array) parameters1, 1);
        target = (JsDictionaryObject) this.SetMonthImpl(target, parameters1);
      }
      return (JsInstance) target;
    }

    public JsInstance UTCImpl(JsInstance[] parameters)
    {
      for (int index = 0; index < parameters.Length; ++index)
      {
        if (parameters[index] == JsUndefined.Instance || parameters[index].Class == "Number" && double.IsNaN(parameters[index].ToNumber()) || parameters[index].Class == "Number" && double.IsInfinity(parameters[index].ToNumber()))
          return this.Global.NaN;
      }
      return (JsInstance) this.Global.NumberClass.New(this.Construct(parameters).ToNumber() + TimeZone.CurrentTimeZone.GetUtcOffset(new DateTime()).TotalMilliseconds);
    }
  }
}
