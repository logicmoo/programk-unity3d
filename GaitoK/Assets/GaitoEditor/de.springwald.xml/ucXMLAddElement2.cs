// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.ucXMLAddElement2
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.toolbox;
using de.springwald.xml.dtd;
using de.springwald.xml.editor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace de.springwald.xml
{
  public class ucXMLAddElement2 : UserControl
  {
    private bool _nichtAufResizeReagieren = false;
    private XMLEditor _xmlEditor;
    private Timer timerButtonListeAnzeigen;
    private Label lblFehler;
    private List<ucXMLAddElementGruppe> _gruppenControls;
    private IContainer components;

    public XMLEditor XMLEditor
    {
      set
      {
        if (this._xmlEditor != null)
          throw new ApplicationException("There is already a XMLEditor object attached!");
        this._xmlEditor = value;
        this._xmlEditor.ContentChangedEvent += new EventHandler(this._xmlEditor_ContentChangedEvent);
        this._xmlEditor.CursorRoh.ChangedEvent += new EventHandler(this.Cursor_ChangedEvent);
        this.VeraenderungAnmelden_();
        this._gruppenControls = new List<ucXMLAddElementGruppe>();
        for (int index = 0; index < this._xmlEditor.Regelwerk.ElementGruppen.Count; ++index)
        {
          ucXMLAddElementGruppe addElementGruppe = new ucXMLAddElementGruppe(this._xmlEditor.Regelwerk.ElementGruppen[index], this._xmlEditor);
          addElementGruppe.Parent = (Control) this;
          addElementGruppe.Left = 0;
          addElementGruppe.Top = 50 * index;
          addElementGruppe.Visible = true;
          addElementGruppe.Resize += new EventHandler(this.gruppenControl_Resize);
          this._gruppenControls.Add(addElementGruppe);
        }
        ucXMLAddElementGruppe addElementGruppe1 = new ucXMLAddElementGruppe((XMLElementGruppe) null, this._xmlEditor);
        addElementGruppe1.Parent = (Control) this;
        addElementGruppe1.Left = 0;
        addElementGruppe1.Top = 0;
        addElementGruppe1.Visible = true;
        addElementGruppe1.Resize += new EventHandler(this.gruppenControl_Resize);
        this._gruppenControls.Add(addElementGruppe1);
      }
    }

    private void _xmlEditor_ContentChangedEvent(object sender, EventArgs e)
    {
      this.ButtonsNeuAnzeigen();
      if (this._xmlEditor.RootNode == null)
      {
        if (!this.Enabled)
          return;
        this.Enabled = false;
      }
      else if (!this.Enabled)
        this.Enabled = true;
    }

    public ucXMLAddElement2()
    {
      this.InitializeComponent();
      this.Resize += new EventHandler(this.ucXMLAddElement_Resize);
    }

    private void ucXMLAddElement_Load(object sender, EventArgs e)
    {
    }

    private void ucXMLAddElement_Resize(object sender, EventArgs e)
    {
      if (this._nichtAufResizeReagieren)
        return;
      this.VeraenderungAnmelden_();
    }

    private void gruppenControl_Resize(object sender, EventArgs e)
    {
      if (this._nichtAufResizeReagieren)
        return;
      this.VeraenderungAnmelden_();
    }

    private void VeraenderungAnmelden_()
    {
      this.timerButtonListeAnzeigen.Enabled = false;
      this.timerButtonListeAnzeigen.Interval = 100;
      this.timerButtonListeAnzeigen.Enabled = true;
    }

    private void Cursor_ChangedEvent(object sender, EventArgs e)
    {
      this.VeraenderungAnmelden_();
    }

    private void timerButtonListeAnzeigen_Tick(object sender, EventArgs e)
    {
      this.timerButtonListeAnzeigen.Enabled = false;
      this.ButtonsNeuAnzeigen();
    }

    private void ButtonsNeuAnzeigen()
    {
      this.AutoScroll = true;
      if (this.lblFehler.Visible)
        this.lblFehler.Visible = false;
      this._nichtAufResizeReagieren = true;
      if (this._xmlEditor != null && this._xmlEditor.RootNode != null)
      {
        string[] strArray = (string[]) null;
        try
        {
          strArray = this._xmlEditor.Regelwerk.ErlaubteEinfuegeElemente_(this._xmlEditor.CursorOptimiert.StartPos, false, false);
        }
        catch (DTD.XMLUnknownElementException ex)
        {
          Debugger.GlobalDebugger.Protokolliere(string.Format("unknown element {0} in {1}->{2}", (object) ex.ElementName, (object) this.Name, (object) "Aktualisieren"));
          this.lblFehler.Text = string.Format("unknown element '{0}'", (object) ex.ElementName);
          this.lblFehler.Visible = true;
        }
        if (strArray != null)
        {
          string[] elemente = ((IEnumerable<string>) strArray).OrderBy<string, string>((Func<string, string>) (e => e)).ToArray<string>();
          int num1 = 3;
          int num2 = 0;
          for (int index = 0; index < this._gruppenControls.Count; ++index)
          {
            elemente = this._gruppenControls[index].VerfuegbareElementeZuweisenUndRestElementeZurueckGeben(elemente);
            if (this._gruppenControls[index].Visible)
            {
              this._gruppenControls[index].Top = num2;
              this._gruppenControls[index].Left = num1;
              int num3 = this.ClientSize.Width - num1 * 2;
              this._gruppenControls[index].Width = num3;
              num2 += this._gruppenControls[index].Height;
            }
          }
        }
      }
      this._nichtAufResizeReagieren = false;
    }

    protected void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.timerButtonListeAnzeigen = new Timer(this.components);
      this.lblFehler = new Label();
      this.SuspendLayout();
      this.timerButtonListeAnzeigen.Tick += new EventHandler(this.timerButtonListeAnzeigen_Tick);
      this.lblFehler.AutoSize = true;
      this.lblFehler.ForeColor = Color.FromArgb(192, 0, 0);
      this.lblFehler.Location = new Point(3, 0);
      this.lblFehler.Name = "lblFehler";
      this.lblFehler.Size = new Size(46, 13);
      this.lblFehler.TabIndex = 0;
      this.lblFehler.Text = "lblFehler";
      this.Controls.Add((Control) this.lblFehler);
      this.DoubleBuffered = true;
      this.Margin = new Padding(0);
      this.Name = "ucXMLAddElement";
      this.Size = new Size(361, 348);
      this.Load += new EventHandler(this.ucXMLAddElement_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
