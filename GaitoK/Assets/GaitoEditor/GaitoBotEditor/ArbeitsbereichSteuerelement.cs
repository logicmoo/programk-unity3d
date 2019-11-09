// Decompiled with JetBrains decompiler
// Type: GaitoBotEditor.ArbeitsbereichSteuerelement
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using de.springwald.toolbox;
using de.springwald.xml;
using de.springwald.xml.editor;
using GaitoBotEditor.Properties;
using GaitoBotEditorCore;
using GaitoBotEditorCore.controls;
using MultiLang;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using TD.SandDock;
using TD.SandDock.Rendering;

namespace GaitoBotEditor
{
  public class ArbeitsbereichSteuerelement : UserControl
  {
    private bool _erstesResize = true;
    private IContainer components = (IContainer) null;
    private Arbeitsbereich _arbeitsbereich;
    private DockContainer dockContainerUntenSuchenTestEtc;
    private DockingRules dockingRules1;
    private ucCategoryXMLEditor ucXMLEditor;
    private DockableWindow dockWindowTestBot;
    private SandDockManager sandDockManager;
    private DocumentContainer documentContainerCategoryEdit;
    private TabbedDocument tabbedDocumentGrafischeAnsicht;
    private TabbedDocument tabbedDocumentAIMLQuellcode;
    private ucXMLQuellcodeDebugger ucXMLQuellcodeDebugger;
    private DockableWindow dockWindowAIMLDateiListe;
    private ucAIMLDateiListe ucProjektAIMLDateien;
    private DockableWindow dockWindowTopicListe;
    private ucTopicListe ucTopicListe;
    private DockContainer dockContainer1;
    private DockableWindow dockWindowCategoryListe;
    private ucCategoryListe ucCategoryListe;
    private DockContainer dockContainer3;
    private DockableWindow dockWindowXMLInsertElement;
    private DockableWindow dockWindowEditXMLAttribute;
    private ucXMLEditAttributes ucXMLEditAttributes;
    private DockContainer dockContainer6;
    private ucXMLToolbar ucXMLToolbar;
    private DockableWindow dockWindowSuchen;
    private ucArbeitsbereichToolbar ucArbeitsbereichToolbar;
    private Suchen SuchSteuerelement;
    private DockableWindow dockableWindowExport;
    private Export ExportArbeitsbereich;
    private ucBotTest ucBotTest;
    private DockableWindow dockableWindowWorkflow;
    private ucWorkflowToolbar ucWorkflowToolbar;
    private DockableWindow dockableWindowMostSRAIS;
    private ucMeisteSRAIs ucBesteSRAIZiele;
    private ucXMLAddElement2 ucXMLAddElement;
    private ucWorkflowScrollbox ucWorkflowScrollbox;
    private DockableWindow dockableWindowPublish;
    private Publizieren PubliziereArbeitsbereich;

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Diesem ArbeitsbereichSteuerelement wurde bereits ein Arbeitsbereich zugewiesen");
        this._arbeitsbereich = value;
        this.ucWorkflowToolbar.Arbeitsbereich = this._arbeitsbereich;
        this.ucWorkflowScrollbox.Arbeitsbereich = this._arbeitsbereich;
        this.ucXMLEditor.Arbeitsbereich = this._arbeitsbereich;
        this.ucCategoryListe.Arbeitsbereich = this._arbeitsbereich;
        this.ucTopicListe.Arbeitsbereich = this._arbeitsbereich;
        this.ucProjektAIMLDateien.Arbeitsbereich = this._arbeitsbereich;
        this.ucArbeitsbereichToolbar.Arbeitsbereich = this._arbeitsbereich;
        this.ucBesteSRAIZiele.Arbeitsbereich = this._arbeitsbereich;
        this.SuchSteuerelement.Arbeitsbereich = this._arbeitsbereich;
        this.ExportArbeitsbereich.Arbeitsbereich = this._arbeitsbereich;
        this.PubliziereArbeitsbereich.AktArbeitsbereich = this._arbeitsbereich;
        this.ucBotTest.Arbeitsbereich = this._arbeitsbereich;
        this._arbeitsbereich.SucheImArbeitsbereich += new Arbeitsbereich.SucheImArbeitsbereichEventHandler(this._arbeitsbereich_SucheImArbeitsbereich);
        this.Cursor = Cursors.Default;
        if (value.ContentElementUniqueIds.Length == 0)
        {
          int num = (int) new GaitoBotEditorCore.ContentHinzulinken.ContentHinzulinken(value).ShowDialog();
        }
        else
          this._arbeitsbereich.Dateiverwaltung.VordefinierteDateienHinzulinken(this._arbeitsbereich);
        if (this._arbeitsbereich.Dateiverwaltung.AlleAimlDateien.SelectMany((Func<AIMLDatei, IEnumerable<AIMLTopic>>) (a => (IEnumerable<AIMLTopic>) a.getTopics()), 
            (a, t) => new{ a = a, t = t }).SelectMany(_param1 => (IEnumerable<AIMLCategory>) _param1.t.Categories, (_param1, c) => new{ //
            u003Cu003Eh__TransparentIdentifier0 = _param1, c = c }
            //
            ).Where(_param1 => _param1.c.Pattern == "TARGET BOTSTART").Select(_param1 => _param1.c).Any<AIMLCategory>())
          return;
        AIMLDatei aimlDatei = this._arbeitsbereich.Dateiverwaltung.AddAimlLeereDatei(this._arbeitsbereich, true);
        if (aimlDatei != null)
          aimlDatei.MitTargetBotStartFuellen();
      }
    }

    public ArbeitsbereichSteuerelement()
    {
      this.InitializeComponent();
      this.Load += new EventHandler(this.ProjektSteuerelement_Load);
    }

    private void ProjektSteuerelement_Load(object sender, EventArgs e)
    {
      this.sandDockManager.Renderer = (RendererBase) new Office2003Renderer();
      this.SteuerElementeVerheiraten();
      this.ElementeBenennen();
      this.dockWindowTestBot.Collapsed = true;
      this.dockWindowSuchen.Collapsed = true;
      this.dockableWindowPublish.Collapsed = true;
      this.dockableWindowWorkflow.Collapsed = false;
      this.dockWindowTestBot.Collapsed = false;
      this.Resize += new EventHandler(this.ArbeitsbereichSteuerelement_Resize);
      this.dockableWindowWorkflow.Resize += new EventHandler(this.dockableWindowWorkflow_Resize);
      foreach (Control control in (ArrangedElementCollection) this.Controls)
      {
        if (control.Name == "dockContainerUntenSuchenTestEtc")
          control.Height = ToolboxSonstiges.IstEntwicklungsmodus ? 400 : 300;
      }
    }

    private void ArbeitsbereichSteuerelement_Resize(object sender, EventArgs e)
    {
      if (this._erstesResize)
      {
        this._erstesResize = false;
        if (this.Height > 800)
        {
          this.dockableWindowWorkflow.Collapsed = false;
          this.dockWindowTestBot.Collapsed = false;
        }
        else
        {
          this.dockableWindowWorkflow.Collapsed = true;
          this.dockWindowTestBot.Collapsed = true;
        }
      }
      this.dockContainerUntenSuchenTestEtc.Height = Math.Max(200, Math.Min(400, (int) ((double) this.Height * 0.3)));
    }

    private void _arbeitsbereich_SucheImArbeitsbereich(
      object sender,
      Arbeitsbereich.SucheImArbeitsbereichEventArgs e)
    {
      this.dockWindowSuchen.Open();
    }

    private void SteuerElementeVerheiraten()
    {
      this.ucXMLAddElement.XMLEditor = this.ucXMLEditor.XmlEditor;
      this.ucXMLEditAttributes.XMLEditor = this.ucXMLEditor.XmlEditor;
      this.ucXMLQuellcodeDebugger.XMLEditor = this.ucXMLEditor.XmlEditor;
      this.ucXMLToolbar.XMLEditor = this.ucXMLEditor.XmlEditor;
      this.SuchSteuerelement.SuchTitelChanged += new Suchen.SuchTitelChangedEventHandler(this.SuchSteuerelement_SuchTitelChanged);
      this.ucArbeitsbereichToolbar.ExportAnzeigen += new EventHandler(this.ucArbeitsbereichToolbar_ExportAnzeigen);
      this.ucArbeitsbereichToolbar.ManuellenTestAnzeigen += new EventHandler(this.ucArbeitsbereichToolbar_ManuellenTestAnzeigen);
      this.ucArbeitsbereichToolbar.PublizierenAnzeigen += new EventHandler(this.ucArbeitsbereichToolbar_PublizierenAnzeigen);
      this.ucWorkflowToolbar.SyncCategoryAngewaehlt += new ucWorkflowToolbar.SyncCategoryAngewaehltEventHandler(this.ucWorkflowToolbar_SyncCategoryAngewaehlt);
      this.ucWorkflowToolbar.AnzeigeRefreshen += new EventHandler(this.ucWorkflowToolbar_AnzeigeRefreshen);
    }

    private void SuchSteuerelement_SuchTitelChanged(
      object sender,
      Suchen.SuchTitelChangedEventArgs e)
    {
      this.dockWindowSuchen.Text = e.Titel;
    }

    private void ucArbeitsbereichToolbar_ExportAnzeigen(object sender, EventArgs e)
    {
      this.dockableWindowExport.Open();
    }

    private void ucArbeitsbereichToolbar_PublizierenAnzeigen(object sender, EventArgs e)
    {
      this.dockableWindowPublish.Open();
    }

    private void ucArbeitsbereichToolbar_ManuellenTestAnzeigen(object sender, EventArgs e)
    {
      this.dockWindowTestBot.Open();
    }

    private void ElementeBenennen()
    {
      this.Text = string.Format(ml.ml_string(58, "GaitoBot AIML Editor V {0} - {1}"), (object) ("" + Assembly.GetExecutingAssembly().GetName().Version.Major.ToString() + "." + Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString()), (object) "");
    }

    private void tabbedDocumentGrafischeAnsicht_Resize(object sender, EventArgs e)
    {
      this.ucXMLEditor.Left = 0;
      this.ucXMLEditor.Top = this.ucXMLToolbar.Top + this.ucXMLToolbar.Height;
      this.ucXMLEditor.Width = this.tabbedDocumentGrafischeAnsicht.ClientSize.Width;
      this.ucXMLEditor.Height = this.tabbedDocumentGrafischeAnsicht.ClientSize.Height - this.ucXMLEditor.Top;
    }

    private void dockableWindowWorkflow_Resize(object sender, EventArgs e)
    {
      this.ucWorkflowScrollbox.Left = 0;
      this.ucWorkflowScrollbox.Top = this.ucWorkflowToolbar.Top + this.ucWorkflowToolbar.Height;
      this.ucWorkflowScrollbox.Width = this.dockableWindowWorkflow.ClientSize.Width;
      this.ucWorkflowScrollbox.Height = this.dockableWindowWorkflow.ClientSize.Height - this.ucWorkflowScrollbox.Top;
    }

    private void ucWorkflowToolbar_SyncCategoryAngewaehlt(
      object sender,
      ucWorkflowToolbar.SyncCategoryAngewaehltEventArgs e)
    {
      this.ucWorkflowScrollbox.Category = e.Category;
    }

    private void ucWorkflowToolbar_AnzeigeRefreshen(object sender, EventArgs e)
    {
      this.ucWorkflowScrollbox.RefreshAnzeige();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ArbeitsbereichSteuerelement));
      DockingRules dockingRules = new DockingRules();
      this.dockWindowTestBot = new DockableWindow();
      this.ucBotTest = new ucBotTest();
      this.dockWindowSuchen = new DockableWindow();
      this.SuchSteuerelement = new Suchen();
      this.dockableWindowExport = new DockableWindow();
      this.ExportArbeitsbereich = new Export();
      this.dockableWindowPublish = new DockableWindow();
      this.PubliziereArbeitsbereich = new Publizieren();
      this.dockableWindowWorkflow = new DockableWindow();
      this.ucWorkflowToolbar = new ucWorkflowToolbar();
      this.ucWorkflowScrollbox = new ucWorkflowScrollbox();
      this.dockableWindowMostSRAIS = new DockableWindow();
      this.ucBesteSRAIZiele = new ucMeisteSRAIs();
      this.sandDockManager = new SandDockManager();
      this.dockWindowAIMLDateiListe = new DockableWindow();
      this.ucProjektAIMLDateien = new ucAIMLDateiListe();
      this.dockWindowTopicListe = new DockableWindow();
      this.ucTopicListe = new ucTopicListe();
      this.tabbedDocumentGrafischeAnsicht = new TabbedDocument();
      this.ucXMLToolbar = new ucXMLToolbar();
      this.ucXMLEditor = new ucCategoryXMLEditor();
      this.documentContainerCategoryEdit = new DocumentContainer();
      this.tabbedDocumentAIMLQuellcode = new TabbedDocument();
      this.ucXMLQuellcodeDebugger = new ucXMLQuellcodeDebugger();
      this.dockWindowCategoryListe = new DockableWindow();
      this.ucCategoryListe = new ucCategoryListe();
      this.dockContainer1 = new DockContainer();
      this.dockContainer3 = new DockContainer();
      this.dockWindowXMLInsertElement = new DockableWindow();
      this.ucXMLAddElement = new ucXMLAddElement2();
      this.dockWindowEditXMLAttribute = new DockableWindow();
      this.ucXMLEditAttributes = new ucXMLEditAttributes();
      this.dockContainer6 = new DockContainer();
      this.ucArbeitsbereichToolbar = new ucArbeitsbereichToolbar();
      this.dockContainerUntenSuchenTestEtc = new DockContainer();
      this.dockWindowTestBot.SuspendLayout();
      this.dockWindowSuchen.SuspendLayout();
      this.dockableWindowExport.SuspendLayout();
      this.dockableWindowPublish.SuspendLayout();
      this.dockableWindowWorkflow.SuspendLayout();
      this.dockableWindowMostSRAIS.SuspendLayout();
      this.dockWindowAIMLDateiListe.SuspendLayout();
      this.dockWindowTopicListe.SuspendLayout();
      this.tabbedDocumentGrafischeAnsicht.SuspendLayout();
      this.documentContainerCategoryEdit.SuspendLayout();
      this.tabbedDocumentAIMLQuellcode.SuspendLayout();
      this.dockWindowCategoryListe.SuspendLayout();
      this.dockContainer1.SuspendLayout();
      this.dockContainer3.SuspendLayout();
      this.dockWindowXMLInsertElement.SuspendLayout();
      this.dockWindowEditXMLAttribute.SuspendLayout();
      this.dockContainer6.SuspendLayout();
      this.dockContainerUntenSuchenTestEtc.SuspendLayout();
      this.SuspendLayout();
      this.dockWindowTestBot.AllowClose = false;
      this.dockWindowTestBot.Controls.Add((Control) this.ucBotTest);
      this.dockWindowTestBot.FloatingSize = new System.Drawing.Size(250, 116);
      this.dockWindowTestBot.Guid = new Guid("b5e67ccb-f99b-4e45-8e8b-53afe1c26699");
      componentResourceManager.ApplyResources((object) this.dockWindowTestBot, "dockWindowTestBot");
      this.dockWindowTestBot.Name = "dockWindowTestBot";
      this.dockWindowTestBot.ShowOptions = false;
      this.dockWindowTestBot.TabImage = (Image) Resources.applications_16;
      componentResourceManager.ApplyResources((object) this.ucBotTest, "ucBotTest");
      this.ucBotTest.Name = "ucBotTest";
      this.dockWindowSuchen.AllowClose = false;
      this.dockWindowSuchen.Controls.Add((Control) this.SuchSteuerelement);
      dockingRules.AllowDockBottom = true;
      dockingRules.AllowDockLeft = true;
      dockingRules.AllowDockRight = true;
      dockingRules.AllowDockTop = true;
      dockingRules.AllowFloat = false;
      dockingRules.AllowTab = false;
      this.dockWindowSuchen.DockingRules = dockingRules;
      this.dockWindowSuchen.FloatingSize = new System.Drawing.Size(450, 400);
      this.dockWindowSuchen.Guid = new Guid("c2581e6a-d96f-49c2-a2b9-a7b4cd022403");
      componentResourceManager.ApplyResources((object) this.dockWindowSuchen, "dockWindowSuchen");
      this.dockWindowSuchen.Name = "dockWindowSuchen";
      this.dockWindowSuchen.ShowOptions = false;
      this.dockWindowSuchen.TabImage = (Image) Resources.BINOCULR;
      componentResourceManager.ApplyResources((object) this.SuchSteuerelement, "SuchSteuerelement");
      this.SuchSteuerelement.Name = "SuchSteuerelement";
      this.SuchSteuerelement.Titel = "No search started.: 0 hit(s)";
      this.dockableWindowExport.AllowClose = false;
      this.dockableWindowExport.Controls.Add((Control) this.ExportArbeitsbereich);
      this.dockableWindowExport.Cursor = Cursors.Default;
      this.dockableWindowExport.Guid = new Guid("4b077e64-38cc-4b5e-a99f-da9b2730f692");
      componentResourceManager.ApplyResources((object) this.dockableWindowExport, "dockableWindowExport");
      this.dockableWindowExport.Name = "dockableWindowExport";
      this.dockableWindowExport.ShowOptions = false;
      this.dockableWindowExport.TabImage = (Image) Resources.redo_16;
      componentResourceManager.ApplyResources((object) this.ExportArbeitsbereich, "ExportArbeitsbereich");
      this.ExportArbeitsbereich.Name = "ExportArbeitsbereich";
      this.dockableWindowPublish.AllowClose = false;
      this.dockableWindowPublish.Controls.Add((Control) this.PubliziereArbeitsbereich);
      this.dockableWindowPublish.Guid = new Guid("cf60f5be-8603-4733-9032-662b0d05c24d");
      componentResourceManager.ApplyResources((object) this.dockableWindowPublish, "dockableWindowPublish");
      this.dockableWindowPublish.Name = "dockableWindowPublish";
      this.dockableWindowPublish.ShowOptions = false;
      this.dockableWindowPublish.TabImage = (Image) Resources.Globe;
      componentResourceManager.ApplyResources((object) this.PubliziereArbeitsbereich, "PubliziereArbeitsbereich");
      this.PubliziereArbeitsbereich.Name = "PubliziereArbeitsbereich";
      this.dockableWindowWorkflow.AllowClose = false;
      this.dockableWindowWorkflow.Controls.Add((Control) this.ucWorkflowToolbar);
      this.dockableWindowWorkflow.Controls.Add((Control) this.ucWorkflowScrollbox);
      this.dockableWindowWorkflow.Guid = new Guid("50ef7a81-ad45-4994-881e-e423baee0104");
      componentResourceManager.ApplyResources((object) this.dockableWindowWorkflow, "dockableWindowWorkflow");
      this.dockableWindowWorkflow.Name = "dockableWindowWorkflow";
      this.dockableWindowWorkflow.ShowOptions = false;
      this.dockableWindowWorkflow.TabImage = (Image) Resources.GRAPH14;
      componentResourceManager.ApplyResources((object) this.ucWorkflowToolbar, "ucWorkflowToolbar");
      this.ucWorkflowToolbar.Name = "ucWorkflowToolbar";
      componentResourceManager.ApplyResources((object) this.ucWorkflowScrollbox, "ucWorkflowScrollbox");
      this.ucWorkflowScrollbox.BackColor = Color.White;
      this.ucWorkflowScrollbox.Category = (AIMLCategory) null;
      this.ucWorkflowScrollbox.Name = "ucWorkflowScrollbox";
      this.dockableWindowMostSRAIS.AllowClose = false;
      this.dockableWindowMostSRAIS.Controls.Add((Control) this.ucBesteSRAIZiele);
      this.dockableWindowMostSRAIS.Guid = new Guid("668e99cf-2422-41cf-9838-70d0007347a7");
      componentResourceManager.ApplyResources((object) this.dockableWindowMostSRAIS, "dockableWindowMostSRAIS");
      this.dockableWindowMostSRAIS.Name = "dockableWindowMostSRAIS";
      this.dockableWindowMostSRAIS.ShowOptions = false;
      componentResourceManager.ApplyResources((object) this.ucBesteSRAIZiele, "ucBesteSRAIZiele");
      this.ucBesteSRAIZiele.Name = "ucBesteSRAIZiele";
      this.sandDockManager.DockSystemContainer = (Control) this;
      this.sandDockManager.OwnerForm = (Form) null;
      this.dockWindowAIMLDateiListe.AllowClose = false;
      this.dockWindowAIMLDateiListe.Controls.Add((Control) this.ucProjektAIMLDateien);
      this.dockWindowAIMLDateiListe.Guid = new Guid("51cde5d8-7920-4b1a-86aa-f14518ee0e47");
      componentResourceManager.ApplyResources((object) this.dockWindowAIMLDateiListe, "dockWindowAIMLDateiListe");
      this.dockWindowAIMLDateiListe.Name = "dockWindowAIMLDateiListe";
      this.dockWindowAIMLDateiListe.ShowOptions = false;
      this.ucProjektAIMLDateien.BackColor = SystemColors.Control;
      componentResourceManager.ApplyResources((object) this.ucProjektAIMLDateien, "ucProjektAIMLDateien");
      this.ucProjektAIMLDateien.Name = "ucProjektAIMLDateien";
      this.dockWindowTopicListe.AllowClose = false;
      this.dockWindowTopicListe.Controls.Add((Control) this.ucTopicListe);
      this.dockWindowTopicListe.Guid = new Guid("ea5081bf-2f8a-4752-b387-ec19f8831882");
      componentResourceManager.ApplyResources((object) this.dockWindowTopicListe, "dockWindowTopicListe");
      this.dockWindowTopicListe.Name = "dockWindowTopicListe";
      this.dockWindowTopicListe.ShowOptions = false;
      componentResourceManager.ApplyResources((object) this.ucTopicListe, "ucTopicListe");
      this.ucTopicListe.Name = "ucTopicListe";
      this.tabbedDocumentGrafischeAnsicht.AllowClose = false;
      this.tabbedDocumentGrafischeAnsicht.BackColor = Color.White;
      this.tabbedDocumentGrafischeAnsicht.Controls.Add((Control) this.ucXMLToolbar);
      this.tabbedDocumentGrafischeAnsicht.Controls.Add((Control) this.ucXMLEditor);
      this.tabbedDocumentGrafischeAnsicht.FloatingSize = new System.Drawing.Size(550, 400);
      this.tabbedDocumentGrafischeAnsicht.Guid = new Guid("dd4dda3d-4da1-4a08-8187-813737830be1");
      componentResourceManager.ApplyResources((object) this.tabbedDocumentGrafischeAnsicht, "tabbedDocumentGrafischeAnsicht");
      this.tabbedDocumentGrafischeAnsicht.Name = "tabbedDocumentGrafischeAnsicht";
      this.tabbedDocumentGrafischeAnsicht.Resize += new EventHandler(this.tabbedDocumentGrafischeAnsicht_Resize);
      componentResourceManager.ApplyResources((object) this.ucXMLToolbar, "ucXMLToolbar");
      this.ucXMLToolbar.Name = "ucXMLToolbar";
      componentResourceManager.ApplyResources((object) this.ucXMLEditor, "ucXMLEditor");
      this.ucXMLEditor.BackColor = Color.White;
      this.ucXMLEditor.ForeColor = SystemColors.Control;
      this.ucXMLEditor.Name = "ucXMLEditor";
      this.documentContainerCategoryEdit.ContentSize = 400;
      this.documentContainerCategoryEdit.Controls.Add((Control) this.tabbedDocumentGrafischeAnsicht);
      this.documentContainerCategoryEdit.Controls.Add((Control) this.tabbedDocumentAIMLQuellcode);
      this.documentContainerCategoryEdit.LayoutSystem = new SplitLayoutSystem(new SizeF(250f, 400f), Orientation.Horizontal, new LayoutSystemBase[1]
      {
        (LayoutSystemBase) new DocumentLayoutSystem(new SizeF(281f, 150f), new DockControl[2]
        {
          (DockControl) this.tabbedDocumentGrafischeAnsicht,
          (DockControl) this.tabbedDocumentAIMLQuellcode
        }, (DockControl) this.tabbedDocumentGrafischeAnsicht)
      });
      componentResourceManager.ApplyResources((object) this.documentContainerCategoryEdit, "documentContainerCategoryEdit");
      this.documentContainerCategoryEdit.Manager = this.sandDockManager;
      this.documentContainerCategoryEdit.Name = "documentContainerCategoryEdit";
      this.tabbedDocumentAIMLQuellcode.AllowClose = false;
      this.tabbedDocumentAIMLQuellcode.BackColor = Color.White;
      this.tabbedDocumentAIMLQuellcode.Controls.Add((Control) this.ucXMLQuellcodeDebugger);
      this.tabbedDocumentAIMLQuellcode.FloatingSize = new System.Drawing.Size(550, 400);
      this.tabbedDocumentAIMLQuellcode.Guid = new Guid("ee004c2a-1eda-45f3-aa57-bfd00714eb65");
      componentResourceManager.ApplyResources((object) this.tabbedDocumentAIMLQuellcode, "tabbedDocumentAIMLQuellcode");
      this.tabbedDocumentAIMLQuellcode.Name = "tabbedDocumentAIMLQuellcode";
      this.ucXMLQuellcodeDebugger.BackColor = SystemColors.Control;
      componentResourceManager.ApplyResources((object) this.ucXMLQuellcodeDebugger, "ucXMLQuellcodeDebugger");
      this.ucXMLQuellcodeDebugger.Name = "ucXMLQuellcodeDebugger";
      this.dockWindowCategoryListe.AllowClose = false;
      this.dockWindowCategoryListe.Controls.Add((Control) this.ucCategoryListe);
      this.dockWindowCategoryListe.Guid = new Guid("71593c02-4597-41dc-8df3-eff7d26bacc2");
      componentResourceManager.ApplyResources((object) this.dockWindowCategoryListe, "dockWindowCategoryListe");
      this.dockWindowCategoryListe.Name = "dockWindowCategoryListe";
      this.dockWindowCategoryListe.ShowOptions = false;
      componentResourceManager.ApplyResources((object) this.ucCategoryListe, "ucCategoryListe");
      this.ucCategoryListe.Name = "ucCategoryListe";
      this.dockContainer1.ContentSize = 400;
      this.dockContainer1.Controls.Add((Control) this.dockWindowCategoryListe);
      componentResourceManager.ApplyResources((object) this.dockContainer1, "dockContainer1");
      this.dockContainer1.LayoutSystem = new SplitLayoutSystem(new SizeF(250f, 400f), Orientation.Vertical, new LayoutSystemBase[1]
      {
        (LayoutSystemBase) new ControlLayoutSystem(new SizeF(283f, 272f), new DockControl[1]
        {
          (DockControl) this.dockWindowCategoryListe
        }, (DockControl) this.dockWindowCategoryListe)
      });
      this.dockContainer1.Manager = this.sandDockManager;
      this.dockContainer1.Name = "dockContainer1";
      this.dockContainer3.ContentSize = 250;
      this.dockContainer3.Controls.Add((Control) this.dockWindowXMLInsertElement);
      this.dockContainer3.Controls.Add((Control) this.dockWindowEditXMLAttribute);
      componentResourceManager.ApplyResources((object) this.dockContainer3, "dockContainer3");
      this.dockContainer3.LayoutSystem = new SplitLayoutSystem(new SizeF(250f, 400f), Orientation.Horizontal, new LayoutSystemBase[2]
      {
        (LayoutSystemBase) new ControlLayoutSystem(new SizeF(164f, 311f), new DockControl[1]
        {
          (DockControl) this.dockWindowXMLInsertElement
        }, (DockControl) this.dockWindowXMLInsertElement),
        (LayoutSystemBase) new ControlLayoutSystem(new SizeF(164f, 114f), new DockControl[1]
        {
          (DockControl) this.dockWindowEditXMLAttribute
        }, (DockControl) this.dockWindowEditXMLAttribute)
      });
      this.dockContainer3.Manager = this.sandDockManager;
      this.dockContainer3.Name = "dockContainer3";
      this.dockWindowXMLInsertElement.AllowClose = false;
      this.dockWindowXMLInsertElement.Controls.Add((Control) this.ucXMLAddElement);
      this.dockWindowXMLInsertElement.Guid = new Guid("537d1bfb-ec52-421e-844c-230c301c3825");
      componentResourceManager.ApplyResources((object) this.dockWindowXMLInsertElement, "dockWindowXMLInsertElement");
      this.dockWindowXMLInsertElement.Name = "dockWindowXMLInsertElement";
      this.dockWindowXMLInsertElement.ShowOptions = false;
      componentResourceManager.ApplyResources((object) this.ucXMLAddElement, "ucXMLAddElement");
      this.ucXMLAddElement.Name = "ucXMLAddElement";
      this.dockWindowEditXMLAttribute.AllowClose = false;
      this.dockWindowEditXMLAttribute.Controls.Add((Control) this.ucXMLEditAttributes);
      this.dockWindowEditXMLAttribute.Guid = new Guid("89e6e7ee-6ca5-4907-a2aa-fd2748ae354e");
      componentResourceManager.ApplyResources((object) this.dockWindowEditXMLAttribute, "dockWindowEditXMLAttribute");
      this.dockWindowEditXMLAttribute.Name = "dockWindowEditXMLAttribute";
      this.dockWindowEditXMLAttribute.ShowOptions = false;
      componentResourceManager.ApplyResources((object) this.ucXMLEditAttributes, "ucXMLEditAttributes");
      this.ucXMLEditAttributes.Name = "ucXMLEditAttributes";
      this.dockContainer6.ContentSize = 250;
      this.dockContainer6.Controls.Add((Control) this.dockWindowAIMLDateiListe);
      this.dockContainer6.Controls.Add((Control) this.dockWindowTopicListe);
      componentResourceManager.ApplyResources((object) this.dockContainer6, "dockContainer6");
      this.dockContainer6.LayoutSystem = new SplitLayoutSystem(new SizeF(250f, 400f), Orientation.Horizontal, new LayoutSystemBase[2]
      {
        (LayoutSystemBase) new ControlLayoutSystem(new SizeF(225f, 280f), new DockControl[1]
        {
          (DockControl) this.dockWindowAIMLDateiListe
        }, (DockControl) this.dockWindowAIMLDateiListe),
        (LayoutSystemBase) new ControlLayoutSystem(new SizeF(225f, 145f), new DockControl[1]
        {
          (DockControl) this.dockWindowTopicListe
        }, (DockControl) this.dockWindowTopicListe)
      });
      this.dockContainer6.Manager = this.sandDockManager;
      this.dockContainer6.Name = "dockContainer6";
      componentResourceManager.ApplyResources((object) this.ucArbeitsbereichToolbar, "ucArbeitsbereichToolbar");
      this.ucArbeitsbereichToolbar.Name = "ucArbeitsbereichToolbar";
      this.dockContainerUntenSuchenTestEtc.ContentSize = 176;
      this.dockContainerUntenSuchenTestEtc.Controls.Add((Control) this.dockWindowTestBot);
      this.dockContainerUntenSuchenTestEtc.Controls.Add((Control) this.dockWindowSuchen);
      this.dockContainerUntenSuchenTestEtc.Controls.Add((Control) this.dockableWindowExport);
      this.dockContainerUntenSuchenTestEtc.Controls.Add((Control) this.dockableWindowPublish);
      this.dockContainerUntenSuchenTestEtc.Controls.Add((Control) this.dockableWindowWorkflow);
      this.dockContainerUntenSuchenTestEtc.Controls.Add((Control) this.dockableWindowMostSRAIS);
      componentResourceManager.ApplyResources((object) this.dockContainerUntenSuchenTestEtc, "dockContainerUntenSuchenTestEtc");
      this.dockContainerUntenSuchenTestEtc.LayoutSystem = new SplitLayoutSystem(new SizeF(250f, 400f), Orientation.Vertical, new LayoutSystemBase[2]
      {
        (LayoutSystemBase) new ControlLayoutSystem(new SizeF(309.3716f, 100f), new DockControl[4]
        {
          (DockControl) this.dockWindowTestBot,
          (DockControl) this.dockWindowSuchen,
          (DockControl) this.dockableWindowExport,
          (DockControl) this.dockableWindowPublish
        }, (DockControl) this.dockWindowTestBot),
        (LayoutSystemBase) new ControlLayoutSystem(new SizeF(366.6284f, 100f), new DockControl[2]
        {
          (DockControl) this.dockableWindowWorkflow,
          (DockControl) this.dockableWindowMostSRAIS
        }, (DockControl) this.dockableWindowWorkflow)
      });
      this.dockContainerUntenSuchenTestEtc.Manager = this.sandDockManager;
      this.dockContainerUntenSuchenTestEtc.Name = "dockContainerUntenSuchenTestEtc";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.documentContainerCategoryEdit);
      this.Controls.Add((Control) this.dockContainer1);
      this.Controls.Add((Control) this.dockContainer3);
      this.Controls.Add((Control) this.dockContainer6);
      this.Controls.Add((Control) this.ucArbeitsbereichToolbar);
      this.Controls.Add((Control) this.dockContainerUntenSuchenTestEtc);
      this.Cursor = Cursors.WaitCursor;
      this.Name = nameof (ArbeitsbereichSteuerelement);
      this.dockWindowTestBot.ResumeLayout(false);
      this.dockWindowSuchen.ResumeLayout(false);
      this.dockableWindowExport.ResumeLayout(false);
      this.dockableWindowPublish.ResumeLayout(false);
      this.dockableWindowWorkflow.ResumeLayout(false);
      this.dockableWindowMostSRAIS.ResumeLayout(false);
      this.dockWindowAIMLDateiListe.ResumeLayout(false);
      this.dockWindowTopicListe.ResumeLayout(false);
      this.tabbedDocumentGrafischeAnsicht.ResumeLayout(false);
      this.documentContainerCategoryEdit.ResumeLayout(false);
      this.tabbedDocumentAIMLQuellcode.ResumeLayout(false);
      this.dockWindowCategoryListe.ResumeLayout(false);
      this.dockContainer1.ResumeLayout(false);
      this.dockContainer3.ResumeLayout(false);
      this.dockWindowXMLInsertElement.ResumeLayout(false);
      this.dockWindowEditXMLAttribute.ResumeLayout(false);
      this.dockContainer6.ResumeLayout(false);
      this.dockContainerUntenSuchenTestEtc.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
