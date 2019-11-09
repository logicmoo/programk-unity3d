// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsError
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;

namespace Jint.Native
{
  [Serializable]
  public class JsError : JsObject
  {
    private IGlobal global;

    private string message
    {
      get
      {
        return this[nameof (message)].ToString();
      }
      set
      {
        this[nameof (message)] = (JsInstance) this.global.StringClass.New(value);
      }
    }

    public override bool IsClr
    {
      get
      {
        return false;
      }
    }

    public override object Value
    {
      get
      {
        return (object) this.message;
      }
    }

    public JsError(IGlobal global)
      : this(global, string.Empty)
    {
    }

    public JsError(IGlobal global, string message)
      : base(global.ErrorClass.PrototypeProperty)
    {
      this.global = global;
      this.message = message;
    }

    public override string Class
    {
      get
      {
        return "Error";
      }
    }

    public override string ToString()
    {
      return this.Value.ToString();
    }
  }
}
