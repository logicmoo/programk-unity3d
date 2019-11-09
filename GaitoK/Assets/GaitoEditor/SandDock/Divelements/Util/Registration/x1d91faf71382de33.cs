// Decompiled with JetBrains decompiler
// Type: Divelements.Util.Registration.x1d91faf71382de33
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using Microsoft.Win32;
using System;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Divelements.Util.Registration
{
  internal class x1d91faf71382de33 : xbd7c5470fc89975b
  {
    private static bool x5ee2d89e2d4d8414;
    private bool xc71dae9225f5522a;

    public x1d91faf71382de33(bool expires)
    {
      if ((uint) expires - (uint) expires >= 0U)
        goto label_11;
      else
        goto label_5;
label_2:
      if (!this.xc71dae9225f5522a || x1d91faf71382de33.x5ee2d89e2d4d8414)
        return;
      string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(Assembly.GetExecutingAssembly());
      goto label_10;
label_5:
      string[] strArray;
      strArray[1] = assemblyProductName;
      strArray[2] = " has expired. The software will therefore now be limited, but you will not lose any work.";
      if (true)
      {
        strArray[3] = Environment.NewLine;
        if (false)
          goto label_13;
      }
      else
        goto label_10;
label_7:
      strArray[4] = Environment.NewLine;
      x294bd621a33dc533.ShowMessage(string.Concat(strArray) + "You can purchase " + assemblyProductName + " online. After installing the commercial version, full functionality will be restored.", assemblyProductName);
      x1d91faf71382de33.x5ee2d89e2d4d8414 = true;
      if (((expires ? 1 : 0) & 0) == 0)
      {
        if ((uint) expires + (uint) expires > uint.MaxValue || ((expires ? 1 : 0) | int.MaxValue) != 0)
          return;
        goto label_11;
      }
      else
        goto label_2;
label_10:
      strArray = new string[5]
      {
        "Your evaluation period for ",
        null,
        null,
        null,
        null
      };
      goto label_5;
label_11:
      if (!expires)
        return;
      if (false)
        goto label_7;
label_13:
      this.xc71dae9225f5522a = this.xa1d7cab22b1cb36a();
      goto label_2;
    }

    public x1d91faf71382de33()
      : this(true)
    {
    }

    public override bool Evaluation
    {
      get
      {
        return true;
      }
    }

    public override bool Locked
    {
      get
      {
        return this.xc71dae9225f5522a;
      }
    }

    private bool xa1d7cab22b1cb36a()
    {
      AssemblyName name = Assembly.GetExecutingAssembly().GetName();
      string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(Assembly.GetExecutingAssembly());
      string base64String;
      long num;
      bool flag;
      using (SHA1 shA1 = SHA1.Create())
      {
        object[] objArray = new object[6];
        byte[] hash;
        do
        {
          objArray[0] = (object) assemblyProductName;
          if ((uint) num >= 0U)
            goto label_6;
label_4:
          objArray[3] = (object) name.Version.Minor;
          objArray[4] = (object) ".";
          objArray[5] = (object) name.Version.Build;
          string s = string.Concat(objArray);
          hash = shA1.ComputeHash(Encoding.Default.GetBytes(s));
          continue;
label_6:
          objArray[1] = (object) name.Version.Major;
          objArray[2] = (object) ".";
          goto label_4;
        }
        while ((uint) num - (uint) flag < 0U);
        base64String = Convert.ToBase64String(hash);
      }
      RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\.NETFramework", true);
      if (registryKey == null)
      {
        try
        {
          registryKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\.NETFramework");
        }
        catch
        {
          return true;
        }
      }
      DateTime dateTime = DateTime.MinValue;
      try
      {
        string s = (string) registryKey.GetValue(base64String);
        if ((uint) flag - (uint) flag <= uint.MaxValue || ((flag ? 1 : 0) & 0) != 0)
        {
          if (s != null)
          {
            if ((uint) flag - (uint) num >= 0U)
              goto label_17;
          }
          else
            registryKey.SetValue(base64String, (object) DateTime.Now.ToFileTime().ToString());
          return false;
        }
label_17:
        dateTime = DateTime.FromFileTime(long.Parse(s));
      }
      finally
      {
        registryKey.Close();
      }
      return DateTime.Now > dateTime + new TimeSpan(30, 0, 0, 0);
    }
  }
}
