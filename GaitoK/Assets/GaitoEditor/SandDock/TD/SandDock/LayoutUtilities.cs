// Decompiled with JetBrains decompiler
// Type: TD.SandDock.LayoutUtilities
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Collections;
using System.Windows.Forms;

namespace TD.SandDock
{
  public sealed class LayoutUtilities
  {
    private static int x9b1e2b1c391ceb59;

    private LayoutUtilities()
    {
    }

    internal static void x3a04ba0cdf69aff2()
    {
      ++LayoutUtilities.x9b1e2b1c391ceb59;
    }

    internal static void x861aa05d0acfeb39()
    {
      if (LayoutUtilities.x9b1e2b1c391ceb59 <= 0)
        return;
      --LayoutUtilities.x9b1e2b1c391ceb59;
    }

    internal static bool x12627d27d864cd19
    {
      get
      {
        return LayoutUtilities.x9b1e2b1c391ceb59 > 0;
      }
    }

    internal static DockSituation x8d287cc6f0a2f529(DockContainer xd3311d815ca25f02)
    {
      if (xd3311d815ca25f02 == null)
        return DockSituation.None;
      if (xd3311d815ca25f02.IsFloating)
        return DockSituation.Floating;
      return xd3311d815ca25f02.Dock == DockStyle.Fill ? DockSituation.Document : DockSituation.Docked;
    }

    internal static ControlLayoutSystem[] x1494f515233a1246(
      DockContainer xd3311d815ca25f02)
    {
      ArrayList arrayList = new ArrayList();
      IEnumerator enumerator = xd3311d815ca25f02.x83627743ea4ce5a2.GetEnumerator();
      try
      {
label_2:
        do
        {
          LayoutSystemBase current;
          do
          {
            if (!enumerator.MoveNext())
            {
              if (true)
                goto label_9;
            }
            current = (LayoutSystemBase) enumerator.Current;
          }
          while (!(current is ControlLayoutSystem));
          arrayList.Add((object) current);
        }
        while (false);
        goto label_2;
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
label_9:
      return (ControlLayoutSystem[]) arrayList.ToArray(typeof (ControlLayoutSystem));
    }

    internal static ControlLayoutSystem xba5fd484c0e6478b(
      SandDockManager x91f347c6e97f1846,
      DockSituation xd39eba9a9a1b028e,
      x129cb2a2bdfd0ab2 xfffbdea061bfa120)
    {
      int index1;
      DockContainer[] dockContainers1;
      int index2;
      ControlLayoutSystem[] controlLayoutSystemArray1;
      int index3;
      DockContainer[] dockContainers2;
      switch (xd39eba9a9a1b028e)
      {
        case DockSituation.Docked:
          dockContainers2 = x91f347c6e97f1846.GetDockContainers();
          index3 = 0;
          goto label_26;
        case DockSituation.Document:
          if (x91f347c6e97f1846.DocumentContainer != null)
          {
            controlLayoutSystemArray1 = LayoutUtilities.x1494f515233a1246((DockContainer) x91f347c6e97f1846.DocumentContainer);
            if (true)
            {
              index2 = 0;
              goto label_21;
            }
            else
              goto label_29;
          }
          else
            break;
        case DockSituation.Floating:
          dockContainers1 = x91f347c6e97f1846.GetDockContainers();
          int num1;
          if ((uint) num1 + (uint) num1 >= 0U)
          {
            index1 = 0;
            goto label_4;
          }
          else
            goto label_21;
        default:
          throw new InvalidOperationException();
      }
label_2:
      return (ControlLayoutSystem) null;
label_3:
      ++index1;
label_4:
      DockContainer xd3311d815ca25f02_1;
      if (index1 < dockContainers1.Length)
        xd3311d815ca25f02_1 = dockContainers1[index1];
      else
        goto label_2;
label_6:
      int index4;
      ControlLayoutSystem[] controlLayoutSystemArray2;
      if (LayoutUtilities.x8d287cc6f0a2f529(xd3311d815ca25f02_1) != xd39eba9a9a1b028e)
      {
        if (true)
          goto label_3;
        else
          goto label_44;
      }
      else
      {
        controlLayoutSystemArray2 = LayoutUtilities.x1494f515233a1246(xd3311d815ca25f02_1);
        if ((uint) index4 + (uint) index2 >= 0U)
          index4 = 0;
        else
          goto label_44;
      }
label_8:
      if (index4 >= controlLayoutSystemArray2.Length)
      {
        if (true)
        {
          if ((uint) index1 - (uint) index2 <= uint.MaxValue)
            goto label_3;
          else
            goto label_6;
        }
        else
          goto label_40;
      }
label_14:
      ControlLayoutSystem controlLayoutSystem1 = controlLayoutSystemArray2[index4];
      ControlLayoutSystem controlLayoutSystem2;
      if (!(controlLayoutSystem1.x0217cda8370c1f17 == xfffbdea061bfa120.x703937d70a13725c))
      {
        ++index4;
        goto label_8;
      }
      else
      {
        controlLayoutSystem2 = controlLayoutSystem1;
        goto label_44;
      }
label_19:
      for (; index2 < controlLayoutSystemArray1.Length; ++index2)
      {
        ControlLayoutSystem controlLayoutSystem3 = controlLayoutSystemArray1[index2];
        if (controlLayoutSystem3.x0217cda8370c1f17 == xfffbdea061bfa120.x703937d70a13725c)
        {
          controlLayoutSystem2 = controlLayoutSystem3;
          goto label_44;
        }
      }
      goto label_2;
label_21:
      int num2;
      int num3;
      if ((uint) num2 - (uint) num3 < 0U)
        goto label_29;
      else
        goto label_19;
label_26:
      DockContainer xd3311d815ca25f02_2;
      if (index3 < dockContainers2.Length)
      {
        xd3311d815ca25f02_2 = dockContainers2[index3];
        goto label_30;
      }
      else
        goto label_2;
label_28:
      if (false)
        goto label_30;
label_29:
      ++index3;
      if (false)
      {
        if (false)
          goto label_19;
        else
          goto label_28;
      }
      else
        goto label_26;
label_30:
      if (LayoutUtilities.x8d287cc6f0a2f529(xd3311d815ca25f02_2) != xd39eba9a9a1b028e && (uint) index1 + (uint) index3 <= uint.MaxValue)
        goto label_29;
label_40:
      int index5;
      do
      {
        ControlLayoutSystem[] controlLayoutSystemArray3 = LayoutUtilities.x1494f515233a1246(xd3311d815ca25f02_2);
        do
        {
          for (index5 = 0; index5 < controlLayoutSystemArray3.Length; ++index5)
          {
            ControlLayoutSystem controlLayoutSystem3 = controlLayoutSystemArray3[index5];
            if (controlLayoutSystem3.x0217cda8370c1f17 == xfffbdea061bfa120.x703937d70a13725c)
            {
              controlLayoutSystem2 = controlLayoutSystem3;
              goto label_44;
            }
          }
          if ((uint) index3 - (uint) index2 <= uint.MaxValue)
            goto label_28;
        }
        while ((uint) index3 < 0U);
      }
      while ((uint) index5 + (uint) index1 < 0U);
      if ((index4 & 0) == 0)
      {
        if ((index3 | 1) != 0)
          goto label_30;
        else
          goto label_29;
      }
      else
        goto label_14;
label_44:
      return controlLayoutSystem2;
    }

    internal static int[] x27f6597db2aeb7d7(ControlLayoutSystem x5d3b2a2c534d6d79)
    {
      ArrayList arrayList = new ArrayList();
      LayoutSystemBase layoutSystem = (LayoutSystemBase) x5d3b2a2c534d6d79;
label_3:
      if (layoutSystem != null)
      {
        while (layoutSystem.Parent != null)
        {
          arrayList.Add((object) layoutSystem.Parent.LayoutSystems.IndexOf(layoutSystem));
          if (true)
            break;
        }
        do
        {
          layoutSystem = (LayoutSystemBase) layoutSystem.Parent;
        }
        while (false);
        goto label_3;
      }
      else
      {
        arrayList.Reverse();
        return (int[]) arrayList.ToArray(typeof (int));
      }
    }

    internal static DockStyle xf8330a3964a419ba(ContainerDockLocation x9c911703d455884e)
    {
      ContainerDockLocation containerDockLocation = x9c911703d455884e;
      if (true)
        goto label_5;
label_4:
      return DockStyle.Left;
label_5:
      switch (containerDockLocation)
      {
        case ContainerDockLocation.Left:
          goto label_4;
        case ContainerDockLocation.Right:
          return DockStyle.Right;
        case ContainerDockLocation.Top:
          return DockStyle.Top;
        case ContainerDockLocation.Bottom:
          return DockStyle.Bottom;
        default:
          return DockStyle.Fill;
      }
    }

    internal static ContainerDockLocation x3650f3b579b2b4d2(
      DockStyle xca9af438b5818619)
    {
      switch (xca9af438b5818619)
      {
        case DockStyle.Top:
          return ContainerDockLocation.Top;
        case DockStyle.Bottom:
          return ContainerDockLocation.Bottom;
        case DockStyle.Left:
          return ContainerDockLocation.Left;
        case DockStyle.Right:
          return ContainerDockLocation.Right;
        default:
          return ContainerDockLocation.Center;
      }
    }

    public static ControlLayoutSystem FindControlLayoutSystem(
      DockContainer container)
    {
      foreach (LayoutSystemBase layoutSystemBase in container.x83627743ea4ce5a2)
      {
        if (layoutSystemBase is ControlLayoutSystem)
          return (ControlLayoutSystem) layoutSystemBase;
      }
      return (ControlLayoutSystem) null;
    }

    internal static void xa7513d57b4844d46(Control x43bec302f92080b9)
    {
      if (x43bec302f92080b9.Parent != null)
        goto label_26;
      else
        goto label_29;
label_1:
      ((DockControl) x43bec302f92080b9).xadad18dc04073a00 = true;
      goto label_3;
label_2:
      if (x43bec302f92080b9 is DockControl)
        goto label_1;
label_3:
      try
      {
        IContainerControl containerControl = x43bec302f92080b9.Parent.GetContainerControl();
        if (true)
          goto label_16;
        else
          goto label_10;
label_4:
        if (true)
          goto label_6;
label_5:
        if (containerControl != null)
          goto label_18;
label_6:
        x43bec302f92080b9.Parent.Controls.Remove(x43bec302f92080b9);
        return;
label_7:
        if (containerControl.ActiveControl == x43bec302f92080b9)
        {
          if (true)
          {
            containerControl.ActiveControl = (Control) null;
            goto label_4;
          }
          else
            goto label_4;
        }
        else
          goto label_6;
label_10:
        DockContainer xd3311d815ca25f02;
        if (xd3311d815ca25f02.Manager.OwnerForm != null)
        {
          while (xd3311d815ca25f02.Manager.OwnerForm.IsMdiContainer)
          {
            LayoutUtilities.xf96eb78473d85a37(xd3311d815ca25f02, xd3311d815ca25f02.LayoutSystem);
            if (true)
              goto label_6;
          }
          goto label_7;
        }
        else
          goto label_7;
label_14:
        if (xd3311d815ca25f02 != null && xd3311d815ca25f02.Manager != null)
        {
          if (false)
            return;
          goto label_10;
        }
        else
          goto label_7;
label_16:
        if (false)
        {
          if (false)
          {
            if (true)
            {
              if (true)
                goto label_7;
              else
                goto label_4;
            }
            else
              goto label_14;
          }
        }
        else
          goto label_5;
label_18:
        xd3311d815ca25f02 = containerControl as DockContainer;
        goto label_14;
      }
      finally
      {
        if (x43bec302f92080b9 is DockControl)
          ((DockControl) x43bec302f92080b9).xadad18dc04073a00 = false;
      }
label_26:
      if (x43bec302f92080b9.ContainsFocus)
      {
        x43bec302f92080b9.Parent.Focus();
        goto label_2;
      }
label_27:
      if (false)
      {
        if (false)
          return;
        goto label_1;
      }
      else
        goto label_2;
label_29:
      if (false)
        goto label_27;
    }

    private static bool xf96eb78473d85a37(
      DockContainer xd3311d815ca25f02,
      SplitLayoutSystem xb25822984a90695b)
    {
      foreach (LayoutSystemBase layoutSystem in (CollectionBase) xb25822984a90695b.LayoutSystems)
      {
        if (!(layoutSystem is SplitLayoutSystem))
          goto label_7;
        else
          goto label_9;
label_4:
        ControlLayoutSystem controlLayoutSystem;
        if (controlLayoutSystem.SelectedControl.Visible && controlLayoutSystem.SelectedControl.Enabled)
        {
          xd3311d815ca25f02.ActiveControl = (Control) controlLayoutSystem.SelectedControl;
          return true;
        }
        continue;
label_7:
        controlLayoutSystem = (ControlLayoutSystem) layoutSystem;
        if (controlLayoutSystem.Collapsed || !xd3311d815ca25f02.Controls.Contains((Control) controlLayoutSystem.SelectedControl))
          continue;
        goto label_4;
label_9:
        bool flag = LayoutUtilities.xf96eb78473d85a37(xd3311d815ca25f02, (SplitLayoutSystem) layoutSystem);
        if (((flag ? 1 : 0) & 0) == 0)
        {
          if (flag)
            return true;
        }
        else
          goto label_4;
      }
      return false;
    }

    internal static void x4487f2f8917e3fd0(ControlLayoutSystem x6e150040c8d97700)
    {
      if (x6e150040c8d97700 == null)
        throw new ArgumentNullException();
      DockContainer dockContainer = x6e150040c8d97700.DockContainer;
      if (x6e150040c8d97700.x10ac79a4257c7f52 != null)
        goto label_22;
      else
        goto label_15;
label_1:
      if (!dockContainer.x61d88745bde7a5ec())
        return;
      goto label_8;
label_3:
      if (x6e150040c8d97700.Parent == null)
        return;
      goto label_17;
label_7:
      dockContainer.Dispose();
      return;
label_8:
      if (!(dockContainer is DocumentContainer))
        goto label_7;
label_9:
      if (dockContainer.Manager != null && dockContainer.Manager.EnableEmptyEnvironment)
        return;
      goto label_7;
label_15:
      if (false)
      {
        if (false)
        {
          if (false)
          {
            if (false)
              goto label_3;
            else
              goto label_8;
          }
          else
            goto label_1;
        }
      }
      else
        goto label_3;
label_17:
      x6e150040c8d97700.Parent.LayoutSystems.Remove((LayoutSystemBase) x6e150040c8d97700);
      if (dockContainer == null)
      {
        if (true)
        {
          if (false)
            goto label_1;
        }
        else if (true)
          goto label_1;
        if (true)
          return;
        goto label_9;
      }
      else
        goto label_1;
label_22:
      if (x6e150040c8d97700.x10ac79a4257c7f52.x23498f53d87354d4 == x6e150040c8d97700)
      {
        x6e150040c8d97700.x10ac79a4257c7f52.xcdb145600c1b7224(true);
        if (false)
          goto label_9;
        else
          goto label_3;
      }
      else
        goto label_3;
    }

    internal static void xf1cbd48a28ce6e74(DockControl x43bec302f92080b9)
    {
      if (x43bec302f92080b9 == null)
        throw new ArgumentNullException();
      ControlLayoutSystem layoutSystem = x43bec302f92080b9.LayoutSystem;
      bool flag;
      if (((flag ? 1 : 0) & 0) != 0 || layoutSystem == null)
        return;
      DockContainer dockContainer = layoutSystem.DockContainer;
      bool containsFocus = x43bec302f92080b9.ContainsFocus;
      if (false)
        goto label_4;
      else
        goto label_15;
label_1:
      if (!containsFocus)
        return;
      if (x43bec302f92080b9.Manager == null)
      {
        if (((containsFocus ? 1 : 0) | 4) != 0)
          return;
      }
      else
        goto label_9;
label_7:
      DockControl recentlyUsedWindow = x43bec302f92080b9.Manager.FindMostRecentlyUsedWindow(~DockSituation.None, x43bec302f92080b9);
      goto label_8;
label_9:
      recentlyUsedWindow = x43bec302f92080b9.Manager.FindMostRecentlyUsedWindow(DockSituation.Document, x43bec302f92080b9);
      if (recentlyUsedWindow != null)
        goto label_8;
      else
        goto label_7;
label_3:
      recentlyUsedWindow.x6d1b64d6c637a91d(true);
      return;
label_4:
      if (true)
      {
        if (false)
          goto label_3;
        else
          goto label_1;
      }
label_8:
      if (recentlyUsedWindow == null)
        return;
      goto label_3;
label_15:
      if (containsFocus)
        goto label_16;
label_12:
      layoutSystem.Controls.Remove(x43bec302f92080b9);
      while (layoutSystem.Controls.Count == 0)
      {
        LayoutUtilities.x4487f2f8917e3fd0(layoutSystem);
        if (true)
          break;
      }
      goto label_1;
label_16:
      Form form = x43bec302f92080b9.FindForm();
      if ((uint) containsFocus + (uint) containsFocus < 0U || form != null)
      {
        form.ActiveControl = (Control) null;
        goto label_12;
      }
      else
        goto label_12;
    }

    internal static int xc6fb69ef430eaa44(DockContainer x0467b00af7810f0c)
    {
      return (x0467b00af7810f0c.AllowResize ? 4 : 0) + LayoutUtilities.xd47535e893e9796b(x0467b00af7810f0c.LayoutSystem, x0467b00af7810f0c.x61c108cc44ef385a ? Orientation.Vertical : Orientation.Horizontal) * 5;
    }

    private static int xd47535e893e9796b(
      SplitLayoutSystem x6e150040c8d97700,
      Orientation xf65758d54b79fc7a)
    {
      int val1 = 0;
      foreach (LayoutSystemBase layoutSystem in (CollectionBase) x6e150040c8d97700.LayoutSystems)
      {
        int num;
        if ((uint) num - (uint) num >= 0U)
          goto label_11;
label_8:
        SplitLayoutSystem x6e150040c8d97700_1;
        if (x6e150040c8d97700_1 != null)
        {
          val1 = Math.Max(val1, LayoutUtilities.xd47535e893e9796b(x6e150040c8d97700_1, xf65758d54b79fc7a));
          continue;
        }
        continue;
label_11:
        x6e150040c8d97700_1 = layoutSystem as SplitLayoutSystem;
        goto label_8;
      }
      int num1 = val1;
      while (x6e150040c8d97700.LayoutSystems.Count > 1)
      {
        if ((uint) val1 + (uint) val1 <= uint.MaxValue)
        {
          if ((uint) val1 - (uint) num1 <= uint.MaxValue)
            goto label_5;
        }
        else
          goto label_17;
label_4:
        if (false)
          continue;
label_5:
        if (x6e150040c8d97700.SplitMode != xf65758d54b79fc7a)
          break;
label_6:
        num1 += x6e150040c8d97700.LayoutSystems.Count - 1;
        if ((num1 | 15) == 0)
          goto label_4;
        else
          break;
label_17:
        if ((uint) num1 >= 0U)
          goto label_5;
        else
          goto label_6;
      }
      return num1;
    }

    internal static x5678bb8d80c0f12e x4689c8634e31fc55(
      SandDockManager x91f347c6e97f1846,
      WindowMetaData xfffbdea061bfa120)
    {
      DockContainer[] dockContainers = x91f347c6e97f1846.GetDockContainers(LayoutUtilities.xf8330a3964a419ba(xfffbdea061bfa120.LastFixedDockSide));
      if (dockContainers.Length != 0)
        goto label_12;
      else
        goto label_15;
label_3:
      if (dockContainers.Length != 0)
        return LayoutUtilities.x2f8f74d308cc9f3f(dockContainers[0], xfffbdea061bfa120.xe62a3d24e0fde928.x61743036ad30763d);
      return new x5678bb8d80c0f12e(x91f347c6e97f1846.CreateNewDockContainer(xfffbdea061bfa120.LastFixedDockSide, ContainerDockEdge.Inside, xfffbdea061bfa120.DockedContentSize).LayoutSystem, 0);
label_12:
      if (dockContainers.Length < xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e || xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 >= dockContainers.Length)
        goto label_5;
      else
        goto label_11;
label_1:
      if (xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 == xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e - 1)
        return new x5678bb8d80c0f12e(x91f347c6e97f1846.CreateNewDockContainer(xfffbdea061bfa120.LastFixedDockSide, ContainerDockEdge.Inside, xfffbdea061bfa120.DockedContentSize).LayoutSystem, 0);
      goto label_3;
label_5:
      if (xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e >= 2)
      {
        if (xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 == 0)
          return new x5678bb8d80c0f12e(x91f347c6e97f1846.CreateNewDockContainer(xfffbdea061bfa120.LastFixedDockSide, ContainerDockEdge.Outside, xfffbdea061bfa120.DockedContentSize).LayoutSystem, 0);
        goto label_1;
      }
      else
        goto label_3;
label_11:
      if (xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 != -1)
        return LayoutUtilities.x2f8f74d308cc9f3f(dockContainers[xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557], xfffbdea061bfa120.xe62a3d24e0fde928.x61743036ad30763d);
      if (false)
        goto label_1;
      else
        goto label_5;
label_15:
      while (true)
      {
        if (true)
          return new x5678bb8d80c0f12e(x91f347c6e97f1846.CreateNewDockContainer(xfffbdea061bfa120.LastFixedDockSide, ContainerDockEdge.Inside, xfffbdea061bfa120.DockedContentSize).LayoutSystem, 0);
      }
      goto label_3;
    }

    internal static x5678bb8d80c0f12e x2f8f74d308cc9f3f(
      DockContainer xd3311d815ca25f02,
      int[] x27bf3f6bb3609d15)
    {
      SplitLayoutSystem splitLayoutSystem = xd3311d815ca25f02.LayoutSystem;
      int[] numArray = x27bf3f6bb3609d15;
      for (int index1 = 0; index1 < numArray.Length; ++index1)
      {
        int index2 = numArray[index1];
        if ((uint) index1 + (uint) index1 >= 0U)
          goto label_7;
        else
          goto label_9;
label_5:
        SplitLayoutSystem layoutSystem = splitLayoutSystem.LayoutSystems[index2] as SplitLayoutSystem;
        x5678bb8d80c0f12e x5678bb8d80c0f12e;
        if (layoutSystem != null)
        {
          splitLayoutSystem = layoutSystem;
          if ((uint) index1 - (uint) index1 >= 0U)
            continue;
          goto label_11;
        }
        else
        {
          x5678bb8d80c0f12e = new x5678bb8d80c0f12e(splitLayoutSystem, index2);
          goto label_11;
        }
label_7:
        if (index2 >= splitLayoutSystem.LayoutSystems.Count)
          goto label_10;
        else
          goto label_5;
label_9:
        if (false)
          goto label_5;
label_10:
        x5678bb8d80c0f12e = new x5678bb8d80c0f12e(splitLayoutSystem, splitLayoutSystem.LayoutSystems.Count);
label_11:
        return x5678bb8d80c0f12e;
      }
      return new x5678bb8d80c0f12e(xd3311d815ca25f02.LayoutSystem, 0);
    }
  }
}
