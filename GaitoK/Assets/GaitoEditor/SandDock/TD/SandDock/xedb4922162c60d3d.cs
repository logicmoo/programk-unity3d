// Decompiled with JetBrains decompiler
// Type: TD.SandDock.xedb4922162c60d3d
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
  internal class xedb4922162c60d3d : x890231ddf317379e
  {
    private System.Drawing.Size xca874006c41dfe29 = System.Drawing.Size.Empty;
    private System.Drawing.Point x2a2e0ce22e62c94e = System.Drawing.Point.Empty;
    private const int x92d9c1851cace8e0 = 30;
    private SandDockManager x91f347c6e97f1846;
    private DockContainer x0467b00af7810f0c;
    private LayoutSystemBase x83e1554f4315a375;
    private DockControl x493191df254612e4;
    private int x9562cf1322eeedf1;
    private xedb4922162c60d3d.DockTarget x521249670374b9ee;
    private Cursor x90ce1c0ec8c6028d;
    private Cursor x52988e63e407fffa;
    private ControlLayoutSystem[] xcd940949dfd37534;

    public event xedb4922162c60d3d.DockingManagerFinishedEventHandler x67ecc0d0e7c9a202;

    public xedb4922162c60d3d(
      SandDockManager manager,
      DockContainer container,
      LayoutSystemBase sourceControlSystem,
      DockControl sourceControl,
      int dockedSize,
      System.Drawing.Point startPoint,
      DockingHints dockingHints)
      : base((Control) container, dockingHints, true, container.x631afe05fcecf1f4.TabStripMetrics.Height)
    {
      if ((uint) dockedSize - (uint) dockedSize <= uint.MaxValue)
        goto label_28;
      else
        goto label_17;
label_4:
      Rectangle bounds;
      if (sourceControl != null)
      {
        this.x2a2e0ce22e62c94e = new System.Drawing.Point(startPoint.X, this.xca874006c41dfe29.Height - (bounds.Bottom - startPoint.Y));
        goto label_6;
      }
label_5:
      this.x2a2e0ce22e62c94e = new System.Drawing.Point(startPoint.X, startPoint.Y - bounds.Top);
label_6:
      this.x2a2e0ce22e62c94e.Y = Math.Max(this.x2a2e0ce22e62c94e.Y, 0);
      this.x2a2e0ce22e62c94e.Y = Math.Min(this.x2a2e0ce22e62c94e.Y, this.xca874006c41dfe29.Height);
      if ((uint) dockedSize - (uint) dockedSize >= 0U)
      {
        if (true)
        {
          this.xcd940949dfd37534 = this.x0ce9d68830aba643();
          this.x0467b00af7810f0c.OnDockingStarted(EventArgs.Empty);
          if (true)
            return;
          goto label_17;
        }
        else if (false)
          goto label_18;
        else
          goto label_4;
      }
label_9:
      if (bounds.Width <= 0)
      {
        if ((uint) dockedSize - (uint) dockedSize >= 0U)
        {
          if ((uint) dockedSize >= 0U)
          {
            if (true)
            {
              startPoint.X = this.xca874006c41dfe29.Width / 2;
              goto label_4;
            }
            else
              goto label_6;
          }
        }
        else
          goto label_22;
      }
      else
      {
        startPoint.X -= bounds.Left;
        startPoint.X = Convert.ToInt32((float) startPoint.X / (float) bounds.Width * (float) this.xca874006c41dfe29.Width);
        goto label_4;
      }
label_12:
      bounds = sourceControlSystem.Bounds;
      goto label_9;
label_17:
      if (!(sourceControlSystem is ControlLayoutSystem) || ((ControlLayoutSystem) sourceControlSystem).SelectedControl == null)
      {
        this.xca874006c41dfe29 = sourceControlSystem.Bounds.Size;
        goto label_12;
      }
label_18:
      this.xca874006c41dfe29 = ((ControlLayoutSystem) sourceControlSystem).SelectedControl.FloatingSize;
      goto label_12;
label_20:
      if (!(sourceControlSystem is SplitLayoutSystem))
      {
        if (sourceControl != null)
        {
          this.xca874006c41dfe29 = sourceControl.FloatingSize;
          goto label_12;
        }
        else
          goto label_17;
      }
      else
      {
        this.xca874006c41dfe29 = ((x410f3612b9a8f9de) container).xb1090c5821a633b5;
        if (true)
          goto label_12;
        else
          goto label_26;
      }
label_22:
      this.x90ce1c0ec8c6028d = new Cursor(this.GetType().Assembly.GetManifestResourceStream("TD.SandDock.Resources.splitting.cur"));
      this.x52988e63e407fffa = new Cursor(this.GetType().Assembly.GetManifestResourceStream("TD.SandDock.Resources.splittingno.cur"));
      goto label_20;
label_26:
      this.x0467b00af7810f0c = container;
      if ((uint) dockedSize - (uint) dockedSize <= uint.MaxValue)
      {
        this.x83e1554f4315a375 = sourceControlSystem;
        do
        {
          this.x493191df254612e4 = sourceControl;
          this.x9562cf1322eeedf1 = dockedSize;
          if ((uint) dockedSize - (uint) dockedSize >= 0U)
          {
            if (container is DocumentContainer)
              goto label_22;
          }
          else
            goto label_5;
        }
        while (false);
        goto label_20;
      }
      else
        goto label_5;
label_28:
      this.x91f347c6e97f1846 = manager;
      goto label_26;
    }

    protected ControlLayoutSystem[] xcdb018cc067a38ae
    {
      get
      {
        return this.xcd940949dfd37534;
      }
    }

    public SandDockManager x460ab163f44a604d
    {
      get
      {
        return this.x91f347c6e97f1846;
      }
    }

    public int xf8ec28822747d4db
    {
      get
      {
        return this.x9562cf1322eeedf1;
      }
    }

    public DockContainer xc99dabdb533b119a
    {
      get
      {
        return this.x0467b00af7810f0c;
      }
    }

    public LayoutSystemBase xf333586e50dccad2
    {
      get
      {
        return this.x83e1554f4315a375;
      }
    }

    public DockControl x59ae058c4a0dec87
    {
      get
      {
        return this.x493191df254612e4;
      }
    }

    private System.Drawing.Point x6fbe0a6d89f5dffb
    {
      get
      {
        return new System.Drawing.Point(Cursor.Position.X - this.x2a2e0ce22e62c94e.X, Cursor.Position.Y - this.x2a2e0ce22e62c94e.Y);
      }
    }

    public bool xd065d1541e1bea63
    {
      get
      {
        return this.x0467b00af7810f0c.x972331c8ecf83413;
      }
    }

    public bool x74e31f9641656e0b
    {
      get
      {
        if (this.xd065d1541e1bea63)
          return false;
        if (this.x59ae058c4a0dec87 != null)
          return this.x59ae058c4a0dec87.DockingRules.AllowFloat;
        return this.xf333586e50dccad2.x74e31f9641656e0b;
      }
    }

    public bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256)
    {
      if (this.x59ae058c4a0dec87 != null)
        return this.x59ae058c4a0dec87.xe302f2203dc14a18(xb9c2cfae130d9256);
      return this.xf333586e50dccad2.xe302f2203dc14a18(xb9c2cfae130d9256);
    }

    public override void OnMouseMove(System.Drawing.Point position)
    {
      xedb4922162c60d3d.DockTarget dockTarget = (xedb4922162c60d3d.DockTarget) null;
      if (false)
        goto label_16;
      else
        goto label_46;
label_8:
      if (false)
        goto label_12;
label_9:
      this.xe5e4149f382149cc(dockTarget.bounds, dockTarget.type == xedb4922162c60d3d.DockTargetType.JoinExistingSystem);
label_10:
      if (this.x0467b00af7810f0c is DocumentContainer)
        goto label_5;
label_1:
      this.x521249670374b9ee = dockTarget;
      return;
label_5:
      if (dockTarget.type == xedb4922162c60d3d.DockTargetType.AlreadyActioned)
        goto label_6;
      else
        goto label_3;
label_2:
      Cursor.Current = this.x52988e63e407fffa;
      goto label_1;
label_3:
      if (dockTarget.type != xedb4922162c60d3d.DockTargetType.None)
      {
        Cursor.Current = this.x90ce1c0ec8c6028d;
        if (true)
          goto label_1;
      }
      else
        goto label_2;
label_6:
      Cursor.Current = Cursors.Default;
      if (true)
      {
        if (true)
          goto label_1;
        else
          goto label_2;
      }
      else
        goto label_40;
label_12:
      while (dockTarget.type != xedb4922162c60d3d.DockTargetType.None)
      {
        if (true)
          goto label_9;
      }
label_15:
      this.x11972e8742c570b8();
      goto label_10;
label_16:
      if (true)
        goto label_12;
label_17:
      if (dockTarget.dockSide != DockSide.None)
      {
        if (true)
        {
          if (true)
            goto label_12;
          else
            goto label_15;
        }
        else
          goto label_16;
      }
      else
        goto label_25;
label_20:
      if (dockTarget.layoutSystem != this.x83e1554f4315a375)
      {
        if (false)
        {
          if (true)
            goto label_8;
        }
        else
          goto label_16;
      }
      else
        goto label_28;
label_24:
      if (true)
        goto label_17;
label_25:
      this.x11972e8742c570b8();
      ControlLayoutSystem x83e1554f4315a375 = (ControlLayoutSystem) this.x83e1554f4315a375;
      if (dockTarget.index != x83e1554f4315a375.Controls.IndexOf(this.x493191df254612e4) && dockTarget.index != x83e1554f4315a375.Controls.IndexOf(this.x493191df254612e4) + 1)
        goto label_23;
label_19:
      dockTarget.type = xedb4922162c60d3d.DockTargetType.AlreadyActioned;
      goto label_10;
label_23:
      x83e1554f4315a375.Controls.SetChildIndex(this.x493191df254612e4, dockTarget.index);
      goto label_19;
label_26:
      if (dockTarget.type != xedb4922162c60d3d.DockTargetType.Float)
      {
        if (true)
          goto label_20;
      }
      else
      {
        dockTarget.bounds = new Rectangle(this.x6fbe0a6d89f5dffb, this.xca874006c41dfe29);
        if (true)
          dockTarget.bounds = this.x90c590fcd758eaee(dockTarget.bounds);
        if (true)
          goto label_42;
        else
          goto label_38;
      }
label_28:
      if (this.x493191df254612e4 != null)
      {
        if (false)
          goto label_41;
        else
          goto label_48;
      }
      else
        goto label_12;
label_32:
      dockTarget.type = xedb4922162c60d3d.DockTargetType.None;
      if (true)
        goto label_26;
label_33:
      if (dockTarget.type == xedb4922162c60d3d.DockTargetType.Undefined)
        goto label_32;
      else
        goto label_26;
label_38:
      if (!this.x74e31f9641656e0b)
      {
        if (true)
          goto label_33;
        else
          goto label_42;
      }
      else
        goto label_43;
label_40:
      dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.None);
      if (true)
        goto label_33;
label_41:
      if (dockTarget.type != xedb4922162c60d3d.DockTargetType.Undefined)
      {
        if (true)
          goto label_33;
        else
          goto label_32;
      }
      else if (this.x91f347c6e97f1846 != null)
      {
        if (false)
        {
          if (true)
            goto label_8;
          else
            goto label_12;
        }
        else
          goto label_38;
      }
      else
        goto label_33;
label_42:
      if (true)
        goto label_20;
      else
        goto label_48;
label_43:
      if (this.x91f347c6e97f1846 != null && this.x74e31f9641656e0b)
      {
        dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.Float);
        if (true)
          goto label_33;
        else
          goto label_40;
      }
      else
        goto label_40;
label_46:
      if ((Control.ModifierKeys & Keys.Control) != Keys.Control)
        goto label_47;
label_45:
      if (dockTarget == null)
        goto label_43;
      else
        goto label_41;
label_47:
      dockTarget = this.FindDockTarget(position);
      goto label_45;
label_48:
      if (true)
        goto label_24;
      else
        goto label_8;
    }

    private Rectangle x90c590fcd758eaee(Rectangle xda73fcb97c77d998)
    {
      if (xda73fcb97c77d998.X >= Screen.PrimaryScreen.Bounds.X && xda73fcb97c77d998.Right <= Screen.PrimaryScreen.Bounds.Right)
        goto label_3;
label_2:
      Screen screen = Screen.FromRectangle(xda73fcb97c77d998);
      if (screen != null && xda73fcb97c77d998.Y < screen.WorkingArea.Y)
        xda73fcb97c77d998.Y = screen.WorkingArea.Y;
      return xda73fcb97c77d998;
label_3:
      if (true)
        goto label_5;
label_4:
      xda73fcb97c77d998.Y = Screen.PrimaryScreen.WorkingArea.Bottom - xda73fcb97c77d998.Height;
      if (true)
        goto label_2;
label_5:
      if (xda73fcb97c77d998.Y > Screen.PrimaryScreen.WorkingArea.Bottom)
        goto label_4;
      else
        goto label_2;
    }

    public xedb4922162c60d3d.DockTarget x42f4c234c9358072
    {
      get
      {
        return this.x521249670374b9ee;
      }
    }

    protected Rectangle x8a1b221df357d098(
      ContainerDockLocation x9c911703d455884e,
      bool x24c3791e61dc49c9)
    {
      if (!x24c3791e61dc49c9)
        goto label_7;
label_6:
      return this.x257d5a0e25592705(x9c911703d455884e, 30, true);
label_7:
      Control dockSystemContainer = this.x460ab163f44a604d.DockSystemContainer;
      int x = 0;
      int width = dockSystemContainer.ClientRectangle.Width;
      int y = 0;
      Rectangle clientRectangle = dockSystemContainer.ClientRectangle;
      if ((uint) y <= uint.MaxValue)
      {
        if ((uint) y + (uint) width <= uint.MaxValue)
        {
          int height = clientRectangle.Height;
          switch (x9c911703d455884e)
          {
            case ContainerDockLocation.Left:
              return new Rectangle(x - 30, y, 30, height - y);
            case ContainerDockLocation.Right:
              return new Rectangle(width, y, 30, height - y);
            case ContainerDockLocation.Top:
              return new Rectangle(x, y - 30, width - x, 30);
            case ContainerDockLocation.Bottom:
              return new Rectangle(x, height, width - x, 30);
          }
        }
        return Rectangle.Empty;
      }
      goto label_6;
    }

    public static Rectangle x41c62f474d3fb367(Control xd3311d815ca25f02)
    {
      int x = 0;
      int num1;
      do
      {
        num1 = xd3311d815ca25f02.ClientRectangle.Width;
      }
      while (false);
      int y = 0;
      int num2 = xd3311d815ca25f02.ClientRectangle.Height;
      if ((uint) y <= uint.MaxValue)
      {
        IEnumerator enumerator = xd3311d815ca25f02.Controls.GetEnumerator();
        try
        {
          while (true)
          {
            Rectangle bounds1;
            Control current;
            Rectangle bounds2;
            do
            {
              if (enumerator.MoveNext())
                goto label_21;
              else
                goto label_16;
label_3:
              continue;
label_8:
              Rectangle bounds3;
              if (bounds3.Right > x)
              {
                bounds2 = current.Bounds;
                if ((uint) y + (uint) num1 > uint.MaxValue)
                {
                  if ((uint) x - (uint) x <= uint.MaxValue)
                    goto label_15;
                  else
                    goto label_30;
                }
                else
                  goto label_17;
              }
label_9:
              if ((uint) num2 - (uint) x <= uint.MaxValue)
              {
                if ((num2 & 0) != 0)
                  goto label_3;
                else
                  continue;
              }
              else if ((uint) num2 + (uint) num2 <= uint.MaxValue)
              {
                if ((uint) num1 + (uint) num2 <= uint.MaxValue)
                  goto label_3;
                else
                  continue;
              }
              else
                goto label_8;
label_15:
              bounds1 = current.Bounds;
              if ((uint) num1 - (uint) y <= uint.MaxValue)
                goto label_3;
              else
                break;
label_16:
              if ((uint) num2 - (uint) num2 > uint.MaxValue)
              {
                if ((uint) y > uint.MaxValue)
                  goto label_9;
              }
              else
                goto label_30;
label_21:
              current = (Control) enumerator.Current;
              if (current.Visible)
              {
                if ((uint) num2 >= 0U)
                {
                  switch (current.Dock)
                  {
                    case DockStyle.Top:
                      goto label_15;
                    case DockStyle.Bottom:
                      if (current.Bounds.Top < num2)
                      {
                        num2 = current.Bounds.Top;
                        if ((x & 0) != 0)
                          goto label_15;
                        else
                          continue;
                      }
                      else
                        continue;
                    case DockStyle.Left:
                      bounds3 = current.Bounds;
                      goto label_8;
                    case DockStyle.Right:
                      goto label_14;
                    default:
                      continue;
                  }
                }
                else
                  break;
              }
            }
            while (bounds1.Bottom <= y);
            y = current.Bounds.Bottom;
            continue;
label_14:
            if (current.Bounds.Left < num1)
            {
              num1 = current.Bounds.Left;
              continue;
            }
            continue;
label_17:
            x = bounds2.Right;
          }
        }
        finally
        {
          (enumerator as IDisposable)?.Dispose();
        }
      }
label_30:
      return new Rectangle(x, y, num1 - x, num2 - y);
    }

    protected Rectangle x257d5a0e25592705(
      ContainerDockLocation x9c911703d455884e,
      int x73f61fa085749e85,
      bool x24c3791e61dc49c9)
    {
      Rectangle rectangle1 = xedb4922162c60d3d.x41c62f474d3fb367(this.x460ab163f44a604d.DockSystemContainer);
      Rectangle rectangle2 = rectangle1;
      if (!x24c3791e61dc49c9)
        goto label_9;
label_6:
      int val1 = x73f61fa085749e85 + 4;
      if ((uint) val1 + (uint) val1 < 0U)
      {
        if (false)
          goto label_8;
      }
      else
        goto label_7;
label_3:
      return new Rectangle(rectangle2.Left, rectangle2.Top, Math.Min(val1, Convert.ToInt32((double) rectangle1.Width * 0.9)), rectangle2.Height);
label_7:
      ContainerDockLocation containerDockLocation = x9c911703d455884e;
label_8:
      switch (containerDockLocation)
      {
        case ContainerDockLocation.Left:
          goto label_3;
        case ContainerDockLocation.Right:
          return new Rectangle(rectangle2.Right - Math.Min(val1, Convert.ToInt32((double) rectangle1.Width * 0.9)), rectangle2.Top, Math.Min(val1, Convert.ToInt32((double) rectangle1.Width * 0.9)), rectangle2.Height);
        case ContainerDockLocation.Top:
          return new Rectangle(rectangle2.Left, rectangle2.Top, rectangle2.Width, Math.Min(val1, Convert.ToInt32((double) rectangle1.Height * 0.9)));
        case ContainerDockLocation.Bottom:
          return new Rectangle(rectangle2.Left, rectangle2.Bottom - Math.Min(val1, Convert.ToInt32((double) rectangle1.Height * 0.9)), rectangle2.Width, Math.Min(val1, Convert.ToInt32((double) rectangle1.Height * 0.9)));
        default:
          return rectangle2;
      }
label_9:
      rectangle2 = this.x460ab163f44a604d.DockSystemContainer.ClientRectangle;
      goto label_6;
    }

    protected bool xecd95d3d6bb4afc3()
    {
      return this.x460ab163f44a604d.FindDockedContainer(DockStyle.Fill) is DocumentContainer;
    }

    private ControlLayoutSystem[] x0ce9d68830aba643()
    {
      ArrayList x3c4da2980d043c95 = new ArrayList();
      if (this.x91f347c6e97f1846 == null)
        goto label_35;
      else
        goto label_32;
label_1:
      ControlLayoutSystem[] controlLayoutSystemArray;
      x3c4da2980d043c95.CopyTo((Array) controlLayoutSystemArray, 0);
      if (true)
        return controlLayoutSystemArray;
      bool isFloating;
      if ((uint) isFloating >= 0U)
        goto label_7;
label_3:
      int index;
      ++index;
label_4:
      DockContainer[] dockContainerArray1;
      DockContainer xd3311d815ca25f02;
      if (index >= dockContainerArray1.Length)
      {
        controlLayoutSystemArray = new ControlLayoutSystem[x3c4da2980d043c95.Count];
        goto label_1;
      }
      else
      {
        xd3311d815ca25f02 = dockContainerArray1[index];
        if ((uint) isFloating <= uint.MaxValue)
        {
          isFloating = xd3311d815ca25f02.IsFloating;
          if ((uint) index < 0U)
            goto label_22;
          else
            goto label_22;
        }
        else
          goto label_32;
      }
label_7:
      if (this.xc99dabdb533b119a != xd3311d815ca25f02)
      {
        if (((isFloating ? 1 : 0) & 0) != 0)
          goto label_11;
        else
          goto label_3;
      }
      else
        goto label_13;
label_9:
      bool flag1;
      if (!flag1)
        goto label_13;
      else
        goto label_7;
label_11:
      if (!isFloating)
      {
        if ((uint) index + (uint) index <= uint.MaxValue)
          goto label_21;
      }
      else
        goto label_15;
label_13:
      this.x53faf379dc10cd0f(xd3311d815ca25f02, x3c4da2980d043c95);
      goto label_3;
label_15:
      bool flag2;
      if (!flag2 || flag1)
        goto label_9;
      else
        goto label_3;
label_16:
      if ((uint) isFloating + (uint) flag1 > uint.MaxValue)
        goto label_11;
      else
        goto label_15;
label_21:
      if ((uint) index >= 0U)
        goto label_27;
label_22:
      int num1;
      if (xd3311d815ca25f02.Dock == DockStyle.Fill)
      {
        num1 = !xd3311d815ca25f02.IsFloating ? 1 : 0;
        goto label_24;
      }
label_23:
      num1 = 0;
label_24:
      flag2 = num1 != 0;
      flag1 = this.xc99dabdb533b119a.Dock == DockStyle.Fill && !this.xc99dabdb533b119a.IsFloating;
      if (isFloating)
        goto label_19;
label_18:
      if (isFloating && !this.x74e31f9641656e0b && this.xf333586e50dccad2.DockContainer != xd3311d815ca25f02)
      {
        if ((uint) flag2 + (uint) isFloating >= 0U)
          goto label_3;
        else
          goto label_21;
      }
      else
        goto label_11;
label_19:
      while (this.xf333586e50dccad2.DockContainer == xd3311d815ca25f02)
      {
        if (!(this.xf333586e50dccad2 is SplitLayoutSystem))
        {
          if ((index & 0) == 0)
          {
            if (((isFloating ? 1 : 0) | 8) != 0)
              goto label_18;
          }
          else
            goto label_27;
        }
        else
          goto label_3;
      }
      if ((uint) isFloating - (uint) index < 0U)
        goto label_1;
      else
        goto label_18;
label_27:
      if (((flag2 ? 1 : 0) | -1) != 0)
      {
        if ((uint) flag2 + (uint) flag1 > uint.MaxValue)
        {
          if ((uint) index + (uint) flag1 > uint.MaxValue)
            goto label_9;
          else
            goto label_7;
        }
        else if (this.xe302f2203dc14a18(LayoutUtilities.x3650f3b579b2b4d2(xd3311d815ca25f02.Dock)))
          goto label_16;
        else
          goto label_3;
      }
      else
        goto label_32;
label_30:
      DockContainer[] dockContainerArray2;
      dockContainerArray1 = dockContainerArray2;
      index = 0;
      goto label_4;
label_32:
      dockContainerArray2 = this.x91f347c6e97f1846.GetDockContainers();
      if ((uint) isFloating + (uint) flag2 > uint.MaxValue)
        goto label_16;
      else
        goto label_30;
label_35:
      DockContainer[] dockContainerArray3 = new DockContainer[1]{ this.xc99dabdb533b119a };
      int num2;
      bool flag3;
      if ((uint) num2 + (uint) flag3 >= 0U)
      {
        if ((num2 | int.MaxValue) != 0)
        {
          dockContainerArray2 = dockContainerArray3;
          goto label_30;
        }
        else
          goto label_32;
      }
      else
        goto label_23;
    }

    private void x53faf379dc10cd0f(DockContainer xd3311d815ca25f02, ArrayList x3c4da2980d043c95)
    {
      bool flag = xd3311d815ca25f02.Width > 0 || xd3311d815ca25f02.Height > 0;
      while (flag)
      {
        if (!xd3311d815ca25f02.Enabled)
        {
          if (true)
            break;
        }
        else
        {
          if (!xd3311d815ca25f02.Visible)
            break;
          this.xabdf625bc93be733(xd3311d815ca25f02, xd3311d815ca25f02.LayoutSystem, x3c4da2980d043c95);
          break;
        }
      }
    }

    private void xabdf625bc93be733(
      DockContainer xd3311d815ca25f02,
      SplitLayoutSystem x35c76d526f88c3c8,
      ArrayList x3c4da2980d043c95)
    {
      IEnumerator enumerator = x35c76d526f88c3c8.LayoutSystems.GetEnumerator();
      bool flag;
      try
      {
        while (enumerator.MoveNext())
        {
          LayoutSystemBase current = (LayoutSystemBase) enumerator.Current;
          if (current is SplitLayoutSystem)
            this.xabdf625bc93be733(xd3311d815ca25f02, (SplitLayoutSystem) current, x3c4da2980d043c95);
          else if (current is ControlLayoutSystem)
          {
            while (this.x493191df254612e4 == null)
            {
              if ((uint) flag + (uint) flag < 0U)
              {
                if (true)
                {
                  if (true)
                    break;
                  goto label_18;
                }
              }
              else
                goto label_4;
            }
            goto label_7;
label_2:
            x3c4da2980d043c95.Add((object) current);
            continue;
label_4:
            int num = !((ControlLayoutSystem) current).Collapsed ? 1 : 0;
label_6:
            flag = num != 0;
            if (flag)
              goto label_2;
            else
              continue;
label_7:
            if (current == this.x83e1554f4315a375)
            {
              if (this.x493191df254612e4.LayoutSystem.Controls.Count == 1)
              {
                num = 0;
                goto label_6;
              }
              else if (false)
                goto label_2;
              else
                goto label_4;
            }
label_18:
            if (false)
              break;
            goto label_4;
          }
        }
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        if (((flag ? 1 : 0) | int.MinValue) == 0 || disposable != null)
          disposable.Dispose();
      }
    }

    protected virtual xedb4922162c60d3d.DockTarget FindDockTarget(System.Drawing.Point position)
    {
      xedb4922162c60d3d.DockTarget dockTarget1 = (xedb4922162c60d3d.DockTarget) null;
      int num1;
      if ((uint) num1 - (uint) num1 < 0U)
        goto label_6;
      else
        goto label_62;
label_2:
      int num2;
      ++num2;
label_3:
      ContainerDockLocation containerDockLocation;
      int index;
      Rectangle rectangle1;
      if (num2 > 4)
      {
        if ((uint) index > uint.MaxValue)
          goto label_25;
      }
      else
      {
        containerDockLocation = (ContainerDockLocation) num2;
        if (this.xe302f2203dc14a18(containerDockLocation))
        {
          rectangle1 = xedb4922162c60d3d.xc68a4bb946c59a9e(this.x8a1b221df357d098(containerDockLocation, true), this.x460ab163f44a604d.DockSystemContainer);
          goto label_10;
        }
        else
          goto label_2;
      }
label_5:
      return (xedb4922162c60d3d.DockTarget) null;
label_6:
      rectangle1 = xedb4922162c60d3d.xc68a4bb946c59a9e(this.x8a1b221df357d098(containerDockLocation, false), this.x460ab163f44a604d.DockSystemContainer);
      if (true)
      {
        if (rectangle1.Contains(position))
        {
          dockTarget1 = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.CreateNewContainer);
          dockTarget1.dockLocation = containerDockLocation;
          if ((uint) index <= uint.MaxValue)
          {
            if ((num2 | 4) != 0)
            {
              if ((uint) index + (uint) num2 <= uint.MaxValue)
              {
                dockTarget1.bounds = xedb4922162c60d3d.xc68a4bb946c59a9e(this.x257d5a0e25592705(containerDockLocation, this.x9562cf1322eeedf1, false), this.x460ab163f44a604d.DockSystemContainer);
                return dockTarget1;
              }
              goto label_64;
            }
            else
              goto label_22;
          }
          else
            goto label_19;
        }
        else
          goto label_2;
      }
      else
        goto label_22;
label_10:
      if (rectangle1.Contains(position))
      {
        do
        {
          dockTarget1 = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.CreateNewContainer);
          dockTarget1.dockLocation = containerDockLocation;
          dockTarget1.bounds = xedb4922162c60d3d.xc68a4bb946c59a9e(this.x257d5a0e25592705(containerDockLocation, this.x9562cf1322eeedf1, true), this.x460ab163f44a604d.DockSystemContainer);
        }
        while (false);
        if (true)
        {
          dockTarget1.middle = true;
          return dockTarget1;
        }
        goto label_6;
      }
      else
        goto label_6;
label_14:
      ++index;
label_15:
      ControlLayoutSystem[] xcd940949dfd37534;
      Rectangle rectangle2;
      ControlLayoutSystem x6e150040c8d97700;
      if (index >= xcd940949dfd37534.Length)
      {
        if (this.x460ab163f44a604d != null)
        {
          num2 = 1;
          goto label_3;
        }
        else
          goto label_5;
      }
      else
      {
        x6e150040c8d97700 = xcd940949dfd37534[index];
        rectangle2 = new Rectangle(x6e150040c8d97700.DockContainer.PointToScreen(x6e150040c8d97700.Bounds.Location), x6e150040c8d97700.Bounds.Size);
        if ((uint) num2 >= 0U)
        {
          if ((index | -2) != 0)
            goto label_25;
          else
            goto label_22;
        }
        else
          goto label_29;
      }
label_19:
      xedb4922162c60d3d.DockTarget dockTarget2;
      if (dockTarget1 == null)
      {
        if (true)
          goto label_14;
        else
          goto label_10;
      }
      else
      {
        dockTarget2 = dockTarget1;
        goto label_64;
      }
label_22:
      dockTarget1 = this.xede53ab1a4b2e20b(x6e150040c8d97700.DockContainer, x6e150040c8d97700, position, true);
      goto label_19;
label_25:
      if ((index & 0) != 0 || rectangle2.Contains(position))
        goto label_22;
      else
        goto label_14;
label_27:
      xcd940949dfd37534 = this.xcd940949dfd37534;
      if (false)
        ;
      index = 0;
      goto label_15;
label_29:
      IEnumerator enumerator = this.x91f347c6e97f1846.xd27fa35d10494112.GetEnumerator();
      try
      {
label_32:
        if (enumerator.MoveNext())
          goto label_53;
        else
          goto label_39;
label_33:
        if (true)
          goto label_44;
label_34:
        if ((uint) index + (uint) index >= 0U)
        {
          if ((uint) index + (uint) num2 >= 0U)
          {
            if ((uint) index <= uint.MaxValue)
              goto label_44;
            else
              goto label_32;
          }
          else
            goto label_33;
        }
label_35:
        DockContainer current;
        if (current.IsFloating)
          goto label_33;
label_36:
        if ((uint) index - (uint) num2 < 0U)
          goto label_34;
        else
          goto label_32;
label_39:
        if (true)
          goto label_27;
        else
          goto label_35;
label_44:
        if (((x410f3612b9a8f9de) current).xd936980ea1aac341.Visible)
        {
          if ((num2 & 0) == 0)
          {
            do
            {
              if (!current.HasSingleControlLayoutSystem)
              {
                if ((uint) num2 - (uint) index > uint.MaxValue)
                  goto label_50;
                else
                  goto label_32;
              }
              else
                goto label_54;
label_42:
              if (!rectangle2.Contains(position))
              {
                if ((uint) num2 > uint.MaxValue)
                {
                  if ((num2 & 0) == 0)
                    continue;
                }
                else
                  goto label_31;
              }
              else
                goto label_51;
label_49:
              dockTarget1.dockContainer = current;
              dockTarget1.layoutSystem = (ControlLayoutSystem) current.LayoutSystem.LayoutSystems[0];
              dockTarget1.bounds = ((x410f3612b9a8f9de) current).x5de6fa99acd93adb;
              goto label_50;
label_51:
              rectangle2 = new Rectangle(current.PointToScreen(current.LayoutSystem.LayoutSystems[0].Bounds.Location), current.LayoutSystem.LayoutSystems[0].Bounds.Size);
              if (!rectangle2.Contains(position))
              {
                if ((uint) num2 + (uint) index <= uint.MaxValue)
                {
                  dockTarget1 = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.JoinExistingSystem);
                  if ((uint) index + (uint) index > uint.MaxValue)
                    goto label_44;
                  else
                    goto label_49;
                }
                else
                  goto label_64;
              }
              else
                goto label_32;
label_50:
              dockTarget2 = dockTarget1;
              if ((uint) index >= 0U)
                goto label_64;
              else
                goto label_42;
label_54:
              if (current.LayoutSystem != this.x83e1554f4315a375)
              {
                rectangle2 = ((x410f3612b9a8f9de) current).x5de6fa99acd93adb;
                goto label_42;
              }
              else
                goto label_32;
            }
            while ((uint) index - (uint) index < 0U);
            goto label_36;
label_31:
            if ((uint) index - (uint) index < 0U)
              goto label_36;
            else
              goto label_32;
          }
          else
            goto label_34;
        }
        else
          goto label_32;
label_53:
        current = (DockContainer) enumerator.Current;
        if ((uint) num2 >= 0U)
          goto label_35;
        else
          goto label_44;
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        do
        {
          if (disposable == null)
          {
            if ((uint) index - (uint) index >= 0U)
              break;
          }
          else
            goto label_59;
label_58:
          continue;
label_59:
          disposable.Dispose();
          goto label_58;
        }
        while ((num2 | int.MaxValue) == 0);
      }
label_62:
      int num3;
      if ((uint) num3 + (uint) num3 <= uint.MaxValue && this.x91f347c6e97f1846 == null || !this.x74e31f9641656e0b)
        goto label_27;
      else
        goto label_29;
label_64:
      return dockTarget2;
    }

    public static Rectangle xc68a4bb946c59a9e(
      Rectangle x337e217cb3ba0627,
      Control x43bec302f92080b9)
    {
      return new Rectangle(x43bec302f92080b9.PointToScreen(x337e217cb3ba0627.Location), x337e217cb3ba0627.Size);
    }

    protected xedb4922162c60d3d.DockTarget xede53ab1a4b2e20b(
      DockContainer xd3311d815ca25f02,
      ControlLayoutSystem x6e150040c8d97700,
      System.Drawing.Point x13d4cb8d1bd20347,
      bool xcef4185c23f358e0)
    {
      xedb4922162c60d3d.DockTarget dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.Undefined);
      System.Drawing.Point client = xd3311d815ca25f02.PointToClient(x13d4cb8d1bd20347);
label_24:
      if (this.x493191df254612e4 == null)
        goto label_25;
label_21:
      Rectangle xccb1fc68964285c2_1 = x6e150040c8d97700.xccb1fc68964285c2;
      if (((xcef4185c23f358e0 ? 1 : 0) & 0) == 0)
        goto label_10;
      else
        goto label_22;
label_2:
      if (xcef4185c23f358e0)
      {
        dockTarget = this.xc366f13a00f0a38d(xd3311d815ca25f02, x6e150040c8d97700, x13d4cb8d1bd20347);
        goto label_33;
      }
      else
        goto label_33;
label_3:
      if (dockTarget.type == xedb4922162c60d3d.DockTargetType.Undefined)
      {
        if (true)
        {
          if (((xcef4185c23f358e0 ? 1 : 0) & 0) != 0)
            goto label_10;
          else
            goto label_2;
        }
      }
      else
        goto label_33;
label_5:
      if (true)
      {
        if ((uint) xcef4185c23f358e0 >= 0U)
          goto label_2;
        else
          goto label_17;
      }
      else
        goto label_3;
label_10:
      if (xccb1fc68964285c2_1.Contains(client))
        goto label_20;
label_11:
      while (!x6e150040c8d97700.xa358da7dd5364cab.Contains(client))
      {
        if (true)
        {
          if (((xcef4185c23f358e0 ? 1 : 0) | -2) == 0)
          {
            if (((xcef4185c23f358e0 ? 1 : 0) | 3) == 0)
              goto label_5;
            else
              goto label_2;
          }
          else
            goto label_3;
        }
        else if (((xcef4185c23f358e0 ? 1 : 0) & 0) == 0)
          goto label_33;
      }
      goto label_20;
label_17:
      dockTarget.bounds = new Rectangle(xd3311d815ca25f02.PointToScreen(x6e150040c8d97700.Bounds.Location), x6e150040c8d97700.Bounds.Size);
      if (!x6e150040c8d97700.xa358da7dd5364cab.Contains(client))
      {
        if (false)
          ;
        dockTarget.index = x6e150040c8d97700.Controls.Count;
        goto label_3;
      }
      else
      {
        dockTarget.index = x6e150040c8d97700.x17fd454c85fad336(client);
        goto label_3;
      }
label_20:
      dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.JoinExistingSystem);
      dockTarget.dockContainer = xd3311d815ca25f02;
      dockTarget.layoutSystem = x6e150040c8d97700;
      if ((uint) xcef4185c23f358e0 - (uint) xcef4185c23f358e0 >= 0U)
      {
        if (true)
        {
          dockTarget.dockSide = DockSide.None;
          if (((xcef4185c23f358e0 ? 1 : 0) | 15) != 0)
          {
            if (true)
              goto label_17;
            else
              goto label_24;
          }
          else
            goto label_26;
        }
        else
          goto label_24;
      }
      else
        goto label_21;
label_22:
      if (false)
        goto label_2;
      else
        goto label_11;
label_33:
      return dockTarget;
label_25:
      while (x6e150040c8d97700 == this.x83e1554f4315a375)
      {
        Rectangle xccb1fc68964285c2_2 = x6e150040c8d97700.xccb1fc68964285c2;
        if (true)
          goto label_28;
        else
          goto label_31;
label_27:
        return new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.None);
label_28:
        if (!xccb1fc68964285c2_2.Contains(client))
          return new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.Undefined);
        goto label_27;
label_31:
        if (false)
        {
          if (true)
            goto label_26;
        }
        else
          goto label_27;
      }
      goto label_21;
label_26:
      if ((uint) xcef4185c23f358e0 - (uint) xcef4185c23f358e0 > uint.MaxValue)
        goto label_24;
      else
        goto label_21;
    }

    private xedb4922162c60d3d.DockTarget xc366f13a00f0a38d(
      DockContainer xd3311d815ca25f02,
      ControlLayoutSystem x6e150040c8d97700,
      System.Drawing.Point x13d4cb8d1bd20347)
    {
      xedb4922162c60d3d.DockTarget x11d58b056c032b03 = (xedb4922162c60d3d.DockTarget) null;
label_42:
      System.Drawing.Point client = xd3311d815ca25f02.PointToClient(x13d4cb8d1bd20347);
      Rectangle x21ed2ecc088ef4e4 = x6e150040c8d97700.x21ed2ecc088ef4e4;
      if (!new Rectangle(x21ed2ecc088ef4e4.Left, x21ed2ecc088ef4e4.Top, x21ed2ecc088ef4e4.Width, 30).Contains(client))
        goto label_32;
      else
        goto label_40;
label_11:
      this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Right);
      goto label_43;
label_20:
      this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Left);
      goto label_43;
label_28:
      if (false)
        goto label_27;
      else
        goto label_33;
label_18:
      if (false)
        goto label_28;
label_19:
      if (client.Y > x21ed2ecc088ef4e4.Bottom - 30)
      {
        this.x6ff0606cba620904(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, x21ed2ecc088ef4e4, client);
        if (false)
        {
          if (false)
          {
            if (true)
              goto label_29;
          }
          else
            goto label_18;
        }
        else
          goto label_43;
      }
      else
        goto label_20;
label_21:
      Rectangle rectangle;
      if (!rectangle.Contains(client))
      {
        if (new Rectangle(x21ed2ecc088ef4e4.Right - 30, x21ed2ecc088ef4e4.Top, 30, x21ed2ecc088ef4e4.Height).Contains(client))
          goto label_16;
        else
          goto label_9;
label_8:
        while (client.X >= x21ed2ecc088ef4e4.Left + 30)
        {
          while (true || true)
          {
            if (client.X > x21ed2ecc088ef4e4.Right - 30)
            {
              this.x4ea01976b3079611(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, x21ed2ecc088ef4e4, client);
              goto label_43;
            }
            else if (false)
            {
              if (true)
                goto label_43;
            }
            else if (true)
            {
              this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Bottom);
              goto label_43;
            }
            else
              goto label_42;
          }
        }
        this.x6ff0606cba620904(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, x21ed2ecc088ef4e4, client);
        goto label_43;
label_9:
        if (new Rectangle(x21ed2ecc088ef4e4.Left, x21ed2ecc088ef4e4.Bottom - 30, x21ed2ecc088ef4e4.Width, 30).Contains(client))
        {
          x11d58b056c032b03 = this.x7aa9d6b148df47c3(xd3311d815ca25f02, x6e150040c8d97700);
          goto label_8;
        }
        else
          goto label_43;
label_16:
        x11d58b056c032b03 = this.x7aa9d6b148df47c3(xd3311d815ca25f02, x6e150040c8d97700);
        if (client.Y >= x21ed2ecc088ef4e4.Top + 30)
        {
          if (client.Y <= x21ed2ecc088ef4e4.Bottom - 30)
          {
            if (true)
              goto label_11;
            else
              goto label_8;
          }
          else
          {
            this.x4ea01976b3079611(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, x21ed2ecc088ef4e4, client);
            goto label_43;
          }
        }
        else
        {
          this.x142a59be2748bb95(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, x21ed2ecc088ef4e4, client);
          goto label_43;
        }
      }
label_27:
      x11d58b056c032b03 = this.x7aa9d6b148df47c3(xd3311d815ca25f02, x6e150040c8d97700);
      if (client.Y >= x21ed2ecc088ef4e4.Top + 30)
        goto label_19;
      else
        goto label_34;
label_33:
      if (true)
        goto label_21;
label_34:
      if (true)
      {
        if (true)
        {
          this.x2a1e65376d30fca5(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, x21ed2ecc088ef4e4, client);
          goto label_43;
        }
        else
          goto label_32;
      }
      else
        goto label_18;
label_29:
      if (client.X > x21ed2ecc088ef4e4.Right - 30)
      {
        this.x142a59be2748bb95(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, x21ed2ecc088ef4e4, client);
        goto label_43;
      }
      else
      {
        this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Top);
        goto label_43;
      }
label_32:
      rectangle = new Rectangle(x21ed2ecc088ef4e4.Left, x21ed2ecc088ef4e4.Top, 30, x21ed2ecc088ef4e4.Height);
      goto label_28;
label_40:
      if (true)
      {
        x11d58b056c032b03 = this.x7aa9d6b148df47c3(xd3311d815ca25f02, x6e150040c8d97700);
        if (true)
        {
          if (true)
          {
            if (true)
            {
              if (client.X >= x21ed2ecc088ef4e4.Left + 30)
                goto label_29;
            }
            else
              goto label_11;
          }
          this.x2a1e65376d30fca5(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, x21ed2ecc088ef4e4, client);
          if (false)
            goto label_20;
        }
        else
          goto label_28;
      }
label_43:
      return x11d58b056c032b03;
    }

    private void x4ea01976b3079611(
      DockContainer xd3311d815ca25f02,
      ControlLayoutSystem x6e150040c8d97700,
      xedb4922162c60d3d.DockTarget x11d58b056c032b03,
      Rectangle x21ed2ecc088ef4e4,
      System.Drawing.Point x6b2bb9f943411698)
    {
      x21ed2ecc088ef4e4.X = x21ed2ecc088ef4e4.Right - 30;
      if (true)
        goto label_4;
label_1:
      if (x6b2bb9f943411698.Y > x21ed2ecc088ef4e4.Top + (int) ((double) x21ed2ecc088ef4e4.Height * ((double) x6b2bb9f943411698.X / (double) x21ed2ecc088ef4e4.Width)))
      {
        this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Bottom);
        return;
      }
      this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Right);
      return;
label_4:
      if (false)
        return;
      x21ed2ecc088ef4e4.Y = x21ed2ecc088ef4e4.Bottom - 30;
      x6b2bb9f943411698.X -= x21ed2ecc088ef4e4.Left;
      x6b2bb9f943411698.Y -= x21ed2ecc088ef4e4.Top;
      x21ed2ecc088ef4e4 = new Rectangle(0, 0, 30, 30);
      if (true)
        goto label_1;
    }

    private void x6ff0606cba620904(
      DockContainer xd3311d815ca25f02,
      ControlLayoutSystem x6e150040c8d97700,
      xedb4922162c60d3d.DockTarget x11d58b056c032b03,
      Rectangle x21ed2ecc088ef4e4,
      System.Drawing.Point x6b2bb9f943411698)
    {
      x21ed2ecc088ef4e4.Y = x21ed2ecc088ef4e4.Bottom - 30;
      x6b2bb9f943411698.X -= x21ed2ecc088ef4e4.Left;
      if (false)
        ;
      x6b2bb9f943411698.Y -= x21ed2ecc088ef4e4.Top;
      x21ed2ecc088ef4e4 = new Rectangle(0, 0, 30, 30);
      if (x6b2bb9f943411698.Y <= x21ed2ecc088ef4e4.Bottom - (int) ((double) x21ed2ecc088ef4e4.Height * ((double) x6b2bb9f943411698.X / (double) x21ed2ecc088ef4e4.Width)))
        this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Left);
      else
        this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Bottom);
    }

    private void x142a59be2748bb95(
      DockContainer xd3311d815ca25f02,
      ControlLayoutSystem x6e150040c8d97700,
      xedb4922162c60d3d.DockTarget x11d58b056c032b03,
      Rectangle x21ed2ecc088ef4e4,
      System.Drawing.Point x6b2bb9f943411698)
    {
      x21ed2ecc088ef4e4.X = x21ed2ecc088ef4e4.Right - 30;
      x6b2bb9f943411698.X -= x21ed2ecc088ef4e4.Left;
      x6b2bb9f943411698.Y -= x21ed2ecc088ef4e4.Top;
      x21ed2ecc088ef4e4 = new Rectangle(0, 0, 30, 30);
      if (x6b2bb9f943411698.Y <= x21ed2ecc088ef4e4.Top + (int) ((double) x21ed2ecc088ef4e4.Height * ((double) (x21ed2ecc088ef4e4.Right - x6b2bb9f943411698.X) / (double) x21ed2ecc088ef4e4.Width)))
        this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Top);
      else
        this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Right);
    }

    private void x2a1e65376d30fca5(
      DockContainer xd3311d815ca25f02,
      ControlLayoutSystem x6e150040c8d97700,
      xedb4922162c60d3d.DockTarget x11d58b056c032b03,
      Rectangle x21ed2ecc088ef4e4,
      System.Drawing.Point x6b2bb9f943411698)
    {
      x6b2bb9f943411698.X -= x21ed2ecc088ef4e4.Left;
      do
      {
        x6b2bb9f943411698.Y -= x21ed2ecc088ef4e4.Top;
        if (true)
        {
          x21ed2ecc088ef4e4 = new Rectangle(0, 0, 30, 30);
          if (x6b2bb9f943411698.Y <= x21ed2ecc088ef4e4.Top + (int) ((double) x21ed2ecc088ef4e4.Height * ((double) x6b2bb9f943411698.X / (double) x21ed2ecc088ef4e4.Width)))
            this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Top);
          else
            goto label_2;
        }
        else
          goto label_5;
      }
      while (false);
      goto label_6;
label_5:
      return;
label_2:
      this.xa86a93682c30b8c6(xd3311d815ca25f02, x6e150040c8d97700, x11d58b056c032b03, DockSide.Left);
      return;
label_6:;
    }

    private void xa86a93682c30b8c6(
      DockContainer xd3311d815ca25f02,
      ControlLayoutSystem x6e150040c8d97700,
      xedb4922162c60d3d.DockTarget x11d58b056c032b03,
      DockSide x4f217665270fa928)
    {
      x11d58b056c032b03.bounds = this.x3102817291e84207(xd3311d815ca25f02, x6e150040c8d97700, x4f217665270fa928);
      x11d58b056c032b03.dockSide = x4f217665270fa928;
    }

    internal Rectangle x3102817291e84207(
      DockContainer xd3311d815ca25f02,
      ControlLayoutSystem x6e150040c8d97700,
      DockSide x4f217665270fa928)
    {
      Rectangle rectangle = new Rectangle(xd3311d815ca25f02.PointToScreen(x6e150040c8d97700.Bounds.Location), x6e150040c8d97700.Bounds.Size);
      switch (x4f217665270fa928)
      {
        case DockSide.Top:
          rectangle.Height /= 2;
          goto default;
        case DockSide.Bottom:
          rectangle.Offset(0, rectangle.Height / 2);
          rectangle.Height /= 2;
          if (true)
          {
            if (true)
              goto default;
            else
              goto case DockSide.Top;
          }
          else
            break;
        case DockSide.Left:
          rectangle.Width /= 2;
          if (true)
            break;
          goto default;
        case DockSide.Right:
          rectangle.Offset(rectangle.Width / 2, 0);
          rectangle.Width /= 2;
          goto default;
        default:
label_7:
          return rectangle;
      }
      if (false)
        goto label_7;
      else
        goto label_7;
    }

    private xedb4922162c60d3d.DockTarget x7aa9d6b148df47c3(
      DockContainer xd3311d815ca25f02,
      ControlLayoutSystem x6e150040c8d97700)
    {
      return new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.SplitExistingSystem) { dockContainer = xd3311d815ca25f02, layoutSystem = x6e150040c8d97700 };
    }

    public override void Commit()
    {
      base.Commit();
      LayoutUtilities.x3a04ba0cdf69aff2();
      try
      {
        if (this.x67ecc0d0e7c9a202 == null)
          return;
        this.x67ecc0d0e7c9a202(this.x521249670374b9ee);
      }
      finally
      {
        LayoutUtilities.x861aa05d0acfeb39();
      }
    }

    public override void Dispose()
    {
      this.x0467b00af7810f0c.OnDockingFinished(EventArgs.Empty);
      if (true)
        goto label_6;
label_1:
      base.Dispose();
      return;
label_6:
      do
      {
        if (this.x90ce1c0ec8c6028d != (Cursor) null)
        {
          this.x90ce1c0ec8c6028d.Dispose();
          if (false)
            continue;
        }
        if (this.x52988e63e407fffa != (Cursor) null)
          goto label_3;
      }
      while (false);
      goto label_1;
label_3:
      this.x52988e63e407fffa.Dispose();
      goto label_1;
    }

    public delegate void DockingManagerFinishedEventHandler(xedb4922162c60d3d.DockTarget target);

    public class DockTarget
    {
      public DockSide dockSide = DockSide.None;
      public Rectangle bounds = Rectangle.Empty;
      public ContainerDockLocation dockLocation = ContainerDockLocation.Center;
      public xedb4922162c60d3d.DockTargetType type;
      public DockContainer dockContainer;
      public ControlLayoutSystem layoutSystem;
      public int index;
      public bool middle;

      public DockTarget(xedb4922162c60d3d.DockTargetType type)
      {
        this.type = type;
      }
    }

    public enum DockTargetType
    {
      Undefined,
      None,
      Float,
      SplitExistingSystem,
      JoinExistingSystem,
      CreateNewContainer,
      AlreadyActioned,
    }
  }
}
