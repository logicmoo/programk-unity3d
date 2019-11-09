// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsDictionaryObject
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Expressions;
using Jint.PropertyBags;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Jint.Native
{
  [Serializable]
  public abstract class JsDictionaryObject : JsInstance, IEnumerable<KeyValuePair<string, JsInstance>>, IEnumerable
  {
    protected internal IPropertyBag properties = (IPropertyBag) new MiniCachedPropertyBag();
    private int m_length = 0;

    public bool Extensible { get; set; }

    public bool hasChildren { get; private set; }

    public virtual int Length
    {
      get
      {
        return this.m_length;
      }
      set
      {
      }
    }

    public JsDictionaryObject()
    {
      this.Extensible = true;
      this.Prototype = (JsDictionaryObject) JsNull.Instance;
    }

    public JsDictionaryObject(JsDictionaryObject prototype)
    {
      this.Prototype = prototype;
      this.Extensible = true;
      prototype.hasChildren = true;
    }

    private JsDictionaryObject Prototype { get; set; }

    public virtual bool HasProperty(string key)
    {
      JsDictionaryObject dictionaryObject = this;
      do
      {
        if (!dictionaryObject.HasOwnProperty(key))
          dictionaryObject = dictionaryObject.Prototype;
        else
          goto label_1;
      }
      while (dictionaryObject != JsUndefined.Instance && dictionaryObject != JsNull.Instance);
      goto label_3;
label_1:
      return true;
label_3:
      return false;
    }

    public virtual bool HasOwnProperty(string key)
    {
      Descriptor descriptor;
      return this.properties.TryGet(key, out descriptor) && descriptor.Owner == this;
    }

    public virtual bool HasProperty(JsInstance key)
    {
      return this.HasProperty(key.ToString());
    }

    public virtual bool HasOwnProperty(JsInstance key)
    {
      return this.HasOwnProperty(key.ToString());
    }

    public virtual Descriptor GetDescriptor(string index)
    {
      Descriptor descriptor1;
      if (this.properties.TryGet(index, out descriptor1))
      {
        if (!descriptor1.isDeleted)
          return descriptor1;
        this.properties.Delete(index);
      }
      Descriptor descriptor2;
      if ((descriptor2 = this.Prototype.GetDescriptor(index)) != null)
        this.properties.Put(index, descriptor2);
      return descriptor2;
    }

    public virtual bool TryGetDescriptor(JsInstance index, out Descriptor result)
    {
      return this.TryGetDescriptor(index.ToString(), out result);
    }

    public virtual bool TryGetDescriptor(string index, out Descriptor result)
    {
      result = this.GetDescriptor(index);
      return result != null;
    }

    public virtual bool TryGetProperty(JsInstance index, out JsInstance result)
    {
      return this.TryGetProperty(index.ToString(), out result);
    }

    public virtual bool TryGetProperty(string index, out JsInstance result)
    {
      Descriptor descriptor = this.GetDescriptor(index);
      if (descriptor == null)
      {
        result = (JsInstance) JsUndefined.Instance;
        return false;
      }
      result = descriptor.Get(this);
      return true;
    }

    public virtual JsInstance this[JsInstance key]
    {
      get
      {
        return this[key.ToString()];
      }
      set
      {
        this[key.ToString()] = value;
      }
    }

    public virtual JsInstance this[string index]
    {
      get
      {
        Descriptor descriptor = this.GetDescriptor(index);
        return descriptor != null ? descriptor.Get(this) : (JsInstance) JsUndefined.Instance;
      }
      set
      {
        Descriptor descriptor = this.GetDescriptor(index);
        if (descriptor == null || descriptor.Owner != this && descriptor.DescriptorType == DescriptorType.Value)
          this.DefineOwnProperty((Descriptor) new ValueDescriptor(this, index, value));
        else
          descriptor.Set(this, value);
      }
    }

    public virtual void Delete(JsInstance key)
    {
      this.Delete(key.ToString());
    }

    public virtual void Delete(string index)
    {
      Descriptor result = (Descriptor) null;
      if (!this.TryGetDescriptor(index, out result) || result.Owner != this)
        return;
      if (!result.Configurable)
        throw new JintException("Property " + index + " isn't configurable");
      this.properties.Delete(index);
      result.Delete();
      --this.m_length;
    }

    public void DefineOwnProperty(
      string key,
      JsInstance value,
      PropertyAttributes propertyAttributes)
    {
      ValueDescriptor valueDescriptor = new ValueDescriptor(this, key, value);
      valueDescriptor.Writable = (propertyAttributes & PropertyAttributes.ReadOnly) == PropertyAttributes.None;
      valueDescriptor.Enumerable = (propertyAttributes & PropertyAttributes.DontEnum) == PropertyAttributes.None;
      this.DefineOwnProperty((Descriptor) valueDescriptor);
    }

    public void DefineOwnProperty(string key, JsInstance value)
    {
      this.DefineOwnProperty((Descriptor) new ValueDescriptor(this, key, value));
    }

    public virtual void DefineOwnProperty(Descriptor currentDescriptor)
    {
      string name = currentDescriptor.Name;
      Descriptor descriptor;
      if (this.properties.TryGet(name, out descriptor) && descriptor.Owner == this)
      {
        switch (descriptor.DescriptorType)
        {
          case DescriptorType.Value:
            switch (currentDescriptor.DescriptorType)
            {
              case DescriptorType.Value:
                this.properties.Get(name).Set(this, currentDescriptor.Get(this));
                return;
              case DescriptorType.Accessor:
                this.properties.Delete(name);
                this.properties.Put(name, currentDescriptor);
                return;
              case DescriptorType.Clr:
                throw new NotSupportedException();
              default:
                return;
            }
          case DescriptorType.Accessor:
            PropertyDescriptor propertyDescriptor = (PropertyDescriptor) descriptor;
            if (currentDescriptor.DescriptorType == DescriptorType.Accessor)
            {
              propertyDescriptor.GetFunction = ((PropertyDescriptor) currentDescriptor).GetFunction ?? propertyDescriptor.GetFunction;
              propertyDescriptor.SetFunction = ((PropertyDescriptor) currentDescriptor).SetFunction ?? propertyDescriptor.SetFunction;
              break;
            }
            propertyDescriptor.Set(this, currentDescriptor.Get(this));
            break;
        }
      }
      else
      {
        if (descriptor != null)
          descriptor.Owner.RedefineProperty(descriptor.Name);
        this.properties.Put(name, currentDescriptor);
        ++this.m_length;
      }
    }

    private void RedefineProperty(string name)
    {
      Descriptor descriptor;
      if (!this.properties.TryGet(name, out descriptor) || descriptor.Owner != this)
        return;
      this.properties.Put(name, descriptor.Clone());
      descriptor.Delete();
    }

    public IEnumerator<KeyValuePair<string, JsInstance>> GetEnumerator()
    {
      foreach (KeyValuePair<string, Descriptor> property in (IEnumerable<KeyValuePair<string, Descriptor>>) this.properties)
      {
        KeyValuePair<string, Descriptor> descriptor = property;
        if (descriptor.Value.Enumerable)
          yield return new KeyValuePair<string, JsInstance>(descriptor.Key, descriptor.Value.Get(this));
        descriptor = new KeyValuePair<string, Descriptor>();
      }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      return (IEnumerator) this.properties.GetEnumerator();
    }

    public virtual IEnumerable<JsInstance> GetValues()
    {
      foreach (Descriptor descriptor1 in this.properties.Values)
      {
        Descriptor descriptor = descriptor1;
        if (descriptor.Enumerable)
          yield return descriptor.Get(this);
        descriptor = (Descriptor) null;
      }
    }

    public virtual IEnumerable<string> GetKeys()
    {
      JsDictionaryObject p = this.Prototype;
      if (p != JsUndefined.Instance && p != JsNull.Instance && p != null)
      {
        foreach (string key1 in p.GetKeys())
        {
          string key = key1;
          if (!this.HasOwnProperty(key))
            yield return key;
          key = (string) null;
        }
      }
      foreach (KeyValuePair<string, Descriptor> property in (IEnumerable<KeyValuePair<string, Descriptor>>) this.properties)
      {
        KeyValuePair<string, Descriptor> descriptor = property;
        if (descriptor.Value.Enumerable && descriptor.Value.Owner == this)
          yield return descriptor.Key;
        descriptor = new KeyValuePair<string, Descriptor>();
      }
    }

    public virtual JsInstance GetGetFunction(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("propertyName");
      if (!target.HasOwnProperty(parameters[0].ToString()))
        return this.GetGetFunction(target.Prototype, parameters);
      PropertyDescriptor propertyDescriptor = target.properties.Get(parameters[0].ToString()) as PropertyDescriptor;
      if (propertyDescriptor == null)
        return (JsInstance) JsUndefined.Instance;
      return (JsInstance) ((JsObject) propertyDescriptor.GetFunction ?? (JsObject) JsUndefined.Instance);
    }

    public virtual JsInstance GetSetFunction(
      JsDictionaryObject target,
      JsInstance[] parameters)
    {
      if (parameters.Length == 0)
        throw new ArgumentException("propertyName");
      if (!target.HasOwnProperty(parameters[0].ToString()))
        return this.GetSetFunction(target.Prototype, parameters);
      PropertyDescriptor propertyDescriptor = target.properties.Get(parameters[0].ToString()) as PropertyDescriptor;
      if (propertyDescriptor == null)
        return (JsInstance) JsUndefined.Instance;
      return (JsInstance) ((JsObject) propertyDescriptor.SetFunction ?? (JsObject) JsUndefined.Instance);
    }

    [Obsolete("will be removed in 1.2", true)]
    public override object Call(
      IJintVisitor visitor,
      string function,
      params JsInstance[] parameters)
    {
      visitor.ExecuteFunction(this[function] as JsFunction, this, parameters);
      return (object) visitor.Returned;
    }

    public override bool IsClr
    {
      get
      {
        return false;
      }
    }

    public bool IsPrototypeOf(JsDictionaryObject target)
    {
      if (target == null || (target == JsUndefined.Instance || target == JsNull.Instance))
        return false;
      if (target.Prototype == this)
        return true;
      return this.IsPrototypeOf(target.Prototype);
    }

    public override object Value
    {
      get
      {
        return (object) null;
      }
      set
      {
      }
    }
  }
}
