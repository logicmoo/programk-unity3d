// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.Serialisierung.DeepCloner`1
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace de.springwald.toolbox.Serialisierung
{
  public static class DeepCloner<T>
  {
    public static T Clone(T oSource)
    {
      try
      {
        MemoryStream memoryStream = new MemoryStream();
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize((Stream) memoryStream, (object) oSource);
        memoryStream.Position = 0L;
        T obj = (T) binaryFormatter.Deserialize((Stream) memoryStream);
        memoryStream.Close();
        return obj;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
