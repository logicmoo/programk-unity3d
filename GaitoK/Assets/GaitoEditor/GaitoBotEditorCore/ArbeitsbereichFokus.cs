// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.ArbeitsbereichFokus
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using de.springwald.xml.cursor;
using de.springwald.xml.editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace GaitoBotEditorCore
{
  public class ArbeitsbereichFokus
  {
    private IArbeitsbereichDatei _aktDatei;
    private AIMLTopic _aktAIMLTopic;
    private AIMLCategory _aktAIMLCategory;
    private XMLEditor _xmlEditor;

    public event ArbeitsbereichFokus.AktDateiChangedEventHandler AktDateiChanged;

    protected virtual void AktDateiChangedEvent(IArbeitsbereichDatei datei)
    {
      if (this.AktDateiChanged == null)
        return;
      this.AktDateiChanged((object) this, new EventArgs<IArbeitsbereichDatei>(datei));
    }

    public event ArbeitsbereichFokus.AktAIMLTopicChangedEventHandler AktAIMLTopicChanged;

    protected virtual void AktAIMLTopicChangedEvent(AIMLTopic topic)
    {
      if (this.AktAIMLTopicChanged == null)
        return;
      this.AktAIMLTopicChanged((object) this, new ArbeitsbereichFokus.AktAIMLTopicChangedEventArgs(topic));
    }

    public event EventHandler<EventArgs<AIMLCategory>> AktAIMLCategoryChanged;

    protected virtual void AktAIMLCategoryChangedEvent(AIMLCategory category)
    {
      if (this.AktAIMLCategoryChanged == null)
        return;
      this.AktAIMLCategoryChanged((object) this, new EventArgs<AIMLCategory>(category));
    }

    public IArbeitsbereichDatei AktDatei
    {
      get
      {
        return this._aktDatei;
      }
      set
      {
        bool flag = this._aktDatei != value;
        this._aktDatei = value;
        if (!flag)
          return;
        this.AktDateiChangedEvent(this._aktDatei);
        if (this._aktDatei is AIMLDatei)
        {
          this.BestesTopicSelektieren();
          this.BesteCategorySelektieren();
        }
        if (this._aktDatei is StartupDatei)
        {
          this.AktAIMLTopic = (AIMLTopic) null;
          this.AktAIMLCategory = (AIMLCategory) null;
          Application.DoEvents();
          this.FokusAufXmlEditorSetzen();
          Application.DoEvents();
          this.XMLCursorInDasErsteTagDerStartUpDateietzen();
          Application.DoEvents();
        }
      }
    }

    public AIMLTopic AktAIMLTopic
    {
      get
      {
        return this._aktAIMLTopic;
      }
      set
      {
        if (value != null && this.AktDatei != value.AIMLDatei)
        {
          this._aktDatei = (IArbeitsbereichDatei) value.AIMLDatei;
          this.AktDateiChangedEvent(this._aktDatei);
        }
        bool flag = this._aktAIMLTopic != value;
        this._aktAIMLTopic = value;
        if (flag)
        {
          this.AktAIMLTopicChangedEvent(this._aktAIMLTopic);
          this.BesteCategorySelektieren();
        }
        if (this._aktDatei == null || !(this._aktDatei is AIMLDatei))
          return;
        ((AIMLDatei) this._aktDatei).ZuletztInDieserDateiGewaehlesTopic = this._aktAIMLTopic;
      }
    }

    public AIMLCategory AktAIMLCategory
    {
      get
      {
        return this._aktAIMLCategory;
      }
      set
      {
        if (value != null)
        {
          if (this.AktDatei != value.AIMLTopic.AIMLDatei)
          {
            this._aktDatei = (IArbeitsbereichDatei) value.AIMLTopic.AIMLDatei;
            this.AktDateiChangedEvent(this._aktDatei);
          }
          if (this.AktAIMLTopic != value.AIMLTopic)
          {
            this._aktAIMLTopic = value.AIMLTopic;
            this.AktAIMLTopicChangedEvent(this._aktAIMLTopic);
          }
        }
        bool flag = this._aktAIMLCategory != value;
        this._aktAIMLCategory = value;
        if (flag)
        {
          this.AktAIMLCategoryChangedEvent(this._aktAIMLCategory);
          this.XMLCursorInDasPatternTagDerAktuellenCategorySetzen();
        }
        if (this._aktAIMLTopic == null)
          return;
        this._aktAIMLTopic.ZuletztInDiesemTopicGewaehlteCategory = this._aktAIMLCategory;
      }
    }

    public XMLEditor XmlEditor
    {
      get
      {
        return this._xmlEditor;
      }
      set
      {
        this._xmlEditor = value;
      }
    }

    public void FokusAufXmlEditorSetzen()
    {
      if (this._xmlEditor == null)
        return;
      this._xmlEditor.ZeichnungsSteuerelement.Focus();
    }

    public void XMLCursorInDasErsteTagDerStartUpDateietzen()
    {
      if (this._aktDatei == null || !(this._aktDatei is StartupDatei) || ((StartupDatei) this._aktDatei).XML.DocumentElement != this._xmlEditor.RootNode)
        return;
      XmlNode firstChild1 = ((StartupDatei) this._aktDatei).XML.DocumentElement.FirstChild;
      if (firstChild1 == null)
        return;
      if (firstChild1.ChildNodes.Count == 0)
      {
        this._xmlEditor.CursorRoh.BeideCursorPosSetzen(firstChild1, XMLCursorPositionen.CursorInDemLeeremNode);
      }
      else
      {
        XmlNode firstChild2 = firstChild1.FirstChild;
        if (firstChild2 != null)
          this._xmlEditor.CursorRoh.BeideCursorPosSetzen(firstChild2, XMLCursorPositionen.CursorVorDemNode);
      }
    }

    public void XMLCursorInDasPatternTagDerAktuellenCategorySetzen()
    {
      if (this._xmlEditor == null || this._aktAIMLCategory == null || this._aktAIMLCategory.ContentNode != this._xmlEditor.RootNode)
        return;
      XmlNode contentNode = this._aktAIMLCategory.ContentNode;
      if (contentNode != null)
      {
        XmlNode firstChild1 = contentNode.FirstChild;
        if (firstChild1 != null && !(firstChild1.Name != "pattern"))
        {
          if (firstChild1.ChildNodes.Count == 0)
          {
            this._xmlEditor.CursorRoh.BeideCursorPosSetzen(firstChild1, XMLCursorPositionen.CursorInDemLeeremNode);
          }
          else
          {
            XmlNode firstChild2 = firstChild1.FirstChild;
            if (firstChild2 != null)
              this._xmlEditor.CursorRoh.BeideCursorPosSetzen(firstChild2, XMLCursorPositionen.CursorVorDemNode);
          }
        }
      }
    }

    public void BestesTopicSelektieren()
    {
      if (this._aktDatei == null)
        this.AktAIMLTopic = (AIMLTopic) null;
      else if (!(this._aktDatei is AIMLDatei))
      {
        this.AktAIMLTopic = (AIMLTopic) null;
      }
      else
      {
        AIMLDatei aktDatei = (AIMLDatei) this._aktDatei;
        IOrderedEnumerable<AIMLTopic> source = aktDatei.getTopics().OrderBy<AIMLTopic, string>((Func<AIMLTopic, string>) (t => t.Name));
        AIMLTopic dateiGewaehlesTopic = aktDatei.ZuletztInDieserDateiGewaehlesTopic;
        if (dateiGewaehlesTopic != null && source.Contains<AIMLTopic>(dateiGewaehlesTopic))
          this.AktAIMLTopic = dateiGewaehlesTopic;
        else
          this.AktAIMLTopic = source.Count<AIMLTopic>() != 0 ? source.First<AIMLTopic>() : (AIMLTopic) null;
      }
    }

    public void BesteCategorySelektieren()
    {
      if (this._aktAIMLTopic == null)
      {
        this.AktAIMLCategory = (AIMLCategory) null;
      }
      else
      {
        List<AIMLCategory> categories = this._aktAIMLTopic.Categories;
        AIMLCategory gewaehlteCategory = this._aktAIMLTopic.ZuletztInDiesemTopicGewaehlteCategory;
        AIMLCategory aimlCategory = (AIMLCategory) null;
        if (gewaehlteCategory != null && categories.Contains(gewaehlteCategory))
          aimlCategory = gewaehlteCategory;
        if (aimlCategory == null)
          aimlCategory = categories.Count != 0 ? categories[0] : (AIMLCategory) null;
        this.AktAIMLCategory = aimlCategory;
      }
    }

    public delegate void AktDateiChangedEventHandler(
      object sender,
      EventArgs<IArbeitsbereichDatei> e);

    public class AktAIMLTopicChangedEventArgs : EventArgs
    {
      public AIMLTopic topic;

      public AktAIMLTopicChangedEventArgs(AIMLTopic topic)
      {
        this.topic = topic;
      }
    }

    public delegate void AktAIMLTopicChangedEventHandler(
      object sender,
      ArbeitsbereichFokus.AktAIMLTopicChangedEventArgs e);
  }
}
