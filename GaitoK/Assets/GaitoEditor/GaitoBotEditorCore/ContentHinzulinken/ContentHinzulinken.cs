// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.ContentHinzulinken.ContentHinzulinken
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.gaitobot.content;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace GaitoBotEditorCore.ContentHinzulinken
{
  public class ContentHinzulinken : Form
  {
    private IContainer components = (IContainer) null;
    private Arbeitsbereich _arbeitbereich;
    private List<ContentInfo> _infos;
    private Panel panel1;
    private Button buttonFertig;
    private Label labelAnweisung;

    public ContentHinzulinken(Arbeitsbereich arbeitsbereich)
    {
      this._arbeitbereich = arbeitsbereich;
      this.InitializeComponent();
      this.Load += new EventHandler(this.ContentHinzulinken_Load);
      this.Closing += new CancelEventHandler(this.ContentHinzulinken_Closing);
    }

    private void ContentHinzulinken_Load(object sender, EventArgs e)
    {
      this.GewaehlteBausteineAnzeigen();
      this.AbhaengigkeitenAnzeigen();
    }

    private void ContentHinzulinken_Closing(object sender, CancelEventArgs e)
    {
      ContentManager contentManager = new ContentManager();
      List<string> stringList = new List<string>();
      foreach (ContentInfo info in this._infos)
      {
        if (info.Gewaehlt)
          stringList.Add(info.Info.UniqueKey);
      }
      this._arbeitbereich.ContentElementUniqueIds = stringList.ToArray();
      this._arbeitbereich.Dateiverwaltung.VordefinierteDateienHinzulinken(this._arbeitbereich);
    }

    private void GewaehlteBausteineAnzeigen()
    {
      this._infos = new List<ContentInfo>();
      int num = 0;
      foreach (ContentElementInfo contentElementInfo in new ContentManager().EnthalteneContentElementInfos)
      {
        ContentInfo contentInfo = new ContentInfo();
        this.panel1.Controls.Add((Control) contentInfo);
        this._infos.Add(contentInfo);
        contentInfo.Info = contentElementInfo;
        contentInfo.Gewaehlt = ((IEnumerable<string>) this._arbeitbereich.ContentElementUniqueIds).Contains<string>(contentElementInfo.UniqueKey);
        contentInfo.Width = this.panel1.Width - 10;
        contentInfo.Top = num;
        num += contentInfo.Height;
        contentInfo.GewaehltChanged += new EventHandler(this.info_GewaehltChanged);
      }
    }

    private void info_GewaehltChanged(object sender, EventArgs e)
    {
      this.AbhaengigkeitenAnzeigen();
    }

    private void AbhaengigkeitenAnzeigen()
    {
      foreach (ContentInfo info in this._infos)
        info.WahlEnabled = true;
      foreach (ContentInfo info1 in this._infos)
      {
        if (info1.Gewaehlt)
        {
          foreach (ContentInfo info2 in this._infos)
          {
            if (((IEnumerable<string>) info1.Info.AbhaengigkeitenUniqueIds).Contains<string>(info2.Info.UniqueKey))
            {
              info2.Gewaehlt = true;
              info2.WahlEnabled = false;
            }
          }
        }
      }
    }

    private void buttonFertig_Click(object sender, EventArgs e)
    {
      this.Close();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (GaitoBotEditorCore.ContentHinzulinken.ContentHinzulinken));
      this.panel1 = new Panel();
      this.buttonFertig = new Button();
      this.labelAnweisung = new Label();
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this.panel1, "panel1");
      this.panel1.Name = "panel1";
      componentResourceManager.ApplyResources((object) this.buttonFertig, "buttonFertig");
      this.buttonFertig.Name = "buttonFertig";
      this.buttonFertig.UseVisualStyleBackColor = true;
      this.buttonFertig.Click += new EventHandler(this.buttonFertig_Click);
      componentResourceManager.ApplyResources((object) this.labelAnweisung, "labelAnweisung");
      this.labelAnweisung.Name = "labelAnweisung";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.labelAnweisung);
      this.Controls.Add((Control) this.buttonFertig);
      this.Controls.Add((Control) this.panel1);
      this.FormBorderStyle = FormBorderStyle.FixedSingle;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = nameof (ContentHinzulinken);
      this.SizeGripStyle = SizeGripStyle.Hide;
      this.TopMost = true;
      this.ResumeLayout(false);
    }
  }
}
