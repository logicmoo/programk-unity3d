// Decompiled with JetBrains decompiler
// Type: GaitoBotEditor.Arbeitsbereiche
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using de.springwald.toolbox;
using GaitoBotEditorCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GaitoBotEditor
{
  public class Arbeitsbereiche : UserControl
  {
    private IContainer components = (IContainer) null;
    private ArbeitsbereichVerwaltung _arbeitsbereichVerwaltung;
    private Label labelTitelArbeitsbereiche;
    private LinkLabel linkLabelNeuenArbeitsbereich;
    private Panel panelArbeitsbereiche;

    public ArbeitsbereichVerwaltung ArbeitsbereichVerwaltung
    {
      set
      {
        this._arbeitsbereichVerwaltung = value;
        this._arbeitsbereichVerwaltung.ArbeitsbereichAddedEvent += new EventHandler<EventArgs<Arbeitsbereich>>(this._arbeitsbereichVerwaltung_ArbeitsbereichAddedEvent);
        this._arbeitsbereichVerwaltung.ArbeitsbereichEntferntEvent += new EventHandler<EventArgs<Arbeitsbereich>>(this._arbeitsbereichVerwaltung_ArbeitsbereichEntferntEvent);
        this.VorhandeneArbeitsbereicheAuflisten();
      }
    }

    private void _arbeitsbereichVerwaltung_ArbeitsbereichEntferntEvent(
      object sender,
      EventArgs<Arbeitsbereich> e)
    {
      this.VorhandeneArbeitsbereicheAuflisten();
    }

    private void _arbeitsbereichVerwaltung_ArbeitsbereichAddedEvent(
      object sender,
      EventArgs<Arbeitsbereich> e)
    {
      this.VorhandeneArbeitsbereicheAuflisten();
    }

    public Arbeitsbereiche()
    {
      this.InitializeComponent();
    }

    private void Arbeitsbereiche_Load(object sender, EventArgs e)
    {
    }

    private void VorhandeneArbeitsbereicheAuflisten()
    {
      List<Arbeitsbereich> geladeneArbeitsbereiche = this._arbeitsbereichVerwaltung.VorhandeneNochNichtGeladeneArbeitsbereiche;
      this.panelArbeitsbereiche.Controls.Clear();
      foreach (Arbeitsbereich arbeitsbereich in geladeneArbeitsbereiche)
      {
        EinArbeitsBereichListenEintrag bereichListenEintrag = new EinArbeitsBereichListenEintrag();
        bereichListenEintrag.Anzeigen(arbeitsbereich);
        this.panelArbeitsbereiche.Controls.Add((Control) bereichListenEintrag);
        bereichListenEintrag.Dock = DockStyle.Top;
        bereichListenEintrag.ArbeitsbereichOeffnen += new EventHandler<EventArgs<Arbeitsbereich>>(this.eintrag_ArbeitsbereichOeffnen);
        bereichListenEintrag.ArbeitsbereichLoeschen += new EventHandler<EventArgs<Arbeitsbereich>>(this.eintrag_ArbeitsbereichLoeschen);
      }
    }

    private void eintrag_ArbeitsbereichLoeschen(object sender, EventArgs<Arbeitsbereich> e)
    {
      if (MessageBox.Show(string.Format("Sind Sie sicher, dass Sie den Arbeitsbereich '{0}' inklusive aller seiner Inhalte löschen möchten?", (object) e.Value.Name), "Warnung", MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
        return;
      try
      {
        e.Value.Loeschen();
        this._arbeitsbereichVerwaltung.ArbeitsbereichEntfernen(e.Value);
        this.VorhandeneArbeitsbereicheAuflisten();
        int num = (int) MessageBox.Show("Arbeitsbereich erfolgreich gelöscht");
      }
      catch (Exception ex)
      {
        int num = (int) MessageBox.Show(string.Format("Konnte Arbeitsbereich nicht oder nur teilweise löschen: {0}", (object) ex.Message));
      }
    }

    private void eintrag_ArbeitsbereichOeffnen(object sender, EventArgs<Arbeitsbereich> e)
    {
      this._arbeitsbereichVerwaltung.VorhandenenArbeitsbereichOeffnen(e.Value.Arbeitsverzeichnis);
      this.VorhandeneArbeitsbereicheAuflisten();
    }

    private void linkLabelNeuenArbeitsbereich_LinkClicked(
      object sender,
      LinkLabelLinkClickedEventArgs e)
    {
      if (this._arbeitsbereichVerwaltung == null)
        Debugger.GlobalDebugger.FehlerZeigen("_arbeitsbereichVerwaltung == null", (object) this, "GaitoBotEditor.Arbeitsbereiche.NeuenArbeitsbereichErstellenLinkLabel_LinkClicked");
      else
        this._arbeitsbereichVerwaltung.NeuenArbeitsbereichErstellenUndOeffnen();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Arbeitsbereiche));
      this.labelTitelArbeitsbereiche = new Label();
      this.linkLabelNeuenArbeitsbereich = new LinkLabel();
      this.panelArbeitsbereiche = new Panel();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.labelTitelArbeitsbereiche, "labelTitelArbeitsbereiche");
      this.labelTitelArbeitsbereiche.BackColor = Color.WhiteSmoke;
      this.labelTitelArbeitsbereiche.Name = "labelTitelArbeitsbereiche";
      componentResourceManager.ApplyResources((object) this.linkLabelNeuenArbeitsbereich, "linkLabelNeuenArbeitsbereich");
      this.linkLabelNeuenArbeitsbereich.BackColor = Color.AliceBlue;
      this.linkLabelNeuenArbeitsbereich.Name = "linkLabelNeuenArbeitsbereich";
      this.linkLabelNeuenArbeitsbereich.TabStop = true;
      this.linkLabelNeuenArbeitsbereich.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabelNeuenArbeitsbereich_LinkClicked);
      componentResourceManager.ApplyResources((object) this.panelArbeitsbereiche, "panelArbeitsbereiche");
      this.panelArbeitsbereiche.BackColor = Color.Transparent;
      this.panelArbeitsbereiche.Name = "panelArbeitsbereiche";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LightSteelBlue;
      this.Controls.Add((Control) this.panelArbeitsbereiche);
      this.Controls.Add((Control) this.linkLabelNeuenArbeitsbereich);
      this.Controls.Add((Control) this.labelTitelArbeitsbereiche);
      this.Name = nameof (Arbeitsbereiche);
      this.Load += new EventHandler(this.Arbeitsbereiche_Load);
      this.ResumeLayout(false);
    }
  }
}
