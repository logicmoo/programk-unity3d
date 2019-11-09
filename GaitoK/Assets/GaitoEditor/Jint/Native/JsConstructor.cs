// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;

namespace Jint.Native
{
  [Serializable]
  public abstract class JsConstructor : JsFunction
  {
    public IGlobal Global { get; set; }

    public JsConstructor(IGlobal global)
      : base(global)
    {
      this.Global = global;
    }

    protected JsConstructor(IGlobal global, JsObject prototype)
      : base(prototype)
    {
      this.Global = global;
    }

    public abstract void InitPrototype(IGlobal global);

    public virtual JsInstance Wrap<T>(T value)
    {
      return (JsInstance) new JsObject((object) value, this.PrototypeProperty);
    }

    public override string GetBody()
    {
      return "[native ctor]";
    }
  }
}
