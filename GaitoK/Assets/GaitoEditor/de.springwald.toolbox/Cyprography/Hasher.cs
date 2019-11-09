// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.Cyprography.Hasher
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace de.springwald.toolbox.Cyprography
{
  public class Hasher
  {
    public static string SHA1StringHash(string strString)
    {
      SHA1CryptoServiceProvider cryptoServiceProvider = new SHA1CryptoServiceProvider();
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      byte[] bytes = Encoding.ASCII.GetBytes(strString);
      foreach (byte num in cryptoServiceProvider.ComputeHash(bytes))
      {
        string str = Convert.ToString(num, 16);
        if (str.Length == 1)
          str = "0" + str;
        empty1 += str;
      }
      return empty1;
    }

    private string SHA1FileHash(string dateiname)
    {
      SHA1CryptoServiceProvider cryptoServiceProvider = new SHA1CryptoServiceProvider();
      string empty1 = string.Empty;
      string empty2 = string.Empty;
      FileStream fileStream = new FileStream(dateiname, FileMode.Open, FileAccess.Read, FileShare.Read, 8192);
      cryptoServiceProvider.ComputeHash((Stream) fileStream);
      fileStream.Close();
      foreach (byte num in cryptoServiceProvider.Hash)
      {
        string str = Convert.ToString(num, 16);
        if (str.Length == 1)
          str = "0" + str;
        empty1 += str;
      }
      return empty1;
    }
  }
}
