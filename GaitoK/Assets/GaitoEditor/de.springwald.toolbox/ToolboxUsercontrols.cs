// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.ToolboxUsercontrols
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

namespace de.springwald.toolbox
{
  public abstract class ToolboxUsercontrols
  {
    public static void GroesseAnInhaltAnpassen(UserControl steuerelement, int plusX, int plusY)
    {
      Point point = ToolboxUsercontrols.GroesseMaxPoint(steuerelement, plusX, plusY);
      steuerelement.Width = point.X;
      steuerelement.Height = point.Y;
    }

    public static Point GroesseMaxPoint(UserControl steuerelement, int plusX, int plusY)
    {
      Point point = new Point(0, 0);
      foreach (Control control in (ArrangedElementCollection) steuerelement.Controls)
      {
        if (control.Visible)
        {
          ref Point local1 = ref point;
          int x = point.X;
          int left = control.Left;
          Size clientSize = control.ClientSize;
          int width = clientSize.Width;
          int val2_1 = left + width;
          int num1 = Math.Max(x, val2_1);
          local1.X = num1;
          ref Point local2 = ref point;
          int y = point.Y;
          int top = control.Top;
          clientSize = control.ClientSize;
          int height = clientSize.Height;
          int val2_2 = top + height;
          int num2 = Math.Max(y, val2_2);
          local2.Y = num2;
        }
      }
      point.X += plusX;
      point.Y += plusY;
      return point;
    }

    public static float MeasureDisplayStringWidth(
      Graphics graphics,
      string text,
      Font font,
      StringFormat format)
    {
      if (text.Length < 1)
        return 0.0f;
      text = text.Replace(" ", ".");
      if (format == null)
      {
        format = (StringFormat) StringFormat.GenericTypographic.Clone();
        format.FormatFlags |= StringFormatFlags.MeasureTrailingSpaces;
        format.Trimming = StringTrimming.None;
      }
      return graphics.MeasureString(text, font, 64000, format).Width;
    }
  }
}
