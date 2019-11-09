// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.verwaltung.BenutzerVerwaltung
// Assembly: de.springwald.gaitobot.verwaltung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5FCF1B98-3BF2-4EFC-858C-87D71088B318
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.verwaltung.dll

using de.springwald.toolbox;
using de.springwald.toolbox.Serialisierung;
using System;
using System.Collections.Generic;
using System.IO;

namespace de.springwald.gaitobot.verwaltung
{
  public class BenutzerVerwaltung : ObjektSerialisiererVerwaltung<Benutzer>
  {
    public event EventHandler<EventArgs<string>> BenutzerGeaendert;

    public override string[] AlleVorhandenenIDs
    {
      get
      {
        List<string> stringList = new List<string>();
        foreach (string file in Directory.GetFiles(this.ObjektXMLVerzeichnis, "*.xml", SearchOption.AllDirectories))
        {
          char[] chArray = new char[1]{ '\\' };
          string[] strArray = file.Split(chArray);
          string str1 = strArray[strArray.Length - 1];
          string str2 = str1.Substring(0, str1.Length - ".xml".Length);
          stringList.Add(str2);
        }
        return stringList.ToArray();
      }
    }

    public BenutzerVerwaltung(string objektXMLVerzeichnis)
      : base(objektXMLVerzeichnis)
    {
    }

    public override void SpeichereObjektToFile(Benutzer objekt, bool backup, string kontextpostfix)
    {
      base.SpeichereObjektToFile(objekt, backup, kontextpostfix);
      if (this.BenutzerGeaendert == null)
        return;
      this.BenutzerGeaendert((object) this, new EventArgs<string>(objekt.ID));
    }
  }
}
