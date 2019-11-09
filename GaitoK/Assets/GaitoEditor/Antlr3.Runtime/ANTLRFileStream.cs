// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.ANTLRFileStream
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.IO;
using System.Text;

namespace Antlr.Runtime
{
  [Serializable]
  public class ANTLRFileStream : ANTLRStringStream
  {
    protected string fileName;

    public ANTLRFileStream(string fileName)
      : this(fileName, (Encoding) null)
    {
    }

    public ANTLRFileStream(string fileName, Encoding encoding)
    {
      this.fileName = fileName;
      this.Load(fileName, encoding);
    }

    public virtual void Load(string fileName, Encoding encoding)
    {
      if (fileName == null)
        return;
      this.data = (encoding != null ? File.ReadAllText(fileName, encoding) : File.ReadAllText(fileName)).ToCharArray();
      this.n = this.data.Length;
    }

    public override string SourceName
    {
      get
      {
        return this.fileName;
      }
    }
  }
}
