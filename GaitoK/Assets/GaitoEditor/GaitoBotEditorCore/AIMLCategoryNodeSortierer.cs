// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.AIMLCategoryNodeSortierer
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using System;
using System.Collections;
using System.Xml;

namespace GaitoBotEditorCore
{
  public class AIMLCategoryNodeSortierer : IComparer
  {
    public int Compare(object x, object y)
    {
      try
      {
        return ((XmlNode) x).FirstChild.InnerText.CompareTo(((XmlNode) y).FirstChild.InnerText);
      }
      catch (Exception ex)
      {
        return 0;
      }
    }
  }
}
