// Decompiled with JetBrains decompiler
// Type: GaitoBotEditor.EinArbeitsBereichListenEintrag
// Assembly: GaitoBotEditor, Version=2.10.0.42867, Culture=neutral, PublicKeyToken=null
// MVID: EBD14C24-1519-4F8B-BE7E-6E5D551BEF56
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditor.exe

using de.springwald.toolbox;
using GaitoBotEditorCore;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GaitoBotEditor
{
  public class EinArbeitsBereichListenEintrag : UserControl
  {
    private IContainer components = (IContainer) null;
    private GroupBox groupBoxArbeitsbereich;
    private Button buttonOeffnen;
    private Label labelTitel;
    private Button buttonLoeschen;

    public event EventHandler<EventArgs<Arbeitsbereich>> ArbeitsbereichOeffnen;

    public event EventHandler<EventArgs<Arbeitsbereich>> ArbeitsbereichLoeschen;

    private Arbeitsbereich Arbeitsbereich { get; set; }

    public EinArbeitsBereichListenEintrag()
    {
      this.InitializeComponent();
    }

    public void Anzeigen(Arbeitsbereich arbeitsbereich)
    {
      this.Arbeitsbereich = arbeitsbereich;
      string[] strArray = arbeitsbereich.Arbeitsverzeichnis.Split(new char[1]{ '\\' }, StringSplitOptions.RemoveEmptyEntries);
      this.groupBoxArbeitsbereich.Text = strArray[strArray.Length - 1];
      this.labelTitel.Text = arbeitsbereich.Name;
    }

    private void buttonOeffnen_Click(object sender, EventArgs e)
    {
      if (this.ArbeitsbereichOeffnen == null)
        return;
      this.ArbeitsbereichOeffnen((object) this, new EventArgs<Arbeitsbereich>(this.Arbeitsbereich));
    }

    private void buttonLoeschen_Click(object sender, EventArgs e)
    {
      if (this.ArbeitsbereichLoeschen == null)
        return;
      this.ArbeitsbereichLoeschen((object) this, new EventArgs<Arbeitsbereich>(this.Arbeitsbereich));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (EinArbeitsBereichListenEintrag));
      this.groupBoxArbeitsbereich = new GroupBox();
      this.buttonLoeschen = new Button();
      this.labelTitel = new Label();
      this.buttonOeffnen = new Button();
      this.groupBoxArbeitsbereich.SuspendLayout();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.groupBoxArbeitsbereich, "groupBoxArbeitsbereich");
      this.groupBoxArbeitsbereich.BackColor = Color.White;
      this.groupBoxArbeitsbereich.Controls.Add((Control) this.buttonLoeschen);
      this.groupBoxArbeitsbereich.Controls.Add((Control) this.labelTitel);
      this.groupBoxArbeitsbereich.Controls.Add((Control) this.buttonOeffnen);
      this.groupBoxArbeitsbereich.ForeColor = SystemColors.ControlText;
      this.groupBoxArbeitsbereich.Name = "groupBoxArbeitsbereich";
      this.groupBoxArbeitsbereich.TabStop = false;
      componentResourceManager.ApplyResources((object) this.buttonLoeschen, "buttonLoeschen");
      this.buttonLoeschen.BackColor = SystemColors.Control;
      this.buttonLoeschen.Name = "buttonLoeschen";
      this.buttonLoeschen.UseVisualStyleBackColor = false;
      this.buttonLoeschen.Click += new EventHandler(this.buttonLoeschen_Click);
      componentResourceManager.ApplyResources((object) this.labelTitel, "labelTitel");
      this.labelTitel.Name = "labelTitel";
      componentResourceManager.ApplyResources((object) this.buttonOeffnen, "buttonOeffnen");
      this.buttonOeffnen.BackColor = SystemColors.Control;
      this.buttonOeffnen.Name = "buttonOeffnen";
      this.buttonOeffnen.UseVisualStyleBackColor = false;
      this.buttonOeffnen.Click += new EventHandler(this.buttonOeffnen_Click);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.Transparent;
      this.Controls.Add((Control) this.groupBoxArbeitsbereich);
      this.Name = nameof (EinArbeitsBereichListenEintrag);
      this.groupBoxArbeitsbereich.ResumeLayout(false);
      this.ResumeLayout(false);
    }
  }
}
