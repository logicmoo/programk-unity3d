// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.ToolboxSonstiges
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace de.springwald.toolbox
{
  public abstract class ToolboxSonstiges
  {
    private static bool _istEntwicklungsmodusGecheckt = false;
    private static bool _istEntwicklungsmodus;

    public static bool IstEntwicklungsmodus
    {
      get
      {
        return System.Diagnostics.Debugger.IsAttached;
      }
    }

    public static int Jahr4stelligMachen(int jahr)
    {
      if (jahr < 20)
        return jahr + 2000;
      if (jahr <= 99)
        return 1900 + jahr;
      return jahr;
    }

    public static DateTime Int2Datum(int datum)
    {
      if (datum < 1)
        return new DateTime();
      int year = datum / 10000;
      datum -= year * 10000;
      int month = datum / 100;
      datum -= month * 100;
      int day = datum;
      return new DateTime(year, month, day);
    }

    public static int Datum2Int(DateTime datum)
    {
      return datum.Year * 10000 + datum.Month * 100 + datum.Day;
    }

    public static void HTMLSeiteAufrufen(string url)
    {
      try
      {
        Process.Start(url);
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format(ResReader.Reader.GetString("KannHTMLSeiteNichtAufrufen"), (object) ex.Message));
      }
    }
  }
}
