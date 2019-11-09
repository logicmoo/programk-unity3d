// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x245a5abec1c73d3a
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.ComponentModel;
using System.Globalization;
using System.Xml;

namespace TD.SandDock
{
  internal class x245a5abec1c73d3a
  {
    internal static void x0a680eda7ec8bd81(
      SandDockManager x91f347c6e97f1846,
      XmlNode x8a5ce9fbef4b9a09)
    {
      TypeConverter converter1 = TypeDescriptor.GetConverter(typeof (long));
      do
      {
        TypeConverter converter2 = TypeDescriptor.GetConverter(typeof (int));
        TypeConverter converter3 = TypeDescriptor.GetConverter(typeof (System.Drawing.Size));
        TypeConverter converter4 = TypeDescriptor.GetConverter(typeof (System.Drawing.Point));
        DockControl control = x91f347c6e97f1846.FindControl(new Guid(x8a5ce9fbef4b9a09.Attributes["Guid"].Value));
        if (control != null)
        {
          if (x8a5ce9fbef4b9a09.Attributes["LastFocused"] != null)
            goto label_26;
          else
            goto label_24;
label_3:
          if (true)
            control.MetaData.xe62a3d24e0fde928.x71a5d248534c8557 = (int) converter2.ConvertFromString(x8a5ce9fbef4b9a09.Attributes["LastDockContainerIndex"].Value);
          else
            goto label_15;
label_5:
          x245a5abec1c73d3a.xac29055e1acf1a28(control, x8a5ce9fbef4b9a09, (x129cb2a2bdfd0ab2) control.MetaData.xe62a3d24e0fde928, "Docked");
          if (true)
          {
            x245a5abec1c73d3a.xac29055e1acf1a28(control, x8a5ce9fbef4b9a09, control.MetaData.x25e1dbd0e63329bf, "Document");
            x245a5abec1c73d3a.xac29055e1acf1a28(control, x8a5ce9fbef4b9a09, control.MetaData.xba74b873ae2f845a, "Floating");
            if (true)
              continue;
            goto label_19;
          }
          else
            goto label_7;
label_6:
          if (x8a5ce9fbef4b9a09.Attributes["LastFloatingWindowGuid"] != null)
            control.MetaData.x87f4a9b62a380563(new Guid(x8a5ce9fbef4b9a09.Attributes["LastFloatingWindowGuid"].Value));
label_7:
          if (x8a5ce9fbef4b9a09.Attributes["LastDockContainerCount"] == null)
            goto label_9;
label_8:
          control.MetaData.xe62a3d24e0fde928.xd25c313925dc7d4e = (int) converter2.ConvertFromString(x8a5ce9fbef4b9a09.Attributes["LastDockContainerCount"].Value);
label_9:
          if (x8a5ce9fbef4b9a09.Attributes["LastDockContainerIndex"] != null)
          {
            if (true)
              goto label_3;
          }
          else
            goto label_5;
label_10:
          ContainerDockLocation xbcea506a33cf9111 = ContainerDockLocation.Right;
label_11:
          control.MetaData.xfca44c52f41f0e26(xbcea506a33cf9111);
          goto label_6;
label_15:
          while (x8a5ce9fbef4b9a09.Attributes["LastFixedDockSituation"] != null)
          {
            control.MetaData.x0ba17c4cff658fcf((DockSituation) Enum.Parse(typeof (DockSituation), x8a5ce9fbef4b9a09.Attributes["LastFixedDockSituation"].Value));
            if (true)
              break;
          }
          if (x8a5ce9fbef4b9a09.Attributes["LastFixedDockLocation"] != null)
          {
            xbcea506a33cf9111 = (ContainerDockLocation) Enum.Parse(typeof (ContainerDockLocation), x8a5ce9fbef4b9a09.Attributes["LastFixedDockLocation"].Value);
            if (!Enum.IsDefined(typeof (ContainerDockLocation), (object) xbcea506a33cf9111))
            {
              if (true)
                goto label_10;
              else
                goto label_7;
            }
            else
              goto label_11;
          }
          else
            goto label_6;
label_19:
          control.PopupSize = (int) converter2.ConvertFromString(x8a5ce9fbef4b9a09.Attributes["PopupSize"].Value);
label_20:
          control.FloatingLocation = (System.Drawing.Point) converter4.ConvertFromString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["FloatingLocation"].Value);
          control.FloatingSize = (System.Drawing.Size) converter3.ConvertFromString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["FloatingSize"].Value);
          if (x8a5ce9fbef4b9a09.Attributes["LastOpenDockSituation"] != null)
          {
            control.MetaData.xb0e0bc77d88737a8((DockSituation) Enum.Parse(typeof (DockSituation), x8a5ce9fbef4b9a09.Attributes["LastOpenDockSituation"].Value));
            goto label_15;
          }
          else
            goto label_15;
label_21:
          if (x8a5ce9fbef4b9a09.Attributes["PopupSize"] == null)
            goto label_20;
          else
            goto label_19;
label_24:
          if (x8a5ce9fbef4b9a09.Attributes["DockedSize"] != null)
          {
            control.MetaData.x3ef4455ea4965093((int) converter2.ConvertFromString(x8a5ce9fbef4b9a09.Attributes["DockedSize"].Value));
            goto label_21;
          }
          else
            goto label_21;
label_26:
          control.MetaData.x15481da58c59597a(DateTime.FromFileTime((long) converter1.ConvertFromString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, x8a5ce9fbef4b9a09.Attributes["LastFocused"].Value)));
          if (true)
          {
            if (true)
            {
              if (true)
                goto label_24;
              else
                goto label_21;
            }
            else
              goto label_8;
          }
          else
            goto label_3;
        }
        else
          goto label_31;
      }
      while (false);
      return;
label_31:;
    }

    private static void xac29055e1acf1a28(
      DockControl x76b3d9d2638e5ecd,
      XmlNode xeaa9dbf1fba9aca8,
      x129cb2a2bdfd0ab2 x592a8acce305e2d8,
      string x05bcae9c376a7a50)
    {
      TypeConverter converter = TypeDescriptor.GetConverter(typeof (int));
      if (true)
        goto label_8;
      else
        goto label_4;
label_1:
      if (xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "IndexInWindowGroup"] != null)
        goto label_5;
label_2:
      if (xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "SplitPath"] == null)
        return;
      x592a8acce305e2d8.x61743036ad30763d = x245a5abec1c73d3a.xad77aeacfb4bb694(xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "SplitPath"].Value);
      return;
label_4:
      if (true)
        goto label_1;
label_5:
      x592a8acce305e2d8.x8c8f170696764fac = (int) converter.ConvertFromString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "IndexInWindowGroup"].Value);
      goto label_2;
label_8:
      if (xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WorkingSize"] != null)
        goto label_7;
      else
        goto label_9;
label_6:
      if (xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WindowGroupGuid"] != null)
        goto label_10;
      else
        goto label_4;
label_7:
      x592a8acce305e2d8.x3a4e0c379519d4a2 = SandDockManager.ConvertStringToSizeF(xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WorkingSize"].Value);
      goto label_6;
label_9:
      if (true)
        goto label_6;
label_10:
      x592a8acce305e2d8.x703937d70a13725c = new Guid(xeaa9dbf1fba9aca8.Attributes[x05bcae9c376a7a50 + "WindowGroupGuid"].Value);
      goto label_1;
    }

    private static int[] xad77aeacfb4bb694(string xc077f627453a9374)
    {
      TypeConverter converter = TypeDescriptor.GetConverter(typeof (int));
      int[] numArray;
      do
      {
        string[] strArray = xc077f627453a9374.Split('|');
        numArray = new int[strArray.Length];
        for (int index = 0; index < strArray.Length; ++index)
        {
          numArray[index] = (int) converter.ConvertFromString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, strArray[index]);
          if ((uint) index - (uint) index < 0U)
            goto label_6;
        }
      }
      while (false);
label_6:
      return numArray;
    }

    internal static void x4229d31a884b2577(
      DockControl x76b3d9d2638e5ecd,
      XmlTextWriter xbdfb620b7167944b)
    {
      TypeConverter converter1 = TypeDescriptor.GetConverter(typeof (long));
      TypeConverter converter2 = TypeDescriptor.GetConverter(typeof (int));
      TypeConverter converter3 = TypeDescriptor.GetConverter(typeof (System.Drawing.Size));
      TypeConverter converter4 = TypeDescriptor.GetConverter(typeof (System.Drawing.Point));
      xbdfb620b7167944b.WriteStartElement("Window");
      xbdfb620b7167944b.WriteAttributeString("Guid", x76b3d9d2638e5ecd.Guid.ToString());
      do
      {
        xbdfb620b7167944b.WriteAttributeString("LastFocused", converter1.ConvertToString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) x76b3d9d2638e5ecd.MetaData.LastFocused.ToFileTime()));
        do
        {
          xbdfb620b7167944b.WriteAttributeString("DockedSize", converter2.ConvertToString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) x76b3d9d2638e5ecd.MetaData.DockedContentSize));
          xbdfb620b7167944b.WriteAttributeString("PopupSize", converter2.ConvertToString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) x76b3d9d2638e5ecd.PopupSize));
          xbdfb620b7167944b.WriteAttributeString("FloatingLocation", converter4.ConvertToString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) x76b3d9d2638e5ecd.FloatingLocation));
          xbdfb620b7167944b.WriteAttributeString("FloatingSize", converter3.ConvertToString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) x76b3d9d2638e5ecd.FloatingSize));
          xbdfb620b7167944b.WriteAttributeString("LastOpenDockSituation", x76b3d9d2638e5ecd.MetaData.LastOpenDockSituation.ToString());
        }
        while (false);
        xbdfb620b7167944b.WriteAttributeString("LastFixedDockSituation", x76b3d9d2638e5ecd.MetaData.LastFixedDockSituation.ToString());
        xbdfb620b7167944b.WriteAttributeString("LastFixedDockLocation", x76b3d9d2638e5ecd.MetaData.LastFixedDockSide.ToString());
        if (true)
          xbdfb620b7167944b.WriteAttributeString("LastFloatingWindowGuid", x76b3d9d2638e5ecd.MetaData.LastFloatingWindowGuid.ToString());
        else
          goto label_2;
      }
      while (false);
      goto label_4;
label_2:
      xbdfb620b7167944b.WriteEndElement();
      return;
label_4:
      xbdfb620b7167944b.WriteAttributeString("LastDockContainerCount", converter2.ConvertToString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) x76b3d9d2638e5ecd.MetaData.xe62a3d24e0fde928.xd25c313925dc7d4e));
      xbdfb620b7167944b.WriteAttributeString("LastDockContainerIndex", converter2.ConvertToString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) x76b3d9d2638e5ecd.MetaData.xe62a3d24e0fde928.x71a5d248534c8557));
      if (false)
        return;
      x245a5abec1c73d3a.x47161f81513f1258(x76b3d9d2638e5ecd, xbdfb620b7167944b, (x129cb2a2bdfd0ab2) x76b3d9d2638e5ecd.MetaData.xe62a3d24e0fde928, "Docked");
      x245a5abec1c73d3a.x47161f81513f1258(x76b3d9d2638e5ecd, xbdfb620b7167944b, x76b3d9d2638e5ecd.MetaData.x25e1dbd0e63329bf, "Document");
      x245a5abec1c73d3a.x47161f81513f1258(x76b3d9d2638e5ecd, xbdfb620b7167944b, x76b3d9d2638e5ecd.MetaData.xba74b873ae2f845a, "Floating");
      goto label_2;
    }

    private static void x47161f81513f1258(
      DockControl x76b3d9d2638e5ecd,
      XmlTextWriter xbdfb620b7167944b,
      x129cb2a2bdfd0ab2 x592a8acce305e2d8,
      string x05bcae9c376a7a50)
    {
      TypeConverter converter = TypeDescriptor.GetConverter(typeof (int));
      xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "WorkingSize", SandDockManager.ConvertSizeFToString(x592a8acce305e2d8.x3a4e0c379519d4a2));
      xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "WindowGroupGuid", x592a8acce305e2d8.x703937d70a13725c.ToString());
      xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "IndexInWindowGroup", converter.ConvertToString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) x592a8acce305e2d8.x8c8f170696764fac));
      xbdfb620b7167944b.WriteAttributeString(x05bcae9c376a7a50 + "SplitPath", x245a5abec1c73d3a.x8c8bb4495a487cc5(x592a8acce305e2d8.x61743036ad30763d));
    }

    private static string x8c8bb4495a487cc5(int[] x6a80d3cc98596663)
    {
      TypeConverter converter = TypeDescriptor.GetConverter(typeof (int));
      string[] strArray;
      int index;
      do
      {
        if (true)
          goto label_5;
label_2:
        for (; index < x6a80d3cc98596663.Length; ++index)
          strArray[index] = converter.ConvertToString((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) x6a80d3cc98596663[index]);
        continue;
label_5:
        strArray = new string[x6a80d3cc98596663.Length];
        index = 0;
        goto label_2;
      }
      while ((index & 0) != 0);
      return string.Join("|", strArray);
    }
  }
}
