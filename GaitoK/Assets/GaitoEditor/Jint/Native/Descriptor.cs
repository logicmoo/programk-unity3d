// Decompiled with JetBrains decompiler
// Type: Jint.Native.Descriptor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;

namespace Jint.Native
{
  [Serializable]
  public abstract class Descriptor
  {
    public Descriptor(JsDictionaryObject owner, string name)
    {
      this.Owner = owner;
      this.Name = name;
    }

    public string Name { get; set; }

    public bool Enumerable { get; set; }

    public bool Configurable { get; set; }

    public bool Writable { get; set; }

    public JsDictionaryObject Owner { get; set; }

    public virtual bool isDeleted { get; protected set; }

    public abstract bool isReference { get; }

    public virtual void Delete()
    {
      this.isDeleted = true;
    }

    public bool IsClr
    {
      get
      {
        return false;
      }
    }

    public abstract Descriptor Clone();

    public abstract JsInstance Get(JsDictionaryObject that);

    public abstract void Set(JsDictionaryObject that, JsInstance value);

    internal abstract DescriptorType DescriptorType { get; }

    internal static Descriptor ToPropertyDesciptor(
      IGlobal global,
      JsDictionaryObject owner,
      string name,
      JsInstance jsInstance)
    {
      if (jsInstance.Class != "Object")
        throw new JsException((JsInstance) global.TypeErrorClass.New("The target object has to be an instance of an object"));
      JsObject jsObject = (JsObject) jsInstance;
      if ((jsObject.HasProperty("value") || jsObject.HasProperty("writable")) && (jsObject.HasProperty("set") || jsObject.HasProperty("get")))
        throw new JsException((JsInstance) global.TypeErrorClass.New("The property cannot be both writable and have get/set accessors or cannot have both a value and an accessor defined"));
      JsInstance result = (JsInstance) null;
      Descriptor descriptor = !jsObject.HasProperty("value") ? (Descriptor) new PropertyDescriptor(global, owner, name) : (Descriptor) new ValueDescriptor(owner, name, jsObject["value"]);
      if (jsObject.TryGetProperty("enumerable", out result))
        descriptor.Enumerable = result.ToBoolean();
      if (jsObject.TryGetProperty("configurable", out result))
        descriptor.Configurable = result.ToBoolean();
      if (jsObject.TryGetProperty("writable", out result))
        descriptor.Writable = result.ToBoolean();
      if (jsObject.TryGetProperty("get", out result))
      {
        if (!(result is JsFunction))
          throw new JsException((JsInstance) global.TypeErrorClass.New("The getter has to be a function"));
        ((PropertyDescriptor) descriptor).GetFunction = (JsFunction) result;
      }
      if (jsObject.TryGetProperty("set", out result))
      {
        if (!(result is JsFunction))
          throw new JsException((JsInstance) global.TypeErrorClass.New("The setter has to be a function"));
        ((PropertyDescriptor) descriptor).SetFunction = (JsFunction) result;
      }
      return descriptor;
    }
  }
}
