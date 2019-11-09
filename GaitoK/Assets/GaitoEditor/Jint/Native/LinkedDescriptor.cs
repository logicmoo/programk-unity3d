// Decompiled with JetBrains decompiler
// Type: Jint.Native.LinkedDescriptor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

namespace Jint.Native
{
  internal class LinkedDescriptor : Descriptor
  {
    private Descriptor d;
    private JsDictionaryObject m_that;

    public LinkedDescriptor(
      JsDictionaryObject owner,
      string name,
      Descriptor source,
      JsDictionaryObject that)
      : base(owner, name)
    {
      if (source.isReference)
      {
        LinkedDescriptor linkedDescriptor = source as LinkedDescriptor;
        this.d = linkedDescriptor.d;
        this.m_that = linkedDescriptor.m_that;
      }
      else
        this.d = source;
      this.Enumerable = true;
      this.Writable = true;
      this.Configurable = true;
      this.m_that = that;
    }

    public JsDictionaryObject targetObject
    {
      get
      {
        return this.m_that;
      }
    }

    public override bool isReference
    {
      get
      {
        return true;
      }
    }

    public override bool isDeleted
    {
      get
      {
        return this.d.isDeleted;
      }
      protected set
      {
      }
    }

    public override Descriptor Clone()
    {
      LinkedDescriptor linkedDescriptor = new LinkedDescriptor(this.Owner, this.Name, (Descriptor) this, this.targetObject);
      linkedDescriptor.Writable = this.Writable;
      linkedDescriptor.Configurable = this.Configurable;
      linkedDescriptor.Enumerable = this.Enumerable;
      return (Descriptor) linkedDescriptor;
    }

    public override JsInstance Get(JsDictionaryObject that)
    {
      return this.d.Get(that);
    }

    public override void Set(JsDictionaryObject that, JsInstance value)
    {
      this.d.Set(that, value);
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
