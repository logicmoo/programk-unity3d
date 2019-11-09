// Decompiled with JetBrains decompiler
// Type: GaitoBotEditor.SpracheAuswaehlen
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using GaitoBotEditor.Properties;
using GaitoBotEditorCore;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GaitoBotEditor
{
  public class SpracheAuswaehlen : Form
  {
    private IContainer components = (IContainer) null;
    private Button buttonDeutschSprache;
    private Button buttonSpracheEnglisch;

    public SpracheAuswaehlen()
    {
      this.InitializeComponent();
    }

    private void buttonDeutschSprache_Click(object sender, EventArgs e)
    {
      Config.GlobalConfig.ProgrammSprache = "de";
      this.Starten();
    }

    private void buttonSpracheEnglisch_Click(object sender, EventArgs e)
    {
      Config.GlobalConfig.ProgrammSprache = "en";
      this.Starten();
    }

    private void Starten()
    {
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (SpracheAuswaehlen));
      this.buttonSpracheEnglisch = new Button();
      this.buttonDeutschSprache = new Button();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.buttonSpracheEnglisch, "buttonSpracheEnglisch");
      this.buttonSpracheEnglisch.Image = (Image) Resources.United_Kingdom;
      this.buttonSpracheEnglisch.Name = "buttonSpracheEnglisch";
      this.buttonSpracheEnglisch.UseVisualStyleBackColor = true;
      this.buttonSpracheEnglisch.Click += new EventHandler(this.buttonSpracheEnglisch_Click);
      this.buttonDeutschSprache.Image = (Image) Resources.Germany;
      componentResourceManager.ApplyResources((object) this.buttonDeutschSprache, "buttonDeutschSprache");
      this.buttonDeutschSprache.Name = "buttonDeutschSprache";
      this.buttonDeutschSprache.UseVisualStyleBackColor = true;
      this.buttonDeutschSprache.Click += new EventHandler(this.buttonDeutschSprache_Click);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.ControlBox = false;
      this.Controls.Add((Control) this.buttonSpracheEnglisch);
      this.Controls.Add((Control) this.buttonDeutschSprache);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (SpracheAuswaehlen);
      this.ResumeLayout(false);
    }
  }
}
