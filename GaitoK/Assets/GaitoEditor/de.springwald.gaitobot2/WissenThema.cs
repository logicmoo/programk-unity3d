// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.WissenThema
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System.Collections;

namespace de.springwald.gaitobot2
{
  public class WissenThema
  {
    private bool _categoriesSortiert = false;
    private bool _starCategoriesSortiert = false;
    private readonly string _name;
    private readonly ArrayList _categories;
    private readonly ArrayList _starCategories;

    public string Name
    {
      get
      {
        return this._name;
      }
    }

    public ArrayList Categories
    {
      get
      {
        if (!this._categoriesSortiert)
        {
          this._categories.Sort((IComparer) new CategorySortierer());
          this._categoriesSortiert = true;
        }
        return this._categories;
      }
    }

    public ArrayList StarCategories
    {
      get
      {
        if (!this._starCategoriesSortiert)
        {
          this._starCategories.Sort((IComparer) new CategorySortierer());
          this._starCategoriesSortiert = true;
        }
        return this._starCategories;
      }
    }

    public WissenThema(string themaName)
    {
      this._name = themaName;
      this._categories = new ArrayList();
      this._starCategories = new ArrayList();
    }

    public void CategoryAufnehmen(WissensCategory category)
    {
      this._categories.Add((object) category);
      if (category.Pattern.Inhalt == "*")
        this._starCategories.Add((object) category);
      this.FlushSortierungen();
    }

    private void FlushSortierungen()
    {
      this._starCategoriesSortiert = false;
      this._categoriesSortiert = false;
    }
  }
}
