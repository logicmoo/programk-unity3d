// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeMethod
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Expressions;
using Jint.Marshal;
using System;
using System.Reflection;

namespace Jint.Native
{
  public class NativeMethod : JsFunction
  {
    private MethodInfo m_nativeMethod;
    private JsMethodImpl m_impl;

    public NativeMethod(JsMethodImpl impl, MethodInfo nativeMethod, JsObject prototype)
      : base(prototype)
    {
      if (impl == null)
        throw new ArgumentNullException(nameof (impl));
      this.m_nativeMethod = nativeMethod;
      this.m_impl = impl;
      if (nativeMethod == null)
        return;
      this.Name = nativeMethod.Name;
      foreach (ParameterInfo parameter in nativeMethod.GetParameters())
        this.Arguments.Add(parameter.Name);
    }

    public NativeMethod(JsMethodImpl impl, JsObject prototype)
      : this(impl, (MethodInfo) null, prototype)
    {
      foreach (ParameterInfo parameter in impl.Method.GetParameters())
        this.Arguments.Add(parameter.Name);
    }

    public NativeMethod(MethodInfo info, JsObject prototype, IGlobal global)
      : base(prototype)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      if (global == null)
        throw new ArgumentNullException(nameof (global));
      this.m_nativeMethod = info;
      this.m_impl = global.Marshaller.WrapMethod(info, true);
      this.Name = info.Name;
      foreach (ParameterInfo parameter in info.GetParameters())
        this.Arguments.Add(parameter.Name);
    }

    public override bool IsClr
    {
      get
      {
        return true;
      }
    }

    public MethodInfo GetWrappedMethod()
    {
      return this.m_nativeMethod;
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      visitor.Return(this.m_impl(visitor.Global, (JsInstance) that, parameters));
      return (JsInstance) that;
    }

    public override JsObject Construct(
      JsInstance[] parameters,
      Type[] genericArgs,
      IJintVisitor visitor)
    {
      throw new JintException("This method can't be used as a constructor");
    }

    public override string GetBody()
    {
      return "[native code]";
    }

    public override JsInstance ToPrimitive(IGlobal global)
    {
      return (JsInstance) global.StringClass.New(this.ToString());
    }
  }
}
