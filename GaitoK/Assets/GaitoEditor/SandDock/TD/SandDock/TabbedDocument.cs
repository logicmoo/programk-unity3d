// Decompiled with JetBrains decompiler
// Type: TD.SandDock.TabbedDocument
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.ComponentModel;
using System.Windows.Forms;

namespace TD.SandDock
{
  public class TabbedDocument : DockControl
  {
    public TabbedDocument()
    {
      this.x84eb05aa1ce8e247();
    }

    public TabbedDocument(SandDockManager manager, Control control, string text)
      : base(manager, control, text)
    {
      this.x84eb05aa1ce8e247();
    }

    private void x84eb05aa1ce8e247()
    {
      if (this.Text.Length == 0)
        this.Text = "Tabbed Document";
      this.CloseAction = DockControlCloseAction.Dispose;
      this.PersistState = false;
      this.SetPositionMetaData(DockSituation.Document);
    }

    protected override DockingRules CreateDockingRules()
    {
      return new DockingRules(false, true, false);
    }

    public override void Open()
    {
      this.Open(WindowOpenMethod.OnScreenActivate);
    }

    protected override System.Drawing.Size DefaultSize
    {
      get
      {
        return new System.Drawing.Size(550, 400);
      }
    }

    [DefaultValue(typeof (DockControlCloseAction), "Dispose")]
    public override DockControlCloseAction CloseAction
    {
      get
      {
        return base.CloseAction;
      }
      set
      {
        base.CloseAction = value;
      }
    }

    [DefaultValue(false)]
    public override bool PersistState
    {
      get
      {
        return base.PersistState;
      }
      set
      {
        base.PersistState = value;
      }
    }
  }
}
