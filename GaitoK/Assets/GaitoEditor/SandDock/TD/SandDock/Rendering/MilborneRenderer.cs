// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Rendering.MilborneRenderer
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
  [TypeConverter(typeof (xdc4dfd9427bbb983))]
  public class MilborneRenderer : ITabControlRenderer
  {
    private Color xd9caa88fffee2844 = Color.FromArgb(124, 124, 148);
    private Color x62b1822fa10e8658 = SystemColors.ControlLight;
    private Color x68e7227781326461 = Color.FromArgb(117, 116, 147);
    private Color x31d8d8063d8f3c74 = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    private Color x6cefc7bb40cf5d76 = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    private Color x05d7ee48911d8dba = Color.FromArgb(252, 252, 254);
    private Color x51e4f0f96f7fc653 = Color.FromArgb(244, 243, 248);
    private Color xb9bbdee8e645fa7b = Color.FromArgb(216, 216, 228);
    private Color xd96ec9f38c2f034d = Color.FromArgb(243, 242, 247);
    private Color x1b76e612db274a07 = Color.FromArgb((int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue);
    private double x567d5545e28c9c83 = 0.05;
    private TextFormatFlags xae3b2752a89e7464;
    private double x6093764f4f59f8ca;

    public override string ToString()
    {
      return "Milborne";
    }

    public double PageColorBlend
    {
      get
      {
        return this.x6093764f4f59f8ca;
      }
      set
      {
        if (value < 0.0 || value > 1.0)
          throw new ArgumentException("Value must lie between 0 and 1.");
        if (false)
          return;
        this.x6093764f4f59f8ca = value;
      }
    }

    public double TabColorBlend
    {
      get
      {
        return this.x567d5545e28c9c83;
      }
      set
      {
        if (value < 0.0 || value > 1.0)
          throw new ArgumentException("Value must lie between 0 and 1.");
        this.x567d5545e28c9c83 = value;
      }
    }

    public virtual bool ShouldDrawControlBorder
    {
      get
      {
        return false;
      }
    }

    public virtual void DrawFakeTabControlBackgroundExtension(
      Graphics graphics,
      Rectangle bounds,
      Color backColor)
    {
      using (SolidBrush solidBrush = new SolidBrush(this.xb9bbdee8e645fa7b))
        graphics.FillRectangle((Brush) solidBrush, bounds);
      using (Pen pen = new Pen(this.x68e7227781326461))
        graphics.DrawLine(pen, bounds.Right - 1, bounds.Y, bounds.Right - 1, bounds.Bottom - 1);
    }

    public void DrawTabControlButton(
      Graphics graphics,
      Rectangle bounds,
      SandDockButtonType buttonType,
      DrawItemState state)
    {
      if ((state & DrawItemState.Selected) == DrawItemState.Selected)
        bounds.Offset(1, 1);
      SandDockButtonType sandDockButtonType = buttonType;
      if (false)
        ;
      switch (sandDockButtonType)
      {
        case SandDockButtonType.ScrollLeft:
          x9b2777bb8e78938b.xd70a4c1a2378c84e(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
          break;
        case SandDockButtonType.ScrollRight:
          x9b2777bb8e78938b.x793dc1a7cf4113f9(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
          break;
      }
    }

    public System.Drawing.Size MeasureTabControlTab(
      Graphics graphics,
      Image image,
      string text,
      Font font,
      DrawItemState state)
    {
      int width;
      using (new Font(font, FontStyle.Bold))
        width = TextRenderer.MeasureText((IDeviceContext) graphics, text, font, new System.Drawing.Size(int.MaxValue, int.MaxValue), this.xae3b2752a89e7464).Width;
      int num = width + 24;
      if (image != null)
        num += image.Width + 4;
      return new System.Drawing.Size(num + this.TabControlTabExtra, 0);
    }

    public void FinishRenderSession()
    {
    }

    public void StartRenderSession(HotkeyPrefix tabHotKeys)
    {
      this.xae3b2752a89e7464 = TextFormatFlags.EndEllipsis | TextFormatFlags.HorizontalCenter | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.NoPadding;
      if (true)
        goto label_4;
label_1:
      if (true)
        return;
label_3:
      if (tabHotKeys != HotkeyPrefix.Hide)
        return;
      this.xae3b2752a89e7464 |= TextFormatFlags.HidePrefix;
      goto label_1;
label_4:
      if (tabHotKeys != HotkeyPrefix.None)
      {
        if (true)
          goto label_3;
        else
          goto label_1;
      }
      else
        this.xae3b2752a89e7464 |= TextFormatFlags.NoPrefix;
    }

    public int TabControlTabStripHeight
    {
      get
      {
        return Control.DefaultFont.Height + 8;
      }
    }

    public int TabControlTabExtra
    {
      get
      {
        return this.TabControlTabStripHeight - 7;
      }
    }

    public virtual System.Drawing.Size TabControlPadding
    {
      get
      {
        return new System.Drawing.Size(4, 4);
      }
    }

    public void DrawTabControlTabStripBackground(
      Graphics graphics,
      Rectangle bounds,
      Color backColor)
    {
      if (backColor != Color.Transparent)
        xa811784015ed8842.x91433b5e99eb7cac(graphics, backColor);
      using (Pen pen = new Pen(this.x68e7227781326461))
        graphics.DrawLine(pen, bounds.X, bounds.Bottom - 1, bounds.Right - 2, bounds.Bottom - 1);
    }

    public int TabControlTabHeight
    {
      get
      {
        return this.TabControlTabStripHeight;
      }
    }

    public bool ShouldDrawTabControlBackground
    {
      get
      {
        return true;
      }
    }

    private System.Drawing.Point[] x23c99552401d90a0(
      Rectangle xda73fcb97c77d998,
      bool xb35f79a43e184314)
    {
      int num = Math.Min(xda73fcb97c77d998.Width, xda73fcb97c77d998.Height);
      System.Drawing.Point[] pointArray1;
      System.Drawing.Point[] pointArray2;
      do
      {
        if ((uint) xb35f79a43e184314 >= 0U && !xb35f79a43e184314)
        {
          if ((uint) xb35f79a43e184314 <= uint.MaxValue)
            goto label_8;
        }
        else
          goto label_10;
label_7:
        pointArray2[2] = new System.Drawing.Point(xda73fcb97c77d998.X + num + 1, xda73fcb97c77d998.Y + 1);
        if ((uint) num + (uint) num <= uint.MaxValue)
          goto label_4;
label_8:
        if ((num & 0) != 0 || (uint) num >= 0U)
        {
          pointArray1 = new System.Drawing.Point[6];
          do
          {
            pointArray1[0] = new System.Drawing.Point(xda73fcb97c77d998.X, xda73fcb97c77d998.Bottom - 1);
          }
          while (false);
          pointArray1[1] = new System.Drawing.Point(xda73fcb97c77d998.X + num - 4, xda73fcb97c77d998.Y + 3);
          pointArray1[2] = new System.Drawing.Point(xda73fcb97c77d998.X + num + 1, xda73fcb97c77d998.Y);
          pointArray1[3] = new System.Drawing.Point(xda73fcb97c77d998.Right - 4, xda73fcb97c77d998.Y);
          pointArray1[4] = new System.Drawing.Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Y + 3);
          pointArray1[5] = new System.Drawing.Point(xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1);
          continue;
        }
        break;
label_10:
        pointArray2 = new System.Drawing.Point[6];
        pointArray2[0] = new System.Drawing.Point(xda73fcb97c77d998.X + 2, xda73fcb97c77d998.Bottom - 2);
        pointArray2[1] = new System.Drawing.Point(xda73fcb97c77d998.X + num - 3, xda73fcb97c77d998.Y + 3);
        if ((uint) xb35f79a43e184314 > uint.MaxValue)
          goto label_5;
        else
          goto label_7;
      }
      while (false);
      goto label_11;
label_4:
      pointArray2[3] = new System.Drawing.Point(xda73fcb97c77d998.Right - 4, xda73fcb97c77d998.Y + 1);
      pointArray2[4] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Y + 3);
label_5:
      pointArray2[5] = new System.Drawing.Point(xda73fcb97c77d998.Right - 2, xda73fcb97c77d998.Bottom - 2);
      return pointArray2;
label_11:
      return pointArray1;
    }

    public void DrawTabControlTab(
      Graphics graphics,
      Rectangle bounds,
      Image image,
      string text,
      Font font,
      Color backColor,
      Color foreColor,
      DrawItemState state,
      bool drawSeparator)
    {
      int height = bounds.Height;
      if (((drawSeparator ? 1 : 0) & 0) != 0)
        goto label_12;
      else
        goto label_62;
label_11:
      bounds.Inflate(-2, 0);
label_12:
      bool flag1;
      if ((uint) flag1 >= 0U)
        goto label_9;
      else
        goto label_13;
label_8:
      if (bounds.Width <= 4)
        return;
      if (flag1)
      {
        using (Font font1 = new Font(font, FontStyle.Bold))
        {
          TextRenderer.DrawText((IDeviceContext) graphics, text, font1, bounds, foreColor, this.xae3b2752a89e7464);
          return;
        }
      }
      else
      {
        TextRenderer.DrawText((IDeviceContext) graphics, text, font, bounds, foreColor, this.xae3b2752a89e7464);
        return;
      }
label_9:
      if (image == null)
        goto label_8;
label_10:
      Rectangle destRect = new Rectangle(bounds.X, bounds.Y + bounds.Height / 2 - image.Height / 2, image.Width, image.Height);
      graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel);
      bounds.X += image.Width + 4;
      bounds.Width -= image.Width + 4;
      goto label_8;
label_13:
      if ((uint) drawSeparator + (uint) flag1 <= uint.MaxValue)
      {
        if ((uint) drawSeparator - (uint) flag1 <= uint.MaxValue)
          goto label_10;
        else
          goto label_47;
      }
      else
        goto label_40;
label_19:
      Color color1 = this.x62b1822fa10e8658;
label_20:
      using (Pen pen1 = new Pen(color1))
      {
        graphics.DrawLines(pen1, this.x23c99552401d90a0(bounds, true));
        while (!flag1)
        {
          Color color2 = RendererBase.InterpolateColors(this.x31d8d8063d8f3c74, this.x68e7227781326461, 0.5f);
          if (((flag1 ? 1 : 0) | int.MinValue) != 0)
          {
            using (Pen pen2 = new Pen(color2))
            {
              graphics.DrawLines(pen2, new System.Drawing.Point[3]
              {
                new System.Drawing.Point(bounds.Right - 4, bounds.Y + 1),
                new System.Drawing.Point(bounds.Right - 2, bounds.Y + 3),
                new System.Drawing.Point(bounds.Right - 2, bounds.Bottom - 2)
              });
              break;
            }
          }
        }
      }
      Color color3;
      if (flag1)
      {
        using (Pen pen = new Pen(color3))
          graphics.DrawLine(pen, bounds.X + 1, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
      }
      SmoothingMode smoothingMode;
      graphics.SmoothingMode = smoothingMode;
      if ((state & DrawItemState.Checked) == DrawItemState.Checked)
        goto label_17;
label_15:
      bounds.X += this.TabControlTabExtra + 6;
      bounds.Width -= this.TabControlTabExtra + 6;
      goto label_11;
label_17:
      Rectangle rectangle = bounds;
      if (true)
      {
        rectangle.X += this.TabControlTabExtra;
        rectangle.Width -= this.TabControlTabExtra;
        rectangle.Inflate(-4, -3);
        ++rectangle.X;
        ++rectangle.Height;
        if ((uint) flag1 >= 0U)
        {
          ControlPaint.DrawFocusRectangle(graphics, rectangle);
          goto label_15;
        }
        else
          goto label_12;
      }
      else if (((flag1 ? 1 : 0) & 0) == 0)
        goto label_19;
label_39:
      if (flag1)
        goto label_19;
label_40:
      color1 = this.x31d8d8063d8f3c74;
      goto label_20;
label_42:
      using (Pen pen = new Pen(!flag1 ? this.x68e7227781326461 : this.xd9caa88fffee2844))
      {
        graphics.DrawLines(pen, this.x23c99552401d90a0(bounds, false));
        goto label_39;
      }
label_47:
      Color color1_1;
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, color1_1, color3, LinearGradientMode.Vertical))
        graphics.FillPolygon((Brush) linearGradientBrush, this.x23c99552401d90a0(bounds, false));
      smoothingMode = graphics.SmoothingMode;
      graphics.SmoothingMode = SmoothingMode.AntiAlias;
      if ((uint) flag1 - (uint) drawSeparator <= uint.MaxValue)
        goto label_42;
label_58:
      Color color4;
      if (!flag1)
      {
        color4 = this.x51e4f0f96f7fc653;
        goto label_60;
      }
label_59:
      color4 = this.x6cefc7bb40cf5d76;
label_60:
      color1_1 = color4;
      color3 = (uint) drawSeparator - (uint) drawSeparator < 0U || !flag1 ? this.xb9bbdee8e645fa7b : this.x05d7ee48911d8dba;
      if (this.TabColorBlend <= 0.0)
      {
        if (false)
          return;
        goto label_47;
      }
      else
      {
        color1_1 = RendererBase.InterpolateColors(color1_1, backColor, (float) this.TabColorBlend);
        color3 = RendererBase.InterpolateColors(color3, backColor, (float) this.TabColorBlend);
        goto label_47;
      }
label_62:
      bool flag2;
      if ((uint) flag2 - (uint) drawSeparator >= 0U)
      {
        flag1 = (state & DrawItemState.Selected) == DrawItemState.Selected;
        if (false)
        {
          if (true)
            goto label_59;
          else
            goto label_58;
        }
        else if (false)
          goto label_11;
        else
          goto label_58;
      }
      else
        goto label_42;
    }

    public void DrawTabControlBackground(
      Graphics graphics,
      Rectangle bounds,
      Color backColor,
      bool client)
    {
      if (bounds.Width <= 0)
        return;
      if (((client ? 1 : 0) | -1) != 0)
        goto label_54;
label_12:
      Rectangle rect1;
      Color color1;
      Color color2;
      if (rect1.Height > 0)
      {
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rect1, color2, color1, LinearGradientMode.Vertical))
          graphics.FillRectangle((Brush) linearGradientBrush, rect1);
      }
label_13:
      Rectangle rect2 = bounds;
      rect2.Y = rect2.Bottom - this.TabControlPadding.Height;
      rect2.Height = this.TabControlPadding.Height;
label_14:
      using (SolidBrush solidBrush = new SolidBrush(color1))
        graphics.FillRectangle((Brush) solidBrush, rect2);
      using (Pen pen = new Pen(this.x68e7227781326461))
      {
        graphics.DrawLine(pen, bounds.X, bounds.Y, bounds.X, bounds.Bottom - 2);
        graphics.DrawLine(pen, bounds.X, bounds.Bottom - 2, bounds.Right - 2, bounds.Bottom - 2);
        graphics.DrawLine(pen, bounds.Right - 2, bounds.Bottom - 2, bounds.Right - 2, bounds.Y);
      }
      using (Pen pen = new Pen(RendererBase.InterpolateColors(this.x68e7227781326461, SystemColors.Control, 0.8f)))
      {
        graphics.DrawLine(pen, bounds.X, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
        graphics.DrawLine(pen, bounds.Right - 1, bounds.Bottom - 1, bounds.Right - 1, bounds.Y);
        return;
      }
label_54:
      while (bounds.Height > 0)
      {
label_53:
        color2 = Color.FromArgb(252, 252, 254);
        color1 = Color.FromArgb(244, 243, 238);
        if (this.PageColorBlend > 0.0)
          goto label_50;
label_42:
        while (!client)
        {
          if ((uint) client - (uint) client >= 0U)
          {
label_37:
            if (false)
              goto label_38;
label_32:
            Rectangle rect3 = bounds;
            if ((uint) client + (uint) client >= 0U)
            {
              if ((uint) client >= 0U)
              {
                rect3.Height = this.TabControlPadding.Height;
                if (true)
                {
                  using (SolidBrush solidBrush = new SolidBrush(color2))
                    graphics.FillRectangle((Brush) solidBrush, rect3);
                  rect1 = bounds;
                }
                if (true)
                {
                  rect1.Y += this.TabControlPadding.Height;
                  rect1.Height -= this.TabControlPadding.Height * 2;
                }
                if (true)
                  goto label_40;
                else
                  goto label_37;
              }
              else
                goto label_50;
            }
            else
              goto label_14;
label_38:
            if ((uint) client - (uint) client <= uint.MaxValue)
            {
              if (true)
                goto label_32;
            }
            else
              continue;
label_40:
            if (true)
            {
              if (rect1.Width > 0)
                goto label_12;
              else
                goto label_13;
            }
            else if ((uint) client <= uint.MaxValue)
              goto label_13;
            else
              goto label_38;
          }
          else
            goto label_13;
        }
label_44:
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, color2, color1, LinearGradientMode.Vertical))
        {
          graphics.FillRectangle((Brush) linearGradientBrush, bounds);
          break;
        }
label_50:
        color2 = RendererBase.InterpolateColors(color2, backColor, (float) this.PageColorBlend);
        color1 = RendererBase.InterpolateColors(color1, backColor, (float) this.PageColorBlend);
        if ((uint) client - (uint) client >= 0U)
        {
          if (true)
          {
            if (true)
              goto label_42;
            else
              goto label_44;
          }
          else if (false)
            goto label_53;
        }
        else
          goto label_13;
      }
    }
  }
}
