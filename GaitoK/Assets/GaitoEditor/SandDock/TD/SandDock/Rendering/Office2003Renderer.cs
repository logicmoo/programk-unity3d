// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Rendering.Office2003Renderer
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
  public class Office2003Renderer : ThemeAwareRendererBase
  {
    private System.Drawing.Size x95dac044246123ac = new System.Drawing.Size(16, 16);
    private Color x5bdc84993d5749e9;
    private Color xf6500c4730a3d95a;
    private Color xfc7b03fc2744e317;
    private Color xd1edc46cbe592968;
    private Color x43b04232fee73e15;
    private Color x994b52371e1ca7a9;
    private Color xcee7f670c3cc8729;
    private Color x80caa5727f6ffe52;
    private Color x0b2889b8ff5ec580;
    private Color x9196c174a89a4ce4;
    private Color x0e8b6412ec502dbf;
    private Color x488edc060a6f4707;
    private Color x6ea95002bd1a98a3;
    private Color xef5a1f47abc9b7b1;
    private Color x39abd2ac7b4ba43a;
    private Color x5ab33f59f391d4a9;
    private Color _x273909d58eb80850;
    private BoxModel _x066f993679e36022;
    private BoxModel _x3a1fa93b40743331;

    public Office2003Renderer()
    {
    }

    public Office2003Renderer(WindowsColorScheme colorScheme)
    {
      this.ColorScheme = colorScheme;
    }

    public Color HighlightBorderColor
    {
      get
      {
        return this.x5bdc84993d5749e9;
      }
      set
      {
        this.x5bdc84993d5749e9 = value;
        this.CustomColors = true;
      }
    }

    public Color HighlightBackgroundColor1
    {
      get
      {
        return this.xf6500c4730a3d95a;
      }
      set
      {
        this.xf6500c4730a3d95a = value;
        this.CustomColors = true;
      }
    }

    public Color HighlightBackgroundColor2
    {
      get
      {
        return this.xfc7b03fc2744e317;
      }
      set
      {
        this.xfc7b03fc2744e317 = value;
        this.CustomColors = true;
      }
    }

    public Color InactiveTitleBarColor1
    {
      get
      {
        return this.x39abd2ac7b4ba43a;
      }
      set
      {
        this.x39abd2ac7b4ba43a = value;
        this.CustomColors = true;
      }
    }

    public Color InactiveTitleBarColor2
    {
      get
      {
        return this.x5ab33f59f391d4a9;
      }
      set
      {
        this.x5ab33f59f391d4a9 = value;
        this.CustomColors = true;
      }
    }

    public Color ActiveTitleBarColor1
    {
      get
      {
        return this.x6ea95002bd1a98a3;
      }
      set
      {
        this.x6ea95002bd1a98a3 = value;
        this.CustomColors = true;
      }
    }

    public Color ActiveTitleBarColor2
    {
      get
      {
        return this.xef5a1f47abc9b7b1;
      }
      set
      {
        this.xef5a1f47abc9b7b1 = value;
        this.CustomColors = true;
      }
    }

    public Color GripperColor
    {
      get
      {
        return this._x273909d58eb80850;
      }
      set
      {
        this._x273909d58eb80850 = value;
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

    public Color WidgetColor
    {
      get
      {
        return this.x488edc060a6f4707;
      }
      set
      {
        this.x488edc060a6f4707 = value;
        this.CustomColors = true;
      }
    }

    protected override void ApplyStandardColors()
    {
      if (SystemInformation.HighContrast)
      {
        if (false)
        {
          if (true)
            goto label_8;
        }
        else
        {
          do
          {
            this.LayoutBackgroundColor1 = SystemColors.Control;
            this.LayoutBackgroundColor2 = SystemColors.Control;
            this.x994b52371e1ca7a9 = SystemColors.ActiveCaption;
            do
            {
              this.xcee7f670c3cc8729 = SystemColors.ControlDark;
            }
            while (false);
            if (true)
            {
              this.x80caa5727f6ffe52 = SystemColors.Control;
              this.x0b2889b8ff5ec580 = SystemColors.Control;
            }
            else
              goto label_7;
          }
          while (false);
          if (true)
            goto label_13;
          else
            goto label_22;
        }
      }
      else
        goto label_11;
label_3:
      this.x488edc060a6f4707 = SystemColors.ControlText;
      if (true)
        return;
      goto label_8;
label_7:
      do
      {
        this.x5bdc84993d5749e9 = SystemColors.Highlight;
        this.xf6500c4730a3d95a = RendererBase.InterpolateColors(this.x5bdc84993d5749e9, SystemColors.Window, 0.7f);
        this.xfc7b03fc2744e317 = this.xf6500c4730a3d95a;
        this.x39abd2ac7b4ba43a = this.LayoutBackgroundColor2;
        if (true)
          goto label_6;
label_4:
        this.xd1edc46cbe592968 = SystemColors.Control;
        this.x43b04232fee73e15 = SystemColors.ControlLightLight;
        if (false)
          continue;
        goto label_3;
label_6:
        this.x5ab33f59f391d4a9 = RendererBase.InterpolateColors(SystemColors.Control, Color.Black, 0.03f);
        this.x6ea95002bd1a98a3 = Color.FromArgb(212, 213, 216);
        this.xef5a1f47abc9b7b1 = Color.FromArgb(212, 213, 216);
        this._x273909d58eb80850 = SystemColors.ControlDark;
        goto label_4;
      }
      while (false);
label_8:
      this.x9196c174a89a4ce4 = SystemColors.ControlLightLight;
      this.x0e8b6412ec502dbf = SystemColors.Control;
      goto label_7;
label_11:
      this.LayoutBackgroundColor1 = SystemColors.Control;
      if (true)
      {
        this.LayoutBackgroundColor2 = RendererBase.InterpolateColors(SystemColors.Control, SystemColors.Window, 0.8f);
        this.x994b52371e1ca7a9 = SystemColors.ControlDark;
        this.xcee7f670c3cc8729 = SystemColors.ControlDark;
        if (true)
        {
          this.x80caa5727f6ffe52 = SystemColors.ControlLightLight;
          if (true)
          {
            this.x0b2889b8ff5ec580 = SystemColors.Control;
            goto label_22;
          }
          else
            goto label_14;
        }
      }
      else
        goto label_7;
label_13:
      this.x9196c174a89a4ce4 = SystemColors.Control;
label_14:
      this.x0e8b6412ec502dbf = SystemColors.Control;
      goto label_7;
label_22:
      if (true)
        goto label_8;
    }

    protected override void ApplyLunaBlueColors()
    {
      this.LayoutBackgroundColor1 = Color.FromArgb(158, 190, 245);
label_8:
      this.LayoutBackgroundColor2 = Color.FromArgb(195, 218, 249);
      if (false)
        goto label_4;
      else
        goto label_6;
label_3:
      this.x6ea95002bd1a98a3 = Color.FromArgb((int) byte.MaxValue, 211, 142);
      this.xef5a1f47abc9b7b1 = Color.FromArgb(254, 145, 78);
      this._x273909d58eb80850 = Color.FromArgb(39, 65, 118);
      this.xd1edc46cbe592968 = Color.FromArgb(196, 218, 250);
label_4:
      this.x43b04232fee73e15 = SystemColors.ControlLightLight;
      this.x994b52371e1ca7a9 = Color.FromArgb(59, 97, 156);
      this.xcee7f670c3cc8729 = Color.FromArgb(0, 53, 154);
      this.x80caa5727f6ffe52 = SystemColors.ControlLightLight;
      this.x0b2889b8ff5ec580 = SystemColors.ControlLightLight;
      this.x9196c174a89a4ce4 = SystemColors.ControlLightLight;
      this.x0e8b6412ec502dbf = Color.FromArgb(117, 166, 241);
      if (true)
      {
        if (true)
        {
          if (true)
          {
            this.x488edc060a6f4707 = SystemColors.ControlText;
            return;
          }
        }
        else
          goto label_3;
      }
      else
        goto label_7;
label_6:
      this.x5bdc84993d5749e9 = Color.FromArgb(0, 0, 128);
      if (false)
        goto label_8;
label_7:
      this.xf6500c4730a3d95a = Color.FromArgb((int) byte.MaxValue, 244, 204);
      this.xfc7b03fc2744e317 = Color.FromArgb((int) byte.MaxValue, 211, 142);
      this.x39abd2ac7b4ba43a = Color.FromArgb(221, 236, 254);
      this.x5ab33f59f391d4a9 = Color.FromArgb(129, 169, 226);
      goto label_3;
    }

    protected override void ApplyLunaOliveColors()
    {
      this.LayoutBackgroundColor1 = Color.FromArgb(217, 217, 167);
      if (true)
        goto label_6;
label_1:
      this.x80caa5727f6ffe52 = SystemColors.ControlLightLight;
      if (true)
      {
        this.x0b2889b8ff5ec580 = SystemColors.ControlLightLight;
        this.x9196c174a89a4ce4 = SystemColors.ControlLightLight;
        this.x0e8b6412ec502dbf = Color.FromArgb(176, 194, 140);
        this.x488edc060a6f4707 = SystemColors.ControlText;
        return;
      }
label_5:
      this.xef5a1f47abc9b7b1 = Color.FromArgb(254, 145, 78);
      this._x273909d58eb80850 = Color.FromArgb(81, 94, 51);
      this.xd1edc46cbe592968 = Color.FromArgb(242, 241, 228);
      this.x43b04232fee73e15 = SystemColors.ControlLightLight;
      this.x994b52371e1ca7a9 = Color.FromArgb(96, 128, 88);
      this.xcee7f670c3cc8729 = Color.FromArgb(96, 119, 107);
      goto label_8;
label_6:
      this.LayoutBackgroundColor2 = Color.FromArgb(242, 240, 228);
      this.x5bdc84993d5749e9 = Color.FromArgb(63, 93, 56);
      this.xf6500c4730a3d95a = Color.FromArgb((int) byte.MaxValue, 244, 204);
      do
      {
        this.xfc7b03fc2744e317 = Color.FromArgb((int) byte.MaxValue, 211, 142);
        if (false)
          goto label_8;
      }
      while (false);
      this.x39abd2ac7b4ba43a = Color.FromArgb(244, 247, 222);
      this.x5ab33f59f391d4a9 = Color.FromArgb(183, 198, 145);
      this.x6ea95002bd1a98a3 = Color.FromArgb((int) byte.MaxValue, 211, 142);
      goto label_5;
label_8:
      if (true)
        goto label_1;
    }

    protected override void ApplyLunaSilverColors()
    {
      this.LayoutBackgroundColor1 = Color.FromArgb(215, 215, 229);
      if (true)
        goto label_13;
label_1:
      this.x488edc060a6f4707 = SystemColors.ControlText;
      return;
label_13:
      this.LayoutBackgroundColor2 = Color.FromArgb(243, 243, 247);
      this.x5bdc84993d5749e9 = Color.FromArgb(75, 75, 111);
      this.xf6500c4730a3d95a = Color.FromArgb((int) byte.MaxValue, 244, 204);
      this.xfc7b03fc2744e317 = Color.FromArgb((int) byte.MaxValue, 211, 142);
label_11:
      this.x39abd2ac7b4ba43a = Color.FromArgb(243, 244, 250);
      this.x5ab33f59f391d4a9 = Color.FromArgb(140, 138, 172);
      do
      {
        this.x6ea95002bd1a98a3 = Color.FromArgb((int) byte.MaxValue, 211, 142);
        this.xef5a1f47abc9b7b1 = Color.FromArgb(254, 145, 78);
        this._x273909d58eb80850 = Color.FromArgb(84, 84, 117);
        if (true)
        {
          this.xd1edc46cbe592968 = Color.FromArgb(243, 243, 247);
          this.x43b04232fee73e15 = SystemColors.ControlLightLight;
          if (true)
          {
            if (false)
              ;
            this.x994b52371e1ca7a9 = Color.FromArgb(124, 124, 148);
            if (false)
              continue;
          }
          else
            continue;
        }
        if (true)
        {
          if (true)
          {
            this.xcee7f670c3cc8729 = Color.FromArgb(118, 116, 146);
            this.x80caa5727f6ffe52 = SystemColors.ControlLightLight;
            this.x0b2889b8ff5ec580 = SystemColors.ControlLightLight;
            this.x9196c174a89a4ce4 = SystemColors.ControlLightLight;
          }
          this.x0e8b6412ec502dbf = Color.FromArgb(186, 185, 206);
          if (true)
            goto label_14;
        }
        else
          break;
      }
      while (false);
      goto label_11;
label_14:
      if (true)
        goto label_1;
    }

    private void x9271fbf5eef553db(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      DrawItemState x01b557925841ae51)
    {
      if ((x01b557925841ae51 & DrawItemState.HotLight) != DrawItemState.HotLight)
        return;
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(xda73fcb97c77d998, this.xf6500c4730a3d95a, this.xfc7b03fc2744e317, LinearGradientMode.Vertical))
        x41347a961b838962.FillRectangle((Brush) linearGradientBrush, xda73fcb97c77d998);
      using (Pen pen = new Pen(this.x5bdc84993d5749e9))
        x41347a961b838962.DrawRectangle(pen, xda73fcb97c77d998);
    }

    protected internal override void DrawTitleBarButton(
      Graphics graphics,
      Rectangle bounds,
      SandDockButtonType buttonType,
      DrawItemState state,
      bool focused,
      bool toggled)
    {
      --bounds.Width;
      if (false)
      {
        if ((uint) toggled - (uint) toggled >= 0U)
          goto label_6;
      }
      else
        goto label_14;
label_2:
      x9b2777bb8e78938b.x1477b5a75c8a8132(graphics, bounds, focused ? SystemPens.ControlText : SystemPens.ControlText, toggled);
      return;
label_6:
      SandDockButtonType sandDockButtonType;
      do
      {
        do
        {
          switch (sandDockButtonType)
          {
            case SandDockButtonType.Close:
              x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, focused ? SystemPens.ControlText : SystemPens.ControlText);
              continue;
            case SandDockButtonType.Pin:
              goto label_2;
            case SandDockButtonType.ScrollLeft:
              goto label_8;
            case SandDockButtonType.ScrollRight:
              goto label_11;
            case SandDockButtonType.WindowPosition:
              goto label_5;
            default:
              goto label_7;
          }
        }
        while ((uint) focused - (uint) toggled > uint.MaxValue);
        goto label_15;
label_5:
        x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, focused ? SystemPens.ControlText : SystemPens.ControlText);
      }
      while (((focused ? 1 : 0) & 0) != 0);
      goto label_9;
label_15:
      return;
label_9:
      return;
label_8:
      return;
label_11:
      return;
label_7:
      if ((uint) toggled - (uint) focused >= 0U)
        return;
label_13:
      sandDockButtonType = buttonType;
      if (true)
        goto label_6;
label_14:
      --bounds.Height;
      this.x9271fbf5eef553db(graphics, bounds, state);
      if ((uint) toggled + (uint) toggled >= 0U)
      {
        if ((state & DrawItemState.Selected) == DrawItemState.Selected)
        {
          bounds.Offset(1, 1);
          goto label_13;
        }
        else
          goto label_13;
      }
      else
        goto label_6;
    }

    private Brush xe70d5b03e620fb01(
      Rectangle xda73fcb97c77d998,
      LinearGradientMode x23e85093ba3a7d1d,
      Color x6d9a095d183b6b50,
      Color x60a2487f840b534c)
    {
      Color color = RendererBase.InterpolateColors(x6d9a095d183b6b50, x60a2487f840b534c, 0.25f);
      LinearGradientBrush linearGradientBrush = new LinearGradientBrush(xda73fcb97c77d998, x6d9a095d183b6b50, x60a2487f840b534c, x23e85093ba3a7d1d);
      ColorBlend colorBlend;
      do
      {
        colorBlend = new ColorBlend(3);
        colorBlend.Colors = new Color[3]
        {
          x6d9a095d183b6b50,
          color,
          x60a2487f840b534c
        };
      }
      while (false);
      colorBlend.Positions = new float[3]{ 0.0f, 0.5f, 1f };
      linearGradientBrush.InterpolationColors = colorBlend;
      return (Brush) linearGradientBrush;
    }

    protected internal override void DrawTitleBarText(
      Graphics graphics,
      Rectangle bounds,
      bool focused,
      string text,
      Font font)
    {
      bounds.Inflate(-3, 0);
      using (Font font1 = new Font(font, FontStyle.Bold))
      {
        TextFormatFlags flags = this.TextFormat | TextFormatFlags.NoPrefix;
        bounds.X += 3;
        TextRenderer.DrawText((IDeviceContext) graphics, text, font1, bounds, SystemColors.ControlText, flags);
      }
    }

    protected internal override void DrawTitleBarBackground(
      Graphics graphics,
      Rectangle bounds,
      bool focused)
    {
      if (focused)
      {
        using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, this.x6ea95002bd1a98a3, this.xef5a1f47abc9b7b1, LinearGradientMode.Vertical))
          graphics.FillRectangle((Brush) linearGradientBrush, bounds);
      }
      else
      {
        using (Brush brush = this.xe70d5b03e620fb01(bounds, LinearGradientMode.Vertical, this.x39abd2ac7b4ba43a, this.x5ab33f59f391d4a9))
          graphics.FillRectangle(brush, bounds);
      }
      bounds.Inflate(0, -2);
      using (SolidBrush solidBrush = new SolidBrush(this._x273909d58eb80850))
      {
        int num1 = (bounds.Height - 2) / 4 * 4 - 2;
        int x;
        int num2;
        if (true)
        {
          x = bounds.X + 3;
          num2 = bounds.Y + bounds.Height / 2 - num1 / 2;
        }
        int y = num2;
        if ((uint) y - (uint) num1 > uint.MaxValue)
          return;
        for (; y <= num2 + num1; y += 4)
        {
          graphics.FillRectangle(SystemBrushes.ControlLightLight, new Rectangle(x + 1, y + 1, 2, 2));
          graphics.FillRectangle((Brush) solidBrush, new Rectangle(x, y, 2, 2));
        }
      }
    }

    protected internal override BoxModel TitleBarMetrics
    {
      get
      {
        return new BoxModel(0, 25, 4, 0, 0, 0, 0, 0, 0, 0);
      }
    }

    protected internal override TabTextDisplayMode TabTextDisplay
    {
      get
      {
        return TabTextDisplayMode.SelectedTab;
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
      if ((state & DrawItemState.Selected) == DrawItemState.Selected)
        xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, image, text, font, SystemBrushes.ControlText, SystemColors.ControlDarkDark, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
      else
        xa811784015ed8842.x36c79cea8e98cf3c(graphics, bounds, dockSide, image, text, font, SystemBrushes.ControlText, SystemColors.ControlDarkDark, this.TabTextDisplay == TabTextDisplayMode.AllTabs);
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
      if ((state & DrawItemState.Selected) == DrawItemState.Selected)
        xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.x95dac044246123ac, text, font, this.xf6500c4730a3d95a, this.xfc7b03fc2744e317, SystemColors.ControlText, SystemColors.ControlDark, state, this.TextFormat);
      else
        xa811784015ed8842.x272eca3f5ebfa9fc(graphics, bounds, image, this.x95dac044246123ac, text, font, backColor, SystemColors.ControlLightLight, SystemColors.ControlText, SystemColors.ControlDark, state, this.TextFormat);
    }

    protected internal override BoxModel TabStripMetrics
    {
      get
      {
        if (this._x066f993679e36022 == null)
          this._x066f993679e36022 = new BoxModel(0, Control.DefaultFont.Height + 10, 0, 0, 0, 1, 0, 0, 0, 0);
        return this._x066f993679e36022;
      }
    }

    protected internal override void DrawControlClientBackground(
      Graphics graphics,
      Rectangle bounds,
      Color backColor)
    {
    }

    protected internal override void DrawDocumentClientBackground(
      Graphics graphics,
      Rectangle bounds,
      Color backColor)
    {
      using (SolidBrush solidBrush = new SolidBrush(backColor))
        graphics.FillRectangle((Brush) solidBrush, bounds);
    }

    protected internal override System.Drawing.Size MeasureTabStripTab(
      Graphics graphics,
      Image image,
      string text,
      Font font,
      DrawItemState state)
    {
      TextFormatFlags flags = this.TextFormat & ~TextFormatFlags.NoPrefix;
      return new System.Drawing.Size(TextRenderer.MeasureText((IDeviceContext) graphics, text, font, new System.Drawing.Size(int.MaxValue, int.MaxValue), flags).Width + 3 + 30, 18);
    }

    protected internal override System.Drawing.Size MeasureDocumentStripTab(
      Graphics graphics,
      Image image,
      string text,
      Font font,
      DrawItemState state)
    {
      TextFormatFlags flags = this.TextFormat & ~TextFormatFlags.NoPrefix;
      if ((state & DrawItemState.Focus) == DrawItemState.Focus)
        goto label_6;
      else
        goto label_11;
label_1:
      int width;
      width += 24;
      if (true)
      {
        if (image != null)
        {
          if ((width & 0) == 0)
            width += 20;
          else
            goto label_11;
        }
        return new System.Drawing.Size(width + this.DocumentTabExtra, 0);
      }
label_6:
      using (Font font1 = new Font(font, FontStyle.Bold))
      {
        width = TextRenderer.MeasureText((IDeviceContext) graphics, text, font1, new System.Drawing.Size(int.MaxValue, int.MaxValue), flags).Width;
        goto label_1;
      }
label_11:
      width = TextRenderer.MeasureText((IDeviceContext) graphics, text, font, new System.Drawing.Size(int.MaxValue, int.MaxValue), flags).Width;
      goto label_1;
    }

    protected internal override void DrawDockContainerBackground(
      Graphics graphics,
      DockContainer container,
      Rectangle bounds)
    {
      xa811784015ed8842.x91433b5e99eb7cac(graphics, container.BackColor);
    }

    protected internal override Rectangle AdjustDockControlClientBounds(
      ControlLayoutSystem layoutSystem,
      DockControl control,
      Rectangle clientBounds)
    {
      if (!(layoutSystem is DocumentLayoutSystem))
        return base.AdjustDockControlClientBounds(layoutSystem, control, clientBounds);
      clientBounds.Inflate(-4, -4);
      return clientBounds;
    }

    protected internal override int DocumentTabStripSize
    {
      get
      {
        return Control.DefaultFont.Height + 15;
      }
    }

    protected internal override void DrawDocumentStripButton(
      Graphics graphics,
      Rectangle bounds,
      SandDockButtonType buttonType,
      DrawItemState state)
    {
      this.x9271fbf5eef553db(graphics, bounds, state);
      if ((state & DrawItemState.Selected) == DrawItemState.Selected)
        goto label_15;
label_13:
      switch (buttonType)
      {
        case SandDockButtonType.Close:
          using (Pen x90279591611601bc = new Pen(this.x488edc060a6f4707))
          {
            x9b2777bb8e78938b.xb176aa01ddab9f3e(graphics, bounds, x90279591611601bc);
            return;
          }
        case SandDockButtonType.Pin:
          return;
        case SandDockButtonType.ScrollLeft:
          x9b2777bb8e78938b.xd70a4c1a2378c84e(graphics, bounds, this.x488edc060a6f4707, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
          return;
        case SandDockButtonType.ScrollRight:
          x9b2777bb8e78938b.x793dc1a7cf4113f9(graphics, bounds, this.x488edc060a6f4707, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
          return;
        case SandDockButtonType.WindowPosition:
          return;
        case SandDockButtonType.ActiveFiles:
          using (Pen x90279591611601bc = new Pen(this.x488edc060a6f4707))
          {
            x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, x90279591611601bc);
            return;
          }
        default:
          return;
      }
label_15:
      bounds.Offset(1, 1);
      goto label_13;
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
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(new System.Drawing.Point(bounds.X, bounds.Y - 1), new System.Drawing.Point(bounds.X, bounds.Bottom), this.xd1edc46cbe592968, this.x43b04232fee73e15))
        graphics.FillRectangle((Brush) linearGradientBrush, bounds);
      using (Pen pen = new Pen(this.x994b52371e1ca7a9))
        graphics.DrawLine(pen, bounds.Left, bounds.Bottom - 1, bounds.Right - 1, bounds.Bottom - 1);
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
      Color x477e9d1180ece053 = RendererBase.InterpolateColors(backColor, SystemColors.ControlLightLight, 0.78f);
      bool xb0f87b71823b1d4e = (state & DrawItemState.Checked) == DrawItemState.Checked;
      if ((state & DrawItemState.Selected) != DrawItemState.Selected)
      {
        xa811784015ed8842.xf8aac789a7846004(graphics, bounds, contentBounds, image, this.ImageSize, text, font, x477e9d1180ece053, backColor, SystemBrushes.ControlText, this.xcee7f670c3cc8729, this.x0b2889b8ff5ec580, this.x0e8b6412ec502dbf, false, this.DocumentTabSize, this.DocumentTabExtra, this.TextFormat, xb0f87b71823b1d4e);
      }
      else
      {
        xa811784015ed8842.xf8aac789a7846004(graphics, bounds, contentBounds, image, this.ImageSize, text, font, x477e9d1180ece053, backColor, SystemBrushes.ControlText, this.x994b52371e1ca7a9, this.x80caa5727f6ffe52, this.x9196c174a89a4ce4, true, this.DocumentTabSize, this.DocumentTabExtra, this.TextFormat, xb0f87b71823b1d4e);
        if (false)
          ;
      }
    }

    protected internal override int DocumentTabSize
    {
      get
      {
        return Control.DefaultFont.Height + 7;
      }
    }

    protected internal override int DocumentTabExtra
    {
      get
      {
        return 18;
      }
    }

    public override string ToString()
    {
      return "Office 2003";
    }
  }
}
