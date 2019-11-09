// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsStringConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Jint.Native
{
  [Serializable]
  public class JsStringConstructor : JsConstructor
  {
    public JsStringConstructor(IGlobal global)
      : base(global)
    {
      this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) global.ObjectClass.New((JsFunction) this), PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
      this.Name = "String";
      this["fromCharCode"] = (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.FromCharCodeImpl));
    }

    public override void InitPrototype(IGlobal global)
    {
      JsObject prototypeProperty = this.PrototypeProperty;
      prototypeProperty.DefineOwnProperty("split", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SplitImpl), 2), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("replace", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ReplaceImpl), 2), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toLocaleString", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("match", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.MatchFunc)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("localeCompare", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.LocaleCompareImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("substring", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SubstringImpl), 2), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("substr", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SubstrImpl), 2), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("search", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SearchImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("valueOf", (JsInstance) global.FunctionClass.New<JsString>(new Func<JsString, JsInstance[], JsInstance>(this.ValueOfImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("concat", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ConcatImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("charAt", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.CharAtImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("charCodeAt", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.CharCodeAtImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("lastIndexOf", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.LastIndexOfImpl), 1), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("indexOf", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.IndexOfImpl), 1), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toLowerCase", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToLowerCaseImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toLocaleLowerCase", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToLocaleLowerCaseImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toUpperCase", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToUpperCaseImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toLocaleUpperCase", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.ToLocaleUpperCaseImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("slice", (JsInstance) global.FunctionClass.New<JsDictionaryObject>(new Func<JsDictionaryObject, JsInstance[], JsInstance>(this.SliceImpl), 2), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty((Descriptor) new PropertyDescriptor<JsDictionaryObject>(global, (JsDictionaryObject) prototypeProperty, "length", new Func<JsDictionaryObject, JsInstance>(this.LengthImpl)));
    }

    public JsString New()
    {
      return this.New(string.Empty);
    }

    public JsString New(string value)
    {
      return new JsString(value, this.PrototypeProperty);
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      if (that == null || that as IGlobal == visitor.Global)
      {
        if ((uint) parameters.Length > 0U)
          return visitor.Return((JsInstance) this.Global.StringClass.New(parameters[0].ToString()));
        return visitor.Return((JsInstance) this.Global.StringClass.New(string.Empty));
      }
      if ((uint) parameters.Length > 0U)
        that.Value = (object) parameters[0].ToString();
      else
        that.Value = (object) string.Empty;
      return visitor.Return((JsInstance) that);
    }

    private static string EvaluateReplacePattern(
      string matched,
      string before,
      string after,
      string newString,
      GroupCollection groups)
    {
      if (newString.Contains("$"))
        return new Regex("\\$\\$|\\$&|\\$`|\\$'|\\$\\d{1,2}", RegexOptions.Compiled).Replace(newString, (MatchEvaluator) (m =>
        {
          string str = m.Value;
          if (str == "$$")
            return "$";
          if (str == "$&")
            return matched;
          if (str == "$`")
            return before;
          if (str == "$'")
            return after;
          int index = int.Parse(m.Value.Substring(1));
          return index == 0 ? m.Value : groups[index].Value;
        }));
      return newString;
    }

    public JsInstance ToStringImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      return (JsInstance) this.Global.StringClass.New(target.ToString());
    }

    public JsInstance ValueOfImpl(JsString target, JsInstance[] parameters)
    {
      return (JsInstance) this.Global.StringClass.New(target.ToString());
    }

    public JsInstance CharAtImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      return this.SubstringImpl(target, new JsInstance[2]{ parameters[0], (JsInstance) this.Global.NumberClass.New(parameters[0].ToNumber() + 1.0) });
    }

    public JsInstance CharCodeAtImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      string str = target.ToString();
      int number = (int) parameters[0].ToNumber();
      if (str == string.Empty || number > str.Length - 1)
        return this.Global.NaN;
      return (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt32(str[number]));
    }

    public JsInstance FromCharCodeImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      string empty = string.Empty;
      foreach (JsInstance parameter in parameters)
        empty += Convert.ToChar(Convert.ToUInt32(parameter.ToNumber())).ToString();
      return (JsInstance) this.Global.StringClass.New(empty);
    }

    public JsInstance ConcatImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(target.ToString());
      for (int index = 0; index < parameters.Length; ++index)
        stringBuilder.Append(parameters[index].ToString());
      return (JsInstance) this.Global.StringClass.New(stringBuilder.ToString());
    }

    public JsInstance IndexOfImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      string str1 = target.ToString();
      string str2 = parameters[0].ToString();
      int num = parameters.Length > 1 ? (int) parameters[1].ToNumber() : 0;
      if (str2 == string.Empty)
      {
        if (parameters.Length > 1)
          return (JsInstance) this.Global.NumberClass.New((double) Math.Min(str1.Length, num));
        return (JsInstance) this.Global.NumberClass.New(0.0);
      }
      if (num >= str1.Length)
        return (JsInstance) this.Global.NumberClass.New(-1.0);
      return (JsInstance) this.Global.NumberClass.New((double) str1.IndexOf(str2, num));
    }

    public JsInstance LastIndexOfImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      string str1 = target.ToString();
      string str2 = parameters[0].ToString();
      int length = parameters.Length > 1 ? (int) parameters[1].ToNumber() : str1.Length;
      return (JsInstance) this.Global.NumberClass.New((double) str1.Substring(0, length).LastIndexOf(str2));
    }

    public JsInstance LocaleCompareImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      return (JsInstance) this.Global.NumberClass.New((double) target.ToString().CompareTo(parameters[0].ToString()));
    }

    public JsInstance MatchFunc(JsDictionaryObject target, JsInstance[] parameters)
    {
      return this.Global.RegExpClass.ExecImpl(parameters[0].Class == "String" ? this.Global.RegExpClass.New(parameters[0].ToString(), false, false, false) : (JsRegExp) parameters[0], new JsInstance[1]{ (JsInstance) target });
    }

    public JsInstance ReplaceImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        return (JsInstance) this.Global.StringClass.New(target.ToString());
      JsInstance parameter = parameters[0];
      JsInstance jsInstance = (JsInstance) JsUndefined.Instance;
      if (parameters.Length > 1)
        jsInstance = parameters[1];
      string source = target.ToString();
      JsFunction function = jsInstance as JsFunction;
      if (parameter.Class == "RegExp")
      {
        int count = ((JsRegExp) parameters[0]).IsGlobal ? int.MaxValue : 1;
        JsRegExp regexp = (JsRegExp) parameters[0];
        int startat = regexp.IsGlobal ? 0 : Math.Max(0, (int) regexp["lastIndex"].ToNumber() - 1);
        if (regexp.IsGlobal)
          regexp["lastIndex"] = (JsInstance) this.Global.NumberClass.New(0.0);
        if (jsInstance is JsFunction)
          return (JsInstance) this.Global.StringClass.New(((JsRegExp) parameters[0]).Regex.Replace(source, (MatchEvaluator) (m =>
          {
            List<JsInstance> jsInstanceList = new List<JsInstance>();
            if (!regexp.IsGlobal)
              regexp["lastIndex"] = (JsInstance) this.Global.NumberClass.New((double) (m.Index + 1));
            jsInstanceList.Add((JsInstance) this.Global.StringClass.New(m.Value));
            for (int index = 1; index < m.Groups.Count; ++index)
            {
              if (m.Groups[index].Success)
                jsInstanceList.Add((JsInstance) this.Global.StringClass.New(m.Groups[index].Value));
              else
                jsInstanceList.Add((JsInstance) JsUndefined.Instance);
            }
            jsInstanceList.Add((JsInstance) this.Global.NumberClass.New((double) m.Index));
            jsInstanceList.Add((JsInstance) this.Global.StringClass.New(source));
            this.Global.Visitor.ExecuteFunction(function, (JsDictionaryObject) null, jsInstanceList.ToArray());
            return this.Global.Visitor.Returned.ToString();
          }), count, startat));
        string str = parameters[1].ToString();
        return (JsInstance) this.Global.StringClass.New(((JsRegExp) parameters[0]).Regex.Replace(target.ToString(), (MatchEvaluator) (m =>
        {
          if (!regexp.IsGlobal)
            regexp["lastIndex"] = (JsInstance) this.Global.NumberClass.New((double) (m.Index + 1));
          string after = source.Substring(Math.Min(source.Length - 1, m.Index + m.Length));
          return JsStringConstructor.EvaluateReplacePattern(m.Value, source.Substring(0, m.Index), after, str, m.Groups);
        }), count, startat));
      }
      string matched = parameter.ToString();
      int length = source.IndexOf(matched);
      if (length == -1)
        return (JsInstance) this.Global.StringClass.New(source);
      if (jsInstance is JsFunction)
      {
        this.Global.Visitor.ExecuteFunction(function, (JsDictionaryObject) null, new List<JsInstance>()
        {
          (JsInstance) this.Global.StringClass.New(matched),
          (JsInstance) this.Global.NumberClass.New((double) length),
          (JsInstance) this.Global.StringClass.New(source)
        }.ToArray());
        JsInstance result = this.Global.Visitor.Result;
        return (JsInstance) this.Global.StringClass.New(source.Substring(0, length) + result.ToString() + source.Substring(length + matched.Length));
      }
      string before = source.Substring(0, length);
      string after1 = source.Substring(length + matched.Length);
      string replacePattern = JsStringConstructor.EvaluateReplacePattern(matched, before, after1, jsInstance.ToString(), (GroupCollection) null);
      return (JsInstance) this.Global.StringClass.New(before + replacePattern + after1);
    }

    public JsInstance SearchImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (parameters[0].Class == "String")
        parameters[0] = (JsInstance) this.Global.RegExpClass.New(parameters[0].ToString(), false, false, false);
      Match match = ((JsRegExp) parameters[0]).Regex.Match(target.ToString());
      if (match != null && match.Success)
        return (JsInstance) this.Global.NumberClass.New((double) match.Index);
      return (JsInstance) this.Global.NumberClass.New(-1.0);
    }

    public JsInstance SliceImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      string str = target.ToString();
      int startIndex = (int) parameters[0].ToNumber();
      int num = str.Length;
      if (parameters.Length > 1)
      {
        num = (int) parameters[1].ToNumber();
        if (num < 0)
          num = str.Length + num;
      }
      if (startIndex < 0)
        startIndex = str.Length + startIndex;
      return (JsInstance) this.Global.StringClass.New(str.Substring(startIndex, num - startIndex));
    }

    public JsInstance SplitImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      JsObject jsObject = (JsObject) this.Global.ArrayClass.New();
      string input = target.ToString();
      if (parameters.Length == 0 || parameters[0] == JsUndefined.Instance)
        jsObject["0"] = (JsInstance) this.Global.StringClass.New(input);
      JsInstance parameter = parameters[0];
      int count = parameters.Length > 1 ? Convert.ToInt32(parameters[1].ToNumber()) : int.MaxValue;
      int length = input.Length;
      string[] strArray;
      if (parameter.Class == "RegExp")
        strArray = ((JsRegExp) parameters[0]).Regex.Split(input, count);
      else
        strArray = input.Split(new string[1]
        {
          parameter.ToString()
        }, count, StringSplitOptions.None);
      for (int index = 0; index < strArray.Length; ++index)
        jsObject[index.ToString()] = (JsInstance) this.Global.StringClass.New(strArray[index]);
      return (JsInstance) jsObject;
    }

    public JsInstance SubstringImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      string str = target.ToString();
      int val1_1 = 0;
      int val1_2 = str.Length;
      if (parameters.Length != 0 && !double.IsNaN(parameters[0].ToNumber()))
        val1_1 = Convert.ToInt32(parameters[0].ToNumber());
      if (parameters.Length > 1 && parameters[1] != JsUndefined.Instance && !double.IsNaN(parameters[1].ToNumber()))
        val1_2 = Convert.ToInt32(parameters[1].ToNumber());
      int startIndex = Math.Min(Math.Max(val1_1, 0), Math.Max(0, str.Length - 1));
      int num = Math.Min(Math.Max(val1_2, 0), str.Length);
      return (JsInstance) this.New(str.Substring(startIndex, num - startIndex));
    }

    public JsInstance SubstrImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      string str = target.ToString();
      int val1_1 = 0;
      int val1_2 = str.Length;
      if (parameters.Length != 0 && !double.IsNaN(parameters[0].ToNumber()))
        val1_1 = Convert.ToInt32(parameters[0].ToNumber());
      if (parameters.Length > 1 && parameters[1] != JsUndefined.Instance && !double.IsNaN(parameters[1].ToNumber()))
        val1_2 = Convert.ToInt32(parameters[1].ToNumber());
      int startIndex = Math.Min(Math.Max(val1_1, 0), Math.Max(0, str.Length - 1));
      int length = Math.Min(Math.Max(val1_2, 0), str.Length);
      return (JsInstance) this.New(str.Substring(startIndex, length));
    }

    public JsInstance ToLowerCaseImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      return (JsInstance) this.Global.StringClass.New(target.ToString().ToLowerInvariant());
    }

    public JsInstance ToLocaleLowerCaseImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      return (JsInstance) this.Global.StringClass.New(target.ToString().ToLower());
    }

    public JsInstance ToUpperCaseImpl(JsDictionaryObject target, JsInstance[] parameters)
    {
      return (JsInstance) this.Global.StringClass.New(target.ToString().ToUpperInvariant());
    }

    public JsInstance ToLocaleUpperCaseImpl(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      return (JsInstance) this.Global.StringClass.New(target.ToString().ToUpper());
    }

    public JsInstance LengthImpl(JsDictionaryObject target)
    {
      return (JsInstance) this.Global.NumberClass.New((double) target.ToString().Length);
    }
  }
}
