// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.ArbeitsbereichVerwaltung
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GaitoBotEditorCore
{
  public class ArbeitsbereichVerwaltung
  {
    private List<Arbeitsbereich> _arbeitsbereiche;

    public event EventHandler<EventArgs<Arbeitsbereich>> ArbeitsbereichAddedEvent;

    protected virtual void ArbeitsbereichAdded(Arbeitsbereich arbeitsbereich)
    {
      if (this.ArbeitsbereichAddedEvent == null)
        return;
      this.ArbeitsbereichAddedEvent((object) this, new EventArgs<Arbeitsbereich>(arbeitsbereich));
    }

    public event EventHandler<EventArgs<Arbeitsbereich>> ArbeitsbereichEntferntEvent;

    protected virtual void ArbeitsbereichEntfernt(Arbeitsbereich arbeitsbereich)
    {
      if (this.ArbeitsbereichEntferntEvent == null)
        return;
      this.ArbeitsbereichEntferntEvent((object) this, new EventArgs<Arbeitsbereich>(arbeitsbereich));
    }

    public List<Arbeitsbereich> VorhandeneNochNichtGeladeneArbeitsbereiche
    {
      get
      {
        List<Arbeitsbereich> arbeitsbereichList = new List<Arbeitsbereich>();
        foreach (string directory in Directory.GetDirectories(Config.GlobalConfig.ArbeitsbereicheSpeicherVerzeichnis))
        {
          string pfadkorrekt = directory + "\\";
          if (this._arbeitsbereiche.Where<Arbeitsbereich>((Func<Arbeitsbereich, bool>) (a => a.Arbeitsverzeichnis == pfadkorrekt)).Count<Arbeitsbereich>() <= 0 && File.Exists(pfadkorrekt + "metainfos.ser"))
          {
            Arbeitsbereich arbeitsbereich = new Arbeitsbereich(pfadkorrekt);
            arbeitsbereichList.Add(arbeitsbereich);
          }
        }
        return arbeitsbereichList;
      }
    }

    public List<Arbeitsbereich> Arbeitsbereiche
    {
      get
      {
        return this._arbeitsbereiche;
      }
    }

    public ArbeitsbereichVerwaltung()
    {
      this._arbeitsbereiche = new List<Arbeitsbereich>();
    }

    public void ProgrammSollBeendetWerden(out bool cancel)
    {
      foreach (Arbeitsbereich arbeitsbereich in this._arbeitsbereiche)
      {
        bool cancel1 = false;
        arbeitsbereich.ArbeitsbereichSollGeschlossenWerden(out cancel1);
        if (cancel1)
        {
          cancel = true;
          return;
        }
      }
      cancel = false;
    }

    public bool NeuenArbeitsbereichErstellenUndOeffnen()
    {
      bool abgebrochen = false;
      string str = InputBox.Show(ResReader.Reader.GetString("NamenFuerNeuenArbeitsbereichEingeben"), ResReader.Reader.GetString("NeuenArbeitsbereicherzeugen"), ResReader.Reader.GetString("unbenannt"), out abgebrochen);
      if (abgebrochen)
        return false;
      Arbeitsbereich arbeitsbereich = new Arbeitsbereich();
      arbeitsbereich.Name = str;
      this._arbeitsbereiche.Add(arbeitsbereich);
      this.ArbeitsbereichAdded(arbeitsbereich);
      return true;
    }

    public bool VorhandenenArbeitsbereichOeffnen(string arbeitsbereichVerzeichnis)
    {
      Arbeitsbereich arbeitsbereich = new Arbeitsbereich(arbeitsbereichVerzeichnis);
      this._arbeitsbereiche.Add(arbeitsbereich);
      this.ArbeitsbereichAdded(arbeitsbereich);
      return true;
    }

    public void ArbeitsbereichEntfernen(Arbeitsbereich arbeitsbereich)
    {
      if (!this._arbeitsbereiche.Contains(arbeitsbereich))
        return;
      this._arbeitsbereiche.Remove(arbeitsbereich);
      this.ArbeitsbereichEntfernt(arbeitsbereich);
    }
  }
}
