// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLElementGruppenListe
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System.Collections;

namespace de.springwald.xml.editor
{
  public class XMLElementGruppenListe
  {
    private ArrayList _gruppen;

    public int Count
    {
      get
      {
        return this._gruppen.Count;
      }
    }

    public XMLElementGruppe this[int index]
    {
      get
      {
        return (XMLElementGruppe) this._gruppen[index];
      }
      set
      {
        this._gruppen[index] = (object) value;
      }
    }

    public XMLElementGruppenListe()
    {
      this._gruppen = new ArrayList();
    }

    public void Dispose()
    {
      this._gruppen.Clear();
      this._gruppen = (ArrayList) null;
    }

    public void Add(XMLElementGruppe gruppe)
    {
      this._gruppen.Add((object) gruppe);
    }

    public void Remove(XMLElementGruppe gruppe)
    {
      this._gruppen.Remove((object) gruppe);
    }
  }
}
