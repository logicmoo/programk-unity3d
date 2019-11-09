// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.controls.ucMeisteSRAIs
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.gaitobot2;
using de.springwald.toolbox;
using GaitoBotEditorCore.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GaitoBotEditorCore.controls
{
  public class ucMeisteSRAIs : UserControl
  {
    private IContainer components = (IContainer) null;
    private Arbeitsbereich _arbeitsbereich;
    private ToolStrip toolStripTop;
    private DataGridView dataGridViewBesteSRAIs;
    private ToolStripButton toolStripButtonRefresh;
    private ToolStripProgressBar toolStripProgressBar;
    private CategoryCollectionLister categoryCollectionLister;

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Diesem BesteSRAIZiele wurde bereits ein Arbeitsbereich zugeordnet");
        this._arbeitsbereich = value;
        this.NeuBerechnen();
      }
    }

    public ucMeisteSRAIs()
    {
      this.InitializeComponent();
      this.toolStripProgressBar.Visible = false;
      this.dataGridViewBesteSRAIs.Columns.Add(GaitoBotEditorCore.ResReader.Reader.GetString("BestSRAIAnzahl"), GaitoBotEditorCore.ResReader.Reader.GetString("BestSRAIAnzahl"));
      this.dataGridViewBesteSRAIs.Columns.Add(GaitoBotEditorCore.ResReader.Reader.GetString("BestSRAISRAI"), GaitoBotEditorCore.ResReader.Reader.GetString("BestSRAISRAI"));
      this.dataGridViewBesteSRAIs.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dataGridViewBesteSRAIs.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.Resize += new EventHandler(this.ucBesteSRAIZiele_Resize);
    }

    private void ucBesteSRAIZiele_Load(object sender, EventArgs e)
    {
      this.dataGridViewBesteSRAIs.AllowUserToAddRows = false;
      this.dataGridViewBesteSRAIs.AllowUserToResizeColumns = false;
      this.dataGridViewBesteSRAIs.AllowUserToResizeRows = false;
      this.dataGridViewBesteSRAIs.RowHeadersVisible = false;
      this.dataGridViewBesteSRAIs.MultiSelect = false;
      this.dataGridViewBesteSRAIs.ScrollBars = ScrollBars.Both;
      this.dataGridViewBesteSRAIs.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridViewBesteSRAIs.SelectionChanged += new EventHandler(this.dataGridViewBesteSRAIs_SelectionChanged);
      this.toolStripButtonRefresh.Text = GaitoBotEditorCore.ResReader.Reader.GetString("ucMeisteSRAIStoolStripButtonRefresh");
    }

    public void NeuBerechnen()
    {
      if (this._arbeitsbereich == null)
      {
        this.dataGridViewBesteSRAIs.Visible = false;
      }
      else
      {
        Hashtable hashtable = new Hashtable();
        try
        {
          this.toolStripProgressBar.Maximum = this._arbeitsbereich.Dateiverwaltung.AlleAimlDateien.Count;
          this.toolStripProgressBar.Value = 0;
          this.toolStripProgressBar.Visible = true;
        }
        finally
        {
        }
        foreach (AIMLDatei aimlDatei in this._arbeitsbereich.Dateiverwaltung.AlleAimlDateien)
        {
          try
          {
            ++this.toolStripProgressBar.Value;
          }
          finally
          {
          }
          foreach (AIMLTopic topic in aimlDatei.getTopics())
          {
            foreach (AIMLCategory category in topic.Categories)
            {
              foreach (string srai in category.Srais)
              {
                if (srai != "*")
                {
                  string lower = srai.ToLower();
                  if (hashtable.ContainsKey((object) lower))
                    hashtable[(object) lower] = (object) ((int) hashtable[(object) lower] + 1);
                  else
                    hashtable[(object) lower] = (object) 1;
                }
              }
            }
          }
        }
        this.toolStripProgressBar.Visible = false;
        ArrayList arrayList = new ArrayList();
        foreach (DictionaryEntry dictionaryEntry in hashtable)
        {
          int sortWert = (int) dictionaryEntry.Value;
          string key = (string) dictionaryEntry.Key;
          arrayList.Add((object) new IntSorterItem(sortWert, (object) key));
        }
        arrayList.Sort((IComparer) new IntSorterComparerReverse());
        this.dataGridViewBesteSRAIs.Rows.Clear();
        if ((uint) arrayList.Count > 0U)
        {
          int count = Math.Min(50, arrayList.Count);
          this.dataGridViewBesteSRAIs.Rows.Add(count);
          for (int index = 0; index < count; ++index)
          {
            this.dataGridViewBesteSRAIs.Rows[index].Cells[1].Value = (object) (string) ((IntSorterItem) arrayList[index]).Inhalt;
            this.dataGridViewBesteSRAIs.Rows[index].Cells[0].Value = (object) ((IntSorterItem) arrayList[index]).SortWert.ToString();
          }
        }
        this.dataGridViewBesteSRAIs.Visible = true;
      }
      this.AktuelleCategoryListeAnzeigen();
    }

    private void dataGridViewBesteSRAIs_SelectionChanged(object sender, EventArgs e)
    {
      this.AktuelleCategoryListeAnzeigen();
    }

    private void AktuelleCategoryListeAnzeigen()
    {
      if (this.dataGridViewBesteSRAIs.SelectedRows.Count != 1)
        this.categoryCollectionLister.Categories = (List<AIMLCategory>) null;
      else if (this.dataGridViewBesteSRAIs.SelectedRows[0].Cells[1].Value == null)
      {
        this.categoryCollectionLister.Categories = (List<AIMLCategory>) null;
      }
      else
      {
        string lower = this.dataGridViewBesteSRAIs.SelectedRows[0].Cells[1].Value.ToString().ToLower();
        List<AIMLCategory> aimlCategoryList = new List<AIMLCategory>();
        this.toolStripProgressBar.Maximum = this._arbeitsbereich.Dateiverwaltung.AlleAimlDateien.Count;
        this.toolStripProgressBar.Value = 0;
        this.toolStripProgressBar.Visible = true;
        foreach (AIMLDatei aimlDatei in this._arbeitsbereich.Dateiverwaltung.AlleAimlDateien)
        {
          ++this.toolStripProgressBar.Value;
          foreach (AIMLTopic topic in aimlDatei.getTopics())
          {
            foreach (AIMLCategory category in topic.Categories)
            {
              bool flag = false;
              foreach (string srai in category.Srais)
              {
                if (srai.ToLower() == lower)
                  flag = true;
              }
              if (flag)
                aimlCategoryList.Add(category);
            }
          }
        }
        this.toolStripProgressBar.Visible = false;
        this.categoryCollectionLister.Categories = aimlCategoryList;
      }
    }

    private void AktuelleCategoryListeAnzeigenAlt()
    {
      if (this.dataGridViewBesteSRAIs.SelectedRows.Count != 1)
        this.categoryCollectionLister.Categories = (List<AIMLCategory>) null;
      else if (this.dataGridViewBesteSRAIs.SelectedRows[0].Cells[1].Value == null)
      {
        this.categoryCollectionLister.Categories = (List<AIMLCategory>) null;
      }
      else
      {
        string rohEingabe = this.dataGridViewBesteSRAIs.SelectedRows[0].Cells[1].Value.ToString();
        Normalisierung.EingabePatternOptimieren(rohEingabe, true);
        string pattern = "\\A" + rohEingabe.Replace("*", ".*?") + "\\z";
        List<AIMLCategory> aimlCategoryList = new List<AIMLCategory>();
        this.toolStripProgressBar.Maximum = this._arbeitsbereich.Dateiverwaltung.AlleAimlDateien.Count;
        this.toolStripProgressBar.Value = 0;
        this.toolStripProgressBar.Visible = true;
        foreach (AIMLDatei aimlDatei in this._arbeitsbereich.Dateiverwaltung.AlleAimlDateien)
        {
          ++this.toolStripProgressBar.Value;
          foreach (AIMLTopic topic in aimlDatei.getTopics())
          {
            foreach (AIMLCategory category in topic.Categories)
            {
              if (Regex.IsMatch(category.Pattern, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant))
                aimlCategoryList.Add(category);
            }
          }
        }
        this.toolStripProgressBar.Visible = false;
        this.categoryCollectionLister.Categories = aimlCategoryList;
      }
    }

    private void toolStripButtonRefresh_Click(object sender, EventArgs e)
    {
      this.NeuBerechnen();
    }

    private void ucBesteSRAIZiele_Resize(object sender, EventArgs e)
    {
      this.dataGridViewBesteSRAIs.Top = this.toolStripTop.Top + this.toolStripTop.Height;
      this.dataGridViewBesteSRAIs.Left = 0;
      this.dataGridViewBesteSRAIs.Height = this.ClientSize.Height - this.toolStripTop.Top - this.toolStripTop.Height;
      this.dataGridViewBesteSRAIs.Width = this.ClientSize.Width / 3;
      this.ResizeAll();
      this.categoryCollectionLister.Top = this.toolStripTop.Top + this.toolStripTop.Height;
      this.categoryCollectionLister.Left = this.dataGridViewBesteSRAIs.Left + this.dataGridViewBesteSRAIs.Width;
      this.categoryCollectionLister.Height = this.ClientSize.Height - this.toolStripTop.Top - this.toolStripTop.Height;
      this.categoryCollectionLister.Width = this.ClientSize.Width - this.dataGridViewBesteSRAIs.Width;
    }

    private void ResizeAll()
    {
      int num1 = this.dataGridViewBesteSRAIs.ClientSize.Width - 3;
      if (this.dataGridViewBesteSRAIs.Columns.Count != 2)
        return;
      this.dataGridViewBesteSRAIs.Columns[0].Width = 40;
      int num2 = num1 - this.dataGridViewBesteSRAIs.Columns[0].Width;
      this.dataGridViewBesteSRAIs.Columns[1].Width = num2;
      int num3 = num2 - this.dataGridViewBesteSRAIs.Columns[1].Width;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ucMeisteSRAIs));
      this.toolStripTop = new ToolStrip();
      this.toolStripButtonRefresh = new ToolStripButton();
      this.toolStripProgressBar = new ToolStripProgressBar();
      this.dataGridViewBesteSRAIs = new DataGridView();
      this.categoryCollectionLister = new CategoryCollectionLister();
      this.toolStripTop.SuspendLayout();
      ((ISupportInitialize) this.dataGridViewBesteSRAIs).BeginInit();
      this.SuspendLayout();
      this.toolStripTop.Items.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.toolStripButtonRefresh,
        (ToolStripItem) this.toolStripProgressBar
      });
      componentResourceManager.ApplyResources((object) this.toolStripTop, "toolStripTop");
      this.toolStripTop.Name = "toolStripTop";
      this.toolStripButtonRefresh.Image = (Image) Resources.sync;
      componentResourceManager.ApplyResources((object) this.toolStripButtonRefresh, "toolStripButtonRefresh");
      this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
      this.toolStripButtonRefresh.Click += new EventHandler(this.toolStripButtonRefresh_Click);
      this.toolStripProgressBar.Name = "toolStripProgressBar";
      componentResourceManager.ApplyResources((object) this.toolStripProgressBar, "toolStripProgressBar");
      this.dataGridViewBesteSRAIs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      componentResourceManager.ApplyResources((object) this.dataGridViewBesteSRAIs, "dataGridViewBesteSRAIs");
      this.dataGridViewBesteSRAIs.Name = "dataGridViewBesteSRAIs";
      componentResourceManager.ApplyResources((object) this.categoryCollectionLister, "categoryCollectionLister");
      this.categoryCollectionLister.Name = "categoryCollectionLister";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.categoryCollectionLister);
      this.Controls.Add((Control) this.dataGridViewBesteSRAIs);
      this.Controls.Add((Control) this.toolStripTop);
      this.Name = nameof (ucMeisteSRAIs);
      this.Load += new EventHandler(this.ucBesteSRAIZiele_Load);
      this.toolStripTop.ResumeLayout(false);
      this.toolStripTop.PerformLayout();
      ((ISupportInitialize) this.dataGridViewBesteSRAIs).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
