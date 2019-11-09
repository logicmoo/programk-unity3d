// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x60f3af502af1d663
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace TD.SandDock
{
  internal class x60f3af502af1d663
  {
    [DllImport("uxtheme.dll", CharSet = CharSet.Auto)]
    private static extern int GetCurrentThemeName(
      StringBuilder pszThemeFileName,
      int dwMaxNameChars,
      StringBuilder pszColorBuff,
      int dwMaxColorChars,
      StringBuilder pszSizeBuff,
      int cchMaxSizeChars);

    private x60f3af502af1d663()
    {
    }

    public static bool x2e20a402b77c44dc
    {
      get
      {
        return Path.GetFileName(x60f3af502af1d663.x43a4294aa97fcbd9).ToLower() == "luna.msstyles";
      }
    }

    public static string x43a4294aa97fcbd9
    {
      get
      {
        StringBuilder pszThemeFileName = new StringBuilder(512);
        x60f3af502af1d663.GetCurrentThemeName(pszThemeFileName, pszThemeFileName.Capacity, (StringBuilder) null, 0, (StringBuilder) null, 0);
        return pszThemeFileName.ToString();
      }
    }

    public static string x4f15c2ab6fab0941
    {
      get
      {
        StringBuilder pszColorBuff = new StringBuilder(512);
        x60f3af502af1d663.GetCurrentThemeName((StringBuilder) null, 0, pszColorBuff, pszColorBuff.Capacity, (StringBuilder) null, 0);
        return pszColorBuff.ToString();
      }
    }
  }
}
