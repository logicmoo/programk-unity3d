// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.Web.WebUserDetector
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System.Web;

namespace de.springwald.toolbox.Web
{
  public abstract class WebUserDetector
  {
    public static bool IstGoogleBot(HttpRequest request)
    {
      if (request == null)
        return false;
      string serverVariable = request.ServerVariables["HTTP_USER_AGENT"];
      return !string.IsNullOrEmpty(serverVariable) && serverVariable.Contains("Googlebot");
    }
  }
}
