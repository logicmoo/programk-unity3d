// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.controls.ucBotDenkprotokoll
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using de.springwald.gaitobot2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace GaitoBotEditorCore.controls
{
  public class ucBotDenkprotokoll : UserControl
  {
    private IContainer components = (IContainer) null;
    private Arbeitsbereich _arbeitsbereich;
    private ListView listViewSchritte;
    private Label labelDenkprotokoll;
    private ImageList imageListDenkprotokoll;

    public event ucBotDenkprotokoll.CategoryAngewaehltEventHandler CategoryAngewaehlt;

    protected virtual void CategoryAngewaehltEvent(WissensCategory category)
    {
      if (this.CategoryAngewaehlt == null)
        return;
      this.CategoryAngewaehlt((object) this, new ucBotDenkprotokoll.CategoryAngewaehltEventArgs(category));
    }

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Diesem ucBotDenkProtokoll wurde bereits ein Arbeitsbereich zugeordnet");
        this._arbeitsbereich = value;
      }
    }

    public List<BotDenkProtokollSchritt> Denkprotokoll
    {
      set
      {
        this.DenkprotokollAnzeigen(value);
      }
    }

    public ucBotDenkprotokoll()
    {
      this.InitializeComponent();
    }

    private void ucBotDenkprotokoll_Load(object sender, EventArgs e)
    {
      this.SteuerelementeBeschriften();
      this.Resize += new EventHandler(this.ucBotDenkprotokoll_Resize);
      this.listViewSchritte.MouseMove += new MouseEventHandler(this.listViewSchritte_MouseMove);
    }

    private void listViewSchritte_MouseMove(object sender, MouseEventArgs e)
    {
      ListViewItem itemAt = this.listViewSchritte.GetItemAt(e.X, e.Y);
      if (itemAt == null)
        this.Cursor = Cursors.Default;
      else if (itemAt.Tag == null)
        this.Cursor = Cursors.Default;
      else
        this.Cursor = Cursors.Hand;
    }

    private void ucBotDenkprotokoll_Resize(object sender, EventArgs e)
    {
      this.labelDenkprotokoll.Top = 5;
      this.labelDenkprotokoll.Left = 0;
      this.listViewSchritte.Left = 0;
      this.listViewSchritte.Top = this.labelDenkprotokoll.Top + this.labelDenkprotokoll.Height;
      this.listViewSchritte.Height = this.ClientSize.Height - this.listViewSchritte.Top;
      this.listViewSchritte.Width = this.ClientSize.Width;
      int width = this.listViewSchritte.ClientSize.Width;
      int num = width;
      if (this.listViewSchritte.Columns.Count != 2)
        return;
      this.listViewSchritte.Columns[0].Width = width / 3;
      this.listViewSchritte.Columns[1].Width = num - this.listViewSchritte.Columns[0].Width;
    }

    private void DenkprotokollAnzeigen(List<BotDenkProtokollSchritt> denkprotokoll)
    {
      this.listViewSchritte.Items.Clear();
      foreach (BotDenkProtokollSchritt schritt in denkprotokoll)
        this.listViewSchritte.Items.Add(this.Zeile(schritt));
    }

    private ListViewItem Zeile(BotDenkProtokollSchritt schritt)
    {
      ListViewItem listViewItem = new ListViewItem();
      if (schritt.Category != null)
        listViewItem.Tag = (object) schritt.Category;
      switch (schritt.Art)
      {
        case BotDenkProtokollSchritt.SchrittArten.Eingabe:
          listViewItem.ImageKey = "eingabe";
          listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem());
          listViewItem.SubItems[0].Text = GaitoBotEditorCore.ResReader.Reader.GetString("DenkProtokollEingabe");
          listViewItem.SubItems[1].Text = schritt.Meldung;
          break;
        case BotDenkProtokollSchritt.SchrittArten.Info:
          listViewItem.ImageKey = "info";
          listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem());
          listViewItem.SubItems[0].Text = GaitoBotEditorCore.ResReader.Reader.GetString("DenkprotokollInfo");
          listViewItem.SubItems[1].Text = schritt.Meldung;
          break;
        case BotDenkProtokollSchritt.SchrittArten.Warnung:
          listViewItem.ImageKey = "warnung";
          listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem());
          listViewItem.SubItems[0].Text = GaitoBotEditorCore.ResReader.Reader.GetString("Warnung");
          listViewItem.SubItems[1].Text = schritt.Meldung;
          break;
        case BotDenkProtokollSchritt.SchrittArten.PassendeKategorieGefunden:
          listViewItem.ImageKey = "categoryfound";
          listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem());
          listViewItem.SubItems[0].Text = GaitoBotEditorCore.ResReader.Reader.GetString("passendeKategorieGefunden");
          listViewItem.SubItems[1].Text = this.BotCategoryBeschreibung(schritt.Category);
          break;
        default:
          listViewItem.SubItems.Add(new ListViewItem.ListViewSubItem());
          listViewItem.SubItems[1].Text = schritt.Meldung;
          break;
      }
      return listViewItem;
    }

    private void SteuerelementeBeschriften()
    {
      this.labelDenkprotokoll.Text = GaitoBotEditorCore.ResReader.Reader.GetString("labelDenkprotokoll");
      this.listViewSchritte.Columns.Add(GaitoBotEditorCore.ResReader.Reader.GetString("DenkprotokollColumnArt"));
      this.listViewSchritte.Columns.Add(GaitoBotEditorCore.ResReader.Reader.GetString("DenkprotokollColumnInhalt"));
    }

    private void listViewSchritte_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (this.listViewSchritte.SelectedItems.Count != 1)
        return;
      ListViewItem selectedItem = this.listViewSchritte.SelectedItems[0];
      if (selectedItem.Tag != null)
        this.CategoryAngewaehltEvent((WissensCategory) selectedItem.Tag);
    }

    private string BotCategoryBeschreibung(WissensCategory category)
    {
      XmlNode categoryNode = category.CategoryNode;
      if (categoryNode != null)
      {
        AIMLCategory categoryForCategoryNode = this._arbeitsbereich.GetCategoryForCategoryNode(categoryNode);
        if (categoryForCategoryNode != null)
          return categoryForCategoryNode.AutoKomplettZusammenfassung;
      }
      return string.Format("{0}|THAT:{1}|TOPIC:{2}", (object) category.Pattern, (object) category.That, (object) category.ThemaName);
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
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ucBotDenkprotokoll));
      this.listViewSchritte = new ListView();
      this.imageListDenkprotokoll = new ImageList(this.components);
      this.labelDenkprotokoll = new Label();
      this.SuspendLayout();
      this.listViewSchritte.BorderStyle = BorderStyle.None;
      this.listViewSchritte.Cursor = Cursors.Default;
      this.listViewSchritte.FullRowSelect = true;
      this.listViewSchritte.GridLines = true;
      this.listViewSchritte.HideSelection = false;
      componentResourceManager.ApplyResources((object) this.listViewSchritte, "listViewSchritte");
      this.listViewSchritte.MultiSelect = false;
      this.listViewSchritte.Name = "listViewSchritte";
      this.listViewSchritte.SmallImageList = this.imageListDenkprotokoll;
      this.listViewSchritte.UseCompatibleStateImageBehavior = false;
      this.listViewSchritte.View = View.Details;
      this.listViewSchritte.SelectedIndexChanged += new EventHandler(this.listViewSchritte_SelectedIndexChanged);
      this.imageListDenkprotokoll.ImageStream = (ImageListStreamer) componentResourceManager.GetObject("imageListDenkprotokoll.ImageStream");
      this.imageListDenkprotokoll.TransparentColor = Color.Transparent;
      this.imageListDenkprotokoll.Images.SetKeyName(0, "warnung");
      this.imageListDenkprotokoll.Images.SetKeyName(1, "categoryfound");
      this.imageListDenkprotokoll.Images.SetKeyName(2, "info");
      this.imageListDenkprotokoll.Images.SetKeyName(3, "eingabe");
      componentResourceManager.ApplyResources((object) this.labelDenkprotokoll, "labelDenkprotokoll");
      this.labelDenkprotokoll.Name = "labelDenkprotokoll";
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.Controls.Add((Control) this.labelDenkprotokoll);
      this.Controls.Add((Control) this.listViewSchritte);
      this.Name = nameof (ucBotDenkprotokoll);
      this.Load += new EventHandler(this.ucBotDenkprotokoll_Load);
      this.ResumeLayout(false);
      this.PerformLayout();
    }

    public class CategoryAngewaehltEventArgs : EventArgs
    {
      public WissensCategory Category;

      public CategoryAngewaehltEventArgs(WissensCategory category)
      {
        this.Category = category;
      }
    }

    public delegate void CategoryAngewaehltEventHandler(
      object sender,
      ucBotDenkprotokoll.CategoryAngewaehltEventArgs e);
  }
}
