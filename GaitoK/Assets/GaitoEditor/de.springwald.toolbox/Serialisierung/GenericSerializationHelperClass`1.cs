// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.Serialisierung.GenericSerializationHelperClass`1
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using de.springwald.toolbox.IO;
using System;
using System.Data.SqlTypes;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace de.springwald.toolbox.Serialisierung
{
  public static class GenericSerializationHelperClass<T>
  {
    public static bool ToXmlFile(T cryo, string fileName, bool zipped)
    {
      if (zipped)
        return GenericSerializationHelperClass<T>.ToXmlZipFile(cryo, fileName);
      return GenericSerializationHelperClass<T>.ToXmlFile(cryo, fileName);
    }

    internal static bool ToXmlZipFile(T cryo, string fileName)
    {
      DirectoryInfo directory = new FileInfo(fileName).Directory;
      if ((object) cryo == null || directory == null || !directory.Exists)
        return false;
      using (Stream stream = (Stream) new FileStream(fileName, FileMode.Create, FileAccess.Write))
      {
        using (GZipStream gzipStream = new GZipStream(stream, CompressionMode.Compress, true))
          new XmlSerializer(typeof (T)).Serialize((Stream) gzipStream, (object) cryo);
      }
      return true;
    }

    internal static bool ToXmlFile(T cryo, string fileName)
    {
      DirectoryInfo directory = new FileInfo(fileName).Directory;
      if ((object) cryo == null || directory == null || !directory.Exists)
        return false;
      using (Stream stream = (Stream) new FileStream(fileName, FileMode.Create, FileAccess.Write))
        new XmlSerializer(typeof (T)).Serialize(stream, (object) cryo);
      return true;
    }

    public static T FromXmlFile(string frozenObjectFileName, bool zipped)
    {
      if (zipped)
        return GenericSerializationHelperClass<T>.FromGZipXmlFile(frozenObjectFileName);
      return GenericSerializationHelperClass<T>.FromXmlFile(frozenObjectFileName);
    }

    internal static T FromXmlFile(string frozenObjectFileName)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
      if (frozenObjectFileName == null || !File.Exists(frozenObjectFileName))
        return default (T);
      using (FileStream fileStream = new FileStream(frozenObjectFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
        return (T) xmlSerializer.Deserialize((Stream) fileStream);
    }

    internal static T FromGZipXmlFile(string frozenObjectFileName)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
      if (frozenObjectFileName == null || !File.Exists(frozenObjectFileName))
        return default (T);
      using (FileStream fileStream = new FileStream(frozenObjectFileName, FileMode.Open, FileAccess.Read, FileShare.Read))
      {
        using (GZipStream gzipStream = new GZipStream((Stream) fileStream, CompressionMode.Decompress))
          return (T) xmlSerializer.Deserialize((Stream) gzipStream);
      }
    }

    public static string ToXmlString(T cryo, bool zipped)
    {
      if (zipped)
        return GenericSerializationHelperClass<T>.ToXmlZipString(cryo);
      return GenericSerializationHelperClass<T>.ToXmlString(cryo);
    }

    public static string ToXmlString(T cryo)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
      TextWriter textWriter = (TextWriter) new StringWriter();
      try
      {
        xmlSerializer.Serialize(textWriter, (object) cryo);
      }
      finally
      {
        textWriter.Flush();
        textWriter.Close();
      }
      return textWriter.ToString();
    }

    public static string ToUTF8XmlString(T cryo)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
      MemoryStream memoryStream = new MemoryStream();
      UTF8Encoding utF8Encoding = new UTF8Encoding();
      XmlTextWriter xmlTextWriter = new XmlTextWriter((Stream) memoryStream, (Encoding) utF8Encoding);
      try
      {
        xmlSerializer.Serialize((XmlWriter) xmlTextWriter, (object) cryo);
        byte[] array = memoryStream.ToArray();
        return utF8Encoding.GetString(array);
      }
      finally
      {
        memoryStream.Close();
        xmlTextWriter.Flush();
        xmlTextWriter.Close();
      }
    }

    internal static string ToXmlZipString(T cryo)
    {
      return Convert.ToBase64String(IOTools.Compress(Encoding.Unicode.GetBytes(GenericSerializationHelperClass<T>.ToXmlString(cryo))));
    }

    internal static string ToXmlZipStringBinary(T cryo)
    {
      return Convert.ToBase64String(IOTools.Compress(GenericSerializationHelperClass<T>.ToBinary(cryo)));
    }

    internal static T FromXmlZipString(string frozen)
    {
      return GenericSerializationHelperClass<T>.FromXml(Encoding.Unicode.GetString(IOTools.Uncompress(Convert.FromBase64String(frozen))));
    }

    internal static T FromXmlZipStringBinary(string frozen)
    {
      return GenericSerializationHelperClass<T>.FromBinary(IOTools.Uncompress(Convert.FromBase64String(frozen)));
    }

    public static T FromXml(string frozen, bool zipped)
    {
      if (zipped)
        return GenericSerializationHelperClass<T>.FromXmlZipString(frozen);
      return GenericSerializationHelperClass<T>.FromXml(frozen);
    }

    public static T FromXml(string frozen)
    {
      if (frozen.Length <= 0)
        throw new ArgumentOutOfRangeException("frozenObject", "Cannot thaw a zero-length string");
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
      TextReader textReader = (TextReader) new StringReader(frozen);
      object obj = (object) default (T);
      try
      {
        obj = xmlSerializer.Deserialize(textReader);
      }
      finally
      {
        textReader.Close();
      }
      return (T) obj;
    }

    public static string ToXmlStringWithOutXmlns(T cryo)
    {
      return GenericSerializationHelperClass<T>.ToXmlStringWithOutXmlns(cryo, Encoding.GetEncoding("ISO-8859-15"));
    }

    public static string ToXmlStringWithOutXmlns(T cryo, Encoding encoding)
    {
      XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
      namespaces.Add("", "");
      using (MemoryStream memoryStream = new MemoryStream())
      {
        new XmlSerializer(typeof (T)).Serialize((XmlWriter) new XmlTextWriter((Stream) memoryStream, encoding)
        {
          Formatting = Formatting.Indented
        }, (object) cryo, namespaces);
        return encoding.GetString(memoryStream.ToArray());
      }
    }

    public static bool ToXmlFileWithOutXmlns(T cryo, string fileName)
    {
      return GenericSerializationHelperClass<T>.ToXmlFileWithOutXmlns(cryo, fileName, Encoding.GetEncoding("ISO-8859-15"));
    }

    public static bool ToXmlFileWithOutXmlns(T cryo, string fileName, Encoding encoding)
    {
      try
      {
        DirectoryInfo directory = new FileInfo(fileName).Directory;
        if ((object) cryo == null || directory == null || !directory.Exists)
          return false;
        string stringWithOutXmlns = GenericSerializationHelperClass<T>.ToXmlStringWithOutXmlns(cryo, encoding);
        TextWriter textWriter = (TextWriter) new StreamWriter(fileName, false, encoding);
        textWriter.Write(stringWithOutXmlns);
        textWriter.Close();
        return true;
      }
      catch (DirectoryNotFoundException ex)
      {
        return false;
      }
    }

    public static bool ToXmlFileEncoded(T cryo, string fileName, Encoding encoding)
    {
      XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
      namespaces.Add("", "");
      DirectoryInfo directory = new FileInfo(fileName).Directory;
      if ((object) cryo == null || directory == null || !directory.Exists)
        return false;
      using (Stream w = (Stream) new FileStream(fileName, FileMode.Create, FileAccess.Write))
        new XmlSerializer(typeof (T)).Serialize((XmlWriter) new XmlTextWriter(w, encoding), (object) cryo, namespaces);
      return true;
    }

    public static XmlDocument ToXmlDocument(T cryo)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
      XmlDocument xmlDocument = new XmlDocument();
      using (Stream stream = (Stream) new MemoryStream())
      {
        xmlSerializer.Serialize(stream, (object) cryo);
        stream.Position = 0L;
        xmlDocument.Load(stream);
      }
      return xmlDocument;
    }

    public static T FromXml(XmlDocument frozen)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
      Stream stream = (Stream) new MemoryStream();
      frozen.Save(stream);
      try
      {
        stream.Position = 0L;
        return (T) xmlSerializer.Deserialize(stream);
      }
      finally
      {
        stream.Close();
      }
    }

    public static bool ToBinaryFile(T cryo, string fileName, bool zipped)
    {
      if (zipped)
        return GenericSerializationHelperClass<T>.ToBinaryZipFile(cryo, fileName);
      return GenericSerializationHelperClass<T>.ToBinaryFile(cryo, fileName);
    }

    internal static bool ToBinaryZipFile(T cryo, string fileName)
    {
      DirectoryInfo directory = new FileInfo(fileName).Directory;
      if ((object) cryo == null || directory == null || !directory.Exists)
        return false;
      using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
      {
        using (GZipStream gzipStream = new GZipStream((Stream) fileStream, CompressionMode.Compress))
          new BinaryFormatter().Serialize((Stream) gzipStream, (object) cryo);
      }
      return true;
    }

    internal static bool ToBinaryFile(T cryo, string fileName)
    {
      DirectoryInfo directory = new FileInfo(fileName).Directory;
      if ((object) cryo == null || directory == null || !directory.Exists)
        return false;
      using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
        new BinaryFormatter().Serialize((Stream) fileStream, (object) cryo);
      return true;
    }

    public static T FromBinaryFile(string frozenObjectFileName, bool zipped)
    {
      if (zipped)
        return GenericSerializationHelperClass<T>.FromBinaryZipFile(frozenObjectFileName);
      return GenericSerializationHelperClass<T>.FromBinaryFile(frozenObjectFileName);
    }

    internal static T FromBinaryFile(string frozenObjectFileName)
    {
      if (frozenObjectFileName == null || !File.Exists(frozenObjectFileName))
        return default (T);
      using (FileStream fileStream = new FileStream(frozenObjectFileName, FileMode.Open))
        return (T) new BinaryFormatter().Deserialize((Stream) fileStream);
    }

    internal static T FromBinaryZipFile(string frozenObjectFileName)
    {
      if (frozenObjectFileName == null || !File.Exists(frozenObjectFileName))
        return default (T);
      using (FileStream fileStream = new FileStream(frozenObjectFileName, FileMode.Open))
      {
        using (GZipStream gzipStream = new GZipStream((Stream) fileStream, CompressionMode.Decompress))
          return (T) new BinaryFormatter().Deserialize((Stream) gzipStream);
      }
    }

    public static byte[] ToByreArrayMitXmlSerializer(T cryo)
    {
      MemoryStream memoryStream = new MemoryStream();
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
      try
      {
        xmlSerializer.Serialize((Stream) memoryStream, (object) cryo);
        memoryStream.Position = 0L;
        return memoryStream.ToArray();
      }
      finally
      {
        memoryStream.Close();
      }
    }

    public static T FromByteArrayMitXmlSerializer(byte[] frozen)
    {
      if (frozen == null && frozen.Length == 0)
        throw new ArgumentOutOfRangeException("frozenObject", "Cannot thaw a zero-length Byte[] array");
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (T));
      Stream stream = (Stream) new MemoryStream(frozen);
      try
      {
        stream.Position = 0L;
        return (T) xmlSerializer.Deserialize(stream);
      }
      finally
      {
        stream.Close();
      }
    }

    public static byte[] ToBinary(T cryo)
    {
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      Stream serializationStream = (Stream) new MemoryStream();
      try
      {
        binaryFormatter.Serialize(serializationStream, (object) cryo);
        byte[] buffer = new byte[serializationStream.Length];
        serializationStream.Seek(0L, SeekOrigin.Begin);
        serializationStream.Read(buffer, 0, buffer.Length);
        return buffer;
      }
      finally
      {
        serializationStream.Close();
      }
    }

    public static T FromBinary(byte[] frozen)
    {
      if (frozen.Length == 0)
        throw new ArgumentOutOfRangeException("frozenObject", "Cannot thaw a zero-length Byte[] array");
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      Stream serializationStream = (Stream) new MemoryStream(frozen);
      try
      {
        return (T) binaryFormatter.Deserialize(serializationStream);
      }
      finally
      {
        serializationStream.Close();
      }
    }

    public static T FromBinary(byte[] frozen, SerializationBinder customBinder)
    {
      if (frozen.Length == 0)
        throw new ArgumentOutOfRangeException("frozenObject", "Cannot thaw a zero-length Byte[] array");
      if (customBinder == null)
        throw new ArgumentNullException(nameof (customBinder), "SerializationBinder implementation cannot be null");
      BinaryFormatter binaryFormatter = new BinaryFormatter();
      binaryFormatter.Binder = customBinder;
      Stream serializationStream = (Stream) new MemoryStream(frozen);
      try
      {
        return (T) binaryFormatter.Deserialize(serializationStream);
      }
      finally
      {
        serializationStream.Close();
      }
    }

    public static SqlXml ToSqlXml(T cryo)
    {
      throw new NotImplementedException("SqlXml type not implemented");
    }

    public static T FromSqlXml(SqlXml frozen)
    {
      throw new NotImplementedException("SqlXml type not implemented");
    }

    public static T Clone(T oSource)
    {
      MemoryStream memoryStream = new MemoryStream();
      object obj = (object) null;
      try
      {
        new XmlSerializer(typeof (T)).Serialize((Stream) memoryStream, (object) oSource);
        memoryStream.Position = 0L;
        obj = new XmlSerializer(typeof (T)).Deserialize((Stream) memoryStream);
      }
      catch (Exception ex)
      {
        throw ex;
      }
      finally
      {
        if (memoryStream != null)
          memoryStream.Close();
      }
      return (T) obj;
    }

    public static MemoryStream ToBinaryZipStream(T cryo, string fileName)
    {
      MemoryStream memoryStream = new MemoryStream();
      GZipStream gzipStream = new GZipStream((Stream) memoryStream, CompressionMode.Compress, true);
      new BinaryFormatter().Serialize((Stream) gzipStream, (object) cryo);
      gzipStream.Close();
      memoryStream.Position = 0L;
      return memoryStream;
    }

    public static T FromBinaryZipStream(MemoryStream fs)
    {
      using (GZipStream gzipStream = new GZipStream((Stream) fs, CompressionMode.Decompress))
        return (T) new BinaryFormatter().Deserialize((Stream) gzipStream);
    }

    public class GenericBinder : SerializationBinder
    {
      public override Type BindToType(string assemblyName, string typeName)
      {
        string[] strArray = typeName.Split('.');
        bool flag = strArray[0].ToString() == "System";
        string str1 = strArray[strArray.Length - 1];
        Type type1 = Type.GetType(string.Format("{0}, {1}", (object) typeName, (object) assemblyName));
        if (!flag && type1 == null)
        {
          Assembly assembly = Assembly.GetAssembly(typeof (T));
          if (assembly == null)
            throw new ArgumentException("Assembly for type '" + typeof (T).Name.ToString() + "' could not be loaded.");
          string str2 = assembly.FullName.Split(',')[0];
          Type type2 = assembly.GetType(str2 + "." + str1);
          if (type2 == null)
            throw new ArgumentException("Type '" + typeName + "' could not be loaded from assembly '" + str2 + "'.");
          type1 = type2;
        }
        return type1;
      }
    }
  }
}
