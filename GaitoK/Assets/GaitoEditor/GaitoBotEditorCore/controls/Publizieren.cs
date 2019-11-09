// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.controls.Publizieren
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using GaitoBotEditorCore.Publizieren;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GaitoBotEditorCore.controls
{
  public class Publizieren : UserControl
  {
    private IContainer components = (IContainer) null;
    private Arbeitsbereich _arbeitsbereich;
    private string _protokollReverse;
    private Button buttonPublish;
    private TextBox textBoxGaitoBotID;
    private Label labelGaitoBotID;
    private LinkLabel linkLabelKeineBotID;
    private TextBox textBoxProtokoll;

    public Arbeitsbereich AktArbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Diesem PublizierungSteuerelement wurde bereits ein Arbeitsbereich zugeordnet");
        this._arbeitsbereich = value;
        this.Anzeigen();
      }
    }

    public Publizieren()
    {
      this.InitializeComponent();
      this.SteuerElementeBeschriften();
      this.textBoxProtokoll.Visible = false;
      this.Enabled = true;
    }

    private void SteuerElementeBeschriften()
    {
      this.labelGaitoBotID.Text = GaitoBotEditorCore.ResReader.Reader.GetString("PublizierenLabelGaitoBotID");
      this.buttonPublish.Text = GaitoBotEditorCore.ResReader.Reader.GetString("PublizierenbuttonPublish");
      this.linkLabelKeineBotID.Text = GaitoBotEditorCore.ResReader.Reader.GetString("PublizierenlinkLabelKeineBotID");
    }

    private void buttonPublish_Click(object sender, EventArgs e)
    {
      this.buttonPublish.Enabled = false;
      this.textBoxGaitoBotID.Enabled = false;
      this._protokollReverse = "";
      ArbeitsbereichPublizieren arbeitsbereichPublizieren = new ArbeitsbereichPublizieren(this._arbeitsbereich);
      arbeitsbereichPublizieren.PublizerEvent += new EventHandler<PublizierenEventArgs>(this.publizierer_PublizerEvent);
      arbeitsbereichPublizieren.Publizieren();
      switch (arbeitsbereichPublizieren.Ergebnis)
      {
        case ArbeitsbereichPublizieren.ergebnisse.erfolgreich:
        case ArbeitsbereichPublizieren.ergebnisse.fehlerhaft:
          arbeitsbereichPublizieren.PublizerEvent -= new EventHandler<PublizierenEventArgs>(this.publizierer_PublizerEvent);
          arbeitsbereichPublizieren.Dispose();
          this.buttonPublish.Enabled = true;
          this.textBoxGaitoBotID.Enabled = true;
          break;
        default:
          throw new ApplicationException("Unbehandeltes Publizierungsergebnis");
      }
    }

    private void Anzeigen()
    {
      this.textBoxGaitoBotID.Text = this._arbeitsbereich.GaitoBotID;
    }

    private void publizierer_PublizerEvent(object sender, PublizierenEventArgs e)
    {
      this.textBoxProtokoll.Visible = true;
      this._protokollReverse = string.Format("{0}\r\n{1}", (object) e.Meldung, (object) this._protokollReverse);
      this.textBoxProtokoll.Text = this._protokollReverse;
    }

    private void textBoxGaitoBotID_TextChanged(object sender, EventArgs e)
    {
      this._arbeitsbereich.GaitoBotID = this.textBoxGaitoBotID.Text;
    }

    private void linkLabelKeineBotID_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      ToolboxSonstiges.HTMLSeiteAufrufen(Config.GlobalConfig.URLNochKeineGaitoBotID);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (GaitoBotEditorCore.controls.Publizieren));
      this.buttonPublish = new Button();
      this.textBoxGaitoBotID = new TextBox();
      this.labelGaitoBotID = new Label();
      this.linkLabelKeineBotID = new LinkLabel();
      this.textBoxProtokoll = new TextBox();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.buttonPublish, "buttonPublish");
      this.buttonPublish.Name = "buttonPublish";
      this.buttonPublish.UseVisualStyleBackColor = true;
      this.buttonPublish.Click += new EventHandler(this.buttonPublish_Click);
      componentResourceManager.ApplyResources((object) this.textBoxGaitoBotID, "textBoxGaitoBotID");
      this.textBoxGaitoBotID.Name = "textBoxGaitoBotID";
      this.textBoxGaitoBotID.TextChanged += new EventHandler(this.textBoxGaitoBotID_TextChanged);
      componentResourceManager.ApplyResources((object) this.labelGaitoBotID, "labelGaitoBotID");
      this.labelGaitoBotID.Name = "labelGaitoBotID";
      componentResourceManager.ApplyResources((object) this.linkLabelKeineBotID, "linkLabelKeineBotID");
      this.linkLabelKeineBotID.Name = "linkLabelKeineBotID";
      this.linkLabelKeineBotID.TabStop = true;
      this.linkLabelKeineBotID.LinkClicked += new LinkLabelLinkClickedEventHandler(this.linkLabelKeineBotID_LinkClicked);
      componentResourceManager.ApplyResources((object) this.textBoxProtokoll, "textBoxProtokoll");
      this.textBoxProtokoll.Name = "textBoxProtokoll";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.textBoxProtokoll);
      this.Controls.Add((Control) this.linkLabelKeineBotID);
      this.Controls.Add((Control) this.labelGaitoBotID);
      this.Controls.Add((Control) this.textBoxGaitoBotID);
      this.Controls.Add((Control) this.buttonPublish);
      this.Name = nameof (Publizieren);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
