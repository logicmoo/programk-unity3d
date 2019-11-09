// Decompiled with JetBrains decompiler
// Type: TD.SandDock.DockControl
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TD.SandDock.Design;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
  [DefaultEvent("Closing")]
  [ToolboxItem(false)]
  [Designer(typeof (DockControlDesigner))]
  public abstract class DockControl : ContainerControl
  {
    internal Rectangle x123e054dab107457 = Rectangle.Empty;
    internal Rectangle x700c42042910e68b = Rectangle.Empty;
    private string xd84978f0dad7afcd = "";
    private string xc3d462fde66905e5 = string.Empty;
    private bool x6c3086899dc42885 = true;
    private bool x9b80917b168ce488 = true;
    private Guid xb51cd75f17ace1ec = Guid.NewGuid();
    private System.Drawing.Point xc868bd63c888e533 = new System.Drawing.Point(-1, -1);
    private bool x35db3fd5e409fffb = true;
    private bool x1def1a42ad5b7095 = true;
    private SandDockManager x91f347c6e97f1846;
    private ControlLayoutSystem xb6a159a84cb992d6;
    private static Image x28afaed1891a17a1;
    private Image x564c6c527905c683;
    private TD.SandDock.Rendering.BorderStyle xacfbd7a08ba56c78;
    private bool xb98085e1d76c9b6d;
    private bool x4e7c2c44587adeda;
    private bool x131b418d4c565c70;
    internal bool xcfac6723d8a41375;
    private int x5614e4ef0596c91d;
    private int x3214e09b677ccd2b;
    private int xcf3ab1252c42eac6;
    private WindowMetaData xfffbdea061bfa120;
    private BindingContext x2464cce8c6385330;
    private System.Drawing.Size xca874006c41dfe29;
    private DockingRules xd447c58f1b8b8e4b;
    private DockControlCloseAction x8fbef9afc77bc952;
    private Control x3f02d9fd7ae06803;
    private DockSituation xef84499526c04953;

    public event DockControlClosingEventHandler Closing;

    public event EventHandler Closed;

    public event EventHandler Load;

    public event EventHandler AutoHidePopupOpened;

    public event EventHandler AutoHidePopupClosed;

    public event EventHandler DockSituationChanged;

    protected DockControl()
    {
      if (true)
        goto label_7;
label_2:
      if (this.xd447c58f1b8b8e4b == null)
        throw new InvalidOperationException();
      this.SetStyle(ControlStyles.ResizeRedraw, true);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
label_5:
      this.SetStyle(ControlStyles.Selectable, false);
      this.BackColor = SystemColors.Control;
      this.xca874006c41dfe29 = this.DefaultSize;
      if (true)
        return;
      goto label_9;
label_7:
      if (DockControl.x28afaed1891a17a1 == null)
      {
        if (false)
          goto label_5;
      }
      else
        goto label_10;
label_9:
      DockControl.x28afaed1891a17a1 = Image.FromStream(typeof (DockControl).Assembly.GetManifestResourceStream("TD.SandDock.sanddock.png"));
label_10:
      this.xfffbdea061bfa120 = new WindowMetaData();
      this.xd447c58f1b8b8e4b = this.CreateDockingRules();
      if (true)
        goto label_2;
    }

    protected DockControl(SandDockManager manager, Control control, string text)
      : this()
    {
label_19:
      while (manager != null)
      {
        if (true)
          goto label_18;
label_17:
        throw new ArgumentNullException(nameof (control));
label_18:
        while (control != null)
        {
          if (text == null)
            goto label_14;
label_13:
          this.Manager = manager;
          if (!(control is Form))
            goto label_9;
          else
            goto label_11;
label_2:
          if (text != null)
          {
            this.Text = text;
            return;
          }
          if (true)
          {
            if (true)
              return;
            goto label_19;
          }
label_5:
          control.Visible = true;
          goto label_2;
label_7:
          this.Controls.Add(control);
          control.Dock = DockStyle.Fill;
          control.BringToFront();
          if (true)
          {
            this.ResumeLayout();
            if (false)
              continue;
            goto label_5;
          }
          else
            goto label_19;
label_9:
          if (control != null)
          {
            this.SuspendLayout();
            goto label_7;
          }
          else
            goto label_2;
label_11:
          Form form = (Form) control;
          form.TopLevel = false;
          if (true)
          {
            if (true)
            {
              form.FormBorderStyle = FormBorderStyle.None;
              goto label_9;
            }
            else
              goto label_7;
          }
          else
            goto label_20;
label_14:
          text = string.Empty;
          goto label_13;
        }
        goto label_17;
      }
label_20:
      throw new ArgumentNullException(nameof (manager));
    }

    protected abstract DockingRules CreateDockingRules();

    internal void xbdd4aaac1291a8c7(bool x364c1e3b189d47fe)
    {
      this.SetVisibleCore(x364c1e3b189d47fe);
    }

    [Browsable(false)]
    protected virtual bool AllowKeyboardNavigation
    {
      get
      {
        if (this.Manager == null)
          return true;
        return this.Manager.AllowKeyboardNavigation;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      int num1;
      int num2;
      if (this.xb6a159a84cb992d6 != null && ((uint) num2 + (uint) num1 > uint.MaxValue || this.AllowKeyboardNavigation))
      {
        int index1;
        int index2;
        switch (keyData)
        {
          case Keys.Prior | Keys.Control:
            index2 = this.xb6a159a84cb992d6.Controls.IndexOf(this) - 1;
            if (index2 < 0)
              index2 = this.xb6a159a84cb992d6.Controls.Count - 1;
            this.xb6a159a84cb992d6.SelectedControl = this.xb6a159a84cb992d6.Controls[index2];
            if (true)
              goto label_31;
            else
              goto label_30;
          case Keys.Next | Keys.Control:
            index1 = this.xb6a159a84cb992d6.Controls.IndexOf(this) + 1;
            if (index1 >= this.xb6a159a84cb992d6.Controls.Count)
              goto label_25;
label_22:
            this.xb6a159a84cb992d6.SelectedControl = this.xb6a159a84cb992d6.Controls[index1];
            if (this.xb6a159a84cb992d6.SelectedControl == this.xb6a159a84cb992d6.Controls[index1])
              goto label_23;
label_21:
            return true;
label_23:
            this.xb6a159a84cb992d6.Controls[index1].Activate();
            goto label_21;
label_25:
            index1 = 0;
            if ((uint) num1 >= 0U)
            {
              if (true)
              {
                if ((uint) index1 - (uint) index1 <= uint.MaxValue)
                  goto label_22;
                else
                  goto label_30;
              }
              else
                goto label_15;
            }
            else
              break;
          default:
            if (true)
              goto label_15;
            else
              goto label_16;
        }
label_3:
        return true;
label_4:
        if (keyData == Keys.Escape && this.Manager != null)
        {
          if (this.DockSituation == DockSituation.Document)
          {
            if ((uint) index1 <= uint.MaxValue)
            {
              if ((num1 | 4) != 0)
              {
                if ((index1 & 0) == 0)
                  goto label_35;
                else
                  goto label_30;
              }
            }
            else
              goto label_3;
          }
          else
            goto label_12;
label_8:
          DockControl recentlyUsedWindow = this.Manager.FindMostRecentlyUsedWindow(DockSituation.Document);
          if ((num1 | int.MaxValue) != 0)
          {
            if (recentlyUsedWindow != null)
            {
              if (true)
              {
                recentlyUsedWindow.Activate();
                goto label_3;
              }
              else
                goto label_15;
            }
            else
              goto label_3;
          }
          else
            goto label_31;
label_12:
          if (this.Manager.OwnerForm != null)
          {
            this.Manager.OwnerForm.Activate();
            goto label_8;
          }
          else if ((uint) num1 - (uint) num1 <= uint.MaxValue)
            goto label_8;
          else
            goto label_30;
        }
        else
          goto label_35;
label_15:
        if (keyData != (Keys.OemMinus | Keys.Alt))
        {
          if ((uint) index1 + (uint) index1 < 0U)
          {
            if ((num1 | 4) == 0)
              goto label_19;
          }
          else
            goto label_4;
        }
label_16:
        if (this.xb6a159a84cb992d6.IsInContainer)
          this.xb6a159a84cb992d6.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(this, new System.Drawing.Point(0, 0), ContextMenuContext.Keyboard));
        else
          goto label_4;
label_19:
        return true;
label_27:
        return true;
label_30:
        this.xb6a159a84cb992d6.Controls[index2].Activate();
        goto label_27;
label_31:
        if (this.xb6a159a84cb992d6.SelectedControl == this.xb6a159a84cb992d6.Controls[index2])
          goto label_30;
        else
          goto label_27;
      }
label_35:
      return base.ProcessCmdKey(ref msg, keyData);
    }

    internal void x7735d9a753c63a0a()
    {
      if (this.LayoutSystem == null)
        return;
      this.LayoutSystem.x3e0280cae730d1f2();
    }

    internal void x81444a37d39a0e4a()
    {
      this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
    }

    private void x63491667e252563e()
    {
      if (this.x4e7c2c44587adeda)
        return;
      do
      {
        if (this.Manager == null || this.Manager.DocumentContainer == null || !this.Manager.DocumentContainer.x1ec2ea49664e1074)
          goto label_4;
label_1:
        if (this.Manager == null)
          continue;
        goto label_3;
label_4:
        this.MetaData.x15481da58c59597a(DateTime.Now);
        goto label_1;
      }
      while (false);
      goto label_2;
label_3:
      this.Manager.OnDockControlActivated(new DockControlEventArgs(this));
      return;
label_2:;
    }

    protected override void OnEnter(EventArgs e)
    {
      base.OnEnter(e);
      if (true)
      {
        if (true)
          goto label_4;
      }
      else
        goto label_3;
label_2:
      this.LayoutSystem.x317ed3bc8decf394 = true;
label_3:
      if (true)
        goto label_5;
label_4:
      if (this.LayoutSystem != null)
        goto label_2;
label_5:
      this.x63491667e252563e();
    }

    protected override void OnLeave(EventArgs e)
    {
      base.OnLeave(e);
      if (this.LayoutSystem == null)
        return;
      this.LayoutSystem.x317ed3bc8decf394 = false;
    }

    public void SetPositionMetaData(DockSituation dockSituation)
    {
      if (this.DockSituation != DockSituation.None)
      {
        if (true)
          throw new InvalidOperationException("This operation is only valid when the window is not currently open.");
      }
      else
        goto label_3;
label_2:
      throw new ArgumentException(nameof (dockSituation));
label_3:
      if (dockSituation != DockSituation.None)
      {
        this.xfffbdea061bfa120.xb0e0bc77d88737a8(dockSituation);
        this.xfffbdea061bfa120.x0ba17c4cff658fcf(dockSituation);
      }
      else
        goto label_2;
    }

    public void SetPositionMetaData(DockSituation dockSituation, ContainerDockLocation dockLocation)
    {
      if (this.DockSituation != DockSituation.None)
        throw new InvalidOperationException("This operation is only valid when the window is not currently open.");
      if (dockSituation == DockSituation.None)
        throw new ArgumentException(nameof (dockSituation));
      if (false)
        ;
      if (dockLocation == ContainerDockLocation.Center)
        throw new ArgumentException(nameof (dockLocation));
      this.xfffbdea061bfa120.xb0e0bc77d88737a8(dockSituation);
      switch (dockSituation)
      {
        case DockSituation.Docked:
          if (false)
            return;
          goto case DockSituation.Document;
        case DockSituation.Document:
          this.xfffbdea061bfa120.x0ba17c4cff658fcf(dockSituation);
          break;
      }
      this.xfffbdea061bfa120.xfca44c52f41f0e26(dockLocation);
    }

    internal static void xe1da469e4d960f02(
      Control x43bec302f92080b9,
      Graphics x41347a961b838962,
      TD.SandDock.Rendering.BorderStyle xacfbd7a08ba56c78)
    {
      if (xacfbd7a08ba56c78 == TD.SandDock.Rendering.BorderStyle.None)
      {
        if (true)
          return;
        goto label_20;
      }
      else
        goto label_32;
label_2:
      Rectangle rectangle;
      Border3DStyle style;
      ControlPaint.DrawBorder3D(x41347a961b838962, rectangle, style);
      return;
label_8:
      if (xacfbd7a08ba56c78 != TD.SandDock.Rendering.BorderStyle.Flat)
      {
        TD.SandDock.Rendering.BorderStyle borderStyle = xacfbd7a08ba56c78;
        do
        {
          switch (borderStyle)
          {
            case TD.SandDock.Rendering.BorderStyle.Flat:
              goto label_6;
            case TD.SandDock.Rendering.BorderStyle.RaisedThick:
              goto label_7;
            case TD.SandDock.Rendering.BorderStyle.RaisedThin:
              style = Border3DStyle.RaisedInner;
              continue;
            case TD.SandDock.Rendering.BorderStyle.SunkenThick:
              goto label_3;
            default:
              goto label_4;
          }
        }
        while (false);
        goto label_2;
label_3:
        style = Border3DStyle.Sunken;
        goto label_2;
label_4:
        style = Border3DStyle.SunkenOuter;
        if (true)
        {
          if (true)
          {
            if (false)
              return;
            goto label_2;
          }
          else
            goto label_20;
        }
        else
          goto label_11;
label_6:
        style = Border3DStyle.Flat;
        goto label_2;
label_7:
        style = Border3DStyle.Raised;
        goto label_2;
      }
      else
        goto label_30;
label_11:
      --rectangle.Height;
      Color controlDark;
      using (Pen pen = new Pen(controlDark))
      {
        x41347a961b838962.DrawRectangle(pen, rectangle);
        return;
      }
label_18:
      --rectangle.Width;
      goto label_11;
label_20:
      if (false)
        goto label_2;
label_21:
      DockControl window;
      Color backColor;
      if (window.Manager != null)
        window.Manager.Renderer.ModifyDefaultWindowColors(window, ref backColor, ref controlDark);
      else
        goto label_18;
label_22:
      if (true)
      {
        if (false)
          goto label_18;
        else
          goto label_18;
      }
label_24:
      if (window == null)
      {
        if (false)
        {
          if (true)
            goto label_30;
        }
        else
          goto label_18;
      }
      else
        goto label_21;
label_27:
      if (false)
        return;
      if (false)
        goto label_8;
      else
        goto label_24;
label_30:
      backColor = x43bec302f92080b9.BackColor;
      controlDark = SystemColors.ControlDark;
      window = x43bec302f92080b9 as DockControl;
      if (true)
        goto label_27;
      else
        goto label_22;
label_32:
      rectangle = new Rectangle(0, 0, x43bec302f92080b9.Width, x43bec302f92080b9.Height);
      goto label_8;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      DockControl.xe1da469e4d960f02((Control) this, e.Graphics, this.xacfbd7a08ba56c78);
    }

    protected override void OnPaintBackground(PaintEventArgs e)
    {
      Rectangle clientRectangle = this.ClientRectangle;
      Color backColor;
      do
      {
        switch (this.BorderStyle)
        {
          case TD.SandDock.Rendering.BorderStyle.Flat:
          case TD.SandDock.Rendering.BorderStyle.RaisedThin:
          case TD.SandDock.Rendering.BorderStyle.SunkenThin:
            clientRectangle.Inflate(-1, -1);
            if (true)
              goto default;
            else
              break;
          case TD.SandDock.Rendering.BorderStyle.RaisedThick:
          case TD.SandDock.Rendering.BorderStyle.SunkenThick:
            clientRectangle.Inflate(-2, -2);
            break;
          default:
label_7:
            backColor = this.BackColor;
            Color transparent = Color.Transparent;
            if (this.Manager != null)
              goto label_8;
label_4:
            if (clientRectangle != this.ClientRectangle)
            {
              e.Graphics.SetClip(clientRectangle);
              if (true)
                continue;
              break;
            }
            goto label_2;
label_8:
            this.Manager.Renderer.ModifyDefaultWindowColors(this, ref backColor, ref transparent);
            goto label_4;
        }
        if (false)
          goto label_2;
        else
          goto label_7;
      }
      while (false);
      goto label_14;
label_2:
      if (this.BackgroundImage != null)
      {
        base.OnPaintBackground(e);
        return;
      }
      xa811784015ed8842.x91433b5e99eb7cac(e.Graphics, backColor);
      return;
label_14:
      if (true)
        goto label_2;
    }

    internal void x56e964269d48cfcc(DockContainer x0467b00af7810f0c)
    {
      if (x0467b00af7810f0c != null && x0467b00af7810f0c.Manager != null && x0467b00af7810f0c.Manager != this.Manager)
        this.Manager = x0467b00af7810f0c.Manager;
      this.x44fd51d909a57a2a();
    }

    internal void x44fd51d909a57a2a()
    {
      if (this.LayoutSystem == null)
        goto label_15;
      else
        goto label_14;
label_11:
      x129cb2a2bdfd0ab2 xfffbdea061bfa120 = (x129cb2a2bdfd0ab2) null;
      if (true)
        goto label_10;
      else
        goto label_6;
label_2:
      if (xfffbdea061bfa120 != null)
        this.x301b78956138d163(xfffbdea061bfa120);
      DockSituation xbcea506a33cf9111;
      this.x409072a6bb877e49(xbcea506a33cf9111);
      return;
label_6:
      DockContainer[] dockContainers = this.Manager.GetDockContainers(this.LayoutSystem.DockContainer.Dock);
      this.xfffbdea061bfa120.xe62a3d24e0fde928.xd25c313925dc7d4e = dockContainers.Length;
      this.xfffbdea061bfa120.xe62a3d24e0fde928.x71a5d248534c8557 = Array.IndexOf<DockContainer>(dockContainers, this.LayoutSystem.DockContainer);
      goto label_2;
label_10:
      switch (xbcea506a33cf9111)
      {
        case DockSituation.Docked:
          xfffbdea061bfa120 = (x129cb2a2bdfd0ab2) this.xfffbdea061bfa120.xe62a3d24e0fde928;
          this.xfffbdea061bfa120.x0ba17c4cff658fcf(DockSituation.Docked);
          this.xfffbdea061bfa120.xfca44c52f41f0e26(LayoutUtilities.x3650f3b579b2b4d2(this.LayoutSystem.DockContainer.Dock));
          break;
        case DockSituation.Document:
          xfffbdea061bfa120 = this.xfffbdea061bfa120.x25e1dbd0e63329bf;
          if (true)
          {
            if (false)
              return;
            this.xfffbdea061bfa120.x0ba17c4cff658fcf(DockSituation.Document);
            goto label_2;
          }
          else
            break;
        case DockSituation.Floating:
          xfffbdea061bfa120 = this.xfffbdea061bfa120.xba74b873ae2f845a;
          this.xfffbdea061bfa120.x87f4a9b62a380563(((x410f3612b9a8f9de) this.LayoutSystem.DockContainer).x0217cda8370c1f17);
          if (false)
            goto case DockSituation.Docked;
          else
            goto label_2;
        default:
          goto label_2;
      }
      this.xfffbdea061bfa120.x3ef4455ea4965093(this.LayoutSystem.DockContainer.ContentSize);
      if (this.Manager != null)
        goto label_6;
      else
        goto label_2;
label_12:
      if (xbcea506a33cf9111 == DockSituation.None)
      {
        if (true)
          goto label_11;
      }
      else
        goto label_17;
label_14:
      if (this.LayoutSystem.DockContainer != null)
      {
        xbcea506a33cf9111 = LayoutUtilities.x8d287cc6f0a2f529(this.LayoutSystem.DockContainer);
        if (true)
          goto label_12;
        else
          goto label_17;
      }
label_15:
      xbcea506a33cf9111 = DockSituation.None;
      goto label_12;
label_17:
      this.xfffbdea061bfa120.xb0e0bc77d88737a8(xbcea506a33cf9111);
      if (false)
        goto label_12;
      else
        goto label_11;
    }

    private void x301b78956138d163(x129cb2a2bdfd0ab2 xfffbdea061bfa120)
    {
      if (this.LayoutSystem == null)
        return;
      xfffbdea061bfa120.x703937d70a13725c = this.LayoutSystem.x0217cda8370c1f17;
      xfffbdea061bfa120.x8c8f170696764fac = this.LayoutSystem.Controls.IndexOf(this);
      xfffbdea061bfa120.x3a4e0c379519d4a2 = this.LayoutSystem.WorkingSize;
      xfffbdea061bfa120.x61743036ad30763d = LayoutUtilities.x27f6597db2aeb7d7(this.LayoutSystem);
    }

    private void x550f9212086279db()
    {
      if (this.IsDisposed)
        throw new ObjectDisposedException(this.GetType().Name);
    }

    internal void xb37e72cd3ce9b2b4()
    {
      this.CreateControl();
    }

    private void x298b2fdefeb76ab8()
    {
      this.x550f9212086279db();
      if (this.x91f347c6e97f1846 == null)
        throw new InvalidOperationException("No SandDockManager is associated with this DockControl. To create an association, set the Manager property.");
    }

    private void xc64dfbbdd2fa7bf6()
    {
      this.x298b2fdefeb76ab8();
      if (this.Manager.DockSystemContainer == null)
        throw new InvalidOperationException("The SandDockManager associated with this DockControl does not have its DockSystemContainer property set.");
    }

    public void OpenFloating()
    {
      this.OpenFloating(WindowOpenMethod.OnScreenActivate);
    }

    public void OpenFloating(Rectangle bounds, WindowOpenMethod openMethod)
    {
      this.x298b2fdefeb76ab8();
      this.Remove();
      this.MetaData.x87f4a9b62a380563(Guid.Empty);
      this.MetaData.xba74b873ae2f845a.x703937d70a13725c = Guid.Empty;
      this.FloatingLocation = bounds.Location;
      this.FloatingSize = bounds.Size;
      if (false)
        ;
      this.OpenFloating(openMethod);
    }

    public void OpenFloating(WindowOpenMethod openMethod)
    {
      this.x298b2fdefeb76ab8();
      if (false)
      {
        if (true)
          goto label_25;
        else
          goto label_20;
      }
      else
        goto label_31;
label_3:
      x5678bb8d80c0f12e x5678bb8d80c0f12e;
      do
      {
        ControlLayoutSystem newLayoutSystem = x5678bb8d80c0f12e.x07bf3386da210f81.DockContainer.CreateNewLayoutSystem(this, this.MetaData.xba74b873ae2f845a.x3a4e0c379519d4a2);
        if (this.MetaData.xba74b873ae2f845a.x703937d70a13725c == Guid.Empty)
          goto label_4;
label_2:
        newLayoutSystem.x0217cda8370c1f17 = this.MetaData.xba74b873ae2f845a.x703937d70a13725c;
        x5678bb8d80c0f12e.x07bf3386da210f81.LayoutSystems.Insert(x5678bb8d80c0f12e.xd1bdf42207dd3638, (LayoutSystemBase) newLayoutSystem);
        continue;
label_4:
        this.MetaData.xba74b873ae2f845a.x703937d70a13725c = Guid.NewGuid();
        if (true)
          goto label_2;
        else
          goto label_26;
      }
      while (false);
      return;
label_26:
      return;
label_5:
      x410f3612b9a8f9de x410f3612b9a8f9de;
      ControlLayoutSystem controlLayoutSystem;
      x410f3612b9a8f9de.LayoutSystem.LayoutSystems.Add((LayoutSystemBase) controlLayoutSystem);
      Rectangle xda73fcb97c77d998;
      x410f3612b9a8f9de.x159713d3b60fae0c(xda73fcb97c77d998, true, openMethod == WindowOpenMethod.OnScreenActivate);
      return;
label_8:
      if (this.MetaData.xba74b873ae2f845a.x703937d70a13725c == Guid.Empty)
      {
        this.MetaData.xba74b873ae2f845a.x703937d70a13725c = Guid.NewGuid();
        if (true)
        {
          if (true)
            goto label_24;
          else
            goto label_20;
        }
        else
          goto label_31;
      }
label_10:
      controlLayoutSystem.x0217cda8370c1f17 = this.MetaData.xba74b873ae2f845a.x703937d70a13725c;
      if (true)
        goto label_5;
      else
        goto label_3;
label_12:
      x410f3612b9a8f9de = new x410f3612b9a8f9de(this.Manager, this.xfffbdea061bfa120.LastFloatingWindowGuid);
      controlLayoutSystem = x410f3612b9a8f9de.CreateNewLayoutSystem(this, this.xfffbdea061bfa120.xba74b873ae2f845a.x3a4e0c379519d4a2);
      goto label_8;
label_20:
      controlLayoutSystem.Controls.Insert(Math.Min(this.MetaData.xba74b873ae2f845a.x8c8f170696764fac, controlLayoutSystem.Controls.Count), this);
      if (openMethod == WindowOpenMethod.OnScreen)
        return;
label_21:
      this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
      return;
label_24:
      if (false)
      {
        if (false)
          goto label_5;
        else
          goto label_8;
      }
      else if (false)
        goto label_8;
      else
        goto label_10;
label_25:
      this.Remove();
      controlLayoutSystem = LayoutUtilities.xba5fd484c0e6478b(this.Manager, DockSituation.Floating, this.MetaData.xba74b873ae2f845a);
      if (controlLayoutSystem == null)
      {
        x410f3612b9a8f9de = this.Manager.FindFloatingDockContainer(this.MetaData.LastFloatingWindowGuid);
        if (true)
        {
          if (true)
          {
            if (x410f3612b9a8f9de != null)
            {
              x5678bb8d80c0f12e = LayoutUtilities.x2f8f74d308cc9f3f((DockContainer) x410f3612b9a8f9de, this.MetaData.xba74b873ae2f845a.x61743036ad30763d);
              goto label_3;
            }
            else if (true)
            {
              if (this.xfffbdea061bfa120.LastFloatingWindowGuid == Guid.Empty)
                this.xfffbdea061bfa120.x87f4a9b62a380563(Guid.NewGuid());
              else
                goto label_12;
            }
            else
              goto label_8;
          }
          if (true)
            goto label_12;
          else
            goto label_24;
        }
        else
          goto label_20;
      }
      else
        goto label_20;
label_31:
      if (true)
      {
        this.xb37e72cd3ce9b2b4();
        if (this.DockSituation == DockSituation.Floating)
          return;
        if (true)
        {
          if (true)
          {
            if (true)
            {
              xda73fcb97c77d998 = this.xc0154d85fceb081c();
              goto label_25;
            }
            else
              goto label_25;
          }
          else
            goto label_12;
        }
        else
          goto label_3;
      }
      else
        goto label_21;
    }

    internal Rectangle xc0154d85fceb081c()
    {
      this.x298b2fdefeb76ab8();
      if (this.xc868bd63c888e533.X == -1 && this.xc868bd63c888e533.Y == -1)
        this.xc868bd63c888e533 = this.GetDefaultFloatingLocation();
      return new Rectangle(this.xc868bd63c888e533, this.xca874006c41dfe29);
    }

    protected virtual System.Drawing.Point GetDefaultFloatingLocation()
    {
      System.Drawing.Point point;
      if (!this.x1a9802d2d8708515)
      {
        Rectangle workingArea = (this.Manager.DockSystemContainer == null ? Screen.PrimaryScreen : Screen.FromControl(this.Manager.DockSystemContainer)).WorkingArea;
        point = new System.Drawing.Point(workingArea.X + workingArea.Width / 2 - this.xca874006c41dfe29.Width / 2, workingArea.Y + workingArea.Height / 2 - this.xca874006c41dfe29.Height / 2);
      }
      else
      {
        point = this.LayoutSystem.DockContainer.PointToScreen(this.LayoutSystem.Bounds.Location);
        if (true)
          point -= new System.Drawing.Size(SystemInformation.CaptionHeight, SystemInformation.CaptionHeight);
      }
      return point;
    }

    public Form GetFloatingForm()
    {
      if (this.DockSituation == DockSituation.Floating && this.Parent != null)
        return this.Parent.Parent as Form;
      return (Form) null;
    }

    public abstract void Open();

    public void Open(WindowOpenMethod openMethod)
    {
      this.x298b2fdefeb76ab8();
      if (this.DockSituation == DockSituation.None)
        goto label_6;
label_1:
      if (openMethod == WindowOpenMethod.OnScreen)
        return;
      this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
      return;
label_6:
      switch (this.xfffbdea061bfa120.LastOpenDockSituation)
      {
        case DockSituation.Docked:
          this.OpenDocked(openMethod);
          break;
        case DockSituation.Document:
          this.OpenDocument(openMethod);
          break;
        case DockSituation.Floating:
          this.OpenFloating(openMethod);
          break;
        default:
          goto label_1;
      }
    }

    internal void x6d1b64d6c637a91d(bool x53c0846b47593790)
    {
      if (this.LayoutSystem != null)
      {
        if (false)
        {
          if ((uint) x53c0846b47593790 - (uint) x53c0846b47593790 <= uint.MaxValue)
            goto label_8;
        }
        else
          goto label_12;
      }
label_3:
      while (x53c0846b47593790)
      {
        this.Activate();
        if (true)
        {
          if ((uint) x53c0846b47593790 <= uint.MaxValue)
            break;
          goto label_12;
        }
      }
      return;
label_8:
      if (this.LayoutSystem.SelectedControl != this)
        goto label_13;
label_5:
      if (this.LayoutSystem.x10ac79a4257c7f52 != null)
      {
        this.LayoutSystem.x10ac79a4257c7f52.xe6ff614263a59ef9(this, true, x53c0846b47593790);
        return;
      }
      goto label_3;
label_13:
      this.LayoutSystem.SelectedControl = this;
      if (this.LayoutSystem.SelectedControl != this)
        return;
      goto label_5;
label_12:
      if (true)
        goto label_8;
    }

    internal bool xe302f2203dc14a18(ContainerDockLocation xb9c2cfae130d9256)
    {
      switch (xb9c2cfae130d9256)
      {
        case ContainerDockLocation.Left:
          return this.DockingRules.AllowDockLeft;
        case ContainerDockLocation.Right:
          return this.DockingRules.AllowDockRight;
        case ContainerDockLocation.Top:
          return this.DockingRules.AllowDockTop;
        case ContainerDockLocation.Bottom:
          return this.DockingRules.AllowDockBottom;
        default:
          return this.DockingRules.AllowTab;
      }
    }

    public void Remove()
    {
      LayoutUtilities.xf1cbd48a28ce6e74(this);
    }

    public void OpenDocked()
    {
      this.OpenDocked(this.xfffbdea061bfa120.LastFixedDockSide);
    }

    public void OpenDocked(ContainerDockLocation dockLocation)
    {
      if (dockLocation == this.xfffbdea061bfa120.LastFixedDockSide)
        this.OpenDocked(WindowOpenMethod.OnScreenSelect);
      else
        this.OpenDocked(dockLocation, WindowOpenMethod.OnScreenSelect);
    }

    public void OpenDocked(ContainerDockLocation dockLocation, WindowOpenMethod openMethod)
    {
      if (dockLocation == ContainerDockLocation.Center)
      {
        this.OpenDocument(openMethod);
      }
      else
      {
        this.x298b2fdefeb76ab8();
        if (this.DockSituation == DockSituation.Docked && this.xfffbdea061bfa120.LastFixedDockSide == dockLocation)
          return;
        this.Remove();
        this.xfffbdea061bfa120.xfca44c52f41f0e26(dockLocation);
        this.xfffbdea061bfa120.xe62a3d24e0fde928.x703937d70a13725c = Guid.Empty;
        this.xfffbdea061bfa120.xe62a3d24e0fde928.x61743036ad30763d = new int[0];
        this.OpenDocked(openMethod);
      }
    }

    public void OpenDocument(WindowOpenMethod openMethod)
    {
      this.x298b2fdefeb76ab8();
label_27:
      this.xb37e72cd3ce9b2b4();
      if (this.DockSituation == DockSituation.Document)
        return;
      this.Remove();
      ControlLayoutSystem controlLayoutSystem = LayoutUtilities.xba5fd484c0e6478b(this.Manager, DockSituation.Document, this.xfffbdea061bfa120.x25e1dbd0e63329bf);
      if (true)
      {
        while (controlLayoutSystem == null)
        {
          DockContainer container;
          do
          {
            container = this.Manager.FindDockContainer(ContainerDockLocation.Center);
            if (container == null)
              goto label_17;
          }
          while (false);
          goto label_29;
label_1:
          if (false)
            goto label_11;
label_2:
          while (openMethod != WindowOpenMethod.OnScreen)
          {
            this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
            if (true)
            {
              if (true)
              {
                if (true)
                  break;
              }
              else if (true)
                goto label_16;
              else
                goto label_14;
            }
          }
          return;
label_11:
          container.LayoutSystem.LayoutSystems.Add((LayoutSystemBase) controlLayoutSystem);
          goto label_2;
label_14:
          controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem(container);
          if (controlLayoutSystem != null)
          {
            if (this.Manager.DocumentOpenPosition != DocumentContainerWindowOpenPosition.First)
            {
              if (true)
              {
                if (true)
                {
                  controlLayoutSystem.Controls.Add(this);
                  goto label_2;
                }
                else
                  goto label_27;
              }
              else
                continue;
            }
            else
            {
              controlLayoutSystem.Controls.Insert(0, this);
              goto label_2;
            }
          }
          else if (true)
          {
            controlLayoutSystem = container.CreateNewLayoutSystem(this, this.MetaData.x25e1dbd0e63329bf.x3a4e0c379519d4a2);
            if (false)
              return;
            goto label_11;
          }
label_16:
          if (true)
            goto label_1;
          else
            goto label_27;
label_17:
          container = this.Manager.CreateNewDockContainer(ContainerDockLocation.Center, ContainerDockEdge.Inside, this.MetaData.DockedContentSize);
          goto label_14;
label_29:
          if (true)
            goto label_14;
          else
            goto label_1;
        }
      }
      controlLayoutSystem.Controls.Insert(Math.Min(this.xfffbdea061bfa120.xe62a3d24e0fde928.x8c8f170696764fac, controlLayoutSystem.Controls.Count), this);
      if (openMethod == WindowOpenMethod.OnScreen)
        return;
      this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
    }

    public void OpenDocked(WindowOpenMethod openMethod)
    {
      this.x298b2fdefeb76ab8();
      if (true)
        goto label_22;
      else
        goto label_3;
label_1:
      ControlLayoutSystem controlLayoutSystem;
      controlLayoutSystem.x0217cda8370c1f17 = this.MetaData.xe62a3d24e0fde928.x703937d70a13725c;
      x5678bb8d80c0f12e x5678bb8d80c0f12e;
      x5678bb8d80c0f12e.x07bf3386da210f81.LayoutSystems.Insert(x5678bb8d80c0f12e.xd1bdf42207dd3638, (LayoutSystemBase) controlLayoutSystem);
      if (openMethod == WindowOpenMethod.OnScreen)
        return;
      this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
      goto label_7;
label_3:
      if (false)
        goto label_20;
label_4:
      if (!(this.MetaData.xe62a3d24e0fde928.x703937d70a13725c == Guid.Empty))
      {
        if (true)
        {
          if (true)
            goto label_1;
        }
        else
          goto label_15;
      }
      else
        goto label_8;
label_7:
      if (true)
        return;
      goto label_22;
label_8:
      this.MetaData.xe62a3d24e0fde928.x703937d70a13725c = Guid.NewGuid();
      goto label_1;
label_11:
      while (controlLayoutSystem == null)
      {
        x5678bb8d80c0f12e = LayoutUtilities.x4689c8634e31fc55(this.Manager, this.xfffbdea061bfa120);
        if (true)
          goto label_17;
      }
      controlLayoutSystem.Controls.Insert(Math.Min(this.xfffbdea061bfa120.xe62a3d24e0fde928.x8c8f170696764fac, controlLayoutSystem.Controls.Count), this);
label_15:
      if (openMethod != WindowOpenMethod.OnScreen)
      {
        this.x6d1b64d6c637a91d(openMethod == WindowOpenMethod.OnScreenActivate);
        return;
      }
      if (true)
        return;
label_17:
      if (true)
      {
        controlLayoutSystem = x5678bb8d80c0f12e.x07bf3386da210f81.DockContainer.CreateNewLayoutSystem(this, this.xfffbdea061bfa120.xe62a3d24e0fde928.x3a4e0c379519d4a2);
        if (true)
          goto label_4;
        else
          goto label_8;
      }
      else
        goto label_8;
label_20:
      if (this.DockSituation == DockSituation.Docked)
        return;
      this.Remove();
      controlLayoutSystem = LayoutUtilities.xba5fd484c0e6478b(this.Manager, DockSituation.Docked, (x129cb2a2bdfd0ab2) this.xfffbdea061bfa120.xe62a3d24e0fde928);
      if (true)
        goto label_11;
label_22:
      this.xb37e72cd3ce9b2b4();
      if (true)
        goto label_20;
      else
        goto label_11;
    }

    public void Split(DockSide direction)
    {
      if (!this.x1a9802d2d8708515)
      {
        if (true)
          goto label_11;
      }
      else
        goto label_6;
label_2:
      SizeF workingSize = this.LayoutSystem.WorkingSize;
      ControlLayoutSystem layoutSystem = this.LayoutSystem;
      LayoutUtilities.xf1cbd48a28ce6e74(this);
      ControlLayoutSystem newLayoutSystem = layoutSystem.DockContainer.CreateNewLayoutSystem(this, workingSize);
      layoutSystem.SplitForLayoutSystem((LayoutSystemBase) newLayoutSystem, direction);
      this.Activate();
      return;
label_6:
      while (this.LayoutSystem.Controls.Count >= 2)
      {
        if (direction != DockSide.None)
          goto label_10;
label_8:
        throw new ArgumentException(nameof (direction));
label_10:
        if (true)
        {
          if (true)
          {
            if (true)
            {
              if (true)
                goto label_2;
              else
                goto label_11;
            }
          }
          else
            goto label_8;
        }
        else
          goto label_11;
      }
      throw new InvalidOperationException("A minimum of 2 windows need to be present in a tab group before one can be split off. Check LayoutSystem.Controls.Count before calling this method.");
label_11:
      throw new InvalidOperationException("A window cannot be split while it is not hosted in a DockContainer.");
    }

    public bool Close()
    {
      return this.x8ffe90e7fbccfccd(false);
    }

    internal bool x8ffe90e7fbccfccd(bool xc481dbe8dc50af3f)
    {
      DockControlClosingEventArgs e = new DockControlClosingEventArgs(this, false);
      if (this.Manager != null)
        goto label_8;
label_7:
      if (!e.Cancel)
        goto label_9;
label_6:
      if (e.Cancel)
        return false;
      if (((xc481dbe8dc50af3f ? 1 : 0) & 0) == 0)
      {
        if (true)
        {
          do
          {
            LayoutUtilities.xf1cbd48a28ce6e74(this);
          }
          while ((uint) xc481dbe8dc50af3f < 0U);
          this.OnClosed(EventArgs.Empty);
          if (this.CloseAction == DockControlCloseAction.Dispose)
            this.Dispose();
        }
        else
          goto label_9;
      }
      return true;
label_9:
      this.OnClosing(e);
      goto label_6;
label_8:
      this.Manager.OnDockControlClosing(e);
      goto label_7;
    }

    protected internal virtual void OnClosing(DockControlClosingEventArgs e)
    {
      if (this.xb451d7f50d849473 == null)
        return;
      this.xb451d7f50d849473((object) this, e);
    }

    protected internal virtual void OnClosed(EventArgs e)
    {
      if (this.x289bf94a509dd84c == null)
        return;
      this.x289bf94a509dd84c((object) this, e);
    }

    protected virtual void OnLoad(EventArgs e)
    {
      if (this.x5d95f5f98c940295 == null)
        return;
      this.x5d95f5f98c940295((object) this, e);
    }

    protected virtual void OnDockSituationChanged(EventArgs e)
    {
      if (this.x8e01005e38b88f59 == null)
        return;
      this.x8e01005e38b88f59((object) this, e);
    }

    protected internal virtual void OnTabDoubleClick()
    {
      switch (this.DockSituation)
      {
        case DockSituation.Docked:
        case DockSituation.Document:
          if (!this.DockingRules.AllowFloat)
            break;
          this.OpenFloating(WindowOpenMethod.OnScreenActivate);
          break;
        case DockSituation.Floating:
          if (this.xfffbdea061bfa120.LastFixedDockSituation == DockSituation.Docked)
            goto label_9;
          else
            goto label_12;
label_1:
          if (this.xfffbdea061bfa120.LastFixedDockSituation != DockSituation.Document)
          {
            if (true)
            {
              if (true)
                break;
              if (true)
                goto case DockSituation.Floating;
            }
            else
              goto case DockSituation.Floating;
          }
          else
          {
            if (!this.xe302f2203dc14a18(ContainerDockLocation.Center))
              break;
            this.OpenDocument(WindowOpenMethod.OnScreenActivate);
            break;
          }
label_9:
          if (this.xe302f2203dc14a18(this.xfffbdea061bfa120.LastFixedDockSide))
          {
            this.OpenDocked(WindowOpenMethod.OnScreenActivate);
            break;
          }
          goto label_1;
label_12:
          if (true)
            goto label_1;
          else
            goto label_1;
      }
    }

    public void Activate()
    {
      if (this.LayoutSystem == null)
        return;
      while (this.Parent != null)
      {
        if (this.LayoutSystem.SelectedControl != this)
          goto label_28;
label_15:
        if (this.DockSituation == DockSituation.Floating)
          goto label_19;
label_17:
        if (!this.IsOpen)
          break;
        if (true)
        {
          if (true)
            goto label_33;
          else
            continue;
        }
label_19:
        this.x410f3612b9a8f9de.x5b7f6ddd07ded8cd();
        goto label_17;
label_28:
        this.LayoutSystem.SelectedControl = this;
        if (false)
          goto label_29;
label_20:
        if (this.LayoutSystem.SelectedControl != this)
          break;
        if (false)
          continue;
        goto label_15;
label_29:
        if (true)
          break;
        if (true)
          goto label_20;
label_33:
        if (false)
          break;
        this.x4e7c2c44587adeda = true;
        try
        {
          IContainerControl containerControl = this.Parent.GetContainerControl();
          if (true)
          {
            do
            {
              containerControl.ActiveControl = this.ActiveControl;
              if (!this.ContainsFocus)
              {
                if (true)
                {
                  if (this.PrimaryControl == null)
                    goto label_6;
                  else
                    goto label_12;
label_4:
                  while (!this.ContainsFocus)
                  {
                    if (this.Controls.Count != 1)
                    {
                      this.Focus();
                      if (true)
                        goto label_14;
                    }
                    else
                    {
                      this.Controls[0].Focus();
                      goto label_14;
                    }
                  }
                  continue;
label_6:
                  this.SelectNextControl((Control) this, true, true, true, true);
                  goto label_4;
label_12:
                  this.PrimaryControl.Focus();
                  if (false)
                    break;
                  goto label_4;
                }
                else
                  break;
              }
              else
                break;
            }
            while (false);
          }
        }
        finally
        {
          this.x4e7c2c44587adeda = false;
        }
label_14:
        this.x63491667e252563e();
        break;
      }
    }

    [Obsolete("Use the OpenWith method instead.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public void DockNextTo(DockControl existingWindow)
    {
      this.OpenWith(existingWindow);
    }

    public void OpenWith(DockControl existingWindow)
    {
      if (existingWindow != null)
      {
        if (existingWindow == this)
          return;
        if (existingWindow.DockSituation == DockSituation.None)
          throw new InvalidOperationException("The specified window is not open.");
        if (true)
        {
          this.Remove();
          existingWindow.LayoutSystem.Controls.Add(this);
        }
        if (true)
          return;
      }
      throw new ArgumentNullException();
    }

    public void OpenBeside(DockControl existingWindow, DockSide side)
    {
      if (existingWindow == null)
        throw new ArgumentNullException();
      if (existingWindow == this)
        return;
      if (false)
        ;
      if (existingWindow.DockSituation == DockSituation.None)
        throw new InvalidOperationException("The specified window is not open.");
      this.Remove();
      existingWindow.LayoutSystem.SplitForLayoutSystem((LayoutSystemBase) new ControlLayoutSystem(this.MetaData.xe62a3d24e0fde928.x3a4e0c379519d4a2, new DockControl[1]
      {
        this
      }, this), side);
    }

    public void DockInNewContainer(ContainerDockLocation dockLocation, ContainerDockEdge edge)
    {
      this.xc64dfbbdd2fa7bf6();
      this.Remove();
      DockContainer newDockContainer = this.Manager.CreateNewDockContainer(dockLocation, edge, this.xfffbdea061bfa120.DockedContentSize);
      ControlLayoutSystem newLayoutSystem = newDockContainer.CreateNewLayoutSystem(this, (SizeF) this.FloatingSize);
      newDockContainer.LayoutSystem.LayoutSystems.Add((LayoutSystemBase) newLayoutSystem);
    }

    internal void x02847d0dec2e498a(ControlLayoutSystem x6e150040c8d97700, int xc0c4c459c6ccbd00)
    {
      if (this.xb6a159a84cb992d6 != x6e150040c8d97700)
      {
        if (false)
          ;
        LayoutUtilities.xf1cbd48a28ce6e74(this);
        x6e150040c8d97700.Controls.Insert(xc0c4c459c6ccbd00, this);
      }
      else
        x6e150040c8d97700.Controls.SetChildIndex(this, xc0c4c459c6ccbd00);
      x6e150040c8d97700.SelectedControl = this;
    }

    protected override void OnCreateControl()
    {
      base.OnCreateControl();
      this.OnLoad(EventArgs.Empty);
    }

    protected internal virtual void OnAutoHidePopupClosed(EventArgs e)
    {
      if (this.x7e416c13135971ea == null)
        return;
      this.x7e416c13135971ea((object) this, e);
    }

    protected internal virtual void OnAutoHidePopupOpened(EventArgs e)
    {
      if (this.x5b29af28d5fc1a4e == null)
        return;
      this.x5b29af28d5fc1a4e((object) this, e);
    }

    public override BindingContext BindingContext
    {
      get
      {
        if (this.x2464cce8c6385330 != null)
          return this.x2464cce8c6385330;
        if (this.Manager != null && this.Manager.DockSystemContainer != null)
          return this.Manager.DockSystemContainer.BindingContext;
        if (this.DesignMode)
          return base.BindingContext;
        return (BindingContext) null;
      }
      set
      {
        this.x2464cce8c6385330 = value;
        base.BindingContext = value;
      }
    }

    [DefaultValue(typeof (Control), null)]
    [Category("Behavior")]
    [Description("The control that will be focused when the window is activated.")]
    public Control PrimaryControl
    {
      get
      {
        return this.x3f02d9fd7ae06803;
      }
      set
      {
        this.x3f02d9fd7ae06803 = value;
      }
    }

    [Category("Layout")]
    [DefaultValue(false)]
    [Description("Indicates whether the window is collapsed when docked.")]
    public bool Collapsed
    {
      get
      {
        if (this.LayoutSystem == null)
          return false;
        return this.LayoutSystem.Collapsed;
      }
      set
      {
        if (this.LayoutSystem == null)
          return;
        this.LayoutSystem.Collapsed = value;
      }
    }

    [DefaultValue(typeof (DockControlCloseAction), "HideOnly")]
    [Description("Indicates what action will be performed when the DockControl is closed.")]
    [Category("Behavior")]
    public virtual DockControlCloseAction CloseAction
    {
      get
      {
        return this.x8fbef9afc77bc952;
      }
      set
      {
        this.x8fbef9afc77bc952 = value;
      }
    }

    [Browsable(false)]
    public WindowMetaData MetaData
    {
      get
      {
        return this.xfffbdea061bfa120;
      }
    }

    internal bool xadad18dc04073a00
    {
      get
      {
        return this.xb98085e1d76c9b6d;
      }
      set
      {
        this.xb98085e1d76c9b6d = value;
      }
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
        base.Dock = value;
      }
    }

    public override Rectangle DisplayRectangle
    {
      get
      {
        Rectangle displayRectangle = base.DisplayRectangle;
        switch (this.xacfbd7a08ba56c78)
        {
          case TD.SandDock.Rendering.BorderStyle.Flat:
          case TD.SandDock.Rendering.BorderStyle.RaisedThin:
          case TD.SandDock.Rendering.BorderStyle.SunkenThin:
            displayRectangle.Inflate(-1, -1);
            break;
          case TD.SandDock.Rendering.BorderStyle.RaisedThick:
          case TD.SandDock.Rendering.BorderStyle.SunkenThick:
            displayRectangle.Inflate(-2, -2);
            if (false)
              goto case TD.SandDock.Rendering.BorderStyle.Flat;
            else
              break;
        }
        return displayRectangle;
      }
    }

    [Category("Behavior")]
    [Description("Indicates whether the location of the DockControl will be included in layout serialization.")]
    [DefaultValue(true)]
    [Browsable(true)]
    public virtual bool PersistState
    {
      get
      {
        return this.x35db3fd5e409fffb;
      }
      set
      {
        this.x35db3fd5e409fffb = value;
      }
    }

    [Description("The type of border to be drawn around the control.")]
    [DefaultValue(typeof (TD.SandDock.Rendering.BorderStyle), "None")]
    [Category("Appearance")]
    public TD.SandDock.Rendering.BorderStyle BorderStyle
    {
      get
      {
        return this.xacfbd7a08ba56c78;
      }
      set
      {
        this.xacfbd7a08ba56c78 = value;
        this.PerformLayout();
        this.Invalidate();
      }
    }

    [Browsable(false)]
    public ControlLayoutSystem LayoutSystem
    {
      get
      {
        return this.xb6a159a84cb992d6;
      }
    }

    internal void xb2b69aae23a4ae6d(ControlLayoutSystem x6e150040c8d97700)
    {
      this.xb6a159a84cb992d6 = x6e150040c8d97700;
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public SandDockManager Manager
    {
      get
      {
        return this.x91f347c6e97f1846;
      }
      set
      {
        if (value == this.x91f347c6e97f1846)
          return;
        if (false)
        {
          if (false)
            return;
        }
        else
          goto label_10;
label_3:
        if (this.x91f347c6e97f1846 == null)
          return;
label_5:
        this.x91f347c6e97f1846.RegisterWindow(this);
        return;
label_10:
        if (this.x91f347c6e97f1846 != null)
          goto label_13;
        else
          goto label_7;
label_6:
        if (false)
          goto label_10;
        else
          goto label_8;
label_7:
        if (false)
          goto label_6;
label_8:
        this.x91f347c6e97f1846 = value;
        if (true)
        {
          if (true)
          {
            if (true)
              goto label_3;
            else
              goto label_5;
          }
          else
            goto label_6;
        }
        else
          goto label_10;
label_13:
        this.x91f347c6e97f1846.UnregisterWindow(this);
        goto label_6;
      }
    }

    [Category("Advanced")]
    [Description("The unique identifier for the window.")]
    public Guid Guid
    {
      get
      {
        return this.xb51cd75f17ace1ec;
      }
      set
      {
        Guid xb51cd75f17ace1ec = this.xb51cd75f17ace1ec;
        this.xb51cd75f17ace1ec = value;
        if (this.Manager == null)
          return;
        this.Manager.ReRegisterWindow(this, xb51cd75f17ace1ec);
      }
    }

    [Browsable(false)]
    [Obsolete("Use the DockSituation property instead.")]
    public bool IsDocked
    {
      get
      {
        if (this.x1a9802d2d8708515 && !(this.xb6a159a84cb992d6.DockContainer is DocumentContainer))
          return !(this.xb6a159a84cb992d6.DockContainer is x410f3612b9a8f9de);
        return false;
      }
    }

    [Obsolete("Use the DockSituation property instead.")]
    [Browsable(false)]
    public bool IsTabbedDocument
    {
      get
      {
        if (this.x1a9802d2d8708515)
          return this.xb6a159a84cb992d6.DockContainer is DocumentContainer;
        return false;
      }
    }

    [Obsolete("Use the DockSituation property instead.")]
    [Browsable(false)]
    public bool IsFloating
    {
      get
      {
        if (this.x1a9802d2d8708515)
          return this.xb6a159a84cb992d6.DockContainer.IsFloating;
        return false;
      }
    }

    [Browsable(false)]
    internal bool x1a9802d2d8708515
    {
      get
      {
        if (this.xb6a159a84cb992d6 != null)
          return this.xb6a159a84cb992d6.DockContainer != null;
        return false;
      }
    }

    [Browsable(false)]
    public bool IsOpen
    {
      get
      {
        bool flag = this.x1a9802d2d8708515 && this.xb6a159a84cb992d6 != null && this.xb6a159a84cb992d6.SelectedControl == this;
label_1:
        while (flag || (uint) flag + (uint) flag < 0U)
        {
          while (!this.xb6a159a84cb992d6.Collapsed)
          {
            if ((uint) flag > uint.MaxValue)
            {
              if ((uint) flag <= uint.MaxValue)
                goto label_1;
            }
            else
              goto label_6;
          }
          flag = this.xb6a159a84cb992d6.IsPoppedUp;
          if ((uint) flag - (uint) flag <= uint.MaxValue)
            break;
        }
label_6:
        return flag;
      }
    }

    [DefaultValue(typeof (Color), "Control")]
    public override Color BackColor
    {
      get
      {
        return base.BackColor;
      }
      set
      {
        base.BackColor = value;
label_8:
        if (false)
          goto label_2;
label_1:
        if (this.LayoutSystem == null)
          return;
label_2:
        if (this.LayoutSystem.DockContainer == null)
          return;
        this.LayoutSystem.DockContainer.Invalidate(this.LayoutSystem.Bounds);
        if (true)
        {
          if (true)
            return;
          if (true)
            goto label_8;
          else
            goto label_1;
        }
        else
          goto label_1;
      }
    }

    public override Color ForeColor
    {
      get
      {
        return base.ForeColor;
      }
      set
      {
        base.ForeColor = value;
        while (this.LayoutSystem != null && this.LayoutSystem.DockContainer != null)
        {
          this.LayoutSystem.DockContainer.Invalidate(this.x123e054dab107457);
          if (true)
            break;
        }
      }
    }

    [Category("Layout")]
    [DefaultValue(typeof (System.Drawing.Size), "250, 400")]
    [Description("Indicates the default size this control will assume when floating on its own.")]
    public System.Drawing.Size FloatingSize
    {
      get
      {
        return this.xca874006c41dfe29;
      }
      set
      {
        if (value.Width > 0)
          goto label_7;
label_6:
        throw new ArgumentOutOfRangeException(nameof (value));
label_7:
        if (value.Height > 0)
        {
          this.xca874006c41dfe29 = value;
          while (this.DockSituation == DockSituation.Floating && this.x410f3612b9a8f9de.xb1090c5821a633b5 != this.xca874006c41dfe29)
          {
            this.x410f3612b9a8f9de.xb1090c5821a633b5 = this.xca874006c41dfe29;
            if (true)
            {
              if (true)
                break;
              goto label_7;
            }
          }
        }
        else
          goto label_6;
      }
    }

    [DefaultValue(typeof (System.Drawing.Point), "-1, -1")]
    [Browsable(false)]
    public System.Drawing.Point FloatingLocation
    {
      get
      {
        return this.xc868bd63c888e533;
      }
      set
      {
        this.xc868bd63c888e533 = value;
        if (this.DockSituation != DockSituation.Floating || !(this.x410f3612b9a8f9de.x12992900724b93dc != this.xc868bd63c888e533))
          return;
        this.x410f3612b9a8f9de.x12992900724b93dc = this.xc868bd63c888e533;
      }
    }

    private x410f3612b9a8f9de x410f3612b9a8f9de
    {
      get
      {
        return this.xb6a159a84cb992d6.DockContainer as x410f3612b9a8f9de;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Obsolete("Use the DockingRules property instead.")]
    public bool AllowFloat
    {
      get
      {
        return this.DockingRules.AllowFloat;
      }
      set
      {
        this.DockingRules.AllowFloat = value;
      }
    }

    [Obsolete("Use the DockingRules property instead.")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool AllowDockCenter
    {
      get
      {
        return this.DockingRules.AllowTab;
      }
      set
      {
        this.DockingRules.AllowTab = value;
      }
    }

    [Browsable(false)]
    [Obsolete("Use the DockingRules property instead.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool AllowDockLeft
    {
      get
      {
        return this.DockingRules.AllowDockLeft;
      }
      set
      {
        this.DockingRules.AllowDockLeft = value;
      }
    }

    [Obsolete("Use the DockingRules property instead.")]
    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool AllowDockRight
    {
      get
      {
        return this.DockingRules.AllowDockRight;
      }
      set
      {
        this.DockingRules.AllowDockRight = value;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Obsolete("Use the DockingRules property instead.")]
    public bool AllowDockTop
    {
      get
      {
        return this.DockingRules.AllowDockTop;
      }
      set
      {
        this.DockingRules.AllowDockTop = value;
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Obsolete("Use the DockingRules property instead.")]
    [Browsable(false)]
    public bool AllowDockBottom
    {
      get
      {
        return this.DockingRules.AllowDockBottom;
      }
      set
      {
        this.DockingRules.AllowDockBottom = value;
      }
    }

    [Description("The rules with which to govern where the user can move the window.")]
    [Category("Behavior")]
    public DockingRules DockingRules
    {
      get
      {
        return this.xd447c58f1b8b8e4b;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException(nameof (value));
        this.xd447c58f1b8b8e4b = value;
      }
    }

    private bool ShouldSerializeDockingRules()
    {
      DockingRules dockingRules = this.CreateDockingRules();
      if (true)
        goto label_8;
      else
        goto label_11;
label_6:
      while (dockingRules.AllowDockBottom != this.DockingRules.AllowDockBottom)
      {
        if (false)
        {
          if (true)
            break;
        }
        else
          goto label_12;
      }
label_7:
      if (dockingRules.AllowDockLeft != this.DockingRules.AllowDockLeft)
      {
        if (false)
        {
          if (true)
            goto label_6;
        }
        else
          goto label_12;
      }
      else
      {
        if (dockingRules.AllowDockRight == this.DockingRules.AllowDockRight && dockingRules.AllowTab == this.DockingRules.AllowTab)
          return dockingRules.AllowFloat != this.DockingRules.AllowFloat;
        goto label_12;
      }
label_8:
      if (dockingRules.AllowDockTop == this.DockingRules.AllowDockTop)
      {
        if (false)
          goto label_6;
        else
          goto label_6;
      }
      else
        goto label_12;
label_11:
      if (true)
        goto label_6;
      else
        goto label_7;
label_12:
      return true;
    }

    [Category("Behavior")]
    [Description("Determines whether the user will be able to press tab to bring the focus within the window when docked.")]
    [DefaultValue(false)]
    public bool AllowKeyboardFocus
    {
      get
      {
        return this.GetStyle(ControlStyles.Selectable);
      }
      set
      {
        this.SetStyle(ControlStyles.Selectable, value);
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [Obsolete("Use the AllowClose property instead.", true)]
    public bool Closable
    {
      get
      {
        return this.AllowClose;
      }
      set
      {
        this.AllowClose = value;
      }
    }

    [DefaultValue(true)]
    [Description("Indicates whether this control will be closable by the user.")]
    [Category("Docking")]
    public virtual bool AllowClose
    {
      get
      {
        return this.x6c3086899dc42885;
      }
      set
      {
        this.x6c3086899dc42885 = value;
        this.x7735d9a753c63a0a();
      }
    }

    [DefaultValue(0)]
    [Category("Layout")]
    [Description("Indicates the maximum width of the tab representing the window.")]
    public int MaximumTabWidth
    {
      get
      {
        return this.x3214e09b677ccd2b;
      }
      set
      {
        if (value < 0)
          throw new ArgumentException("Value must be greater than or equal to zero.");
        this.x3214e09b677ccd2b = value;
        this.x7735d9a753c63a0a();
      }
    }

    [Description("Indicates the minimum width of the tab representing the window.")]
    [DefaultValue(0)]
    [Category("Layout")]
    public int MinimumTabWidth
    {
      get
      {
        return this.xcf3ab1252c42eac6;
      }
      set
      {
        if (value < 0)
          throw new ArgumentOutOfRangeException(nameof (value));
        this.xcf3ab1252c42eac6 = value;
        this.x7735d9a753c63a0a();
      }
    }

    [DefaultValue(true)]
    [Category("Appearance")]
    [Description("Indicates whether an options button will be displayed in the titlebar for this window.")]
    public bool ShowOptions
    {
      get
      {
        return this.x1def1a42ad5b7095;
      }
      set
      {
        this.x1def1a42ad5b7095 = value;
        this.x7735d9a753c63a0a();
      }
    }

    [Category("Docking")]
    [DefaultValue(true)]
    [Description("Indicates whether the user will be able to put this control in to auto-hide mode.")]
    public virtual bool AllowCollapse
    {
      get
      {
        return this.x9b80917b168ce488;
      }
      set
      {
        this.x9b80917b168ce488 = value;
        if ((uint) value - (uint) value <= uint.MaxValue)
          goto label_4;
label_2:
        if (this.Collapsed)
        {
          this.Collapsed = false;
          if (false)
            goto label_4;
        }
label_3:
        this.x7735d9a753c63a0a();
        return;
label_4:
        if (value)
          goto label_3;
        else
          goto label_2;
      }
    }

    private bool ShouldSerializeTabText()
    {
      if (this.xc3d462fde66905e5.Length != 0)
        return this.xc3d462fde66905e5 != this.Text;
      return false;
    }

    [Localizable(true)]
    [Category("Appearance")]
    [DefaultValue("")]
    [Description("Gets or sets the text that appears as a ToolTip for the control tab.")]
    public virtual string ToolTipText
    {
      get
      {
        return this.xd84978f0dad7afcd;
      }
      set
      {
        if (value == null)
          value = string.Empty;
        this.xd84978f0dad7afcd = value;
      }
    }

    [Localizable(true)]
    [Category("Appearance")]
    [Description("The text to display on the tab for the DockControl. This can be different to the standard text.")]
    public virtual string TabText
    {
      get
      {
        if (this.xc3d462fde66905e5.Length == 0)
          return this.Text;
        return this.xc3d462fde66905e5;
      }
      set
      {
        if (value == null)
          value = string.Empty;
        this.xc3d462fde66905e5 = value;
        this.x7735d9a753c63a0a();
      }
    }

    [Description("The size of the control when popped up from a collapsed state. Leave this as zero for the default size.")]
    [DefaultValue(0)]
    [Category("Docking")]
    public int PopupSize
    {
      get
      {
        return this.x5614e4ef0596c91d;
      }
      set
      {
        if (value < 0)
        {
          if ((uint) value - (uint) value <= uint.MaxValue)
            goto label_14;
        }
        else
          goto label_15;
label_2:
        if ((uint) value + (uint) value >= 0U)
          return;
label_3:
        if (this.LayoutSystem.x10ac79a4257c7f52.x23498f53d87354d4 != this.LayoutSystem)
        {
          if (true)
            return;
        }
        else
        {
          this.LayoutSystem.x10ac79a4257c7f52.xca843b3e9a1c605f = value;
          return;
        }
label_14:
        throw new ArgumentException("Value must be at least equal to zero.");
label_15:
        this.x5614e4ef0596c91d = value;
label_6:
        if (this.LayoutSystem == null)
          return;
        while (this.LayoutSystem.x10ac79a4257c7f52 == null)
        {
          if ((uint) value + (uint) value >= 0U)
          {
            if (false)
            {
              if (true)
                goto label_14;
            }
            else
              goto label_2;
          }
          if (true)
            goto label_6;
        }
        goto label_3;
      }
    }

    public override string Text
    {
      get
      {
        return base.Text;
      }
      set
      {
        base.Text = value;
        this.x7735d9a753c63a0a();
        if (false)
          ;
        if (this.DockSituation != DockSituation.Floating)
          return;
        if (!this.x410f3612b9a8f9de.HasSingleControlLayoutSystem)
          goto label_4;
label_2:
        if (this.LayoutSystem.SelectedControl != this)
          return;
        this.x410f3612b9a8f9de.xd1bdd0ee5924b59e();
        return;
label_4:
        if (true)
        {
          if (false)
            goto label_2;
        }
        else if (true)
          goto label_2;
      }
    }

    internal Image x1999b243e321e38a
    {
      get
      {
        if (this.x564c6c527905c683 == null)
          return DockControl.x28afaed1891a17a1;
        return this.x564c6c527905c683;
      }
    }

    [Browsable(false)]
    public Rectangle TabBounds
    {
      get
      {
        return this.x123e054dab107457;
      }
    }

    [Browsable(false)]
    public DockSituation DockSituation
    {
      get
      {
        return this.xef84499526c04953;
      }
    }

    private void x409072a6bb877e49(DockSituation xbcea506a33cf9111)
    {
      if (this.x131b418d4c565c70)
        throw new InvalidOperationException("The requested operation is not valid on a window that is currently engaged in an activity further up the call stack. Consider using BeginInvoke to postpone the operation until the stack has unwound.");
      if (xbcea506a33cf9111 == this.xef84499526c04953)
        return;
      this.xef84499526c04953 = xbcea506a33cf9111;
      this.x131b418d4c565c70 = true;
      try
      {
        this.OnDockSituationChanged(EventArgs.Empty);
      }
      finally
      {
        this.x131b418d4c565c70 = false;
      }
    }

    [DefaultValue(typeof (Image), null)]
    [AmbientValue(typeof (Image), null)]
    [Description("The image displayed for this control on docking tabs.")]
    [Category("Appearance")]
    public Image TabImage
    {
      get
      {
        return this.x564c6c527905c683;
      }
      set
      {
        this.x564c6c527905c683 = value;
        this.x7735d9a753c63a0a();
      }
    }

    protected override System.Drawing.Size DefaultSize
    {
      get
      {
        return new System.Drawing.Size(250, 400);
      }
    }

    protected override void OnFontChanged(EventArgs e)
    {
      base.OnFontChanged(e);
      if (this.xadad18dc04073a00)
        return;
      this.x7735d9a753c63a0a();
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (((disposing ? 1 : 0) & 0) != 0)
          return;
        if (this.xb6a159a84cb992d6 != null)
          LayoutUtilities.xf1cbd48a28ce6e74(this);
        if (this.Manager != null)
          this.Manager = (SandDockManager) null;
      }
      base.Dispose(disposing);
    }

    protected override void WndProc(ref Message m)
    {
      if (m.Msg == 33)
      {
        if (true)
          base.WndProc(ref m);
      }
      else
        goto label_5;
label_3:
      while (!this.ContainsFocus)
      {
        this.Activate();
        if (true)
          break;
      }
      return;
label_5:
      base.WndProc(ref m);
      if (false)
        goto label_3;
    }
  }
}
