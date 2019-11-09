// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.ArbeitsbereichDateiverwaltung
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.gaitobot.content;
using de.springwald.toolbox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GaitoBotEditorCore
{
  public class ArbeitsbereichDateiverwaltung
  {
    private readonly List<IArbeitsbereichDatei> _dateien;
    private readonly string _arbeitsVerzeichnis;

    public event EventHandler AimlDateienContentChanged;

    protected virtual void OnAimlDateienContentChangedEvent()
    {
      if (this.AimlDateienContentChanged == null)
        return;
      this.AimlDateienContentChanged((object) this, EventArgs.Empty);
    }

    public event EventHandler<EventArgs<IArbeitsbereichDatei>> DateiAddedEvent;

    protected virtual void DateiAdded(IArbeitsbereichDatei datei)
    {
      if (this.DateiAddedEvent == null)
        return;
      this.DateiAddedEvent((object) this, new EventArgs<IArbeitsbereichDatei>(datei));
    }

    public event EventHandler<EventArgs<IArbeitsbereichDatei>> DateiRemovedEvent;

    protected virtual void AimlDateiRemoved(IArbeitsbereichDatei datei)
    {
      if (this.DateiRemovedEvent == null)
        return;
      this.DateiRemovedEvent((object) this, new EventArgs<IArbeitsbereichDatei>(datei));
    }

    public event EventHandler<EventArgs<string>> AimlDateiWirdGeladenEvent;

    protected virtual void AimlDateiWirdGeladen(string dateiname)
    {
      if (this.AimlDateiWirdGeladenEvent == null)
        return;
      this.AimlDateiWirdGeladenEvent((object) this, new EventArgs<string>(dateiname));
    }

    public event EventHandler AimlDateiFertigGeladenEvent;

    protected virtual void AimlDateiFertigGeladen()
    {
      if (this.AimlDateiFertigGeladenEvent == null)
        return;
      this.AimlDateiFertigGeladenEvent((object) this, EventArgs.Empty);
    }

    public List<IArbeitsbereichDatei> Dateien
    {
      get
      {
        return this._dateien;
      }
    }

    public List<AIMLDatei> AlleAimlDateien
    {
      get
      {
        return this._dateien.Where<IArbeitsbereichDatei>((Func<IArbeitsbereichDatei, bool>) (d => d is AIMLDatei)).Select<IArbeitsbereichDatei, AIMLDatei>((Func<IArbeitsbereichDatei, AIMLDatei>) (d => (AIMLDatei) d)).ToList<AIMLDatei>();
      }
    }

    public bool DateienIsChanged
    {
      get
      {
        return this._dateien.Any<IArbeitsbereichDatei>((Func<IArbeitsbereichDatei, bool>) (datei => datei.IsChanged));
      }
    }

    public ArbeitsbereichDateiverwaltung(string arbeitsverzeichnis)
    {
      this._arbeitsVerzeichnis = arbeitsverzeichnis;
      this._dateien = new List<IArbeitsbereichDatei>();
    }

    public void VordefinierteDateienHinzulinken(Arbeitsbereich arbeitsbereich)
    {
      if (arbeitsbereich.Dateiverwaltung != this)
        throw new ApplicationException("Arbeitsbereich passt nicht zur ArbeitsbereichDateiverwaltung!");
      ContentManager contentManager = new ContentManager();
      foreach (string contentElementUniqueId in arbeitsbereich.ContentElementUniqueIds)
      {
        string uniqueId = contentElementUniqueId;
        if (!this._dateien.Where<IArbeitsbereichDatei>((Func<IArbeitsbereichDatei, bool>) (d =>
        {
          if (!string.IsNullOrEmpty(d.ZusatzContentUniqueId))
            return d.ZusatzContentUniqueId == uniqueId;
          return false;
        })).Any<IArbeitsbereichDatei>())
        {
          foreach (ContentDokument dokument in contentManager.GetDokumente(uniqueId))
          {
            string dateiExtension = dokument.DateiExtension;
            if (!(dateiExtension == "aiml"))
            {
              if (!(dateiExtension == "startup"))
                throw new ApplicationException(string.Format("Unbekannte Content-Datei-Extension '{0}' in '{1}'", (object) dokument.DateiExtension, (object) dokument.Titel));
              this.DateiAdded((IArbeitsbereichDatei) this.AddStartUpdateiHinzugelinkteContent(dokument, arbeitsbereich));
            }
            else
              this.DateiAdded((IArbeitsbereichDatei) this.AddAimlHinzugelinkteContentDatei(dokument, arbeitsbereich));
          }
        }
      }
      List<IArbeitsbereichDatei> arbeitsbereichDateiList = new List<IArbeitsbereichDatei>();
      foreach (IArbeitsbereichDatei arbeitsbereichDatei in this.Dateien)
      {
        if (!string.IsNullOrEmpty(arbeitsbereichDatei.ZusatzContentUniqueId) && !((IEnumerable<string>) arbeitsbereich.ContentElementUniqueIds).Contains<string>(arbeitsbereichDatei.ZusatzContentUniqueId))
          arbeitsbereichDateiList.Add(arbeitsbereichDatei);
      }
      foreach (IArbeitsbereichDatei datei in arbeitsbereichDateiList)
        this.DateiLoeschen(datei, arbeitsbereich);
    }

    public AIMLDatei VorhandeneExterneAimlDateiImportieren(
      string externerDateiname,
      Arbeitsbereich zielArbeitsbereich)
    {
      if (zielArbeitsbereich.Dateiverwaltung != this)
        throw new ApplicationException("Arbeitsbereich passt nicht zur ArbeitsbereichDateiverwaltung!");
      string vorgabe = AIMLDatei.TitelAusDateinameHerleiten(externerDateiname);
      bool abgebrochen = false;
      string str = this.ErmittleFreienNamenFuerAimlDatei(vorgabe, "aiml", out abgebrochen);
      if (abgebrochen)
        return (AIMLDatei) null;
      try
      {
        File.Copy(externerDateiname, str);
      }
      catch (Exception ex)
      {
        throw new AIMLDatei.AIMLDateiNichtGeladenException(ex.Message);
      }
      this.AimlDateiWirdGeladen(str);
      AIMLDatei aimlDatei = new AIMLDatei(zielArbeitsbereich);
      aimlDatei.OnChanged += new EventHandler(this.AimlDateiOnChanged);
      try
      {
        aimlDatei.LiesAusDatei(str, this._arbeitsVerzeichnis);
        this._dateien.Add((IArbeitsbereichDatei) aimlDatei);
        this.AimlDateiFertigGeladen();
        return aimlDatei;
      }
      catch (AIMLDatei.AIMLDateiNichtGeladenException ex1)
      {
        try
        {
          File.Delete(str);
        }
        catch (Exception ex2)
        {
        }
        throw new AIMLDatei.AIMLDateiNichtGeladenException(ex1.Message);
      }
    }

    public StartupDatei VorhandeneExterneStartupDateiImportieren(
      string externerDateiname,
      Arbeitsbereich zielArbeitsbereich)
    {
      if (zielArbeitsbereich.Dateiverwaltung != this)
        throw new ApplicationException("Arbeitsbereich passt nicht zur ArbeitsbereichDateiverwaltung!");
      string vorgabe = StartupDatei.TitelAusDateinameHerleiten(externerDateiname);
      bool abgebrochen = false;
      string str = this.ErmittleFreienNamenFuerAimlDatei(vorgabe, "startup", out abgebrochen);
      if (abgebrochen)
        return (StartupDatei) null;
      try
      {
        File.Copy(externerDateiname, str);
      }
      catch (Exception ex)
      {
        throw new AIMLDatei.AIMLDateiNichtGeladenException(ex.Message);
      }
      this.AimlDateiWirdGeladen(str);
      StartupDatei startupDatei = new StartupDatei(zielArbeitsbereich);
      startupDatei.OnChanged += new EventHandler(this.AimlDateiOnChanged);
      try
      {
        startupDatei.LiesAusDatei(str, this._arbeitsVerzeichnis);
        this._dateien.Add((IArbeitsbereichDatei) startupDatei);
        this.AimlDateiFertigGeladen();
        return startupDatei;
      }
      catch (AIMLDatei.AIMLDateiNichtGeladenException ex1)
      {
        try
        {
          File.Delete(str);
        }
        catch (Exception ex2)
        {
        }
        throw new AIMLDatei.AIMLDateiNichtGeladenException(ex1.Message);
      }
    }

    public bool DateiLoeschen(IArbeitsbereichDatei datei, Arbeitsbereich arbeitsbereich)
    {
      if (arbeitsbereich.Dateiverwaltung != this)
        throw new ApplicationException("Arbeitsbereich passt nicht zur ArbeitsbereichDateiverwaltung!");
      bool flag1 = !string.IsNullOrEmpty(datei.ZusatzContentUniqueId);
      bool flag2;
      if (this._dateien.Contains(datei))
      {
        if (flag1 || MessageBox.Show(string.Format(ResReader.Reader.GetString("AIMLDateiWirklichLoeschen"), (object) datei.Dateiname), "", MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
        {
          try
          {
            if (!flag1)
              File.Delete(datei.Dateiname);
            this._dateien.Remove(datei);
            arbeitsbereich.Verlauf.AlleVerweiseDieserDateiEntfernen(datei);
            flag2 = true;
          }
          catch (Exception ex)
          {
            flag2 = false;
          }
        }
        else
          flag2 = false;
      }
      else
        flag2 = false;
      this.AimlDateiRemoved(datei);
      return flag2;
    }

    public IArbeitsbereichDatei LadeEinzelneAimlDateiDirektOhneKopieEin(
      string dateiname,
      Arbeitsbereich arbeitsbereich)
    {
      if (arbeitsbereich.Dateiverwaltung != this)
        throw new ApplicationException("Arbeitsbereich passt nicht zur ArbeitsbereichDateiverwaltung!");
      AIMLDatei aimlDatei;
      try
      {
        aimlDatei = this.AddAimlVorhandeneDatei(dateiname, arbeitsbereich);
      }
      catch (AIMLDatei.AIMLDateiNichtGeladenException ex)
      {
        Debugger.GlobalDebugger.FehlerZeigen(string.Format(ResReader.Reader.GetString("AIMLDateiLadeFehler"), (object) dateiname, (object) ex.Message), (object) this, "LadeDatei");
        return (IArbeitsbereichDatei) null;
      }
      return (IArbeitsbereichDatei) aimlDatei;
    }

    public IArbeitsbereichDatei LadeEinzelneGaitoBotConfigDateiDirektOhneKopieEin(
      string dateiname,
      Arbeitsbereich arbeitsbereich)
    {
      if (arbeitsbereich.Dateiverwaltung != this)
        throw new ApplicationException("Arbeitsbereich passt nicht zur ArbeitsbereichDateiverwaltung!");
      StartupDatei startupDatei;
      try
      {
        startupDatei = this.AddGaitoBotConfig_VorhandeneDatei(dateiname, arbeitsbereich);
      }
      catch (AIMLDatei.AIMLDateiNichtGeladenException ex)
      {
        Debugger.GlobalDebugger.FehlerZeigen(string.Format(ResReader.Reader.GetString("AIMLDateiLadeFehler"), (object) dateiname, (object) ex.Message), (object) this, "LadeDatei");
        return (IArbeitsbereichDatei) null;
      }
      return (IArbeitsbereichDatei) startupDatei;
    }

    public StartupDatei AddLeereStartupDatei(Arbeitsbereich arbeitsbereich)
    {
      if (arbeitsbereich.Dateiverwaltung != this)
        throw new ApplicationException("Arbeitsbereich passt nicht zur ArbeitsbereichDateiverwaltung!");
      bool abgebrochen;
      string str = this.ErmittleFreienNamenFuerAimlDatei((string) null, "startup", out abgebrochen);
      if (abgebrochen)
        return (StartupDatei) null;
      StartupDatei startupDatei = new StartupDatei(arbeitsbereich);
      startupDatei.OnChanged += new EventHandler(this.AimlDateiOnChanged);
      startupDatei.LeerFuellen();
      startupDatei.Dateiname = str;
      bool cancel;
      startupDatei.Save(out cancel);
      this._dateien.Add((IArbeitsbereichDatei) startupDatei);
      this.DateiAdded((IArbeitsbereichDatei) startupDatei);
      return startupDatei;
    }

    public AIMLDatei AddAimlLeereDatei(
      Arbeitsbereich arbeitsbereich,
      bool ersteDateiMitBeispielen)
    {
      if (arbeitsbereich.Dateiverwaltung != this)
        throw new ApplicationException("Arbeitsbereich passt nicht zur ArbeitsbereichDateiverwaltung!");
      string vorgabe = (string) null;
      if (ersteDateiMitBeispielen)
        vorgabe = ResReader.Reader.GetString("MeineErsteAimlDatei");
      bool abgebrochen;
      string str = this.ErmittleFreienNamenFuerAimlDatei(vorgabe, "aiml", out abgebrochen);
      if (abgebrochen)
        return (AIMLDatei) null;
      AIMLDatei aimlDatei = new AIMLDatei(arbeitsbereich);
      aimlDatei.OnChanged += new EventHandler(this.AimlDateiOnChanged);
      if (ersteDateiMitBeispielen)
        aimlDatei.MitTargetBotStartFuellen();
      else
        aimlDatei.LeerFuellen();
      aimlDatei.Dateiname = str;
      bool cancel;
      aimlDatei.Save(out cancel);
      this._dateien.Add((IArbeitsbereichDatei) aimlDatei);
      this.DateiAdded((IArbeitsbereichDatei) aimlDatei);
      return aimlDatei;
    }

    public AIMLDatei AddAimlVorhandeneDatei(
      string dateiname,
      Arbeitsbereich arbeitsbereich)
    {
      if (arbeitsbereich.Dateiverwaltung != this)
        throw new ApplicationException("Arbeitsbereich passt nicht zur ArbeitsbereichDateiverwaltung!");
      this.AimlDateiWirdGeladen(dateiname);
      AIMLDatei aimlDatei = new AIMLDatei(arbeitsbereich);
      aimlDatei.OnChanged += new EventHandler(this.AimlDateiOnChanged);
      try
      {
        aimlDatei.LiesAusDatei(dateiname, this._arbeitsVerzeichnis);
        this._dateien.Add((IArbeitsbereichDatei) aimlDatei);
        this.AimlDateiFertigGeladen();
        this.DateiAdded((IArbeitsbereichDatei) aimlDatei);
        return aimlDatei;
      }
      catch (AIMLDatei.AIMLDateiNichtGeladenException ex)
      {
        throw new AIMLDatei.AIMLDateiNichtGeladenException(ex.Message);
      }
    }

    private AIMLDatei AddAimlHinzugelinkteContentDatei(
      ContentDokument dokument,
      Arbeitsbereich arbeitsbereich)
    {
      if (arbeitsbereich.Dateiverwaltung != this)
        throw new ApplicationException("Arbeitsbereich passt nicht zur ArbeitsbereichDateiverwaltung!");
      this.AimlDateiWirdGeladen(dokument.Titel);
      AIMLDatei aimlDatei = new AIMLDatei(arbeitsbereich);
      aimlDatei.OnChanged += new EventHandler(this.AimlDateiOnChanged);
      try
      {
        aimlDatei.LiesAusString(dokument.Inhalt);
        aimlDatei.ZusatzContentUniqueId = dokument.ZusatzContentUniqueId;
        aimlDatei.Titel = dokument.Titel;
        aimlDatei.NurFuerGaitoBotExportieren = true;
        aimlDatei.ReadOnly = true;
        aimlDatei.Unterverzeichnisse = dokument.Unterverzeichnise;
        this._dateien.Add((IArbeitsbereichDatei) aimlDatei);
        this.AimlDateiFertigGeladen();
        this.DateiAdded((IArbeitsbereichDatei) aimlDatei);
        return aimlDatei;
      }
      catch (AIMLDatei.AIMLDateiNichtGeladenException ex)
      {
        throw new AIMLDatei.AIMLDateiNichtGeladenException(ex.Message);
      }
    }

    private StartupDatei AddStartUpdateiHinzugelinkteContent(
      ContentDokument dokument,
      Arbeitsbereich arbeitsbereich)
    {
      if (arbeitsbereich.Dateiverwaltung != this)
        throw new ApplicationException("Arbeitsbereich passt nicht zur ArbeitsbereichDateiverwaltung!");
      this.AimlDateiWirdGeladen(dokument.Titel);
      StartupDatei startupDatei = new StartupDatei(arbeitsbereich);
      startupDatei.OnChanged += new EventHandler(this.AimlDateiOnChanged);
      try
      {
        startupDatei.LiesAusString(dokument.Inhalt);
        startupDatei.Titel = dokument.Titel;
        startupDatei.ZusatzContentUniqueId = dokument.ZusatzContentUniqueId;
        startupDatei.NurFuerGaitoBotExportieren = true;
        startupDatei.ReadOnly = true;
        startupDatei.Unterverzeichnisse = dokument.Unterverzeichnise;
        this._dateien.Add((IArbeitsbereichDatei) startupDatei);
        this.AimlDateiFertigGeladen();
        this.DateiAdded((IArbeitsbereichDatei) startupDatei);
        return startupDatei;
      }
      catch (AIMLDatei.AIMLDateiNichtGeladenException ex)
      {
        throw new AIMLDatei.AIMLDateiNichtGeladenException(ex.Message);
      }
    }

    private StartupDatei AddGaitoBotConfig_VorhandeneDatei(
      string dateiname,
      Arbeitsbereich arbeitsbereich)
    {
      if (arbeitsbereich.Dateiverwaltung != this)
        throw new ApplicationException("Arbeitsbereich passt nicht zur ArbeitsbereichDateiverwaltung!");
      this.AimlDateiWirdGeladen(dateiname);
      StartupDatei startupDatei = new StartupDatei(arbeitsbereich);
      startupDatei.OnChanged += new EventHandler(this.AimlDateiOnChanged);
      try
      {
        startupDatei.LiesAusDatei(dateiname, this._arbeitsVerzeichnis);
        this._dateien.Add((IArbeitsbereichDatei) startupDatei);
        this.AimlDateiFertigGeladen();
        this.DateiAdded((IArbeitsbereichDatei) startupDatei);
        return startupDatei;
      }
      catch (AIMLDatei.AIMLDateiNichtGeladenException ex)
      {
        throw new AIMLDatei.AIMLDateiNichtGeladenException(ex.Message);
      }
    }

    private void AimlDateiOnChanged(object sender, EventArgs e)
    {
      this.OnAimlDateienContentChangedEvent();
    }

    private string ErmittleFreienNamenFuerAimlDatei(
      string vorgabe,
      string extension,
      out bool abgebrochen)
    {
      abgebrochen = false;
      bool flag = false;
      string str1 = "";
      if (string.IsNullOrEmpty(vorgabe))
        vorgabe = ResReader.Reader.GetString("unbenannt");
      do
      {
        string original = InputBox.Show(ResReader.Reader.GetString("NamenFuerNeueAIMLDateiAngeben"), ResReader.Reader.GetString("NeueAIMLDateiErzeugen"), vorgabe, out abgebrochen);
        if (string.IsNullOrEmpty(original))
          abgebrochen = true;
        if (!abgebrochen)
        {
          flag = false;
          string str2 = ToolboxStrings.ReplaceEx(ToolboxStrings.ReplaceEx(ToolboxStrings.ReplaceEx(ToolboxStrings.ReplaceEx(ToolboxStrings.ReplaceEx(ToolboxStrings.ReplaceEx(original, string.Format(".{0}", (object) "aiml"), ""), string.Format(".{0}", (object) "startup"), ""), ".xml", ""), ".", "_"), "\\", "_"), "/", "_").Trim();
          if (str2 == "")
          {
            flag = true;
          }
          else
          {
            str1 = string.Format("{0}\\{1}.{2}", (object) this._arbeitsVerzeichnis, (object) str2, (object) extension);
            if (File.Exists(str1))
            {
              int num = (int) MessageBox.Show(ResReader.Reader.GetString("AIMLDateiSchonVorhanden"));
              flag = true;
            }
            else
            {
              try
              {
                ToolboxStrings.String2File("test", str1);
                File.Delete(str1);
              }
              catch (Exception ex)
              {
                int num = (int) MessageBox.Show(string.Format(ResReader.Reader.GetString("AIMLDateiNameUngueltigOderKeinZugriff"), (object) ex.Message));
                flag = true;
              }
            }
          }
        }
      }
      while (!abgebrochen & flag);
      if (abgebrochen)
        str1 = (string) null;
      return str1;
    }
  }
}
