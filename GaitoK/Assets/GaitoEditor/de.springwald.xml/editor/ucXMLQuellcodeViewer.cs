// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.ucXMLQuellcodeViewer
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace de.springwald.xml.editor
{
  public class ucXMLQuellcodeViewer : UserControl
  {
    private RichTextBox txtQuellcode;
    private string _quellcodeAlsRTF;

    private void InitializeComponent()
    {
      this.txtQuellcode = new RichTextBox();
      this.SuspendLayout();
      this.txtQuellcode.BackColor = Color.White;
      this.txtQuellcode.BorderStyle = BorderStyle.None;
      this.txtQuellcode.DetectUrls = false;
      this.txtQuellcode.Location = new Point(8, 8);
      this.txtQuellcode.Name = "txtQuellcode";
      this.txtQuellcode.ReadOnly = true;
      this.txtQuellcode.Size = new Size(600, 392);
      this.txtQuellcode.TabIndex = 0;
      this.txtQuellcode.Text = "txtQuellcode";
      this.BackColor = SystemColors.Control;
      this.Controls.Add((Control) this.txtQuellcode);
      this.Name = nameof (ucXMLQuellcodeViewer);
      this.Size = new Size(624, 416);
      this.Load += new EventHandler(this.ucXMLQuellcodeViewer_Load);
      this.ResumeLayout(false);
    }

    public string XMLCodeAlsRTF
    {
      set
      {
        this._quellcodeAlsRTF = value;
        this.Zeichnen();
      }
    }

    public ucXMLQuellcodeViewer()
    {
      this.InitializeComponent();
      this.txtQuellcode.Text = "";
      this.Resize += new EventHandler(this.ucXMLQuellcodeViewer_Resize);
    }

    private void ucXMLQuellcodeViewer_Load(object sender, EventArgs e)
    {
      this.BackColor = this.txtQuellcode.BackColor;
      this.Zeichnen();
    }

    private void ucXMLQuellcodeViewer_Resize(object sender, EventArgs e)
    {
      int num = 5;
      this.txtQuellcode.Left = num;
      this.txtQuellcode.Top = num;
      this.txtQuellcode.Width = this.ClientSize.Width - 2 * num;
      this.txtQuellcode.Height = this.ClientSize.Height - 2 * num;
      this.Zeichnen();
    }

    private void Zeichnen()
    {
      if (this._quellcodeAlsRTF == "")
        return;
      this.txtQuellcode.Rtf = this._quellcodeAlsRTF;
    }
  }
}
