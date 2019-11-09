// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x8e80e1c8bce8caf7
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
  internal class x8e80e1c8bce8caf7 : x890231ddf317379e
  {
    private System.Drawing.Point xcb09bd0cee4909a3 = System.Drawing.Point.Empty;
    internal const int x7ae613ae2690dbe6 = 25;
    private DockContainer xd3311d815ca25f02;
    private SplitLayoutSystem xd0bab8a0f8013a7b;
    private LayoutSystemBase xc13a8191724b6d55;
    private LayoutSystemBase x5aa50bbadb0a1e6c;
    private int xffa8345bf918658d;
    private int xb646339c3b9e735a;
    private float x5c2440c931f8d932;
    private float x4afa341b2323a009;
    private float x3fb8b43b602e016f;

    public event x8e80e1c8bce8caf7.SplittingManagerFinishedEventHandler x67ecc0d0e7c9a202;

    public x8e80e1c8bce8caf7(
      DockContainer container,
      SplitLayoutSystem splitLayout,
      LayoutSystemBase aboveLayout,
      LayoutSystemBase belowLayout,
      System.Drawing.Point startPoint,
      DockingHints dockingHints)
      : base((Control) container, dockingHints, false)
    {
label_7:
      this.xd3311d815ca25f02 = container;
      this.xd0bab8a0f8013a7b = splitLayout;
      this.xc13a8191724b6d55 = aboveLayout;
      this.x5aa50bbadb0a1e6c = belowLayout;
      this.xcb09bd0cee4909a3 = startPoint;
      if (splitLayout.SplitMode == Orientation.Horizontal)
        goto label_5;
      else
        goto label_3;
label_2:
      this.OnMouseMove(startPoint);
      return;
label_3:
      this.xffa8345bf918658d = aboveLayout.Bounds.X + 25;
      do
      {
        this.xb646339c3b9e735a = belowLayout.Bounds.Right - 25;
        if (true)
        {
          if (true)
            this.x3fb8b43b602e016f = aboveLayout.WorkingSize.Width + belowLayout.WorkingSize.Width;
          else
            goto label_7;
        }
        else
          goto label_5;
      }
      while (false);
      goto label_2;
label_5:
      this.xffa8345bf918658d = aboveLayout.Bounds.Y + 25;
      this.xb646339c3b9e735a = belowLayout.Bounds.Bottom - 25;
      this.x3fb8b43b602e016f = aboveLayout.WorkingSize.Height + belowLayout.WorkingSize.Height;
      goto label_2;
    }

    public SplitLayoutSystem x07bf3386da210f81
    {
      get
      {
        return this.xd0bab8a0f8013a7b;
      }
    }

    public override void Commit()
    {
      base.Commit();
      while (this.x67ecc0d0e7c9a202 != null)
      {
        this.x67ecc0d0e7c9a202(this.xc13a8191724b6d55, this.x5aa50bbadb0a1e6c, this.x5c2440c931f8d932, this.x4afa341b2323a009);
        if (true)
          break;
      }
    }

    public override void OnMouseMove(System.Drawing.Point position)
    {
      Rectangle rectangle = Rectangle.Empty;
      if (this.xd0bab8a0f8013a7b.SplitMode == Orientation.Horizontal)
        goto label_17;
      else
        goto label_9;
label_6:
      this.xe5e4149f382149cc(new Rectangle(this.xd3311d815ca25f02.PointToScreen(rectangle.Location), rectangle.Size), false);
      if (false)
        goto label_2;
label_1:
      Cursor cursor;
      if (this.xd0bab8a0f8013a7b.SplitMode != Orientation.Horizontal)
      {
        cursor = Cursors.VSplit;
        goto label_3;
      }
label_2:
      cursor = Cursors.HSplit;
label_3:
      Cursor.Current = cursor;
      float num1;
      if ((uint) num1 >= 0U)
        return;
      if (((int) (uint) num1 & 0) == 0)
        goto label_11;
      else
        goto label_1;
label_7:
      rectangle.X = Math.Max(rectangle.X, this.xffa8345bf918658d);
      if (((int) (uint) num1 & 0) == 0)
      {
        rectangle.X = Math.Min(rectangle.X, this.xb646339c3b9e735a - 4);
        num1 = (float) (this.x5aa50bbadb0a1e6c.Bounds.Right - this.xc13a8191724b6d55.Bounds.Left - 4);
        this.x5c2440c931f8d932 = (float) (rectangle.X - this.xc13a8191724b6d55.Bounds.Left) / num1 * this.x3fb8b43b602e016f;
        this.x4afa341b2323a009 = this.x3fb8b43b602e016f - this.x5c2440c931f8d932;
        goto label_6;
      }
      else
        goto label_18;
label_9:
      float num2;
      if ((uint) num2 >= 0U)
      {
        rectangle = new Rectangle(position.X - 2, this.xd0bab8a0f8013a7b.Bounds.Y, 4, this.xd0bab8a0f8013a7b.Bounds.Height);
        if ((uint) num2 - (uint) num2 < 0U)
          return;
        goto label_7;
      }
      else
        goto label_14;
label_11:
      if (((int) (uint) num1 | int.MinValue) != 0)
      {
        if ((uint) num1 + (uint) num1 <= uint.MaxValue)
          goto label_6;
        else
          goto label_7;
      }
label_13:
      float num3 = (float) (this.x5aa50bbadb0a1e6c.Bounds.Bottom - this.xc13a8191724b6d55.Bounds.Top - 4);
label_14:
      this.x5c2440c931f8d932 = (float) (rectangle.Y - this.xc13a8191724b6d55.Bounds.Top) / num3 * this.x3fb8b43b602e016f;
      this.x4afa341b2323a009 = this.x3fb8b43b602e016f - this.x5c2440c931f8d932;
      goto label_11;
label_17:
      rectangle = new Rectangle(this.xd0bab8a0f8013a7b.Bounds.X, position.Y - 2, this.xd0bab8a0f8013a7b.Bounds.Width, 4);
      rectangle.Y = Math.Max(rectangle.Y, this.xffa8345bf918658d);
label_18:
      rectangle.Y = Math.Min(rectangle.Y, this.xb646339c3b9e735a - 4);
      goto label_13;
    }

    public delegate void SplittingManagerFinishedEventHandler(
      LayoutSystemBase aboveLayout,
      LayoutSystemBase belowLayout,
      float aboveSize,
      float belowSize);
  }
}
