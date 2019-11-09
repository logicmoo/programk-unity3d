// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.verwaltung.LizenzVerwaltung
// Assembly: de.springwald.gaitobot.verwaltung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5FCF1B98-3BF2-4EFC-858C-87D71088B318
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.verwaltung.dll

using de.springwald.toolbox;
using de.springwald.toolbox.Serialisierung;
using System;

namespace de.springwald.gaitobot.verwaltung
{
  public class LizenzVerwaltung : ObjektSerialisiererVerwaltung<Lizenz>
  {
    public event EventHandler<EventArgs<string>> LizenzGeaendert;

    public LizenzVerwaltung(string objektXMLVerzeichnis)
      : base(objektXMLVerzeichnis)
    {
    }

    public override void SpeichereObjektToFile(Lizenz objekt, bool backup, string kontextpostfix)
    {
      base.SpeichereObjektToFile(objekt, backup, kontextpostfix);
      if (this.LizenzGeaendert == null)
        return;
      this.LizenzGeaendert((object) this, new EventArgs<string>(objekt.ID));
    }
  }
}
