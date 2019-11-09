// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsObject
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;
using System.Runtime.CompilerServices;

namespace Jint.Native
{
  [Serializable]
  public class JsObject : JsDictionaryObject
  {
    protected object value;

    public INativeIndexer Indexer { get; set; }

    public JsObject()
    {
    }

    public JsObject(object value, JsObject prototype)
      : base((JsDictionaryObject) prototype)
    {
      this.value = value;
    }

    public JsObject(JsObject prototype)
      : base((JsDictionaryObject) prototype)
    {
    }

    public override bool IsClr
    {
      get
      {
        return this.Value != null;
      }
    }

    public override string Class
    {
      get
      {
        return "Object";
      }
    }

    public override string Type
    {
      get
      {
        return "object";
      }
    }

    public override object Value
    {
      get
      {
        return this.value;
      }
      set
      {
        this.value = value;
      }
    }

    public override int GetHashCode()
    {
      return RuntimeHelpers.GetHashCode((object) this);
    }

    public override JsInstance ToPrimitive(IGlobal global)
    {
      if (this.Value != null && !(this.Value is IComparable))
        return (JsInstance) global.StringClass.New(this.Value.ToString());
      switch (Convert.GetTypeCode(this.Value))
      {
        case TypeCode.Object:
        case TypeCode.Char:
        case TypeCode.String:
          return (JsInstance) global.StringClass.New(this.Value.ToString());
        case TypeCode.Boolean:
          return (JsInstance) global.BooleanClass.New((bool) this.Value);
        case TypeCode.SByte:
        case TypeCode.Byte:
        case TypeCode.Int16:
        case TypeCode.UInt16:
        case TypeCode.Int32:
        case TypeCode.UInt32:
        case TypeCode.Int64:
        case TypeCode.UInt64:
        case TypeCode.Single:
        case TypeCode.Double:
        case TypeCode.Decimal:
          return (JsInstance) global.NumberClass.New(Convert.ToDouble(this.Value));
        case TypeCode.DateTime:
          return (JsInstance) global.DateClass.New((DateTime) this.Value);
        default:
          return (JsInstance) JsUndefined.Instance;
      }
    }

    public override bool ToBoolean()
    {
      if (this.Value != null && !(this.Value is IConvertible))
        return true;
      switch (Convert.GetTypeCode(this.Value))
      {
        case TypeCode.Object:
          return Convert.ToBoolean(this.Value);
        case TypeCode.Boolean:
          return (bool) this.Value;
        case TypeCode.Char:
        case TypeCode.String:
          return JsString.StringToBoolean((string) this.Value);
        case TypeCode.SByte:
        case TypeCode.Byte:
        case TypeCode.Int16:
        case TypeCode.UInt16:
        case TypeCode.Int32:
        case TypeCode.UInt32:
        case TypeCode.Int64:
        case TypeCode.UInt64:
        case TypeCode.Single:
        case TypeCode.Double:
        case TypeCode.Decimal:
          return JsNumber.NumberToBoolean(Convert.ToDouble(this.Value));
        case TypeCode.DateTime:
          return JsNumber.NumberToBoolean(JsDate.DateToDouble((DateTime) this.Value));
        default:
          return true;
      }
    }

    public override double ToNumber()
    {
      if (this.Value == null)
        return 0.0;
      if (!(this.Value is IConvertible))
        return double.NaN;
      switch (Convert.GetTypeCode(this.Value))
      {
        case TypeCode.Boolean:
          return JsBoolean.BooleanToNumber((bool) this.Value);
        case TypeCode.Char:
        case TypeCode.String:
          return JsString.StringToNumber((string) this.Value);
        case TypeCode.DateTime:
          return JsDate.DateToDouble((DateTime) this.Value);
        default:
          return Convert.ToDouble(this.Value);
      }
    }

    public override string ToString()
    {
      if (this.value == null)
        return (string) null;
      if (this.value is IConvertible)
        return Convert.ToString(this.Value);
      return this.value.ToString();
    }
  }
}
