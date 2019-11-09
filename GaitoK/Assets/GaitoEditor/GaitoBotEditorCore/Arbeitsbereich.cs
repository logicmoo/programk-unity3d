// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.Arbeitsbereich
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using MultiLang;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace GaitoBotEditorCore
{
  public class Arbeitsbereich
  {
    private bool _geoeffnet;
    private ArbeitsbereichFokus _fokus;
    private ArbeitsbereichVerlauf _verlauf;
    private readonly string _arbeitsVerzeichnis;
    private ArbeitsbereichMetaInfos _arbeitsbereichMetaInfos;

    public string GaitoBotID
    {
      get
      {
        return this._arbeitsbereichMetaInfos.GaitoBotID;
      }
      set
      {
        if (!(this._arbeitsbereichMetaInfos.GaitoBotID != value))
          return;
        this._arbeitsbereichMetaInfos.GaitoBotID = value;
      }
    }

    public List<IArbeitsbereichDatei> GetZuExportierendeDateien(
      bool fuerGaitoBotDePublizierungExportieren)
    {
      List<IArbeitsbereichDatei> arbeitsbereichDateiList = new List<IArbeitsbereichDatei>();
      foreach (IArbeitsbereichDatei datei in this.Dateiverwaltung.Dateien)
      {
        if ((fuerGaitoBotDePublizierungExportieren || !datei.NurFuerGaitoBotExportieren) && !this.DieseAIMLDateiNichtExportieren(datei))
          arbeitsbereichDateiList.Add(datei);
      }
      return arbeitsbereichDateiList;
    }

    public string Exportverzeichnis
    {
      get
      {
        return this._arbeitsbereichMetaInfos.Exportverzeichnis;
      }
      set
      {
        this._arbeitsbereichMetaInfos.Exportverzeichnis = value;
      }
    }

    public bool ExportverzeichnisVorExportLeeren
    {
      get
      {
        return this._arbeitsbereichMetaInfos.ExportverzeichnisVorExportLeeren;
      }
      set
      {
        this._arbeitsbereichMetaInfos.ExportverzeichnisVorExportLeeren = value;
      }
    }

    public bool AlleStarTagsInExtraDateiExportieren
    {
      get
      {
        return this._arbeitsbereichMetaInfos.AlleStarTagsInExtraDateiExportieren;
      }
      set
      {
        this._arbeitsbereichMetaInfos.AlleStarTagsInExtraDateiExportieren = value;
      }
    }

    public string[] NichtExporierenDateinamen
    {
      get
      {
        return this._arbeitsbereichMetaInfos.NichtExportierenDateinamen;
      }
      set
      {
        this._arbeitsbereichMetaInfos.NichtExportierenDateinamen = value;
      }
    }

    public bool SindAlleZuExportierendenDateienFehlerFrei
    {
      get
      {
        foreach (AIMLDatei aimlDatei in this.Dateiverwaltung.AlleAimlDateien)
        {
          if (!aimlDatei.SeitLetztemIsChangedAufDTDFehlergeprueft)
            aimlDatei.GegenAIMLDTDPruefen(AIMLDatei.PruefFehlerVerhalten.NiemalsFehlerZeigen);
        }
        return this.GetZuExportierendeDateien(true).Cast<IArbeitsbereichDatei>().Where<IArbeitsbereichDatei>((Func<IArbeitsbereichDatei, bool>) (d => d.HatFehler)).Count<IArbeitsbereichDatei>() <= 0;
      }
    }

    public bool DieseAIMLDateiNichtExportieren(IArbeitsbereichDatei datei)
    {
      if (datei is AIMLDatei)
      {
        foreach (object obj in this.NichtExporierenDateinamen)
        {
          string str = string.Format("\\{0}.aiml", obj);
          if (!string.IsNullOrEmpty(datei.Dateiname) && datei.Dateiname.EndsWith(str, StringComparison.OrdinalIgnoreCase))
            return true;
        }
      }
      return false;
    }

    public void Exportieren(
      string exportVerzeichnis,
      Arbeitsbereich.VerzeichnisVorherLeeren verzeichnisVorherLeeren,
      bool alleStarTagsInExtraDateiExportieren,
      bool exportFuerGaitoBotDePublizierung,
      out bool abgebrochen)
    {
      if (!Directory.Exists(exportVerzeichnis))
        throw new ApplicationException(string.Format("Exportverzeichnis '{0}' nicht vorhanden!", (object) exportVerzeichnis));
      if ((uint) verzeichnisVorherLeeren > 0U)
      {
        if (verzeichnisVorherLeeren == Arbeitsbereich.VerzeichnisVorherLeeren.leerenUndVorherFragen && MessageBox.Show(string.Format(ResReader.Reader.GetString("ExportVerzeichnisWirklichLeeren"), (object) exportVerzeichnis), ResReader.Reader.GetString("Export"), MessageBoxButtons.YesNo) != DialogResult.Yes)
        {
          abgebrochen = true;
          return;
        }
        foreach (string directory in Directory.GetDirectories(exportVerzeichnis))
        {
          try
          {
            Directory.Delete(directory, true);
          }
          catch (Exception ex)
          {
            int num = (int) MessageBox.Show(string.Format(ml.ml_string(70, "Das Verzeichnis '{0}' konnte nicht gelöscht werden: {1}"), (object) directory, (object) ex.Message));
            abgebrochen = true;
            return;
          }
        }
        foreach (string file in Directory.GetFiles(exportVerzeichnis))
        {
          try
          {
            File.Delete(file);
          }
          catch (Exception ex)
          {
            int num = (int) MessageBox.Show(string.Format(ml.ml_string(71, "Die Datei '{0}' konnte nicht gelöscht werden: {1}"), (object) file, (object) ex.Message));
            abgebrochen = true;
            return;
          }
        }
      }
      if (alleStarTagsInExtraDateiExportieren)
      {
        StringCollection stringCollection = new StringCollection();
        foreach (IArbeitsbereichDatei arbeitsbereichDatei in this.GetZuExportierendeDateien(exportFuerGaitoBotDePublizierung))
        {
          if (arbeitsbereichDatei is AIMLDatei)
          {
            AIMLDatei aimlDatei1 = (AIMLDatei) arbeitsbereichDatei;
            AIMLDatei aimlDatei2 = new AIMLDatei(this);
            aimlDatei2.LiesAusString(aimlDatei1.XML.OuterXml);
            List<AIMLCategory> aimlCategoryList = new List<AIMLCategory>();
            foreach (AIMLCategory category in aimlDatei2.RootTopic.Categories)
            {
              if (category.That == "" && category.Pattern == "*")
              {
                stringCollection.Add(category.Template);
                aimlCategoryList.Add(category);
              }
            }
            foreach (AIMLCategory category in aimlCategoryList)
              aimlDatei2.RootTopic.LoescheCategory(category);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string str in aimlDatei1.Unterverzeichnisse)
              stringBuilder.AppendFormat("{0}_", (object) str);
            string str1 = string.Format("{0}\\{1}{2}.aiml", (object) exportVerzeichnis, (object) stringBuilder.ToString(), (object) aimlDatei1.Titel);
            aimlDatei2.Dateiname = str1;
            bool cancel = false;
            aimlDatei2.Save(out cancel);
          }
        }
        if ((uint) stringCollection.Count > 0U)
        {
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.Append("<pattern>*</pattern><template><random>");
          foreach (string str in stringCollection)
            stringBuilder.AppendFormat("<li>{0}</li>", (object) str);
          stringBuilder.Append("</random></template>");
          AIMLDatei aimlDatei = new AIMLDatei(this);
          aimlDatei.LeerFuellen();
          aimlDatei.Dateiname = string.Format("{0}\\_stars_.aiml", (object) exportVerzeichnis);
          aimlDatei.RootTopic.AddNewCategory().ContentNode.InnerXml = stringBuilder.ToString();
          bool cancel = false;
          if (File.Exists(aimlDatei.Dateiname))
            File.Delete(aimlDatei.Dateiname);
          aimlDatei.Save(out cancel);
        }
        foreach (IArbeitsbereichDatei arbeitsbereichDatei in this.GetZuExportierendeDateien(exportFuerGaitoBotDePublizierung))
        {
          if (arbeitsbereichDatei is StartupDatei)
          {
            StartupDatei startupDatei = (StartupDatei) arbeitsbereichDatei;
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string baustein in arbeitsbereichDatei.Unterverzeichnisse)
              stringBuilder.AppendFormat("{0}_", (object) this.DateinameBausteinBereinigt(baustein));
            string str1 = "startup";
            string str2 = string.Format("{0}\\{1}{2}.{3}", (object) exportVerzeichnis, (object) stringBuilder.ToString(), (object) this.DateinameBausteinBereinigt(startupDatei.Titel), (object) str1);
            string dateiname = startupDatei.Dateiname;
            if (string.IsNullOrEmpty(dateiname))
              ToolboxStrings.String2File(startupDatei.XML.OuterXml, str2);
            else
              File.Copy(dateiname, str2, true);
          }
        }
      }
      else
      {
        foreach (IArbeitsbereichDatei arbeitsbereichDatei in this.GetZuExportierendeDateien(exportFuerGaitoBotDePublizierung))
        {
          StringBuilder stringBuilder = new StringBuilder();
          foreach (string baustein in arbeitsbereichDatei.Unterverzeichnisse)
            stringBuilder.AppendFormat("{0}_", (object) this.DateinameBausteinBereinigt(baustein));
          string str1;
          if (arbeitsbereichDatei is AIMLDatei)
          {
            str1 = "aiml";
          }
          else
          {
            if (!(arbeitsbereichDatei is StartupDatei))
              throw new ApplicationException(string.Format("Datei '{0}' hat einen unbekannten Typ", (object) arbeitsbereichDatei.Titel));
            str1 = "startup";
          }
          string str2 = string.Format("{0}\\{1}{2}.{3}", (object) exportVerzeichnis, (object) stringBuilder.ToString(), (object) this.DateinameBausteinBereinigt(arbeitsbereichDatei.Titel), (object) str1);
          string dateiname = arbeitsbereichDatei.Dateiname;
          if (string.IsNullOrEmpty(dateiname))
            ToolboxStrings.String2File(arbeitsbereichDatei.XML.OuterXml, str2);
          else
            File.Copy(dateiname, str2, true);
        }
      }
      abgebrochen = false;
    }

    private string DateinameBausteinBereinigt(string baustein)
    {
      if (string.IsNullOrEmpty(baustein))
        return baustein;
      baustein = baustein.Replace("|", "_");
      baustein = baustein.Replace(":", "_");
      baustein = baustein.Replace("\\", "_");
      baustein = baustein.Replace("/", "_");
      baustein = baustein.Replace(" ", "_");
      baustein = baustein.Replace("@", "_");
      baustein = baustein.Replace("$", "_");
      baustein = baustein.Replace("§", "_");
      return baustein;
    }

    public event Arbeitsbereich.SucheImArbeitsbereichEventHandler SucheImArbeitsbereich;

    protected virtual void SucheImArbeitsbereichEvent(
      string sucheingabe,
      Arbeitsbereich.WoSuchenOrte woSuchen)
    {
      if (this.SucheImArbeitsbereich == null)
        return;
      this.SucheImArbeitsbereich((object) this, new Arbeitsbereich.SucheImArbeitsbereichEventArgs(sucheingabe, woSuchen));
    }

    public AIMLCategory GetCategoryForCategoryNode(XmlNode categoryNode)
    {
      foreach (AIMLDatei aimlDatei in this.Dateiverwaltung.AlleAimlDateien)
      {
        foreach (AIMLTopic topic in aimlDatei.getTopics())
        {
          foreach (AIMLCategory category in topic.Categories)
          {
            if (category.ContentNode == categoryNode)
              return category;
          }
        }
      }
      return (AIMLCategory) null;
    }

    public void Suchen(string suchEingabe, Arbeitsbereich.WoSuchenOrte woSuchen)
    {
      suchEingabe = ToolboxStrings.UmlauteAussschreiben(suchEingabe);
      this.SucheImArbeitsbereichEvent(suchEingabe, woSuchen);
    }

    public static string WoSuchenOrt2Name(Arbeitsbereich.WoSuchenOrte ort)
    {
      switch (ort)
      {
        case Arbeitsbereich.WoSuchenOrte.ImArbeitsbereich:
          return ResReader.Reader.GetString("SuchenOrtNameImArbeitsbereich");
        case Arbeitsbereich.WoSuchenOrte.InAktuellerAIMLDatei:
          return ResReader.Reader.GetString("SuchenOrtNameInAktuellerAIMLDatei");
        case Arbeitsbereich.WoSuchenOrte.InAktuellemTopic:
          return ResReader.Reader.GetString("SuchenOrtNameInAktuellemTopic");
        default:
          throw new ApplicationException("Unbehandelter WoSuchenOrt '" + (object) ort + "'!");
      }
    }

    public static void WoSuchenAuswahlFuellen(
      ToolStripComboBox combo,
      Arbeitsbereich.WoSuchenOrte welchenSelektieren)
    {
      Arbeitsbereich.WoSuchenAuswahlFuellenEiner(combo, Arbeitsbereich.WoSuchenOrte.ImArbeitsbereich, welchenSelektieren);
      Arbeitsbereich.WoSuchenAuswahlFuellenEiner(combo, Arbeitsbereich.WoSuchenOrte.InAktuellerAIMLDatei, welchenSelektieren);
      Arbeitsbereich.WoSuchenAuswahlFuellenEiner(combo, Arbeitsbereich.WoSuchenOrte.InAktuellemTopic, welchenSelektieren);
    }

    private static void WoSuchenAuswahlFuellenEiner(
      ToolStripComboBox combo,
      Arbeitsbereich.WoSuchenOrte ort,
      Arbeitsbereich.WoSuchenOrte welchenSelektieren)
    {
      int num = combo.Items.Add((object) Arbeitsbereich.WoSuchenOrt2Name(ort));
      if (ort != welchenSelektieren)
        return;
      combo.SelectedIndex = num;
    }

    public event EventHandler MetaInfosChangedEvent;

    protected virtual void MetaInfosChanged()
    {
      if (this.MetaInfosChangedEvent == null)
        return;
      this.MetaInfosChangedEvent((object) this, EventArgs.Empty);
    }

    public event EventHandler NameChangedEvent;

    protected virtual void NameChanged()
    {
      if (this.NameChangedEvent == null)
        return;
      this.NameChangedEvent((object) this, EventArgs.Empty);
    }

    public event EventHandler UseOneWordSRAIChanged;

    protected virtual void UseOneWordSRAIChangedEvent()
    {
      if (this.UseOneWordSRAIChanged == null)
        return;
      this.UseOneWordSRAIChanged((object) this, EventArgs.Empty);
    }

    public event EventHandler WissenSpracheChanged;

    protected virtual void WissenSpracheChangedEvent()
    {
      if (this.WissenSpracheChanged == null)
        return;
      this.WissenSpracheChanged((object) this, EventArgs.Empty);
    }

    private string ArbeitsBereichMetaInfosDateiname
    {
      get
      {
        return Path.Combine(this._arbeitsVerzeichnis, "metainfos.ser");
      }
    }

    public string[] ContentElementUniqueIds
    {
      get
      {
        return this._arbeitsbereichMetaInfos.ContentElementUniqueIds;
      }
      set
      {
        this._arbeitsbereichMetaInfos.ContentElementUniqueIds = value;
        this.MetaInfosChanged();
      }
    }

    public ArbeitsbereichDateiverwaltung Dateiverwaltung { get; private set; }

    public bool MetaInfosIsChanged { get; set; }

    public int AnzahlKategorien
    {
      get
      {
        int num = 0;
        foreach (AIMLDatei aimlDatei in this.Dateiverwaltung.AlleAimlDateien)
          num += aimlDatei.AnzahlCategories;
        return num;
      }
    }

    public ArbeitsbereichFokus Fokus
    {
      get
      {
        return this._fokus;
      }
    }

    public ArbeitsbereichVerlauf Verlauf
    {
      get
      {
        return this._verlauf;
      }
    }

    public string Name
    {
      get
      {
        return this._arbeitsbereichMetaInfos.Name;
      }
      set
      {
        this._arbeitsbereichMetaInfos.Name = value;
        this.NameChanged();
      }
    }

    public string Arbeitsverzeichnis
    {
      get
      {
        return this._arbeitsVerzeichnis;
      }
    }

    public Arbeitsbereich(string arbeitsverzeichnis)
    {
      this._arbeitsVerzeichnis = arbeitsverzeichnis;
      this.InitArbeitsbereich();
    }

    public Arbeitsbereich()
    {
      int num = 0;
      do
      {
        ++num;
        this._arbeitsVerzeichnis = Path.Combine(Config.GlobalConfig.ArbeitsbereicheSpeicherVerzeichnis, num.ToString());
      }
      while (Directory.Exists(this._arbeitsVerzeichnis));
      Directory.CreateDirectory(this._arbeitsVerzeichnis);
      this.InitArbeitsbereich();
    }

    public void Loeschen()
    {
      Directory.Delete(this.Arbeitsverzeichnis, true);
    }

    public void SaveAll()
    {
      foreach (IArbeitsbereichDatei arbeitsbereichDatei in this.Dateiverwaltung.Dateien)
      {
        if (arbeitsbereichDatei.IsChanged)
        {
          bool cancel;
          arbeitsbereichDatei.Save(out cancel);
          if (cancel)
            return;
        }
      }
      this.MetaInfosSpeichern();
    }

    public void ArbeitsbereichSollGeschlossenWerden(out bool cancel)
    {
      cancel = false;
      foreach (IArbeitsbereichDatei arbeitsbereichDatei in this.Dateiverwaltung.Dateien)
      {
        if (arbeitsbereichDatei.IsChanged)
        {
          DialogResult dialogResult = MessageBox.Show(ResReader.Reader.GetString("SollenDieAenderungenGespeichertWerden"), string.Format(ResReader.Reader.GetString("DateiInhaltHatSichSeitSpeichernGeaendert"), (object) arbeitsbereichDatei.Titel), MessageBoxButtons.YesNoCancel);
          switch (dialogResult)
          {
            case DialogResult.Cancel:
              cancel = true;
              return;
            case DialogResult.Yes:
              bool cancel1;
              arbeitsbereichDatei.Save(out cancel1);
              cancel = cancel1;
              goto case DialogResult.No;
            case DialogResult.No:
              break;
            default:
              throw new ApplicationException("Unbekanntes Dialogergebnis '" + (object) dialogResult + "'");
          }
        }
      }
      if (!this.MetaInfosIsChanged)
        return;
      DialogResult dialogResult1 = MessageBox.Show(ResReader.Reader.GetString("SollenDieAenderungenGespeichertWerden"), string.Format(ResReader.Reader.GetString("DerInhaltDesArbeitsbereichesWurdeVeraendert"), (object) this.Name), MessageBoxButtons.YesNoCancel);
      switch (dialogResult1)
      {
        case DialogResult.Cancel:
          cancel = true;
          break;
        case DialogResult.Yes:
          this.MetaInfosSpeichern();
          goto case DialogResult.No;
        case DialogResult.No:
          break;
        default:
          throw new ApplicationException("Unbekanntes Dialogergebnis '" + (object) dialogResult1 + "'");
      }
    }

    public override string ToString()
    {
      return this.Name;
    }

    public void MetaInfosSpeichern()
    {
      ArbeitsbereichMetaInfos.SerialisiereInXMLDatei(this.ArbeitsBereichMetaInfosDateiname, this._arbeitsbereichMetaInfos);
      this.MetaInfosIsChanged = false;
    }

    public void Oeffnen()
    {
      if (this._geoeffnet)
        throw new ApplicationException(ml.ml_string(65, "Dieser Arbeitsbereich wurde bereits geöffnet!"));
      this._geoeffnet = true;
      this.LadeVerzeichnis(this._arbeitsVerzeichnis, true);
    }

    private void InitArbeitsbereich()
    {
      this.Dateiverwaltung = new ArbeitsbereichDateiverwaltung(this._arbeitsVerzeichnis);
      this._arbeitsbereichMetaInfos = !File.Exists(this.ArbeitsBereichMetaInfosDateiname) ? new ArbeitsbereichMetaInfos() : ArbeitsbereichMetaInfos.DeSerialisiereAusXMLDatei(this.ArbeitsBereichMetaInfosDateiname);
      this._arbeitsbereichMetaInfos.Changed += new EventHandler(this.MetaInfos_Changed);
      this._fokus = new ArbeitsbereichFokus();
      this._verlauf = new ArbeitsbereichVerlauf(this._fokus);
    }

        private void LadeVerzeichnis(string verzeichnis, bool mitUnterverzeichnissen)
        {
            try
            {
                foreach (string file in Directory.GetFiles(verzeichnis, "*.xml"))
                    this.Dateiverwaltung.LadeEinzelneAimlDateiDirektOhneKopieEin(file, this);
                foreach (string file in Directory.GetFiles(verzeichnis, "*.aiml"))
                    this.Dateiverwaltung.LadeEinzelneAimlDateiDirektOhneKopieEin(file, this);
                foreach (string file in Directory.GetFiles(verzeichnis, "*.startup"))
                    this.Dateiverwaltung.LadeEinzelneGaitoBotConfigDateiDirektOhneKopieEin(file, this);
                if (!mitUnterverzeichnissen)
                    return;
                foreach (string directory in Directory.GetDirectories(verzeichnis))
                    this.LadeVerzeichnis(directory, true);
            }
            catch (Exception) { }
        }

        private void MetaInfos_Changed(object sender, EventArgs e)
    {
      this.MetaInfosIsChanged = true;
      this.MetaInfosChanged();
    }

    public enum VerzeichnisVorherLeeren
    {
      nichtLeeren,
      leerenUndVorherFragen,
      leerenUndNichtVorherFragen,
    }

    public enum WoSuchenOrte
    {
      ImArbeitsbereich,
      InAktuellerAIMLDatei,
      InAktuellemTopic,
    }

    public class SucheImArbeitsbereichEventArgs : EventArgs
    {
      public string SuchEingabe;
      public Arbeitsbereich.WoSuchenOrte WoSuchen;

      public SucheImArbeitsbereichEventArgs(
        string sucheingabe,
        Arbeitsbereich.WoSuchenOrte woSuchen)
      {
        this.SuchEingabe = sucheingabe;
        this.WoSuchen = woSuchen;
      }
    }

    public delegate void SucheImArbeitsbereichEventHandler(
      object sender,
      Arbeitsbereich.SucheImArbeitsbereichEventArgs e);
  }
}
