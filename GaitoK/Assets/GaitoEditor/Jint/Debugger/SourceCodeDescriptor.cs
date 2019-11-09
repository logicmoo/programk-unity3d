// Decompiled with JetBrains decompiler
// Type: Jint.Debugger.SourceCodeDescriptor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;

namespace Jint.Debugger
{
  [Serializable]
  public class SourceCodeDescriptor
  {
    protected SourceCodeDescriptor.Location start;
    protected SourceCodeDescriptor.Location stop;

    public SourceCodeDescriptor.Location Start
    {
      get
      {
        return this.start;
      }
      set
      {
        this.start = value;
      }
    }

    public SourceCodeDescriptor.Location Stop
    {
      get
      {
        return this.stop;
      }
      set
      {
        this.stop = value;
      }
    }

    public string Code { get; private set; }

    public SourceCodeDescriptor(
      int startLine,
      int startChar,
      int stopLine,
      int stopChar,
      string code)
    {
      this.Code = code;
      this.Start = new SourceCodeDescriptor.Location(startLine, startChar);
      this.Stop = new SourceCodeDescriptor.Location(stopLine, stopChar);
    }

    public override string ToString()
    {
      return "Line: " + (object) this.Start.Line + " Char: " + (object) this.Start.Char;
    }

    [Serializable]
    public class Location
    {
      private int line;
      private int _Char;

      public Location(int line, int c)
      {
        this.line = line;
        this._Char = c;
      }

      public int Line
      {
        get
        {
          return this.line;
        }
        set
        {
          this.line = value;
        }
      }

      public int Char
      {
        get
        {
          return this._Char;
        }
        set
        {
          this._Char = value;
        }
      }
    }
  }
}
