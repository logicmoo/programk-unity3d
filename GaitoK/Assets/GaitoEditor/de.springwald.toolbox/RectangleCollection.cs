// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.RectangleCollection
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;
using System.Collections;
using System.Drawing;

namespace de.springwald.toolbox
{
  public class RectangleCollection : CollectionBase
  {
    public Rectangle this[int index]
    {
      get
      {
        return (Rectangle) this.List[index];
      }
      set
      {
        this.List[index] = (object) value;
      }
    }

    public int Add(Rectangle value)
    {
      return this.List.Add((object) value);
    }

    public int IndexOf(Rectangle value)
    {
      return this.List.IndexOf((object) value);
    }

    public void Insert(int index, Rectangle value)
    {
      this.List.Insert(index, (object) value);
    }

    public void Remove(Rectangle value)
    {
      this.List.Remove((object) value);
    }

    public bool Contains(Rectangle value)
    {
      return this.List.Contains((object) value);
    }

    protected override void OnInsert(int index, object value)
    {
      if (!(value is Rectangle))
        throw new ArgumentException("value must be of type Rectangle.", nameof (value));
    }

    protected override void OnRemove(int index, object value)
    {
      if (!(value is Rectangle))
        throw new ArgumentException("value must be of type Rectangle.", nameof (value));
    }

    protected override void OnSet(int index, object oldValue, object newValue)
    {
      if (!(newValue is Rectangle))
        throw new ArgumentException("newValue must be of type Rectangle.", nameof (newValue));
    }

    protected override void OnValidate(object value)
    {
      if (!(value is Rectangle))
        throw new ArgumentException("value must be of type Rectangle.");
    }
  }
}
