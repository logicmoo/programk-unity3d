// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Rendering.xa811784015ed8842
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
  internal class xa811784015ed8842
  {
    internal static void x91433b5e99eb7cac(Graphics x41347a961b838962, Color x6c50a99faab7d741)
    {
      try
      {
        x41347a961b838962.Clear(x6c50a99faab7d741);
      }
      catch
      {
      }
    }

    public static void xf8aac789a7846004(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      Rectangle x0bd0d09521a6c8ef,
      Image xe058541ca798c059,
      System.Drawing.Size x95dac044246123ac,
      string xb41faee6912a2313,
      Font x26094932cf7a9139,
      Color x477e9d1180ece053,
      Color x3421b2dea6733873,
      Brush x4fe4e32776bbc2b0,
      Color xa1359fb73f86c7a4,
      Color xfca0e3085d5a7f42,
      Color x228f9881a1be0e5d,
      bool x9f93ebd2ca5601a2,
      int x6843d1739e949b3a,
      int xbd5e294caed74c4d,
      TextFormatFlags xae3b2752a89e7464,
      bool xb0f87b71823b1d4e)
    {
      if (xda73fcb97c77d998.Width <= 0)
        return;
      while (xda73fcb97c77d998.Height > 0)
      {
label_37:
        using (Pen pen = new Pen(xa1359fb73f86c7a4))
        {
          x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 2, xda73fcb97c77d998.Left + 1, xda73fcb97c77d998.Bottom - 2);
          if (true)
            goto label_40;
label_39:
          x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a - 1, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Left + x6843d1739e949b3a, xda73fcb97c77d998.Top + 1);
          x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top);
          x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top + 2);
          x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 2);
          if (((xb0f87b71823b1d4e ? 1 : 0) & 0) == 0)
            goto label_45;
label_40:
          x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + 1, xda73fcb97c77d998.Bottom - 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 2);
          x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 2, xda73fcb97c77d998.Top + 2);
          if ((x6843d1739e949b3a & 0) == 0)
            goto label_39;
        }
label_45:
        using (Pen pen = new Pen(xfca0e3085d5a7f42))
        {
          x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom - 2, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 3);
          x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 3, xda73fcb97c77d998.Left + x6843d1739e949b3a - 2, xda73fcb97c77d998.Top + 3);
          x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a - 1, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Left + x6843d1739e949b3a, xda73fcb97c77d998.Top + 2);
          x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Right - 4, xda73fcb97c77d998.Top + 1);
        }
        using (Pen pen = new Pen(x228f9881a1be0e5d))
        {
          x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Top + 1, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2);
          x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2, xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 2);
        }
        System.Drawing.Point[] points = new System.Drawing.Point[5];
        points[0] = new System.Drawing.Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom - 1);
        points[1] = new System.Drawing.Point(xda73fcb97c77d998.Left + x6843d1739e949b3a - 3, xda73fcb97c77d998.Top + 4);
        if ((uint) xb0f87b71823b1d4e >= 0U)
        {
          if ((uint) xbd5e294caed74c4d - (uint) xbd5e294caed74c4d < 0U)
            ;
          points[2] = new System.Drawing.Point(xda73fcb97c77d998.Left + x6843d1739e949b3a + 1, xda73fcb97c77d998.Top + 2);
          if (((xb0f87b71823b1d4e ? 1 : 0) | -1) == 0)
            break;
label_27:
          points[3] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top + 2);
          do
          {
            points[4] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 1);
            using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(xda73fcb97c77d998, x477e9d1180ece053, x3421b2dea6733873, LinearGradientMode.Vertical))
              x41347a961b838962.FillPolygon((Brush) linearGradientBrush, points);
            if (!x9f93ebd2ca5601a2)
            {
              if ((uint) x9f93ebd2ca5601a2 >= 0U)
                goto label_12;
            }
            else
              goto label_22;
          }
          while (false);
          goto label_27;
label_12:
          xda73fcb97c77d998 = x0bd0d09521a6c8ef;
          xda73fcb97c77d998.X += xbd5e294caed74c4d;
          xda73fcb97c77d998.Width -= xbd5e294caed74c4d;
          while (xe058541ca798c059 != null)
          {
            x41347a961b838962.DrawImage(xe058541ca798c059, xda73fcb97c77d998.X + 4, xda73fcb97c77d998.Y + 2, x95dac044246123ac.Width, x95dac044246123ac.Height);
            xda73fcb97c77d998.X += x95dac044246123ac.Width + 4;
            if ((xbd5e294caed74c4d | int.MinValue) != 0)
            {
              xda73fcb97c77d998.Width -= x95dac044246123ac.Width + 4;
              if (((x9f93ebd2ca5601a2 ? 1 : 0) & 0) == 0)
                goto label_6;
            }
            else
              goto label_6;
          }
          goto label_10;
label_1:
          do
          {
            while (xb0f87b71823b1d4e)
            {
              Rectangle rectangle = xda73fcb97c77d998;
              if (((xb0f87b71823b1d4e ? 1 : 0) | 15) != 0)
              {
                rectangle.Inflate(-2, -2);
                rectangle.Height += 2;
                ++rectangle.X;
                --rectangle.Width;
                ControlPaint.DrawFocusRectangle(x41347a961b838962, rectangle);
                if (((x9f93ebd2ca5601a2 ? 1 : 0) | 15) != 0)
                  return;
              }
              else
                goto label_12;
            }
          }
          while ((uint) x6843d1739e949b3a + (uint) xbd5e294caed74c4d > uint.MaxValue);
          break;
label_6:
          if (xda73fcb97c77d998.Width > 8)
          {
            xae3b2752a89e7464 |= TextFormatFlags.HorizontalCenter;
            xae3b2752a89e7464 &= ~TextFormatFlags.Default;
            if (false)
              goto label_37;
            else
              goto label_11;
          }
          else
            goto label_1;
label_10:
          if (true)
            goto label_6;
label_11:
          if ((uint) x9f93ebd2ca5601a2 - (uint) xb0f87b71823b1d4e >= 0U)
          {
            TextRenderer.DrawText((IDeviceContext) x41347a961b838962, xb41faee6912a2313, x26094932cf7a9139, xda73fcb97c77d998, SystemColors.ControlText, xae3b2752a89e7464);
            goto label_1;
          }
          else
            goto label_1;
label_22:
          using (Pen pen = new Pen(x3421b2dea6733873))
          {
            x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1);
            goto label_12;
          }
        }
      }
    }

    public static void x272eca3f5ebfa9fc(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      Image xe058541ca798c059,
      System.Drawing.Size x95dac044246123ac,
      string xb41faee6912a2313,
      Font x26094932cf7a9139,
      Color x477e9d1180ece053,
      Color x3421b2dea6733873,
      Color x93532ca0ace0c1ae,
      Color xa1359fb73f86c7a4,
      DrawItemState x01b557925841ae51,
      TextFormatFlags xae3b2752a89e7464)
    {
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(xda73fcb97c77d998, x477e9d1180ece053, x3421b2dea6733873, LinearGradientMode.Vertical))
        xa811784015ed8842.x272eca3f5ebfa9fc(x41347a961b838962, xda73fcb97c77d998, xe058541ca798c059, x95dac044246123ac, xb41faee6912a2313, x26094932cf7a9139, (Brush) linearGradientBrush, x93532ca0ace0c1ae, xa1359fb73f86c7a4, x01b557925841ae51, xae3b2752a89e7464);
    }

    public static void x272eca3f5ebfa9fc(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      Image xe058541ca798c059,
      System.Drawing.Size x95dac044246123ac,
      string xb41faee6912a2313,
      Font x26094932cf7a9139,
      Brush x6f967439eb9e4ffb,
      Color x93532ca0ace0c1ae,
      Color xa1359fb73f86c7a4,
      DrawItemState x01b557925841ae51,
      TextFormatFlags xae3b2752a89e7464)
    {
      if ((x01b557925841ae51 & DrawItemState.Selected) != DrawItemState.Selected)
        goto label_15;
      else
        goto label_18;
label_1:
      TextRenderer.DrawText((IDeviceContext) x41347a961b838962, xb41faee6912a2313, x26094932cf7a9139, xda73fcb97c77d998, x93532ca0ace0c1ae, xae3b2752a89e7464);
      if (true)
      {
        if (true)
          return;
        goto label_6;
      }
label_5:
      xae3b2752a89e7464 &= ~TextFormatFlags.HorizontalCenter;
      if (true)
        goto label_1;
label_6:
      xda73fcb97c77d998.X += x95dac044246123ac.Width + 4;
      xda73fcb97c77d998.Width -= x95dac044246123ac.Width + 4;
label_7:
      xda73fcb97c77d998.Width -= 2;
      if (xda73fcb97c77d998.Width <= 8)
        return;
      xda73fcb97c77d998.X += 3;
      if (true)
      {
        --xda73fcb97c77d998.Y;
        xae3b2752a89e7464 = xae3b2752a89e7464;
        goto label_5;
      }
      else
        goto label_10;
label_8:
      x41347a961b838962.DrawImage(xe058541ca798c059, new Rectangle(xda73fcb97c77d998.X + 3, xda73fcb97c77d998.Y + 2, x95dac044246123ac.Width, x95dac044246123ac.Height));
      if (true)
        goto label_6;
      else
        goto label_18;
label_10:
      System.Drawing.Point[] points;
      using (Pen pen = new Pen(xa1359fb73f86c7a4))
        x41347a961b838962.DrawLines(pen, points);
label_15:
      if (xda73fcb97c77d998.Width < x95dac044246123ac.Width + 8)
        goto label_7;
      else
        goto label_8;
label_18:
      Rectangle rect = xda73fcb97c77d998;
      rect.Inflate(-1, 0);
      if (true)
      {
        --rect.Height;
        x41347a961b838962.FillRectangle(x6f967439eb9e4ffb, rect);
        points = new System.Drawing.Point[6];
        if (true)
        {
          points[0] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top);
          points[1] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 3);
          points[2] = new System.Drawing.Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom - 1);
          points[3] = new System.Drawing.Point(xda73fcb97c77d998.Right - 3, xda73fcb97c77d998.Bottom - 1);
          if (true)
          {
            points[4] = new System.Drawing.Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 3);
            points[5] = new System.Drawing.Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
            goto label_10;
          }
          else
            goto label_8;
        }
        else
          goto label_1;
      }
      else
        goto label_8;
    }

    public static void x36c79cea8e98cf3c(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      DockSide xf33779c598cac695,
      Image xe058541ca798c059,
      string xb41faee6912a2313,
      Font x26094932cf7a9139,
      Brush x4fe4e32776bbc2b0,
      Color xa1359fb73f86c7a4,
      bool x96c7dce50f0f3286)
    {
      xa811784015ed8842.x36c79cea8e98cf3c(x41347a961b838962, xda73fcb97c77d998, xf33779c598cac695, xe058541ca798c059, xb41faee6912a2313, x26094932cf7a9139, (Brush) null, x4fe4e32776bbc2b0, xa1359fb73f86c7a4, x96c7dce50f0f3286);
    }

    public static void x36c79cea8e98cf3c(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      DockSide xf33779c598cac695,
      Image xe058541ca798c059,
      string xb41faee6912a2313,
      Font x26094932cf7a9139,
      Brush x6f967439eb9e4ffb,
      Brush x4fe4e32776bbc2b0,
      Color xa1359fb73f86c7a4,
      bool x96c7dce50f0f3286)
    {
      bool flag = false;
label_36:
      System.Drawing.Point[] points = new System.Drawing.Point[6];
      int num;
      switch (xf33779c598cac695)
      {
        case DockSide.Top:
          points[0] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top);
          if ((uint) x96c7dce50f0f3286 <= uint.MaxValue)
          {
            points[1] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Top);
            points[2] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Bottom - 2);
            points[3] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom);
            goto label_28;
          }
          else
            goto default;
        case DockSide.Bottom:
          points[0] = new System.Drawing.Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Top);
          points[1] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top);
          goto label_26;
        case DockSide.Left:
          points[0] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top);
          points[1] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Top);
          points[2] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Top + 2);
          points[3] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Bottom - 2);
          points[4] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom);
          points[5] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom);
          if ((uint) num - (uint) x96c7dce50f0f3286 >= 0U)
          {
            if ((uint) flag + (uint) x96c7dce50f0f3286 >= 0U)
            {
              flag = true;
              goto default;
            }
            else
              goto label_26;
          }
          else
            goto label_8;
        case DockSide.Right:
          points[0] = new System.Drawing.Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Top);
          if (true)
          {
            points[1] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Top);
            points[2] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Bottom);
            if (true)
            {
              points[3] = new System.Drawing.Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom);
              points[4] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 2);
              points[5] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top + 2);
              flag = true;
              goto default;
            }
            else
              goto default;
          }
          else
            goto label_40;
        default:
label_18:
          if (x6f967439eb9e4ffb != null)
            x41347a961b838962.FillPolygon(x6f967439eb9e4ffb, points);
          do
          {
            using (Pen pen = new Pen(xa1359fb73f86c7a4))
              x41347a961b838962.DrawPolygon(pen, points);
            xda73fcb97c77d998.Inflate(-2, -2);
            if ((uint) x96c7dce50f0f3286 - (uint) x96c7dce50f0f3286 < 0U)
              goto label_17;
          }
          while ((uint) num > uint.MaxValue);
          if (flag)
            goto label_16;
          else
            goto label_12;
label_9:
          x41347a961b838962.DrawImage(xe058541ca798c059, new Rectangle(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xe058541ca798c059.Width, xe058541ca798c059.Height));
          break;
label_12:
          if ((uint) x96c7dce50f0f3286 - (uint) num >= 0U)
          {
            xda73fcb97c77d998.Offset(1, 0);
            goto label_9;
          }
          else
            goto label_28;
label_16:
          xda73fcb97c77d998.Offset(0, 1);
          goto label_9;
      }
label_3:
      if (xb41faee6912a2313.Length == 0)
      {
        if ((uint) flag >= 0U)
          return;
      }
      else
        goto label_10;
label_6:
      xda73fcb97c77d998.Offset(0, num);
      if (((x96c7dce50f0f3286 ? 1 : 0) | -2) != 0)
        x41347a961b838962.DrawString(xb41faee6912a2313, x26094932cf7a9139, x4fe4e32776bbc2b0, (RectangleF) xda73fcb97c77d998, EverettRenderer.xc351c68a86733972);
      else
        goto label_18;
label_8:
      if ((uint) num + (uint) flag >= 0U)
        return;
label_10:
      num = !x96c7dce50f0f3286 ? 23 : 21;
      if (!flag)
      {
        xda73fcb97c77d998.Offset(num, 0);
        if ((num | (int) byte.MaxValue) != 0)
          goto label_40;
        else
          goto label_36;
      }
      else
        goto label_6;
label_17:
      points[5] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Top + 2);
      goto label_18;
label_26:
      points[2] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Top + 2);
      points[3] = new System.Drawing.Point(xda73fcb97c77d998.Right, xda73fcb97c77d998.Bottom);
      points[4] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom);
      goto label_17;
label_28:
      points[4] = new System.Drawing.Point(xda73fcb97c77d998.Left + 2, xda73fcb97c77d998.Bottom);
      points[5] = new System.Drawing.Point(xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 2);
      goto label_18;
label_40:
      if (false)
        return;
      if ((uint) num >= 0U)
        x41347a961b838962.DrawString(xb41faee6912a2313, x26094932cf7a9139, x4fe4e32776bbc2b0, (RectangleF) xda73fcb97c77d998, EverettRenderer.x27e1c82c97265861);
      else
        goto label_3;
    }
  }
}
