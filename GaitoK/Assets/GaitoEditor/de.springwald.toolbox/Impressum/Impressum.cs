// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.Impressum.Impressum
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

namespace de.springwald.toolbox.Impressum
{
  public static class Impressum
  {
    public static string ImpressumTextAscii
    {
      get
      {
        return "Springwald Software GmbH\r\nAlter Eistreff 36\r\n44789 Bochum\r\nDeutschland / Germany\r\nwww.springwald.de\r\n\r\nVertretungsberechtigter Geschäftsführer: Daniel Springwald (Anschrift wie oben)\r\nAmtsgericht Bochum, Handelsregisternummer: HRB 12756\r\nUSt-IdNr: DE272058075\r\n\r\nEmail: info@springwald.de\r\nTelefon: 0700 / 777 464 925*\r\n* max. 12,4 Cent pro Minute aus dem Festnetz der Deutschen Telekom";
      }
    }

    public static string ImpressumTextHtml
    {
      get
      {
        return de.springwald.toolbox.Impressum.Impressum.ImpressumTextAscii.Replace("\r\n", "<br/>");
      }
    }
  }
}
