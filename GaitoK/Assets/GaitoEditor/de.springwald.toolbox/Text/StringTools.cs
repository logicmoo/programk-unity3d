// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.Text.StringTools
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.Globalization;
using System.Text;
using System.Web;

namespace de.springwald.toolbox.Text
{
  public class StringTools
  {
    public static void DoppelteLeerzeichenRaus_(StringBuilder eingabe)
    {
      long num = -1;
      while (num != (long) eingabe.Length)
      {
        num = (long) eingabe.Length;
        eingabe.Replace("  ", " ");
      }
    }

    public static string StringMax(string eingabe, int maxlaenge, string abkuerzungszeichen)
    {
      return string.IsNullOrEmpty(eingabe) || eingabe.Length <= maxlaenge ? eingabe : eingabe.Substring(0, maxlaenge) + abkuerzungszeichen;
    }

    public static string DoppelteLeerzeichenRaus_(string eingabe)
    {
      StringBuilder stringBuilder = new StringBuilder(eingabe);
      long num = -1;
      while (num != (long) stringBuilder.Length)
      {
        num = (long) stringBuilder.Length;
        stringBuilder.Replace("  ", " ");
      }
      return stringBuilder.ToString();
    }

    public static bool IsInteger(string ausdruck)
    {
      return StringTools.IsNumeric(ausdruck, NumberStyles.Integer);
    }

    public static bool IsNumeric(string ausdruck, NumberStyles artDerZahl)
    {
      double result;
      return double.TryParse(ausdruck, artDerZahl, (IFormatProvider) NumberFormatInfo.InvariantInfo, out result);
    }

    [Obsolete("Verwende EncodingTools.UrlISO885915Encode")]
    public static string URLEncode(string rohstring)
    {
      return EncodingTools.UrlISO885915Encode(rohstring);
    }

    public static string HTMLEncode(string rohstring)
    {
      return HttpUtility.HtmlEncode(rohstring);
    }

    public static string HTMLDecode(string rohString)
    {
      return HttpUtility.HtmlDecode(rohString);
    }

    public static string ReplaceEx(string original, string pattern, string replacement)
    {
      int num1;
      int num2 = num1 = 0;
      int startIndex = num1;
      int length = num1;
      string upper1 = original.ToUpper();
      string upper2 = pattern.ToUpper();
      int val2 = original.Length / pattern.Length * (replacement.Length - pattern.Length);
      char[] chArray = new char[original.Length + Math.Max(0, val2)];
      int num3;
      for (; (num3 = upper1.IndexOf(upper2, startIndex)) != -1; startIndex = num3 + pattern.Length)
      {
        for (int index = startIndex; index < num3; ++index)
          chArray[length++] = original[index];
        for (int index = 0; index < replacement.Length; ++index)
          chArray[length++] = replacement[index];
      }
      if (startIndex == 0)
        return original;
      for (int index = startIndex; index < original.Length; ++index)
        chArray[length++] = original[index];
      return new string(chArray, 0, length);
    }
  }
}
