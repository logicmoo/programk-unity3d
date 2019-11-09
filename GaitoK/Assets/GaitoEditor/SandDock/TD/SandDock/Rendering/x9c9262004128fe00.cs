// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Rendering.x9c9262004128fe00
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace TD.SandDock.Rendering
{
  internal class x9c9262004128fe00 : TypeConverter
  {
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof (string) || destinationType == typeof (InstanceDescriptor))
        return true;
      return base.CanConvertTo(context, destinationType);
    }

    public override object ConvertTo(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value,
      Type destinationType)
    {
      if (destinationType == typeof (string))
      {
        if (false)
        {
          if (false)
            goto label_6;
        }
        else
        {
          if (!(value is string))
            return (object) value.ToString();
          return value;
        }
      }
      if (destinationType != typeof (InstanceDescriptor))
        return base.ConvertTo(context, culture, value, destinationType);
label_6:
      return (object) new InstanceDescriptor((MemberInfo) value.GetType().GetConstructor(Type.EmptyTypes), (ICollection) new object[0], true);
    }

    public override object ConvertFrom(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value)
    {
      if (!(value is string))
        return base.ConvertFrom(context, culture, value);
      string str;
      if ((str = (string) value) != null)
        goto label_14;
label_2:
      return (object) null;
label_14:
      while (!(str == "Everett"))
      {
        if (true)
          goto label_16;
label_7:
        return (object) new MilborneRenderer();
label_16:
        if (true)
          goto label_10;
        else
          goto label_17;
label_3:
        if (!(str == "Milborne"))
        {
          if (str == "Office 2007")
            return (object) new Office2007Renderer();
          goto label_2;
        }
        else
          goto label_7;
label_9:
        return (object) new WhidbeyRenderer();
label_10:
        if (!(str == "Office 2003"))
        {
          if (true)
          {
            if (false)
              continue;
            goto label_21;
          }
          else
            goto label_3;
        }
label_13:
        return (object) new Office2003Renderer();
label_17:
        if (true)
        {
          if (false)
          {
            if (true)
              goto label_9;
          }
          else
            goto label_13;
        }
        else
          continue;
label_21:
        if (true)
        {
          if (!(str == "Whidbey"))
          {
            if (true)
              goto label_3;
            else
              goto label_7;
          }
          else
            goto label_9;
        }
        else
          goto label_3;
      }
      return (object) new EverettRenderer();
    }

    public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof (string))
        return true;
      return base.CanConvertFrom(context, sourceType);
    }

    public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
    {
      return true;
    }

    public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
    {
      return true;
    }

    public override TypeConverter.StandardValuesCollection GetStandardValues(
      ITypeDescriptorContext context)
    {
      ArrayList arrayList = new ArrayList();
      if (context != null)
        goto label_3;
      else
        goto label_5;
label_1:
      do
      {
        arrayList.Add((object) "Everett");
        arrayList.Add((object) "Office 2003");
        if (true)
        {
          arrayList.Add((object) "Whidbey");
          arrayList.Add((object) "Office 2007");
        }
        else
          goto label_4;
      }
      while (false);
      goto label_6;
label_3:
      if (!(context.Instance is DockContainer))
        goto label_1;
label_4:
      arrayList.Add((object) "(default)");
      goto label_1;
label_5:
      if (true)
        goto label_1;
label_6:
      return new TypeConverter.StandardValuesCollection((ICollection) arrayList);
    }
  }
}
