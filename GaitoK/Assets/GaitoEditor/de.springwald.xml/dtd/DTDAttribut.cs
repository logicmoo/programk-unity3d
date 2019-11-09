// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.dtd.DTDAttribut
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using System.Collections.Specialized;

namespace de.springwald.xml.dtd
{
  public class DTDAttribut
  {
    private string _name;
    private DTDAttribut.PflichtArten _pflicht;
    private string _typ;
    private string _standardWert;
    private StringCollection _erlaubteWerte;

    public string Name
    {
      get
      {
        return this._name;
      }
      set
      {
        this._name = value;
      }
    }

    public DTDAttribut.PflichtArten Pflicht
    {
      get
      {
        return this._pflicht;
      }
      set
      {
        this._pflicht = value;
      }
    }

    public StringCollection ErlaubteWerte
    {
      get
      {
        return this._erlaubteWerte;
      }
      set
      {
        this._erlaubteWerte = value;
      }
    }

    public string StandardWert
    {
      get
      {
        return this._standardWert;
      }
      set
      {
        this._standardWert = value;
      }
    }

    public string Typ
    {
      set
      {
        this._typ = value;
      }
      get
      {
        return this._typ;
      }
    }

    public DTDAttribut()
    {
      this._name = "";
      this._pflicht = DTDAttribut.PflichtArten.Optional;
      this._standardWert = "";
      this._erlaubteWerte = new StringCollection();
    }

    public enum PflichtArten
    {
      Pflicht,
      Optional,
      Konstante,
    }
  }
}
