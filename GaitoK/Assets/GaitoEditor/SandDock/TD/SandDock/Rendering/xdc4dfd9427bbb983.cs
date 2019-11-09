// Decompiled with JetBrains decompiler
// Type: TD.SandDock.Rendering.xdc4dfd9427bbb983
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.Collections;
using System.ComponentModel;

namespace TD.SandDock.Rendering
{
  internal class xdc4dfd9427bbb983 : x9c9262004128fe00
  {
    public override TypeConverter.StandardValuesCollection GetStandardValues(
      ITypeDescriptorContext context)
    {
      ArrayList arrayList = new ArrayList();
      arrayList.Add((object) "Everett");
      arrayList.Add((object) "Office 2003");
      arrayList.Add((object) "Whidbey");
      arrayList.Add((object) "Milborne");
      if (false)
        ;
      arrayList.Add((object) "Office 2007");
      return new TypeConverter.StandardValuesCollection((ICollection) arrayList);
    }
  }
}
