// Decompiled with JetBrains decompiler
// Type: TD.SandDock.xd936980ea1aac341
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
  internal class xd936980ea1aac341 : Form
  {
    private const int x7260e2e8b818e128 = 2;
    private const int xcc781840d1708149 = 165;
    private const int x07ac164555740e80 = 164;
    private const int x5898cfc7c31e0ba4 = 161;
    private const int xad2c4838c7f4b06e = 163;
    private x410f3612b9a8f9de xd3311d815ca25f02;
    private System.Drawing.Point x6afebf16b45c02e0;

    public xd936980ea1aac341(x410f3612b9a8f9de container)
    {
      this.xd3311d815ca25f02 = container;
      this.FormBorderStyle = FormBorderStyle.SizableToolWindow;
      this.StartPosition = FormStartPosition.Manual;
      this.ShowInTaskbar = false;
    }

    protected override void OnActivated(EventArgs e)
    {
      base.OnActivated(e);
      if (this.xd3311d815ca25f02.ActiveControl != null)
        return;
      ControlLayoutSystem controlLayoutSystem = LayoutUtilities.FindControlLayoutSystem((DockContainer) this.xd3311d815ca25f02);
      if (controlLayoutSystem == null)
        return;
      if (false)
        ;
      if (controlLayoutSystem.SelectedControl == null)
        return;
      this.xd3311d815ca25f02.ActiveControl = (Control) controlLayoutSystem.SelectedControl;
    }

    protected override void OnResize(EventArgs e)
    {
      base.OnResize(e);
      if (true)
        goto label_10;
      else
        goto label_8;
label_2:
      int index;
      if (this.xd3311d815ca25f02 == null)
      {
        if ((index | 4) != 0)
          return;
      }
      else
        goto label_11;
label_8:
      DockControl[] x9476096be9672d38;
      for (index = 0; index < x9476096be9672d38.Length; ++index)
      {
        x9476096be9672d38[index].FloatingSize = this.Size;
        if (false)
          goto label_10;
      }
      if ((index | (int) byte.MaxValue) != 0)
        return;
      goto label_2;
label_10:
      if (true)
        goto label_2;
label_11:
      x9476096be9672d38 = this.xd3311d815ca25f02.LayoutSystem.x9476096be9672d38;
      goto label_8;
    }

    protected override void OnMove(EventArgs e)
    {
      base.OnMove(e);
      while (this.xd3311d815ca25f02 != null)
      {
        DockControl[] x9476096be9672d38 = this.xd3311d815ca25f02.LayoutSystem.x9476096be9672d38;
        for (int index = 0; index < x9476096be9672d38.Length; ++index)
        {
          DockControl dockControl;
          do
          {
            dockControl = x9476096be9672d38[index];
            if ((uint) index - (uint) index < 0U)
              goto label_6;
          }
          while ((uint) index < 0U);
          dockControl.FloatingLocation = this.Location;
        }
label_6:
        if (true)
          break;
      }
    }

    private bool x8956f13386ebab05()
    {
      if (this.xd3311d815ca25f02.HasSingleControlLayoutSystem)
      {
        ControlLayoutSystem layoutSystem = (ControlLayoutSystem) this.xd3311d815ca25f02.LayoutSystem.LayoutSystems[0];
        if (layoutSystem.SelectedControl != null)
        {
          this.xd3311d815ca25f02.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(layoutSystem.SelectedControl, layoutSystem.SelectedControl.PointToClient(Cursor.Position), ContextMenuContext.RightClick));
          return true;
        }
      }
      return false;
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (e.Button != MouseButtons.Left || !(this.x6afebf16b45c02e0 != System.Drawing.Point.Empty))
        return;
      Rectangle rectangle;
      do
      {
        rectangle = new Rectangle(this.x6afebf16b45c02e0, SystemInformation.DragSize);
      }
      while (false);
      do
      {
        rectangle.Offset(-SystemInformation.DragSize.Width / 2, -SystemInformation.DragSize.Height / 2);
        if (!rectangle.Contains(e.X, e.Y))
        {
          this.x6afebf16b45c02e0.Y += SystemInformation.ToolWindowCaptionHeight + SystemInformation.FrameBorderSize.Height;
          this.xd3311d815ca25f02.LayoutSystem.xe9a159cd1e028df2(this.xd3311d815ca25f02.Manager, (DockContainer) this.xd3311d815ca25f02, (LayoutSystemBase) this.xd3311d815ca25f02.LayoutSystem, (DockControl) null, this.xd3311d815ca25f02.xbe0b15fe97a1ee89.MetaData.DockedContentSize, this.x6afebf16b45c02e0, this.xd3311d815ca25f02.Manager.DockingHints, this.xd3311d815ca25f02.Manager.DockingManager);
        }
        else
          goto label_2;
      }
      while (false);
      goto label_1;
label_2:
      return;
label_1:
      this.xd3311d815ca25f02.x3df31cf55a47bc37 = (LayoutSystemBase) this.xd3311d815ca25f02.LayoutSystem;
      this.Capture = false;
      this.xd3311d815ca25f02.Capture = true;
      this.x6afebf16b45c02e0 = System.Drawing.Point.Empty;
    }

    protected override void WndProc(ref Message m)
    {
      if (m.Msg != 161)
        goto label_14;
      else
        goto label_17;
label_1:
      if (this.x8956f13386ebab05())
        goto label_9;
label_2:
      base.WndProc(ref m);
      IntPtr wparam1;
      if ((uint) wparam1 + (uint) wparam1 <= uint.MaxValue)
        return;
label_3:
      IntPtr wparam2;
      if (wparam2.ToInt32() != 2)
      {
        if ((uint) wparam1 + (uint) wparam1 >= 0U)
        {
          if ((uint) wparam1 <= uint.MaxValue)
            goto label_2;
        }
        else
          goto label_1;
      }
      else
        goto label_12;
label_6:
      if (m.Msg == 164)
      {
        this.Capture = false;
        if ((uint) wparam2 - (uint) wparam1 >= 0U)
          goto label_1;
      }
      else
        goto label_2;
label_9:
      m.Result = IntPtr.Zero;
      return;
label_12:
      this.OnDoubleClick(EventArgs.Empty);
      m.Result = IntPtr.Zero;
      return;
label_14:
      if (m.Msg == 163)
      {
        wparam2 = m.WParam;
        IntPtr num;
        if (((int) (uint) num | 4) != 0)
        {
          if ((uint) wparam2 + (uint) wparam2 > uint.MaxValue)
            goto label_12;
          else
            goto label_3;
        }
        else
          goto label_1;
      }
      else
        goto label_6;
label_17:
      IntPtr num1;
      if ((uint) num1 <= uint.MaxValue)
      {
        wparam1 = m.WParam;
        if (wparam1.ToInt32() == 2)
        {
          x443cc432acaadb1d.ReleaseCapture();
          this.Activate();
          this.x6afebf16b45c02e0 = this.PointToClient(Cursor.Position);
          this.Capture = true;
          if (false)
            return;
          m.Result = IntPtr.Zero;
        }
        else
          goto label_2;
      }
      else
        goto label_2;
    }
  }
}
