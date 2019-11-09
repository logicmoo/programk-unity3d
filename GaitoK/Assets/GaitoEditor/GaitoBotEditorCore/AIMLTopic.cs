// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.AIMLTopic
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;

namespace GaitoBotEditorCore
{
  public class AIMLTopic : IDisposable
  {
    private AIMLDatei _aimlDatei;
    private XmlNode _topicNode;
    private bool _istRootTopic;
    private List<AIMLCategory> __categoryListe;
    private AIMLCategory _zuletztInDiesemTopicGewaehlteCategory;

    public List<AIMLCategory> Categories
    {
      get
      {
        if (this.__categoryListe == null)
        {
          this.__categoryListe = new List<AIMLCategory>();
          foreach (XmlNode selectNode in this._topicNode.SelectNodes("category"))
            this.__categoryListe.Add(new AIMLCategory(selectNode, this));
        }
        return this.__categoryListe;
      }
    }

    public AIMLDatei AIMLDatei
    {
      get
      {
        return this._aimlDatei;
      }
    }

    public XmlNode TopicNode
    {
      get
      {
        return this._topicNode;
      }
    }

    public string Name
    {
      get
      {
        if (this._istRootTopic)
          return "_standard_";
        return this._topicNode.Attributes.GetNamedItem("name").Value.ToString();
      }
      set
      {
        if (this._istRootTopic)
          return;
        this._topicNode.Attributes.GetNamedItem("name").Value = value;
      }
    }

    public bool IstRootTopic
    {
      get
      {
        return this._istRootTopic;
      }
    }

    public AIMLCategory ZuletztInDiesemTopicGewaehlteCategory
    {
      get
      {
        return this._zuletztInDiesemTopicGewaehlteCategory;
      }
      set
      {
        this._zuletztInDiesemTopicGewaehlteCategory = value;
      }
    }

    public AIMLTopic(XmlNode xmlNode, AIMLDatei aimlDatei)
    {
      this._topicNode = xmlNode;
      this._aimlDatei = aimlDatei;
      this._istRootTopic = this._topicNode.Name.Equals("aiml");
      if (this._istRootTopic || this._topicNode.Attributes.GetNamedItem("name") != null)
        return;
      this._topicNode.Attributes.Append(this._topicNode.OwnerDocument.CreateAttribute("", "name", ""));
    }

    public void LoescheCategory(AIMLCategory category)
    {
      if (category == null)
        return;
      if (this.Categories == null)
      {
        Debugger.GlobalDebugger.FehlerZeigen("Categories == null", (object) this, "GaitoBotEditorCore.AIMLTopic.LoescheCategory");
      }
      else
      {
        if (this.Categories.Contains(category))
          this.Categories.Remove(category);
        if (this._aimlDatei == null)
          Debugger.GlobalDebugger.FehlerZeigen("_aimlDatei == null", (object) this, "GaitoBotEditorCore.AIMLTopic.LoescheCategory");
        else if (this._aimlDatei.Arbeitsbereich == null)
          Debugger.GlobalDebugger.FehlerZeigen("_aimlDatei.Arbeitsbereich == null", (object) this, "GaitoBotEditorCore.AIMLTopic.LoescheCategory");
        else if (this._aimlDatei.Arbeitsbereich.Verlauf == null)
        {
          Debugger.GlobalDebugger.FehlerZeigen("_aimlDatei.Arbeitsbereich.Verlauf == null", (object) this, "GaitoBotEditorCore.AIMLTopic.LoescheCategory");
        }
        else
        {
          this._aimlDatei.Arbeitsbereich.Verlauf.AlleVerweiseDieserAIMLCategoryEntfernen(category);
          if (category == null)
            throw new ApplicationException("category wurde offenbar nachträglich noch == null");
          try
          {
            category.Delete();
          }
          catch (Exception ex)
          {
            throw new ApplicationException("Fehler bei  category.Delete():" + ex.Message);
          }
          try
          {
            category.Dispose();
          }
          catch (Exception ex)
          {
            throw new ApplicationException("Fehler bei  category.Dispose():" + ex.Message);
          }
        }
      }
    }

    public void CategoriesSortieren_()
    {
      ArrayList arrayList = new ArrayList();
      foreach (AIMLCategory category in this.Categories)
      {
        XmlNode xmlNode = this._topicNode.RemoveChild(category.ContentNode);
        arrayList.Add((object) xmlNode);
      }
      arrayList.Sort((IComparer) new AIMLCategoryNodeSortierer());
      foreach (XmlNode newChild in arrayList)
        this._topicNode.AppendChild(newChild);
      this.__categoryListe = (List<AIMLCategory>) null;
    }

    public AIMLCategory AddNewCategory()
    {
      AIMLCategory newCategory = AIMLCategory.createNewCategory(this);
      this.Categories.Add(newCategory);
      return newCategory;
    }

    public AIMLCategory AddNewCategory(XmlNode newCategoryNode)
    {
      AIMLCategory newCategory = AIMLCategory.createNewCategory(this, newCategoryNode);
      this.Categories.Add(newCategory);
      return newCategory;
    }

    public void Delete()
    {
      if (this._istRootTopic)
        throw new ApplicationException("Root-Topic can´t be deleted!");
      this._topicNode.ParentNode.RemoveChild(this._topicNode);
      this.Dispose();
    }

    public static AIMLTopic createNewTopic(AIMLDatei aimlDatei)
    {
      XmlTextReader xmlTextReader = new XmlTextReader("<topic name=\"noname\"></topic>", XmlNodeType.Element, (XmlParserContext) null);
      int content = (int) xmlTextReader.MoveToContent();
      XmlNode xmlNode = aimlDatei.XML.ReadNode((XmlReader) xmlTextReader);
      aimlDatei.XML.DocumentElement.AppendChild(xmlNode);
      return new AIMLTopic(xmlNode, aimlDatei);
    }

    public void Dispose()
    {
      this._topicNode = (XmlNode) null;
      this.__categoryListe = (List<AIMLCategory>) null;
    }
  }
}
