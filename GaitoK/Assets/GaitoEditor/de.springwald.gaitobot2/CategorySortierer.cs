// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.CategorySortierer
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System.Collections;

namespace de.springwald.gaitobot2
{
  public class CategorySortierer : IComparer
  {
    public int Compare(object x, object y)
    {
      int length1 = ((WissensCategory) x).Pattern.Inhalt.Length;
      int length2 = ((WissensCategory) y).Pattern.Inhalt.Length;
      if (length1 == length2)
        return -(((WissensCategory) x).That.Inhalt.Length - ((WissensCategory) y).That.Inhalt.Length);
      return -(length1 - length2);
    }

    public int Compare2(object x, object y)
    {
      int length1 = ((WissensCategory) x).That.Inhalt.Length;
      int length2 = ((WissensCategory) y).That.Inhalt.Length;
      if (length1 == length2)
        return -(((WissensCategory) x).Pattern.Inhalt.Length - ((WissensCategory) y).Pattern.Inhalt.Length);
      return -(length1 - length2);
    }
  }
}
