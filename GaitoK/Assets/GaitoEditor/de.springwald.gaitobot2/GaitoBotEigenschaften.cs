// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.GaitoBotEigenschaften
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Serialization;

namespace de.springwald.gaitobot2
{
  public class GaitoBotEigenschaften
  {
    private readonly Dictionary<string, string> _eigenschaften;

    public event EventHandler Changed;

    protected virtual void ChangedEvent()
    {
      if (this.Changed == null)
        return;
      this.Changed((object) this, EventArgs.Empty);
    }

    public string[] Namen
    {
      get
      {
        List<string> stringList = new List<string>();
        foreach (string key in this._eigenschaften.Keys)
        {
          if (!this.IsEmpty(key))
            stringList.Add(key);
        }
        return stringList.ToArray();
      }
    }

    public GaitoBotEigenschaften()
    {
      this._eigenschaften = new Dictionary<string, string>();
    }

    private bool IsEmpty(string name)
    {
      name = name.ToLower();
      return !this._eigenschaften.ContainsKey(name) || this._eigenschaften[name] == null || this._eigenschaften[name].Trim() == "";
    }

    public string Lesen(string name)
    {
      name = name.ToLower();
      if (!this.IsEmpty(name))
        return this._eigenschaften[name];
      return ResReader.Reader((CultureInfo) null).GetString("unbekannteBotEigenschaft");
    }

    public void Setzen(string name, string inhalt)
    {
      name = name.ToLower();
      this._eigenschaften[name] = inhalt;
      this.ChangedEvent();
    }

    public static void SerialisiereListeInXMLDatei(
      string dateiname,
      GaitoBotEigenschaften eigenschaften)
    {
      List<GaitoBotEigenschaft> gaitoBotEigenschaftList = new List<GaitoBotEigenschaft>();
      foreach (string key in eigenschaften._eigenschaften.Keys)
      {
        if (!eigenschaften.IsEmpty(key))
          gaitoBotEigenschaftList.Add(new GaitoBotEigenschaft()
          {
            Name = key,
            Inhalt = eigenschaften.Lesen(key)
          });
      }
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (List<GaitoBotEigenschaft>));
      StreamWriter text = File.CreateText(dateiname);
      xmlSerializer.Serialize((TextWriter) text, (object) gaitoBotEigenschaftList);
      text.Close();
    }

    public static GaitoBotEigenschaften DeSerialisiereListeAusXMLDatei(
      string dateiname)
    {
      XmlSerializer xmlSerializer = new XmlSerializer(typeof (List<GaitoBotEigenschaft>));
      if (!File.Exists(dateiname))
        throw new ApplicationException("GaitoBotEigenschaften-Datei '" + dateiname + "' nicht vorhanden!");
      StreamReader streamReader = File.OpenText(dateiname);
      List<GaitoBotEigenschaft> gaitoBotEigenschaftList = (List<GaitoBotEigenschaft>) xmlSerializer.Deserialize((TextReader) streamReader);
      streamReader.Close();
      GaitoBotEigenschaften botEigenschaften = new GaitoBotEigenschaften();
      foreach (GaitoBotEigenschaft gaitoBotEigenschaft in gaitoBotEigenschaftList)
        botEigenschaften.Setzen(gaitoBotEigenschaft.Name, gaitoBotEigenschaft.Inhalt);
      return botEigenschaften;
    }
  }
}
