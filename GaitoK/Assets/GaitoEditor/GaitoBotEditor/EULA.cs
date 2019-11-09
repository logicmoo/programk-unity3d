// Decompiled with JetBrains decompiler
// Type: GaitoBotEditor.EULA
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GaitoBotEditor
{
  public class EULA : Form
  {
    private IContainer components = (IContainer) null;
    private bool _bestaetigt;
    private bool _darfSchliessen;
    private WebBrowser webBrowserEULA;
    private Button buttonDrucken;
    private Button buttonAkzeptieren;
    private Button buttonAblehnen;

    public bool DarfSchliessen
    {
      set
      {
        this._darfSchliessen = value;
      }
    }

    public bool Bestaetigt
    {
      get
      {
        return this._bestaetigt;
      }
    }

    public EULA()
    {
      this.InitializeComponent();
    }

    private void EULA_Load(object sender, EventArgs e)
    {
      this.webBrowserEULA.DocumentText = ResReader.Reader.GetString(nameof (EULA));
      this.webBrowserEULA.AllowNavigation = false;
      this.webBrowserEULA.IsWebBrowserContextMenuEnabled = false;
      this.FormClosing += new FormClosingEventHandler(this.EULA_FormClosing);
    }

    private void buttonAblehnen_Click(object sender, EventArgs e)
    {
      this.Hide();
    }

    private void buttonAkzeptieren_Click(object sender, EventArgs e)
    {
      this._bestaetigt = true;
      this.Hide();
    }

    private void buttonDrucken_Click(object sender, EventArgs e)
    {
      this.webBrowserEULA.Print();
    }

    private void EULA_FormClosing(object sender, FormClosingEventArgs e)
    {
      if (this._darfSchliessen)
        return;
      this.Hide();
      e.Cancel = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (EULA));
      this.webBrowserEULA = new WebBrowser();
      this.buttonDrucken = new Button();
      this.buttonAkzeptieren = new Button();
      this.buttonAblehnen = new Button();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.webBrowserEULA, "webBrowserEULA");
      this.webBrowserEULA.MinimumSize = new Size(20, 20);
      this.webBrowserEULA.Name = "webBrowserEULA";
      componentResourceManager.ApplyResources((object) this.buttonDrucken, "buttonDrucken");
      this.buttonDrucken.Name = "buttonDrucken";
      this.buttonDrucken.UseVisualStyleBackColor = true;
      this.buttonDrucken.Click += new EventHandler(this.buttonDrucken_Click);
      componentResourceManager.ApplyResources((object) this.buttonAkzeptieren, "buttonAkzeptieren");
      this.buttonAkzeptieren.Name = "buttonAkzeptieren";
      this.buttonAkzeptieren.UseVisualStyleBackColor = true;
      this.buttonAkzeptieren.Click += new EventHandler(this.buttonAkzeptieren_Click);
      componentResourceManager.ApplyResources((object) this.buttonAblehnen, "buttonAblehnen");
      this.buttonAblehnen.DialogResult = DialogResult.Cancel;
      this.buttonAblehnen.Name = "buttonAblehnen";
      this.buttonAblehnen.UseVisualStyleBackColor = true;
      this.buttonAblehnen.Click += new EventHandler(this.buttonAblehnen_Click);
      this.AcceptButton = (IButtonControl) this.buttonAblehnen;
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.CancelButton = (IButtonControl) this.buttonAblehnen;
      this.Controls.Add((Control) this.buttonAblehnen);
      this.Controls.Add((Control) this.buttonAkzeptieren);
      this.Controls.Add((Control) this.buttonDrucken);
      this.Controls.Add((Control) this.webBrowserEULA);
      this.Name = nameof (EULA);
      this.Load += new EventHandler(this.EULA_Load);
      this.ResumeLayout(false);
    }
  }
}
