// Decompiled with JetBrains decompiler
// Type: TD.SandDock.ShowControlContextMenuEventArgs
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

namespace TD.SandDock
{
  public class ShowControlContextMenuEventArgs : DockControlEventArgs
  {
    private System.Drawing.Point x13d4cb8d1bd20347 = System.Drawing.Point.Empty;
    private ContextMenuContext x0f7b23d1c393aed9;

    internal ShowControlContextMenuEventArgs(
      DockControl dockControl,
      System.Drawing.Point position,
      ContextMenuContext context)
      : base(dockControl)
    {
      this.x13d4cb8d1bd20347 = position;
      this.x0f7b23d1c393aed9 = context;
    }

    public ContextMenuContext Context
    {
      get
      {
        return this.x0f7b23d1c393aed9;
      }
    }

    public System.Drawing.Point Position
    {
      get
      {
        return this.x13d4cb8d1bd20347;
      }
    }
  }
}
