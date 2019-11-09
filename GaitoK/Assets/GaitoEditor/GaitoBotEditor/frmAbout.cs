// Decompiled with JetBrains decompiler
// Type: GaitoBotEditor.frmAbout
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using GaitoBotEditorCore;
using MultiLang;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GaitoBotEditor
{
  public class frmAbout : Form
  {
    private IContainer components = (IContainer) null;
    private Label labelUeberschrift;
    private Button buttonOk;
    private TextBox textBoxInhalt;

    public frmAbout()
    {
      this.InitializeComponent();
      this.Load += new EventHandler(this.frmAbout_Load);
    }

    private void frmAbout_Load(object sender, EventArgs e)
    {
      this.Text = string.Format(ml.ml_string(61, "über {0}"), (object) LizenzManager.ProgrammName);
      this.labelUeberschrift.Text = string.Format("{0} {1} V{2}", (object) LizenzManager.ProgrammName, (object) LizenzManager.ProgrammLizenzName, (object) LizenzManager.ProgrammVersionNummerAnzeige);
      StringBuilder stringBuilder = new StringBuilder();
      switch (LizenzManager.Lizenz)
      {
        case LizenzManager.LizenzArten.Betaversion:
        case LizenzManager.LizenzArten.Standard:
          stringBuilder.Append(ResReader.Reader.GetString("about"));
          this.textBoxInhalt.Text = stringBuilder.ToString();
          break;
        default:
          stringBuilder.Append("\r\n");
          stringBuilder.AppendFormat(ml.ml_string(52, "Lizenziert für: {0}"), (object) LizenzManager.LizenziertAuf);
          stringBuilder.Append("\r\n");
          stringBuilder.Append("\r\n");
          goto case LizenzManager.LizenzArten.Betaversion;
      }
    }

    private void buttonOk_Click(object sender, EventArgs e)
    {
      this.Close();
      this.Dispose();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmAbout));
      this.labelUeberschrift = new Label();
      this.buttonOk = new Button();
      this.textBoxInhalt = new TextBox();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.labelUeberschrift, "labelUeberschrift");
      this.labelUeberschrift.Name = "labelUeberschrift";
      componentResourceManager.ApplyResources((object) this.buttonOk, "buttonOk");
      this.buttonOk.BackColor = SystemColors.Control;
      this.buttonOk.Name = "buttonOk";
      this.buttonOk.UseVisualStyleBackColor = false;
      this.buttonOk.Click += new EventHandler(this.buttonOk_Click);
      componentResourceManager.ApplyResources((object) this.textBoxInhalt, "textBoxInhalt");
      this.textBoxInhalt.BackColor = Color.White;
      this.textBoxInhalt.BorderStyle = BorderStyle.None;
      this.textBoxInhalt.Name = "textBoxInhalt";
      this.textBoxInhalt.ReadOnly = true;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.Controls.Add((Control) this.textBoxInhalt);
      this.Controls.Add((Control) this.buttonOk);
      this.Controls.Add((Control) this.labelUeberschrift);
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmAbout);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
