// Decompiled with JetBrains decompiler
// Type: GaitoBotEditor.frmSplashScreen
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using GaitoBotEditor.Properties;
using GaitoBotEditorCore;
using MultiLang;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GaitoBotEditor
{
  public class frmSplashScreen : Form
  {
    private int _warteAusblenden = 200;
    private int _opacity = 100;
    private IContainer components = (IContainer) null;
    private Label labelOben;
    private Label labelLizenzArt;
    private Timer timerAusblenden;
    private Label labelLizenziertFuer;

    public frmSplashScreen()
    {
      this.InitializeComponent();
      this.Load += new EventHandler(this.frmSplashScreen_Load);
    }

    private void Anzeigen()
    {
      this.labelLizenzArt.Text = LizenzManager.ProgrammLizenzName;
      switch (LizenzManager.Lizenz)
      {
        case LizenzManager.LizenzArten.Betaversion:
        case LizenzManager.LizenzArten.Standard:
          this.labelLizenziertFuer.Visible = false;
          break;
        default:
          this.labelLizenziertFuer.Text = string.Format(ml.ml_string(52, "Lizenziert für: {0}"), (object) LizenzManager.LizenziertAuf);
          break;
      }
      this.labelOben.Text = string.Format(ml.ml_string(53, "version {0}"), (object) LizenzManager.ProgrammVersionNummerAnzeige);
    }

    private void timerAusblenden_Tick(object sender, EventArgs e)
    {
      if (this._warteAusblenden > 0)
      {
        --this._warteAusblenden;
      }
      else
      {
        this._opacity -= 4;
        if (this._opacity <= 0)
        {
          this.Close();
          this.Dispose();
        }
        else
          this.Opacity = (double) this._opacity / 100.0;
      }
    }

    private void frmSplashScreen_Load(object sender, EventArgs e)
    {
      this.Anzeigen();
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmSplashScreen));
      this.labelOben = new Label();
      this.labelLizenzArt = new Label();
      this.timerAusblenden = new Timer(this.components);
      this.labelLizenziertFuer = new Label();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.labelOben, "labelOben");
      this.labelOben.Name = "labelOben";
      componentResourceManager.ApplyResources((object) this.labelLizenzArt, "labelLizenzArt");
      this.labelLizenzArt.Name = "labelLizenzArt";
      this.timerAusblenden.Enabled = true;
      this.timerAusblenden.Interval = 10;
      this.timerAusblenden.Tick += new EventHandler(this.timerAusblenden_Tick);
      componentResourceManager.ApplyResources((object) this.labelLizenziertFuer, "labelLizenziertFuer");
      this.labelLizenziertFuer.Name = "labelLizenziertFuer";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.BackgroundImage = (Image) Resources.splashScreen;
      this.ControlBox = false;
      this.Controls.Add((Control) this.labelLizenziertFuer);
      this.Controls.Add((Control) this.labelLizenzArt);
      this.Controls.Add((Control) this.labelOben);
      this.FormBorderStyle = FormBorderStyle.None;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmSplashScreen);
      this.ShowInTaskbar = false;
      this.TopMost = true;
      this.ResumeLayout(false);
    }
  }
}
