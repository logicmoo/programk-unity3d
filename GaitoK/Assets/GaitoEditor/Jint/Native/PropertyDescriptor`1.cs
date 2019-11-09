﻿// Decompiled with JetBrains decompiler
// Type: Jint.Native.PropertyDescriptor`1
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using System;

namespace Jint.Native
{
  [Serializable]
  public class PropertyDescriptor<T> : PropertyDescriptor where T : JsInstance
  {
    public PropertyDescriptor(
      IGlobal global,
      JsDictionaryObject owner,
      string name,
      Func<T, JsInstance> get)
      : base(global, owner, name)
    {
      this.GetFunction = global.FunctionClass.New<T>(get);
    }

    public PropertyDescriptor(
      IGlobal global,
      JsDictionaryObject owner,
      string name,
      Func<T, JsInstance> get,
      Func<T, JsInstance[], JsInstance> set)
      : this(global, owner, name, get)
    {
      this.SetFunction = global.FunctionClass.New<T>(set);
    }
  }
}