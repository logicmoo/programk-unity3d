// Decompiled with JetBrains decompiler
// Type: GaitoBotEditorCore.WorkflowKlickbereich
// Assembly: GaitoBotEditorCore, Version=2.0.6109.32924, Culture=neutral, PublicKeyToken=null
// MVID: 931F1E00-3A73-48E8-BFF3-5F2BA6F612DD
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\GaitoBotEditorCore.dll

using System.Drawing;

namespace GaitoBotEditorCore
{
  public class WorkflowKlickbereich
  {
    private AIMLCategory _category;
    private Rectangle _bereich;

    public AIMLCategory Category
    {
      get
      {
        return this._category;
      }
    }

    public Rectangle Bereich
    {
      get
      {
        return this._bereich;
      }
    }

    public WorkflowKlickbereich(AIMLCategory category, Rectangle bereich)
    {
      this._category = category;
      this._bereich = bereich;
    }
  }
}
