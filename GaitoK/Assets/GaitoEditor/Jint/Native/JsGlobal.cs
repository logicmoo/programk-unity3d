// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsGlobal
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Jint.Native
{
  [Serializable]
  public class JsGlobal : JsObject, IGlobal
  {
    private static char[] reservedEncoded = new char[11]{ ';', ',', '/', '?', ':', '@', '&', '=', '+', '$', '#' };
    private static char[] reservedEncodedComponent = new char[11]{ '-', '_', '.', '!', '~', '*', '\'', '(', ')', '[', ']' };

    public IJintVisitor Visitor { get; set; }

    public Options Options { get; set; }

    public JsGlobal(ExecutionVisitor visitor, Options options)
      : base((JsObject) JsNull.Instance)
    {
      this.Options = options;
      this.Visitor = (IJintVisitor) visitor;
      this["null"] = (JsInstance) JsNull.Instance;
      JsObject jsObject = new JsObject((JsObject) JsNull.Instance);
      JsFunction jsFunction = (JsFunction) new JsFunctionWrapper((Func<JsInstance[], JsInstance>) (arguments => (JsInstance) JsUndefined.Instance), jsObject);
      this["Function"] = (JsInstance) (this.FunctionClass = new JsFunctionConstructor((IGlobal) this, (JsObject) jsFunction));
      this["Object"] = (JsInstance) (this.ObjectClass = new JsObjectConstructor((IGlobal) this, (JsObject) jsFunction, jsObject));
      this.ObjectClass.InitPrototype((IGlobal) this);
      this["Array"] = (JsInstance) (this.ArrayClass = new JsArrayConstructor((IGlobal) this));
      this["Boolean"] = (JsInstance) (this.BooleanClass = new JsBooleanConstructor((IGlobal) this));
      this["Date"] = (JsInstance) (this.DateClass = new JsDateConstructor((IGlobal) this));
      this["Error"] = (JsInstance) (this.ErrorClass = new JsErrorConstructor((IGlobal) this, "Error"));
      this["EvalError"] = (JsInstance) (this.EvalErrorClass = new JsErrorConstructor((IGlobal) this, "EvalError"));
      this["RangeError"] = (JsInstance) (this.RangeErrorClass = new JsErrorConstructor((IGlobal) this, "RangeError"));
      this["ReferenceError"] = (JsInstance) (this.ReferenceErrorClass = new JsErrorConstructor((IGlobal) this, "ReferenceError"));
      this["SyntaxError"] = (JsInstance) (this.SyntaxErrorClass = new JsErrorConstructor((IGlobal) this, "SyntaxError"));
      this["TypeError"] = (JsInstance) (this.TypeErrorClass = new JsErrorConstructor((IGlobal) this, "TypeError"));
      this["URIError"] = (JsInstance) (this.URIErrorClass = new JsErrorConstructor((IGlobal) this, "URIError"));
      this["Number"] = (JsInstance) (this.NumberClass = new JsNumberConstructor((IGlobal) this));
      this["RegExp"] = (JsInstance) (this.RegExpClass = new JsRegExpConstructor((IGlobal) this));
      this["String"] = (JsInstance) (this.StringClass = new JsStringConstructor((IGlobal) this));
      this["Math"] = (JsInstance) (this.MathClass = new JsMathConstructor((IGlobal) this));
      foreach (JsInstance jsInstance in this.GetValues())
      {
        if (jsInstance is JsConstructor)
          ((JsConstructor) jsInstance).InitPrototype((IGlobal) this);
      }
      this[nameof (NaN)] = this.NumberClass[nameof (NaN)];
      this["Infinity"] = this.NumberClass["POSITIVE_INFINITY"];
      this["undefined"] = (JsInstance) JsUndefined.Instance;
      this[JsScope.THIS] = (JsInstance) this;
      this["eval"] = (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.Eval), this.FunctionClass.PrototypeProperty);
      this["parseInt"] = (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.ParseInt), this.FunctionClass.PrototypeProperty);
      this["parseFloat"] = (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.ParseFloat), this.FunctionClass.PrototypeProperty);
      this["isNaN"] = (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.IsNaN), this.FunctionClass.PrototypeProperty);
      this["isFinite"] = (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.isFinite), this.FunctionClass.PrototypeProperty);
      this["decodeURI"] = (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.DecodeURI), this.FunctionClass.PrototypeProperty);
      this["encodeURI"] = (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.EncodeURI), this.FunctionClass.PrototypeProperty);
      this["decodeURIComponent"] = (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.DecodeURIComponent), this.FunctionClass.PrototypeProperty);
      this["encodeURIComponent"] = (JsInstance) new JsFunctionWrapper(new Func<JsInstance[], JsInstance>(this.EncodeURIComponent), this.FunctionClass.PrototypeProperty);
      this.Marshaller = new Marshaller((IGlobal) this);
      this.Marshaller.InitTypes();
    }

    public override string Class
    {
      get
      {
        return "Global";
      }
    }

    public JsObjectConstructor ObjectClass { get; private set; }

    public JsFunctionConstructor FunctionClass { get; private set; }

    public JsArrayConstructor ArrayClass { get; private set; }

    public JsBooleanConstructor BooleanClass { get; private set; }

    public JsDateConstructor DateClass { get; private set; }

    public JsErrorConstructor ErrorClass { get; private set; }

    public JsErrorConstructor EvalErrorClass { get; private set; }

    public JsErrorConstructor RangeErrorClass { get; private set; }

    public JsErrorConstructor ReferenceErrorClass { get; private set; }

    public JsErrorConstructor SyntaxErrorClass { get; private set; }

    public JsErrorConstructor TypeErrorClass { get; private set; }

    public JsErrorConstructor URIErrorClass { get; private set; }

    public JsMathConstructor MathClass { get; private set; }

    public JsNumberConstructor NumberClass { get; private set; }

    public JsRegExpConstructor RegExpClass { get; private set; }

    public JsStringConstructor StringClass { get; private set; }

    public Marshaller Marshaller { get; private set; }

    public JsInstance Eval(JsInstance[] arguments)
    {
      if ("String" != arguments[0].Class)
        return arguments[0];
      Program program;
      try
      {
        program = JintEngine.Compile(arguments[0].ToString(), this.Visitor.DebugMode);
      }
      catch (Exception ex)
      {
        throw new JsException((JsInstance) this.SyntaxErrorClass.New(ex.Message));
      }
      try
      {
        program.Accept((IStatementVisitor) this.Visitor);
      }
      catch (Exception ex)
      {
        throw new JsException((JsInstance) this.EvalErrorClass.New(ex.Message));
      }
      return this.Visitor.Result;
    }

    public JsInstance ParseInt(JsInstance[] arguments)
    {
      if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
        return (JsInstance) JsUndefined.Instance;
      if (arguments[0].IsClr && arguments[0].Value.GetType().IsEnum)
        return (JsInstance) this.NumberClass.New((double) (int) arguments[0].Value);
      string s = arguments[0].ToString().Trim();
      int num = 1;
      int fromBase = 10;
      if (s == string.Empty)
        return this["NaN"];
      if (s.StartsWith("-"))
      {
        s = s.Substring(1);
        num = -1;
      }
      else if (s.StartsWith("+"))
        s = s.Substring(1);
      if (arguments.Length >= 2 && (arguments[1] != JsUndefined.Instance && !0.Equals((object) arguments[1])))
        fromBase = Convert.ToInt32(arguments[1].Value);
      if (fromBase == 0)
        fromBase = 10;
      else if (fromBase < 2 || fromBase > 36)
        return this["NaN"];
      if (s.ToLower().StartsWith("0x"))
        fromBase = 16;
      try
      {
        if (fromBase != 10)
          return (JsInstance) this.NumberClass.New((double) (num * Convert.ToInt32(s, fromBase)));
        double result;
        if (double.TryParse(s, NumberStyles.Any, (IFormatProvider) CultureInfo.InvariantCulture, out result))
          return (JsInstance) this.NumberClass.New((double) num * Math.Floor(result));
        return this["NaN"];
      }
      catch
      {
        return this["NaN"];
      }
    }

    public JsInstance ParseFloat(JsInstance[] arguments)
    {
      if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
        return (JsInstance) JsUndefined.Instance;
      Match match = new Regex("^[\\+\\-\\d\\.e]*", RegexOptions.IgnoreCase).Match(arguments[0].ToString().Trim());
      double result;
      if (match.Success && double.TryParse(match.Value, NumberStyles.Float, (IFormatProvider) new CultureInfo("en-US"), out result))
        return (JsInstance) this.NumberClass.New(result);
      return this["NaN"];
    }

    public JsInstance IsNaN(JsInstance[] arguments)
    {
      if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
        return (JsInstance) this.BooleanClass.New(false);
      return (JsInstance) this.BooleanClass.New(double.NaN.Equals(arguments[0].ToNumber()));
    }

    protected JsInstance isFinite(JsInstance[] arguments)
    {
      if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
        return (JsInstance) this.BooleanClass.False;
      JsInstance jsInstance = arguments[0];
      return (JsInstance) this.BooleanClass.New(jsInstance != this.NumberClass["NaN"] && jsInstance != this.NumberClass["POSITIVE_INFINITY"] && jsInstance != this.NumberClass["NEGATIVE_INFINITY"]);
    }

    protected JsInstance DecodeURI(JsInstance[] arguments)
    {
      if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
        return (JsInstance) this.StringClass.New();
      return (JsInstance) this.StringClass.New(Uri.UnescapeDataString(arguments[0].ToString().Replace("+", " ")));
    }

    protected JsInstance EncodeURI(JsInstance[] arguments)
    {
      if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
        return (JsInstance) this.StringClass.New();
      string str = Uri.EscapeDataString(arguments[0].ToString());
      foreach (char ch in JsGlobal.reservedEncoded)
        str = str.Replace(Uri.EscapeDataString(ch.ToString()), ch.ToString());
      foreach (char ch in JsGlobal.reservedEncodedComponent)
        str = str.Replace(Uri.EscapeDataString(ch.ToString()), ch.ToString());
      return (JsInstance) this.StringClass.New(str.ToUpper());
    }

    protected JsInstance DecodeURIComponent(JsInstance[] arguments)
    {
      if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
        return (JsInstance) this.StringClass.New();
      return (JsInstance) this.StringClass.New(Uri.UnescapeDataString(arguments[0].ToString().Replace("+", " ")));
    }

    protected JsInstance EncodeURIComponent(JsInstance[] arguments)
    {
      if (arguments.Length < 1 || arguments[0] == JsUndefined.Instance)
        return (JsInstance) this.StringClass.New();
      string str = Uri.EscapeDataString(arguments[0].ToString());
      foreach (char ch in JsGlobal.reservedEncodedComponent)
        str = str.Replace(Uri.EscapeDataString(ch.ToString()), ch.ToString().ToUpper());
      return (JsInstance) this.StringClass.New(str);
    }

    [Obsolete]
    public JsObject Wrap(object value)
    {
      switch (Convert.GetTypeCode(value))
      {
        case TypeCode.Object:
          return this.ObjectClass.New(value);
        case TypeCode.Boolean:
          return (JsObject) this.BooleanClass.New((bool) value);
        case TypeCode.Char:
        case TypeCode.String:
          return (JsObject) this.StringClass.New(Convert.ToString(value));
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
          return (JsObject) this.NumberClass.New(Convert.ToDouble(value));
        case TypeCode.DateTime:
          return (JsObject) this.DateClass.New((DateTime) value);
        default:
          throw new ArgumentNullException(nameof (value));
      }
    }

    public JsObject WrapClr(object value)
    {
      return (JsObject) this.Marshaller.MarshalClrValue<object>(value);
    }

    public bool HasOption(Options options)
    {
      return (this.Options & options) == options;
    }

    public JsInstance NaN
    {
      get
      {
        return this[nameof (NaN)];
      }
    }
  }
}
