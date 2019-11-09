// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.Web.WebPlaceholderTools
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace de.springwald.toolbox.Web
{
  public abstract class WebPlaceholderTools
  {
    public static bool IstPlaceholderLeer(ContentPlaceHolder placeHolder)
    {
      foreach (Control control in placeHolder.Controls)
      {
        if (control is LiteralControl)
        {
          if (((LiteralControl) placeHolder.Controls[0]).Text.Trim(' ', '\r', '\n') != "")
            return false;
        }
        else if (!(control is ContentPlaceHolder) || !WebPlaceholderTools.IstPlaceholderLeer((ContentPlaceHolder) control))
          return false;
      }
      return true;
    }

    public static string GetPlaceholderText(ContentPlaceHolder placeHolder)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (object control in placeHolder.Controls)
      {
        if (control is LiteralControl)
        {
          if (!(((LiteralControl) control).Text.Trim(' ', '\r', '\n') == ""))
            stringBuilder.Append(((LiteralControl) control).Text);
        }
        if (control is Literal)
        {
          if (!(((Literal) control).Text.Trim(' ', '\r', '\n') == ""))
            stringBuilder.Append(((Literal) control).Text);
        }
        if (control is ContentPlaceHolder)
          stringBuilder.Append(WebPlaceholderTools.GetPlaceholderText((ContentPlaceHolder) control));
      }
      return stringBuilder.ToString();
    }
  }
}
