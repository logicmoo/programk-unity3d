// Decompiled with JetBrains decompiler
// Type: TD.SandDock.ControlLayoutSystem
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
  [TypeConverter(typeof (x44c2ba9761cb4dd2))]
  public class ControlLayoutSystem : LayoutSystemBase
  {
    private Guid xb51cd75f17ace1ec = Guid.NewGuid();
    private System.Drawing.Point x6afebf16b45c02e0 = System.Drawing.Point.Empty;
    private const int x1e9b7c427b6c44fa = 19;
    private const int x26539fe4604823df = 15;
    private ControlLayoutSystem.DockControlCollection xe477cc01ecfef1fb;
    private bool xb9835bbd335d127e;
    internal Rectangle xb48529af1739dd06;
    internal Rectangle xa358da7dd5364cab;
    internal Rectangle x21ed2ecc088ef4e4;
    internal Rectangle xc78399ba98eab19f;
    private DockControl xbf5c00c8e3dd85fc;
    private bool xf111a0cc60fdac46;
    private x10ac79a4257c7f52 x4fb7dbcd13b8ce4b;
    private x0a9f5257a10031b2 x26e80f23e22a05ae;
    private x0a9f5257a10031b2 x65911b61bef3a921;
    private x0a9f5257a10031b2 x3b444f64233558c3;
    private x0a9f5257a10031b2 x502580ccb6d2ffd4;
    internal bool xfa5e20eb950b9ee1;
    private bool x04c163da360b887e;
    internal bool xd30df1068ed42e28;
    private bool x49cf4e0157d9436c;
    private bool xd34ff54c5dd91133;

    internal event ControlLayoutSystem.xf09a9df3c262275d xcc55983eb55360ac;

    public ControlLayoutSystem()
    {
      this.xe477cc01ecfef1fb = new ControlLayoutSystem.DockControlCollection(this);
      this.x26e80f23e22a05ae = new x0a9f5257a10031b2();
      this.x65911b61bef3a921 = new x0a9f5257a10031b2();
      this.x3b444f64233558c3 = new x0a9f5257a10031b2();
    }

    public ControlLayoutSystem(int desiredWidth, int desiredHeight)
      : this()
    {
      this.WorkingSize = new SizeF((float) desiredWidth, (float) desiredHeight);
    }

    [Obsolete("Use the constructor that takes a SizeF instead.")]
    public ControlLayoutSystem(
      int desiredWidth,
      int desiredHeight,
      DockControl[] controls,
      DockControl selectedControl)
      : this(desiredWidth, desiredHeight)
    {
      this.xe477cc01ecfef1fb.AddRange(controls);
      if ((uint) desiredHeight - (uint) desiredWidth <= uint.MaxValue && selectedControl == null)
        return;
      this.SelectedControl = selectedControl;
    }

    public ControlLayoutSystem(
      SizeF workingSize,
      DockControl[] windows,
      DockControl selectedWindow)
      : this()
    {
      this.WorkingSize = workingSize;
      this.Controls.AddRange(windows);
      if (selectedWindow == null)
        return;
      this.SelectedControl = selectedWindow;
    }

    public ControlLayoutSystem(
      int desiredWidth,
      int desiredHeight,
      DockControl[] controls,
      DockControl selectedControl,
      bool collapsed)
      : this(new SizeF((float) desiredWidth, (float) desiredHeight), controls, selectedControl)
    {
      this.Collapsed = collapsed;
    }

    internal override DockControl[] x9476096be9672d38
    {
      get
      {
        DockControl[] array = new DockControl[this.Controls.Count];
        this.Controls.CopyTo(array, 0);
        return array;
      }
    }

    internal int xca843b3e9a1c605f
    {
      get
      {
        if (this.SelectedControl != null)
        {
          if (true)
            goto label_7;
        }
        else
          goto label_4;
label_2:
        if (true)
          goto label_4;
label_3:
        return this.DockContainer.ContentSize;
label_4:
        if (!this.IsInContainer)
        {
          if (true)
            return 200;
        }
        else
          goto label_3;
label_7:
        if (this.SelectedControl.PopupSize != 0)
          return this.SelectedControl.PopupSize;
        goto label_2;
      }
      set
      {
        foreach (DockControl control in (CollectionBase) this.Controls)
          control.PopupSize = value;
      }
    }

    internal override bool x56005f23d6948487
    {
      get
      {
        IEnumerator enumerator = this.Controls.GetEnumerator();
        bool flag;
        try
        {
          do
          {
            if (!enumerator.MoveNext())
              goto label_11;
          }
          while (!((DockControl) enumerator.Current).PersistState);
          do
          {
            flag = true;
          }
          while (false);
          goto label_12;
        }
        finally
        {
          IDisposable disposable = enumerator as IDisposable;
          do
          {
            if (disposable == null)
            {
              if (((flag ? 1 : 0) & 0) == 0)
                break;
            }
            else
            {
              do
              {
                disposable.Dispose();
              }
              while (false);
            }
          }
          while ((uint) flag - (uint) flag < 0U);
        }
label_11:
        return false;
label_12:
        return flag;
      }
    }

    internal Guid x0217cda8370c1f17
    {
      get
      {
        return this.xb51cd75f17ace1ec;
      }
      set
      {
        this.xb51cd75f17ace1ec = value;
      }
    }

    public bool LockControls
    {
      get
      {
        return this.x04c163da360b887e;
      }
      set
      {
        this.x04c163da360b887e = value;
      }
    }

    public bool IsPoppedUp
    {
      get
      {
        if (this.x10ac79a4257c7f52 != null)
          return this.x10ac79a4257c7f52.x23498f53d87354d4 == this;
        return false;
      }
    }

    public void ClosePopup()
    {
      if (!this.IsPoppedUp)
        return;
      this.x10ac79a4257c7f52.xcdb145600c1b7224(true);
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public ControlLayoutSystem.DockControlCollection Controls
    {
      get
      {
        return this.xe477cc01ecfef1fb;
      }
    }

    internal x10ac79a4257c7f52 x10ac79a4257c7f52
    {
      get
      {
        return this.x4fb7dbcd13b8ce4b;
      }
    }

    internal void xa85d8c17921cc878(x10ac79a4257c7f52 x4fb7dbcd13b8ce4b)
    {
      this.x4fb7dbcd13b8ce4b = x4fb7dbcd13b8ce4b;
    }

    internal Control x0e40cec3a0be4a70
    {
      get
      {
        if (!this.IsInContainer)
          return (Control) null;
        if (this.IsPoppedUp)
          return this.x10ac79a4257c7f52.x87cf4de36131799d;
        return (Control) this.DockContainer;
      }
    }

    [DefaultValue(false)]
    [Browsable(false)]
    public virtual bool Collapsed
    {
      get
      {
        return this.xb9835bbd335d127e;
      }
      set
      {
        if (this.xb9835bbd335d127e == value)
        {
          if (true)
            return;
        }
        else
          goto label_36;
label_31:
        this.x1f43ebe301d1df45 = (x0a9f5257a10031b2) null;
        if (!this.xb9835bbd335d127e)
          goto label_14;
        else
          goto label_32;
label_2:
        if (this.IsInContainer)
        {
          this.DockContainer.x7e9646eed248ed11();
          return;
        }
        if (((value ? 1 : 0) & 0) == 0)
          ;
        return;
label_3:
        IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator();
        try
        {
          while (true)
          {
            DockControl current;
            do
            {
              if (!enumerator.MoveNext())
              {
                if ((uint) value <= uint.MaxValue)
                  goto label_2;
              }
              current = (DockControl) enumerator.Current;
            }
            while (current.Parent == this.DockContainer);
            current.Parent = (Control) this.DockContainer;
          }
        }
        finally
        {
          IDisposable disposable = enumerator as IDisposable;
          if ((uint) value - (uint) value > uint.MaxValue || disposable != null)
            disposable.Dispose();
        }
label_14:
        if (this.x10ac79a4257c7f52 == null)
          goto label_3;
label_17:
        this.x10ac79a4257c7f52.x7fdaeb05cb5e84f3.x52b190e626f65140(this);
        goto label_3;
label_32:
        if (((value ? 1 : 0) & 0) != 0)
          ;
        if ((uint) value + (uint) value >= 0U)
        {
          if (this.IsInContainer)
          {
            foreach (DockControl dockControl in (CollectionBase) this.xe477cc01ecfef1fb)
            {
              if (dockControl.Parent == this.DockContainer)
                LayoutUtilities.xa7513d57b4844d46((Control) dockControl);
            }
            x10ac79a4257c7f52 autoHideBar = this.DockContainer.Manager.GetAutoHideBar(this.DockContainer.Dock);
            if (autoHideBar != null)
            {
              if (true)
              {
                autoHideBar.x7fdaeb05cb5e84f3.xd6b6ed77479ef68c(this);
                goto label_2;
              }
              else
                goto label_3;
            }
            else
              goto label_2;
          }
          else
            goto label_2;
        }
        else if ((uint) value - (uint) value <= uint.MaxValue)
          goto label_14;
        else
          goto label_17;
label_36:
        this.xb9835bbd335d127e = value;
        if (((value ? 1 : 0) | 15) != 0)
          goto label_31;
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public virtual DockControl SelectedControl
    {
      get
      {
        return this.xbf5c00c8e3dd85fc;
      }
      set
      {
        if (value == null || this.xe477cc01ecfef1fb.Contains(value))
        {
          if (this.SelectedControl != null)
            goto label_13;
          else
            goto label_10;
label_8:
          DockControl xbf5c00c8e3dd85fc = this.xbf5c00c8e3dd85fc;
          if (true)
          {
            this.xbf5c00c8e3dd85fc = value;
            this.x3e0280cae730d1f2();
            if (this.IsPoppedUp)
              goto label_5;
label_2:
            this.xe20c835979d60df8(xbf5c00c8e3dd85fc, this.xbf5c00c8e3dd85fc);
            return;
label_5:
            if (xbf5c00c8e3dd85fc != null)
              goto label_6;
label_1:
            while (this.xbf5c00c8e3dd85fc != null)
            {
              this.xbf5c00c8e3dd85fc.OnAutoHidePopupOpened(EventArgs.Empty);
              if (true)
              {
                if (true)
                  break;
              }
              else
                goto label_8;
            }
            goto label_2;
label_6:
            xbf5c00c8e3dd85fc.OnAutoHidePopupClosed(EventArgs.Empty);
            if (false)
              return;
            goto label_1;
          }
          else
            goto label_12;
label_10:
          if (false)
            goto label_8;
          else
            goto label_8;
label_13:
          if (this.SelectedControl.Manager != null && (this.SelectedControl.Manager.RaiseValidationEvents && !this.SelectedControl.ValidateChildren()))
            return;
          goto label_8;
        }
label_12:
        throw new ArgumentOutOfRangeException(nameof (value));
      }
    }

    protected virtual void OnCloseButtonClick(EventArgs e)
    {
      if (this.SelectedControl == null)
        return;
      this.SelectedControl.x8ffe90e7fbccfccd(true);
    }

    protected virtual void OnPinButtonClick()
    {
      this.Collapsed = !this.Collapsed;
      if (!this.IsInContainer)
        return;
      if (false)
        ;
      if (this.SelectedControl == null)
        return;
      if (!this.Collapsed || this.x10ac79a4257c7f52 == null)
      {
        do
        {
          this.SelectedControl.Activate();
        }
        while (false);
      }
      else
      {
        this.x10ac79a4257c7f52.xe6ff614263a59ef9(this.SelectedControl, true, false);
        this.x10ac79a4257c7f52.xcdb145600c1b7224(false);
      }
    }

    private void xe20c835979d60df8(DockControl x321bff1c322e5433, DockControl x31b34ee91c89cf69)
    {
      if (this.xcc55983eb55360ac == null)
        return;
      this.xcc55983eb55360ac(x321bff1c322e5433, x31b34ee91c89cf69);
    }

    protected internal override void OnMouseDoubleClick()
    {
      System.Drawing.Point client = this.DockContainer.PointToClient(Cursor.Position);
      if (true)
        goto label_26;
label_3:
      DockControl controlAt;
      controlAt.OnTabDoubleClick();
      return;
label_26:
      if (false)
        return;
label_24:
      while (this.DockContainer.Manager != null)
      {
        while (false)
        {
          if (true)
          {
            if (true)
              goto label_18;
          }
          else
            goto label_24;
        }
label_1:
        if (this.LockControls)
          break;
label_14:
        if (this.xb48529af1739dd06.Contains(client))
          goto label_15;
        else
          goto label_9;
label_5:
        if (false)
          goto label_11;
label_7:
        controlAt = this.GetControlAt(client);
        if (controlAt == null)
        {
          if (true)
            break;
          goto label_5;
        }
        else
          goto label_3;
label_9:
        if (true)
        {
          if (false)
          {
            if (true)
            {
              if (false)
                goto label_18;
              else
                goto label_5;
            }
            else
              goto label_3;
          }
          else
            goto label_7;
        }
        else
          goto label_15;
label_11:
        if (!this.x65911b61bef3a921.xda73fcb97c77d998.Contains(client))
        {
          if (true)
          {
            if (this.Controls.Count == 0)
            {
              if (false)
                goto label_9;
              else
                goto label_7;
            }
            else
            {
              this.xa7b62e7d2cd81eb7();
              break;
            }
          }
          else
            goto label_1;
        }
        else
          goto label_7;
label_15:
        if (this.x26e80f23e22a05ae.xda73fcb97c77d998.Contains(client))
        {
          if (true)
            goto label_5;
          else
            goto label_3;
        }
        else
          goto label_11;
label_18:
        if (true)
          goto label_1;
        else
          goto label_14;
      }
    }

    private void xa7b62e7d2cd81eb7()
    {
      switch (this.SelectedControl.DockSituation)
      {
        case DockSituation.Docked:
        case DockSituation.Document:
          if (!this.x74e31f9641656e0b)
            return;
          this.x18f55df6f6629e9f(DockSituation.Floating);
          return;
        case DockSituation.Floating:
label_6:
          if (this.SelectedControl.MetaData.LastFixedDockSituation == DockSituation.Docked)
            goto label_7;
          else
            break;
        default:
          if (true)
          {
            if (true)
              ;
            return;
          }
          goto label_7;
      }
label_2:
      if (this.SelectedControl.MetaData.LastFixedDockSituation != DockSituation.Document)
      {
        if (true)
        {
          if (true)
            ;
          return;
        }
        goto label_6;
      }
      else
      {
        if (!this.xe302f2203dc14a18(ContainerDockLocation.Center))
          return;
        this.x18f55df6f6629e9f(DockSituation.Document);
        return;
      }
label_7:
      if (this.xe302f2203dc14a18(this.SelectedControl.MetaData.LastFixedDockSide))
        this.x18f55df6f6629e9f(DockSituation.Docked);
      else
        goto label_2;
    }

    protected internal override void OnMouseMove(MouseEventArgs e)
    {
      if (this.xd30df1068ed42e28)
        return;
      if (e.Button == MouseButtons.None)
        this.xf111a0cc60fdac46 = false;
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
        goto label_26;
label_2:
      if (this.xf111a0cc60fdac46)
        return;
      this.x1f43ebe301d1df45 = this.x07083a4bfd59263d(e.X, e.Y);
      return;
label_26:
      if (this.x531514c39973cbc6 == null)
      {
        Rectangle rectangle = new Rectangle(this.x6afebf16b45c02e0, new System.Drawing.Size(0, 0));
        if (false)
          return;
        rectangle.Inflate(SystemInformation.DragSize);
        if (!rectangle.Contains(e.X, e.Y))
        {
          if (true)
            goto label_4;
          else
            goto label_11;
label_1:
          if (false)
            goto label_19;
          else
            goto label_2;
label_4:
          if (!this.IsInContainer)
          {
            if (true)
              goto label_1;
          }
          else
            goto label_11;
label_6:
          if (true)
            goto label_11;
          else
            goto label_4;
label_7:
          DockControl controlAt;
          if (!this.Collapsed)
          {
            if (this.LockControls)
            {
              if (true)
              {
                if (true)
                  goto label_2;
                else
                  goto label_2;
              }
            }
            else
            {
              controlAt = this.GetControlAt(this.x6afebf16b45c02e0);
              this.x49cf4e0157d9436c = controlAt == null;
              goto label_18;
            }
          }
          else
            goto label_2;
label_10:
          if (true)
            goto label_6;
label_11:
          if (!(this.x6afebf16b45c02e0 != System.Drawing.Point.Empty))
            goto label_2;
          else
            goto label_7;
label_13:
          DockingManager xab4835b6b3620991;
          if (this.DockContainer.Manager == null)
            xab4835b6b3620991 = DockingManager.Standard;
          else
            goto label_17;
label_15:
          DockingHints x48cee1d69929b4fe;
          this.xe9a159cd1e028df2(this.DockContainer.Manager, this.DockContainer, (LayoutSystemBase) this, controlAt, this.SelectedControl.MetaData.DockedContentSize, this.x6afebf16b45c02e0, x48cee1d69929b4fe, xab4835b6b3620991);
          if (true)
            return;
          goto label_7;
label_17:
          xab4835b6b3620991 = this.DockContainer.Manager.DockingManager;
          if (false)
            goto label_4;
          else
            goto label_15;
label_18:
          if (this.DockContainer.Manager != null)
          {
            x48cee1d69929b4fe = this.DockContainer.Manager.DockingHints;
            if (true)
              goto label_13;
            else
              goto label_1;
          }
label_19:
          do
          {
            x48cee1d69929b4fe = DockingHints.TranslucentFill;
            if (false)
              goto label_10;
          }
          while (false);
          if (false)
            goto label_18;
          else
            goto label_13;
        }
        else
          goto label_2;
      }
      else
        this.x531514c39973cbc6.OnMouseMove(Cursor.Position);
    }

    internal x0a9f5257a10031b2 x1f43ebe301d1df45
    {
      get
      {
        return this.x502580ccb6d2ffd4;
      }
      set
      {
        if (value == this.x502580ccb6d2ffd4)
          return;
        if (true)
        {
          if (this.x502580ccb6d2ffd4 != null)
            this.xd541e2fc281b554b();
          this.x502580ccb6d2ffd4 = value;
        }
        if (this.x502580ccb6d2ffd4 == null)
          return;
        this.xd541e2fc281b554b();
      }
    }

    internal override bool x2f61709eaa5ebf76
    {
      get
      {
        IEnumerator enumerator = this.Controls.GetEnumerator();
        bool flag;
        try
        {
label_2:
          if (enumerator.MoveNext())
            goto label_5;
label_4:
          if (true)
            goto label_11;
label_5:
          if (!((DockControl) enumerator.Current).DockingRules.AllowTab)
          {
            flag = false;
            if (true)
              goto label_12;
            else
              goto label_4;
          }
          else
            goto label_2;
        }
        finally
        {
          IDisposable disposable = enumerator as IDisposable;
          do
          {
            while (disposable != null)
            {
              disposable.Dispose();
              if (true)
                goto label_10;
            }
          }
          while (false);
label_10:;
        }
label_11:
        return true;
label_12:
        return flag;
      }
    }

    internal override bool x74e31f9641656e0b
    {
      get
      {
        IEnumerator enumerator = this.Controls.GetEnumerator();
        try
        {
          DockControl current;
          bool flag;
          do
          {
            if (!enumerator.MoveNext())
            {
              if (true)
                goto label_9;
            }
            current = (DockControl) enumerator.Current;
          }
          while (((flag ? 1 : 0) | 3) != 0 && current.DockingRules.AllowFloat);
          return false;
        }
        finally
        {
          (enumerator as IDisposable)?.Dispose();
        }
label_9:
        return true;
      }
    }

    private bool x43d7533e3cdb2944
    {
      get
      {
        IEnumerator enumerator = this.Controls.GetEnumerator();
        try
        {
          do
          {
            if (!enumerator.MoveNext())
            {
              if (true)
              {
                if (true)
                  goto label_10;
              }
              else
                goto label_10;
            }
          }
          while (((DockControl) enumerator.Current).AllowCollapse);
          return false;
        }
        finally
        {
          (enumerator as IDisposable)?.Dispose();
        }
label_10:
        return true;
      }
    }

    internal override bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256)
    {
      IEnumerator enumerator = this.Controls.GetEnumerator();
      bool flag;
      try
      {
        do
        {
          if (!enumerator.MoveNext())
          {
            if (false)
              goto label_9;
            else
              goto label_9;
          }
        }
        while (((DockControl) enumerator.Current).xe302f2203dc14a18(xb9c2cfae130d9256));
        flag = false;
        if ((uint) flag >= 0U)
          goto label_10;
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
label_9:
      return true;
label_10:
      return flag;
    }

    internal virtual string xe0e7b93bedab6c05(System.Drawing.Point x13d4cb8d1bd20347)
    {
      DockControl controlAt = this.GetControlAt(x13d4cb8d1bd20347);
      if (controlAt == null)
      {
        do
        {
          x0a9f5257a10031b2 x0a9f5257a10031b2 = this.x07083a4bfd59263d(x13d4cb8d1bd20347.X, x13d4cb8d1bd20347.Y);
          if (x0a9f5257a10031b2 != this.x26e80f23e22a05ae)
          {
            if (x0a9f5257a10031b2 != this.x65911b61bef3a921)
            {
              if (x0a9f5257a10031b2 == this.x3b444f64233558c3)
                goto label_1;
            }
            else
              goto label_5;
          }
          else
            goto label_7;
        }
        while (false);
        goto label_13;
label_1:
        return SandDockLanguage.WindowPositionText;
label_5:
        return SandDockLanguage.AutoHideText;
label_7:
        return SandDockLanguage.CloseText;
label_13:
        return "";
      }
      if (controlAt.ToolTipText.Length != 0)
        return controlAt.ToolTipText;
      if (controlAt.xcfac6723d8a41375)
        return controlAt.Text;
      return "";
    }

    internal virtual x0a9f5257a10031b2 x07083a4bfd59263d(
      int x08db3aeabb253cb1,
      int x1e218ceaee1bb583)
    {
      if (!this.x26e80f23e22a05ae.x364c1e3b189d47fe)
        goto label_5;
      else
        goto label_11;
label_1:
      if (this.x3b444f64233558c3.x364c1e3b189d47fe && this.x3b444f64233558c3.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
        return this.x3b444f64233558c3;
      return (x0a9f5257a10031b2) null;
label_2:
      if (!this.x65911b61bef3a921.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
        goto label_1;
label_4:
      return this.x65911b61bef3a921;
label_5:
      if (!this.x65911b61bef3a921.x364c1e3b189d47fe)
        goto label_1;
      else
        goto label_2;
label_11:
      while (!this.x26e80f23e22a05ae.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
      {
        if ((x08db3aeabb253cb1 & 0) == 0)
        {
          if (false)
          {
            if ((uint) x08db3aeabb253cb1 <= uint.MaxValue)
              goto label_2;
            else
              goto label_4;
          }
          else
            goto label_5;
        }
        else if ((uint) x08db3aeabb253cb1 + (uint) x1e218ceaee1bb583 >= 0U)
          goto label_5;
      }
      return this.x26e80f23e22a05ae;
    }

    internal override void x0ae87c4881d90427(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      base.x0ae87c4881d90427(xe0292b9ed559da7d, xfbf34718e704c6bc);
      this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
    }

    protected internal override void OnDragOver(DragEventArgs drgevent)
    {
      base.OnDragOver(drgevent);
      DockControl controlAt = this.GetControlAt(this.DockContainer.PointToClient(new System.Drawing.Point(drgevent.X, drgevent.Y)));
      while (false)
      {
        if (true)
          goto label_5;
      }
      if (controlAt == null)
        return;
label_5:
      if (this.SelectedControl == controlAt)
        return;
      this.SelectedControl = controlAt;
    }

    protected internal override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
      if (true)
        goto label_26;
      else
        goto label_16;
label_7:
      if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
        goto label_13;
      else
        goto label_8;
label_4:
      DockControl controlAt = this.GetControlAt(new System.Drawing.Point(e.X, e.Y));
label_5:
      if (controlAt == null)
        return;
      controlAt.Activate();
      this.xf111a0cc60fdac46 = true;
      if (false)
        return;
      if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
      {
        if (true)
          return;
        goto label_12;
      }
      else
      {
        this.x6afebf16b45c02e0 = new System.Drawing.Point(e.X, e.Y);
        if (true)
          return;
        goto label_9;
      }
label_8:
      if (true)
      {
        while (true)
        {
          if (true)
            goto label_4;
        }
      }
      else
        goto label_5;
label_9:
      if (this.x1f43ebe301d1df45 != null)
        goto label_15;
      else
        goto label_4;
label_12:
      this.x6afebf16b45c02e0 = new System.Drawing.Point(e.X, e.Y);
      goto label_9;
label_13:
      if (!this.xb48529af1739dd06.Contains(e.X, e.Y))
      {
        if (true)
          goto label_9;
      }
      else
        goto label_12;
label_15:
      this.xfa5e20eb950b9ee1 = true;
      this.xd541e2fc281b554b();
      this.x11e90588eb0baaf1(this.x1f43ebe301d1df45);
      this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
      return;
label_16:
      if (this.SelectedControl != null)
      {
        this.SelectedControl.Activate();
        if (true)
          goto label_7;
        else
          goto label_28;
      }
      else
        goto label_7;
label_26:
      this.xf111a0cc60fdac46 = false;
      while (!this.xb48529af1739dd06.Contains(e.X, e.Y))
      {
        if (false)
        {
          if (true)
          {
            if (true)
              goto label_28;
            else
              goto label_26;
          }
        }
        else
          goto label_7;
      }
      goto label_16;
label_28:
      if (true)
        goto label_16;
    }

    protected internal override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
      this.xf111a0cc60fdac46 = false;
      if (this.x531514c39973cbc6 == null)
      {
        DockControl dockControl;
        System.Drawing.Point p;
        do
        {
          if ((e.Button & MouseButtons.Right) == MouseButtons.Right)
            goto label_22;
label_8:
          if ((e.Button & MouseButtons.Middle) == MouseButtons.Middle && (this.IsInContainer && this.DockContainer.Manager != null))
          {
            if (!this.DockContainer.Manager.AllowMiddleButtonClosure)
            {
              if (true)
                goto label_4;
            }
            else
              goto label_13;
          }
          else
            goto label_3;
label_19:
          if (dockControl != null && this.IsInContainer)
          {
            p = new System.Drawing.Point(e.X, e.Y);
            p = dockControl.Parent.PointToScreen(p);
            continue;
          }
          goto label_8;
label_22:
          dockControl = this.GetControlAt(new System.Drawing.Point(e.X, e.Y));
          if (dockControl == null && this.xb48529af1739dd06.Contains(e.X, e.Y))
          {
            dockControl = this.SelectedControl;
            goto label_19;
          }
          else
            goto label_19;
        }
        while (false);
        goto label_18;
label_2:
        this.xd541e2fc281b554b();
        return;
label_3:
        if ((e.Button & MouseButtons.Left) != MouseButtons.Left)
          return;
        goto label_5;
label_4:
        if (true)
          goto label_3;
label_5:
        if (this.x1f43ebe301d1df45 == null)
          return;
        this.xa82f7b310984e03e(this.x1f43ebe301d1df45);
        this.xfa5e20eb950b9ee1 = false;
        goto label_2;
label_13:
        DockControl controlAt = this.GetControlAt(new System.Drawing.Point(e.X, e.Y));
        if (true)
        {
          if (controlAt == null)
            return;
        }
        else
          goto label_14;
label_10:
        if (!controlAt.AllowClose)
          return;
        controlAt.x8ffe90e7fbccfccd(true);
        if (true)
        {
          if (false)
            goto label_4;
          else
            goto label_15;
        }
        else
          goto label_2;
label_14:
        if (true)
          goto label_10;
label_15:
        if (true)
          return;
        goto label_3;
label_18:
        System.Drawing.Point client = dockControl.PointToClient(p);
        this.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(dockControl, client, ContextMenuContext.RightClick));
      }
      else
        this.x531514c39973cbc6.Commit();
    }

    internal virtual void x11e90588eb0baaf1(x0a9f5257a10031b2 x128517d7ded59312)
    {
    }

    internal virtual void xa82f7b310984e03e(x0a9f5257a10031b2 x128517d7ded59312)
    {
      if (this.x1f43ebe301d1df45 != this.x26e80f23e22a05ae)
      {
        if (this.x1f43ebe301d1df45 != this.x65911b61bef3a921)
        {
          do
          {
            if (this.x1f43ebe301d1df45 == this.x3b444f64233558c3)
              goto label_8;
            else
              goto label_4;
label_1:
            continue;
label_4:
            if (true)
            {
              if (false)
                goto label_1;
              else
                goto label_5;
            }
            else if (true)
              goto label_1;
            else
              goto label_11;
label_8:
            this.xf0820a0467228c88();
            goto label_1;
          }
          while (false);
          return;
label_5:
          return;
label_11:;
        }
        else
          this.OnPinButtonClick();
      }
      else
        this.OnCloseButtonClick(EventArgs.Empty);
    }

    private void xf0820a0467228c88()
    {
      this.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(this.SelectedControl, this.SelectedControl.PointToClient(this.SelectedControl.Parent.PointToScreen(new System.Drawing.Point(this.x3b444f64233558c3.xda73fcb97c77d998.Left, this.x3b444f64233558c3.xda73fcb97c77d998.Bottom))), ContextMenuContext.OptionsButton));
    }

    protected internal override void OnMouseLeave()
    {
      base.OnMouseLeave();
      this.x1f43ebe301d1df45 = (x0a9f5257a10031b2) null;
      this.xfa5e20eb950b9ee1 = false;
    }

    internal bool x61ce2417e4ef76f9()
    {
      if (this.IsInContainer)
      {
        do
        {
          if (true)
            goto label_3;
          else
            goto label_7;
label_1:
          if (!this.SelectedControl.ContainsFocus)
            continue;
          goto label_8;
label_3:
          if (this.SelectedControl == null)
            break;
          goto label_1;
label_7:
          if (false)
            goto label_5;
          else
            goto label_1;
        }
        while (false);
        goto label_9;
label_5:
        return true;
label_8:
        this.x317ed3bc8decf394 = true;
        if (this.SelectedControl != null)
        {
          this.DockContainer.Manager.OnDockControlActivated(new DockControlEventArgs(this.SelectedControl));
          goto label_5;
        }
        else
          goto label_5;
      }
label_9:
      return false;
    }

    internal void x82dd941e2755ffd2()
    {
      this.x317ed3bc8decf394 = false;
    }

    internal bool x317ed3bc8decf394
    {
      get
      {
        return this.xd34ff54c5dd91133;
      }
      set
      {
        if (value == this.xd34ff54c5dd91133)
          return;
        this.xd34ff54c5dd91133 = value;
        this.xd541e2fc281b554b();
      }
    }

    internal override void x84b6f3c22477dacb(
      RendererBase x38870620fd380a6b,
      Graphics x41347a961b838962,
      Font x26094932cf7a9139)
    {
      if (this.DockContainer == null)
        return;
      Control container = this.DockContainer.IsFloating || this.DockContainer.Manager == null || this.DockContainer.Manager.DockSystemContainer == null ? (Control) this.DockContainer : this.DockContainer.Manager.DockSystemContainer;
      if (true)
        goto label_84;
      else
        goto label_79;
label_49:
      if (this.xe477cc01ecfef1fb.Count > 1)
        goto label_43;
      else
        goto label_69;
label_1:
      int selectedTabOffset;
      bool focused;
      while (this.x3b444f64233558c3.x364c1e3b189d47fe)
      {
        if (this.x3b444f64233558c3.xda73fcb97c77d998.Left <= this.xb48529af1739dd06.Left)
        {
          if ((selectedTabOffset | int.MaxValue) != 0)
            break;
        }
        else
        {
          DrawItemState state = DrawItemState.Default;
          if (this.x1f43ebe301d1df45 == this.x3b444f64233558c3)
            goto label_7;
label_4:
          x38870620fd380a6b.DrawTitleBarButton(x41347a961b838962, this.x3b444f64233558c3.xda73fcb97c77d998, SandDockButtonType.WindowPosition, state, focused, false);
          break;
label_7:
          state |= DrawItemState.HotLight;
          if (this.xfa5e20eb950b9ee1)
          {
            state |= DrawItemState.Selected;
            goto label_4;
          }
          else
            goto label_4;
        }
      }
      return;
label_11:
      DrawItemState state1;
      x38870620fd380a6b.DrawTitleBarButton(x41347a961b838962, this.x65911b61bef3a921.xda73fcb97c77d998, SandDockButtonType.Pin, state1, focused, this.Collapsed);
      if (true)
        goto label_1;
      else
        goto label_35;
label_13:
      state1 |= DrawItemState.HotLight;
      while (this.xfa5e20eb950b9ee1)
      {
        state1 |= DrawItemState.Selected;
        if ((uint) selectedTabOffset - (uint) selectedTabOffset <= uint.MaxValue)
          break;
      }
      goto label_11;
label_35:
      if (this.x26e80f23e22a05ae.x364c1e3b189d47fe)
        goto label_42;
label_36:
      Rectangle rectangle;
      bool drawSeparator;
      do
      {
        if (this.x65911b61bef3a921.x364c1e3b189d47fe)
          goto label_37;
label_34:
        do
        {
          if (this.x3b444f64233558c3.x364c1e3b189d47fe)
            goto label_38;
          else
            goto label_39;
label_15:
          if (this.x26e80f23e22a05ae.x364c1e3b189d47fe && this.x26e80f23e22a05ae.xda73fcb97c77d998.Left > this.xb48529af1739dd06.Left)
            goto label_26;
label_14:
          if (this.x65911b61bef3a921.x364c1e3b189d47fe)
          {
            if ((uint) drawSeparator <= uint.MaxValue)
              goto label_8;
            else
              goto label_25;
          }
          else
            goto label_1;
label_17:
          x38870620fd380a6b.DrawTitleBarButton(x41347a961b838962, this.x26e80f23e22a05ae.xda73fcb97c77d998, SandDockButtonType.Close, state1, focused, false);
          if ((uint) selectedTabOffset < 0U)
            goto label_15;
          else
            goto label_14;
label_25:
          if ((uint) selectedTabOffset - (uint) drawSeparator >= 0U)
          {
            if ((uint) selectedTabOffset + (uint) drawSeparator <= uint.MaxValue)
              goto label_24;
            else
              goto label_22;
label_20:
            if (((focused ? 1 : 0) & 0) != 0)
              goto label_24;
            else
              goto label_17;
label_22:
            if ((uint) drawSeparator - (uint) focused > uint.MaxValue)
            {
              if ((uint) drawSeparator + (uint) drawSeparator >= 0U)
                continue;
              goto label_41;
            }
label_23:
            state1 |= DrawItemState.Selected;
            if (false)
              goto label_83;
            else
              goto label_20;
label_24:
            if (!this.xfa5e20eb950b9ee1)
            {
              if (false)
              {
                if ((uint) focused < 0U)
                  goto label_1;
                else
                  goto label_20;
              }
              else
                goto label_17;
            }
            else
              goto label_23;
          }
          else
            goto label_90;
label_26:
          state1 = DrawItemState.Default;
          if ((uint) drawSeparator >= 0U)
          {
            if (this.x1f43ebe301d1df45 == this.x26e80f23e22a05ae)
            {
              state1 |= DrawItemState.HotLight;
              if ((uint) focused + (uint) drawSeparator <= uint.MaxValue)
                goto label_25;
              else
                goto label_8;
            }
            else
              goto label_17;
          }
          else
            goto label_76;
label_29:
          x38870620fd380a6b.DrawTitleBarText(x41347a961b838962, rectangle, focused, this.xbf5c00c8e3dd85fc == null ? "Empty Layout System" : this.xbf5c00c8e3dd85fc.Text, this.xbf5c00c8e3dd85fc != null ? this.xbf5c00c8e3dd85fc.Font : this.DockContainer.Font);
          if ((uint) drawSeparator - (uint) selectedTabOffset <= uint.MaxValue)
            goto label_15;
label_30:
          if (rectangle.Width > 8)
            goto label_29;
          else
            goto label_15;
label_31:
          rectangle = x38870620fd380a6b.TitleBarMetrics.RemovePadding(rectangle);
          goto label_30;
label_38:
          rectangle.Width -= 21;
          if (((drawSeparator ? 1 : 0) & 0) != 0)
            continue;
          goto label_31;
label_39:
          if ((uint) focused - (uint) drawSeparator < 0U)
          {
            if ((uint) drawSeparator <= uint.MaxValue)
              goto label_29;
            else
              goto label_1;
          }
          else
            goto label_31;
        }
        while (true);
        continue;
label_76:
        continue;
label_37:
        rectangle.Width -= 21;
        goto label_34;
      }
      while ((uint) focused - (uint) selectedTabOffset < 0U);
      goto label_43;
label_8:
      if (this.x65911b61bef3a921.xda73fcb97c77d998.Left > this.xb48529af1739dd06.Left)
      {
        state1 = DrawItemState.Default;
        if (this.x1f43ebe301d1df45 != this.x65911b61bef3a921)
          goto label_11;
        else
          goto label_13;
      }
      else
        goto label_1;
label_90:
      return;
label_83:
      if ((uint) drawSeparator + (uint) focused < 0U)
        goto label_45;
      else
        goto label_84;
label_41:
      if ((uint) focused + (uint) selectedTabOffset <= uint.MaxValue)
        goto label_35;
label_42:
      rectangle.Width -= 21;
      goto label_36;
label_43:
      if (this.xa358da7dd5364cab != Rectangle.Empty)
      {
        selectedTabOffset = 0;
        if ((uint) drawSeparator > uint.MaxValue)
        {
          if ((uint) drawSeparator - (uint) selectedTabOffset >= 0U)
            goto label_48;
          else
            goto label_49;
        }
        else
          goto label_71;
      }
label_44:
      rectangle = this.xb48529af1739dd06;
      if (!(rectangle != Rectangle.Empty))
        return;
label_45:
      if (rectangle.Width <= 0 || rectangle.Height <= 0)
        return;
      x38870620fd380a6b.DrawTitleBarBackground(x41347a961b838962, rectangle, focused);
      goto label_41;
label_48:
      if (true)
        goto label_43;
      else
        goto label_49;
label_69:
      if ((selectedTabOffset | 4) != 0)
      {
        if (this.DockContainer.x972331c8ecf83413)
          goto label_48;
        else
          goto label_44;
      }
      else if ((uint) selectedTabOffset >= 0U)
      {
        if ((uint) selectedTabOffset - (uint) focused < 0U)
        {
          if ((uint) selectedTabOffset + (uint) focused >= 0U)
            goto label_35;
          else
            goto label_1;
        }
        else
          goto label_43;
      }
label_71:
      if (this.xbf5c00c8e3dd85fc != null)
        goto label_68;
label_50:
      x38870620fd380a6b.DrawTabStripBackground(container, (Control) this.DockContainer, x41347a961b838962, this.xa358da7dd5364cab, selectedTabOffset);
      IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator();
      try
      {
        while (true)
        {
          if (!enumerator.MoveNext())
          {
            if ((uint) focused - (uint) drawSeparator <= uint.MaxValue)
              goto label_44;
          }
          DockControl current = (DockControl) enumerator.Current;
          DrawItemState state2 = DrawItemState.Default;
          if (this.xbf5c00c8e3dd85fc != current)
            goto label_59;
          else
            goto label_64;
label_52:
          x38870620fd380a6b.DrawTabStripTab(x41347a961b838962, current.x123e054dab107457, current.x1999b243e321e38a, current.TabText, current.Font, current.BackColor, current.ForeColor, state2, drawSeparator);
          continue;
label_55:
          while (x38870620fd380a6b is WhidbeyRenderer)
          {
            drawSeparator = false;
            if ((uint) drawSeparator - (uint) drawSeparator < 0U)
            {
              if (((focused ? 1 : 0) & 0) != 0)
                goto label_62;
            }
            else
              break;
          }
          goto label_52;
label_59:
          drawSeparator = true;
          if (this.xbf5c00c8e3dd85fc != null && this.xe477cc01ecfef1fb.IndexOf(current) == this.xe477cc01ecfef1fb.IndexOf(this.xbf5c00c8e3dd85fc) - 1)
            goto label_60;
label_57:
          if (this.xe477cc01ecfef1fb.IndexOf(current) != this.xe477cc01ecfef1fb.Count - 1)
          {
            if ((uint) focused + (uint) drawSeparator >= 0U)
              goto label_52;
          }
          else
            goto label_55;
label_60:
          drawSeparator = false;
          goto label_57;
label_62:
          state2 |= DrawItemState.Selected;
          if (((drawSeparator ? 1 : 0) & 0) == 0)
            goto label_59;
          else
            goto label_55;
label_64:
          if ((uint) selectedTabOffset - (uint) drawSeparator > uint.MaxValue)
            goto label_62;
          else
            goto label_62;
        }
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
label_68:
      selectedTabOffset = this.xbf5c00c8e3dd85fc.x123e054dab107457.X - this.Bounds.Left;
      if ((uint) selectedTabOffset + (uint) focused > uint.MaxValue)
        goto label_13;
      else
        goto label_50;
label_77:
      if (this.SelectedControl == null)
      {
        x38870620fd380a6b.DrawControlClientBackground(x41347a961b838962, this.x21ed2ecc088ef4e4, SystemColors.Control);
        if ((uint) focused - (uint) focused < 0U)
          goto label_81;
        else
          goto label_49;
      }
      else
      {
        x38870620fd380a6b.DrawControlClientBackground(x41347a961b838962, this.x21ed2ecc088ef4e4, this.SelectedControl.BackColor);
        if (false)
        {
          if ((uint) selectedTabOffset >= 0U)
            return;
          goto label_87;
        }
        else
          goto label_49;
      }
label_79:
      if (this.DockContainer.x972331c8ecf83413)
        goto label_87;
label_80:
      focused = this.x317ed3bc8decf394;
label_81:
      if ((uint) selectedTabOffset + (uint) focused < 0U)
        goto label_49;
      else
        goto label_77;
label_84:
      if (this.IsInContainer)
        goto label_79;
      else
        goto label_80;
label_87:
      focused = ((ISelectionService) this.DockContainer.x7159e85e85b84817(typeof (ISelectionService))).GetComponentSelected((object) this.SelectedControl);
      if ((uint) drawSeparator <= uint.MaxValue)
        goto label_77;
      else
        goto label_49;
    }

    internal void xb30ec7cfdf3e5c19(
      Graphics x41347a961b838962,
      RendererBase x38870620fd380a6b,
      x0a9f5257a10031b2 x128517d7ded59312,
      SandDockButtonType x271bd5d42b3ea793,
      bool x2fef7d841879a711)
    {
      if (!x128517d7ded59312.x364c1e3b189d47fe)
        return;
      DrawItemState state = DrawItemState.Default;
      if (this.x1f43ebe301d1df45 == x128517d7ded59312)
        goto label_5;
label_2:
      if (!x2fef7d841879a711)
        goto label_3;
label_1:
      x38870620fd380a6b.DrawDocumentStripButton(x41347a961b838962, x128517d7ded59312.xda73fcb97c77d998, x271bd5d42b3ea793, state);
      return;
label_3:
      state |= DrawItemState.Disabled;
      goto label_1;
label_5:
      state |= DrawItemState.HotLight;
      if (this.xfa5e20eb950b9ee1)
      {
        state |= DrawItemState.Selected;
        goto label_2;
      }
      else
        goto label_2;
    }

    internal virtual void xd541e2fc281b554b()
    {
      if (this.x10ac79a4257c7f52 == null)
      {
        if (!this.IsInContainer)
          return;
        this.DockContainer.Invalidate(this.xb48529af1739dd06);
      }
      else
      {
        if (this.x10ac79a4257c7f52.x23498f53d87354d4 != this)
          return;
        this.x10ac79a4257c7f52.xbb5f70c792fb9034(this.xb48529af1739dd06);
      }
    }

    internal override void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
    {
      base.x46ff430ed3944e0f(x11d58b056c032b03);
      while (x11d58b056c032b03 != null && x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.None && x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.AlreadyActioned)
      {
label_20:
        DockControl selectedControl = this.SelectedControl;
        SandDockManager manager = this.DockContainer.Manager;
        if (true)
          goto label_21;
label_2:
        if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.CreateNewContainer)
          break;
label_3:
        this.x6b145af772038ef2(manager, selectedControl, this.x49cf4e0157d9436c, x11d58b056c032b03);
        if (selectedControl != null)
        {
          selectedControl.Activate();
          break;
        }
label_18:
        if (true)
          break;
        if (true)
          continue;
        goto label_20;
label_21:
        if (this.x49cf4e0157d9436c)
          goto label_22;
        else
          goto label_14;
label_6:
        if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.Float)
        {
          if (true)
          {
            if (x11d58b056c032b03.dockContainer != null)
              goto label_3;
            else
              goto label_2;
          }
          else
            goto label_18;
        }
        else
          goto label_16;
label_14:
        LayoutUtilities.xf1cbd48a28ce6e74(selectedControl);
label_15:
        if (true)
          goto label_6;
label_16:
        selectedControl.MetaData.x87f4a9b62a380563(Guid.NewGuid());
        if (!this.x49cf4e0157d9436c)
        {
          if (true)
          {
            selectedControl.OpenFloating(x11d58b056c032b03.bounds, WindowOpenMethod.OnScreenActivate);
            break;
          }
          goto label_15;
        }
        else
        {
          do
          {
            this.Float(manager, x11d58b056c032b03.bounds, WindowOpenMethod.OnScreenActivate);
            if (false)
              goto label_14;
          }
          while (false);
          break;
        }
label_22:
        LayoutUtilities.x4487f2f8917e3fd0(this);
        if (true)
        {
          if (false)
            break;
          goto label_6;
        }
      }
    }

    internal void x6b145af772038ef2(
      SandDockManager x91f347c6e97f1846,
      DockControl x43bec302f92080b9,
      bool x49cf4e0157d9436c,
      xedb4922162c60d3d.DockTarget x11d58b056c032b03)
    {
      DockContainer dockedContainer;
      if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.JoinExistingSystem)
      {
        if ((uint) x49cf4e0157d9436c <= uint.MaxValue)
          goto label_27;
      }
      else
      {
        if (x11d58b056c032b03.type == xedb4922162c60d3d.DockTargetType.CreateNewContainer)
          goto label_25;
        else
          goto label_9;
label_2:
        DockContainer dockContainer = x11d58b056c032b03.dockContainer;
        DockControl[] controls;
        if (!x49cf4e0157d9436c)
          controls = new DockControl[1]{ x43bec302f92080b9 };
        else
          controls = this.x9476096be9672d38;
        SizeF workingSize = this.WorkingSize;
        ControlLayoutSystem newLayoutSystem = dockContainer.CreateNewLayoutSystem(controls, workingSize);
        x11d58b056c032b03.layoutSystem.SplitForLayoutSystem((LayoutSystemBase) newLayoutSystem, x11d58b056c032b03.dockSide);
        return;
label_9:
        if ((uint) x49cf4e0157d9436c + (uint) x49cf4e0157d9436c < 0U || x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.SplitExistingSystem)
        {
          if (true)
          {
            if (true)
              return;
            goto label_27;
          }
          else
            goto label_19;
        }
        else
          goto label_2;
label_25:
        dockedContainer = x91f347c6e97f1846.FindDockedContainer(DockStyle.Fill);
        if (x11d58b056c032b03.dockLocation != ContainerDockLocation.Center || dockedContainer == null)
        {
          if (!x49cf4e0157d9436c)
            goto label_12;
          else
            goto label_13;
label_6:
          if (true)
            return;
          goto label_2;
label_12:
          x43bec302f92080b9.DockInNewContainer(x11d58b056c032b03.dockLocation, x11d58b056c032b03.middle ? ContainerDockEdge.Inside : ContainerDockEdge.Outside);
          goto label_6;
label_13:
          this.x810df8ef88cf4bf2(x91f347c6e97f1846, x11d58b056c032b03.dockLocation, x11d58b056c032b03.middle ? ContainerDockEdge.Inside : ContainerDockEdge.Outside);
          if ((uint) x49cf4e0157d9436c - (uint) x49cf4e0157d9436c <= uint.MaxValue)
          {
            if (false)
              ;
            return;
          }
          goto label_6;
        }
      }
label_19:
      ControlLayoutSystem controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem(dockedContainer);
      if (controlLayoutSystem == null)
        return;
      if (x49cf4e0157d9436c)
        goto label_21;
label_15:
      x43bec302f92080b9.x02847d0dec2e498a(controlLayoutSystem, 0);
      return;
label_21:
      this.Dock(controlLayoutSystem);
      if ((uint) x49cf4e0157d9436c + (uint) x49cf4e0157d9436c >= 0U)
        return;
      goto label_15;
label_27:
      if (!x49cf4e0157d9436c)
        x43bec302f92080b9.x02847d0dec2e498a(x11d58b056c032b03.layoutSystem, x11d58b056c032b03.index);
      else
        this.Dock(x11d58b056c032b03.layoutSystem, x11d58b056c032b03.index);
    }

    public void SplitForLayoutSystem(LayoutSystemBase layoutSystem, DockSide side)
    {
      if (layoutSystem != null)
        goto label_21;
      else
        goto label_26;
label_11:
      if (true)
        return;
label_18:
      SplitLayoutSystem parent = this.Parent;
      if (parent.SplitMode != Orientation.Horizontal)
      {
        while (parent.SplitMode == Orientation.Vertical)
        {
label_4:
          if (side != DockSide.Left)
            goto label_9;
label_5:
          this.x46d2db93dc2104ad(layoutSystem, side == DockSide.Left ? parent.LayoutSystems.IndexOf((LayoutSystemBase) this) : parent.LayoutSystems.IndexOf((LayoutSystemBase) this) + 1, false);
          if (true)
          {
            if (false)
            {
              if (false)
                break;
              continue;
            }
            if (true)
              break;
            goto label_11;
          }
          else if (true)
            goto label_4;
label_9:
          if (side != DockSide.Right)
          {
            this.xd2be843c6119e3c3(layoutSystem, Orientation.Horizontal, side == DockSide.Top);
            break;
          }
          goto label_5;
        }
        return;
      }
      if (side != DockSide.Top && side != DockSide.Bottom)
      {
        this.xd2be843c6119e3c3(layoutSystem, Orientation.Vertical, side == DockSide.Left);
        goto label_11;
      }
      else
      {
        this.x46d2db93dc2104ad(layoutSystem, side == DockSide.Top ? parent.LayoutSystems.IndexOf((LayoutSystemBase) this) : parent.LayoutSystems.IndexOf((LayoutSystemBase) this) + 1, true);
        return;
      }
label_21:
      while (side != DockSide.None)
      {
        if (true)
          goto label_20;
        else
          goto label_23;
label_19:
        throw new InvalidOperationException("This layout system must be removed from its parent before it can be moved to a new layout system.");
label_20:
        if (layoutSystem.Parent == null)
        {
          if (this.Parent == null)
            throw new InvalidOperationException("This layout system is not parented yet.");
          goto label_18;
        }
        else
          goto label_19;
label_23:
        if (true)
          goto label_19;
      }
      throw new ArgumentException(nameof (side));
label_26:
      if (true)
        throw new ArgumentNullException(nameof (layoutSystem));
      goto label_11;
    }

    private void x46d2db93dc2104ad(
      LayoutSystemBase x6e150040c8d97700,
      int xc0c4c459c6ccbd00,
      bool xab8cd0402556fe8f)
    {
      SplitLayoutSystem parent = this.Parent;
      parent.LayoutSystems.xd7a3953bce504b63 = true;
      parent.LayoutSystems.Insert(xc0c4c459c6ccbd00, x6e150040c8d97700);
      parent.LayoutSystems.xd7a3953bce504b63 = false;
      parent.x8e9e04a70e31e166();
    }

    private void xd2be843c6119e3c3(
      LayoutSystemBase x6e150040c8d97700,
      Orientation xf65758d54b79fc7a,
      bool x6b161b1ae41c1651)
    {
      SplitLayoutSystem parent = this.Parent;
label_8:
      SplitLayoutSystem splitLayoutSystem = new SplitLayoutSystem();
      splitLayoutSystem.SplitMode = xf65758d54b79fc7a;
      splitLayoutSystem.WorkingSize = this.WorkingSize;
      int index = parent.LayoutSystems.IndexOf((LayoutSystemBase) this);
      parent.LayoutSystems.xd7a3953bce504b63 = true;
      parent.LayoutSystems.Remove((LayoutSystemBase) this);
      parent.LayoutSystems.Insert(index, (LayoutSystemBase) splitLayoutSystem);
      do
      {
        parent.LayoutSystems.xd7a3953bce504b63 = false;
        if (true)
        {
          if ((uint) x6b161b1ae41c1651 + (uint) index >= 0U)
            goto label_4;
        }
        else
          goto label_8;
      }
      while ((uint) index > uint.MaxValue);
label_2:
      splitLayoutSystem.LayoutSystems.Add(x6e150040c8d97700);
      if (((x6b161b1ae41c1651 ? 1 : 0) | 3) == 0)
        goto label_5;
label_3:
      parent.x8e9e04a70e31e166();
      return;
label_4:
      splitLayoutSystem.LayoutSystems.Add((LayoutSystemBase) this);
label_5:
      if ((uint) index - (uint) x6b161b1ae41c1651 < 0U || x6b161b1ae41c1651)
      {
        splitLayoutSystem.LayoutSystems.Insert(0, x6e150040c8d97700);
        goto label_3;
      }
      else
        goto label_2;
    }

    internal void x18f55df6f6629e9f(DockSituation x7e49ae9bddfdfd07)
    {
      if (this.Controls.Count != 0)
      {
        if (this.SelectedControl.DockSituation == x7e49ae9bddfdfd07)
          return;
        DockControl selectedControl = this.SelectedControl;
        DockControl[] array = new DockControl[this.Controls.Count];
        this.Controls.CopyTo(array, 0);
        LayoutUtilities.x4487f2f8917e3fd0(this);
        if (true)
        {
          if (false)
            goto label_3;
          else
            goto label_8;
label_1:
          throw new InvalidOperationException();
label_3:
          DockControl[] controls;
          Array.Copy((Array) array, 1, (Array) controls, 0, array.Length - 1);
          array[0].LayoutSystem.Controls.AddRange(controls);
          array[0].LayoutSystem.SelectedControl = selectedControl;
          if (true)
            return;
          goto label_1;
label_8:
          this.Controls.Clear();
          if (false)
            ;
          switch (x7e49ae9bddfdfd07)
          {
            case DockSituation.Docked:
              array[0].OpenDocked(WindowOpenMethod.OnScreenActivate);
              if (true)
                break;
              goto label_12;
            case DockSituation.Document:
              array[0].OpenDocument(WindowOpenMethod.OnScreenActivate);
              break;
            case DockSituation.Floating:
              array[0].OpenFloating(WindowOpenMethod.OnScreenActivate);
              break;
            default:
              goto label_1;
          }
          controls = new DockControl[array.Length - 1];
          goto label_3;
        }
      }
label_12:
      throw new InvalidOperationException();
    }

    public void Float(SandDockManager manager, Rectangle bounds, WindowOpenMethod openMethod)
    {
      if (this.Parent != null)
      {
        if (true)
        {
          LayoutUtilities.x4487f2f8917e3fd0(this);
          goto label_5;
        }
      }
      else
        goto label_5;
label_2:
      x410f3612b9a8f9de x410f3612b9a8f9de;
      x410f3612b9a8f9de.LayoutSystem.LayoutSystems.Add((LayoutSystemBase) this);
      x410f3612b9a8f9de.x159713d3b60fae0c(bounds, true, openMethod == WindowOpenMethod.OnScreenActivate);
      if (openMethod != WindowOpenMethod.OnScreenActivate)
        return;
      this.SelectedControl.Activate();
      return;
label_5:
      if (this.SelectedControl.MetaData.LastFloatingWindowGuid == Guid.Empty)
        goto label_9;
label_6:
      x410f3612b9a8f9de = new x410f3612b9a8f9de(manager, this.SelectedControl.MetaData.LastFloatingWindowGuid);
      if (false)
        return;
      goto label_2;
label_9:
      this.SelectedControl.MetaData.x87f4a9b62a380563(Guid.NewGuid());
      goto label_6;
    }

    public void Float(SandDockManager manager)
    {
      if (this.SelectedControl == null)
        throw new InvalidOperationException("The layout system must have a selected control to be floated.");
      this.Float(manager, this.SelectedControl.xc0154d85fceb081c(), WindowOpenMethod.OnScreenActivate);
    }

    public void Dock(ControlLayoutSystem layoutSystem)
    {
      if (layoutSystem == null)
        throw new ArgumentNullException();
      this.Dock(layoutSystem, 0);
    }

    public void Dock(ControlLayoutSystem layoutSystem, int index)
    {
      if (layoutSystem != null)
      {
        if (this.Parent != null)
          throw new InvalidOperationException("This layout system already has a parent. To remove it, use the parent layout system's LayoutSystems.Remove method.");
        if ((uint) index + (uint) index < 0U)
          return;
        if (true)
          goto label_8;
        else
          goto label_15;
label_3:
        DockControl selectedControl;
        if (this.xe477cc01ecfef1fb.Count == 0)
        {
          if (selectedControl == null)
            return;
          layoutSystem.SelectedControl = selectedControl;
          if (true)
            return;
          goto label_14;
        }
label_7:
        DockControl control = this.xe477cc01ecfef1fb[0];
        goto label_16;
label_8:
        selectedControl = this.SelectedControl;
        goto label_3;
label_15:
        if ((uint) index - (uint) index >= 0U)
          goto label_7;
label_16:
        if ((index & 0) != 0)
          return;
        this.xe477cc01ecfef1fb.RemoveAt(0);
        layoutSystem.Controls.Insert(index, control);
        goto label_3;
      }
label_14:
      throw new ArgumentNullException();
    }

    internal override void x56e964269d48cfcc(DockContainer x0467b00af7810f0c)
    {
      if (x0467b00af7810f0c == null)
      {
        if (false)
        {
          if (true)
            goto label_11;
          else
            goto label_5;
        }
        else
          goto label_31;
      }
      else
        goto label_21;
label_3:
      if (this.x10ac79a4257c7f52 == null)
        return;
      this.x10ac79a4257c7f52.x7fdaeb05cb5e84f3.x52b190e626f65140(this);
      if (false)
        return;
      if (true)
      {
        if (true)
          return;
        goto label_11;
      }
      else
        goto label_8;
label_5:
      if (x0467b00af7810f0c.Manager == null || this.x10ac79a4257c7f52 != null)
        goto label_3;
label_8:
      x0467b00af7810f0c.Manager.GetAutoHideBar(x0467b00af7810f0c.Dock)?.x7fdaeb05cb5e84f3.xd6b6ed77479ef68c(this);
      return;
label_11:
      foreach (DockControl control in (CollectionBase) this.Controls)
        control.x56e964269d48cfcc(x0467b00af7810f0c);
      if (!this.Collapsed)
        return;
      if (true)
      {
        if (x0467b00af7810f0c == null)
          goto label_3;
        else
          goto label_5;
      }
      else
        goto label_31;
label_21:
      if (x0467b00af7810f0c != null && !this.IsInContainer)
        goto label_32;
label_22:
      base.x56e964269d48cfcc(x0467b00af7810f0c);
      goto label_11;
label_32:
      IEnumerator enumerator1 = this.Controls.GetEnumerator();
      try
      {
        while (true)
        {
          if (!enumerator1.MoveNext())
          {
            if (true)
              goto label_22;
          }
          DockControl current = (DockControl) enumerator1.Current;
          if (current.Parent != null)
            goto label_41;
label_39:
          current.Location = new System.Drawing.Point(x0467b00af7810f0c.Width, x0467b00af7810f0c.Height);
          if (!this.Collapsed || !x0467b00af7810f0c.x0c2484ccd29b8358)
          {
            current.Parent = (Control) x0467b00af7810f0c;
            continue;
          }
          continue;
label_41:
          LayoutUtilities.xa7513d57b4844d46((Control) current);
          goto label_39;
        }
      }
      finally
      {
        (enumerator1 as IDisposable)?.Dispose();
      }
label_31:
      if (this.IsInContainer)
      {
        IEnumerator enumerator2 = this.Controls.GetEnumerator();
        try
        {
          while (enumerator2.MoveNext())
          {
            DockControl current = (DockControl) enumerator2.Current;
            if (current.Parent == this.DockContainer)
              LayoutUtilities.xa7513d57b4844d46((Control) current);
          }
          goto label_21;
        }
        finally
        {
          (enumerator2 as IDisposable)?.Dispose();
        }
      }
      else
        goto label_21;
    }

    public virtual DockControl GetControlAt(System.Drawing.Point position)
    {
      if (this.xa358da7dd5364cab.Contains(position) && !this.x26e80f23e22a05ae.xda73fcb97c77d998.Contains(position) && !this.x65911b61bef3a921.xda73fcb97c77d998.Contains(position))
      {
        IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator();
        try
        {
          DockControl current;
          while (enumerator.MoveNext())
          {
            current = (DockControl) enumerator.Current;
            Rectangle x123e054dab107457 = current.x123e054dab107457;
            if (false)
              ;
            if (x123e054dab107457.Contains(position))
              goto label_6;
          }
          if (true)
            goto label_11;
label_6:
          return current;
        }
        finally
        {
          (enumerator as IDisposable)?.Dispose();
        }
      }
label_11:
      return (DockControl) null;
    }

    internal int x17fd454c85fad336(System.Drawing.Point x13d4cb8d1bd20347)
    {
      int num = 0;
      foreach (DockControl dockControl in (CollectionBase) this.xe477cc01ecfef1fb)
      {
        Rectangle x123e054dab107457 = dockControl.x123e054dab107457;
        if (x13d4cb8d1bd20347.X > x123e054dab107457.Left + x123e054dab107457.Width / 2)
          ++num;
      }
      return num;
    }

    internal void x3e0280cae730d1f2()
    {
      if (this.x10ac79a4257c7f52 != null)
        this.x10ac79a4257c7f52.x200394302d96eb9b(this);
      if (!this.IsInContainer)
        return;
      if (!this.DockContainer.IsFloating)
        this.DockContainer.xec9697acef66c1bc((LayoutSystemBase) this, this.Bounds);
      else
        goto label_6;
label_2:
      this.DockContainer.Invalidate(this.Bounds);
      return;
label_6:
      this.DockContainer.CalculateAllMetricsAndLayout();
      goto label_2;
    }

    private void x5425d90305f1baa5()
    {
      if (this.xbf5c00c8e3dd85fc == null)
      {
        this.x26e80f23e22a05ae.x364c1e3b189d47fe = false;
        this.x65911b61bef3a921.x364c1e3b189d47fe = false;
        this.x3b444f64233558c3.x364c1e3b189d47fe = false;
      }
      else
      {
        int y = this.xb48529af1739dd06.Top + this.xb48529af1739dd06.Height / 2 - 7;
        int num1 = this.xb48529af1739dd06.Right - 2;
        if (this.xbf5c00c8e3dd85fc.AllowClose)
          goto label_12;
        else
          goto label_9;
label_3:
        this.x65911b61bef3a921.x364c1e3b189d47fe = false;
label_4:
        if (!this.xbf5c00c8e3dd85fc.ShowOptions)
        {
          this.x3b444f64233558c3.x364c1e3b189d47fe = false;
          return;
        }
        this.x3b444f64233558c3.x364c1e3b189d47fe = true;
        if ((uint) y + (uint) num1 >= 0U)
        {
          this.x3b444f64233558c3.xda73fcb97c77d998 = new Rectangle(num1 - 19, y, 19, 15);
          int num2 = num1 - 21;
          return;
        }
        goto label_7;
label_6:
        if (this.x43d7533e3cdb2944)
          goto label_10;
        else
          goto label_3;
label_7:
        if (!this.DockContainer.x0c2484ccd29b8358)
          goto label_3;
label_8:
        this.x65911b61bef3a921.x364c1e3b189d47fe = true;
        this.x65911b61bef3a921.xda73fcb97c77d998 = new Rectangle(num1 - 19, y, 19, 15);
        num1 -= 21;
        goto label_4;
label_9:
        this.x26e80f23e22a05ae.x364c1e3b189d47fe = false;
        if ((uint) y - (uint) num1 <= uint.MaxValue)
          goto label_6;
label_10:
        if (this.IsInContainer)
        {
          if ((uint) y >= 0U)
            goto label_7;
          else
            goto label_6;
        }
        else
          goto label_8;
label_12:
        this.x26e80f23e22a05ae.x364c1e3b189d47fe = true;
        this.x26e80f23e22a05ae.xda73fcb97c77d998 = new Rectangle(num1 - 19, y, 19, 15);
        num1 -= 21;
        goto label_6;
      }
    }

    protected internal virtual void LayoutCollapsed(RendererBase renderer, Rectangle bounds)
    {
      this.xb48529af1739dd06 = bounds;
      if (false)
        goto label_12;
      else
        goto label_13;
label_1:
      IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
        {
          DockControl current = (DockControl) enumerator.Current;
          Rectangle rectangle;
          do
          {
            rectangle = renderer.AdjustDockControlClientBounds(this, current, this.x21ed2ecc088ef4e4);
          }
          while (false);
          current.xbdd4aaac1291a8c7(current == this.xbf5c00c8e3dd85fc);
          current.Bounds = rectangle;
        }
        return;
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        if (true)
          goto label_9;
label_8:
        disposable.Dispose();
        if (true)
          goto label_11;
label_9:
        if (disposable == null)
        {
          if (false)
            ;
        }
        else
          goto label_8;
label_11:;
      }
label_12:
      this.x5425d90305f1baa5();
      bounds.Offset(0, renderer.TitleBarMetrics.Height);
      bounds.Height -= renderer.TitleBarMetrics.Height;
      this.x21ed2ecc088ef4e4 = bounds;
      this.xa358da7dd5364cab = Rectangle.Empty;
      goto label_1;
label_13:
      this.xb48529af1739dd06.Offset(0, renderer.TitleBarMetrics.Margin.Top);
      this.xb48529af1739dd06.Height = renderer.TitleBarMetrics.Height - (renderer.TitleBarMetrics.Margin.Top + renderer.TitleBarMetrics.Margin.Bottom);
      if (true)
        goto label_12;
      else
        goto label_1;
    }

    protected virtual void CalculateLayout(
      RendererBase renderer,
      Rectangle bounds,
      bool floating,
      out Rectangle titlebarBounds,
      out Rectangle tabstripBounds,
      out Rectangle clientBounds,
      out Rectangle joinCatchmentBounds)
    {
      if (floating)
      {
        if (true)
          goto label_19;
      }
      else
        goto label_17;
label_2:
      if (true)
      {
        if (false)
          goto label_12;
      }
      else
        goto label_18;
label_4:
      tabstripBounds = Rectangle.Empty;
label_5:
      clientBounds = bounds;
      joinCatchmentBounds = titlebarBounds;
      if (true)
        return;
      goto label_19;
label_6:
      while (this.Controls.Count <= 1)
      {
        if (this.DockContainer.x972331c8ecf83413)
        {
          if (true)
            break;
        }
        else if ((uint) floating + (uint) floating >= 0U)
        {
          if ((uint) floating > uint.MaxValue)
            return;
          goto label_2;
        }
        else
          goto label_19;
      }
      tabstripBounds = bounds;
      tabstripBounds.Y = tabstripBounds.Bottom - renderer.TabStripMetrics.Height;
label_9:
      tabstripBounds.Height = renderer.TabStripMetrics.Height;
      tabstripBounds = renderer.TabStripMetrics.RemoveMargin(tabstripBounds);
      bounds.Height -= renderer.TabStripMetrics.Height;
      goto label_5;
label_11:
      this.x5425d90305f1baa5();
label_12:
      bounds.Offset(0, renderer.TitleBarMetrics.Height);
      if (((floating ? 1 : 0) & 0) == 0)
      {
        bounds.Height -= renderer.TitleBarMetrics.Height;
        goto label_6;
      }
      else
        goto label_5;
label_17:
      titlebarBounds = bounds;
label_18:
      titlebarBounds.Offset(0, renderer.TitleBarMetrics.Margin.Top);
      titlebarBounds.Height = renderer.TitleBarMetrics.Height - (renderer.TitleBarMetrics.Margin.Top + renderer.TitleBarMetrics.Margin.Bottom);
      if ((uint) floating - (uint) floating >= 0U)
        goto label_11;
label_19:
      titlebarBounds = Rectangle.Empty;
      if ((uint) floating + (uint) floating >= 0U)
      {
        if (((floating ? 1 : 0) | 8) != 0)
        {
          if ((uint) floating - (uint) floating < 0U)
            goto label_9;
          else
            goto label_6;
        }
        else
          goto label_11;
      }
      else
        goto label_4;
    }

    internal Rectangle xccb1fc68964285c2
    {
      get
      {
        return this.xc78399ba98eab19f;
      }
    }

    private void x7fd1f193b21c8833()
    {
      foreach (DockControl control in (CollectionBase) this.Controls)
        control.x44fd51d909a57a2a();
    }

    protected internal override void Layout(
      RendererBase renderer,
      Graphics graphics,
      Rectangle bounds,
      bool floating)
    {
      base.Layout(renderer, graphics, bounds, floating);
      this.x7fd1f193b21c8833();
      if (this.Collapsed && this.DockContainer.x0c2484ccd29b8358)
        return;
      this.CalculateLayout(renderer, bounds, floating, out this.xb48529af1739dd06, out this.xa358da7dd5364cab, out this.x21ed2ecc088ef4e4, out this.xc78399ba98eab19f);
      this.xd30df1068ed42e28 = true;
      try
      {
        if (this.xb48529af1739dd06 != Rectangle.Empty)
          this.x5425d90305f1baa5();
        this.x5d6e30ce9634c49e(renderer, graphics, this.xa358da7dd5364cab);
        foreach (DockControl dockControl in (CollectionBase) this.xe477cc01ecfef1fb)
        {
          if (dockControl != this.SelectedControl)
            dockControl.xbdd4aaac1291a8c7(false);
        }
        foreach (DockControl control in (CollectionBase) this.xe477cc01ecfef1fb)
        {
          if (control == this.SelectedControl)
          {
            if ((uint) floating > uint.MaxValue)
              break;
            Rectangle rectangle = renderer.AdjustDockControlClientBounds(this, control, this.x21ed2ecc088ef4e4);
            control.Bounds = rectangle;
            control.xbdd4aaac1291a8c7(true);
          }
        }
      }
      finally
      {
        this.xd30df1068ed42e28 = false;
      }
    }

    private void x5d6e30ce9634c49e(
      RendererBase x38870620fd380a6b,
      Graphics x41347a961b838962,
      Rectangle xa358da7dd5364cab)
    {
      int num1 = 0;
      int num2 = xa358da7dd5364cab.Width - (x38870620fd380a6b.TabStripMetrics.Padding.Left + x38870620fd380a6b.TabStripMetrics.Padding.Right);
      int num3;
      if ((num3 | 4) == 0)
        return;
label_16:
      do
      {
        int[] numArray = new int[this.xe477cc01ecfef1fb.Count];
        int num4;
        if ((uint) num4 + (uint) num4 <= uint.MaxValue)
          goto label_17;
label_12:
        int index1;
        int index2;
        for (; index2 < index1; ++index2)
        {
          numArray[index2] -= (int) ((double) num4 * ((double) numArray[index2] / (double) num1));
          this.xe477cc01ecfef1fb[index2].xcfac6723d8a41375 = true;
        }
label_13:
        xa358da7dd5364cab = x38870620fd380a6b.TabStripMetrics.RemovePadding(xa358da7dd5364cab);
        int left = xa358da7dd5364cab.Left;
        int index3;
        int val1;
        if ((num4 | -1) != 0)
        {
          index1 = 0;
          index3 = 0;
          while (true)
          {
            if (index3 < this.xe477cc01ecfef1fb.Count)
              goto label_10;
            else
              goto label_5;
label_3:
            ++index1;
            ++index3;
            continue;
label_5:
            if ((uint) num1 + (uint) index2 <= uint.MaxValue)
            {
              if ((uint) index2 - (uint) val1 > uint.MaxValue)
              {
                if (false)
                {
                  if ((num1 | -1) != 0)
                    goto label_15;
                }
                else
                  goto label_16;
              }
              else
                break;
            }
            else
              goto label_3;
label_9:
            BoxModel tabMetrics = x38870620fd380a6b.TabMetrics;
            Rectangle rectangle = new Rectangle(left + tabMetrics.Margin.Left, xa358da7dd5364cab.Top + tabMetrics.Margin.Top, tabMetrics.Padding.Left + numArray[index1] + tabMetrics.Padding.Right, xa358da7dd5364cab.Height - (tabMetrics.Margin.Top + tabMetrics.Margin.Bottom));
            DockControl dockControl;
            dockControl.x123e054dab107457 = rectangle;
            left += rectangle.Width + tabMetrics.ExtraWidth;
            goto label_3;
label_10:
            dockControl = this.xe477cc01ecfef1fb[index3];
            goto label_9;
          }
          if (true)
            continue;
          goto label_12;
        }
label_15:
        num4 = num1 - num2;
        index2 = 0;
        goto label_12;
label_17:
        index1 = 0;
        IEnumerator enumerator = this.xe477cc01ecfef1fb.GetEnumerator();
        try
        {
label_19:
          if (enumerator.MoveNext())
          {
            DockControl current = (DockControl) enumerator.Current;
            current.xcfac6723d8a41375 = false;
            System.Drawing.Size size = x38870620fd380a6b.MeasureTabStripTab(x41347a961b838962, current.TabImage, current.TabText, current.Font, DrawItemState.Default);
label_27:
            do
            {
              val1 = size.Width;
              if (current.MinimumTabWidth != 0)
                goto label_28;
label_25:
              while (current.MaximumTabWidth != 0 && current.MaximumTabWidth < val1)
              {
                if ((index3 | 2) != 0)
                {
                  if ((num4 & 0) == 0)
                  {
                    do
                    {
                      val1 = current.MaximumTabWidth;
                      current.xcfac6723d8a41375 = true;
                      if ((uint) num2 + (uint) left > uint.MaxValue)
                        goto label_25;
                    }
                    while ((num2 & 0) != 0);
                    break;
                  }
                  goto label_22;
                }
                else
                  goto label_27;
              }
              num1 += val1;
label_22:
              numArray[index1++] = val1;
              continue;
label_28:
              val1 = Math.Max(val1, current.MinimumTabWidth);
              goto label_25;
            }
            while ((uint) index2 < 0U);
            goto label_19;
          }
        }
        finally
        {
          IDisposable disposable = enumerator as IDisposable;
          if ((val1 & 0) != 0 || disposable != null)
            disposable.Dispose();
        }
        if (num1 <= num2)
          goto label_13;
        else
          goto label_15;
      }
      while ((uint) num2 > uint.MaxValue);
    }

    public class DockControlCollection : CollectionBase
    {
      private ControlLayoutSystem xb6a159a84cb992d6;
      private bool x6278c23b2376c7c7;
      private bool xa536df1e17daee9d;

      internal DockControlCollection(ControlLayoutSystem parent)
      {
        this.xb6a159a84cb992d6 = parent;
      }

      internal int x259d21cdec19b1cf(int xff665e1cf667e663, bool x1743ddb153315e91)
      {
        if (xff665e1cf667e663 < 0 || xff665e1cf667e663 > this.Count)
        {
          do
          {
            xff665e1cf667e663 = x1743ddb153315e91 ? this.Count : 0;
          }
          while (false);
        }
        return xff665e1cf667e663;
      }

      public void SetChildIndex(DockControl control, int index)
      {
        if (control != null)
        {
label_10:
          while (this.Contains(control))
          {
            while (index != this.IndexOf(control))
            {
              if (this.IndexOf(control) >= index)
                goto label_3;
label_1:
              --index;
label_3:
              this.xa536df1e17daee9d = true;
              this.List.Remove((object) control);
              this.List.Insert(index, (object) control);
              this.xa536df1e17daee9d = false;
              this.xb6a159a84cb992d6.x3e0280cae730d1f2();
              if ((uint) index - (uint) index >= 0U)
              {
                if (true)
                  break;
                if (false)
                {
                  if (false)
                    goto label_14;
                }
                else
                {
                  if ((uint) index + (uint) index > uint.MaxValue)
                    break;
                  goto label_10;
                }
              }
              else
                goto label_1;
            }
            return;
          }
          throw new ArgumentOutOfRangeException(nameof (control));
        }
label_14:
        throw new ArgumentNullException(nameof (control));
      }

      protected override void OnClear()
      {
        base.OnClear();
        foreach (DockControl dockControl in (CollectionBase) this)
        {
          dockControl.xb2b69aae23a4ae6d((ControlLayoutSystem) null);
          dockControl.x44fd51d909a57a2a();
        }
      }

      protected override void OnClearComplete()
      {
        base.OnClearComplete();
        this.xb6a159a84cb992d6.SelectedControl = (DockControl) null;
        this.xb6a159a84cb992d6.x3e0280cae730d1f2();
        if (false)
          ;
        if (this.xb6a159a84cb992d6.DockContainer == null)
          return;
        this.xb6a159a84cb992d6.DockContainer.x5fc4eceec879ff0f();
      }

      protected override void OnInsertComplete(int index, object value)
      {
        base.OnInsertComplete(index, value);
label_25:
        while (!this.xa536df1e17daee9d)
        {
          DockControl dockControl = (DockControl) value;
          dockControl.xb2b69aae23a4ae6d(this.xb6a159a84cb992d6);
          if (this.xb6a159a84cb992d6.IsInContainer && (this.xb6a159a84cb992d6.DockContainer.Manager != null && this.xb6a159a84cb992d6.DockContainer.Manager != dockControl.Manager))
            goto label_22;
label_20:
          if (this.xb6a159a84cb992d6.IsInContainer)
            goto label_19;
          else
            goto label_13;
label_7:
          if (this.xb6a159a84cb992d6.xbf5c00c8e3dd85fc == null)
            goto label_6;
label_5:
          while (this.xb6a159a84cb992d6.DockContainer != null)
          {
            this.xb6a159a84cb992d6.DockContainer.x5fc4eceec879ff0f();
            if ((index & 0) == 0)
            {
              if (true)
                break;
            }
            else
              goto label_25;
          }
          if (this.x6278c23b2376c7c7)
            break;
          this.xb6a159a84cb992d6.x3e0280cae730d1f2();
          if ((uint) index - (uint) index >= 0U)
            break;
          if (true)
            continue;
          goto label_19;
label_6:
          this.xb6a159a84cb992d6.SelectedControl = dockControl;
          goto label_5;
label_9:
          if (dockControl.Parent != null)
            goto label_12;
label_10:
          dockControl.Parent = this.xb6a159a84cb992d6.x0e40cec3a0be4a70;
          goto label_7;
label_11:
          if (!this.xb6a159a84cb992d6.IsInContainer)
          {
            if (true)
              goto label_7;
            else
              continue;
          }
          else
            goto label_9;
label_12:
          LayoutUtilities.xa7513d57b4844d46((Control) dockControl);
          goto label_10;
label_13:
          if (true)
            goto label_11;
label_18:
          if (true)
          {
            if (true)
            {
              if (false)
              {
                if (true)
                {
                  if (true)
                    goto label_9;
                  else
                    goto label_12;
                }
              }
              else
                goto label_11;
            }
            else
              goto label_13;
          }
          else
            goto label_20;
label_19:
          dockControl.x56e964269d48cfcc(this.xb6a159a84cb992d6.DockContainer);
          if ((uint) index - (uint) index >= 0U)
            goto label_18;
label_22:
          dockControl.Manager = this.xb6a159a84cb992d6.DockContainer.Manager;
          goto label_20;
        }
      }

      protected override void OnRemoveComplete(int index, object value)
      {
        base.OnRemoveComplete(index, value);
label_39:
        if (false)
          return;
        while (!this.xa536df1e17daee9d)
        {
          if ((index & 0) != 0)
            goto label_24;
          else
            goto label_36;
label_1:
          this.xb6a159a84cb992d6.DockContainer.x5fc4eceec879ff0f();
label_3:
          this.xb6a159a84cb992d6.x3e0280cae730d1f2();
          break;
label_5:
          if (this.xb6a159a84cb992d6.xbf5c00c8e3dd85fc == value)
            goto label_8;
          else
            goto label_6;
label_2:
          if (this.xb6a159a84cb992d6.DockContainer != null)
            goto label_1;
          else
            goto label_3;
label_6:
          if (true)
            goto label_2;
          else
            goto label_19;
label_8:
          if (this.xb6a159a84cb992d6.xe477cc01ecfef1fb.Count != 0)
          {
            this.xb6a159a84cb992d6.SelectedControl = this[0];
            goto label_2;
          }
          else if (true)
          {
            if ((uint) index + (uint) index <= uint.MaxValue)
            {
              this.xb6a159a84cb992d6.SelectedControl = (DockControl) null;
              goto label_2;
            }
            else
              goto label_2;
          }
          else
            goto label_31;
label_11:
          if (true)
            goto label_5;
label_14:
          DockControl dockControl;
          if (dockControl.Parent == this.xb6a159a84cb992d6.x0e40cec3a0be4a70)
            goto label_23;
          else
            goto label_5;
label_17:
          if (dockControl.Parent != null)
            goto label_14;
          else
            goto label_11;
label_19:
          if ((index | int.MinValue) == 0)
          {
            if (true)
              goto label_39;
          }
          else
            goto label_1;
label_21:
          if ((index & 0) != 0)
          {
            if ((uint) index + (uint) index <= uint.MaxValue)
              goto label_11;
            else
              goto label_14;
          }
          else
            goto label_17;
label_23:
          LayoutUtilities.xa7513d57b4844d46((Control) dockControl);
          if (true)
          {
            if ((uint) index >= 0U)
            {
              if ((uint) index + (uint) index < 0U)
              {
                if (true)
                {
                  if (true)
                  {
                    if (true)
                      goto label_11;
                    else
                      goto label_19;
                  }
                  else
                    goto label_14;
                }
                else
                  goto label_17;
              }
              else
                goto label_5;
            }
            else
              goto label_17;
          }
          else if ((uint) index + (uint) index <= uint.MaxValue)
            goto label_21;
          else
            goto label_14;
label_24:
          if ((uint) index <= uint.MaxValue)
            goto label_17;
          else
            goto label_14;
label_25:
          dockControl = (DockControl) value;
          if (true)
          {
            dockControl.xb2b69aae23a4ae6d((ControlLayoutSystem) null);
            if ((uint) index + (uint) index <= uint.MaxValue)
            {
              dockControl.x44fd51d909a57a2a();
              if (true)
              {
                if (false)
                {
                  if (true)
                    goto label_23;
                  else
                    goto label_39;
                }
                else
                  goto label_24;
              }
            }
            else
              goto label_17;
          }
          else
            goto label_14;
label_28:
          if ((uint) index + (uint) index > uint.MaxValue)
            goto label_37;
          else
            goto label_32;
label_29:
          if ((uint) index - (uint) index <= uint.MaxValue)
          {
            if (false)
              goto label_23;
          }
          else
            goto label_28;
label_31:
          if (true)
            goto label_25;
label_32:
          if ((uint) index < 0U)
            goto label_29;
          else
            goto label_25;
label_36:
          if (true)
            goto label_28;
label_37:
          if ((uint) index + (uint) index <= uint.MaxValue)
          {
            if ((uint) index - (uint) index >= 0U)
              goto label_29;
            else
              goto label_28;
          }
        }
      }

      public void AddRange(DockControl[] controls)
      {
        this.x6278c23b2376c7c7 = true;
        DockControl[] dockControlArray = controls;
        int num;
        if ((uint) num - (uint) num <= uint.MaxValue)
          goto label_5;
label_3:
        DockControl control;
        this.Add(control);
        int index;
        ++index;
label_4:
        if (index >= dockControlArray.Length)
        {
          this.x6278c23b2376c7c7 = false;
          this.xb6a159a84cb992d6.x3e0280cae730d1f2();
          return;
        }
        control = dockControlArray[index];
        goto label_3;
label_5:
        index = 0;
        goto label_4;
      }

      public int Add(DockControl control)
      {
        if (this.List.Contains((object) control))
          throw new InvalidOperationException("The DockControl already belongs to this ControlLayoutSystem.");
        int count = this.Count;
        this.Insert(count, control);
        return count;
      }

      public void Insert(int index, DockControl control)
      {
        if (control == null)
          return;
        if (control.LayoutSystem == this.xb6a159a84cb992d6)
          goto label_12;
label_2:
        if (control.LayoutSystem != null)
          goto label_4;
label_3:
        this.List.Insert(index, (object) control);
        if ((uint) index - (uint) index >= 0U)
          ;
        return;
label_4:
        if (this.Contains(control) && this.IndexOf(control) < index)
          goto label_5;
label_1:
        control.LayoutSystem.Controls.Remove(control);
        goto label_3;
label_5:
        --index;
        goto label_1;
label_12:
        while (this.IndexOf(control) != index && this.Count != 1)
        {
          if (true)
            goto label_2;
        }
      }

      public DockControl this[int index]
      {
        get
        {
          return (DockControl) this.List[index];
        }
      }

      public void Remove(DockControl control)
      {
        if (control == null)
          throw new ArgumentNullException(nameof (control));
        this.List.Remove((object) control);
      }

      public bool Contains(DockControl control)
      {
        return this.List.Contains((object) control);
      }

      public int IndexOf(DockControl control)
      {
        return this.List.IndexOf((object) control);
      }

      public void CopyTo(DockControl[] array, int index)
      {
        this.List.CopyTo((Array) array, index);
      }
    }

    internal delegate void xf09a9df3c262275d(DockControl oldSelection, DockControl newSelection);
  }
}
