// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.Serialisierung.ObjektSerialisierVerwaltungTiefe2`1
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System.Collections.Generic;
using System.IO;

namespace de.springwald.toolbox.Serialisierung
{
  public class ObjektSerialisierVerwaltungTiefe2<TObjektTyp> : ObjektSerialisiererVerwaltung<TObjektTyp>
  {
    protected const int AnzahlZeichenAusIdFuerVerzeichnis = 2;

    public override string[] AlleVorhandenenIDs
    {
      get
      {
        List<string> stringList = new List<string>();
        foreach (string directory in Directory.GetDirectories(this.ObjektXMLVerzeichnis))
        {
          foreach (string file in Directory.GetFiles(directory, "*.xml"))
          {
            FileInfo fileInfo = new FileInfo(file);
            stringList.Add(fileInfo.Name.Replace(".xml", ""));
          }
        }
        return stringList.ToArray();
      }
    }

    public ObjektSerialisierVerwaltungTiefe2(string objektXmlVerzeichnis)
      : base(objektXmlVerzeichnis)
    {
    }

    public override void SpeichereObjektToFile(
      TObjektTyp objekt,
      bool backup,
      string backupKontextpostfix)
    {
      this.IdWennNoetigVergeben(objekt);
      string objektVerzeichnis = this.GetObjektVerzeichnis(((IObjektSerialisierVerwaltbar) (object) objekt).ID);
      if (!Directory.Exists(objektVerzeichnis))
        Directory.CreateDirectory(objektVerzeichnis);
      base.SpeichereObjektToFile(objekt, backup, backupKontextpostfix);
    }

    public virtual string GetObjektVerzeichnis(string id)
    {
      return Path.Combine(this.ObjektXMLVerzeichnis, string.Format("{0}\\", (object) id.Substring(0, 2)));
    }

    public override string GetObjektDateiname(string id)
    {
      return Path.Combine(this.GetObjektVerzeichnis(id), string.Format("{0}.xml", (object) id));
    }
  }
}
