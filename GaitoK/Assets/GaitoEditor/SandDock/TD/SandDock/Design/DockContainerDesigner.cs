// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Design.DockContainerDesigner
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TD.SandDock.Design
{
  internal class DockContainerDesigner : ParentControlDesigner
  {
    private System.Drawing.Point x6afebf16b45c02e0 = System.Drawing.Point.Empty;
    private DockContainer x0467b00af7810f0c;
    private DockControl xaaafffc15ba630b7;
    private xedb4922162c60d3d x531514c39973cbc6;
    private x8e80e1c8bce8caf7 x372569d2ea29984e;
    private x09c1c18390e52ebf x754f1c6f433be75d;
    private IComponentChangeService x4cd3df9bd5e139a3;
    private IDesignerHost xff9c60b45aa37b1e;

    public DockContainerDesigner()
    {
      this.EnableDragDrop(false);
    }

    private DockControl x37c93a224e23ba95(System.Drawing.Point x13d4cb8d1bd20347)
    {
      LayoutSystemBase layoutSystemAt = this.x0467b00af7810f0c.GetLayoutSystemAt(x13d4cb8d1bd20347);
      if (layoutSystemAt is ControlLayoutSystem)
        return ((ControlLayoutSystem) layoutSystemAt).GetControlAt(x13d4cb8d1bd20347);
      return (DockControl) null;
    }

    [Browsable(false)]
    [DefaultValue(false)]
    protected override bool DrawGrid
    {
      get
      {
        return false;
      }
      set
      {
        base.DrawGrid = value;
      }
    }

    protected override void OnMouseDragBegin(int x, int y)
    {
      ISelectionService service1 = (ISelectionService) this.GetService(typeof (ISelectionService));
      if ((uint) y - (uint) x > uint.MaxValue)
        goto label_24;
      else
        goto label_37;
label_18:
      DockControl controlAt;
      while (controlAt == null)
      {
        if ((uint) x <= uint.MaxValue)
          goto label_14;
      }
      goto label_17;
label_11:
      if (false)
        goto label_14;
label_13:
      ControlLayoutSystem controlLayoutSystem;
      System.Drawing.Point client;
      if (!controlLayoutSystem.xb48529af1739dd06.Contains(client))
        goto label_12;
      else
        goto label_15;
label_7:
      if (controlLayoutSystem.SelectedControl != null)
      {
        service1.SetSelectedComponents((ICollection) new object[1]
        {
          (object) controlLayoutSystem.SelectedControl
        }, SelectionTypes.Click);
        if ((uint) y > uint.MaxValue)
          goto label_31;
      }
      this.x6afebf16b45c02e0 = new System.Drawing.Point(x, y);
      if ((uint) y + (uint) y > uint.MaxValue)
      {
        if (true)
          goto label_14;
        else
          goto label_11;
      }
      else
        goto label_16;
label_12:
      if (controlAt == null)
      {
        service1.SetSelectedComponents((ICollection) new object[1]
        {
          (object) this.x0467b00af7810f0c
        }, SelectionTypes.MouseDown | SelectionTypes.Click);
        this.x0467b00af7810f0c.Capture = true;
        return;
      }
      goto label_7;
label_15:
      if ((uint) x + (uint) y >= 0U)
        goto label_7;
label_16:
      if ((x & 0) == 0)
      {
        if (false)
          return;
        if ((x | 1) != 0)
        {
          if (true)
            ;
          return;
        }
        goto label_7;
      }
      else
        goto label_18;
label_14:
      if (true)
        goto label_13;
label_17:
      if (controlAt.LayoutSystem.SelectedControl != controlAt)
      {
        IComponentChangeService service2 = (IComponentChangeService) this.GetService(typeof (IComponentChangeService));
        if (true)
        {
          service2.OnComponentChanging((object) this.x0467b00af7810f0c, (MemberDescriptor) TypeDescriptor.GetProperties((object) this.x0467b00af7810f0c)["LayoutSystem"]);
          controlAt.LayoutSystem.SelectedControl = controlAt;
          service2.OnComponentChanged((object) this.x0467b00af7810f0c, (MemberDescriptor) TypeDescriptor.GetProperties((object) this.x0467b00af7810f0c)["LayoutSystem"], (object) null, (object) null);
          if (true)
            goto label_13;
          else
            goto label_18;
        }
        else
          goto label_14;
      }
      else
        goto label_11;
label_24:
      controlAt = controlLayoutSystem.GetControlAt(client);
      goto label_18;
label_25:
      this.x754f1c6f433be75d.x67ecc0d0e7c9a202 += new x09c1c18390e52ebf.ResizingManagerFinishedEventHandler(this.xa7afb2334769edc5);
label_26:
      this.x0467b00af7810f0c.Capture = true;
      if ((uint) y + (uint) x <= uint.MaxValue)
        return;
      goto label_25;
label_31:
      if ((uint) y - (uint) y <= uint.MaxValue)
      {
        this.x0467b00af7810f0c.Capture = true;
        return;
      }
      goto label_26;
label_37:
      if ((uint) y - (uint) y >= 0U)
      {
        client = this.x0467b00af7810f0c.PointToClient(new System.Drawing.Point(x, y));
        LayoutSystemBase layoutSystemAt = this.x0467b00af7810f0c.GetLayoutSystemAt(client);
        if (!(layoutSystemAt is SplitLayoutSystem))
          goto label_22;
        else
          goto label_34;
label_2:
        service1.SetSelectedComponents((ICollection) new object[1]
        {
          (object) this.x0467b00af7810f0c
        }, SelectionTypes.MouseDown | SelectionTypes.Click);
        return;
label_22:
        if (!(this.x0467b00af7810f0c.x0c42f19be578ccee != Rectangle.Empty) || !this.x0467b00af7810f0c.x0c42f19be578ccee.Contains(client))
        {
          if (layoutSystemAt is ControlLayoutSystem)
          {
            controlLayoutSystem = (ControlLayoutSystem) layoutSystemAt;
            goto label_24;
          }
          else
            goto label_2;
        }
        else
        {
          if ((uint) x > uint.MaxValue)
            return;
          this.x754f1c6f433be75d = new x09c1c18390e52ebf(this.x0467b00af7810f0c.Manager, this.x0467b00af7810f0c, client);
          this.x754f1c6f433be75d.x868a32060451dd2e += new EventHandler(this.x30c28c62b1a6040e);
          goto label_25;
        }
label_34:
        SplitLayoutSystem splitLayout = (SplitLayoutSystem) layoutSystemAt;
        if (splitLayout.x090b65ef9b096e0b(client.X, client.Y))
        {
          LayoutSystemBase xc13a8191724b6d55;
          LayoutSystemBase x5aa50bbadb0a1e6c;
          splitLayout.x5a3264f7eba0fe4f(client, out xc13a8191724b6d55, out x5aa50bbadb0a1e6c);
          this.x372569d2ea29984e = new x8e80e1c8bce8caf7(this.x0467b00af7810f0c, splitLayout, xc13a8191724b6d55, x5aa50bbadb0a1e6c, client, DockingHints.TranslucentFill);
          this.x372569d2ea29984e.x868a32060451dd2e += new EventHandler(this.xfae511fd7c4fb447);
          this.x372569d2ea29984e.x67ecc0d0e7c9a202 += new x8e80e1c8bce8caf7.SplittingManagerFinishedEventHandler(this.xc555e814c1720baf);
          goto label_31;
        }
        else
          goto label_2;
      }
      else
        goto label_18;
    }

    private void x1b91eb6f6bb77abc()
    {
      this.x754f1c6f433be75d.x868a32060451dd2e -= new EventHandler(this.x30c28c62b1a6040e);
      this.x754f1c6f433be75d.x67ecc0d0e7c9a202 -= new x09c1c18390e52ebf.ResizingManagerFinishedEventHandler(this.xa7afb2334769edc5);
      this.x754f1c6f433be75d = (x09c1c18390e52ebf) null;
    }

    private void xa7afb2334769edc5(int x0d4b3b88c5b24565)
    {
      this.x1b91eb6f6bb77abc();
      DesignerTransaction transaction = this.xff9c60b45aa37b1e.CreateTransaction("Resize Docked Windows");
      this.RaiseComponentChanging((MemberDescriptor) TypeDescriptor.GetProperties((object) this.Component)["ContentSize"]);
      this.x0467b00af7810f0c.ContentSize = x0d4b3b88c5b24565;
      this.RaiseComponentChanged((MemberDescriptor) TypeDescriptor.GetProperties((object) this.Component)["ContentSize"], (object) null, (object) null);
      if ((uint) x0d4b3b88c5b24565 + (uint) x0d4b3b88c5b24565 > uint.MaxValue)
        ;
      transaction.Commit();
    }

    private void x30c28c62b1a6040e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.x1b91eb6f6bb77abc();
    }

    protected override void OnMouseDragEnd(bool cancel)
    {
      this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
      try
      {
        if (this.x372569d2ea29984e == null)
        {
          if (this.x754f1c6f433be75d == null)
          {
            if ((uint) cancel + (uint) cancel <= uint.MaxValue)
              goto label_11;
label_2:
            DockControl dockControl;
            if (dockControl != null)
              return;
            LayoutSystemBase layoutSystemAt = this.x0467b00af7810f0c.GetLayoutSystemAt(this.x0467b00af7810f0c.PointToClient(Cursor.Position));
            if ((uint) cancel <= uint.MaxValue && layoutSystemAt is ControlLayoutSystem)
              return;
            if (((cancel ? 1 : 0) | 2) != 0)
            {
              if (((cancel ? 1 : 0) | int.MaxValue) != 0)
                return;
              goto label_22;
            }
label_5:
            if ((uint) cancel + (uint) cancel > uint.MaxValue)
            {
              if (false)
                ;
              return;
            }
            goto label_2;
label_11:
            if (this.x531514c39973cbc6 == null)
            {
              dockControl = this.x37c93a224e23ba95(this.x0467b00af7810f0c.PointToClient(Cursor.Position));
              goto label_5;
            }
            else
            {
              this.x531514c39973cbc6.Commit();
              if ((uint) cancel <= uint.MaxValue)
              {
                if ((uint) cancel - (uint) cancel >= 0U)
                {
                  this.x0467b00af7810f0c.Capture = false;
                  return;
                }
                goto label_22;
              }
            }
          }
          else
          {
            this.x754f1c6f433be75d.Commit();
            this.x0467b00af7810f0c.Capture = false;
            return;
          }
        }
        else
          goto label_22;
label_19:
        this.x0467b00af7810f0c.Capture = false;
        return;
label_22:
        this.x372569d2ea29984e.Commit();
        goto label_19;
      }
      finally
      {
        if (this.Control != null)
          this.Control.Capture = false;
      }
    }

    protected override void OnMouseDragMove(int x, int y)
    {
      System.Drawing.Point client = this.x0467b00af7810f0c.PointToClient(new System.Drawing.Point(x, y));
label_19:
      if (this.x372569d2ea29984e == null)
      {
        while (this.x754f1c6f433be75d == null)
        {
label_8:
          if (this.x531514c39973cbc6 != null)
            goto label_12;
label_4:
          if (!(this.x6afebf16b45c02e0 != System.Drawing.Point.Empty))
            return;
          Rectangle rectangle = new Rectangle(this.x6afebf16b45c02e0, SystemInformation.DragSize);
          rectangle.Offset(-SystemInformation.DragSize.Width / 2, -SystemInformation.DragSize.Height / 2);
          if (rectangle.Contains(x, y))
            return;
          if ((uint) x + (uint) x <= uint.MaxValue)
          {
            this.xe2e0ed61975ce467(this.x0467b00af7810f0c.PointToClient(this.x6afebf16b45c02e0));
            if (true)
            {
              this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
              return;
            }
          }
          else
            continue;
label_12:
          this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
          if ((uint) x - (uint) y >= 0U)
          {
            if (true)
              goto label_10;
            else
              goto label_17;
label_9:
            if (this.x531514c39973cbc6.x42f4c234c9358072.type != xedb4922162c60d3d.DockTargetType.None)
            {
              Cursor.Current = Cursors.Default;
              return;
            }
            goto label_11;
label_10:
            if (this.x531514c39973cbc6.x42f4c234c9358072 != null)
              goto label_9;
label_11:
            Cursor.Current = Cursors.No;
            return;
label_17:
            if ((uint) y - (uint) x < 0U)
            {
              if (false)
                goto label_8;
              else
                goto label_4;
            }
            else
              goto label_9;
          }
          else
            goto label_19;
        }
        this.x754f1c6f433be75d.OnMouseMove(client);
      }
      else
        this.x372569d2ea29984e.OnMouseMove(client);
    }

    private void xe2e0ed61975ce467(System.Drawing.Point x13d4cb8d1bd20347)
    {
      LayoutSystemBase layoutSystemAt = this.x0467b00af7810f0c.GetLayoutSystemAt(x13d4cb8d1bd20347);
      if (!(layoutSystemAt is ControlLayoutSystem))
        return;
      while (this.x531514c39973cbc6 == null)
      {
        ControlLayoutSystem controlLayoutSystem = (ControlLayoutSystem) layoutSystemAt;
        if (true)
        {
          DockControl controlAt = controlLayoutSystem.GetControlAt(x13d4cb8d1bd20347);
          this.x531514c39973cbc6 = (xedb4922162c60d3d) new x31248f32f85df1dd(this.x0467b00af7810f0c.Manager, this.x0467b00af7810f0c, (LayoutSystemBase) controlLayoutSystem, controlAt, controlLayoutSystem.SelectedControl.MetaData.DockedContentSize, x13d4cb8d1bd20347, DockingHints.TranslucentFill);
          this.x531514c39973cbc6.x67ecc0d0e7c9a202 += new xedb4922162c60d3d.DockingManagerFinishedEventHandler(this.x46ff430ed3944e0f);
          this.x531514c39973cbc6.x868a32060451dd2e += new EventHandler(this.x0ae87c4881d90427);
          this.x0467b00af7810f0c.Capture = true;
          if (true)
            break;
          break;
        }
      }
    }

    private void xf6aefb7d0abb95ba()
    {
      this.x531514c39973cbc6.x67ecc0d0e7c9a202 -= new xedb4922162c60d3d.DockingManagerFinishedEventHandler(this.x46ff430ed3944e0f);
      this.x531514c39973cbc6.x868a32060451dd2e -= new EventHandler(this.x0ae87c4881d90427);
      this.x531514c39973cbc6 = (xedb4922162c60d3d) null;
    }

    internal virtual void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
    {
      IComponentChangeService service1 = (IComponentChangeService) this.GetService(typeof (IComponentChangeService));
      bool flag;
      if ((uint) flag - (uint) flag > uint.MaxValue)
        goto label_36;
      else
        goto label_37;
label_1:
      bool x49cf4e0157d9436c;
      if ((uint) x49cf4e0157d9436c + (uint) x49cf4e0157d9436c > uint.MaxValue || x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.AlreadyActioned)
        return;
      IDesignerHost service2;
      DesignerTransaction transaction = service2.CreateTransaction("Move DockControl");
      ControlLayoutSystem xf333586e50dccad2;
      DockControl selectedControl;
      ISelectionService service3;
      try
      {
        if (this.x0467b00af7810f0c.Manager != null)
          goto label_32;
label_31:
        Control control1 = (Control) null;
        goto label_33;
label_32:
        control1 = this.x0467b00af7810f0c.Manager.DockSystemContainer;
label_33:
        Control control2 = control1;
label_28:
        if ((uint) x49cf4e0157d9436c + (uint) x49cf4e0157d9436c > uint.MaxValue)
          goto label_5;
        else
          goto label_29;
label_4:
        service1.OnComponentChanged((object) control2, (MemberDescriptor) TypeDescriptor.GetProperties((object) control2)["Controls"], (object) null, (object) null);
label_5:
        transaction.Commit();
        if (((x49cf4e0157d9436c ? 1 : 0) | int.MaxValue) != 0)
        {
          if (true)
            return;
          goto label_31;
        }
        else
          goto label_14;
label_10:
        if (x11d58b056c032b03.dockContainer == null)
        {
          if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.CreateNewContainer)
          {
            if (control2 != null)
              goto label_9;
label_7:
            xf333586e50dccad2.x6b145af772038ef2(selectedControl.Manager, selectedControl, x49cf4e0157d9436c, x11d58b056c032b03);
            service2.Container.Add((IComponent) selectedControl.LayoutSystem.DockContainer);
            if (control2 != null)
              goto label_4;
            else
              goto label_5;
label_9:
            service1.OnComponentChanging((object) control2, (MemberDescriptor) TypeDescriptor.GetProperties((object) control2)["Controls"]);
            if (true)
              goto label_7;
            else
              goto label_4;
          }
          else
            goto label_5;
        }
        else
        {
          service1.OnComponentChanging((object) x11d58b056c032b03.dockContainer, (MemberDescriptor) TypeDescriptor.GetProperties((object) x11d58b056c032b03.dockContainer)["LayoutSystem"]);
          xf333586e50dccad2.x6b145af772038ef2(x11d58b056c032b03.dockContainer.Manager, selectedControl, x49cf4e0157d9436c, x11d58b056c032b03);
          service1.OnComponentChanged((object) x11d58b056c032b03.dockContainer, (MemberDescriptor) TypeDescriptor.GetProperties((object) x11d58b056c032b03.dockContainer)["LayoutSystem"], (object) null, (object) null);
          goto label_5;
        }
label_14:
        service1.OnComponentChanged((object) control2, (MemberDescriptor) TypeDescriptor.GetProperties((object) control2)["Controls"], (object) null, (object) null);
label_27:
        if (((x49cf4e0157d9436c ? 1 : 0) | int.MaxValue) != 0)
          goto label_10;
        else
          goto label_28;
label_29:
        if (false)
          goto label_20;
        else
          goto label_22;
label_18:
        do
        {
          service1.OnComponentChanging((object) this.x0467b00af7810f0c, (MemberDescriptor) TypeDescriptor.GetProperties((object) this.x0467b00af7810f0c)["Manager"]);
          service1.OnComponentChanging((object) this.x0467b00af7810f0c, (MemberDescriptor) TypeDescriptor.GetProperties((object) this.x0467b00af7810f0c)["LayoutSystem"]);
          if (!x49cf4e0157d9436c)
          {
            if (true)
            {
              LayoutUtilities.xf1cbd48a28ce6e74(selectedControl);
              if (true)
                goto label_26;
            }
            else
              goto label_31;
          }
          else
            goto label_19;
        }
        while ((uint) x49cf4e0157d9436c + (uint) x49cf4e0157d9436c < 0U);
        goto label_22;
label_13:
        service1.OnComponentChanged((object) this.x0467b00af7810f0c, (MemberDescriptor) TypeDescriptor.GetProperties((object) this.x0467b00af7810f0c)["LayoutSystem"], (object) null, (object) null);
        service1.OnComponentChanged((object) this.x0467b00af7810f0c, (MemberDescriptor) TypeDescriptor.GetProperties((object) this.x0467b00af7810f0c)["Manager"], (object) null, (object) null);
        if (control2 == null)
          goto label_10;
        else
          goto label_14;
label_19:
        LayoutUtilities.x4487f2f8917e3fd0(xf333586e50dccad2);
        goto label_13;
label_26:
        if ((uint) x49cf4e0157d9436c - (uint) x49cf4e0157d9436c >= 0U)
          goto label_13;
        else
          goto label_27;
label_20:
        if (control2 == null)
          goto label_18;
label_21:
        service1.OnComponentChanging((object) control2, (MemberDescriptor) TypeDescriptor.GetProperties((object) control2)["Controls"]);
        if ((uint) x49cf4e0157d9436c + (uint) x49cf4e0157d9436c < 0U)
          goto label_4;
        else
          goto label_18;
label_22:
        if (control2 != null)
        {
          service3.SetSelectedComponents((ICollection) new object[1]
          {
            (object) this.x0467b00af7810f0c.Manager.DockSystemContainer
          }, SelectionTypes.Replace);
          goto label_20;
        }
        else
        {
          service3.SetSelectedComponents((ICollection) new object[1]
          {
            (object) service2.RootComponent
          }, SelectionTypes.Replace);
          if (((x49cf4e0157d9436c ? 1 : 0) & 0) == 0)
            goto label_20;
          else
            goto label_21;
        }
      }
      catch
      {
        transaction.Cancel();
        return;
      }
label_36:
      x49cf4e0157d9436c = this.x531514c39973cbc6.x59ae058c4a0dec87 == null;
      selectedControl = xf333586e50dccad2.SelectedControl;
      this.xf6aefb7d0abb95ba();
      if (x11d58b056c032b03 == null || x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.None)
        return;
      goto label_1;
label_37:
      service2 = (IDesignerHost) this.GetService(typeof (IDesignerHost));
      service3 = (ISelectionService) this.GetService(typeof (ISelectionService));
      xf333586e50dccad2 = (ControlLayoutSystem) this.x531514c39973cbc6.xf333586e50dccad2;
      if ((uint) flag > uint.MaxValue)
        goto label_1;
      else
        goto label_36;
    }

    internal virtual void x0ae87c4881d90427(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.xf6aefb7d0abb95ba();
    }

    private void x367ada130c39f434()
    {
      this.x372569d2ea29984e.x868a32060451dd2e -= new EventHandler(this.xfae511fd7c4fb447);
      this.x372569d2ea29984e.x67ecc0d0e7c9a202 -= new x8e80e1c8bce8caf7.SplittingManagerFinishedEventHandler(this.xc555e814c1720baf);
      this.x372569d2ea29984e = (x8e80e1c8bce8caf7) null;
    }

    private void xfae511fd7c4fb447(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.x367ada130c39f434();
    }

    private void xc555e814c1720baf(
      LayoutSystemBase xc13a8191724b6d55,
      LayoutSystemBase x5aa50bbadb0a1e6c,
      float x5c2440c931f8d932,
      float x4afa341b2323a009)
    {
      SplitLayoutSystem x07bf3386da210f81 = this.x372569d2ea29984e.x07bf3386da210f81;
      if (true)
        goto label_8;
      else
        goto label_2;
label_1:
      DesignerTransaction transaction;
      transaction.Commit();
      x07bf3386da210f81.x3e0280cae730d1f2();
      if (true)
        return;
label_2:
      SizeF workingSize1;
      workingSize1.Width = x4afa341b2323a009;
      if (((int) (uint) x5c2440c931f8d932 & 0) != 0)
        goto label_1;
label_3:
      SizeF workingSize2;
      xc13a8191724b6d55.WorkingSize = workingSize2;
      x5aa50bbadb0a1e6c.WorkingSize = workingSize1;
      IComponentChangeService service;
      service.OnComponentChanged((object) this.x0467b00af7810f0c, (MemberDescriptor) TypeDescriptor.GetProperties((object) this.x0467b00af7810f0c)["LayoutSystem"], (object) null, (object) null);
      goto label_1;
label_8:
      do
      {
        this.x367ada130c39f434();
        if (((int) (uint) x4afa341b2323a009 & 0) == 0)
        {
          transaction = this.xff9c60b45aa37b1e.CreateTransaction("Resize Docked Windows");
          service = (IComponentChangeService) this.GetService(typeof (IComponentChangeService));
          service.OnComponentChanging((object) this.x0467b00af7810f0c, (MemberDescriptor) TypeDescriptor.GetProperties((object) this.x0467b00af7810f0c)["LayoutSystem"]);
          workingSize2 = xc13a8191724b6d55.WorkingSize;
          workingSize1 = x5aa50bbadb0a1e6c.WorkingSize;
          if (x07bf3386da210f81.SplitMode != Orientation.Horizontal || (uint) x4afa341b2323a009 - (uint) x4afa341b2323a009 < 0U)
            workingSize2.Width = x5c2440c931f8d932;
          else
            goto label_6;
        }
        else
          goto label_10;
      }
      while ((uint) x5c2440c931f8d932 - (uint) x5c2440c931f8d932 > uint.MaxValue);
      goto label_11;
label_6:
      workingSize2.Height = x5c2440c931f8d932;
      workingSize1.Height = x4afa341b2323a009;
      goto label_3;
label_10:
      return;
label_11:
      if ((uint) x4afa341b2323a009 + (uint) x5c2440c931f8d932 <= uint.MaxValue)
        goto label_2;
    }

    protected override void OnSetCursor()
    {
      System.Drawing.Point client = this.x0467b00af7810f0c.PointToClient(Cursor.Position);
      SplitLayoutSystem layoutSystemAt;
      do
      {
        layoutSystemAt = this.x0467b00af7810f0c.GetLayoutSystemAt(client) as SplitLayoutSystem;
        if (true)
          goto label_8;
        else
          goto label_16;
label_1:
        if (this.x0467b00af7810f0c.x0c42f19be578ccee != Rectangle.Empty)
          goto label_9;
label_3:
        Cursor.Current = Cursors.Default;
        if (true)
          continue;
        goto label_12;
label_9:
        if (!this.x0467b00af7810f0c.x0c42f19be578ccee.Contains(client))
        {
          if (false)
            goto label_11;
          else
            goto label_3;
        }
        else
          goto label_6;
label_8:
        if (layoutSystemAt != null)
          goto label_17;
        else
          goto label_1;
label_16:
        if (false)
          goto label_4;
label_17:
        if (!layoutSystemAt.x090b65ef9b096e0b(client.X, client.Y))
          goto label_1;
        else
          goto label_12;
      }
      while (false);
      goto label_5;
label_4:
      Cursor.Current = Cursors.HSplit;
      if (true)
        return;
      goto label_10;
label_6:
      if (this.x0467b00af7810f0c.x61c108cc44ef385a)
      {
        Cursor.Current = Cursors.VSplit;
        return;
      }
      goto label_4;
label_10:
      Cursor.Current = Cursors.VSplit;
      return;
label_11:
      if (false)
        goto label_10;
label_12:
      if (layoutSystemAt.SplitMode == Orientation.Horizontal)
      {
        Cursor.Current = Cursors.HSplit;
        return;
      }
      goto label_10;
label_5:;
    }

    public override void InitializeNewComponent(IDictionary defaultValues)
    {
      base.InitializeNewComponent(defaultValues);
      this.x391093a02bb10339();
    }

    private void x391093a02bb10339()
    {
      IExtenderListService service = (IExtenderListService) this.GetService(typeof (IExtenderListService));
      if (false)
      {
        int num;
        if ((uint) num >= 0U)
          return;
      }
      else
        goto label_15;
label_2:
      MethodInfo method;
      if (method == null)
      {
        if (true)
          return;
        goto label_15;
      }
      else
        goto label_9;
label_8:
      if (true)
        goto label_2;
label_9:
      IExtenderProvider extenderProvider;
      method.Invoke((object) extenderProvider, new object[2]
      {
        (object) this.Component,
        (object) false
      });
      int index;
      if ((uint) index >= 0U)
        return;
      goto label_8;
label_15:
      IExtenderProvider[] extenderProviders = service.GetExtenderProviders();
      index = 0;
      if ((uint) index > uint.MaxValue)
        return;
      for (; index < extenderProviders.Length; ++index)
      {
        extenderProvider = extenderProviders[index];
        while (extenderProvider.GetType().FullName == "System.ComponentModel.Design.Serialization.CodeDomDesignerLoader+ModifiersExtenderProvider")
        {
          method = extenderProvider.GetType().GetMethod("SetGenerateMember", BindingFlags.Instance | BindingFlags.Public);
          if ((uint) index + (uint) index >= 0U)
            goto label_8;
        }
      }
    }

    public override SelectionRules SelectionRules
    {
      get
      {
        return SelectionRules.Visible;
      }
    }

    public override void Initialize(IComponent component)
    {
      base.Initialize(component);
      do
      {
        if (!(component is DockContainer))
          goto label_4;
label_3:
        ISelectionService service = (ISelectionService) this.GetService(typeof (ISelectionService));
        this.x4cd3df9bd5e139a3 = (IComponentChangeService) this.GetService(typeof (IComponentChangeService));
        this.xff9c60b45aa37b1e = (IDesignerHost) this.GetService(typeof (IDesignerHost));
        continue;
label_4:
        SandDockLanguage.ShowCachedAssemblyError(component.GetType().Assembly, this.GetType().Assembly);
        if (false)
          goto label_2;
        else
          goto label_3;
      }
      while (false);
      this.x4cd3df9bd5e139a3.ComponentRemoving += new ComponentEventHandler(this.x97263465e88c9d8e);
      this.x4cd3df9bd5e139a3.ComponentRemoved += new ComponentEventHandler(this.x5c6da9d6db2adc7a);
label_2:
      this.x0467b00af7810f0c = (DockContainer) component;
    }

    protected override void Dispose(bool disposing)
    {
      ISelectionService service = (ISelectionService) this.GetService(typeof (ISelectionService));
      this.x4cd3df9bd5e139a3.ComponentRemoving += new ComponentEventHandler(this.x97263465e88c9d8e);
      this.x4cd3df9bd5e139a3.ComponentRemoved += new ComponentEventHandler(this.x5c6da9d6db2adc7a);
      base.Dispose(disposing);
    }

    private void x97263465e88c9d8e(object xe0292b9ed559da7d, ComponentEventArgs xfbf34718e704c6bc)
    {
      DockControl component = xfbf34718e704c6bc.Component as DockControl;
      while (component != null && component.LayoutSystem != null)
      {
        if (component.LayoutSystem.DockContainer == this.x0467b00af7810f0c)
        {
          this.xaaafffc15ba630b7 = component;
          if (false)
            break;
          this.RaiseComponentChanging((MemberDescriptor) TypeDescriptor.GetProperties((object) this.x0467b00af7810f0c)["LayoutSystem"]);
          break;
        }
        if (true)
          break;
      }
    }

    private void x5c6da9d6db2adc7a(object xe0292b9ed559da7d, ComponentEventArgs xfbf34718e704c6bc)
    {
      if (xfbf34718e704c6bc.Component != this.xaaafffc15ba630b7)
        return;
      this.xaaafffc15ba630b7 = (DockControl) null;
      this.RaiseComponentChanged((MemberDescriptor) TypeDescriptor.GetProperties((object) this.x0467b00af7810f0c)["LayoutSystem"], (object) null, (object) null);
    }
  }
}
