// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.TreePatternLexer
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System.Text;

namespace Antlr.Runtime.Tree
{
  public class TreePatternLexer
  {
    protected int p = -1;
    public StringBuilder sval = new StringBuilder();
    public const int Begin = 1;
    public const int End = 2;
    public const int Id = 3;
    public const int Arg = 4;
    public const int Percent = 5;
    public const int Colon = 6;
    public const int Dot = 7;
    protected string pattern;
    protected int c;
    protected int n;
    public bool error;

    public TreePatternLexer(string pattern)
    {
      this.pattern = pattern;
      this.n = pattern.Length;
      this.Consume();
    }

    public virtual int NextToken()
    {
      this.sval.Length = 0;
      while (this.c != -1)
      {
        if (this.c == 32 || this.c == 10 || (this.c == 13 || this.c == 9))
        {
          this.Consume();
        }
        else
        {
          if (this.c >= 97 && this.c <= 122 || this.c >= 65 && this.c <= 90 || this.c == 95)
          {
            this.sval.Append((char) this.c);
            this.Consume();
            while (this.c >= 97 && this.c <= 122 || this.c >= 65 && this.c <= 90 || (this.c >= 48 && this.c <= 57 || this.c == 95))
            {
              this.sval.Append((char) this.c);
              this.Consume();
            }
            return 3;
          }
          if (this.c == 40)
          {
            this.Consume();
            return 1;
          }
          if (this.c == 41)
          {
            this.Consume();
            return 2;
          }
          if (this.c == 37)
          {
            this.Consume();
            return 5;
          }
          if (this.c == 58)
          {
            this.Consume();
            return 6;
          }
          if (this.c == 46)
          {
            this.Consume();
            return 7;
          }
          if (this.c == 91)
          {
            this.Consume();
            while (this.c != 93)
            {
              if (this.c == 92)
              {
                this.Consume();
                if (this.c != 93)
                  this.sval.Append('\\');
                this.sval.Append((char) this.c);
              }
              else
                this.sval.Append((char) this.c);
              this.Consume();
            }
            this.Consume();
            return 4;
          }
          this.Consume();
          this.error = true;
          return -1;
        }
      }
      return -1;
    }

    protected virtual void Consume()
    {
      ++this.p;
      if (this.p >= this.n)
        this.c = -1;
      else
        this.c = (int) this.pattern[this.p];
    }
  }
}
