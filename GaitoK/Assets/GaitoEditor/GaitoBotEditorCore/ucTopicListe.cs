// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.ucTopicListe
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.toolbox;
using GaitoBotEditorCore.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace GaitoBotEditorCore
{
  public class ucTopicListe : UserControl
  {
    private ListView listThemen;
    private ColumnHeader Thema;
    private ImageList imgListToolbar;
    private ToolStrip toolStrip1;
    private ToolStripButton toolStripButtonNeuesThema;
    private ToolStripButton toolStripButtonTopicLoeschen;
    private ToolStripButton toolStripButtonTopicUmbenennen;
    private IContainer components;
    private bool _wirdGeradeNeuGezeichnet;
    private Arbeitsbereich _arbeitsbereich;

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      this.components = (IContainer) new Container();
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ucTopicListe));
      this.listThemen = new ListView();
      this.Thema = new ColumnHeader();
      this.imgListToolbar = new ImageList(this.components);
      this.toolStrip1 = new ToolStrip();
      this.toolStripButtonNeuesThema = new ToolStripButton();
      this.toolStripButtonTopicLoeschen = new ToolStripButton();
      this.toolStripButtonTopicUmbenennen = new ToolStripButton();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      this.listThemen.BorderStyle = BorderStyle.FixedSingle;
      this.listThemen.Columns.AddRange(new ColumnHeader[1]
      {
        this.Thema
      });
      this.listThemen.FullRowSelect = true;
      this.listThemen.HeaderStyle = ColumnHeaderStyle.Nonclickable;
      this.listThemen.HideSelection = false;
      this.listThemen.Items.AddRange(new ListViewItem[6]
      {
        (ListViewItem) componentResourceManager.GetObject("listThemen.Items"),
        (ListViewItem) componentResourceManager.GetObject("listThemen.Items1"),
        (ListViewItem) componentResourceManager.GetObject("listThemen.Items2"),
        (ListViewItem) componentResourceManager.GetObject("listThemen.Items3"),
        (ListViewItem) componentResourceManager.GetObject("listThemen.Items4"),
        (ListViewItem) componentResourceManager.GetObject("listThemen.Items5")
      });
      componentResourceManager.ApplyResources((object) this.listThemen, "listThemen");
      this.listThemen.MultiSelect = false;
      this.listThemen.Name = "listThemen";
      this.listThemen.UseCompatibleStateImageBehavior = false;
      this.listThemen.View = View.List;
      this.listThemen.SelectedIndexChanged += new EventHandler(this.listThemen_SelectedIndexChanged);
      componentResourceManager.ApplyResources((object) this.Thema, "Thema");
      this.imgListToolbar.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imgListToolbar.ImageStream");
      this.imgListToolbar.TransparentColor = Color.Transparent;
      this.imgListToolbar.Images.SetKeyName(0, "");
      this.imgListToolbar.Images.SetKeyName(1, "");
      this.toolStrip1.Items.AddRange(new ToolStripItem[3]
      {
        (ToolStripItem) this.toolStripButtonNeuesThema,
        (ToolStripItem) this.toolStripButtonTopicLoeschen,
        (ToolStripItem) this.toolStripButtonTopicUmbenennen
      });
      componentResourceManager.ApplyResources((object) this.toolStrip1, "toolStrip1");
      this.toolStrip1.Name = "toolStrip1";
      this.toolStripButtonNeuesThema.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonNeuesThema.Image = (Image) Resources.add_161;
      componentResourceManager.ApplyResources((object) this.toolStripButtonNeuesThema, "toolStripButtonNeuesThema");
      this.toolStripButtonNeuesThema.Name = "toolStripButtonNeuesThema";
      this.toolStripButtonNeuesThema.Click += new EventHandler(this.toolStripButtonNeuesThema_Click);
      this.toolStripButtonTopicLoeschen.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonTopicLoeschen.Image = (Image) Resources.delete_161;
      componentResourceManager.ApplyResources((object) this.toolStripButtonTopicLoeschen, "toolStripButtonTopicLoeschen");
      this.toolStripButtonTopicLoeschen.Name = "toolStripButtonTopicLoeschen";
      this.toolStripButtonTopicLoeschen.Click += new EventHandler(this.toolStripButtonLoeschen_Click);
      this.toolStripButtonTopicUmbenennen.DisplayStyle = ToolStripItemDisplayStyle.Image;
      this.toolStripButtonTopicUmbenennen.Image = (Image) Resources.rename1;
      componentResourceManager.ApplyResources((object) this.toolStripButtonTopicUmbenennen, "toolStripButtonTopicUmbenennen");
      this.toolStripButtonTopicUmbenennen.Name = "toolStripButtonTopicUmbenennen";
      this.toolStripButtonTopicUmbenennen.Click += new EventHandler(this.toolStripButtonTopicUmbenennen_Click);
      this.Controls.Add((Control) this.toolStrip1);
      this.Controls.Add((Control) this.listThemen);
      this.Name = nameof (ucTopicListe);
      componentResourceManager.ApplyResources((object) this, "$this");
      this.Load += new EventHandler(this.ucThemenListe_Load);
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    private AIMLDatei AimlDatei
    {
      get
      {
        if (this._arbeitsbereich == null || !(this._arbeitsbereich.Fokus.AktDatei is AIMLDatei))
          return (AIMLDatei) null;
        return (AIMLDatei) this._arbeitsbereich.Fokus.AktDatei;
      }
    }

    private AIMLTopic AktuellesThema
    {
      get
      {
        if (this._arbeitsbereich == null)
          throw new ApplicationException("Noch kein Arbeitsbereich zugewiesen!");
        return this._arbeitsbereich.Fokus.AktAIMLTopic;
      }
      set
      {
        if (this._arbeitsbereich == null)
          throw new ApplicationException("Noch kein Arbeitsbereich zugewiesen!");
        this._arbeitsbereich.Fokus.AktAIMLTopic = value;
      }
    }

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Dieser AIMLTopicListe wurde bereits ein Arbeitsbereich zugeordnet");
        this._arbeitsbereich = value;
        this._arbeitsbereich.Fokus.AktAIMLTopicChanged += new ArbeitsbereichFokus.AktAIMLTopicChangedEventHandler(this.Fokus_AktAIMLTopicChanged);
        this.AIMLTopicsNeuAnzeigen();
      }
    }

    public ucTopicListe()
    {
      this.InitializeComponent();
      this.Resize += new EventHandler(this.ucThemenListe_Resize);
    }

    private void ucThemenListe_Load(object sender, EventArgs e)
    {
      this.SteuerElementeBeschriften();
      this.listThemen.Columns.Add("Datei", "Datei");
      this.listThemen.FullRowSelect = true;
      this.listThemen.HideSelection = false;
      this.listThemen.MultiSelect = false;
      this.listThemen.HeaderStyle = ColumnHeaderStyle.None;
      this.listThemen.View = View.Details;
      this.ucThemenListe_Resize((object) null, (EventArgs) null);
      this.listThemen.AllowDrop = true;
      this.listThemen.DragEnter += new DragEventHandler(this.listThemen_DragOver);
      this.listThemen.DragOver += new DragEventHandler(this.listThemen_DragOver);
      this.listThemen.DragDrop += new DragEventHandler(this.listThemen_DragDrop);
      this.listThemen.MouseMove += new MouseEventHandler(this.listThemen_MouseMove);
    }

    private bool DateiIstReadOnly
    {
      get
      {
        return this.AimlDatei != null && this.AimlDatei.ReadOnly;
      }
    }

    private void listThemen_MouseMove(object sender, MouseEventArgs e)
    {
      if (this.DateiIstReadOnly || e.Button != MouseButtons.Left)
        return;
      AIMLTopic aktuellesThema = this.AktuellesThema;
      if (aktuellesThema != null && !aktuellesThema.IstRootTopic && this.listThemen.DoDragDrop((object) aktuellesThema, DragDropEffects.Copy | DragDropEffects.Move) == DragDropEffects.Move)
      {
        this.AimlDatei.LoescheTopic(aktuellesThema);
        this._arbeitsbereich.Fokus.BestesTopicSelektieren();
      }
    }

    private void listThemen_DragOver(object sender, DragEventArgs e)
    {
      if (this.DateiIstReadOnly)
        return;
      if (e.Data.GetDataPresent(typeof (AIMLCategory)))
      {
        AIMLCategory data = (AIMLCategory) e.Data.GetData(typeof (AIMLCategory));
        if (data != null)
        {
          AIMLTopic aimlTopic = this.TopicUnterPos(new Point(e.X, e.Y));
          if (aimlTopic != null)
          {
            if (aimlTopic != data.AIMLTopic)
              e.Effect = DragDropEffects.Move;
            else
              e.Effect = DragDropEffects.None;
          }
          else
            e.Effect = DragDropEffects.None;
        }
        else
          e.Effect = DragDropEffects.None;
      }
      else
        e.Effect = DragDropEffects.None;
    }

    private void listThemen_DragDrop(object sender, DragEventArgs e)
    {
      if (this.DateiIstReadOnly)
        return;
      if (e.Data.GetDataPresent(typeof (AIMLCategory)))
      {
        AIMLCategory data = (AIMLCategory) e.Data.GetData(typeof (AIMLCategory));
        if (data == null)
          return;
        AIMLTopic aimlTopic = this.TopicUnterPos(new Point(e.X, e.Y));
        if (aimlTopic != null)
        {
          if (aimlTopic != data.AIMLTopic)
          {
            aimlTopic.AddNewCategory().ContentNode.InnerXml = data.ContentNode.InnerXml;
            e.Effect = DragDropEffects.Move;
          }
          else
            e.Effect = DragDropEffects.None;
        }
        else
          e.Effect = DragDropEffects.None;
      }
      else
        e.Effect = DragDropEffects.None;
    }

    private AIMLTopic TopicUnterPos(Point screenPos)
    {
      Point client = this.listThemen.PointToClient(screenPos);
      ListViewItem itemAt = this.listThemen.GetItemAt(client.X, client.Y);
      if (itemAt == null)
        return (AIMLTopic) null;
      AIMLTopic tag = (AIMLTopic) itemAt.Tag;
      if (tag != null)
        return tag;
      return (AIMLTopic) null;
    }

    private void Fokus_AktAIMLTopicChanged(
      object sender,
      ArbeitsbereichFokus.AktAIMLTopicChangedEventArgs e)
    {
      this.AIMLTopicsNeuAnzeigen();
    }

    private void ucThemenListe_Resize(object sender, EventArgs e)
    {
      this.listThemen.Top = this.toolStrip1.Top + this.toolStrip1.Height;
      this.listThemen.Left = 0;
      this.listThemen.Height = this.ClientSize.Height - this.listThemen.Top;
      this.listThemen.Width = this.ClientSize.Width;
      this.listThemen.Columns[0].Width = this.listThemen.ClientSize.Width;
    }

    private void listThemen_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this._wirdGeradeNeuGezeichnet)
        return;
      ListView.SelectedListViewItemCollection selectedItems = this.listThemen.SelectedItems;
      if (selectedItems.Count == 1)
      {
        if (selectedItems[0].Tag != null && selectedItems[0].Tag is AIMLTopic)
          this.AktuellesThema = (AIMLTopic) selectedItems[0].Tag;
        else
          this.AktuellesThema = (AIMLTopic) null;
      }
      else
        this.AktuellesThema = (AIMLTopic) null;
    }

    private void AIMLTopicsNeuAnzeigen()
    {
      if (this._wirdGeradeNeuGezeichnet)
        return;
      this._wirdGeradeNeuGezeichnet = true;
      AIMLDatei aimlDatei = this.AimlDatei;
      if (aimlDatei == null)
      {
        this.Enabled = false;
        this.listThemen.Items.Clear();
      }
      else
      {
        IOrderedEnumerable<AIMLTopic> source = aimlDatei.getTopics().OrderBy<AIMLTopic, string>((Func<AIMLTopic, string>) (t => t.Name));
        while (this.listThemen.Items.Count < source.Count<AIMLTopic>())
          this.listThemen.Items.Add(new ListViewItem());
        int index = 0;
        foreach (AIMLTopic aimlTopic in (IEnumerable<AIMLTopic>) source)
        {
          ListViewItem listViewItem = this.listThemen.Items[index];
          listViewItem.Tag = (object) aimlTopic;
          this.ListenEintragBeschriften(listViewItem);
          ++index;
        }
        for (int count = this.listThemen.Items.Count; count > source.Count<AIMLTopic>(); count = this.listThemen.Items.Count)
          this.listThemen.Items.Remove(this.listThemen.Items[count - 1]);
        this.Enabled = true;
      }
      this.ToolStripButtonsAnzeigen();
      this._wirdGeradeNeuGezeichnet = false;
    }

    private void ListenEintragBeschriften(ListViewItem item)
    {
      AIMLTopic tag = (AIMLTopic) item.Tag;
      string name = tag.Name;
      if (item.Text != name)
        item.Text = name;
      bool flag = tag == this.AktuellesThema;
      if (item.Selected == flag)
        return;
      item.Selected = flag;
    }

    private void NeuesTopicHinzufuegen()
    {
      if (this.DateiIstReadOnly)
        return;
      this.AktuellesThema = this.AimlDatei.AddNewTopic();
    }

    private void AktuellesTopicLoeschen()
    {
      if (this.DateiIstReadOnly)
        return;
      AIMLTopic aktuellesThema = this.AktuellesThema;
      if (aktuellesThema == null)
        return;
      if (aktuellesThema.IstRootTopic)
      {
        int num = (int) MessageBox.Show(ResReader.Reader.GetString("RootTopicKannNichtGeloeschtWerden"));
      }
      else if (MessageBox.Show(string.Format(ResReader.Reader.GetString("SollDasThemaWirklichGeloeschtWerden"), (object) aktuellesThema.Name), ResReader.Reader.GetString("ThemaLoeschen"), MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
      {
        this.AimlDatei.LoescheTopic(aktuellesThema);
        this._arbeitsbereich.Fokus.BestesTopicSelektieren();
      }
    }

    private void SteuerElementeBeschriften()
    {
      this.toolStripButtonTopicLoeschen.Text = ResReader.Reader.GetString("toolStripButtonTopicLoeschen");
      this.toolStripButtonTopicUmbenennen.Text = ResReader.Reader.GetString("toolStripButtonTopicUmbenennen");
      this.toolStripButtonNeuesThema.Text = ResReader.Reader.GetString("toolStripButtonNeuesThema");
    }

    private void toolStripButtonLoeschen_Click(object sender, EventArgs e)
    {
      this.AktuellesTopicLoeschen();
    }

    private void ToolStripButtonsAnzeigen()
    {
      this.toolStripButtonNeuesThema.Enabled = !this.DateiIstReadOnly;
      AIMLTopic aktuellesThema = this.AktuellesThema;
      if (aktuellesThema == null || this.DateiIstReadOnly)
      {
        this.toolStripButtonTopicLoeschen.Enabled = false;
        this.toolStripButtonTopicUmbenennen.Enabled = false;
      }
      else
      {
        this.toolStripButtonTopicLoeschen.Enabled = !aktuellesThema.IstRootTopic;
        this.toolStripButtonTopicUmbenennen.Enabled = !aktuellesThema.IstRootTopic;
      }
    }

    private void toolStripButtonNeuesThema_Click(object sender, EventArgs e)
    {
      this.NeuesTopicHinzufuegen();
      this.AktuellesTopicUmbenennen();
    }

    private void toolStripButtonTopicUmbenennen_Click(object sender, EventArgs e)
    {
      if (this.DateiIstReadOnly)
        return;
      this.AktuellesTopicUmbenennen();
    }

    public void AktuellesTopicUmbenennen()
    {
      AIMLTopic aktuellesThema = this.AktuellesThema;
      if (aktuellesThema == null)
        return;
      if (aktuellesThema.IstRootTopic)
      {
        int num1 = (int) MessageBox.Show(ResReader.Reader.GetString("KannStandardTopicNichtUmbenennen"), ResReader.Reader.GetString("KonnteAIMLTopicNichtUmbenennen"));
      }
      else
      {
        bool abgebrochen = false;
        bool flag = false;
        while (!flag)
        {
          string str1 = InputBox.Show(ResReader.Reader.GetString("BitteNamenFuerAIMLTopic"), ResReader.Reader.GetString("NameFuerAIMLTopicVergeben"), aktuellesThema.Name, out abgebrochen);
          if (str1 == "" || str1 == null)
            abgebrochen = true;
          if (abgebrochen)
          {
            flag = true;
          }
          else
          {
            string str2 = str1.Trim();
            if (aktuellesThema.Name == str2)
            {
              flag = true;
            }
            else
            {
              string text = (string) null;
              foreach (AIMLTopic topic in aktuellesThema.AIMLDatei.getTopics())
              {
                if (aktuellesThema != topic && topic.Name == str2)
                  text = string.Format(ResReader.Reader.GetString("TopicNameSchonVorhanden"), (object) str2);
              }
              if (text == null)
              {
                try
                {
                  aktuellesThema.Name = str2;
                  this.AIMLTopicsNeuAnzeigen();
                  flag = true;
                }
                catch (Exception ex)
                {
                  text = ex.Message;
                }
              }
              if (text != null)
              {
                int num2 = (int) MessageBox.Show(text, ResReader.Reader.GetString("KonnteAIMLTopicNichtUmbenennen"));
                Debugger.GlobalDebugger.Protokolliere("Konnte AIMLTopic '" + aktuellesThema.Name + "' nicht umbenennen:" + text, Debugger.ProtokollTypen.Fehlermeldung);
              }
            }
          }
        }
      }
    }
  }
}
