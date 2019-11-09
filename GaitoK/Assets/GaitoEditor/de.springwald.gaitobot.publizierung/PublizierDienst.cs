// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.publizierung.PublizierDienst
// Assembly: de.springwald.gaitobot.publizierung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6410624A-016E-45EA-823B-136F27836F7E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.publizierung.dll

using de.springwald.gaitobot.publizierung.Gaitobot_de_publizieren;
using de.springwald.toolbox;

namespace de.springwald.gaitobot.publizierung
{
  public class PublizierDienst
  {
    private static Publizieren _webdienst_Buffer;

    private static Publizieren Webdienst
    {
      get
      {
        if (PublizierDienst._webdienst_Buffer == null)
        {
          PublizierDienst._webdienst_Buffer = new Publizieren();
          PublizierDienst._webdienst_Buffer.Url = "http://www.gaitobot.de/gaitobot/Webservices/Publizieren.asmx";
          PublizierDienst._webdienst_Buffer.Timeout = 50000;
        }
        return PublizierDienst._webdienst_Buffer;
      }
    }

    public static bool ExistsGaitoBotID(string gaitoBotEditorID)
    {
      return PublizierDienst.Webdienst.ExistsGaitoBotID(gaitoBotEditorID);
    }

    public static void ReseteGaitoBot(string gaitoBotEditorID)
    {
      PublizierDienst.Webdienst.ReseteGaitoBot(gaitoBotEditorID);
    }

    public static long MaxKBWissen(string gaitoBotEditorID)
    {
      return PublizierDienst.Webdienst.MaxKBWissen(gaitoBotEditorID);
    }

    public static string[] AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGeben(
      string gaitoBotEditorID,
      DateiPublizierungsInfos[] dateien)
    {
      de.springwald.gaitobot.publizierung.Gaitobot_de_publizieren.DateiPublizierungsInfos[] dateien1 = GenericConverter<DateiPublizierungsInfos[], de.springwald.gaitobot.publizierung.Gaitobot_de_publizieren.DateiPublizierungsInfos[]>.ConvertTo(dateien);
      return PublizierDienst.Webdienst.AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGeben(gaitoBotEditorID, dateien1);
    }

    public static void UebertrageAIMLDatei(
      string gaitoBotEditorID,
      AIMLDateiUebertragung aimlDateiInhalt)
    {
      de.springwald.gaitobot.publizierung.Gaitobot_de_publizieren.AIMLDateiUebertragung aimlDateiInhalt1 = new de.springwald.gaitobot.publizierung.Gaitobot_de_publizieren.AIMLDateiUebertragung()
      {
        CheckString = aimlDateiInhalt.CheckString,
        Dateiname = aimlDateiInhalt.Dateiname,
        Inhalt = aimlDateiInhalt.Inhalt
      };
      PublizierDienst.Webdienst.UebertrageAIMLDatei(gaitoBotEditorID, aimlDateiInhalt1);
    }
  }
}
