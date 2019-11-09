// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.Wissen
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System;
using System.Collections;
using System.Linq;

namespace de.springwald.gaitobot2
{
  public class Wissen
  {
    private readonly Hashtable _themen;

    public int AnzahlCategories
    {
      get
      {
        return this._themen.Values.Cast<WissenThema>().Sum<WissenThema>((Func<WissenThema, int>) (thema => thema.Categories.Count));
      }
    }

    public Wissen()
    {
      this._themen = new Hashtable();
    }

    public WissenThema GetThema(string themaName)
    {
      if (themaName == null)
        themaName = "*";
      return (WissenThema) this._themen[(object) themaName];
    }

    public void CategoryAufnehmen(WissensCategory category)
    {
      WissenThema wissenThema = (WissenThema) this._themen[(object) category.ThemaName];
      if (wissenThema == null)
      {
        wissenThema = new WissenThema(category.ThemaName);
        this._themen.Add((object) category.ThemaName, (object) wissenThema);
      }
      wissenThema.CategoryAufnehmen(category);
    }
  }
}
