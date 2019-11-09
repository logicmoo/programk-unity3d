// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsFunctionWrapper
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;

namespace Jint.Native
{
  [Serializable]
  public class JsFunctionWrapper : JsFunction
  {
    public Func<JsInstance[], JsInstance> Delegate { get; set; }

    public JsFunctionWrapper(Func<JsInstance[], JsInstance> d, JsObject prototype)
      : base(prototype)
    {
      this.Delegate = d;
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      try
      {
        JsInstance jsInstance = this.Delegate(parameters);
        visitor.Return(jsInstance == null ? (JsInstance) JsUndefined.Instance : jsInstance);
        return (JsInstance) that;
      }
      catch (Exception ex)
      {
        if (ex.InnerException is JsException)
          throw ex.InnerException;
        throw;
      }
    }

    public override string ToString()
    {
      return string.Format("function {0}() {{ [native code] }}", (object) this.Delegate.Method.Name);
    }
  }
}
