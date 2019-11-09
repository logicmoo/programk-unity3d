// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x410f3612b9a8f9de
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace TD.SandDock
{
  internal class x410f3612b9a8f9de : DockContainer
  {
    private bool x50765ed4559630d6 = true;
    private const int x339acab5bf3e83ae = 64;
    private const int x77bf04ec211c4a37 = 16;
    private const int xdbb7427772b219d6 = 128;
    private const int x4c4ed64783077b76 = 4;
    private TD.SandDock.xd936980ea1aac341 xa6607dfd4b3038ad;
    private ControlLayoutSystem x6fd7c9ad69859c3e;
    private Guid xb51cd75f17ace1ec;

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(
      HandleRef hWnd,
      HandleRef hWndInsertAfter,
      int x,
      int y,
      int cx,
      int cy,
      int flags);

    [DllImport("user32.dll")]
    private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

    public x410f3612b9a8f9de(SandDockManager manager, Guid guid)
    {
      if (manager == null)
        throw new ArgumentNullException(nameof (manager));
      this.xa6607dfd4b3038ad = new TD.SandDock.xd936980ea1aac341(this);
      this.xa6607dfd4b3038ad.Activated += new EventHandler(((DockContainer) this).xa2414c47d888068e);
      this.xa6607dfd4b3038ad.Deactivate += new EventHandler(((DockContainer) this).x19e788b09b195d4f);
      this.xa6607dfd4b3038ad.Closing += new CancelEventHandler(this.x9218bee68262250e);
      do
      {
        this.xa6607dfd4b3038ad.DoubleClick += new EventHandler(this.xe1f5f125062dc4fb);
        this.LayoutSystem.x7e9646eed248ed11 += new EventHandler(this.x8e9e04a70e31e166);
        if (true)
          goto label_4;
label_1:
        this.Manager = manager;
        this.xb51cd75f17ace1ec = guid;
        continue;
label_4:
        this.x8e9e04a70e31e166((object) this.LayoutSystem, EventArgs.Empty);
        if (true)
          goto label_1;
        else
          goto label_7;
      }
      while (false);
      this.xa6607dfd4b3038ad.Controls.Add((Control) this);
      this.Dock = DockStyle.Fill;
      return;
label_7:;
    }

    public Guid x0217cda8370c1f17
    {
      get
      {
        return this.xb51cd75f17ace1ec;
      }
    }

    internal override bool x0c2484ccd29b8358
    {
      get
      {
        return false;
      }
    }

    public override SplitLayoutSystem LayoutSystem
    {
      get
      {
        return base.LayoutSystem;
      }
      set
      {
        this.LayoutSystem.x7e9646eed248ed11 -= new EventHandler(this.x8e9e04a70e31e166);
        base.LayoutSystem = value;
        this.LayoutSystem.x7e9646eed248ed11 += new EventHandler(this.x8e9e04a70e31e166);
        this.x8e9e04a70e31e166((object) this.LayoutSystem, EventArgs.Empty);
      }
    }

    public override SandDockManager Manager
    {
      get
      {
        return base.Manager;
      }
      set
      {
        if (this.Manager == null)
          goto label_15;
label_13:
        if (this.Manager.OwnerForm != null)
          this.Manager.OwnerForm.RemoveOwnedForm((Form) this.xa6607dfd4b3038ad);
label_15:
        base.Manager = value;
        if (this.Manager == null)
          return;
        if (false)
          goto label_7;
        else
          goto label_17;
label_2:
        if (true)
        {
          if (true)
            return;
          goto label_13;
        }
label_6:
        if (this.Manager.OwnerForm != null)
          goto label_10;
label_7:
        if (true)
          return;
        if (true)
        {
          if (true)
            goto label_18;
          else
            goto label_13;
        }
label_9:
        if (true)
          goto label_6;
label_10:
        do
        {
          this.Manager.OwnerForm.AddOwnedForm((Form) this.xa6607dfd4b3038ad);
        }
        while (false);
        this.Font = new Font(this.Manager.OwnerForm.Font, this.Manager.OwnerForm.Font.Style);
        if (true)
          goto label_2;
        else
          goto label_6;
label_17:
        if (true)
          goto label_9;
label_18:
        if (true)
          goto label_2;
      }
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        goto label_2;
label_1:
      base.Dispose(disposing);
      return;
label_2:
      while (!this.IsDisposed)
      {
        this.LayoutSystem.x7e9646eed248ed11 -= new EventHandler(this.x8e9e04a70e31e166);
        this.xa6607dfd4b3038ad.Activated -= new EventHandler(((DockContainer) this).xa2414c47d888068e);
        this.xa6607dfd4b3038ad.Deactivate -= new EventHandler(((DockContainer) this).x19e788b09b195d4f);
        this.xa6607dfd4b3038ad.Closing -= new CancelEventHandler(this.x9218bee68262250e);
        this.xa6607dfd4b3038ad.DoubleClick -= new EventHandler(this.xe1f5f125062dc4fb);
        LayoutUtilities.xa7513d57b4844d46((Control) this);
        this.xa6607dfd4b3038ad.Dispose();
        if (true)
          break;
      }
      goto label_1;
    }

    public void x35579b297303ed43()
    {
      this.xa6607dfd4b3038ad.Show();
    }

    public void x5486e0b5e830d25c()
    {
      this.xa6607dfd4b3038ad.Hide();
    }

    public Form xd936980ea1aac341
    {
      get
      {
        return (Form) this.xa6607dfd4b3038ad;
      }
    }

    public Rectangle x5de6fa99acd93adb
    {
      get
      {
        return this.xa6607dfd4b3038ad.Bounds;
      }
    }

    public void x159713d3b60fae0c(
      Rectangle xda73fcb97c77d998,
      bool x789c645a15deb49b,
      bool x17cc8f73454a0462)
    {
      int flags = 0;
      while (x789c645a15deb49b)
      {
        flags |= 64;
        if (true)
        {
          if ((uint) flags - (uint) x789c645a15deb49b >= 0U)
            goto label_10;
        }
        else
          break;
      }
      flags |= 128;
label_10:
      if (!x17cc8f73454a0462)
        flags |= 16;
      x410f3612b9a8f9de.SetWindowPos(new HandleRef((object) this, this.xa6607dfd4b3038ad.Handle), new HandleRef((object) this, IntPtr.Zero), xda73fcb97c77d998.X, xda73fcb97c77d998.Y, xda73fcb97c77d998.Width, xda73fcb97c77d998.Height, flags);
      this.xa6607dfd4b3038ad.Visible = x789c645a15deb49b;
      if (!x789c645a15deb49b)
        return;
      foreach (Control control in (ArrangedElementCollection) this.xa6607dfd4b3038ad.Controls)
        control.Visible = true;
    }

    public System.Drawing.Size xb1090c5821a633b5
    {
      get
      {
        return this.xa6607dfd4b3038ad.Size;
      }
      set
      {
        this.xa6607dfd4b3038ad.Size = value;
      }
    }

    public System.Drawing.Point x12992900724b93dc
    {
      get
      {
        return this.xa6607dfd4b3038ad.Location;
      }
      set
      {
        this.xa6607dfd4b3038ad.Location = value;
      }
    }

    private void xe20c835979d60df8(DockControl x321bff1c322e5433, DockControl x31b34ee91c89cf69)
    {
      if (x31b34ee91c89cf69 != null)
        this.xa6607dfd4b3038ad.Text = x31b34ee91c89cf69.Text;
      else
        this.xa6607dfd4b3038ad.Text = "";
    }

    public void xd1bdd0ee5924b59e()
    {
      this.x8e9e04a70e31e166((object) null, (EventArgs) null);
    }

    private void x8e9e04a70e31e166(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      if (this.x6fd7c9ad69859c3e != null)
        goto label_4;
label_1:
      if (!this.HasSingleControlLayoutSystem)
      {
        this.xa6607dfd4b3038ad.Text = "";
        this.x6fd7c9ad69859c3e = (ControlLayoutSystem) null;
        return;
      }
      goto label_5;
label_4:
      this.x6fd7c9ad69859c3e.xcc55983eb55360ac -= new ControlLayoutSystem.xf09a9df3c262275d(this.xe20c835979d60df8);
      if (true)
        goto label_1;
label_5:
      do
      {
        this.x6fd7c9ad69859c3e = (ControlLayoutSystem) this.LayoutSystem.LayoutSystems[0];
        this.x6fd7c9ad69859c3e.xcc55983eb55360ac += new ControlLayoutSystem.xf09a9df3c262275d(this.xe20c835979d60df8);
        this.xe20c835979d60df8((DockControl) null, this.x6fd7c9ad69859c3e.SelectedControl);
      }
      while (false);
    }

    public override bool IsFloating
    {
      get
      {
        return true;
      }
    }

    private void x9218bee68262250e(object xe0292b9ed559da7d, CancelEventArgs xfbf34718e704c6bc)
    {
      if (!this.x50765ed4559630d6)
        return;
      do
      {
        DockControl[] x9476096be9672d38 = this.LayoutSystem.x9476096be9672d38;
        int index1;
        int index2;
        if ((uint) index1 - (uint) index2 <= uint.MaxValue)
          goto label_16;
label_2:
        DockControl[] dockControlArray1;
        for (; index1 < dockControlArray1.Length; ++index1)
        {
          if (!dockControlArray1[index1].Close())
          {
            xfbf34718e704c6bc.Cancel = true;
            return;
          }
        }
        continue;
label_16:
        DockControl[] dockControlArray2 = x9476096be9672d38;
        index2 = 0;
        while (true)
        {
          do
          {
            if (index2 >= dockControlArray2.Length)
            {
              dockControlArray1 = x9476096be9672d38;
              index1 = 0;
              if ((uint) index1 >= 0U)
                goto label_14;
            }
            if (!dockControlArray2[index2].AllowClose)
            {
              xfbf34718e704c6bc.Cancel = true;
              if ((uint) index1 + (uint) index1 > uint.MaxValue)
                goto label_7;
            }
            else
              goto label_7;
          }
          while (false);
          goto label_6;
label_7:
          ++index2;
        }
label_14:
        if ((uint) index1 + (uint) index1 >= 0U)
          goto label_2;
      }
      while (false);
      return;
label_6:;
    }

    public DockControl xbe0b15fe97a1ee89
    {
      get
      {
        ControlLayoutSystem controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem((DockContainer) this);
        if (controlLayoutSystem == null)
          throw new InvalidOperationException("A docking operation was started while the window hierarchy is in an invalid state.");
        return controlLayoutSystem.SelectedControl;
      }
    }

    private void xe1f5f125062dc4fb(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      Form activeForm = Form.ActiveForm;
label_22:
      do
      {
        Form xd936980ea1aac341 = this.xd936980ea1aac341;
label_21:
        DockControl[] x9476096be9672d38;
        DockControl xbe0b15fe97a1ee89;
        do
        {
          x9476096be9672d38 = this.LayoutSystem.x9476096be9672d38;
          xbe0b15fe97a1ee89 = this.xbe0b15fe97a1ee89;
          if (true)
            goto label_19;
label_13:
          this.LayoutSystem = new SplitLayoutSystem();
          this.Dispose();
          continue;
label_19:
          if (x9476096be9672d38[0].MetaData.LastFixedDockSituation == DockSituation.Docked)
            goto label_17;
          else
            goto label_20;
label_11:
          if (x9476096be9672d38[0].MetaData.LastFixedDockSituation == DockSituation.Document)
            goto label_14;
label_12:
          SandDockManager manager = this.Manager;
          goto label_13;
label_14:
          if (this.LayoutSystem.xe302f2203dc14a18(ContainerDockLocation.Center))
            goto label_12;
          else
            goto label_23;
label_17:
          if (!this.LayoutSystem.xe302f2203dc14a18(xbe0b15fe97a1ee89.MetaData.LastFixedDockSide))
            goto label_15;
          else
            goto label_11;
label_20:
          if (true)
          {
            if (true)
              goto label_11;
            else
              goto label_17;
          }
          else
            goto label_14;
        }
        while (false);
        do
        {
          if (xbe0b15fe97a1ee89.MetaData.LastFixedDockSituation == DockSituation.Docked)
          {
            if (true)
            {
              if (false)
              {
                if (true)
                  goto label_22;
              }
              else
                goto label_2;
            }
            else
              goto label_24;
          }
          else
            goto label_3;
        }
        while (false);
        goto label_21;
label_2:
        x9476096be9672d38[0].OpenDocked(WindowOpenMethod.OnScreenActivate);
        goto label_4;
label_3:
        x9476096be9672d38[0].OpenDocument(WindowOpenMethod.OnScreenActivate);
label_4:
        DockControl[] controls = new DockControl[x9476096be9672d38.Length - 1];
        if (true)
        {
          Array.Copy((Array) x9476096be9672d38, 1, (Array) controls, 0, x9476096be9672d38.Length - 1);
          x9476096be9672d38[0].LayoutSystem.Controls.AddRange(controls);
          x9476096be9672d38[0].LayoutSystem.SelectedControl = xbe0b15fe97a1ee89;
          if (false)
            goto label_2;
        }
      }
      while (false);
      return;
label_24:
      return;
label_23:
      return;
label_15:;
    }

    internal void x5b7f6ddd07ded8cd()
    {
      this.xa6607dfd4b3038ad.Activate();
    }
  }
}
