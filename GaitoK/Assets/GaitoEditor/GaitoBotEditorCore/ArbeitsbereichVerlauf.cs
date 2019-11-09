// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.ArbeitsbereichVerlauf
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using System;
using System.Collections.Generic;

namespace GaitoBotEditorCore
{
  public class ArbeitsbereichVerlauf
  {
    private static int _maxVerlauf = 500;
    private ArbeitsbereichFokus _fokus;
    private List<AIMLCategory> _vorher;
    private List<AIMLCategory> _nachher;
    private bool _eigeneNavigationLaeuft;

    public event EventHandler Changed;

    protected virtual void ChangedEvent()
    {
      if (this.Changed == null)
        return;
      this.Changed((object) this, EventArgs.Empty);
    }

    public bool ZurueckVerfuegbar
    {
      get
      {
        return this._vorher.Count > 1;
      }
    }

    public bool VorwaertsVerfuegbar
    {
      get
      {
        return this._nachher.Count > 1;
      }
    }

    public ArbeitsbereichVerlauf(ArbeitsbereichFokus fokus)
    {
      this._fokus = fokus;
      this._fokus.AktAIMLCategoryChanged += new EventHandler<EventArgs<AIMLCategory>>(this.FokusAktAimlCategoryChanged);
      this._vorher = new List<AIMLCategory>();
      this._nachher = new List<AIMLCategory>();
    }

    public void AlleVerweiseDieserDateiEntfernen(IArbeitsbereichDatei datei)
    {
      if (!(datei is AIMLDatei))
        return;
      this.AlleVerweiseDieserAIMLDateiEntfernen((AIMLDatei) datei);
    }

    public void AlleVerweiseDieserAIMLDateiEntfernen(AIMLDatei datei)
    {
      foreach (AIMLTopic topic in datei.getTopics())
        this.AlleVerweiseDiesesAIMLTopicEntfernen(topic);
    }

    public void AlleVerweiseDiesesAIMLTopicEntfernen(AIMLTopic topic)
    {
      foreach (AIMLCategory category in topic.Categories)
        this.AlleVerweiseDieserAIMLCategoryEntfernen(category);
    }

    public void AlleVerweiseDieserAIMLCategoryEntfernen(AIMLCategory category)
    {
      bool flag = false;
      if (this._vorher.Contains(category))
      {
        this._vorher.Remove(category);
        flag = true;
      }
      if (this._nachher.Contains(category))
      {
        this._nachher.Remove(category);
        flag = true;
      }
      if (!flag)
        return;
      this.ChangedEvent();
    }

    public void Vorwaerts()
    {
      if (this._nachher.Count < 2)
        return;
      this._eigeneNavigationLaeuft = true;
      AIMLCategory aimlCategory = this._nachher[this._nachher.Count - 1];
      this._nachher.RemoveAt(this._nachher.Count - 1);
      this._vorher.Add(aimlCategory);
      if (this._nachher.Count > 0)
      {
        this._fokus.AktAIMLCategory = this._nachher[this._nachher.Count - 1];
        this._vorher.Add(this._nachher[this._nachher.Count - 1]);
      }
      this._eigeneNavigationLaeuft = false;
      this.ChangedEvent();
    }

    public void Zurueck()
    {
      if (this._vorher.Count < 2)
        return;
      this._eigeneNavigationLaeuft = true;
      AIMLCategory aimlCategory = this._vorher[this._vorher.Count - 1];
      this._vorher.RemoveAt(this._vorher.Count - 1);
      this._nachher.Add(aimlCategory);
      if (this._vorher.Count > 0)
      {
        this._fokus.AktAIMLCategory = this._vorher[this._vorher.Count - 1];
        this._nachher.Add(this._vorher[this._vorher.Count - 1]);
      }
      this._eigeneNavigationLaeuft = false;
      this.ChangedEvent();
    }

    private void FokusAktAimlCategoryChanged(object sender, EventArgs<AIMLCategory> e)
    {
      if (this._eigeneNavigationLaeuft || e.Value == null || (uint) this._vorher.Count > 0U && this._vorher[this._vorher.Count - 1] == e.Value)
        return;
      this._vorher.Add(e.Value);
      if ((uint) this._nachher.Count > 0U)
      {
        if (this._nachher[this._nachher.Count - 1] == e.Value)
          this._nachher.RemoveAt(this._nachher.Count - 1);
        else
          this._nachher.Clear();
      }
      while (this._vorher.Count > ArbeitsbereichVerlauf._maxVerlauf)
        this._vorher.RemoveAt(0);
      this.ChangedEvent();
    }
  }
}
