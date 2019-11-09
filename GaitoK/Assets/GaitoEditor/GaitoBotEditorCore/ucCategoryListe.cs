// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.ucCategoryListe
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using GaitoBotEditorCore.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace GaitoBotEditorCore
{
  public class ucCategoryListe : UserControl
  {
    private ImageList imgListToolbar;
    private ToolStrip toolStrip1;
    private ToolStripButton toolStripButtonDeleteKategory;
    private DataGridView dataGridViewCategories;
    private ToolStripButton toolStripButtonSortieren;
    private ToolStripSplitButton toolStripButtonNeueKategorie;
    private ToolStripMenuItem toolStripButtonCreateTHATReference;
    private ToolStripMenuItem toolStripButtonPassendesSRAI;
    private ToolStripMenuItem toolStripButtonTHATKlonen;
    private ToolStripMenuItem toolStripButtonCloneTemplate;
    private ToolStripMenuItem cloneToolStripMenuItem;
    private IContainer components;
    private bool _zeilenWerdenGeradeAufgefuellt;
    private bool _wirdGeradeNeuGezeichnet;
    private List<AIMLCategory> _merkeCategories;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ucCategoryListe));
      this.imgListToolbar = new ImageList(this.components);
      this.toolStrip1 = new ToolStrip();
      this.toolStripButtonNeueKategorie = new ToolStripSplitButton();
      this.toolStripButtonCreateTHATReference = new ToolStripMenuItem();
      this.toolStripButtonPassendesSRAI = new ToolStripMenuItem();
      this.toolStripButtonTHATKlonen = new ToolStripMenuItem();
      this.toolStripButtonCloneTemplate = new ToolStripMenuItem();
      this.cloneToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripButtonDeleteKategory = new ToolStripButton();
      this.toolStripButtonSortieren = new ToolStripButton();
      this.dataGridViewCategories = new DataGridView();
      this.toolStrip1.SuspendLayout();
      ((ISupportInitialize) this.dataGridViewCategories).BeginInit();
      this.SuspendLayout();
      this.imgListToolbar.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imgListToolbar.ImageStream");
      this.imgListToolbar.TransparentColor = Color.Transparent;
      this.imgListToolbar.Images.SetKeyName(0, "");
      this.imgListToolbar.Images.SetKeyName(1, "");
      this.toolStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.toolStripButtonNeueKategorie,
        (ToolStripItem) this.toolStripButtonDeleteKategory,
        (ToolStripItem) this.toolStripButtonSortieren
      });
      componentResourceManager.ApplyResources((object) this.toolStrip1, "toolStrip1");
      this.toolStrip1.Name = "toolStrip1";
      this.toolStripButtonNeueKategorie.DropDownItems.AddRange(new ToolStripItem[5]
      {
        (ToolStripItem) this.toolStripButtonCreateTHATReference,
        (ToolStripItem) this.toolStripButtonPassendesSRAI,
        (ToolStripItem) this.toolStripButtonTHATKlonen,
        (ToolStripItem) this.toolStripButtonCloneTemplate,
        (ToolStripItem) this.cloneToolStripMenuItem
      });
      this.toolStripButtonNeueKategorie.Image = (Image) Resources.add_161;
      componentResourceManager.ApplyResources((object) this.toolStripButtonNeueKategorie, "toolStripButtonNeueKategorie");
      this.toolStripButtonNeueKategorie.Name = "toolStripButtonNeueKategorie";
      this.toolStripButtonNeueKategorie.ButtonClick += new EventHandler(this.toolStripButtonNeueKategorie_ButtonClick);
      this.toolStripButtonCreateTHATReference.Name = "toolStripButtonCreateTHATReference";
      componentResourceManager.ApplyResources((object) this.toolStripButtonCreateTHATReference, "toolStripButtonCreateTHATReference");
      this.toolStripButtonCreateTHATReference.Click += new EventHandler(this.toolStripButtonCreateTHATReference_Click_1);
      this.toolStripButtonPassendesSRAI.Name = "toolStripButtonPassendesSRAI";
      componentResourceManager.ApplyResources((object) this.toolStripButtonPassendesSRAI, "toolStripButtonPassendesSRAI");
      this.toolStripButtonPassendesSRAI.Click += new EventHandler(this.toolStripButtonPassendesSRAI_Click_1);
      this.toolStripButtonTHATKlonen.Name = "toolStripButtonTHATKlonen";
      componentResourceManager.ApplyResources((object) this.toolStripButtonTHATKlonen, "toolStripButtonTHATKlonen");
      this.toolStripButtonTHATKlonen.Click += new EventHandler(this.toolStripButtonTHATKlonen_Click_1);
      this.toolStripButtonCloneTemplate.Name = "toolStripButtonCloneTemplate";
      componentResourceManager.ApplyResources((object) this.toolStripButtonCloneTemplate, "toolStripButtonCloneTemplate");
      this.toolStripButtonCloneTemplate.Click += new EventHandler(this.toolStripButtonCloneTemplate_Click_1);
      this.cloneToolStripMenuItem.Name = "cloneToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.cloneToolStripMenuItem, "cloneToolStripMenuItem");
      this.cloneToolStripMenuItem.Click += new EventHandler(this.cloneToolStripMenuItem_Click);
      componentResourceManager.ApplyResources((object) this.toolStripButtonDeleteKategory, "toolStripButtonDeleteKategory");
      this.toolStripButtonDeleteKategory.Name = "toolStripButtonDeleteKategory";
      this.toolStripButtonDeleteKategory.Click += new EventHandler(this.toolStripButtonDeleteKategory_Click);
      this.toolStripButtonSortieren.Image = (Image) Resources.KEY06;
      componentResourceManager.ApplyResources((object) this.toolStripButtonSortieren, "toolStripButtonSortieren");
      this.toolStripButtonSortieren.Name = "toolStripButtonSortieren";
      this.toolStripButtonSortieren.Click += new EventHandler(this.toolStripButtonSortieren_Click);
      this.dataGridViewCategories.AllowUserToAddRows = false;
      this.dataGridViewCategories.AllowUserToDeleteRows = false;
      this.dataGridViewCategories.AllowUserToResizeColumns = false;
      this.dataGridViewCategories.AllowUserToResizeRows = false;
      this.dataGridViewCategories.BackgroundColor = Color.White;
      this.dataGridViewCategories.ClipboardCopyMode = DataGridViewClipboardCopyMode.Disable;
      this.dataGridViewCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dataGridViewCategories.EditMode = DataGridViewEditMode.EditProgrammatically;
      componentResourceManager.ApplyResources((object) this.dataGridViewCategories, "dataGridViewCategories");
      this.dataGridViewCategories.MultiSelect = false;
      this.dataGridViewCategories.Name = "dataGridViewCategories";
      this.dataGridViewCategories.ReadOnly = true;
      this.dataGridViewCategories.RowHeadersVisible = false;
      this.dataGridViewCategories.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
      this.dataGridViewCategories.RowTemplate.ReadOnly = true;
      this.dataGridViewCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridViewCategories.ShowCellErrors = false;
      this.dataGridViewCategories.ShowCellToolTips = false;
      this.dataGridViewCategories.ShowEditingIcon = false;
      this.dataGridViewCategories.ShowRowErrors = false;
      this.dataGridViewCategories.CellContentClick += new DataGridViewCellEventHandler(this.dataGridViewCategories_CellContentClick);
      this.Controls.Add((Control) this.dataGridViewCategories);
      this.Controls.Add((Control) this.toolStrip1);
      this.DoubleBuffered = true;
      this.Name = nameof (ucCategoryListe);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Load += new EventHandler(this.ucCategoryListe_Load);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      ((ISupportInitialize) this.dataGridViewCategories).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private AIMLTopic aimlTopic
    {
      get
      {
        if (this._arbeitsbereich == null)
          return (AIMLTopic) null;
        return this._arbeitsbereich.Fokus.AktAIMLTopic;
      }
    }

    private AIMLCategory AktuelleCategory
    {
      get
      {
        if (this._arbeitsbereich == null)
          throw new ApplicationException("Noch kein Arbeitsbereich zugewiesen!");
        return this._arbeitsbereich.Fokus.AktAIMLCategory;
      }
      set
      {
        if (this._arbeitsbereich == null)
          throw new ApplicationException("Noch kein Arbeitsbereich zugewiesen!");
        this._arbeitsbereich.Fokus.AktAIMLCategory = value;
      }
    }

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Dieser AIMLCategoryListe wurde bereits ein Arbeitsbereich zugeordnet");
        this._arbeitsbereich = value;
        this._arbeitsbereich.Fokus.AktAIMLTopicChanged += new ArbeitsbereichFokus.AktAIMLTopicChangedEventHandler(this.Fokus_AktAIMLTopicChanged);
        this._arbeitsbereich.Fokus.AktAIMLCategoryChanged += new EventHandler<EventArgs<AIMLCategory>>(this.Fokus_AktAIMLCategoryChanged);
        this.AIMLCategoriesNeuAnzeigen(false);
      }
    }

    public ucCategoryListe()
    {
      this.InitializeComponent();
      this.Resize += new EventHandler(this.ucCategoryListe_Resize);
      this.dataGridViewCategories.Columns.Add(ResReader.Reader.GetString("Pattern"), ResReader.Reader.GetString("Pattern"));
      this.dataGridViewCategories.Columns.Add(ResReader.Reader.GetString("That"), ResReader.Reader.GetString("That"));
      this.dataGridViewCategories.Columns.Add(ResReader.Reader.GetString("Template"), ResReader.Reader.GetString("Template"));
      this.dataGridViewCategories.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dataGridViewCategories.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dataGridViewCategories.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dataGridViewCategories.SelectionChanged += new EventHandler(this.dataGridViewCategories_SelectionChanged);
      this.dataGridViewCategories.Scroll += new ScrollEventHandler(this.dataGridViewCategories_Scroll);
      this.dataGridViewCategories.Resize += new EventHandler(this.dataGridViewCategories_Resize);
    }

    private void ucCategoryListe_Load(object sender, EventArgs e)
    {
      this.dataGridViewCategories.AllowUserToAddRows = false;
      this.dataGridViewCategories.AllowUserToResizeColumns = false;
      this.dataGridViewCategories.AllowUserToResizeRows = false;
      this.dataGridViewCategories.MouseMove += new MouseEventHandler(this.dataGridViewCategories_MouseMove);
      this.dataGridViewCategories.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
      this.SteuerelementeBeschriften();
    }

    private bool DateiIstReadOnly
    {
      get
      {
        return this.aimlTopic != null && this.aimlTopic.AIMLDatei != null && this.aimlTopic.AIMLDatei.ReadOnly;
      }
    }

    private AIMLCategory GetNaechstLiegendeCategory(AIMLCategory category)
    {
      if (category.ContentNode.NextSibling != null)
      {
        AIMLCategory categoryForCategoryNode = this._arbeitsbereich.GetCategoryForCategoryNode(category.ContentNode.NextSibling);
        if (categoryForCategoryNode != null)
          return categoryForCategoryNode;
      }
      else if (category.ContentNode.PreviousSibling != null)
      {
        AIMLCategory categoryForCategoryNode = this._arbeitsbereich.GetCategoryForCategoryNode(category.ContentNode.PreviousSibling);
        if (categoryForCategoryNode != null)
          return categoryForCategoryNode;
      }
      return (AIMLCategory) null;
    }

    private void dataGridViewCategories_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.DateiIstReadOnly || e.Button != MouseButtons.Left || this.AktuelleCategory == null)
        return;
      AIMLCategory aktuelleCategory = this.AktuelleCategory;
      if (this.dataGridViewCategories.DoDragDrop((object) aktuelleCategory, DragDropEffects.Copy | DragDropEffects.Move) == DragDropEffects.Move && aktuelleCategory != null)
      {
        AIMLTopic aimlTopic = aktuelleCategory.AIMLTopic;
        AIMLCategory liegendeCategory = this.GetNaechstLiegendeCategory(aktuelleCategory);
        aimlTopic.LoescheCategory(aktuelleCategory);
        this.AIMLCategoriesNeuAnzeigen(false);
        if (liegendeCategory != null)
          this.AktuelleCategory = liegendeCategory;
        else
          this._arbeitsbereich.Fokus.BesteCategorySelektieren();
        this.ZeilenInhalteRefreshen();
      }
    }

    private void SteuerelementeBeschriften()
    {
      this.toolStripButtonDeleteKategory.Text = ResReader.Reader.GetString("toolStripButtonDeleteKategory");
      this.toolStripButtonNeueKategorie.Text = ResReader.Reader.GetString("toolStripButtonNeueKategorie");
      this.toolStripButtonCreateTHATReference.Text = ResReader.Reader.GetString("toolStripButtonCreateTHATReferenceText");
      this.toolStripButtonCreateTHATReference.ToolTipText = ResReader.Reader.GetString("toolStripButtonCreateTHATReferenceTooltip");
      this.toolStripButtonTHATKlonen.Text = ResReader.Reader.GetString("toolStripButtonTHATKlonenText");
      this.toolStripButtonTHATKlonen.ToolTipText = ResReader.Reader.GetString("toolStripButtonTHATKlonenToolTipp");
      this.toolStripButtonCloneTemplate.Text = ResReader.Reader.GetString("toolStripButtonCloneTemplateText");
      this.toolStripButtonPassendesSRAI.Text = ResReader.Reader.GetString("toolStripButtonPassendesSRAIText");
      this.toolStripButtonPassendesSRAI.ToolTipText = ResReader.Reader.GetString("toolStripButtonPassendesSRAITooltip");
      this.toolStripButtonSortieren.Text = ResReader.Reader.GetString("toolStripButtonSortieren");
      this.cloneToolStripMenuItem.Text = ResReader.Reader.GetString("cloneToolStripMenuItem");
    }

    private void Fokus_AktAIMLTopicChanged(
      object sender,
      ArbeitsbereichFokus.AktAIMLTopicChangedEventArgs e)
    {
      if (this.AktuelleCategory != null)
        return;
      this.AIMLCategoriesNeuAnzeigen(false);
    }

    private void Fokus_AktAIMLCategoryChanged(object sender, EventArgs<AIMLCategory> e)
    {
      this.AIMLCategoriesNeuAnzeigen(false);
    }

    private void AIMLCategoriesNeuAnzeigen(
      bool markierteZeileAufJedenFallInDenSichtbarenBereichScrollen)
    {
      if (this._wirdGeradeNeuGezeichnet)
        return;
      this._wirdGeradeNeuGezeichnet = true;
      int num = 0;
      AIMLTopic aimlTopic = this.aimlTopic;
      if (aimlTopic == null)
      {
        num = 0;
        this._merkeCategories = (List<AIMLCategory>) null;
        this.Enabled = false;
        this.dataGridViewCategories.Rows.Clear();
      }
      else
      {
        this._merkeCategories = aimlTopic.Categories;
        this.AnzahlZeilenAuffuellen(this._merkeCategories.Count);
        AIMLCategory aktuelleCategory = this.AktuelleCategory;
        if (aktuelleCategory != null)
        {
          int index = this._merkeCategories.IndexOf(aktuelleCategory);
          if (index != -1)
          {
            DataGridViewRow row = this.dataGridViewCategories.Rows[index];
            if (!row.Selected)
              row.Selected = true;
            if (!row.Displayed | markierteZeileAufJedenFallInDenSichtbarenBereichScrollen)
            {
              try
              {
                this.dataGridViewCategories.FirstDisplayedScrollingRowIndex = index;
              }
              catch (Exception ex)
              {
              }
            }
          }
        }
        this.Enabled = true;
      }
      this._wirdGeradeNeuGezeichnet = false;
      this.ToolStripButtonsAnzeigen();
      this.ZeilenInhalteRefreshen();
    }

    private void AnzahlZeilenAuffuellen(int anzahlKategorien)
    {
      this._zeilenWerdenGeradeAufgefuellt = true;
      if (anzahlKategorien == 0)
        this.dataGridViewCategories.Rows.Clear();
      int num = anzahlKategorien - this.dataGridViewCategories.Rows.Count;
      if (num < 0 && -num > anzahlKategorien)
        this.dataGridViewCategories.Rows.Clear();
      if (anzahlKategorien > this.dataGridViewCategories.Rows.Count)
        this.dataGridViewCategories.Rows.Add(anzahlKategorien - this.dataGridViewCategories.Rows.Count);
      while (anzahlKategorien < this.dataGridViewCategories.Rows.Count)
        this.dataGridViewCategories.Rows.RemoveAt(this.dataGridViewCategories.Rows.Count - 1);
      this._zeilenWerdenGeradeAufgefuellt = false;
    }

    private void dataGridViewCategories_Scroll(object sender, ScrollEventArgs e)
    {
      this.ZeilenInhalteRefreshen();
    }

    private void ZeilenInhalteRefreshen()
    {
      if (this._zeilenWerdenGeradeAufgefuellt || this._merkeCategories == null || this._wirdGeradeNeuGezeichnet)
        return;
      this._wirdGeradeNeuGezeichnet = true;
      int scrollingRowIndex = this.dataGridViewCategories.FirstDisplayedScrollingRowIndex;
      int val1 = scrollingRowIndex + this.dataGridViewCategories.DisplayedRowCount(true);
      int num1 = Math.Max(0, scrollingRowIndex);
      int num2 = Math.Min(val1, this._merkeCategories.Count);
      for (int index = num1; index < num2; ++index)
      {
        this.dataGridViewCategories.Rows[index].Cells[0].Value = (object) this._merkeCategories[index].AutoKurzNamePattern;
        this.dataGridViewCategories.Rows[index].Cells[1].Value = (object) this._merkeCategories[index].AutoThatZusammenfassung;
        this.dataGridViewCategories.Rows[index].Cells[2].Value = (object) this._merkeCategories[index].AutoTemplateZusammenfassung;
      }
      this._wirdGeradeNeuGezeichnet = false;
      Application.DoEvents();
    }

    private void dataGridViewCategories_SelectionChanged(object sender, EventArgs e)
    {
      if (this._wirdGeradeNeuGezeichnet)
        return;
      DataGridViewSelectedRowCollection selectedRows = this.dataGridViewCategories.SelectedRows;
      if (selectedRows.Count == 1)
      {
        if (this._merkeCategories != null)
        {
          if (this._merkeCategories.Count == this.dataGridViewCategories.Rows.Count)
          {
            this.AktuelleCategory = this._merkeCategories[selectedRows[0].Index];
          }
          else
          {
            this.AIMLCategoriesNeuAnzeigen(true);
            this.AktuelleCategory = (AIMLCategory) null;
          }
        }
        else
          this.AktuelleCategory = (AIMLCategory) null;
      }
      else
        this.AktuelleCategory = (AIMLCategory) null;
      this.ZeilenInhalteRefreshen();
    }

    private void NeueCategoryHinzufuegen()
    {
      this.AktuelleCategory = this.aimlTopic.AddNewCategory();
      this._arbeitsbereich.Fokus.FokusAufXmlEditorSetzen();
      this.AIMLCategoriesNeuAnzeigen(true);
    }

    private void AktuelleCategoryLoeschen()
    {
      AIMLCategory aktuelleCategory = this.AktuelleCategory;
      if (aktuelleCategory == null || MessageBox.Show(ResReader.Reader.GetString("AktuelleCategoryWirklichLoeschen"), ResReader.Reader.GetString(nameof (AktuelleCategoryLoeschen)), MessageBoxButtons.YesNoCancel) != DialogResult.Yes)
        return;
      AIMLCategory liegendeCategory = this.GetNaechstLiegendeCategory(aktuelleCategory);
      if (this.aimlTopic == null)
        throw new ApplicationException("aimlTopic==null!");
      if (aktuelleCategory == null)
        throw new ApplicationException("Es ist keine aktuelle Category mehr zum Löschen gewählt!");
      this.aimlTopic.LoescheCategory(aktuelleCategory);
      if (liegendeCategory != null)
      {
        this.AktuelleCategory = liegendeCategory;
      }
      else
      {
        if (this._arbeitsbereich == null)
          throw new ApplicationException("_arbeitsbereich==null!");
        this._arbeitsbereich.Fokus.BesteCategorySelektieren();
      }
    }

    private void ToolStripButtonsAnzeigen()
    {
      bool flag = true;
      if (this.aimlTopic == null)
        flag = false;
      if (this.DateiIstReadOnly)
        flag = false;
      if (!flag)
      {
        this.toolStripButtonNeueKategorie.Enabled = false;
        this.toolStripButtonDeleteKategory.Enabled = false;
        this.toolStripButtonCreateTHATReference.Enabled = false;
        this.toolStripButtonTHATKlonen.Enabled = false;
        this.toolStripButtonCloneTemplate.Enabled = false;
        this.toolStripButtonPassendesSRAI.Enabled = false;
        this.cloneToolStripMenuItem.Enabled = false;
      }
      else
      {
        this.toolStripButtonNeueKategorie.Enabled = true;
        this.toolStripButtonDeleteKategory.Enabled = this.AktuelleCategory != null;
        this.toolStripButtonCreateTHATReference.Enabled = this.AktuelleCategory != null;
        this.toolStripButtonTHATKlonen.Enabled = this.AktuelleCategory != null && this.AktuelleCategory.That != "";
        this.toolStripButtonCloneTemplate.Enabled = this.AktuelleCategory != null;
        this.toolStripButtonPassendesSRAI.Enabled = this.AktuelleCategory != null;
        this.cloneToolStripMenuItem.Enabled = this.AktuelleCategory != null;
      }
    }

    private void toolStripButtonSortieren_Click(object sender, EventArgs e)
    {
      if (this._arbeitsbereich == null)
        return;
      AIMLTopic aktAimlTopic = this._arbeitsbereich.Fokus.AktAIMLTopic;
      if (aktAimlTopic != null)
      {
        aktAimlTopic.CategoriesSortieren_();
        this.AIMLCategoriesNeuAnzeigen(true);
        AIMLCategory aktuelleCategory = this.AktuelleCategory;
        this.AktuelleCategory = (AIMLCategory) null;
        this.AktuelleCategory = aktuelleCategory;
      }
    }

    private void toolStripButtonNeueKategorie_ButtonClick(object sender, EventArgs e)
    {
      this.NeueCategoryHinzufuegen();
    }

    private void toolStripButtonDeleteKategory_Click(object sender, EventArgs e)
    {
      this.AktuelleCategoryLoeschen();
    }

    private void toolStripButtonCreateTHATReference_Click_1(object sender, EventArgs e)
    {
      AIMLCategory aktuelleCategory = this.AktuelleCategory;
      AIMLCategory category = aktuelleCategory.AIMLTopic.AddNewCategory();
      XmlNode element = (XmlNode) category.ContentNode.OwnerDocument.CreateElement("that");
      string template = aktuelleCategory.Template;
      element.InnerXml = template;
      XmlNode refChild = category.ContentNode.SelectSingleNode("pattern");
      if (refChild != null)
      {
        category.ContentNode.InsertAfter(element, refChild);
        this.AktuelleCategory = category;
        this._arbeitsbereich.Fokus.FokusAufXmlEditorSetzen();
      }
      else
        aktuelleCategory.AIMLTopic.LoescheCategory(category);
      this.AIMLCategoriesNeuAnzeigen(true);
    }

    private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
    {
      AIMLCategory aktuelleCategory = this.AktuelleCategory;
      XmlNode newCategoryNode = aktuelleCategory.ContentNode.Clone();
      this.AktuelleCategory = aktuelleCategory.AIMLTopic.AddNewCategory(newCategoryNode);
      this._arbeitsbereich.Fokus.FokusAufXmlEditorSetzen();
      this.AIMLCategoriesNeuAnzeigen(true);
    }

    private void toolStripButtonTHATKlonen_Click_1(object sender, EventArgs e)
    {
      AIMLCategory aktuelleCategory = this.AktuelleCategory;
      AIMLCategory category = aktuelleCategory.AIMLTopic.AddNewCategory();
      XmlNode element = (XmlNode) category.ContentNode.OwnerDocument.CreateElement("that");
      string that = aktuelleCategory.That;
      element.InnerXml = that;
      XmlNode refChild = category.ContentNode.SelectSingleNode("pattern");
      if (refChild != null)
      {
        category.ContentNode.InsertAfter(element, refChild);
        this.AktuelleCategory = category;
        this._arbeitsbereich.Fokus.FokusAufXmlEditorSetzen();
      }
      else
        aktuelleCategory.AIMLTopic.LoescheCategory(category);
      this.AIMLCategoriesNeuAnzeigen(true);
    }

    private void toolStripButtonCloneTemplate_Click_1(object sender, EventArgs e)
    {
      AIMLCategory aktuelleCategory = this.AktuelleCategory;
      AIMLCategory category = aktuelleCategory.AIMLTopic.AddNewCategory();
      XmlNode xmlNode1 = aktuelleCategory.ContentNode.SelectSingleNode("template");
      XmlNode xmlNode2 = category.ContentNode.SelectSingleNode("template");
      if (xmlNode1 != null)
      {
        foreach (XmlNode childNode in xmlNode1.ChildNodes)
        {
          XmlNode newChild = childNode.Clone();
          xmlNode2.AppendChild(newChild);
        }
        this.AktuelleCategory = category;
        this._arbeitsbereich.Fokus.FokusAufXmlEditorSetzen();
      }
      else
        aktuelleCategory.AIMLTopic.LoescheCategory(category);
      this.AIMLCategoriesNeuAnzeigen(true);
    }

    private void toolStripButtonPassendesSRAI_Click_1(object sender, EventArgs e)
    {
      AIMLCategory aktuelleCategory = this.AktuelleCategory;
      AIMLCategory category = aktuelleCategory.AIMLTopic.AddNewCategory();
      XmlNode xmlNode = aktuelleCategory.ContentNode.SelectSingleNode("pattern");
      if (xmlNode != null)
      {
        XmlNode element = (XmlNode) category.ContentNode.OwnerDocument.CreateElement("srai");
        element.InnerText = xmlNode.InnerXml;
        category.ContentNode.SelectSingleNode("template").AppendChild(element);
        this.AktuelleCategory = category;
        this._arbeitsbereich.Fokus.FokusAufXmlEditorSetzen();
      }
      else
        aktuelleCategory.AIMLTopic.LoescheCategory(category);
      this.AIMLCategoriesNeuAnzeigen(true);
    }

    private void dataGridViewCategories_Resize(object sender, EventArgs e)
    {
      this.ResizeAll();
    }

    private void ucCategoryListe_Resize(object sender, EventArgs e)
    {
      this.ResizeAll();
    }

    private void ResizeAll()
    {
      this.dataGridViewCategories.Top = this.toolStrip1.Top + this.toolStrip1.Height;
      this.dataGridViewCategories.Left = 0;
      this.dataGridViewCategories.Height = this.ClientSize.Height - this.dataGridViewCategories.Top;
      this.dataGridViewCategories.Width = this.ClientSize.Width;
      int num1 = this.dataGridViewCategories.ClientSize.Width - 3;
      int num2 = num1;
      if (this.dataGridViewCategories.Columns.Count == 3)
      {
        this.dataGridViewCategories.Columns[0].Width = num1 / 3;
        int num3 = num2 - this.dataGridViewCategories.Columns[0].Width;
        this.dataGridViewCategories.Columns[1].Width = num1 / 3;
        this.dataGridViewCategories.Columns[2].Width = num3 - this.dataGridViewCategories.Columns[1].Width;
      }
      this.ZeilenInhalteRefreshen();
    }

    private void dataGridViewCategories_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
    }
  }
}
