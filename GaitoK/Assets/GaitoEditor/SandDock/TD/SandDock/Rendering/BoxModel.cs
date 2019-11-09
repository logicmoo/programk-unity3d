// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Rendering.BoxModel
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.Drawing;

namespace TD.SandDock.Rendering
{
  public class BoxModel
  {
    private BoxEdges x13ebc58426767551;
    private BoxEdges xcaf2e4729806e32b;
    private int x9b0739496f8b5475;
    private int x4d5aabc7a55b12ba;

    public BoxModel()
    {
      this.x13ebc58426767551 = new BoxEdges();
      this.xcaf2e4729806e32b = new BoxEdges();
    }

    public BoxModel(
      int width,
      int height,
      int paddingLeft,
      int paddingTop,
      int paddingRight,
      int paddingBottom,
      int marginLeft,
      int marginTop,
      int marginRight,
      int marginBottom)
    {
      this.x9b0739496f8b5475 = width;
      this.x4d5aabc7a55b12ba = height;
      this.xcaf2e4729806e32b = new BoxEdges(paddingLeft, paddingTop, paddingRight, paddingBottom);
      this.x13ebc58426767551 = new BoxEdges(marginLeft, marginTop, marginRight, marginBottom);
    }

    public int ExtraWidth
    {
      get
      {
        return this.x13ebc58426767551.Left + this.x13ebc58426767551.Right + this.xcaf2e4729806e32b.Left + this.xcaf2e4729806e32b.Right;
      }
    }

    public int ExtraHeight
    {
      get
      {
        return this.x13ebc58426767551.Top + this.x13ebc58426767551.Bottom + this.xcaf2e4729806e32b.Top + this.xcaf2e4729806e32b.Bottom;
      }
    }

    public Rectangle RemovePadding(Rectangle source)
    {
      source.X += this.xcaf2e4729806e32b.Left;
      source.Y += this.xcaf2e4729806e32b.Top;
      source.Width -= this.xcaf2e4729806e32b.Left + this.xcaf2e4729806e32b.Right;
      source.Height -= this.xcaf2e4729806e32b.Top + this.xcaf2e4729806e32b.Bottom;
      return source;
    }

    public Rectangle RemoveMargin(Rectangle source)
    {
      source.X += this.x13ebc58426767551.Left;
      source.Y += this.x13ebc58426767551.Top;
      source.Width -= this.x13ebc58426767551.Left + this.x13ebc58426767551.Right;
      source.Height -= this.x13ebc58426767551.Top + this.x13ebc58426767551.Bottom;
      return source;
    }

    public System.Drawing.Size InnerSize
    {
      get
      {
        return new System.Drawing.Size(this.x9b0739496f8b5475 - this.x13ebc58426767551.Left - this.x13ebc58426767551.Right, this.x4d5aabc7a55b12ba - this.x13ebc58426767551.Top - this.x13ebc58426767551.Bottom);
      }
    }

    public int Height
    {
      get
      {
        return this.x4d5aabc7a55b12ba;
      }
      set
      {
        this.x4d5aabc7a55b12ba = value;
      }
    }

    public int Width
    {
      get
      {
        return this.x9b0739496f8b5475;
      }
      set
      {
        this.x9b0739496f8b5475 = value;
      }
    }

    public BoxEdges Margin
    {
      get
      {
        return this.x13ebc58426767551;
      }
      set
      {
        this.x13ebc58426767551 = value;
      }
    }

    public BoxEdges Padding
    {
      get
      {
        return this.xcaf2e4729806e32b;
      }
      set
      {
        this.xcaf2e4729806e32b = value;
      }
    }
  }
}
