// Decompiled with JetBrains decompiler
// Type: GaitoBotEditor.AktuelleNachrichten
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using GaitoBotEditorCore;
using MultiLang;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GaitoBotEditor
{
  public class AktuelleNachrichten : UserControl
  {
    private IContainer components = (IContainer) null;
    private WebBrowser webBrowserAktInfo;
    private Label labelTitelAktuelleNachrichten;

    private string NewsFehlerSeiteTitel
    {
      get
      {
        return ml.ml_string(57, "Kann aktuelle News nicht laden");
      }
    }

    private string NewsFehlerSeiteInhalt
    {
      get
      {
        return string.Format("<p><b>{0}</b></p><p>{1}</p>", (object) ml.ml_string(57, "Kann aktuelle News nicht laden"), (object) ml.ml_string(48, "Bitte prüfen Sie Ihre Internetverbindung und stellen Sie sicher, dass das Programm nicht durch eine Firewall blockiert wird."));
      }
    }

    public AktuelleNachrichten()
    {
      this.InitializeComponent();
      this.webBrowserAktInfo.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.webBrowserAktInfo_DocumentCompleted);
      this.webBrowserAktInfo.WebBrowserShortcutsEnabled = false;
      this.webBrowserAktInfo.IsWebBrowserContextMenuEnabled = false;
    }

    public void Anzeigen()
    {
      this.webBrowserAktInfo.DocumentText = ml.ml_string(56, "News werden geladen...");
      this.webBrowserAktInfo.Navigate(Config.GlobalConfig.URLAktuelleInformationen);
    }

    private void webBrowserAktInfo_DocumentCompleted(
      object sender,
      WebBrowserDocumentCompletedEventArgs e)
    {
      if (this.webBrowserAktInfo.Url.AbsoluteUri == "about:blank" || this.webBrowserAktInfo.DocumentTitle == this.NewsFehlerSeiteTitel || this.webBrowserAktInfo.DocumentTitle.ToLower().Contains("gaito"))
        return;
      this.webBrowserAktInfo.DocumentText = this.NewsFehlerSeiteInhalt;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (AktuelleNachrichten));
      this.webBrowserAktInfo = new WebBrowser();
      this.labelTitelAktuelleNachrichten = new Label();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.webBrowserAktInfo, "webBrowserAktInfo");
      this.webBrowserAktInfo.MinimumSize = new Size(20, 20);
      this.webBrowserAktInfo.Name = "webBrowserAktInfo";
      componentResourceManager.ApplyResources((object) this.labelTitelAktuelleNachrichten, "labelTitelAktuelleNachrichten");
      this.labelTitelAktuelleNachrichten.BackColor = Color.WhiteSmoke;
      this.labelTitelAktuelleNachrichten.Name = "labelTitelAktuelleNachrichten";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LightSteelBlue;
      this.Controls.Add((Control) this.labelTitelAktuelleNachrichten);
      this.Controls.Add((Control) this.webBrowserAktInfo);
      this.Name = nameof (AktuelleNachrichten);
      this.ResumeLayout(false);
    }
  }
}
