// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x31248f32f85df1dd
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
  internal class x31248f32f85df1dd : xedb4922162c60d3d
  {
    private ControlLayoutSystem x5d62a4c2b1aa6ba9;
    private x31248f32f85df1dd.x23d0185c2770c169 xa0a376f49c1ad375;
    private bool x347de2b6e474668a;
    private bool x66992a14bbd05efe;
    private Rectangle x6f306c95372dd403;
    private Rectangle x8caac3836061e4ad;
    private ArrayList x71ba9145749e5eef;

    public x31248f32f85df1dd(
      SandDockManager manager,
      DockContainer container,
      LayoutSystemBase sourceControlSystem,
      DockControl sourceControl,
      int dockedSize,
      System.Drawing.Point startPoint,
      DockingHints dockingHints)
      : base(manager, container, sourceControlSystem, sourceControl, dockedSize, startPoint, dockingHints)
    {
      this.x71ba9145749e5eef = new ArrayList();
      if (this.x460ab163f44a604d == null || this.x460ab163f44a604d.DockSystemContainer == null)
        return;
      this.xcaa196e697d8d7c5();
    }

    private void xcaa196e697d8d7c5()
    {
      this.x6f306c95372dd403 = xedb4922162c60d3d.xc68a4bb946c59a9e(this.x460ab163f44a604d.DockSystemContainer.ClientRectangle, this.x460ab163f44a604d.DockSystemContainer);
label_44:
      this.x8caac3836061e4ad = xedb4922162c60d3d.xc68a4bb946c59a9e(xedb4922162c60d3d.x41c62f474d3fb367(this.x460ab163f44a604d.DockSystemContainer), this.x460ab163f44a604d.DockSystemContainer);
      bool flag1;
      do
      {
        if (this.xe302f2203dc14a18(ContainerDockLocation.Top))
          goto label_41;
        else
          goto label_38;
label_36:
        if (this.xe302f2203dc14a18(ContainerDockLocation.Left))
          goto label_35;
label_31:
        if (this.xe302f2203dc14a18(ContainerDockLocation.Bottom))
        {
          this.x71ba9145749e5eef.Add((object) new x31248f32f85df1dd.x23d0185c2770c169(this, this.x6f306c95372dd403, DockStyle.Bottom));
          if (true)
            goto label_34;
        }
        else
          goto label_34;
label_33:
        this.x71ba9145749e5eef.Add((object) new x31248f32f85df1dd.x23d0185c2770c169(this, this.x6f306c95372dd403, DockStyle.Right));
        if (((flag1 ? 1 : 0) | 2) != 0)
          break;
label_34:
        if (!this.xe302f2203dc14a18(ContainerDockLocation.Right))
          continue;
        goto label_33;
label_35:
        this.x71ba9145749e5eef.Add((object) new x31248f32f85df1dd.x23d0185c2770c169(this, this.x6f306c95372dd403, DockStyle.Left));
        goto label_31;
label_38:
        if (true)
        {
          if (false)
            goto label_20;
          else
            goto label_36;
        }
        else
          goto label_27;
label_41:
        this.x71ba9145749e5eef.Add((object) new x31248f32f85df1dd.x23d0185c2770c169(this, this.x6f306c95372dd403, DockStyle.Top));
        goto label_36;
      }
      while (false);
      goto label_28;
label_19:
      if (this.xe302f2203dc14a18(ContainerDockLocation.Right))
        goto label_21;
label_20:
      int num1;
      if (!this.xe302f2203dc14a18(ContainerDockLocation.Top))
      {
        num1 = this.xe302f2203dc14a18(ContainerDockLocation.Bottom) ? 1 : 0;
        goto label_22;
      }
label_21:
      num1 = 1;
label_22:
      bool flag2 = num1 != 0;
      bool flag3;
      int num2;
      if ((uint) flag2 + (uint) flag2 <= uint.MaxValue)
      {
        if (flag3)
          num2 = 0;
        else
          goto label_15;
      }
      else
        goto label_17;
label_14:
      flag1 = num2 != 0;
      if (flag1)
        goto label_25;
label_11:
      if (this.x460ab163f44a604d == null || this.x460ab163f44a604d.OwnerForm == null)
        return;
      IEnumerator enumerator = this.x71ba9145749e5eef.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
          this.x460ab163f44a604d.OwnerForm.AddOwnedForm((Form) enumerator.Current);
        return;
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        if ((uint) flag2 - (uint) flag1 <= uint.MaxValue && (uint) flag2 - (uint) flag3 <= uint.MaxValue)
          goto label_7;
label_6:
        disposable.Dispose();
        if (((flag2 ? 1 : 0) | int.MinValue) != 0 && (uint) flag1 - (uint) flag3 >= 0U)
          goto label_8;
label_7:
        if (disposable != null)
          goto label_6;
label_8:;
      }
label_25:
      if (((flag2 ? 1 : 0) & 0) == 0)
      {
        if ((uint) flag3 - (uint) flag2 >= 0U)
        {
          if ((uint) flag2 <= uint.MaxValue)
          {
            this.x71ba9145749e5eef.Add((object) new x31248f32f85df1dd.x23d0185c2770c169(this, this.x8caac3836061e4ad, DockStyle.Fill));
            goto label_11;
          }
          else
            goto label_23;
        }
        else
          goto label_44;
      }
      else
        goto label_28;
label_15:
      if (this.xe302f2203dc14a18(ContainerDockLocation.Center))
      {
        num2 = 1;
        goto label_14;
      }
      else
        goto label_18;
label_17:
      if ((uint) flag3 + (uint) flag1 >= 0U)
        goto label_15;
label_18:
      num2 = flag2 ? 1 : 0;
      goto label_14;
label_23:
      if ((uint) flag3 - (uint) flag2 >= 0U)
        goto label_21;
      else
        goto label_19;
label_27:
      if ((uint) flag2 + (uint) flag2 <= uint.MaxValue)
        goto label_29;
label_28:
      int num3;
      if (this.xc99dabdb533b119a.Dock == DockStyle.Fill)
      {
        num3 = !this.xc99dabdb533b119a.IsFloating ? 1 : 0;
        goto label_30;
      }
label_29:
      num3 = 0;
label_30:
      flag3 = num3 != 0;
      if (!this.xe302f2203dc14a18(ContainerDockLocation.Left))
        goto label_19;
      else
        goto label_23;
    }

    protected override xedb4922162c60d3d.DockTarget FindDockTarget(System.Drawing.Point position)
    {
      xedb4922162c60d3d.DockTarget x11d58b056c032b03 = (xedb4922162c60d3d.DockTarget) null;
      bool flag1 = this.x6f306c95372dd403.Contains(position);
      bool flag2 = this.x8caac3836061e4ad.Contains(position);
      if (flag1 != this.x347de2b6e474668a)
        goto label_59;
label_34:
      if (flag2 != this.x66992a14bbd05efe)
        goto label_59;
label_35:
      ControlLayoutSystem controlLayoutSystem = this.x674f2f3b17dc4197(position, out x11d58b056c032b03);
      int index1;
      if ((uint) flag1 + (uint) index1 > uint.MaxValue)
        goto label_40;
label_28:
      if (controlLayoutSystem != this.xf333586e50dccad2)
        goto label_30;
label_29:
      if (this.x59ae058c4a0dec87 == null)
        goto label_33;
label_30:
      int index2;
      while (controlLayoutSystem != this.x5d62a4c2b1aa6ba9)
      {
        if (true)
        {
          if ((uint) flag2 >= 0U)
          {
            if (this.xa0a376f49c1ad375 == null)
              goto label_23;
label_22:
            this.xa0a376f49c1ad375.x8ffe90e7fbccfccd();
            this.xa0a376f49c1ad375 = (x31248f32f85df1dd.x23d0185c2770c169) null;
            if (((flag2 ? 1 : 0) & 0) != 0)
              goto label_60;
label_23:
            this.x5d62a4c2b1aa6ba9 = controlLayoutSystem;
            if ((uint) index2 <= uint.MaxValue)
            {
              if (this.x5d62a4c2b1aa6ba9 != null)
              {
                this.xa0a376f49c1ad375 = new x31248f32f85df1dd.x23d0185c2770c169(this, this.x5d62a4c2b1aa6ba9);
                if (true)
                {
                  this.xa0a376f49c1ad375.x35579b297303ed43();
                  if (((flag2 ? 1 : 0) & 0) == 0)
                    break;
                }
                else if (false)
                {
                  if ((uint) index2 - (uint) flag2 >= 0U)
                    goto label_39;
                  else
                    goto label_28;
                }
                else
                  goto label_17;
              }
              else
                break;
            }
            else
              goto label_22;
          }
          else
            goto label_43;
        }
        else
          goto label_39;
      }
      goto label_16;
label_8:
      object[] array1 = this.x71ba9145749e5eef.ToArray();
      if (true)
        goto label_5;
      else
        goto label_11;
label_1:
      ++index2;
label_2:
      if (index2 < array1.Length)
      {
        x31248f32f85df1dd.x23d0185c2770c169 x23d0185c2770c169 = (x31248f32f85df1dd.x23d0185c2770c169) array1[index2];
        if (x11d58b056c032b03 == null && x23d0185c2770c169.x6ae4612a8469678e.Contains(position))
        {
          x11d58b056c032b03 = x23d0185c2770c169.x22749e65b5253094(position);
          if ((index1 | 2) != 0)
            goto label_11;
        }
        else
          goto label_1;
      }
      else
        goto label_60;
label_5:
      index2 = 0;
      goto label_2;
label_11:
      if (((flag2 ? 1 : 0) & 0) == 0)
      {
        if ((uint) flag2 >= 0U)
          goto label_1;
        else
          goto label_41;
      }
      else
        goto label_12;
label_10:
      if (this.xa0a376f49c1ad375 == null)
        goto label_8;
label_12:
      Rectangle x6ae4612a8469678e = this.xa0a376f49c1ad375.x6ae4612a8469678e;
      if ((uint) index2 - (uint) flag1 <= uint.MaxValue)
      {
        if ((uint) index2 + (uint) index2 > uint.MaxValue || x6ae4612a8469678e.Contains(position))
          goto label_9;
label_6:
        if ((uint) index1 + (uint) index2 >= 0U)
          goto label_8;
label_9:
        if (x11d58b056c032b03 != null)
        {
          if (false)
            goto label_6;
          else
            goto label_8;
        }
        else
        {
          x11d58b056c032b03 = this.xa0a376f49c1ad375.x22749e65b5253094(position);
          goto label_8;
        }
      }
      else
        goto label_36;
label_16:
      if (x11d58b056c032b03 == null)
        goto label_10;
label_17:
      if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.Undefined)
      {
        x11d58b056c032b03 = (xedb4922162c60d3d.DockTarget) null;
        goto label_10;
      }
      else if ((uint) index2 + (uint) flag2 > uint.MaxValue)
      {
        if ((index2 & 0) == 0)
          goto label_12;
        else
          goto label_41;
      }
      else
        goto label_10;
label_60:
      return x11d58b056c032b03;
label_33:
      controlLayoutSystem = (ControlLayoutSystem) null;
      if ((uint) index1 >= 0U)
        goto label_30;
      else
        goto label_39;
label_40:
      if ((uint) index1 + (uint) index2 >= 0U)
      {
        if (true)
          goto label_29;
        else
          goto label_33;
      }
      else
        goto label_30;
label_36:
      ++index1;
label_37:
      object[] array2;
      x31248f32f85df1dd.x23d0185c2770c169 x23d0185c2770c169_1;
      if (index1 >= array2.Length)
      {
        this.x347de2b6e474668a = flag1;
        this.x66992a14bbd05efe = flag2;
        if ((uint) flag1 <= uint.MaxValue)
          goto label_35;
      }
      else
      {
        x23d0185c2770c169_1 = (x31248f32f85df1dd.x23d0185c2770c169) array2[index1];
label_49:
        while (x23d0185c2770c169_1.xa9803b9efaf4da87 == DockStyle.Fill)
        {
          if ((uint) flag1 - (uint) flag1 >= 0U)
          {
            while (flag2 != this.x66992a14bbd05efe)
            {
              if (flag2)
                goto label_58;
label_54:
              x23d0185c2770c169_1.x5486e0b5e830d25c();
              goto label_36;
label_58:
              x23d0185c2770c169_1.x35579b297303ed43();
              if ((uint) index1 - (uint) index1 >= 0U)
              {
                if ((uint) flag1 > uint.MaxValue)
                {
                  if ((index2 & 0) == 0)
                  {
                    if ((uint) flag2 - (uint) flag1 < 0U)
                      goto label_34;
                  }
                  else
                    goto label_49;
                }
                else
                  goto label_36;
              }
              else
                goto label_54;
            }
            break;
          }
          if (((flag1 ? 1 : 0) | int.MinValue) != 0)
          {
            if (true)
              goto label_44;
            else
              goto label_43;
          }
          else
            break;
        }
        goto label_41;
      }
label_39:
      if (flag1 != this.x347de2b6e474668a)
        goto label_43;
      else
        goto label_36;
label_41:
      if (x23d0185c2770c169_1.xa9803b9efaf4da87 != DockStyle.Fill || (index1 | -1) == 0)
        goto label_39;
      else
        goto label_36;
label_43:
      if (flag1)
      {
        x23d0185c2770c169_1.x35579b297303ed43();
        goto label_36;
      }
label_44:
      x23d0185c2770c169_1.x5486e0b5e830d25c();
      if ((uint) flag1 - (uint) flag2 > uint.MaxValue)
        goto label_36;
      else
        goto label_36;
label_59:
      array2 = this.x71ba9145749e5eef.ToArray();
      index1 = 0;
      goto label_37;
    }

    private ControlLayoutSystem x674f2f3b17dc4197(
      System.Drawing.Point x13d4cb8d1bd20347,
      out xedb4922162c60d3d.DockTarget x11d58b056c032b03)
    {
      x11d58b056c032b03 = (xedb4922162c60d3d.DockTarget) null;
      int num;
      do
      {
        num = 1;
      }
      while (false);
      for (; num >= 0; --num)
      {
        bool boolean = Convert.ToBoolean(num);
        ControlLayoutSystem[] xcdb018cc067a38ae = this.xcdb018cc067a38ae;
        int index = 0;
label_3:
        if (index < xcdb018cc067a38ae.Length)
        {
          ControlLayoutSystem x6e150040c8d97700 = xcdb018cc067a38ae[index];
          if (((boolean ? 1 : 0) & 0) == 0)
          {
            do
            {
              if (x6e150040c8d97700.DockContainer.IsFloating == boolean)
                goto label_9;
label_2:
              ++index;
              continue;
label_9:
              if ((uint) index - (uint) num <= uint.MaxValue)
              {
                if (!new Rectangle(x6e150040c8d97700.DockContainer.PointToScreen(x6e150040c8d97700.Bounds.Location), x6e150040c8d97700.Bounds.Size).Contains(x13d4cb8d1bd20347))
                  goto label_2;
                else
                  goto label_11;
              }
              else
                goto label_6;
            }
            while ((uint) index < 0U);
            goto label_3;
label_6:
            return x6e150040c8d97700;
label_11:
            x11d58b056c032b03 = this.xede53ab1a4b2e20b(x6e150040c8d97700.DockContainer, x6e150040c8d97700, x13d4cb8d1bd20347, false);
            if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.Undefined)
              return (ControlLayoutSystem) null;
            goto label_6;
          }
          else
            break;
        }
      }
      return (ControlLayoutSystem) null;
    }

    public override void Dispose()
    {
      if (this.xa0a376f49c1ad375 != null)
      {
        this.xa0a376f49c1ad375.x8ffe90e7fbccfccd();
        this.xa0a376f49c1ad375 = (x31248f32f85df1dd.x23d0185c2770c169) null;
      }
      foreach (x31248f32f85df1dd.x23d0185c2770c169 x23d0185c2770c169 in this.x71ba9145749e5eef)
        x23d0185c2770c169.x8ffe90e7fbccfccd();
      this.x71ba9145749e5eef.Clear();
      if (false)
        return;
      base.Dispose();
    }

    private class x23d0185c2770c169 : xd0a1f65420a07725
    {
      private Rectangle xda73fcb97c77d998 = Rectangle.Empty;
      private DockSide xf33779c598cac695 = DockSide.None;
      private const int xca96dc7024c32126 = 88;
      private const int xc82cb74794544a35 = 88;
      private const int x6b0037d5c155e862 = 200;
      private const int x77bf04ec211c4a37 = 16;
      private const int x339acab5bf3e83ae = 64;
      private x31248f32f85df1dd x91f347c6e97f1846;
      private ControlLayoutSystem x6e150040c8d97700;
      private bool x3321191c6256921e;
      private Bitmap xaf410773a496d7d0;
      private bool x3b280f462145bf12;
      private Timer x1700d731d6397130;
      private int x1a5b1715d3a0d7a6;
      private bool x9063896ecf738664;
      private DockStyle xca9af438b5818619;

      [DllImport("user32.dll")]
      private static extern bool SetWindowPos(
        HandleRef hWnd,
        int hWndInsertAfter,
        int x,
        int y,
        int cx,
        int cy,
        int flags);

      private x23d0185c2770c169()
      {
        do
        {
          this.FormBorderStyle = FormBorderStyle.None;
          this.ShowInTaskbar = false;
          this.StartPosition = FormStartPosition.Manual;
          this.x1700d731d6397130 = new Timer();
          do
          {
            this.x1700d731d6397130.Interval = 50;
          }
          while (false);
          this.x1700d731d6397130.Tick += new EventHandler(this.xa1ebc192abdef013);
          this.xaf410773a496d7d0 = new Bitmap(88, 88, PixelFormat.Format32bppArgb);
        }
        while (false);
      }

      public x23d0185c2770c169(x31248f32f85df1dd manager, Rectangle fc, DockStyle dockStyle)
        : this()
      {
        this.x91f347c6e97f1846 = manager;
        if (false)
          goto label_4;
        else
          goto label_8;
label_2:
        this.x912beb3fd0dd9feb();
        return;
label_4:
        this.xda73fcb97c77d998 = new Rectangle(fc.X + fc.Width / 2 - 44, fc.Bottom - 88 - 15, 88, 88);
        if (false)
          return;
        goto label_2;
label_8:
        this.xca9af438b5818619 = dockStyle;
        switch (dockStyle)
        {
          case DockStyle.Top:
            this.xda73fcb97c77d998 = new Rectangle(fc.X + fc.Width / 2 - 44, fc.Y + 15, 88, 88);
            goto label_2;
          case DockStyle.Bottom:
            goto label_4;
          case DockStyle.Left:
            this.xda73fcb97c77d998 = new Rectangle(fc.X + 15, fc.Y + fc.Height / 2 - 44, 88, 88);
            goto label_2;
          case DockStyle.Right:
            this.xda73fcb97c77d998 = new Rectangle(fc.Right - 88 - 15, fc.Y + fc.Height / 2 - 44, 88, 88);
            goto label_2;
          case DockStyle.Fill:
            this.xda73fcb97c77d998 = new Rectangle(fc.X + fc.Width / 2 - 44, fc.Y + fc.Height / 2 - 44, 88, 88);
            goto label_2;
          default:
            goto label_2;
        }
      }

      public x23d0185c2770c169(x31248f32f85df1dd manager, ControlLayoutSystem layoutSystem)
        : this()
      {
        do
        {
          this.x91f347c6e97f1846 = manager;
          this.x6e150040c8d97700 = layoutSystem;
        }
        while (false);
        this.xda73fcb97c77d998 = new Rectangle(layoutSystem.DockContainer.PointToScreen(layoutSystem.Bounds.Location), layoutSystem.Bounds.Size);
        this.xda73fcb97c77d998 = new Rectangle(this.xda73fcb97c77d998.X + this.xda73fcb97c77d998.Width / 2 - 44, this.xda73fcb97c77d998.Y + this.xda73fcb97c77d998.Height / 2 - 44, 88, 88);
        this.x912beb3fd0dd9feb();
      }

      public DockStyle xa9803b9efaf4da87
      {
        get
        {
          return this.xca9af438b5818619;
        }
      }

      private void x912beb3fd0dd9feb()
      {
        using (Graphics x41347a961b838962 = Graphics.FromImage((Image) this.xaf410773a496d7d0))
        {
          xa811784015ed8842.x91433b5e99eb7cac(x41347a961b838962, Color.Transparent);
          if (this.xca9af438b5818619 == DockStyle.None)
            goto label_56;
          else
            goto label_61;
label_32:
          Color highlight = SystemColors.Highlight;
          Color transparent = Color.Transparent;
          if (this.xca9af438b5818619 != DockStyle.None)
            goto label_29;
          else
            goto label_30;
label_27:
          do
          {
            if (this.xca9af438b5818619 == DockStyle.None || this.xca9af438b5818619 == DockStyle.Fill)
              goto label_25;
            else
              goto label_28;
label_20:
            if (this.xca9af438b5818619 != DockStyle.None)
            {
              if (this.xca9af438b5818619 != DockStyle.Fill)
              {
                if (false)
                {
                  if (true)
                    continue;
                }
                else
                  goto label_14;
              }
              else
                goto label_19;
            }
            else
              goto label_18;
label_24:
            if (this.xca9af438b5818619 != DockStyle.Right)
              goto label_20;
label_25:
            this.xa1ff3514b97ff955(x41347a961b838962, !this.x3321191c6256921e || this.xf33779c598cac695 != DockSide.Right ? transparent : highlight);
            goto label_20;
label_28:
            if (true)
              goto label_24;
            else
              break;
          }
          while (false);
          goto label_63;
label_14:
          if (this.xca9af438b5818619 == DockStyle.Bottom)
            goto label_19;
label_15:
          if (this.xca9af438b5818619 == DockStyle.None)
            goto label_13;
          else
            goto label_16;
label_2:
          if (this.xca9af438b5818619 == DockStyle.None)
            goto label_5;
label_3:
          if (this.xca9af438b5818619 == DockStyle.Fill)
          {
            if (false)
              goto label_2;
          }
          else if (true)
            goto label_67;
          else
            goto label_19;
label_5:
          this.x6e8df868b7130012(x41347a961b838962, !this.x3321191c6256921e || this.xf33779c598cac695 != DockSide.None ? transparent : highlight);
          if (true)
          {
            if (false)
              goto label_12;
            else
              goto label_67;
          }
          else
            goto label_40;
label_9:
          if (this.xca9af438b5818619 == DockStyle.Fill)
            goto label_13;
label_10:
          if (this.xca9af438b5818619 != DockStyle.Left)
          {
            if (false)
              goto label_29;
            else
              goto label_2;
          }
label_12:
          if (false)
            goto label_9;
label_13:
          this.x46d7024135bf7082(x41347a961b838962, !this.x3321191c6256921e || this.xf33779c598cac695 != DockSide.Left ? transparent : highlight);
          if (true)
          {
            if (true)
              goto label_2;
            else
              goto label_3;
          }
          else
            goto label_10;
label_16:
          if (true)
          {
            if (true)
              goto label_9;
            else
              goto label_10;
          }
          else
            goto label_45;
label_18:
          if (false)
            goto label_55;
label_19:
          this.x9ceea7a4567f6a5f(x41347a961b838962, !this.x3321191c6256921e || this.xf33779c598cac695 != DockSide.Bottom ? transparent : highlight);
          if (true)
            goto label_15;
          else
            goto label_14;
label_63:
          if (true)
            goto label_19;
          else
            goto label_67;
label_29:
          if (this.xca9af438b5818619 != DockStyle.Fill && this.xca9af438b5818619 != DockStyle.Top)
            goto label_27;
label_30:
          this.xd349d1e0601e763e(x41347a961b838962, !this.x3321191c6256921e || this.xf33779c598cac695 != DockSide.Top ? transparent : highlight);
          if (true)
            goto label_27;
          else
            goto label_27;
label_40:
          using (Image image = Image.FromStream(typeof (x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghintleft.png")))
          {
            x41347a961b838962.DrawImageUnscaled(image, 0, 29);
            goto label_32;
          }
label_45:
          using (Image image = Image.FromStream(typeof (x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghintbottom.png")))
          {
            x41347a961b838962.DrawImageUnscaled(image, 29, 57);
            goto label_32;
          }
label_55:
          if (this.xca9af438b5818619 != DockStyle.Top)
          {
            if (this.xca9af438b5818619 != DockStyle.Bottom)
            {
              if (this.xca9af438b5818619 != DockStyle.Left)
              {
                if (this.xca9af438b5818619 == DockStyle.Right)
                {
                  using (Image image = Image.FromStream(typeof (x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghintright.png")))
                  {
                    x41347a961b838962.DrawImageUnscaled(image, 57, 29);
                    goto label_32;
                  }
                }
                else
                  goto label_32;
              }
              else
                goto label_40;
            }
            else
              goto label_45;
          }
          else
          {
            using (Image image = Image.FromStream(typeof (x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghinttop.png")))
            {
              x41347a961b838962.DrawImageUnscaled(image, 29, 0);
              goto label_32;
            }
          }
label_56:
          using (Image image = Image.FromStream(typeof (x31248f32f85df1dd.x23d0185c2770c169).Assembly.GetManifestResourceStream("TD.SandDock.Resources.dockinghintcenter.png")))
          {
            x41347a961b838962.DrawImageUnscaled(image, 0, 0);
            goto label_32;
          }
label_61:
          if (this.xca9af438b5818619 == DockStyle.Fill)
          {
            if (true)
              goto label_56;
            else
              goto label_32;
          }
          else
            goto label_55;
        }
label_67:
        this.x0ecee64b07d2d5b1(this.xaf410773a496d7d0, byte.MaxValue);
      }

      protected override void Dispose(bool disposing)
      {
        if (disposing)
        {
          this.xaf410773a496d7d0.Dispose();
          this.x1700d731d6397130.Tick -= new EventHandler(this.xa1ebc192abdef013);
          this.x1700d731d6397130.Dispose();
        }
        base.Dispose(disposing);
      }

      private xedb4922162c60d3d.DockTarget xd9d182c023a01aa8(
        System.Drawing.Point x6b2bb9f943411698)
      {
        xedb4922162c60d3d.DockTarget dockTarget = (xedb4922162c60d3d.DockTarget) null;
        if (true)
          goto label_21;
label_1:
        dockTarget.bounds = this.x91f347c6e97f1846.x3102817291e84207(this.x6e150040c8d97700.DockContainer, this.x6e150040c8d97700, dockTarget.dockSide);
        if (true)
        {
          if (true)
            goto label_25;
          else
            goto label_16;
        }
        else
          goto label_5;
label_2:
        if (this.x2e982e5b420711bf(this.xa449c67cf6031591, x6b2bb9f943411698))
        {
          dockTarget.type = xedb4922162c60d3d.DockTargetType.JoinExistingSystem;
          dockTarget.dockSide = DockSide.None;
          goto label_1;
        }
        else
        {
          dockTarget.type = xedb4922162c60d3d.DockTargetType.Undefined;
          goto label_1;
        }
label_5:
        if (false)
          goto label_10;
label_6:
        if (true)
          goto label_2;
label_7:
        if (false)
          goto label_5;
        else
          goto label_2;
label_10:
        if (this.x2e982e5b420711bf(this.xd163ca0298f48d0e, x6b2bb9f943411698))
        {
          dockTarget.dockSide = DockSide.Left;
          goto label_1;
        }
        else if (true)
          goto label_7;
        else
          goto label_17;
label_16:
        dockTarget.dockSide = DockSide.Right;
        if (false)
          goto label_21;
        else
          goto label_1;
label_17:
        if (true)
          goto label_5;
        else
          goto label_25;
label_21:
        while (true)
        {
          dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.SplitExistingSystem);
          if (true)
          {
            dockTarget.layoutSystem = this.x6e150040c8d97700;
            if (true)
            {
              if (true)
              {
                dockTarget.dockContainer = this.x6e150040c8d97700.DockContainer;
                if (!this.x2e982e5b420711bf(this.x922c86dd03ed0805, x6b2bb9f943411698))
                {
                  if (!this.x2e982e5b420711bf(this.x71b3d93f18a3424c, x6b2bb9f943411698))
                  {
                    if (!this.x2e982e5b420711bf(this.xaf8b7fb67e0c3bcb, x6b2bb9f943411698))
                    {
                      if (true)
                        goto label_10;
                      else
                        goto label_17;
                    }
                    else
                      break;
                  }
                  else
                    goto label_16;
                }
                else
                {
                  dockTarget.dockSide = DockSide.Top;
                  if (false)
                    goto label_6;
                  else
                    goto label_1;
                }
              }
            }
            else if (true)
              goto label_16;
            else
              goto label_25;
          }
          else
            goto label_16;
        }
        dockTarget.dockSide = DockSide.Bottom;
        goto label_1;
label_25:
        return dockTarget;
      }

      private xedb4922162c60d3d.DockTarget x54f27420b41557c2(
        System.Drawing.Point x6b2bb9f943411698)
      {
label_42:
        xedb4922162c60d3d.DockTarget dockTarget = new xedb4922162c60d3d.DockTarget(xedb4922162c60d3d.DockTargetType.SplitExistingSystem);
        dockTarget.layoutSystem = this.x6e150040c8d97700;
        dockTarget.dockContainer = this.x6e150040c8d97700 != null ? this.x6e150040c8d97700.DockContainer : (DockContainer) null;
        if (!this.x2e982e5b420711bf(this.x922c86dd03ed0805, x6b2bb9f943411698))
          goto label_32;
        else
          goto label_35;
label_1:
        dockTarget.middle = this.xca9af438b5818619 == DockStyle.Fill;
        dockTarget.bounds = xedb4922162c60d3d.xc68a4bb946c59a9e(this.x91f347c6e97f1846.x257d5a0e25592705(dockTarget.dockLocation, this.x91f347c6e97f1846.xf8ec28822747d4db, dockTarget.middle), this.x91f347c6e97f1846.x460ab163f44a604d.DockSystemContainer);
        if (true)
          goto label_43;
        else
          goto label_10;
label_2:
        if (dockTarget.type != xedb4922162c60d3d.DockTargetType.Undefined)
        {
          if (true)
          {
            dockTarget.type = xedb4922162c60d3d.DockTargetType.CreateNewContainer;
            goto label_1;
          }
        }
        else
          goto label_43;
label_6:
        if (!this.x2e982e5b420711bf(this.xa449c67cf6031591, x6b2bb9f943411698) || !this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Center) || this.xca9af438b5818619 != DockStyle.Fill)
        {
          do
          {
            dockTarget.type = xedb4922162c60d3d.DockTargetType.Undefined;
          }
          while (false);
          goto label_2;
        }
        else
        {
          dockTarget.dockLocation = ContainerDockLocation.Center;
          dockTarget.dockSide = DockSide.None;
          if (true)
          {
            if (true)
            {
              if (true)
                goto label_2;
              else
                goto label_1;
            }
            else
              goto label_29;
          }
          else
            goto label_28;
        }
label_10:
        if (this.xca9af438b5818619 == DockStyle.Fill)
        {
          if (false)
            goto label_16;
          else
            goto label_18;
        }
        else
          goto label_13;
label_11:
        if (true)
        {
          if (true)
            goto label_6;
        }
        else
          goto label_10;
label_13:
        if (false)
          goto label_11;
        else
          goto label_6;
label_16:
        if (this.xca9af438b5818619 != DockStyle.Left)
          goto label_10;
label_18:
        dockTarget.dockLocation = ContainerDockLocation.Left;
        if (false)
        {
          if (false)
          {
            if (true)
              goto label_10;
            else
              goto label_2;
          }
          else
            goto label_11;
        }
        else
        {
          dockTarget.dockSide = DockSide.Left;
          goto label_2;
        }
label_22:
        if (!this.x2e982e5b420711bf(this.xaf8b7fb67e0c3bcb, x6b2bb9f943411698))
          goto label_21;
        else
          goto label_23;
label_19:
        if (false)
          goto label_2;
        else
          goto label_16;
label_21:
        if (!this.x2e982e5b420711bf(this.xd163ca0298f48d0e, x6b2bb9f943411698) || !this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Left))
          goto label_6;
        else
          goto label_19;
label_23:
        if (!this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Bottom))
        {
          if (true)
            goto label_21;
          else
            goto label_19;
        }
        else
        {
          if (this.xca9af438b5818619 != DockStyle.Bottom)
            goto label_39;
label_27:
          dockTarget.dockLocation = ContainerDockLocation.Bottom;
          goto label_28;
label_39:
          if (true)
          {
            if (true)
            {
              if (this.xca9af438b5818619 != DockStyle.Fill)
                goto label_21;
              else
                goto label_27;
            }
            else
              goto label_18;
          }
          else
            goto label_42;
        }
label_28:
        dockTarget.dockSide = DockSide.Bottom;
        goto label_2;
label_29:
        if (this.xca9af438b5818619 == DockStyle.Fill)
          goto label_34;
        else
          goto label_22;
label_31:
        if (this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Right))
          goto label_33;
        else
          goto label_22;
label_32:
        if (this.x2e982e5b420711bf(this.x71b3d93f18a3424c, x6b2bb9f943411698))
          goto label_31;
        else
          goto label_22;
label_33:
        if (this.xca9af438b5818619 != DockStyle.Right)
          goto label_29;
label_34:
        dockTarget.dockLocation = ContainerDockLocation.Right;
        dockTarget.dockSide = DockSide.Right;
        if (false)
          goto label_22;
        else
          goto label_2;
label_35:
        if (!this.x91f347c6e97f1846.xe302f2203dc14a18(ContainerDockLocation.Top))
        {
          if (false)
          {
            if (false)
            {
              if (false)
                goto label_2;
              else
                goto label_33;
            }
            else
              goto label_31;
          }
          else
            goto label_32;
        }
        else if (this.xca9af438b5818619 == DockStyle.Top || this.xca9af438b5818619 == DockStyle.Fill)
        {
          dockTarget.dockLocation = ContainerDockLocation.Top;
          dockTarget.dockSide = DockSide.Top;
          goto label_2;
        }
        else
          goto label_32;
label_43:
        return dockTarget;
      }

      public xedb4922162c60d3d.DockTarget x22749e65b5253094(System.Drawing.Point x13d4cb8d1bd20347)
      {
        System.Drawing.Point client = this.PointToClient(x13d4cb8d1bd20347);
label_19:
        xedb4922162c60d3d.DockTarget dockTarget = this.x6e150040c8d97700 != null ? this.xd9d182c023a01aa8(client) : this.x54f27420b41557c2(client);
        bool flag = dockTarget.type != xedb4922162c60d3d.DockTargetType.Undefined;
        int num;
        if (dockTarget.type == xedb4922162c60d3d.DockTargetType.Undefined)
          num = (int) this.xf33779c598cac695;
        else
          goto label_20;
label_18:
        DockSide dockSide = (DockSide) num;
        goto label_21;
label_20:
        if ((uint) flag - (uint) flag >= 0U)
        {
          num = (int) dockTarget.dockSide;
          goto label_18;
        }
label_21:
        if ((uint) flag + (uint) flag <= uint.MaxValue)
          goto label_14;
label_1:
        if (false)
          goto label_10;
        else
          goto label_22;
label_3:
        if ((uint) flag - (uint) flag >= 0U)
        {
          if ((uint) flag <= uint.MaxValue)
          {
            if (true)
              goto label_1;
            else
              goto label_19;
          }
          else
            goto label_10;
        }
        else
          goto label_8;
label_5:
        if (dockSide == this.xf33779c598cac695)
        {
          if (false)
          {
            if (false)
              goto label_11;
          }
          else
            goto label_3;
        }
        else
          goto label_10;
label_8:
        while (true)
        {
          if (((flag ? 1 : 0) & 0) == 0)
          {
            if (false)
              goto label_3;
            else
              goto label_22;
          }
        }
        goto label_5;
label_10:
        this.x3321191c6256921e = flag;
label_11:
        this.xf33779c598cac695 = dockSide;
        this.x912beb3fd0dd9feb();
        goto label_8;
label_14:
        if ((uint) flag >= 0U)
        {
          if (flag != this.x3321191c6256921e)
            goto label_10;
          else
            goto label_5;
        }
        else if (((flag ? 1 : 0) | 15) != 0)
          goto label_5;
        else
          goto label_10;
label_22:
        return dockTarget;
      }

      private bool x2e982e5b420711bf(Rectangle xe125219852864557, System.Drawing.Point x13d4cb8d1bd20347)
      {
        return xe125219852864557.Contains(x13d4cb8d1bd20347);
      }

      private Rectangle xa449c67cf6031591
      {
        get
        {
          return new Rectangle(28, 28, 32, 32);
        }
      }

      private Rectangle x922c86dd03ed0805
      {
        get
        {
          return new Rectangle(29, 0, 29, 28);
        }
      }

      private Rectangle x71b3d93f18a3424c
      {
        get
        {
          return new Rectangle(60, 29, 28, 29);
        }
      }

      private Rectangle xaf8b7fb67e0c3bcb
      {
        get
        {
          return new Rectangle(29, 60, 29, 28);
        }
      }

      private Rectangle xd163ca0298f48d0e
      {
        get
        {
          return new Rectangle(0, 29, 28, 29);
        }
      }

      public Rectangle x6ae4612a8469678e
      {
        get
        {
          return this.xda73fcb97c77d998;
        }
      }

      private void x6e8df868b7130012(Graphics x41347a961b838962, Color x3c4da2980d043c95)
      {
        using (Pen pen = new Pen(x3c4da2980d043c95))
        {
          x41347a961b838962.DrawLine(pen, 22, 29, 29, 22);
          x41347a961b838962.DrawLine(pen, 57, 22, 64, 29);
          x41347a961b838962.DrawLine(pen, 64, 57, 57, 64);
          x41347a961b838962.DrawLine(pen, 29, 64, 22, 57);
        }
      }

      private void x46d7024135bf7082(Graphics x41347a961b838962, Color x3c4da2980d043c95)
      {
        using (Pen pen = new Pen(x3c4da2980d043c95))
        {
          x41347a961b838962.DrawLine(pen, 0, 29, 0, 57);
          x41347a961b838962.DrawLine(pen, 0, 57, 23, 57);
          x41347a961b838962.DrawLine(pen, 0, 29, 23, 29);
        }
      }

      private void x9ceea7a4567f6a5f(Graphics x41347a961b838962, Color x3c4da2980d043c95)
      {
        using (Pen pen = new Pen(x3c4da2980d043c95))
        {
          x41347a961b838962.DrawLine(pen, 29, 87, 57, 87);
          x41347a961b838962.DrawLine(pen, 29, 87, 29, 64);
          x41347a961b838962.DrawLine(pen, 57, 87, 57, 64);
        }
      }

      private void xa1ff3514b97ff955(Graphics x41347a961b838962, Color x3c4da2980d043c95)
      {
        using (Pen pen = new Pen(x3c4da2980d043c95))
        {
          x41347a961b838962.DrawLine(pen, 87, 29, 87, 57);
          x41347a961b838962.DrawLine(pen, 87, 29, 64, 29);
          x41347a961b838962.DrawLine(pen, 87, 57, 64, 57);
        }
      }

      private void xd349d1e0601e763e(Graphics x41347a961b838962, Color x3c4da2980d043c95)
      {
        using (Pen pen = new Pen(x3c4da2980d043c95))
        {
          x41347a961b838962.DrawLine(pen, 29, 0, 57, 0);
          x41347a961b838962.DrawLine(pen, 57, 0, 57, 23);
          x41347a961b838962.DrawLine(pen, 29, 0, 29, 23);
        }
      }

      public void x8ffe90e7fbccfccd()
      {
        this.x9063896ecf738664 = true;
        this.x5486e0b5e830d25c();
      }

      public void x5486e0b5e830d25c()
      {
        if (!this.Visible)
        {
          if (true)
          {
            if (this.x3b280f462145bf12 || !this.x1700d731d6397130.Enabled)
              return;
          }
          else
            goto label_4;
        }
        this.x1a5b1715d3a0d7a6 = Environment.TickCount;
label_4:
        this.x3b280f462145bf12 = true;
        this.x1700d731d6397130.Start();
      }

      public void x35579b297303ed43()
      {
        this.x0ecee64b07d2d5b1(this.xaf410773a496d7d0, (byte) 0);
        this.x2c6f5ac62ee048e5();
        this.x1a5b1715d3a0d7a6 = Environment.TickCount;
        this.x3b280f462145bf12 = false;
        this.x1700d731d6397130.Start();
      }

      public void x2c6f5ac62ee048e5()
      {
        x31248f32f85df1dd.x23d0185c2770c169.SetWindowPos(new HandleRef((object) this, this.Handle), -1, this.xda73fcb97c77d998.X, this.xda73fcb97c77d998.Y, this.xda73fcb97c77d998.Width, this.xda73fcb97c77d998.Height, 80);
      }

      private void xa1ebc192abdef013(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
      {
        int num1 = Environment.TickCount - this.x1a5b1715d3a0d7a6;
        double num2;
        if ((uint) num2 - (uint) num1 > uint.MaxValue)
        {
          if ((uint) num2 - (uint) num2 <= uint.MaxValue)
            goto label_10;
          else
            goto label_8;
        }
        else
          goto label_16;
label_3:
        double num3;
        if ((uint) num3 <= uint.MaxValue)
          return;
label_4:
        if (num1 < 200)
          return;
        this.x1700d731d6397130.Stop();
        this.Visible = !this.x3b280f462145bf12;
        if (this.x9063896ecf738664)
        {
          this.Dispose();
          goto label_3;
        }
        else if (true)
        {
          if (((int) (uint) num3 & 0) == 0)
            return;
          goto label_16;
        }
        else
          goto label_10;
label_8:
        this.x0ecee64b07d2d5b1(this.xaf410773a496d7d0, (byte) num3);
        goto label_4;
label_10:
        num3 = (1.0 - num3) * (double) byte.MaxValue;
        goto label_8;
label_16:
        do
        {
          if (num1 > 200)
            goto label_17;
label_13:
          num3 = (double) num1 / 200.0;
          continue;
label_17:
          num1 = 200;
          if ((uint) num1 - (uint) num3 < 0U)
            goto label_4;
          else
            goto label_13;
        }
        while (false);
        if (((int) (uint) num3 | 3) != 0)
        {
          if (!this.x3b280f462145bf12)
          {
            num3 *= (double) byte.MaxValue;
            goto label_8;
          }
          else
            goto label_10;
        }
        else
          goto label_3;
      }
    }
  }
}
