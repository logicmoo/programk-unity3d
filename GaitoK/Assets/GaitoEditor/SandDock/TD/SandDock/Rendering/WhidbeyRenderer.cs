// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Rendering.WhidbeyRenderer
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
  public class WhidbeyRenderer : ThemeAwareRendererBase
  {
    private Color x994b52371e1ca7a9;
    private Color xcee7f670c3cc8729;
    private Color x80caa5727f6ffe52;
    private Color x0b2889b8ff5ec580;
    private Color x9196c174a89a4ce4;
    private Color x0e8b6412ec502dbf;
    private Color xd1edc46cbe592968;
    private Color x43b04232fee73e15;
    private Color x8e2e7f87608d5b3b;
    private Color x9a7470f809ffee0d;
    private Color x2d5bde28a1e8ae90;
    private Color xebb7eaf00d600976;
    private Color x6b97fa649c9b3a44;
    private Color x693536a88ebe8191;
    private Color x503b1fd8602da9a9;
    private Color xb2b9c364e92661dd;
    private Color x4056384aa48da1d1;
    private Color x2e1ef9b84f7ac14b;
    private Color x4dea88af4363a77b;
    private BoxModel _x066f993679e36022;
    private BoxModel _x3a1fa93b40743331;
    private BoxModel _x6defba3d5d846e0d;

    public WhidbeyRenderer()
    {
    }

    public WhidbeyRenderer(WindowsColorScheme colorScheme)
    {
      this.ColorScheme = colorScheme;
    }

    public Color ActiveDocumentBorderColor
    {
      get
      {
        return this.x994b52371e1ca7a9;
      }
      set
      {
        this.x994b52371e1ca7a9 = value;
        this.CustomColors = true;
      }
    }

    public Color InactiveDocumentBorderColor
    {
      get
      {
        return this.xcee7f670c3cc8729;
      }
      set
      {
        this.xcee7f670c3cc8729 = value;
        this.CustomColors = true;
      }
    }

    public Color DocumentStripBackgroundColor1
    {
      get
      {
        return this.xd1edc46cbe592968;
      }
      set
      {
        this.xd1edc46cbe592968 = value;
        this.CustomColors = true;
      }
    }

    public Color DocumentStripBackgroundColor2
    {
      get
      {
        return this.x43b04232fee73e15;
      }
      set
      {
        this.x43b04232fee73e15 = value;
        this.CustomColors = true;
      }
    }

    public Color ActiveHotButtonBorderColor
    {
      get
      {
        return this.x4dea88af4363a77b;
      }
      set
      {
        this.x4dea88af4363a77b = value;
        this.CustomColors = true;
      }
    }

    public Color ActiveHotButtonBackgroundColor
    {
      get
      {
        return this.x2e1ef9b84f7ac14b;
      }
      set
      {
        this.x2e1ef9b84f7ac14b = value;
        this.CustomColors = true;
      }
    }

    public Color ActiveButtonBorderColor
    {
      get
      {
        return this.x4056384aa48da1d1;
      }
      set
      {
        this.x4056384aa48da1d1 = value;
        this.CustomColors = true;
      }
    }

    public Color ActiveButtonBackgroundColor
    {
      get
      {
        return this.xb2b9c364e92661dd;
      }
      set
      {
        this.xb2b9c364e92661dd = value;
        this.CustomColors = true;
      }
    }

    public Color InactiveButtonBorderColor
    {
      get
      {
        return this.x503b1fd8602da9a9;
      }
      set
      {
        this.x503b1fd8602da9a9 = value;
        this.CustomColors = true;
      }
    }

    public Color InactiveButtonBackgroundColor
    {
      get
      {
        return this.x693536a88ebe8191;
      }
      set
      {
        this.x693536a88ebe8191 = value;
        this.CustomColors = true;
      }
    }

    public Color ActiveTitleBarForegroundColor
    {
      get
      {
        return this.x6b97fa649c9b3a44;
      }
      set
      {
        this.x6b97fa649c9b3a44 = value;
        this.CustomColors = true;
      }
    }

    public Color ActiveTitleBarBackgroundColor2
    {
      get
      {
        return this.xebb7eaf00d600976;
      }
      set
      {
        this.xebb7eaf00d600976 = value;
        this.CustomColors = true;
      }
    }

    public Color ActiveTitleBarBackgroundColor1
    {
      get
      {
        return this.x2d5bde28a1e8ae90;
      }
      set
      {
        this.x2d5bde28a1e8ae90 = value;
        this.CustomColors = true;
      }
    }

    public Color InactiveTitleBarForegroundColor
    {
      get
      {
        return this.x9a7470f809ffee0d;
      }
      set
      {
        this.x9a7470f809ffee0d = value;
        this.CustomColors = true;
      }
    }

    public Color InactiveTitleBarBackgroundColor
    {
      get
      {
        return this.x8e2e7f87608d5b3b;
      }
      set
      {
        this.x8e2e7f87608d5b3b = value;
        this.CustomColors = true;
      }
    }

    public Color ActiveDocumentShadowColor
    {
      get
      {
        return this.x9196c174a89a4ce4;
      }
      set
      {
        this.x9196c174a89a4ce4 = value;
        this.CustomColors = true;
      }
    }

    public Color InactiveDocumentShadowColor
    {
      get
      {
        return this.x0e8b6412ec502dbf;
      }
      set
      {
        this.x0e8b6412ec502dbf = value;
        this.CustomColors = true;
      }
    }

    public Color InactiveDocumentHighlightColor
    {
      get
      {
        return this.x0b2889b8ff5ec580;
      }
      set
      {
        this.x0b2889b8ff5ec580 = value;
        this.CustomColors = true;
      }
    }

    public Color ActiveDocumentHighlightColor
    {
      get
      {
        return this.x80caa5727f6ffe52;
      }
      set
      {
        this.x80caa5727f6ffe52 = value;
        this.CustomColors = true;
      }
    }

    protected override void GetColorsFromSystem()
    {
      base.GetColorsFromSystem();
      if (true)
        goto label_6;
label_3:
      this.x0b2889b8ff5ec580 = SystemColors.Control;
      this.x9196c174a89a4ce4 = SystemColors.Control;
label_4:
      this.x0e8b6412ec502dbf = SystemColors.Control;
      return;
label_6:
      while (!SystemInformation.HighContrast)
      {
        this.x80caa5727f6ffe52 = SystemColors.ControlLightLight;
        if (true)
        {
          this.x0b2889b8ff5ec580 = SystemColors.ControlLightLight;
          this.x9196c174a89a4ce4 = SystemColors.ControlLightLight;
          this.x0e8b6412ec502dbf = SystemColors.Control;
          if (true)
            return;
        }
        else
          goto label_4;
      }
      this.x80caa5727f6ffe52 = SystemColors.Control;
      goto label_3;
    }

    protected override void ApplyStandardColors()
    {
      if (!SystemInformation.HighContrast)
        goto label_11;
      else
        goto label_9;
label_2:
      while (true)
      {
        if (true)
          goto label_4;
label_1:
        this.x4dea88af4363a77b = SystemColors.ControlLightLight;
        if (true)
          return;
        continue;
label_4:
        this.x9a7470f809ffee0d = SystemColors.InactiveCaptionText;
        this.x693536a88ebe8191 = Color.Transparent;
        this.x503b1fd8602da9a9 = SystemColors.ControlLightLight;
        this.xb2b9c364e92661dd = Color.Transparent;
        this.x4056384aa48da1d1 = SystemColors.ControlLightLight;
        this.x2e1ef9b84f7ac14b = SystemInformation.HighContrast ? Color.Transparent : Color.FromArgb(100, SystemColors.Control);
        goto label_1;
      }
      goto label_10;
label_7:
      this.xd1edc46cbe592968 = SystemColors.Control;
      this.x43b04232fee73e15 = this.xd1edc46cbe592968;
      this.x2d5bde28a1e8ae90 = SystemColors.ActiveCaption;
      this.xebb7eaf00d600976 = SystemColors.ActiveCaption;
      this.x6b97fa649c9b3a44 = SystemColors.ActiveCaptionText;
      if (true)
      {
        this.x8e2e7f87608d5b3b = SystemColors.InactiveCaption;
        goto label_2;
      }
      else
        goto label_2;
label_9:
      this.LayoutBackgroundColor1 = SystemColors.Control;
      this.LayoutBackgroundColor2 = SystemColors.Control;
      this.ActiveDocumentBorderColor = SystemColors.ActiveCaption;
label_10:
      this.InactiveDocumentBorderColor = SystemColors.ControlDark;
      goto label_7;
label_11:
      this.LayoutBackgroundColor1 = SystemColors.Control;
      this.LayoutBackgroundColor2 = RendererBase.InterpolateColors(SystemColors.Control, SystemColors.Window, 0.8f);
      this.ActiveDocumentBorderColor = SystemColors.AppWorkspace;
      if (true)
        goto label_8;
label_6:
      this.InactiveDocumentBorderColor = SystemColors.ControlDark;
      goto label_7;
label_8:
      if (true)
      {
        if (true)
          goto label_6;
        else
          goto label_2;
      }
      else
        goto label_9;
    }

    protected override void ApplyLunaBlueColors()
    {
      this.LayoutBackgroundColor1 = Color.FromArgb(229, 229, 215);
label_7:
      if (false)
        goto label_4;
      else
        goto label_8;
label_3:
      this.x8e2e7f87608d5b3b = Color.FromArgb(204, 199, 186);
      this.x9a7470f809ffee0d = Color.Black;
      this.x693536a88ebe8191 = SystemColors.Control;
      this.x503b1fd8602da9a9 = Color.FromArgb(140, 134, 123);
label_4:
      this.xb2b9c364e92661dd = Color.FromArgb(156, 182, 231);
      this.x4056384aa48da1d1 = Color.FromArgb(60, 90, 170);
      do
      {
        this.x2e1ef9b84f7ac14b = Color.FromArgb(120, 150, 210);
      }
      while (false);
      this.x4dea88af4363a77b = Color.FromArgb(60, 90, 170);
      if (true)
        return;
      if (true)
        goto label_7;
label_6:
      this.x43b04232fee73e15 = this.xd1edc46cbe592968;
      this.ActiveDocumentBorderColor = Color.FromArgb((int) sbyte.MaxValue, 157, 185);
      this.InactiveDocumentBorderColor = SystemColors.ControlDark;
      this.x2d5bde28a1e8ae90 = Color.FromArgb(59, 128, 237);
      this.xebb7eaf00d600976 = Color.FromArgb(49, 106, 197);
      this.x6b97fa649c9b3a44 = Color.White;
      if (true)
        goto label_3;
      else
        goto label_7;
label_8:
      this.LayoutBackgroundColor2 = Color.FromArgb(243, 242, 231);
      this.xd1edc46cbe592968 = Color.FromArgb(228, 226, 213);
      if (true)
        goto label_6;
      else
        goto label_3;
    }

    protected override void ApplyLunaOliveColors()
    {
      this.LayoutBackgroundColor1 = Color.FromArgb(229, 229, 215);
      do
      {
        this.LayoutBackgroundColor2 = Color.FromArgb(243, 242, 231);
        this.xd1edc46cbe592968 = Color.FromArgb(228, 226, 213);
        if (true)
        {
          this.x43b04232fee73e15 = this.xd1edc46cbe592968;
          this.ActiveDocumentBorderColor = Color.FromArgb((int) sbyte.MaxValue, 157, 185);
          this.InactiveDocumentBorderColor = SystemColors.ControlDark;
          this.x2d5bde28a1e8ae90 = Color.FromArgb(182, 195, 146);
          this.xebb7eaf00d600976 = Color.FromArgb(145, 160, 117);
          this.x6b97fa649c9b3a44 = Color.White;
          do
          {
            this.x8e2e7f87608d5b3b = Color.FromArgb(204, 199, 186);
            this.x9a7470f809ffee0d = Color.Black;
            if (true)
            {
              this.x693536a88ebe8191 = SystemColors.Control;
              this.x503b1fd8602da9a9 = Color.FromArgb(140, 134, 123);
              this.xb2b9c364e92661dd = Color.FromArgb(181, 199, 140);
              this.x4056384aa48da1d1 = Color.FromArgb(118, 128, 95);
              this.x2e1ef9b84f7ac14b = Color.FromArgb(148, 162, 115);
            }
            else
              break;
          }
          while (false);
          if (true)
            this.x4dea88af4363a77b = Color.FromArgb(118, 128, 95);
          else
            goto label_5;
        }
        else
          goto label_7;
      }
      while (false);
      return;
label_7:
      return;
label_5:;
    }

    protected override void ApplyLunaSilverColors()
    {
      this.LayoutBackgroundColor1 = Color.FromArgb(215, 215, 229);
      if (true)
        goto label_6;
label_2:
      this.x2e1ef9b84f7ac14b = Color.FromArgb((int) byte.MaxValue, 182, 115);
      this.x4dea88af4363a77b = Color.FromArgb(74, 73, 107);
      return;
label_6:
      if (true)
        goto label_5;
label_1:
      this.x693536a88ebe8191 = Color.FromArgb(214, 215, 222);
      this.x503b1fd8602da9a9 = Color.FromArgb(123, 125, 148);
      this.xb2b9c364e92661dd = Color.FromArgb((int) byte.MaxValue, 227, 173);
      this.x4056384aa48da1d1 = Color.FromArgb(74, 73, 107);
      goto label_2;
label_5:
      this.LayoutBackgroundColor2 = Color.FromArgb(243, 243, 247);
      this.xd1edc46cbe592968 = Color.FromArgb(238, 238, 238);
      this.x43b04232fee73e15 = this.xd1edc46cbe592968;
      this.ActiveDocumentBorderColor = Color.FromArgb((int) sbyte.MaxValue, 157, 185);
      this.InactiveDocumentBorderColor = SystemColors.ControlDark;
      if (true)
        goto label_4;
label_3:
      this.x6b97fa649c9b3a44 = Color.Black;
      this.x8e2e7f87608d5b3b = Color.FromArgb(240, 240, 245);
      this.x9a7470f809ffee0d = Color.Black;
      goto label_1;
label_4:
      this.x2d5bde28a1e8ae90 = Color.FromArgb(211, 212, 221);
      this.xebb7eaf00d600976 = Color.FromArgb(166, 165, 191);
      goto label_3;
    }

    private void x50aa48875b838a15()
    {
      this._x066f993679e36022 = (BoxModel) null;
      this._x3a1fa93b40743331 = (BoxModel) null;
      this._x6defba3d5d846e0d = (BoxModel) null;
    }

    public override System.Drawing.Size ImageSize
    {
      get
      {
        return base.ImageSize;
      }
      set
      {
        this.x50aa48875b838a15();
        base.ImageSize = value;
      }
    }

    public override System.Drawing.Size TabControlPadding
    {
      get
      {
        return new System.Drawing.Size(3, 3);
      }
    }

    protected internal override void DrawDocumentStripBackground(
      Graphics graphics,
      Rectangle bounds)
    {
      if (bounds.Width <= 0 || bounds.Height <= 0)
        return;
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new System.Drawing.Point(bounds.X, bounds.Y - 1), new System.Drawing.Point(bounds.X, bounds.Bottom), this.xd1edc46cbe592968, this.x43b04232fee73e15))
        graphics.FillRectangle((Brush) linearGradientBrush, bounds);
      using (Pen pen = new Pen(this.x994b52371e1ca7a9))
        graphics.DrawLine(pen, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
    }

    internal virtual void x9271fbf5eef553db(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      DrawItemState x01b557925841ae51,
      bool xb0f87b71823b1d4e)
    {
      if ((x01b557925841ae51 & DrawItemState.HotLight) != DrawItemState.HotLight)
        return;
      if (true)
        goto label_25;
      else
        goto label_20;
label_14:
      Color color1;
      using (SolidBrush solidBrush = new SolidBrush(color1))
        x41347a961b838962.FillRectangle((Brush) solidBrush, xda73fcb97c77d998);
      Color color2;
      using (Pen pen = new Pen(color2))
      {
        x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
        x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1);
      }
      Color color3;
      using (Pen pen = new Pen(color3))
      {
        x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
        x41347a961b838962.DrawLine(pen, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1);
        return;
      }
label_19:
      color1 = this.xb2b9c364e92661dd;
      goto label_14;
label_20:
      if (((xb0f87b71823b1d4e ? 1 : 0) | -2) != 0)
      {
        color3 = this.x4056384aa48da1d1;
        goto label_19;
      }
      else
        goto label_27;
label_23:
      color2 = this.x4dea88af4363a77b;
      color3 = this.x4dea88af4363a77b;
      color1 = this.x2e1ef9b84f7ac14b;
      goto label_14;
label_24:
      if ((x01b557925841ae51 & DrawItemState.Selected) != DrawItemState.Selected)
      {
        color2 = this.x4056384aa48da1d1;
        if (true)
          goto label_20;
      }
      else
        goto label_23;
label_25:
      if (((xb0f87b71823b1d4e ? 1 : 0) & 0) == 0)
      {
        if (!xb0f87b71823b1d4e)
        {
          color2 = this.x503b1fd8602da9a9;
          color3 = this.x503b1fd8602da9a9;
          color1 = this.x693536a88ebe8191;
          goto label_14;
        }
        else
          goto label_24;
      }
      else if ((uint) xb0f87b71823b1d4e < 0U)
        goto label_19;
label_27:
      if (true)
        goto label_24;
      else
        goto label_23;
    }

    protected internal override void DrawControlClientBackground(
      Graphics graphics,
      Rectangle bounds,
      Color backColor)
    {
      graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
      graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 1, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
      graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
    }

    protected internal override void DrawDocumentClientBackground(
      Graphics graphics,
      Rectangle bounds,
      Color backColor)
    {
      using (SolidBrush solidBrush = new SolidBrush(backColor))
        graphics.FillRectangle((Brush) solidBrush, bounds);
    }

    protected internal override void DrawDocumentStripButton(
      Graphics graphics,
      Rectangle bounds,
      SandDockButtonType buttonType,
      DrawItemState state)
    {
      this.x9271fbf5eef553db(graphics, bounds, state, true);
      if (true)
        goto label_9;
label_1:
      if (true)
      {
        if (true)
          return;
        goto label_5;
      }
label_4:
      --bounds.X;
label_5:
      x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, SystemPens.ControlText);
      if (true)
        return;
label_9:
      do
      {
        switch (buttonType)
        {
          case SandDockButtonType.Close:
            x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, SystemPens.ControlText);
            continue;
          case SandDockButtonType.Pin:
            goto label_6;
          case SandDockButtonType.ScrollLeft:
            goto label_11;
          case SandDockButtonType.ScrollRight:
            goto label_12;
          case SandDockButtonType.WindowPosition:
            goto label_14;
          case SandDockButtonType.ActiveFiles:
            goto label_3;
          default:
            goto label_7;
        }
      }
      while (false);
      goto label_1;
label_3:
      bounds.Inflate(1, 1);
      goto label_4;
label_6:
      return;
label_14:
      return;
label_7:
      return;
label_11:
      x9b2777bb8e78938b.xd70a4c1a2378c84e(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
      return;
label_12:
      x9b2777bb8e78938b.x793dc1a7cf4113f9(graphics, bounds, SystemColors.ControlText, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
    }

    protected internal override System.Drawing.Size MeasureTabStripTab(
      Graphics graphics,
      Image image,
      string text,
      Font font,
      DrawItemState state)
    {
      TextFormatFlags flags = this.TextFormat & ~TextFormatFlags.NoPrefix;
      int width;
      if (true)
        width = TextRenderer.MeasureText((IDeviceContext) graphics, text, font, new System.Drawing.Size(int.MaxValue, int.MaxValue), flags).Width + 3 + 6 + (this.ImageSize.Width + 4);
      return new System.Drawing.Size(width, 16);
    }

    protected internal override System.Drawing.Size MeasureDocumentStripTab(
      Graphics graphics,
      Image image,
      string text,
      Font font,
      DrawItemState state)
    {
      TextFormatFlags textFormat = this.TextFormat;
      int num1;
      if ((num1 & 0) == 0)
        goto label_9;
label_3:
      int width;
      using (Font font1 = new Font(font, FontStyle.Bold))
        width = TextRenderer.MeasureText((IDeviceContext) graphics, text, font1, new System.Drawing.Size(int.MaxValue, int.MaxValue), textFormat).Width;
      int num2 = width + 14;
      if (image != null)
        num2 += 20;
      return new System.Drawing.Size(num2 + this.DocumentTabExtra, 0);
label_9:
      textFormat &= ~TextFormatFlags.NoPrefix;
      goto label_3;
    }

    protected internal override int DocumentTabSize
    {
      get
      {
        return Math.Max(Control.DefaultFont.Height, this.ImageSize.Height) + 3;
      }
    }

    protected internal override int DocumentTabStripSize
    {
      get
      {
        return Math.Max(Control.DefaultFont.Height, this.ImageSize.Height) + 4;
      }
    }

    protected internal override void DrawDockContainerBackground(
      Graphics graphics,
      DockContainer container,
      Rectangle bounds)
    {
      xa811784015ed8842.x91433b5e99eb7cac(graphics, container.BackColor);
    }

    protected internal override int DocumentTabExtra
    {
      get
      {
        return this.ImageSize.Width - 4;
      }
    }

    protected internal override void DrawDocumentStripTab(
      Graphics graphics,
      Rectangle bounds,
      Rectangle contentBounds,
      Image image,
      string text,
      Font font,
      Color backColor,
      Color foreColor,
      DrawItemState state,
      bool drawSeparator)
    {
      bool xb0f87b71823b1d4e = (state & DrawItemState.Checked) == DrawItemState.Checked;
      while ((uint) drawSeparator >= 0U && (state & DrawItemState.Selected) != DrawItemState.Selected)
      {
        xa811784015ed8842.xf8aac789a7846004(graphics, bounds, contentBounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemInformation.HighContrast ? SystemColors.Control : backColor, SystemBrushes.ControlText, this.InactiveDocumentBorderColor, this.x0b2889b8ff5ec580, this.x0e8b6412ec502dbf, false, this.DocumentTabSize, this.DocumentTabExtra, this.TextFormat, xb0f87b71823b1d4e);
        if ((uint) xb0f87b71823b1d4e - (uint) xb0f87b71823b1d4e <= uint.MaxValue)
          return;
      }
      xa811784015ed8842.xf8aac789a7846004(graphics, bounds, contentBounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemBrushes.ControlText, this.ActiveDocumentBorderColor, this.x80caa5727f6ffe52, this.x9196c174a89a4ce4, true, this.DocumentTabSize, this.DocumentTabExtra, this.TextFormat, xb0f87b71823b1d4e);
      if (false)
        ;
    }

    internal static bool x7fb2e1ce54a27086()
    {
      bool flag = false;
      if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        flag = Environment.OSVersion.Version >= new Version(5, 1, 0, 0);
      return flag;
    }

    public override void StartRenderSession(HotkeyPrefix hotKeys)
    {
      base.StartRenderSession(hotKeys);
    }

    protected internal override void DrawTabStripBackground(
      Control container,
      Control control,
      Graphics graphics,
      Rectangle bounds,
      int selectedTabOffset)
    {
      base.DrawTabStripBackground(container, control, graphics, bounds, selectedTabOffset);
      graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top + 2, bounds.Right - 1, bounds.Top + 2);
      if (true)
        goto label_6;
label_1:
      using (Pen pen = new Pen(SystemColors.ControlLightLight))
      {
        graphics.DrawLine(pen, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
        graphics.DrawLine(pen, bounds.Left, bounds.Top + 1, bounds.Right - 1, bounds.Top + 1);
        return;
      }
label_6:
      while (SystemInformation.HighContrast)
      {
        if (true)
          return;
      }
      goto label_1;
    }

    protected internal override void DrawTabStripTab(
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
      bounds.Y += 2;
      do
      {
        bounds.Height -= 2;
      }
      while (false);
      do
      {
        if ((state & DrawItemState.Selected) == DrawItemState.Selected)
          xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemColors.ControlText, SystemColors.ControlDark, state, this.TextFormat);
        else
          xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.ImageSize, text, font, SystemInformation.HighContrast ? SystemColors.Control : backColor, SystemInformation.HighContrast ? SystemColors.Control : SystemColors.ControlLightLight, SystemColors.ControlDarkDark, SystemColors.ControlDark, state, this.TextFormat);
        if ((state & DrawItemState.Selected) == DrawItemState.Selected)
          goto label_8;
      }
      while ((uint) drawSeparator - (uint) drawSeparator < 0U);
      if (!drawSeparator)
        return;
      graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 2, bounds.Top + 3, bounds.Right - 2, bounds.Bottom - 4);
      return;
label_8:;
    }

    protected internal override BoxModel TitleBarMetrics
    {
      get
      {
        if (this._x6defba3d5d846e0d == null)
          this._x6defba3d5d846e0d = new BoxModel(0, SystemInformation.ToolWindowCaptionHeight, 0, 0, 0, 0, 0, 0, 0, 0);
        return this._x6defba3d5d846e0d;
      }
    }

    protected internal override BoxModel TabMetrics
    {
      get
      {
        if (this._x3a1fa93b40743331 == null)
          this._x3a1fa93b40743331 = new BoxModel(0, 0, 0, 0, 0, 0, 0, 0, -1, 0);
        return this._x3a1fa93b40743331;
      }
    }

    protected internal override BoxModel TabStripMetrics
    {
      get
      {
        if (this._x066f993679e36022 == null)
          this._x066f993679e36022 = new BoxModel(0, Math.Max(Control.DefaultFont.Height, this.ImageSize.Height) + 8, 0, 0, 0, 1, 0, 0, 0, 0);
        return this._x066f993679e36022;
      }
    }

    protected internal override TabTextDisplayMode TabTextDisplay
    {
      get
      {
        return TabTextDisplayMode.AllTabs;
      }
    }

    protected internal override void DrawCollapsedTab(
      Graphics graphics,
      Rectangle bounds,
      DockSide dockSide,
      Image image,
      string text,
      Font font,
      Color backColor,
      Color foreColor,
      DrawItemState state,
      bool vertical)
    {
      if (dockSide == DockSide.Left || dockSide == DockSide.Right)
      {
        using (Image xe058541ca798c059 = (Image) new Bitmap(image))
        {
          xe058541ca798c059.RotateFlip(RotateFlipType.Rotate90FlipNone);
          xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, xe058541ca798c059, text, font, SystemBrushes.ControlDarkDark, SystemColors.ControlDark, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
        }
      }
      else
        xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, image, text, font, SystemBrushes.ControlDarkDark, SystemColors.ControlDark, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
    }

    protected internal override void DrawTitleBarButton(
      Graphics graphics,
      Rectangle bounds,
      SandDockButtonType buttonType,
      DrawItemState state,
      bool focused,
      bool toggled)
    {
      this.x9271fbf5eef553db(graphics, bounds, state, focused);
      using (Pen x90279591611601bc = (uint) focused + (uint) focused < 0U || !focused ? new Pen(this.x9a7470f809ffee0d) : new Pen(this.x6b97fa649c9b3a44))
      {
        SandDockButtonType sandDockButtonType = buttonType;
        do
        {
          switch (sandDockButtonType)
          {
            case SandDockButtonType.Close:
              goto label_7;
            case SandDockButtonType.Pin:
              x9b2777bb8e78938b.x1477b5a75c8a8132(graphics, bounds, x90279591611601bc, toggled);
              continue;
            case SandDockButtonType.ScrollLeft:
              goto label_8;
            case SandDockButtonType.ScrollRight:
              goto label_6;
            case SandDockButtonType.WindowPosition:
              goto label_3;
            default:
              goto label_2;
          }
        }
        while ((uint) toggled > uint.MaxValue);
        goto label_12;
label_3:
        x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, x90279591611601bc);
        return;
label_8:
        return;
label_6:
        return;
label_2:
        return;
label_12:
        return;
label_7:
        x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, x90279591611601bc);
      }
    }

    protected internal override void DrawTitleBarBackground(
      Graphics graphics,
      Rectangle bounds,
      bool focused)
    {
      if (focused)
      {
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new System.Drawing.Point(bounds.X, bounds.Y - 1), new System.Drawing.Point(bounds.X, bounds.Bottom), this.x2d5bde28a1e8ae90, this.xebb7eaf00d600976))
        {
          graphics.FillRectangle((Brush) linearGradientBrush, bounds);
          goto label_11;
        }
      }
label_6:
      using (SolidBrush solidBrush = new SolidBrush(this.x8e2e7f87608d5b3b))
        graphics.FillRectangle((Brush) solidBrush, bounds);
label_11:
      graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
      graphics.DrawLine(SystemPens.ControlDark, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
      if (true)
        graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 1, bounds.Top, bounds.Right - 1, bounds.Bottom - 1);
      else
        goto label_6;
    }

    protected internal override void DrawTitleBarText(
      Graphics graphics,
      Rectangle bounds,
      bool focused,
      string text,
      Font font)
    {
      bounds.Inflate(-3, 0);
      TextFormatFlags flags = this.TextFormat | TextFormatFlags.NoPrefix;
      bounds.X += 3;
      TextRenderer.DrawText((IDeviceContext) graphics, text, font, bounds, focused ? this.x6b97fa649c9b3a44 : this.x9a7470f809ffee0d, flags);
    }

    public override string ToString()
    {
      return "Whidbey";
    }
  }
}
