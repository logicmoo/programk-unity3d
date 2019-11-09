// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.ucXMLEditAttribut
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.xml.dtd;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace de.springwald.xml.editor
{
  public class ucXMLEditAttribut : UserControl
  {
    private Container components = (Container) null;
    private TextBox txtEingabe;
    private ComboBox comboAuswahl;
    private Label lblTitel;
    private XMLEditor _xmlEditor;
    private XmlNode _node;
    private DTDAttribut _attribut;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.txtEingabe = new TextBox();
      this.comboAuswahl = new ComboBox();
      this.lblTitel = new Label();
      this.SuspendLayout();
      this.txtEingabe.Location = new Point(88, 16);
      this.txtEingabe.Name = "txtEingabe";
      this.txtEingabe.TabIndex = 0;
      this.txtEingabe.Text = "txtEingabe";
      this.txtEingabe.TextChanged += new EventHandler(this.txtEingabe_TextChanged);
      this.comboAuswahl.Location = new Point(0, 16);
      this.comboAuswahl.Name = "comboAuswahl";
      this.comboAuswahl.Size = new Size(88, 21);
      this.comboAuswahl.TabIndex = 1;
      this.comboAuswahl.Text = "comboAuswahl";
      this.comboAuswahl.SelectedIndexChanged += new EventHandler(this.comboAuswahl_SelectedIndexChanged);
      this.lblTitel.Location = new Point(0, 0);
      this.lblTitel.Name = "lblTitel";
      this.lblTitel.Size = new Size(184, 16);
      this.lblTitel.TabIndex = 2;
      this.lblTitel.Text = "lblTitel";
      this.Controls.Add((Control) this.lblTitel);
      this.Controls.Add((Control) this.comboAuswahl);
      this.Controls.Add((Control) this.txtEingabe);
      this.Name = nameof (ucXMLEditAttribut);
      this.Size = new Size(192, 40);
      this.ResumeLayout(false);
    }

    private string XMLInhaltInNode
    {
      get
      {
        XmlAttribute attribute = this._node.Attributes[this._attribut.Name];
        if (attribute == null)
          return "";
        return attribute.Value;
      }
    }

    public XMLEditor XMLEditor
    {
      set
      {
        this._xmlEditor = value;
      }
    }

    public XmlNode Node
    {
      set
      {
        this._node = value;
      }
    }

    public DTDAttribut Attribut
    {
      set
      {
        this._attribut = value;
      }
      get
      {
        return this._attribut;
      }
    }

    public ucXMLEditAttribut()
    {
      this.InitializeComponent();
      this.Resize += new EventHandler(this.ucXMLEditAttribut_Resize);
    }

    public void NeuZeichnen()
    {
      if (this._attribut == null)
        throw new ApplicationException("Es wurde noch kein Attribut zugewiesen!");
      if (this._node == null)
        throw new ApplicationException("Es wurde noch kein Node zugewiesen!");
      this.lblTitel.Text = this._attribut.Name;
      if (this._attribut.ErlaubteWerte.Count > 0)
      {
        this.comboAuswahl.Visible = true;
        this.txtEingabe.Visible = false;
        this.comboAuswahl.Items.Clear();
        if (this._attribut.Pflicht == DTDAttribut.PflichtArten.Optional)
          this.comboAuswahl.Items.Add((object) "");
        foreach (object obj in this._attribut.ErlaubteWerte)
          this.comboAuswahl.Items.Add(obj);
        this.comboAuswahl.Text = this.XMLInhaltInNode;
      }
      else
      {
        this.comboAuswahl.Visible = false;
        this.txtEingabe.Visible = true;
        this.txtEingabe.Text = this.XMLInhaltInNode;
      }
    }

    private void comboAuswahl_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._attribut == null)
        throw new ApplicationException("Es wurde noch kein Attribut zugewiesen!");
      if (this._node == null)
        throw new ApplicationException("Es wurde noch kein Node zugewiesen!");
      this._xmlEditor.AktionAttributWertInNodeSetzen(this._node, this._attribut.Name, this.comboAuswahl.Text, XMLEditor.UndoSnapshotSetzenOptionen.ja);
    }

    private void txtEingabe_TextChanged(object sender, EventArgs e)
    {
      if (this._attribut == null)
        throw new ApplicationException("Es wurde noch kein Attribut zugewiesen!");
      if (this._node == null)
        throw new ApplicationException("Es wurde noch kein Node zugewiesen!");
      this._xmlEditor.AktionAttributWertInNodeSetzen(this._node, this._attribut.Name, this.txtEingabe.Text, XMLEditor.UndoSnapshotSetzenOptionen.ja);
    }

    private void ucXMLEditAttribut_Resize(object sender, EventArgs e)
    {
      this.lblTitel.Top = 0;
      this.lblTitel.Left = 0;
      this.lblTitel.Width = this.ClientSize.Width;
      this.txtEingabe.Left = 0;
      this.txtEingabe.Top = this.lblTitel.Top + this.lblTitel.Height;
      this.txtEingabe.Width = this.ClientSize.Width;
      this.comboAuswahl.Left = 0;
      this.comboAuswahl.Top = this.lblTitel.Top + this.lblTitel.Height;
      this.comboAuswahl.Width = this.ClientSize.Width;
    }
  }
}
