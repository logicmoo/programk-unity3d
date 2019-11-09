// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeIndexer
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Marshal;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Jint.Native
{
  public class NativeIndexer : INativeIndexer
  {
    private NativeOverloadImpl<MethodInfo, JsIndexerGetter> m_getOverload;
    private NativeOverloadImpl<MethodInfo, JsIndexerSetter> m_setOverload;

    public NativeIndexer(Marshaller marshaller, MethodInfo[] getters, MethodInfo[] setters)
    {
      this.m_getOverload = new NativeOverloadImpl<MethodInfo, JsIndexerGetter>(marshaller, (NativeOverloadImpl<MethodInfo, JsIndexerGetter>.GetMembersDelegate) ((genericArgs, Length) => (IEnumerable<MethodInfo>) Array.FindAll<MethodInfo>(getters, (Predicate<MethodInfo>) (mi => mi.GetParameters().Length == Length))), new NativeOverloadImpl<MethodInfo, JsIndexerGetter>.WrapMmemberDelegate(marshaller.WrapIndexerGetter));
      this.m_setOverload = new NativeOverloadImpl<MethodInfo, JsIndexerSetter>(marshaller, (NativeOverloadImpl<MethodInfo, JsIndexerSetter>.GetMembersDelegate) ((genericArgs, Length) => (IEnumerable<MethodInfo>) Array.FindAll<MethodInfo>(setters, (Predicate<MethodInfo>) (mi => mi.GetParameters().Length == Length))), new NativeOverloadImpl<MethodInfo, JsIndexerSetter>.WrapMmemberDelegate(marshaller.WrapIndexerSetter));
    }

    public JsInstance get(JsInstance that, JsInstance index)
    {
      JsIndexerGetter jsIndexerGetter = this.m_getOverload.ResolveOverload(new JsInstance[1]{ index }, (Type[]) null);
      if (jsIndexerGetter == null)
        throw new JintException("No matching overload found");
      return jsIndexerGetter(that, index);
    }

    public void set(JsInstance that, JsInstance index, JsInstance value)
    {
      JsIndexerSetter jsIndexerSetter = this.m_setOverload.ResolveOverload(new JsInstance[2]{ index, value }, (Type[]) null);
      if (jsIndexerSetter == null)
        throw new JintException("No matching overload found");
      jsIndexerSetter(that, index, value);
    }
  }
}
