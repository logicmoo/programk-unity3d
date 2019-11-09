// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.controls.ucBotTest
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.gaitobot2;
using de.springwald.toolbox;
using GaitoBotEditorCore.Properties;
using MultiLang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace GaitoBotEditorCore.controls
{
  public class ucBotTest : UserControl
  {
    private IContainer components = (IContainer) null;
    private Arbeitsbereich _arbeitsbereich;
    private GaitoBotInterpreter _bot;
    private GaitoBotSession _session;
    private TextBox textBoxBenutzerEingabe;
    private Button buttonAbsenden;
    private ToolStrip toolStrip;
    private ToolStripButton toolStripButtonWissenNeuLaden;
    private ToolStripSeparator toolStripSeparatorBitteWarten;
    private ToolStripLabel toolStripLabelWissenWirdGeladen;
    private ToolStripProgressBar toolStripProgressBarWissenLaden;
    private WebBrowser webBrowserBotAusgabe;
    private ucBotDenkprotokoll ucBotDenkprotokoll;
    private ToolStripButton toolStripButtonLadeProtokollZeigen;
    private ToolStripButton toolStripButtonZeigeStart;
    private ToolStripSeparator toolStripSeparator1;

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Diesem BotTester wurde bereits ein Arbeitsbereich zugeordnet");
        this._arbeitsbereich = value;
        this._arbeitsbereich.WissenSpracheChanged += new EventHandler(this._arbeitsbereich_WissenSpracheChangedEvent);
        this._arbeitsbereich.UseOneWordSRAIChanged += new EventHandler(this._arbeitsbereich_UseOneWordSRAIChanged);
        this._arbeitsbereich.Dateiverwaltung.AimlDateienContentChanged += new EventHandler(this._arbeitsbereich_AIMLDateienContentChanged);
        this._arbeitsbereich.MetaInfosChangedEvent += new EventHandler(this._arbeitsbereich_MetaInfosChangedEvent);
        this.ucBotDenkprotokoll.Arbeitsbereich = this._arbeitsbereich;
      }
    }

    public ucBotTest()
    {
      this.InitializeComponent();
      this.SteuerelementeBeschriften();
      this.webBrowserBotAusgabe.WebBrowserShortcutsEnabled = false;
      this.webBrowserBotAusgabe.IsWebBrowserContextMenuEnabled = false;
      this.textBoxBenutzerEingabe.KeyDown += new KeyEventHandler(this.textBoxBenutzerEingabe_KeyDown);
      this.ucBotDenkprotokoll.CategoryAngewaehlt += new ucBotDenkprotokoll.CategoryAngewaehltEventHandler(this.ucBotDenkprotokoll1_CategoryAngewaehlt);
      this.BitteWartenZeigen(false);
      this.toolStripButtonLadeProtokollZeigen.Visible = false;
      this.Resize += new EventHandler(this.ucBotTest_Resize);
    }

    private void ucBotTest_Resize(object sender, EventArgs e)
    {
      this.webBrowserBotAusgabe.Height = this.buttonAbsenden.Top - this.webBrowserBotAusgabe.Top - 5;
      this.ucBotDenkprotokoll.Left = this.webBrowserBotAusgabe.Left + this.webBrowserBotAusgabe.Width + 5;
      this.ucBotDenkprotokoll.Top = this.toolStrip.Top + this.toolStrip.Height;
      this.ucBotDenkprotokoll.Width = this.ClientSize.Width - 5 - this.ucBotDenkprotokoll.Left;
      this.ucBotDenkprotokoll.Height = this.ClientSize.Height - this.ucBotDenkprotokoll.Top;
    }

    private void WissenLaden()
    {
      if (this._arbeitsbereich == null)
        return;
      this.Enabled = false;
      this.BitteWartenZeigen(true);
      Application.DoEvents();
      List<DomDocLadePaket> xmlDoms = new List<DomDocLadePaket>();
      StartupInfos startupInfos = new StartupInfos();
      foreach (IArbeitsbereichDatei datei in this._arbeitsbereich.Dateiverwaltung.Dateien)
      {
        if (!this._arbeitsbereich.DieseAIMLDateiNichtExportieren(datei))
        {
          if (datei is AIMLDatei)
          {
            DomDocLadePaket domDocLadePaket = new DomDocLadePaket(datei.XML, datei.Titel);
            xmlDoms.Add(domDocLadePaket);
          }
          else if (datei is StartupDatei)
            startupInfos.FuegeEintraegeAusStartupDateiHinzu(datei.XML);
        }
      }
      this.toolStripProgressBarWissenLaden.Value = 0;
      this.toolStripProgressBarWissenLaden.Maximum = xmlDoms.Count + 1;
      CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
      this._bot = new GaitoBotInterpreter(currentUiCulture, startupInfos);
      this._bot.AIMLDateiWirdGeladen += new GaitoBotInterpreter.AimlDateiWirdGeladenEventHandler(this._bot_AIMLDateiWirdGeladen);
      this._bot.LadenAusXMLDoms(xmlDoms);
      this._bot.AIMLDateiWirdGeladen -= new GaitoBotInterpreter.AimlDateiWirdGeladenEventHandler(this._bot_AIMLDateiWirdGeladen);
      this._session = new GaitoBotSession(currentUiCulture);
      this.BitteWartenZeigen(false);
      this.Enabled = true;
    }

    private void _bot_AIMLDateiWirdGeladen(
      object sender,
      GaitoBotInterpreter.AimlDateiWirdGeladenEventArgs e)
    {
      try
      {
        ++this.toolStripProgressBarWissenLaden.Value;
        this.toolStripLabelWissenWirdGeladen.Text = string.Format(GaitoBotEditorCore.ResReader.Reader.GetString("toolStripLabelWissenWirdGeladen"), (object) this.toolStripProgressBarWissenLaden.Value, (object) (this.toolStripProgressBarWissenLaden.Maximum - 1));
      }
      catch (Exception ex)
      {
      }
      Application.DoEvents();
    }

    private void SteuerelementeBeschriften()
    {
      this.toolStripButtonZeigeStart.Text = ml.ml_string(72, "Begrüßung");
      this.toolStripButtonZeigeStart.ToolTipText = ml.ml_string(72, "Begrüßung");
      this.toolStripButtonWissenNeuLaden.Text = GaitoBotEditorCore.ResReader.Reader.GetString("toolStripButtonWissenNeuLaden");
      this.buttonAbsenden.Text = GaitoBotEditorCore.ResReader.Reader.GetString("BotTestButtonAbsenden");
      this.toolStripButtonLadeProtokollZeigen.Text = GaitoBotEditorCore.ResReader.Reader.GetString("BotTestLadeProtokollZeigenButton");
    }

    private void toolStripButtonWissenNeuLaden_Click(object sender, EventArgs e)
    {
      this.WissenLaden();
      if (this.webBrowserBotAusgabe == null)
        return;
      this.BegruessungAnzeigen();
    }

    private void BenutzerEingabe(string eingabe)
    {
      if (this._bot == null)
        this.WissenLaden();
      this._session.DenkprotokollLeeren();
      this.webBrowserBotAusgabe.DocumentText = this._bot.GetAntwort(eingabe, this._session);
      this.ucBotDenkprotokoll.Denkprotokoll = this._session.Denkprotokoll;
      this.textBoxBenutzerEingabe.Text = "";
      this.textBoxBenutzerEingabe.Focus();
    }

    private void buttonAbsenden_Click(object sender, EventArgs e)
    {
      this.BenutzerEingabe(this.textBoxBenutzerEingabe.Text);
    }

    private void ucBotDenkprotokoll1_CategoryAngewaehlt(
      object sender,
      ucBotDenkprotokoll.CategoryAngewaehltEventArgs e)
    {
      XmlNode categoryNode = e.Category.CategoryNode;
      if (categoryNode == null)
        return;
      AIMLCategory categoryForCategoryNode = this._arbeitsbereich.GetCategoryForCategoryNode(categoryNode);
      if (categoryForCategoryNode != null)
        this._arbeitsbereich.Fokus.AktAIMLCategory = categoryForCategoryNode;
    }

    private void textBoxBenutzerEingabe_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyData != Keys.Return)
        return;
      this.BenutzerEingabe(this.textBoxBenutzerEingabe.Text);
    }

    private void BitteWartenZeigen(bool zeigen)
    {
      try
      {
        this.toolStripLabelWissenWirdGeladen.Visible = zeigen;
        this.toolStripProgressBarWissenLaden.Visible = zeigen;
        this.toolStripSeparatorBitteWarten.Visible = zeigen;
        this.toolStripButtonLadeProtokollZeigen.Visible = !zeigen;
      }
      catch (Exception ex)
      {
        if (ToolboxSonstiges.IstEntwicklungsmodus)
          throw new ApplicationException(ml.ml_string(69, "Wahrscheinlich wird das Programm gerade während des Ladens geschlossen?"));
      }
    }

    private void _arbeitsbereich_WissenSpracheChangedEvent(object sender, EventArgs e)
    {
      this._bot = (GaitoBotInterpreter) null;
      this.BegruessungAnzeigen();
    }

    private void BegruessungAnzeigen()
    {
      this.BenutzerEingabe("TARGET BOTSTART");
    }

    private void _arbeitsbereich_UseOneWordSRAIChanged(object sender, EventArgs e)
    {
      this._bot = (GaitoBotInterpreter) null;
    }

    private void _arbeitsbereich_AIMLDateienContentChanged(object sender, EventArgs e)
    {
      this._bot = (GaitoBotInterpreter) null;
    }

    private void _arbeitsbereich_MetaInfosChangedEvent(object sender, EventArgs e)
    {
      this._bot = (GaitoBotInterpreter) null;
    }

    private void toolStripButtonLadeProtokollZeigen_Click(object sender, EventArgs e)
    {
      if (this._bot == null)
        return;
      int num = (int) MessageBox.Show(this._bot.LadeProtokoll);
    }

    private void toolStripButtonZeigeStart_Click(object sender, EventArgs e)
    {
      this.BegruessungAnzeigen();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ucBotTest));
      this.textBoxBenutzerEingabe = new TextBox();
      this.buttonAbsenden = new Button();
      this.toolStrip = new ToolStrip();
      this.toolStripButtonZeigeStart = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripButtonWissenNeuLaden = new ToolStripButton();
      this.toolStripSeparatorBitteWarten = new ToolStripSeparator();
      this.toolStripLabelWissenWirdGeladen = new ToolStripLabel();
      this.toolStripProgressBarWissenLaden = new ToolStripProgressBar();
      this.toolStripButtonLadeProtokollZeigen = new ToolStripButton();
      this.webBrowserBotAusgabe = new WebBrowser();
      this.ucBotDenkprotokoll = new ucBotDenkprotokoll();
      this.toolStrip.SuspendLayout();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.textBoxBenutzerEingabe, "textBoxBenutzerEingabe");
      this.textBoxBenutzerEingabe.Name = "textBoxBenutzerEingabe";
      componentResourceManager.ApplyResources((object) this.buttonAbsenden, "buttonAbsenden");
      this.buttonAbsenden.Name = "buttonAbsenden";
      this.buttonAbsenden.UseVisualStyleBackColor = true;
      this.buttonAbsenden.Click += new EventHandler(this.buttonAbsenden_Click);
      this.toolStrip.Items.AddRange(new ToolStripItem[7]
      {
        (ToolStripItem) this.toolStripButtonZeigeStart,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripButtonWissenNeuLaden,
        (ToolStripItem) this.toolStripSeparatorBitteWarten,
        (ToolStripItem) this.toolStripLabelWissenWirdGeladen,
        (ToolStripItem) this.toolStripProgressBarWissenLaden,
        (ToolStripItem) this.toolStripButtonLadeProtokollZeigen
      });
      componentResourceManager.ApplyResources((object) this.toolStrip, "toolStrip");
      this.toolStrip.Name = "toolStrip";
      this.toolStripButtonZeigeStart.DisplayStyle = ToolStripItemDisplayStyle.Text;
      componentResourceManager.ApplyResources((object) this.toolStripButtonZeigeStart, "toolStripButtonZeigeStart");
      this.toolStripButtonZeigeStart.Name = "toolStripButtonZeigeStart";
      this.toolStripButtonZeigeStart.Click += new EventHandler(this.toolStripButtonZeigeStart_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator1, "toolStripSeparator1");
      this.toolStripButtonWissenNeuLaden.Image = (Image) Resources.undo_16;
      componentResourceManager.ApplyResources((object) this.toolStripButtonWissenNeuLaden, "toolStripButtonWissenNeuLaden");
      this.toolStripButtonWissenNeuLaden.Name = "toolStripButtonWissenNeuLaden";
      this.toolStripButtonWissenNeuLaden.Click += new EventHandler(this.toolStripButtonWissenNeuLaden_Click);
      this.toolStripSeparatorBitteWarten.Name = "toolStripSeparatorBitteWarten";
      componentResourceManager.ApplyResources((object) this.toolStripSeparatorBitteWarten, "toolStripSeparatorBitteWarten");
      this.toolStripLabelWissenWirdGeladen.Name = "toolStripLabelWissenWirdGeladen";
      componentResourceManager.ApplyResources((object) this.toolStripLabelWissenWirdGeladen, "toolStripLabelWissenWirdGeladen");
      this.toolStripProgressBarWissenLaden.Name = "toolStripProgressBarWissenLaden";
      componentResourceManager.ApplyResources((object) this.toolStripProgressBarWissenLaden, "toolStripProgressBarWissenLaden");
      this.toolStripButtonLadeProtokollZeigen.Image = (Image) Resources.documents_161;
      componentResourceManager.ApplyResources((object) this.toolStripButtonLadeProtokollZeigen, "toolStripButtonLadeProtokollZeigen");
      this.toolStripButtonLadeProtokollZeigen.Name = "toolStripButtonLadeProtokollZeigen";
      this.toolStripButtonLadeProtokollZeigen.Click += new EventHandler(this.toolStripButtonLadeProtokollZeigen_Click);
      componentResourceManager.ApplyResources((object) this.webBrowserBotAusgabe, "webBrowserBotAusgabe");
      this.webBrowserBotAusgabe.MinimumSize = new Size(20, 20);
      this.webBrowserBotAusgabe.Name = "webBrowserBotAusgabe";
      componentResourceManager.ApplyResources((object) this.ucBotDenkprotokoll, "ucBotDenkprotokoll");
      this.ucBotDenkprotokoll.Name = "ucBotDenkprotokoll";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.textBoxBenutzerEingabe);
      this.Controls.Add((Control) this.ucBotDenkprotokoll);
      this.Controls.Add((Control) this.toolStrip);
      this.Controls.Add((Control) this.buttonAbsenden);
      this.Controls.Add((Control) this.webBrowserBotAusgabe);
      this.Name = nameof (ucBotTest);
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
