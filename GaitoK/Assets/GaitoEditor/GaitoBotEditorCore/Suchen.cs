// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.Suchen
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GaitoBotEditorCore
{
  public class Suchen : UserControl
  {
    private IContainer components = (IContainer) null;
    private Arbeitsbereich _arbeitsbereich;
    private bool _sucheLaeuft;
    private ArrayList _treffer;
    private string _titel;
    private string _wonachGesucht;
    private Arbeitsbereich.WoSuchenOrte _woGesucht;
    private ToolStrip toolStripSuchen;
    private ToolStripTextBox txtboxSucheingabe;
    private ToolStripProgressBar toolStripProgressBarSuchen;
    private ToolStripSplitButton toolStripSplitButtonSucheImArbeitsbereich;
    private ToolStripMenuItem searchInActualAimlfileToolStripMenuItem;
    private ToolStripMenuItem searchInActualTopicToolStripMenuItem;
    private DataGridView dataGridViewTrefferliste;

    private string SuchBeschreibung
    {
      get
      {
        if (this._wonachGesucht == null)
          return ResReader.Reader.GetString("NochKeineSucheAusgefuehrt");
        return string.Format(ResReader.Reader.GetString("SucheNachIn"), (object) this._wonachGesucht, (object) Arbeitsbereich.WoSuchenOrt2Name(this._woGesucht));
      }
    }

    public event Suchen.SuchTitelChangedEventHandler SuchTitelChanged;

    protected virtual void SuchTitelChangedEvent(string titel)
    {
      if (this.SuchTitelChanged == null)
        return;
      this.SuchTitelChanged((object) this, new Suchen.SuchTitelChangedEventArgs(titel));
    }

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Diesem SuchControl wurde bereits ein Arbeitsbereich zugeordnet");
        this._arbeitsbereich = value;
        this._arbeitsbereich.SucheImArbeitsbereich += new Arbeitsbereich.SucheImArbeitsbereichEventHandler(this._arbeitsbereich_SucheImArbeitsbereich);
      }
    }

    public string Titel
    {
      get
      {
        return this._titel;
      }
      set
      {
        bool flag = this._titel != value;
        this._titel = value;
        if (!flag)
          return;
        this.SuchTitelChangedEvent(this._titel);
      }
    }

    public Suchen()
    {
      this.InitializeComponent();
      this.dataGridViewTrefferliste.Columns.Add(ResReader.Reader.GetString("SuchenCellAIMLDatei"), ResReader.Reader.GetString("SuchenCellAIMLDatei"));
      this.dataGridViewTrefferliste.Columns.Add(ResReader.Reader.GetString("SuchenCellAIMLDateiThema"), ResReader.Reader.GetString("SuchenCellAIMLDateiThema"));
      this.dataGridViewTrefferliste.Columns.Add(ResReader.Reader.GetString("SuchenCellAIMLCategory"), ResReader.Reader.GetString("SuchenCellAIMLCategory"));
      this.dataGridViewTrefferliste.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dataGridViewTrefferliste.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
      this.dataGridViewTrefferliste.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
    }

    private void Suchen_Load(object sender, EventArgs e)
    {
      this.SteuerElementeBeschriften();
      this.SucheFertig();
      this.dataGridViewTrefferliste.AllowUserToAddRows = false;
      this.dataGridViewTrefferliste.AllowUserToResizeColumns = false;
      this.dataGridViewTrefferliste.AllowUserToResizeRows = false;
      this.dataGridViewTrefferliste.RowHeadersVisible = false;
      this.dataGridViewTrefferliste.MultiSelect = false;
      this.dataGridViewTrefferliste.ScrollBars = ScrollBars.Both;
      this.dataGridViewTrefferliste.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
      this.dataGridViewTrefferliste.Scroll += new ScrollEventHandler(this.dataGridViewTrefferliste_Scroll);
      this.dataGridViewTrefferliste.SelectionChanged += new EventHandler(this.dataGridViewTrefferliste_SelectionChanged);
      this.txtboxSucheingabe.KeyDown += new KeyEventHandler(this.txtboxSucheingabe_KeyDown);
      this.Resize += new EventHandler(this.Suchen_Resize);
      this.ResizeAll();
    }

    private void Suchen_Resize(object sender, EventArgs e)
    {
      this.ResizeAll();
    }

    private void txtboxSucheingabe_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this.SucheStarten(this.txtboxSucheingabe.Text, Arbeitsbereich.WoSuchenOrte.ImArbeitsbereich);
    }

    private void ResizeAll()
    {
      this.dataGridViewTrefferliste.Top = this.toolStripSuchen.Top + this.toolStripSuchen.Height;
      this.dataGridViewTrefferliste.Left = 0;
      this.dataGridViewTrefferliste.Height = this.ClientSize.Height - this.dataGridViewTrefferliste.Top;
      this.dataGridViewTrefferliste.Width = this.ClientSize.Width;
      int num1 = this.dataGridViewTrefferliste.ClientSize.Width - 3;
      int num2 = num1;
      if (this.dataGridViewTrefferliste.Columns.Count == 3)
      {
        this.dataGridViewTrefferliste.Columns[0].Width = num1 / 7;
        int num3 = num2 - this.dataGridViewTrefferliste.Columns[0].Width;
        this.dataGridViewTrefferliste.Columns[1].Width = num1 / 7;
        this.dataGridViewTrefferliste.Columns[2].Width = num3 - this.dataGridViewTrefferliste.Columns[1].Width;
      }
      this.ZeilenInhalteRefreshen();
    }

    private void _arbeitsbereich_SucheImArbeitsbereich(
      object sender,
      Arbeitsbereich.SucheImArbeitsbereichEventArgs e)
    {
      this.txtboxSucheingabe.Text = e.SuchEingabe;
      this.SucheStarten(e.SuchEingabe, e.WoSuchen);
    }

    private void SucheStarten(string suchEingabe, Arbeitsbereich.WoSuchenOrte woSuchen)
    {
      if (this._sucheLaeuft)
      {
        this.SuchFehlerZeigen(ResReader.Reader.GetString("EsLaeuftBereitsEineSuche"));
      }
      else
      {
        this.Titel = this.SuchBeschreibung;
        if (!this.IstSuchEingabeGueltig(suchEingabe))
          return;
        this._sucheLaeuft = true;
        this._wonachGesucht = suchEingabe.Trim();
        this._woGesucht = woSuchen;
        this.toolStripProgressBarSuchen.Value = 0;
        this.toolStripProgressBarSuchen.Maximum = this._arbeitsbereich.Dateiverwaltung.AlleAimlDateien.Count;
        this.toolStripProgressBarSuchen.Visible = false;
        this.toolStripSuchen.Enabled = false;
        this.dataGridViewTrefferliste.Visible = false;
        this._treffer = new ArrayList();
        switch (woSuchen)
        {
          case Arbeitsbereich.WoSuchenOrte.ImArbeitsbereich:
            this.ArbeitsbereichDurchsuchen(this._arbeitsbereich, suchEingabe);
            break;
          case Arbeitsbereich.WoSuchenOrte.InAktuellerAIMLDatei:
            if (this._arbeitsbereich.Fokus.AktDatei is AIMLDatei)
            {
              this.AIMLDateiDurchsuchen((AIMLDatei) this._arbeitsbereich.Fokus.AktDatei, suchEingabe);
              break;
            }
            break;
          case Arbeitsbereich.WoSuchenOrte.InAktuellemTopic:
            this.AIMLTopicDurchsuchen(this._arbeitsbereich.Fokus.AktAIMLTopic, suchEingabe);
            break;
          default:
            throw new ApplicationException("Unbekannter Suchort " + (object) woSuchen + "!");
        }
        this.SucheFertig();
      }
    }

    private void SucheFertig()
    {
      this.toolStripProgressBarSuchen.Visible = false;
      this.toolStripSuchen.Enabled = true;
      int num;
      if (this._treffer == null || this._treffer.Count == 0)
      {
        num = 0;
        this.dataGridViewTrefferliste.Visible = false;
      }
      else
      {
        num = this._treffer.Count;
        this.dataGridViewTrefferliste.Rows.Clear();
        this.dataGridViewTrefferliste.Rows.Add(this._treffer.Count);
        this.dataGridViewTrefferliste.Visible = true;
        this.ResizeAll();
        this.ZeilenInhalteRefreshen();
      }
      this.Titel = string.Format(ResReader.Reader.GetString("SuchTitelMitTreffer"), (object) this.SuchBeschreibung, (object) num);
      this._sucheLaeuft = false;
    }

    private void ZeilenInhalteRefreshen()
    {
      if (this._treffer == null || this._treffer.Count == 0)
        return;
      int scrollingRowIndex = this.dataGridViewTrefferliste.FirstDisplayedScrollingRowIndex;
      int val1 = scrollingRowIndex + this.dataGridViewTrefferliste.DisplayedRowCount(true);
      int num1 = Math.Max(0, scrollingRowIndex);
      int num2 = Math.Min(val1, this._treffer.Count);
      for (int index = num1; index < num2; ++index)
      {
        if (this._treffer[index] is AIMLCategory)
        {
          AIMLCategory aimlCategory = (AIMLCategory) this._treffer[index];
          this.dataGridViewTrefferliste.Rows[index].Cells[0].Value = (object) aimlCategory.AIMLTopic.AIMLDatei.Titel;
          this.dataGridViewTrefferliste.Rows[index].Cells[1].Value = (object) aimlCategory.AIMLTopic.Name;
          this.dataGridViewTrefferliste.Rows[index].Cells[2].Value = (object) aimlCategory.AutoKomplettZusammenfassung;
        }
      }
      Application.DoEvents();
    }

    private bool IstSuchEingabeGueltig(string suchEingabe)
    {
      if (suchEingabe == null)
      {
        this.SuchFehlerZeigen(string.Format(ResReader.Reader.GetString("UngueltigeSuchEingabe"), (object) ""));
        return false;
      }
      suchEingabe = suchEingabe.Trim();
      if (suchEingabe == "")
      {
        this.SuchFehlerZeigen(string.Format(ResReader.Reader.GetString("UngueltigeSuchEingabe"), (object) ""));
        return false;
      }
      try
      {
        if ("hallo test test".IndexOf(suchEingabe, StringComparison.OrdinalIgnoreCase) != -1)
          ;
      }
      catch (Exception ex)
      {
        this.SuchFehlerZeigen(string.Format(ResReader.Reader.GetString("UngueltigeSuchEingabe"), (object) suchEingabe));
        return false;
      }
      return true;
    }

    private void SuchFehlerZeigen(string fehler)
    {
      int num = (int) MessageBox.Show(fehler);
      Debugger.GlobalDebugger.Protokolliere("Suchfehler:" + fehler);
    }

    private void ArbeitsbereichDurchsuchen(Arbeitsbereich arbeitsbereich, string suchEingabe)
    {
      if (arbeitsbereich == null)
        return;
      foreach (IArbeitsbereichDatei arbeitsbereichDatei in arbeitsbereich.Dateiverwaltung.Dateien)
      {
        if (arbeitsbereichDatei is AIMLDatei)
          this.AIMLDateiDurchsuchen((AIMLDatei) arbeitsbereichDatei, suchEingabe);
      }
    }

    private void AIMLDateiDurchsuchen(AIMLDatei datei, string suchEingabe)
    {
      if (datei == null)
        return;
      try
      {
        ++this.toolStripProgressBarSuchen.Value;
      }
      catch (Exception ex)
      {
      }
      Application.DoEvents();
      foreach (AIMLTopic topic in datei.getTopics())
        this.AIMLTopicDurchsuchen(topic, suchEingabe);
    }

    private void AIMLTopicDurchsuchen(AIMLTopic topic, string suchEingabe)
    {
      if (topic == null)
        return;
      foreach (AIMLCategory category in topic.Categories)
        this.AIMLCategoryDurchsuchen(category, suchEingabe);
    }

    private void AIMLCategoryDurchsuchen(AIMLCategory category, string suchEingabe)
    {
      try
      {
        if (category.ContentNode.InnerXml.IndexOf(suchEingabe, StringComparison.OrdinalIgnoreCase) == -1)
          return;
        this._treffer.Add((object) category);
      }
      catch (Exception ex)
      {
      }
    }

    private void SteuerElementeBeschriften()
    {
      this.toolStripSplitButtonSucheImArbeitsbereich.Text = ResReader.Reader.GetString("toolStripSplitButtonSucheImArbeitsbereich");
      this.searchInActualAimlfileToolStripMenuItem.Text = ResReader.Reader.GetString("searchInActualAimlfileToolStripMenuItem");
      this.searchInActualTopicToolStripMenuItem.Text = ResReader.Reader.GetString("searchInActualTopicToolStripMenuItem");
    }

    private void dataGridViewTrefferliste_SelectionChanged(object sender, EventArgs e)
    {
      if (this._treffer == null || this._treffer.Count == 0 || this.dataGridViewTrefferliste.SelectedRows.Count != 1)
        return;
      int index = this.dataGridViewTrefferliste.SelectedRows[0].Index;
      if (index > this._treffer.Count - 1)
        return;
      if (this._treffer[index] is AIMLCategory)
        this._arbeitsbereich.Fokus.AktAIMLCategory = (AIMLCategory) this._treffer[index];
      Application.DoEvents();
    }

    private void dataGridViewTrefferliste_Scroll(object sender, ScrollEventArgs e)
    {
      this.ZeilenInhalteRefreshen();
    }

    private void toolStripSplitButtonSucheImArbeitsbereich_ButtonClick(object sender, EventArgs e)
    {
      this.SucheStarten(this.txtboxSucheingabe.Text, Arbeitsbereich.WoSuchenOrte.ImArbeitsbereich);
    }

    private void searchInActualAimlfileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SucheStarten(this.txtboxSucheingabe.Text, Arbeitsbereich.WoSuchenOrte.InAktuellerAIMLDatei);
    }

    private void searchInActualTopicToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.SucheStarten(this.txtboxSucheingabe.Text, Arbeitsbereich.WoSuchenOrte.InAktuellemTopic);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Suchen));
      this.toolStripSuchen = new ToolStrip();
      this.txtboxSucheingabe = new ToolStripTextBox();
      this.toolStripSplitButtonSucheImArbeitsbereich = new ToolStripSplitButton();
      this.searchInActualAimlfileToolStripMenuItem = new ToolStripMenuItem();
      this.searchInActualTopicToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripProgressBarSuchen = new ToolStripProgressBar();
      this.dataGridViewTrefferliste = new DataGridView();
      this.toolStripSuchen.SuspendLayout();
      ((ISupportInitialize) this.dataGridViewTrefferliste).BeginInit();
      this.SuspendLayout();
      this.toolStripSuchen.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.txtboxSucheingabe,
        (ToolStripItem) this.toolStripSplitButtonSucheImArbeitsbereich,
        (ToolStripItem) this.toolStripProgressBarSuchen
      });
      componentResourceManager.ApplyResources((object) this.toolStripSuchen, "toolStripSuchen");
      this.toolStripSuchen.Name = "toolStripSuchen";
      this.txtboxSucheingabe.Name = "txtboxSucheingabe";
      componentResourceManager.ApplyResources((object) this.txtboxSucheingabe, "txtboxSucheingabe");
      this.toolStripSplitButtonSucheImArbeitsbereich.DisplayStyle = ToolStripItemDisplayStyle.Text;
      this.toolStripSplitButtonSucheImArbeitsbereich.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.searchInActualAimlfileToolStripMenuItem,
        (ToolStripItem) this.searchInActualTopicToolStripMenuItem
      });
      componentResourceManager.ApplyResources((object) this.toolStripSplitButtonSucheImArbeitsbereich, "toolStripSplitButtonSucheImArbeitsbereich");
      this.toolStripSplitButtonSucheImArbeitsbereich.Name = "toolStripSplitButtonSucheImArbeitsbereich";
      this.toolStripSplitButtonSucheImArbeitsbereich.ButtonClick += new EventHandler(this.toolStripSplitButtonSucheImArbeitsbereich_ButtonClick);
      this.searchInActualAimlfileToolStripMenuItem.Name = "searchInActualAimlfileToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.searchInActualAimlfileToolStripMenuItem, "searchInActualAimlfileToolStripMenuItem");
      this.searchInActualAimlfileToolStripMenuItem.Click += new EventHandler(this.searchInActualAimlfileToolStripMenuItem_Click);
      this.searchInActualTopicToolStripMenuItem.Name = "searchInActualTopicToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.searchInActualTopicToolStripMenuItem, "searchInActualTopicToolStripMenuItem");
      this.searchInActualTopicToolStripMenuItem.Click += new EventHandler(this.searchInActualTopicToolStripMenuItem_Click);
      this.toolStripProgressBarSuchen.ForeColor = Color.FromArgb(128, 128, (int) byte.MaxValue);
      this.toolStripProgressBarSuchen.Name = "toolStripProgressBarSuchen";
      componentResourceManager.ApplyResources((object) this.toolStripProgressBarSuchen, "toolStripProgressBarSuchen");
      this.toolStripProgressBarSuchen.Value = 50;
      this.dataGridViewTrefferliste.AllowUserToAddRows = false;
      this.dataGridViewTrefferliste.AllowUserToDeleteRows = false;
      this.dataGridViewTrefferliste.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      componentResourceManager.ApplyResources((object) this.dataGridViewTrefferliste, "dataGridViewTrefferliste");
      this.dataGridViewTrefferliste.Name = "dataGridViewTrefferliste";
      this.dataGridViewTrefferliste.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.dataGridViewTrefferliste);
      this.Controls.Add((Control) this.toolStripSuchen);
      this.Name = nameof (Suchen);
      this.Load += new EventHandler(this.Suchen_Load);
      this.toolStripSuchen.ResumeLayout(false);
      this.toolStripSuchen.PerformLayout();
      ((ISupportInitialize) this.dataGridViewTrefferliste).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public class SuchTitelChangedEventArgs : EventArgs
    {
      public string Titel;

      public SuchTitelChangedEventArgs(string titel)
      {
        this.Titel = titel;
      }
    }

    public delegate void SuchTitelChangedEventHandler(
      object sender,
      Suchen.SuchTitelChangedEventArgs e);
  }
}
