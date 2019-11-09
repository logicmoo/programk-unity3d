// Decompiled with JetBrains decompiler
// Type: Jint.Native.ValueDescriptor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;

namespace Jint.Native
{
  [Serializable]
  public class ValueDescriptor : Descriptor
  {
    private JsInstance value;

    public ValueDescriptor(JsDictionaryObject owner, string name)
      : base(owner, name)
    {
      this.Enumerable = true;
      this.Writable = true;
      this.Configurable = true;
    }

    public ValueDescriptor(JsDictionaryObject owner, string name, JsInstance value)
      : this(owner, name)
    {
      this.Set((JsDictionaryObject) null, value);
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
      ValueDescriptor valueDescriptor = new ValueDescriptor(this.Owner, this.Name, this.value);
      valueDescriptor.Enumerable = this.Enumerable;
      valueDescriptor.Configurable = this.Configurable;
      valueDescriptor.Writable = this.Writable;
      return (Descriptor) valueDescriptor;
    }

    public override JsInstance Get(JsDictionaryObject that)
    {
      return this.value ?? (JsInstance) JsUndefined.Instance;
    }

    public override void Set(JsDictionaryObject that, JsInstance value)
    {
      if (!this.Writable)
        throw new JintException("This property is not writable");
      this.value = value;
    }

    internal override DescriptorType DescriptorType
    {
      get
      {
        return DescriptorType.Value;
      }
    }
  }
}
