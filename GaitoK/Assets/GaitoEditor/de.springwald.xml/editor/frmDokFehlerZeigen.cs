// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.frmDokFehlerZeigen
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace de.springwald.xml.editor
{
  public class frmDokFehlerZeigen : Form
  {
    private Container components = (Container) null;
    private ucXMLQuellcodeViewer ucXMLQuellcodeViewer;
    private Splitter splitter1;
    private ucXMLQuellCodeFehlerliste ucXMLQuellCodeFehlerliste;

    public frmDokFehlerZeigen()
    {
      this.InitializeComponent();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (frmDokFehlerZeigen));
      this.ucXMLQuellCodeFehlerliste = new ucXMLQuellCodeFehlerliste();
      this.ucXMLQuellcodeViewer = new ucXMLQuellcodeViewer();
      this.splitter1 = new Splitter();
      this.SuspendLayout();
      this.ucXMLQuellCodeFehlerliste.Dock = DockStyle.Left;
      this.ucXMLQuellCodeFehlerliste.Location = new Point(0, 0);
      this.ucXMLQuellCodeFehlerliste.Name = "ucXMLQuellCodeFehlerliste";
      this.ucXMLQuellCodeFehlerliste.Size = new Size(352, 357);
      this.ucXMLQuellCodeFehlerliste.TabIndex = 0;
      this.ucXMLQuellcodeViewer.BackColor = SystemColors.Control;
      this.ucXMLQuellcodeViewer.Dock = DockStyle.Fill;
      this.ucXMLQuellcodeViewer.Location = new Point(352, 0);
      this.ucXMLQuellcodeViewer.Name = "ucXMLQuellcodeViewer";
      this.ucXMLQuellcodeViewer.Size = new Size(240, 357);
      this.ucXMLQuellcodeViewer.TabIndex = 1;
      this.splitter1.Location = new Point(352, 0);
      this.splitter1.Name = "splitter1";
      this.splitter1.Size = new Size(3, 357);
      this.splitter1.TabIndex = 2;
      this.splitter1.TabStop = false;
      this.AutoScaleBaseSize = new Size(5, 13);
      this.ClientSize = new Size(592, 357);
      this.Controls.Add((Control) this.splitter1);
      this.Controls.Add((Control) this.ucXMLQuellcodeViewer);
      this.Controls.Add((Control) this.ucXMLQuellCodeFehlerliste);
      this.Icon = (Icon) componentResourceManager.GetObject("$this.Icon");
      this.Name = nameof (frmDokFehlerZeigen);
      this.StartPosition = FormStartPosition.CenterScreen;
      this.Text = nameof (frmDokFehlerZeigen);
      this.WindowState = FormWindowState.Maximized;
      this.Load += new EventHandler(this.frmDokFehlerZeigen_Load);
      this.ResumeLayout(false);
    }

    private void frmDokFehlerZeigen_Load(object sender, EventArgs e)
    {
      this.Text = ResReader.Reader.GetString("QuellcodeFehleranzeige");
    }

    public void Anzeigen(string xMLQuellCodeAlsRTF, string fehlerProtokollAlsText)
    {
      this.ucXMLQuellcodeViewer.XMLCodeAlsRTF = xMLQuellCodeAlsRTF;
      this.ucXMLQuellCodeFehlerliste.FehlerProtokollAlsText = fehlerProtokollAlsText;
    }
  }
}
