// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x890231ddf317379e
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TD.SandDock
{
  internal abstract class x890231ddf317379e : IDisposable, IMessageFilter
  {
    private DockingHints x48cee1d69929b4fe = DockingHints.TranslucentFill;
    private Rectangle xca9fb28c817965fb = Rectangle.Empty;
    private int x189455fe88a3b711 = 21;
    private const int x3ab50d2ad9712e32 = 256;
    private const int xacaf912f8e96627a = 257;
    private const int x9e72e1fc89a4d09f = 260;
    private const int x0099d1a3582c25df = 261;
    private const int xcd390c5181df4669 = 15;
    private Form xa6607dfd4b3038ad;
    private Control x43bec302f92080b9;
    private bool xd0c8332c4cbc4175;
    private bool x21480c2e0df4efcd;
    private x7a797590a9beb775 x74e209c76c4b5a3e;

    public event EventHandler x868a32060451dd2e;

    public x890231ddf317379e(
      Control control,
      DockingHints dockingHints,
      bool hollow,
      int tabStripSize)
      : this(control, dockingHints, hollow)
    {
      this.x189455fe88a3b711 = tabStripSize;
    }

    public x890231ddf317379e(Control control, DockingHints dockingHints, bool hollow)
    {
label_12:
      this.x43bec302f92080b9 = control;
      this.x21480c2e0df4efcd = hollow;
      bool flag = OSFeature.Feature.IsPresent(OSFeature.LayeredWindows);
      if (dockingHints != DockingHints.TranslucentFill || flag)
        goto label_8;
      else
        goto label_9;
label_4:
      control.MouseCaptureChanged += new EventHandler(this.x772288dc6422a53d);
      Application.AddMessageFilter((IMessageFilter) this);
      while (dockingHints == DockingHints.TranslucentFill)
      {
        this.x74e209c76c4b5a3e = new x7a797590a9beb775(hollow);
        if (true)
        {
          if ((uint) hollow - (uint) hollow <= uint.MaxValue)
            return;
          goto label_12;
        }
      }
      if ((uint) flag - (uint) hollow <= uint.MaxValue)
        return;
label_6:
      this.xa6607dfd4b3038ad = control.FindForm();
      if (this.xa6607dfd4b3038ad != null)
      {
        this.xa6607dfd4b3038ad.Deactivate += new EventHandler(this.xbf6ca0f637696dc9);
        goto label_4;
      }
      else
        goto label_4;
label_8:
      this.x48cee1d69929b4fe = dockingHints;
      if ((uint) flag > uint.MaxValue)
        return;
      goto label_6;
label_9:
      dockingHints = DockingHints.RubberBand;
      if ((uint) flag - (uint) hollow < 0U)
        goto label_4;
      else
        goto label_8;
    }

    private void x772288dc6422a53d(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.Cancel();
    }

    internal static bool xca8cda6e489f8dd8()
    {
      bool flag = false;
      if (((flag ? 1 : 0) | 15) == 0 || Environment.OSVersion.Platform == PlatformID.Win32NT)
        flag = Environment.OSVersion.Version >= new Version(5, 0, 0, 0);
      return flag;
    }

    protected void xe5e4149f382149cc(Rectangle xda73fcb97c77d998, bool x067d6ddeefb41622)
    {
      if (!(this.xca9fb28c817965fb == xda73fcb97c77d998))
        goto label_10;
      else
        goto label_8;
label_2:
      this.xd0c8332c4cbc4175 = x067d6ddeefb41622;
      return;
label_8:
      if (true)
        return;
      goto label_2;
label_10:
      if (this.x48cee1d69929b4fe == DockingHints.RubberBand)
        goto label_9;
label_3:
      if (this.x48cee1d69929b4fe != DockingHints.RubberBand)
      {
        this.x74e209c76c4b5a3e.xf00ba4096f8180b1(xda73fcb97c77d998, x067d6ddeefb41622);
        return;
      }
      if (this.x21480c2e0df4efcd)
        goto label_7;
      else
        goto label_6;
label_1:
      this.xca9fb28c817965fb = xda73fcb97c77d998;
      goto label_2;
label_6:
      x130e0425ae2d4496.xe5e0d1644c72aafd((Control) null, xda73fcb97c77d998);
      goto label_1;
label_7:
      x130e0425ae2d4496.xda2defffc25953e0((Control) null, xda73fcb97c77d998, x067d6ddeefb41622, this.x189455fe88a3b711);
      goto label_1;
label_9:
      this.x45e11bb29ea5a4f9();
      goto label_3;
    }

    protected void x11972e8742c570b8()
    {
      if (this.x48cee1d69929b4fe == DockingHints.RubberBand)
        this.x45e11bb29ea5a4f9();
      else
        this.x74e209c76c4b5a3e.Hide();
    }

    private void x45e11bb29ea5a4f9()
    {
      if (this.xca9fb28c817965fb != Rectangle.Empty)
        goto label_3;
label_2:
      this.xca9fb28c817965fb = Rectangle.Empty;
      return;
label_3:
      if (!this.x21480c2e0df4efcd)
      {
        x130e0425ae2d4496.xe5e0d1644c72aafd((Control) null, this.xca9fb28c817965fb);
        goto label_2;
      }
      else
      {
        x130e0425ae2d4496.xda2defffc25953e0((Control) null, this.xca9fb28c817965fb, this.xd0c8332c4cbc4175, this.x189455fe88a3b711);
        goto label_2;
      }
    }

    public virtual void Commit()
    {
      this.Dispose();
    }

    public virtual void Cancel()
    {
      this.Dispose();
      if (this.x868a32060451dd2e == null)
        return;
      this.x868a32060451dd2e((object) this, EventArgs.Empty);
    }

    public virtual void Dispose()
    {
      if (this.x43bec302f92080b9 != null)
      {
        if (true)
        {
          this.x43bec302f92080b9.MouseCaptureChanged -= new EventHandler(this.x772288dc6422a53d);
          goto label_8;
        }
      }
      else
        goto label_8;
label_2:
      while (false)
      {
        if (true)
          goto label_4;
      }
      goto label_5;
label_4:
      if (this.xa6607dfd4b3038ad != null)
        goto label_7;
label_5:
      Application.RemoveMessageFilter((IMessageFilter) this);
      this.xa6607dfd4b3038ad = (Form) null;
      this.x43bec302f92080b9 = (Control) null;
      return;
label_7:
      this.xa6607dfd4b3038ad.Deactivate -= new EventHandler(this.xbf6ca0f637696dc9);
      goto label_2;
label_8:
      this.x11972e8742c570b8();
      while (this.x48cee1d69929b4fe == DockingHints.TranslucentFill)
      {
        this.x74e209c76c4b5a3e.Dispose();
        this.x74e209c76c4b5a3e = (x7a797590a9beb775) null;
        if (false)
        {
          if (true)
            goto label_7;
        }
        else
          break;
      }
      goto label_4;
    }

    private void xbf6ca0f637696dc9(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.Cancel();
    }

    private void x7ec1a570ae92aafb()
    {
      if (this.x48cee1d69929b4fe != DockingHints.RubberBand)
        return;
      this.x45e11bb29ea5a4f9();
    }

    public abstract void OnMouseMove(System.Drawing.Point position);

    public bool PreFilterMessage(ref Message m)
    {
      if (m.Msg != 15)
        goto label_27;
      else
        goto label_28;
label_6:
      if (m.Msg == 260 || m.Msg == 261)
        goto label_4;
label_1:
      IntPtr wparam1;
      while (m.Msg >= 256 && m.Msg <= 264)
      {
        this.Cancel();
        if ((uint) wparam1 + (uint) wparam1 <= uint.MaxValue)
          return true;
      }
      goto label_30;
label_4:
      wparam1 = m.WParam;
      if (wparam1.ToInt32() == 18)
        return true;
      goto label_1;
label_10:
      IntPtr wparam2;
      IntPtr wparam3;
      if (true)
      {
        if ((uint) wparam2 + (uint) wparam2 < 0U)
        {
          if (true)
            goto label_18;
          else
            goto label_16;
        }
        else if ((uint) wparam3 + (uint) wparam3 <= uint.MaxValue)
          goto label_6;
        else
          goto label_30;
      }
      else
        goto label_16;
label_15:
      if (m.Msg == 257)
        goto label_18;
      else
        goto label_10;
label_16:
      if (wparam3.ToInt32() == 16)
        return true;
      IntPtr num1;
      if ((uint) wparam2 - (uint) num1 <= uint.MaxValue)
      {
        if ((uint) num1 <= uint.MaxValue)
        {
          if (false)
          {
            if ((uint) wparam2 - (uint) wparam2 > uint.MaxValue)
              goto label_30;
            else
              goto label_10;
          }
          else
            goto label_6;
        }
        else
          goto label_24;
      }
      else
        goto label_15;
label_17:
      if (m.Msg != 256)
        goto label_15;
label_18:
      wparam3 = m.WParam;
      goto label_16;
label_20:
      if (wparam2.ToInt32() == 17)
        goto label_26;
      else
        goto label_17;
label_22:
      if (m.Msg != 257)
      {
        IntPtr num2;
        if (((int) (uint) num2 & 0) == 0)
        {
          if ((uint) num1 - (uint) num1 <= uint.MaxValue)
            goto label_17;
          else
            goto label_15;
        }
        else
          goto label_20;
      }
label_23:
      wparam2 = m.WParam;
label_24:
      if (((int) (uint) wparam3 | -1) != 0)
      {
        if (((int) (uint) wparam3 & 0) == 0)
          goto label_20;
      }
      else
        goto label_30;
label_26:
      this.OnMouseMove(Cursor.Position);
      return false;
label_27:
      if (m.Msg != 256)
        goto label_22;
      else
        goto label_23;
label_28:
      this.x7ec1a570ae92aafb();
      IntPtr num3;
      if (((int) (uint) num3 | 15) != 0)
        goto label_27;
      else
        goto label_22;
label_30:
      return false;
    }
  }
}
