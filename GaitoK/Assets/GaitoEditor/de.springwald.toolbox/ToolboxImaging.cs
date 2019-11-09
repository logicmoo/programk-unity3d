// Decompiled with JetBrains decompiler
// Type: ToolboxImaging
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public class ToolboxImaging
{
  public static bool ResizeImageAndUpload(
    FileStream newFile,
    string folderPathAndFilenameNoExtension,
    double maxHeight,
    double maxWidth,
    int qualitaet)
  {
    try
    {
      Image image = Image.FromStream((Stream) newFile);
      int width = image.Width;
      int height = image.Height;
      if ((double) width > maxWidth)
      {
        float num = (float) width / (float) maxWidth;
        width = (int) ((double) width / (double) num);
        height = (int) ((double) height / (double) num);
      }
      if ((double) height > maxHeight)
      {
        float num = (float) height / (float) maxHeight;
        height = (int) ((double) height / (double) num);
        width = (int) ((double) width / (double) num);
      }
      Bitmap bmp = new Bitmap(width, height);
      Graphics graphics = Graphics.FromImage((Image) bmp);
      SolidBrush solidBrush = new SolidBrush(Color.White);
      graphics.FillRectangle((Brush) solidBrush, 0, 0, bmp.Width, bmp.Height);
      graphics.DrawImage(image, 0, 0, bmp.Width, bmp.Height);
      solidBrush.Dispose();
      graphics.Dispose();
      image.Dispose();
      string str = folderPathAndFilenameNoExtension;
      if (!str.ToLower().EndsWith(".jpg"))
        str += ".jpg";
      if (File.Exists(str))
        File.Delete(str);
      ToolboxImaging.SaveImageAsJpg(bmp, str, (long) qualitaet);
      bmp.Dispose();
      return true;
    }
    catch (Exception ex)
    {
      return false;
    }
  }

  public static void SaveImageAsJpg(Bitmap bmp, string filename, long qualitaet)
  {
    EncoderParameters encoderParams = new EncoderParameters(1);
    encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, qualitaet);
    bmp.Save(filename, ToolboxImaging.GetEncoder(ImageFormat.Jpeg), encoderParams);
  }

  public static void SaveImageAsJpg(Bitmap bmp, Stream stream, long qualitaet)
  {
    EncoderParameters encoderParams = new EncoderParameters(1);
    encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, qualitaet);
    bmp.Save(stream, ToolboxImaging.GetEncoder(ImageFormat.Jpeg), encoderParams);
  }

  public static ImageCodecInfo GetEncoder(ImageFormat format)
  {
    foreach (ImageCodecInfo imageDecoder in ImageCodecInfo.GetImageDecoders())
    {
      if (imageDecoder.FormatID == format.Guid)
        return imageDecoder;
    }
    return (ImageCodecInfo) null;
  }
}
