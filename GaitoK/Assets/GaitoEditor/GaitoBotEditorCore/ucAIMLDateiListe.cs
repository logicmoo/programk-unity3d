// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.ucAIMLDateiListe
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using GaitoBotEditorCore.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GaitoBotEditorCore
{
  public class ucAIMLDateiListe : UserControl
  {
    private Timer tmrRefresh;
    private MenuItem mnuSave;
    private ToolStrip toolStrip1;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton toolStripButtonOpenFile;
    private ToolStripButton toolStripButtonDelete;
    private ToolStripButton toolStripButtonSave;
    private OpenFileDialog openFileDialog;
    private ToolStripButton toolStripButtonFehlerZeigen;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton toolStripButtonAIMLDateiUmbenennen;
    private TreeView treeViewDateien;
    private ToolStripDropDownButton toolStripButtonNewFile;
    private ToolStripMenuItem newAimlFileToolStripMenuItem;
    private ToolStripMenuItem newReplaceConfigFileToolStripMenuItem;
    private ToolStripButton toolStripButtonHinzugelinkteDateienWaehlen;
    private ImageList imageListDateien;
    private IContainer components;
    private bool _wirdGeradeNeuGezeichnet;
    private Arbeitsbereich _arbeitsbereich;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ucAIMLDateiListe));
      this.tmrRefresh = new Timer(this.components);
      this.mnuSave = new MenuItem();
      this.toolStrip1 = new ToolStrip();
      this.toolStripButtonSave = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripButtonOpenFile = new ToolStripButton();
      this.toolStripButtonNewFile = new ToolStripDropDownButton();
      this.newAimlFileToolStripMenuItem = new ToolStripMenuItem();
      this.newReplaceConfigFileToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripButtonDelete = new ToolStripButton();
      this.toolStripButtonAIMLDateiUmbenennen = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripButtonFehlerZeigen = new ToolStripButton();
      this.toolStripButtonHinzugelinkteDateienWaehlen = new ToolStripButton();
      this.openFileDialog = new OpenFileDialog();
      this.treeViewDateien = new TreeView();
      this.imageListDateien = new ImageList(this.components);
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      this.tmrRefresh.Interval = 2000;
      this.mnuSave.Index = -1;
      this.mnuSave.Text = MultiLang._75;
      this.toolStrip1.Items.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.toolStripButtonSave,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripButtonOpenFile,
        (ToolStripItem) this.toolStripButtonNewFile,
        (ToolStripItem) this.toolStripButtonDelete,
        (ToolStripItem) this.toolStripButtonAIMLDateiUmbenennen,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripButtonFehlerZeigen,
        (ToolStripItem) this.toolStripButtonHinzugelinkteDateienWaehlen
      });
      componentResourceManager.ApplyResources((object) this.toolStrip1, "toolStrip1");
      this.toolStrip1.Name = "toolStrip1";
      this.toolStripButtonSave.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonSave.Image = (Image) Resources.save_16;
      componentResourceManager.ApplyResources((object) this.toolStripButtonSave, "toolStripButtonSave");
      this.toolStripButtonSave.Name = "toolStripButtonSave";
      this.toolStripButtonSave.Click += new EventHandler(this.toolStripButtonSave_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator1, "toolStripSeparator1");
      this.toolStripButtonOpenFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonOpenFile.Image = (Image) Resources.folder_open_16;
      componentResourceManager.ApplyResources((object) this.toolStripButtonOpenFile, "toolStripButtonOpenFile");
      this.toolStripButtonOpenFile.Name = "toolStripButtonOpenFile";
      this.toolStripButtonOpenFile.Click += new EventHandler(this.toolStripButtonOpenFile_Click);
      this.toolStripButtonNewFile.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonNewFile.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.newAimlFileToolStripMenuItem,
        (ToolStripItem) this.newReplaceConfigFileToolStripMenuItem
      });
      this.toolStripButtonNewFile.Image = (Image) Resources.add_161;
      componentResourceManager.ApplyResources((object) this.toolStripButtonNewFile, "toolStripButtonNewFile");
      this.toolStripButtonNewFile.Name = "toolStripButtonNewFile";
      this.newAimlFileToolStripMenuItem.Name = "newAimlFileToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.newAimlFileToolStripMenuItem, "newAimlFileToolStripMenuItem");
      this.newAimlFileToolStripMenuItem.Click += new EventHandler(this.newAimlFileToolStripMenuItem_Click);
      this.newReplaceConfigFileToolStripMenuItem.Name = "newReplaceConfigFileToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.newReplaceConfigFileToolStripMenuItem, "newReplaceConfigFileToolStripMenuItem");
      this.newReplaceConfigFileToolStripMenuItem.Click += new EventHandler(this.newStartupDateiToolStripMenuItem_Click);
      this.toolStripButtonDelete.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonDelete.Image = (Image) Resources.delete_161;
      componentResourceManager.ApplyResources((object) this.toolStripButtonDelete, "toolStripButtonDelete");
      this.toolStripButtonDelete.Name = "toolStripButtonDelete";
      this.toolStripButtonDelete.Click += new EventHandler(this.toolStripButtonDelete_Click);
      this.toolStripButtonAIMLDateiUmbenennen.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonAIMLDateiUmbenennen.Image = (Image) Resources.rename1;
      componentResourceManager.ApplyResources((object) this.toolStripButtonAIMLDateiUmbenennen, "toolStripButtonAIMLDateiUmbenennen");
      this.toolStripButtonAIMLDateiUmbenennen.Name = "toolStripButtonAIMLDateiUmbenennen";
      this.toolStripButtonAIMLDateiUmbenennen.Click += new EventHandler(this.toolStripButtonUmbenennen_Click);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator2, "toolStripSeparator2");
      this.toolStripButtonFehlerZeigen.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonFehlerZeigen.Image = (Image) Resources.W95MBX03;
      componentResourceManager.ApplyResources((object) this.toolStripButtonFehlerZeigen, "toolStripButtonFehlerZeigen");
      this.toolStripButtonFehlerZeigen.Name = "toolStripButtonFehlerZeigen";
      this.toolStripButtonFehlerZeigen.Click += new EventHandler(this.toolStripButtonFehlerZeigen_Click);
      this.toolStripButtonHinzugelinkteDateienWaehlen.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonHinzugelinkteDateienWaehlen.Image = (Image) Resources.App;
      componentResourceManager.ApplyResources((object) this.toolStripButtonHinzugelinkteDateienWaehlen, "toolStripButtonHinzugelinkteDateienWaehlen");
      this.toolStripButtonHinzugelinkteDateienWaehlen.Name = "toolStripButtonHinzugelinkteDateienWaehlen";
      this.toolStripButtonHinzugelinkteDateienWaehlen.Click += new EventHandler(this.toolStripButtonHinzugelinkteDateienWaehlen_Click);
      this.openFileDialog.FileName = "openFileDialog";
      componentResourceManager.ApplyResources((object) this.treeViewDateien, "treeViewDateien");
      this.treeViewDateien.ImageList = this.imageListDateien;
      this.treeViewDateien.Name = "treeViewDateien";
      this.imageListDateien.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageListDateien.ImageStream");
      this.imageListDateien.TransparentColor = Color.Transparent;
      this.imageListDateien.Images.SetKeyName(0, "aiml");
      this.imageListDateien.Images.SetKeyName(1, "startup");
      this.imageListDateien.Images.SetKeyName(2, "paket");
      this.BackColor = SystemColors.Control;
      this.Controls.Add((Control) this.treeViewDateien);
      this.Controls.Add((Control) this.toolStrip1);
      this.Name = nameof (ucAIMLDateiListe);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Load += new EventHandler(this.uAIMLDateiListe_Load);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private IArbeitsbereichDatei AktuelleDatei
    {
      get
      {
        if (this._arbeitsbereich == null)
          throw new ApplicationException("Noch kein Arbeitsbereich zugewiesen!");
        return this._arbeitsbereich.Fokus.AktDatei;
      }
      set
      {
        if (this._arbeitsbereich == null)
          throw new ApplicationException("Noch kein Arbeitsbereich zugewiesen!");
        this._arbeitsbereich.Fokus.AktDatei = value;
      }
    }

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Dieser AIMLDateiListe wurde bereits ein Arbeitsbereich zugeordnet");
        this._arbeitsbereich = value;
        this._arbeitsbereich.Fokus.AktDateiChanged += new ArbeitsbereichFokus.AktDateiChangedEventHandler(this.Fokus_AktAIMLDateiChanged);
        this._arbeitsbereich.Dateiverwaltung.DateiAddedEvent += new EventHandler<EventArgs<IArbeitsbereichDatei>>(this.Dateiverwaltung_AimlDateiAddedEvent);
        this._arbeitsbereich.Dateiverwaltung.DateiRemovedEvent += new EventHandler<EventArgs<IArbeitsbereichDatei>>(this.Dateiverwaltung_AimlDateiRemovedEvent);
        this.AIMLDateienNeuAnzeigen(true);
        this.ErsteDateiSelektieren();
        this.tmrRefresh.Tick += new EventHandler(this.tmrRefresh_Tick);
        this.tmrRefresh.Enabled = true;
      }
      private get
      {
        return this._arbeitsbereich;
      }
    }

    public ucAIMLDateiListe()
    {
      this.InitializeComponent();
      this.treeViewDateien.FullRowSelect = true;
      this.treeViewDateien.HideSelection = false;
      this.Resize += new EventHandler(this.uAIMLDateiListe_Resize);
    }

    private void uAIMLDateiListe_Load(object sender, EventArgs e)
    {
      this.SteuerElementeBenennen();
      this.treeViewDateien.AfterSelect += new TreeViewEventHandler(this.treeViewDateien_AfterSelect);
      this.treeViewDateien.AllowDrop = true;
      this.treeViewDateien.DragEnter += new DragEventHandler(this.DateiListenAnzeige_DragEnter);
      this.treeViewDateien.DragOver += new DragEventHandler(this.DateiListenAnzeige_DragEnter);
      this.treeViewDateien.DragDrop += new DragEventHandler(this.DateiListenAnzeige_DragDrop);
    }

    private void Dateiverwaltung_AimlDateiRemovedEvent(
      object sender,
      EventArgs<IArbeitsbereichDatei> e)
    {
      this.AIMLDateienNeuAnzeigen(true);
    }

    private void Dateiverwaltung_AimlDateiAddedEvent(
      object sender,
      EventArgs<IArbeitsbereichDatei> e)
    {
      this.AIMLDateienNeuAnzeigen(true);
    }

    private void DateiListenAnzeige_DragDrop(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(typeof (AIMLCategory)))
      {
        AIMLCategory data = (AIMLCategory) e.Data.GetData(typeof (AIMLCategory));
        if (data == null)
          return;
        IArbeitsbereichDatei arbeitsbereichDatei = this.DateiUnterPos(new Point(e.X, e.Y));
        if (arbeitsbereichDatei != null && !arbeitsbereichDatei.ReadOnly)
        {
          if (arbeitsbereichDatei != data.AIMLTopic.AIMLDatei)
          {
            if (arbeitsbereichDatei is AIMLDatei)
            {
              ((AIMLDatei) arbeitsbereichDatei).RootTopic.AddNewCategory().ContentNode.InnerXml = data.ContentNode.InnerXml;
              e.Effect = DragDropEffects.Move;
            }
          }
          else
            e.Effect = DragDropEffects.None;
        }
        else
          e.Effect = DragDropEffects.None;
      }
      else if (e.Data.GetDataPresent(typeof (AIMLTopic)))
      {
        AIMLTopic data = (AIMLTopic) e.Data.GetData(typeof (AIMLTopic));
        if (data == null)
          return;
        IArbeitsbereichDatei arbeitsbereichDatei = this.DateiUnterPos(new Point(e.X, e.Y));
        if (arbeitsbereichDatei != null && !arbeitsbereichDatei.ReadOnly)
        {
          if (arbeitsbereichDatei != data.AIMLDatei)
          {
            if (arbeitsbereichDatei is AIMLDatei)
            {
              AIMLTopic aimlTopic = ((AIMLDatei) arbeitsbereichDatei).AddNewTopic();
              aimlTopic.TopicNode.InnerXml = data.TopicNode.InnerXml;
              aimlTopic.Name = data.Name;
              e.Effect = DragDropEffects.Move;
            }
          }
          else
            e.Effect = DragDropEffects.None;
        }
        else
          e.Effect = DragDropEffects.None;
      }
      else
        e.Effect = DragDropEffects.None;
    }

    private void DateiListenAnzeige_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(typeof (AIMLTopic)))
      {
        AIMLTopic data = (AIMLTopic) e.Data.GetData(typeof (AIMLTopic));
        if (data != null)
        {
          IArbeitsbereichDatei arbeitsbereichDatei = this.DateiUnterPos(new Point(e.X, e.Y));
          if (arbeitsbereichDatei != null && !arbeitsbereichDatei.ReadOnly)
          {
            if (arbeitsbereichDatei != data.AIMLDatei)
              e.Effect = DragDropEffects.Move;
            else
              e.Effect = DragDropEffects.None;
          }
          else
            e.Effect = DragDropEffects.None;
        }
        else
          e.Effect = DragDropEffects.None;
      }
      else if (e.Data.GetDataPresent(typeof (AIMLCategory)))
      {
        AIMLCategory data = (AIMLCategory) e.Data.GetData(typeof (AIMLCategory));
        if (data != null)
        {
          IArbeitsbereichDatei arbeitsbereichDatei = this.DateiUnterPos(new Point(e.X, e.Y));
          if (arbeitsbereichDatei != null && !arbeitsbereichDatei.ReadOnly)
          {
            if (arbeitsbereichDatei != data.AIMLTopic.AIMLDatei)
              e.Effect = DragDropEffects.Move;
            else
              e.Effect = DragDropEffects.None;
          }
          else
            e.Effect = DragDropEffects.None;
        }
        else
          e.Effect = DragDropEffects.None;
      }
      else
        e.Effect = DragDropEffects.None;
    }

    private void Fokus_AktAIMLDateiChanged(object sender, EventArgs<IArbeitsbereichDatei> e)
    {
      this.AIMLDateienNeuAnzeigen(false);
    }

    private void treeViewDateien_AfterSelect(object sender, TreeViewEventArgs e)
    {
      if (this._wirdGeradeNeuGezeichnet)
        return;
      TreeNode selectedNode = this.treeViewDateien.SelectedNode;
      if (selectedNode == null)
        this.AktuelleDatei = (IArbeitsbereichDatei) null;
      else
        this.AktuelleDatei = selectedNode.Tag == null ? (IArbeitsbereichDatei) null : (IArbeitsbereichDatei) selectedNode.Tag;
    }

    private void toolStripButtonSave_Click(object sender, EventArgs e)
    {
      this.Save();
    }

    private void toolStripButtonOpenFile_Click(object sender, EventArgs e)
    {
      this.openFileDialog.FileName = "";
      this.openFileDialog.Multiselect = false;
      this.openFileDialog.AddExtension = false;
      this.openFileDialog.CheckFileExists = true;
      this.openFileDialog.CheckPathExists = true;
      this.openFileDialog.DefaultExt = "aiml";
      this.openFileDialog.Filter = "aiml files (*.aiml)|*.aiml|xml files (*.xml)|*.xml|startup files (*.startup)|*.startup";
      this.openFileDialog.Title = ResReader.Reader.GetString("BitteAIMLDateiWaehlen");
      int num = (int) this.openFileDialog.ShowDialog();
      string fileName = this.openFileDialog.FileName;
      if (string.IsNullOrEmpty(fileName))
        return;
      string lower = fileName.ToLower();
      if (lower.EndsWith(".aiml") || lower.EndsWith(".xml"))
        this.VorhandeneAIMLDateiHinzufuegen(fileName, true);
      else if (lower.EndsWith(".startup"))
        this.VorhandeneStartupDateiHinzufuegen(fileName, true);
    }

    private void VorhandeneStartupDateiHinzufuegen(string dateiname, bool dateiAlsChangedMarkieren)
    {
      if (!File.Exists(dateiname))
        return;
      try
      {
        StartupDatei startupDatei = this._arbeitsbereich.Dateiverwaltung.VorhandeneExterneStartupDateiImportieren(dateiname, this._arbeitsbereich);
        this.AktuelleDatei = (IArbeitsbereichDatei) startupDatei;
        if (dateiAlsChangedMarkieren && startupDatei != null)
          startupDatei.IsChanged = true;
        this.AIMLDateienNeuAnzeigen(true);
      }
      catch (AIMLDatei.AIMLDateiNichtGeladenException ex)
      {
        Debugger.GlobalDebugger.FehlerZeigen(string.Format(ResReader.Reader.GetString("AIMLDateiLadeFehler"), (object) dateiname, (object) ex.Message), (object) this, "LadeDatei");
      }
    }

    private void VorhandeneAIMLDateiHinzufuegen(string dateiname, bool dateiAlsChangedMarkieren)
    {
      if (!File.Exists(dateiname))
        return;
      try
      {
        AIMLDatei aimlDatei = this._arbeitsbereich.Dateiverwaltung.VorhandeneExterneAimlDateiImportieren(dateiname, this._arbeitsbereich);
        this.AktuelleDatei = (IArbeitsbereichDatei) aimlDatei;
        if (dateiAlsChangedMarkieren && aimlDatei != null)
          aimlDatei.IsChanged = true;
        this.AIMLDateienNeuAnzeigen(true);
      }
      catch (AIMLDatei.AIMLDateiNichtGeladenException ex)
      {
        Debugger.GlobalDebugger.FehlerZeigen(string.Format(ResReader.Reader.GetString("AIMLDateiLadeFehler"), (object) dateiname, (object) ex.Message), (object) this, "LadeDatei");
      }
    }

    private void newStartupDateiToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.AktuelleDatei = (IArbeitsbereichDatei) this._arbeitsbereich.Dateiverwaltung.AddLeereStartupDatei(this._arbeitsbereich);
      this.AIMLDateienNeuAnzeigen(true);
    }

    private void newAimlFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.AktuelleDatei = (IArbeitsbereichDatei) this._arbeitsbereich.Dateiverwaltung.AddAimlLeereDatei(this._arbeitsbereich, false);
      this.AIMLDateienNeuAnzeigen(true);
    }

    private void toolStripButtonDelete_Click(object sender, EventArgs e)
    {
      IArbeitsbereichDatei aktuelleDatei = this.AktuelleDatei;
      if (aktuelleDatei == null || !this._arbeitsbereich.Dateiverwaltung.DateiLoeschen(aktuelleDatei, this._arbeitsbereich))
        return;
      this.AIMLDateienNeuAnzeigen(true);
      Application.DoEvents();
      this.ErsteDateiSelektieren();
    }

    private void AIMLDateienNeuAnzeigen(bool vorherLeeren)
    {
      vorherLeeren = true;
      if (this._wirdGeradeNeuGezeichnet)
        return;
      this._wirdGeradeNeuGezeichnet = true;
      if (vorherLeeren)
      {
        IOrderedEnumerable<IArbeitsbereichDatei> orderedEnumerable = this._arbeitsbereich.Dateiverwaltung.Dateien.Cast<IArbeitsbereichDatei>().OrderBy<IArbeitsbereichDatei, string>((Func<IArbeitsbereichDatei, string>) (a => a.SortKey));
        this.treeViewDateien.Nodes.Clear();
        foreach (IArbeitsbereichDatei arbeitsbereichDatei in (IEnumerable<IArbeitsbereichDatei>) orderedEnumerable)
        {
          string titel = arbeitsbereichDatei.Titel;
          if (string.IsNullOrEmpty(titel))
            titel = arbeitsbereichDatei.Titel;
          TreeNode node = new TreeNode(titel);
          node.Tag = (object) arbeitsbereichDatei;
          this.ListenEintragBeschriften(node, false);
          TreeNode parentTreeNode = this.GetParentTreeNode(arbeitsbereichDatei.Unterverzeichnisse);
          if (parentTreeNode == null)
            this.treeViewDateien.Nodes.Add(node);
          else
            parentTreeNode.Nodes.Add(node);
        }
      }
      else
      {
        foreach (TreeNode node in this.treeViewDateien.Nodes)
          this.ListenEintragBeschriften(node, true);
      }
      this._wirdGeradeNeuGezeichnet = false;
    }

    private TreeNode GetParentTreeNode(string[] unterverzeichnisse)
    {
      if (unterverzeichnisse == null || unterverzeichnisse.Length == 0)
        return (TreeNode) null;
      TreeNode treeNode1 = (TreeNode) null;
      int index = 0;
      ArrayList arrayList = new ArrayList();
      foreach (TreeNode node in this.treeViewDateien.Nodes)
      {
        if (node.Parent == null)
          arrayList.Add((object) node);
      }
      for (; index < unterverzeichnisse.Length; ++index)
      {
        TreeNode treeNode2 = (TreeNode) null;
        foreach (TreeNode treeNode3 in arrayList)
        {
          if (treeNode3.Text == unterverzeichnisse[index])
          {
            treeNode2 = treeNode3;
            break;
          }
        }
        if (treeNode2 == null)
        {
          TreeNode node = new TreeNode(unterverzeichnisse[index]);
          if (treeNode1 == null)
            this.treeViewDateien.Nodes.Add(node);
          else
            treeNode1.Nodes.Add(node);
          treeNode1 = node;
        }
        else
          treeNode1 = treeNode2;
        arrayList = new ArrayList();
        foreach (TreeNode node in treeNode1.Nodes)
          arrayList.Add((object) node);
      }
      treeNode1.ImageKey = "paket";
      treeNode1.SelectedImageKey = treeNode1.ImageKey;
      return treeNode1;
    }

    private void ListenEintragBeschriften(TreeNode item, bool unterNodesAuch)
    {
      if (item.Tag != null && item.Tag is IArbeitsbereichDatei)
      {
        IArbeitsbereichDatei tag = (IArbeitsbereichDatei) item.Tag;
        Color color1;
        Color color2;
        string str;
        if (tag.HatFehler)
        {
          color1 = Color.Red;
          color2 = Color.Black;
          str = string.Format("{0} ({1})", (object) tag.Titel, (object) ResReader.Reader.GetString("ungueltig"));
        }
        else if (this._arbeitsbereich.DieseAIMLDateiNichtExportieren(tag))
        {
          color1 = this.treeViewDateien.BackColor;
          color2 = Color.LightGray;
          str = string.Format("[{0}] ({1})", (object) tag.Titel, (object) ResReader.Reader.GetString("DieseDateiNichtExportieren"));
        }
        else if (tag.ReadOnly)
        {
          color2 = Color.Black;
          color1 = Color.FromArgb(0, 240, 240, (int) byte.MaxValue);
          str = tag.Titel;
        }
        else
        {
          color2 = Color.Black;
          color1 = this.treeViewDateien.BackColor;
          str = tag.Titel;
        }
        if (tag is AIMLDatei)
          item.ImageKey = "aiml";
        if (tag is StartupDatei)
          item.ImageKey = "startup";
        if (item.Text != str)
          item.Text = str;
        if (item.ForeColor != color2)
          item.ForeColor = color2;
        if (item.BackColor != color1)
          item.BackColor = color1;
        bool flag = false;
        if (this.AktuelleDatei != null)
          flag = tag == this.AktuelleDatei;
        if (flag)
          this.treeViewDateien.SelectedNode = item;
      }
      if (unterNodesAuch)
      {
        foreach (TreeNode node in item.Nodes)
          this.ListenEintragBeschriften(node, true);
      }
      item.SelectedImageKey = item.ImageKey;
    }

    private void SteuerElementeBenennen()
    {
      this.toolStripButtonSave.Text = ResReader.Reader.GetString("toolStripButtonSave");
      this.toolStripButtonDelete.Text = ResReader.Reader.GetString("toolStripButtonDelete");
      this.toolStripButtonNewFile.Text = ResReader.Reader.GetString("toolStripButtonNewFile");
      this.toolStripButtonOpenFile.Text = ResReader.Reader.GetString("toolStripButtonOpenFile");
      this.toolStripButtonFehlerZeigen.Text = ResReader.Reader.GetString("toolStripButtonFehlerzeigen");
      this.toolStripButtonAIMLDateiUmbenennen.Text = ResReader.Reader.GetString("toolStripButtonAIMLDateiUmbenennen");
    }

    private void uAIMLDateiListe_Resize(object sender, EventArgs e)
    {
      this.treeViewDateien.Top = this.toolStrip1.Top + this.toolStrip1.Height;
      this.treeViewDateien.Left = 0;
      this.treeViewDateien.Height = this.ClientSize.Height - this.treeViewDateien.Top;
      this.treeViewDateien.Width = this.ClientSize.Width;
      int num = this.treeViewDateien.ClientSize.Width - 3;
    }

    private void AIMLDateiChangedZeigen()
    {
      IArbeitsbereichDatei aktuelleDatei = this.AktuelleDatei;
      if (aktuelleDatei != null)
      {
        if (aktuelleDatei.ReadOnly)
        {
          this.toolStripButtonSave.Enabled = false;
          this.toolStripButtonDelete.Enabled = false;
          this.toolStripButtonFehlerZeigen.Enabled = aktuelleDatei.HatFehler;
          this.toolStripButtonAIMLDateiUmbenennen.Enabled = false;
        }
        else
        {
          this.toolStripButtonSave.Enabled = aktuelleDatei.IsChanged;
          this.toolStripButtonDelete.Enabled = true;
          this.toolStripButtonFehlerZeigen.Enabled = aktuelleDatei.HatFehler;
          this.toolStripButtonAIMLDateiUmbenennen.Enabled = true;
        }
      }
      else
      {
        this.toolStripButtonFehlerZeigen.Enabled = false;
        this.toolStripButtonSave.Enabled = false;
        this.toolStripButtonDelete.Enabled = false;
        this.toolStripButtonAIMLDateiUmbenennen.Enabled = false;
      }
    }

    private void Save()
    {
      IArbeitsbereichDatei aktuelleDatei = this.AktuelleDatei;
      if (aktuelleDatei == null)
        return;
      bool cancel;
      aktuelleDatei.Save(out cancel);
      this.AIMLDateiChangedZeigen();
    }

    private void tmrRefresh_Tick(object sender, EventArgs e)
    {
      this.AIMLDateiChangedZeigen();
    }

    private void toolStripButtonFehlerZeigen_Click(object sender, EventArgs e)
    {
      IArbeitsbereichDatei aktuelleDatei = this.AktuelleDatei;
      if (aktuelleDatei == null || !(aktuelleDatei is AIMLDatei))
        return;
      ((AIMLDatei) aktuelleDatei).GegenAIMLDTDPruefen(AIMLDatei.PruefFehlerVerhalten.FehlerDirektZeigen);
    }

    private void toolStripButtonUmbenennen_Click(object sender, EventArgs e)
    {
      IArbeitsbereichDatei aktuelleDatei = this.AktuelleDatei;
      if (aktuelleDatei == null)
        return;
      bool abgebrochen = false;
      bool flag = false;
      while (!flag)
      {
        string str1 = InputBox.Show(ResReader.Reader.GetString("BitteNeuenNamenFuerAIMLDatei"), ResReader.Reader.GetString("AIMLDateiUmbenennen"), aktuelleDatei.Titel, out abgebrochen);
        if (string.IsNullOrEmpty(str1))
          abgebrochen = true;
        if (abgebrochen)
        {
          flag = true;
        }
        else
        {
          string str2 = str1.Trim();
          if (aktuelleDatei.Titel == str2)
          {
            flag = true;
          }
          else
          {
            string str3 = string.Format("\\{0}.aiml", (object) str2);
            foreach (object obj in aktuelleDatei.Unterverzeichnisse)
              str3 = string.Format("\\{0}", obj) + str3;
            string str4 = this._arbeitsbereich.Arbeitsverzeichnis + "\\" + str3;
            bool cancel = false;
            aktuelleDatei.Save(out cancel);
            if (!cancel)
            {
              string grundWennNichtErfolgreich;
              if (this.AIMLDateiUmbenennen(aktuelleDatei.Dateiname, str4, out grundWennNichtErfolgreich))
              {
                this._arbeitsbereich.Dateiverwaltung.Dateien.Remove(aktuelleDatei);
                this.AktuelleDatei = this._arbeitsbereich.Dateiverwaltung.LadeEinzelneAimlDateiDirektOhneKopieEin(str4, this._arbeitsbereich);
                flag = true;
                this.AIMLDateienNeuAnzeigen(true);
              }
              else
              {
                int num = (int) MessageBox.Show(grundWennNichtErfolgreich, ResReader.Reader.GetString("KonnteAIMLDateiNichtUmbenennen"));
                Debugger.GlobalDebugger.Protokolliere("Konnte AIMLDatei '" + aktuelleDatei.Dateiname + "' nicht umbenennen:" + grundWennNichtErfolgreich, Debugger.ProtokollTypen.Fehlermeldung);
              }
            }
          }
        }
      }
    }

    public bool AIMLDateiUmbenennen(
      string alterDateiname,
      string neuerDateiname,
      out string grundWennNichtErfolgreich)
    {
      try
      {
        if (File.Exists(neuerDateiname))
        {
          grundWennNichtErfolgreich = ResReader.Reader.GetString("AIMLDateiSchonVorhanden");
          return false;
        }
        File.Move(alterDateiname, neuerDateiname);
      }
      catch (Exception ex)
      {
        grundWennNichtErfolgreich = ex.Message;
        return false;
      }
      grundWennNichtErfolgreich = (string) null;
      return true;
    }

    private void ErsteDateiSelektieren()
    {
      if (this._arbeitsbereich == null)
        return;
      this._arbeitsbereich.Fokus.AktDatei = this.treeViewDateien.Nodes.Count <= 0 ? (IArbeitsbereichDatei) null : (IArbeitsbereichDatei) this.treeViewDateien.Nodes[0].Tag;
    }

    private IArbeitsbereichDatei DateiUnterPos(Point screenPos)
    {
      Point client = this.treeViewDateien.PointToClient(screenPos);
      TreeNode nodeAt = this.treeViewDateien.GetNodeAt(client.X, client.Y);
      if (nodeAt == null)
        return (IArbeitsbereichDatei) null;
      IArbeitsbereichDatei tag = (IArbeitsbereichDatei) nodeAt.Tag;
      if (tag != null)
        return tag;
      return (IArbeitsbereichDatei) null;
    }

    private void toolStripButtonHinzugelinkteDateienWaehlen_Click(object sender, EventArgs e)
    {
      int num = (int) new GaitoBotEditorCore.ContentHinzulinken.ContentHinzulinken(this.Arbeitsbereich).ShowDialog();
    }
  }
}
