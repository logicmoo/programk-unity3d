// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.frmFeedback
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace de.springwald.toolbox
{
  public class frmFeedback : Form
  {
    private IContainer components = (IContainer) null;
    private WebBrowser webBrowserSenden;

    public frmFeedback()
    {
      this.InitializeComponent();
      this.Load += new EventHandler(this.frmFeedback_Load);
    }

    private void frmFeedback_Load(object sender, EventArgs e)
    {
      this.Text = ResReader.Reader.GetString("FeedbackFormular");
      this.webBrowserSenden.WebBrowserShortcutsEnabled = false;
      this.webBrowserSenden.ScriptErrorsSuppressed = false;
      this.webBrowserSenden.IsWebBrowserContextMenuEnabled = false;
    }

    public void ZeigeFeedbackFormular(string feedbackmailAdresse, string feedbackWebScript)
    {
      this.UeberBrowserAnzeigen(feedbackmailAdresse, feedbackWebScript);
      this.Show();
    }

    private void UeberBrowserAnzeigen(string feedbackmailAdresse, string feedbackWebScript)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<html><head><title>feedback</title>");
      stringBuilder.Append("<body>");
      stringBuilder.AppendFormat("<p STYLE=\"font-family: Arial; font-size: 13px\">{0}</p>", (object) string.Format(ResReader.Reader.GetString("BitteGebenSieIhrFeedbackEin"), (object) feedbackmailAdresse));
      stringBuilder.AppendFormat("<form METHOD=\"POST\" ACTION=\"{0}\">", (object) feedbackWebScript);
      stringBuilder.Append("<TABLE BORDER=\"0\" CELLSPACING=\"5\" CELLPADDING=\"0\"><TR><TD>");
      stringBuilder.AppendFormat("<P STYLE=\"font-family: Arial; font-size: 13px\">{0}:<br>", (object) ResReader.Reader.GetString("IhrNameOptional"));
      stringBuilder.Append("<INPUT TYPE=\"TEXT\" SIZE=\"30\" TYPE=\"HIDDEN\" NAME=\"name\" >");
      stringBuilder.Append("</TD><TD>");
      stringBuilder.AppendFormat("<P STYLE=\"font-family: Arial; font-size: 13px\">{0}:<br>", (object) ResReader.Reader.GetString("IhreEmailOptional"));
      stringBuilder.Append("<INPUT TYPE=\"TEXT\" SIZE=\"30\" TYPE=\"HIDDEN\" NAME=\"email\" >");
      stringBuilder.Append("</TD></TR></TABLE>");
      stringBuilder.AppendFormat("<P STYLE=\"font-family: Arial; font-size: 13px\">{0}:<br>", (object) ResReader.Reader.GetString("IhrFeedback"));
      stringBuilder.Append("<TEXTAREA NAME=\"feedbacktext\" STYLE=\"width: 100%; height: 100px; font-family: Arial; font-size: 12px\"></TEXTAREA></p>");
      stringBuilder.AppendFormat("<INPUT TYPE=\"HIDDEN\" NAME=\"betreff\" VALUE=\"Feedback for {0}\">", (object) (Application.ProductName + " " + Application.ProductVersion));
      stringBuilder.AppendFormat("<INPUT TYPE=\"HIDDEN\" NAME=\"danke\" VALUE=\"{0}\">", (object) ResReader.Reader.GetString("DankeFuerIhrFeedback"));
      stringBuilder.AppendFormat("<P STYLE=\"font-family: Arial; font-size: 13px\"><INPUT TYPE=\"SUBMIT\" NAME=\"Submit1\" VALUE=\"{0}\"></P>", (object) ResReader.Reader.GetString("absenden"));
      stringBuilder.Append("</form>");
      stringBuilder.Append("</body></html>");
      this.webBrowserSenden.DocumentText = stringBuilder.ToString();
    }

    private void frmFehlerReport_Load(object sender, EventArgs e)
    {
      this.Text = ResReader.Reader.GetString("AnwendungsFehler");
      this.webBrowserSenden.WebBrowserShortcutsEnabled = false;
      this.webBrowserSenden.ScriptErrorsSuppressed = false;
      this.webBrowserSenden.IsWebBrowserContextMenuEnabled = false;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmFeedback));
      this.webBrowserSenden = new WebBrowser();
      this.SuspendLayout();
      this.webBrowserSenden.Dock = DockStyle.Fill;
      this.webBrowserSenden.Location = new Point(0, 0);
      this.webBrowserSenden.MinimumSize = new Size(20, 20);
      this.webBrowserSenden.Name = "webBrowserSenden";
      this.webBrowserSenden.ScrollBarsEnabled = false;
      this.webBrowserSenden.Size = new Size(592, 423);
      this.webBrowserSenden.TabIndex = 0;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.White;
      this.ClientSize = new Size(592, 423);
      this.Controls.Add((Control) this.webBrowserSenden);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmFeedback);
      this.Text = nameof (frmFeedback);
      this.ResumeLayout(false);
    }
  }
}
