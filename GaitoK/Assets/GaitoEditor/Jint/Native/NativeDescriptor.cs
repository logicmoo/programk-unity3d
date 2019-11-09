// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeDescriptor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Marshal;

namespace Jint.Native
{
  public class NativeDescriptor : Descriptor
  {
    private JsGetter getter;
    private JsSetter setter;

    public NativeDescriptor(JsDictionaryObject owner, string name, JsGetter getter)
      : base(owner, name)
    {
      this.getter = getter;
      this.Writable = false;
    }

    public NativeDescriptor(
      JsDictionaryObject owner,
      string name,
      JsGetter getter,
      JsSetter setter)
      : base(owner, name)
    {
      this.getter = getter;
      this.setter = setter;
    }

    public NativeDescriptor(JsDictionaryObject owner, NativeDescriptor src)
      : base(owner, src.Name)
    {
      this.getter = src.getter;
      this.setter = src.setter;
      this.Writable = src.Writable;
      this.Configurable = src.Configurable;
      this.Enumerable = src.Enumerable;
    }

    public override bool isReference
    {
      get
      {
        return false;
      }
    }

    public override Descriptor Clone()
    {
      return (Descriptor) new NativeDescriptor(this.Owner, this);
    }

    public override JsInstance Get(JsDictionaryObject that)
    {
      return this.getter != null ? this.getter(that) : (JsInstance) JsUndefined.Instance;
    }

    public override void Set(JsDictionaryObject that, JsInstance value)
    {
      if (this.setter == null)
        return;
      this.setter(that, value);
    }

    internal override DescriptorType DescriptorType
    {
      get
      {
        return DescriptorType.Clr;
      }
    }
  }
}
