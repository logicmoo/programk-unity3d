// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsRegExpConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;
using System.Text.RegularExpressions;

namespace Jint.Native
{
  [Serializable]
  public class JsRegExpConstructor : JsConstructor
  {
    public JsRegExpConstructor(IGlobal global)
      : base(global)
    {
      this.Name = "RegExp";
      this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) global.ObjectClass.New((JsFunction) this), PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
    }

    public override void InitPrototype(IGlobal global)
    {
      JsObject prototypeProperty = this.PrototypeProperty;
      prototypeProperty.DefineOwnProperty("toString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toLocaleString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("lastIndex", (JsInstance) global.FunctionClass.New<JsRegExp>(new Func<JsRegExp, JsInstance[], JsInstance>(this.GetLastIndex)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("exec", (JsInstance) global.FunctionClass.New<JsRegExp>(new Func<JsRegExp, JsInstance[], JsInstance>(this.ExecImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("test", (JsInstance) global.FunctionClass.New<JsRegExp>(new Func<JsRegExp, JsInstance[], JsInstance>(this.TestImpl)), PropertyAttributes.DontEnum);
    }

    public JsInstance GetLastIndex(JsRegExp regex, JsInstance[] parameters)
    {
      return regex["lastIndex"];
    }

    public JsRegExp New()
    {
      return this.New(string.Empty, false, false, false);
    }

    public JsRegExp New(string pattern, bool g, bool i, bool m)
    {
      JsRegExp jsRegExp = new JsRegExp(pattern, g, i, m, this.PrototypeProperty);
      jsRegExp["source"] = (JsInstance) this.Global.StringClass.New(pattern);
      jsRegExp["lastIndex"] = (JsInstance) this.Global.NumberClass.New(0.0);
      jsRegExp["global"] = (JsInstance) this.Global.BooleanClass.New(g);
      return jsRegExp;
    }

    public JsInstance ExecImpl(JsRegExp regexp, JsInstance[] parameters)
    {
      JsArray jsArray = this.Global.ArrayClass.New();
      string input = parameters[0].ToString();
      jsArray["input"] = (JsInstance) this.Global.StringClass.New(input);
      int num = 0;
      MatchCollection matchCollection = Regex.Matches(input, regexp.Pattern, regexp.Options);
      if (matchCollection.Count > 0)
      {
        if (regexp.IsGlobal)
        {
          foreach (Match match in matchCollection)
            jsArray[(JsInstance) this.Global.NumberClass.New((double) num++)] = (JsInstance) this.Global.StringClass.New(match.Value);
        }
        else
        {
          foreach (Group group in matchCollection[0].Groups)
            jsArray[(JsInstance) this.Global.NumberClass.New((double) num++)] = (JsInstance) this.Global.StringClass.New(group.Value);
        }
        jsArray["index"] = (JsInstance) this.Global.NumberClass.New((double) matchCollection[0].Index);
      }
      return (JsInstance) jsArray;
    }

    public JsInstance TestImpl(JsRegExp regex, JsInstance[] parameters)
    {
      return (JsInstance) this.Global.BooleanClass.New(this.ExecImpl(regex, parameters) != JsNull.Instance);
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        return visitor.Return((JsInstance) this.New());
      return visitor.Return((JsInstance) this.New(parameters[0].ToString(), false, false, false));
    }

    public JsInstance ToStringImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      return (JsInstance) this.Global.StringClass.New(target.ToString());
    }
  }
}
