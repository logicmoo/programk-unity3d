// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsArrayConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jint.Native
{
  [Serializable]
  public class JsArrayConstructor : JsConstructor
  {
    public JsArrayConstructor(IGlobal global)
      : base(global)
    {
      this.Name = "Array";
      this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) global.ObjectClass.New((JsFunction) this), PropertyAttributes.ReadOnly | PropertyAttributes.DontEnum | PropertyAttributes.DontDelete);
    }

    public override void InitPrototype(IGlobal global)
    {
      JsObject prototypeProperty = this.PrototypeProperty;
      JsObject jsObject = prototypeProperty;
      PropertyDescriptor<JsObject> propertyDescriptor = new PropertyDescriptor<JsObject>(global, (JsDictionaryObject) prototypeProperty, "length", new Func<JsObject, JsInstance>(this.GetLengthImpl), new Func<JsObject, JsInstance[], JsInstance>(this.SetLengthImpl));
      propertyDescriptor.Enumerable = false;
      jsObject.DefineOwnProperty((Descriptor) propertyDescriptor);
      prototypeProperty.DefineOwnProperty("toString", (JsInstance) global.FunctionClass.New<JsArray>(new Func<JsArray, JsInstance[], JsInstance>(this.ToStringImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("toLocaleString", (JsInstance) global.FunctionClass.New<JsArray>(new Func<JsArray, JsInstance[], JsInstance>(this.ToLocaleStringImpl)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("concat", (JsInstance) global.FunctionClass.New<JsObject>(new Func<JsObject, JsInstance[], JsInstance>(this.Concat)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("join", (JsInstance) global.FunctionClass.New<JsObject>(new Func<JsObject, JsInstance[], JsInstance>(this.Join), 1), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("pop", (JsInstance) global.FunctionClass.New<JsObject>(new Func<JsObject, JsInstance[], JsInstance>(this.Pop)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("push", (JsInstance) global.FunctionClass.New<JsObject>(new Func<JsObject, JsInstance[], JsInstance>(this.Push), 1), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("reverse", (JsInstance) global.FunctionClass.New<JsObject>(new Func<JsObject, JsInstance[], JsInstance>(this.Reverse)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("shift", (JsInstance) global.FunctionClass.New<JsObject>(new Func<JsObject, JsInstance[], JsInstance>(this.Shift)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("slice", (JsInstance) global.FunctionClass.New<JsObject>(new Func<JsObject, JsInstance[], JsInstance>(this.Slice), 2), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("sort", (JsInstance) global.FunctionClass.New<JsObject>(new Func<JsObject, JsInstance[], JsInstance>(this.Sort)), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("splice", (JsInstance) global.FunctionClass.New<JsObject>(new Func<JsObject, JsInstance[], JsInstance>(this.Splice), 2), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("unshift", (JsInstance) global.FunctionClass.New<JsObject>(new Func<JsObject, JsInstance[], JsInstance>(this.UnShift), 1), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("indexOf", (JsInstance) global.FunctionClass.New<JsObject>(new Func<JsObject, JsInstance[], JsInstance>(this.IndexOfImpl), 1), PropertyAttributes.DontEnum);
      prototypeProperty.DefineOwnProperty("lastIndexOf", (JsInstance) global.FunctionClass.New<JsObject>(new Func<JsObject, JsInstance[], JsInstance>(this.LastIndexOfImpl), 1), PropertyAttributes.DontEnum);
    }

    public JsArray New()
    {
      return new JsArray(this.PrototypeProperty);
    }

    public override JsObject Construct(
      JsInstance[] parameters,
      Type[] genericArgs,
      IJintVisitor visitor)
    {
      JsArray jsArray = this.New();
      for (int i = 0; i < parameters.Length; ++i)
        jsArray.put(i, parameters[i]);
      return (JsObject) jsArray;
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      if (that == null || that as IGlobal == visitor.Global)
        return visitor.Return((JsInstance) this.Construct(parameters, (Type[]) null, visitor));
      for (int index = 0; index < parameters.Length; ++index)
        that[index.ToString()] = parameters[index];
      return visitor.Return((JsInstance) that);
    }

    public JsInstance ToStringImpl(JsArray target, JsInstance[] parameters)
    {
      JsArray jsArray = this.Global.ArrayClass.New();
      for (int index = 0; index < target.Length; ++index)
      {
        JsDictionaryObject _this = (JsDictionaryObject) target[index.ToString()];
        if (ExecutionVisitor.IsNullOrUndefined((JsInstance) _this))
        {
          jsArray[index.ToString()] = (JsInstance) this.Global.StringClass.New();
        }
        else
        {
          JsFunction function = _this["toString"] as JsFunction;
          if (function != null)
          {
            this.Global.Visitor.ExecuteFunction(function, _this, parameters);
            jsArray[index.ToString()] = this.Global.Visitor.Returned;
          }
          else
            jsArray[index.ToString()] = (JsInstance) this.Global.StringClass.New();
        }
      }
      return (JsInstance) this.Global.StringClass.New(jsArray.ToString());
    }

    public JsInstance ToLocaleStringImpl(JsArray target, JsInstance[] parameters)
    {
      JsArray jsArray = this.Global.ArrayClass.New();
      for (int index = 0; index < target.Length; ++index)
      {
        JsDictionaryObject _this = (JsDictionaryObject) target[index.ToString()];
        this.Global.Visitor.ExecuteFunction((JsFunction) _this["toLocaleString"], _this, parameters);
        jsArray[index.ToString()] = this.Global.Visitor.Returned;
      }
      return (JsInstance) this.Global.StringClass.New(jsArray.ToString());
    }

    public JsInstance Concat(JsObject target, JsInstance[] parameters)
    {
      if (target is JsArray)
        return (JsInstance) ((JsArray) target).concat(this.Global, parameters);
      JsArray jsArray = this.Global.ArrayClass.New();
      List<JsInstance> jsInstanceList = new List<JsInstance>();
      jsInstanceList.Add((JsInstance) target);
      jsInstanceList.AddRange((IEnumerable<JsInstance>) parameters);
      int i = 0;
      while (jsInstanceList.Count > 0)
      {
        JsInstance jsInstance = jsInstanceList[0];
        jsInstanceList.RemoveAt(0);
        if (this.Global.ArrayClass.HasInstance(jsInstance as JsObject))
        {
          for (int index1 = 0; index1 < ((JsDictionaryObject) jsInstance).Length; ++index1)
          {
            string index2 = index1.ToString();
            JsInstance result = (JsInstance) null;
            if (((JsDictionaryObject) jsInstance).TryGetProperty(index2, out result))
              jsArray.put(i, result);
            ++i;
          }
        }
        else
        {
          jsArray.put(i, jsInstance);
          ++i;
        }
      }
      return (JsInstance) jsArray;
    }

    public JsInstance Join(JsObject target, JsInstance[] parameters)
    {
      if (target is JsArray)
        return (JsInstance) ((JsArray) target).join(this.Global, parameters.Length != 0 ? parameters[0] : (JsInstance) JsUndefined.Instance);
      string str = parameters.Length == 0 || parameters[0] == JsUndefined.Instance ? "," : parameters[0].ToString();
      if (target.Length == 0)
        return (JsInstance) this.Global.StringClass.New();
      JsInstance jsInstance1 = target[0.ToString()];
      StringBuilder stringBuilder = jsInstance1 != JsUndefined.Instance && jsInstance1 != JsNull.Instance ? new StringBuilder(jsInstance1.ToString()) : new StringBuilder(string.Empty);
      double number = target["length"].ToNumber();
      for (int index = 1; (double) index < number; ++index)
      {
        stringBuilder.Append(str);
        JsInstance jsInstance2 = target[index.ToString()];
        if (jsInstance2 != JsUndefined.Instance && jsInstance2 != JsNull.Instance)
          stringBuilder.Append(jsInstance2.ToString());
      }
      return (JsInstance) this.Global.StringClass.New(stringBuilder.ToString());
    }

    public JsInstance Pop(JsObject target, JsInstance[] parameters)
    {
      uint uint32 = Convert.ToUInt32(target.Length);
      if (uint32 == 0U)
        return (JsInstance) JsUndefined.Instance;
      string index = (uint32 - 1U).ToString();
      JsInstance jsInstance = target[index];
      target.Delete(index);
      --target.Length;
      return jsInstance;
    }

    public JsInstance Push(JsDictionaryObject target, JsInstance[] parameters)
    {
      int number = (int) target["length"].ToNumber();
      foreach (JsInstance parameter in parameters)
      {
        target[(JsInstance) this.Global.NumberClass.New((double) number)] = parameter;
        ++number;
      }
      return (JsInstance) this.Global.NumberClass.New((double) number);
    }

    public JsInstance Reverse(JsObject target, JsInstance[] parameters)
    {
      int length = target.Length;
      int num = length / 2;
      for (int index1 = 0; index1 != num; ++index1)
      {
        string index2 = (length - index1 - 1).ToString();
        string index3 = index1.ToString();
        JsInstance result1 = (JsInstance) null;
        JsInstance result2 = (JsInstance) null;
        bool property1 = target.TryGetProperty(index3, out result1);
        bool property2 = target.TryGetProperty(index2, out result2);
        if (property1)
          target[index2] = result1;
        else
          target.Delete(index2);
        if (property2)
          target[index3] = result2;
        else
          target.Delete(index3);
      }
      return (JsInstance) target;
    }

    public JsInstance Shift(JsDictionaryObject target, JsInstance[] parameters)
    {
      if (target.Length == 0)
        return (JsInstance) JsUndefined.Instance;
      JsInstance jsInstance = target[0.ToString()];
      int num;
      for (int index1 = 1; index1 < target.Length; ++index1)
      {
        JsInstance result = (JsInstance) null;
        string index2 = index1.ToString();
        num = index1 - 1;
        string index3 = num.ToString();
        if (target.TryGetProperty(index2, out result))
          target[index3] = result;
        else
          target.Delete(index3);
      }
      JsDictionaryObject dictionaryObject = target;
      num = target.Length - 1;
      string index = num.ToString();
      dictionaryObject.Delete(index);
      num = target.Length--;
      return jsInstance;
    }

    public JsInstance Slice(JsObject target, JsInstance[] parameters)
    {
      int num1 = (int) parameters[0].ToNumber();
      int num2 = target.Length;
      if (parameters.Length > 1)
        num2 = (int) parameters[1].ToNumber();
      if (num1 < 0)
        num1 += target.Length;
      if (num2 < 0)
        num2 += target.Length;
      if (num1 > target.Length)
        num1 = target.Length;
      if (num2 > target.Length)
        num2 = target.Length;
      JsArray jsArray = this.Global.ArrayClass.New();
      for (int index = num1; index < num2; ++index)
        this.Push((JsDictionaryObject) jsArray, new JsInstance[1]
        {
          target[(JsInstance) this.Global.NumberClass.New((double) index)]
        });
      return (JsInstance) jsArray;
    }

    public JsInstance Sort(JsObject target, JsInstance[] parameters)
    {
      if (target.Length <= 1)
        return (JsInstance) target;
      JsFunction function = (JsFunction) null;
      if ((uint) parameters.Length > 0U)
        function = parameters[0] as JsFunction;
      List<JsInstance> jsInstanceList = new List<JsInstance>();
      int number = (int) target["length"].ToNumber();
      for (int index = 0; index < number; ++index)
        jsInstanceList.Add(target[index.ToString()]);
      if (function != null)
      {
        try
        {
          jsInstanceList.Sort((IComparer<JsInstance>) new JsComparer(this.Global.Visitor, function));
        }
        catch (Exception ex)
        {
          if (ex.InnerException is JsException)
            throw ex.InnerException;
          throw;
        }
      }
      else
        jsInstanceList.Sort();
      for (int index = 0; index < number; ++index)
        target[index.ToString()] = jsInstanceList[index];
      return (JsInstance) target;
    }

    public JsInstance Splice(JsObject target, JsInstance[] parameters)
    {
      JsArray jsArray = this.Global.ArrayClass.New();
      int int32 = Convert.ToInt32(parameters[0].ToNumber());
      int num1 = int32 < 0 ? Math.Max(target.Length + int32, 0) : Math.Min(int32, target.Length);
      int num2 = Math.Min(Math.Max(Convert.ToInt32(parameters[1].ToNumber()), 0), target.Length - num1);
      int length1 = target.Length;
      int num3;
      for (int i = 0; i < num2; ++i)
      {
        num3 = int32 + i;
        string index = num3.ToString();
        JsInstance result = (JsInstance) null;
        if (target.TryGetProperty(index, out result))
          jsArray.put(i, result);
      }
      List<JsInstance> jsInstanceList = new List<JsInstance>();
      jsInstanceList.AddRange((IEnumerable<JsInstance>) parameters);
      jsInstanceList.RemoveAt(0);
      jsInstanceList.RemoveAt(0);
      if (jsInstanceList.Count < num2)
      {
        for (int index1 = num1; index1 < length1 - num2; ++index1)
        {
          JsInstance result = (JsInstance) null;
          num3 = index1 + num2;
          string index2 = num3.ToString();
          num3 = index1 + jsInstanceList.Count;
          string index3 = num3.ToString();
          if (target.TryGetProperty(index2, out result))
            target[index3] = result;
          else
            target.Delete(index3);
        }
        for (int length2 = target.Length; length2 > length1 - num2 + jsInstanceList.Count; --length2)
        {
          JsObject jsObject = target;
          num3 = length2 - 1;
          string index = num3.ToString();
          jsObject.Delete(index);
        }
        target.Length = length1 - num2 + jsInstanceList.Count;
      }
      else
      {
        for (int index1 = length1 - num2; index1 > num1; --index1)
        {
          JsInstance result = (JsInstance) null;
          num3 = index1 + num2 - 1;
          string index2 = num3.ToString();
          num3 = index1 + jsInstanceList.Count - 1;
          string index3 = num3.ToString();
          if (target.TryGetProperty(index2, out result))
            target[index3] = result;
          else
            target.Delete(index3);
        }
      }
      for (int index = 0; index < jsInstanceList.Count; ++index)
        target[index.ToString()] = jsInstanceList[index];
      return (JsInstance) jsArray;
    }

    public JsInstance UnShift(JsObject target, JsInstance[] parameters)
    {
      for (int length = target.Length; length > 0; --length)
      {
        JsInstance result = (JsInstance) null;
        int num = length - 1;
        string index1 = num.ToString();
        num = length + parameters.Length - 1;
        string index2 = num.ToString();
        if (target.TryGetProperty(index1, out result))
          target[index2] = result;
        else
          target.Delete(index2);
      }
      List<JsInstance> jsInstanceList = new List<JsInstance>((IEnumerable<JsInstance>) parameters);
      int num1 = 0;
      while (jsInstanceList.Count > 0)
      {
        JsInstance jsInstance = jsInstanceList[0];
        jsInstanceList.RemoveAt(0);
        target[num1.ToString()] = jsInstance;
        ++num1;
      }
      return (JsInstance) this.Global.NumberClass.New((double) target.Length);
    }

    public JsInstance LastIndexOfImpl(JsObject target, JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        return (JsInstance) this.Global.NumberClass.New(-1.0);
      int length = target.Length;
      if (length == 0)
        return (JsInstance) this.Global.NumberClass.New(-1.0);
      int val1 = length;
      if (parameters.Length > 1)
        val1 = Convert.ToInt32(parameters[1].ToNumber());
      JsInstance parameter = parameters[0];
      for (int index = val1 < 0 ? length - Math.Abs(val1 - 1) : Math.Min(val1, length - 1); index >= 0; --index)
      {
        JsInstance result = (JsInstance) null;
        if (target.TryGetProperty(index.ToString(), out result) && result == parameter)
          return (JsInstance) this.Global.NumberClass.New((double) index);
      }
      return (JsInstance) this.Global.NumberClass.New(-1.0);
    }

    public JsInstance IndexOfImpl(JsObject target, JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        return (JsInstance) this.Global.NumberClass.New(-1.0);
      int number = (int) target["length"].ToNumber();
      if (number == 0)
        return (JsInstance) this.Global.NumberClass.New(-1.0);
      int num = 0;
      if (parameters.Length > 1)
        num = Convert.ToInt32(parameters[1].ToNumber());
      if (num >= number)
        return (JsInstance) this.Global.NumberClass.New(-1.0);
      JsInstance parameter = parameters[0];
      for (int index = num < 0 ? number - Math.Abs(num) : num; index < number; ++index)
      {
        JsInstance result = (JsInstance) null;
        if (target.TryGetProperty(index.ToString(), out result) && result == parameter)
          return (JsInstance) this.Global.NumberClass.New((double) index);
      }
      return (JsInstance) this.Global.NumberClass.New(-1.0);
    }

    private JsInstance GetLengthImpl(JsObject that)
    {
      return (JsInstance) this.Global.NumberClass.New((double) that.Length);
    }

    private JsInstance SetLengthImpl(JsObject that, JsInstance[] parameters)
    {
      if (that is JsArray)
      {
        that.Length = (int) parameters[0].ToNumber();
      }
      else
      {
        int length1 = that.Length;
        that.Length = (int) parameters[0].ToNumber();
        for (int length2 = that.Length; length2 < length1; ++length2)
          that.Delete((JsInstance) this.Global.NumberClass.New((double) length2));
      }
      return parameters[0];
    }
  }
}
