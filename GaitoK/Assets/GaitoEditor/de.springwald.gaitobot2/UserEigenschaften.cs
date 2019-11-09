// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.UserEigenschaften
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System.Collections;
using System.Globalization;
using System.Text;

namespace de.springwald.gaitobot2
{
  public class UserEigenschaften
  {
    private Hashtable _eigenschaften;

    public UserEigenschaften()
    {
      this._eigenschaften = new Hashtable();
    }

    public void Leeren()
    {
      this._eigenschaften = new Hashtable();
    }

    public string GetSerialString()
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (DictionaryEntry dictionaryEntry in this._eigenschaften)
      {
        if (!this.IsEmpty(dictionaryEntry.Key.ToString()))
        {
          if (stringBuilder.Length == 0)
            stringBuilder.AppendFormat("{0}={1}", dictionaryEntry.Key, dictionaryEntry.Value);
          else
            stringBuilder.AppendFormat("|{0}={1}", dictionaryEntry.Key, dictionaryEntry.Value);
        }
      }
      return stringBuilder.ToString();
    }

    public void FillFromSerialString(string inhalte)
    {
      string str1 = inhalte;
      char[] chArray1 = new char[1]{ '|' };
      foreach (string str2 in str1.Split(chArray1))
      {
        char[] chArray2 = new char[1]{ '=' };
        string[] strArray = str2.Split(chArray2);
        if (strArray.Length == 2)
        {
          string str3 = strArray[0].Trim();
          if ((uint) str3.Length > 0U)
            this._eigenschaften[(object) str3] = (object) strArray[1];
        }
      }
    }

    public bool IsEmpty(string name)
    {
      name = name.ToLower();
      return !this._eigenschaften.Contains((object) name) || this._eigenschaften[(object) name] == null || ((string) this._eigenschaften[(object) name]).Trim() == "";
    }

    public string Lesen(string name)
    {
      name = name.ToLower();
      if (!this.IsEmpty(name))
        return (string) this._eigenschaften[(object) name];
      return ResReader.Reader((CultureInfo) null).GetString("unbekannteEigenschaft");
    }

    public void Setzen(string name, string inhalt)
    {
      name = name.ToLower();
      this._eigenschaften[(object) name] = (object) inhalt;
    }
  }
}
