// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.ParserRuleReturnScope`1
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

namespace Antlr.Runtime
{
  public class ParserRuleReturnScope<TToken> : IRuleReturnScope<TToken>, IRuleReturnScope
  {
    private TToken _start;
    private TToken _stop;

    public TToken Start
    {
      get
      {
        return this._start;
      }
      set
      {
        this._start = value;
      }
    }

    public TToken Stop
    {
      get
      {
        return this._stop;
      }
      set
      {
        this._stop = value;
      }
    }

    object IRuleReturnScope.Start
    {
      get
      {
        return (object) this.Start;
      }
    }

    object IRuleReturnScope.Stop
    {
      get
      {
        return (object) this.Stop;
      }
    }
  }
}
