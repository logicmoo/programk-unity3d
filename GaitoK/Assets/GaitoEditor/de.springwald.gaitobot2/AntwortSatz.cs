// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot2.AntwortSatz
// Assembly: de.springwald.gaitobot2, Version=1.0.6109.32917, Culture=neutral, PublicKeyToken=null
// MVID: C23F13A5-69C4-46E1-8D62-CE84D92940B0
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot2.dll

namespace de.springwald.gaitobot2
{
  public class AntwortSatz
  {
    public string Satz { get; set; }

    public bool IstNotfallAntwort { get; set; }

    public AntwortSatz(string satz, bool istNotfallAntwort)
    {
      this.IstNotfallAntwort = istNotfallAntwort;
      this.Satz = satz;
    }
  }
}
