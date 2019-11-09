// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Rendering.RendererBase
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
  [TypeConverter(typeof (x9c9262004128fe00))]
  public abstract class RendererBase : ITabControlRenderer, IDisposable
  {
    private System.Drawing.Size x95dac044246123ac = new System.Drawing.Size(16, 16);
    private bool x106e6f99e65ccd35;

    public event EventHandler MetricsChanged;

    public RendererBase()
    {
      SystemEvents.UserPreferenceChanged += new UserPreferenceChangedEventHandler(this.x985016783c040310);
      this.GetColorsFromSystem();
    }

    public void Dispose()
    {
      SystemEvents.UserPreferenceChanged -= new UserPreferenceChangedEventHandler(this.x985016783c040310);
    }

    protected virtual void OnMetricsChanged(EventArgs e)
    {
      if (this.x8b0d947fe3d04bb9 == null)
        return;
      this.x8b0d947fe3d04bb9((object) this, e);
    }

    public virtual void ModifyDefaultWindowColors(
      DockControl window,
      ref System.Drawing.Color backColor,
      ref System.Drawing.Color borderColor)
    {
    }

    private void x985016783c040310(
      object xe0292b9ed559da7d,
      UserPreferenceChangedEventArgs xfbf34718e704c6bc)
    {
      if (xfbf34718e704c6bc.Category != UserPreferenceCategory.Color || this.x106e6f99e65ccd35)
        return;
      this.GetColorsFromSystem();
      this.x106e6f99e65ccd35 = false;
    }

    public bool CustomColors
    {
      get
      {
        return this.x106e6f99e65ccd35;
      }
      set
      {
        this.x106e6f99e65ccd35 = value;
        if (this.x106e6f99e65ccd35)
          return;
        this.GetColorsFromSystem();
      }
    }

    protected internal static System.Drawing.Color InterpolateColors(
      System.Drawing.Color color1,
      System.Drawing.Color color2,
      float percentage)
    {
      int r1 = (int) color1.R;
      int num1;
      if ((uint) num1 < 0U)
      {
        int num2;
        if ((uint) num2 >= 0U)
          goto label_4;
      }
      else
        goto label_6;
label_3:
      int r2 = (int) color2.R;
      int g1 = (int) color2.G;
      int b1 = (int) color2.B;
      int a1 = (int) color2.A;
      byte num3 = Convert.ToByte((float) r1 + (float) (r2 - r1) * percentage);
      int g2;
      byte num4;
      int b2;
      byte num5;
      int a2;
      byte num6;
      do
      {
        num4 = Convert.ToByte((float) g2 + (float) (g1 - g2) * percentage);
        num5 = Convert.ToByte((float) b2 + (float) (b1 - b2) * percentage);
        num6 = Convert.ToByte((float) a2 + (float) (a1 - a2) * percentage);
      }
      while ((uint) g2 > uint.MaxValue);
      return System.Drawing.Color.FromArgb((int) num6, (int) num3, (int) num4, (int) num5);
label_4:
      b2 = (int) color1.B;
      byte num7;
      if (((int) num7 & 0) == 0)
      {
        a2 = (int) color1.A;
        goto label_3;
      }
      else
        goto label_3;
label_6:
      g2 = (int) color1.G;
      goto label_4;
    }

    protected virtual void GetColorsFromSystem()
    {
      this.x106e6f99e65ccd35 = false;
    }

    protected internal virtual Rectangle AdjustDockControlClientBounds(
      ControlLayoutSystem layoutSystem,
      DockControl control,
      Rectangle clientBounds)
    {
      return clientBounds;
    }

    protected internal abstract BoxModel TabStripMetrics { get; }

    protected internal abstract BoxModel TabMetrics { get; }

    protected internal abstract BoxModel TitleBarMetrics { get; }

    public virtual System.Drawing.Size ImageSize
    {
      get
      {
        return this.x95dac044246123ac;
      }
      set
      {
        this.x95dac044246123ac = value;
        this.OnMetricsChanged(EventArgs.Empty);
      }
    }

    protected internal abstract TabTextDisplayMode TabTextDisplay { get; }

    protected internal abstract System.Drawing.Size MeasureDocumentStripTab(
      Graphics graphics,
      Image image,
      string text,
      Font font,
      DrawItemState state);

    protected internal abstract System.Drawing.Size MeasureTabStripTab(
      Graphics graphics,
      Image image,
      string text,
      Font font,
      DrawItemState state);

    protected internal abstract void DrawDocumentStripBackground(
      Graphics graphics,
      Rectangle bounds);

    protected internal abstract void DrawControlClientBackground(
      Graphics graphics,
      Rectangle bounds,
      System.Drawing.Color backColor);

    protected internal abstract void DrawDocumentClientBackground(
      Graphics graphics,
      Rectangle bounds,
      System.Drawing.Color backColor);

    protected internal abstract void DrawDocumentStripTab(
      Graphics graphics,
      Rectangle bounds,
      Rectangle contentBounds,
      Image image,
      string text,
      Font font,
      System.Drawing.Color backColor,
      System.Drawing.Color foreColor,
      DrawItemState state,
      bool drawSeparator);

    protected internal abstract void DrawDockContainerBackground(
      Graphics graphics,
      DockContainer container,
      Rectangle bounds);

    protected internal abstract void DrawDocumentStripButton(
      Graphics graphics,
      Rectangle bounds,
      SandDockButtonType buttonType,
      DrawItemState state);

    protected internal abstract int DocumentTabExtra { get; }

    protected internal abstract int DocumentTabSize { get; }

    protected internal abstract int DocumentTabStripSize { get; }

    public abstract void StartRenderSession(HotkeyPrefix hotKeys);

    protected internal abstract void DrawTabStripBackground(
      Control container,
      Control control,
      Graphics graphics,
      Rectangle bounds,
      int selectedTabOffset);

    protected internal abstract void DrawSplitter(
      Control container,
      Control control,
      Graphics graphics,
      Rectangle bounds,
      Orientation orientation);

    protected internal abstract void DrawTabStripTab(
      Graphics graphics,
      Rectangle bounds,
      Image image,
      string text,
      Font font,
      System.Drawing.Color backColor,
      System.Drawing.Color foreColor,
      DrawItemState state,
      bool drawSeparator);

    protected internal abstract void DrawAutoHideBarBackground(
      Control container,
      Control control,
      Graphics graphics,
      Rectangle bounds);

    protected internal abstract void DrawCollapsedTab(
      Graphics graphics,
      Rectangle bounds,
      DockSide dockSide,
      Image image,
      string text,
      Font font,
      System.Drawing.Color backColor,
      System.Drawing.Color foreColor,
      DrawItemState state,
      bool vertical);

    protected internal abstract void DrawTitleBarBackground(
      Graphics graphics,
      Rectangle bounds,
      bool focused);

    protected internal abstract void DrawTitleBarText(
      Graphics graphics,
      Rectangle bounds,
      bool focused,
      string text,
      Font font);

    protected internal abstract void DrawTitleBarButton(
      Graphics graphics,
      Rectangle bounds,
      SandDockButtonType buttonType,
      DrawItemState state,
      bool focused,
      bool toggled);

    public abstract void FinishRenderSession();

    public virtual bool ShouldDrawControlBorder
    {
      get
      {
        return true;
      }
    }

    public virtual void DrawFakeTabControlBackgroundExtension(
      Graphics graphics,
      Rectangle bounds,
      System.Drawing.Color backColor)
    {
      using (SolidBrush solidBrush = new SolidBrush(backColor))
        graphics.FillRectangle((Brush) solidBrush, bounds);
    }

    public virtual void DrawTabControlButton(
      Graphics graphics,
      Rectangle bounds,
      SandDockButtonType buttonType,
      DrawItemState state)
    {
      this.DrawDocumentStripButton(graphics, bounds, buttonType, state);
    }

    public virtual void DrawTabControlBackground(
      Graphics graphics,
      Rectangle bounds,
      System.Drawing.Color backColor,
      bool client)
    {
      using (SolidBrush solidBrush = new SolidBrush(backColor))
        graphics.FillRectangle((Brush) solidBrush, bounds);
    }

    public virtual bool ShouldDrawTabControlBackground
    {
      get
      {
        return false;
      }
    }

    public abstract System.Drawing.Size TabControlPadding { get; }

    public virtual System.Drawing.Size MeasureTabControlTab(
      Graphics graphics,
      Image image,
      string text,
      Font font,
      DrawItemState state)
    {
      return this.MeasureDocumentStripTab(graphics, image, text, font, state);
    }

    public virtual void DrawTabControlTab(
      Graphics graphics,
      Rectangle bounds,
      Image image,
      string text,
      Font font,
      System.Drawing.Color backColor,
      System.Drawing.Color foreColor,
      DrawItemState state,
      bool drawSeparator)
    {
      this.DrawDocumentStripTab(graphics, bounds, bounds, image, text, font, backColor, foreColor, state, drawSeparator);
    }

    public virtual void DrawTabControlTabStripBackground(
      Graphics graphics,
      Rectangle bounds,
      System.Drawing.Color backColor)
    {
      this.DrawDocumentStripBackground(graphics, bounds);
    }

    public virtual int TabControlTabExtra
    {
      get
      {
        return this.DocumentTabExtra;
      }
    }

    public virtual int TabControlTabStripHeight
    {
      get
      {
        return this.DocumentTabStripSize;
      }
    }

    public virtual int TabControlTabHeight
    {
      get
      {
        return this.DocumentTabSize;
      }
    }
  }
}
