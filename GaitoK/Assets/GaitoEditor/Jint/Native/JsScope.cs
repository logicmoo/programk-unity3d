// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsScope
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;
using System.Collections.Generic;

namespace Jint.Native
{
  [Serializable]
  public class JsScope : JsDictionaryObject
  {
    public static string THIS = "this";
    public static string ARGUMENTS = "arguments";
    private Descriptor thisDescriptor;
    private Descriptor argumentsDescriptor;
    private JsScope globalScope;
    private JsDictionaryObject bag;

    public JsScope()
      : base((JsDictionaryObject) JsNull.Instance)
    {
      this.globalScope = (JsScope) null;
    }

    public JsScope(JsScope outer)
      : base((JsDictionaryObject) outer)
    {
      if (outer == null)
        throw new ArgumentNullException(nameof (outer));
      this.globalScope = outer.Global;
    }

    public JsScope(JsScope outer, JsDictionaryObject bag)
      : base((JsDictionaryObject) outer)
    {
      if (outer == null)
        throw new ArgumentNullException(nameof (outer));
      if (bag == null)
        throw new ArgumentNullException(nameof (bag));
      this.globalScope = outer.Global;
      this.bag = bag;
    }

    public JsScope(JsDictionaryObject bag)
      : base((JsDictionaryObject) JsNull.Instance)
    {
      this.bag = bag;
    }

    public override string Class
    {
      get
      {
        return "Scope";
      }
    }

    public override string Type
    {
      get
      {
        return "object";
      }
    }

    public JsScope Global
    {
      get
      {
        return this.globalScope ?? this;
      }
    }

    public override JsInstance this[string index]
    {
      get
      {
        if (index == JsScope.THIS && this.thisDescriptor != null)
          return this.thisDescriptor.Get((JsDictionaryObject) this);
        if (index == JsScope.ARGUMENTS && this.argumentsDescriptor != null)
          return this.argumentsDescriptor.Get((JsDictionaryObject) this);
        return base[index];
      }
      set
      {
        if (index == JsScope.THIS)
        {
          if (this.thisDescriptor != null)
            this.thisDescriptor.Set((JsDictionaryObject) this, value);
          else
            this.DefineOwnProperty(this.thisDescriptor = (Descriptor) new ValueDescriptor((JsDictionaryObject) this, index, value));
        }
        else if (index == JsScope.ARGUMENTS)
        {
          if (this.argumentsDescriptor != null)
            this.argumentsDescriptor.Set((JsDictionaryObject) this, value);
          else
            this.DefineOwnProperty(this.argumentsDescriptor = (Descriptor) new ValueDescriptor((JsDictionaryObject) this, index, value));
        }
        else
        {
          Descriptor descriptor = this.GetDescriptor(index);
          if (descriptor != null)
            descriptor.Set((JsDictionaryObject) this, value);
          else if (this.globalScope != null)
            this.globalScope.DefineOwnProperty(index, value);
          else
            this.DefineOwnProperty(index, value);
        }
      }
    }

    public override Descriptor GetDescriptor(string index)
    {
      Descriptor descriptor1;
      Descriptor descriptor2;
      if ((descriptor1 = base.GetDescriptor(index)) != null && descriptor1.Owner == this || (this.bag == null || (descriptor2 = this.bag.GetDescriptor(index)) == null))
        return descriptor1;
      Descriptor currentDescriptor = (Descriptor) new LinkedDescriptor((JsDictionaryObject) this, descriptor2.Name, descriptor2, this.bag);
      this.DefineOwnProperty(currentDescriptor);
      return currentDescriptor;
    }

    public override IEnumerable<string> GetKeys()
    {
      if (this.bag != null)
      {
        foreach (string key1 in this.bag.GetKeys())
        {
          string key = key1;
          if (this.baseGetDescriptor(key) == null)
            yield return key;
          key = (string) null;
        }
      }
      foreach (string key1 in this.baseGetKeys())
      {
        string key = key1;
        yield return key;
        key = (string) null;
      }
    }

    private Descriptor baseGetDescriptor(string key)
    {
      return base.GetDescriptor(key);
    }

    private IEnumerable<string> baseGetKeys()
    {
      return base.GetKeys();
    }

    public override IEnumerable<JsInstance> GetValues()
    {
      foreach (string key1 in this.GetKeys())
      {
        string key = key1;
        yield return this[key];
        key = (string) null;
      }
    }

    public override bool IsClr
    {
      get
      {
        return this.bag != null && this.bag.IsClr;
      }
    }

    public override object Value
    {
      get
      {
        return this.bag != null ? this.bag.Value : (object) null;
      }
      set
      {
        if (this.bag == null)
          return;
        this.bag.Value = value;
      }
    }
  }
}
