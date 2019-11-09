// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.frmFehlerReport
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
  public class frmFehlerReport : Form
  {
    private IContainer components = (IContainer) null;
    private WebBrowser webBrowserSenden;

    public string ProgrammVersionNummerAnzeige
    {
      get
      {
        Version version = new Version(Application.ProductVersion);
        return string.Format("{0}.{1} B{2}", (object) version.Major, (object) version.Minor, (object) version.Build);
      }
    }

    public frmFehlerReport()
    {
      this.InitializeComponent();
    }

    public void ZeigeFehler(
      Exception e,
      string additiveMeldung,
      string supportEmailAdresse,
      string supportWebScript)
    {
      string str1 = "-----------------------------------------------\r\n";
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(str1);
      stringBuilder.Append("Exception:\r\n");
      stringBuilder.AppendFormat(">Message:  {0}\r\n", (object) e.Message);
      stringBuilder.Append(str1);
      stringBuilder.AppendFormat(">Source:  {0}\r\n", (object) e.Source);
      stringBuilder.Append(str1);
      stringBuilder.AppendFormat(">StackTrace:  {0}\r\n", (object) e.StackTrace);
      stringBuilder.Append(str1);
      if (e.InnerException != null)
      {
        stringBuilder.Append("InnerException:\r\n");
        stringBuilder.AppendFormat(">Message:  {0}\r\n", (object) e.InnerException.Message);
        stringBuilder.Append(str1);
        stringBuilder.AppendFormat(">Source:  {0}\r\n", (object) e.InnerException.Source);
        stringBuilder.Append(str1);
        stringBuilder.AppendFormat(">StackTrace:  {0}\r\n", (object) e.InnerException.StackTrace);
        stringBuilder.Append(str1);
      }
      stringBuilder.Append(str1);
      stringBuilder.Append("Program:\r\n");
      stringBuilder.AppendFormat(">Version:  {0}\r\n", (object) this.ProgrammVersionNummerAnzeige);
      stringBuilder.AppendFormat(">VersionInternal:  {0}\r\n", (object) Application.ProductVersion);
      stringBuilder.AppendFormat(">Name:  {0}\r\n", (object) Application.ProductName);
      stringBuilder.AppendFormat(">CommonAppDataPath:  {0}\r\n", (object) Application.CommonAppDataPath);
      try
      {
        stringBuilder.AppendFormat(">CommonAppDataRegistry:  {0}\r\n", (object) Application.CommonAppDataRegistry);
      }
      catch (Exception ex)
      {
      }
      stringBuilder.AppendFormat(">CurrentCulture:  {0}\r\n", (object) Application.CurrentCulture);
      stringBuilder.AppendFormat(">CurrentInputLanguage:  {0}\r\n", (object) Application.CurrentInputLanguage);
      stringBuilder.AppendFormat(">ExecutablePath:  {0}\r\n", (object) Application.ExecutablePath);
      stringBuilder.AppendFormat(">LocalUserAppDataPath:  {0}\r\n", (object) Application.LocalUserAppDataPath);
      stringBuilder.AppendFormat(">StartupPath:  {0}\r\n", (object) Application.StartupPath);
      stringBuilder.AppendFormat(">UserAppDataPath:  {0}\r\n", (object) Application.UserAppDataPath);
      stringBuilder.AppendFormat(">UserAppDataRegistry:  {0}\r\n", (object) Application.UserAppDataRegistry);
      stringBuilder.Append(str1);
      stringBuilder.Append("Debug-Log:\r\n");
      string str2 = "";
      try
      {
        if (Debugger.GlobalDebugger.ProtokollDateiname != null)
        {
          Debugger.GlobalDebugger.ProtokollDateiSchliessen();
          str2 = ToolboxStrings.File2String(Debugger.GlobalDebugger.ProtokollDateiname);
        }
      }
      catch (Exception ex)
      {
      }
      stringBuilder.Append(str2);
      stringBuilder.Append(str1);
      if (additiveMeldung != null && additiveMeldung != "")
      {
        stringBuilder.Append(str1);
        stringBuilder.Append(additiveMeldung);
        stringBuilder.Append(str1);
      }
      this.UeberBrowserAnzeigen(stringBuilder.ToString(), supportEmailAdresse, supportWebScript);
      this.Show();
    }

    private void UeberBrowserAnzeigen(
      string meldung,
      string supportEmailAdresse,
      string supportWebScript)
    {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append("<html><head><title>error report</title>");
      stringBuilder.Append("<body>");
      stringBuilder.AppendFormat("<p STYLE=\"font-family: Arial; font-size: 13px\">{0}</p>", (object) string.Format(ResReader.Reader.GetString("EinFehlerIstAufgetretenProgrammWirdBeendet"), (object) supportEmailAdresse));
      stringBuilder.AppendFormat("<form METHOD=\"POST\" ACTION=\"{0}\">", (object) supportWebScript);
      stringBuilder.AppendFormat("<P STYLE=\"font-family: Arial; font-size: 13px\"><INPUT TYPE=\"SUBMIT\" NAME=\"Submit1\" VALUE=\"{0}\"></P>", (object) ResReader.Reader.GetString("FehlerMelden"));
      stringBuilder.AppendFormat("<P STYLE=\"font-family: Arial; font-size: 13px\">{0}:<br>", (object) ResReader.Reader.GetString("WasHabenSieGetan"));
      stringBuilder.Append("<TEXTAREA NAME=\"wasgetan\" STYLE=\"width: 100%; height: 50px; font-family: Arial; font-size: 10px\"></TEXTAREA></p>");
      stringBuilder.AppendFormat("<P STYLE=\"font-family: Arial; font-size: 13px\">{0}:<br>", (object) ResReader.Reader.GetString("DetailierteFehlermeldung"));
      stringBuilder.AppendFormat("<TEXTAREA NAME=\"fehlermeldung\" STYLE=\"width: 100%; height: 100px; font-family: Arial; font-size: 10px\">{0}</TEXTAREA></p>", (object) meldung);
      stringBuilder.AppendFormat("<INPUT TYPE=\"HIDDEN\" NAME=\"betreff\" VALUE=\"Error Report {0}\">", (object) (Application.ProductName + " " + Application.ProductVersion));
      stringBuilder.AppendFormat("<INPUT TYPE=\"HIDDEN\" NAME=\"danke\" VALUE=\"{0}\">", (object) ResReader.Reader.GetString("DankeFuerIhreFehlermeldung"));
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmFehlerReport));
      this.webBrowserSenden = new WebBrowser();
      this.SuspendLayout();
      this.webBrowserSenden.Dock = DockStyle.Fill;
      this.webBrowserSenden.Location = new Point(0, 0);
      this.webBrowserSenden.MinimumSize = new Size(20, 20);
      this.webBrowserSenden.Name = "webBrowserSenden";
      this.webBrowserSenden.ScrollBarsEnabled = false;
      this.webBrowserSenden.Size = new Size(592, 423);
      this.webBrowserSenden.TabIndex = 5;
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = SystemColors.Control;
      this.ClientSize = new Size(592, 423);
      this.Controls.Add((Control) this.webBrowserSenden);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (frmFehlerReport);
      this.StartPosition = FormStartPosition.CenterParent;
      this.Text = nameof (frmFehlerReport);
      this.TopMost = true;
      this.Load += new EventHandler(this.frmFehlerReport_Load);
      this.ResumeLayout(false);
    }
  }
}
