// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.IArbeitsbereichDatei
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using System;
using System.Xml;

namespace GaitoBotEditorCore
{
  public interface IArbeitsbereichDatei
  {
    string ZusatzContentUniqueId { get; set; }

    bool ReadOnly { get; set; }

    bool NurFuerGaitoBotExportieren { get; set; }

    Arbeitsbereich Arbeitsbereich { get; }

    event EventHandler OnChanged;

    string[] Unterverzeichnisse { get; }

    void LiesAusString(string inhalt);

    void LiesAusDatei(string dateiname, string arbeitsbereichRootPfad);

    string Dateiname { get; set; }

    bool HatFehler { get; }

    bool IsChanged { get; }

    void Save(out bool cancel);

    XmlDocument XML { get; }

    string Titel { get; }

    string SortKey { get; }

    void LeerFuellen();
  }
}
