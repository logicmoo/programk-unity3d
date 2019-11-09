// Decompiled with JetBrains decompiler
// Type: Jint.Native.PropertyDescriptor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;

namespace Jint.Native
{
  [Serializable]
  public class PropertyDescriptor : Descriptor
  {
    private IGlobal global;

    public PropertyDescriptor(IGlobal global, JsDictionaryObject owner, string name)
      : base(owner, name)
    {
      this.global = global;
      this.Enumerable = false;
    }

    public JsFunction GetFunction { get; set; }

    public JsFunction SetFunction { get; set; }

    public override bool isReference
    {
      get
      {
        return false;
      }
    }

    public override Descriptor Clone()
    {
      PropertyDescriptor propertyDescriptor = new PropertyDescriptor(this.global, this.Owner, this.Name);
      propertyDescriptor.Enumerable = this.Enumerable;
      propertyDescriptor.Configurable = this.Configurable;
      propertyDescriptor.Writable = this.Writable;
      propertyDescriptor.GetFunction = this.GetFunction;
      propertyDescriptor.SetFunction = this.SetFunction;
      return (Descriptor) propertyDescriptor;
    }

    public override JsInstance Get(JsDictionaryObject that)
    {
      this.global.Visitor.ExecuteFunction(this.GetFunction, that, JsInstance.EMPTY);
      return this.global.Visitor.Returned;
    }

    public override void Set(JsDictionaryObject that, JsInstance value)
    {
      if (this.SetFunction == null)
        throw new JsException((JsInstance) this.global.TypeErrorClass.New());
      this.global.Visitor.ExecuteFunction(this.SetFunction, that, new JsInstance[1]
      {
        value
      });
    }

    internal override DescriptorType DescriptorType
    {
      get
      {
        return DescriptorType.Accessor;
      }
    }
  }
}
