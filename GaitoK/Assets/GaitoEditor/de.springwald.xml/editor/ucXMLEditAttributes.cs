// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.ucXMLEditAttributes
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.toolbox;
using de.springwald.xml.cursor;
using de.springwald.xml.dtd;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace de.springwald.xml.editor
{
  public class ucXMLEditAttributes : UserControl
  {
    private IContainer components;
    private XMLEditor _xmlEditor;
    private Timer timerAttributListeAnzeigen;
    private ArrayList _attributEditFelder;
    private Label lblFehler;
    private List<DTDAttribut> _attribute;

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.timerAttributListeAnzeigen = new Timer(this.components);
      this.lblFehler = new Label();
      this.SuspendLayout();
      this.timerAttributListeAnzeigen.Tick += new EventHandler(this.timerAttributListeAnzeigen_Tick);
      this.lblFehler.AutoSize = true;
      this.lblFehler.ForeColor = Color.FromArgb(192, 0, 0);
      this.lblFehler.Location = new Point(3, 0);
      this.lblFehler.Name = "lblFehler";
      this.lblFehler.Size = new Size(46, 13);
      this.lblFehler.TabIndex = 0;
      this.lblFehler.Text = "lblFehler";
      this.Controls.Add((Control) this.lblFehler);
      this.Name = nameof (ucXMLEditAttributes);
      this.Load += new EventHandler(this.ucXMLEditAttributes_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public XMLEditor XMLEditor
    {
      set
      {
        this._attributEditFelder = new ArrayList();
        this._attribute = (List<DTDAttribut>) null;
        this._xmlEditor = value;
        this._xmlEditor.CursorRoh.ChangedEvent += new EventHandler(this.Cursor_ChangedEvent);
        this._xmlEditor.ContentChangedEvent += new EventHandler(this._xmlEditor_ContentChangedEvent);
        this.VeraenderungAnmelden();
      }
    }

    private void _xmlEditor_ContentChangedEvent(object sender, EventArgs e)
    {
      if (this._xmlEditor.RootNode == null)
      {
        this.AttributeAnzeigen();
        this.Enabled = false;
      }
      else
        this.Enabled = true;
    }

    public ucXMLEditAttributes()
    {
      this.InitializeComponent();
    }

    private void ucXMLEditAttributes_Load(object sender, EventArgs e)
    {
    }

    public void NeuZeichnen()
    {
      this.VeraenderungAnmelden();
    }

    private void VeraenderungAnmelden()
    {
      this.timerAttributListeAnzeigen.Enabled = false;
      this.timerAttributListeAnzeigen.Interval = 100;
      this.timerAttributListeAnzeigen.Enabled = true;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (this.components != null)
          this.components.Dispose();
        if (this._xmlEditor != null)
          this._xmlEditor.CursorRoh.ChangedEvent -= new EventHandler(this.Cursor_ChangedEvent);
        this.DisposeAttribute();
      }
      base.Dispose(disposing);
    }

    private void DisposeAttribute()
    {
      this._attribute = (List<DTDAttribut>) null;
      if (this._attributEditFelder == null)
        return;
      foreach (Component component in this._attributEditFelder)
        component.Dispose();
      this._attributEditFelder.Clear();
    }

    private void timerAttributListeAnzeigen_Tick(object sender, EventArgs e)
    {
      this.timerAttributListeAnzeigen.Enabled = false;
      this.AttributeAnzeigen();
    }

    private void Cursor_ChangedEvent(object sender, EventArgs e)
    {
      this.VeraenderungAnmelden();
    }

    public void AttributeAnzeigen()
    {
      this._attribute = (List<DTDAttribut>) null;
      this.lblFehler.Visible = false;
      if (this._xmlEditor != null && this._xmlEditor.RootNode != null && this._xmlEditor.CursorRoh.StartPos.Equals(this._xmlEditor.CursorRoh.EndPos))
      {
        int num1 = 5;
        int num2 = num1;
        XmlNode xmlNode;
        switch (this._xmlEditor.CursorRoh.StartPos.PosAmNode)
        {
          case XMLCursorPositionen.CursorVorDemNode:
          case XMLCursorPositionen.CursorHinterDemNode:
            xmlNode = this._xmlEditor.CursorRoh.StartPos.AktNode.ParentNode;
            break;
          case XMLCursorPositionen.CursorAufNodeSelbstVorderesTag:
          case XMLCursorPositionen.CursorAufNodeSelbstHinteresTag:
          case XMLCursorPositionen.CursorInDemLeeremNode:
            xmlNode = this._xmlEditor.CursorRoh.StartPos.AktNode;
            break;
          case XMLCursorPositionen.CursorInnerhalbDesTextNodes:
            xmlNode = this._xmlEditor.CursorRoh.StartPos.AktNode;
            break;
          default:
            xmlNode = (XmlNode) null;
            break;
        }
        while (xmlNode is XmlText)
          xmlNode = xmlNode.ParentNode;
        if (xmlNode != null)
        {
          DTDElement dtdElement = (DTDElement) null;
          try
          {
            dtdElement = this._xmlEditor.Regelwerk.DTD.DTDElementByName(xmlNode.Name, true);
          }
          catch (DTD.XMLUnknownElementException ex)
          {
            Debugger.GlobalDebugger.Protokolliere(string.Format("unknown element {0} in {1}->{2}", (object) ex.ElementName, (object) this.Name, (object) "AttributeNeuAnzeigen"));
            this.lblFehler.Text = string.Format("unknown element '{0}'", (object) ex.ElementName);
            this.lblFehler.Visible = true;
          }
          if (dtdElement != null)
          {
            this._attribute = dtdElement.Attribute;
            if (this._attribute.Count > 0)
            {
              for (int index = 0; index < this._attribute.Count; ++index)
              {
                ucXMLEditAttribut ucXmlEditAttribut;
                if (index < this._attributEditFelder.Count)
                {
                  ucXmlEditAttribut = (ucXMLEditAttribut) this._attributEditFelder[index];
                }
                else
                {
                  ucXmlEditAttribut = new ucXMLEditAttribut();
                  ucXmlEditAttribut.Parent = (Control) this;
                  ucXmlEditAttribut.Top = num2;
                  ucXmlEditAttribut.Left = num1;
                  ucXmlEditAttribut.Width = 10;
                  ucXmlEditAttribut.Visible = true;
                  this._attributEditFelder.Add((object) ucXmlEditAttribut);
                }
                ucXmlEditAttribut.XMLEditor = this._xmlEditor;
                ucXmlEditAttribut.Node = xmlNode;
                ucXmlEditAttribut.Attribut = this._attribute[index];
                ucXmlEditAttribut.NeuZeichnen();
                num2 += ucXmlEditAttribut.Height;
                this.NichtMehrBenoetigteAttributEditFelderLoeschen();
                foreach (Control control in this._attributEditFelder)
                  control.Width = this.ClientSize.Width - num1 * 2;
              }
            }
          }
        }
      }
      this.NichtMehrBenoetigteAttributEditFelderLoeschen();
    }

    private void NichtMehrBenoetigteAttributEditFelderLoeschen()
    {
      if (this._attributEditFelder == null)
        return;
      int num = this._attribute != null ? this._attribute.Count : 0;
      while (this._attributEditFelder.Count > num)
      {
        ucXMLEditAttribut ucXmlEditAttribut = (ucXMLEditAttribut) this._attributEditFelder[this._attributEditFelder.Count - 1];
        this._attributEditFelder.Remove((object) ucXmlEditAttribut);
        ucXmlEditAttribut.Dispose();
      }
    }
  }
}
