// Decompiled with JetBrains decompiler
// Type: Jint.Native.IGlobal
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Expressions;

namespace Jint.Native
{
  public interface IGlobal
  {
    bool HasOption(Options options);

    JsArrayConstructor ArrayClass { get; }

    JsBooleanConstructor BooleanClass { get; }

    JsDateConstructor DateClass { get; }

    JsErrorConstructor ErrorClass { get; }

    JsErrorConstructor EvalErrorClass { get; }

    JsFunctionConstructor FunctionClass { get; }

    JsInstance IsNaN(JsInstance[] arguments);

    JsMathConstructor MathClass { get; }

    JsNumberConstructor NumberClass { get; }

    JsObjectConstructor ObjectClass { get; }

    JsInstance ParseFloat(JsInstance[] arguments);

    JsInstance ParseInt(JsInstance[] arguments);

    JsErrorConstructor RangeErrorClass { get; }

    JsErrorConstructor ReferenceErrorClass { get; }

    JsRegExpConstructor RegExpClass { get; }

    JsStringConstructor StringClass { get; }

    JsErrorConstructor SyntaxErrorClass { get; }

    JsErrorConstructor TypeErrorClass { get; }

    JsErrorConstructor URIErrorClass { get; }

    JsObject Wrap(object value);

    JsObject WrapClr(object value);

    JsInstance NaN { get; }

    IJintVisitor Visitor { get; }

    Marshaller Marshaller { get; }
  }
}
