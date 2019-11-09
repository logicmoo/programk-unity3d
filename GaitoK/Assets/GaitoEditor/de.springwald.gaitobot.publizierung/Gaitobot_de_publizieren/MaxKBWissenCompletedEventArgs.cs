// Decompiled with JetBrains decompiler
// Type: de.springwald.gaitobot.publizierung.Gaitobot_de_publizieren.MaxKBWissenCompletedEventArgs
// Assembly: de.springwald.gaitobot.publizierung, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 6410624A-016E-45EA-823B-136F27836F7E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.gaitobot.publizierung.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace de.springwald.gaitobot.publizierung.Gaitobot_de_publizieren
{
  [GeneratedCode("System.Web.Services", "4.0.30319.33440")]
  [DebuggerStepThrough]
  [DesignerCategory("code")]
  public class MaxKBWissenCompletedEventArgs : AsyncCompletedEventArgs
  {
    private object[] results;

    internal MaxKBWissenCompletedEventArgs(
      object[] results,
      Exception exception,
      bool cancelled,
      object userState)
      : base(exception, cancelled, userState)
    {
      this.results = results;
    }

    public long Result
    {
      get
      {
        this.RaiseExceptionIfNecessary();
        return (long) this.results[0];
      }
    }
  }
}
