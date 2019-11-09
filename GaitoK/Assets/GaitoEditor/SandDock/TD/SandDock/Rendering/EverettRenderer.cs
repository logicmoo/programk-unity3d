// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Rendering.EverettRenderer
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
  public class EverettRenderer : RendererBase
  {
    private Color xef5f9f8a08f25e70 = SystemColors.InactiveCaption;
    private Color x4978f8b41a50b017 = SystemColors.ActiveCaption;
    private Color x228f9881a1be0e5d = SystemColors.ControlText;
    private Color xfca0e3085d5a7f42 = SystemColors.ControlLightLight;
    private Color x1da108dbfca32343 = SystemColors.ControlDarkDark;
    private Color x9c1f2f40026567ee = SystemColors.ControlDark;
    private Color x488edc060a6f4707 = SystemColors.ControlDarkDark;
    private static StringFormat xdc3f45c33fe25d85;
    private static StringFormat x7553dbb15fca5d00;
    private Color x7f2683d69c01d139;
    private SolidBrush x166a89f4cd379ec8;
    private Pen x7a0be2490cda8794;
    private Pen x050be261498a0c97;
    private Pen xa33e6094d9ed12d6;
    private SolidBrush x54c190ae969c389d;
    private StringFormat x2771fbe8bb84042b;
    private BoxModel _x066f993679e36022;
    private BoxModel _x3a1fa93b40743331;
    private BoxModel _x6defba3d5d846e0d;

    internal static StringFormat x27e1c82c97265861
    {
      get
      {
        if (EverettRenderer.xdc3f45c33fe25d85 == null)
        {
          EverettRenderer.xdc3f45c33fe25d85 = new StringFormat(StringFormat.GenericDefault);
          EverettRenderer.xdc3f45c33fe25d85.Alignment = StringAlignment.Near;
          EverettRenderer.xdc3f45c33fe25d85.LineAlignment = StringAlignment.Center;
          EverettRenderer.xdc3f45c33fe25d85.Trimming = StringTrimming.EllipsisCharacter;
          if (false)
            ;
          EverettRenderer.xdc3f45c33fe25d85.FormatFlags |= StringFormatFlags.NoWrap;
        }
        return EverettRenderer.xdc3f45c33fe25d85;
      }
    }

    internal static StringFormat xc351c68a86733972
    {
      get
      {
        if (EverettRenderer.x7553dbb15fca5d00 == null)
        {
          EverettRenderer.x7553dbb15fca5d00 = new StringFormat(StringFormat.GenericDefault);
          if (true)
          {
            do
            {
              EverettRenderer.x7553dbb15fca5d00.Alignment = StringAlignment.Near;
              EverettRenderer.x7553dbb15fca5d00.LineAlignment = StringAlignment.Center;
              EverettRenderer.x7553dbb15fca5d00.Trimming = StringTrimming.EllipsisCharacter;
            }
            while (false);
            EverettRenderer.x7553dbb15fca5d00.FormatFlags |= StringFormatFlags.NoWrap;
            EverettRenderer.x7553dbb15fca5d00.FormatFlags |= StringFormatFlags.DirectionVertical;
          }
        }
        return EverettRenderer.x7553dbb15fca5d00;
      }
    }

    protected override void GetColorsFromSystem()
    {
      this.x7f2683d69c01d139 = this.x2c04503a704e817c(SystemColors.Control);
    }

    private Color x2c04503a704e817c(Color xdd0e633cf3dbad19)
    {
      byte r = xdd0e633cf3dbad19.R;
      byte g = xdd0e633cf3dbad19.G;
      byte b = xdd0e633cf3dbad19.B;
      byte num1 = Math.Max(Math.Max(r, g), b);
      if (num1 == (byte) 0)
        return Color.FromArgb(35, 35, 35);
      byte num2 = ((int) num1 | 1) == 0 || num1 <= (byte) 220 ? (byte) 35 : (byte) ((uint) byte.MaxValue - (uint) num1);
      if (((int) num2 & 0) == 0)
        goto label_2;
label_1:
      byte num3 = (byte) ((uint) b + (uint) (byte) ((double) num2 * ((double) b / (double) num1) + 0.5));
      return Color.FromArgb((int) r, (int) g, (int) num3);
label_2:
      r += (byte) ((double) num2 * ((double) r / (double) num1) + 0.5);
      g += (byte) ((double) num2 * ((double) g / (double) num1) + 0.5);
      goto label_1;
    }

    public Color CollapsedTabOutlineColor
    {
      get
      {
        return this.x9c1f2f40026567ee;
      }
      set
      {
        this.x9c1f2f40026567ee = value;
        this.CustomColors = true;
      }
    }

    public Color BackgroundTabForeColor
    {
      get
      {
        return this.x1da108dbfca32343;
      }
      set
      {
        this.x1da108dbfca32343 = value;
      }
    }

    public Color HighlightColor
    {
      get
      {
        return this.xfca0e3085d5a7f42;
      }
      set
      {
        this.xfca0e3085d5a7f42 = value;
        this.CustomColors = true;
      }
    }

    public Color ShadowColor
    {
      get
      {
        return this.x228f9881a1be0e5d;
      }
      set
      {
        this.x228f9881a1be0e5d = value;
        this.CustomColors = true;
      }
    }

    public Color TabStripBackgroundColor
    {
      get
      {
        return this.x7f2683d69c01d139;
      }
    }

    public Color InactiveTitleBarColor
    {
      get
      {
        return this.xef5f9f8a08f25e70;
      }
      set
      {
        this.xef5f9f8a08f25e70 = value;
        this.CustomColors = true;
      }
    }

    public Color ActiveTitleBarColor
    {
      get
      {
        return this.x4978f8b41a50b017;
      }
      set
      {
        this.x4978f8b41a50b017 = value;
        this.CustomColors = true;
      }
    }

    protected internal override TabTextDisplayMode TabTextDisplay
    {
      get
      {
        return TabTextDisplayMode.SelectedTab;
      }
    }

    protected internal override Rectangle AdjustDockControlClientBounds(
      ControlLayoutSystem layoutSystem,
      DockControl control,
      Rectangle clientBounds)
    {
      if (!(layoutSystem is DocumentLayoutSystem))
        return base.AdjustDockControlClientBounds(layoutSystem, control, clientBounds);
      clientBounds.Inflate(-2, -2);
      return clientBounds;
    }

    protected internal override BoxModel TitleBarMetrics
    {
      get
      {
        if (this._x6defba3d5d846e0d == null)
          this._x6defba3d5d846e0d = new BoxModel(0, SystemInformation.ToolWindowCaptionHeight + 2, 0, 0, 0, 0, 0, 0, 0, 2);
        return this._x6defba3d5d846e0d;
      }
    }

    protected internal override BoxModel TabMetrics
    {
      get
      {
        if (this._x3a1fa93b40743331 == null)
          this._x3a1fa93b40743331 = new BoxModel(0, 0, 0, 0, 0, 0, 0, 0, 1, 0);
        return this._x3a1fa93b40743331;
      }
    }

    protected internal override BoxModel TabStripMetrics
    {
      get
      {
        if (this._x066f993679e36022 == null)
          this._x066f993679e36022 = new BoxModel(0, Control.DefaultFont.Height + 9, 4, 0, 5, 1, 0, 2, 0, 0);
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

    protected internal override void DrawDocumentStripBackground(
      Graphics graphics,
      Rectangle bounds)
    {
      graphics.FillRectangle((Brush) this.x166a89f4cd379ec8, bounds);
      graphics.DrawLine(this.x050be261498a0c97, bounds.X, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
    }

    public override System.Drawing.Size TabControlPadding
    {
      get
      {
        return new System.Drawing.Size(3, 3);
      }
    }

    protected internal override void DrawDockContainerBackground(
      Graphics graphics,
      DockContainer container,
      Rectangle bounds)
    {
      xa811784015ed8842.x91433b5e99eb7cac(graphics, container.BackColor);
    }

    protected internal override System.Drawing.Size MeasureTabStripTab(
      Graphics graphics,
      Image image,
      string text,
      Font font,
      DrawItemState state)
    {
      return new System.Drawing.Size((int) Math.Ceiling((double) graphics.MeasureString(text, font, int.MaxValue, this.x2771fbe8bb84042b).Width) + 30, 18);
    }

    protected internal override System.Drawing.Size MeasureDocumentStripTab(
      Graphics graphics,
      Image image,
      string text,
      Font font,
      DrawItemState state)
    {
      if ((state & DrawItemState.Focus) == DrawItemState.Focus)
      {
        if (true)
          goto label_4;
      }
      else
        goto label_9;
label_2:
      int num;
      num += 20;
label_3:
      return new System.Drawing.Size(num + this.DocumentTabExtra, 0);
label_4:
      using (Font font1 = new Font(font, FontStyle.Bold))
      {
        num = (int) Math.Ceiling((double) graphics.MeasureString(text, font1, 999, this.x2771fbe8bb84042b).Width);
        goto label_10;
      }
label_9:
      num = (int) Math.Ceiling((double) graphics.MeasureString(text, font, 999, this.x2771fbe8bb84042b).Width);
label_10:
      num += 2 + this.xe5ad29d0f658e81f * 2 + 2;
      if ((num & 0) == 0)
      {
        if (image == null)
          goto label_3;
        else
          goto label_2;
      }
      else
        goto label_4;
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
      if ((state & DrawItemState.Selected) != DrawItemState.Selected)
      {
        if (drawSeparator)
        {
          do
          {
            graphics.DrawLine(SystemPens.ControlDark, bounds.Right, bounds.Top + 3, bounds.Right, bounds.Bottom - 3);
          }
          while (false);
        }
      }
      else
        goto label_21;
label_16:
      bounds = contentBounds;
      if (image != null)
        goto label_14;
label_1:
      if (bounds.Width <= 8)
        return;
      Font font1 = font;
      if ((state & DrawItemState.Focus) == DrawItemState.Focus)
        font1 = new Font(font, FontStyle.Bold);
label_3:
      if ((state & DrawItemState.Selected) == DrawItemState.Selected)
        goto label_7;
      else
        goto label_4;
label_2:
      if ((state & DrawItemState.Focus) == DrawItemState.Focus)
      {
        font1.Dispose();
        if ((uint) drawSeparator + (uint) drawSeparator >= 0U)
          return;
      }
      if ((uint) drawSeparator <= uint.MaxValue)
        return;
      goto label_14;
label_4:
      graphics.DrawString(text, font1, (Brush) this.x54c190ae969c389d, (RectangleF) bounds, this.x2771fbe8bb84042b);
      goto label_2;
label_7:
      using (SolidBrush solidBrush = new SolidBrush(foreColor))
      {
        graphics.DrawString(text, font1, (Brush) solidBrush, (RectangleF) bounds, this.x2771fbe8bb84042b);
        goto label_2;
      }
label_14:
      graphics.DrawImage(image, bounds.X + 4, bounds.Y + 2, 16, 16);
      bounds.X += 20;
      bounds.Width -= 20;
      if ((uint) drawSeparator > uint.MaxValue)
        goto label_3;
      else
        goto label_1;
label_21:
      using (SolidBrush solidBrush = new SolidBrush(backColor))
        graphics.FillRectangle((Brush) solidBrush, bounds);
      graphics.DrawLine(this.x050be261498a0c97, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
      graphics.DrawLine(this.x050be261498a0c97, bounds.Left, bounds.Top, bounds.Right - 1, bounds.Top);
      graphics.DrawLine(this.x7a0be2490cda8794, bounds.Right - 1, bounds.Top + 1, bounds.Right - 1, bounds.Bottom - 1);
      goto label_16;
    }

    internal virtual int xe5ad29d0f658e81f
    {
      get
      {
        return 5;
      }
    }

    protected internal override int DocumentTabSize
    {
      get
      {
        return Control.DefaultFont.Height + 6;
      }
    }

    protected internal override int DocumentTabStripSize
    {
      get
      {
        return Control.DefaultFont.Height + 8;
      }
    }

    protected internal override int DocumentTabExtra
    {
      get
      {
        return 0;
      }
    }

    public override void StartRenderSession(HotkeyPrefix hotKeys)
    {
      this.x166a89f4cd379ec8 = new SolidBrush(this.x7f2683d69c01d139);
      do
      {
        this.x7a0be2490cda8794 = new Pen(this.x228f9881a1be0e5d);
        this.x050be261498a0c97 = new Pen(this.xfca0e3085d5a7f42);
        this.x54c190ae969c389d = new SolidBrush(this.x1da108dbfca32343);
        this.xa33e6094d9ed12d6 = new Pen(this.x9c1f2f40026567ee);
        this.x2771fbe8bb84042b = new StringFormat(StringFormat.GenericDefault);
        this.x2771fbe8bb84042b.FormatFlags = StringFormatFlags.NoWrap;
        this.x2771fbe8bb84042b.Alignment = StringAlignment.Center;
        if (false)
          goto label_2;
      }
      while (false);
      goto label_5;
label_2:
      this.x2771fbe8bb84042b.HotkeyPrefix = hotKeys;
      return;
label_5:
      if (false)
        return;
      this.x2771fbe8bb84042b.LineAlignment = StringAlignment.Center;
      goto label_2;
    }

    protected internal override void DrawSplitter(
      Control container,
      Control control,
      Graphics graphics,
      Rectangle bounds,
      Orientation orientation)
    {
    }

    protected internal override void DrawDocumentStripButton(
      Graphics graphics,
      Rectangle bounds,
      SandDockButtonType buttonType,
      DrawItemState state)
    {
      this.x9271fbf5eef553db(graphics, bounds, state);
      if (true)
        goto label_17;
label_1:
      using (Pen x90279591611601bc = new Pen(this.x488edc060a6f4707))
      {
        x9b2777bb8e78938b.xb176aa01ddab9f3e(graphics, bounds, x90279591611601bc);
        return;
      }
label_17:
      if (true)
        goto label_14;
      else
        goto label_12;
label_8:
      x9b2777bb8e78938b.xd70a4c1a2378c84e(graphics, bounds, this.x488edc060a6f4707, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
      return;
label_10:
      SandDockButtonType sandDockButtonType = buttonType;
      if (true)
      {
        switch (sandDockButtonType)
        {
          case SandDockButtonType.Close:
            goto label_1;
          case SandDockButtonType.Pin:
            return;
          case SandDockButtonType.ScrollLeft:
            goto label_8;
          case SandDockButtonType.ScrollRight:
            x9b2777bb8e78938b.x793dc1a7cf4113f9(graphics, bounds, this.x488edc060a6f4707, (state & DrawItemState.Disabled) != DrawItemState.Disabled);
            break;
          case SandDockButtonType.WindowPosition:
            return;
          case SandDockButtonType.ActiveFiles:
            x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, SystemPens.ControlText);
            return;
          default:
            return;
        }
      }
      if (true)
        return;
      goto label_1;
label_12:
      bounds.Offset(1, 1);
      if (true)
      {
        if (true)
          goto label_10;
      }
      else
        goto label_8;
label_14:
      if ((state & DrawItemState.Selected) == DrawItemState.Selected)
        goto label_12;
      else
        goto label_10;
    }

    internal virtual void x9271fbf5eef553db(
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998,
      DrawItemState x01b557925841ae51)
    {
      if ((x01b557925841ae51 & DrawItemState.HotLight) != DrawItemState.HotLight)
        return;
      Pen pen1;
      Pen pen2;
      if ((x01b557925841ae51 & DrawItemState.Selected) != DrawItemState.Selected)
      {
        if (false)
          ;
        pen2 = this.x7a0be2490cda8794;
        pen1 = this.x050be261498a0c97;
      }
      else
        goto label_5;
label_4:
      x41347a961b838962.DrawLine(pen1, xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
      x41347a961b838962.DrawLine(pen1, xda73fcb97c77d998.Left, xda73fcb97c77d998.Top, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1);
      x41347a961b838962.DrawLine(pen2, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Top);
      x41347a961b838962.DrawLine(pen2, xda73fcb97c77d998.Right - 1, xda73fcb97c77d998.Bottom - 1, xda73fcb97c77d998.Left, xda73fcb97c77d998.Bottom - 1);
      if (true)
        return;
label_5:
      pen1 = this.x7a0be2490cda8794;
      pen2 = this.x050be261498a0c97;
      goto label_4;
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
      do
      {
        if (true)
          --bounds.Height;
        this.x9271fbf5eef553db(graphics, bounds, state);
        if (((toggled ? 1 : 0) & 0) == 0)
          goto label_11;
        else
          goto label_19;
label_7:
        switch (buttonType)
        {
          case SandDockButtonType.Close:
            goto label_4;
          case SandDockButtonType.Pin:
            goto label_2;
          case SandDockButtonType.ScrollLeft:
            goto label_8;
          case SandDockButtonType.ScrollRight:
            goto label_10;
          case SandDockButtonType.WindowPosition:
            x9b2777bb8e78938b.xeac2e7eb44dff86e(graphics, bounds, focused ? SystemPens.ActiveCaptionText : SystemPens.ControlText);
            if ((uint) focused - (uint) focused >= 0U)
              goto label_15;
            else
              goto label_13;
          default:
            goto label_3;
        }
label_11:
        if ((state & DrawItemState.Selected) != DrawItemState.Selected)
        {
          if (true)
            goto label_7;
        }
        else
          goto label_19;
label_13:
        if ((uint) toggled >= 0U)
        {
          if (true)
          {
            if ((uint) focused + (uint) focused > uint.MaxValue)
              goto label_12;
            else
              goto label_7;
          }
        }
        else
          goto label_11;
label_15:
        continue;
label_19:
        bounds.Offset(1, 1);
        if ((uint) focused < 0U)
          goto label_13;
        else
          goto label_13;
      }
      while ((uint) focused - (uint) focused < 0U);
      goto label_9;
label_2:
      x9b2777bb8e78938b.x1477b5a75c8a8132(graphics, bounds, focused ? SystemPens.ActiveCaptionText : SystemPens.ControlText, toggled);
      return;
label_4:
      x9b2777bb8e78938b.x26f0f0028ef01fa5(graphics, bounds, focused ? SystemPens.ActiveCaptionText : SystemPens.ControlText);
      return;
label_12:
      return;
label_8:
      return;
label_10:
      return;
label_3:
      return;
label_9:;
    }

    protected internal override void DrawTabStripBackground(
      Control container,
      Control control,
      Graphics graphics,
      Rectangle bounds,
      int selectedTabOffset)
    {
      graphics.FillRectangle((Brush) this.x166a89f4cd379ec8, bounds);
      graphics.DrawLine(this.x7a0be2490cda8794, bounds.X, bounds.Y, bounds.Right, bounds.Y);
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
      if ((state & DrawItemState.Selected) != DrawItemState.Selected)
        goto label_18;
      else
        goto label_20;
label_14:
      if (bounds.Width >= 24)
        graphics.DrawImage(image, new Rectangle(bounds.X + 4, bounds.Y + 2, image.Width, image.Height));
      bounds.X += 23;
      if ((uint) drawSeparator + (uint) drawSeparator > uint.MaxValue)
        return;
      bounds.Width -= 25;
      while (bounds.Width > 8)
      {
        if ((state & DrawItemState.Selected) == DrawItemState.Selected)
        {
          using (SolidBrush solidBrush = new SolidBrush(foreColor))
          {
            graphics.DrawString(text, font, (Brush) solidBrush, (RectangleF) bounds, EverettRenderer.x27e1c82c97265861);
            break;
          }
        }
        else
        {
          graphics.DrawString(text, font, (Brush) this.x54c190ae969c389d, (RectangleF) bounds, EverettRenderer.x27e1c82c97265861);
          if ((uint) drawSeparator - (uint) drawSeparator >= 0U)
          {
            if (true)
            {
              if ((uint) drawSeparator + (uint) drawSeparator >= 0U)
                break;
            }
            else
              goto label_20;
          }
          else
            goto label_17;
        }
      }
      return;
label_17:
      graphics.DrawLine(this.x7a0be2490cda8794, bounds.Right, bounds.Top, bounds.Right, bounds.Bottom - 1);
      goto label_14;
label_18:
      if (drawSeparator)
      {
        graphics.DrawLine(SystemPens.ControlDark, bounds.Right, bounds.Top + 3, bounds.Right, bounds.Bottom - 3);
        goto label_14;
      }
      else
        goto label_14;
label_20:
      using (SolidBrush solidBrush = new SolidBrush(backColor))
        graphics.FillRectangle((Brush) solidBrush, bounds);
      graphics.DrawLine(this.x050be261498a0c97, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom - 1);
      graphics.DrawLine(this.x7a0be2490cda8794, bounds.Left, bounds.Bottom - 1, bounds.Right, bounds.Bottom - 1);
      goto label_17;
    }

    protected internal override void DrawAutoHideBarBackground(
      Control container,
      Control autoHideBar,
      Graphics graphics,
      Rectangle bounds)
    {
      using (this.x166a89f4cd379ec8 = new SolidBrush(this.x7f2683d69c01d139))
        graphics.FillRectangle((Brush) this.x166a89f4cd379ec8, bounds);
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
      using (SolidBrush solidBrush = new SolidBrush(backColor))
        graphics.FillRectangle((Brush) solidBrush, bounds);
      if (dockSide == DockSide.Top)
        goto label_20;
      else
        goto label_26;
label_5:
      do
      {
        if (text.Length != 0)
          goto label_10;
        else
          goto label_7;
label_6:
        continue;
label_7:
        if (((vertical ? 1 : 0) & 0) != 0)
          goto label_6;
        else
          goto label_27;
label_10:
        if (!vertical)
        {
          bounds.Offset(23, 0);
          graphics.DrawString(text, font, (Brush) this.x54c190ae969c389d, (RectangleF) bounds, EverettRenderer.x27e1c82c97265861);
          goto label_6;
        }
        else
          goto label_11;
      }
      while (false);
      return;
label_27:
      return;
label_11:
      bounds.Offset(0, 23);
      graphics.DrawString(text, font, (Brush) this.x54c190ae969c389d, (RectangleF) bounds, EverettRenderer.xc351c68a86733972);
      if (((vertical ? 1 : 0) & 0) == 0)
        return;
      goto label_18;
label_12:
      if (vertical)
      {
        bounds.Offset(0, 1);
        goto label_15;
      }
label_14:
      bounds.Offset(1, 0);
label_15:
      graphics.DrawImage(image, new Rectangle(bounds.Left, bounds.Top, image.Width, image.Height));
      goto label_5;
label_17:
      if (dockSide != DockSide.Left)
        graphics.DrawLine(this.xa33e6094d9ed12d6, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom);
      else
        goto label_19;
label_18:
      if (false)
        goto label_17;
label_19:
      bounds.Inflate(-2, -2);
      goto label_12;
label_20:
      if (dockSide != DockSide.Right)
        goto label_24;
label_21:
      if (dockSide != DockSide.Bottom)
      {
        graphics.DrawLine(this.xa33e6094d9ed12d6, bounds.Left, bounds.Bottom, bounds.Right, bounds.Bottom);
        goto label_17;
      }
      else
        goto label_17;
label_24:
      graphics.DrawLine(this.xa33e6094d9ed12d6, bounds.Right, bounds.Top, bounds.Right, bounds.Bottom);
      if ((uint) vertical - (uint) vertical > uint.MaxValue)
        goto label_5;
      else
        goto label_21;
label_26:
      graphics.DrawLine(this.xa33e6094d9ed12d6, bounds.Left, bounds.Top, bounds.Right, bounds.Top);
      if (false)
      {
        if ((uint) vertical + (uint) vertical < 0U)
          goto label_12;
        else
          goto label_14;
      }
      else
        goto label_20;
    }

    protected internal override void DrawTitleBarBackground(
      Graphics graphics,
      Rectangle bounds,
      bool focused)
    {
      if (focused)
      {
        graphics.FillRectangle(SystemBrushes.ActiveCaption, bounds);
      }
      else
      {
        graphics.FillRectangle(SystemBrushes.Control, bounds);
        graphics.DrawLine(SystemPens.ControlDark, bounds.X + 1, bounds.Y, bounds.Right - 2, bounds.Y);
        if (false)
          ;
        graphics.DrawLine(SystemPens.ControlDark, bounds.X + 1, bounds.Bottom - 1, bounds.Right - 2, bounds.Bottom - 1);
        graphics.DrawLine(SystemPens.ControlDark, bounds.X, bounds.Y + 1, bounds.X, bounds.Bottom - 2);
        graphics.DrawLine(SystemPens.ControlDark, bounds.Right - 1, bounds.Y + 1, bounds.Right - 1, bounds.Bottom - 2);
      }
    }

    protected internal override void DrawTitleBarText(
      Graphics graphics,
      Rectangle bounds,
      bool focused,
      string text,
      Font font)
    {
      Brush brush = focused ? SystemBrushes.ActiveCaptionText : SystemBrushes.ControlText;
      bounds.Inflate(-3, 0);
      graphics.DrawString(text, font, brush, (RectangleF) bounds, EverettRenderer.x27e1c82c97265861);
    }

    public override void FinishRenderSession()
    {
      this.x166a89f4cd379ec8.Dispose();
      this.x7a0be2490cda8794.Dispose();
      this.x050be261498a0c97.Dispose();
      if (true)
        this.x54c190ae969c389d.Dispose();
      this.xa33e6094d9ed12d6.Dispose();
      this.x2771fbe8bb84042b.Dispose();
    }

    public override string ToString()
    {
      return "Everett";
    }
  }
}
