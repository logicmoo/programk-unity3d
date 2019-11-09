// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.controls.ucWorkflowToolbar
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using GaitoBotEditorCore.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GaitoBotEditorCore.controls
{
  public class ucWorkflowToolbar : UserControl
  {
    private IContainer components = (IContainer) null;
    private const int _bisAnzahlAutofresh = 3000;
    private const int _bisAnzahlAutoSync = 5000;
    private Arbeitsbereich _arbeitsbereich;
    private AIMLCategory _aktSyncCategory;
    private Timer timerRefresh;
    private ToolStripButton toolStripButtonSyncronisieren;
    private ToolStrip toolStripTop;

    public event EventHandler AnzeigeRefreshen;

    protected virtual void AnzeigeRefreshenEvent()
    {
      if (this.AnzeigeRefreshen == null)
        return;
      this.AnzeigeRefreshen((object) this, EventArgs.Empty);
    }

    public event ucWorkflowToolbar.SyncCategoryAngewaehltEventHandler SyncCategoryAngewaehlt;

    protected virtual void SyncCategoryAngewaehltEvent(AIMLCategory category)
    {
      if (this.SyncCategoryAngewaehlt == null)
        return;
      this.SyncCategoryAngewaehlt((object) this, new ucWorkflowToolbar.SyncCategoryAngewaehltEventArgs(category));
    }

    public AIMLCategory AktSyncCategory
    {
      get
      {
        return this._aktSyncCategory;
      }
    }

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Dieser Workflow-Toolbar wurde bereits ein Arbeitsbereich zugewiesen");
        this._arbeitsbereich = value;
        this._arbeitsbereich.Fokus.AktAIMLCategoryChanged += new EventHandler<EventArgs<AIMLCategory>>(this.Fokus_AktAIMLCategoryChanged);
      }
    }

    public ucWorkflowToolbar()
    {
      this.InitializeComponent();
      this.Load += new EventHandler(this.ucWorkflowToolbar_Load);
    }

    private void ucWorkflowToolbar_Load(object sender, EventArgs e)
    {
      this.toolStripButtonSyncronisieren.Text = GaitoBotEditorCore.ResReader.Reader.GetString("toolStripButtonSyncronisieren");
    }

    private void toolStripButtonSyncronisieren_Click(object sender, EventArgs e)
    {
      this._aktSyncCategory = this._arbeitsbereich.Fokus.AktAIMLCategory;
      this.SyncCategoryAngewaehltEvent(this._aktSyncCategory);
    }

    private void Fokus_AktAIMLCategoryChanged(object sender, EventArgs<AIMLCategory> e)
    {
      if (this._arbeitsbereich == null || this._arbeitsbereich.AnzahlKategorien >= 5000)
        return;
      this._aktSyncCategory = e.Value;
      this.SyncCategoryAngewaehltEvent(this._aktSyncCategory);
    }

    private void timerRefresh_Tick(object sender, EventArgs e)
    {
      if (this._arbeitsbereich != null)
      {
        if (this._arbeitsbereich.AnzahlKategorien < 3000)
          this.AnzeigeRefreshenEvent();
        this.toolStripButtonSyncronisieren.Enabled = this._arbeitsbereich.AnzahlKategorien > 3000;
      }
      else
        this.toolStripButtonSyncronisieren.Enabled = false;
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ucWorkflowToolbar));
      this.timerRefresh = new Timer(this.components);
      this.toolStripButtonSyncronisieren = new ToolStripButton();
      this.toolStripTop = new ToolStrip();
      this.toolStripTop.SuspendLayout();
      this.SuspendLayout();
      this.timerRefresh.Enabled = true;
      this.timerRefresh.Interval = 3000;
      this.timerRefresh.Tick += new EventHandler(this.timerRefresh_Tick);
      this.toolStripButtonSyncronisieren.Image = (Image) Resources.sync;
      componentResourceManager.ApplyResources((object) this.toolStripButtonSyncronisieren, "toolStripButtonSyncronisieren");
      this.toolStripButtonSyncronisieren.Name = "toolStripButtonSyncronisieren";
      this.toolStripButtonSyncronisieren.Click += new EventHandler(this.toolStripButtonSyncronisieren_Click);
      componentResourceManager.ApplyResources((object) this.toolStripTop, "toolStripTop");
      this.toolStripTop.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripButtonSyncronisieren
      });
      this.toolStripTop.Name = "toolStripTop";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.toolStripTop);
      this.Name = nameof (ucWorkflowToolbar);
      this.toolStripTop.ResumeLayout(false);
      this.toolStripTop.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public class SyncCategoryAngewaehltEventArgs : EventArgs
    {
      public AIMLCategory Category;

      public SyncCategoryAngewaehltEventArgs(AIMLCategory category)
      {
        this.Category = category;
      }
    }

    public delegate void SyncCategoryAngewaehltEventHandler(
      object sender,
      ucWorkflowToolbar.SyncCategoryAngewaehltEventArgs e);
  }
}
