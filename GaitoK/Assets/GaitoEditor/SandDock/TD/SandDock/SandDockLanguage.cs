// Decompiled with JetBrains decompiler
// Type: TD.SandDock.SandDockLanguage
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace TD.SandDock
{
  public sealed class SandDockLanguage
  {
    private static string x44b5349697df48ef = "Close";
    private static string xa411173168232f87;
    private static string xd1710f20a2c171cd;
    private static string x9e94b420934211d6;
    private static string x9956f53fadd73b87;
    private static string x5e3773048fa89dc1;
    private static string x39981e4ce91f2127;
    private static string x0c2979d11a5a497d;
    private static string x72913f986fffe0b3;

    public static void ShowCachedAssemblyError(
      Assembly componentAssembly,
      Assembly designerAssembly)
    {
      string text = SandDockLanguage.x39981e4ce91f2127 + Environment.NewLine + Environment.NewLine;
label_8:
      string str1 = text;
      string[] strArray1 = new string[6];
      strArray1[0] = str1;
      while (true)
      {
        if (true)
        {
          if (true)
            goto label_7;
          else
            break;
        }
      }
label_1:
      string[] strArray2;
      strArray2[3] = Environment.NewLine;
      strArray2[4] = SandDockLanguage.x72913f986fffe0b3;
      text = string.Concat(strArray2);
      int num = (int) MessageBox.Show(text, "Visual Studio Error Detected", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      if (true)
        return;
      if (true)
        goto label_8;
label_7:
      strArray1[1] = "Component Assembly:";
      strArray1[2] = Environment.NewLine;
      strArray1[3] = componentAssembly.Location;
      strArray1[4] = Environment.NewLine;
      string[] strArray3;
      do
      {
        strArray1[5] = Environment.NewLine;
        strArray3 = new string[6]
        {
          string.Concat(strArray1),
          "Designer Assembly:",
          null,
          null,
          null,
          null
        };
      }
      while (false);
      strArray3[2] = Environment.NewLine;
      strArray3[3] = designerAssembly.Location;
      strArray3[4] = Environment.NewLine;
      string str2;
      do
      {
        strArray3[5] = Environment.NewLine;
        str2 = string.Concat(strArray3);
      }
      while (false);
      strArray2 = new string[5]
      {
        str2,
        SandDockLanguage.x0c2979d11a5a497d,
        Environment.NewLine,
        null,
        null
      };
      goto label_1;
    }

    private SandDockLanguage()
    {
    }

    [Localizable(true)]
    public static string ActiveFilesText
    {
      get
      {
        return SandDockLanguage.x5e3773048fa89dc1;
      }
      set
      {
        if (value == null)
          value = string.Empty;
        SandDockLanguage.x5e3773048fa89dc1 = value;
      }
    }

    [Localizable(true)]
    public static string WindowPositionText
    {
      get
      {
        return SandDockLanguage.x9956f53fadd73b87;
      }
      set
      {
        SandDockLanguage.x9956f53fadd73b87 = value;
      }
    }

    [Localizable(true)]
    public static string ScrollRightText
    {
      get
      {
        return SandDockLanguage.x9e94b420934211d6;
      }
      set
      {
        SandDockLanguage.x9e94b420934211d6 = value;
      }
    }

    [Localizable(true)]
    public static string ScrollLeftText
    {
      get
      {
        return SandDockLanguage.xd1710f20a2c171cd;
      }
      set
      {
        SandDockLanguage.xd1710f20a2c171cd = value;
      }
    }

    [Localizable(true)]
    public static string CloseText
    {
      get
      {
        return SandDockLanguage.x44b5349697df48ef;
      }
      set
      {
        SandDockLanguage.x44b5349697df48ef = value;
      }
    }

    [Localizable(true)]
    public static string AutoHideText
    {
      get
      {
        return SandDockLanguage.xa411173168232f87;
      }
      set
      {
        SandDockLanguage.xa411173168232f87 = value;
      }
    }

    static SandDockLanguage()
    {
label_4:
      SandDockLanguage.xa411173168232f87 = "Auto Hide";
      SandDockLanguage.xd1710f20a2c171cd = "Scroll Left";
      if (true)
        SandDockLanguage.x9e94b420934211d6 = "Scroll Right";
      else
        goto label_5;
label_3:
      SandDockLanguage.x9956f53fadd73b87 = "Window  Position";
      SandDockLanguage.x5e3773048fa89dc1 = "Active Files";
      SandDockLanguage.x39981e4ce91f2127 = "Visual Studio is attempting to load designers from a different assembly than the one your components are being created with. This will result in failure to load your designed component. This message is being displayed because SandDock has detected this condition and will give you more information that will help you to correct the problem.";
      SandDockLanguage.x0c2979d11a5a497d = "The component in question should be installed in only one location, by default within the \"Program Files\\Divelements\" folder. Please close Visual Studio, remove the errant assembly and try loading your designer again.";
      if (false)
        goto label_4;
label_5:
      if (true)
        SandDockLanguage.x72913f986fffe0b3 = "Ensure that you do not attempt to save any designer that opens with errors, as this can result in loss of work. Note that you may receive this message multiple times, once for each component instance in your designer.";
      else
        goto label_3;
    }
  }
}
