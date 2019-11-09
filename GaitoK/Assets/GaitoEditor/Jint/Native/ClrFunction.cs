// Decompiled with JetBrains decompiler
// Type: Jint.Native.ClrFunction
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Expressions;
using System;
using System.Reflection;

namespace Jint.Native
{
  [Serializable]
  public class ClrFunction : JsFunction
  {
    public Delegate Delegate { get; set; }

    public ParameterInfo[] Parameters { get; set; }

    public ClrFunction(Delegate d, JsObject prototype)
      : base(prototype)
    {
      this.Delegate = d;
      this.Parameters = d.Method.GetParameters();
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      object[] objArray = new object[this.Delegate.Method.GetParameters().Length];
      for (int index = 0; index < parameters.Length; ++index)
      {
        int num = !typeof (JsInstance).IsAssignableFrom(this.Parameters[index].ParameterType) ? 0 : (this.Parameters[index].ParameterType.IsInstanceOfType((object) parameters[index]) ? 1 : 0);
        objArray[index] = num == 0 ? (!this.Parameters[index].ParameterType.IsInstanceOfType(parameters[index].Value) ? visitor.Global.Marshaller.MarshalJsValue<object>(parameters[index]) : parameters[index].Value) : (object) parameters[index];
      }
      object o;
      try
      {
        o = this.Delegate.DynamicInvoke(objArray);
      }
      catch (TargetInvocationException ex)
      {
        throw ex.InnerException;
      }
      catch (Exception ex)
      {
        if (ex.InnerException is JsException)
          throw ex.InnerException;
        throw;
      }
      if (o != null)
      {
        if (typeof (JsInstance).IsInstanceOfType(o))
          visitor.Return((JsInstance) o);
        else
          visitor.Return((JsInstance) visitor.Global.WrapClr(o));
      }
      else
        visitor.Return((JsInstance) JsUndefined.Instance);
      return (JsInstance) null;
    }

    public override string ToString()
    {
      return string.Format("function {0}() { [native code] }", (object) this.Delegate.Method.Name);
    }
  }
}
