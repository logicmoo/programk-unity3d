// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.ucCategoryXMLEditor
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using de.springwald.xml;
using de.springwald.xml.editor;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace GaitoBotEditorCore
{
  public class ucCategoryXMLEditor : UserControl
  {
    private XMLRegelwerk _aimlRegelwerk;
    private XMLRegelwerk _startupRegelwerk;
    private IArbeitsbereichDatei _aktDatei;
    private Arbeitsbereich _arbeitsbereich;
    private AIMLCategory _category;

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ucCategoryXMLEditor));
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this, "$this");
      this.BackColor = SystemColors.Control;
      this.ForeColor = SystemColors.Control;
      this.Name = nameof (ucCategoryXMLEditor);
      this.ResumeLayout(false);
    }

    private IArbeitsbereichDatei AktDatei
    {
      set
      {
        this._aktDatei = value;
        if (value == null)
          return;
        this.XmlEditor.ReadOnly = this._aktDatei.ReadOnly;
        if (this.XmlEditor.RootNode != value.XML.DocumentElement)
          this.XmlEditor.RootNode = (XmlNode) value.XML.DocumentElement;
        if (value is StartupDatei)
        {
          this.XmlEditor.Regelwerk = this._startupRegelwerk;
        }
        else
        {
          if (!(value is AIMLDatei))
            throw new ApplicationException("Unbehandelte Dateiart " + this.AktDatei.Dateiname);
          this.XmlEditor.Regelwerk = this._aimlRegelwerk;
        }
      }
      get
      {
        return this._aktDatei;
      }
    }

    private AIMLCategory AktCategory
    {
      set
      {
        if (!(this._arbeitsbereich.Fokus.AktDatei is AIMLDatei))
          return;
        this._category = value;
        if (this._category == null)
        {
          if (this.XmlEditor.RootNode != null)
            this.XmlEditor.RootNode = (XmlNode) null;
        }
        else if (this.XmlEditor.RootNode != this._category.ContentNode)
          this.XmlEditor.RootNode = this._category.ContentNode;
      }
      get
      {
        return this._category;
      }
    }

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Diesem ucCategoryXMLEditor wurde bereits ein Arbeitsbereich zugeordnet");
        this._arbeitsbereich = value;
        this._arbeitsbereich.Fokus.XmlEditor = this.XmlEditor;
        this._arbeitsbereich.Fokus.AktAIMLCategoryChanged += new EventHandler<EventArgs<AIMLCategory>>(this.Fokus_AktAIMLCategoryChanged);
        this._arbeitsbereich.Fokus.AktDateiChanged += new ArbeitsbereichFokus.AktDateiChangedEventHandler(this.Fokus_AktDateiChanged);
      }
    }

    public XMLEditor XmlEditor { get; private set; }

    public ucCategoryXMLEditor()
    {
      this.InitializeComponent();
      this._aimlRegelwerk = (XMLRegelwerk) new AimlXmlRegelwerk(AIMLDTD.GetAIMLDTD());
      this._startupRegelwerk = (XMLRegelwerk) new StartupDatei_XmlRegelwerk(StartupDateiDtd.GetStartupDtd());
      this.XmlEditor = new XMLEditor(this._aimlRegelwerk, (Control) this);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.UpdateStyles();
    }

    private void Fokus_AktAIMLCategoryChanged(object sender, EventArgs<AIMLCategory> e)
    {
      this.AktCategory = e.Value;
    }

    private void Fokus_AktDateiChanged(object sender, EventArgs<IArbeitsbereichDatei> e)
    {
      this.AktDatei = e.Value;
    }

    protected override bool IsInputKey(Keys keyData)
    {
      bool flag = true;
      switch (keyData)
      {
        case Keys.Left:
        case Keys.Up:
        case Keys.Right:
        case Keys.Down:
          return flag;
        default:
          flag = base.IsInputKey(keyData);
          goto case Keys.Left;
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      this.XmlEditor.Paint(e);
    }
  }
}
