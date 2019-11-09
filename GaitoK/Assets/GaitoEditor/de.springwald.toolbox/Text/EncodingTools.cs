// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.Text.EncodingTools
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.Text;
using System.Web;

namespace de.springwald.toolbox.Text
{
  public abstract class EncodingTools
  {
    public static string AsciiUmlaute2HTML(string eingabe)
    {
      StringBuilder stringBuilder = new StringBuilder(eingabe);
      stringBuilder.Replace("ä", "&auml;");
      stringBuilder.Replace("ö", "&ouml;");
      stringBuilder.Replace("ü", "&uuml;");
      stringBuilder.Replace("Ä", "&Auml;");
      stringBuilder.Replace("Ö", "&Ouml;");
      stringBuilder.Replace("Ü", "&Uuml;");
      stringBuilder.Replace("ß", "&szlig;");
      return stringBuilder.ToString();
    }

    public static string HTML2ASCII(string eingabe)
    {
      StringBuilder stringBuilder1 = new StringBuilder(eingabe);
      stringBuilder1.Replace("/t", " ");
      stringBuilder1.Replace("/r/n", " ");
      stringBuilder1.Replace("/n", " ");
      StringBuilder stringBuilder2 = new StringBuilder(StringTools.DoppelteLeerzeichenRaus_(stringBuilder1.ToString()));
      stringBuilder2.Replace("&auml;", "ä");
      stringBuilder2.Replace("&ouml;", "ö");
      stringBuilder2.Replace("&uuml;", "ü");
      stringBuilder2.Replace("&Auml;", "Ä");
      stringBuilder2.Replace("&Ouml;", "Ö");
      stringBuilder2.Replace("&Uuml;", "Ü");
      stringBuilder2.Replace("&szlig;", "ß");
      stringBuilder2.Replace("&amp;", "&");
      stringBuilder2.Replace("&quot;", "\"");
      stringBuilder2.Replace("&#128;", "€");
      stringBuilder2.Replace("&#132;", "\"");
      stringBuilder2.Replace("&#147;", "\"");
      stringBuilder2.Replace("&nbsp;", " ");
      return stringBuilder2.ToString();
    }

    public static string EncodingSonderzeichenToAscii(string inhalt)
    {
      StringBuilder inhalt1 = new StringBuilder(inhalt);
      EncodingTools.EncodingSonderzeichenToMinimumAscii(inhalt1);
      return inhalt1.ToString();
    }

    public static void EncodingSonderzeichenToMinimumAscii(StringBuilder inhalt)
    {
      inhalt.Replace("„", "\"");
      inhalt.Replace("”", "\"");
      inhalt.Replace("&#8222;", "\"");
      inhalt.Replace("&#8221;", "\"");
      inhalt.Replace("&#8211;", "-");
      inhalt.Replace("&#8364;", "€");
    }

    public static byte[] GetBytesIso_8859_1(string umwandlungsText)
    {
      return Encoding.GetEncoding("iso-8859-1").GetBytes(umwandlungsText);
    }

    public static string GetStringIso_8859_1(byte[] umwandlungsFeld)
    {
      return Encoding.GetEncoding("iso-8859-1").GetString(umwandlungsFeld);
    }

    public static byte[] ConvertFromHHText(string text)
    {
      byte[] numArray = new byte[text.Length / 2];
      for (int index = 0; index < text.Length / 2; ++index)
        numArray[index] = Convert.ToByte(text.Substring(2 * index, 2), 16);
      return numArray;
    }

    public static string ConvertToHHText(byte[] bytes)
    {
      string str = "";
      foreach (byte num in bytes)
        str += Convert.ToString(num, 16).PadLeft(2, "0"[0]);
      return str;
    }

    public static string UrlISO88591Encode(string wert)
    {
      return HttpUtility.UrlEncode(wert, Encoding.GetEncoding("iso-8859-1"));
    }

    public static string UrlISO885915Encode(string wert)
    {
      return HttpUtility.UrlEncode(wert, Encoding.GetEncoding("iso-8859-15"));
    }

    public static string UrlISO88591Decode(string wert)
    {
      return HttpUtility.UrlDecode(wert, Encoding.GetEncoding("iso-8859-1"));
    }

    public static string UrlISO885915Decode(string wert)
    {
      return HttpUtility.UrlDecode(wert, Encoding.GetEncoding("iso-8859-15"));
    }
  }
}
