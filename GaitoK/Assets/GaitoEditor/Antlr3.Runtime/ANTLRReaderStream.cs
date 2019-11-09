// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.ANTLRReaderStream
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.IO;

namespace Antlr.Runtime
{
  [Serializable]
  public class ANTLRReaderStream : ANTLRStringStream
  {
    public const int ReadBufferSize = 1024;
    public const int InitialBufferSize = 1024;

    public ANTLRReaderStream(TextReader r)
      : this(r, 1024, 1024)
    {
    }

    public ANTLRReaderStream(TextReader r, int size)
      : this(r, size, 1024)
    {
    }

    public ANTLRReaderStream(TextReader r, int size, int readChunkSize)
    {
      this.Load(r, size, readChunkSize);
    }

    public virtual void Load(TextReader r, int size, int readChunkSize)
    {
      if (r == null)
        return;
      if (size <= 0)
        size = 1024;
      if (readChunkSize <= 0)
        readChunkSize = 1024;
      try
      {
        this.data = r.ReadToEnd().ToCharArray();
        this.n = this.data.Length;
      }
      finally
      {
        r.Close();
      }
    }
  }
}
