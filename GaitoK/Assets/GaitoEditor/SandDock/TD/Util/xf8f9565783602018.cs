// Decompiled with JetBrains decompiler
// Type: TD.Util.xf8f9565783602018
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TD.Util
{
  internal class xf8f9565783602018 : IDisposable
  {
    private bool xeefb7b23d49f09bc = true;
    private const int x77bf04ec211c4a37 = 16;
    private const int x339acab5bf3e83ae = 64;
    private const int xdbb7427772b219d6 = 128;
    private const int xb644deafcaa222c4 = 2;
    private const int xb8a822e576f3bf60 = 1;
    private Control x43bec302f92080b9;
    private bool x364c1e3b189d47fe;
    private bool x0e75cd3866dbb930;
    private Point xa639e9f791585165;
    private xf8f9565783602018.xab7df35839b7399e xa6607dfd4b3038ad;
    private Timer x537a4001020fd4c7;
    private Form x9238f6a5f034aeb5;

    public event xf8f9565783602018.x58986a4a0b75e5b5 x9b21ee8e7ceaada3;

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(
      IntPtr hWnd,
      int hWndInsertAfter,
      int x,
      int y,
      int cx,
      int cy,
      int flags);

    public xf8f9565783602018(Control control)
    {
      if (true)
        goto label_4;
label_1:
      this.xa6607dfd4b3038ad.MouseMove += new MouseEventHandler(this.x1aaaf41037533886);
      this.x537a4001020fd4c7 = new Timer();
      this.x537a4001020fd4c7.Interval = SystemInformation.DoubleClickTime;
      this.x537a4001020fd4c7.Tick += new EventHandler(this.x79a58a5d2c65c5a4);
      return;
label_4:
      if (true)
        goto label_5;
label_2:
      control.FontChanged += new EventHandler(this.xb27df3b0091b2a36);
      this.xa6607dfd4b3038ad = new xf8f9565783602018.xab7df35839b7399e(this);
      goto label_7;
label_5:
      this.x43bec302f92080b9 = control;
      if (true)
      {
        control.MouseMove += new MouseEventHandler(this.x51529e0468abe27e);
        control.MouseLeave += new EventHandler(this.x664829383a59617c);
        control.MouseDown += new MouseEventHandler(this.x1c8953a8a8447816);
        control.MouseWheel += new MouseEventHandler(this.x5e1cbc67acfe3317);
        control.Disposed += new EventHandler(this.x77d9086325b6e538);
      }
      if (true)
        goto label_2;
label_7:
      if (true)
        goto label_1;
    }

    public void Dispose()
    {
      if (this.x0e75cd3866dbb930)
        return;
      if (true)
        goto label_6;
label_2:
      this.x537a4001020fd4c7.Tick -= new EventHandler(this.x79a58a5d2c65c5a4);
      this.x537a4001020fd4c7.Dispose();
      this.x0e75cd3866dbb930 = true;
      return;
label_6:
      this.x47c79a4d207183de();
      this.xa6607dfd4b3038ad.MouseMove -= new MouseEventHandler(this.x1aaaf41037533886);
      this.xa6607dfd4b3038ad.Dispose();
      this.xa6607dfd4b3038ad = (xf8f9565783602018.xab7df35839b7399e) null;
      if (false)
        return;
      if (true)
      {
        this.x43bec302f92080b9.MouseMove -= new MouseEventHandler(this.x51529e0468abe27e);
        this.x43bec302f92080b9.MouseLeave -= new EventHandler(this.x664829383a59617c);
        this.x43bec302f92080b9.MouseDown -= new MouseEventHandler(this.x1c8953a8a8447816);
        this.x43bec302f92080b9.MouseWheel -= new MouseEventHandler(this.x5e1cbc67acfe3317);
        if (true)
        {
          this.x43bec302f92080b9.Disposed -= new EventHandler(this.x77d9086325b6e538);
          this.x43bec302f92080b9.FontChanged -= new EventHandler(this.xb27df3b0091b2a36);
        }
        this.x43bec302f92080b9 = (Control) null;
        goto label_2;
      }
      else
        goto label_2;
    }

    public bool xa6e4f463e64a5987
    {
      get
      {
        return this.xeefb7b23d49f09bc;
      }
      set
      {
        this.xeefb7b23d49f09bc = value;
      }
    }

    public bool x9ab519b46dd91330
    {
      get
      {
        return this.xa6607dfd4b3038ad.x9ab519b46dd91330;
      }
      set
      {
        this.xa6607dfd4b3038ad.x9ab519b46dd91330 = value;
      }
    }

    private static bool x7fb2e1ce54a27086()
    {
      bool flag = false;
      if (Environment.OSVersion.Platform == PlatformID.Win32NT)
        flag = Environment.OSVersion.Version >= new Version(5, 1, 0, 0);
      return flag;
    }

    public void x4402a69f607144e3(Point xb9c2cfae130d9256, string xb41faee6912a2313)
    {
      this.xa6607dfd4b3038ad.Text = xb41faee6912a2313;
      do
      {
        Size size = Size.Ceiling(this.xa6607dfd4b3038ad.x0a8f2a18d3b53839(xb41faee6912a2313));
        size.Height += 4;
        size.Width += 4;
label_35:
        xb9c2cfae130d9256.Y += 19;
        Screen screen = Screen.FromPoint(xb9c2cfae130d9256);
label_30:
        if (xb9c2cfae130d9256.X < screen.Bounds.Left)
          goto label_28;
        else
          goto label_31;
label_1:
        if (this.x9238f6a5f034aeb5 == null)
          continue;
        goto label_4;
label_3:
        if (false)
          goto label_7;
label_4:
        this.x9238f6a5f034aeb5.Deactivate += new EventHandler(this.xdef19f2ef265bf1e);
        this.xa6607dfd4b3038ad.Owner = this.x9238f6a5f034aeb5;
        if (true)
        {
          if (true)
            goto label_29;
          else
            goto label_1;
        }
        else
          goto label_10;
label_7:
        this.x9238f6a5f034aeb5 = this.x624fa8b017460890(this.x43bec302f92080b9);
        if (false)
          goto label_32;
label_8:
        if (false)
        {
          if (true)
            goto label_3;
        }
        else
          goto label_1;
label_10:
        xf8f9565783602018.SetWindowPos(this.xa6607dfd4b3038ad.Handle, -1, xb9c2cfae130d9256.X, xb9c2cfae130d9256.Y, size.Width, size.Height, 80);
        this.xa6607dfd4b3038ad.Invalidate();
        if (true)
        {
          this.x364c1e3b189d47fe = true;
          if (this.x9238f6a5f034aeb5 != null)
          {
            if (true)
            {
              this.x9238f6a5f034aeb5.Deactivate -= new EventHandler(this.xdef19f2ef265bf1e);
              if (true)
              {
                if (false)
                  goto label_33;
                else
                  goto label_7;
              }
              else
                goto label_4;
            }
            else
              goto label_3;
          }
          else
            goto label_7;
        }
        else
          continue;
label_17:
        if (xb9c2cfae130d9256.Y + size.Height > screen.Bounds.Bottom)
        {
          if (false)
          {
            if (true)
              goto label_23;
          }
          else if (true)
          {
            xb9c2cfae130d9256.Y = screen.Bounds.Bottom - size.Height;
            if (xb9c2cfae130d9256.Y >= screen.Bounds.Top)
            {
              ++xb9c2cfae130d9256.X;
              goto label_10;
            }
            else
              goto label_40;
          }
          else
            goto label_37;
        }
        else
          goto label_10;
label_20:
        if (true)
          goto label_22;
label_21:
        xb9c2cfae130d9256.Y = screen.Bounds.Top;
        goto label_17;
label_22:
        if (xb9c2cfae130d9256.Y < screen.Bounds.Top)
          goto label_21;
        else
          goto label_17;
label_23:
        if (xb9c2cfae130d9256.X >= screen.Bounds.Left)
          goto label_22;
        else
          goto label_14;
label_25:
        if (xb9c2cfae130d9256.X + size.Width > screen.Bounds.Right)
        {
          xb9c2cfae130d9256.X = screen.Bounds.Right - size.Width;
          if (false)
            goto label_8;
          else
            goto label_39;
        }
        else
          goto label_20;
label_28:
        xb9c2cfae130d9256.X = screen.Bounds.Left;
        goto label_32;
label_31:
        if (true)
        {
          if (true)
          {
            if (true)
              goto label_25;
            else
              goto label_39;
          }
          else
            goto label_35;
        }
label_32:
        if (false)
          goto label_30;
        else
          goto label_25;
label_39:
        if (true)
          goto label_23;
        else
          goto label_1;
      }
      while (false);
      return;
label_33:
      return;
label_29:
      return;
label_40:
      return;
label_14:
      return;
label_37:;
    }

    public void x47c79a4d207183de()
    {
      this.xa6607dfd4b3038ad.Owner = (Form) null;
      this.xa6607dfd4b3038ad.Visible = false;
      this.x364c1e3b189d47fe = false;
      if (this.x9238f6a5f034aeb5 == null)
        return;
      this.x9238f6a5f034aeb5.Deactivate -= new EventHandler(this.xdef19f2ef265bf1e);
      this.x9238f6a5f034aeb5 = (Form) null;
    }

    private void x51529e0468abe27e(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
    {
      string xb41faee6912a2313;
      if (xfbf34718e704c6bc.Button != MouseButtons.None)
      {
        if (true)
          return;
        goto label_12;
      }
      else
      {
        if (!this.x364c1e3b189d47fe)
        {
          Point point = new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y);
          if (!(point != this.xa639e9f791585165))
          {
            if (true)
            {
              if (true)
                ;
              return;
            }
            if (false)
              return;
            goto label_18;
          }
          else
          {
            this.xa639e9f791585165 = point;
            goto label_8;
          }
        }
        else
          goto label_25;
label_16:
        this.x47c79a4d207183de();
        return;
label_17:
        if (xb41faee6912a2313 == null)
          goto label_16;
label_18:
        if (xb41faee6912a2313.Length != 0)
        {
          if (true)
          {
            if (true)
              goto label_26;
          }
          else
            goto label_17;
        }
        else
          goto label_16;
label_25:
        xb41faee6912a2313 = this.x9b21ee8e7ceaada3(new Point(xfbf34718e704c6bc.X, xfbf34718e704c6bc.Y));
        if (true)
          goto label_17;
label_26:
        if (false)
          return;
        goto label_12;
      }
label_8:
      if (false)
        return;
      this.x537a4001020fd4c7.Enabled = false;
      this.x537a4001020fd4c7.Enabled = true;
      return;
label_12:
      if (true)
      {
        if (xb41faee6912a2313.Length == 0 || !(xb41faee6912a2313 != this.xa6607dfd4b3038ad.Text))
          return;
        this.x4402a69f607144e3(Cursor.Position, xb41faee6912a2313);
      }
      else
        goto label_8;
    }

    private void x79a58a5d2c65c5a4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.x537a4001020fd4c7.Enabled = false;
label_24:
      Point client = this.x43bec302f92080b9.PointToClient(Cursor.Position);
      Rectangle clientRectangle = this.x43bec302f92080b9.ClientRectangle;
      bool flag;
      if ((uint) flag + (uint) flag > uint.MaxValue || !clientRectangle.Contains(client))
        return;
label_23:
      string xb41faee6912a2313 = this.x9b21ee8e7ceaada3(client);
      if (xb41faee6912a2313 == null || xb41faee6912a2313.Length == 0)
        return;
      Form form = this.x624fa8b017460890(this.x43bec302f92080b9);
      Form activeForm = Form.ActiveForm;
      if (form == null)
        goto label_9;
      else
        goto label_18;
label_6:
      int num;
      if (activeForm != form)
      {
        num = activeForm == form.Owner ? 1 : 0;
        goto label_10;
      }
label_7:
      num = 1;
      goto label_10;
label_9:
      num = 0;
label_10:
      flag = num != 0;
      if ((uint) flag + (uint) flag < 0U)
        return;
      if (true)
      {
        if ((uint) flag <= uint.MaxValue && !flag)
          return;
        while (!this.x43bec302f92080b9.Visible)
        {
          if (true)
            return;
          if ((uint) flag - (uint) flag > uint.MaxValue)
          {
            if (((flag ? 1 : 0) & 0) == 0)
            {
              if (true)
              {
                if (false)
                  goto label_7;
                else
                  goto label_7;
              }
              else
                goto label_23;
            }
          }
          else
            goto label_24;
        }
        this.x4402a69f607144e3(Cursor.Position, xb41faee6912a2313);
        return;
      }
      goto label_6;
label_18:
      if (true)
      {
        if (activeForm != null)
          goto label_6;
        else
          goto label_9;
      }
      else if (true)
        goto label_6;
    }

    private Form x624fa8b017460890(Control x3c4da2980d043c95)
    {
      while (x3c4da2980d043c95.Parent != null)
        x3c4da2980d043c95 = x3c4da2980d043c95.Parent;
      return x3c4da2980d043c95 as Form;
    }

    private void x664829383a59617c(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      if (this.x364c1e3b189d47fe)
        this.x47c79a4d207183de();
      this.x537a4001020fd4c7.Enabled = false;
    }

    private void x1c8953a8a8447816(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
    {
      if (this.x364c1e3b189d47fe)
        this.x47c79a4d207183de();
      this.x537a4001020fd4c7.Enabled = false;
    }

    private void x5e1cbc67acfe3317(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
    {
      if (this.x364c1e3b189d47fe)
        this.x47c79a4d207183de();
      this.x537a4001020fd4c7.Enabled = false;
    }

    private void x1aaaf41037533886(object xe0292b9ed559da7d, MouseEventArgs xfbf34718e704c6bc)
    {
      this.x47c79a4d207183de();
    }

    private void xdef19f2ef265bf1e(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.x47c79a4d207183de();
    }

    private void x77d9086325b6e538(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.Dispose();
    }

    private void xb27df3b0091b2a36(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.xa6607dfd4b3038ad.Font = this.x43bec302f92080b9.Font;
    }

    private class xab7df35839b7399e : Form
    {
      private const int x3e8b9d6faeff6586 = 32;
      private const int x2b7f5d3ca7ec1edf = -2147483648;
      private const int xd708511d2241a4fb = 131072;
      private const int x836e53e090609b16 = 4132;
      private xf8f9565783602018 xac1c850120b1f254;
      private TextFormatFlags xae3b2752a89e7464;

      [DllImport("user32.dll")]
      private static extern bool SystemParametersInfo(
        int nAction,
        int nParam,
        ref int i,
        int nUpdate);

      public xab7df35839b7399e(xf8f9565783602018 tooltips)
      {
        this.xac1c850120b1f254 = tooltips;
label_4:
        this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
        do
        {
          this.Font = tooltips.x43bec302f92080b9.Font;
          this.xae3b2752a89e7464 = TextFormatFlags.NoClipping | TextFormatFlags.VerticalCenter;
          this.ShowInTaskbar = false;
          this.FormBorderStyle = FormBorderStyle.None;
          this.ControlBox = false;
          this.StartPosition = FormStartPosition.Manual;
          if (false)
            goto label_4;
        }
        while (false);
      }

      public bool x9ab519b46dd91330
      {
        get
        {
          return (this.xae3b2752a89e7464 & TextFormatFlags.HidePrefix) != TextFormatFlags.HidePrefix;
        }
        set
        {
          if (value)
          {
            do
            {
              this.xae3b2752a89e7464 |= TextFormatFlags.HidePrefix;
            }
            while (false);
            this.xae3b2752a89e7464 &= ~TextFormatFlags.NoPrefix;
          }
          else
          {
            this.xae3b2752a89e7464 &= ~TextFormatFlags.HidePrefix;
            this.xae3b2752a89e7464 |= TextFormatFlags.NoPrefix;
          }
        }
      }

      public SizeF x0a8f2a18d3b53839(string xb41faee6912a2313)
      {
        using (Graphics graphics = this.CreateGraphics())
        {
          SizeF sizeF = (SizeF) TextRenderer.MeasureText((IDeviceContext) graphics, xb41faee6912a2313, this.Font, new Size(int.MaxValue, int.MaxValue), this.xae3b2752a89e7464);
          sizeF.Width -= 2f;
          sizeF.Height += 2f;
          return sizeF;
        }
      }

      protected override CreateParams CreateParams
      {
        get
        {
          CreateParams createParams = base.CreateParams;
label_6:
          if (this.xac1c850120b1f254 != null)
            goto label_4;
          else
            goto label_7;
label_1:
          if (true)
            goto label_8;
label_2:
          if (xf8f9565783602018.xab7df35839b7399e.x3b1aa41797c18588)
          {
            createParams.ClassStyle |= 131072;
            if (true)
            {
              if (false)
                goto label_1;
              else
                goto label_8;
            }
            else
              goto label_6;
          }
          else
            goto label_8;
label_4:
          if (this.xac1c850120b1f254.xa6e4f463e64a5987)
            goto label_2;
          else
            goto label_1;
label_7:
          if (false)
            goto label_1;
label_8:
          return createParams;
        }
      }

      private static bool x3b1aa41797c18588
      {
        get
        {
          int i = 0;
          if (!xf8f9565783602018.x7fb2e1ce54a27086())
            return false;
          xf8f9565783602018.xab7df35839b7399e.SystemParametersInfo(4132, 0, ref i, 0);
          return Convert.ToBoolean(i);
        }
      }

      protected override void Dispose(bool disposing)
      {
        int num = disposing ? 1 : 0;
        base.Dispose(disposing);
      }

      protected override void OnPaint(PaintEventArgs e)
      {
        e.Graphics.FillRectangle(SystemBrushes.Info, this.ClientRectangle);
        if (!SystemInformation.HighContrast)
          goto label_4;
label_2:
        Pen pen1 = SystemPens.InfoText;
label_3:
        Pen pen2 = pen1;
        e.Graphics.DrawLine(pen2, this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientRectangle.Right, this.ClientRectangle.Top);
        e.Graphics.DrawLine(pen2, this.ClientRectangle.Left, this.ClientRectangle.Top, this.ClientRectangle.Left, this.ClientRectangle.Bottom);
        e.Graphics.DrawLine(SystemPens.InfoText, this.ClientRectangle.Left, this.ClientRectangle.Bottom - 1, this.ClientRectangle.Right, this.ClientRectangle.Bottom - 1);
        if (true)
        {
          e.Graphics.DrawLine(SystemPens.InfoText, this.ClientRectangle.Right - 1, this.ClientRectangle.Top, this.ClientRectangle.Right - 1, this.ClientRectangle.Bottom);
          Rectangle clientRectangle = this.ClientRectangle;
          clientRectangle.Inflate(-2, -2);
          TextRenderer.DrawText((IDeviceContext) e.Graphics, this.Text, this.Font, clientRectangle, SystemColors.InfoText, this.xae3b2752a89e7464);
          return;
        }
        goto label_2;
label_4:
        pen1 = SystemPens.Control;
        goto label_3;
      }
    }

    internal delegate string x58986a4a0b75e5b5(Point location);
  }
}
