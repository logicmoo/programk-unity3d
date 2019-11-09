// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x9b2777bb8e78938b
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.Drawing;

namespace TD.SandDock
{
  internal class x9b2777bb8e78938b
  {
    private x9b2777bb8e78938b()
    {
    }

    public static void xeac2e7eb44dff86e(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      Pen x90279591611601bc)
    {
      int num1 = xda73fcb97c77d998.Width / 4;
      int num2;
      do
      {
        num2 = 1;
        while (num2 <= num1)
        {
          int num3 = (num1 - num2) * 2;
          int x1 = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2 - (num1 - num2);
          int num4 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2 + (num2 - 1);
          x41347a961b838962.DrawLine(x90279591611601bc, x1, num4, x1 + num3 + 1, num4);
          if ((num1 | 1) != 0)
            ++num2;
        }
      }
      while ((uint) num2 + (uint) num2 > uint.MaxValue);
    }

    public static void xd70a4c1a2378c84e(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      Color x6c50a99faab7d741,
      bool x2fef7d841879a711)
    {
      int num1 = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2;
      if (true)
        goto label_3;
label_1:
      System.Drawing.Point[] x6fa2570084b2ad39;
      int num2;
      x6fa2570084b2ad39[1] = new System.Drawing.Point(num1 - 2, num2 - 1);
label_2:
      x6fa2570084b2ad39[2] = new System.Drawing.Point(num1 + 2, num2 + 3);
      x9b2777bb8e78938b.x31bdb6d312240ef9(x41347a961b838962, x6fa2570084b2ad39, x6c50a99faab7d741, x2fef7d841879a711);
      if ((uint) x2fef7d841879a711 - (uint) num1 <= uint.MaxValue)
        return;
label_3:
      num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
      x6fa2570084b2ad39 = new System.Drawing.Point[3];
      if ((uint) num2 >= 0U)
      {
        x6fa2570084b2ad39[0] = new System.Drawing.Point(num1 + 2, num2 - 5);
        goto label_1;
      }
      else
        goto label_2;
    }

    public static void x793dc1a7cf4113f9(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      Color x6c50a99faab7d741,
      bool x2fef7d841879a711)
    {
      int num1 = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2;
      int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
      do
      {
        System.Drawing.Point[] x6fa2570084b2ad39 = new System.Drawing.Point[3];
        if ((uint) x2fef7d841879a711 <= uint.MaxValue)
        {
          x6fa2570084b2ad39[0] = new System.Drawing.Point(num1 - 2, num2 - 5);
          x6fa2570084b2ad39[1] = new System.Drawing.Point(num1 + 2, num2 - 1);
          x6fa2570084b2ad39[2] = new System.Drawing.Point(num1 - 2, num2 + 3);
          x9b2777bb8e78938b.x31bdb6d312240ef9(x41347a961b838962, x6fa2570084b2ad39, x6c50a99faab7d741, x2fef7d841879a711);
        }
        else
          goto label_2;
      }
      while (false);
      return;
label_2:;
    }

    private static void x31bdb6d312240ef9(
      Graphics x41347a961b838962,
      System.Drawing.Point[] x6fa2570084b2ad39,
      Color x6c50a99faab7d741,
      bool x2fef7d841879a711)
    {
      if (x2fef7d841879a711)
      {
        using (SolidBrush solidBrush = new SolidBrush(x6c50a99faab7d741))
          x41347a961b838962.FillPolygon((Brush) solidBrush, x6fa2570084b2ad39);
      }
      else
      {
        using (Pen pen = new Pen(x6c50a99faab7d741))
          x41347a961b838962.DrawPolygon(pen, x6fa2570084b2ad39);
      }
    }

    public static void x1477b5a75c8a8132(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      Pen x90279591611601bc,
      bool x533813ae5953a526)
    {
      int num1 = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2;
label_9:
      int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
label_4:
      while (!x533813ae5953a526)
      {
label_5:
        x41347a961b838962.DrawLine(x90279591611601bc, num1 - 3, num2 + 2, num1 + 3, num2 + 2);
        do
        {
          x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 - 3, num1 - 2, num2 + 2);
          x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 - 3, num1 + 2, num2 - 3);
          x41347a961b838962.DrawLine(x90279591611601bc, num1 + 1, num2 - 3, num1 + 1, num2 + 2);
          if ((uint) x533813ae5953a526 - (uint) x533813ae5953a526 <= uint.MaxValue)
          {
            x41347a961b838962.DrawLine(x90279591611601bc, num1 + 2, num2 - 3, num1 + 2, num2 + 2);
            x41347a961b838962.DrawLine(x90279591611601bc, num1, num2 + 2, num1, num2 + 5);
            if ((uint) num1 > uint.MaxValue)
              goto label_5;
          }
          else
            goto label_4;
        }
        while ((uint) x533813ae5953a526 < 0U);
        if ((uint) num1 + (uint) num1 >= 0U)
          return;
        if ((uint) num1 >= 0U)
          goto label_9;
        else
          goto label_8;
      }
      goto label_10;
label_8:
      x41347a961b838962.DrawLine(x90279591611601bc, num1 + 4, num2 - 2, num1 + 4, num2 + 2);
      return;
label_10:
      x41347a961b838962.DrawLine(x90279591611601bc, num1 - 5, num2, num1 - 2, num2);
      x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 - 3, num1 - 2, num2 + 3);
      x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 - 2, num1 + 4, num2 - 2);
      x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 + 1, num1 + 4, num2 + 1);
      x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 + 2, num1 + 4, num2 + 2);
      goto label_8;
    }

    public static void xb176aa01ddab9f3e(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      Pen x90279591611601bc)
    {
      int num1 = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2 - 1;
      int num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
      x41347a961b838962.DrawLine(x90279591611601bc, num1 - 3, num2 - 4, num1 + 3, num2 + 2);
      if ((num2 & 0) != 0)
        ;
      x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 - 4, num1 + 4, num2 + 2);
      x41347a961b838962.DrawLine(x90279591611601bc, num1 - 3, num2 + 2, num1 + 3, num2 - 4);
      x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 + 2, num1 + 4, num2 - 4);
    }

    public static void x26f0f0028ef01fa5(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      Pen x90279591611601bc)
    {
      int num1 = xda73fcb97c77d998.Left + xda73fcb97c77d998.Width / 2 - 1;
      int num2;
      do
      {
        num2 = xda73fcb97c77d998.Top + xda73fcb97c77d998.Height / 2;
        x41347a961b838962.DrawLine(x90279591611601bc, num1 - 3, num2 - 3, num1 + 4, num2 + 4);
        x41347a961b838962.DrawLine(x90279591611601bc, num1 - 2, num2 - 3, num1 + 4, num2 + 3);
        x41347a961b838962.DrawLine(x90279591611601bc, num1 - 3, num2 - 2, num1 + 3, num2 + 4);
      }
      while ((uint) num2 < 0U);
      x41347a961b838962.DrawLine(x90279591611601bc, num1 + 4, num2 - 3, num1 - 3, num2 + 4);
      x41347a961b838962.DrawLine(x90279591611601bc, num1 + 3, num2 - 3, num1 - 3, num2 + 3);
      x41347a961b838962.DrawLine(x90279591611601bc, num1 + 4, num2 - 2, num1 - 2, num2 + 4);
    }
  }
}
