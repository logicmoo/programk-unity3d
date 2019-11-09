// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.IO.FileTools
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.IO;
using System.Text;

namespace de.springwald.toolbox.IO
{
  public abstract class FileTools
  {
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

    public static void AppendString2File_(string inhalt, string dateiname)
    {
      if (!File.Exists(dateiname))
      {
        FileTools.String2File(inhalt, dateiname);
      }
      else
      {
        try
        {
          StreamWriter streamWriter = new StreamWriter(dateiname, true, Encoding.GetEncoding("ISO-8859-15"));
          streamWriter.AutoFlush = true;
          streamWriter.Write(inhalt);
          streamWriter.Close();
        }
        catch (Exception ex)
        {
          throw new ApplicationException(string.Format("Konnte an ZielDatei '{0}' nicht anhängen: \n\n{1}", (object) dateiname, (object) ex));
        }
      }
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
  }
}
