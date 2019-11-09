// Decompiled with JetBrains decompiler
// Type: TD.SandDock.DockableWindow
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.Windows.Forms;

namespace TD.SandDock
{
  public class DockableWindow : DockControl
  {
    public DockableWindow()
    {
      this.x84eb05aa1ce8e247();
    }

    public DockableWindow(SandDockManager manager, Control control, string text)
      : base(manager, control, text)
    {
      this.x84eb05aa1ce8e247();
    }

    protected override DockingRules CreateDockingRules()
    {
      return new DockingRules(true, false, true);
    }

    public override void Open()
    {
      this.Open(WindowOpenMethod.OnScreenSelect);
    }

    private void x84eb05aa1ce8e247()
    {
      if (this.Text.Length == 0)
        this.Text = "Dockable Window";
      this.SetPositionMetaData(DockSituation.Docked, ContainerDockLocation.Right);
    }

    protected override System.Drawing.Size DefaultSize
    {
      get
      {
        return new System.Drawing.Size(250, 400);
      }
    }
  }
}
