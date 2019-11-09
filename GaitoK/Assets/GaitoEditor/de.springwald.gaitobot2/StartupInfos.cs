// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.StartupInfos
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace de.springwald.gaitobot2
{
  public class StartupInfos
  {
    private List<DictionaryEntry> _ersetzungen;
    private List<string> _satztrenner;

    public GaitoBotEigenschaften BotEigenschaften { get; private set; }

    public List<DictionaryEntry> PersonAustauscher { get; private set; }

    public List<DictionaryEntry> Person2Austauscher { get; private set; }

    public List<DictionaryEntry> GeschlechtsAustauscher { get; private set; }

    public List<DictionaryEntry> Ersetzungen { get; private set; }

    public List<string> SatzTrenner { get; private set; }

    public StartupInfos()
    {
      this.Clear();
    }

    public void Clear()
    {
      this.BotEigenschaften = new GaitoBotEigenschaften();
      this.Ersetzungen = new List<DictionaryEntry>()
      {
        new DictionaryEntry((object) " \\", (object) " "),
        new DictionaryEntry((object) "&QUOT;", (object) ""),
        new DictionaryEntry((object) "/", (object) " "),
        new DictionaryEntry((object) "&AMP;", (object) " "),
        new DictionaryEntry((object) "  ", (object) " ")
      };
      this.GeschlechtsAustauscher = new List<DictionaryEntry>();
      this.PersonAustauscher = new List<DictionaryEntry>();
      this.Person2Austauscher = new List<DictionaryEntry>();
      this.SatzTrenner = new List<string>()
      {
        ";",
        ".",
        "?",
        "!"
      };
    }

    public void FuegeEintraegeAusStartupDateiHinzu(XmlDocument startupDateiInhalt)
    {
      this.MerkeErsetzungen(startupDateiInhalt.SelectNodes("/gaitobot-startup/substitutions/input/substitute"), this.Ersetzungen);
      this.MerkeErsetzungen(startupDateiInhalt.SelectNodes("/gaitobot-startup/substitutions/gender/substitute"), this.GeschlechtsAustauscher);
      this.MerkeErsetzungen(startupDateiInhalt.SelectNodes("/gaitobot-startup/substitutions/person/substitute"), this.PersonAustauscher);
      this.MerkeErsetzungen(startupDateiInhalt.SelectNodes("/gaitobot-startup/substitutions/person2/substitute"), this.Person2Austauscher);
      foreach (XmlElement selectNode in startupDateiInhalt.SelectNodes("/gaitobot-startup/bot/property"))
      {
        XmlAttribute attribute1 = selectNode.Attributes["name"];
        XmlAttribute attribute2 = selectNode.Attributes["value"];
        if (attribute2 != null && !string.IsNullOrEmpty(attribute2.Value) && (attribute1 != null && !string.IsNullOrEmpty(attribute1.Value)))
          this.BotEigenschaften.Setzen(attribute1.Value, attribute2.Value);
      }
      foreach (XmlNode selectNode in startupDateiInhalt.SelectNodes("/gaitobot-startup/sentence-splitters/splitter"))
      {
        XmlAttribute attribute = selectNode.Attributes["value"];
        if (attribute != null && !string.IsNullOrEmpty(attribute.Value))
          this.SatzTrenner.Add(attribute.Value);
      }
    }

    public void FuegeEintraegeAusStartupDateienInVerzeichnisHinzu(string verzeichnis)
    {
      foreach (string file in Directory.GetFiles(verzeichnis, "*.startup"))
        this.StartUpDateiVerarbeiten(file);
    }

    private void StartUpDateiVerarbeiten(string startupDateiname)
    {
      XmlDocument startupDateiInhalt = new XmlDocument();
      startupDateiInhalt.PreserveWhitespace = false;
      startupDateiInhalt.Load(startupDateiname);
      this.FuegeEintraegeAusStartupDateiHinzu(startupDateiInhalt);
    }

    private void MerkeErsetzungen(XmlNodeList ersetzungenXmlNodes, List<DictionaryEntry> zielListe)
    {
      foreach (XmlElement ersetzungenXmlNode in ersetzungenXmlNodes)
      {
        XmlAttribute attribute1 = ersetzungenXmlNode.Attributes["find"];
        XmlAttribute attribute2 = ersetzungenXmlNode.Attributes["replace"];
        if (attribute1 != null && !string.IsNullOrEmpty(attribute1.Value) && attribute2 != null && !string.IsNullOrEmpty(attribute2.Value))
          zielListe.Add(new DictionaryEntry((object) attribute1.Value, (object) attribute2.Value));
      }
    }
  }
}
