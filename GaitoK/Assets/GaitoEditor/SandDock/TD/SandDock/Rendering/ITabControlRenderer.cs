// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Rendering.ITabControlRenderer
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace TD.SandDock.Rendering
{
  public interface ITabControlRenderer
  {
    void DrawFakeTabControlBackgroundExtension(
      Graphics graphics,
      Rectangle bounds,
      Color backColor);

    void DrawTabControlButton(
      Graphics graphics,
      Rectangle bounds,
      SandDockButtonType buttonType,
      DrawItemState state);

    void DrawTabControlBackground(
      Graphics graphics,
      Rectangle bounds,
      Color backColor,
      bool client);

    bool ShouldDrawTabControlBackground { get; }

    void DrawTabControlTab(
      Graphics graphics,
      Rectangle bounds,
      Image image,
      string text,
      Font font,
      Color backColor,
      Color foreColor,
      DrawItemState state,
      bool drawSeparator);

    System.Drawing.Size MeasureTabControlTab(
      Graphics graphics,
      Image image,
      string text,
      Font font,
      DrawItemState state);

    void DrawTabControlTabStripBackground(Graphics graphics, Rectangle bounds, Color backColor);

    int TabControlTabExtra { get; }

    int TabControlTabStripHeight { get; }

    int TabControlTabHeight { get; }

    System.Drawing.Size TabControlPadding { get; }

    void StartRenderSession(HotkeyPrefix tabHotKeys);

    void FinishRenderSession();

    bool ShouldDrawControlBorder { get; }
  }
}
