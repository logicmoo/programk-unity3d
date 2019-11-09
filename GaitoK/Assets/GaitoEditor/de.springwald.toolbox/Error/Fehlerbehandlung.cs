// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.Error.Fehlerbehandlung
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace de.springwald.toolbox.Error
{
  public abstract class Fehlerbehandlung
  {
    public static string FehlerEmailAbsender
    {
      get
      {
        return "info@springwald.de";
      }
    }

    public static string FehlerEmailEmpfaenger
    {
      get
      {
        return "info@springwald.de";
      }
    }

    public static string GenExceptionInfos(
      Exception exception,
      params string[] zusatzinformationszeilen)
    {
      return Fehlerbehandlung.GenExceptionInfos(exception, true, zusatzinformationszeilen);
    }

    public static string GenExceptionInfos(
      Exception exception,
      bool systemdetails,
      params string[] zusatzinformationszeilen)
    {
      StringBuilder stringBuilder1 = new StringBuilder();
      StringBuilder stringBuilder2 = stringBuilder1;
      DateTime dateTime = DateTime.Now;
      string str1 = dateTime.ToString();
      dateTime = DateTime.Now;
      dateTime = dateTime.ToUniversalTime();
      string str2 = dateTime.ToString();
      stringBuilder2.AppendFormat("Es wurde um {0} ({1} UTC) ein Fehler aufgezeichnet.\r\n\r\n", (object) str1, (object) str2);
      Exception exception1 = exception == null ? (Exception) null : exception.GetBaseException();
      if (exception1 != null)
        stringBuilder1.Append("Fehlermeldung: " + exception1.Message + "\r\n");
      try
      {
        stringBuilder1.AppendFormat("NetBIOS-Name: {0}\r\n", (object) Environment.MachineName);
      }
      catch (Exception ex)
      {
        stringBuilder1.AppendFormat("Der NetBIOS-Name des Computers kann nicht ermittelt werden: {0}\r\n", (object) ex.Message);
      }
      try
      {
        stringBuilder1.AppendFormat("DNS-Hostnamen: {0}\r\n", (object) Dns.GetHostName());
      }
      catch (Exception ex)
      {
        stringBuilder1.AppendFormat("Beim Auflösen des Hostnamens ist ein Fehler aufgetreten: {0}\r\n", (object) ex.Message);
      }
      HttpContext current1 = HttpContext.Current;
      if (current1 != null && current1.Request != null)
      {
        stringBuilder1.Append("Http Servername: " + current1.Request.ServerVariables.Get("SERVER_NAME") + "\r\n");
        if (systemdetails)
          stringBuilder1.Append("Http ServerIP: " + current1.Request.ServerVariables.Get("LOCAL_ADDR") + "\r\n");
        if (current1.Request.Url != (Uri) null)
          stringBuilder1.Append("Http Url: " + current1.Request.Url.AbsoluteUri + "\r\n");
      }
      if (systemdetails)
      {
        stringBuilder1.Append("App UserName: " + Environment.UserName + "\r\n");
        try
        {
          stringBuilder1.Append("App UserDomainName: " + Environment.UserDomainName + "\r\n");
        }
        catch
        {
        }
        stringBuilder1.Append("UserInteractive: " + (object) Environment.UserInteractive + "\r\n");
      }
      if (zusatzinformationszeilen != null && (uint) zusatzinformationszeilen.Length > 0U)
      {
        stringBuilder1.Append(Fehlerbehandlung.ErzeugeKopfzeile("Zusatzinformationen"));
        foreach (string str3 in zusatzinformationszeilen)
          stringBuilder1.Append(" >> " + str3 + "\r\n");
      }
      if (systemdetails)
      {
        Exception exception2 = exception;
        for (int index = 0; exception2 != null && index > -20; exception2 = exception2.InnerException)
        {
          stringBuilder1.Append(Fehlerbehandlung.ErzeugeExceptionDateils(string.Format("Exception Ebene: {0}", (object) index.ToString()), exception2));
          --index;
        }
      }
      if (systemdetails)
      {
        try
        {
          AppDomain currentDomain = AppDomain.CurrentDomain;
          if (currentDomain != null)
          {
            stringBuilder1.Append(Fehlerbehandlung.ErzeugeKopfzeile("AppDomain"));
            stringBuilder1.Append("AppDomain.BaseDirectory: " + currentDomain.BaseDirectory + "\r\n");
            stringBuilder1.Append("AppDomain.RelativeSearchPath: " + currentDomain.RelativeSearchPath + "\r\n");
            stringBuilder1.Append("AppDomain.FriendlyName: " + currentDomain.FriendlyName + "\r\n");
            stringBuilder1.Append("AppDomain.Id: " + (object) currentDomain.Id + "\r\n");
            if (currentDomain.SetupInformation != null)
            {
              stringBuilder1.Append(Fehlerbehandlung.ErzeugeKopfzeile("SetupInformation"));
              stringBuilder1.Append("SetupInformation.ApplicationBase: " + currentDomain.SetupInformation.ApplicationBase + "\r\n");
              stringBuilder1.Append("SetupInformation.ApplicationName: " + currentDomain.SetupInformation.ApplicationName + "\r\n");
              stringBuilder1.Append("SetupInformation.ConfigurationFile: " + currentDomain.SetupInformation.ConfigurationFile + "\r\n");
              stringBuilder1.Append("SetupInformation.PrivateBinPath: " + currentDomain.SetupInformation.PrivateBinPath + "\r\n");
            }
          }
        }
        catch (Exception ex)
        {
          stringBuilder1.AppendFormat("Fehler beim Zugriff auf Werte der AppDomain.CurrentDomain: {0}\r\n", (object) ex.Message);
        }
        stringBuilder1.Append("Environment.CommandLine: " + Environment.CommandLine + "\r\n");
      }
      if (systemdetails)
      {
        try
        {
          HttpContext current2 = HttpContext.Current;
          if (current2 != null && current2.Request != null)
          {
            stringBuilder1.Append(Fehlerbehandlung.ErzeugeKopfzeile("HTTPAufrufdetails"));
            stringBuilder1.Append("RequestType: " + current2.Request.RequestType + "\r\n");
            stringBuilder1.Append("Url: " + current2.Request.Url.AbsoluteUri + "\r\n");
            stringBuilder1.Append("Path: " + current2.Request.Path + "\r\n");
            stringBuilder1.Append("ApplicationPath: " + current2.Request.ApplicationPath + "\r\n");
            stringBuilder1.Append("Handler: " + (current2.Handler == null ? "null" : current2.Handler.ToString()) + "\r\n");
            stringBuilder1.Append(Fehlerbehandlung.ErzeugeKopfzeile("Session"));
            if (current2.Handler != null && (current2.Handler is IRequiresSessionState || current2.Handler is IReadOnlySessionState))
            {
              stringBuilder1.Append("Session.IsNewSession: " + (object) current2.Session.IsNewSession + "\r\n");
              stringBuilder1.Append("Session.IsReadOnly: " + (object) current2.Session.IsReadOnly + "\r\n");
              stringBuilder1.Append("Session.SessionID: " + current2.Session.SessionID + "\r\n");
              stringBuilder1.Append("Session.Count: " + (object) current2.Session.Count + "\r\n");
            }
            stringBuilder1.Append(Fehlerbehandlung.ErzeugeKopfzeile("QueryString"));
            if (current2.Request.QueryString != null && current2.Request.QueryString.Count > 0)
            {
              foreach (string allKey in current2.Request.QueryString.AllKeys)
                stringBuilder1.Append(allKey + "=" + current2.Request.QueryString[allKey] + "\r\n");
            }
            stringBuilder1.Append(Fehlerbehandlung.ErzeugeKopfzeile("PostData"));
            if (current2.Request.Form != null && current2.Request.Form.Count > 0)
            {
              foreach (string allKey in current2.Request.Form.AllKeys)
                stringBuilder1.Append(allKey + "=" + current2.Request.Form[allKey] + "\r\n");
            }
            stringBuilder1.Append(Fehlerbehandlung.ErzeugeKopfzeile("HTTP ServerVariables"));
            foreach (string allKey in current2.Request.ServerVariables.AllKeys)
              stringBuilder1.Append(allKey + "=" + current2.Request.ServerVariables[allKey] + "\r\n");
          }
        }
        catch (Exception ex)
        {
          stringBuilder1.Append("Fehler beim Zugriff auf Werte des HttpContext: " + ex.Message);
        }
      }
      return stringBuilder1.ToString();
    }

    private static string ErzeugeKopfzeile(string kopfzeile)
    {
      if (kopfzeile == null)
        kopfzeile = string.Empty;
      else if (kopfzeile.Length < 52)
        kopfzeile = kopfzeile.PadLeft(26 + kopfzeile.Length / 2).PadRight(52);
      return string.Format("\r\n\r\n{0}{0}\r\n--- {1} ---\r\n{0}{0}\r\n\r\n", (object) "------------------------------", (object) kopfzeile);
    }

    private static string ErzeugeExceptionDateils(string kopfzeile, Exception exception)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(Fehlerbehandlung.ErzeugeKopfzeile(kopfzeile));
      if (exception != null)
      {
        stringBuilder.Append("Message: " + exception.Message + "\r\n");
        stringBuilder.Append("Source: " + exception.Source + "\r\n");
        stringBuilder.Append("TargetSite: " + (exception.TargetSite == null ? "" : exception.TargetSite.ToString()) + "\r\n");
        try
        {
          stringBuilder.Append("Assembly: " + (exception.TargetSite == null || exception.TargetSite.Module == null || exception.TargetSite.Module.Assembly == null ? "" : exception.TargetSite.Module.Assembly.FullName) + "\r\n");
        }
        catch
        {
        }
        stringBuilder.Append("StackTrace:\r\n" + exception.StackTrace + "\r\n");
        if (exception.Data != null && exception.Data.Count > 0)
        {
          stringBuilder.Append("UserData:\r\n");
          foreach (object key in (IEnumerable) exception.Data.Keys)
            stringBuilder.Append(">" + key + ": " + exception.Data[key] + "\r\n");
        }
      }
      return stringBuilder.ToString();
    }

    public static string fehlermeldungErzeugen(
      string ortsBeschreibung,
      Exception oE,
      string benutzerBeschreibung,
      HttpContext context)
    {
      StringBuilder stringBuilder = new StringBuilder();
      List<string> stringList = new List<string>();
      if (ortsBeschreibung != null)
        stringList.Add("Ort: " + ortsBeschreibung);
      if (context != null && context.Session != null && context.Session["UserSession.LogSessionIDKey"] != null)
        stringList.Add("SessionLog-ID: " + context.Session["UserSession.LogSessionIDKey"]);
      if (!string.IsNullOrEmpty(benutzerBeschreibung))
        stringList.Add("Angemeldeter Benutzer: " + benutzerBeschreibung);
      return Fehlerbehandlung.GenExceptionInfos(oE, stringList.ToArray());
    }
  }
}
