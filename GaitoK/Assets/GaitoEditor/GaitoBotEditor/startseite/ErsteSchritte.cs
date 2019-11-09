// Decompiled with JetBrains decompiler
// Type: GaitoBotEditor.startseite.ErsteSchritte
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using GaitoBotEditorCore;
using MultiLang;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GaitoBotEditor.startseite
{
  public class ErsteSchritte : UserControl
  {
    private IContainer components = (IContainer) null;
    private WebBrowser webBrowserErsteSchritte;
    private Label labelTitelErsteSchritte;

    private string ErsteSchritteFehlerSeiteTitel
    {
      get
      {
        return ml.ml_string(49, "Kann erste Schritte nicht laden");
      }
    }

    private string ErsteSchritteFehlerSeiteInhalt
    {
      get
      {
        return string.Format("<p><b>{0}</b></p><p>{1}</p>", (object) ml.ml_string(49, "Kann erste Schritte nicht laden"), (object) ml.ml_string(48, "Bitte prüfen Sie Ihre Internetverbindung und stellen Sie sicher, dass das Programm nicht durch eine Firewall blockiert wird."));
      }
    }

    public ErsteSchritte()
    {
      this.InitializeComponent();
      this.webBrowserErsteSchritte.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.webBrowserErsteSchritte_DocumentCompleted);
      this.webBrowserErsteSchritte.WebBrowserShortcutsEnabled = false;
      this.webBrowserErsteSchritte.IsWebBrowserContextMenuEnabled = false;
    }

    public void Anzeigen()
    {
      this.webBrowserErsteSchritte.DocumentText = ml.ml_string(50, "Erste Schritte werden geladen");
      this.webBrowserErsteSchritte.Navigate(Config.GlobalConfig.URLErsteSchritte);
    }

    private void webBrowserErsteSchritte_DocumentCompleted(
      object sender,
      WebBrowserDocumentCompletedEventArgs e)
    {
      if (this.webBrowserErsteSchritte.Url.AbsoluteUri == "about:blank" || this.webBrowserErsteSchritte.DocumentTitle == this.ErsteSchritteFehlerSeiteTitel || this.webBrowserErsteSchritte.DocumentTitle.Contains("GAITO"))
        return;
      this.webBrowserErsteSchritte.DocumentText = this.ErsteSchritteFehlerSeiteInhalt;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ErsteSchritte));
      this.webBrowserErsteSchritte = new WebBrowser();
      this.labelTitelErsteSchritte = new Label();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.webBrowserErsteSchritte, "webBrowserErsteSchritte");
      this.webBrowserErsteSchritte.MinimumSize = new Size(20, 20);
      this.webBrowserErsteSchritte.Name = "webBrowserErsteSchritte";
      componentResourceManager.ApplyResources((object) this.labelTitelErsteSchritte, "labelTitelErsteSchritte");
      this.labelTitelErsteSchritte.BackColor = Color.WhiteSmoke;
      this.labelTitelErsteSchritte.Name = "labelTitelErsteSchritte";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.LightSteelBlue;
      this.Controls.Add((Control) this.labelTitelErsteSchritte);
      this.Controls.Add((Control) this.webBrowserErsteSchritte);
      this.Name = nameof (ErsteSchritte);
      this.ResumeLayout(false);
    }
  }
}
