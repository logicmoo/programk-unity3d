// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsUndefined
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;

namespace Jint.Native
{
  [Serializable]
  public class JsUndefined : JsObject
  {
    public static JsUndefined Instance;

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

    public override bool IsClr
    {
      get
      {
        return false;
      }
    }

    public override Descriptor GetDescriptor(string index)
    {
      return (Descriptor) null;
    }

    public override string Class
    {
      get
      {
        return "Object";
      }
    }

    public override string Type
    {
      get
      {
        return "undefined";
      }
    }

    public override string ToString()
    {
      return "undefined";
    }

    public override object ToObject()
    {
      return (object) null;
    }

    public override bool ToBoolean()
    {
      return false;
    }

    public override double ToNumber()
    {
      return double.NaN;
    }

    static JsUndefined()
    {
      JsUndefined jsUndefined = new JsUndefined();
      jsUndefined.Attributes = PropertyAttributes.DontEnum | PropertyAttributes.DontDelete;
      JsUndefined.Instance = jsUndefined;
    }
  }
}
