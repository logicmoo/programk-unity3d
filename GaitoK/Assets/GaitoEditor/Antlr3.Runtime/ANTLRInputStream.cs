// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.ANTLRInputStream
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.IO;
using System.Text;

namespace Antlr.Runtime
{
  [Serializable]
  public class ANTLRInputStream : ANTLRReaderStream
  {
    public ANTLRInputStream(Stream input)
      : this(input, (Encoding) null)
    {
    }

    public ANTLRInputStream(Stream input, int size)
      : this(input, size, (Encoding) null)
    {
    }

    public ANTLRInputStream(Stream input, Encoding encoding)
      : this(input, 1024, encoding)
    {
    }

    public ANTLRInputStream(Stream input, int size, Encoding encoding)
      : this(input, size, 1024, encoding)
    {
    }

    public ANTLRInputStream(Stream input, int size, int readBufferSize, Encoding encoding)
      : base((TextReader) ANTLRInputStream.GetStreamReader(input, encoding), size, readBufferSize)
    {
    }

    private static StreamReader GetStreamReader(Stream input, Encoding encoding)
    {
      if (encoding != null)
        return new StreamReader(input, encoding);
      return new StreamReader(input);
    }
  }
}
