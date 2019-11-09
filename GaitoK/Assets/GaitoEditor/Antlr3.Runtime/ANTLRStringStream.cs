// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.ANTLRStringStream
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections.Generic;

namespace Antlr.Runtime
{
  [Serializable]
  public class ANTLRStringStream : ICharStream, IIntStream
  {
    private int line = 1;
    protected char[] data;
    protected int n;
    protected int p;
    private int charPositionInLine;
    protected int markDepth;
    protected IList<CharStreamState> markers;
    protected int lastMarker;
    public string name;

    public ANTLRStringStream(string input)
      : this(input, (string) null)
    {
    }

    public ANTLRStringStream(string input, string sourceName)
      : this(input.ToCharArray(), input.Length, sourceName)
    {
    }

    public ANTLRStringStream(char[] data, int numberOfActualCharsInArray)
      : this(data, numberOfActualCharsInArray, (string) null)
    {
    }

    public ANTLRStringStream(char[] data, int numberOfActualCharsInArray, string sourceName)
    {
      if (data == null)
        throw new ArgumentNullException(nameof (data));
      if (numberOfActualCharsInArray < 0)
        throw new ArgumentOutOfRangeException();
      if (numberOfActualCharsInArray > data.Length)
        throw new ArgumentException();
      this.data = data;
      this.n = numberOfActualCharsInArray;
      this.name = sourceName;
    }

    protected ANTLRStringStream()
    {
      this.data = new char[0];
    }

    public virtual int Index
    {
      get
      {
        return this.p;
      }
    }

    public virtual int Line
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

    public virtual int CharPositionInLine
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

    public virtual void Reset()
    {
      this.p = 0;
      this.line = 1;
      this.charPositionInLine = 0;
      this.markDepth = 0;
    }

    public virtual void Consume()
    {
      if (this.p >= this.n)
        return;
      ++this.charPositionInLine;
      if (this.data[this.p] == '\n')
      {
        ++this.line;
        this.charPositionInLine = 0;
      }
      ++this.p;
    }

    public virtual int LA(int i)
    {
      if (i == 0)
        return 0;
      if (i < 0)
      {
        ++i;
        if (this.p + i - 1 < 0)
          return -1;
      }
      if (this.p + i - 1 >= this.n)
        return -1;
      return (int) this.data[this.p + i - 1];
    }

    public virtual int LT(int i)
    {
      return this.LA(i);
    }

    public virtual int Count
    {
      get
      {
        return this.n;
      }
    }

    public virtual int Mark()
    {
      if (this.markers == null)
      {
        this.markers = (IList<CharStreamState>) new List<CharStreamState>();
        this.markers.Add((CharStreamState) null);
      }
      ++this.markDepth;
      CharStreamState charStreamState;
      if (this.markDepth >= this.markers.Count)
      {
        charStreamState = new CharStreamState();
        this.markers.Add(charStreamState);
      }
      else
        charStreamState = this.markers[this.markDepth];
      charStreamState.p = this.p;
      charStreamState.line = this.line;
      charStreamState.charPositionInLine = this.charPositionInLine;
      this.lastMarker = this.markDepth;
      return this.markDepth;
    }

    public virtual void Rewind(int m)
    {
      if (m < 0)
        throw new ArgumentOutOfRangeException();
      CharStreamState marker = this.markers[m];
      this.Seek(marker.p);
      this.line = marker.line;
      this.charPositionInLine = marker.charPositionInLine;
      this.Release(m);
    }

    public virtual void Rewind()
    {
      this.Rewind(this.lastMarker);
    }

    public virtual void Release(int marker)
    {
      this.markDepth = marker;
      --this.markDepth;
    }

    public virtual void Seek(int index)
    {
      if (index <= this.p)
      {
        this.p = index;
      }
      else
      {
        while (this.p < index)
          this.Consume();
      }
    }

    public virtual string Substring(int start, int length)
    {
      if (start < 0)
        throw new ArgumentOutOfRangeException();
      if (length < 0)
        throw new ArgumentOutOfRangeException();
      if (start + length > this.data.Length)
        throw new ArgumentException();
      if (length == 0)
        return string.Empty;
      return new string(this.data, start, length);
    }

    public virtual string SourceName
    {
      get
      {
        return this.name;
      }
    }

    public override string ToString()
    {
      return new string(this.data);
    }
  }
}
