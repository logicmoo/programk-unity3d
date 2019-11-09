// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.IO.IOTools
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.IO;
using System.IO.Compression;
using System.Text;

namespace de.springwald.toolbox.IO
{
  public class IOTools
  {
    public static readonly Encoding ISO88591Encoding = Encoding.GetEncoding("ISO-8859-1");
    public static readonly Encoding ISO885915Encoding = Encoding.GetEncoding("ISO-8859-15");

    private IOTools()
    {
    }

    [Obsolete("Der Name der Methode ist falsch: Verwende CopyStreamChunked")]
    public static int CopyStream(Stream instream, Stream outstream)
    {
      return IOTools.CopyStreamChunked(instream, outstream);
    }

    public static int CopyStreamChunked(Stream instream, Stream outstream)
    {
      byte[] buffer = new byte[4096];
      int num = 0;
      int count;
      while ((count = instream.Read(buffer, 0, 4096)) > 0)
      {
        outstream.Write(buffer, 0, count);
        num += count;
      }
      return num;
    }

    public static int CopyStreamAtOnce(Stream instream, Stream outstream)
    {
      if (!instream.CanSeek)
        return IOTools.CopyStreamChunked(instream, outstream);
      byte[] buffer = new byte[instream.Length];
      int count = instream.Read(buffer, 0, buffer.Length);
      outstream.Write(buffer, 0, count);
      return count;
    }

    public static int CopyStreamSelect(Stream instream, Stream outstream)
    {
      if (instream.CanSeek && instream.Length < 1048577L)
        return IOTools.CopyStreamAtOnce(instream, outstream);
      return IOTools.CopyStreamChunked(instream, outstream);
    }

    [Obsolete("Der Name der Methode ist falsch: Verwende CopyStreamChunked")]
    public static long CopyStream(Stream instream, Stream outstream, long length)
    {
      return IOTools.CopyStreamChunked(instream, outstream, length);
    }

    public static long CopyStreamChunked(Stream instream, Stream outstream, long length)
    {
      byte[] buffer1 = new byte[4096];
      long num = 0;
      while (true)
      {
        Stream stream = instream;
        byte[] buffer2 = buffer1;
        int count1 = 4096L < length ? 4096 : (int) length;
        int count2;
        if ((count2 = stream.Read(buffer2, 0, count1)) > 0)
        {
          outstream.Write(buffer1, 0, count2);
          length -= (long) count2;
          num += (long) count2;
        }
        else
          break;
      }
      return num;
    }

    public static long CopyStreamAtOnce(Stream instream, Stream outstream, long length)
    {
      if (!instream.CanSeek)
        return IOTools.CopyStreamChunked(instream, outstream, length);
      byte[] buffer = new byte[Math.Min(instream.Length, length)];
      int count = instream.Read(buffer, 0, buffer.Length);
      outstream.Write(buffer, 0, count);
      return (long) count;
    }

    public static byte[] StreamToBytesChunked(Stream instream)
    {
      byte[] buffer = new byte[4096];
      using (MemoryStream memoryStream = new MemoryStream())
      {
        int count;
        while ((count = instream.Read(buffer, 0, buffer.Length)) > 0)
          memoryStream.Write(buffer, 0, count);
        return memoryStream.ToArray();
      }
    }

    public static byte[] StreamToBytesAtOnce(Stream instream)
    {
      if (!instream.CanSeek)
        return IOTools.StreamToBytesChunked(instream);
      byte[] buffer = new byte[instream.Length];
      instream.Read(buffer, 0, (int) instream.Length);
      return buffer;
    }

    [Obsolete("Der Name der Methode ist falsch: Verwende StreamToBytesAtOnce")]
    public static byte[] StreamToBytes(Stream instream)
    {
      return IOTools.StreamToBytesAtOnce(instream);
    }

    public static void CompressStreamGZipStream(Stream instream, Stream outstream)
    {
      GZipStream gzipStream = new GZipStream(outstream, CompressionMode.Compress, true);
      IOTools.CopyStreamChunked(instream, (Stream) gzipStream);
      gzipStream.Close();
    }

    public static void DecompressGZipStream(Stream instream, Stream outstream)
    {
      GZipStream gzipStream = new GZipStream(instream, CompressionMode.Decompress, true);
      IOTools.CopyStreamChunked((Stream) gzipStream, outstream);
      gzipStream.Close();
    }

    public static void CompressStreamGZipStreamSelect(
      Stream instream,
      Stream outstream,
      bool datacheck)
    {
      Stream outstream1 = datacheck ? (Stream) new GZipStream(outstream, CompressionMode.Compress, true) : (Stream) new DeflateStream(outstream, CompressionMode.Compress, true);
      IOTools.CopyStreamSelect(instream, outstream1);
      outstream1.Close();
    }

    public static void DecompressGZipStreamSelect(
      Stream instream,
      Stream outstream,
      bool datacheck)
    {
      Stream instream1 = datacheck ? (Stream) new GZipStream(instream, CompressionMode.Decompress, true) : (Stream) new DeflateStream(instream, CompressionMode.Decompress, true);
      IOTools.CopyStreamSelect(instream1, outstream);
      instream1.Close();
    }

    [Obsolete("Der Name der Methode ist falsch: Verwende CompressWithLength")]
    public static byte[] Compress(byte[] input)
    {
      return IOTools.CompressWithLength(input);
    }

    public static byte[] CompressWithLength(byte[] input)
    {
      MemoryStream memoryStream1 = new MemoryStream();
      GZipStream gzipStream = new GZipStream((Stream) memoryStream1, CompressionMode.Compress, true);
      IOTools.BytesToStream(input, (Stream) gzipStream);
      gzipStream.Close();
      memoryStream1.Position = 0L;
      MemoryStream memoryStream2 = new MemoryStream();
      byte[] buffer = new byte[memoryStream1.Length];
      memoryStream1.Read(buffer, 0, buffer.Length);
      byte[] numArray = new byte[buffer.Length + 4];
      Buffer.BlockCopy((Array) buffer, 0, (Array) numArray, 4, buffer.Length);
      Buffer.BlockCopy((Array) BitConverter.GetBytes(input.Length), 0, (Array) numArray, 0, 4);
      return numArray;
    }

    [Obsolete("Der Name der Methode ist falsch: Verwende UncompressWithLength")]
    public static byte[] Uncompress(byte[] input)
    {
      return IOTools.UncompressWithLength(input);
    }

    public static byte[] UncompressWithLength(byte[] input)
    {
      MemoryStream memoryStream = new MemoryStream();
      int int32 = BitConverter.ToInt32(input, 0);
      memoryStream.Write(input, 4, input.Length - 4);
      byte[] buffer = new byte[int32];
      memoryStream.Position = 0L;
      new GZipStream((Stream) memoryStream, CompressionMode.Decompress).Read(buffer, 0, buffer.Length);
      return buffer;
    }

    public static string StreamISO88591ToString(Stream instream)
    {
      StreamReader streamReader = new StreamReader(instream, IOTools.ISO88591Encoding);
      string end = streamReader.ReadToEnd();
      streamReader.Close();
      return end;
    }

    public static string StreamToString(Stream instream, Encoding encoding)
    {
      StreamReader streamReader = new StreamReader(instream, encoding);
      string end = streamReader.ReadToEnd();
      streamReader.Close();
      return end;
    }

    public static void StreamToFileChunked(Stream instream, string filename)
    {
      DirectoryInfo directory = new FileInfo(filename).Directory;
      if (!directory.Exists)
        directory.Create();
      FileStream fileStream = File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.None);
      IOTools.CopyStreamChunked(instream, (Stream) fileStream);
      fileStream.Close();
    }

    [Obsolete("Der Name der Methode ist falsch: Verwende StreamToFileChunked bzw. StreamToFileAtOnce")]
    public static void StreamToFile(Stream instream, string filename)
    {
      DirectoryInfo directory = new FileInfo(filename).Directory;
      if (!directory.Exists)
        directory.Create();
      FileStream fileStream = File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.None);
      IOTools.CopyStreamChunked(instream, (Stream) fileStream);
      fileStream.Close();
    }

    public static void StreamToFileAtOnce(Stream instream, string filename)
    {
      DirectoryInfo directory = new FileInfo(filename).Directory;
      if (!directory.Exists)
        directory.Create();
      FileStream fileStream = File.Open(filename, FileMode.Create, FileAccess.Write, FileShare.None);
      IOTools.CopyStreamAtOnce(instream, (Stream) fileStream);
      fileStream.Close();
    }

    public static byte[] ReadBytesFromStream(Stream instream, int offset, int length)
    {
      if ((long) (offset + length) > instream.Length)
        throw new ApplicationException("Versuch über das Ende des Streams hinaus zu lesen.");
      instream.Seek((long) offset, SeekOrigin.Begin);
      byte[] buffer = new byte[length];
      instream.Read(buffer, 0, buffer.Length);
      return buffer;
    }

    public static Stream ReadStreamFromStream(Stream instream, long offset, long length)
    {
      MemoryStream memoryStream = new MemoryStream();
      instream.Seek(offset, SeekOrigin.Begin);
      IOTools.CopyStreamChunked(instream, (Stream) memoryStream, length);
      memoryStream.Seek(0L, SeekOrigin.Begin);
      return (Stream) memoryStream;
    }

    public static void BytesToStream(byte[] srcdata, Stream outstream)
    {
      int count = 4096;
      byte[] buffer = new byte[count];
      for (int srcOffset = 0; srcOffset < srcdata.Length; srcOffset += count)
      {
        if (srcdata.Length - srcOffset < count)
          count = srcdata.Length - srcOffset;
        Buffer.BlockCopy((Array) srcdata, srcOffset, (Array) buffer, 0, count);
        outstream.Write(buffer, 0, count);
      }
    }

    public static string ReadFileShared(string filename)
    {
      return IOTools.ReadFileShared(filename, IOTools.ISO88591Encoding);
    }

    public static string ReadFileShared(string filename, Encoding instreamencoding)
    {
      Stream stream = (Stream) File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
      StreamReader streamReader = new StreamReader(stream, instreamencoding);
      string end = streamReader.ReadToEnd();
      streamReader.Close();
      stream.Close();
      return end;
    }

    public static byte[] ReadFileBytesShared(string filename)
    {
      Stream instream = (Stream) File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
      byte[] bytes = IOTools.StreamToBytes(instream);
      instream.Close();
      return bytes;
    }

    [Obsolete("Verwende ReadFileShared", true)]
    public static string LadeDateiText(string dateiname, Encoding dateiEncoding)
    {
      string end;
      using (StreamReader streamReader = new StreamReader(dateiname, dateiEncoding))
      {
        end = streamReader.ReadToEnd();
        streamReader.Close();
      }
      return end;
    }

    [Obsolete("Verwende ReadFileShared", true)]
    public static string LadeDateiText(string dateiname)
    {
      return IOTools.LadeDateiText(dateiname, IOTools.ISO88591Encoding);
    }

    public static void SchreibeDateiText(
      string dateiname,
      string dateitext,
      Encoding dateiEncoding)
    {
      DirectoryInfo directory = new FileInfo(dateiname).Directory;
      if (!directory.Exists)
        directory.Create();
      using (StreamWriter streamWriter = new StreamWriter(dateiname, false, dateiEncoding))
      {
        streamWriter.Write(dateitext);
        streamWriter.Close();
      }
    }

    public static void SchreibeDateiText(string dateiname, string dateitext)
    {
      IOTools.SchreibeDateiText(dateiname, dateitext, IOTools.ISO88591Encoding);
    }

    public static void SchreibeDateiText(
      string dateiname,
      string dateitext,
      Encoding dateiEncoding,
      DateTime creationTimeUtc,
      DateTime lastWriteTimeUtc)
    {
      IOTools.SchreibeDateiText(dateiname, dateitext, dateiEncoding);
      FileInfo fileInfo = new FileInfo(dateiname);
      fileInfo.CreationTimeUtc = creationTimeUtc;
      fileInfo.LastWriteTimeUtc = lastWriteTimeUtc;
    }

    public static void SchreibeDateiText(
      string dateiname,
      string dateitext,
      DateTime creationTimeUtc,
      DateTime lastWriteTimeUtc)
    {
      IOTools.SchreibeDateiText(dateiname, dateitext, IOTools.ISO88591Encoding, creationTimeUtc, lastWriteTimeUtc);
    }

    public static string PfadVerbinder(string basispfad, string relativerpfad)
    {
      if (basispfad == null)
        basispfad = "";
      if (relativerpfad == null)
        relativerpfad = "";
      basispfad.Replace("/", "\\");
      relativerpfad.Replace("/", "\\");
      if (relativerpfad.IndexOf(":") > -1 || relativerpfad.StartsWith("\\\\"))
        basispfad = "";
      if (basispfad != "" && !basispfad.EndsWith("\\"))
        basispfad += "\\";
      string str;
      int length1;
      for (str = (basispfad + relativerpfad).Replace("\\.\\", "\\"); str.IndexOf("\\..\\") > -1; str = str.Substring(0, str.Substring(0, length1).LastIndexOf("\\") + 1) + str.Substring(length1 + 4))
        length1 = str.IndexOf("\\..\\");
      int length2;
      for (; str.LastIndexOf("\\->\\") > -1; str = str.Substring(0, length2) + str.Substring(str.IndexOf("\\", length2 + 4)))
        length2 = str.LastIndexOf("\\->\\");
      return str;
    }
  }
}
