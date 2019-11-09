// Decompiled with JetBrains decompiler
// Type: Jint.Native.NativeTypeConstructor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;

namespace Jint.Native
{
  internal class NativeTypeConstructor : NativeConstructor
  {
    protected NativeTypeConstructor(IGlobal global, JsObject typePrototype)
      : base(typeof (Type), global, typePrototype, typePrototype)
    {
      this.DefineOwnProperty(JsFunction.PROTOTYPE, (JsInstance) typePrototype);
    }

    public static NativeTypeConstructor CreateNativeTypeConstructor(
      IGlobal global)
    {
      if (global == null)
        throw new ArgumentNullException(nameof (global));
      JsObject typePrototype = (JsObject) global.FunctionClass.New();
      NativeTypeConstructor nativeTypeConstructor = new NativeTypeConstructor(global, typePrototype);
      nativeTypeConstructor.InitPrototype(global);
      nativeTypeConstructor.SetupNativeProperties((JsDictionaryObject) nativeTypeConstructor);
      return nativeTypeConstructor;
    }

    public override JsInstance Wrap<T>(T value)
    {
      if ((object) value == null)
        throw new ArgumentNullException(nameof (value));
      if ((object) value is Type)
      {
        NativeConstructor nativeConstructor = new NativeConstructor((object) value as Type, this.Global, (JsObject) null, this.PrototypeProperty);
        nativeConstructor.InitPrototype(this.Global);
        this.SetupNativeProperties((JsDictionaryObject) nativeConstructor);
        return (JsInstance) nativeConstructor;
      }
      throw new JintException("Attempt to wrap '" + value.GetType().FullName + "' with '" + typeof (Type).FullName + "'");
    }

    public JsInstance WrapSpecialType(Type value, JsObject prototypePropertyPrototype)
    {
      if (value == null)
        throw new ArgumentNullException(nameof (value));
      NativeConstructor nativeConstructor = new NativeConstructor(value, this.Global, prototypePropertyPrototype, this.PrototypeProperty);
      nativeConstructor.InitPrototype(this.Global);
      this.SetupNativeProperties((JsDictionaryObject) nativeConstructor);
      return (JsInstance) nativeConstructor;
    }
  }
}
