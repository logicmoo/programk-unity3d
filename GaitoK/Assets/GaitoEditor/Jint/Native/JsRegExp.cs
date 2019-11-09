// Decompiled with JetBrains decompiler
// Type: Jint.Native.JsRegExp
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;
using System.Text.RegularExpressions;

namespace Jint.Native
{
  [Serializable]
  public class JsRegExp : JsObject
  {
    private string pattern;
    private RegexOptions options;

    public bool IsGlobal
    {
      get
      {
        return this["global"].ToBoolean();
      }
    }

    public bool IsIgnoreCase
    {
      get
      {
        return (this.options & RegexOptions.IgnoreCase) == RegexOptions.IgnoreCase;
      }
    }

    public bool IsMultiline
    {
      get
      {
        return (this.options & RegexOptions.Multiline) == RegexOptions.Multiline;
      }
    }

    public JsRegExp(JsObject prototype)
      : base(prototype)
    {
    }

    public JsRegExp(string pattern, JsObject prototype)
      : this(pattern, false, false, false, prototype)
    {
    }

    public JsRegExp(string pattern, bool g, bool i, bool m, JsObject prototype)
      : base(prototype)
    {
      this.options = RegexOptions.ECMAScript;
      if (m)
        this.options |= RegexOptions.Multiline;
      if (i)
        this.options |= RegexOptions.IgnoreCase;
      this.pattern = pattern;
    }

    public string Pattern
    {
      get
      {
        return this.pattern;
      }
    }

    public Regex Regex
    {
      get
      {
        return new Regex(this.pattern, this.options);
      }
    }

    public RegexOptions Options
    {
      get
      {
        return this.options;
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
        return (object) null;
      }
    }

    public override string ToSource()
    {
      return "/" + this.pattern.ToString() + "/";
    }

    public override string ToString()
    {
      return "/" + this.pattern.ToString() + "/" + (this.IsGlobal ? "g" : string.Empty) + (this.IsIgnoreCase ? "i" : string.Empty) + (this.IsMultiline ? "m" : string.Empty);
    }

    public override string Class
    {
      get
      {
        return "RegExp";
      }
    }
  }
}
