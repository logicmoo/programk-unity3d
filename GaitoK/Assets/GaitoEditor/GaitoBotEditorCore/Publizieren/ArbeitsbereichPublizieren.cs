// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.Publizieren.ArbeitsbereichPublizieren
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.gaitobot.publizierung;
using de.springwald.toolbox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GaitoBotEditorCore.Publizieren
{
  public class ArbeitsbereichPublizieren : IDisposable
  {
    private string _arbeitsVerzeichnis;
    private Arbeitsbereich _arbeitsbereich;
    private StringBuilder _ergebnisProtokoll;

    private long GroesseExportInByte
    {
      get
      {
        long num = 0;
        foreach (string file in Directory.GetFiles(this.ExportVerzeichnis))
        {
          FileInfo fileInfo = new FileInfo(file);
          num += fileInfo.Length;
        }
        return num;
      }
    }

    public event EventHandler<PublizierenEventArgs> PublizerEvent;

    public ArbeitsbereichPublizieren.ergebnisse Ergebnis { get; set; }

    private string ExportVerzeichnis
    {
      get
      {
        if (this._arbeitsVerzeichnis == null)
        {
          int num = 0;
          do
          {
            ++num;
            this._arbeitsVerzeichnis = Path.Combine(Config.GlobalConfig.ArbeitsbereicheSpeicherVerzeichnis, string.Format("{0}_temp", (object) num));
          }
          while (Directory.Exists(this._arbeitsVerzeichnis));
          Directory.CreateDirectory(this._arbeitsVerzeichnis);
        }
        return this._arbeitsVerzeichnis;
      }
    }

    public ArbeitsbereichPublizieren(Arbeitsbereich arbeitsbereich)
    {
      this._arbeitsbereich = arbeitsbereich;
      this.Ergebnis = ArbeitsbereichPublizieren.ergebnisse.undefiniert;
      this._ergebnisProtokoll = new StringBuilder();
    }

    public void Publizieren()
    {
      this.Ergebnis = ArbeitsbereichPublizieren.ergebnisse.erfolgreich;
      this._ergebnisProtokoll = new StringBuilder();
      this.Protkolliere(GaitoBotEditorCore.ResReader.Reader.GetString("PublizierungGestartet"));
      if (!this._arbeitsbereich.SindAlleZuExportierendenDateienFehlerFrei)
      {
        this.ZeigeFehler(GaitoBotEditorCore.ResReader.Reader.GetString("PublizierenNichtAlleAIMLDateienKorrekt"), "Publizieren:Checking AIML-Files");
        this.Ergebnis = ArbeitsbereichPublizieren.ergebnisse.fehlerhaft;
      }
      else
      {
        string gaitoBotEditorID = this._arbeitsbereich.GaitoBotID;
        if (gaitoBotEditorID != null)
          gaitoBotEditorID = gaitoBotEditorID.Trim();
        if (string.IsNullOrEmpty(gaitoBotEditorID))
        {
          this.ZeigeFehler(GaitoBotEditorCore.ResReader.Reader.GetString("KeineGaitoBotIDEingegeben"), "Publizieren:Checking GaitoBotID");
          this.Ergebnis = ArbeitsbereichPublizieren.ergebnisse.fehlerhaft;
        }
        else
        {
          bool flag;
          try
          {
            flag = PublizierDienst.ExistsGaitoBotID(this._arbeitsbereich.GaitoBotID);
          }
          catch (Exception ex)
          {
            this.ZeigeFehler(string.Format(GaitoBotEditorCore.ResReader.Reader.GetString("FehlerBeiGaitoBotWebServiceZugriff"), (object) ex.Message), nameof (Publizieren));
            this.Ergebnis = ArbeitsbereichPublizieren.ergebnisse.fehlerhaft;
            goto label_33;
          }
          if (flag)
          {
            this.Protkolliere(GaitoBotEditorCore.ResReader.Reader.GetString("GaitotbotIDExistiert"));
            this.Protkolliere(GaitoBotEditorCore.ResReader.Reader.GetString("AIMLDateienWerdenExportiert"));
            bool abgebrochen = false;
            this._arbeitsbereich.Exportieren(this.ExportVerzeichnis, Arbeitsbereich.VerzeichnisVorherLeeren.leerenUndNichtVorherFragen, true, true, out abgebrochen);
            if (abgebrochen)
            {
              this.Ergebnis = ArbeitsbereichPublizieren.ergebnisse.fehlerhaft;
            }
            else
            {
              long num1 = (long) (int) (this.GroesseExportInByte / 1024L);
              this.Protkolliere(string.Format(GaitoBotEditorCore.ResReader.Reader.GetString("AIMLExportGroesseLautetKB"), (object) num1));
              long num2 = PublizierDienst.MaxKBWissen(this._arbeitsbereich.GaitoBotID);
              this.Protkolliere(string.Format(GaitoBotEditorCore.ResReader.Reader.GetString("AIMLExportGroesseErlaubtKB"), (object) num2));
              if (num1 > num2)
              {
                this.ZeigeFehler(GaitoBotEditorCore.ResReader.Reader.GetString("AIMLExportZuGrossFuerPublizieren"), "Publizieren:Checking export size");
                this.Ergebnis = ArbeitsbereichPublizieren.ergebnisse.fehlerhaft;
              }
              else
              {
                this.Protkolliere(GaitoBotEditorCore.ResReader.Reader.GetString("LoescheAlteAIMLDateienRemote"));
                List<DateiPublizierungsInfos> source1 = new List<DateiPublizierungsInfos>();
                foreach (string file in Directory.GetFiles(this.ExportVerzeichnis, "*.*"))
                {
                  DateiPublizierungsInfos publizierungsInfos1 = new DateiPublizierungsInfos();
                  publizierungsInfos1.SetzeWerte(file);
                  DateiPublizierungsInfos publizierungsInfos2 = new DateiPublizierungsInfos() { CRC32Checksumme = publizierungsInfos1.CRC32Checksumme, Dateiname = publizierungsInfos1.Dateiname, Groesse = publizierungsInfos1.Groesse, GesamtCheckString = publizierungsInfos1.GesamtCheckString };
                  source1.Add(publizierungsInfos2);
                }
                string[] toDoDateinamen = (string[]) null;
                try
                {
                  toDoDateinamen = PublizierDienst.AlteOderGeloeschteDateienLoeschenUndHochzuladendeZurueckGeben(this._arbeitsbereich.GaitoBotID, source1.ToArray());
                }
                catch (Exception ex)
                {
                  this.ZeigeFehler(string.Format(GaitoBotEditorCore.ResReader.Reader.GetString("FehlerBeimRemoteLoeschen"), (object) ex.Message), "Publizieren:deleting old remote files");
                  this.Ergebnis = ArbeitsbereichPublizieren.ergebnisse.fehlerhaft;
                  goto label_33;
                }
                IEnumerable<DateiPublizierungsInfos> source2 = source1.Where<DateiPublizierungsInfos>((Func<DateiPublizierungsInfos, bool>) (toDo => ((IEnumerable<string>) toDoDateinamen).Contains<string>(toDo.Dateiname)));
                this.Protkolliere(string.Format(GaitoBotEditorCore.ResReader.Reader.GetString("AnzahlDateienZuPublizieren"), (object) source2.Count<DateiPublizierungsInfos>()));
                foreach (DateiPublizierungsInfos publizierungsInfos in source2)
                {
                  try
                  {
                    this.Protkolliere(string.Format(GaitoBotEditorCore.ResReader.Reader.GetString("PubliziereDatei"), (object) publizierungsInfos.Dateiname));
                    AIMLDateiUebertragung aimlDateiInhalt = new AIMLDateiUebertragung() { CheckString = publizierungsInfos.GesamtCheckString, Dateiname = publizierungsInfos.Dateiname, Inhalt = ToolboxStrings.File2String(Path.Combine(this.ExportVerzeichnis, publizierungsInfos.Dateiname)) };
                    PublizierDienst.UebertrageAIMLDatei(gaitoBotEditorID, aimlDateiInhalt);
                  }
                  catch (Exception ex)
                  {
                    this.ZeigeFehler(string.Format(GaitoBotEditorCore.ResReader.Reader.GetString("FehlerBeimDateiPublizieren"), (object) publizierungsInfos.Dateiname, (object) ex.Message), "Publizieren:transfering file");
                    this.Ergebnis = ArbeitsbereichPublizieren.ergebnisse.fehlerhaft;
                  }
                }
                try
                {
                  this.Protkolliere("Resete GaitoBot auf Server");
                  PublizierDienst.ReseteGaitoBot(gaitoBotEditorID);
                }
                catch (Exception ex)
                {
                  this.ZeigeFehler(string.Format(GaitoBotEditorCore.ResReader.Reader.GetString("FehlerBeimDateiPublizieren"), (object) "", (object) ex.Message), "Publizieren:reseting gaitobot on server");
                  this.Ergebnis = ArbeitsbereichPublizieren.ergebnisse.fehlerhaft;
                }
              }
            }
          }
          else
          {
            this.ZeigeFehler(GaitoBotEditorCore.ResReader.Reader.GetString("GaitotbotIDExistiertNicht"), "Publizieren:Checking GaitoBotID");
            this.Ergebnis = ArbeitsbereichPublizieren.ergebnisse.fehlerhaft;
          }
        }
      }
label_33:
      this.TempverzeichnisWiederLoeschen();
      switch (this.Ergebnis)
      {
        case ArbeitsbereichPublizieren.ergebnisse.erfolgreich:
          this.Protkolliere(GaitoBotEditorCore.ResReader.Reader.GetString("PublizierungErfolgreich"));
          break;
        case ArbeitsbereichPublizieren.ergebnisse.fehlerhaft:
          this.Protkolliere(GaitoBotEditorCore.ResReader.Reader.GetString("PublizierungFehlerhaft"));
          break;
        default:
          throw new ApplicationException("Unbehandeltes Publizierungsergebnis: " + (object) this.Ergebnis);
      }
      this.Ergebnis = ArbeitsbereichPublizieren.ergebnisse.erfolgreich;
    }

    private void TempverzeichnisWiederLoeschen()
    {
      try
      {
        Directory.Delete(this.ExportVerzeichnis, true);
      }
      finally
      {
        this._arbeitsVerzeichnis = (string) null;
      }
    }

    private void Protkolliere(string inhalt)
    {
      if (this.PublizerEvent != null)
        this.PublizerEvent((object) this, new PublizierenEventArgs()
        {
          Meldung = string.Format("{0}", (object) inhalt)
        });
      this._ergebnisProtokoll.AppendFormat(string.Format("{0}\r\n", (object) inhalt));
      Debugger.GlobalDebugger.Protokolliere(inhalt, Debugger.ProtokollTypen.TechnischerVorgang);
    }

    private void ZeigeFehler(string inhalt, string kontext)
    {
      if (this.PublizerEvent != null)
        this.PublizerEvent((object) this, new PublizierenEventArgs()
        {
          Meldung = string.Format("{0}:{1}", (object) GaitoBotEditorCore.ResReader.Reader.GetString("Fehler"), (object) inhalt)
        });
      this._ergebnisProtokoll.AppendFormat("{0}:{1} ({2})\r\n", (object) GaitoBotEditorCore.ResReader.Reader.GetString("Fehler"), (object) inhalt, (object) kontext);
      Debugger.GlobalDebugger.FehlerZeigen(inhalt, (object) nameof (ArbeitsbereichPublizieren), kontext);
    }

    public void Dispose()
    {
      if (this._arbeitsVerzeichnis == null)
        return;
      try
      {
        Directory.Delete(this._arbeitsVerzeichnis, true);
      }
      finally
      {
      }
    }

    public enum ergebnisse
    {
      undefiniert,
      erfolgreich,
      fehlerhaft,
    }
  }
}
