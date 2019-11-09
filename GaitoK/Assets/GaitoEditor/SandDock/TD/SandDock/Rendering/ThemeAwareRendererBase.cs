// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Rendering.ThemeAwareRendererBase
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
  public abstract class ThemeAwareRendererBase : RendererBase
  {
    private WindowsColorScheme x62a65b2c0f145432;
    private Color x433ae1e8829e8c68;
    private Color x15920bc36c82e681;
    private int x03bb1ee2adad51ea;
    private TextFormatFlags xae3b2752a89e7464;

    protected abstract void ApplyStandardColors();

    protected abstract void ApplyLunaBlueColors();

    protected abstract void ApplyLunaOliveColors();

    protected abstract void ApplyLunaSilverColors();

    protected TextFormatFlags TextFormat
    {
      get
      {
        return this.xae3b2752a89e7464;
      }
    }

    public override void StartRenderSession(HotkeyPrefix hotKeys)
    {
      this.xae3b2752a89e7464 = TextFormatFlags.EndEllipsis | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.PreserveGraphicsClipping | TextFormatFlags.NoPadding;
      if (false)
        goto label_3;
      else
        goto label_2;
label_1:
      ++this.x03bb1ee2adad51ea;
      return;
label_2:
      switch (hotKeys)
      {
        case HotkeyPrefix.None:
          break;
        case HotkeyPrefix.Hide:
          this.xae3b2752a89e7464 |= TextFormatFlags.HidePrefix;
          goto label_1;
        default:
          goto label_1;
      }
label_3:
      this.xae3b2752a89e7464 |= TextFormatFlags.NoPrefix;
      goto label_1;
    }

    public override void FinishRenderSession()
    {
      this.x03bb1ee2adad51ea = Math.Max(this.x03bb1ee2adad51ea - 1, 0);
    }

    public Color LayoutBackgroundColor1
    {
      get
      {
        return this.x433ae1e8829e8c68;
      }
      set
      {
        this.x433ae1e8829e8c68 = value;
        this.CustomColors = true;
      }
    }

    public Color LayoutBackgroundColor2
    {
      get
      {
        return this.x15920bc36c82e681;
      }
      set
      {
        this.x15920bc36c82e681 = value;
        this.CustomColors = true;
      }
    }

    public WindowsColorScheme ColorScheme
    {
      get
      {
        return this.x62a65b2c0f145432;
      }
      set
      {
        this.x62a65b2c0f145432 = value;
        this.GetColorsFromSystem();
      }
    }

    private void xbff62e1edc3f3404(
      Control xd3311d815ca25f02,
      Control x43bec302f92080b9,
      Graphics x41347a961b838962,
      Rectangle xda73fcb97c77d998)
    {
      Rectangle clientRectangle = xd3311d815ca25f02.ClientRectangle;
      if (true)
        goto label_14;
label_1:
      System.Drawing.Point client1;
      System.Drawing.Point client2;
      Color backgroundColor1;
      Color backgroundColor2;
      using (LinearGradientBrush linearGradientBrush = new LinearGradientBrush(client1, client2, backgroundColor1, backgroundColor2))
      {
        x41347a961b838962.FillRectangle((Brush) linearGradientBrush, xda73fcb97c77d998);
        return;
      }
label_14:
      if (clientRectangle.Width <= 0)
      {
        if (false)
          ;
      }
      else
      {
        if (xd3311d815ca25f02.ClientRectangle.Height <= 0)
          return;
        if (true)
          goto label_8;
        else
          goto label_9;
label_6:
        if (xda73fcb97c77d998.Height <= 0)
          return;
        backgroundColor1 = this.LayoutBackgroundColor1;
        backgroundColor2 = this.LayoutBackgroundColor2;
        client1 = x43bec302f92080b9.PointToClient(xd3311d815ca25f02.PointToScreen(new System.Drawing.Point(0, 0)));
        client2 = x43bec302f92080b9.PointToClient(xd3311d815ca25f02.PointToScreen(new System.Drawing.Point(xd3311d815ca25f02.ClientRectangle.Right, 0)));
        goto label_1;
label_8:
        if (xda73fcb97c77d998.Width <= 0)
          return;
        goto label_6;
label_9:
        if (true)
          goto label_6;
      }
    }

    protected internal override void DrawAutoHideBarBackground(
      Control container,
      Control autoHideBar,
      Graphics graphics,
      Rectangle bounds)
    {
      this.xbff62e1edc3f3404(container, autoHideBar, graphics, bounds);
    }

    protected internal override void DrawSplitter(
      Control container,
      Control control,
      Graphics graphics,
      Rectangle bounds,
      Orientation orientation)
    {
      if (container == null)
        return;
      this.xbff62e1edc3f3404(container, control, graphics, bounds);
    }

    protected internal override void DrawTabStripBackground(
      Control container,
      Control control,
      Graphics graphics,
      Rectangle bounds,
      int selectedTabOffset)
    {
      this.xbff62e1edc3f3404(container, control, graphics, bounds);
    }

    protected override void GetColorsFromSystem()
    {
      WindowsColorScheme x62a65b2c0f145432 = this.x62a65b2c0f145432;
label_28:
      do
      {
        switch (x62a65b2c0f145432)
        {
          case WindowsColorScheme.Automatic:
            goto label_14;
          case WindowsColorScheme.Standard:
            this.ApplyStandardColors();
            continue;
          case WindowsColorScheme.LunaBlue:
            goto label_4;
          case WindowsColorScheme.LunaOlive:
            goto label_5;
          case WindowsColorScheme.LunaSilver:
            goto label_1;
          default:
            goto label_2;
        }
      }
      while (false);
      goto label_2;
label_1:
      this.ApplyLunaSilverColors();
label_2:
      base.GetColorsFromSystem();
      return;
label_4:
      this.ApplyLunaBlueColors();
      goto label_2;
label_5:
      this.ApplyLunaOliveColors();
      goto label_2;
label_14:
      if (!WhidbeyRenderer.x7fb2e1ce54a27086())
        goto label_24;
      else
        goto label_15;
label_13:
      if (true)
        goto label_21;
      else
        goto label_14;
label_15:
      string str1;
      if (x60f3af502af1d663.x2e20a402b77c44dc)
        str1 = x60f3af502af1d663.x4f15c2ab6fab0941;
      else
        goto label_13;
label_17:
      string str2 = str1;
      while (true)
      {
        if (true)
        {
          if (false)
          {
            if (true)
              goto label_28;
            else
              goto label_24;
          }
          else
          {
            if (false)
              return;
            switch (str2)
            {
              case "NormalColor":
                this.ApplyLunaBlueColors();
                goto label_2;
              case "HomeStead":
                this.ApplyLunaOliveColors();
                goto label_2;
              case "Metallic":
                if (true)
                {
                  this.ApplyLunaSilverColors();
                  goto label_2;
                }
                else
                  goto label_13;
              default:
                this.ApplyStandardColors();
                if (true)
                {
                  if (false)
                    return;
                  if (false)
                    continue;
                  goto label_2;
                }
                else
                  goto case "HomeStead";
            }
          }
        }
        else
          goto label_20;
      }
      goto label_2;
label_20:
      if (true)
        goto label_13;
label_21:
      str1 = "none";
      goto label_17;
label_24:
      if (false)
      {
        if (true)
          goto label_20;
      }
      else
        goto label_21;
    }
  }
}
