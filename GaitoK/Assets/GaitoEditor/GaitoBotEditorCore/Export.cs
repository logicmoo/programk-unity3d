// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.Export
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace GaitoBotEditorCore
{
  public class Export : UserControl
  {
    private IContainer components = (IContainer) null;
    private Arbeitsbereich _arbeitsbereich;
    private FolderBrowserDialog folderBrowserDialog;
    private TextBox textBoxExportVerzeichnis;
    private Button buttonDurchsuchen;
    private Label labelExportVerzeichnis;
    private Button buttonExportStarten;
    private CheckBox checkBoxVorExportVerzeichnisLeeren;
    private CheckBox checkBoxAlleStarTagsInEineDatei;

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Diesem ExportSteuerelement wurde bereits ein Arbeitsbereich zugeordnet");
        this._arbeitsbereich = value;
        this.Anzeigen();
      }
    }

    public Export()
    {
      this.InitializeComponent();
    }

    private void Export_Load(object sender, EventArgs e)
    {
      this.SteuerelementeBenennen();
    }

    private void buttonExportStarten_Click(object sender, EventArgs e)
    {
      if (this._arbeitsbereich.Exportverzeichnis != this.textBoxExportVerzeichnis.Text)
        this._arbeitsbereich.Exportverzeichnis = this.textBoxExportVerzeichnis.Text;
      if (this._arbeitsbereich.Dateiverwaltung.DateienIsChanged)
      {
        if (MessageBox.Show(ResReader.Reader.GetString("ArbeitsBereichMussVorExportGespeichertWerden"), nameof (Export), MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
        {
          this._arbeitsbereich.SaveAll();
        }
        else
        {
          int num = (int) MessageBox.Show(ResReader.Reader.GetString("ExportAbgebrochen"));
          return;
        }
      }
      string exportverzeichnis = this._arbeitsbereich.Exportverzeichnis;
      try
      {
        if (!Directory.Exists(exportverzeichnis))
        {
          if (MessageBox.Show(ResReader.Reader.GetString("SollExportVerzeichnisAngelegtWerden"), nameof (Export), MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
          {
            Directory.CreateDirectory(exportverzeichnis);
          }
          else
          {
            int num = (int) MessageBox.Show(ResReader.Reader.GetString("ExportAbgebrochen"));
            return;
          }
        }
      }
      catch (Exception ex)
      {
        Debugger.GlobalDebugger.FehlerZeigen(ex.Message, (object) ("CreateExportDirectory '" + exportverzeichnis + "'"), nameof (Export));
        int num = (int) MessageBox.Show(ResReader.Reader.GetString("ExportAbgebrochen"));
        return;
      }
      this.Enabled = false;
      bool abgebrochen = false;
      Arbeitsbereich.VerzeichnisVorherLeeren verzeichnisVorherLeeren = Arbeitsbereich.VerzeichnisVorherLeeren.nichtLeeren;
      if (this.checkBoxVorExportVerzeichnisLeeren.Checked)
        verzeichnisVorherLeeren = Arbeitsbereich.VerzeichnisVorherLeeren.leerenUndVorherFragen;
      this._arbeitsbereich.Exportieren(exportverzeichnis, verzeichnisVorherLeeren, this._arbeitsbereich.AlleStarTagsInExtraDateiExportieren, false, out abgebrochen);
      if (abgebrochen)
      {
        int num1 = (int) MessageBox.Show(ResReader.Reader.GetString("ExportAbgebrochen"));
      }
      else
      {
        int num2 = (int) MessageBox.Show(ResReader.Reader.GetString("ExportErfolgreich"));
      }
      this.Enabled = true;
    }

    private void Anzeigen()
    {
      if (this._arbeitsbereich == null)
      {
        this.Enabled = false;
      }
      else
      {
        this.Enabled = true;
        this.checkBoxVorExportVerzeichnisLeeren.Checked = this._arbeitsbereich.ExportverzeichnisVorExportLeeren;
        this.checkBoxAlleStarTagsInEineDatei.Checked = this._arbeitsbereich.AlleStarTagsInExtraDateiExportieren;
        this.textBoxExportVerzeichnis.Text = this._arbeitsbereich.Exportverzeichnis;
      }
    }

    private void buttonDurchsuchen_Click(object sender, EventArgs e)
    {
      this.folderBrowserDialog.ShowNewFolderButton = true;
      this.folderBrowserDialog.SelectedPath = this.textBoxExportVerzeichnis.Text;
      if (this.folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
        return;
      this._arbeitsbereich.Exportverzeichnis = this.folderBrowserDialog.SelectedPath;
      this.Anzeigen();
    }

    private void SteuerelementeBenennen()
    {
      this.labelExportVerzeichnis.Text = ResReader.Reader.GetString("labelExportVerzeichnis");
      this.buttonDurchsuchen.Text = ResReader.Reader.GetString("ExportButtonDurchsuchenText");
      this.buttonExportStarten.Text = ResReader.Reader.GetString("ExportStarten");
      this.checkBoxVorExportVerzeichnisLeeren.Text = ResReader.Reader.GetString("checkBoxVorExportVerzeichnisLeeren");
      this.checkBoxAlleStarTagsInEineDatei.Text = ResReader.Reader.GetString("checkBoxAlleStarTagsInEineDatei");
    }

    private void checkBoxVorExportVerzeichnisLeeren_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBoxVorExportVerzeichnisLeeren.Checked == this._arbeitsbereich.ExportverzeichnisVorExportLeeren)
        return;
      this._arbeitsbereich.ExportverzeichnisVorExportLeeren = this.checkBoxVorExportVerzeichnisLeeren.Checked;
    }

    private void checkBoxAlleStarTagsInEineDatei_CheckedChanged(object sender, EventArgs e)
    {
      if (this.checkBoxAlleStarTagsInEineDatei.Checked == this._arbeitsbereich.AlleStarTagsInExtraDateiExportieren)
        return;
      this._arbeitsbereich.AlleStarTagsInExtraDateiExportieren = this.checkBoxAlleStarTagsInEineDatei.Checked;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (Export));
      this.folderBrowserDialog = new FolderBrowserDialog();
      this.textBoxExportVerzeichnis = new TextBox();
      this.buttonDurchsuchen = new Button();
      this.labelExportVerzeichnis = new Label();
      this.buttonExportStarten = new Button();
      this.checkBoxVorExportVerzeichnisLeeren = new CheckBox();
      this.checkBoxAlleStarTagsInEineDatei = new CheckBox();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.textBoxExportVerzeichnis, "textBoxExportVerzeichnis");
      this.textBoxExportVerzeichnis.Name = "textBoxExportVerzeichnis";
      componentResourceManager.ApplyResources((object) this.buttonDurchsuchen, "buttonDurchsuchen");
      this.buttonDurchsuchen.Name = "buttonDurchsuchen";
      this.buttonDurchsuchen.UseVisualStyleBackColor = true;
      this.buttonDurchsuchen.Click += new EventHandler(this.buttonDurchsuchen_Click);
      componentResourceManager.ApplyResources((object) this.labelExportVerzeichnis, "labelExportVerzeichnis");
      this.labelExportVerzeichnis.Name = "labelExportVerzeichnis";
      componentResourceManager.ApplyResources((object) this.buttonExportStarten, "buttonExportStarten");
      this.buttonExportStarten.Name = "buttonExportStarten";
      this.buttonExportStarten.UseVisualStyleBackColor = true;
      this.buttonExportStarten.Click += new EventHandler(this.buttonExportStarten_Click);
      componentResourceManager.ApplyResources((object) this.checkBoxVorExportVerzeichnisLeeren, "checkBoxVorExportVerzeichnisLeeren");
      this.checkBoxVorExportVerzeichnisLeeren.Name = "checkBoxVorExportVerzeichnisLeeren";
      this.checkBoxVorExportVerzeichnisLeeren.UseVisualStyleBackColor = true;
      this.checkBoxVorExportVerzeichnisLeeren.CheckedChanged += new EventHandler(this.checkBoxVorExportVerzeichnisLeeren_CheckedChanged);
      componentResourceManager.ApplyResources((object) this.checkBoxAlleStarTagsInEineDatei, "checkBoxAlleStarTagsInEineDatei");
      this.checkBoxAlleStarTagsInEineDatei.Name = "checkBoxAlleStarTagsInEineDatei";
      this.checkBoxAlleStarTagsInEineDatei.UseVisualStyleBackColor = true;
      this.checkBoxAlleStarTagsInEineDatei.CheckedChanged += new EventHandler(this.checkBoxAlleStarTagsInEineDatei_CheckedChanged);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.checkBoxAlleStarTagsInEineDatei);
      this.Controls.Add((Control) this.checkBoxVorExportVerzeichnisLeeren);
      this.Controls.Add((Control) this.buttonExportStarten);
      this.Controls.Add((Control) this.labelExportVerzeichnis);
      this.Controls.Add((Control) this.buttonDurchsuchen);
      this.Controls.Add((Control) this.textBoxExportVerzeichnis);
      this.Name = nameof (Export);
      this.Load += new EventHandler(this.Export_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}
