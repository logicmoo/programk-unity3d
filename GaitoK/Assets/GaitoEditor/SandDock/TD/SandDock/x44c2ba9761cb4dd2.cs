// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x44c2ba9761cb4dd2
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Globalization;
using System.Reflection;

namespace TD.SandDock
{
  internal class x44c2ba9761cb4dd2 : TypeConverter
  {
    public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof (InstanceDescriptor))
        return true;
      return base.CanConvertTo(context, destinationType);
    }

    private Type MakeArrayType(Type firstType)
    {
      return firstType.Assembly.GetType(firstType.FullName + "[]");
    }

    public override object ConvertTo(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value,
      Type destinationType)
    {
      if (destinationType != null)
      {
label_9:
        if (destinationType == typeof (InstanceDescriptor))
          goto label_6;
        else
          goto label_10;
label_1:
        if (false)
          goto label_7;
label_3:
        if (!(value.GetType().Name == "DocumentLayoutSystem"))
        {
          if (false)
          {
            if (true)
              goto label_8;
            else
              goto label_7;
          }
          else if (true)
            goto label_24;
          else
            goto label_19;
        }
        else
          goto label_18;
label_6:
        if (value.GetType().Name == "ControlLayoutSystem")
          goto label_18;
        else
          goto label_1;
label_7:
        if (true)
        {
          if (false)
            goto label_1;
          else
            goto label_3;
        }
        else
          goto label_6;
label_8:
        ConstructorInfo constructor;
        SizeF sizeF;
        object[] instance;
        object obj;
        return (object) new InstanceDescriptor((MemberInfo) constructor, (ICollection) new object[3]{ (object) sizeF, (object) instance, obj });
label_10:
        if (false)
          goto label_1;
        else
          goto label_24;
label_18:
        Type type1;
        Type type2;
        do
        {
          type1 = value.GetType();
          type1.Assembly.GetType("TD.SandDock.LayoutSystemBase");
          type2 = type1.Assembly.GetType("TD.SandDock.DockControl");
          if (false)
          {
            if (false)
            {
              if (false)
                goto label_7;
            }
            else
              goto label_9;
          }
          else
            goto label_16;
        }
        while (false);
        goto label_6;
label_16:
        PropertyInfo property1;
        do
        {
          PropertyInfo property2;
          do
          {
            if (true)
              goto label_17;
label_15:
            ICollection collection;
            instance = (object[]) Activator.CreateInstance(this.MakeArrayType(type2), (object) collection.Count);
            collection.CopyTo((Array) instance, 0);
            property2 = type1.GetProperty("WorkingSize", BindingFlags.Instance | BindingFlags.Public);
            continue;
label_17:
            constructor = type1.GetConstructor(new Type[3]
            {
              typeof (SizeF),
              this.MakeArrayType(type2),
              type2
            });
            collection = (ICollection) type1.GetProperty("Controls", BindingFlags.Instance | BindingFlags.Public).GetValue(value, (object[]) null);
            goto label_15;
          }
          while (false);
          if (true)
          {
            sizeF = (SizeF) property2.GetValue(value, (object[]) null);
            property1 = type1.GetProperty("SelectedControl", BindingFlags.Instance | BindingFlags.Public);
            if (true)
              goto label_11;
          }
          else
            goto label_11;
        }
        while (false);
        goto label_19;
label_11:
        obj = property1.GetValue(value, (object[]) null);
        goto label_8;
label_24:
        return base.ConvertTo(context, culture, value, destinationType);
      }
label_19:
      throw new ArgumentNullException();
    }
  }
}
