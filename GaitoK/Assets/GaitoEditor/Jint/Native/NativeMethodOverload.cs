// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeMethodOverload
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Expressions;
using Jint.Marshal;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Jint.Native
{
  public class NativeMethodOverload : JsFunction
  {
    private LinkedList<MethodInfo> m_methods = new LinkedList<MethodInfo>();
    private LinkedList<MethodInfo> m_generics = new LinkedList<MethodInfo>();
    private Marshaller m_marshaller;
    private NativeOverloadImpl<MethodInfo, JsMethodImpl> m_overloads;

    public NativeMethodOverload(
      ICollection<MethodInfo> methods,
      JsObject prototype,
      IGlobal global)
      : base(prototype)
    {
      if (global == null)
        throw new ArgumentNullException(nameof (global));
      this.m_marshaller = global.Marshaller;
      using (IEnumerator<MethodInfo> enumerator = methods.GetEnumerator())
      {
        if (enumerator.MoveNext())
          this.Name = enumerator.Current.Name;
      }
      foreach (MethodInfo method in (IEnumerable<MethodInfo>) methods)
      {
        if (method.IsGenericMethodDefinition)
          this.m_generics.AddLast(method);
        else if (!method.ContainsGenericParameters)
          this.m_methods.AddLast(method);
      }
      this.m_overloads = new NativeOverloadImpl<MethodInfo, JsMethodImpl>(this.m_marshaller, new NativeOverloadImpl<MethodInfo, JsMethodImpl>.GetMembersDelegate(this.GetMembers), new NativeOverloadImpl<MethodInfo, JsMethodImpl>.WrapMmemberDelegate(this.WrapMember));
    }

    public override bool IsClr
    {
      get
      {
        return true;
      }
    }

    public override object Value
    {
      get
      {
        return (object) true;
      }
      set
      {
      }
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      return this.Execute(visitor, that, parameters, (Type[]) null);
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters,
      Type[] genericArguments)
    {
      if (this.m_generics.Count == 0 && (genericArguments != null && (uint) genericArguments.Length > 0U))
        return base.Execute(visitor, that, parameters, genericArguments);
      JsMethodImpl jsMethodImpl = this.m_overloads.ResolveOverload(parameters, genericArguments);
      if (jsMethodImpl == null)
        throw new JintException(string.Format("No matching overload found {0}<{1}>", (object) this.Name, (object) genericArguments));
      visitor.Return(jsMethodImpl(visitor.Global, (JsInstance) that, parameters));
      return (JsInstance) that;
    }

    protected JsMethodImpl WrapMember(MethodInfo info)
    {
      return this.m_marshaller.WrapMethod(info, true);
    }

    protected IEnumerable<MethodInfo> GetMembers(
      Type[] genericArguments,
      int argCount)
    {
      if (genericArguments != null && (uint) genericArguments.Length > 0U)
      {
        foreach (MethodInfo generic in this.m_generics)
        {
          MethodInfo item = generic;
          if (item.GetGenericArguments().Length == genericArguments.Length && item.GetParameters().Length == argCount)
          {
            MethodInfo m = (MethodInfo) null;
            try
            {
              m = item.MakeGenericMethod(genericArguments);
            }
            catch
            {
            }
            if (m != null)
              yield return m;
            m = (MethodInfo) null;
          }
          item = (MethodInfo) null;
        }
      }
      foreach (MethodInfo method in this.m_methods)
      {
        MethodInfo item = method;
        ParameterInfo[] parameters = item.GetParameters();
        if (parameters.Length == argCount)
        {
          yield return item;
          parameters = (ParameterInfo[]) null;
          item = (MethodInfo) null;
        }
      }
    }

    public override string GetBody()
    {
      return "[native overload]";
    }
  }
}
