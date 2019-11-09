// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.controls.ucWorkflowScrollbox
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GaitoBotEditorCore.controls
{
  public class ucWorkflowScrollbox : UserControl
  {
    private IContainer components = (IContainer) null;
    private Arbeitsbereich _arbeitsbereich;
    private ucWorkflow ucWorkflow;

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Dieser WorkflowScrollbox wurde bereits ein Arbeitsbereich zugewiesen");
        this._arbeitsbereich = value;
        this.ucWorkflow.Arbeitsbereich = this._arbeitsbereich;
      }
    }

    public AIMLCategory Category
    {
      get
      {
        return this.ucWorkflow.Category;
      }
      set
      {
        this.ucWorkflow.Category = value;
      }
    }

    public ucWorkflowScrollbox()
    {
      this.InitializeComponent();
    }

    private void ucWorkflowScrollbox_Load(object sender, EventArgs e)
    {
      this.BackColor = Color.White;
    }

    public void RefreshAnzeige()
    {
      this.ucWorkflow.RefreshAnzeige();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ucWorkflowScrollbox));
      this.ucWorkflow = new ucWorkflow();
      this.SuspendLayout();
      this.ucWorkflow.BackColor = Color.FromArgb((int) byte.MaxValue, 192, 192);
      this.ucWorkflow.Category = (AIMLCategory) null;
      componentResourceManager.ApplyResources((object) this.ucWorkflow, "ucWorkflow");
      this.ucWorkflow.Name = "ucWorkflow";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb(192, (int) byte.MaxValue, 192);
      this.Controls.Add((Control) this.ucWorkflow);
      this.Name = nameof (ucWorkflowScrollbox);
      this.Load += new EventHandler(this.ucWorkflowScrollbox_Load);
      this.ResumeLayout(false);
    }
  }
}
