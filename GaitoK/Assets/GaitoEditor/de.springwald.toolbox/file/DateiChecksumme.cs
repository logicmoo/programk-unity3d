// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.file.DateiChecksumme
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System.IO;

namespace de.springwald.toolbox.file
{
  public class DateiChecksumme
  {
    private long[] pTable = new long[256];
    private long Poly = 3988292384;

    public DateiChecksumme()
    {
      for (int index1 = 0; index1 < 256; ++index1)
      {
        long num = (long) index1;
        for (int index2 = 0; index2 < 8; ++index2)
        {
          if ((num & 1L) == 1L)
            num = num >> 1 ^ this.Poly;
          else
            num >>= 1;
        }
        this.pTable[index1] = num;
      }
    }

    public uint GetCRC32(string FileName)
    {
      int count = 4096;
      FileStream fileStream = new FileStream(FileName, FileMode.Open);
      long length = fileStream.Length;
      long num = (long) uint.MaxValue;
      for (; length > 0L; length -= (long) count)
      {
        if (length < (long) count)
          count = (int) length;
        byte[] buffer = new byte[count];
        fileStream.Read(buffer, 0, count);
        for (int index = 0; index < count; ++index)
          num = (num & 4294967040L) / 256L & 16777215L ^ this.pTable[(long) buffer[index] ^ num & (long) byte.MaxValue];
      }
      fileStream.Close();
      return (uint) ((ulong) -num - 1UL);
    }
  }
}
