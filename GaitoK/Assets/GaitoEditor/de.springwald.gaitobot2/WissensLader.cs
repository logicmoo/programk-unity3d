// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.WissensLader
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using de.springwald.toolbox;
using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace de.springwald.gaitobot2
{
  internal class WissensLader
  {
    private readonly Wissen _wissen;
    private readonly Normalisierung _normalisierung;
    private readonly StringBuilder _protokoll;
    private readonly CultureInfo _protokollKultur;

    public event WissensLader.AimlDateiWirdGeladenEventHandler AimlDateiWirdGeladen;

    protected virtual void AimlDateiWirdGeladenEvent(string dateiname)
    {
      if (this.AimlDateiWirdGeladen == null)
        return;
      this.AimlDateiWirdGeladen((object) this, new WissensLader.AimlDateiWirdGeladenEventArgs(dateiname));
    }

    public string Protokoll
    {
      get
      {
        return this._protokoll.ToString();
      }
    }

    public WissensLader(Wissen wissen, CultureInfo protokollKultur, Normalisierung normalisierung)
    {
      this._wissen = wissen;
      this._protokollKultur = protokollKultur;
      this._normalisierung = normalisierung;
      this._protokoll = new StringBuilder();
      this._protokoll.AppendFormat(ResReader.Reader(this._protokollKultur).GetString("WissensLadenGestartetUm", this._protokollKultur), (object) DateTime.Now.ToString());
      this._protokoll.Append("\n");
    }

    public void LadeAimlDateienAusVerzeichnis(
      string verzeichnis,
      GaitoBotEigenschaften botEigenschaften)
    {
      if (Directory.Exists(verzeichnis))
      {
        string[] files = Directory.GetFiles(verzeichnis, "*.aiml");
        if (files.Length == 0)
        {
          this._protokoll.AppendFormat(ResReader.Reader(this._protokollKultur).GetString("KeineAIMLDateienImVerzeichnisGefunden", this._protokollKultur), (object) verzeichnis);
          this._protokoll.Append("\n");
        }
        foreach (string aimlDateiname in files)
          this.AIMLDateiVerarbeiten(aimlDateiname, botEigenschaften);
        this._protokoll.AppendFormat(ResReader.Reader(this._protokollKultur).GetString("VerzeichnisEingelesen", this._protokollKultur), (object) verzeichnis, (object) this._wissen.AnzahlCategories);
        this._protokoll.Append("\n");
      }
      else
      {
        this._protokoll.AppendFormat(ResReader.Reader(this._protokollKultur).GetString("VerzeichnisNichtGefunden", this._protokollKultur), (object) verzeichnis);
        this._protokoll.Append("\n");
      }
    }

    public void AIMLDateiVerarbeiten(string aimlDateiname, GaitoBotEigenschaften botEigenschaften)
    {
      XmlDocument doc = new XmlDocument();
      doc.PreserveWhitespace = true;
      doc.Load(aimlDateiname);
      this.AimldomDokumentVerarbeiten(doc, aimlDateiname, botEigenschaften);
    }

    public void AimldomDokumentVerarbeiten(
      XmlDocument doc,
      string aimlDateiname,
      GaitoBotEigenschaften botEigenschaften)
    {
      this.AimlDateiWirdGeladenEvent(aimlDateiname);
      ToolboxXML.WhitespacesBereinigen((XmlNode) doc.OwnerDocument);
      foreach (XmlNode childNode in doc.DocumentElement.ChildNodes)
      {
        string name = childNode.Name;
        if (!(name == "topic"))
        {
          if (name == "category")
            this.CategoryVerarbeiten(childNode, aimlDateiname, botEigenschaften);
        }
        else
          this.TopicVerarbeiten(childNode, aimlDateiname, botEigenschaften);
      }
    }

    private void TopicVerarbeiten(
      XmlNode topicNode,
      string aimlDateiname,
      GaitoBotEigenschaften botEigenschaften)
    {
      string themaName = topicNode.Attributes[0].Value;
      if (string.IsNullOrEmpty(themaName))
        themaName = "*";
      foreach (XmlNode selectNode in topicNode.SelectNodes("category"))
      {
        if (selectNode.Name == "category")
          this.CategoryVerarbeiten(selectNode, themaName, aimlDateiname, botEigenschaften);
      }
    }

    private void CategoryVerarbeiten(
      XmlNode categoryNode,
      string aimlDateiname,
      GaitoBotEigenschaften botEigenschaften)
    {
      this.CategoryVerarbeiten(categoryNode, "*", aimlDateiname, botEigenschaften);
    }

    private void CategoryVerarbeiten(
      XmlNode categoryNode,
      string themaName,
      string aimlDateiname,
      GaitoBotEigenschaften botEigenschaften)
    {
      this._wissen.CategoryAufnehmen(new WissensCategory(this._normalisierung, categoryNode, themaName, aimlDateiname, botEigenschaften));
    }

    public class AimlDateiWirdGeladenEventArgs : EventArgs
    {
      public readonly string Dateiname;

      public AimlDateiWirdGeladenEventArgs(string dateiname)
      {
        this.Dateiname = dateiname;
      }
    }

    public delegate void AimlDateiWirdGeladenEventHandler(
      object sender,
      WissensLader.AimlDateiWirdGeladenEventArgs e);
  }
}
