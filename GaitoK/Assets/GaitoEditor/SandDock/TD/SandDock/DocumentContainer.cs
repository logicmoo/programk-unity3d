// Decompiled with JetBrains decompiler
// Type: TD.SandDock.DocumentContainer
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TD.SandDock.Design;

namespace TD.SandDock
{
  [ToolboxItem(false)]
  [Designer(typeof (DocumentContainerDesigner))]
  public class DocumentContainer : DockContainer, IMessageFilter
  {
    private TD.SandDock.Rendering.BorderStyle xacfbd7a08ba56c78 = TD.SandDock.Rendering.BorderStyle.Flat;
    private DocumentOverflowMode x8362acb4106ff84c = DocumentOverflowMode.Scrollable;
    private int xabb78e5e36f68ff6 = -1;
    private const int x3ab50d2ad9712e32 = 256;
    private const int xacaf912f8e96627a = 257;
    private const int xa1cfcecc2bbf1b88 = 9;
    private const int x94f3e1f6055486d7 = 17;
    private const int x0e421de239ce3d08 = 16;
    private bool x26be2ab374407894;
    private DockControl[] xe1c7adce7be56121;

    public DocumentContainer()
    {
      this.Dock = DockStyle.Fill;
      this.BackColor = SystemColors.AppWorkspace;
    }

    internal bool x1ec2ea49664e1074
    {
      get
      {
        return this.xe1c7adce7be56121 != null;
      }
    }

    internal override ControlLayoutSystem xd6284ffe96aec512()
    {
      return (ControlLayoutSystem) new DocumentLayoutSystem();
    }

    internal override bool x0c2484ccd29b8358
    {
      get
      {
        return false;
      }
    }

    private bool xe96ee18ce2c3b205
    {
      get
      {
        if (this.Manager == null)
          return true;
        return this.Manager.AllowKeyboardNavigation;
      }
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      if (keyData == (Keys.Tab | Keys.Control) || keyData == (Keys.Tab | Keys.Shift | Keys.Control))
      {
        if (!this.xe96ee18ce2c3b205)
        {
          int num;
          if ((uint) num - (uint) num > uint.MaxValue)
            ;
        }
        else
        {
          DockControl[] dockControls = this.Manager.GetDockControls(DockSituation.Document);
          while (dockControls.Length >= 2)
          {
            do
            {
              DateTime[] keys = new DateTime[dockControls.Length];
              int index = 0;
              while (true)
              {
                do
                {
                  if (index >= dockControls.Length)
                  {
                    Array.Sort<DateTime, DockControl>(keys, dockControls);
                    this.xe1c7adce7be56121 = dockControls;
                    do
                    {
                      if ((keyData & Keys.Shift) != Keys.Shift)
                      {
                        if (false)
                        {
                          if ((uint) index + (uint) index > uint.MaxValue)
                            goto label_11;
                        }
                        else
                          break;
                      }
                      else
                        goto label_14;
                    }
                    while (false);
                    goto label_6;
label_14:
                    this.xabb78e5e36f68ff6 = this.xe1c7adce7be56121.Length - 1;
                  }
                  else
                    goto label_15;
                }
                while ((index & 0) != 0);
                if ((uint) index + (uint) index <= uint.MaxValue)
                  goto label_7;
label_15:
                keys[index] = dockControls[index].MetaData.LastFocused;
                ++index;
              }
label_6:
              this.xabb78e5e36f68ff6 = 1;
label_7:
              this.xf166541af22172c9();
label_11:;
            }
            while (false);
            if (true)
            {
              Application.AddMessageFilter((IMessageFilter) this);
              return true;
            }
          }
          return true;
        }
      }
      return base.ProcessCmdKey(ref msg, keyData);
    }

    private DockControl xf166541af22172c9()
    {
      if (this.xabb78e5e36f68ff6 > this.xe1c7adce7be56121.Length)
        this.xabb78e5e36f68ff6 = this.xe1c7adce7be56121.Length;
      int index = this.xe1c7adce7be56121.Length - 1 - this.xabb78e5e36f68ff6;
      this.xe1c7adce7be56121[index].x6d1b64d6c637a91d(true);
      return this.xe1c7adce7be56121[index];
    }

    bool IMessageFilter.x4bbcf05291a247a0(ref Message x6088325dec1baa2a)
    {
      if (x6088325dec1baa2a.Msg == 256)
        goto label_29;
label_10:
      DockControl dockControl;
      IntPtr wparam1;
      IntPtr wparam2;
      IntPtr wparam3;
      do
      {
        if (x6088325dec1baa2a.Msg == 256)
          goto label_12;
label_7:
        do
        {
          if (x6088325dec1baa2a.Msg == 257)
            goto label_6;
          else
            goto label_8;
label_5:
          dockControl = this.xf166541af22172c9();
          continue;
label_6:
          wparam2 = x6088325dec1baa2a.WParam;
          if (wparam2.ToInt32() == 17)
            goto label_5;
label_8:
          if (x6088325dec1baa2a.Msg == 256)
          {
            if (((int) (uint) wparam1 | 3) == 0)
              goto label_24;
            else
              goto label_5;
          }
          else
            goto label_30;
        }
        while ((uint) wparam2 - (uint) wparam1 > uint.MaxValue);
        this.xabb78e5e36f68ff6 = -1;
        if ((uint) wparam1 <= uint.MaxValue)
        {
          if (true)
          {
            if ((uint) wparam2 - (uint) wparam3 >= 0U)
              goto label_14;
          }
          else
            goto label_9;
        }
        else
          goto label_29;
label_12:
        wparam3 = x6088325dec1baa2a.WParam;
        if (wparam3.ToInt32() == 16)
        {
          if (true)
            goto label_9;
        }
        else
          goto label_7;
label_14:
        if ((uint) wparam3 >= 0U)
          goto label_17;
      }
      while ((uint) wparam3 + (uint) wparam1 <= uint.MaxValue && (uint) wparam3 - (uint) wparam2 <= uint.MaxValue);
      goto label_16;
label_9:
      return true;
label_17:
      if (true)
        goto label_28;
      else
        goto label_26;
label_16:
      if (wparam1.ToInt32() == 9)
      {
        if ((Control.ModifierKeys & Keys.Shift) == Keys.Shift)
        {
          --this.xabb78e5e36f68ff6;
          if (true)
            goto label_26;
          else
            goto label_28;
        }
        else
          goto label_24;
      }
      else
        goto label_10;
label_23:
      if (this.xabb78e5e36f68ff6 <= this.xe1c7adce7be56121.Length - 1)
      {
        if (true)
          goto label_20;
      }
      else
        goto label_22;
label_19:
      this.xabb78e5e36f68ff6 = this.xe1c7adce7be56121.Length - 1;
      goto label_21;
label_20:
      if (this.xabb78e5e36f68ff6 < 0)
        goto label_19;
label_21:
      this.xf166541af22172c9();
      return true;
label_22:
      this.xabb78e5e36f68ff6 = 0;
      goto label_20;
label_24:
      ++this.xabb78e5e36f68ff6;
      goto label_23;
label_26:
      if (((int) (uint) wparam1 | -1) == 0)
        goto label_10;
      else
        goto label_23;
label_28:
      if (((int) (uint) wparam2 | 3) != 0)
      {
        this.xe1c7adce7be56121 = (DockControl[]) null;
        dockControl.x6d1b64d6c637a91d(true);
        Application.RemoveMessageFilter((IMessageFilter) this);
        return true;
      }
      goto label_30;
label_29:
      wparam1 = x6088325dec1baa2a.WParam;
      if ((uint) wparam1 >= 0U)
        goto label_16;
label_30:
      return false;
    }

    [Description("The type of border to be drawn around the control.")]
    [DefaultValue(typeof (TD.SandDock.Rendering.BorderStyle), "Flat")]
    [Category("Appearance")]
    internal TD.SandDock.Rendering.BorderStyle x64b4c49ed703037e
    {
      get
      {
        return this.xacfbd7a08ba56c78;
      }
      set
      {
        this.xacfbd7a08ba56c78 = value;
        this.OnResize(EventArgs.Empty);
      }
    }

    public override Rectangle DisplayRectangle
    {
      get
      {
        Rectangle displayRectangle = base.DisplayRectangle;
        if (true)
          goto label_4;
label_1:
        TD.SandDock.Rendering.BorderStyle xacfbd7a08ba56c78;
        switch (xacfbd7a08ba56c78)
        {
          case TD.SandDock.Rendering.BorderStyle.Flat:
          case TD.SandDock.Rendering.BorderStyle.RaisedThin:
          case TD.SandDock.Rendering.BorderStyle.SunkenThin:
            displayRectangle.Inflate(-1, -1);
            break;
          case TD.SandDock.Rendering.BorderStyle.RaisedThick:
          case TD.SandDock.Rendering.BorderStyle.SunkenThick:
            displayRectangle.Inflate(-2, -2);
            if (true)
              break;
            goto label_4;
        }
        return displayRectangle;
label_4:
        xacfbd7a08ba56c78 = this.xacfbd7a08ba56c78;
        goto label_1;
      }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      DockControl.xe1da469e4d960f02((Control) this, e.Graphics, this.xacfbd7a08ba56c78);
    }

    internal bool xa957e8f86f5e6115
    {
      get
      {
        return this.x26be2ab374407894;
      }
      set
      {
        this.x26be2ab374407894 = value;
        this.CalculateAllMetricsAndLayout();
      }
    }

    internal DocumentOverflowMode x7d2c5325d16e569d
    {
      get
      {
        return this.x8362acb4106ff84c;
      }
      set
      {
        this.x8362acb4106ff84c = value;
        this.CalculateAllMetricsAndLayout();
      }
    }

    protected override System.Drawing.Size DefaultSize
    {
      get
      {
        return new System.Drawing.Size(300, 300);
      }
    }

    [DefaultValue(typeof (Color), "AppWorkspace")]
    public override Color BackColor
    {
      get
      {
        return base.BackColor;
      }
      set
      {
        base.BackColor = value;
      }
    }

    [DefaultValue(typeof (DockStyle), "Fill")]
    public override DockStyle Dock
    {
      get
      {
        return base.Dock;
      }
      set
      {
        if (value != DockStyle.Fill)
          throw new ArgumentException("Only the Fill dock style is valid for this type of container.");
        base.Dock = value;
      }
    }
  }
}
