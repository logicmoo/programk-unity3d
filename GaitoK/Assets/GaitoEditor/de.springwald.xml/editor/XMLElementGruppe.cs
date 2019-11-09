// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLElementGruppe
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System.Collections;

namespace de.springwald.xml.editor
{
  public class XMLElementGruppe
  {
    private Hashtable _elemente;
    private string _titel;
    private bool _standardMaessigZusammengeklappt;

    public string Titel
    {
      get
      {
        return this._titel;
      }
    }

    public bool StandardMaessigZusammengeklappt
    {
      get
      {
        return this._standardMaessigZusammengeklappt;
      }
    }

    public XMLElementGruppe(string titel, bool standardMaessigZusammengeklappt)
    {
      this._titel = titel;
      this._elemente = new Hashtable();
      this._standardMaessigZusammengeklappt = standardMaessigZusammengeklappt;
    }

    public void AddElementName(string name)
    {
      this._elemente.Add((object) name.ToLower(), (object) null);
    }

    public bool ContainsElement(string name)
    {
      return this._elemente.ContainsKey((object) name.ToLower());
    }
  }
}
