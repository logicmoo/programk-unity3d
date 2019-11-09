// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.ucXMLToolbar
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
  public class ucXMLToolbar : UserControl
  {
    private IContainer components = (IContainer) null;
    private XMLEditor _xmlEditor;
    private ToolStripButton ButtonUndo;
    private ToolStrip toolStrip;
    private ToolStripButton ButtonRedo;
    private ToolStripSeparator toolStripSeparator1;
    private ToolStripButton ButtonAusschneiden;
    private ToolStripButton ButtonEinfuegen;
    private ToolStripButton ButtonKopieren;
    private ToolStripSeparator toolStripSeparator2;
    private ToolStripButton ButtonHome;
    private ToolStripButton ButtonLoeschen;
    private Timer timerButtonsNeuZeichnen;

    public XMLEditor XMLEditor
    {
      set
      {
        this._xmlEditor = value;
        this._xmlEditor.ContentChangedEvent += new EventHandler(this._xmlEditor_ContentChangedEvent);
        this._xmlEditor.CursorRoh.ChangedEvent += new EventHandler(this.CursorRoh_ChangedEvent);
        this.VeraenderungAnmelden();
      }
    }

    public ucXMLToolbar()
    {
      this.InitializeComponent();
      this.VeraenderungAnmelden();
    }

    private void ucXMLToolbar_Load(object sender, EventArgs e)
    {
      this.SteuerElementeBeschriften();
    }

    private void SteuerElementeBeschriften()
    {
      this.ButtonAusschneiden.Text = ResReader.Reader.GetString("ButtonAusschneiden");
      this.ButtonEinfuegen.Text = ResReader.Reader.GetString("ButtonEinfuegen");
      this.ButtonHome.Text = ResReader.Reader.GetString("ButtonHome");
      this.ButtonKopieren.Text = ResReader.Reader.GetString("ButtonKopieren");
      this.ButtonLoeschen.Text = ResReader.Reader.GetString("ButtonLoeschen");
      this.ButtonRedo.Text = ResReader.Reader.GetString("ButtonRedo");
      this.ButtonUndo.Text = ResReader.Reader.GetString("ButtonUndo");
    }

    private void VeraenderungAnmelden()
    {
      this.timerButtonsNeuZeichnen.Enabled = false;
      this.timerButtonsNeuZeichnen.Interval = 100;
      this.timerButtonsNeuZeichnen.Enabled = true;
    }

    private void ButtonsZeichnen()
    {
      if (this._xmlEditor == null)
        this.toolStrip.Enabled = false;
      else if (this._xmlEditor.RootNode == null)
        this.toolStrip.Enabled = false;
      else if (this._xmlEditor.ReadOnly)
      {
        this.toolStrip.Enabled = false;
      }
      else
      {
        this.toolStrip.Enabled = true;
        bool istEtwasSelektiert = this._xmlEditor.IstEtwasSelektiert;
        this.ButtonAusschneiden.Enabled = istEtwasSelektiert;
        this.ButtonLoeschen.Enabled = istEtwasSelektiert;
        this.ButtonKopieren.Enabled = istEtwasSelektiert;
        this.ButtonUndo.Enabled = this._xmlEditor.UndoMoeglich;
        this.ButtonUndo.Text = this._xmlEditor.UndoSchrittName;
        this.ButtonRedo.Visible = false;
        this.ButtonRedo.Enabled = false;
        this.ButtonHome.Enabled = true;
        this.ButtonEinfuegen.Enabled = this._xmlEditor.IstEtwasInZwischenablage && this._xmlEditor.CursorRoh.StartPos.AktNode != null;
      }
    }

    private void CursorRoh_ChangedEvent(object sender, EventArgs e)
    {
      this.VeraenderungAnmelden();
    }

    private void _xmlEditor_ContentChangedEvent(object sender, EventArgs e)
    {
      this.VeraenderungAnmelden();
    }

    private void timerButtonsNeuZeichnen_Tick(object sender, EventArgs e)
    {
      this.timerButtonsNeuZeichnen.Enabled = false;
      this.ButtonsZeichnen();
    }

    private void ButtonLoeschen_Click(object sender, EventArgs e)
    {
      if (this._xmlEditor == null)
        return;
      this._xmlEditor.AktionDelete(XMLEditor.UndoSnapshotSetzenOptionen.ja);
    }

    private void ButtonKopieren_Click(object sender, EventArgs e)
    {
      if (this._xmlEditor == null)
        return;
      this._xmlEditor.AktionCopyToClipboard();
    }

    private void ButtonAusschneiden_Click(object sender, EventArgs e)
    {
      if (this._xmlEditor == null)
        return;
      this._xmlEditor.AktionCutToClipboard(XMLEditor.UndoSnapshotSetzenOptionen.ja);
    }

    private void ButtonEinfuegen_Click(object sender, EventArgs e)
    {
      if (this._xmlEditor == null)
        return;
      this._xmlEditor.AktionPasteFromClipboard(XMLEditor.UndoSnapshotSetzenOptionen.ja);
    }

    private void ButtonUndo_Click(object sender, EventArgs e)
    {
      if (this._xmlEditor == null)
        return;
      this._xmlEditor.UnDo();
    }

    private void ButtonHome_Click(object sender, EventArgs e)
    {
      if (this._xmlEditor == null)
        return;
      this._xmlEditor.AktionCursorAufPos1();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      this.toolStrip = new ToolStrip();
      this.ButtonHome = new ToolStripButton();
      this.toolStripSeparator1 = new ToolStripSeparator();
      this.ButtonUndo = new ToolStripButton();
      this.ButtonRedo = new ToolStripButton();
      this.toolStripSeparator2 = new ToolStripSeparator();
      this.ButtonAusschneiden = new ToolStripButton();
      this.ButtonEinfuegen = new ToolStripButton();
      this.ButtonKopieren = new ToolStripButton();
      this.ButtonLoeschen = new ToolStripButton();
      this.timerButtonsNeuZeichnen = new Timer(this.components);
      this.toolStrip.SuspendLayout();
      this.SuspendLayout();
      this.toolStrip.Items.AddRange(new ToolStripItem[9]
      {
        (ToolStripItem) this.ButtonHome,
        (ToolStripItem) this.toolStripSeparator1,
        (ToolStripItem) this.ButtonUndo,
        (ToolStripItem) this.ButtonRedo,
        (ToolStripItem) this.toolStripSeparator2,
        (ToolStripItem) this.ButtonAusschneiden,
        (ToolStripItem) this.ButtonEinfuegen,
        (ToolStripItem) this.ButtonKopieren,
        (ToolStripItem) this.ButtonLoeschen
      });
      this.toolStrip.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
      this.toolStrip.Location = new Point(0, 0);
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.RenderMode = ToolStripRenderMode.Professional;
      this.toolStrip.Size = new Size(924, 25);
      this.toolStrip.TabIndex = 0;
      this.toolStrip.Text = "toolStrip1";
      this.ButtonHome.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.ButtonHome.Image = (Image) Resources.home_161;
      this.ButtonHome.ImageTransparentColor = Color.Magenta;
      this.ButtonHome.Name = "ButtonHome";
      this.ButtonHome.Size = new Size(23, 22);
      this.ButtonHome.Text = "Pos1";
      this.ButtonHome.Click += new EventHandler(this.ButtonHome_Click);
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new Size(6, 25);
      this.ButtonUndo.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.ButtonUndo.Image = (Image) Resources.undo_16;
      this.ButtonUndo.ImageTransparentColor = Color.Magenta;
      this.ButtonUndo.Name = "ButtonUndo";
      this.ButtonUndo.Size = new Size(23, 22);
      this.ButtonUndo.Text = "undo";
      this.ButtonUndo.Click += new EventHandler(this.ButtonUndo_Click);
      this.ButtonRedo.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.ButtonRedo.Image = (Image) Resources.redo_16;
      this.ButtonRedo.ImageTransparentColor = Color.Magenta;
      this.ButtonRedo.Name = "ButtonRedo";
      this.ButtonRedo.Size = new Size(23, 22);
      this.ButtonRedo.Text = "redo";
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new Size(6, 25);
      this.ButtonAusschneiden.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.ButtonAusschneiden.Image = (Image) Resources.cut_16;
      this.ButtonAusschneiden.ImageTransparentColor = Color.Magenta;
      this.ButtonAusschneiden.Name = "ButtonAusschneiden";
      this.ButtonAusschneiden.Size = new Size(23, 22);
      this.ButtonAusschneiden.Text = "ausschneiden";
      this.ButtonAusschneiden.Click += new EventHandler(this.ButtonAusschneiden_Click);
      this.ButtonEinfuegen.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.ButtonEinfuegen.Image = (Image) Resources.paste_16;
      this.ButtonEinfuegen.ImageTransparentColor = Color.Magenta;
      this.ButtonEinfuegen.Name = "ButtonEinfuegen";
      this.ButtonEinfuegen.Size = new Size(23, 22);
      this.ButtonEinfuegen.Text = "einfügen";
      this.ButtonEinfuegen.Click += new EventHandler(this.ButtonEinfuegen_Click);
      this.ButtonKopieren.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.ButtonKopieren.Image = (Image) Resources.copy_16;
      this.ButtonKopieren.ImageTransparentColor = Color.Magenta;
      this.ButtonKopieren.Name = "ButtonKopieren";
      this.ButtonKopieren.Size = new Size(23, 22);
      this.ButtonKopieren.Text = "kopieren";
      this.ButtonKopieren.Click += new EventHandler(this.ButtonKopieren_Click);
      this.ButtonLoeschen.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.ButtonLoeschen.Image = (Image) Resources.delete_161;
      this.ButtonLoeschen.ImageTransparentColor = Color.Magenta;
      this.ButtonLoeschen.Name = "ButtonLoeschen";
      this.ButtonLoeschen.Size = new Size(23, 22);
      this.ButtonLoeschen.Text = "delete";
      this.ButtonLoeschen.Click += new EventHandler(this.ButtonLoeschen_Click);
      this.timerButtonsNeuZeichnen.Tick += new EventHandler(this.timerButtonsNeuZeichnen_Tick);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.toolStrip);
      this.Name = nameof (ucXMLToolbar);
      this.Size = new Size(924, 26);
      this.Load += new EventHandler(this.ucXMLToolbar_Load);
      this.toolStrip.ResumeLayout(false);
      this.toolStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
