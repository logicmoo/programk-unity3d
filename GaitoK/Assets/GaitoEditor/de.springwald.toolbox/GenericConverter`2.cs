// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.GenericConverter`2
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.IO;
using System.Xml.Serialization;

namespace de.springwald.toolbox
{
  public static class GenericConverter<SourceType, DestType>
  {
    public static DestType ConvertTo(SourceType oSource)
    {
      MemoryStream memoryStream = new MemoryStream();
      object obj = (object) null;
      try
      {
        new XmlSerializer(typeof (SourceType)).Serialize((Stream) memoryStream, (object) oSource);
        memoryStream.Position = 0L;
        obj = new XmlSerializer(typeof (DestType)).Deserialize((Stream) memoryStream);
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
      return (DestType) obj;
    }
  }
}
