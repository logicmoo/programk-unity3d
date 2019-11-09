// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.AIMLDatei
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using de.springwald.xml;
using de.springwald.xml.editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Schema;

namespace GaitoBotEditorCore
{
  public class AIMLDatei : IArbeitsbereichDatei
  {
    private int _anzahlCategories = -1;
    private string _dateiname;
    private string _titel;
    private List<AIMLTopic> _topicListe;
    private static Regex _nameSpaceBereinigerOeffnendTag;
    private static Regex _nameSpaceBereinigerSchliessendTag;
    public const string FileExtension = "aiml";

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

    public string[] Unterverzeichnisse { get; set; }

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

    public bool HatFehler { get; private set; }

    public string Titel
    {
      get
      {
        if (this._titel == null)
          this._titel = AIMLDatei.TitelAusDateinameHerleiten(this._dateiname);
        return this._titel;
      }
      set
      {
        this._titel = value;
      }
    }

    public bool IsChanged { get; set; }

    public bool SeitLetztemIsChangedAufDTDFehlergeprueft { get; private set; }

    public AIMLTopic ZuletztInDieserDateiGewaehlesTopic { get; set; }

    public AIMLTopic RootTopic
    {
      get
      {
        foreach (AIMLTopic topic in this.getTopics())
        {
          if (topic.IstRootTopic)
            return topic;
        }
        return (AIMLTopic) null;
      }
    }

    public string SortKey
    {
      get
      {
        StringBuilder stringBuilder = new StringBuilder();
        if (this.Unterverzeichnisse != null)
        {
          foreach (string str in this.Unterverzeichnisse)
            stringBuilder.AppendFormat("__{0} ", (object) str);
        }
        stringBuilder.AppendFormat("_{0}", (object) this.Titel);
        return stringBuilder.ToString();
      }
    }

    public AIMLDatei(Arbeitsbereich arbeitsbereich)
    {
      this.Arbeitsbereich = arbeitsbereich;
      this.Unterverzeichnisse = new string[0];
      this.XML = new XmlDocument();
      this.XML.PreserveWhitespace = true;
      this.XML.NodeChanged += new XmlNodeChangedEventHandler(this.XMLChangedEvent);
      this.XML.NodeInserted += new XmlNodeChangedEventHandler(this.XMLChangedEvent);
      this.XML.NodeRemoved += new XmlNodeChangedEventHandler(this.XMLChangedEvent);
    }

    public static string TitelAusDateinameHerleiten(string dateiname)
    {
      string str = dateiname;
      if (str.LastIndexOf("\\") != -1)
        str = str.Remove(0, str.LastIndexOf("\\") + 1);
      if (str.LastIndexOf(".xml") > 0)
        str = str.Remove(str.LastIndexOf(".xml"), 4);
      if (str.LastIndexOf(".aiml") > 0)
        str = str.Remove(str.LastIndexOf(".aiml"), 5);
      return str;
    }

    public static string[] UnterverzeichnisseAusDateinameHerleiten(
      string dateiname,
      string arbeitsbereichRootPfad)
    {
      if (!dateiname.StartsWith(arbeitsbereichRootPfad, StringComparison.OrdinalIgnoreCase))
        return (string[]) null;
      dateiname = dateiname.Remove(0, arbeitsbereichRootPfad.Length);
      string[] strArray = dateiname.Split(new char[1]{ '\\' }, StringSplitOptions.RemoveEmptyEntries);
      ArrayList arrayList = new ArrayList();
      for (int index = 0; index < strArray.Length - 1; ++index)
        arrayList.Add((object) strArray[index]);
      return (string[]) arrayList.ToArray(typeof (string));
    }

    public bool LoescheTopic(AIMLTopic topic)
    {
      if (topic == null || topic.IstRootTopic)
        return false;
      if (this._topicListe.Contains(topic))
        this._topicListe.Remove(topic);
      this.Arbeitsbereich.Verlauf.AlleVerweiseDiesesAIMLTopicEntfernen(topic);
      topic.Delete();
      topic.Dispose();
      return true;
    }

    public int AnzahlCategories
    {
      get
      {
        if (this._anzahlCategories == -1)
        {
          this._anzahlCategories = 0;
          foreach (AIMLTopic topic in this.getTopics())
            this._anzahlCategories += topic.Categories.Count;
        }
        return this._anzahlCategories;
      }
    }

    public List<AIMLTopic> getTopics()
    {
      if (this._topicListe == null)
        this.TopicListeBereitstellen();
      return this._topicListe;
    }

    public AIMLTopic AddNewTopic()
    {
      AIMLTopic newTopic = AIMLTopic.createNewTopic(this);
      this._topicListe.Add(newTopic);
      return newTopic;
    }

    public void LeerFuellen()
    {
      this.LiesAusString("<aiml></aiml>");
    }

    public void LiesAusString(string inhalt)
    {
      inhalt = this.AIMLInhaltBereinigen(inhalt);
      try
      {
        this.XML.LoadXml(inhalt);
        ToolboxXML.WhitespacesBereinigen((XmlNode) this.XML.DocumentElement);
      }
      catch (XmlException ex)
      {
        throw new AIMLDatei.AIMLDateiNichtGeladenException(string.Format(ResReader.Reader.GetString("AIMLDateiInhaltlichFehlerhaft"), (object) ex.Message));
      }
      catch (Exception ex)
      {
        throw new AIMLDatei.AIMLDateiNichtGeladenException(string.Format(ResReader.Reader.GetString("AIMLDateiDefekt"), (object) ex.Message));
      }
      if (!this.XML.DocumentElement.Name.Equals("aiml"))
        throw new AIMLDatei.AIMLDateiNichtGeladenException(string.Format(ResReader.Reader.GetString("AIMLDateiDefekt"), (object) ResReader.Reader.GetString("DokumentElementNichtAIML")));
      if (this.XML.SelectNodes("/aiml").Count != 1)
        throw new AIMLDatei.AIMLDateiNichtGeladenException(string.Format(ResReader.Reader.GetString("AIMLDateiDefekt"), (object) ResReader.Reader.GetString("DokumentElementAIMLNurEinmal")));
      if (ToolboxSonstiges.IstEntwicklungsmodus)
        this.GegenAIMLDTDPruefen(AIMLDatei.PruefFehlerVerhalten.NiemalsFehlerZeigen);
      else
        this.GegenAIMLDTDPruefen(AIMLDatei.PruefFehlerVerhalten.BeiFehlerFragenObAnzeigen);
      this.TopicListeBereitstellen();
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
      this.Unterverzeichnisse = AIMLDatei.UnterverzeichnisseAusDateinameHerleiten(dateiname, arbeitsbereichRootPfad_);
    }

    public void GegenAIMLDTDPruefen(AIMLDatei.PruefFehlerVerhalten pruefVerhalten)
    {
      this.SeitLetztemIsChangedAufDTDFehlergeprueft = true;
      XMLQuellcodeAlsRTF xmlQuellcodeAlsRtf = new XMLQuellcodeAlsRTF();
      xmlQuellcodeAlsRtf.Regelwerk = new XMLRegelwerk(AIMLDTD.GetAIMLDTD());
      xmlQuellcodeAlsRtf.Rootnode = (XmlNode) this.XML.DocumentElement;
      xmlQuellcodeAlsRtf.NodeWirdGeprueftEvent += new EventHandler(this.toRtf_NodeWirdGeprueftEvent);
      xmlQuellcodeAlsRtf.Rendern();
      xmlQuellcodeAlsRtf.NodeWirdGeprueftEvent -= new EventHandler(this.toRtf_NodeWirdGeprueftEvent);
      if (xmlQuellcodeAlsRtf.FehlerProtokollAlsText == "")
      {
        this.HatFehler = false;
      }
      else
      {
        switch (pruefVerhalten)
        {
          case AIMLDatei.PruefFehlerVerhalten.FehlerDirektZeigen:
            xmlQuellcodeAlsRtf.QuellCodeUndFehlerInNeuemFormZeigen();
            break;
          case AIMLDatei.PruefFehlerVerhalten.BeiFehlerFragenObAnzeigen:
            if (MessageBox.Show(ResReader.Reader.GetString("FehlerImXMLDokJetztAnzeigen"), ResReader.Reader.GetString("DTDFehler"), MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
              xmlQuellcodeAlsRtf.QuellCodeUndFehlerInNeuemFormZeigen();
              break;
            }
            break;
        }
        this.HatFehler = true;
      }
    }

    public void Save(out bool cancel)
    {
      if (this._dateiname == null)
        throw new ApplicationException(ResReader.Reader.GetString("NochKeinDateinameVergeben"));
      if (!this.SeitLetztemIsChangedAufDTDFehlergeprueft)
        this.GegenAIMLDTDPruefen(AIMLDatei.PruefFehlerVerhalten.NiemalsFehlerZeigen);
      bool flag = true;
      if (this.HatFehler)
      {
        DialogResult dialogResult = MessageBox.Show(ResReader.Reader.GetString("SollDieDateiDefektGespeichertWerden"), string.Format(ResReader.Reader.GetString("DateiIstDefektUndSollteVorSpeichernKorrigiertWerden"), (object) this.Titel), MessageBoxButtons.YesNoCancel);
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
      AIMLDateiKommentare aimlDateiKommentare = new AIMLDateiKommentare(this.XML);
      aimlDateiKommentare.SchreibeKommentarEintrag("created with", string.Format("{0} V{1}", (object) Application.ProductName, (object) Application.ProductVersion));
      aimlDateiKommentare.SchreibeKommentarEintrag("licence", LizenzManager.ProgrammLizenzName);
      aimlDateiKommentare.SchreibeKommentarEintrag("author", Environment.UserName);
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
      string name = "ISO-8859-15";
      string str = Regex.Replace(this.XML.InnerXml.ToString(), "<\\?xml .*? ?>", "");
      string s = "<?xml version=\"1.0\" encoding=\"" + name + "\"?>" + str;
      if (true)
      {
        StringBuilder stringBuilder = new StringBuilder(s);
        stringBuilder.Replace("<category>", "\r\n<category>");
        stringBuilder.Replace("</category>", "\r\n</category>");
        stringBuilder.Replace("<template>", "\r\n\t<template>");
        stringBuilder.Replace("<pattern>", "\r\n\t<pattern>");
        stringBuilder.Replace("<random>", "\r\n\t\t<random>");
        stringBuilder.Replace("</random>", "\r\n\t\t</random>");
        stringBuilder.Replace("<li>", "\r\n\t\t\t<li>");
        stringBuilder.Replace("</aiml>", "\r\n</aiml>");
        stringBuilder.Replace("<aiml", "\r\n<aiml");
        stringBuilder.Replace("<!--", "\r\n<!--");
        s = stringBuilder.ToString();
      }
      byte[] bytes = Encoding.GetEncoding(name).GetBytes(s);
      fileStream.Write(bytes, 0, bytes.Length);
      fileStream.Close();
      this.IsChanged = false;
    }

    public void MitTargetBotStartFuellen()
    {
      this.LiesAusString("<aiml><category><pattern>TARGET BOTSTART</pattern><template>This is the greeting of a GaitoBot conversation.</template></category></aiml>");
    }

    private void XMLChangedEvent(object src, XmlNodeChangedEventArgs args)
    {
      this.IsChanged = true;
      this.SeitLetztemIsChangedAufDTDFehlergeprueft = false;
      this._anzahlCategories = -1;
      this.OnChangedEvent(EventArgs.Empty);
    }

    private string AIMLInhaltBereinigen(string inhalt)
    {
      string pattern1 = "<[?]xml[\\t\\r\\n ]+[^>]+>";
      inhalt = Regex.Replace(inhalt, pattern1, "<?xml version=\"1.0\" encoding=\"ISO-8859-15\"?>");
      string pattern2 = "<aiml[\\t\\r\\n ]+[^>]+>";
      inhalt = Regex.Replace(inhalt, pattern2, "<aiml>");
      inhalt = inhalt.Replace("<person/>", "<person><star/></person>");
      inhalt = inhalt.Replace("<person2/>", "<person2><star/></person2>");
      inhalt = inhalt.Replace("<gender/>", "<gender><star/></gender>");
      inhalt = inhalt.Replace("<sr/>", "<srai><star/></srai>");
      inhalt = inhalt.Replace("<person />", "<person><star/></person>");
      inhalt = inhalt.Replace("<person2 />", "<person2><star/></person2>");
      inhalt = inhalt.Replace("<gender />", "<gender><star/></gender>");
      inhalt = inhalt.Replace("<sr />", "<srai><star/></srai>");
      inhalt = this.TagsUmNameSpaceBereinigen(inhalt);
      return inhalt;
    }

    private string TagsUmNameSpaceBereinigen(string inhalt)
    {
      if (AIMLDatei._nameSpaceBereinigerOeffnendTag == null)
        AIMLDatei._nameSpaceBereinigerOeffnendTag = new Regex("<(?<namespace>[\\w-_]+):(?<inhalt>[^>]+)>", RegexOptions.Compiled);
      for (Match match = AIMLDatei._nameSpaceBereinigerOeffnendTag.Match(inhalt); match.Success; match = AIMLDatei._nameSpaceBereinigerOeffnendTag.Match(inhalt))
      {
        string str1 = match.Groups["namespace"].Value;
        string str2 = match.Groups[nameof (inhalt)].Value;
        inhalt = inhalt.Replace(string.Format("<{0}:{1}>", (object) str1, (object) str2), string.Format("<{0}>", (object) str2));
      }
      if (AIMLDatei._nameSpaceBereinigerSchliessendTag == null)
        AIMLDatei._nameSpaceBereinigerSchliessendTag = new Regex("</(?<namespace>[\\w-_]+):(?<inhalt>[^>]+)>", RegexOptions.Compiled);
      for (Match match = AIMLDatei._nameSpaceBereinigerSchliessendTag.Match(inhalt); match.Success; match = AIMLDatei._nameSpaceBereinigerSchliessendTag.Match(inhalt))
      {
        string str1 = match.Groups["namespace"].Value;
        string str2 = match.Groups[nameof (inhalt)].Value;
        inhalt = inhalt.Replace(string.Format("</{0}:{1}>", (object) str1, (object) str2), string.Format("</{0}>", (object) str2));
      }
      return inhalt;
    }

    private void TopicListeBereitstellen()
    {
      this._topicListe = new List<AIMLTopic>();
      this._topicListe.Add(new AIMLTopic((XmlNode) this.XML.DocumentElement, this));
      foreach (XmlNode selectNode in this.XML.SelectNodes("/aiml/topic"))
        this._topicListe.Add(new AIMLTopic(selectNode, this));
    }

    private static void ValidationCallback(object sender, ValidationEventArgs args)
    {
      Console.WriteLine("Validation error loading: {0}", (object) "");
      Console.WriteLine(args.Message);
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

    public class AIMLDateiNichtGeladenException : ApplicationException
    {
      public AIMLDateiNichtGeladenException(string message)
        : base(message)
      {
      }
    }
  }
}
