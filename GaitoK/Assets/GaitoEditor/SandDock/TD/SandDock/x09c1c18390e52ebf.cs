// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x09c1c18390e52ebf
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
  internal class x09c1c18390e52ebf : x890231ddf317379e
  {
    private DockContainer xd3311d815ca25f02;
    private int xffa8345bf918658d;
    private int xb646339c3b9e735a;
    private int x0d4b3b88c5b24565;
    private int xf623ffb827affd4f;

    public event x09c1c18390e52ebf.ResizingManagerFinishedEventHandler x67ecc0d0e7c9a202;

    public x09c1c18390e52ebf(SandDockManager manager, DockContainer container, System.Drawing.Point startPoint)
      : base((Control) container, manager.DockingHints, false)
    {
      if (true)
        goto label_20;
      else
        goto label_17;
label_1:
      this.OnMouseMove(startPoint);
      return;
label_8:
      Rectangle rectangle;
      int num1;
      int x555227b0d2a372bd;
      this.xffa8345bf918658d = Math.Max(rectangle.Left + 20, startPoint.X - (num1 - x555227b0d2a372bd));
      if (false)
        ;
      int num2;
      this.xb646339c3b9e735a = startPoint.X + (x555227b0d2a372bd - num2);
      this.xf623ffb827affd4f = startPoint.X - container.x0c42f19be578ccee.X;
      goto label_1;
label_16:
      int val1;
      num2 = Math.Max(val1, LayoutUtilities.xc6fb69ef430eaa44(container));
      if (manager != null)
        goto label_13;
label_12:
      int num3 = 500;
      goto label_14;
label_13:
      num3 = manager.MaximumDockContainerSize;
label_14:
      num1 = num3;
      x555227b0d2a372bd = container.x555227b0d2a372bd;
      if ((uint) num1 <= uint.MaxValue)
      {
        if ((uint) num2 + (uint) num2 >= 0U)
        {
          switch (container.Dock)
          {
            case DockStyle.Top:
              this.xffa8345bf918658d = startPoint.Y - (x555227b0d2a372bd - num2);
              if ((uint) x555227b0d2a372bd + (uint) x555227b0d2a372bd <= uint.MaxValue)
                break;
              goto label_1;
            case DockStyle.Bottom:
              this.xffa8345bf918658d = Math.Max(rectangle.Top + 20, startPoint.Y - (num1 - x555227b0d2a372bd));
              this.xb646339c3b9e735a = startPoint.Y + (x555227b0d2a372bd - num2);
              if (true)
              {
                if ((num2 | 2) != 0)
                {
                  this.xf623ffb827affd4f = startPoint.Y - container.x0c42f19be578ccee.Y;
                  if ((uint) num2 - (uint) num2 < 0U)
                    return;
                  goto label_1;
                }
                else
                  break;
              }
              else
                goto label_1;
            case DockStyle.Left:
              this.xffa8345bf918658d = startPoint.X - (x555227b0d2a372bd - num2);
              this.xb646339c3b9e735a = Math.Min(rectangle.Right - 20, startPoint.X + (num1 - x555227b0d2a372bd));
              this.xf623ffb827affd4f = startPoint.X - container.x0c42f19be578ccee.X;
              goto label_1;
            case DockStyle.Right:
              goto label_8;
            default:
              goto label_1;
          }
          this.xb646339c3b9e735a = Math.Min(rectangle.Bottom - 20, startPoint.Y + (num1 - x555227b0d2a372bd));
          this.xf623ffb827affd4f = startPoint.Y - container.x0c42f19be578ccee.Y;
          goto label_1;
        }
        else
          goto label_12;
      }
      else
        goto label_1;
label_17:
      int num4;
      if ((num4 | -1) == 0)
        goto label_8;
label_18:
      val1 = 30;
      goto label_16;
label_20:
      this.xd3311d815ca25f02 = container;
      Rectangle empty = Rectangle.Empty;
      rectangle = xedb4922162c60d3d.xc68a4bb946c59a9e(xedb4922162c60d3d.x41c62f474d3fb367(container.Parent), container.Parent);
      rectangle = new Rectangle(container.PointToClient(rectangle.Location), rectangle.Size);
      if (manager != null)
      {
        val1 = manager.MinimumDockContainerSize;
        goto label_16;
      }
      else
        goto label_18;
    }

    public override void OnMouseMove(System.Drawing.Point position)
    {
      Rectangle rectangle = Rectangle.Empty;
      if (true)
        goto label_23;
label_16:
      if (rectangle.Y > this.xb646339c3b9e735a - 4)
        goto label_19;
label_17:
      switch (this.xd3311d815ca25f02.Dock)
      {
        case DockStyle.Top:
          this.x0d4b3b88c5b24565 = this.xd3311d815ca25f02.ContentSize + (rectangle.Y - this.xd3311d815ca25f02.x0c42f19be578ccee.Y);
          if (false)
          {
            if (false)
            {
              if (false)
                goto label_4;
              else
                goto label_4;
            }
            else
              goto label_6;
          }
          else
            goto default;
        case DockStyle.Bottom:
          this.x0d4b3b88c5b24565 = this.xd3311d815ca25f02.ContentSize + (this.xd3311d815ca25f02.x0c42f19be578ccee.Y - rectangle.Y);
          if (false)
            goto default;
          else
            goto default;
        case DockStyle.Left:
label_12:
          this.x0d4b3b88c5b24565 = this.xd3311d815ca25f02.ContentSize + (rectangle.X - this.xd3311d815ca25f02.x0c42f19be578ccee.X);
          goto default;
        case DockStyle.Right:
          this.x0d4b3b88c5b24565 = this.xd3311d815ca25f02.ContentSize + (this.xd3311d815ca25f02.x0c42f19be578ccee.X - rectangle.X);
          goto default;
        default:
          this.xe5e4149f382149cc(new Rectangle(this.xd3311d815ca25f02.PointToScreen(rectangle.Location), rectangle.Size), false);
          goto label_4;
      }
label_1:
      if (this.xd3311d815ca25f02.Dock != DockStyle.Right)
      {
        Cursor.Current = Cursors.HSplit;
        if (true)
          return;
        goto label_23;
      }
      else
        goto label_8;
label_4:
      if (this.xd3311d815ca25f02.Dock != DockStyle.Left)
      {
        if (true)
        {
          if (true)
            goto label_1;
          else
            goto label_12;
        }
      }
      else
        goto label_8;
label_6:
      if (false)
        goto label_4;
      else
        goto label_1;
label_8:
      Cursor.Current = Cursors.VSplit;
      return;
label_19:
      rectangle.Y = this.xb646339c3b9e735a - 4;
      goto label_17;
label_23:
      if (!this.xd3311d815ca25f02.x61c108cc44ef385a)
      {
        if (true)
        {
          rectangle = new Rectangle(0, position.Y - this.xf623ffb827affd4f, this.xd3311d815ca25f02.Width, 4);
          if (false)
            return;
          while (rectangle.Y < this.xffa8345bf918658d)
          {
            rectangle.Y = this.xffa8345bf918658d;
            if (true)
            {
              if (true)
                break;
              goto label_19;
            }
          }
          goto label_16;
        }
        else
          goto label_16;
      }
      else
      {
        rectangle = new Rectangle(position.X - this.xf623ffb827affd4f, 0, 4, this.xd3311d815ca25f02.Height);
        if (rectangle.X < this.xffa8345bf918658d)
          goto label_29;
label_25:
        if (rectangle.X > this.xb646339c3b9e735a - 4)
        {
          rectangle.X = this.xb646339c3b9e735a - 4;
          goto label_17;
        }
        else
          goto label_17;
label_29:
        rectangle.X = this.xffa8345bf918658d;
        goto label_25;
      }
    }

    public override void Commit()
    {
      base.Commit();
      if (this.x67ecc0d0e7c9a202 == null)
        return;
      this.x67ecc0d0e7c9a202(this.x0d4b3b88c5b24565);
    }

    public delegate void ResizingManagerFinishedEventHandler(int newSize);
  }
}
