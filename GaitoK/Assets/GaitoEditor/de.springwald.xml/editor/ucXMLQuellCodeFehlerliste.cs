// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.ucXMLQuellCodeFehlerliste
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace de.springwald.xml.editor
{
  public class ucXMLQuellCodeFehlerliste : UserControl
  {
    private Container components = (Container) null;
    private TextBox txtFehlerProtokoll;
    private string _fehlerProtokollAlsText;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.txtFehlerProtokoll = new TextBox();
      this.SuspendLayout();
      this.txtFehlerProtokoll.Location = new Point(8, 16);
      this.txtFehlerProtokoll.Multiline = true;
      this.txtFehlerProtokoll.Name = "txtFehlerProtokoll";
      this.txtFehlerProtokoll.ScrollBars = ScrollBars.Both;
      this.txtFehlerProtokoll.Size = new Size(304, 216);
      this.txtFehlerProtokoll.TabIndex = 0;
      this.txtFehlerProtokoll.Text = "txtFehlerProtokoll";
      this.Controls.Add((Control) this.txtFehlerProtokoll);
      this.Name = nameof (ucXMLQuellCodeFehlerliste);
      this.Size = new Size(392, 264);
      this.Load += new EventHandler(this.ucXMLQuellCodeFehlerliste_Load);
      this.ResumeLayout(false);
    }

    public string FehlerProtokollAlsText
    {
      set
      {
        this._fehlerProtokollAlsText = value;
        this.Zeichnen();
      }
    }

    public ucXMLQuellCodeFehlerliste()
    {
      this.InitializeComponent();
      this.Resize += new EventHandler(this.ucXMLQuellCodeFehlerliste_Resize);
    }

    private void Zeichnen()
    {
      this.txtFehlerProtokoll.Text = this._fehlerProtokollAlsText;
      this.txtFehlerProtokoll.Select(0, 0);
    }

    private void ucXMLQuellCodeFehlerliste_Load(object sender, EventArgs e)
    {
    }

    private void ucXMLQuellCodeFehlerliste_Resize(object sender, EventArgs e)
    {
      this.txtFehlerProtokoll.Left = 0;
      this.txtFehlerProtokoll.Top = 0;
      this.txtFehlerProtokoll.Width = this.ClientSize.Width;
      this.txtFehlerProtokoll.Height = this.ClientSize.Height;
    }
  }
}
