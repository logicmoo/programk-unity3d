// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Design.DockControlDesigner
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TD.SandDock.Design
{
  internal class DockControlDesigner : ParentControlDesigner
  {
    private static bool xb070ba46e7c7d3b6;
    private DockControl xdeac46e41e0fbcf5;
    private bool x9f93ebd2ca5601a2;
    private IComponentChangeService x4cd3df9bd5e139a3;
    private IDesignerHost xff9c60b45aa37b1e;
    private ISelectionService x77da34c6f08140f2;

    public override SelectionRules SelectionRules
    {
      get
      {
        return SelectionRules.None;
      }
    }

    public override void Initialize(IComponent component)
    {
      base.Initialize(component);
      if (component is DockControl)
        goto label_11;
      else
        goto label_13;
label_1:
      if (true)
        return;
label_4:
      this.xdeac46e41e0fbcf5.Collapsed = false;
      if (true)
        goto label_9;
label_5:
      if (this.xdeac46e41e0fbcf5.Collapsed)
        goto label_6;
label_2:
      do
      {
        if (false)
          goto label_5;
      }
      while (false);
      return;
label_6:
      this.Collapsed = true;
      if (true)
      {
        if (true)
          goto label_4;
        else
          goto label_2;
      }
label_7:
      this.xdeac46e41e0fbcf5 = (DockControl) component;
      this.xdeac46e41e0fbcf5.x81444a37d39a0e4a();
      this.x77da34c6f08140f2.SelectionChanged += new EventHandler(this.x6179d221e3fa4b20);
      this.xdeac46e41e0fbcf5.ControlAdded += new ControlEventHandler(this.x5ba88706ad55272f);
      this.xdeac46e41e0fbcf5.ControlRemoved += new ControlEventHandler(this.x5ba88706ad55272f);
      goto label_5;
label_9:
      if (true)
        goto label_1;
label_10:
      SandDockLanguage.ShowCachedAssemblyError(component.GetType().Assembly, this.GetType().Assembly);
label_11:
      this.x4cd3df9bd5e139a3 = (IComponentChangeService) this.GetService(typeof (IComponentChangeService));
      this.xff9c60b45aa37b1e = (IDesignerHost) this.GetService(typeof (IDesignerHost));
      this.x77da34c6f08140f2 = (ISelectionService) this.GetService(typeof (ISelectionService));
      if (true)
        goto label_7;
      else
        goto label_9;
label_13:
      if (true)
        goto label_10;
      else
        goto label_1;
    }

    protected override void Dispose(bool disposing)
    {
      this.xdeac46e41e0fbcf5.ControlAdded -= new ControlEventHandler(this.x5ba88706ad55272f);
      this.xdeac46e41e0fbcf5.ControlRemoved -= new ControlEventHandler(this.x5ba88706ad55272f);
      this.x77da34c6f08140f2.SelectionChanged -= new EventHandler(this.x6179d221e3fa4b20);
      base.Dispose(disposing);
    }

    public bool Collapsed
    {
      get
      {
        return (bool) this.ShadowProperties[nameof (Collapsed)];
      }
      set
      {
        this.ShadowProperties[nameof (Collapsed)] = (object) value;
        if ((uint) value + (uint) value >= 0U && this.xdeac46e41e0fbcf5.LayoutSystem == null || DockControlDesigner.xb070ba46e7c7d3b6)
          return;
        DockControlDesigner.xb070ba46e7c7d3b6 = true;
        try
        {
          IEnumerator enumerator = this.xdeac46e41e0fbcf5.LayoutSystem.Controls.GetEnumerator();
          try
          {
label_8:
            if (!enumerator.MoveNext())
              goto label_9;
label_4:
            DockControl current = (DockControl) enumerator.Current;
label_5:
            if ((uint) value + (uint) value >= 0U)
              goto label_7;
label_6:
            TypeDescriptor.GetProperties((object) current)[nameof (Collapsed)].SetValue((object) current, (object) value);
            if ((uint) value + (uint) value <= uint.MaxValue)
              goto label_8;
label_7:
            if (current != this.xdeac46e41e0fbcf5)
              goto label_6;
            else
              goto label_8;
label_9:
            if (true)
              return;
            if ((uint) value + (uint) value <= uint.MaxValue)
            {
              if ((uint) value - (uint) value >= 0U)
                goto label_4;
            }
            else
              goto label_5;
          }
          finally
          {
            (enumerator as IDisposable)?.Dispose();
          }
        }
        finally
        {
          DockControlDesigner.xb070ba46e7c7d3b6 = false;
        }
      }
    }

    protected override void PreFilterProperties(IDictionary properties)
    {
      base.PreFilterProperties(properties);
      string[] strArray = new string[1]{ "Collapsed" };
      int index = 0;
      while (true)
      {
        if (index < strArray.Length)
          goto label_7;
        else
          goto label_4;
label_2:
        ++index;
        continue;
label_4:
        if (false)
          goto label_2;
        else
          break;
label_7:
        string str = strArray[index];
        PropertyDescriptor property = (PropertyDescriptor) properties[(object) str];
        if ((index & 0) != 0)
          goto label_5;
label_1:
        if (property != null)
          goto label_6;
        else
          goto label_2;
label_5:
        if ((index & 0) != 0)
          ;
label_6:
        properties[(object) str] = (object) TypeDescriptor.CreateProperty(typeof (DockControlDesigner), property);
        if ((uint) index - (uint) index <= uint.MaxValue)
          goto label_2;
        else
          goto label_1;
      }
    }

    private void x6179d221e3fa4b20(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      bool componentSelected = this.x77da34c6f08140f2.GetComponentSelected((object) this.Component);
      if (componentSelected != this.x9f93ebd2ca5601a2)
        this.x9f93ebd2ca5601a2 = componentSelected;
      else
        goto label_3;
label_2:
      ((DockControl) this.Component).LayoutSystem.xd541e2fc281b554b();
      return;
label_3:
      if (false)
        goto label_2;
    }

    protected override void OnPaintAdornments(PaintEventArgs pe)
    {
      base.OnPaintAdornments(pe);
      if (this.xdeac46e41e0fbcf5.Controls.Count == 0)
        goto label_2;
label_1:
      if (this.xdeac46e41e0fbcf5.BorderStyle != TD.SandDock.Rendering.BorderStyle.None)
        return;
      using (Pen pen = new Pen(SystemColors.ControlDark))
      {
        pen.DashStyle = DashStyle.Dot;
        Rectangle clientRectangle = this.xdeac46e41e0fbcf5.ClientRectangle;
        --clientRectangle.Width;
        --clientRectangle.Height;
        pe.Graphics.DrawRectangle(pen, clientRectangle);
        return;
      }
label_2:
      Rectangle clientRectangle1 = this.xdeac46e41e0fbcf5.ClientRectangle;
      clientRectangle1.Inflate(-10, -10);
      using (Font font = new Font(this.xdeac46e41e0fbcf5.Font.Name, 6.75f))
      {
        TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;
        TextRenderer.DrawText((IDeviceContext) pe.Graphics, "To redock windows, click and drag their tabs or titlebars to other locations on your form.", font, clientRectangle1, SystemColors.ControlDarkDark, flags);
        goto label_1;
      }
    }

    private void x5ba88706ad55272f(object xe0292b9ed559da7d, ControlEventArgs xfbf34718e704c6bc)
    {
      if (this.xdeac46e41e0fbcf5.Controls.Count != 0 && this.xdeac46e41e0fbcf5.Controls.Count != 1)
        return;
      this.xdeac46e41e0fbcf5.Invalidate();
    }
  }
}
