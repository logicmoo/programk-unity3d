// Decompiled with JetBrains decompiler
// Type: Jint.Marshal.ProxyHelper
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Native;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace Jint.Marshal
{
  internal class ProxyHelper
  {
    private Dictionary<MethodInfo, JsMethodImpl> methodCache = new Dictionary<MethodInfo, JsMethodImpl>();
    private Dictionary<ConstructorInfo, ConstructorImpl> ctorCache = new Dictionary<ConstructorInfo, ConstructorImpl>();
    private Dictionary<PropertyInfo, DynamicMethod> propGetCache = new Dictionary<PropertyInfo, DynamicMethod>();
    private Dictionary<PropertyInfo, DynamicMethod> propSetCache = new Dictionary<PropertyInfo, DynamicMethod>();
    private Dictionary<FieldInfo, DynamicMethod> fieldSetCache = new Dictionary<FieldInfo, DynamicMethod>();
    private Dictionary<FieldInfo, DynamicMethod> fieldGetCache = new Dictionary<FieldInfo, DynamicMethod>();
    private Dictionary<MethodInfo, DynamicMethod> indexerGetCache = new Dictionary<MethodInfo, DynamicMethod>();
    private Dictionary<MethodInfo, DynamicMethod> indexerSetCache = new Dictionary<MethodInfo, DynamicMethod>();
    private static ProxyHelper m_default;

    public static ProxyHelper Default
    {
      get
      {
        lock (typeof (ProxyHelper))
        {
          if (ProxyHelper.m_default == null)
            ProxyHelper.m_default = new ProxyHelper();
          return ProxyHelper.m_default;
        }
      }
    }

    public JsMethodImpl WrapMethod(MethodInfo info, bool passGlobal)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      if (info.ContainsGenericParameters)
        throw new InvalidOperationException("Can't wrap an unclosed generic");
      lock (this.methodCache)
      {
        JsMethodImpl jsMethodImpl;
        if (this.methodCache.TryGetValue(info, out jsMethodImpl))
          return jsMethodImpl;
      }
      LinkedList<ParameterInfo> linkedList1 = new LinkedList<ParameterInfo>((IEnumerable<ParameterInfo>) info.GetParameters());
      LinkedList<ProxyHelper.MarshalledParameter> linkedList2 = new LinkedList<ProxyHelper.MarshalledParameter>();
      DynamicMethod dynamicMethod = new DynamicMethod("jsWrapper", typeof (JsInstance), new Type[3]{ typeof (IGlobal), typeof (JsInstance), typeof (JsInstance[]) }, this.GetType());
      ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
      ilGenerator.DeclareLocal(typeof (int));
      ilGenerator.DeclareLocal(typeof (Marshaller));
      ilGenerator.Emit(OpCodes.Ldarg_0);
      ilGenerator.Emit(OpCodes.Call, typeof (IGlobal).GetProperty("Marshaller").GetGetMethod());
      if (!info.ReturnType.Equals(typeof (void)))
        ilGenerator.Emit(OpCodes.Dup);
      ilGenerator.Emit(OpCodes.Stloc_1);
      if (!info.IsStatic)
      {
        Label label1 = ilGenerator.DefineLabel();
        Label label2 = ilGenerator.DefineLabel();
        ilGenerator.Emit(OpCodes.Ldloc_1);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        if (info.DeclaringType.IsValueType)
          ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(info.DeclaringType));
        else
          ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(info.DeclaringType));
        ilGenerator.Emit(OpCodes.Dup);
        ilGenerator.Emit(OpCodes.Ldnull);
        ilGenerator.Emit(OpCodes.Beq, label2);
        ilGenerator.Emit(OpCodes.Br, label1);
        ilGenerator.MarkLabel(label2);
        ilGenerator.Emit(OpCodes.Ldstr, "The specified 'that' object is not acceptable for this method");
        ilGenerator.Emit(OpCodes.Newobj, typeof (JintException).GetConstructor(new Type[1]
        {
          typeof (string)
        }));
        ilGenerator.Emit(OpCodes.Throw);
        ilGenerator.MarkLabel(label1);
        if (info.DeclaringType.IsValueType)
          ilGenerator.Emit(OpCodes.Unbox, info.DeclaringType);
      }
      if (passGlobal && linkedList1.First != null && typeof (IGlobal).IsAssignableFrom(linkedList1.First.Value.ParameterType))
      {
        linkedList1.RemoveFirst();
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Isinst, typeof (IGlobal));
      }
      ilGenerator.Emit(OpCodes.Ldarg_2);
      ilGenerator.Emit(OpCodes.Ldlen);
      ilGenerator.Emit(OpCodes.Stloc_0);
      int index = 0;
      foreach (ParameterInfo parameterInfo in linkedList1)
      {
        ilGenerator.Emit(OpCodes.Ldloc_1);
        Label label1 = ilGenerator.DefineLabel();
        Label label2 = ilGenerator.DefineLabel();
        ilGenerator.Emit(OpCodes.Ldloc_0);
        ilGenerator.Emit(OpCodes.Ldc_I4, index);
        ilGenerator.Emit(OpCodes.Ble, label1);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        ilGenerator.Emit(OpCodes.Ldc_I4, index);
        ilGenerator.Emit(OpCodes.Ldelem, typeof (JsInstance));
        ilGenerator.Emit(OpCodes.Br, label2);
        ilGenerator.MarkLabel(label1);
        ilGenerator.Emit(OpCodes.Ldsfld, typeof (JsUndefined).GetField("Instance"));
        ilGenerator.MarkLabel(label2);
        if (parameterInfo.ParameterType.IsByRef)
        {
          Type elementType = parameterInfo.ParameterType.GetElementType();
          LocalBuilder temp = ilGenerator.DeclareLocal(elementType);
          ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(elementType));
          ilGenerator.Emit(OpCodes.Stloc, temp.LocalIndex);
          ilGenerator.Emit(OpCodes.Ldloca, temp.LocalIndex);
          if (parameterInfo.IsOut)
            linkedList2.AddLast(new ProxyHelper.MarshalledParameter(temp, index));
        }
        else
          ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(parameterInfo.ParameterType));
        ++index;
      }
      if (!info.IsStatic)
        ilGenerator.Emit(OpCodes.Callvirt, info);
      else
        ilGenerator.Emit(OpCodes.Call, info);
      foreach (ProxyHelper.MarshalledParameter marshalledParameter in linkedList2)
      {
        Label label = ilGenerator.DefineLabel();
        ilGenerator.Emit(OpCodes.Ldloc_0);
        ilGenerator.Emit(OpCodes.Ldc_I4, marshalledParameter.index);
        ilGenerator.Emit(OpCodes.Ble, label);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        ilGenerator.Emit(OpCodes.Ldc_I4, marshalledParameter.index);
        ilGenerator.Emit(OpCodes.Ldloc_1);
        ilGenerator.Emit(OpCodes.Ldloc, marshalledParameter.tempLocal);
        ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(marshalledParameter.tempLocal.LocalType));
        ilGenerator.Emit(OpCodes.Stelem, typeof (JsInstance));
        ilGenerator.MarkLabel(label);
      }
      if (!info.ReturnType.Equals(typeof (void)))
      {
        ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(info.ReturnType));
      }
      else
      {
        ilGenerator.Emit(OpCodes.Ldnull);
        ilGenerator.Emit(OpCodes.Ldfld, typeof (JsUndefined).GetField("Instance"));
      }
      ilGenerator.Emit(OpCodes.Ret);
      JsMethodImpl jsMethodImpl1 = (JsMethodImpl) dynamicMethod.CreateDelegate(typeof (JsMethodImpl));
      lock (this.methodCache)
        this.methodCache[info] = jsMethodImpl1;
      return jsMethodImpl1;
    }

    public ConstructorImpl WrapConstructor(ConstructorInfo info, bool passGlobal)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      lock (this.ctorCache)
      {
        ConstructorImpl constructorImpl;
        if (this.ctorCache.TryGetValue(info, out constructorImpl))
          return constructorImpl;
      }
      LinkedList<ParameterInfo> linkedList = new LinkedList<ParameterInfo>((IEnumerable<ParameterInfo>) info.GetParameters());
      DynamicMethod dynamicMethod = new DynamicMethod("clrConstructor", typeof (object), new Type[2]{ typeof (IGlobal), typeof (JsInstance[]) }, this.GetType());
      ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
      ilGenerator.DeclareLocal(typeof (int));
      if (passGlobal && linkedList.First != null && typeof (IGlobal).IsAssignableFrom(linkedList.First.Value.ParameterType))
      {
        linkedList.RemoveFirst();
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Isinst, typeof (IGlobal));
      }
      ilGenerator.Emit(OpCodes.Ldarg_1);
      ilGenerator.Emit(OpCodes.Ldlen);
      ilGenerator.Emit(OpCodes.Stloc_0);
      int num = 0;
      foreach (ParameterInfo parameterInfo in linkedList)
      {
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.EmitCall(OpCodes.Call, typeof (IGlobal).GetProperty("Marshaller").GetGetMethod(), (Type[]) null);
        Label label1 = ilGenerator.DefineLabel();
        Label label2 = ilGenerator.DefineLabel();
        ilGenerator.Emit(OpCodes.Ldloc_0);
        ilGenerator.Emit(OpCodes.Ldc_I4, num);
        ilGenerator.Emit(OpCodes.Ble, label1);
        ilGenerator.Emit(OpCodes.Ldarg_1);
        ilGenerator.Emit(OpCodes.Ldc_I4, num);
        ilGenerator.Emit(OpCodes.Ldelem, typeof (JsInstance));
        ilGenerator.Emit(OpCodes.Br, label2);
        ilGenerator.MarkLabel(label1);
        ilGenerator.Emit(OpCodes.Ldsfld, typeof (JsUndefined).GetField("Instance"));
        ilGenerator.MarkLabel(label2);
        if (parameterInfo.ParameterType.IsByRef)
        {
          Type elementType = parameterInfo.ParameterType.GetElementType();
          LocalBuilder localBuilder = ilGenerator.DeclareLocal(elementType);
          ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(elementType));
          ilGenerator.Emit(OpCodes.Stloc, localBuilder.LocalIndex);
          ilGenerator.Emit(OpCodes.Ldloca, localBuilder.LocalIndex);
        }
        else
          ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(parameterInfo.ParameterType));
        ++num;
      }
      ilGenerator.Emit(OpCodes.Newobj, info);
      if (info.DeclaringType.IsValueType)
        ilGenerator.Emit(OpCodes.Box, info.DeclaringType);
      ilGenerator.Emit(OpCodes.Ret);
      ConstructorImpl constructorImpl1 = (ConstructorImpl) dynamicMethod.CreateDelegate(typeof (ConstructorImpl));
      lock (this.ctorCache)
        this.ctorCache[info] = constructorImpl1;
      return constructorImpl1;
    }

    public JsGetter WrapGetProperty(PropertyInfo prop, Marshaller marshaller)
    {
      if (prop == null)
        throw new ArgumentNullException(nameof (prop));
      DynamicMethod dynamicMethod;
      lock (this.propGetCache)
        this.propGetCache.TryGetValue(prop, out dynamicMethod);
      if (dynamicMethod == null)
      {
        dynamicMethod = new DynamicMethod("dynamicPropertyGetter", typeof (JsInstance), new Type[2]
        {
          typeof (Marshaller),
          typeof (JsDictionaryObject)
        }, this.GetType());
        MethodInfo getMethod = prop.GetGetMethod();
        ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
        ilGenerator.Emit(OpCodes.Ldarg_0);
        if (!getMethod.IsStatic)
        {
          ilGenerator.Emit(OpCodes.Dup);
          ilGenerator.Emit(OpCodes.Ldarg_1);
          if (prop.DeclaringType.IsValueType)
          {
            ilGenerator.Emit(OpCodes.Callvirt, typeof (Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(prop.DeclaringType));
            ilGenerator.Emit(OpCodes.Unbox, prop.DeclaringType);
          }
          else
            ilGenerator.Emit(OpCodes.Callvirt, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(prop.DeclaringType));
          ilGenerator.Emit(OpCodes.Callvirt, getMethod);
        }
        else
          ilGenerator.Emit(OpCodes.Call, getMethod);
        ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(prop.PropertyType));
        ilGenerator.Emit(OpCodes.Ret);
        lock (this.propGetCache)
          this.propGetCache[prop] = dynamicMethod;
      }
      return (JsGetter) dynamicMethod.CreateDelegate(typeof (JsGetter), (object) marshaller);
    }

    public JsGetter WrapGetField(FieldInfo field, Marshaller marshaller)
    {
      if (field == null)
        throw new ArgumentNullException(nameof (field));
      DynamicMethod dynamicMethod;
      lock (this.fieldGetCache)
        this.fieldGetCache.TryGetValue(field, out dynamicMethod);
      if (dynamicMethod == null)
      {
        dynamicMethod = new DynamicMethod("dynamicFieldGetter", typeof (JsInstance), new Type[2]
        {
          typeof (Marshaller),
          typeof (JsDictionaryObject)
        }, this.GetType());
        ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
        ilGenerator.Emit(OpCodes.Ldarg_0);
        if (!field.IsStatic)
        {
          ilGenerator.Emit(OpCodes.Dup);
          ilGenerator.Emit(OpCodes.Ldarg_1);
          if (field.DeclaringType.IsValueType)
          {
            ilGenerator.Emit(OpCodes.Callvirt, typeof (Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(field.DeclaringType));
            ilGenerator.Emit(OpCodes.Unbox, field.DeclaringType);
          }
          else
            ilGenerator.Emit(OpCodes.Callvirt, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(field.DeclaringType));
          ilGenerator.Emit(OpCodes.Ldfld, field);
        }
        else
          ilGenerator.Emit(OpCodes.Ldsfld, field);
        ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(field.FieldType));
        ilGenerator.Emit(OpCodes.Ret);
        lock (this.fieldGetCache)
          this.fieldGetCache[field] = dynamicMethod;
      }
      return (JsGetter) dynamicMethod.CreateDelegate(typeof (JsGetter), (object) marshaller);
    }

    public JsSetter WrapSetProperty(PropertyInfo prop, Marshaller marshaller)
    {
      if (prop == null)
        throw new ArgumentNullException(nameof (prop));
      DynamicMethod dynamicMethod;
      lock (this.propSetCache)
        this.propSetCache.TryGetValue(prop, out dynamicMethod);
      if (dynamicMethod == null)
      {
        dynamicMethod = new DynamicMethod("dynamicPropertySetter", (Type) null, new Type[3]
        {
          typeof (Marshaller),
          typeof (JsDictionaryObject),
          typeof (JsInstance)
        }, this.GetType());
        MethodInfo setMethod = prop.GetSetMethod();
        ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
        if (!setMethod.IsStatic)
        {
          ilGenerator.Emit(OpCodes.Ldarg_0);
          ilGenerator.Emit(OpCodes.Ldarg_1);
          if (prop.DeclaringType.IsValueType)
          {
            ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(prop.DeclaringType));
            ilGenerator.Emit(OpCodes.Unbox, prop.DeclaringType);
          }
          else
            ilGenerator.Emit(OpCodes.Callvirt, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(prop.DeclaringType));
        }
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        ilGenerator.Emit(OpCodes.Callvirt, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(prop.PropertyType));
        if (setMethod.IsStatic)
          ilGenerator.Emit(OpCodes.Call, setMethod);
        else
          ilGenerator.Emit(OpCodes.Callvirt, setMethod);
        ilGenerator.Emit(OpCodes.Ret);
        lock (this.propSetCache)
          this.propSetCache[prop] = dynamicMethod;
      }
      return (JsSetter) dynamicMethod.CreateDelegate(typeof (JsSetter), (object) marshaller);
    }

    public JsSetter WrapSetField(FieldInfo field, Marshaller marshaller)
    {
      if (field == null)
        throw new ArgumentNullException(nameof (field));
      DynamicMethod dynamicMethod;
      lock (this.fieldSetCache)
        this.fieldSetCache.TryGetValue(field, out dynamicMethod);
      if (dynamicMethod == null)
      {
        dynamicMethod = new DynamicMethod("dynamicPropertySetter", (Type) null, new Type[3]
        {
          typeof (Marshaller),
          typeof (JsDictionaryObject),
          typeof (JsInstance)
        }, this.GetType());
        ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
        if (!field.IsStatic)
        {
          ilGenerator.Emit(OpCodes.Ldarg_0);
          ilGenerator.Emit(OpCodes.Ldarg_1);
          if (field.DeclaringType.IsValueType)
          {
            ilGenerator.Emit(OpCodes.Callvirt, typeof (Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(field.DeclaringType));
            ilGenerator.Emit(OpCodes.Unbox, field.DeclaringType);
          }
          else
            ilGenerator.Emit(OpCodes.Callvirt, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(field.DeclaringType));
        }
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        ilGenerator.Emit(OpCodes.Callvirt, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(field.FieldType));
        if (field.IsStatic)
          ilGenerator.Emit(OpCodes.Stsfld, field);
        else
          ilGenerator.Emit(OpCodes.Stfld, field);
        ilGenerator.Emit(OpCodes.Ret);
        lock (this.fieldSetCache)
          this.fieldSetCache[field] = dynamicMethod;
      }
      return (JsSetter) dynamicMethod.CreateDelegate(typeof (JsSetter), (object) marshaller);
    }

    public JsIndexerGetter WrapIndexerGetter(
      MethodInfo getMethod,
      Marshaller marshaller)
    {
      if (getMethod == null)
        throw new ArgumentNullException(nameof (getMethod));
      DynamicMethod dynamicMethod;
      lock (this.indexerGetCache)
        this.indexerGetCache.TryGetValue(getMethod, out dynamicMethod);
      if (dynamicMethod == null)
      {
        if (getMethod.GetParameters().Length != 1 || getMethod.ReturnType.Equals(typeof (void)))
          throw new ArgumentException("Invalid getter", nameof (getMethod));
        dynamicMethod = new DynamicMethod("dynamicIndexerSetter", typeof (JsInstance), new Type[3]
        {
          typeof (Marshaller),
          typeof (JsInstance),
          typeof (JsInstance)
        }, this.GetType());
        ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
        ilGenerator.Emit(OpCodes.Ldarg_0);
        if (!getMethod.IsStatic)
        {
          ilGenerator.Emit(OpCodes.Ldarg_0);
          ilGenerator.Emit(OpCodes.Ldarg_1);
          if (getMethod.DeclaringType.IsValueType)
          {
            ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(getMethod.DeclaringType));
            ilGenerator.Emit(OpCodes.Unbox, getMethod.DeclaringType);
          }
          else
            ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(getMethod.DeclaringType));
        }
        ParameterInfo parameter = getMethod.GetParameters()[0];
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        if (parameter.ParameterType.IsByRef)
        {
          ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(parameter.ParameterType));
          ilGenerator.Emit(OpCodes.Unbox, parameter.ParameterType);
        }
        else
          ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(parameter.ParameterType));
        if (getMethod.IsStatic)
          ilGenerator.Emit(OpCodes.Call, getMethod);
        else
          ilGenerator.Emit(OpCodes.Callvirt, getMethod);
        ilGenerator.Emit(OpCodes.Callvirt, typeof (Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(getMethod.ReturnType));
        ilGenerator.Emit(OpCodes.Ret);
        lock (this.indexerGetCache)
          this.indexerGetCache[getMethod] = dynamicMethod;
      }
      return (JsIndexerGetter) dynamicMethod.CreateDelegate(typeof (JsIndexerGetter), (object) marshaller);
    }

    public JsIndexerSetter WrapIndexerSetter(
      MethodInfo setMethod,
      Marshaller marshaller)
    {
      if (setMethod == null)
        throw new ArgumentNullException("getMethod");
      DynamicMethod dynamicMethod;
      lock (this.indexerSetCache)
        this.indexerSetCache.TryGetValue(setMethod, out dynamicMethod);
      if (dynamicMethod == null)
      {
        if (setMethod.GetParameters().Length != 2 || !setMethod.ReturnType.Equals(typeof (void)))
          throw new ArgumentException("Invalid getter", "getMethod");
        dynamicMethod = new DynamicMethod("dynamicIndexerSetter", typeof (void), new Type[4]
        {
          typeof (Marshaller),
          typeof (JsInstance),
          typeof (JsInstance),
          typeof (JsInstance)
        }, this.GetType());
        ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
        if (!setMethod.IsStatic)
        {
          ilGenerator.Emit(OpCodes.Ldarg_0);
          ilGenerator.Emit(OpCodes.Ldarg_1);
          if (setMethod.DeclaringType.IsValueType)
          {
            ilGenerator.Emit(OpCodes.Callvirt, typeof (Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(setMethod.DeclaringType));
            ilGenerator.Emit(OpCodes.Unbox, setMethod.DeclaringType);
          }
          else
            ilGenerator.Emit(OpCodes.Callvirt, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(setMethod.DeclaringType));
        }
        ParameterInfo parameter1 = setMethod.GetParameters()[0];
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldarg_2);
        if (parameter1.ParameterType.IsByRef)
        {
          ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(parameter1.ParameterType));
          ilGenerator.Emit(OpCodes.Unbox, parameter1.ParameterType);
        }
        else
          ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(parameter1.ParameterType));
        ParameterInfo parameter2 = setMethod.GetParameters()[1];
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldarg_3);
        if (parameter2.ParameterType.IsByRef)
        {
          ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValueBoxed").MakeGenericMethod(parameter2.ParameterType));
          ilGenerator.Emit(OpCodes.Unbox, parameter2.ParameterType);
        }
        else
          ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(parameter2.ParameterType));
        if (setMethod.IsStatic)
          ilGenerator.Emit(OpCodes.Call, setMethod);
        else
          ilGenerator.Emit(OpCodes.Callvirt, setMethod);
        ilGenerator.Emit(OpCodes.Ret);
        lock (this.indexerSetCache)
          this.indexerSetCache[setMethod] = dynamicMethod;
      }
      return (JsIndexerSetter) dynamicMethod.CreateDelegate(typeof (JsIndexerSetter), (object) marshaller);
    }

    private struct MarshalledParameter
    {
      public LocalBuilder tempLocal;
      public int index;

      public MarshalledParameter(LocalBuilder temp, int index)
      {
        this.tempLocal = temp;
        this.index = index;
      }
    }
  }
}
