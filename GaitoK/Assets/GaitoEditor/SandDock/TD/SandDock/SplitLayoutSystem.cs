// Decompiled with JetBrains decompiler
// Type: TD.SandDock.SplitLayoutSystem
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
  [TypeConverter(typeof (x807757bdf074f1b8))]
  public class SplitLayoutSystem : LayoutSystemBase
  {
    internal const int x51b0f429bd564626 = 4;
    private SplitLayoutSystem.LayoutSystemBaseCollection x820c504c9c557c92;
    private Orientation xe36f4efbf268b3f1;
    private ArrayList x366d4cf7098f9c63;
    private x8e80e1c8bce8caf7 x372569d2ea29984e;

    internal event EventHandler x7e9646eed248ed11;

    public SplitLayoutSystem()
    {
      this.x820c504c9c557c92 = new SplitLayoutSystem.LayoutSystemBaseCollection(this);
      this.x366d4cf7098f9c63 = new ArrayList();
    }

    public SplitLayoutSystem(int desiredWidth, int desiredHeight)
      : this()
    {
      this.WorkingSize = new SizeF((float) desiredWidth, (float) desiredHeight);
    }

    [Obsolete("Use the constructor taking a SizeF instead.")]
    public SplitLayoutSystem(
      int desiredWidth,
      int desiredHeight,
      Orientation splitMode,
      LayoutSystemBase[] layoutSystems)
      : this(desiredWidth, desiredHeight)
    {
      this.xe36f4efbf268b3f1 = splitMode;
      this.x820c504c9c557c92.AddRange(layoutSystems);
    }

    public SplitLayoutSystem(
      SizeF workingSize,
      Orientation splitMode,
      LayoutSystemBase[] layoutSystems)
      : this()
    {
      this.WorkingSize = workingSize;
      this.xe36f4efbf268b3f1 = splitMode;
      this.x820c504c9c557c92.AddRange(layoutSystems);
    }

    internal override bool x56005f23d6948487
    {
      get
      {
        foreach (LayoutSystemBase layoutSystem in (CollectionBase) this.LayoutSystems)
        {
          if (layoutSystem.x56005f23d6948487)
            return true;
        }
        return false;
      }
    }

    public bool Optimize()
    {
      if (this.LayoutSystems.Count != 1)
        goto label_3;
      else
        goto label_33;
label_1:
      return false;
label_3:
      IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
      bool flag1;
      int index1;
      bool flag2;
      try
      {
        do
        {
          int index2;
          if (!enumerator.MoveNext())
          {
            if ((uint) index2 + (uint) index1 >= 0U)
              goto label_1;
          }
label_20:
          LayoutSystemBase current = (LayoutSystemBase) enumerator.Current;
label_6:
          if (current is SplitLayoutSystem)
          {
            SplitLayoutSystem splitLayoutSystem = (SplitLayoutSystem) current;
            do
            {
              LayoutSystemBase[] array;
              do
              {
                if ((uint) flag2 <= uint.MaxValue)
                {
                  if (splitLayoutSystem.SplitMode == this.SplitMode)
                  {
                    array = new LayoutSystemBase[splitLayoutSystem.LayoutSystems.Count];
                    if ((uint) index2 <= uint.MaxValue)
                    {
                      splitLayoutSystem.LayoutSystems.CopyTo(array, 0);
                      splitLayoutSystem.LayoutSystems.xd7a3953bce504b63 = true;
                    }
                    splitLayoutSystem.LayoutSystems.Clear();
                    index1 = this.LayoutSystems.IndexOf((LayoutSystemBase) splitLayoutSystem);
                    this.LayoutSystems.xd7a3953bce504b63 = true;
                  }
                  else
                    goto label_9;
                }
                else
                  goto label_6;
              }
              while ((uint) flag2 < 0U);
              this.LayoutSystems.Remove((LayoutSystemBase) splitLayoutSystem);
              for (index2 = array.Length - 1; index2 >= 0; --index2)
                this.LayoutSystems.Insert(index1, array[index2]);
              this.LayoutSystems.xd7a3953bce504b63 = false;
              flag1 = true;
              if ((uint) index1 - (uint) flag2 <= uint.MaxValue)
                goto label_38;
            }
            while ((uint) index2 > uint.MaxValue);
            goto label_20;
label_9:
            flag2 = splitLayoutSystem.Optimize();
          }
        }
        while (!flag2);
        flag1 = true;
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        if ((uint) flag1 - (uint) index1 <= uint.MaxValue)
          goto label_25;
        else
          goto label_24;
label_23:
        if ((uint) index1 - (uint) flag2 < 0U)
          goto label_25;
        else
          goto label_27;
label_24:
        disposable.Dispose();
        goto label_23;
label_25:
        if (disposable == null)
        {
          if ((uint) index1 + (uint) flag2 >= 0U && false)
            goto label_23;
        }
        else
          goto label_24;
label_27:;
      }
label_38:
      return flag1;
label_33:
      bool flag3;
      bool flag4;
      while (!(this.LayoutSystems[0] is SplitLayoutSystem))
      {
        while ((uint) flag4 + (uint) flag4 > uint.MaxValue)
        {
          if (true)
          {
            if (true)
            {
              if ((uint) flag3 - (uint) flag4 <= uint.MaxValue && (uint) flag4 <= uint.MaxValue)
                break;
            }
            else
              goto label_1;
          }
          else
            goto label_33;
        }
        goto label_3;
      }
      SplitLayoutSystem layoutSystem1 = (SplitLayoutSystem) this.LayoutSystems[0];
      int num1;
      int num2;
      while ((layoutSystem1.LayoutSystems.Count == 1 || (num2 | (int) byte.MaxValue) == 0) && (layoutSystem1.LayoutSystems[0] is SplitLayoutSystem || (uint) flag3 - (uint) num1 > uint.MaxValue) && ((SplitLayoutSystem) layoutSystem1.LayoutSystems[0]).SplitMode == this.SplitMode)
      {
        SplitLayoutSystem layoutSystem2 = (SplitLayoutSystem) layoutSystem1.LayoutSystems[0];
        LayoutSystemBase[] layoutSystemBaseArray = new LayoutSystemBase[layoutSystem2.LayoutSystems.Count];
        layoutSystem2.LayoutSystems.CopyTo(layoutSystemBaseArray, 0);
        if ((uint) flag4 + (uint) num2 <= uint.MaxValue)
          goto label_34;
label_32:
        this.LayoutSystems.xd7a3953bce504b63 = false;
        return true;
label_34:
        if ((uint) flag3 - (uint) flag4 <= uint.MaxValue)
        {
          layoutSystem2.LayoutSystems.xd7a3953bce504b63 = true;
          layoutSystem2.LayoutSystems.Clear();
          this.LayoutSystems.xd7a3953bce504b63 = true;
          this.LayoutSystems.Clear();
          this.LayoutSystems.AddRange(layoutSystemBaseArray);
          goto label_32;
        }
      }
      goto label_1;
    }

    internal override void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
    {
      base.x46ff430ed3944e0f(x11d58b056c032b03);
      if (x11d58b056c032b03 == null || x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.None || x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.AlreadyActioned)
        return;
      x410f3612b9a8f9de dockContainer1 = (x410f3612b9a8f9de) this.DockContainer;
      SandDockManager manager = this.DockContainer.Manager;
      DockControl[] x9476096be9672d38;
      if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.Float)
        x9476096be9672d38 = this.x9476096be9672d38;
      else
        goto label_33;
label_2:
      DockControl xbe0b15fe97a1ee89 = dockContainer1.xbe0b15fe97a1ee89;
label_3:
      dockContainer1.LayoutSystem = new SplitLayoutSystem();
      if (true)
      {
        dockContainer1.Dispose();
        try
        {
          if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.CreateNewContainer)
            goto label_24;
          else
            goto label_30;
label_6:
          if (false)
            goto label_9;
label_7:
          x11d58b056c032b03.layoutSystem.SplitForLayoutSystem((LayoutSystemBase) this, x11d58b056c032b03.dockSide);
          if (true)
            return;
label_8:
          while (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.SplitExistingSystem)
          {
            if (!(x11d58b056c032b03.dockContainer is DocumentContainer))
            {
              if (this.LayoutSystems.Count != 1)
                goto label_7;
              else
                goto label_9;
            }
            else
            {
              ControlLayoutSystem newLayoutSystem;
              do
              {
                newLayoutSystem = x11d58b056c032b03.dockContainer.CreateNewLayoutSystem(this.WorkingSize);
                newLayoutSystem.Controls.AddRange(x9476096be9672d38);
                if (true)
                {
                  if (false)
                    goto label_8;
                }
                else
                  goto label_31;
              }
              while (false);
              if (false)
                break;
              x11d58b056c032b03.layoutSystem.SplitForLayoutSystem((LayoutSystemBase) newLayoutSystem, x11d58b056c032b03.dockSide);
label_31:
              if (true)
                break;
              break;
            }
          }
          return;
label_9:
          if (this.LayoutSystems[0] is ControlLayoutSystem)
          {
            ControlLayoutSystem layoutSystem = (ControlLayoutSystem) this.LayoutSystems[0];
            this.LayoutSystems.Remove((LayoutSystemBase) layoutSystem);
            x11d58b056c032b03.layoutSystem.SplitForLayoutSystem((LayoutSystemBase) layoutSystem, x11d58b056c032b03.dockSide);
            return;
          }
          if (true)
            goto label_7;
          else
            goto label_6;
label_24:
          if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.JoinExistingSystem)
          {
            this.MoveToLayoutSystem(x11d58b056c032b03.layoutSystem, x11d58b056c032b03.index);
            return;
          }
          goto label_8;
label_30:
          DockContainer dockContainer2 = manager.FindDockContainer(x11d58b056c032b03.dockLocation);
          if (x11d58b056c032b03.dockLocation != ContainerDockLocation.Center)
          {
            if (false)
              goto label_6;
          }
          else
            goto label_27;
label_22:
          this.x810df8ef88cf4bf2(manager, x11d58b056c032b03.dockLocation, x11d58b056c032b03.middle ? ContainerDockEdge.Inside : ContainerDockEdge.Outside);
          return;
label_27:
          if (dockContainer2 != null)
          {
            this.MoveToLayoutSystem(LayoutUtilities.FindControlLayoutSystem(dockContainer2));
            return;
          }
          goto label_22;
        }
        finally
        {
          xbe0b15fe97a1ee89.Activate();
        }
      }
      else
        goto label_2;
label_33:
      dockContainer1.x159713d3b60fae0c(x11d58b056c032b03.bounds, true, true);
      if (false)
        goto label_3;
    }

    public void MoveToLayoutSystem(ControlLayoutSystem layoutSystem)
    {
      this.MoveToLayoutSystem(layoutSystem, 0);
    }

    public void MoveToLayoutSystem(ControlLayoutSystem layoutSystem, int index)
    {
      DockControl dockControl = (DockControl) null;
      if (this.LayoutSystems.Count == 1 && this.LayoutSystems[0] is ControlLayoutSystem)
        dockControl = ((ControlLayoutSystem) this.LayoutSystems[0]).SelectedControl;
      DockControl[] x9476096be9672d38 = this.x9476096be9672d38;
      for (int index1 = x9476096be9672d38.Length - 1; index1 >= 0; --index1)
      {
        DockControl control = x9476096be9672d38[index1];
        layoutSystem.Controls.Insert(index, control);
      }
      if (dockControl == null)
        return;
      layoutSystem.SelectedControl = dockControl;
    }

    internal override DockControl[] x9476096be9672d38
    {
      get
      {
        ArrayList x8da10969b0e2a75e = new ArrayList();
        this.xd78391e378ab076b(this, x8da10969b0e2a75e);
        return (DockControl[]) x8da10969b0e2a75e.ToArray(typeof (DockControl));
      }
    }

    private void xd78391e378ab076b(SplitLayoutSystem xb25822984a90695b, ArrayList x8da10969b0e2a75e)
    {
      foreach (LayoutSystemBase layoutSystemBase in (CollectionBase) xb25822984a90695b.x820c504c9c557c92)
      {
        if (!(layoutSystemBase is SplitLayoutSystem))
        {
          if (layoutSystemBase is ControlLayoutSystem)
          {
            foreach (DockControl control in (CollectionBase) ((ControlLayoutSystem) layoutSystemBase).Controls)
              x8da10969b0e2a75e.Add((object) control);
          }
        }
        else
          this.xd78391e378ab076b((SplitLayoutSystem) layoutSystemBase, x8da10969b0e2a75e);
      }
    }

    internal void x5a3264f7eba0fe4f(
      System.Drawing.Point x13d4cb8d1bd20347,
      out LayoutSystemBase xc13a8191724b6d55,
      out LayoutSystemBase x5aa50bbadb0a1e6c)
    {
      int index1 = 0;
      int num;
      if ((num & 0) == 0)
        goto label_10;
label_1:
      int index2;
      while (index2 < this.x820c504c9c557c92.Count)
      {
        if (this.x820c504c9c557c92[index2] is ControlLayoutSystem)
        {
          while (((ControlLayoutSystem) this.x820c504c9c557c92[index2]).Collapsed)
          {
            while ((uint) index2 >= 0U)
            {
              if (true)
              {
                if ((uint) index1 - (uint) index2 < 0U)
                  goto label_31;
                else
                  goto label_6;
              }
            }
            if (false)
              continue;
label_6:
            ++index2;
            if ((uint) index2 <= uint.MaxValue)
            {
              if ((uint) index2 - (uint) index1 < 0U)
                return;
              goto label_1;
            }
            else
              goto label_10;
          }
        }
        x5aa50bbadb0a1e6c = this.LayoutSystems[index2];
        break;
      }
      return;
label_10:
      IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
      try
      {
label_14:
        LayoutSystemBase current;
        while (enumerator.MoveNext())
        {
          current = (LayoutSystemBase) enumerator.Current;
          if ((uint) index1 <= uint.MaxValue)
          {
            if (!(current is ControlLayoutSystem) || !((ControlLayoutSystem) current).Collapsed)
            {
              if (this.SplitMode != Orientation.Horizontal)
                goto label_13;
              else
                goto label_15;
            }
          }
          else
            goto label_13;
        }
        if ((uint) index1 > uint.MaxValue)
          goto label_15;
        else
          goto label_30;
label_13:
        if (this.SplitMode != Orientation.Vertical || x13d4cb8d1bd20347.X < current.Bounds.Right || x13d4cb8d1bd20347.X > current.Bounds.Right + 4)
          goto label_14;
        else
          goto label_18;
label_15:
        if (x13d4cb8d1bd20347.Y >= current.Bounds.Bottom && x13d4cb8d1bd20347.Y <= current.Bounds.Bottom + 4)
        {
          if ((uint) index2 + (uint) index1 > uint.MaxValue)
            goto label_24;
        }
        else
          goto label_13;
label_18:
        index1 = this.LayoutSystems.IndexOf(current);
label_24:
        if ((uint) index1 + (uint) index2 < 0U)
        {
          if (true)
          {
            if ((uint) index1 - (uint) index1 >= 0U)
            {
              if ((uint) index2 + (uint) index1 <= uint.MaxValue)
                goto label_15;
            }
            else
              goto label_14;
          }
        }
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
label_30:
      xc13a8191724b6d55 = this.LayoutSystems[index1];
label_31:
      x5aa50bbadb0a1e6c = xc13a8191724b6d55;
      index2 = index1 + 1;
      goto label_1;
    }

    protected internal override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      foreach (Rectangle rectangle in this.x366d4cf7098f9c63)
      {
        if (false)
          goto label_10;
label_2:
        if (!rectangle.Contains(e.X, e.Y))
          continue;
label_10:
        LayoutSystemBase xc13a8191724b6d55;
        LayoutSystemBase x5aa50bbadb0a1e6c;
        this.x5a3264f7eba0fe4f(new System.Drawing.Point(e.X, e.Y), out xc13a8191724b6d55, out x5aa50bbadb0a1e6c);
        if (this.x372569d2ea29984e != null)
          goto label_7;
label_6:
        DockingHints dockingHints = this.DockContainer.Manager != null ? this.DockContainer.Manager.DockingHints : DockingHints.TranslucentFill;
        this.x372569d2ea29984e = new x8e80e1c8bce8caf7(this.DockContainer, this, xc13a8191724b6d55, x5aa50bbadb0a1e6c, new System.Drawing.Point(e.X, e.Y), dockingHints);
        this.x372569d2ea29984e.x868a32060451dd2e += new EventHandler(this.xfae511fd7c4fb447);
        if (true)
        {
          if (false)
            ;
          this.x372569d2ea29984e.x67ecc0d0e7c9a202 += new x8e80e1c8bce8caf7.SplittingManagerFinishedEventHandler(this.xc555e814c1720baf);
          break;
        }
        if (true)
          continue;
        goto label_2;
label_7:
        this.x372569d2ea29984e.Dispose();
        goto label_6;
      }
    }

    protected internal override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      if (this.x531514c39973cbc6 == null)
      {
        if (this.x372569d2ea29984e == null)
          return;
        this.x372569d2ea29984e.Commit();
      }
      else
        this.x531514c39973cbc6.Commit();
    }

    internal bool x090b65ef9b096e0b(int x08db3aeabb253cb1, int x1e218ceaee1bb583)
    {
      IEnumerator enumerator = this.x366d4cf7098f9c63.GetEnumerator();
      bool flag;
      try
      {
label_2:
        while (enumerator.MoveNext())
        {
          while (!((Rectangle) enumerator.Current).Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
          {
            if ((x08db3aeabb253cb1 & 0) != 0)
            {
              if ((uint) x08db3aeabb253cb1 > uint.MaxValue)
                goto label_14;
            }
            else
              goto label_2;
          }
          flag = true;
          return flag;
        }
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        do
        {
          if (disposable != null)
            goto label_9;
          else
            goto label_11;
label_8:
          continue;
label_9:
          disposable.Dispose();
          goto label_8;
label_11:
          if ((uint) x1e218ceaee1bb583 - (uint) x1e218ceaee1bb583 > uint.MaxValue)
            goto label_8;
          else
            goto label_12;
        }
        while ((uint) x08db3aeabb253cb1 + (uint) flag < 0U);
        goto label_13;
label_12:
        if ((uint) flag - (uint) flag <= uint.MaxValue)
          ;
label_13:;
      }
label_14:
      return false;
    }

    protected internal override void OnMouseMove(MouseEventArgs e)
    {
      bool flag = false;
      if (e.Button == MouseButtons.Left)
        goto label_15;
      else
        goto label_8;
label_1:
      base.OnMouseMove(e);
      if ((uint) flag <= uint.MaxValue)
      {
        if ((uint) flag - (uint) flag >= 0U)
          return;
        goto label_12;
      }
label_4:
      if (this.xe36f4efbf268b3f1 == Orientation.Horizontal)
      {
        Cursor.Current = Cursors.HSplit;
        goto label_1;
      }
label_5:
      Cursor.Current = Cursors.VSplit;
      if ((uint) flag + (uint) flag > uint.MaxValue || (uint) flag <= uint.MaxValue)
        goto label_1;
      else
        goto label_4;
label_8:
      if (false)
        return;
      if ((uint) flag < 0U)
        goto label_5;
label_10:
      flag = this.x090b65ef9b096e0b(e.X, e.Y);
      if (!flag)
      {
        if ((uint) flag + (uint) flag <= uint.MaxValue)
        {
          Cursor.Current = Cursors.Default;
          if ((uint) flag + (uint) flag < 0U)
            return;
          if (true)
            goto label_1;
          else
            goto label_4;
        }
        else
          goto label_1;
      }
      else
        goto label_4;
label_12:
      this.x372569d2ea29984e.OnMouseMove(new System.Drawing.Point(e.X, e.Y));
      return;
label_15:
      if (this.x531514c39973cbc6 != null)
        this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
      else if (this.x372569d2ea29984e == null)
        goto label_10;
      else
        goto label_12;
    }

    [Category("Layout")]
    [Description("Indicates whether this layout is split horizontally or vertically.")]
    [DefaultValue(typeof (Orientation), "Horizontal")]
    public Orientation SplitMode
    {
      get
      {
        return this.xe36f4efbf268b3f1;
      }
      set
      {
        this.xe36f4efbf268b3f1 = value;
        this.x3e0280cae730d1f2();
      }
    }

    internal override bool x74e31f9641656e0b
    {
      get
      {
        IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
        try
        {
label_2:
          if (!enumerator.MoveNext())
          {
            bool flag;
            if (((flag ? 1 : 0) & 0) == 0)
            {
              if (true)
                goto label_12;
              else
                goto label_8;
            }
            else if ((uint) flag >= 0U)
              goto label_2;
          }
          else
            goto label_8;
label_6:
          LayoutSystemBase current;
          if (!current.x74e31f9641656e0b)
            return false;
          goto label_2;
label_8:
          current = (LayoutSystemBase) enumerator.Current;
          goto label_6;
        }
        finally
        {
          (enumerator as IDisposable)?.Dispose();
        }
label_12:
        return true;
      }
    }

    internal override bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256)
    {
      foreach (LayoutSystemBase layoutSystem in (CollectionBase) this.LayoutSystems)
      {
        if (!layoutSystem.xe302f2203dc14a18(xb9c2cfae130d9256))
          return false;
      }
      return true;
    }

    internal override bool x2f61709eaa5ebf76
    {
      get
      {
        foreach (LayoutSystemBase layoutSystem in (CollectionBase) this.LayoutSystems)
        {
          if (!layoutSystem.x2f61709eaa5ebf76)
            return false;
        }
        return true;
      }
    }

    internal void x8e9e04a70e31e166()
    {
      if (this.DockContainer != null)
      {
        this.DockContainer.x7e9646eed248ed11();
        if (false)
        {
          if (false)
            ;
        }
        else
          goto label_4;
      }
      else
        goto label_4;
label_3:
      this.x7e9646eed248ed11((object) this, EventArgs.Empty);
      return;
label_4:
      if (this.x7e9646eed248ed11 != null)
        goto label_3;
    }

    internal void x3e0280cae730d1f2()
    {
      if (this.DockContainer != null)
        this.DockContainer.xec9697acef66c1bc((LayoutSystemBase) this, this.Bounds);
      if (this.DockContainer == null)
        return;
      this.DockContainer.Invalidate(this.Bounds);
    }

    internal override void x56e964269d48cfcc(DockContainer x0467b00af7810f0c)
    {
      base.x56e964269d48cfcc(x0467b00af7810f0c);
      foreach (LayoutSystemBase layoutSystem in (CollectionBase) this.LayoutSystems)
        layoutSystem.x56e964269d48cfcc(x0467b00af7810f0c);
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public SplitLayoutSystem.LayoutSystemBaseCollection LayoutSystems
    {
      get
      {
        return this.x820c504c9c557c92;
      }
    }

    private LayoutSystemBase[] x10878bfc002a3aaf(out int x10f4d88af727adbc)
    {
      x10f4d88af727adbc = 0;
      LayoutSystemBase[] layoutSystemBaseArray1 = new LayoutSystemBase[this.LayoutSystems.Count];
      IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
      try
      {
label_2:
        while (enumerator.MoveNext())
        {
          LayoutSystemBase current = (LayoutSystemBase) enumerator.Current;
          if (true)
          {
            int num1;
            while (!(current is ControlLayoutSystem))
            {
              int num2;
              if ((uint) num1 + (uint) num1 <= uint.MaxValue || (num2 | 3) != 0)
              {
                if (current is SplitLayoutSystem)
                {
                  if (true)
                  {
                    if (((SplitLayoutSystem) current).x7ca4fdcb31f9824a())
                    {
                      LayoutSystemBase[] layoutSystemBaseArray2 = layoutSystemBaseArray1;
                      num2 = x10f4d88af727adbc++;
                      int index = num2;
                      LayoutSystemBase layoutSystemBase = current;
                      layoutSystemBaseArray2[index] = layoutSystemBase;
                    }
                    else
                      goto label_2;
                  }
                  if ((num1 & 0) == 0)
                    goto label_2;
                  else
                    goto label_16;
                }
                else
                  goto label_2;
              }
            }
            if (!((ControlLayoutSystem) current).Collapsed || this.IsInContainer && !this.DockContainer.x0c2484ccd29b8358)
            {
              LayoutSystemBase[] layoutSystemBaseArray2 = layoutSystemBaseArray1;
              num1 = x10f4d88af727adbc++;
              int index = num1;
              LayoutSystemBase layoutSystemBase = current;
              layoutSystemBaseArray2[index] = layoutSystemBase;
            }
          }
        }
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
label_16:
      return layoutSystemBaseArray1;
    }

    protected internal override void Layout(
      RendererBase renderer,
      Graphics graphics,
      Rectangle bounds,
      bool floating)
    {
      base.Layout(renderer, graphics, bounds, floating);
      float num1;
      if ((uint) num1 - (uint) floating < 0U)
        goto label_44;
      else
        goto label_65;
label_1:
      int index1;
      int x10f4d88af727adbc;
      if (index1 >= x10f4d88af727adbc - 1)
        return;
      goto label_6;
label_4:
      this.x366d4cf7098f9c63.Add((object) bounds);
      ++index1;
      float num2;
      int index2;
      if ((uint) num2 + (uint) index2 < 0U)
        goto label_28;
      else
        goto label_1;
label_6:
      LayoutSystemBase[] layoutSystemBaseArray;
      bounds = layoutSystemBaseArray[index1].Bounds;
      int num3;
      int index3;
      if (this.xe36f4efbf268b3f1 != Orientation.Horizontal)
      {
        bounds.Offset(bounds.Width, 0);
        if ((index2 & 0) == 0)
        {
          if ((uint) num3 - (uint) num3 <= uint.MaxValue)
          {
            bounds.Width = 4;
            goto label_4;
          }
          else
          {
            if ((uint) index3 + (uint) index2 <= uint.MaxValue)
              return;
            goto label_58;
          }
        }
        else
          goto label_1;
      }
      else
      {
        bounds.Offset(0, bounds.Height);
        bounds.Height = 4;
        goto label_4;
      }
label_9:
      SizeF[] sizeFArray;
      int int32;
      if (index2 >= x10f4d88af727adbc)
      {
        index1 = 0;
        goto label_1;
      }
      else if (this.xe36f4efbf268b3f1 != Orientation.Horizontal)
      {
        int32 = Convert.ToInt32(sizeFArray[index2].Width);
        goto label_22;
      }
label_21:
      int32 = Convert.ToInt32(sizeFArray[index2].Height);
label_22:
      int num4 = Math.Max(int32, 4);
      int index4;
      int num5;
      if (this.xe36f4efbf268b3f1 != Orientation.Horizontal)
      {
        if (index2 == x10f4d88af727adbc - 1)
        {
          if ((index4 | -1) != 0)
            num4 = bounds.Right - num5;
          else
            goto label_51;
        }
        layoutSystemBaseArray[index2].Layout(renderer, graphics, new Rectangle(num5, bounds.Y, num4, bounds.Height), floating);
      }
      else
        goto label_17;
label_15:
      num5 += num4 + 4;
      float num6;
      float num7;
      if ((num4 | 8) != 0)
      {
        ++index2;
        goto label_9;
      }
      else if ((uint) num6 + (uint) num7 >= 0U)
        goto label_6;
      else
        goto label_1;
label_17:
      if (index2 == x10f4d88af727adbc - 1)
        num4 = bounds.Bottom - num5;
      layoutSystemBaseArray[index2].Layout(renderer, graphics, new Rectangle(bounds.X, num5, bounds.Width, num4), floating);
      if ((uint) index4 < 0U)
        goto label_25;
      else
        goto label_15;
label_24:
      num5 = this.xe36f4efbf268b3f1 == Orientation.Horizontal ? bounds.Y : bounds.X;
label_25:
      index2 = 0;
      int index5;
      if ((uint) index2 - (uint) floating >= 0U)
      {
        if ((uint) index5 <= uint.MaxValue)
          goto label_9;
      }
      else
        goto label_4;
label_27:
      sizeFArray[0].Width += num6;
      goto label_24;
label_28:
      if ((double) num3 != (double) num2)
      {
        num6 = (float) num3 - num2;
        index3 = 0;
        goto label_39;
      }
      else
        goto label_24;
label_29:
      sizeFArray[0].Height += num6;
      goto label_24;
label_34:
      if ((uint) num6 > uint.MaxValue)
        return;
label_35:
      while (index4 >= x10f4d88af727adbc)
      {
        num6 = (float) num3 - num2;
        if ((uint) index3 + (uint) index3 <= uint.MaxValue)
        {
          if (this.xe36f4efbf268b3f1 != Orientation.Horizontal)
          {
            if ((index3 | 3) == 0)
            {
              if ((uint) floating + (uint) num2 <= uint.MaxValue)
                goto label_41;
            }
            else
              goto label_27;
          }
          else
            goto label_29;
        }
        else if (true)
          goto label_29;
        else
          goto label_41;
      }
      num2 += this.xe36f4efbf268b3f1 == Orientation.Horizontal ? sizeFArray[index4].Height : sizeFArray[index4].Width;
      ++index4;
      goto label_34;
label_38:
      ++index3;
      if ((num5 | 1) == 0)
        goto label_9;
label_39:
      if (index3 >= x10f4d88af727adbc)
      {
        num2 = 0.0f;
        index4 = 0;
        if (((int) (uint) num6 | 3) != 0)
        {
          if ((uint) index1 <= uint.MaxValue)
            goto label_35;
          else
            goto label_29;
        }
      }
      else
      {
        float num8 = this.xe36f4efbf268b3f1 != Orientation.Horizontal ? sizeFArray[index3].Width : sizeFArray[index3].Height;
        num7 = num8 + num6 * (num8 / num2);
      }
label_41:
      if (this.xe36f4efbf268b3f1 != Orientation.Horizontal)
      {
        sizeFArray[index3].Width = num7;
        goto label_38;
      }
label_44:
      sizeFArray[index3].Height = num7;
      goto label_38;
label_51:
      for (; index5 < x10f4d88af727adbc; ++index5)
        num2 += this.xe36f4efbf268b3f1 == Orientation.Horizontal ? layoutSystemBaseArray[index5].WorkingSize.Height : layoutSystemBaseArray[index5].WorkingSize.Width;
      this.x366d4cf7098f9c63.Clear();
      if (num3 <= 0)
        return;
      if ((uint) index4 - (uint) num5 >= 0U)
      {
        sizeFArray = new SizeF[x10f4d88af727adbc];
        for (int index6 = 0; index6 < x10f4d88af727adbc; ++index6)
          sizeFArray[index6] = layoutSystemBaseArray[index6].WorkingSize;
        goto label_28;
      }
      else
        goto label_28;
label_55:
      int num9;
      num3 = num9;
      num2 = 0.0f;
      index5 = 0;
      goto label_51;
label_58:
      if ((uint) num5 - (uint) floating <= uint.MaxValue)
      {
        num9 = bounds.Height - (x10f4d88af727adbc - 1) * 4;
        goto label_55;
      }
      else
        goto label_4;
label_65:
      layoutSystemBaseArray = this.x10878bfc002a3aaf(out x10f4d88af727adbc);
      if (x10f4d88af727adbc == 0)
        return;
      if (true)
      {
        if (x10f4d88af727adbc > 1)
          goto label_60;
label_57:
        if (this.xe36f4efbf268b3f1 != Orientation.Horizontal)
        {
          num9 = bounds.Width - (x10f4d88af727adbc - 1) * 4;
          goto label_55;
        }
        else
          goto label_58;
label_60:
        int num8;
        int num10;
        if ((uint) num8 - (uint) num10 <= uint.MaxValue)
        {
          floating = false;
          goto label_57;
        }
        else
          goto label_34;
      }
      else
        goto label_21;
    }

    internal override void x84b6f3c22477dacb(
      RendererBase x38870620fd380a6b,
      Graphics x41347a961b838962,
      Font x26094932cf7a9139)
    {
      if (this.DockContainer == null)
        return;
      Control container = this.DockContainer.Manager == null ? (Control) null : this.DockContainer.Manager.DockSystemContainer;
      foreach (Rectangle bounds in this.x366d4cf7098f9c63)
        x38870620fd380a6b.DrawSplitter(container, (Control) this.DockContainer, x41347a961b838962, bounds, this.xe36f4efbf268b3f1);
      IEnumerator enumerator = this.LayoutSystems.GetEnumerator();
      try
      {
label_10:
        while (enumerator.MoveNext())
        {
          Region clip;
          do
          {
            LayoutSystemBase current = (LayoutSystemBase) enumerator.Current;
            if (current is ControlLayoutSystem && ((ControlLayoutSystem) current).Collapsed)
            {
              while (this.DockContainer.x0c2484ccd29b8358)
              {
                if (true)
                  goto label_10;
              }
            }
            clip = x41347a961b838962.Clip;
            x41347a961b838962.SetClip(current.Bounds);
            current.x84b6f3c22477dacb(x38870620fd380a6b, x41347a961b838962, x26094932cf7a9139);
          }
          while (false);
          x41347a961b838962.Clip = clip;
        }
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
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
      this.x367ada130c39f434();
      if ((double) x5c2440c931f8d932 <= 0.0 || (double) x4afa341b2323a009 <= 0.0)
        return;
      SizeF workingSize1 = xc13a8191724b6d55.WorkingSize;
      SizeF workingSize2 = x5aa50bbadb0a1e6c.WorkingSize;
      if ((uint) x5c2440c931f8d932 + (uint) x5c2440c931f8d932 < 0U)
        return;
      if (true)
        goto label_3;
label_2:
      xc13a8191724b6d55.WorkingSize = workingSize1;
      x5aa50bbadb0a1e6c.WorkingSize = workingSize2;
      this.x3e0280cae730d1f2();
      return;
label_3:
      if (this.SplitMode != Orientation.Horizontal)
      {
        workingSize1.Width = x5c2440c931f8d932;
        workingSize2.Width = x4afa341b2323a009;
        goto label_2;
      }
      else
      {
        workingSize1.Height = x5c2440c931f8d932;
        workingSize2.Height = x4afa341b2323a009;
        goto label_2;
      }
    }

    internal bool x7ca4fdcb31f9824a()
    {
      IEnumerator enumerator = this.x820c504c9c557c92.GetEnumerator();
      try
      {
label_3:
        do
        {
          bool flag;
          if (!enumerator.MoveNext())
          {
            if ((uint) flag >= 0U)
              break;
          }
          LayoutSystemBase current = (LayoutSystemBase) enumerator.Current;
          if (current is ControlLayoutSystem)
            goto label_15;
label_10:
          if (((SplitLayoutSystem) current).x7ca4fdcb31f9824a())
            return true;
          if (true)
            continue;
label_13:
          if ((uint) flag + (uint) flag >= 0U && !this.IsInContainer)
          {
            if (true)
            {
              while (true)
              {
                if (((flag ? 1 : 0) & 0) != 0)
                {
                  if ((uint) flag - (uint) flag < 0U)
                    goto label_3;
                }
                else
                  goto label_3;
              }
            }
            else
              continue;
          }
          if (this.DockContainer.x0c2484ccd29b8358)
          {
            if (false)
              goto label_10;
            else
              continue;
          }
label_14:
          return true;
label_15:
          if (!((ControlLayoutSystem) current).Collapsed)
            goto label_14;
          else
            goto label_13;
        }
        while (true);
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
      return false;
    }

    public class LayoutSystemBaseCollection : CollectionBase
    {
      private SplitLayoutSystem xb6a159a84cb992d6;
      internal bool xd7a3953bce504b63;

      internal LayoutSystemBaseCollection(SplitLayoutSystem parent)
      {
        this.xb6a159a84cb992d6 = parent;
      }

      private void x8e9e04a70e31e166()
      {
        this.xb6a159a84cb992d6.x8e9e04a70e31e166();
      }

      protected override void OnClear()
      {
        base.OnClear();
        foreach (LayoutSystemBase layoutSystemBase in (CollectionBase) this)
        {
          layoutSystemBase.xb6a159a84cb992d6 = (SplitLayoutSystem) null;
          layoutSystemBase.x56e964269d48cfcc((DockContainer) null);
        }
      }

      protected override void OnClearComplete()
      {
        base.OnClearComplete();
        if (this.xd7a3953bce504b63)
          return;
        this.x8e9e04a70e31e166();
      }

      protected override void OnInsertComplete(int index, object value)
      {
        base.OnInsertComplete(index, value);
        LayoutSystemBase layoutSystemBase = (LayoutSystemBase) value;
        do
        {
          layoutSystemBase.xb6a159a84cb992d6 = this.xb6a159a84cb992d6;
        }
        while (false);
        layoutSystemBase.x56e964269d48cfcc(this.xb6a159a84cb992d6.DockContainer);
        if (this.xd7a3953bce504b63)
          return;
        this.x8e9e04a70e31e166();
      }

      protected override void OnRemoveComplete(int index, object value)
      {
        base.OnRemoveComplete(index, value);
        ((LayoutSystemBase) value).xb6a159a84cb992d6 = (SplitLayoutSystem) null;
        ((LayoutSystemBase) value).x56e964269d48cfcc((DockContainer) null);
        if (this.xd7a3953bce504b63)
          return;
        if (this.Count <= 1)
        {
          while (this.xb6a159a84cb992d6.xb6a159a84cb992d6 != null)
          {
            SplitLayoutSystem xb6a159a84cb992d6;
            LayoutSystemBase layoutSystem;
            do
            {
              xb6a159a84cb992d6 = this.xb6a159a84cb992d6.xb6a159a84cb992d6;
              if (this.Count == 1)
              {
                layoutSystem = this[0];
                this.xd7a3953bce504b63 = true;
                this.Remove(layoutSystem);
              }
              else
                goto label_7;
            }
            while ((uint) index < 0U);
            goto label_8;
label_7:
            int num;
            if ((num | 3) != 0)
              goto label_4;
label_3:
            if (this.Count != 0)
              return;
            goto label_6;
label_4:
            if (true)
            {
              if (true)
                goto label_3;
            }
            else
              continue;
label_6:
            xb6a159a84cb992d6.LayoutSystems.Remove((LayoutSystemBase) this.xb6a159a84cb992d6);
            return;
label_8:
            this.xd7a3953bce504b63 = false;
            xb6a159a84cb992d6.LayoutSystems.xd7a3953bce504b63 = true;
            int index1 = xb6a159a84cb992d6.LayoutSystems.IndexOf((LayoutSystemBase) this.xb6a159a84cb992d6);
            xb6a159a84cb992d6.LayoutSystems.Remove((LayoutSystemBase) this.xb6a159a84cb992d6);
            xb6a159a84cb992d6.LayoutSystems.Insert(index1, layoutSystem);
            xb6a159a84cb992d6.LayoutSystems.xd7a3953bce504b63 = false;
            xb6a159a84cb992d6.x8e9e04a70e31e166();
            return;
          }
        }
        this.x8e9e04a70e31e166();
      }

      public void AddRange(LayoutSystemBase[] layoutSystems)
      {
        this.xd7a3953bce504b63 = true;
        LayoutSystemBase[] layoutSystemBaseArray = layoutSystems;
        if (false)
          goto label_4;
        else
          goto label_3;
label_1:
        int index;
        if (index >= layoutSystemBaseArray.Length)
        {
          this.xd7a3953bce504b63 = false;
          this.x8e9e04a70e31e166();
          if (true)
            return;
        }
        else
          goto label_4;
label_3:
        index = 0;
        goto label_1;
label_4:
        this.Add(layoutSystemBaseArray[index]);
        ++index;
        goto label_1;
      }

      public int Add(LayoutSystemBase layoutSystem)
      {
        int count = this.Count;
        this.Insert(count, layoutSystem);
        return count;
      }

      public void Insert(int index, LayoutSystemBase layoutSystem)
      {
        if (layoutSystem.xb6a159a84cb992d6 != null)
          throw new ArgumentException("Layout system already has a parent. You must first remove it from its parent.");
        this.List.Insert(index, (object) layoutSystem);
      }

      public LayoutSystemBase this[int index]
      {
        get
        {
          return (LayoutSystemBase) this.List[index];
        }
      }

      public void Remove(LayoutSystemBase layoutSystem)
      {
        this.List.Remove((object) layoutSystem);
      }

      public bool Contains(LayoutSystemBase layoutSystem)
      {
        return this.List.Contains((object) layoutSystem);
      }

      public int IndexOf(LayoutSystemBase layoutSystem)
      {
        return this.List.IndexOf((object) layoutSystem);
      }

      public void CopyTo(LayoutSystemBase[] array, int index)
      {
        this.List.CopyTo((Array) array, index);
      }
    }
  }
}
