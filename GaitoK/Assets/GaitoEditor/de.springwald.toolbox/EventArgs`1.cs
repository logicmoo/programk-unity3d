﻿// Decompiled with JetBrains decompiler
// Type: de.springwald.toolbox.EventArgs`1
// Assembly: de.springwald.toolbox, Version=1.0.6109.32916, Culture=neutral, PublicKeyToken=null
// MVID: AE6915FE-1CED-4089-BE03-CEA59CF13600
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.toolbox.dll

using System;

namespace de.springwald.toolbox
{
  public class EventArgs<T> : EventArgs
  {
    private T m_value;

    public EventArgs(T value)
    {
      this.m_value = value;
    }

    public T Value
    {
      get
      {
        return this.m_value;
      }
    }
  }
}
