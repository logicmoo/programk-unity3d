﻿// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.GaitoBotSessionSchritt
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

namespace de.springwald.gaitobot2
{
  public class GaitoBotSessionSchritt
  {
    public string UserEingabe { get; set; }

    public string BotAusgabe { get; set; }

    public string That { get; set; }

    public string Topic { get; set; }

    public GaitoBotSessionSchritt()
    {
      this.That = "*";
      this.Topic = "*";
      this.UserEingabe = "";
      this.BotAusgabe = "";
    }

    public static GaitoBotSessionSchritt CreateBegruessungsSchritt(
      string botBegruessung)
    {
      return new GaitoBotSessionSchritt()
      {
        BotAusgabe = botBegruessung,
        That = "*",
        Topic = "*",
        UserEingabe = ""
      };
    }
  }
}
