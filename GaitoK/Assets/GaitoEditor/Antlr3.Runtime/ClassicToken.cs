// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.ClassicToken
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;

namespace Antlr.Runtime
{
  [Serializable]
  public class ClassicToken : IToken
  {
    private string text;
    private int type;
    private int line;
    private int charPositionInLine;
    private int channel;
    private int index;

    public ClassicToken(int type)
    {
      this.type = type;
    }

    public ClassicToken(IToken oldToken)
    {
      this.text = oldToken.Text;
      this.type = oldToken.Type;
      this.line = oldToken.Line;
      this.charPositionInLine = oldToken.CharPositionInLine;
      this.channel = oldToken.Channel;
    }

    public ClassicToken(int type, string text)
    {
      this.type = type;
      this.text = text;
    }

    public ClassicToken(int type, string text, int channel)
    {
      this.type = type;
      this.text = text;
      this.channel = channel;
    }

    public string Text
    {
      get
      {
        return this.text;
      }
      set
      {
        this.text = value;
      }
    }

    public int Type
    {
      get
      {
        return this.type;
      }
      set
      {
        this.type = value;
      }
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

    public int CharPositionInLine
    {
      get
      {
        return this.charPositionInLine;
      }
      set
      {
        this.charPositionInLine = value;
      }
    }

    public int Channel
    {
      get
      {
        return this.channel;
      }
      set
      {
        this.channel = value;
      }
    }

    public int StartIndex
    {
      get
      {
        return -1;
      }
      set
      {
      }
    }

    public int StopIndex
    {
      get
      {
        return -1;
      }
      set
      {
      }
    }

    public int TokenIndex
    {
      get
      {
        return this.index;
      }
      set
      {
        this.index = value;
      }
    }

    public ICharStream InputStream
    {
      get
      {
        return (ICharStream) null;
      }
      set
      {
      }
    }

    public override string ToString()
    {
      string str = "";
      if (this.channel > 0)
        str = ",channel=" + (object) this.channel;
      string text = this.Text;
      return "[@" + (object) this.TokenIndex + ",'" + (text == null ? "<no text>" : text.Replace("\n", "\\\\n").Replace("\r", "\\\\r").Replace("\t", "\\\\t")) + "',<" + (object) this.type + ">" + str + "," + (object) this.line + ":" + (object) this.CharPositionInLine + "]";
    }
  }
}
