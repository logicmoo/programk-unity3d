// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsNull
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;
using System.Collections.Generic;

namespace Jint.Native
{
  [Serializable]
  public class JsNull : JsObject
  {
    public static JsNull Instance = new JsNull();

    public override bool IsClr
    {
      get
      {
        return false;
      }
    }

    public override string Type
    {
      get
      {
        return "null";
      }
    }

    public override string Class
    {
      get
      {
        return "Object";
      }
    }

    public override int Length
    {
      get
      {
        return 0;
      }
      set
      {
      }
    }

    public override bool ToBoolean()
    {
      return false;
    }

    public override double ToNumber()
    {
      return 0.0;
    }

    public override string ToString()
    {
      return "null";
    }

    public override Descriptor GetDescriptor(string index)
    {
      return (Descriptor) null;
    }

    public override IEnumerable<string> GetKeys()
    {
      return (IEnumerable<string>) new string[0];
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

    public override void DefineOwnProperty(Descriptor value)
    {
    }

    public override bool HasProperty(string key)
    {
      return false;
    }

    public override bool HasOwnProperty(string key)
    {
      return false;
    }

    public override JsInstance this[string index]
    {
      get
      {
        return (JsInstance) JsUndefined.Instance;
      }
      set
      {
      }
    }
  }
}
