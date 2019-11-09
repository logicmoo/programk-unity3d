// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLUndoSchritt
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.xml.cursor;

namespace de.springwald.xml.editor
{
  public class XMLUndoSchritt
  {
    protected string _snapshotName;
    protected XMLCursor _cursorVorher;

    public bool IstSnapshot
    {
      get
      {
        return this._snapshotName != null && this._snapshotName != "";
      }
    }

    public string SnapShotName
    {
      get
      {
        return this._snapshotName;
      }
      set
      {
        this._snapshotName = value;
      }
    }

    public XMLCursor CursorVorher
    {
      set
      {
        this._cursorVorher = value.Clone();
      }
      get
      {
        return this._cursorVorher;
      }
    }

    public XMLUndoSchritt()
    {
      this._snapshotName = (string) null;
    }

    public virtual void UnDo()
    {
    }
  }
}
