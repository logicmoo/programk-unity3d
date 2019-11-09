// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.GaitoBotInterpreter
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace de.springwald.gaitobot2
{
  public class GaitoBotInterpreter
  {
    public const string SRAI_TARGET_BOTSTART = "TARGET BOTSTART";
    public const string SRAI_TARGET_EmptyInput = "TARGET EMPTYINPUT";
    public const string SRAI_TARGET_FirstBadAnswer = "TARGET FIRSTBADANSWER";
    public const string SRAI_TARGET_OnlyOneWord = "TARGET ONLYONEWORD";
    private bool _beiEinwortEingabenOhneMatchAufSraiOnlyOneWordUmleiten;
    private readonly Normalisierung _normalisierung;
    private readonly CultureInfo _loggingKultur;
    private readonly StringBuilder _ladeProtokoll;
    private GaitoBotEigenschaften _botEigenschaften;
    private readonly Wissen _wissen;

    public event GaitoBotInterpreter.AimlDateiWirdGeladenEventHandler AIMLDateiWirdGeladen;

    protected virtual void AIMLDateiWirdGeladenEvent(string dateiname)
    {
      if (this.AIMLDateiWirdGeladen == null)
        return;
      this.AIMLDateiWirdGeladen((object) this, new GaitoBotInterpreter.AimlDateiWirdGeladenEventArgs(dateiname));
    }

    public GaitoBotEigenschaften BotEigenschaften
    {
      get
      {
        if (this._botEigenschaften == null)
          throw new ApplicationException("EsWurdenNochKeineBotEigenschaftenZugewiesen");
        return this._botEigenschaften;
      }
      set
      {
        this._botEigenschaften = value;
      }
    }

    private CultureInfo LoggingKultur
    {
      get
      {
        return this._loggingKultur;
      }
    }

    public string LadeProtokoll
    {
      get
      {
        return this._ladeProtokoll.ToString();
      }
    }

    public int AnzahlCategories
    {
      get
      {
        return this._wissen.AnzahlCategories;
      }
    }

    public GaitoBotInterpreter(CultureInfo loggingKultur, StartupInfos startupInfos)
    {
      this._wissen = new Wissen();
      this._botEigenschaften = startupInfos.BotEigenschaften;
      this._loggingKultur = loggingKultur;
      this._normalisierung = new Normalisierung(startupInfos);
      this._ladeProtokoll = new StringBuilder();
    }

    public void LadenAusVerzeichnis(string verzeichnis)
    {
      this.PreInit();
      WissensLader wissensLader = new WissensLader(this._wissen, this._loggingKultur, this._normalisierung);
      wissensLader.AimlDateiWirdGeladen += new WissensLader.AimlDateiWirdGeladenEventHandler(this.loader_AIMLDateiWirdGeladen);
      wissensLader.LadeAimlDateienAusVerzeichnis(verzeichnis, this._botEigenschaften);
      wissensLader.AimlDateiWirdGeladen -= new WissensLader.AimlDateiWirdGeladenEventHandler(this.loader_AIMLDateiWirdGeladen);
      this._ladeProtokoll.Append(wissensLader.Protokoll);
      this.PostInit();
    }

    public void LadenAusDateinamen(string[] aimlDateinamen)
    {
      this.PreInit();
      WissensLader wissensLader = new WissensLader(this._wissen, this._loggingKultur, this._normalisierung);
      wissensLader.AimlDateiWirdGeladen += new WissensLader.AimlDateiWirdGeladenEventHandler(this.loader_AIMLDateiWirdGeladen);
      foreach (string aimlDateiname in aimlDateinamen)
      {
        Application.DoEvents();
        wissensLader.AIMLDateiVerarbeiten(aimlDateiname, this._botEigenschaften);
      }
      wissensLader.AimlDateiWirdGeladen -= new WissensLader.AimlDateiWirdGeladenEventHandler(this.loader_AIMLDateiWirdGeladen);
      this._ladeProtokoll.Append(wissensLader.Protokoll);
      this.PostInit();
    }

    public void LadenAusXMLDoms(List<DomDocLadePaket> xmlDoms)
    {
      this.PreInit();
      WissensLader wissensLader = new WissensLader(this._wissen, this._loggingKultur, this._normalisierung);
      wissensLader.AimlDateiWirdGeladen += new WissensLader.AimlDateiWirdGeladenEventHandler(this.loader_AIMLDateiWirdGeladen);
      foreach (DomDocLadePaket xmlDom in xmlDoms)
      {
        Application.DoEvents();
        wissensLader.AimldomDokumentVerarbeiten(xmlDom.XmlDocument, xmlDom.Dateiname, this._botEigenschaften);
      }
      wissensLader.AimlDateiWirdGeladen -= new WissensLader.AimlDateiWirdGeladenEventHandler(this.loader_AIMLDateiWirdGeladen);
      this._ladeProtokoll.Append(wissensLader.Protokoll);
      this._ladeProtokoll.AppendFormat(ResReader.Reader(this._loggingKultur).GetString("DOMDokumenteEingelesen", this._loggingKultur), (object) xmlDoms.Count, (object) this._wissen.AnzahlCategories);
      this._ladeProtokoll.Append("\n");
      this.PostInit();
    }

    public string GetAntwort(string eingabe, GaitoBotSession session)
    {
      if (eingabe == null || eingabe.Trim() == "")
        eingabe = "TARGET EMPTYINPUT";
      session.Denkprotokoll.Add(new BotDenkProtokollSchritt(eingabe, BotDenkProtokollSchritt.SchrittArten.Eingabe));
      List<AntwortSatz> antwortSatzList = new AntwortFinder(this._normalisierung.StartupInfos.SatzTrenner.ToArray(), this._normalisierung, this._wissen, session, this._botEigenschaften, this._beiEinwortEingabenOhneMatchAufSraiOnlyOneWordUmleiten).GetAntwortSaetze(eingabe);
      StringBuilder stringBuilder = new StringBuilder();
      if (antwortSatzList == null)
      {
        session.Denkprotokoll.Add(new BotDenkProtokollSchritt(ResReader.Reader(session.DenkprotokollKultur).GetString("KonnteKeineGueltigeAntwortEreugen", session.DenkprotokollKultur), BotDenkProtokollSchritt.SchrittArten.Warnung));
        antwortSatzList = new List<AntwortSatz>();
        antwortSatzList.Add(new AntwortSatz(ResReader.Reader(this.LoggingKultur).GetString("NotfallAntwort", this.LoggingKultur), true));
      }
      foreach (AntwortSatz antwortSatz in antwortSatzList)
      {
        string satz = antwortSatz.Satz;
        char[] chArray = new char[1]{ '|' };
        foreach (string str in satz.Split(chArray))
        {
          session.AddSchritt(new GaitoBotSessionSchritt()
          {
            BotAusgabe = str,
            That = session.LetzterSchritt == null ? string.Empty : session.LetzterSchritt.BotAusgabe,
            Topic = session.AktuellesThema,
            UserEingabe = eingabe
          });
          if ((uint) stringBuilder.Length > 0U)
            stringBuilder.Append(" ");
          stringBuilder.Append(str);
        }
      }
      return stringBuilder.ToString();
    }

    private void loader_AIMLDateiWirdGeladen(
      object sender,
      WissensLader.AimlDateiWirdGeladenEventArgs e)
    {
      this.AIMLDateiWirdGeladenEvent(e.Dateiname);
    }

    private void PostInit()
    {
      this.trennerLaden();
    }

    private void PreInit()
    {
    }

    private void trennerLaden()
    {
    }

    public class AimlDateiWirdGeladenEventArgs : EventArgs
    {
      public string Dateiname;

      public AimlDateiWirdGeladenEventArgs(string dateiname)
      {
        this.Dateiname = dateiname;
      }
    }

    public delegate void AimlDateiWirdGeladenEventHandler(
      object sender,
      GaitoBotInterpreter.AimlDateiWirdGeladenEventArgs e);
  }
}
