// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.verwaltung.ChatbotVerwaltung
// Assembly: de.springwald.gaitobot.verwaltung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5FCF1B98-3BF2-4EFC-858C-87D71088B318
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.verwaltung.dll

using de.springwald.toolbox;
using de.springwald.toolbox.Serialisierung;
using System;
using System.IO;

namespace de.springwald.gaitobot.verwaltung
{
  public class ChatbotVerwaltung : ObjektSerialisiererVerwaltung<Chatbot>
  {
    public event EventHandler<EventArgs<string>> ChatbotGeaendert;

    public ChatbotVerwaltung(string objektXMLVerzeichnis)
      : base(objektXMLVerzeichnis)
    {
    }

    public string GetAIMLVerzeichnis(string id)
    {
      return Path.Combine(this.ObjektXMLVerzeichnis, string.Format("{0}\\aiml\\", (object) id));
    }

    public string GetBesucherDatenVerzeichnis(string id)
    {
      return Path.Combine(this.ObjektXMLVerzeichnis, string.Format("{0}\\besucher\\", (object) id));
    }

    public string GetChatbotVerzeichnis(string id)
    {
      return Path.Combine(this.ObjektXMLVerzeichnis, string.Format("{0}\\", (object) id));
    }

    public string GetLoggingDatenverzeichnis(string id)
    {
      return Path.Combine(this.ObjektXMLVerzeichnis, string.Format("{0}\\logging\\", (object) id));
    }

    public override string GetObjektDateiname(string id)
    {
      return Path.Combine(this.ObjektXMLVerzeichnis, string.Format("{0}\\chatbot.xml", (object) id));
    }

    public override void SpeichereObjektToFile(Chatbot objekt, bool backup, string kontextpostfix)
    {
      if (objekt.ID == null)
        objekt.ID = this.NaechsteFreieID();
      string path = Path.Combine(this.ObjektXMLVerzeichnis, string.Format("{0}\\", (object) objekt.ID));
      if (!Directory.Exists(path))
      {
        Directory.CreateDirectory(path);
        Directory.CreateDirectory(this.GetAIMLVerzeichnis(objekt.ID));
        Directory.CreateDirectory(this.GetBesucherDatenVerzeichnis(objekt.ID));
        Directory.CreateDirectory(this.GetLoggingDatenverzeichnis(objekt.ID));
      }
      base.SpeichereObjektToFile(objekt, backup, kontextpostfix);
      if (this.ChatbotGeaendert == null)
        return;
      this.ChatbotGeaendert((object) this, new EventArgs<string>(objekt.ID));
    }
  }
}
