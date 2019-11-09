// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x130e0425ae2d4496
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TD.SandDock
{
  internal class x130e0425ae2d4496
  {
    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateBitmap(
      int nWidth,
      int nHeight,
      int nPlanes,
      int nBitsPerPixel,
      short[] lpvBits);

    [DllImport("gdi32.dll")]
    private static extern IntPtr CreateBrushIndirect(x130e0425ae2d4496.x78c6fa48e5c2be9b lb);

    [DllImport("gdi32.dll")]
    private static extern bool DeleteObject(HandleRef hObject);

    [DllImport("user32.dll")]
    private static extern int ReleaseDC(HandleRef hWnd, HandleRef hDC);

    [DllImport("gdi32.dll")]
    private static extern IntPtr SelectObject(HandleRef hDC, HandleRef hObject);

    [DllImport("gdi32.dll")]
    private static extern bool PatBlt(
      HandleRef hdc,
      int left,
      int top,
      int width,
      int height,
      int rop);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr GetDC(HandleRef hWnd);

    public static void xda2defffc25953e0(
      Control xd9927c905e42526c,
      Rectangle xa688a683bf2cfced,
      bool xc346f54d9968657b,
      int x189455fe88a3b711)
    {
      x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Y, xa688a683bf2cfced.Width, 4));
      if (!xc346f54d9968657b)
        goto label_3;
      else
        goto label_6;
label_1:
      x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Bottom - 4, xa688a683bf2cfced.Width, 4));
      return;
label_3:
      x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Y + 4, 4, xa688a683bf2cfced.Height - 8));
      if ((uint) xc346f54d9968657b >= 0U)
      {
        x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.Right - 4, xa688a683bf2cfced.Y + 4, 4, xa688a683bf2cfced.Height - 8));
        goto label_1;
      }
      else
        goto label_1;
label_6:
      x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Y + 4, 4, xa688a683bf2cfced.Height - 4 - x189455fe88a3b711));
      x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.Right - 4, xa688a683bf2cfced.Y + 4, 4, xa688a683bf2cfced.Height - 4 - x189455fe88a3b711));
      x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X, xa688a683bf2cfced.Bottom - x189455fe88a3b711, 10, 4));
      x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X + 80, xa688a683bf2cfced.Bottom - x189455fe88a3b711, xa688a683bf2cfced.Width - 80, 4));
      do
      {
        x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X + 10, xa688a683bf2cfced.Bottom - 4, 70, 4));
        x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X + 10, xa688a683bf2cfced.Bottom - x189455fe88a3b711, 4, x189455fe88a3b711 - 4));
        if ((uint) xc346f54d9968657b >= 0U)
          x130e0425ae2d4496.xe5e0d1644c72aafd(xd9927c905e42526c, new Rectangle(xa688a683bf2cfced.X + 76, xa688a683bf2cfced.Bottom - x189455fe88a3b711, 4, x189455fe88a3b711 - 4));
        else
          goto label_1;
      }
      while ((uint) x189455fe88a3b711 - (uint) xc346f54d9968657b < 0U);
    }

    public static void xe5e0d1644c72aafd(Control xd9927c905e42526c, Rectangle xa688a683bf2cfced)
    {
      IntPtr handle1 = IntPtr.Zero;
      IntPtr num1;
      if ((uint) num1 <= uint.MaxValue)
        goto label_8;
label_2:
      IntPtr dc = x130e0425ae2d4496.GetDC(new HandleRef((object) xd9927c905e42526c, handle1));
      IntPtr handle2 = x130e0425ae2d4496.xf7ba50da2798338e();
      IntPtr handle3 = x130e0425ae2d4496.SelectObject(new HandleRef((object) xd9927c905e42526c, dc), new HandleRef((object) null, handle2));
      x130e0425ae2d4496.PatBlt(new HandleRef((object) xd9927c905e42526c, dc), xa688a683bf2cfced.X, xa688a683bf2cfced.Y, xa688a683bf2cfced.Width, xa688a683bf2cfced.Height, 5898313);
      x130e0425ae2d4496.SelectObject(new HandleRef((object) xd9927c905e42526c, dc), new HandleRef((object) null, handle3));
      x130e0425ae2d4496.DeleteObject(new HandleRef((object) null, handle2));
      if ((uint) handle2 - (uint) handle2 <= uint.MaxValue)
      {
        x130e0425ae2d4496.ReleaseDC(new HandleRef((object) xd9927c905e42526c, handle1), new HandleRef((object) null, dc));
        return;
      }
label_4:
      handle1 = xd9927c905e42526c.Handle;
      if (((int) (uint) handle3 & 0) != 0)
        return;
      goto label_2;
label_8:
      while (!(xa688a683bf2cfced == Rectangle.Empty))
      {
        if (false)
          goto label_5;
label_3:
        if (xd9927c905e42526c == null)
        {
          handle1 = IntPtr.Zero;
          goto label_2;
        }
        else
          goto label_4;
label_5:
        IntPtr num2;
        if ((uint) num2 >= 0U)
        {
          if (((int) (uint) num2 & 0) != 0)
          {
            if ((uint) handle1 - (uint) num2 < 0U)
              ;
          }
          else
            goto label_3;
        }
      }
    }

    private static IntPtr xf7ba50da2798338e()
    {
      short[] lpvBits = new short[8];
      int index = 0;
      x130e0425ae2d4496.x78c6fa48e5c2be9b lb;
      IntPtr bitmap;
      while (true)
      {
        if (index >= 8)
        {
          bitmap = x130e0425ae2d4496.CreateBitmap(8, 8, 1, 1, lpvBits);
          do
          {
            lb = new x130e0425ae2d4496.x78c6fa48e5c2be9b();
            lb.x1e592a1c6402f4a1 = ColorTranslator.ToWin32(Color.Black);
          }
          while (((int) (uint) bitmap & 0) != 0);
          if ((index | int.MinValue) != 0)
          {
            if (true)
              goto label_3;
label_1:
            lb.x7d12b02569342309 = bitmap;
            if (true)
              break;
label_3:
            lb.x7cedc2a7cb7ec88d = 3;
            IntPtr num;
            if ((uint) num - (uint) bitmap >= 0U)
              goto label_1;
          }
        }
        lpvBits[index] = (short) (21845 << (index & 1));
        ++index;
      }
      IntPtr brushIndirect = x130e0425ae2d4496.CreateBrushIndirect(lb);
      x130e0425ae2d4496.DeleteObject(new HandleRef((object) null, bitmap));
      return brushIndirect;
    }

    [StructLayout(LayoutKind.Sequential)]
    private class x78c6fa48e5c2be9b
    {
      public int x7cedc2a7cb7ec88d;
      public int x1e592a1c6402f4a1;
      public IntPtr x7d12b02569342309;
    }
  }
}
