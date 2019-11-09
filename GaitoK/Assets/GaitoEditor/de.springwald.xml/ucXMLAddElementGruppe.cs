// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.ucXMLAddElementGruppe
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.toolbox;
using de.springwald.xml.editor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace de.springwald.xml
{
  public class ucXMLAddElementGruppe : UserControl
  {
    private bool _buttonWirdGeradeGeklickt = false;
    private IContainer components = (IContainer) null;
    private XMLEditor _xmlEditor;
    private ArrayList _buttons;
    private string[] _elemente;
    private XMLElementGruppe _gruppe;
    private KlappbareGroupBox klappbareGroupBox;

    public ucXMLAddElementGruppe(XMLElementGruppe gruppe, XMLEditor xmlEditor)
    {
      this._xmlEditor = xmlEditor;
      this._gruppe = gruppe;
      this.InitializeComponent();
    }

    private void ucXMLAddElementGruppe_Load(object sender, EventArgs e)
    {
      if (this._gruppe == null)
      {
        this.klappbareGroupBox.Visible = false;
      }
      else
      {
        this.klappbareGroupBox.Visible = true;
        this.klappbareGroupBox.Text = this._gruppe.Titel;
        this.klappbareGroupBox.IsCollapsed = this._gruppe.StandardMaessigZusammengeklappt;
        this.klappbareGroupBox.CollapseBoxClickedEvent += new KlappbareGroupBox.CollapseBoxClickedEventHandler(this.klappbareGroupBox_CollapseBoxClickedEvent);
      }
      this._buttons = new ArrayList();
      this.Resize += new EventHandler(this.ucXMLAddElementGruppe_Resize);
    }

    private void klappbareGroupBox_CollapseBoxClickedEvent(object sender)
    {
      this.ButtonsAnzeigen();
    }

    public string[] VerfuegbareElementeZuweisenUndRestElementeZurueckGeben(string[] elemente)
    {
      List<string> stringList1 = new List<string>();
      List<string> stringList2 = new List<string>();
      foreach (string name in elemente)
      {
        if (this._gruppe == null)
          stringList2.Add(name);
        else if (this._gruppe.ContainsElement(name))
          stringList2.Add(name);
        else
          stringList1.Add(name);
      }
      this._elemente = stringList2.ToArray();
      this.ButtonsAnzeigen();
      if (this._gruppe != null)
      {
        string str = string.Format("{0} ({1})", (object) this._gruppe.Titel, (object) this._elemente.Length);
        if (this.klappbareGroupBox.Text != str)
          this.klappbareGroupBox.Text = str;
      }
      return stringList1.ToArray();
    }

    private void ButtonsAnzeigen()
    {
      if (this._gruppe != null && this.klappbareGroupBox.IsCollapsed)
      {
        this.NichtMehrBenoetigteButtonsLoeschen();
        this.Height = this.klappbareGroupBox.Top + this.klappbareGroupBox.Height;
      }
      else if (this._elemente == null)
      {
        this.NichtMehrBenoetigteButtonsLoeschen();
      }
      else
      {
        int num1 = 5;
        int num2 = this._gruppe != null ? 20 : num1;
        for (int index = 0; index < this._elemente.Length; ++index)
        {
          Button button;
          if (index < this._buttons.Count)
          {
            button = (Button) this._buttons[index];
          }
          else
          {
            button = new Button();
            button.Top = num2;
            button.Left = num1;
            button.Visible = true;
            button.Click += new EventHandler(this.Button_Click);
            this._buttons.Add((object) button);
            if (this._gruppe == null)
              button.Parent = (Control) this;
            else
              button.Parent = (Control) this.klappbareGroupBox;
          }
          Size clientSize;
          int num3;
          if (this._gruppe == null)
          {
            clientSize = this.ClientSize;
            num3 = clientSize.Width - num1 * 2;
          }
          else
          {
            clientSize = this.ClientSize;
            num3 = clientSize.Width - num1 * 3;
          }
          if (button.Width != num3)
            button.Width = num3;
          if (button.Text != this._elemente[index])
            button.Text = this._elemente[index];
          num2 += button.Height + num1;
        }
        if (this._gruppe == null)
        {
          if (this.Height != num2)
            this.Height = num2;
        }
        else
        {
          if (this.klappbareGroupBox.Height != num2 + num1 + num1)
            this.klappbareGroupBox.Height = num2 + num1 + num1;
          if (this.Height != this.klappbareGroupBox.Top + this.klappbareGroupBox.Height)
            this.Height = this.klappbareGroupBox.Top + this.klappbareGroupBox.Height;
        }
        this.NichtMehrBenoetigteButtonsLoeschen();
      }
      bool flag = this._elemente != null && (uint) this._elemente.Length > 0U;
      if (this.Visible == flag)
        return;
      this.Visible = flag;
    }

    private void ucXMLAddElementGruppe_Resize(object sender, EventArgs e)
    {
      if ((uint) this.klappbareGroupBox.Top > 0U)
        this.klappbareGroupBox.Top = 0;
      if ((uint) this.klappbareGroupBox.Left > 0U)
        this.klappbareGroupBox.Left = 0;
      if (this.klappbareGroupBox.Width != this.ClientSize.Width)
        this.klappbareGroupBox.Width = this.ClientSize.Width;
      this.ButtonsAnzeigen();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (this.components != null)
          this.components.Dispose();
        this.DisposeButtons_();
      }
      base.Dispose(disposing);
    }

    private void DisposeButtons_()
    {
      if (this._buttons == null)
        return;
      foreach (Button button in this._buttons)
      {
        if (button != null)
        {
          button.Click -= new EventHandler(this.Button_Click);
          button.Dispose();
        }
      }
      this._buttons = (ArrayList) null;
    }

    private void Button_Click(object sender, EventArgs e)
    {
      if (this._buttonWirdGeradeGeklickt)
        return;
      this._buttonWirdGeradeGeklickt = true;
      if (this._buttons != null)
      {
        string nodeName = (string) null;
        for (int index = 0; index < this._buttons.Count; ++index)
        {
          if (this._buttons[index] == sender)
            nodeName = this._elemente[index];
        }
        if (nodeName == null || this._xmlEditor.AktionNeuesElementAnAktCursorPosEinfuegen(nodeName, XMLEditor.UndoSnapshotSetzenOptionen.ja, false) != null)
          ;
      }
      this._xmlEditor.FokusAufEingabeFormularSetzen();
      this._buttonWirdGeradeGeklickt = false;
    }

    private void NichtMehrBenoetigteButtonsLoeschen()
    {
      if (this._buttons == null)
        return;
      int num = this._xmlEditor != null && this._xmlEditor.RootNode != null && this._elemente != null ? (this._gruppe == null || !this.klappbareGroupBox.IsCollapsed ? this._elemente.Length : 0) : 0;
      while (this._buttons.Count > num)
      {
        Button button = (Button) this._buttons[this._buttons.Count - 1];
        this._buttons.Remove((object) button);
        button.Click -= new EventHandler(this.Button_Click);
        button.Dispose();
      }
    }

    private void klappbareGroupBox_Enter(object sender, EventArgs e)
    {
    }

    private void InitializeComponent()
    {
      this.klappbareGroupBox = new KlappbareGroupBox();
      this.SuspendLayout();
      this.klappbareGroupBox.BorderColor = Color.Black;
      this.klappbareGroupBox.Location = new Point(0, 0);
      this.klappbareGroupBox.Margin = new Padding(0);
      this.klappbareGroupBox.MinimumSize = new Size(0, 25);
      this.klappbareGroupBox.Name = "klappbareGroupBox";
      this.klappbareGroupBox.Padding = new Padding(0);
      this.klappbareGroupBox.Size = new Size(134, 139);
      this.klappbareGroupBox.TabIndex = 0;
      this.klappbareGroupBox.TabStop = false;
      this.klappbareGroupBox.Text = "klappbareGroupBox";
      this.klappbareGroupBox.Enter += new EventHandler(this.klappbareGroupBox_Enter);
      this.AutoScaleDimensions = new SizeF(6f, 13f);
      this.AutoScaleMode = AutoScaleMode.Font;
      this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      this.BackColor = SystemColors.Control;
      this.Controls.Add((Control) this.klappbareGroupBox);
      this.Margin = new Padding(0);
      this.Name = nameof (ucXMLAddElementGruppe);
      this.Size = new Size(140, 170);
      this.Load += new EventHandler(this.ucXMLAddElementGruppe_Load);
      this.ResumeLayout(false);
    }
  }
}
