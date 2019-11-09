// Decompiled with JetBrains decompiler
// Type: Jint.Marshal.JsFunctionDelegate
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Expressions;
using Jint.Native;
using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Jint.Marshal
{
  internal class JsFunctionDelegate
  {
    private Delegate m_impl;
    private IJintVisitor m_visitor;
    private JsFunction m_function;
    private JsDictionaryObject m_that;
    private Marshaller m_marshaller;
    private Type m_delegateType;

    public JsFunctionDelegate(
      IJintVisitor visitor,
      JsFunction function,
      JsDictionaryObject that,
      Type delegateType)
    {
      if (visitor == null)
        throw new ArgumentNullException(nameof (visitor));
      if (function == null)
        throw new ArgumentNullException(nameof (function));
      if (delegateType == null)
        throw new ArgumentNullException(nameof (delegateType));
      if (!typeof (Delegate).IsAssignableFrom(delegateType))
        throw new ArgumentException("A delegate type is required", nameof (delegateType));
      this.m_visitor = visitor;
      this.m_function = function;
      this.m_delegateType = delegateType;
      this.m_that = that;
      this.m_marshaller = visitor.Global.Marshaller;
    }

    public Delegate GetDelegate()
    {
      if (this.m_impl != null)
        return this.m_impl;
      MethodInfo method = this.m_delegateType.GetMethod("Invoke");
      ParameterInfo[] parameters = method.GetParameters();
      Type[] parameterTypes = new Type[parameters.Length + 1];
      for (int index = 1; index <= parameters.Length; ++index)
        parameterTypes[index] = parameters[index - 1].ParameterType;
      parameterTypes[0] = typeof (JsFunctionDelegate);
      DynamicMethod dynamicMethod = new DynamicMethod("DelegateWrapper", method.ReturnType, parameterTypes, typeof (JsFunctionDelegate));
      ILGenerator ilGenerator = dynamicMethod.GetILGenerator();
      ilGenerator.DeclareLocal(typeof (JsInstance[]));
      ilGenerator.DeclareLocal(typeof (Marshaller));
      ilGenerator.Emit(OpCodes.Ldc_I4, parameters.Length);
      ilGenerator.Emit(OpCodes.Newarr, typeof (JsInstance));
      ilGenerator.Emit(OpCodes.Stloc_0);
      ilGenerator.Emit(OpCodes.Ldarg_0);
      ilGenerator.Emit(OpCodes.Ldfld, typeof (JsFunctionDelegate).GetField("m_marshaller", BindingFlags.Instance | BindingFlags.NonPublic));
      ilGenerator.Emit(OpCodes.Stloc_1);
      for (int index = 1; index <= parameters.Length; ++index)
      {
        ParameterInfo parameterInfo = parameters[index - 1];
        Type cls = parameterInfo.ParameterType;
        ilGenerator.Emit(OpCodes.Ldloc_0);
        ilGenerator.Emit(OpCodes.Ldc_I4, index - 1);
        ilGenerator.Emit(OpCodes.Ldloc_1);
        ilGenerator.Emit(OpCodes.Ldarg, index);
        if (cls.IsByRef)
        {
          cls = cls.GetElementType();
          if (parameterInfo.IsOut && !parameterInfo.IsIn)
          {
            ilGenerator.Emit(OpCodes.Ldarg, index);
            ilGenerator.Emit(OpCodes.Initobj);
          }
          if (cls.IsValueType)
            ilGenerator.Emit(OpCodes.Ldobj, cls);
          else
            ilGenerator.Emit(OpCodes.Ldind_Ref);
        }
        ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalClrValue").MakeGenericMethod(cls));
        ilGenerator.Emit(OpCodes.Stelem, typeof (JsInstance));
      }
      ilGenerator.Emit(OpCodes.Ldarg_0);
      ilGenerator.Emit(OpCodes.Ldfld, typeof (JsFunctionDelegate).GetField("m_visitor", BindingFlags.Instance | BindingFlags.NonPublic));
      ilGenerator.Emit(OpCodes.Ldarg_0);
      ilGenerator.Emit(OpCodes.Ldfld, typeof (JsFunctionDelegate).GetField("m_function", BindingFlags.Instance | BindingFlags.NonPublic));
      ilGenerator.Emit(OpCodes.Ldarg_0);
      ilGenerator.Emit(OpCodes.Ldfld, typeof (JsFunctionDelegate).GetField("m_that", BindingFlags.Instance | BindingFlags.NonPublic));
      ilGenerator.Emit(OpCodes.Ldloc_0);
      ilGenerator.Emit(OpCodes.Callvirt, typeof (IJintVisitor).GetMethod("ExecuteFunction"));
      for (int index = 1; index <= parameters.Length; ++index)
      {
        ParameterInfo parameterInfo = parameters[index - 1];
        Type elementType = parameterInfo.ParameterType.GetElementType();
        if (parameterInfo.IsOut)
        {
          ilGenerator.Emit(OpCodes.Ldarg, index);
          ilGenerator.Emit(OpCodes.Ldloc_1);
          ilGenerator.Emit(OpCodes.Ldloc_0);
          ilGenerator.Emit(OpCodes.Ldc_I4, index - 1);
          ilGenerator.Emit(OpCodes.Ldelem, typeof (JsInstance));
          ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(elementType));
          if (elementType.IsValueType)
            ilGenerator.Emit(OpCodes.Stobj, elementType);
          else
            ilGenerator.Emit(OpCodes.Stind_Ref);
        }
      }
      if (!method.ReturnType.Equals(typeof (void)))
      {
        ilGenerator.Emit(OpCodes.Ldloc_1);
        ilGenerator.Emit(OpCodes.Ldarg_0);
        ilGenerator.Emit(OpCodes.Ldfld, typeof (JsFunctionDelegate).GetField("m_visitor", BindingFlags.Instance | BindingFlags.NonPublic));
        ilGenerator.Emit(OpCodes.Call, typeof (IJintVisitor).GetProperty("Returned").GetGetMethod());
        ilGenerator.Emit(OpCodes.Call, typeof (Marshaller).GetMethod("MarshalJsValue").MakeGenericMethod(method.ReturnType));
      }
      ilGenerator.Emit(OpCodes.Ret);
      return this.m_impl = dynamicMethod.CreateDelegate(this.m_delegateType, (object) this);
    }
  }
}
