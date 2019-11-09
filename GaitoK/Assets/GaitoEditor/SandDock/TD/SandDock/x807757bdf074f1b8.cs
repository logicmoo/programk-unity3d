// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x807757bdf074f1b8
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
using System.Windows.Forms;

namespace TD.SandDock
{
  internal class x807757bdf074f1b8 : TypeConverter
  {
    public override bool CanConvertTo(ITypeDescriptorContext context, System.Type destinationType)
    {
      if (destinationType == typeof (InstanceDescriptor))
        return true;
      return base.CanConvertTo(context, destinationType);
    }

    private System.Type MakeArrayType(System.Type firstType)
    {
      return firstType.Assembly.GetType(firstType.FullName + "[]");
    }

    public override object ConvertTo(
      ITypeDescriptorContext context,
      CultureInfo culture,
      object value,
      System.Type destinationType)
    {
      if (destinationType != null)
      {
        if (destinationType == typeof (InstanceDescriptor))
        {
          if (false)
            goto label_8;
label_3:
          System.Type type;
          if (value.GetType().Name == "SplitLayoutSystem")
          {
            type = value.GetType();
            goto label_8;
          }
label_7:
          if (true)
            goto label_11;
          else
            goto label_9;
label_8:
          System.Type baseType = type.BaseType;
          MemberInfo constructor = (MemberInfo) type.GetConstructor(new System.Type[3]{ typeof (SizeF), typeof (Orientation), this.MakeArrayType(baseType) });
          ICollection collection = (ICollection) type.GetProperty("LayoutSystems", BindingFlags.Instance | BindingFlags.Public).GetValue(value, (object[]) null);
          object[] instance = (object[]) Activator.CreateInstance(this.MakeArrayType(baseType), (object) collection.Count);
          collection.CopyTo((Array) instance, 0);
          if (true)
          {
            if (true)
            {
              SizeF sizeF = (SizeF) type.GetProperty("WorkingSize", BindingFlags.Instance | BindingFlags.Public).GetValue(value, (object[]) null);
              Orientation orientation = (Orientation) type.GetProperty("SplitMode", BindingFlags.Instance | BindingFlags.Public).GetValue(value, (object[]) null);
              if (true)
                return (object) new InstanceDescriptor(constructor, (ICollection) new object[3]{ (object) sizeF, (object) orientation, (object) instance });
              goto label_7;
            }
            else
              goto label_3;
          }
          else
            goto label_9;
        }
label_11:
        return base.ConvertTo(context, culture, value, destinationType);
      }
label_9:
      throw new ArgumentNullException();
    }
  }
}
