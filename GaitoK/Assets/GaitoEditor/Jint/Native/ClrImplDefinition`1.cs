// Decompiled with JetBrains decompiler
// Type: Jint.Native.ClrImplDefinition`1
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Delegates;
using Jint.Expressions;
using System;
using System.Reflection;

namespace Jint.Native
{
  [Serializable]
  public class ClrImplDefinition<T> : JsFunction where T : JsInstance
  {
    private Delegate impl;
    private int length;
    private bool hasParameters;

    private ClrImplDefinition(bool hasParameters, JsObject prototype)
      : base(prototype)
    {
      this.hasParameters = hasParameters;
    }

    public ClrImplDefinition(Func<T, JsInstance[], JsInstance> impl, JsObject prototype)
      : this(impl, -1, prototype)
    {
    }

    public ClrImplDefinition(
      Func<T, JsInstance[], JsInstance> impl,
      int length,
      JsObject prototype)
      : this(true, prototype)
    {
      this.impl = (Delegate) impl;
      this.length = length;
    }

    public ClrImplDefinition(Func<T, JsInstance> impl, JsObject prototype)
      : this(impl, -1, prototype)
    {
    }

    public ClrImplDefinition(Func<T, JsInstance> impl, int length, JsObject prototype)
      : this(false, prototype)
    {
      this.impl = (Delegate) impl;
      this.length = length;
    }

    public override JsInstance Execute(
      IJintVisitor visitor,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      try
      {
        JsInstance result;
        if (this.hasParameters)
          result = this.impl.DynamicInvoke((object) that, (object) parameters) as JsInstance;
        else
          result = this.impl.DynamicInvoke((object) that) as JsInstance;
        visitor.Return(result);
        return result;
      }
      catch (TargetInvocationException ex)
      {
        throw ex.InnerException;
      }
      catch (ArgumentException ex)
      {
        JsFunction jsFunction = that["constructor"] as JsFunction;
        throw new JsException((JsInstance) visitor.Global.TypeErrorClass.New("incompatible type: " + (object) jsFunction == null ? "<unknown>" : jsFunction.Name));
      }
      catch (Exception ex)
      {
        if (ex.InnerException is JsException)
          throw ex.InnerException;
        throw;
      }
    }

    public override int Length
    {
      get
      {
        if (this.length == -1)
          return base.Length;
        return this.length;
      }
    }

    public override string ToString()
    {
      return string.Format("function {0}() { [native code] }", (object) this.impl.Method.Name);
    }
  }
}
