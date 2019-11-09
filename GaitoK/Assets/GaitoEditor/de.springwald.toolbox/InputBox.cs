// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.InputBox
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace de.springwald.toolbox
{
  public abstract class InputBox
  {
    public static string Show(
      string prompt,
      string header,
      string defaultResponse,
      out bool abgebrochen)
    {
      frmInput frmInput = new frmInput(prompt, header, defaultResponse);
      if (frmInput.ShowDialog() == DialogResult.OK)
      {
        abgebrochen = false;
        return frmInput.Response;
      }
      abgebrochen = true;
      return defaultResponse;
    }

    public static string Show(string prompt, string header, string defaultResponse)
    {
      frmInput frmInput = new frmInput(prompt, header, defaultResponse);
      if (frmInput.ShowDialog() == DialogResult.OK)
        return frmInput.Response;
      return defaultResponse;
    }

    public static string Show(string prompt, string header)
    {
      return InputBox.Show(prompt, header, string.Empty);
    }

    public static string Show(string prompt)
    {
      return InputBox.Show(prompt, Path.GetFileName(Assembly.GetCallingAssembly().Location), string.Empty);
    }
  }
}
