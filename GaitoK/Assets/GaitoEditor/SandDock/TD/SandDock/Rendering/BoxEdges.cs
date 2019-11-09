// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Rendering.BoxEdges
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

namespace TD.SandDock.Rendering
{
  public class BoxEdges
  {
    private int xa447fc54e41dfe06;
    private int xc941868c59399d3e;
    private int xaf9a0436a70689de;
    private int xfc2074a859a5db8c;

    public BoxEdges()
    {
    }

    public BoxEdges(int left, int top, int right, int bottom)
    {
      this.xa447fc54e41dfe06 = left;
      this.xc941868c59399d3e = top;
      this.xfc2074a859a5db8c = right;
      this.xaf9a0436a70689de = bottom;
    }

    public int Left
    {
      get
      {
        return this.xa447fc54e41dfe06;
      }
    }

    public int Top
    {
      get
      {
        return this.xc941868c59399d3e;
      }
    }

    public int Right
    {
      get
      {
        return this.xfc2074a859a5db8c;
      }
    }

    public int Bottom
    {
      get
      {
        return this.xaf9a0436a70689de;
      }
    }
  }
}
