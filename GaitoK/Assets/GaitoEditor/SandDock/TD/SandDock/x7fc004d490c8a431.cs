// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x7fc004d490c8a431
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
  internal class x7fc004d490c8a431 : x890231ddf317379e
  {
    private x10ac79a4257c7f52 x2ee8392f53a01b93;
    private x87cf4de36131799d x5fea292ffeb2c28c;
    private System.Drawing.Point xcb09bd0cee4909a3;
    private int xe7e5c1179f5c7ae1;
    private int xffa8345bf918658d;
    private int xb646339c3b9e735a;
    private int x0d4b3b88c5b24565;

    public event x7fc004d490c8a431.ResizingManagerFinishedEventHandler x67ecc0d0e7c9a202;

    public x7fc004d490c8a431(
      x10ac79a4257c7f52 bar,
      x87cf4de36131799d popupContainer,
      System.Drawing.Point startPoint)
      : base((Control) bar, bar.x460ab163f44a604d != null ? bar.x460ab163f44a604d.DockingHints : DockingHints.TranslucentFill, false)
    {
label_36:
      this.x2ee8392f53a01b93 = bar;
      if (true)
        goto label_34;
      else
        goto label_31;
label_28:
      int num1 = bar.x460ab163f44a604d.MaximumDockContainerSize;
label_29:
      int num2 = num1;
      this.xe7e5c1179f5c7ae1 = popupContainer.xca843b3e9a1c605f;
      int val2;
      do
      {
        DockStyle dock = bar.Dock;
        if (true)
        {
          switch (dock)
          {
            case DockStyle.Top:
              goto label_15;
            case DockStyle.Bottom:
              goto label_4;
            case DockStyle.Left:
              goto label_25;
            case DockStyle.Right:
              if (bar.x460ab163f44a604d == null)
                continue;
              goto label_19;
            default:
              goto label_3;
          }
        }
        else
          goto label_35;
      }
      while ((uint) val2 - (uint) num2 < 0U);
      goto label_18;
label_2:
      this.xffa8345bf918658d = startPoint.Y - (num2 - this.xe7e5c1179f5c7ae1);
      this.xb646339c3b9e735a = startPoint.Y + (this.xe7e5c1179f5c7ae1 - val2);
label_3:
      this.OnMouseMove(startPoint);
      if (true)
        goto label_21;
      else
        goto label_5;
label_4:
      Rectangle bounds;
      if (bar.x460ab163f44a604d != null)
      {
        if ((uint) num2 + (uint) num2 >= 0U)
        {
          if (bar.x460ab163f44a604d.DockSystemContainer != null)
          {
            bounds = popupContainer.Bounds;
            goto label_13;
          }
          else
            goto label_2;
        }
        else
          goto label_21;
      }
      else
        goto label_2;
label_5:
      num2 = Math.Max(bounds.Bottom - val2, val2);
      goto label_2;
label_7:
      this.xffa8345bf918658d = startPoint.Y - (this.xe7e5c1179f5c7ae1 - val2);
      this.xb646339c3b9e735a = startPoint.Y + (num2 - this.xe7e5c1179f5c7ae1);
      goto label_3;
label_12:
      if ((num2 | 1) != 0)
      {
        if (bar.x460ab163f44a604d.DockSystemContainer == null)
        {
          if ((num2 & 0) == 0)
            goto label_7;
        }
        else
        {
          num2 = Math.Max(bar.x460ab163f44a604d.DockSystemContainer.Height - popupContainer.Bounds.Top - val2, val2);
          goto label_7;
        }
      }
      else
        goto label_24;
label_13:
      if (true)
        goto label_5;
      else
        goto label_21;
label_15:
      if (bar.x460ab163f44a604d == null)
        goto label_7;
      else
        goto label_12;
label_18:
      this.xffa8345bf918658d = startPoint.X - (num2 - this.xe7e5c1179f5c7ae1);
      if ((uint) num2 - (uint) num2 >= 0U)
      {
        this.xb646339c3b9e735a = startPoint.X + (this.xe7e5c1179f5c7ae1 - val2);
        goto label_3;
      }
      else
        goto label_12;
label_19:
      if (bar.x460ab163f44a604d.DockSystemContainer != null)
      {
        num2 = Math.Max(popupContainer.Bounds.Right - val2, val2);
        goto label_18;
      }
      else
        goto label_18;
label_21:
      if ((uint) val2 - (uint) num2 >= 0U)
        return;
      if ((uint) val2 + (uint) num2 >= 0U)
        goto label_36;
      else
        goto label_31;
label_24:
      this.xb646339c3b9e735a = startPoint.X + (num2 - this.xe7e5c1179f5c7ae1);
      goto label_3;
label_25:
      if (bar.x460ab163f44a604d != null && bar.x460ab163f44a604d.DockSystemContainer != null)
        goto label_26;
label_23:
      this.xffa8345bf918658d = startPoint.X - (this.xe7e5c1179f5c7ae1 - val2);
      goto label_24;
label_26:
      num2 = Math.Max(bar.x460ab163f44a604d.DockSystemContainer.Width - popupContainer.Bounds.Left - val2, val2);
      goto label_23;
label_31:
      if ((uint) num2 - (uint) val2 < 0U)
        goto label_35;
      else
        goto label_28;
label_34:
      this.x5fea292ffeb2c28c = popupContainer;
label_35:
      if ((uint) val2 + (uint) val2 >= 0U)
      {
        this.xcb09bd0cee4909a3 = startPoint;
        val2 = bar.x460ab163f44a604d != null ? bar.x460ab163f44a604d.MinimumDockContainerSize : 30;
        if (bar.x460ab163f44a604d == null)
        {
          num1 = 500;
          goto label_29;
        }
        else
          goto label_28;
      }
      else
        goto label_36;
    }

    public override void OnMouseMove(System.Drawing.Point position)
    {
      Rectangle rectangle = Rectangle.Empty;
      if (true)
        goto label_23;
      else
        goto label_19;
label_1:
      this.x0d4b3b88c5b24565 = this.xe7e5c1179f5c7ae1 + (position.Y - this.xcb09bd0cee4909a3.Y);
      goto label_3;
label_2:
      this.x0d4b3b88c5b24565 = this.xe7e5c1179f5c7ae1 + (this.xcb09bd0cee4909a3.Y - position.Y);
label_3:
      this.xe5e4149f382149cc(new Rectangle(this.x5fea292ffeb2c28c.PointToScreen(rectangle.Location), rectangle.Size), false);
      if (true)
        return;
      goto label_16;
label_9:
      DockStyle dock = this.x2ee8392f53a01b93.Dock;
      if (true)
      {
        if (false)
          goto label_2;
      }
      else
        goto label_22;
label_13:
      if (true)
        goto label_5;
label_4:
      this.x0d4b3b88c5b24565 = this.xe7e5c1179f5c7ae1 + (this.xcb09bd0cee4909a3.X - position.X);
      goto label_3;
label_5:
      switch (dock)
      {
        case DockStyle.Top:
          goto label_1;
        case DockStyle.Bottom:
          goto label_2;
        case DockStyle.Left:
          this.x0d4b3b88c5b24565 = this.xe7e5c1179f5c7ae1 + (position.X - this.xcb09bd0cee4909a3.X);
          goto label_3;
        case DockStyle.Right:
          goto label_4;
        default:
          goto label_3;
      }
label_16:
      rectangle = new Rectangle(position.X - 2, 0, 4, this.x5fea292ffeb2c28c.Height);
      goto label_9;
label_19:
      if (true)
        goto label_16;
label_20:
      if (position.X <= this.xb646339c3b9e735a)
        goto label_16;
label_22:
      position.X = this.xb646339c3b9e735a;
      goto label_19;
label_23:
      if (true)
      {
        if (!this.x2ee8392f53a01b93.x61c108cc44ef385a)
        {
          if (true)
            goto label_15;
          else
            goto label_14;
label_7:
          if (position.Y > this.xb646339c3b9e735a)
            goto label_12;
label_8:
          rectangle = new Rectangle(0, position.Y - 2, this.x5fea292ffeb2c28c.Width, 4);
          goto label_9;
label_12:
          position.Y = this.xb646339c3b9e735a;
          if (true)
            goto label_8;
          else
            goto label_13;
label_14:
          if (true)
          {
            position.Y = this.xffa8345bf918658d;
            goto label_7;
          }
label_15:
          if (position.Y >= this.xffa8345bf918658d)
            goto label_7;
          else
            goto label_14;
        }
        else
          goto label_26;
      }
      else if (true)
        goto label_26;
label_25:
      position.X = this.xffa8345bf918658d;
      goto label_20;
label_26:
      if (position.X >= this.xffa8345bf918658d)
      {
        if (false)
          goto label_1;
        else
          goto label_20;
      }
      else
        goto label_25;
    }

    public override void Commit()
    {
      base.Commit();
      do
      {
        if (this.x67ecc0d0e7c9a202 != null)
          goto label_5;
label_1:
        if (true)
          goto label_6;
label_3:
        continue;
label_5:
        this.x67ecc0d0e7c9a202(this.x0d4b3b88c5b24565);
        if (true)
          goto label_3;
        else
          goto label_1;
      }
      while (false);
      goto label_4;
label_6:
      return;
label_4:;
    }

    public delegate void ResizingManagerFinishedEventHandler(int newSize);
  }
}
