// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.StartupDatei
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using de.springwald.xml;
using de.springwald.xml.editor;
using System;
using System.Collections;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace GaitoBotEditorCore
{
  public class StartupDatei : IArbeitsbereichDatei
  {
    private Arbeitsbereich _arbeitsbereich;
    private string _dateiname;
    private string _titel;
    private bool _seitLetztemIsChangedAufDTDFehlergeprueft;
    private bool _hatDTDFehler;
    private static Regex _nameSpaceBereinigerOeffnendTag;
    private static Regex _nameSpaceBereinigerSchliessendTag;
    public const string FileExtension = "startup";

    public event EventHandler OnChanged;

    protected virtual void OnChangedEvent(EventArgs e)
    {
      if (this.OnChanged == null)
        return;
      this.OnChanged((object) this, e);
    }

    public event EventHandler NodeWirdGeprueftEvent;

    protected virtual void ActivateNodeWirdGeprueft(EventArgs e)
    {
      if (this.NodeWirdGeprueftEvent == null)
        return;
      this.NodeWirdGeprueftEvent((object) this, e);
    }

    public string ZusatzContentUniqueId { get; set; }

    public bool ReadOnly { get; set; }

    public bool NurFuerGaitoBotExportieren { get; set; }

    public Arbeitsbereich Arbeitsbereich { get; private set; }

    public XmlDocument XML { get; private set; }

    public string Dateiname
    {
      get
      {
        return this._dateiname;
      }
      set
      {
        this._dateiname = value;
        this._titel = (string) null;
      }
    }

    public string Titel
    {
      get
      {
        if (this._titel == null)
          this._titel = StartupDatei.TitelAusDateinameHerleiten(this._dateiname);
        return this._titel;
      }
      set
      {
        this._titel = value;
      }
    }

    public bool HatFehler
    {
      get
      {
        return this._hatDTDFehler;
      }
    }

    public bool IsChanged { get; set; }

    public bool SeitLetztemIsChangedAufDTDFehlergeprueft
    {
      get
      {
        return this._seitLetztemIsChangedAufDTDFehlergeprueft;
      }
    }

    public StartupDatei(Arbeitsbereich arbeitsbereich)
    {
      this.Unterverzeichnisse = new string[0];
      this._arbeitsbereich = arbeitsbereich;
      this.XML = new XmlDocument();
      this.XML.PreserveWhitespace = false;
      this.XML.NodeChanged += new XmlNodeChangedEventHandler(this.XMLChangedEvent);
      this.XML.NodeInserted += new XmlNodeChangedEventHandler(this.XMLChangedEvent);
      this.XML.NodeRemoved += new XmlNodeChangedEventHandler(this.XMLChangedEvent);
    }

    public string SortKey
    {
      get
      {
        return this.Dateiname;
      }
    }

    public void LeerFuellen()
    {
      this.LiesAusString("<gaitobot-startup></gaitobot-startup>");
    }

    public string[] Unterverzeichnisse { get; set; }

    public void LiesAusString(string inhalt)
    {
      inhalt = this.StartUpInhaltBereinigen(inhalt);
      try
      {
        this.XML.LoadXml(inhalt);
        ToolboxXML.WhitespacesBereinigen((XmlNode) this.XML.DocumentElement);
      }
      catch (XmlException ex)
      {
        throw new StartupDatei.StartUpDateiNichtGeladenException(string.Format(ResReader.Reader.GetString("StartupDateiInhaltlichFehlerhaft"), (object) ex.Message));
      }
      catch (Exception ex)
      {
        throw new StartupDatei.StartUpDateiNichtGeladenException(string.Format(ResReader.Reader.GetString("StartupDateiDefekt"), (object) ex.Message));
      }
      if (!this.XML.DocumentElement.Name.Equals("gaitobot-startup"))
        throw new StartupDatei.StartUpDateiNichtGeladenException(string.Format(ResReader.Reader.GetString("StartupDateiDefekt"), (object) ResReader.Reader.GetString("DokumentElementNichtGaitoBotStartup")));
      if (this.XML.SelectNodes("/gaitobot-startup").Count != 1)
        throw new StartupDatei.StartUpDateiNichtGeladenException(string.Format(ResReader.Reader.GetString("StartupDateiDefekt"), (object) ResReader.Reader.GetString("DokumentElementStartupNurEinmal")));
      if (ToolboxSonstiges.IstEntwicklungsmodus)
        this.GegenStartupDTDPruefen(StartupDatei.PruefFehlerVerhalten.NiemalsFehlerZeigen);
      else
        this.GegenStartupDTDPruefen(StartupDatei.PruefFehlerVerhalten.BeiFehlerFragenObAnzeigen);
      this.IsChanged = false;
    }

    public void LiesAusDatei(string dateiname, string arbeitsbereichRootPfad_)
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
        throw new ApplicationException(string.Format("Unable to read file '{0}'\n{1}", (object) dateiname, (object) ex.Message));
      }
      this._dateiname = dateiname;
      this.LiesAusString(end);
    }

    public void GegenStartupDTDPruefen(StartupDatei.PruefFehlerVerhalten pruefVerhalten)
    {
      this._seitLetztemIsChangedAufDTDFehlergeprueft = true;
      XMLQuellcodeAlsRTF xmlQuellcodeAlsRtf = new XMLQuellcodeAlsRTF();
      xmlQuellcodeAlsRtf.Regelwerk = new XMLRegelwerk(StartUpDTD.GetStartUpDTD());
      xmlQuellcodeAlsRtf.Rootnode = (XmlNode) this.XML.DocumentElement;
      xmlQuellcodeAlsRtf.NodeWirdGeprueftEvent += new EventHandler(this.toRtf_NodeWirdGeprueftEvent);
      xmlQuellcodeAlsRtf.Rendern();
      xmlQuellcodeAlsRtf.NodeWirdGeprueftEvent -= new EventHandler(this.toRtf_NodeWirdGeprueftEvent);
      if (xmlQuellcodeAlsRtf.FehlerProtokollAlsText == "")
      {
        this._hatDTDFehler = false;
      }
      else
      {
        switch (pruefVerhalten)
        {
          case StartupDatei.PruefFehlerVerhalten.FehlerDirektZeigen:
            xmlQuellcodeAlsRtf.QuellCodeUndFehlerInNeuemFormZeigen();
            break;
          case StartupDatei.PruefFehlerVerhalten.BeiFehlerFragenObAnzeigen:
            if (MessageBox.Show(ResReader.Reader.GetString("FehlerImXMLDokJetztAnzeigen"), ResReader.Reader.GetString("DTDFehler"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
              xmlQuellcodeAlsRtf.QuellCodeUndFehlerInNeuemFormZeigen();
              break;
            }
            break;
        }
        this._hatDTDFehler = true;
      }
    }

    public void Save(out bool cancel)
    {
      if (this._dateiname == null)
        throw new ApplicationException(ResReader.Reader.GetString("NochKeinDateinameVergeben"));
      if (this._seitLetztemIsChangedAufDTDFehlergeprueft)
        this.GegenStartupDTDPruefen(StartupDatei.PruefFehlerVerhalten.NiemalsFehlerZeigen);
      bool flag = true;
      if (this.HatFehler)
      {
        DialogResult dialogResult = MessageBox.Show(ResReader.Reader.GetString("SollDieDateiDefektGespeichertWerden"), string.Format(ResReader.Reader.GetString("DateiIstDefektUndSollteVorSpeichernKorrigiertWerden"), (object) this.Dateiname), MessageBoxButtons.YesNoCancel);
        switch (dialogResult)
        {
          case DialogResult.Cancel:
            cancel = true;
            flag = false;
            break;
          case DialogResult.Yes:
            cancel = false;
            flag = true;
            break;
          case DialogResult.No:
            cancel = false;
            flag = false;
            break;
          default:
            throw new ApplicationException("Unbekanntes Dialogergebnis '" + (object) dialogResult + "'");
        }
      }
      else
        cancel = false;
      if (!flag)
        return;
      ArrayList arrayList = new ArrayList();
      foreach (XmlNode childNode in this.XML.DocumentElement.ChildNodes)
      {
        if (childNode.Name == "meta")
          arrayList.Add((object) childNode);
      }
      foreach (XmlNode oldChild in arrayList)
        oldChild.ParentNode.RemoveChild(oldChild);
      for (int index = 10; index >= 0; --index)
      {
        try
        {
          File.Delete(string.Format("{0}.bak_{1}", (object) this.Dateiname, (object) index.ToString()));
          File.Move(string.Format("{0}.bak_{1}", (object) this.Dateiname, (object) (index - 1)), string.Format("{0}.bak_{1}", (object) this.Dateiname, (object) index));
        }
        catch (Exception ex)
        {
        }
      }
      if (File.Exists(this.Dateiname))
        File.Move(this.Dateiname, string.Format("{0}.bak_0", (object) this.Dateiname));
      FileStream fileStream = File.Create(this.Dateiname);
      string s = "<?xml version=\"1.0\" encoding=\"ISO-8859-15\"?>" + Regex.Replace(this.XML.InnerXml.ToString(), "<\\?xml .*? ?>", "");
      if (true)
      {
        StringBuilder stringBuilder = new StringBuilder(s);
        stringBuilder.Replace("<bot>", "\r\n<bot>");
        stringBuilder.Replace("<predicates>", "\r\n\t<predicates>");
        stringBuilder.Replace("<substitutions>", "\r\n\t<substitutions>");
        stringBuilder.Replace("<sentence-splitters>", "\r\n\t\t<sentence-splitters>");
        stringBuilder.Replace("<input>", "\r\n<input>");
        stringBuilder.Replace("<gender>", "\r\n<gender>");
        stringBuilder.Replace("<person>", "\r\n<person>");
        stringBuilder.Replace("<person2>", "\r\n<person2>");
        stringBuilder.Replace("<property ", "\r\n\t\t<property ");
        stringBuilder.Replace("<substitute ", "\r\n\t\t<substitute ");
        stringBuilder.Replace("<splitter ", "\r\n\t\t\t<splitter ");
        stringBuilder.Replace("<!--", "\r\n<!--");
        s = stringBuilder.ToString();
      }
      byte[] bytes = Encoding.GetEncoding("ISO-8859-15").GetBytes(s);
      fileStream.Write(bytes, 0, bytes.Length);
      fileStream.Close();
      this.IsChanged = false;
    }

    private void XMLChangedEvent(object src, XmlNodeChangedEventArgs args)
    {
      this.IsChanged = true;
      this._seitLetztemIsChangedAufDTDFehlergeprueft = false;
      this.OnChangedEvent(EventArgs.Empty);
    }

    private string StartUpInhaltBereinigen(string inhalt)
    {
      string pattern1 = "<[?]xml[\\t\\r\\n ]+[^>]+>";
      inhalt = Regex.Replace(inhalt, pattern1, "<?xml version=\"1.0\" encoding=\"ISO-8859-15\"?>");
      string pattern2 = "</[a-zA-Z]*-?startup>";
      inhalt = Regex.Replace(inhalt, pattern2, "</gaitobot-startup>");
      string pattern3 = "<[a-zA-Z]*-?startup>";
      inhalt = Regex.Replace(inhalt, pattern3, "<gaitobot-startup>");
      return inhalt;
    }

    public static string TitelAusDateinameHerleiten(string dateiname)
    {
      string str = dateiname;
      if (str.LastIndexOf("\\") != -1)
        str = str.Remove(0, str.LastIndexOf("\\") + 1);
      if (str.LastIndexOf(".startup") > 0)
        str = str.Remove(str.LastIndexOf(".startup"), 8);
      return str;
    }

    private void toRtf_NodeWirdGeprueftEvent(object sender, EventArgs e)
    {
      this.ActivateNodeWirdGeprueft(EventArgs.Empty);
    }

    public enum PruefFehlerVerhalten
    {
      NiemalsFehlerZeigen,
      FehlerDirektZeigen,
      BeiFehlerFragenObAnzeigen,
    }

    public class StartUpDateiNichtGeladenException : ApplicationException
    {
      public StartUpDateiNichtGeladenException(string message)
        : base(message)
      {
      }
    }
  }
}
