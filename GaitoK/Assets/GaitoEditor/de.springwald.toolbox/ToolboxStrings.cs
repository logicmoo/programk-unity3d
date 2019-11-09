// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.ToolboxStrings
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace de.springwald.toolbox
{
  public abstract class ToolboxStrings
  {
    public static bool IsEmail(string text)
    {
      return Regex.IsMatch(text, "^[a-z0-9|ä|ü|ö|\\-|\\.|_]+@[a-z0-9|ä|ü|ö|\\-|\\.|_]+\\.[a-z]{2,4}$", RegexOptions.IgnoreCase);
    }

    public static bool IsInteger(string ausdruck)
    {
      return ToolboxStrings.IsNumeric(ausdruck, NumberStyles.Integer);
    }

    public static bool IsNumeric(string ausdruck, NumberStyles artDerZahl)
    {
      double result;
      return double.TryParse(ausdruck, artDerZahl, (IFormatProvider) NumberFormatInfo.InvariantInfo, out result);
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

    public static void String2File(string inhalt, string dateiname)
    {
      if (File.Exists(dateiname))
      {
        try
        {
          File.Delete(dateiname);
        }
        catch (Exception ex)
        {
          throw new ApplicationException(string.Format("Konnte ZielDatei '{0}' nicht löschen: \n\n{1}", (object) dateiname, (object) ex));
        }
      }
      StreamWriter streamWriter;
      try
      {
        streamWriter = new StreamWriter(dateiname, false, Encoding.GetEncoding("ISO-8859-15"));
        streamWriter.AutoFlush = true;
      }
      catch (Exception ex)
      {
        throw new ApplicationException(string.Format("Konnte ZielDatei '{0}' nicht anlegen: \n\n{1}", (object) dateiname, (object) ex));
      }
      streamWriter.Write(inhalt);
      streamWriter.Close();
    }

    public static string File2String(string dateiname)
    {
      string end;
      try
      {
        StreamReader streamReader = new StreamReader(dateiname, Encoding.GetEncoding("ISO-8859-15"));
        end = streamReader.ReadToEnd();
        streamReader.Close();
      }
      catch (FileNotFoundException ex)
      {
        throw new ApplicationException(string.Format("Konnte Datei '{0}' nicht einlesen:\n{1}", (object) dateiname, (object) ex.Message));
      }
      return end;
    }

    public static string DoppelteLeerzeichenRaus(string eingabe)
    {
      string str1 = "";
      string str2;
      for (str2 = eingabe; str1 != str2; str2 = str2.Replace("  ", " "))
        str1 = str2;
      return str2;
    }

    public static string VerlaengereStringLinks(string eingabeString, int size, char fill)
    {
      while (eingabeString.Length < size)
        eingabeString = fill.ToString() + eingabeString;
      return eingabeString;
    }

    public static string UmlauteAussschreiben(string eingabe)
    {
      StringBuilder stringBuilder = new StringBuilder(eingabe);
      stringBuilder.Replace("Ä", "Ae");
      stringBuilder.Replace("Ü", "Ue");
      stringBuilder.Replace("Ö", "Oe");
      stringBuilder.Replace("ä", "ae");
      stringBuilder.Replace("ö", "oe");
      stringBuilder.Replace("ü", "ue");
      stringBuilder.Replace("ß", "ss");
      return stringBuilder.ToString();
    }

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
      StringBuilder stringBuilder2 = new StringBuilder(ToolboxStrings.DoppelteLeerzeichenRaus(stringBuilder1.ToString()));
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
  }
}
