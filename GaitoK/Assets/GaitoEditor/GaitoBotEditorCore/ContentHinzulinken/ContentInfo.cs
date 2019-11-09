// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.ContentHinzulinken.ContentInfo
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.gaitobot.content;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GaitoBotEditorCore.ContentHinzulinken
{
  public class ContentInfo : UserControl
  {
    private IContainer components = (IContainer) null;
    private ContentElementInfo _info;
    private CheckBox checkBox1;
    private Label label1;

    public event EventHandler GewaehltChanged;

    public ContentElementInfo Info
    {
      set
      {
        this.label1.Text = value.Beschreibung;
        this.checkBox1.Text = value.Name;
        this._info = value;
      }
      get
      {
        return this._info;
      }
    }

    public bool WahlEnabled
    {
      get
      {
        return this.checkBox1.Enabled;
      }
      set
      {
        this.checkBox1.Enabled = value;
      }
    }

    public bool Gewaehlt
    {
      get
      {
        return this.checkBox1.Checked;
      }
      set
      {
        this.checkBox1.Checked = value;
      }
    }

    public ContentInfo()
    {
      this.InitializeComponent();
      this.checkBox1.CheckedChanged += new EventHandler(this.checkBox1_CheckedChanged);
      this.Resize += new EventHandler(this.ContentInfo_Resize);
    }

    private void ContentInfo_Resize(object sender, EventArgs e)
    {
      this.label1.Width = this.Width - 20;
    }

    private void checkBox1_CheckedChanged(object sender, EventArgs e)
    {
      if (this.GewaehltChanged == null)
        return;
      this.GewaehltChanged((object) this, EventArgs.Empty);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ContentInfo));
      this.checkBox1 = new CheckBox();
      this.label1 = new Label();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.checkBox1, "checkBox1");
      this.checkBox1.Name = "checkBox1";
      this.checkBox1.UseVisualStyleBackColor = true;
      this.label1.AutoEllipsis = true;
      componentResourceManager.ApplyResources((object) this.label1, "label1");
      this.label1.Name = "label1";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.label1);
      this.Controls.Add((Control) this.checkBox1);
      this.Name = nameof (ContentInfo);
      this.ResumeLayout(false);
    }
  }
}
