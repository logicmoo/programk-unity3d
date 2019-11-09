// Decompiled with JetBrains decompiler
// Type: Jint.Marshaller
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using Jint.Marshal;
using Jint.Native;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Jint
{
  public class Marshaller
  {
    private static bool[,] IntegralTypeConvertions = new bool[19, 19]{ { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }, { false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, true }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true }, { false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, false, false, true }, { false, false, false, true, true, true, true, true, true, true, true, true, true, false, false, false, false, false, true }, { false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, false, false, true }, { false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, false, false, true }, { false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, false, false, true }, { false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, false, false, true }, { false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, false, false, true }, { false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, false, false, true }, { false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, false, false, true }, { false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, false, false, true }, { false, false, false, true, false, true, true, true, true, true, true, true, true, true, true, true, false, false, true }, { false, false, false, true, false, true, true, true, true, true, true, true, true, true, true, true, false, false, true }, { false, false, false, true, false, true, true, true, true, true, true, true, true, true, true, true, false, false, true }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, false, true }, { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false }, { false, false, false, true, true, true, true, true, true, true, true, true, true, true, true, true, true, false, true } };
    private Dictionary<Type, NativeConstructor> m_typeCache = new Dictionary<Type, NativeConstructor>();
    private Dictionary<Type, Delegate> m_arrayMarshllers = new Dictionary<Type, Delegate>();
    private IGlobal m_global;
    private NativeTypeConstructor m_typeType;

    public Marshaller(IGlobal global)
    {
      this.m_global = global;
    }

    public void InitTypes()
    {
      this.m_typeType = NativeTypeConstructor.CreateNativeTypeConstructor(this.m_global);
      this.m_typeCache[typeof (Type)] = (NativeConstructor) this.m_typeType;
      Type[] typeArray = new Type[10]{ typeof (short), typeof (int), typeof (long), typeof (ushort), typeof (uint), typeof (ulong), typeof (float), typeof (double), typeof (byte), typeof (sbyte) };
      foreach (Type t in typeArray)
        this.m_typeCache[t] = this.CreateConstructor(t, this.m_global.NumberClass.PrototypeProperty);
      this.m_typeCache[typeof (string)] = this.CreateConstructor(typeof (string), this.m_global.StringClass.PrototypeProperty);
      this.m_typeCache[typeof (char)] = this.CreateConstructor(typeof (char), this.m_global.StringClass.PrototypeProperty);
      this.m_typeCache[typeof (bool)] = this.CreateConstructor(typeof (bool), this.m_global.BooleanClass.PrototypeProperty);
      this.m_typeCache[typeof (DateTime)] = this.CreateConstructor(typeof (DateTime), this.m_global.DateClass.PrototypeProperty);
      this.m_typeCache[typeof (Regex)] = this.CreateConstructor(typeof (Regex), this.m_global.RegExpClass.PrototypeProperty);
    }

    public JsInstance MarshalClrValue<T>(T value)
    {
      if ((object) value == null)
        return (JsInstance) JsNull.Instance;
      if ((object) value is JsInstance)
        return (object) value as JsInstance;
      if (!((object) value is Type))
        return this.MarshalType(value.GetType()).Wrap<T>(value);
      Type reflectedType = (object) value as Type;
      if (!reflectedType.IsGenericTypeDefinition)
        return (JsInstance) this.MarshalType((object) value as Type);
      NativeGenericType nativeGenericType = new NativeGenericType(reflectedType, this.m_typeType.PrototypeProperty);
      this.m_typeType.SetupNativeProperties((JsDictionaryObject) nativeGenericType);
      return (JsInstance) nativeGenericType;
    }

    public JsConstructor MarshalType(Type t)
    {
      NativeConstructor nativeConstructor;
      if (this.m_typeCache.TryGetValue(t, out nativeConstructor))
        return (JsConstructor) nativeConstructor;
      return (JsConstructor) (this.m_typeCache[t] = this.CreateConstructor(t));
    }

    private NativeConstructor CreateConstructor(Type t)
    {
      return (NativeConstructor) this.m_typeType.Wrap<Type>(t);
    }

    private NativeConstructor CreateConstructor(
      Type t,
      JsObject prototypePropertyPrototype)
    {
      return (NativeConstructor) this.m_typeType.WrapSpecialType(t, prototypePropertyPrototype);
    }

    private TElem[] MarshalJsArrayHelper<TElem>(JsObject value)
    {
      int length = (int) value["length"].ToNumber();
      if (length < 0)
        length = 0;
      TElem[] elemArray = new TElem[length];
      for (int num = 0; num < length; ++num)
        elemArray[num] = this.MarshalJsValue<TElem>(value[(JsInstance) new JsNumber(num, (JsObject) JsUndefined.Instance)]);
      return elemArray;
    }

    private object MarshalJsFunctionHelper(JsFunction func, Type delegateType)
    {
      return (object) new JsFunctionDelegate((IJintVisitor) new ExecutionVisitor(this.m_global, new JsScope((JsDictionaryObject) this.m_global)) { PermissionSet = ((ExecutionVisitor) this.m_global.Visitor).PermissionSet }, func, (JsDictionaryObject) JsNull.Instance, delegateType).GetDelegate();
    }

    public T MarshalJsValue<T>(JsInstance value)
    {
      if (value.Value is T)
        return (T) value.Value;
      if (typeof (T).IsArray)
      {
        if (value == null || value == JsUndefined.Instance || value == JsNull.Instance)
          return default (T);
        if (!this.m_global.ArrayClass.HasInstance(value as JsObject))
          throw new JintException("Array is required");
        Delegate delegate1;
        if (!this.m_arrayMarshllers.TryGetValue(typeof (T), out delegate1))
        {
          Dictionary<Type, Delegate> arrayMarshllers = this.m_arrayMarshllers;
          Type index = typeof (T);
          Type type = typeof (Func<JsObject, T>);
          MethodInfo method = typeof (Marshaller).GetMethod("MarshalJsFunctionHelper").MakeGenericMethod(typeof (T).GetElementType());
          Delegate delegate2;
          delegate1 = delegate2 = Delegate.CreateDelegate(type, (object) this, method);
          arrayMarshllers[index] = delegate2;
        }
        return ((Func<JsObject, T>) delegate1)(value as JsObject);
      }
      if (typeof (Delegate).IsAssignableFrom(typeof (T)))
      {
        if (value == null || value == JsUndefined.Instance || value == JsNull.Instance)
          return default (T);
        if (!(value is JsFunction))
          throw new JintException("Can't convert a non function object to a delegate type");
        return (T) this.MarshalJsFunctionHelper(value as JsFunction, typeof (T));
      }
      if (value != JsNull.Instance && value != JsUndefined.Instance && value is T)
        return (T) value;
      return (T) Convert.ChangeType(value.Value, typeof (T));
    }

    public object MarshalJsValueBoxed<T>(JsInstance value)
    {
      if (value.Value is T)
        return value.Value;
      return (object) null;
    }

    public Type GetInstanceType(JsInstance value)
    {
      if (value == null || value == JsUndefined.Instance || value == JsNull.Instance)
        return (Type) null;
      if (value.Value != null)
        return value.Value.GetType();
      return value.GetType();
    }

    public JsMethodImpl WrapMethod(MethodInfo info, bool passGlobal)
    {
      return ProxyHelper.Default.WrapMethod(info, passGlobal);
    }

    public ConstructorImpl WrapConstructor(ConstructorInfo info, bool passGlobal)
    {
      return ProxyHelper.Default.WrapConstructor(info, passGlobal);
    }

    public JsGetter WrapGetProperty(PropertyInfo prop)
    {
      return ProxyHelper.Default.WrapGetProperty(prop, this);
    }

    public JsGetter WrapGetField(FieldInfo field)
    {
      return ProxyHelper.Default.WrapGetField(field, this);
    }

    public JsSetter WrapSetProperty(PropertyInfo prop)
    {
      return ProxyHelper.Default.WrapSetProperty(prop, this);
    }

    public JsSetter WrapSetField(FieldInfo field)
    {
      return ProxyHelper.Default.WrapSetField(field, this);
    }

    public JsIndexerGetter WrapIndexerGetter(MethodInfo getMethod)
    {
      return ProxyHelper.Default.WrapIndexerGetter(getMethod, this);
    }

    public JsIndexerSetter WrapIndexerSetter(MethodInfo setMethod)
    {
      return ProxyHelper.Default.WrapIndexerSetter(setMethod, this);
    }

    public NativeDescriptor MarshalPropertyInfo(
      PropertyInfo prop,
      JsDictionaryObject owner)
    {
      JsSetter setter = (JsSetter) null;
      JsGetter getter = !prop.CanRead || prop.GetGetMethod() == null ? (JsGetter) (that => (JsInstance) JsUndefined.Instance) : this.WrapGetProperty(prop);
      if (prop.CanWrite && prop.GetSetMethod() != null)
        setter = this.WrapSetProperty(prop);
      NativeDescriptor nativeDescriptor1;
      if (setter != null)
      {
        NativeDescriptor nativeDescriptor2 = new NativeDescriptor(owner, prop.Name, getter, setter);
        nativeDescriptor2.Enumerable = true;
        nativeDescriptor1 = nativeDescriptor2;
      }
      else
      {
        nativeDescriptor1 = new NativeDescriptor(owner, prop.Name, getter);
        nativeDescriptor1.Enumerable = true;
      }
      return nativeDescriptor1;
    }

    public NativeDescriptor MarshalFieldInfo(
      FieldInfo prop,
      JsDictionaryObject owner)
    {
      JsGetter getter;
      JsSetter setter;
      if (prop.IsLiteral)
      {
        JsInstance value = (JsInstance) null;
        getter = (JsGetter) (that =>
        {
          if (value == null)
            value = (JsInstance) typeof (Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(prop.FieldType).Invoke((object) this, new object[1]
            {
              prop.GetValue((object) null)
            });
          return value;
        });
        setter = (JsSetter) ((that, v) => {});
      }
      else
      {
        getter = this.WrapGetField(prop);
        setter = this.WrapSetField(prop);
      }
      NativeDescriptor nativeDescriptor = new NativeDescriptor(owner, prop.Name, getter, setter);
      nativeDescriptor.Enumerable = true;
      return nativeDescriptor;
    }

    public bool IsAssignable(Type target, Type source)
    {
      return typeof (IConvertible).IsAssignableFrom(source) && Marshaller.IntegralTypeConvertions[(int) Type.GetTypeCode(source), (int) Type.GetTypeCode(target)] || target.IsAssignableFrom(source);
    }
  }
}
