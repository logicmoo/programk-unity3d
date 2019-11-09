// Decompiled with JetBrains decompiler
// Type: Divelements.Util.Registration.x294bd621a33dc533
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Divelements.Util.Registration
{
  internal class x294bd621a33dc533 : LicenseProvider
  {
    private const string xed11756391d61907 = "Software\\\\Divelements Limited\\\\Registration";
    private static bool x4528b3b385025289;
    private static bool x0b277e20f7c1b92c;
    private static bool xba4ce277d393a202;
    private static bool x9fb6f00276c83908;

    public static void ActivateProduct(string licenseKey)
    {
      if (licenseKey != null)
      {
        licenseKey = licenseKey.Trim();
        string[] strArray = x294bd621a33dc533.SplitLicenseString(licenseKey);
        if (true)
        {
          int customerID = int.Parse(strArray[0], (IFormatProvider) CultureInfo.InvariantCulture);
          Assembly assembly = typeof (x294bd621a33dc533).Assembly;
          string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
          if ((uint) customerID - (uint) customerID <= uint.MaxValue)
          {
            Version versionFromAssembly = x294bd621a33dc533.GetVersionFromAssembly(assembly);
            while (true)
            {
              if ((uint) customerID - (uint) customerID <= uint.MaxValue)
              {
                string licenseKeyForCustomer = x294bd621a33dc533.GenerateLicenseKeyForCustomer(assemblyProductName, "buildmachine", versionFromAssembly.Major, versionFromAssembly.Minor, versionFromAssembly.Build, customerID);
                if (!(strArray[1] == licenseKeyForCustomer))
                {
                  if (true)
                    goto label_10;
                }
                else
                  break;
              }
              else
                goto label_10;
            }
            x294bd621a33dc533.x0b277e20f7c1b92c = true;
            return;
          }
        }
label_10:
        throw new ArgumentException("The supplied license key is not valid. Check you are using the correct license key for the version of the software installed.", nameof (licenseKey));
      }
      throw new ArgumentNullException(nameof (licenseKey));
    }

    public static bool StaticallyActivated
    {
      get
      {
        return x294bd621a33dc533.x0b277e20f7c1b92c;
      }
    }

    private static Version GetVersionFromAssembly(Assembly assembly)
    {
      return assembly.GetName().Version;
    }

    public static string[] SplitLicenseString(string s)
    {
      return new string[2]{ s.Substring(0, s.IndexOf('|')), s.Substring(s.IndexOf('|') + 1) };
    }

    public static string GetAssemblyProductName(Assembly assembly)
    {
      string str = (string) null;
      AssemblyProductAttribute[] customAttributes = (AssemblyProductAttribute[]) assembly.GetCustomAttributes(typeof (AssemblyProductAttribute), false);
      if (customAttributes.Length != 0)
        str = customAttributes[0].Product;
      return str;
    }

    private string GetSavedLicenseKey(LicenseContext context, System.Type type)
    {
      string savedLicenseKey1 = context.GetSavedLicenseKey(type, (Assembly) null);
      int num;
      if ((num & 0) == 0)
        goto label_7;
label_1:
      int index;
      ++index;
label_2:
      Assembly[] assemblies;
      if (index >= assemblies.Length)
        return (string) null;
      Assembly resourceAssembly = assemblies[index];
      if (!(resourceAssembly is AssemblyBuilder))
      {
        string savedLicenseKey2 = context.GetSavedLicenseKey(type, resourceAssembly);
        if (savedLicenseKey2 != null)
          return savedLicenseKey2;
        goto label_1;
      }
      else
        goto label_1;
label_7:
      if (savedLicenseKey1 != null)
        return savedLicenseKey1;
      assemblies = AppDomain.CurrentDomain.GetAssemblies();
      index = 0;
      if (false)
        goto label_2;
      else
        goto label_2;
    }

    public override License GetLicense(
      LicenseContext context,
      System.Type type,
      object instance,
      bool allowExceptions)
    {
      if (!x294bd621a33dc533.x0b277e20f7c1b92c)
        goto label_44;
label_43:
      return (License) new xbd7c5470fc89975b();
label_44:
      if (context != null)
        goto label_45;
label_4:
      int customerID;
      x1d91faf71382de33 x1d91faf71382de33;
      do
      {
        if (x294bd621a33dc533.IsDebug)
          this.WriteDebugMessage("eval");
        x1d91faf71382de33 = new x1d91faf71382de33();
      }
      while ((uint) customerID + (uint) customerID < 0U);
      if ((customerID & 0) == 0)
      {
        if (((allowExceptions ? 1 : 0) & 0) == 0)
        {
          if ((customerID & 0) == 0)
          {
            if (false)
            {
              if ((uint) allowExceptions >= 0U)
                goto label_31;
              else
                goto label_25;
            }
            else
              goto label_46;
          }
          else
            goto label_29;
        }
        else
          goto label_13;
      }
      else
        goto label_9;
label_7:
      if (context.UsageMode == LicenseUsageMode.Designtime)
      {
        if (!this.DoesValidDevelopmentLicenseExist(type.Assembly, (System.IServiceProvider) context, out customerID))
        {
          if ((uint) allowExceptions > uint.MaxValue)
            goto label_20;
          else
            goto label_4;
        }
        else
        {
          string key = customerID.ToString((IFormatProvider) CultureInfo.InvariantCulture) + "|" + this.GenerateLicenseKeyForType(type, customerID);
          context.SetSavedLicenseKey(type, key);
          if (!x294bd621a33dc533.IsDebug)
            goto label_10;
        }
      }
      else
        goto label_4;
label_9:
      this.WriteDebugMessage("valid");
label_10:
      return (License) new xbd7c5470fc89975b();
label_13:
      if (!x294bd621a33dc533.x4528b3b385025289)
      {
        if ((uint) allowExceptions - (uint) allowExceptions < 0U)
          goto label_9;
      }
      else
        goto label_7;
label_15:
      if (this.DoesValidDevelopmentLicenseExist(type.Assembly, (System.IServiceProvider) context, out customerID))
        goto label_27;
      else
        goto label_7;
label_16:
      if (context.UsageMode != LicenseUsageMode.Runtime)
      {
        if ((uint) customerID > uint.MaxValue)
          goto label_13;
        else
          goto label_7;
      }
      else
      {
        string savedLicenseKey = this.GetSavedLicenseKey(context, type);
        if (savedLicenseKey != null)
        {
          if (this.IsTypeKeyValid(savedLicenseKey, type))
          {
            if ((uint) allowExceptions > uint.MaxValue)
            {
              if (false)
              {
                if (true)
                {
                  if (true)
                    goto label_35;
                  else
                    goto label_43;
                }
                else
                  goto label_13;
              }
              else
                goto label_43;
            }
            else
              goto label_31;
          }
          else
            goto label_13;
        }
        else
          goto label_29;
      }
label_20:
      string message;
      message += "Press OK to read more.";
      string assemblyProductName;
      x294bd621a33dc533.ShowMessage(message, assemblyProductName);
      if ((uint) customerID <= uint.MaxValue)
      {
        Process.Start("http://www.divelements.co.uk/net/support/kb/licensing.aspx");
        x294bd621a33dc533.x4528b3b385025289 = true;
        goto label_7;
      }
label_22:
      string[] strArray = new string[5]{ "Warning: Although your development license for ", assemblyProductName, " is valid, it has not been embedded into your application by Visual Studio. This means that on a machine without ", null, null };
      if (((allowExceptions ? 1 : 0) & 0) == 0)
      {
        strArray[3] = assemblyProductName;
        strArray[4] = " installed, the license will not be found. Normally, opening at least one form designer will ensure the licenses.licx file in your project is created and updated correctly. If you continue to see this message, ensure the following lines are present in the file.";
        message = string.Concat(strArray) + Environment.NewLine + Environment.NewLine + this.GetLicenseFileLines(type);
        if (true)
        {
          message = message + Environment.NewLine + Environment.NewLine;
          goto label_20;
        }
        else
          goto label_35;
      }
      else if ((uint) allowExceptions + (uint) customerID >= 0U)
        goto label_37;
label_25:
      if ((uint) allowExceptions - (uint) customerID >= 0U)
        goto label_27;
label_26:
      this.WriteDebugMessage("devok,notembedded");
      goto label_28;
label_27:
      if (x294bd621a33dc533.IsDebug)
        goto label_26;
label_28:
      assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(type.Assembly);
      if (true)
        goto label_22;
      else
        goto label_46;
label_29:
      if ((uint) allowExceptions >= 0U)
        goto label_13;
      else
        goto label_15;
label_31:
      if (x294bd621a33dc533.IsDebug)
        this.WriteDebugMessage("valid");
      return (License) new xbd7c5470fc89975b();
label_35:
      if (x294bd621a33dc533.IsDebug)
      {
        this.WriteDebugMessage("licreq," + context.UsageMode.ToString());
        if ((customerID | (int) byte.MaxValue) == 0)
          goto label_13;
      }
      else
        goto label_16;
label_37:
      if ((uint) customerID - (uint) customerID < 0U)
        goto label_35;
      else
        goto label_16;
label_45:
      this.GetLicenseFileLines(type);
      goto label_35;
label_46:
      return (License) x1d91faf71382de33;
    }

    private string GetLicenseFileLines(System.Type type)
    {
      string name = type.Assembly.GetName().Name;
      int index;
      string str;
      do
      {
        str = string.Empty;
        System.Type[] types = type.Assembly.GetTypes();
        for (index = 0; index < types.Length; ++index)
        {
          System.Type type1 = types[index];
          while (type1.GetCustomAttributes(typeof (LicenseProviderAttribute), true).Length != 0)
          {
            if (str.Length != 0)
              goto label_6;
            else
              goto label_8;
label_5:
            str = str + type1.FullName + "," + name;
            break;
label_6:
            str += Environment.NewLine;
            goto label_5;
label_8:
            if ((uint) index - (uint) index >= 0U)
              goto label_5;
          }
        }
      }
      while ((uint) index - (uint) index < 0U);
      return str;
    }

    internal static void ShowMessage(string message, string title)
    {
      int num = (int) MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
    }

    private bool DoesValidDevelopmentLicenseExist(
      Assembly assembly,
      System.IServiceProvider serviceProvider,
      out int customerID)
    {
      customerID = 0;
      string[] strArray1;
      string assemblyProductName;
      do
      {
        assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
        string s1;
        do
        {
          RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\Wow6432Node\\Divelements Limited\\Registration", false);
          if (true)
          {
            if (registryKey != null)
              s1 = (string) registryKey.GetValue(assemblyProductName);
            else
              goto label_18;
          }
          else
            goto label_27;
        }
        while (false);
        goto label_24;
label_16:
        if (!x294bd621a33dc533.IsDebug)
        {
          if (false)
            goto label_30;
        }
        else
        {
          this.WriteDebugMessage("novalue");
          if (false)
            break;
        }
label_18:
        string[] strArray2;
        do
        {
          RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\\\Divelements Limited\\\\Registration", false);
          if (registryKey != null)
          {
            string s2 = (string) registryKey.GetValue(assemblyProductName);
            if (s2 != null)
              strArray2 = x294bd621a33dc533.SplitLicenseString(s2);
            else
              goto label_1;
          }
          else
            goto label_5;
        }
        while (false);
        goto label_20;
label_1:
        if (!x294bd621a33dc533.IsDebug)
        {
          if (true)
            continue;
          goto label_3;
        }
        else
          goto label_7;
label_20:
        if (true)
        {
          if (true)
          {
            customerID = int.Parse(strArray2[0], (IFormatProvider) CultureInfo.InvariantCulture);
            if (true)
            {
              if (!(strArray2[1] == x294bd621a33dc533.GenerateLicenseKeyForCustomer(assembly, customerID)))
              {
                if (x294bd621a33dc533.IsDebug)
                  this.WriteDebugMessage("licinvalid");
                strArray1 = new string[5]
                {
                  "A license key was found, but it is not valid. This usually means you are building against a different version of the assembly than the one you activated. You are building against version ",
                  null,
                  null,
                  null,
                  null
                };
                if (false)
                  goto label_1;
                else
                  goto label_8;
              }
              else
                goto label_12;
            }
            else
              continue;
          }
          else if (false)
          {
            if (false)
              goto label_26;
          }
          else
            goto label_27;
        }
        else
          goto label_16;
label_24:
        if (s1 == null)
        {
          if (true)
            goto label_16;
          else
            goto label_27;
        }
        else
        {
          string[] strArray3 = x294bd621a33dc533.SplitLicenseString(s1);
          customerID = int.Parse(strArray3[0], (IFormatProvider) CultureInfo.InvariantCulture);
          if (!(strArray3[1] == x294bd621a33dc533.GenerateLicenseKeyForCustomer(assembly, customerID)))
            goto label_27;
          else
            goto label_30;
        }
label_26:
        x294bd621a33dc533.ShowMessage("A license key was found, but it is not valid. This usually means you are building against a different version of the assembly than the one you activated. You are building against version " + assembly.GetName().Version.ToString() + " and your machine name is " + Environment.MachineName + ". A clean install of the product will solve this issue.", assemblyProductName);
        goto label_18;
label_27:
        if (x294bd621a33dc533.IsDebug)
        {
          this.WriteDebugMessage("licinvalid");
          goto label_26;
        }
        else
          goto label_26;
      }
      while (false);
      goto label_36;
label_3:
      if (x294bd621a33dc533.IsDebug)
        goto label_6;
      else
        goto label_36;
label_5:
      if (true)
        goto label_3;
label_6:
      this.WriteDebugMessage("nokey");
      goto label_36;
label_7:
      this.WriteDebugMessage("novalue");
      goto label_36;
label_8:
      strArray1[1] = assembly.GetName().Version.ToString();
      strArray1[2] = " and your machine name is ";
      strArray1[3] = Environment.MachineName;
      strArray1[4] = ". A clean install of the product will solve this issue.";
      x294bd621a33dc533.ShowMessage(string.Concat(strArray1), assemblyProductName);
      goto label_36;
label_12:
      return true;
label_30:
      return true;
label_36:
      return false;
    }

    private static bool IsDebug
    {
      get
      {
        if (!x294bd621a33dc533.xba4ce277d393a202)
        {
          try
          {
            using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("Software\\\\Divelements Limited\\\\Registration", false))
            {
              if (registryKey != null)
              {
                object obj = registryKey.GetValue("Debug");
                if (obj is int)
                  x294bd621a33dc533.x9fb6f00276c83908 = Convert.ToBoolean((int) obj);
              }
            }
          }
          catch
          {
          }
          x294bd621a33dc533.xba4ce277d393a202 = true;
        }
        return x294bd621a33dc533.x9fb6f00276c83908;
      }
    }

    private void WriteDebugMessage(string message)
    {
      string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "Divelements.Licensing.log");
      try
      {
        using (StreamWriter streamWriter = new StreamWriter(path, true))
          streamWriter.WriteLine(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString() + ": " + message);
      }
      catch
      {
      }
    }

    public static string GenerateLicenseKeyForCustomer(
      string productName,
      string computerName,
      int majorVersion,
      int minorVersion,
      int buildVersion,
      int customerID)
    {
      string[] strArray = new string[6];
      string s;
      do
      {
        if ((uint) customerID - (uint) minorVersion > uint.MaxValue)
          goto label_9;
        else
          goto label_11;
label_7:
        s = string.Concat(strArray);
        continue;
label_9:
        strArray[1] = computerName.ToUpper(CultureInfo.InvariantCulture);
        strArray[2] = majorVersion.ToString();
        strArray[3] = minorVersion.ToString();
        strArray[4] = buildVersion.ToString();
        strArray[5] = customerID.ToString((IFormatProvider) CultureInfo.InvariantCulture);
        goto label_7;
label_11:
        if ((uint) majorVersion + (uint) customerID <= uint.MaxValue)
        {
          strArray[0] = productName;
          goto label_9;
        }
        else
          goto label_7;
      }
      while ((minorVersion | 1) == 0);
      string base64String;
      if ((uint) minorVersion >= 0U)
      {
        byte[] hash;
        using (SHA1 shA1 = SHA1.Create())
          hash = shA1.ComputeHash(Encoding.ASCII.GetBytes(s));
        base64String = Convert.ToBase64String(hash);
      }
      return base64String;
    }

    public static string GenerateLicenseKeyForCustomer(Assembly assembly, int customerID)
    {
      string assemblyProductName = x294bd621a33dc533.GetAssemblyProductName(assembly);
      string machineName = Environment.MachineName;
      Version version = assembly.GetName().Version;
      return x294bd621a33dc533.GenerateLicenseKeyForCustomer(assemblyProductName, machineName, version.Major, version.Minor, version.Build, customerID);
    }

    private bool IsTypeKeyValid(string key, System.Type type)
    {
      string[] strArray = x294bd621a33dc533.SplitLicenseString(key);
      int customerID = int.Parse(strArray[0], (IFormatProvider) CultureInfo.InvariantCulture);
      return strArray[1] == this.GenerateLicenseKeyForType(type, customerID);
    }

    private string GenerateLicenseKeyForType(System.Type type, int customerID)
    {
      string s = type.FullName + type.Assembly.GetName().Version.ToString() + customerID.ToString((IFormatProvider) CultureInfo.InvariantCulture);
      byte[] hash;
      using (SHA1 shA1 = SHA1.Create())
        hash = shA1.ComputeHash(Encoding.ASCII.GetBytes(s));
      return Convert.ToBase64String(hash);
    }
  }
}
