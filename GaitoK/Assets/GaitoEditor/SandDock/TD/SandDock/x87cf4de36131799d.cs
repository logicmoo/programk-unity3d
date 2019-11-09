// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x87cf4de36131799d
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using TD.Util;

namespace TD.SandDock
{
  internal class x87cf4de36131799d : Control
  {
    private x10ac79a4257c7f52 x2ee8392f53a01b93;
    private ControlLayoutSystem x6e150040c8d97700;
    private x7fc004d490c8a431 x372569d2ea29984e;
    private Rectangle x21ed2ecc088ef4e4;
    private Rectangle x59f159fe47159543;
    private xf8f9565783602018 xac1c850120b1f254;

    public x87cf4de36131799d(x10ac79a4257c7f52 bar)
    {
      if (true)
        goto label_3;
label_1:
      if (false)
        return;
      this.xac1c850120b1f254 = new xf8f9565783602018((Control) this);
      this.xac1c850120b1f254.xa6e4f463e64a5987 = false;
      this.xac1c850120b1f254.x9b21ee8e7ceaada3 += new xf8f9565783602018.x58986a4a0b75e5b5(this.xa3a7472ac4e61f76);
      this.BackColor = SystemColors.Control;
      return;
label_3:
      this.x2ee8392f53a01b93 = bar;
      this.SetStyle(ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);
      this.SetStyle(ControlStyles.Selectable, false);
      goto label_1;
    }

    private void x81dc33c66d5e1e33(System.Drawing.Point xcb09bd0cee4909a3)
    {
      this.x372569d2ea29984e = new x7fc004d490c8a431(this.x2ee8392f53a01b93, this, xcb09bd0cee4909a3);
      this.x372569d2ea29984e.x868a32060451dd2e += new EventHandler(this.xfae511fd7c4fb447);
      this.x372569d2ea29984e.x67ecc0d0e7c9a202 += new x7fc004d490c8a431.ResizingManagerFinishedEventHandler(this.xc555e814c1720baf);
    }

    private void xd5979b8834306b81()
    {
      this.x372569d2ea29984e.x868a32060451dd2e -= new EventHandler(this.xfae511fd7c4fb447);
      this.x372569d2ea29984e.x67ecc0d0e7c9a202 -= new x7fc004d490c8a431.ResizingManagerFinishedEventHandler(this.xc555e814c1720baf);
      this.x372569d2ea29984e = (x7fc004d490c8a431) null;
    }

    private void xfae511fd7c4fb447(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.xd5979b8834306b81();
    }

    private void xc555e814c1720baf(int x0d4b3b88c5b24565)
    {
      this.xd5979b8834306b81();
      this.xca843b3e9a1c605f = x0d4b3b88c5b24565;
    }

    public int xca843b3e9a1c605f
    {
      get
      {
        if (this.x2ee8392f53a01b93.Dock == DockStyle.Left || this.x2ee8392f53a01b93.Dock == DockStyle.Right)
          return this.x21ed2ecc088ef4e4.Width;
        return this.x21ed2ecc088ef4e4.Height;
      }
      set
      {
        Rectangle bounds = this.Bounds;
label_10:
        int num;
        do
        {
          num = value;
          if (this.x61fa1911d2d31a75)
            goto label_11;
          else
            goto label_12;
label_8:
          switch (this.x2ee8392f53a01b93.Dock)
          {
            case DockStyle.Top:
              goto label_4;
            case DockStyle.Bottom:
              bounds.Y = bounds.Bottom - num;
              bounds.Height = num;
              continue;
            case DockStyle.Left:
              goto label_9;
            case DockStyle.Right:
              goto label_6;
            default:
              goto label_1;
          }
label_11:
          num += 4;
          goto label_8;
label_12:
          if ((value & 0) != 0)
            goto label_2;
          else
            goto label_8;
        }
        while ((uint) num > uint.MaxValue);
        goto label_14;
label_1:
        this.Bounds = bounds;
label_2:
        if (true)
        {
          this.x5a9cbf8ad0ee9896.xca843b3e9a1c605f = value;
          return;
        }
        goto label_7;
label_4:
        bounds.Height = num;
        goto label_1;
label_6:
        bounds.X = bounds.Right - num;
label_7:
        bounds.Width = num;
        if ((uint) num <= uint.MaxValue)
          goto label_1;
        else
          goto label_10;
label_9:
        bounds.Width = num;
        if ((uint) value - (uint) value < 0U)
          goto label_1;
        else
          goto label_1;
label_14:
        if ((uint) value - (uint) num <= uint.MaxValue)
          goto label_1;
      }
    }

    public bool x1c3de22188ea5bb2
    {
      get
      {
        return this.x372569d2ea29984e != null;
      }
    }

    public ControlLayoutSystem x5a9cbf8ad0ee9896
    {
      get
      {
        return this.x6e150040c8d97700;
      }
      set
      {
        this.x6e150040c8d97700 = value;
        this.PerformLayout();
      }
    }

    private bool x61fa1911d2d31a75
    {
      get
      {
        return this.x2ee8392f53a01b93.x460ab163f44a604d.AllowDockContainerResize;
      }
    }

    protected override void OnLayout(LayoutEventArgs levent)
    {
      if (this.x6e150040c8d97700 == null)
        return;
      do
      {
        this.x21ed2ecc088ef4e4 = this.ClientRectangle;
        if (!this.x61fa1911d2d31a75)
          this.x59f159fe47159543 = Rectangle.Empty;
        else
          goto label_12;
label_2:
        this.x6e150040c8d97700.LayoutCollapsed(this.x2ee8392f53a01b93.x460ab163f44a604d.Renderer, this.x21ed2ecc088ef4e4);
        this.Invalidate();
        continue;
label_12:
        switch (this.x2ee8392f53a01b93.Dock)
        {
          case DockStyle.Top:
            this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.X, this.x21ed2ecc088ef4e4.Bottom - 4, this.x21ed2ecc088ef4e4.Width, 4);
            if (false)
              goto default;
            else
              break;
          case DockStyle.Bottom:
            do
            {
              this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.X, this.x21ed2ecc088ef4e4.Y, this.x21ed2ecc088ef4e4.Width, 4);
              this.x21ed2ecc088ef4e4.Y += 4;
              this.x21ed2ecc088ef4e4.Height -= 4;
            }
            while (false);
            goto label_2;
          case DockStyle.Left:
            this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.Right - 4, this.x21ed2ecc088ef4e4.Y, 4, this.x21ed2ecc088ef4e4.Height);
            if (true)
            {
              this.x21ed2ecc088ef4e4.Width -= 4;
              if (false)
              {
                if (false)
                  goto case DockStyle.Bottom;
                else
                  goto case DockStyle.Bottom;
              }
              else
                goto label_2;
            }
            else
              break;
          case DockStyle.Right:
            this.x59f159fe47159543 = new Rectangle(this.x21ed2ecc088ef4e4.X, this.x21ed2ecc088ef4e4.Y, 4, this.x21ed2ecc088ef4e4.Height);
            this.x21ed2ecc088ef4e4.X += 4;
            this.x21ed2ecc088ef4e4.Width -= 4;
            goto label_2;
          default:
            this.x59f159fe47159543 = Rectangle.Empty;
            goto label_2;
        }
        this.x21ed2ecc088ef4e4.Height -= 4;
        goto label_2;
      }
      while (false);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        goto label_17;
label_4:
      base.Dispose(disposing);
      return;
label_17:
      while (!this.IsDisposed)
      {
        if (true)
          goto label_12;
        else
          goto label_14;
label_9:
        if (!this.x2ee8392f53a01b93.x460ab163f44a604d.OwnerForm.IsMdiContainer && (uint) disposing - (uint) disposing <= uint.MaxValue)
          goto label_11;
label_10:
        if (this.x2ee8392f53a01b93.x460ab163f44a604d.OwnerForm.ActiveMdiChild != null)
          this.x2ee8392f53a01b93.x460ab163f44a604d.OwnerForm.ActiveControl = (Control) this.x2ee8392f53a01b93.x460ab163f44a604d.OwnerForm.ActiveMdiChild;
label_11:
        do
        {
          this.x2ee8392f53a01b93.xcdb145600c1b7224(true);
          if (true)
          {
            this.x2ee8392f53a01b93 = (x10ac79a4257c7f52) null;
            this.x5a9cbf8ad0ee9896 = (ControlLayoutSystem) null;
            if (false)
              goto label_12;
          }
          if ((uint) disposing - (uint) disposing <= uint.MaxValue || true)
          {
            if (this.xac1c850120b1f254 != null)
              this.xac1c850120b1f254.Dispose();
            else
              goto label_2;
          }
          else
            goto label_17;
        }
        while (false);
        goto label_7;
label_2:
        if (this.x372569d2ea29984e != null)
        {
          this.xd5979b8834306b81();
          break;
        }
        break;
label_7:
        this.xac1c850120b1f254 = (xf8f9565783602018) null;
        if (((disposing ? 1 : 0) & 0) == 0)
        {
          if ((uint) disposing + (uint) disposing > uint.MaxValue)
            goto label_10;
          else
            goto label_2;
        }
        else
          goto label_9;
label_12:
        if (this.ContainsFocus)
        {
          if (false)
            goto label_9;
        }
        else
          goto label_11;
label_14:
        if (this.x2ee8392f53a01b93.x460ab163f44a604d.OwnerForm == null)
          goto label_11;
        else
          goto label_9;
      }
      goto label_4;
    }

    protected override void OnEnter(EventArgs e)
    {
      base.OnEnter(e);
      if (this.x6e150040c8d97700 == null)
        return;
      this.x6e150040c8d97700.xd541e2fc281b554b();
    }

    protected override void OnLeave(EventArgs e)
    {
      base.OnLeave(e);
      while (this.x6e150040c8d97700 != null)
      {
        do
        {
          this.x6e150040c8d97700.xd541e2fc281b554b();
        }
        while (false);
        if (true)
          break;
      }
    }

    private string xa3a7472ac4e61f76(System.Drawing.Point xb9c2cfae130d9256)
    {
      if (this.x21ed2ecc088ef4e4.Contains(xb9c2cfae130d9256) && this.x6e150040c8d97700 != null)
        return this.x6e150040c8d97700.xe0e7b93bedab6c05(xb9c2cfae130d9256);
      return "";
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (this.x59f159fe47159543.Contains(e.X, e.Y) || this.x372569d2ea29984e != null)
        goto label_15;
      else
        goto label_13;
label_1:
      if (!this.x21ed2ecc088ef4e4.Contains(e.X, e.Y) || this.x6e150040c8d97700 == null && (true || true))
        return;
label_2:
      this.x6e150040c8d97700.OnMouseMove(e);
      return;
label_3:
      if (this.x372569d2ea29984e == null)
      {
        if (true)
        {
          if (true)
          {
            if (false)
            {
              if (false)
                return;
              goto label_2;
            }
            else
              goto label_1;
          }
          else
            goto label_14;
        }
        else
          goto label_12;
      }
      else
      {
        this.x372569d2ea29984e.OnMouseMove(new System.Drawing.Point(e.X, e.Y));
        return;
      }
label_7:
      if (this.Capture)
        goto label_3;
      else
        goto label_1;
label_12:
      Cursor.Current = Cursors.HSplit;
      goto label_7;
label_13:
      Cursor.Current = Cursors.Default;
label_14:
      if (true)
        goto label_7;
      else
        goto label_3;
label_15:
      if (this.x2ee8392f53a01b93.Dock == DockStyle.Left || this.x2ee8392f53a01b93.Dock == DockStyle.Right)
      {
        Cursor.Current = Cursors.VSplit;
        goto label_7;
      }
      else
        goto label_12;
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      base.OnMouseLeave(e);
      if (this.x6e150040c8d97700 == null)
        return;
      this.x6e150040c8d97700.OnMouseLeave();
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      base.OnMouseDown(e);
label_6:
      do
      {
        if (this.x59f159fe47159543.Contains(e.X, e.Y))
          goto label_7;
label_2:
        while (this.x21ed2ecc088ef4e4.Contains(e.X, e.Y))
        {
          if (this.x6e150040c8d97700 != null)
          {
            this.x6e150040c8d97700.OnMouseDown(e);
            if (true)
              return;
          }
          else
          {
            if (true)
              return;
            goto label_6;
          }
        }
        continue;
label_7:
        if (true || true)
        {
          if (e.Button == MouseButtons.Left)
            goto label_12;
          else
            goto label_2;
        }
      }
      while (false);
      return;
label_12:
      this.x81dc33c66d5e1e33(new System.Drawing.Point(e.X, e.Y));
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      base.OnMouseUp(e);
      while (this.x372569d2ea29984e == null || e.Button != MouseButtons.Left)
      {
        while (this.x21ed2ecc088ef4e4.Contains(e.X, e.Y))
        {
          if (this.x6e150040c8d97700 == null)
            return;
          this.x6e150040c8d97700.OnMouseUp(e);
          if (true)
            return;
        }
        if (true)
          return;
      }
      this.x372569d2ea29984e.Commit();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      this.x2ee8392f53a01b93.x460ab163f44a604d.Renderer.StartRenderSession(HotkeyPrefix.None);
      if (this.x6e150040c8d97700 != null)
        goto label_7;
label_2:
      if (this.x61fa1911d2d31a75)
        this.x2ee8392f53a01b93.x460ab163f44a604d.Renderer.DrawSplitter((Control) null, (Control) this, e.Graphics, this.x59f159fe47159543, this.x2ee8392f53a01b93.Dock == DockStyle.Top || this.x2ee8392f53a01b93.Dock == DockStyle.Bottom ? Orientation.Horizontal : Orientation.Vertical);
      this.x2ee8392f53a01b93.x460ab163f44a604d.Renderer.FinishRenderSession();
      if (false)
        ;
      return;
label_7:
      this.x6e150040c8d97700.x84b6f3c22477dacb(this.x2ee8392f53a01b93.x460ab163f44a604d.Renderer, e.Graphics, this.Font);
      if (true)
        goto label_2;
    }
  }
}
