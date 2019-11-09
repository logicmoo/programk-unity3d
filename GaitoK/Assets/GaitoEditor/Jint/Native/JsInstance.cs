// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsInstance
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Expressions;
using System;

namespace Jint.Native
{
  [Serializable]
  public abstract class JsInstance
  {
    public static JsInstance[] EMPTY = new JsInstance[0];
    public const string TYPE_OBJECT = "object";
    public const string TYPE_BOOLEAN = "boolean";
    public const string TYPE_STRING = "string";
    public const string TYPE_NUMBER = "number";
    public const string TYPE_UNDEFINED = "undefined";
    public const string TYPE_NULL = "null";
    public const string TYPE_DESCRIPTOR = "descriptor";
    public const string TYPEOF_FUNCTION = "function";
    public const string CLASS_NUMBER = "Number";
    public const string CLASS_STRING = "String";
    public const string CLASS_BOOLEAN = "Boolean";
    public const string CLASS_OBJECT = "Object";
    public const string CLASS_FUNCTION = "Function";
    public const string CLASS_ARRAY = "Array";
    public const string CLASS_REGEXP = "RegExp";
    public const string CLASS_DATE = "Date";
    public const string CLASS_ERROR = "Error";
    public const string CLASS_ARGUMENTS = "Arguments";
    public const string CLASS_GLOBAL = "Global";
    public const string CLASS_DESCRIPTOR = "Descriptor";
    public const string CLASS_SCOPE = "Scope";

    public abstract bool IsClr { get; }

    public abstract object Value { get; set; }

    public PropertyAttributes Attributes { get; set; }

    public virtual JsInstance ToPrimitive(IGlobal global)
    {
      return (JsInstance) JsUndefined.Instance;
    }

    public virtual bool ToBoolean()
    {
      return true;
    }

    public virtual double ToNumber()
    {
      return 0.0;
    }

    public virtual int ToInteger()
    {
      return (int) this.ToNumber();
    }

    public virtual object ToObject()
    {
      return this.Value;
    }

    public virtual string ToSource()
    {
      return this.ToString();
    }

    public override string ToString()
    {
      return (this.Value ?? (object) this.Class).ToString();
    }

    public override int GetHashCode()
    {
      return this.Value != null ? this.Value.GetHashCode() : base.GetHashCode();
    }

    public abstract string Class { get; }

    public abstract string Type { get; }

    [Obsolete("will be removed in the 1.0 version", true)]
    public virtual object Call(
      IJintVisitor visitor,
      string function,
      params JsInstance[] parameters)
    {
      if (function == "toString")
        return (object) visitor.Global.StringClass.New(this.ToString());
      return (object) JsUndefined.Instance;
    }
  }
}
