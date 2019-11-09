// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x10ac79a4257c7f52
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
  internal class x10ac79a4257c7f52 : Control
  {
    private SandDockManager x91f347c6e97f1846;
    private x10ac79a4257c7f52.x01c0afa1afffb431 x820c504c9c557c92;
    private Timer x537a4001020fd4c7;
    private Timer x2076b5c9f1eb82ef;
    private System.Drawing.Point xa639e9f791585165;
    private ControlLayoutSystem xdf67155884991aa8;
    private TD.SandDock.x87cf4de36131799d x5fea292ffeb2c28c;
    private Rectangle x792c0fd4639cad90;
    private bool x297f71a96c16086c;

    public x10ac79a4257c7f52()
    {
      this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
      this.SetStyle(ControlStyles.Selectable, false);
      this.x820c504c9c557c92 = new x10ac79a4257c7f52.x01c0afa1afffb431(this);
      this.x537a4001020fd4c7 = new Timer();
      this.x537a4001020fd4c7.Interval = SystemInformation.DoubleClickTime;
      this.x537a4001020fd4c7.Tick += new EventHandler(this.x79a58a5d2c65c5a4);
      this.x2076b5c9f1eb82ef = new Timer();
      if (false)
        return;
      do
      {
        this.x2076b5c9f1eb82ef.Interval = 800;
        this.x2076b5c9f1eb82ef.Tick += new EventHandler(this.xeccc53b32ba6b859);
        this.Visible = false;
      }
      while (false);
    }

    public x10ac79a4257c7f52.x01c0afa1afffb431 x7fdaeb05cb5e84f3
    {
      get
      {
        return this.x820c504c9c557c92;
      }
    }

    public SandDockManager x460ab163f44a604d
    {
      get
      {
        return this.x91f347c6e97f1846;
      }
      set
      {
        if (this.x91f347c6e97f1846 != null)
          this.x91f347c6e97f1846.UnregisterAutoHideBar(this);
        this.x91f347c6e97f1846 = value;
        if (this.x91f347c6e97f1846 == null)
          return;
        this.x91f347c6e97f1846.RegisterAutoHideBar(this);
        this.x7e9646eed248ed11();
        if (false)
          ;
      }
    }

    private int xf03a14e5f0010fc9
    {
      get
      {
        return Math.Max(Control.DefaultFont.Height, 16) + 6;
      }
    }

    public Control x87cf4de36131799d
    {
      get
      {
        return (Control) this.x5fea292ffeb2c28c;
      }
    }

    protected override System.Drawing.Size DefaultSize
    {
      get
      {
        return new System.Drawing.Size(this.xf03a14e5f0010fc9, this.xf03a14e5f0010fc9);
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

    internal void x200394302d96eb9b(ControlLayoutSystem x6e150040c8d97700)
    {
      this.x7e9646eed248ed11();
      if (this.x23498f53d87354d4 != x6e150040c8d97700)
        return;
      this.x5fea292ffeb2c28c.PerformLayout();
    }

    internal void x4481febbc2e58301()
    {
      this.x7e9646eed248ed11();
    }

    private void x7e9646eed248ed11()
    {
      int num1 = 0;
      if (this.x23498f53d87354d4 == null)
        goto label_56;
      else
        goto label_58;
label_1:
      RendererBase renderer = this.x460ab163f44a604d.Renderer;
      using (Graphics graphics = this.CreateGraphics())
      {
        foreach (ControlLayoutSystem controlLayoutSystem in (CollectionBase) this.x7fdaeb05cb5e84f3)
        {
          int num2;
          int num3;
          int num4;
          do
          {
            num1 += 3;
            num3 = 0;
            if ((uint) num4 >= 0U)
            {
              if (renderer.TabTextDisplay == TabTextDisplayMode.SelectedTab)
                goto label_32;
            }
            else
              break;
          }
          while ((uint) num1 + (uint) num2 < 0U);
label_4:
          foreach (DockControl control in (CollectionBase) controlLayoutSystem.Controls)
          {
            Rectangle rectangle = new Rectangle(-1, -1, this.xf03a14e5f0010fc9 - 2, this.xf03a14e5f0010fc9 - 2);
            switch (this.Dock)
            {
              case DockStyle.Bottom:
                rectangle.Offset(0, 3);
                break;
              case DockStyle.Right:
                rectangle.Offset(3, 0);
                break;
            }
            num2 = 7;
            num2 += 16;
            if (false)
              goto label_10;
            else
              goto label_24;
label_6:
            num1 += num2;
label_7:
            control.x700c42042910e68b = rectangle;
            continue;
label_10:
            if (controlLayoutSystem.SelectedControl == control)
              goto label_15;
label_11:
            if (!this.x61c108cc44ef385a)
            {
              rectangle.Offset(num1, 0);
              rectangle.Width = num2;
              goto label_6;
            }
            else if (true)
            {
              rectangle.Offset(0, num1);
              rectangle.Height = num2;
              num1 += num2;
              goto label_7;
            }
            else
              goto label_18;
label_15:
            num2 += num3 + 16;
            goto label_11;
label_18:
            num2 += 3;
            goto label_11;
label_24:
            if ((uint) num3 >= 0U)
              goto label_19;
            else
              goto label_20;
label_16:
            if (!this.x61c108cc44ef385a)
            {
              num2 += (int) Math.Ceiling((double) graphics.MeasureString(control.TabText, this.Font, int.MaxValue, EverettRenderer.x27e1c82c97265861).Width);
              goto label_18;
            }
            else
            {
              num2 += (int) Math.Ceiling((double) graphics.MeasureString(control.TabText, this.Font, int.MaxValue, EverettRenderer.xc351c68a86733972).Height);
              goto label_18;
            }
label_19:
            if (renderer.TabTextDisplay != TabTextDisplayMode.AllTabs)
            {
              if ((num3 & 0) == 0)
                goto label_10;
              else
                goto label_15;
            }
            else
              goto label_16;
label_20:
            if ((uint) num1 + (uint) num3 > uint.MaxValue)
              goto label_6;
            else
              goto label_16;
          }
          num1 += 10;
          continue;
label_32:
          IEnumerator enumerator = controlLayoutSystem.Controls.GetEnumerator();
          try
          {
label_35:
            if (!enumerator.MoveNext())
            {
              if (true)
                goto label_4;
              else
                goto label_39;
            }
            else
              goto label_41;
label_38:
            while (num4 > num3)
            {
              num3 = num4;
              if ((num1 | -2) == 0)
                ;
              if ((num2 | 2) != 0)
                break;
            }
            goto label_35;
label_39:
            DockControl current;
            do
            {
              num4 = (int) Math.Ceiling((double) graphics.MeasureString(current.TabText, this.Font, int.MaxValue, EverettRenderer.xc351c68a86733972).Height);
            }
            while ((uint) num1 + (uint) num1 > uint.MaxValue);
            goto label_38;
label_41:
            current = (DockControl) enumerator.Current;
            if (!this.x61c108cc44ef385a)
            {
              num4 = (int) Math.Ceiling((double) graphics.MeasureString(current.TabText, this.Font, int.MaxValue, EverettRenderer.x27e1c82c97265861).Width);
              goto label_38;
            }
            else
              goto label_39;
          }
          finally
          {
            IDisposable disposable = enumerator as IDisposable;
            if ((uint) num2 > uint.MaxValue || disposable != null)
              disposable.Dispose();
          }
        }
      }
      this.Visible = this.x7fdaeb05cb5e84f3.Count != 0;
      this.Invalidate();
      return;
label_56:
      if (this.x460ab163f44a604d == null)
        return;
      int num5;
      if ((uint) num1 - (uint) num5 <= uint.MaxValue)
        goto label_1;
label_58:
      if (this.x7fdaeb05cb5e84f3.x263d579af1d0d43f(this.x23498f53d87354d4))
      {
        if ((uint) num5 + (uint) num5 <= uint.MaxValue)
          goto label_56;
        else
          goto label_1;
      }
      else
      {
        this.xcdb145600c1b7224(true);
        goto label_56;
      }
    }

    private DockControl x37c93a224e23ba95(System.Drawing.Point x13d4cb8d1bd20347)
    {
      IEnumerator enumerator1 = this.x7fdaeb05cb5e84f3.GetEnumerator();
      try
      {
label_14:
        if (enumerator1.MoveNext())
        {
          IEnumerator enumerator2 = ((ControlLayoutSystem) enumerator1.Current).Controls.GetEnumerator();
          try
          {
label_4:
            DockControl current;
            do
            {
              if (!enumerator2.MoveNext())
              {
                if (true)
                  goto label_14;
              }
              do
              {
                current = (DockControl) enumerator2.Current;
                if (current.x700c42042910e68b.Contains(x13d4cb8d1bd20347))
                  goto label_9;
              }
              while (false);
            }
            while (false);
            goto label_4;
label_9:
            return current;
          }
          finally
          {
            IDisposable disposable = enumerator2 as IDisposable;
            while (disposable != null)
            {
              disposable.Dispose();
              if (true)
                break;
            }
          }
        }
      }
      finally
      {
        (enumerator1 as IDisposable)?.Dispose();
      }
      return (DockControl) null;
    }

    protected override void OnPaintBackground(PaintEventArgs pevent)
    {
      if (this.x460ab163f44a604d == null)
        goto label_4;
label_1:
      if (this.x460ab163f44a604d.DockSystemContainer != null)
      {
        this.x460ab163f44a604d.Renderer.DrawAutoHideBarBackground(this.x460ab163f44a604d.DockSystemContainer, (Control) this, pevent.Graphics, this.ClientRectangle);
        return;
      }
label_4:
      base.OnPaintBackground(pevent);
      if (false)
        goto label_1;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (this.x460ab163f44a604d != null)
        goto label_28;
label_27:
      base.OnPaint(e);
      return;
label_28:
      DockSide dockSide = DockSide.Right;
      switch (this.Dock)
      {
        case DockStyle.Top:
          dockSide = DockSide.Top;
          if (false)
            goto case DockStyle.Left;
          else
            break;
        case DockStyle.Bottom:
          dockSide = DockSide.Bottom;
          break;
        case DockStyle.Left:
          dockSide = DockSide.Left;
          break;
        default:
          if (false)
            break;
          break;
      }
      this.x460ab163f44a604d.Renderer.StartRenderSession(HotkeyPrefix.None);
      foreach (ControlLayoutSystem controlLayoutSystem in (CollectionBase) this.x7fdaeb05cb5e84f3)
      {
        foreach (DockControl control in (CollectionBase) controlLayoutSystem.Controls)
        {
          string text;
          DrawItemState state;
          do
          {
            state = DrawItemState.Default;
            if (control == controlLayoutSystem.SelectedControl)
              state |= DrawItemState.Selected;
            text = control.TabText;
            if (this.x460ab163f44a604d.Renderer.TabTextDisplay != TabTextDisplayMode.SelectedTab)
              goto label_7;
          }
          while (false);
          goto label_10;
label_7:
          this.x460ab163f44a604d.Renderer.DrawCollapsedTab(e.Graphics, control.x700c42042910e68b, dockSide, control.x1999b243e321e38a, text, this.Font, control.BackColor, control.ForeColor, state, this.x61c108cc44ef385a);
          continue;
label_10:
          if (true)
          {
            if (control == controlLayoutSystem.SelectedControl)
              goto label_7;
          }
          else if (false)
            break;
          text = "";
          goto label_7;
        }
      }
      this.x460ab163f44a604d.Renderer.FinishRenderSession();
      if (false)
        goto label_27;
    }

    private void x53cde82d34a241f8(
      TD.SandDock.x87cf4de36131799d xd70b090e3181abff,
      Rectangle x0ac6c3cc02709091,
      Rectangle x0cd0c84a144ffcbc)
    {
      this.x297f71a96c16086c = true;
      try
      {
        float num1 = (float) (x0cd0c84a144ffcbc.X - x0ac6c3cc02709091.X);
        float num2 = (float) (x0cd0c84a144ffcbc.Y - x0ac6c3cc02709091.Y);
label_8:
        float num3 = (float) (x0cd0c84a144ffcbc.Width - x0ac6c3cc02709091.Width);
        float num4 = (float) (x0cd0c84a144ffcbc.Height - x0ac6c3cc02709091.Height);
        int tickCount = Environment.TickCount;
        while (Environment.TickCount < tickCount + 100)
        {
label_7:
          float num5 = (float) (Environment.TickCount - tickCount) / 100f;
          float num6 = (float) x0ac6c3cc02709091.X + num1 * num5;
          float num7 = (float) x0ac6c3cc02709091.Y + num2 * num5;
          float num8 = (float) x0ac6c3cc02709091.Width + num3 * num5;
          float num9 = (float) x0ac6c3cc02709091.Height + num4 * num5;
          if ((uint) num4 - (uint) num2 <= uint.MaxValue)
          {
            if (((int) (uint) num1 & 0) == 0)
            {
              do
              {
                Rectangle rectangle = new Rectangle((int) num6, (int) num7, (int) num8, (int) num9);
                xd70b090e3181abff.SetBounds(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, BoundsSpecified.All);
                Application.DoEvents();
                if ((uint) num2 - (uint) num4 >= 0U && xd70b090e3181abff != null)
                {
                  if ((uint) num7 + (uint) num1 < 0U)
                    goto label_7;
                }
                else
                  goto label_12;
              }
              while ((tickCount | 1) == 0);
              goto label_11;
label_12:
              break;
            }
label_11:
            if ((uint) num1 - (uint) num1 < 0U)
              break;
          }
          else
            goto label_8;
        }
      }
      finally
      {
        this.x297f71a96c16086c = false;
      }
    }

    public ControlLayoutSystem x23498f53d87354d4
    {
      get
      {
        return this.xdf67155884991aa8;
      }
    }

    public int xca843b3e9a1c605f
    {
      get
      {
        return this.x5fea292ffeb2c28c.xca843b3e9a1c605f;
      }
      set
      {
        if (value == this.x5fea292ffeb2c28c.xca843b3e9a1c605f)
          return;
        this.x5fea292ffeb2c28c.xca843b3e9a1c605f = value;
      }
    }

    private bool x6991238ec3e25129()
    {
      return !x443cc432acaadb1d.x641f26d1017e3571;
    }

    internal void xcdb145600c1b7224(bool x0b9c38731edfc369)
    {
      if (this.xdf67155884991aa8 == null)
        return;
      TD.SandDock.x87cf4de36131799d x5fea292ffeb2c28c = this.x5fea292ffeb2c28c;
label_19:
      if (true)
        goto label_20;
label_7:
      Control[] controlArray1;
      x5fea292ffeb2c28c.Controls.CopyTo((Array) controlArray1, 0);
      Control[] controlArray2 = controlArray1;
      int index;
      if ((uint) x0b9c38731edfc369 + (uint) index >= 0U)
        goto label_4;
label_2:
      ControlLayoutSystem xdf67155884991aa8;
      if (xdf67155884991aa8 == null || (uint) x0b9c38731edfc369 <= uint.MaxValue && xdf67155884991aa8.SelectedControl == null)
        return;
      xdf67155884991aa8.SelectedControl.OnAutoHidePopupClosed(EventArgs.Empty);
      if ((uint) index - (uint) x0b9c38731edfc369 <= uint.MaxValue)
        return;
      goto label_11;
label_4:
      for (index = 0; index < controlArray2.Length; ++index)
        LayoutUtilities.xa7513d57b4844d46(controlArray2[index]);
      x5fea292ffeb2c28c.Dispose();
      goto label_2;
label_10:
      xdf67155884991aa8 = this.xdf67155884991aa8;
      this.xdf67155884991aa8 = (ControlLayoutSystem) null;
      controlArray1 = new Control[x5fea292ffeb2c28c.Controls.Count];
      goto label_7;
label_11:
      x5fea292ffeb2c28c.ResumeLayout();
      if (((x0b9c38731edfc369 ? 1 : 0) & 0) == 0)
      {
        while ((uint) x0b9c38731edfc369 <= uint.MaxValue)
        {
          if ((uint) index <= uint.MaxValue)
            goto label_10;
        }
      }
      else
        goto label_19;
label_12:
      if (!x0b9c38731edfc369)
      {
        Rectangle xd2acd28268ef2513;
        this.x8012502b8eced8ff(this.xdf67155884991aa8.xca843b3e9a1c605f, out xd2acd28268ef2513);
        x5fea292ffeb2c28c.SuspendLayout();
        this.x53cde82d34a241f8(x5fea292ffeb2c28c, x5fea292ffeb2c28c.Bounds, xd2acd28268ef2513);
        goto label_11;
      }
      else
        goto label_10;
label_20:
      int num;
      if (x0b9c38731edfc369)
        num = 1;
      else
        goto label_21;
label_16:
      x0b9c38731edfc369 = num != 0;
      this.x2076b5c9f1eb82ef.Enabled = false;
      goto label_12;
label_21:
      if (false)
        ;
      num = !this.x6991238ec3e25129() ? 1 : 0;
      goto label_16;
    }

    internal void xe6ff614263a59ef9(
      DockControl x43bec302f92080b9,
      bool x0b9c38731edfc369,
      bool x17cc8f73454a0462)
    {
      if (this.xdf67155884991aa8 == x43bec302f92080b9.LayoutSystem)
        goto label_54;
label_1:
      int num;
      if (x0b9c38731edfc369)
        num = 1;
      else
        goto label_46;
label_3:
      x0b9c38731edfc369 = num != 0;
      x43bec302f92080b9.LayoutSystem.SelectedControl = x43bec302f92080b9;
      if (x43bec302f92080b9.LayoutSystem.SelectedControl != x43bec302f92080b9)
        return;
      try
      {
        if (this.xdf67155884991aa8 == x43bec302f92080b9.LayoutSystem)
        {
          if ((uint) x17cc8f73454a0462 + (uint) x17cc8f73454a0462 > uint.MaxValue)
          {
            if (((x0b9c38731edfc369 ? 1 : 0) & 0) != 0 && (uint) x0b9c38731edfc369 + (uint) x0b9c38731edfc369 >= 0U)
              goto label_11;
          }
          else
            goto label_35;
        }
        else
          goto label_20;
label_8:
        TD.SandDock.x87cf4de36131799d xd70b090e3181abff;
        if (xd70b090e3181abff.IsDisposed)
          return;
        if (xd70b090e3181abff.Parent == null)
          goto label_11;
label_10:
        this.x5fea292ffeb2c28c = xd70b090e3181abff;
        this.xdf67155884991aa8 = x43bec302f92080b9.LayoutSystem;
        this.x2076b5c9f1eb82ef.Enabled = true;
        x43bec302f92080b9.OnAutoHidePopupOpened(EventArgs.Empty);
        if ((uint) x17cc8f73454a0462 + (uint) x17cc8f73454a0462 >= 0U)
          return;
        goto label_35;
label_11:
        if ((uint) x17cc8f73454a0462 - (uint) x0b9c38731edfc369 <= uint.MaxValue)
          return;
label_12:
        if (((x17cc8f73454a0462 ? 1 : 0) | 8) == 0)
          return;
        goto label_8;
label_20:
        Rectangle xd2acd28268ef2513;
        do
        {
          this.xcdb145600c1b7224(true);
          if (true)
          {
            this.x792c0fd4639cad90 = this.x8012502b8eced8ff(x43bec302f92080b9.LayoutSystem.xca843b3e9a1c605f, out xd2acd28268ef2513);
            xd70b090e3181abff = new TD.SandDock.x87cf4de36131799d(this);
            IEnumerator enumerator = x43bec302f92080b9.LayoutSystem.Controls.GetEnumerator();
            try
            {
              while (enumerator.MoveNext())
              {
                DockControl current = (DockControl) enumerator.Current;
                while (current.Parent != null)
                {
                  LayoutUtilities.xa7513d57b4844d46((Control) current);
                  if ((uint) x17cc8f73454a0462 - (uint) x0b9c38731edfc369 >= 0U)
                    goto label_24;
                }
                if (((x17cc8f73454a0462 ? 1 : 0) & 0) != 0)
                  continue;
label_24:
                current.Parent = (Control) xd70b090e3181abff;
              }
            }
            finally
            {
              IDisposable disposable = enumerator as IDisposable;
              while (disposable != null)
              {
                disposable.Dispose();
                if (true)
                  break;
              }
            }
            xd70b090e3181abff.x5a9cbf8ad0ee9896 = x43bec302f92080b9.LayoutSystem;
            xd70b090e3181abff.Visible = false;
          }
          else
            goto label_12;
        }
        while ((uint) x17cc8f73454a0462 > uint.MaxValue);
        if (true)
        {
          this.Parent.Controls.Add((Control) xd70b090e3181abff);
          xd70b090e3181abff.Bounds = this.x792c0fd4639cad90;
          if (true)
          {
            if (true)
              goto label_18;
label_15:
            while (x0b9c38731edfc369)
            {
              if ((uint) x0b9c38731edfc369 >= 0U)
              {
                if ((uint) x17cc8f73454a0462 - (uint) x17cc8f73454a0462 >= 0U)
                  goto label_14;
              }
              else
                goto label_10;
            }
            goto label_17;
label_14:
            xd70b090e3181abff.Bounds = this.x792c0fd4639cad90;
            xd70b090e3181abff.ResumeLayout();
            goto label_8;
label_17:
            this.x53cde82d34a241f8(xd70b090e3181abff, xd2acd28268ef2513, this.x792c0fd4639cad90);
            goto label_14;
label_18:
            xd70b090e3181abff.SuspendLayout();
            xd70b090e3181abff.Bounds = xd2acd28268ef2513;
            xd70b090e3181abff.Visible = true;
            xd70b090e3181abff.BringToFront();
            goto label_15;
          }
        }
label_35:
        if (false)
          ;
        return;
      }
      finally
      {
        if (x17cc8f73454a0462 && (((x0b9c38731edfc369 ? 1 : 0) | 1) == 0 || this.x23498f53d87354d4 == x43bec302f92080b9.LayoutSystem))
          x43bec302f92080b9.Activate();
      }
label_46:
      num = !this.x6991238ec3e25129() ? 1 : 0;
      goto label_3;
label_54:
      if ((uint) x0b9c38731edfc369 - (uint) x17cc8f73454a0462 >= 0U)
      {
        if (x43bec302f92080b9.LayoutSystem.SelectedControl != x43bec302f92080b9)
        {
          if (((x17cc8f73454a0462 ? 1 : 0) | int.MaxValue) != 0)
            goto label_1;
          else
            goto label_46;
        }
      }
      else
        goto label_52;
label_50:
      if (!x17cc8f73454a0462)
      {
        if ((uint) x17cc8f73454a0462 < 0U)
          ;
        return;
      }
      goto label_53;
label_52:
      if ((uint) x0b9c38731edfc369 + (uint) x0b9c38731edfc369 <= uint.MaxValue)
        goto label_50;
label_53:
      x43bec302f92080b9.Activate();
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      if (this.xdf67155884991aa8 == null)
        return;
      this.BeginInvoke((Delegate) new x10ac79a4257c7f52.x23dc61b48e59b2f1(this.xcdb145600c1b7224), (object) true);
    }

    protected override void OnLocationChanged(EventArgs e)
    {
      base.OnLocationChanged(e);
      if (this.xdf67155884991aa8 == null)
        return;
      this.BeginInvoke((Delegate) new x10ac79a4257c7f52.x23dc61b48e59b2f1(this.xcdb145600c1b7224), (object) true);
    }

    private Rectangle x8012502b8eced8ff(
      int x5614e4ef0596c91d,
      out Rectangle xd2acd28268ef2513)
    {
      Rectangle rectangle = this.Bounds;
      switch (this.Dock)
      {
        case DockStyle.Top:
          rectangle = new Rectangle(rectangle.Left, rectangle.Bottom, rectangle.Width, 0);
          goto label_12;
        case DockStyle.Bottom:
          rectangle = new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, 0);
          goto label_12;
        case DockStyle.Left:
          rectangle = new Rectangle(rectangle.Right, rectangle.Top, 0, rectangle.Height);
          goto label_12;
        case DockStyle.Right:
          rectangle = new Rectangle(rectangle.Left, rectangle.Top, 0, rectangle.Height);
          goto label_12;
        default:
          if (true)
          {
            if (true)
              goto label_12;
            else
              goto label_18;
          }
          else
            goto label_8;
      }
label_7:
      DockStyle dock = this.Dock;
label_8:
      int num;
      bool flag;
      if ((uint) flag <= uint.MaxValue)
      {
        switch (dock)
        {
          case DockStyle.Top:
            rectangle.Height = num;
            goto label_18;
          case DockStyle.Bottom:
            rectangle.Offset(0, -num);
            rectangle.Height = num;
            if ((uint) num - (uint) flag < 0U)
              goto label_7;
            else
              goto label_18;
          case DockStyle.Left:
            rectangle.Width = num;
            goto label_18;
          case DockStyle.Right:
            do
            {
              rectangle.Offset(-num, 0);
            }
            while ((uint) num - (uint) x5614e4ef0596c91d > uint.MaxValue);
            rectangle.Width = num;
            goto label_18;
          default:
            if ((uint) num - (uint) flag >= 0U || (uint) x5614e4ef0596c91d + (uint) num < 0U)
              goto label_18;
            else
              goto case DockStyle.Top;
        }
      }
      else
        goto label_7;
label_12:
      xd2acd28268ef2513 = rectangle;
      flag = true;
      num = x5614e4ef0596c91d;
      if (flag)
      {
        num += 4;
        goto label_7;
      }
      else
        goto label_7;
label_18:
      return rectangle;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      while (!this.x297f71a96c16086c)
      {
        System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);
        if (!(point != this.xa639e9f791585165))
        {
          if (true)
            break;
        }
        else
        {
          this.xa639e9f791585165 = point;
          this.x537a4001020fd4c7.Enabled = false;
          this.x537a4001020fd4c7.Enabled = true;
          if (true)
            break;
          break;
        }
      }
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
label_2:
      if (this.x297f71a96c16086c)
        return;
      DockControl x43bec302f92080b9 = this.x37c93a224e23ba95(new System.Drawing.Point(e.X, e.Y));
      while (x43bec302f92080b9 != null)
      {
        if (true)
        {
          if (true)
          {
            this.xe6ff614263a59ef9(x43bec302f92080b9, false, true);
            break;
          }
          goto label_2;
        }
      }
    }

    protected override void OnDragOver(DragEventArgs drgevent)
    {
      base.OnDragOver(drgevent);
      DockControl x43bec302f92080b9 = this.x37c93a224e23ba95(this.PointToClient(new System.Drawing.Point(drgevent.X, drgevent.Y)));
      if (x43bec302f92080b9 == null)
        return;
      this.xe6ff614263a59ef9(x43bec302f92080b9, true, false);
    }

    private void x79a58a5d2c65c5a4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.x537a4001020fd4c7.Enabled = false;
      while (this.x297f71a96c16086c)
      {
        if (true)
          return;
      }
      DockControl x43bec302f92080b9 = this.x37c93a224e23ba95(this.PointToClient(Cursor.Position));
      if (x43bec302f92080b9 == null)
        return;
      this.xe6ff614263a59ef9(x43bec302f92080b9, false, false);
    }

    private void xeccc53b32ba6b859(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      bool flag1 = this.x5fea292ffeb2c28c.ClientRectangle.Contains(this.x5fea292ffeb2c28c.PointToClient(Cursor.Position));
      bool flag2;
      if ((uint) flag2 < 0U)
        return;
label_16:
      bool flag3 = this.ClientRectangle.Contains(this.PointToClient(Cursor.Position));
      if (flag1)
        return;
      if (!flag3)
        goto label_13;
      else
        goto label_9;
label_2:
      if ((uint) flag3 - (uint) flag3 >= 0U)
        return;
      goto label_4;
label_3:
      if (!this.x5fea292ffeb2c28c.ContainsFocus)
        goto label_10;
      else
        goto label_2;
label_4:
      while ((uint) flag1 + (uint) flag1 <= uint.MaxValue)
      {
        if ((uint) flag3 + (uint) flag3 <= uint.MaxValue)
        {
          if (true)
          {
            if ((uint) flag1 >= 0U)
              return;
            goto label_16;
          }
          else
            goto label_2;
        }
      }
      goto label_3;
label_9:
      if ((uint) flag3 + (uint) flag1 >= 0U)
        goto label_4;
label_10:
      this.xcdb145600c1b7224(false);
      return;
label_13:
      if (!this.x5fea292ffeb2c28c.x1c3de22188ea5bb2)
        goto label_3;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        goto label_6;
label_3:
      base.Dispose(disposing);
      return;
label_6:
      this.xcdb145600c1b7224(true);
      this.x537a4001020fd4c7.Tick -= new EventHandler(this.x79a58a5d2c65c5a4);
      this.x537a4001020fd4c7.Dispose();
      this.x537a4001020fd4c7 = (Timer) null;
      do
      {
        this.x2076b5c9f1eb82ef.Tick -= new EventHandler(this.xeccc53b32ba6b859);
        this.x2076b5c9f1eb82ef.Dispose();
        this.x2076b5c9f1eb82ef = (Timer) null;
        if (this.x5fea292ffeb2c28c != null)
          goto label_4;
      }
      while (false);
label_2:
      this.x7fdaeb05cb5e84f3.Clear();
      goto label_3;
label_4:
      this.x5fea292ffeb2c28c.Dispose();
      this.x5fea292ffeb2c28c = (TD.SandDock.x87cf4de36131799d) null;
      goto label_2;
    }

    public void xbb5f70c792fb9034(Rectangle xda73fcb97c77d998)
    {
      this.x5fea292ffeb2c28c.Invalidate(xda73fcb97c77d998);
    }

    internal class x01c0afa1afffb431 : CollectionBase
    {
      private x10ac79a4257c7f52 xb6a159a84cb992d6;

      public x01c0afa1afffb431(x10ac79a4257c7f52 parent)
      {
        this.xb6a159a84cb992d6 = parent;
      }

      public bool x263d579af1d0d43f(ControlLayoutSystem x6e150040c8d97700)
      {
        return this.List.Contains((object) x6e150040c8d97700);
      }

      protected override void OnInsertComplete(int index, object value)
      {
        ((ControlLayoutSystem) value).xa85d8c17921cc878(this.xb6a159a84cb992d6);
        this.xb6a159a84cb992d6.x7e9646eed248ed11();
      }

      protected override void OnRemoveComplete(int index, object value)
      {
        ((ControlLayoutSystem) value).xa85d8c17921cc878((x10ac79a4257c7f52) null);
        this.xb6a159a84cb992d6.x7e9646eed248ed11();
      }

      protected override void OnClearComplete()
      {
        this.xb6a159a84cb992d6.x7e9646eed248ed11();
      }

      protected override void OnClear()
      {
        foreach (ControlLayoutSystem controlLayoutSystem in (CollectionBase) this)
          controlLayoutSystem.xa85d8c17921cc878((x10ac79a4257c7f52) null);
      }

      public int xd6b6ed77479ef68c(ControlLayoutSystem x6e150040c8d97700)
      {
        return this.List.Add((object) x6e150040c8d97700);
      }

      public void x52b190e626f65140(ControlLayoutSystem x6e150040c8d97700)
      {
        this.List.Remove((object) x6e150040c8d97700);
      }

      public ControlLayoutSystem get_xe6d4b1b411ed94b5(int xc0c4c459c6ccbd00)
      {
        return (ControlLayoutSystem) this.List[xc0c4c459c6ccbd00];
      }
    }

    private delegate void x23dc61b48e59b2f1(bool quick);
  }
}
