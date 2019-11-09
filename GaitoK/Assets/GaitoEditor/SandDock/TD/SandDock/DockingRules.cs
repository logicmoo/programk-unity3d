// Decompiled with JetBrains decompiler
// Type: TD.SandDock.DockingRules
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.ComponentModel;

namespace TD.SandDock
{
  [TypeConverter(typeof (ExpandableObjectConverter))]
  public class DockingRules
  {
    private bool x33b0d41936d07496 = true;
    private bool x608234746b921e23 = true;
    private bool x22d61e656653012c = true;
    private bool xf2ea876cc567e81e = true;
    private bool x789b1ef056ebb726 = true;
    private bool xadbc8fe70595ade0 = true;

    public DockingRules()
    {
    }

    public DockingRules(bool allowDock, bool allowTab, bool allowFloat)
    {
      if (true)
        goto label_4;
label_1:
      if ((uint) allowTab + (uint) allowTab <= uint.MaxValue)
      {
        this.AllowDockRight = allowDock;
        this.AllowDockTop = allowDock;
      }
      this.AllowDockBottom = allowDock;
      this.AllowTab = allowTab;
      this.AllowFloat = allowFloat;
      return;
label_4:
      this.AllowDockLeft = allowDock;
      goto label_1;
    }

    internal void xd5da23b762ce52a2(DockingRules[] x7c92c43084985bae)
    {
      DockingRules[] dockingRulesArray = x7c92c43084985bae;
      int index = 0;
      while (index < dockingRulesArray.Length)
      {
        DockingRules dockingRules = dockingRulesArray[index];
        this.AllowDockLeft = this.AllowDockLeft && dockingRules.AllowDockLeft;
        this.AllowDockRight = this.AllowDockRight && dockingRules.AllowDockRight;
        this.AllowDockTop = this.AllowDockTop && dockingRules.AllowDockTop;
        this.AllowDockBottom = this.AllowDockBottom && dockingRules.AllowDockBottom;
        this.AllowTab = this.AllowTab && dockingRules.AllowTab;
        this.AllowFloat = this.AllowFloat && dockingRules.AllowFloat;
        ++index;
        if (false)
          ;
      }
    }

    public bool AllowDockLeft
    {
      get
      {
        return this.x33b0d41936d07496;
      }
      set
      {
        this.x33b0d41936d07496 = value;
      }
    }

    public bool AllowDockRight
    {
      get
      {
        return this.x608234746b921e23;
      }
      set
      {
        this.x608234746b921e23 = value;
      }
    }

    public bool AllowDockTop
    {
      get
      {
        return this.x22d61e656653012c;
      }
      set
      {
        this.x22d61e656653012c = value;
      }
    }

    public bool AllowDockBottom
    {
      get
      {
        return this.xf2ea876cc567e81e;
      }
      set
      {
        this.xf2ea876cc567e81e = value;
      }
    }

    public bool AllowTab
    {
      get
      {
        return this.x789b1ef056ebb726;
      }
      set
      {
        this.x789b1ef056ebb726 = value;
      }
    }

    public bool AllowFloat
    {
      get
      {
        return this.xadbc8fe70595ade0;
      }
      set
      {
        this.xadbc8fe70595ade0 = value;
      }
    }
  }
}
