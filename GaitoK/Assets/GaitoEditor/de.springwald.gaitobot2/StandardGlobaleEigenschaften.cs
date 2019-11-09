// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.StandardGlobaleEigenschaften
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System;
using System.Globalization;

namespace de.springwald.gaitobot2
{
  public class StandardGlobaleEigenschaften
  {
    public static string GetStandardConditionContent(string name)
    {
      name = name.ToLower().Trim();
      try
      {
        if (name.StartsWith("datetime."))
          return StandardGlobaleEigenschaften.GetDateTimeCondition(name);
      }
      catch (Exception ex)
      {
        return string.Format("Error processing GetDateTimeCondition '{0}': {1} ", (object) name, (object) ex.Message);
      }
      return (string) null;
    }

    private static string GetDateTimeCondition(string name)
    {
      DateTime now = DateTime.Now;
      switch (name)
      {
        case "datetime.now.day":
          return now.Day.ToString();
        case "datetime.now.dayofweek":
          switch (now.DayOfWeek)
          {
            case DayOfWeek.Sunday:
              return "7";
            case DayOfWeek.Monday:
              return "1";
            case DayOfWeek.Tuesday:
              return "2";
            case DayOfWeek.Wednesday:
              return "3";
            case DayOfWeek.Thursday:
              return "4";
            case DayOfWeek.Friday:
              return "5";
            case DayOfWeek.Saturday:
              return "6";
            default:
              throw new ApplicationException(string.Format("Unbehandelter DayOfWeek '{0}'", (object) now.DayOfWeek));
          }
        case "datetime.now.dayofweekname":
          return CultureInfo.CurrentCulture.DateTimeFormat.DayNames[(int) now.DayOfWeek].ToString();
        case "datetime.now.dayofyear":
          return now.DayOfYear.ToString();
        case "datetime.now.hour":
          return now.Hour.ToString();
        case "datetime.now.millisecond":
          return now.Millisecond.ToString();
        case "datetime.now.minute":
          return now.Minute.ToString();
        case "datetime.now.month":
          return now.Month.ToString();
        case "datetime.now.monthname":
          return DateTimeFormatInfo.CurrentInfo.MonthNames[now.Month - 1];
        case "datetime.now.second":
          return now.Second.ToString();
        case "datetime.now.year":
          return now.Year.ToString();
        default:
          throw new ApplicationException(string.Format("Unbehandelte DateTime-Syntax '{0}'", (object) name));
      }
    }
  }
}
