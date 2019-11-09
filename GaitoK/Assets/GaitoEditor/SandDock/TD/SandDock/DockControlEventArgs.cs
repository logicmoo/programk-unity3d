// Decompiled with JetBrains decompiler
// Type: TD.SandDock.DockControlEventArgs
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;

namespace TD.SandDock
{
  public class DockControlEventArgs : EventArgs
  {
    private DockControl xdeac46e41e0fbcf5;

    internal DockControlEventArgs(DockControl dockControl)
    {
      this.xdeac46e41e0fbcf5 = dockControl;
    }

    public DockControl DockControl
    {
      get
      {
        return this.xdeac46e41e0fbcf5;
      }
    }
  }
}
