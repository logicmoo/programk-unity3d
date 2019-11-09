// Decompiled with JetBrains decompiler
// Type: Divelements.Util.Registration.xbd7c5470fc89975b
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System.ComponentModel;

namespace Divelements.Util.Registration
{
  internal class xbd7c5470fc89975b : License
  {
    internal xbd7c5470fc89975b()
    {
    }

    public virtual bool Evaluation
    {
      get
      {
        return false;
      }
    }

    public virtual bool Locked
    {
      get
      {
        return false;
      }
    }

    public override string LicenseKey
    {
      get
      {
        return "This is a licensed component.";
      }
    }

    public override void Dispose()
    {
    }
  }
}
