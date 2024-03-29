﻿// Decompiled with JetBrains decompiler
// Type: GaitoBotEditor.frmMain
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using de.springwald.toolbox;
using GaitoBotEditorCore;
using MultiLang;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TD.SandDock;

namespace GaitoBotEditor
{
  public class frmMain : Form
  {
    private SandDockManager sandDockManager;
    private MainMenu mainMenu;
    private MenuItem mnuProgramm;
    private MenuItem mnuProgrammBeenden;
    private MenuItem mnuAnsicht;
    private MenuItem mnuDebugger;
    private MenuItem mnuHilfe;
    private MenuItem mnuHandbuch;
    private MenuItem mnuHomepage;
    private MenuItem menuItem3;
    private MenuItem mnuInfo;
    private DocumentContainer documentContainer;
    private TabbedDocument tabbedDocumentStartseite;
    private DockContainer dockContainer1;
    private DockableWindow dockableWindowDebug;
    private TextBox txtDebuggerAusgabe;
    private IContainer components;
    private Startseite startseite;
    private ArbeitsbereichVerwaltung _arbeitsbereichVerwaltung;
    private frmAbout _aboutForm;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmMain));
      this.sandDockManager = new SandDockManager();
      this.mainMenu = new MainMenu(this.components);
      this.mnuProgramm = new MenuItem();
      this.mnuProgrammBeenden = new MenuItem();
      this.mnuAnsicht = new MenuItem();
      this.mnuDebugger = new MenuItem();
      this.mnuHilfe = new MenuItem();
      this.mnuHandbuch = new MenuItem();
      this.mnuHomepage = new MenuItem();
      this.menuItem3 = new MenuItem();
      this.mnuInfo = new MenuItem();
      this.tabbedDocumentStartseite = new TabbedDocument();
      this.startseite = new Startseite();
      this.documentContainer = new DocumentContainer();
      this.dockableWindowDebug = new DockableWindow();
      this.txtDebuggerAusgabe = new TextBox();
      this.dockContainer1 = new DockContainer();
      this.tabbedDocumentStartseite.SuspendLayout();
      this.documentContainer.SuspendLayout();
      this.dockableWindowDebug.SuspendLayout();
      this.dockContainer1.SuspendLayout();
      this.SuspendLayout();
      this.sandDockManager.DockSystemContainer = (Control) this;
      this.sandDockManager.OwnerForm = (Form) this;
      this.mainMenu.MenuItems.AddRange(new MenuItem[3]
      {
        this.mnuProgramm,
        this.mnuAnsicht,
        this.mnuHilfe
      });
      this.mnuProgramm.Index = 0;
      this.mnuProgramm.MenuItems.AddRange(new MenuItem[1]
      {
        this.mnuProgrammBeenden
      });
      componentResourceManager.ApplyResources((object) this.mnuProgramm, "mnuProgramm");
      this.mnuProgrammBeenden.Index = 0;
      componentResourceManager.ApplyResources((object) this.mnuProgrammBeenden, "mnuProgrammBeenden");
      this.mnuProgrammBeenden.Click += new EventHandler(this.mnuProgrammBeenden_Click);
      this.mnuAnsicht.Index = 1;
      this.mnuAnsicht.MenuItems.AddRange(new MenuItem[1]
      {
        this.mnuDebugger
      });
      componentResourceManager.ApplyResources((object) this.mnuAnsicht, "mnuAnsicht");
      this.mnuDebugger.Index = 0;
      componentResourceManager.ApplyResources((object) this.mnuDebugger, "mnuDebugger");
      this.mnuDebugger.Click += new EventHandler(this.mnuDebugger_Click_1);
      this.mnuHilfe.Index = 2;
      this.mnuHilfe.MenuItems.AddRange(new MenuItem[4]
      {
        this.mnuHandbuch,
        this.mnuHomepage,
        this.menuItem3,
        this.mnuInfo
      });
      componentResourceManager.ApplyResources((object) this.mnuHilfe, "mnuHilfe");
      this.mnuHandbuch.Index = 0;
      componentResourceManager.ApplyResources((object) this.mnuHandbuch, "mnuHandbuch");
      this.mnuHandbuch.Click += new EventHandler(this.mnuHandbuch_Click);
      this.mnuHomepage.Index = 1;
      componentResourceManager.ApplyResources((object) this.mnuHomepage, "mnuHomepage");
      this.mnuHomepage.Click += new EventHandler(this.mnuHomepage_Click);
      this.menuItem3.Index = 2;
      componentResourceManager.ApplyResources((object) this.menuItem3, "menuItem3");
      this.mnuInfo.Index = 3;
      componentResourceManager.ApplyResources((object) this.mnuInfo, "mnuInfo");
      this.mnuInfo.Click += new EventHandler(this.mnuInfo_Click);
      this.tabbedDocumentStartseite.AllowClose = false;
      this.tabbedDocumentStartseite.AllowCollapse = false;
      this.tabbedDocumentStartseite.Controls.Add((Control) this.startseite);
      this.tabbedDocumentStartseite.FloatingSize = new System.Drawing.Size(550, 400);
      this.tabbedDocumentStartseite.Guid = new Guid("9ee7f539-b109-4417-80cb-02aa6c3c738d");
      componentResourceManager.ApplyResources((object) this.tabbedDocumentStartseite, "tabbedDocumentStartseite");
      this.tabbedDocumentStartseite.Name = "tabbedDocumentStartseite";
      this.tabbedDocumentStartseite.ShowOptions = false;
      this.startseite.BackColor = Color.FromArgb(192, 192, (int) byte.MaxValue);
      componentResourceManager.ApplyResources((object) this.startseite, "startseite");
      this.startseite.Name = "startseite";
      this.documentContainer.ContentSize = 400;
      this.documentContainer.Controls.Add((Control) this.tabbedDocumentStartseite);
      this.documentContainer.LayoutSystem = new SplitLayoutSystem(new SizeF(250f, 400f), Orientation.Horizontal, new LayoutSystemBase[1]
      {
        (LayoutSystemBase) new DocumentLayoutSystem(new SizeF(763f, 388f), new DockControl[1]
        {
          (DockControl) this.tabbedDocumentStartseite
        }, (DockControl) this.tabbedDocumentStartseite)
      });
      componentResourceManager.ApplyResources((object) this.documentContainer, "documentContainer");
      this.documentContainer.Manager = this.sandDockManager;
      this.documentContainer.Name = "documentContainer";
      this.dockableWindowDebug.Controls.Add((Control) this.txtDebuggerAusgabe);
      this.dockableWindowDebug.Guid = new Guid("8098dec4-2a99-4d25-86aa-a35f31fa49d6");
      componentResourceManager.ApplyResources((object) this.dockableWindowDebug, "dockableWindowDebug");
      this.dockableWindowDebug.Name = "dockableWindowDebug";
      this.txtDebuggerAusgabe.AcceptsReturn = true;
      this.txtDebuggerAusgabe.AcceptsTab = true;
      this.txtDebuggerAusgabe.BorderStyle = BorderStyle.None;
      this.txtDebuggerAusgabe.Cursor = Cursors.IBeam;
      componentResourceManager.ApplyResources((object) this.txtDebuggerAusgabe, "txtDebuggerAusgabe");
      this.txtDebuggerAusgabe.Name = "txtDebuggerAusgabe";
      this.dockContainer1.ContentSize = 400;
      this.dockContainer1.Controls.Add((Control) this.dockableWindowDebug);
      componentResourceManager.ApplyResources((object) this.dockContainer1, "dockContainer1");
      this.dockContainer1.LayoutSystem = new SplitLayoutSystem(new SizeF(250f, 400f), Orientation.Vertical, new LayoutSystemBase[1]
      {
        (LayoutSystemBase) new ControlLayoutSystem(new SizeF(765f, (float) sbyte.MaxValue), new DockControl[1]
        {
          (DockControl) this.dockableWindowDebug
        }, (DockControl) this.dockableWindowDebug)
      });
      this.dockContainer1.Manager = this.sandDockManager;
      this.dockContainer1.Name = "dockContainer1";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.BackColor = Color.DodgerBlue;
      this.Controls.Add((Control) this.documentContainer);
      this.Controls.Add((Control) this.dockContainer1);
      this.Menu = this.mainMenu;
      this.Name = nameof (frmMain);
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.frmMain_Load);
      this.tabbedDocumentStartseite.ResumeLayout(false);
      this.documentContainer.ResumeLayout(false);
      this.dockableWindowDebug.ResumeLayout(false);
      this.dockableWindowDebug.PerformLayout();
      this.dockContainer1.ResumeLayout(false);
      this.ResumeLayout(false);
    }

    public frmMain()
    {
      if (Config.GlobalConfig.ProgrammSprache == "")
        Config.GlobalConfig.ProgrammSprache = "en";
      Thread.CurrentThread.CurrentUICulture = new CultureInfo(Config.GlobalConfig.ProgrammSprache);
      this.InitializeComponent();
      this.FormClosing += new FormClosingEventHandler(this.frmMain_FormClosing);
    }

    private void frmMain_Load(object sender, EventArgs e)
    {
      this.ProgrammTitelUndVorgangTitelAnzeigen(ml.ml_string(59, "laed"));
      if (this.LizenzChecken())
      {
        if (!ToolboxSonstiges.IstEntwicklungsmodus)
        {
          new frmSplashScreen().Show();
          Application.DoEvents();
        }
        this.dockableWindowDebug.Close();
        this.tabbedDocumentStartseite.Enter += new EventHandler(this.tabbedDocumentStartseite_Enter);
        Debugger.GlobalDebugger.NeueProtokollZeileEvent += new DebuggerNeueZeileEventHandler(this.GlobalDebugger_NeueProtokollZeileEvent);
        this.txtDebuggerAusgabe.Text = "";
        Debugger.GlobalDebugger.SetzeProtokollDateiname(Config.GlobalConfig.SpeicherVerzeichnis + "\\debuglog.txt", true);
        this.ProgrammTitelUndVorgangTitelAnzeigen();
        this._arbeitsbereichVerwaltung = new ArbeitsbereichVerwaltung();
        this._arbeitsbereichVerwaltung.ArbeitsbereichAddedEvent += new EventHandler<EventArgs<Arbeitsbereich>>(this._arbeitsbereichVerwaltung_ArbeitsbereichAddedEvent);
        this.startseite.ArbeitsbereichVerwaltung = this._arbeitsbereichVerwaltung;
        if (!ToolboxSonstiges.IstEntwicklungsmodus)
          return;
        this._arbeitsbereichVerwaltung.VorhandenenArbeitsbereichOeffnen(Path.Combine(Config.GlobalConfig.ArbeitsbereicheSpeicherVerzeichnis, "1"));
      }
      else
      {
        this.Close();
        this.Dispose();
      }
    }

    private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      bool cancel = false;
      if (this._arbeitsbereichVerwaltung != null)
        this._arbeitsbereichVerwaltung.ProgrammSollBeendetWerden(out cancel);
      if (!cancel)
        return;
      e.Cancel = true;
    }

    private bool LizenzChecken()
    {
      if (LizenzManager.DarfProgrammUeberhauptGestartetWerden)
      {
        this.Visible = false;
        if (!frmMain.EULAOk())
          return false;
        this.Visible = true;
        return true;
      }
      this.Visible = false;
      int num = (int) MessageBox.Show(LizenzManager.WarumDarfProgrammNichtGestartetWerden, Application.ProductName + " " + Application.ProductVersion, MessageBoxButtons.OK);
      return false;
    }

    private static bool EULAOk()
    {
      if (ToolboxSonstiges.IstEntwicklungsmodus)
        return true;
      string productVersion = Application.ProductVersion;
      if (Config.GlobalConfig.EULABestaetigtFuer == productVersion)
        return true;
      EULA eula = new EULA();
      eula.Show();
      Application.DoEvents();
      while (eula.Visible)
        Application.DoEvents();
      eula.DarfSchliessen = true;
      if (eula.Bestaetigt)
      {
        Config.GlobalConfig.EULABestaetigtFuer = productVersion;
        eula.Close();
        return true;
      }
      eula.Close();
      return false;
    }

    private void _arbeitsbereichVerwaltung_ArbeitsbereichAddedEvent(
      object sender,
      EventArgs<Arbeitsbereich> e)
    {
      ArbeitsbereichSteuerelement arbeitsbereichSteuerelement = new ArbeitsbereichSteuerelement();
      TabbedDocument tabbedDocument = new TabbedDocument(this.sandDockManager, (Control) arbeitsbereichSteuerelement, ml.ml_string(60, "es wird geladen..."));
      tabbedDocument.Enter += new EventHandler(this._ArbeitsbereichFenster_Enter);
      arbeitsbereichSteuerelement.Visible = false;
      tabbedDocument.Open();
      tabbedDocument.Show();
      tabbedDocument.AllowClose = true;
      tabbedDocument.Closing += new DockControlClosingEventHandler(this._ArbeitsbereichFenster_Closing);
      tabbedDocument.Cursor = Cursors.WaitCursor;
      Arbeitsbereich arbeitsbereich = e.Value;
      tabbedDocument.Tag = (object) arbeitsbereich;
      arbeitsbereich.Dateiverwaltung.AimlDateiWirdGeladenEvent += new EventHandler<EventArgs<string>>(this.Dateiverwaltung_AimlDateiWirdGeladenEvent);
      arbeitsbereich.Oeffnen();
      arbeitsbereich.NameChangedEvent += new EventHandler(this.arbeitsbereich_NameChangedEvent);
      arbeitsbereichSteuerelement.Visible = true;
      arbeitsbereichSteuerelement.Arbeitsbereich = arbeitsbereich;
      Application.DoEvents();
      this.arbeitsbereich_NameChangedEvent((object) null, (EventArgs) null);
      this.ProgrammTitelUndVorgangTitelAnzeigen();
      tabbedDocument.Cursor = Cursors.Default;
    }

    private void arbeitsbereich_NameChangedEvent(object sender, EventArgs e)
    {
      foreach (TabbedDocument document in this.sandDockManager.Documents)
      {
        if (document.Tag != null && document.Tag is Arbeitsbereich)
        {
          Arbeitsbereich tag = (Arbeitsbereich) document.Tag;
          document.Text = string.Format(ml.ml_string(62, "Arbeitsbereich \"{0}\""), (object) tag.Name);
        }
      }
    }

    private void _ArbeitsbereichFenster_Closing(object sender, DockControlClosingEventArgs e)
    {
      if (e.DockControl.Tag == null)
        return;
      Arbeitsbereich tag = (Arbeitsbereich) e.DockControl.Tag;
      bool cancel;
      tag.ArbeitsbereichSollGeschlossenWerden(out cancel);
      if (cancel)
      {
        e.Cancel = true;
      }
      else
      {
        tag.NameChangedEvent -= new EventHandler(this.arbeitsbereich_NameChangedEvent);
        this._arbeitsbereichVerwaltung.ArbeitsbereichEntfernen(tag);
      }
    }

    private void _ArbeitsbereichFenster_Enter(object sender, EventArgs e)
    {
      this.ProgrammTitelUndVorgangTitelAnzeigen();
    }

    private void Dateiverwaltung_AimlDateiWirdGeladenEvent(object sender, EventArgs<string> e)
    {
      string str = e.Value;
      try
      {
        string[] strArray = str.Split('\\');
        str = strArray[strArray.Length - 1];
      }
      catch (Exception ex)
      {
      }
      this.ProgrammTitelUndVorgangTitelAnzeigen(string.Format(ml.ml_string(63, "Öffne Datei {0}"), (object) str));
      Debugger.GlobalDebugger.Protokolliere(string.Format(ml.ml_string(63, "Öffne Datei {0}"), (object) e.Value));
      Application.DoEvents();
    }

    private void mnuDebugger_Click_1(object sender, EventArgs e)
    {
      this.dockableWindowDebug.Open();
    }

    private void GlobalDebugger_NeueProtokollZeileEvent(
      object sender,
      DebuggerNeueZeileEventArgs ae)
    {
      this.txtDebuggerAusgabe.Text = string.Format("{0}\r\n{1}", (object) ae._inhalt, (object) this.txtDebuggerAusgabe.Text);
      if (this.txtDebuggerAusgabe.Text.Length > 2000)
        this.txtDebuggerAusgabe.Text = this.txtDebuggerAusgabe.Text.Substring(0, 1500);
      Application.DoEvents();
    }

    private void mnuProgrammBeenden_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    private void mnuInfo_Click(object sender, EventArgs e)
    {
      if (this._aboutForm != null)
      {
        if (!this._aboutForm.Visible)
        {
          this._aboutForm.Dispose();
          this._aboutForm = (frmAbout) null;
        }
        else
        {
          this._aboutForm.Show();
          this._aboutForm.BringToFront();
        }
      }
      if (this._aboutForm != null)
        return;
      this._aboutForm = new frmAbout();
      this._aboutForm.Show();
    }

    private void mnuHandbuch_Click(object sender, EventArgs e)
    {
      ToolboxSonstiges.HTMLSeiteAufrufen(Config.GlobalConfig.URLHandbuch);
    }

    private void mnuHomepage_Click(object sender, EventArgs e)
    {
      ToolboxSonstiges.HTMLSeiteAufrufen(ml.ml_string(54, "http://www.gaitobot.de"));
    }

    private void tabbedDocumentStartseite_Enter(object sender, EventArgs e)
    {
      this.ProgrammTitelUndVorgangTitelAnzeigen();
    }

    private void ProgrammTitelUndVorgangTitelAnzeigen(string vorgangTitel)
    {
      this.Text = string.Format(ml.ml_string(58, "GaitoBot AIML Editor V {0} - {1}"), (object) LizenzManager.ProgrammVersionNummerAnzeige, (object) vorgangTitel);
    }

    private void ProgrammTitelUndVorgangTitelAnzeigen()
    {
      if (this.documentContainer.ActiveControl != null)
        this.ProgrammTitelUndVorgangTitelAnzeigen(this.documentContainer.ActiveControl.Text);
      else
        this.ProgrammTitelUndVorgangTitelAnzeigen("");
    }
  }
}
