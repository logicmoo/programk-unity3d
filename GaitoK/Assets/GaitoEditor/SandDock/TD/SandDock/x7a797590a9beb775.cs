// Decompiled with JetBrains decompiler
// Type: TD.SandDock.x7a797590a9beb775
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TD.SandDock
{
  internal class x7a797590a9beb775 : Form
  {
    private const int x25e1af1de31299a2 = 2;
    private const int xb615ddf284afbdf6 = 524288;
    private const int x77bf04ec211c4a37 = 16;
    private const int x339acab5bf3e83ae = 64;
    private const int xb644deafcaa222c4 = 2;
    private const int xb8a822e576f3bf60 = 1;
    private bool x21480c2e0df4efcd;

    [DllImport("user32.dll")]
    private static extern bool SetWindowPos(
      HandleRef hWnd,
      HandleRef hWndInsertAfter,
      int x,
      int y,
      int cx,
      int cy,
      int flags);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern bool SetLayeredWindowAttributes(
      IntPtr hwnd,
      int crKey,
      byte bAlpha,
      int dwFlags);

    public x7a797590a9beb775(bool hollow)
    {
      this.x21480c2e0df4efcd = hollow;
      this.BackColor = SystemColors.Highlight;
      this.ShowInTaskbar = false;
      this.SetStyle(ControlStyles.ResizeRedraw, true);
    }

    public void xf00ba4096f8180b1(Rectangle xda73fcb97c77d998, bool x067d6ddeefb41622)
    {
      x7a797590a9beb775.SetWindowPos(new HandleRef((object) this, this.Handle), new HandleRef((object) this, IntPtr.Zero), xda73fcb97c77d998.X, xda73fcb97c77d998.Y, xda73fcb97c77d998.Width, xda73fcb97c77d998.Height, 80);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      if (!this.x21480c2e0df4efcd)
        return;
      Rectangle clientRectangle = this.ClientRectangle;
      --clientRectangle.Width;
      do
      {
        --clientRectangle.Height;
        e.Graphics.DrawRectangle(SystemPens.ControlDark, clientRectangle);
        clientRectangle.Inflate(-1, -1);
      }
      while (false);
      e.Graphics.DrawRectangle(SystemPens.ControlDark, clientRectangle);
    }

    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);
      x7a797590a9beb775.SetLayeredWindowAttributes(this.Handle, 0, (byte) 128, 2);
    }

    protected override CreateParams CreateParams
    {
      get
      {
        CreateParams createParams = base.CreateParams;
        createParams.Style = int.MinValue;
        createParams.ExStyle |= 524288;
        return createParams;
      }
    }
  }
}
