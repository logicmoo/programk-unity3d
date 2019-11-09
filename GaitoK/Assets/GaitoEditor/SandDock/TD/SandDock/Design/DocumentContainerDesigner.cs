// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Design.DocumentContainerDesigner
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.ComponentModel;
using System.Drawing;

namespace TD.SandDock.Design
{
  internal class DocumentContainerDesigner : DockContainerDesigner
  {
    private DockContainer x1f1a3b29d7ed7776;

    protected override bool GetHitTest(System.Drawing.Point point)
    {
      point = this.x1f1a3b29d7ed7776.PointToClient(point);
      if (true)
        goto label_6;
label_1:
      Rectangle scrollButtonBounds1;
      if (!scrollButtonBounds1.Contains(point))
        goto label_8;
label_2:
      return true;
label_6:
      LayoutSystemBase layoutSystemAt = this.x1f1a3b29d7ed7776.GetLayoutSystemAt(point);
      if (layoutSystemAt is DocumentLayoutSystem)
      {
        DocumentLayoutSystem documentLayoutSystem = (DocumentLayoutSystem) layoutSystemAt;
        Rectangle scrollButtonBounds2 = documentLayoutSystem.LeftScrollButtonBounds;
        while (!scrollButtonBounds2.Contains(point))
        {
          if (true)
          {
            scrollButtonBounds1 = documentLayoutSystem.RightScrollButtonBounds;
            goto label_1;
          }
        }
        goto label_2;
      }
label_8:
      return base.GetHitTest(point);
    }

    public override void Initialize(IComponent component)
    {
      base.Initialize(component);
      this.x1f1a3b29d7ed7776 = (DockContainer) component;
    }
  }
}
