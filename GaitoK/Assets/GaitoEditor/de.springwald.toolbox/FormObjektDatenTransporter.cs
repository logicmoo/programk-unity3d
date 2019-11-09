// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.FormObjektDatenTransporter
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System.Web.UI.WebControls;

namespace de.springwald.toolbox
{
  public abstract class FormObjektDatenTransporter
  {
    public static string ReadWriteWebTextBox(
      string wert,
      ref TextBox formObjekt,
      TransportRichtungen inControlSchreiben)
    {
      if (inControlSchreiben != TransportRichtungen.InDasControl)
        return formObjekt.Text;
      formObjekt.Text = wert;
      return wert;
    }

    public static int ReadWriteWebTextBox(
      int wert,
      ref TextBox formObjekt,
      TransportRichtungen inControlSchreiben)
    {
      if (inControlSchreiben != TransportRichtungen.InDasControl)
        return int.Parse(formObjekt.Text);
      formObjekt.Text = wert.ToString();
      return wert;
    }

    public static bool ReadWriteWebCheckBox(
      bool wert,
      ref CheckBox formObjekt,
      TransportRichtungen inControlSchreiben)
    {
      if (inControlSchreiben != TransportRichtungen.InDasControl)
        return formObjekt.Checked;
      formObjekt.Checked = wert;
      return wert;
    }
  }
}
