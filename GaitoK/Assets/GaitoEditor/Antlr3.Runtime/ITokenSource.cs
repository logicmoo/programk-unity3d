// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.ITokenSource
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

namespace Antlr.Runtime
{
  public interface ITokenSource
  {
    IToken NextToken();

    string SourceName { get; }

    string[] TokenNames { get; }
  }
}
