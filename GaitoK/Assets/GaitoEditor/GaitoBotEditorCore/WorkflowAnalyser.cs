// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.WorkflowAnalyser
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using System.Collections.Generic;

namespace GaitoBotEditorCore
{
  internal class WorkflowAnalyser
  {
    private Arbeitsbereich _arbeitsbereich;
    private AIMLCategory _kategorie;

    public List<AIMLCategory> ThatNachfolger
    {
      get
      {
        List<AIMLCategory> aimlCategoryList = new List<AIMLCategory>();
        foreach (AIMLDatei aimlDatei in this._arbeitsbereich.Dateiverwaltung.AlleAimlDateien)
        {
          foreach (AIMLTopic topic in aimlDatei.getTopics())
          {
            foreach (AIMLCategory category in topic.Categories)
            {
              if (category != this._kategorie && category.IstThatNachfolger(this._kategorie))
                aimlCategoryList.Add(category);
            }
          }
        }
        return aimlCategoryList;
      }
    }

    public List<AIMLCategory> SraiNachfolger
    {
      get
      {
        List<AIMLCategory> aimlCategoryList = new List<AIMLCategory>();
        foreach (AIMLDatei aimlDatei in this._arbeitsbereich.Dateiverwaltung.AlleAimlDateien)
        {
          foreach (AIMLTopic topic in aimlDatei.getTopics())
          {
            foreach (AIMLCategory category in topic.Categories)
            {
              if (category != this._kategorie && category.IstSraiNachfolger(this._kategorie))
                aimlCategoryList.Add(category);
            }
          }
        }
        return aimlCategoryList;
      }
    }

    public List<AIMLCategory> SraiVorgaenger
    {
      get
      {
        List<AIMLCategory> aimlCategoryList = new List<AIMLCategory>();
        foreach (AIMLDatei aimlDatei in this._arbeitsbereich.Dateiverwaltung.AlleAimlDateien)
        {
          foreach (AIMLTopic topic in aimlDatei.getTopics())
          {
            foreach (AIMLCategory category in topic.Categories)
            {
              if (category != this._kategorie && this._kategorie.IstSraiNachfolger(category))
                aimlCategoryList.Add(category);
            }
          }
        }
        return aimlCategoryList;
      }
    }

    public List<AIMLCategory> ThatVorgaenger
    {
      get
      {
        List<AIMLCategory> aimlCategoryList = new List<AIMLCategory>();
        foreach (AIMLDatei aimlDatei in this._arbeitsbereich.Dateiverwaltung.AlleAimlDateien)
        {
          foreach (AIMLTopic topic in aimlDatei.getTopics())
          {
            foreach (AIMLCategory category in topic.Categories)
            {
              if (category != this._kategorie && this._kategorie.IstThatNachfolger(category))
                aimlCategoryList.Add(category);
            }
          }
        }
        return aimlCategoryList;
      }
    }

    public List<AIMLCategory> Duplikate
    {
      get
      {
        List<AIMLCategory> aimlCategoryList = new List<AIMLCategory>();
        foreach (AIMLDatei aimlDatei in this._arbeitsbereich.Dateiverwaltung.AlleAimlDateien)
        {
          foreach (AIMLTopic topic in aimlDatei.getTopics())
          {
            foreach (AIMLCategory category in topic.Categories)
            {
              if (category != this._kategorie && this._kategorie.IstDuplikat(category))
                aimlCategoryList.Add(category);
            }
          }
        }
        return aimlCategoryList;
      }
    }

    public WorkflowAnalyser(Arbeitsbereich arbeitsbereich, AIMLCategory kategorie)
    {
      this._arbeitsbereich = arbeitsbereich;
      this._kategorie = kategorie;
    }

    public void FlushBuffer()
    {
    }
  }
}
