// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.dtd.DTDTestmuster
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System.Text;

namespace de.springwald.xml.dtd
{
  public class DTDTestmuster
  {
    private string _elementName;
    private string _parentElementName;
    private bool _erfolgreich;
    private string _vergleichsStringFuerRegEx;
    private StringBuilder _elementNamenListe;

    public string ElementName
    {
      get
      {
        return this._elementName;
      }
    }

    public string VergleichStringFuerRegEx
    {
      get
      {
        if (this._vergleichsStringFuerRegEx == null)
        {
          this._elementNamenListe.Append("<");
          this._vergleichsStringFuerRegEx = this._elementNamenListe.ToString();
        }
        return this._vergleichsStringFuerRegEx;
      }
    }

    public string Zusammenfassung
    {
      get
      {
        StringBuilder stringBuilder = new StringBuilder();
        if (this._erfolgreich)
          stringBuilder.Append("+ ");
        else
          stringBuilder.Append("- ");
        stringBuilder.Append(this._parentElementName);
        stringBuilder.Append(" (");
        stringBuilder.Append(this.VergleichStringFuerRegEx);
        stringBuilder.Append(")");
        if (this._elementName == null)
          stringBuilder.Append(" [getestet: löschen]");
        else
          stringBuilder.AppendFormat("[getestet: {0}]", (object) this._elementName);
        return stringBuilder.ToString();
      }
    }

    public bool Erfolgreich
    {
      get
      {
        return this._erfolgreich;
      }
      set
      {
        this._erfolgreich = value;
      }
    }

    public DTDTestmuster(string elementName, string parentElementName)
    {
      this._elementNamenListe = new StringBuilder();
      this._elementNamenListe.Append(">");
      this._elementName = elementName;
      this._parentElementName = parentElementName;
      this._erfolgreich = false;
    }

    public void AddElement(string elementName)
    {
      this._elementNamenListe.AppendFormat("-{0}", (object) elementName);
    }
  }
}
