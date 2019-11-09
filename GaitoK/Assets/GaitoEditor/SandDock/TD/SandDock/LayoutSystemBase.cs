// Decompiled with JetBrains decompiler
// Type: TD.SandDock.LayoutSystemBase
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
  public abstract class LayoutSystemBase
  {
    private Rectangle xda73fcb97c77d998 = Rectangle.Empty;
    private SizeF x0e30cd10f9fd6d77 = new SizeF(250f, 400f);
    internal const int x35828a68467e5465 = 250;
    internal const int x87970cf44a2c6ba8 = 400;
    internal SplitLayoutSystem xb6a159a84cb992d6;
    private DockContainer x0467b00af7810f0c;
    internal xedb4922162c60d3d x531514c39973cbc6;

    internal void xe9a159cd1e028df2(
      SandDockManager x91f347c6e97f1846,
      DockContainer xd3311d815ca25f02,
      LayoutSystemBase x6e150040c8d97700,
      DockControl x43bec302f92080b9,
      int x9562cf1322eeedf1,
      System.Drawing.Point x6afebf16b45c02e0,
      DockingHints x48cee1d69929b4fe,
      DockingManager xab4835b6b3620991)
    {
      if (xab4835b6b3620991 == DockingManager.Whidbey)
        goto label_5;
label_1:
      this.x531514c39973cbc6 = new xedb4922162c60d3d(x91f347c6e97f1846, this.DockContainer, this, x43bec302f92080b9, x9562cf1322eeedf1, x6afebf16b45c02e0, x48cee1d69929b4fe);
label_2:
      this.x531514c39973cbc6.x67ecc0d0e7c9a202 += new xedb4922162c60d3d.DockingManagerFinishedEventHandler(this.x46ff430ed3944e0f);
      this.x531514c39973cbc6.x868a32060451dd2e += new EventHandler(this.x0ae87c4881d90427);
      if (true)
      {
        this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
        return;
      }
label_5:
      if (x890231ddf317379e.xca8cda6e489f8dd8())
      {
        this.x531514c39973cbc6 = (xedb4922162c60d3d) new x31248f32f85df1dd(x91f347c6e97f1846, this.DockContainer, this, x43bec302f92080b9, x9562cf1322eeedf1, x6afebf16b45c02e0, x48cee1d69929b4fe);
        goto label_2;
      }
      else
        goto label_1;
    }

    private void xf6aefb7d0abb95ba()
    {
      this.x531514c39973cbc6.x67ecc0d0e7c9a202 -= new xedb4922162c60d3d.DockingManagerFinishedEventHandler(this.x46ff430ed3944e0f);
      this.x531514c39973cbc6.x868a32060451dd2e -= new EventHandler(this.x0ae87c4881d90427);
      this.x531514c39973cbc6 = (xedb4922162c60d3d) null;
    }

    internal virtual void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
    {
      this.xf6aefb7d0abb95ba();
    }

    internal virtual void x0ae87c4881d90427(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.xf6aefb7d0abb95ba();
    }

    internal abstract bool x56005f23d6948487 { get; }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public SizeF WorkingSize
    {
      get
      {
        return this.x0e30cd10f9fd6d77;
      }
      set
      {
        if ((double) value.Width <= 0.0 || (double) value.Height <= 0.0)
          throw new ArgumentException(nameof (value));
        this.x0e30cd10f9fd6d77 = value;
      }
    }

    public DockContainer DockContainer
    {
      get
      {
        return this.x0467b00af7810f0c;
      }
    }

    public bool IsInContainer
    {
      get
      {
        return this.x0467b00af7810f0c != null;
      }
    }

    public SplitLayoutSystem Parent
    {
      get
      {
        return this.xb6a159a84cb992d6;
      }
    }

    internal virtual void x56e964269d48cfcc(DockContainer x0467b00af7810f0c)
    {
      this.x0467b00af7810f0c = x0467b00af7810f0c;
    }

    internal LayoutSystemBase()
    {
    }

    protected internal virtual void OnDragOver(DragEventArgs drgevent)
    {
    }

    protected internal virtual void OnMouseMove(MouseEventArgs e)
    {
    }

    protected internal virtual void OnMouseLeave()
    {
    }

    protected internal virtual void OnMouseDoubleClick()
    {
    }

    protected internal virtual void OnMouseDown(MouseEventArgs e)
    {
    }

    protected internal virtual void OnMouseUp(MouseEventArgs e)
    {
    }

    protected internal virtual void Layout(
      RendererBase renderer,
      Graphics graphics,
      Rectangle bounds,
      bool floating)
    {
      this.xda73fcb97c77d998 = bounds;
    }

    internal void x810df8ef88cf4bf2(
      SandDockManager x91f347c6e97f1846,
      ContainerDockLocation x9c911703d455884e,
      ContainerDockEdge x3e4dcab61996c9ea)
    {
      DockControl[] x9476096be9672d38 = this.x9476096be9672d38;
      int num = 0;
      if ((uint) num + (uint) num >= 0U)
        goto label_21;
label_10:
      ControlLayoutSystem newLayoutSystem;
      DockContainer newDockContainer;
      do
      {
        if (!(this is ControlLayoutSystem))
        {
          if (this.Parent != null)
            this.Parent.LayoutSystems.Remove(this);
        }
        else
          goto label_11;
label_7:
        newDockContainer = x91f347c6e97f1846.CreateNewDockContainer(x9c911703d455884e, x3e4dcab61996c9ea, num);
        if (newDockContainer is DocumentContainer)
        {
          newLayoutSystem = newDockContainer.CreateNewLayoutSystem(this.WorkingSize);
          newDockContainer.LayoutSystem.LayoutSystems.Add((LayoutSystemBase) newLayoutSystem);
          if (this is SplitLayoutSystem)
          {
            ((SplitLayoutSystem) this).MoveToLayoutSystem(newLayoutSystem);
            continue;
          }
          goto label_2;
        }
        else
          goto label_3;
label_11:
        if (true)
        {
          LayoutUtilities.x4487f2f8917e3fd0((ControlLayoutSystem) this);
          if (false)
            goto label_7;
          else
            goto label_7;
        }
        else
          goto label_1;
      }
      while ((uint) num > uint.MaxValue);
      goto label_15;
label_2:
      newLayoutSystem.Controls.AddRange(this.x9476096be9672d38);
      return;
label_3:
      newDockContainer.LayoutSystem.LayoutSystems.Add(this);
      return;
label_1:
      return;
label_15:
      if ((uint) num - (uint) num >= 0U)
        ;
      return;
label_21:
      if ((uint) num < 0U || x9476096be9672d38.Length > 0)
        goto label_22;
label_19:
      Rectangle rectangle;
      do
      {
        rectangle = xedb4922162c60d3d.x41c62f474d3fb367(x91f347c6e97f1846.DockSystemContainer);
        do
        {
          switch (x9c911703d455884e)
          {
            case ContainerDockLocation.Left:
              goto label_18;
            case ContainerDockLocation.Right:
              continue;
            case ContainerDockLocation.Top:
              goto label_14;
            default:
              goto label_13;
          }
        }
        while (false);
label_18:
        num = Math.Min(num, Convert.ToInt32((double) rectangle.Width * 0.9));
      }
      while ((num & 0) != 0);
      goto label_10;
label_9:
      if (x9c911703d455884e == ContainerDockLocation.Bottom)
        goto label_14;
      else
        goto label_10;
label_13:
      if (true)
        goto label_9;
label_14:
      num = Math.Min(num, Convert.ToInt32((double) rectangle.Height * 0.9));
      if ((uint) num >= 0U)
        goto label_10;
      else
        goto label_9;
label_22:
      num = x9476096be9672d38[0].MetaData.DockedContentSize;
      goto label_19;
    }

    private void x298b2fdefeb76ab8()
    {
      if (this.x460ab163f44a604d == null)
        throw new InvalidOperationException("No SandDockManager is associated with this ControlLayoutSystem.");
    }

    private SandDockManager x460ab163f44a604d
    {
      get
      {
        if (this.DockContainer != null)
          return this.DockContainer.Manager;
        return (SandDockManager) null;
      }
    }

    public Rectangle Bounds
    {
      get
      {
        return this.xda73fcb97c77d998;
      }
    }

    internal abstract DockControl[] x9476096be9672d38 { get; }

    internal abstract bool x74e31f9641656e0b { get; }

    internal abstract bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256);

    internal abstract bool x2f61709eaa5ebf76 { get; }

    internal abstract void x84b6f3c22477dacb(
      RendererBase x38870620fd380a6b,
      Graphics x41347a961b838962,
      Font x26094932cf7a9139);
  }
}
