// Decompiled with JetBrains decompiler
// Type: TD.SandDock.TabPage
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
  [Designer("TD.SandDock.Design.TabPageDesigner, SandDock.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
  [ToolboxItem(false)]
  public class TabPage : Panel
  {
    private Image xe058541ca798c059;
    private int x3214e09b677ccd2b;
    internal double x9b0739496f8b5475;
    internal int xa806b754814b9ae0;
    internal Rectangle x123e054dab107457;
    internal bool xcfac6723d8a41375;

    public event EventHandler Load;

    public TabPage()
    {
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
    }

    protected override void Dispose(bool disposing)
    {
      int num = disposing ? 1 : 0;
      base.Dispose(disposing);
    }

    public TabPage(string text)
      : this()
    {
      this.Text = text;
    }

    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      this.OnLoad(EventArgs.Empty);
    }

    protected virtual void OnLoad(EventArgs e)
    {
      if (this.x5d95f5f98c940295 == null)
        return;
      this.x5d95f5f98c940295((object) this, e);
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
      if (this.ClientRectangle == Rectangle.Empty)
      {
        if (true)
          return;
      }
      else if (!(this.Parent is TabControl) || !((TabControl) this.Parent).Renderer.ShouldDrawTabControlBackground)
      {
        base.OnPaintBackground(pevent);
        return;
      }
      ((TabControl) this.Parent).Renderer.DrawTabControlBackground(pevent.Graphics, this.ClientRectangle, this.BackColor, true);
    }

    protected override void CreateHandle()
    {
      int newIndex = -1;
      do
      {
        if (this.Parent != null)
          goto label_5;
label_1:
        base.CreateHandle();
        if (this.Parent == null)
          continue;
        goto label_2;
label_5:
        newIndex = this.Parent.Controls.IndexOf((Control) this);
        if (false)
          goto label_7;
        else
          goto label_1;
      }
      while (false);
      goto label_6;
label_2:
      this.Parent.Controls.SetChildIndex((Control) this, newIndex);
      return;
label_6:
      return;
label_7:;
    }

    public override Color BackColor
    {
      get
      {
        return base.BackColor;
      }
      set
      {
        base.BackColor = value;
        if (!(this.Parent is TabControl))
          return;
        this.Parent.Invalidate(this.x123e054dab107457);
      }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override DockStyle Dock
    {
      get
      {
        return base.Dock;
      }
      set
      {
        base.Dock = value;
      }
    }

    [Browsable(false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override AnchorStyles Anchor
    {
      get
      {
        return base.Anchor;
      }
      set
      {
        base.Anchor = value;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new bool Enabled
    {
      get
      {
        return base.Enabled;
      }
      set
      {
        base.Enabled = value;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new int TabIndex
    {
      get
      {
        return base.TabIndex;
      }
      set
      {
        base.TabIndex = value;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new bool TabStop
    {
      get
      {
        return base.TabStop;
      }
      set
      {
        base.TabStop = value;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Browsable(false)]
    public new bool Visible
    {
      get
      {
        return base.Visible;
      }
      set
      {
        base.Visible = value;
      }
    }

    [Category("Layout")]
    [DefaultValue(0)]
    [Description("Indicates the maximum width of the tab.")]
    public int MaximumTabWidth
    {
      get
      {
        return this.x3214e09b677ccd2b;
      }
      set
      {
        if (value < 0)
          throw new ArgumentException("Value must be greater than or equal to zero.");
        this.x3214e09b677ccd2b = value;
        if (!(this.Parent is TabControl))
          return;
        ((TabControl) this.Parent).x436f6f3ee14607e0();
      }
    }

    [Browsable(true)]
    public override string Text
    {
      get
      {
        return base.Text;
      }
      set
      {
        base.Text = value;
        if (!(this.Parent is TabControl))
          return;
        ((TabControl) this.Parent).x436f6f3ee14607e0();
      }
    }

    [Category("Appearance")]
    [AmbientValue(typeof (Image), null)]
    [DefaultValue(typeof (Image), null)]
    [Description("The image displayed next to the text on the tab.")]
    public Image TabImage
    {
      get
      {
        return this.xe058541ca798c059;
      }
      set
      {
        this.xe058541ca798c059 = value;
        if (!(this.Parent is TabControl))
          return;
        ((TabControl) this.Parent).x436f6f3ee14607e0();
      }
    }

    [Browsable(false)]
    public Rectangle TabBounds
    {
      get
      {
        return this.x123e054dab107457;
      }
    }

    [Browsable(false)]
    [Obsolete]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Guid Guid
    {
      get
      {
        return Guid.Empty;
      }
      set
      {
      }
    }

    [Browsable(false)]
    [Obsolete]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public System.Drawing.Size FloatingSize
    {
      get
      {
        return System.Drawing.Size.Empty;
      }
      set
      {
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Obsolete]
    public string TabText
    {
      get
      {
        return "";
      }
      set
      {
      }
    }
  }
}
