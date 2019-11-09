// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.AIMLCategory
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.gaitobot2;
using de.springwald.toolbox;
using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Xml;

namespace GaitoBotEditorCore
{
  public class AIMLCategory : IDisposable
  {
    private string _patternOptimiertBufferFuerVerwandte;
    private string[] _sraisOptimiertBufferFuerVerwandte;
    private Regex _patternRegExOptimiertBufferFuerVerwandte;
    private ArrayList _sraisRegExOptimiertBufferFuerVerwandte;
    private static Regex _regExNurStars;
    private AIMLTopic _topic;
    private XmlNode _node;
    private string _autoKurzName;
    private string _autoTemplateZusammenfassung;
    private string _autoThatZusammenfassung;
    private string _thatBuffer;
    private string _templateBuffer;
    private string _patternBuffer;
    private string[] _sraisBuffer;
    private bool _disposed;

    private static Regex RegExNurStars
    {
      get
      {
        if (AIMLCategory._regExNurStars == null)
          AIMLCategory._regExNurStars = new Regex("\\A([*]| )+\\z");
        return AIMLCategory._regExNurStars;
      }
    }

    private string PatternOptimiertFuerVerwandte
    {
      get
      {
        if (this._patternOptimiertBufferFuerVerwandte == null)
          this._patternOptimiertBufferFuerVerwandte = Normalisierung.EingabePatternOptimieren(this.Pattern, true);
        return this._patternOptimiertBufferFuerVerwandte;
      }
    }

    private string[] SraisOptimiertFuerVerwandte
    {
      get
      {
        if (this._sraisOptimiertBufferFuerVerwandte == null)
        {
          if (this.Srais.Length == 0)
          {
            this._sraisOptimiertBufferFuerVerwandte = new string[0];
          }
          else
          {
            ArrayList arrayList = new ArrayList();
            foreach (string srai in this.Srais)
            {
              if (!AIMLCategory.RegExNurStars.IsMatch(srai))
              {
                string str = Normalisierung.EingabePatternOptimieren(srai, true);
                if (!arrayList.Contains((object) str))
                  arrayList.Add((object) str);
              }
            }
            this._sraisOptimiertBufferFuerVerwandte = (string[]) arrayList.ToArray(typeof (string));
          }
        }
        return this._sraisOptimiertBufferFuerVerwandte;
      }
    }

    private Regex PatternRegExOptimiertFuerVerwandte
    {
      get
      {
        if (this._patternRegExOptimiertBufferFuerVerwandte == null)
          this._patternRegExOptimiertBufferFuerVerwandte = new Regex(string.Format("<srai>{0}</srai>", (object) this.PatternOptimiertFuerVerwandte.Replace("*", ".*?").Replace("+", "\\+")), RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        return this._patternRegExOptimiertBufferFuerVerwandte;
      }
    }

    private ArrayList SraisRegExOptimiertFuerVerwandte
    {
      get
      {
        if (this._sraisRegExOptimiertBufferFuerVerwandte == null)
        {
          this._sraisRegExOptimiertBufferFuerVerwandte = new ArrayList();
          foreach (string str in this.SraisOptimiertFuerVerwandte)
            this._sraisRegExOptimiertBufferFuerVerwandte.Add((object) new Regex(string.Format("\\A{0}\\z", (object) str.Replace("*", ".*?").Replace("+", "\\+")), RegexOptions.IgnoreCase | RegexOptions.CultureInvariant));
        }
        return this._sraisRegExOptimiertBufferFuerVerwandte;
      }
    }

    public bool IstThatNachfolger(AIMLCategory potentiellerVorgaenger)
    {
      return potentiellerVorgaenger != this && potentiellerVorgaenger.AIMLTopic.Name == this.AIMLTopic.Name && !potentiellerVorgaenger.Template.Contains("<srai>") && (!(this.That == "") && !(this.That == "*") && potentiellerVorgaenger.Template == this.That);
    }

    public bool IstSraiNachfolger(AIMLCategory potentiellerVorgaenger)
    {
      if (potentiellerVorgaenger == this || !(potentiellerVorgaenger.AIMLTopic.Name == this.AIMLTopic.Name) || potentiellerVorgaenger.Srais.Length == 0)
        return false;
      foreach (Regex regex in potentiellerVorgaenger.SraisRegExOptimiertFuerVerwandte)
      {
        if (regex.IsMatch(this.Pattern))
          return true;
      }
      foreach (string input in potentiellerVorgaenger.SraisOptimiertFuerVerwandte)
      {
        if (!AIMLCategory.RegExNurStars.IsMatch(this.Pattern) && this.PatternRegExOptimiertFuerVerwandte.IsMatch(input))
          return true;
      }
      return false;
    }

    public bool IstDuplikat(AIMLCategory potentiellesDuplikat)
    {
      return potentiellesDuplikat != this && (potentiellesDuplikat.AIMLTopic.Name == this.AIMLTopic.Name && potentiellesDuplikat.Pattern == this.Pattern && potentiellesDuplikat.That == this.That);
    }

    public XmlNode ContentNode
    {
      get
      {
        return this._node;
      }
    }

    public AIMLTopic AIMLTopic
    {
      get
      {
        return this._topic;
      }
    }

    public string AutoKomplettZusammenfassung
    {
      get
      {
        if (this.AutoThatZusammenfassung == "")
          return string.Format("{0} >> {1}", (object) this.AutoKurzNamePattern, (object) this.AutoTemplateZusammenfassung);
        return string.Format("{0} ({1}) >> {2}", (object) this.AutoKurzNamePattern, (object) this.AutoThatZusammenfassung, (object) this.AutoTemplateZusammenfassung);
      }
    }

    public string AutoThatZusammenfassung
    {
      get
      {
        try
        {
          if (this._autoThatZusammenfassung == null)
          {
            XmlNode xmlNode = this._node.SelectSingleNode("that");
            if (xmlNode == null)
            {
              this._autoThatZusammenfassung = "";
            }
            else
            {
              this._autoThatZusammenfassung = xmlNode.InnerXml;
              this._autoThatZusammenfassung = this._autoThatZusammenfassung.Trim('\n', '\t', '\r', '\v');
            }
          }
        }
        catch (Exception ex)
        {
          return string.Format(ResReader.Reader.GetString("NodeNichtVorhandenOderFehlerhaft"), (object) "that");
        }
        return this._autoThatZusammenfassung;
      }
    }

    public string AutoKurzNamePattern
    {
      get
      {
        try
        {
          if (this._autoKurzName == null)
            this._autoKurzName = this._node.SelectSingleNode("pattern").InnerXml;
        }
        catch (Exception ex)
        {
          return string.Format(ResReader.Reader.GetString("NodeNichtVorhandenOderFehlerhaft"), (object) "pattern");
        }
        return this._autoKurzName;
      }
    }

    public string AutoTemplateZusammenfassung
    {
      get
      {
        try
        {
          if (this._autoTemplateZusammenfassung == null)
          {
            this._autoTemplateZusammenfassung = this._node.SelectSingleNode("template").InnerXml;
            this._autoTemplateZusammenfassung = this._autoTemplateZusammenfassung.Trim('\n', '\t', '\r', '\v');
          }
        }
        catch (Exception ex)
        {
          return string.Format(ResReader.Reader.GetString("NodeNichtVorhandenOderFehlerhaft"), (object) "template");
        }
        return this._autoTemplateZusammenfassung;
      }
    }

    public string That
    {
      get
      {
        if (this._thatBuffer == null)
        {
          try
          {
            XmlNode xmlNode = this._node.SelectSingleNode("that");
            this._thatBuffer = xmlNode != null ? ToolboxStrings.UmlauteAussschreiben(xmlNode.InnerXml) : "";
          }
          catch (Exception ex)
          {
            this._thatBuffer = string.Format(ResReader.Reader.GetString("NodeNichtVorhandenOderFehlerhaft"), (object) "that");
          }
        }
        return this._thatBuffer;
      }
    }

    public string Pattern
    {
      get
      {
        if (this._patternBuffer == null)
        {
          try
          {
            XmlNode xmlNode = this._node.SelectSingleNode("pattern");
            this._patternBuffer = xmlNode != null ? ToolboxStrings.UmlauteAussschreiben(xmlNode.InnerXml) : "";
          }
          catch (Exception ex)
          {
            this._patternBuffer = string.Format(ResReader.Reader.GetString("NodeNichtVorhandenOderFehlerhaft"), (object) "pattern");
          }
        }
        return this._patternBuffer;
      }
    }

    public string Template
    {
      get
      {
        if (this._templateBuffer == null)
        {
          try
          {
            XmlNode xmlNode = this._node.SelectSingleNode("template");
            this._templateBuffer = xmlNode != null ? ToolboxStrings.UmlauteAussschreiben(xmlNode.InnerXml) : "";
          }
          catch (Exception ex)
          {
            return string.Format(ResReader.Reader.GetString("NodeNichtVorhandenOderFehlerhaft"), (object) "template");
          }
        }
        return this._templateBuffer;
      }
    }

    public string[] Srais
    {
      get
      {
        if (this._sraisBuffer == null)
        {
          MatchCollection matchCollection = Regex.Matches(this.Template, "<srai>.+?</srai>");
          if (matchCollection.Count == 0)
          {
            this._sraisBuffer = new string[0];
          }
          else
          {
            ArrayList arrayList = new ArrayList();
            foreach (Match match in matchCollection)
            {
              string str1 = match.Value;
              string str2 = Regex.Replace(match.Value, "<star .*?/>", "*").Replace("<srai>", "").Replace("</srai>", "");
              if (!arrayList.Contains((object) str2))
                arrayList.Add((object) str2);
            }
            this._sraisBuffer = (string[]) arrayList.ToArray(typeof (string));
          }
        }
        return this._sraisBuffer;
      }
    }

    public AIMLCategory(XmlNode categoryNode, AIMLTopic topic)
    {
      this._node = categoryNode;
      this._topic = topic;
      this._node.OwnerDocument.NodeChanged += new XmlNodeChangedEventHandler(this.OwnerDocument_NodeChanged);
      this._node.OwnerDocument.NodeInserted += new XmlNodeChangedEventHandler(this.OwnerDocument_NodeChanged);
      this._node.OwnerDocument.NodeRemoved += new XmlNodeChangedEventHandler(this.OwnerDocument_NodeChanged);
    }

    public void BufferLeeren()
    {
      this._autoKurzName = (string) null;
      this._autoTemplateZusammenfassung = (string) null;
      this._autoThatZusammenfassung = (string) null;
      this._thatBuffer = (string) null;
      this._templateBuffer = (string) null;
      this._patternBuffer = (string) null;
      this._patternOptimiertBufferFuerVerwandte = (string) null;
      this._sraisBuffer = (string[]) null;
      this._sraisOptimiertBufferFuerVerwandte = (string[]) null;
      this._patternRegExOptimiertBufferFuerVerwandte = (Regex) null;
      this._sraisRegExOptimiertBufferFuerVerwandte = (ArrayList) null;
    }

    public static AIMLCategory createNewCategory(AIMLTopic topic)
    {
      XmlTextReader xmlTextReader = new XmlTextReader("<category><pattern></pattern><template></template></category>", XmlNodeType.Element, (XmlParserContext) null);
      int content = (int) xmlTextReader.MoveToContent();
      XmlNode xmlNode = topic.TopicNode.OwnerDocument.ReadNode((XmlReader) xmlTextReader);
      topic.TopicNode.AppendChild(xmlNode);
      return new AIMLCategory(xmlNode, topic);
    }

    public static AIMLCategory createNewCategory(
      AIMLTopic topic,
      XmlNode newCategoryNode)
    {
      topic.TopicNode.AppendChild(newCategoryNode);
      return new AIMLCategory(newCategoryNode, topic);
    }

    public void Delete()
    {
      this._node.ParentNode.RemoveChild(this._node);
      this.Dispose();
    }

    private void OwnerDocument_NodeChanged(object sender, XmlNodeChangedEventArgs e)
    {
      if (e.Node == this._node)
      {
        this.BufferLeeren();
      }
      else
      {
        switch (e.Action)
        {
          case XmlNodeChangedAction.Insert:
            if (e.NewParent == this._node)
            {
              this.BufferLeeren();
              break;
            }
            if (ToolboxXML.IstChild(e.NewParent, this._node))
              this.BufferLeeren();
            break;
          case XmlNodeChangedAction.Remove:
            if (e.OldParent == this._node)
            {
              this.BufferLeeren();
              break;
            }
            if (ToolboxXML.IstChild(e.OldParent, this._node))
              this.BufferLeeren();
            break;
          case XmlNodeChangedAction.Change:
            if (ToolboxXML.IstChild(e.Node, this._node))
            {
              this.BufferLeeren();
              break;
            }
            break;
        }
      }
    }

    public void Dispose()
    {
      if (this._disposed)
        return;
      this._disposed = true;
      this._node.OwnerDocument.NodeChanged -= new XmlNodeChangedEventHandler(this.OwnerDocument_NodeChanged);
      this._node.OwnerDocument.NodeInserted -= new XmlNodeChangedEventHandler(this.OwnerDocument_NodeChanged);
      this._node.OwnerDocument.NodeRemoved -= new XmlNodeChangedEventHandler(this.OwnerDocument_NodeChanged);
      this._node = (XmlNode) null;
      this.BufferLeeren();
    }
  }
}
