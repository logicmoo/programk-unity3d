// Decompiled with JetBrains decompiler
// Type: TD.SandDock.ActiveFilesListEventArgs
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Windows.Forms;

namespace TD.SandDock
{
  public class ActiveFilesListEventArgs : EventArgs
  {
    private DockControl[] x8fb2a5bf0df0416f;
    private Control x43bec302f92080b9;
    private System.Drawing.Point x13d4cb8d1bd20347;

    internal ActiveFilesListEventArgs(DockControl[] windows, Control control, System.Drawing.Point position)
    {
      this.x8fb2a5bf0df0416f = windows;
      this.x43bec302f92080b9 = control;
      this.x13d4cb8d1bd20347 = position;
    }

    public DockControl[] Windows
    {
      get
      {
        return this.x8fb2a5bf0df0416f;
      }
    }

    public Control Control
    {
      get
      {
        return this.x43bec302f92080b9;
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
