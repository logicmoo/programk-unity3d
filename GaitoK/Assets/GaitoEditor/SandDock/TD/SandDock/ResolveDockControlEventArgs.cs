// Decompiled with JetBrains decompiler
// Type: TD.SandDock.ResolveDockControlEventArgs
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;

namespace TD.SandDock
{
  public class ResolveDockControlEventArgs : EventArgs
  {
    private DockControl x43bec302f92080b9;
    private Guid xb51cd75f17ace1ec;

    internal ResolveDockControlEventArgs(Guid guid)
    {
      this.xb51cd75f17ace1ec = guid;
    }

    public Guid Guid
    {
      get
      {
        return this.xb51cd75f17ace1ec;
      }
    }

    public DockControl DockControl
    {
      get
      {
        return this.x43bec302f92080b9;
      }
      set
      {
        this.x43bec302f92080b9 = value;
      }
    }
  }
}
