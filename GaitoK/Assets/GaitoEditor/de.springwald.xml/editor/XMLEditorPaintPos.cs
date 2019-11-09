// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLEditorPaintPos
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

namespace de.springwald.xml.editor
{
  public class XMLEditorPaintPos
  {
    public int ZeilenStartX { get; set; }

    public int ZeilenEndeX { get; set; }

    public int PosX { get; set; }

    public int PosY { get; set; }

    public int HoeheAktZeile { get; set; }

    public int BisherMaxX { get; set; }

    public XMLEditorPaintPos()
    {
      this.ZeilenStartX = 0;
      this.ZeilenEndeX = 0;
      this.PosX = 0;
      this.PosY = 0;
      this.HoeheAktZeile = 0;
      this.BisherMaxX = this.PosX;
    }

    public XMLEditorPaintPos Clone()
    {
      return new XMLEditorPaintPos()
      {
        ZeilenStartX = this.ZeilenStartX,
        ZeilenEndeX = this.ZeilenEndeX,
        PosX = this.PosX,
        PosY = this.PosY,
        HoeheAktZeile = this.HoeheAktZeile,
        BisherMaxX = this.BisherMaxX
      };
    }
  }
}
