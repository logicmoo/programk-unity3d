// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x443cc432acaadb1d
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.Drawing;
using System.Runtime.InteropServices;

namespace TD.SandDock
{
  internal class x443cc432acaadb1d
  {
    public const int xe8adba66ee59f491 = -1;
    public const int x152a3652057f019c = 4096;
    public const int xeaa67d27b4965bbd = 33;

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern int GetSysColor(int nIndex);

    [DllImport("user32.dll")]
    public static extern bool ReleaseCapture();

    [DllImport("user32.dll")]
    public static extern int GetSystemMetrics(int smIndex);

    public static Color x75cc9d2f9fd85f82
    {
      get
      {
        return ColorTranslator.FromWin32(x443cc432acaadb1d.GetSysColor(27));
      }
    }

    public static bool x641f26d1017e3571
    {
      get
      {
        return x443cc432acaadb1d.GetSystemMetrics(4096) != 0;
      }
    }
  }
}
