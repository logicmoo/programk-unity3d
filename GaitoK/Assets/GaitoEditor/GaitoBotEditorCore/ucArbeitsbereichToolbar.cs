// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.ucArbeitsbereichToolbar
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using GaitoBotEditorCore.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GaitoBotEditorCore
{
  public class ucArbeitsbereichToolbar : UserControl
  {
    private IContainer components = (IContainer) null;
    private Arbeitsbereich _arbeitsbereich;
    private ToolStrip toolStrip1;
    private ToolStripButton toolStripButtonSaveAll;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton toolStripButtonExport;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripTextBox toolStripTextBoxSearch;
    private ToolStripButton toolStripButtonSearch;
    private ToolStripSeparator toolStripSeparator3;
    private ToolStripSplitButton toolStripSplitButtonTest;
    private ToolStripMenuItem manuellerTestToolStripMenuItem;
    private ToolStripMenuItem automatischeTestsToolStripMenuItem;
    private ToolStripSeparator toolStripSeparator4;
    private ToolStripButton toolStripButtonUmbenennen;
    private Timer timerAkualisieren;
    private ToolStripSeparator toolStripSeparator5;
    private ToolStripButton toolStripButtonHistoryBack;
    private ToolStripButton toolStripButtonHistoryForward;
    private ToolStripButton toolStripButtonPublish;

    public event EventHandler ExportAnzeigen;

    protected virtual void ExportAnzeigenEvent()
    {
      if (this.ExportAnzeigen == null)
        return;
      this.ExportAnzeigen((object) this, EventArgs.Empty);
    }

    public event EventHandler PublizierenAnzeigen;

    protected virtual void PublizierenAnzeigenEvent()
    {
      if (this.PublizierenAnzeigen == null)
        return;
      this.PublizierenAnzeigen((object) this, EventArgs.Empty);
    }

    public event EventHandler ManuellenTestAnzeigen;

    protected virtual void ManuellenTestAnzeigenEvent()
    {
      if (this.ManuellenTestAnzeigen == null)
        return;
      this.ManuellenTestAnzeigen((object) this, EventArgs.Empty);
    }

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Dieser Arbeitsbereich-Toolbar wurde bereits ein Arbeitsbereich zugeordnet");
        this._arbeitsbereich = value;
        this._arbeitsbereich.Verlauf.Changed += new EventHandler(this.Verlauf_Changed);
        this.Aktualisieren();
      }
    }

    public ucArbeitsbereichToolbar()
    {
      this.InitializeComponent();
      this.Load += new EventHandler(this.ucArbeitsbereich_Load);
    }

    private void ucArbeitsbereich_Load(object sender, EventArgs e)
    {
      if (ToolboxSonstiges.IstEntwicklungsmodus)
        this.automatischeTestsToolStripMenuItem.Visible = false;
      this.toolStripTextBoxSearch.TextChanged += new EventHandler(this.toolStripTextBoxSearch_TextChanged);
      this.toolStripTextBoxSearch.KeyDown += new KeyEventHandler(this.toolStripTextBoxSearch_KeyDown);
      this.toolStripButtonSearch.Enabled = false;
      this.SteuerElementeBeschriften();
      this.Aktualisieren();
    }

    private void Verlauf_Changed(object sender, EventArgs e)
    {
      this.Aktualisieren();
    }

    private void toolStripTextBoxSearch_TextChanged(object sender, EventArgs e)
    {
      if (this.toolStripTextBoxSearch.Text == null || this.toolStripTextBoxSearch.Text.Trim() == "")
        this.toolStripButtonSearch.Enabled = false;
      else
        this.toolStripButtonSearch.Enabled = true;
    }

    private void timerAkualisieren_Tick(object sender, EventArgs e)
    {
      this.Aktualisieren();
    }

    private void Aktualisieren()
    {
      if (this._arbeitsbereich == null)
      {
        this.Enabled = false;
      }
      else
      {
        this.Enabled = true;
        this.toolStripButtonSaveAll.Enabled = this._arbeitsbereich.Dateiverwaltung.DateienIsChanged;
        this.toolStripButtonHistoryBack.Enabled = this._arbeitsbereich.Verlauf.ZurueckVerfuegbar;
        this.toolStripButtonHistoryForward.Enabled = this._arbeitsbereich.Verlauf.VorwaertsVerfuegbar;
      }
    }

    private void SteuerElementeBeschriften()
    {
      this.toolStripButtonSaveAll.Text = ResReader.Reader.GetString("toolStripButtonSaveAll");
      this.toolStripButtonPublish.Text = ResReader.Reader.GetString("toolStripButtonPublish");
      this.toolStripButtonExport.Text = ResReader.Reader.GetString("toolStripButtonExport");
      this.toolStripButtonSearch.Text = ResReader.Reader.GetString("toolStripButtonSearch");
      this.toolStripSplitButtonTest.Text = ResReader.Reader.GetString("toolStripSplitButtonTest");
      this.manuellerTestToolStripMenuItem.Text = ResReader.Reader.GetString("manuellerTestToolStripMenuItem");
      this.automatischeTestsToolStripMenuItem.Text = ResReader.Reader.GetString("automatischeTestsToolStripMenuItem");
      this.toolStripButtonUmbenennen.Text = ResReader.Reader.GetString("toolStripButtonUmbenennen");
      this.toolStripButtonUmbenennen.ToolTipText = ResReader.Reader.GetString("ArbeitsbereichUmbenennen");
      this.toolStripButtonHistoryBack.Text = ResReader.Reader.GetString("toolStripButtonHistoryBack");
      this.toolStripButtonHistoryForward.Text = ResReader.Reader.GetString("toolStripButtonHistoryForward");
    }

    private void toolStripButtonSaveAll_Click(object sender, EventArgs e)
    {
      if (this._arbeitsbereich != null)
        this._arbeitsbereich.SaveAll();
      this.Aktualisieren();
    }

    private void toolStripButtonExport_Click(object sender, EventArgs e)
    {
      this.ExportAnzeigenEvent();
    }

    private void toolStripButtonPublish_Click(object sender, EventArgs e)
    {
      this.PublizierenAnzeigenEvent();
    }

    private void toolStripSplitButtonTest_ButtonClick(object sender, EventArgs e)
    {
      this.ManuellenTestAnzeigenEvent();
    }

    private void manuellerTestToolStripMenuItem_Click(object sender, EventArgs e)
    {
      this.ManuellenTestAnzeigenEvent();
    }

    private void automatischeTestsToolStripMenuItem_Click(object sender, EventArgs e)
    {
    }

    private void toolStripButtonUmbenennen_Click(object sender, EventArgs e)
    {
      if (this._arbeitsbereich == null)
        return;
      bool abgebrochen = false;
      string str = InputBox.Show(ResReader.Reader.GetString("BitteNeuenNamenFuerArbeitsbereich"), ResReader.Reader.GetString("ArbeitsbereichUmbenennen"), this._arbeitsbereich.Name, out abgebrochen);
      if (abgebrochen)
        return;
      this._arbeitsbereich.Name = str;
    }

    private void toolStripButtonSearch_Click(object sender, EventArgs e)
    {
      this._arbeitsbereich.Suchen(this.toolStripTextBoxSearch.Text, Arbeitsbereich.WoSuchenOrte.ImArbeitsbereich);
    }

    private void toolStripTextBoxSearch_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.KeyCode != Keys.Return)
        return;
      this._arbeitsbereich.Suchen(this.toolStripTextBoxSearch.Text, Arbeitsbereich.WoSuchenOrte.ImArbeitsbereich);
    }

    private void toolStripButtonHistoryBack_Click(object sender, EventArgs e)
    {
      if (this._arbeitsbereich == null)
        return;
      this._arbeitsbereich.Verlauf.Zurueck();
    }

    private void toolStripButtonHistoryForward_Click(object sender, EventArgs e)
    {
      if (this._arbeitsbereich == null)
        return;
      this._arbeitsbereich.Verlauf.Vorwaerts();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ucArbeitsbereichToolbar));
      this.toolStrip1 = new ToolStrip();
      this.toolStripButtonSaveAll = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.toolStripButtonPublish = new ToolStripButton();
      this.toolStripButtonExport = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.toolStripSplitButtonTest = new ToolStripSplitButton();
      this.manuellerTestToolStripMenuItem = new ToolStripMenuItem();
      this.automatischeTestsToolStripMenuItem = new ToolStripMenuItem();
      this.toolStripSeparator3 = new ToolStripSeparator();
      this.toolStripTextBoxSearch = new ToolStripTextBox();
      this.toolStripButtonSearch = new ToolStripButton();
      this.toolStripSeparator4 = new ToolStripSeparator();
      this.toolStripButtonUmbenennen = new ToolStripButton();
      this.toolStripSeparator5 = new ToolStripSeparator();
      this.toolStripButtonHistoryBack = new ToolStripButton();
      this.toolStripButtonHistoryForward = new ToolStripButton();
      this.timerAkualisieren = new Timer(this.components);
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      this.toolStrip1.Items.AddRange(new ToolStripItem[14]
      {
        (ToolStripItem) this.toolStripButtonSaveAll,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.toolStripButtonPublish,
        (ToolStripItem) this.toolStripButtonExport,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.toolStripSplitButtonTest,
        (ToolStripItem) this.toolStripSeparator3,
        (ToolStripItem) this.toolStripTextBoxSearch,
        (ToolStripItem) this.toolStripButtonSearch,
        (ToolStripItem) this.toolStripSeparator4,
        (ToolStripItem) this.toolStripButtonUmbenennen,
        (ToolStripItem) this.toolStripSeparator5,
        (ToolStripItem) this.toolStripButtonHistoryBack,
        (ToolStripItem) this.toolStripButtonHistoryForward
      });
      componentResourceManager.ApplyResources((object) this.toolStrip1, "toolStrip1");
      this.toolStrip1.Name = "toolStrip1";
      this.toolStripButtonSaveAll.Image = (Image) Resources.save_16;
      componentResourceManager.ApplyResources((object) this.toolStripButtonSaveAll, "toolStripButtonSaveAll");
      this.toolStripButtonSaveAll.Name = "toolStripButtonSaveAll";
      this.toolStripButtonSaveAll.Click += new EventHandler(this.toolStripButtonSaveAll_Click);
      this.toolStripSeparator1.Margin = new Padding(2, 0, 2, 0);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator1, "toolStripSeparator1");
      this.toolStripButtonPublish.Image = (Image) Resources.Globe;
      componentResourceManager.ApplyResources((object) this.toolStripButtonPublish, "toolStripButtonPublish");
      this.toolStripButtonPublish.Name = "toolStripButtonPublish";
      this.toolStripButtonPublish.Click += new EventHandler(this.toolStripButtonPublish_Click);
      this.toolStripButtonExport.Image = (Image) Resources.redo_16;
      componentResourceManager.ApplyResources((object) this.toolStripButtonExport, "toolStripButtonExport");
      this.toolStripButtonExport.Name = "toolStripButtonExport";
      this.toolStripButtonExport.Click += new EventHandler(this.toolStripButtonExport_Click);
      this.toolStripSeparator2.Margin = new Padding(2, 0, 2, 0);
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator2, "toolStripSeparator2");
      this.toolStripSplitButtonTest.DropDownItems.AddRange(new ToolStripItem[2]
      {
        (ToolStripItem) this.manuellerTestToolStripMenuItem,
        (ToolStripItem) this.automatischeTestsToolStripMenuItem
      });
      this.toolStripSplitButtonTest.Image = (Image) Resources.applications_16;
      componentResourceManager.ApplyResources((object) this.toolStripSplitButtonTest, "toolStripSplitButtonTest");
      this.toolStripSplitButtonTest.Name = "toolStripSplitButtonTest";
      this.toolStripSplitButtonTest.ButtonClick += new EventHandler(this.toolStripSplitButtonTest_ButtonClick);
      this.manuellerTestToolStripMenuItem.Name = "manuellerTestToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.manuellerTestToolStripMenuItem, "manuellerTestToolStripMenuItem");
      this.manuellerTestToolStripMenuItem.Click += new EventHandler(this.manuellerTestToolStripMenuItem_Click);
      this.automatischeTestsToolStripMenuItem.Name = "automatischeTestsToolStripMenuItem";
      componentResourceManager.ApplyResources((object) this.automatischeTestsToolStripMenuItem, "automatischeTestsToolStripMenuItem");
      this.automatischeTestsToolStripMenuItem.Click += new EventHandler(this.automatischeTestsToolStripMenuItem_Click);
      this.toolStripSeparator3.Margin = new Padding(2, 0, 2, 0);
      this.toolStripSeparator3.Name = "toolStripSeparator3";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator3, "toolStripSeparator3");
      this.toolStripTextBoxSearch.Name = "toolStripTextBoxSearch";
      componentResourceManager.ApplyResources((object) this.toolStripTextBoxSearch, "toolStripTextBoxSearch");
      this.toolStripButtonSearch.DisplayStyle = ToolStripItemDisplayStyle.Text;
      componentResourceManager.ApplyResources((object) this.toolStripButtonSearch, "toolStripButtonSearch");
      this.toolStripButtonSearch.Name = "toolStripButtonSearch";
      this.toolStripButtonSearch.Click += new EventHandler(this.toolStripButtonSearch_Click);
      this.toolStripSeparator4.Margin = new Padding(2, 0, 2, 0);
      this.toolStripSeparator4.Name = "toolStripSeparator4";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator4, "toolStripSeparator4");
      this.toolStripButtonUmbenennen.Image = (Image) Resources.rename1;
      componentResourceManager.ApplyResources((object) this.toolStripButtonUmbenennen, "toolStripButtonUmbenennen");
      this.toolStripButtonUmbenennen.Name = "toolStripButtonUmbenennen";
      this.toolStripButtonUmbenennen.Click += new EventHandler(this.toolStripButtonUmbenennen_Click);
      this.toolStripSeparator5.Name = "toolStripSeparator5";
      componentResourceManager.ApplyResources((object) this.toolStripSeparator5, "toolStripSeparator5");
      this.toolStripButtonHistoryBack.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonHistoryBack.Image = (Image) Resources.arrow_back_16;
      componentResourceManager.ApplyResources((object) this.toolStripButtonHistoryBack, "toolStripButtonHistoryBack");
      this.toolStripButtonHistoryBack.Name = "toolStripButtonHistoryBack";
      this.toolStripButtonHistoryBack.Click += new EventHandler(this.toolStripButtonHistoryBack_Click);
      this.toolStripButtonHistoryForward.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonHistoryForward.Image = (Image) Resources.arrow_forward_16;
      componentResourceManager.ApplyResources((object) this.toolStripButtonHistoryForward, "toolStripButtonHistoryForward");
      this.toolStripButtonHistoryForward.Name = "toolStripButtonHistoryForward";
      this.toolStripButtonHistoryForward.Click += new EventHandler(this.toolStripButtonHistoryForward_Click);
      this.timerAkualisieren.Enabled = true;
      this.timerAkualisieren.Interval = 2000;
      this.timerAkualisieren.Tick += new EventHandler(this.timerAkualisieren_Tick);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.toolStrip1);
      this.Name = nameof (ucArbeitsbereichToolbar);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
