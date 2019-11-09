// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.ucXMLQuellcodeDebugger
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.xml.Properties;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace de.springwald.xml.editor
{
  public class ucXMLQuellcodeDebugger : UserControl
  {
    private ucXMLQuellcodeViewer ucXMLQuellcodeViewer;
    private ucXMLQuellCodeFehlerliste ucXMLQuellCodeFehlerliste;
    private ToolStrip toolStripTop;
    private ToolStripButton toolStripButtonAktualisieren;
    private IContainer components;
    private XMLEditor _xmlEditor;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.toolStripTop = new ToolStrip();
      this.toolStripButtonAktualisieren = new ToolStripButton();
      this.ucXMLQuellCodeFehlerliste = new ucXMLQuellCodeFehlerliste();
      this.ucXMLQuellcodeViewer = new ucXMLQuellcodeViewer();
      this.toolStripTop.SuspendLayout();
      this.SuspendLayout();
      this.toolStripTop.Items.AddRange(new ToolStripItem[1]
      {
        (ToolStripItem) this.toolStripButtonAktualisieren
      });
      this.toolStripTop.Location = new Point(0, 0);
      this.toolStripTop.Name = "toolStripTop";
      this.toolStripTop.Size = new Size(528, 25);
      this.toolStripTop.TabIndex = 2;
      this.toolStripTop.Text = "toolStrip1";
      this.toolStripButtonAktualisieren.Image = (Image) Resources.sync;
      this.toolStripButtonAktualisieren.ImageTransparentColor = Color.Magenta;
      this.toolStripButtonAktualisieren.Name = "toolStripButtonAktualisieren";
      this.toolStripButtonAktualisieren.Size = new Size(160, 22);
      this.toolStripButtonAktualisieren.Text = "toolStripButtonAktualisieren";
      this.toolStripButtonAktualisieren.Click += new EventHandler(this.toolStripButtonAktualisieren_Click);
      this.ucXMLQuellCodeFehlerliste.Location = new Point(328, 64);
      this.ucXMLQuellCodeFehlerliste.Name = "ucXMLQuellCodeFehlerliste";
      this.ucXMLQuellCodeFehlerliste.Size = new Size(200, 256);
      this.ucXMLQuellCodeFehlerliste.TabIndex = 1;
      this.ucXMLQuellcodeViewer.BackColor = Color.White;
      this.ucXMLQuellcodeViewer.Location = new Point(0, 85);
      this.ucXMLQuellcodeViewer.Name = "ucXMLQuellcodeViewer";
      this.ucXMLQuellcodeViewer.Size = new Size(254, 235);
      this.ucXMLQuellcodeViewer.TabIndex = 0;
      this.Controls.Add((Control) this.toolStripTop);
      this.Controls.Add((Control) this.ucXMLQuellCodeFehlerliste);
      this.Controls.Add((Control) this.ucXMLQuellcodeViewer);
      this.Name = nameof (ucXMLQuellcodeDebugger);
      this.Size = new Size(528, 320);
      this.Resize += new EventHandler(this.ucXMLQuellcodeDebugger_Resize);
      this.toolStripTop.ResumeLayout(false);
      this.toolStripTop.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public XMLEditor XMLEditor
    {
      set
      {
        this._xmlEditor = value;
        this._xmlEditor.ContentChangedEvent += new EventHandler(this._xmlEditor_ContentChangedEvent);
        this.Veraendert();
      }
    }

    public ucXMLQuellcodeDebugger()
    {
      this.InitializeComponent();
      this.toolStripButtonAktualisieren.Text = ResReader.Reader.GetString(nameof (toolStripButtonAktualisieren));
    }

    private void Veraendert()
    {
      this.ucXMLQuellCodeFehlerliste.Visible = false;
      this.ucXMLQuellcodeViewer.Visible = false;
    }

    private void ucXMLQuellcodeDebugger_Resize(object sender, EventArgs e)
    {
      this.ucXMLQuellcodeViewer.Top = this.toolStripTop.Top + this.toolStripTop.Height;
      this.ucXMLQuellcodeViewer.Left = 0;
      this.ucXMLQuellcodeViewer.Width = (int) ((double) this.Width * 0.6);
      this.ucXMLQuellcodeViewer.Height = this.Height - this.ucXMLQuellcodeViewer.Top;
      this.ucXMLQuellCodeFehlerliste.Top = this.toolStripTop.Top + this.toolStripTop.Height;
      this.ucXMLQuellCodeFehlerliste.Left = this.ucXMLQuellcodeViewer.Left + this.ucXMLQuellcodeViewer.Width;
      this.ucXMLQuellCodeFehlerliste.Width = this.Width - this.ucXMLQuellCodeFehlerliste.Left;
      this.ucXMLQuellCodeFehlerliste.Height = this.Height - this.ucXMLQuellCodeFehlerliste.Top;
    }

    private void _xmlEditor_ContentChangedEvent(object sender, EventArgs e)
    {
      this.Veraendert();
    }

    private void toolStripButtonAktualisieren_Click(object sender, EventArgs e)
    {
      this.ZeichnenIntern();
    }

    private void ZeichnenIntern()
    {
      if (this._xmlEditor != null && this._xmlEditor.ReadOnly)
      {
        this.Visible = false;
      }
      else
      {
        this.Visible = true;
        XMLQuellcodeAlsRTF xmlQuellcodeAlsRtf = new XMLQuellcodeAlsRTF();
        xmlQuellcodeAlsRtf.Regelwerk = this._xmlEditor.Regelwerk;
        xmlQuellcodeAlsRtf.Rootnode = this._xmlEditor.RootNode;
        this.ucXMLQuellcodeViewer.XMLCodeAlsRTF = xmlQuellcodeAlsRtf.QuellCodeAlsRTF;
        this.ucXMLQuellCodeFehlerliste.FehlerProtokollAlsText = xmlQuellcodeAlsRtf.FehlerProtokollAlsText;
        this.ucXMLQuellCodeFehlerliste.Visible = true;
        this.ucXMLQuellcodeViewer.Visible = true;
      }
    }
  }
}
