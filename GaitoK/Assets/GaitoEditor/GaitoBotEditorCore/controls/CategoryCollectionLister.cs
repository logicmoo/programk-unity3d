// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.controls.CategoryCollectionLister
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace GaitoBotEditorCore.controls
{
  public class CategoryCollectionLister : UserControl
  {
    private static object _lock = new object();
    private IContainer components = (IContainer) null;
    private bool _zeilenWerdenGeradeAufgefuellt;
    private bool _wirdGeradeNeuGezeichnet;
    private List<AIMLCategory> _categories;
    private DataGridView dataGridViewCategorien;

    public List<AIMLCategory> Categories
    {
      set
      {
        this._categories = value;
        if (this._categories == null || this._categories.Count == 0)
          this.dataGridViewCategorien.Visible = false;
        else
          this.NeuZeichnen();
        this.ResizeAll();
      }
    }

    private void NeuZeichnen()
    {
      if (this._wirdGeradeNeuGezeichnet)
        return;
      this._wirdGeradeNeuGezeichnet = true;
      if (this._categories == null || this._categories.Count == 0)
        this.AnzahlZeilenAuffuellen(0);
      else
        this.AnzahlZeilenAuffuellen(this._categories.Count);
      this.dataGridViewCategorien.Visible = true;
      this.ZeilenInhalteRefreshen();
      this._wirdGeradeNeuGezeichnet = false;
    }

    public CategoryCollectionLister()
    {
      this.InitializeComponent();
      this.dataGridViewCategorien.Columns.Add(ResReader.Reader.GetString("CategoryListeCellAIMLDatei"), ResReader.Reader.GetString("SuchenCellAIMLDatei"));
      this.dataGridViewCategorien.Columns.Add(ResReader.Reader.GetString("CategoryListeCellAIMLDateiThema"), ResReader.Reader.GetString("SuchenCellAIMLDateiThema"));
      this.dataGridViewCategorien.Columns.Add(ResReader.Reader.GetString("CategoryListeCellAIMLCategory"), ResReader.Reader.GetString("SuchenCellAIMLCategory"));
      this.dataGridViewCategorien.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dataGridViewCategorien.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dataGridViewCategorien.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.Resize += new EventHandler(this.CategoryCollectionLister_Resize);
    }

    private void CategoryCollectionLister_Load(object sender, EventArgs e)
    {
      this.dataGridViewCategorien.AllowUserToAddRows = false;
      this.dataGridViewCategorien.AllowUserToResizeColumns = false;
      this.dataGridViewCategorien.AllowUserToResizeRows = false;
      this.dataGridViewCategorien.RowHeadersVisible = false;
      this.dataGridViewCategorien.MultiSelect = false;
      this.dataGridViewCategorien.ScrollBars = ScrollBars.Both;
      this.dataGridViewCategorien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridViewCategorien.Scroll += new ScrollEventHandler(this.dataGridViewCategorien_Scroll);
      this.dataGridViewCategorien.SelectionChanged += new EventHandler(this.dataGridViewCategorien_SelectionChanged);
      this.ResizeAll();
    }

    private void ZeilenInhalteRefreshen()
    {
      if (this._zeilenWerdenGeradeAufgefuellt || (this._categories == null || this._categories.Count == 0))
        return;
      int scrollingRowIndex = this.dataGridViewCategorien.FirstDisplayedScrollingRowIndex;
      int val1 = scrollingRowIndex + this.dataGridViewCategorien.DisplayedRowCount(true);
      int num1 = Math.Max(0, scrollingRowIndex);
      int num2 = Math.Min(val1, this._categories.Count);
      for (int index = num1; index < num2; ++index)
      {
        AIMLCategory category = this._categories[index];
        this.dataGridViewCategorien.Rows[index].Cells[0].Value = (object) category.AIMLTopic.AIMLDatei.Titel;
        this.dataGridViewCategorien.Rows[index].Cells[1].Value = (object) category.AIMLTopic.Name;
        this.dataGridViewCategorien.Rows[index].Cells[2].Value = (object) category.AutoKomplettZusammenfassung;
      }
      Application.DoEvents();
    }

    private void ResizeAll()
    {
      this.dataGridViewCategorien.Left = 0;
      this.dataGridViewCategorien.Top = 0;
      this.dataGridViewCategorien.Height = this.ClientSize.Height;
      this.dataGridViewCategorien.Width = this.ClientSize.Width;
      int num1 = this.dataGridViewCategorien.ClientSize.Width - 3;
      int num2 = num1;
      if (this.dataGridViewCategorien.Columns.Count == 3)
      {
        this.dataGridViewCategorien.Columns[0].Width = num1 / 7;
        int num3 = num2 - this.dataGridViewCategorien.Columns[0].Width;
        this.dataGridViewCategorien.Columns[1].Width = num1 / 7;
        this.dataGridViewCategorien.Columns[2].Width = num3 - this.dataGridViewCategorien.Columns[1].Width;
      }
      this.ZeilenInhalteRefreshen();
    }

    private void CategoryCollectionLister_Resize(object sender, EventArgs e)
    {
      this.ResizeAll();
    }

    private void dataGridViewCategorien_SelectionChanged(object sender, EventArgs e)
    {
      if (this._categories == null || this._categories.Count == 0 || this.dataGridViewCategorien.SelectedRows.Count != 1)
        return;
      int index = this.dataGridViewCategorien.SelectedRows[0].Index;
      if (index > this._categories.Count - 1)
        return;
      if (this._categories[index] != null)
      {
        AIMLCategory category = this._categories[index];
        category.AIMLTopic.AIMLDatei.Arbeitsbereich.Fokus.AktAIMLCategory = category;
      }
      Application.DoEvents();
    }

    private void dataGridViewCategorien_Scroll(object sender, ScrollEventArgs e)
    {
      this.ZeilenInhalteRefreshen();
    }

    private void AnzahlZeilenAuffuellen(int anzahlKategorien)
    {
      lock (CategoryCollectionLister._lock)
      {
        this._zeilenWerdenGeradeAufgefuellt = true;
        if (anzahlKategorien == 0)
          this.dataGridViewCategorien.Rows.Clear();
        int num = anzahlKategorien - this.dataGridViewCategorien.Rows.Count;
        if (num < 0 && -num > anzahlKategorien)
          this.dataGridViewCategorien.Rows.Clear();
        if (anzahlKategorien > this.dataGridViewCategorien.Rows.Count)
          this.dataGridViewCategorien.Rows.Add(anzahlKategorien - this.dataGridViewCategorien.Rows.Count);
        while (anzahlKategorien < this.dataGridViewCategorien.Rows.Count)
          this.dataGridViewCategorien.Rows.RemoveAt(this.dataGridViewCategorien.Rows.Count - 1);
        this._zeilenWerdenGeradeAufgefuellt = false;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (CategoryCollectionLister));
      this.dataGridViewCategorien = new DataGridView();
      ((ISupportInitialize) this.dataGridViewCategorien).BeginInit();
      this.SuspendLayout();
      this.dataGridViewCategorien.AllowUserToAddRows = false;
      this.dataGridViewCategorien.AllowUserToDeleteRows = false;
      this.dataGridViewCategorien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      componentResourceManager.ApplyResources((object) this.dataGridViewCategorien, "dataGridViewCategorien");
      this.dataGridViewCategorien.Name = "dataGridViewCategorien";
      this.dataGridViewCategorien.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.dataGridViewCategorien);
      this.Name = nameof (CategoryCollectionLister);
      this.Load += new EventHandler(this.CategoryCollectionLister_Load);
      ((ISupportInitialize) this.dataGridViewCategorien).EndInit();
      this.ResumeLayout(false);
    }
  }
}
