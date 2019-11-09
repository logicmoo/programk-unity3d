// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.dtd.DTDEntity
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

namespace de.springwald.xml.dtd
{
  public class DTDEntity
  {
    private string _name;
    private string _inhalt;
    private bool _istErsetzungsEntity;

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

    public string Inhalt
    {
      get
      {
        return this._inhalt;
      }
      set
      {
        this._inhalt = value;
      }
    }

    public bool IstErsetzungsEntity
    {
      get
      {
        return this._istErsetzungsEntity;
      }
      set
      {
        this._istErsetzungsEntity = value;
      }
    }
  }
}
