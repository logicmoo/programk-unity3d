// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.KlappbareGroupBox
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Windows.Forms.VisualStyles;

namespace de.springwald.toolbox
{
  [ToolboxBitmap(typeof (KlappbareGroupBox))]
  public class KlappbareGroupBox : System.Windows.Forms.GroupBox
  {
    private Color _buttonBackgroundColor = Color.White;
    private Color _buttonDrawColor = Color.Black;
    private Rectangle m_toggleRect = new Rectangle(8, 2, 11, 11);
    private bool m_collapsed = false;
    private bool m_bResizingFromCollapse = false;
    private Size m_FullSize = Size.Empty;
    private IContainer components = (IContainer) null;
    private const int m_collapsedHeight = 20;

    public event KlappbareGroupBox.CollapseBoxClickedEventHandler CollapseBoxClickedEvent;

    public KlappbareGroupBox()
    {
      this.InitializeComponent();
    }

    public Color BorderColor
    {
      get
      {
        return this._buttonDrawColor;
      }
      set
      {
        this._buttonDrawColor = value;
        this.Invalidate();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int FullHeight
    {
      get
      {
        return this.m_FullSize.Height;
      }
    }

    [DefaultValue(false)]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsCollapsed
    {
      get
      {
        return this.m_collapsed;
      }
      set
      {
        if (value == this.m_collapsed)
          return;
        this.m_collapsed = value;
        if (!value)
        {
          this.Size = this.m_FullSize;
        }
        else
        {
          this.m_bResizingFromCollapse = true;
          this.Height = 20;
          this.m_bResizingFromCollapse = false;
        }
        foreach (Control control in (ArrangedElementCollection) this.Controls)
          control.Visible = !value;
        this.Invalidate();
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int CollapsedHeight
    {
      get
      {
        return 20;
      }
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      if (this.m_toggleRect.Contains(e.Location))
        this.ToggleCollapsed();
      else
        base.OnMouseUp(e);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      this.HandleResize();
      this.DrawGroupBox(e.Graphics);
      this.DrawToggleButton(e.Graphics);
    }

        private void DrawGroupBox(Graphics g)
        {
            Rectangle bounds = new Rectangle();// = null;
            ref Rectangle local = ref bounds;
            Rectangle clientRectangle = this.ClientRectangle;
            int x = clientRectangle.X;
            clientRectangle = this.ClientRectangle;
            int y = clientRectangle.Y + 6;
            clientRectangle = this.ClientRectangle;
            int width1 = clientRectangle.Width;
            clientRectangle = this.ClientRectangle;
            int height = clientRectangle.Height - 6;
            local = new Rectangle(x, y, width1, height);
            GroupBoxRenderer.DrawGroupBox(g, bounds, this.Enabled ? GroupBoxState.Normal : GroupBoxState.Disabled);
            StringFormat stringFormat = new StringFormat();
            int num1 = bounds.X + 8 + this.m_toggleRect.Width + 2;
            int width2 = (int)g.MeasureString(this.Text, this.Font).Width;
            int num2 = width2 < 1 ? 1 : width2;
            int num3 = num1 + num2 + 1;
            using (SolidBrush solidBrush = new SolidBrush(this.BackColor))
                g.FillRectangle((Brush)solidBrush, 8, 2, num3 - 8, 12);
            using (SolidBrush solidBrush = new SolidBrush(this.ForeColor))
                g.DrawString(this.Text, this.Font, (Brush)solidBrush, (float)num1, 0.0f);
        }

    private void DrawToggleButton(Graphics g)
    {
      using (SolidBrush solidBrush = new SolidBrush(this._buttonBackgroundColor))
      {
        g.FillRectangle((Brush) solidBrush, this.m_toggleRect);
        using (Pen pen = new Pen(this._buttonDrawColor))
          g.DrawRectangle(pen, this.m_toggleRect.Left + 1, this.m_toggleRect.Top + 1, 8, 8);
        using (Pen pen = new Pen(this._buttonDrawColor))
          g.DrawLine(pen, this.m_toggleRect.Left + 3, this.m_toggleRect.Bottom - 6, this.m_toggleRect.Right - 4, this.m_toggleRect.Bottom - 6);
        if (!this.IsCollapsed)
          return;
        using (Pen pen = new Pen(this._buttonDrawColor))
          g.DrawLine(pen, this.m_toggleRect.Left + 5, this.m_toggleRect.Top + 3, this.m_toggleRect.Left + 5, this.m_toggleRect.Bottom - 4);
      }
    }

    private void ToggleCollapsed()
    {
      this.IsCollapsed = !this.IsCollapsed;
      if (this.CollapseBoxClickedEvent == null)
        return;
      this.CollapseBoxClickedEvent((object) this);
    }

    private void HandleResize()
    {
      if (this.m_bResizingFromCollapse || this.m_collapsed)
        return;
      this.m_FullSize = this.Size;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing && this.components != null)
        this.components.Dispose();
      base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
      ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (KlappbareGroupBox));
      this.SuspendLayout();
      this.Name = nameof (KlappbareGroupBox);
      this.ResumeLayout(false);
    }

    public delegate void CollapseBoxClickedEventHandler(object sender);
  }
}
