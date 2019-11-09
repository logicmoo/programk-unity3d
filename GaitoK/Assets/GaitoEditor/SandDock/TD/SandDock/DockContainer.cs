// Decompiled with JetBrains decompiler
// Type: TD.SandDock.DockContainer
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using Divelements.Util.Registration;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using TD.SandDock.Design;
using TD.SandDock.Rendering;
using TD.Util;

namespace TD.SandDock
{
  [Designer(typeof (DockContainerDesigner))]
  [LicenseProvider(typeof (x294bd621a33dc533))]
  [ToolboxItem(false)]
  public class DockContainer : ContainerControl
  {
    private Rectangle x59f159fe47159543 = Rectangle.Empty;
    private Rectangle x21ed2ecc088ef4e4 = Rectangle.Empty;
    private int xd987e7deb2afdfde = 100;
    private const int xdb2b8faf7aefe99a = 32;
    private SandDockManager x91f347c6e97f1846;
    private SplitLayoutSystem x35c76d526f88c3c8;
    internal ArrayList x83627743ea4ce5a2;
    private RendererBase xa2c39ea75c543fc7;
    private xf8f9565783602018 xac1c850120b1f254;
    private int xa03963cfd21be862;
    private static bool x1f080f764b4036b1;
    private xbd7c5470fc89975b x266365ea27fa7af8;
    private x09c1c18390e52ebf x754f1c6f433be75d;
    private bool x841598f8fd19209c;
    internal LayoutSystemBase x3df31cf55a47bc37;

    public event EventHandler DockingStarted;

    public event EventHandler DockingFinished;

    public DockContainer()
    {
      this.x266365ea27fa7af8 = LicenseManager.Validate(typeof (DockContainer), (object) this) as xbd7c5470fc89975b;
      do
      {
        this.x35c76d526f88c3c8 = new SplitLayoutSystem();
        this.x35c76d526f88c3c8.x56e964269d48cfcc(this);
        this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
      }
      while (false);
      this.SetStyle(ControlStyles.Selectable, false);
      this.x83627743ea4ce5a2 = new ArrayList();
      this.xac1c850120b1f254 = new xf8f9565783602018((Control) this);
      this.xac1c850120b1f254.xa6e4f463e64a5987 = false;
      this.xac1c850120b1f254.x9b21ee8e7ceaada3 += new xf8f9565783602018.x58986a4a0b75e5b5(this.xa3a7472ac4e61f76);
      this.BackColor = SystemColors.Control;
    }

    internal Rectangle x0c42f19be578ccee
    {
      get
      {
        return this.x59f159fe47159543;
      }
    }

    internal virtual void x5fc4eceec879ff0f()
    {
    }

    protected override void OnParentChanged(EventArgs e)
    {
      base.OnParentChanged(e);
      if (this.Manager == null)
        return;
label_5:
      if (this.Parent == null)
        goto label_2;
label_1:
      if (this.Parent is xd936980ea1aac341)
        return;
      this.Manager.DockSystemContainer = this.Parent;
      if (true)
        return;
label_2:
      if (true)
        return;
      if (true)
        goto label_1;
      else
        goto label_5;
    }

    internal void x8ba6fce4f4601549(ShowControlContextMenuEventArgs xfbf34718e704c6bc)
    {
      if (this.Manager == null)
        return;
      this.Manager.OnShowControlContextMenu(xfbf34718e704c6bc);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        goto label_3;
label_2:
      base.Dispose(disposing);
      return;
label_3:
      while (this.xa2c39ea75c543fc7 != null)
      {
        this.xa2c39ea75c543fc7.Dispose();
        this.xa2c39ea75c543fc7 = (RendererBase) null;
        if (true)
          break;
      }
      this.Manager = (SandDockManager) null;
      this.xac1c850120b1f254.x9b21ee8e7ceaada3 -= new xf8f9565783602018.x58986a4a0b75e5b5(this.xa3a7472ac4e61f76);
      this.xac1c850120b1f254.Dispose();
      goto label_2;
    }

    public ControlLayoutSystem CreateNewLayoutSystem(SizeF size)
    {
      return this.CreateNewLayoutSystem(new DockControl[0], size);
    }

    public ControlLayoutSystem CreateNewLayoutSystem(
      DockControl control,
      SizeF size)
    {
      return this.CreateNewLayoutSystem(new DockControl[1]{ control }, size);
    }

    public ControlLayoutSystem CreateNewLayoutSystem(
      DockControl[] controls,
      SizeF size)
    {
      if (controls == null)
      {
        if (true)
          goto label_6;
      }
      else
        goto label_7;
label_2:
      ControlLayoutSystem controlLayoutSystem;
      controlLayoutSystem.Controls.AddRange(controls);
      if (true)
        goto label_8;
label_3:
      if (controls != null)
      {
        if (controls.Length == 0)
        {
          if (true)
            goto label_8;
        }
        else
          goto label_2;
      }
      else
        goto label_8;
label_6:
      throw new ArgumentNullException(nameof (controls));
label_7:
      controlLayoutSystem = this.xd6284ffe96aec512();
      controlLayoutSystem.WorkingSize = size;
      goto label_3;
label_8:
      return controlLayoutSystem;
    }

    internal virtual ControlLayoutSystem xd6284ffe96aec512()
    {
      return new ControlLayoutSystem();
    }

    [Browsable(false)]
    public override DockStyle Dock
    {
      get
      {
        return base.Dock;
      }
      set
      {
        if (value != DockStyle.None)
          goto label_16;
label_15:
        throw new ArgumentException("The value None is not supported for DockContainers.");
label_16:
        base.Dock = value;
        Orientation orientation = Orientation.Horizontal;
label_9:
        if (this.Dock == DockStyle.Top)
          goto label_6;
        else
          goto label_10;
label_2:
        while (this.x35c76d526f88c3c8.SplitMode != orientation)
        {
          this.x35c76d526f88c3c8.SplitMode = orientation;
          if (true)
          {
            if (true)
            {
              if (true)
                break;
              goto label_15;
            }
            else
              goto label_5;
          }
        }
        return;
label_5:
        if (false)
          return;
        goto label_2;
label_6:
        if (true)
          goto label_12;
label_7:
        if (false)
        {
          if (false)
            goto label_6;
          else
            goto label_9;
        }
        else
          goto label_12;
label_10:
        if (this.Dock == DockStyle.Bottom)
          goto label_7;
        else
          goto label_5;
label_12:
        orientation = Orientation.Vertical;
        goto label_2;
      }
    }

    [Browsable(false)]
    public override string Text
    {
      get
      {
        return base.Text;
      }
      set
      {
        base.Text = value;
      }
    }

    [Browsable(false)]
    public override Image BackgroundImage
    {
      get
      {
        return base.BackgroundImage;
      }
      set
      {
        base.BackgroundImage = value;
      }
    }

    [DefaultValue(typeof (Color), "Control")]
    [Browsable(false)]
    public override Color BackColor
    {
      get
      {
        return base.BackColor;
      }
      set
      {
        base.BackColor = value;
      }
    }

    [Browsable(false)]
    public override Color ForeColor
    {
      get
      {
        return base.ForeColor;
      }
      set
      {
        base.ForeColor = value;
      }
    }

    [Browsable(false)]
    public bool HasSingleControlLayoutSystem
    {
      get
      {
        if (this.LayoutSystem.LayoutSystems.Count == 1)
          return this.LayoutSystem.LayoutSystems[0] is ControlLayoutSystem;
        return false;
      }
    }

    internal virtual RendererBase x631afe05fcecf1f4
    {
      get
      {
        if (this.x91f347c6e97f1846 != null)
        {
          if (true)
            goto label_6;
        }
        else
          goto label_4;
label_2:
        return this.x91f347c6e97f1846.Renderer;
label_4:
        if (this.xa2c39ea75c543fc7 == null)
        {
          this.xa2c39ea75c543fc7 = (RendererBase) new WhidbeyRenderer();
          goto label_8;
        }
        else if (true)
          goto label_8;
label_6:
        if (this.x91f347c6e97f1846.Renderer != null)
        {
          if (true)
            goto label_2;
        }
        else
          goto label_4;
label_8:
        return this.xa2c39ea75c543fc7;
      }
    }

    public int ContentSize
    {
      get
      {
        return this.xd987e7deb2afdfde;
      }
      set
      {
        value = Math.Max(value, 32);
        while (value == this.xd987e7deb2afdfde)
        {
          if ((uint) value <= uint.MaxValue)
            return;
        }
        this.x841598f8fd19209c = true;
        do
        {
          this.xd987e7deb2afdfde = value;
          this.x333d8ec4f70a6d86();
        }
        while (false);
      }
    }

    internal int x555227b0d2a372bd
    {
      get
      {
        if (this.x61c108cc44ef385a)
          return this.x21ed2ecc088ef4e4.Width;
        return this.x21ed2ecc088ef4e4.Height;
      }
    }

    [Browsable(false)]
    protected internal virtual bool AllowResize
    {
      get
      {
        if (this.Manager == null)
          return true;
        return this.Manager.AllowDockContainerResize;
      }
    }

    [Browsable(false)]
    public override bool AllowDrop
    {
      get
      {
        return base.AllowDrop;
      }
      set
      {
        base.AllowDrop = value;
      }
    }

    internal object x7159e85e85b84817(System.Type x96168bd31f23b747)
    {
      return this.GetService(x96168bd31f23b747);
    }

    internal bool x972331c8ecf83413
    {
      get
      {
        return this.DesignMode;
      }
    }

    [Browsable(false)]
    public virtual SandDockManager Manager
    {
      get
      {
        return this.x91f347c6e97f1846;
      }
      set
      {
        if (this.x91f347c6e97f1846 != null)
          goto label_20;
label_13:
        if (value != null)
          goto label_15;
label_6:
        this.x91f347c6e97f1846 = value;
        while (this.x91f347c6e97f1846 != null)
        {
          this.x91f347c6e97f1846.RegisterDockContainer(this);
          this.LayoutSystem.x56e964269d48cfcc(this);
          if (true)
            return;
        }
        if (false)
        {
          if (true)
            goto label_11;
          else
            goto label_9;
        }
        else if (true)
          return;
label_7:
        if (value.DockSystemContainer != null)
          goto label_10;
label_8:
        if (true)
          goto label_6;
label_9:
        if (false)
          goto label_7;
label_10:
        if (this.IsFloating)
        {
          if (false)
            goto label_8;
          else
            goto label_6;
        }
        else if (this.Parent == null)
          goto label_6;
        else
          goto label_16;
label_11:
        if (false)
          goto label_6;
        else
          goto label_7;
label_15:
        if (true)
          goto label_11;
label_16:
        if (this.Parent != value.DockSystemContainer)
          throw new ArgumentException("This DockContainer cannot use the specified manager as the manager's DockSystemContainer differs from the DockContainer's Parent.");
        goto label_6;
label_20:
        this.x91f347c6e97f1846.UnregisterDockContainer(this);
        if (true)
          goto label_13;
      }
    }

    protected override System.Drawing.Size DefaultSize
    {
      get
      {
        return new System.Drawing.Size(0, 0);
      }
    }

    [Browsable(false)]
    public virtual bool IsFloating
    {
      get
      {
        return false;
      }
    }

    internal bool x61c108cc44ef385a
    {
      get
      {
        if (this.Dock != DockStyle.Left)
          return this.Dock == DockStyle.Right;
        return true;
      }
    }

    [Browsable(false)]
    public virtual SplitLayoutSystem LayoutSystem
    {
      get
      {
        return this.x35c76d526f88c3c8;
      }
      set
      {
        if (value == this.x35c76d526f88c3c8)
          return;
        if (value == null)
          throw new ArgumentNullException(nameof (value));
        DockContainer.x1f080f764b4036b1 = true;
        try
        {
          if (this.x35c76d526f88c3c8 != null)
          {
            if (true)
              goto label_9;
          }
          else
            goto label_7;
label_4:
          if (false)
            return;
          this.x35c76d526f88c3c8.x56e964269d48cfcc(this);
          this.x7e9646eed248ed11();
          if (true)
            return;
          goto label_9;
label_7:
          if (!this.x841598f8fd19209c)
            goto label_8;
label_6:
          this.x35c76d526f88c3c8 = value;
          if (true)
            goto label_4;
          else
            goto label_9;
label_8:
          this.xd987e7deb2afdfde = !this.x61c108cc44ef385a ? Convert.ToInt32(value.WorkingSize.Height) : Convert.ToInt32(value.WorkingSize.Width);
          this.x841598f8fd19209c = true;
          goto label_6;
label_9:
          this.x35c76d526f88c3c8.x56e964269d48cfcc((DockContainer) null);
          goto label_7;
        }
        finally
        {
          DockContainer.x1f080f764b4036b1 = false;
        }
      }
    }

    internal void x272ed7848e373c56()
    {
      ++this.xa03963cfd21be862;
      this.x35c76d526f88c3c8.x56e964269d48cfcc((DockContainer) null);
      foreach (LayoutSystemBase layoutSystemBase in this.x83627743ea4ce5a2)
      {
        if (layoutSystemBase is ControlLayoutSystem)
        {
          ((ControlLayoutSystem) layoutSystemBase).Controls.Clear();
          if (false)
            break;
        }
      }
      this.x35c76d526f88c3c8 = new SplitLayoutSystem();
    }

    internal void xfe00f14c7d278916()
    {
      if (this.xa03963cfd21be862 > 0)
      {
        --this.xa03963cfd21be862;
        if (false)
        {
          if (false)
            return;
        }
        else
          goto label_5;
      }
      else
        goto label_5;
label_3:
      this.x7e9646eed248ed11();
      return;
label_5:
      if (this.xa03963cfd21be862 == 0)
        goto label_3;
    }

    internal void x4481febbc2e58301()
    {
      this.CalculateAllMetricsAndLayout();
    }

    [Browsable(false)]
    internal virtual bool x0c2484ccd29b8358
    {
      get
      {
        if (this.Dock != DockStyle.Fill)
          return this.Dock != DockStyle.None;
        return false;
      }
    }

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);
      this.CalculateAllMetricsAndLayout();
    }

    public DockControl GetWindowAt(System.Drawing.Point position)
    {
      return (this.GetLayoutSystemAt(position) as ControlLayoutSystem)?.GetControlAt(position);
    }

    public LayoutSystemBase GetLayoutSystemAt(System.Drawing.Point position)
    {
      LayoutSystemBase layoutSystemBase = (LayoutSystemBase) null;
      IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
      try
      {
label_2:
        if (enumerator.MoveNext())
          goto label_13;
        else
          goto label_4;
label_3:
        if (!(layoutSystemBase is ControlLayoutSystem))
          goto label_7;
        else
          goto label_17;
label_4:
        if (false)
          goto label_3;
        else
          goto label_17;
label_6:
        LayoutSystemBase current;
        Rectangle bounds;
        if (bounds.Contains(position))
        {
          if (current is ControlLayoutSystem)
            goto label_8;
label_5:
          layoutSystemBase = current;
          goto label_3;
label_8:
          if (!((ControlLayoutSystem) current).Collapsed)
          {
            if (true)
            {
              if (true)
              {
                if (false)
                  goto label_13;
                else
                  goto label_5;
              }
            }
            else
              goto label_5;
          }
          else
            goto label_2;
        }
        else
          goto label_2;
label_7:
        if (false)
          goto label_6;
        else
          goto label_2;
label_13:
        current = (LayoutSystemBase) enumerator.Current;
        bounds = current.Bounds;
        goto label_6;
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
label_17:
      return layoutSystemBase;
    }

    internal virtual void x7e9646eed248ed11()
    {
      this.x7e9646eed248ed11(false);
    }

    private void x7e9646eed248ed11(bool xaa70223940104cbe)
    {
      this.x83627743ea4ce5a2.Clear();
      this.x3df31cf55a47bc37 = (LayoutSystemBase) null;
      if (true)
        goto label_2;
label_1:
      this.x333d8ec4f70a6d86();
      Application.Idle += new EventHandler(this.x4130a50ad5956bc2);
      return;
label_2:
      this.x5b6d1177ca7f3461((LayoutSystemBase) this.x35c76d526f88c3c8);
      if (!xaa70223940104cbe && this.xa03963cfd21be862 == 0)
        goto label_1;
    }

    private void x4130a50ad5956bc2(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      Application.Idle -= new EventHandler(this.x4130a50ad5956bc2);
      bool flag1;
      bool flag2;
      do
      {
        if (true)
          goto label_7;
label_3:
        flag1 = true;
        if (false)
          goto label_1;
        else
          goto label_8;
label_7:
        flag1 = false;
label_8:
        flag2 = this.LayoutSystem.Optimize();
        if (flag2)
          goto label_3;
      }
      while ((uint) flag2 > uint.MaxValue);
      goto label_2;
label_1:
      this.x7e9646eed248ed11(true);
      return;
label_2:
      if (flag1)
        goto label_1;
    }

    private void x5b6d1177ca7f3461(LayoutSystemBase x6e150040c8d97700)
    {
      this.x83627743ea4ce5a2.Add((object) x6e150040c8d97700);
      if (!(x6e150040c8d97700 is SplitLayoutSystem))
        return;
      foreach (LayoutSystemBase layoutSystem in (CollectionBase) ((SplitLayoutSystem) x6e150040c8d97700).LayoutSystems)
        this.x5b6d1177ca7f3461(layoutSystem);
    }

    internal bool x61d88745bde7a5ec()
    {
      IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
      bool flag;
      try
      {
label_2:
        if (enumerator.MoveNext())
        {
          while (!((LayoutSystemBase) enumerator.Current is ControlLayoutSystem))
          {
            if (true)
              goto label_2;
          }
          do
          {
            flag = false;
          }
          while (((flag ? 1 : 0) | int.MaxValue) == 0);
          goto label_10;
        }
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
      return true;
label_10:
      return flag;
    }

    internal void x333d8ec4f70a6d86()
    {
      if (!this.x0c2484ccd29b8358)
        goto label_2;
      else
        goto label_33;
label_1:
      this.CalculateAllMetricsAndLayout();
      return;
label_2:
      this.CalculateAllMetricsAndLayout();
      if (true)
        return;
label_3:
      int num1;
      this.Height = num1;
      if (true)
        return;
label_5:
      if (this.x61c108cc44ef385a)
        goto label_1;
label_7:
      if (this.Height != num1)
      {
        if ((num1 & 0) != 0)
          goto label_18;
      }
      else
        goto label_1;
label_13:
      bool flag;
      if ((uint) num1 - (uint) flag <= uint.MaxValue)
        goto label_35;
label_14:
      if (this.x61c108cc44ef385a)
      {
        if ((uint) num1 + (uint) num1 <= uint.MaxValue)
        {
          while (this.Width == num1)
          {
            if (false)
            {
              if (true)
                goto label_5;
            }
            else if ((uint) num1 - (uint) flag >= 0U)
            {
              if ((num1 | 1) == 0 || true)
                goto label_5;
              else
                goto label_7;
            }
            else
              goto label_13;
          }
        }
        this.Width = num1;
        return;
      }
      goto label_5;
label_18:
      if (!flag)
      {
        num1 += this.ContentSize + (this.AllowResize ? 4 : 0);
        goto label_14;
      }
      else
        goto label_34;
label_33:
      flag = true;
      int num2;
      if ((uint) num2 >= 0U)
      {
        IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
        try
        {
          do
          {
            if (!enumerator.MoveNext())
            {
              if ((uint) flag <= uint.MaxValue)
                break;
            }
            LayoutSystemBase current = (LayoutSystemBase) enumerator.Current;
            if (current is ControlLayoutSystem)
            {
              ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem) current;
              if ((uint) num2 + (uint) flag < 0U || !controlLayoutSystem.Collapsed)
              {
                flag = false;
                break;
              }
            }
          }
          while ((uint) num2 >= 0U);
        }
        finally
        {
          (enumerator as IDisposable)?.Dispose();
        }
        num1 = 0;
        goto label_18;
      }
label_34:
      if (true)
        goto label_14;
label_35:
      if ((uint) num1 - (uint) num1 <= uint.MaxValue)
        goto label_3;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);
      this.CalculateAllMetricsAndLayout();
    }

    internal void xec9697acef66c1bc(LayoutSystemBase x6e150040c8d97700, Rectangle xda73fcb97c77d998)
    {
      if (!this.IsHandleCreated)
        return;
      using (Graphics graphics = this.CreateGraphics())
      {
        RendererBase x631afe05fcecf1f4 = this.x631afe05fcecf1f4;
        do
        {
          x631afe05fcecf1f4.StartRenderSession(HotkeyPrefix.None);
          if (x6e150040c8d97700 != this.x35c76d526f88c3c8)
            x6e150040c8d97700.Layout(x631afe05fcecf1f4, graphics, xda73fcb97c77d998, false);
          else
            goto label_4;
        }
        while (false);
        goto label_8;
label_3:
        x631afe05fcecf1f4.FinishRenderSession();
        return;
label_4:
        x6e150040c8d97700.Layout(x631afe05fcecf1f4, graphics, xda73fcb97c77d998, this.IsFloating);
        goto label_3;
label_8:
        if (true)
          goto label_3;
      }
    }

    public void CalculateAllMetricsAndLayout()
    {
      if (!this.IsHandleCreated)
        return;
label_19:
      if (this.Capture && !this.IsFloating)
        goto label_20;
label_15:
      do
      {
        this.x21ed2ecc088ef4e4 = this.DisplayRectangle;
label_4:
        if (this.AllowResize)
          goto label_16;
label_1:
        this.x59f159fe47159543 = Rectangle.Empty;
label_2:
        do
        {
          this.xec9697acef66c1bc((LayoutSystemBase) this.x35c76d526f88c3c8, this.x21ed2ecc088ef4e4);
          this.Invalidate();
        }
        while (false);
        if (true)
        {
          if (true)
            continue;
        }
        else
          goto label_4;
label_6:
        this.x59f159fe47159543 = Rectangle.Empty;
        goto label_2;
label_16:
        do
        {
          DockStyle dock = this.Dock;
          if (true)
          {
            switch (dock)
            {
              case DockStyle.Top:
                goto label_11;
              case DockStyle.Bottom:
                goto label_12;
              case DockStyle.Left:
                goto label_13;
              case DockStyle.Right:
                goto label_14;
              default:
                continue;
            }
          }
          else
            goto label_19;
        }
        while (false);
        goto label_6;
label_11:
        this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Left, this.x21ed2ecc088ef4e4.Bottom - 4, this.x21ed2ecc088ef4e4.Width, 4);
        this.x21ed2ecc088ef4e4.Height -= 4;
        goto label_2;
label_12:
        this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Left, this.x21ed2ecc088ef4e4.Top, this.x21ed2ecc088ef4e4.Width, 4);
        if (false)
        {
          if (false)
            goto label_4;
          else
            goto label_1;
        }
        else if (true)
        {
          this.x21ed2ecc088ef4e4.Offset(0, 4);
          this.x21ed2ecc088ef4e4.Height -= 4;
          goto label_2;
        }
        else
          goto label_22;
label_13:
        this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Right - 4, this.x21ed2ecc088ef4e4.Top, 4, this.x21ed2ecc088ef4e4.Height);
        this.x21ed2ecc088ef4e4.Width -= 4;
        goto label_2;
label_14:
        this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Left, this.x21ed2ecc088ef4e4.Top, 4, this.x21ed2ecc088ef4e4.Height);
        this.x21ed2ecc088ef4e4.Offset(4, 0);
        this.x21ed2ecc088ef4e4.Width -= 4;
        goto label_2;
      }
      while (false);
      return;
label_22:
      return;
label_20:
      this.Capture = false;
      goto label_15;
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      Form form = this.FindForm();
      while (form != null)
      {
        if (true)
          goto label_3;
      }
      goto label_6;
label_3:
      if (form.WindowState == FormWindowState.Minimized)
        return;
label_6:
      this.CalculateAllMetricsAndLayout();
      if (false)
        goto label_3;
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      if (this.x3df31cf55a47bc37 == null)
        return;
      this.x3df31cf55a47bc37.OnMouseLeave();
      this.x3df31cf55a47bc37 = (LayoutSystemBase) null;
    }

    protected override void OnDoubleClick(EventArgs e)
    {
      base.OnDoubleClick(e);
      if (this.x266365ea27fa7af8.Locked || this.x3df31cf55a47bc37 == null)
        return;
      this.x3df31cf55a47bc37.OnMouseDoubleClick();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      if (this.x266365ea27fa7af8.Locked)
        return;
      if (this.x3df31cf55a47bc37 == null)
      {
label_6:
        while (this.x59f159fe47159543.Contains(e.X, e.Y))
        {
          if (this.Manager != null)
            goto label_8;
          else
            goto label_4;
label_2:
          if (true)
            break;
          continue;
label_4:
          if (true)
            break;
          if (true)
            goto label_2;
label_5:
          this.x754f1c6f433be75d.x868a32060451dd2e += new EventHandler(this.x30c28c62b1a6040e);
          this.x754f1c6f433be75d.x67ecc0d0e7c9a202 += new x09c1c18390e52ebf.ResizingManagerFinishedEventHandler(this.xa7afb2334769edc5);
          goto label_2;
label_8:
          while (e.Button == MouseButtons.Left)
          {
            if (this.x754f1c6f433be75d != null)
              goto label_10;
label_7:
            this.x754f1c6f433be75d = new x09c1c18390e52ebf(this.Manager, this, new System.Drawing.Point(e.X, e.Y));
            if (true)
            {
              if (false)
                break;
              goto label_5;
            }
            else
              continue;
label_10:
            this.x754f1c6f433be75d.Dispose();
            if (false)
              goto label_6;
            else
              goto label_7;
          }
          break;
        }
      }
      else
        this.x3df31cf55a47bc37.OnMouseDown(e);
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      if (this.x266365ea27fa7af8.Locked)
        return;
      if (this.x3df31cf55a47bc37 == null)
      {
        if (this.x754f1c6f433be75d == null)
          return;
        this.x754f1c6f433be75d.Commit();
      }
      else
        this.x3df31cf55a47bc37.OnMouseUp(e);
    }

    protected override void OnDragOver(DragEventArgs drgevent)
    {
      base.OnDragOver(drgevent);
      this.GetLayoutSystemAt(this.PointToClient(new System.Drawing.Point(drgevent.X, drgevent.Y)))?.OnDragOver(drgevent);
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (!this.Capture)
        goto label_21;
      else
        goto label_23;
label_20:
      this.x754f1c6f433be75d.OnMouseMove(new System.Drawing.Point(e.X, e.Y));
      return;
label_21:
      LayoutSystemBase layoutSystemAt = this.GetLayoutSystemAt(new System.Drawing.Point(e.X, e.Y));
label_17:
      if (layoutSystemAt != null)
        goto label_18;
      else
        goto label_22;
label_15:
      layoutSystemAt.OnMouseMove(e);
      this.x3df31cf55a47bc37 = layoutSystemAt;
      return;
label_18:
      if (this.x3df31cf55a47bc37 != null && this.x3df31cf55a47bc37 != layoutSystemAt)
      {
        this.x3df31cf55a47bc37.OnMouseLeave();
        goto label_15;
      }
      else
        goto label_15;
label_22:
      if (true)
        goto label_8;
      else
        goto label_7;
label_1:
      if (!this.x59f159fe47159543.Contains(e.X, e.Y))
      {
        Cursor.Current = Cursors.Default;
        return;
      }
label_3:
      if (!this.x61c108cc44ef385a)
        goto label_5;
label_4:
      Cursor.Current = Cursors.VSplit;
      return;
label_5:
      Cursor.Current = Cursors.HSplit;
      if (true)
      {
        if (true)
          return;
        goto label_1;
      }
      else
        goto label_4;
label_7:
      if (true)
        goto label_1;
      else
        goto label_3;
label_8:
      if (true)
      {
        while (this.x3df31cf55a47bc37 != null)
        {
          if (true)
          {
            this.x3df31cf55a47bc37.OnMouseLeave();
            goto label_12;
          }
          else if (false)
            goto label_17;
        }
        goto label_1;
      }
label_12:
      this.x3df31cf55a47bc37 = (LayoutSystemBase) null;
      if (true)
      {
        if (false)
        {
          if (true)
            goto label_20;
          else
            goto label_15;
        }
        else
          goto label_7;
      }
label_23:
      if (this.x3df31cf55a47bc37 == null)
      {
        if (this.x754f1c6f433be75d != null)
          goto label_20;
      }
      else
        this.x3df31cf55a47bc37.OnMouseMove(e);
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
      this.x631afe05fcecf1f4.DrawDockContainerBackground(pevent.Graphics, this, this.DisplayRectangle);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (DockContainer.x1f080f764b4036b1)
      {
        if (true)
          return;
      }
      else
        goto label_16;
label_12:
      if (!this.x266365ea27fa7af8.Evaluation)
        return;
      using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(50, Color.White)))
      {
        using (Font font = new Font(this.Font.FontFamily.Name, 14f, FontStyle.Bold))
        {
          e.Graphics.DrawString("evaluation", font, (Brush) solidBrush, (float) (this.x21ed2ecc088ef4e4.Left + 4), (float) (this.x21ed2ecc088ef4e4.Top - 4), StringFormat.GenericTypographic);
          return;
        }
      }
label_16:
      Control container = this.Manager == null ? (Control) null : this.Manager.DockSystemContainer;
      this.x631afe05fcecf1f4.StartRenderSession(HotkeyPrefix.None);
      this.LayoutSystem.x84b6f3c22477dacb(this.x631afe05fcecf1f4, e.Graphics, this.Font);
      if (this.AllowResize)
      {
        this.x631afe05fcecf1f4.DrawSplitter(container, (Control) this, e.Graphics, this.x59f159fe47159543, this.Dock == DockStyle.Top || this.Dock == DockStyle.Bottom ? Orientation.Horizontal : Orientation.Vertical);
        if (false)
          return;
      }
      this.x631afe05fcecf1f4.FinishRenderSession();
      goto label_12;
    }

    internal void xa2414c47d888068e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      IEnumerator enumerator = this.x83627743ea4ce5a2.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
        {
          LayoutSystemBase current = (LayoutSystemBase) enumerator.Current;
          if (current is ControlLayoutSystem)
          {
            if (((ControlLayoutSystem) current).x61ce2417e4ef76f9())
              break;
          }
        }
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        if (true)
          goto label_9;
label_7:
        if (false)
          goto label_12;
        else
          goto label_14;
label_9:
        while (false)
        {
          if (true)
            goto label_11;
        }
        goto label_12;
label_11:
        disposable.Dispose();
        goto label_7;
label_12:
        if (disposable == null)
        {
          if (false)
            goto label_7;
        }
        else
          goto label_11;
label_14:;
      }
    }

    internal void x19e788b09b195d4f(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      foreach (LayoutSystemBase layoutSystemBase in this.x83627743ea4ce5a2)
      {
        if (layoutSystemBase is ControlLayoutSystem)
          ((ControlLayoutSystem) layoutSystemBase).x82dd941e2755ffd2();
      }
    }

    private void x1b91eb6f6bb77abc()
    {
      this.x754f1c6f433be75d.x868a32060451dd2e -= new EventHandler(this.x30c28c62b1a6040e);
      this.x754f1c6f433be75d.x67ecc0d0e7c9a202 -= new x09c1c18390e52ebf.ResizingManagerFinishedEventHandler(this.xa7afb2334769edc5);
      this.x754f1c6f433be75d = (x09c1c18390e52ebf) null;
    }

    private void x30c28c62b1a6040e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.x1b91eb6f6bb77abc();
    }

    private void xa7afb2334769edc5(int x0d4b3b88c5b24565)
    {
      this.x1b91eb6f6bb77abc();
      this.ContentSize = x0d4b3b88c5b24565;
    }

    protected internal virtual void OnDockingStarted(EventArgs e)
    {
      if (this.xc5f1fda5242cf905 != null)
        this.xc5f1fda5242cf905((object) this, e);
      if (this.Manager == null)
        return;
      this.Manager.OnDockingStarted(e);
    }

    protected internal virtual void OnDockingFinished(EventArgs e)
    {
      if (this.x2556ec4d28ceecee != null)
        goto label_5;
label_2:
      while (this.Manager != null)
      {
        this.Manager.OnDockingFinished(e);
        if (true)
          break;
      }
      return;
label_5:
      this.x2556ec4d28ceecee((object) this, e);
      goto label_2;
    }

    private string xa3a7472ac4e61f76(System.Drawing.Point xb9c2cfae130d9256)
    {
      LayoutSystemBase layoutSystemAt = this.GetLayoutSystemAt(xb9c2cfae130d9256);
      if (layoutSystemAt is ControlLayoutSystem)
        return ((ControlLayoutSystem) layoutSystemAt).xe0e7b93bedab6c05(xb9c2cfae130d9256);
      return "";
    }
  }
}
