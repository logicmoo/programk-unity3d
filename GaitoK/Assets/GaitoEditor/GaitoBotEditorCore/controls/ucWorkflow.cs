// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.controls.ucWorkflow
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml;

namespace GaitoBotEditorCore.controls
{
  public class ucWorkflow : UserControl
  {
    private int _teilBreite = 200;
    private int _teilHoehe = 60;
    private int _strichLaenge = 60;
    private int _abstand = 10;
    private IContainer components = (IContainer) null;
    private string _lastPaintContent;
    private Arbeitsbereich _arbeitsbereich;
    private ArrayList _klickbereiche;
    private WorkflowAnalyser _analyser;
    private WorkflowElementCategory _categoryPainter;

    public Arbeitsbereich Arbeitsbereich
    {
      set
      {
        if (this._arbeitsbereich != null)
          throw new ApplicationException("Diesem Workflow-Control wurde bereits ein Arbeitsbereich zugewiesen");
        this._arbeitsbereich = value;
        this.Invalidate();
      }
    }

    public AIMLCategory Category
    {
      get
      {
        if (this._categoryPainter == null)
          return (AIMLCategory) null;
        return this._categoryPainter.Category;
      }
      set
      {
        if (value == null)
        {
          this._categoryPainter = (WorkflowElementCategory) null;
          this._analyser = (WorkflowAnalyser) null;
        }
        else
        {
          if (this._categoryPainter != null && this._categoryPainter.Category != value)
            this._categoryPainter = (WorkflowElementCategory) null;
          if (this._categoryPainter == null)
          {
            this._categoryPainter = new WorkflowElementCategory("main", value, this._teilBreite, this._teilHoehe);
            this._categoryPainter.DickerRahmen = true;
            this._categoryPainter.BackgroundColor = Color.FromArgb((int) byte.MaxValue, 240, (int) byte.MaxValue);
            this._analyser = new WorkflowAnalyser(this._arbeitsbereich, value);
          }
        }
        this.Invalidate();
      }
    }

    public ucWorkflow()
    {
      this._klickbereiche = new ArrayList();
      this.InitializeComponent();
    }

    private void ucWorkflow_Load(object sender, EventArgs e)
    {
      this.MouseClick += new MouseEventHandler(this.ucWorkflow_MouseClick);
      this.DoubleBuffered = true;
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.UpdateStyles();
    }

    public void RefreshAnzeige()
    {
      if (this._categoryPainter == null || this._categoryPainter.Category == null)
        return;
      XmlNode contentNode = this._categoryPainter.Category.ContentNode;
      if (contentNode != null && contentNode.OuterXml != this._lastPaintContent)
      {
        this._analyser.FlushBuffer();
        this.Invalidate();
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      e.Graphics.Clear(Color.White);
      this._teilBreite = Math.Max(50, Math.Min(400, this.Parent.Width / 4));
      this._strichLaenge = Math.Min(50, this._teilBreite / 3);
      this.Anzeigen(e);
    }

    private void Anzeigen(PaintEventArgs e)
    {
      this._klickbereiche = new ArrayList();
      if (this._categoryPainter == null || this._categoryPainter.Category == null || this._categoryPainter.Category.ContentNode == null)
        return;
      this._lastPaintContent = this._categoryPainter.Category.ContentNode.OuterXml;
      int abstand1 = this._abstand;
      int abstand2 = this._abstand;
      int num1 = abstand1;
      int x1 = abstand2 + this._teilBreite + this._strichLaenge;
      int num2 = num1;
      int val2_1 = num1;
      int y = abstand1;
      this.CategorieListeZeichnen(e, ref abstand2, ref y, this._analyser.ThatVorgaenger, ucWorkflow.PfeilArten.VorgaengerTHAT, new Point(x1, num2 + this._teilHoehe / 2));
      if (y != abstand1)
        y += this._abstand;
      this.CategorieListeZeichnen(e, ref abstand2, ref y, this._analyser.SraiVorgaenger, ucWorkflow.PfeilArten.VorgaengerSRAI, new Point(x1, num2 + this._teilHoehe / 2));
      y += this._abstand;
      int val2_2 = Math.Max(y, val2_1);
      int num3 = abstand2 + (this._teilBreite + this._abstand + this._strichLaenge);
      int x2 = x1;
      y = num2;
      this.AktuelleKategorieZeichnen(e, ref x2, ref y);
      y += this._abstand;
      int val2_3 = Math.Max(y, val2_2);
      this.CategorieListeZeichnen(e, ref x2, ref y, this._analyser.Duplikate, ucWorkflow.PfeilArten.Redundanz, new Point(x1 + this._teilBreite / 2, num2 + this._teilHoehe));
      y += this._abstand;
      int val2_4 = Math.Max(y, val2_3);
      x2 += this._teilBreite + this._abstand + this._strichLaenge;
      y = abstand1;
      this.CategorieListeZeichnen(e, ref x2, ref y, this._analyser.ThatNachfolger, ucWorkflow.PfeilArten.NachfolgerTHAT, new Point(x1 + this._teilBreite, num2 + this._teilHoehe / 2));
      if (y != abstand1)
        y += this._abstand;
      this.CategorieListeZeichnen(e, ref x2, ref y, this._analyser.SraiNachfolger, ucWorkflow.PfeilArten.NachfolgerSRAI, new Point(x1 + this._teilBreite, num2 + this._teilHoehe / 2));
      y += this._abstand;
      int num4 = Math.Max(y, val2_4);
      x2 += this._teilBreite + this._abstand;
      this.Width = x2;
      this.Height = num4;
    }

    private void CategorieListeZeichnen(
      PaintEventArgs e,
      ref int x,
      ref int y,
      List<AIMLCategory> liste,
      ucWorkflow.PfeilArten pfeilArt,
      Point dockPunktAnAktKategorie)
    {
      Pen pen1 = (Pen) null;
      Pen pen2 = (Pen) null;
      Color color = Color.White;
      string kontext = "";
      switch (pfeilArt)
      {
        case ucWorkflow.PfeilArten.VorgaengerTHAT:
        case ucWorkflow.PfeilArten.NachfolgerTHAT:
          kontext = "THAT";
          color = Color.FromArgb(240, 240, (int) byte.MaxValue);
          break;
        case ucWorkflow.PfeilArten.VorgaengerSRAI:
        case ucWorkflow.PfeilArten.NachfolgerSRAI:
          kontext = "SRAI";
          color = Color.FromArgb(210, 210, 230);
          break;
        case ucWorkflow.PfeilArten.Redundanz:
          kontext = "IDENT";
          color = Color.FromArgb(250, 250, (int) byte.MaxValue);
          break;
      }
      switch (pfeilArt)
      {
        case ucWorkflow.PfeilArten.VorgaengerTHAT:
        case ucWorkflow.PfeilArten.VorgaengerSRAI:
        case ucWorkflow.PfeilArten.NachfolgerTHAT:
        case ucWorkflow.PfeilArten.NachfolgerSRAI:
          pen1 = new Pen(Color.Gray, 1f);
          pen2 = new Pen(Color.Gray, 1f);
          pen2.EndCap = LineCap.ArrowAnchor;
          break;
        case ucWorkflow.PfeilArten.Redundanz:
          pen1 = new Pen(Color.LightBlue, 1f);
          pen2 = new Pen(Color.LightBlue, 1f);
          pen2.EndCap = LineCap.ArrowAnchor;
          break;
      }
      foreach (AIMLCategory category in liste)
      {
        WorkflowElementCategory workflowElementCategory = new WorkflowElementCategory(kontext, category, this._teilBreite, this._teilHoehe);
        workflowElementCategory.X = x;
        workflowElementCategory.Y = y;
        workflowElementCategory.BackgroundColor = color;
        workflowElementCategory.Paint(e);
        this._klickbereiche.Add((object) new WorkflowKlickbereich(workflowElementCategory.Category, new Rectangle(workflowElementCategory.X, workflowElementCategory.Y, workflowElementCategory.Breite, workflowElementCategory.Hoehe)));
        switch (pfeilArt)
        {
          case ucWorkflow.PfeilArten.VorgaengerTHAT:
          case ucWorkflow.PfeilArten.VorgaengerSRAI:
            Point pt2_1 = new Point(x + this._teilBreite, y + this._teilHoehe / 2);
            Point pt1_1 = new Point(x + this._teilBreite + this._strichLaenge / 2, y + this._teilHoehe / 2);
            Point point1 = new Point(x + this._teilBreite + this._strichLaenge / 2, dockPunktAnAktKategorie.Y);
            e.Graphics.DrawLine(pen1, pt1_1, pt2_1);
            e.Graphics.DrawLine(pen1, pt1_1, point1);
            e.Graphics.DrawLine(pen2, point1, dockPunktAnAktKategorie);
            break;
          case ucWorkflow.PfeilArten.Redundanz:
            Point pt2_2 = new Point(x, y + this._teilHoehe / 2);
            Point pt1_2 = new Point(x - this._strichLaenge / 4, y + this._teilHoehe / 2);
            Point point2 = new Point(x - this._strichLaenge / 4, dockPunktAnAktKategorie.Y + 10);
            Point point3 = new Point(dockPunktAnAktKategorie.X, dockPunktAnAktKategorie.Y + 10);
            e.Graphics.DrawLine(pen2, pt1_2, pt2_2);
            e.Graphics.DrawLine(pen1, pt1_2, point2);
            e.Graphics.DrawLine(pen1, point2, point3);
            e.Graphics.DrawLine(pen2, point3, dockPunktAnAktKategorie);
            break;
          case ucWorkflow.PfeilArten.NachfolgerTHAT:
          case ucWorkflow.PfeilArten.NachfolgerSRAI:
            Point pt2_3 = new Point(x, y + this._teilHoehe / 2);
            Point pt1_3 = new Point(x - this._strichLaenge / 3, y + this._teilHoehe / 2);
            Point point4 = new Point(x - this._strichLaenge / 3, dockPunktAnAktKategorie.Y);
            e.Graphics.DrawLine(pen2, pt1_3, pt2_3);
            e.Graphics.DrawLine(pen1, pt1_3, point4);
            e.Graphics.DrawLine(pen1, point4, dockPunktAnAktKategorie);
            break;
        }
        y += this._teilHoehe + this._abstand;
      }
      if (pen1 != null)
        pen1.Dispose();
      if (pen2 == null)
        return;
      pen2.Dispose();
    }

    private void ucWorkflow_MouseClick(object sender, MouseEventArgs e)
    {
      if (this._arbeitsbereich == null)
        return;
      Point pt = new Point(e.X, e.Y);
      foreach (WorkflowKlickbereich workflowKlickbereich in this._klickbereiche)
      {
        if (workflowKlickbereich.Bereich.Contains(pt) && workflowKlickbereich.Category != null && workflowKlickbereich.Category != this._arbeitsbereich.Fokus.AktAIMLCategory)
          this._arbeitsbereich.Fokus.AktAIMLCategory = workflowKlickbereich.Category;
      }
    }

    private void AktuelleKategorieZeichnen(PaintEventArgs e, ref int x, ref int y)
    {
      this._categoryPainter.X = x;
      this._categoryPainter.Y = y;
      this._categoryPainter.Breite = this._teilBreite;
      this._categoryPainter.Paint(e);
      y += this._teilHoehe + this._abstand;
      this._klickbereiche.Add((object) new WorkflowKlickbereich(this._categoryPainter.Category, new Rectangle(this._categoryPainter.X, this._categoryPainter.Y, this._categoryPainter.Breite, this._categoryPainter.Hoehe)));
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (ucWorkflow));
      this.SuspendLayout();
      componentResourceManager.ApplyResources((object) this, "$this");
      this.AutoScaleMode = AutoScaleMode.Font;
      this.BackColor = Color.FromArgb((int) byte.MaxValue, 192, 192);
      this.Name = nameof (ucWorkflow);
      this.Load += new EventHandler(this.ucWorkflow_Load);
      this.ResumeLayout(false);
    }

    private enum PfeilArten
    {
      VorgaengerTHAT,
      VorgaengerSRAI,
      Redundanz,
      NachfolgerTHAT,
      NachfolgerSRAI,
    }
  }
}
