// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.verwaltung.LizenzInfos
// Assembly: de.springwald.gaitobot.verwaltung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 5FCF1B98-3BF2-4EFC-858C-87D71088B318
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.verwaltung.dll

using MultiLang;
using System;

namespace de.springwald.gaitobot.verwaltung
{
  public class LizenzInfos
  {
    public Lizenz.LizenzArten LizenzArt { get; private set; }

    public long MaxKBWissen
    {
      get
      {
        switch (this.LizenzArt)
        {
          case Lizenz.LizenzArten.Free:
            return 512;
          case Lizenz.LizenzArten.Silver:
            return 1024;
          case Lizenz.LizenzArten.Gold:
            return 4096;
          case Lizenz.LizenzArten.Platinum:
            return long.MaxValue;
          default:
            throw new ApplicationException(string.Format("Unbehandelte Lizenzart '{0}'", (object) this.LizenzArt));
        }
      }
    }

    public bool TechEmailSupport
    {
      get
      {
        switch (this.LizenzArt)
        {
          case Lizenz.LizenzArten.Free:
            return false;
          case Lizenz.LizenzArten.Silver:
            return true;
          case Lizenz.LizenzArten.Gold:
            return true;
          case Lizenz.LizenzArten.Platinum:
            return true;
          default:
            throw new ApplicationException(string.Format("Unbehandelte Lizenzart '{0}'", (object) this.LizenzArt));
        }
      }
    }

    public bool AimlEmailSupport
    {
      get
      {
        switch (this.LizenzArt)
        {
          case Lizenz.LizenzArten.Free:
            return false;
          case Lizenz.LizenzArten.Silver:
            return false;
          case Lizenz.LizenzArten.Gold:
            return false;
          case Lizenz.LizenzArten.Platinum:
            return true;
          default:
            throw new ApplicationException(string.Format("Unbehandelte Lizenzart '{0}'", (object) this.LizenzArt));
        }
      }
    }

    public bool SslAllowed
    {
      get
      {
        switch (this.LizenzArt)
        {
          case Lizenz.LizenzArten.Free:
            return false;
          case Lizenz.LizenzArten.Silver:
            return false;
          case Lizenz.LizenzArten.Gold:
            return false;
          case Lizenz.LizenzArten.Platinum:
            return true;
          default:
            throw new ApplicationException(string.Format("Unbehandelte Lizenzart '{0}'", (object) this.LizenzArt));
        }
      }
    }

    public bool NoGaitoBotBranding
    {
      get
      {
        switch (this.LizenzArt)
        {
          case Lizenz.LizenzArten.Free:
            return false;
          case Lizenz.LizenzArten.Silver:
            return false;
          case Lizenz.LizenzArten.Gold:
            return false;
          case Lizenz.LizenzArten.Platinum:
            return true;
          default:
            throw new ApplicationException(string.Format("Unbehandelte Lizenzart '{0}'", (object) this.LizenzArt));
        }
      }
    }

    public string PreisInEuroProMonat
    {
      get
      {
        switch (this.LizenzArt)
        {
          case Lizenz.LizenzArten.Free:
            return (string) null;
          case Lizenz.LizenzArten.Silver:
            return "5,- EUR";
          case Lizenz.LizenzArten.Gold:
            return "29,- EUR";
          case Lizenz.LizenzArten.Platinum:
            return ml.ml_string(9, "auf Anfrage");
          default:
            throw new ApplicationException(string.Format("Unbehandelte Lizenzart '{0}'", (object) this.LizenzArt));
        }
      }
    }

    public string BestellLink
    {
      get
      {
        switch (this.LizenzArt)
        {
          case Lizenz.LizenzArten.Free:
            return (string) null;
          case Lizenz.LizenzArten.Silver:
            return "https://secure.shareit.com/shareit/checkout.html?PRODUCT[300278815]=1&stylefrom=300278814&backlink=http%3A%2F%2Fwww.gaitobot.de";
          case Lizenz.LizenzArten.Gold:
            return "https://secure.shareit.com/shareit/checkout.html?PRODUCT[300278816]=1&stylefrom=300278814&backlink=http%3A%2F%2Fwww.gaitobot.de";
          case Lizenz.LizenzArten.Platinum:
            return "/GaitoBot/Lizenzen/OrderPlatinum.aspx";
          default:
            throw new ApplicationException(string.Format("Unbehandelte Lizenzart '{0}'", (object) this.LizenzArt));
        }
      }
    }

    public string MindestVertragsLaufzeit
    {
      get
      {
        switch (this.LizenzArt)
        {
          case Lizenz.LizenzArten.Free:
            return (string) null;
          case Lizenz.LizenzArten.Silver:
            return ml.ml_string(10, "12 Monate");
          case Lizenz.LizenzArten.Gold:
            return ml.ml_string(10, "12 Monate");
          case Lizenz.LizenzArten.Platinum:
            return ml.ml_string(9, "auf Anfrage");
          default:
            throw new ApplicationException(string.Format("Unbehandelte Lizenzart '{0}'", (object) this.LizenzArt));
        }
      }
    }

    public long MaxWerbefreieGespraecheProTag
    {
      get
      {
        switch (this.LizenzArt)
        {
          case Lizenz.LizenzArten.Free:
            return 0;
          case Lizenz.LizenzArten.Silver:
            return 10;
          case Lizenz.LizenzArten.Gold:
            return 100;
          case Lizenz.LizenzArten.Platinum:
            return long.MaxValue;
          default:
            throw new ApplicationException(string.Format("Unbehandelte Lizenzart '{0}'", (object) this.LizenzArt));
        }
      }
    }

    public LizenzInfos(Lizenz.LizenzArten lizenzArt)
    {
      this.LizenzArt = lizenzArt;
    }
  }
}
