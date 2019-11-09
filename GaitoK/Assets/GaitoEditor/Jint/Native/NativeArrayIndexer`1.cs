// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeArrayIndexer`1
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;

namespace Jint.Native
{
  internal class NativeArrayIndexer<T> : INativeIndexer
  {
    private Marshaller m_marshller;

    public NativeArrayIndexer(Marshaller marshaller)
    {
      if (marshaller == null)
        throw new ArgumentNullException(nameof (marshaller));
      this.m_marshller = marshaller;
    }

    public JsInstance get(JsInstance that, JsInstance index)
    {
      return this.m_marshller.MarshalClrValue<T>(this.m_marshller.MarshalJsValue<T[]>(that)[this.m_marshller.MarshalJsValue<int>(index)]);
    }

    public void set(JsInstance that, JsInstance index, JsInstance value)
    {
      this.m_marshller.MarshalJsValue<T[]>(that)[this.m_marshller.MarshalJsValue<int>(index)] = this.m_marshller.MarshalJsValue<T>(value);
    }
  }
}
