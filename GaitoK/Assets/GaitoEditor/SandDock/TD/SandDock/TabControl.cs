// Decompiled with JetBrains decompiler
// Type: TD.SandDock.TabControl
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using Divelements.Util.Registration;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
  [LicenseProvider(typeof (x294bd621a33dc533))]
  [Designer("TD.SandDock.Design.TabControlDesigner, SandDock.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
  [DefaultEvent("SelectedPageChanged")]
  [ToolboxItem(true)]
  [ToolboxBitmap(typeof (TabControl))]
  [DefaultProperty("TabLayout")]
  public class TabControl : Control
  {
    private TD.SandDock.Rendering.BorderStyle xacfbd7a08ba56c78 = TD.SandDock.Rendering.BorderStyle.Flat;
    private const int x1e9b7c427b6c44fa = 14;
    private const int x26539fe4604823df = 15;
    private ITabControlRenderer x38870620fd380a6b;
    private static bool xc700d1f31b5ce30a;
    private TabControl.TabPageCollection xc13824d17c0efae4;
    private TabPage x980c1bf410aee986;
    private xbd7c5470fc89975b x266365ea27fa7af8;
    private TabLayout xcd09bc4ebc470051;
    private Rectangle xd2fe3b65e7e0ab37;
    private Rectangle x21ed2ecc088ef4e4;
    private Rectangle x38c1fce82bb0e828;
    private int x200b7f5a9d983ba4;
    private int x4f8ccd50477a481e;
    private Timer x5d56ae798b9cdf38;
    private x0a9f5257a10031b2 x49dae83181e41d72;
    private x0a9f5257a10031b2 xa8ae81960654bc0b;
    private x0a9f5257a10031b2 x216b0c2912ae7c6a;
    private bool xfa5e20eb950b9ee1;

    public event EventHandler SelectedPageChanged;

    public TabControl()
    {
      this.x266365ea27fa7af8 = LicenseManager.Validate(typeof (TabControl), (object) this) as xbd7c5470fc89975b;
      this.SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, true);
      do
      {
        this.SetStyle(ControlStyles.Selectable, true);
      }
      while (false);
      this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
      this.x38870620fd380a6b = (ITabControlRenderer) new MilborneRenderer();
      if (true)
        goto label_2;
label_1:
      this.x5d56ae798b9cdf38 = new Timer();
      this.x5d56ae798b9cdf38.Interval = 20;
      this.x5d56ae798b9cdf38.Tick += new EventHandler(this.xcaf19fd9570f4eb4);
      return;
label_2:
      this.xc13824d17c0efae4 = new TabControl.TabPageCollection(this);
      this.x49dae83181e41d72 = new x0a9f5257a10031b2();
      do
      {
        this.xa8ae81960654bc0b = new x0a9f5257a10031b2();
      }
      while (false);
      goto label_1;
    }

    protected override Control.ControlCollection CreateControlsInstance()
    {
      return (Control.ControlCollection) new TabControl.x9e8d5fa1ed8fe66b(this);
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
      {
        if (this.x38870620fd380a6b is IDisposable)
          goto label_4;
label_2:
        this.x5d56ae798b9cdf38.Dispose();
        goto label_3;
label_4:
        do
        {
          ((IDisposable) this.x38870620fd380a6b).Dispose();
        }
        while ((uint) disposing < 0U);
        goto label_2;
      }
label_3:
      base.Dispose(disposing);
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      this.Renderer.StartRenderSession(this.ShowKeyboardCues ? HotkeyPrefix.Show : HotkeyPrefix.Hide);
      Region region;
      Rectangle xd2fe3b65e7e0ab37;
      do
      {
        DockControl.xe1da469e4d960f02((Control) this, e.Graphics, this.xacfbd7a08ba56c78);
        this.x38870620fd380a6b.DrawTabControlTabStripBackground(e.Graphics, this.xd2fe3b65e7e0ab37, this.BackColor);
        if (true)
        {
          region = (Region) null;
          if (this.TabLayout == TabLayout.SingleLineScrollable)
          {
            region = e.Graphics.Clip;
            xd2fe3b65e7e0ab37 = this.xd2fe3b65e7e0ab37;
          }
          else
            goto label_29;
        }
        else
          goto label_29;
      }
      while (false);
      goto label_31;
label_29:
      int index;
      while (this.TabLayout != TabLayout.MultipleLine)
      {
        if (true)
        {
          if (true)
            goto label_26;
label_25:
          if ((uint) index - (uint) index < 0U)
            continue;
label_26:
          for (index = this.Controls.Count - 1; index >= 0; --index)
            this.xc33f5f7a18a754cb(e.Graphics, (TabPage) this.Controls[index]);
          if ((uint) index - (uint) index < 0U)
            goto label_25;
        }
        if ((uint) index + (uint) index >= 0U)
          goto label_21;
        else
          goto label_15;
      }
      goto label_32;
label_15:
      if (this.SelectedPage != null)
        this.x38870620fd380a6b.DrawTabControlBackground(e.Graphics, this.x21ed2ecc088ef4e4, this.SelectedPage.BackColor, false);
      if (this.TabLayout == TabLayout.SingleLineScrollable)
        goto label_12;
label_2:
      this.Renderer.FinishRenderSession();
      if (!this.x266365ea27fa7af8.Evaluation)
        return;
      using (SolidBrush solidBrush = new SolidBrush(Color.FromArgb(30, Color.Black)))
      {
        using (Font font = new Font(this.Font.FontFamily.Name, 14f, FontStyle.Bold))
        {
          e.Graphics.DrawString("evaluation", font, (Brush) solidBrush, (float) (this.xd2fe3b65e7e0ab37.Left + 4), (float) (this.xd2fe3b65e7e0ab37.Top - 4), StringFormat.GenericTypographic);
          return;
        }
      }
label_12:
      while ((uint) index - (uint) index <= uint.MaxValue)
      {
        do
        {
          this.xb30ec7cfdf3e5c19(e.Graphics, this.x38870620fd380a6b, this.xa8ae81960654bc0b, SandDockButtonType.ScrollRight, this.xa8ae81960654bc0b.x2fef7d841879a711);
          if (true)
            this.xb30ec7cfdf3e5c19(e.Graphics, this.x38870620fd380a6b, this.x49dae83181e41d72, SandDockButtonType.ScrollLeft, this.x49dae83181e41d72.x2fef7d841879a711);
          else
            goto label_12;
        }
        while (false);
        goto label_2;
      }
      goto label_31;
label_21:
      do
      {
        if (this.SelectedPage != null)
          goto label_20;
        else
          goto label_22;
label_18:
        if (this.TabLayout != TabLayout.SingleLineScrollable)
          continue;
        goto label_17;
label_20:
        this.xc33f5f7a18a754cb(e.Graphics, this.SelectedPage);
        goto label_18;
label_22:
        if ((uint) index + (uint) index >= 0U)
          goto label_18;
        else
          goto label_17;
      }
      while (false);
      goto label_15;
label_17:
      e.Graphics.Clip = region;
      goto label_15;
label_32:
      this.xe03691727ff38b10(e.Graphics);
      goto label_21;
label_31:
      xd2fe3b65e7e0ab37.Width -= this.xd2fe3b65e7e0ab37.Right - this.x49dae83181e41d72.xda73fcb97c77d998.Left;
      e.Graphics.SetClip(xd2fe3b65e7e0ab37);
      goto label_29;
    }

    private void xb30ec7cfdf3e5c19(
      Graphics x41347a961b838962,
      ITabControlRenderer x38870620fd380a6b,
      x0a9f5257a10031b2 x128517d7ded59312,
      SandDockButtonType x271bd5d42b3ea793,
      bool x2fef7d841879a711)
    {
      if (!x128517d7ded59312.x364c1e3b189d47fe)
        return;
      do
      {
        DrawItemState state = DrawItemState.Default;
        if (this.x1f43ebe301d1df45 == x128517d7ded59312)
          goto label_8;
label_1:
        if (!x2fef7d841879a711)
          goto label_3;
label_2:
        x38870620fd380a6b.DrawTabControlButton(x41347a961b838962, x128517d7ded59312.xda73fcb97c77d998, x271bd5d42b3ea793, state);
        continue;
label_3:
        state |= DrawItemState.Disabled;
        goto label_2;
label_8:
        state |= DrawItemState.HotLight;
        if ((uint) x2fef7d841879a711 - (uint) x2fef7d841879a711 > uint.MaxValue || this.xfa5e20eb950b9ee1)
        {
          state |= DrawItemState.Selected;
          if ((uint) x2fef7d841879a711 - (uint) x2fef7d841879a711 <= uint.MaxValue)
            goto label_1;
          else
            goto label_4;
        }
        else
          goto label_1;
      }
      while (false);
      return;
label_4:;
    }

    private void xe03691727ff38b10(Graphics x41347a961b838962)
    {
      ArrayList arrayList = new ArrayList();
label_15:
      IEnumerator enumerator = this.Controls.GetEnumerator();
      int index1;
      int index2;
      try
      {
        while (enumerator.MoveNext())
        {
          TabPage current = (TabPage) enumerator.Current;
          if (!arrayList.Contains((object) current.xa806b754814b9ae0))
            arrayList.Add((object) current.xa806b754814b9ae0);
        }
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        if ((uint) index1 - (uint) index1 <= uint.MaxValue)
        {
          while (disposable != null)
          {
            disposable.Dispose();
            if ((uint) index1 + (uint) index2 > uint.MaxValue || true)
              break;
          }
        }
      }
      int[] array = (int[]) arrayList.ToArray(typeof (int));
      Array.Sort<int>(array);
label_26:
      index1 = 0;
      while (index1 < array.Length)
      {
        index2 = this.Controls.Count - 1;
        if ((uint) index1 + (uint) index2 < 0U)
          goto label_28;
label_2:
        if (index2 < 0)
        {
          ++index1;
          if ((index1 & 0) != 0)
          {
            if ((uint) index1 >= 0U)
              goto label_15;
            else
              goto label_12;
          }
          else
          {
            if ((index1 | int.MaxValue) == 0)
              break;
            continue;
          }
        }
        else
          goto label_12;
label_4:
        Rectangle x123e054dab107457;
        TabPage control;
        this.x38870620fd380a6b.DrawFakeTabControlBackgroundExtension(x41347a961b838962, x123e054dab107457, control.BackColor);
        goto label_6;
label_5:
        if (index1 < array.Length - 1)
        {
          x123e054dab107457 = control.x123e054dab107457;
          x123e054dab107457.X = this.xd2fe3b65e7e0ab37.X;
          x123e054dab107457.Width = this.xd2fe3b65e7e0ab37.Width;
          x123e054dab107457.Y = x123e054dab107457.Bottom - 1;
          x123e054dab107457.Height = this.x21ed2ecc088ef4e4.Y - x123e054dab107457.Y - 2;
          goto label_4;
        }
label_6:
        --index2;
        goto label_2;
label_7:
        if ((uint) index2 + (uint) index1 >= 0U)
        {
          if ((uint) index1 + (uint) index1 <= uint.MaxValue)
          {
            this.xc33f5f7a18a754cb(x41347a961b838962, control);
            if ((index2 | -1) == 0)
              continue;
            goto label_5;
          }
          else
            goto label_26;
        }
        else
          goto label_4;
label_12:
        control = (TabPage) this.Controls[index2];
        if ((uint) index2 + (uint) index2 >= 0U)
        {
          if (control.xa806b754814b9ae0 == array[index1])
          {
            if ((uint) index1 + (uint) index1 >= 0U)
              goto label_7;
            else
              goto label_15;
          }
          else
            goto label_6;
        }
        else
          goto label_5;
label_28:
        if ((uint) index1 - (uint) index2 <= uint.MaxValue)
          goto label_12;
        else
          goto label_7;
      }
    }

    private void xc33f5f7a18a754cb(Graphics x41347a961b838962, TabPage xbbe2f7d7c86e0379)
    {
      DrawItemState state = DrawItemState.Default;
      if (xbbe2f7d7c86e0379 == this.SelectedPage)
        goto label_4;
      else
        goto label_3;
label_1:
      this.Renderer.DrawTabControlTab(x41347a961b838962, xbbe2f7d7c86e0379.x123e054dab107457, xbbe2f7d7c86e0379.TabImage, xbbe2f7d7c86e0379.Text, this.Font, xbbe2f7d7c86e0379.BackColor, xbbe2f7d7c86e0379.ForeColor, state, true);
      return;
label_2:
      state |= DrawItemState.Checked;
      goto label_1;
label_3:
      if (false)
        goto label_2;
      else
        goto label_1;
label_4:
      state |= DrawItemState.Selected;
      if (!this.Focused || !this.ShowFocusCues)
        goto label_1;
      else
        goto label_2;
    }

    protected override void OnLayout(LayoutEventArgs levent)
    {
      if (this.x38c1fce82bb0e828.Width <= 0 || this.x38c1fce82bb0e828.Height <= 0)
        return;
      IEnumerator enumerator = this.Controls.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
          ((Control) enumerator.Current).Bounds = this.x38c1fce82bb0e828;
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        if (true)
          goto label_11;
        else
          goto label_8;
label_7:
        if (false)
          goto label_11;
        else
          goto label_13;
label_8:
        if (false)
          goto label_7;
        else
          goto label_13;
label_11:
        if (disposable != null)
        {
          disposable.Dispose();
          goto label_7;
        }
        else if (true)
          goto label_8;
label_13:;
      }
    }

    protected override void OnResize(EventArgs e)
    {
      this.x436f6f3ee14607e0();
      base.OnResize(e);
    }

    protected override void OnControlAdded(ControlEventArgs e)
    {
      base.OnControlAdded(e);
      this.x436f6f3ee14607e0();
      this.PerformLayout();
    }

    protected override void OnControlRemoved(ControlEventArgs e)
    {
      base.OnControlRemoved(e);
      if (false)
      {
        if (true)
          goto label_5;
      }
      else
        goto label_9;
label_2:
      if (true)
        this.OnSelectedPageChanged(EventArgs.Empty);
label_4:
      this.x436f6f3ee14607e0();
      this.PerformLayout();
      if (true)
        return;
      goto label_9;
label_5:
      this.x980c1bf410aee986 = (TabPage) null;
      goto label_2;
label_9:
      if (true)
      {
        if (this.SelectedPage == e.Control)
        {
          if (this.TabPages.Count != 0)
          {
            this.SelectedPage = this.TabPages[0];
            goto label_4;
          }
          else
            goto label_5;
        }
        else
          goto label_4;
      }
      else
        goto label_5;
    }

    internal void x436f6f3ee14607e0()
    {
      if (!this.IsHandleCreated)
        return;
      ITabControlRenderer renderer = this.Renderer;
      using (Graphics graphics = this.CreateGraphics())
      {
        renderer.StartRenderSession(HotkeyPrefix.Hide);
        IEnumerator enumerator = this.Controls.GetEnumerator();
        try
        {
          while (true)
          {
            TabPage current;
            do
            {
              if (!enumerator.MoveNext())
              {
                if (false)
                {
                  int num;
                  if ((num | int.MaxValue) == 0)
                    goto label_28;
                  else
                    goto label_32;
                }
                else
                  goto label_36;
              }
              else
                goto label_32;
label_27:
              continue;
label_28:
              if (current.MaximumTabWidth == 0)
                continue;
              goto label_27;
label_32:
              current = (TabPage) enumerator.Current;
              current.xcfac6723d8a41375 = false;
              DrawItemState state = current != this.SelectedPage ? DrawItemState.Default : DrawItemState.Selected;
              int num1;
              if ((num1 | (int) byte.MaxValue) != 0)
              {
                current.x9b0739496f8b5475 = (double) renderer.MeasureTabControlTab(graphics, current.TabImage, current.Text, this.Font, state).Width;
                goto label_28;
              }
              else
                goto label_27;
            }
            while ((double) current.MaximumTabWidth >= current.x9b0739496f8b5475);
            current.x9b0739496f8b5475 = (double) current.MaximumTabWidth;
            current.xcfac6723d8a41375 = true;
          }
        }
        finally
        {
          (enumerator as IDisposable)?.Dispose();
        }
label_36:
        renderer.FinishRenderSession();
      }
      if (this.TabLayout == TabLayout.MultipleLine)
        goto label_21;
      else
        goto label_9;
label_2:
      this.Invalidate(renderer.ShouldDrawTabControlBackground);
      return;
label_8:
      int num2;
      int width;
      do
      {
        TabLayout tabLayout;
        do
        {
          this.x21ed2ecc088ef4e4 = this.DisplayRectangle;
          this.x21ed2ecc088ef4e4.Offset(0, this.xd2fe3b65e7e0ab37.Height);
          this.x21ed2ecc088ef4e4.Height -= this.xd2fe3b65e7e0ab37.Height;
          this.x38c1fce82bb0e828 = this.x21ed2ecc088ef4e4;
          this.x38c1fce82bb0e828.Inflate(-renderer.TabControlPadding.Width, -renderer.TabControlPadding.Height);
          tabLayout = this.TabLayout;
        }
        while ((uint) num2 + (uint) num2 < 0U);
        if ((uint) width + (uint) width >= 0U)
        {
          switch (tabLayout)
          {
            case TabLayout.SingleLineScrollable:
              goto label_1;
            case TabLayout.SingleLineFixed:
              goto label_4;
            case TabLayout.MultipleLine:
              goto label_3;
            default:
              continue;
          }
        }
        else
          goto label_3;
      }
      while (false);
      goto label_2;
label_1:
      this.xac46da8e3ebf1367();
      goto label_2;
label_3:
      this.xad3ea5eacdd3e808();
      goto label_2;
label_4:
      this.x9ad45a8b0cdc25f7();
      goto label_2;
label_9:
      this.xd2fe3b65e7e0ab37 = this.DisplayRectangle;
      this.xd2fe3b65e7e0ab37.Height = renderer.TabControlTabStripHeight;
      int num3;
      if ((uint) num3 >= 0U)
        goto label_8;
      else
        goto label_2;
label_21:
      width = this.DisplayRectangle.Width;
      int num4;
      int num5;
      do
      {
        num2 = 1;
        num5 = 0;
        foreach (TabPage control in (ArrangedElementCollection) this.Controls)
        {
          num5 += (int) control.x9b0739496f8b5475;
          if ((num5 > width || (num2 & 0) != 0) && num5 != (int) control.x9b0739496f8b5475)
            goto label_16;
label_15:
          num5 -= renderer.TabControlTabExtra;
          continue;
label_16:
          ++num2;
          num5 = (int) control.x9b0739496f8b5475;
          goto label_15;
        }
        num4 = (renderer.TabControlTabHeight - 2) * num2 + (renderer.TabControlTabStripHeight - renderer.TabControlTabHeight) + 2;
        this.xd2fe3b65e7e0ab37 = this.DisplayRectangle;
      }
      while ((uint) num5 - (uint) width > uint.MaxValue);
      this.xd2fe3b65e7e0ab37.Height = num4;
      goto label_8;
    }

    private void xad3ea5eacdd3e808()
    {
      ArrayList arrayList1 = new ArrayList();
      int num1;
      if ((num1 & 0) == 0)
        goto label_55;
label_29:
      bool flag1 = false;
      ArrayList arrayList2;
      bool flag2;
      int left1;
      int num2;
      ArrayList arrayList3;
      int num3;
      foreach (TabPage control in (ArrangedElementCollection) this.Controls)
      {
        do
        {
          if (arrayList3.Count == 0)
            goto label_50;
label_45:
          int num4 = (double) left1 + control.x9b0739496f8b5475 <= (double) this.xd2fe3b65e7e0ab37.Right ? 1 : 0;
label_47:
          flag2 = num4 != 0;
          int num5;
          if ((num5 & 0) != 0 || flag2)
          {
            arrayList3.Add((object) control);
            continue;
          }
          goto label_40;
label_50:
          if ((uint) num2 - (uint) left1 >= 0U)
          {
            if ((uint) num3 + (uint) num5 <= uint.MaxValue && !flag1)
            {
              num4 = 1;
              goto label_47;
            }
            else
              goto label_45;
          }
          else
            break;
        }
        while ((uint) flag2 < 0U);
label_31:
        if (this.SelectedPage == control)
        {
          arrayList2 = arrayList3;
          goto label_34;
        }
label_32:
        if ((uint) flag1 < 0U)
          goto label_40;
label_34:
        left1 += (int) control.x9b0739496f8b5475 - this.x38870620fd380a6b.TabControlTabExtra;
        continue;
label_40:
        arrayList1.Add((object) arrayList3);
        do
        {
          arrayList3 = new ArrayList();
        }
        while ((uint) left1 - (uint) flag2 > uint.MaxValue);
        left1 = this.xd2fe3b65e7e0ab37.Left;
        arrayList3.Add((object) control);
        if ((uint) flag1 + (uint) left1 >= 0U)
        {
          if (this.SelectedPage == control)
          {
            arrayList2 = arrayList3;
            if ((uint) num3 + (uint) flag2 >= 0U)
            {
              if (false)
                goto label_31;
              else
                goto label_34;
            }
            else if ((uint) flag1 + (uint) left1 <= uint.MaxValue)
            {
              if ((uint) left1 + (uint) left1 <= uint.MaxValue)
                goto label_31;
              else
                break;
            }
            else
              goto label_32;
          }
          else
            goto label_34;
        }
        else
          goto label_31;
      }
      if (arrayList3.Count != 0)
        goto label_54;
      else
        goto label_25;
label_1:
      if (arrayList2 != null)
        goto label_26;
label_2:
      int y = this.xd2fe3b65e7e0ab37.Top + (this.x38870620fd380a6b.TabControlTabStripHeight - this.x38870620fd380a6b.TabControlTabHeight);
      IEnumerator enumerator1 = arrayList1.GetEnumerator();
      int num6;
      int width1;
      try
      {
        while (enumerator1.MoveNext())
        {
          ArrayList current1 = (ArrayList) enumerator1.Current;
          num6 = arrayList1.IndexOf((object) current1);
          do
          {
            if (arrayList1.Count <= 1)
            {
              if (((flag2 ? 1 : 0) & 0) == 0)
                break;
            }
            else
              this.xd022f7303b745a62((IList) current1, true);
          }
          while ((uint) y + (uint) flag2 > uint.MaxValue);
          int left2 = this.xd2fe3b65e7e0ab37.Left;
          IEnumerator enumerator2 = current1.GetEnumerator();
          try
          {
            while (enumerator2.MoveNext())
            {
              TabPage current2 = (TabPage) enumerator2.Current;
              do
              {
                current2.xa806b754814b9ae0 = num6;
                width1 = (int) Math.Round(current2.x9b0739496f8b5475, 0);
              }
              while ((uint) y + (uint) num6 < 0U);
              current2.x123e054dab107457 = new Rectangle(left2, y, width1, this.x38870620fd380a6b.TabControlTabHeight);
              left2 += width1 - this.x38870620fd380a6b.TabControlTabExtra;
            }
          }
          finally
          {
            IDisposable disposable = enumerator2 as IDisposable;
            if ((uint) width1 + (uint) flag1 < 0U || disposable != null)
              disposable.Dispose();
          }
          y += this.x38870620fd380a6b.TabControlTabHeight - 2;
        }
        return;
      }
      finally
      {
        IDisposable disposable = enumerator1 as IDisposable;
        if ((uint) num6 + (uint) width1 < 0U || disposable != null)
          disposable.Dispose();
      }
label_25:
      if ((uint) num2 - (uint) left1 <= uint.MaxValue)
        goto label_1;
label_26:
      arrayList1.Remove((object) arrayList2);
      arrayList1.Add((object) arrayList2);
      if ((uint) left1 + (uint) num3 >= 0U)
      {
        if ((uint) flag1 < 0U)
        {
          if ((uint) flag2 - (uint) left1 >= 0U)
            goto label_1;
          else
            goto label_55;
        }
        else
          goto label_2;
      }
      else
        goto label_55;
label_54:
      arrayList1.Add((object) arrayList3);
      goto label_1;
label_55:
      do
      {
        int width2 = this.DisplayRectangle.Width;
        arrayList2 = (ArrayList) null;
        arrayList3 = new ArrayList();
      }
      while (false);
      left1 = this.xd2fe3b65e7e0ab37.Left;
      goto label_29;
    }

    private void xac46da8e3ebf1367()
    {
      int y = this.xd2fe3b65e7e0ab37.Top + this.xd2fe3b65e7e0ab37.Height / 2 - 7;
      int num1;
      int left;
      do
      {
        int num2;
        do
        {
          num1 = this.xd2fe3b65e7e0ab37.Right - 2;
          this.xa8ae81960654bc0b.x364c1e3b189d47fe = true;
          if (true)
          {
            int num3;
            if ((num3 | 2) != 0)
            {
              this.xa8ae81960654bc0b.xda73fcb97c77d998 = new Rectangle(num1 - 14, y, 14, 15);
              num2 = num1 - 15;
              this.x49dae83181e41d72.x364c1e3b189d47fe = true;
            }
            else
              goto label_12;
          }
          else
            goto label_36;
        }
        while (false);
        this.x49dae83181e41d72.xda73fcb97c77d998 = new Rectangle(num2 - 14, y, 14, 15);
        num1 = num2 - 15;
        left = this.xd2fe3b65e7e0ab37.Left;
      }
      while ((uint) left + (uint) num1 > uint.MaxValue);
      goto label_22;
label_12:
      this.x4f8ccd50477a481e = 0;
label_14:
      if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
        goto label_13;
      else
        goto label_18;
label_10:
      this.x49dae83181e41d72.x2fef7d841879a711 = this.x200b7f5a9d983ba4 > 0;
      this.xa8ae81960654bc0b.x2fef7d841879a711 = this.x200b7f5a9d983ba4 < this.x4f8ccd50477a481e;
      int width;
      if (false)
      {
        if ((uint) width + (uint) num1 <= uint.MaxValue)
          goto label_17;
        else
          goto label_15;
      }
      else
        goto label_19;
label_13:
      this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
      goto label_10;
label_18:
      int num4;
      if ((num4 | -1) != 0)
        goto label_10;
label_19:
      if ((uint) width < 0U)
        return;
      IEnumerator enumerator1 = this.Controls.GetEnumerator();
      try
      {
        while (enumerator1.MoveNext())
        {
          TabPage current = (TabPage) enumerator1.Current;
          Rectangle x123e054dab107457 = current.x123e054dab107457;
          do
          {
            x123e054dab107457.Offset(-this.x200b7f5a9d983ba4, 0);
          }
          while ((uint) num1 < 0U);
          current.x123e054dab107457 = x123e054dab107457;
        }
        return;
      }
      finally
      {
        (enumerator1 as IDisposable)?.Dispose();
      }
label_15:
      this.x4f8ccd50477a481e = left - num4;
      if (this.x4f8ccd50477a481e >= 0)
        goto label_14;
      else
        goto label_12;
label_17:
      num4 = this.x49dae83181e41d72.xda73fcb97c77d998.Left - this.xd2fe3b65e7e0ab37.Left;
      goto label_15;
label_22:
      IEnumerator enumerator2 = this.Controls.GetEnumerator();
      try
      {
        while (enumerator2.MoveNext())
        {
          TabPage current = (TabPage) enumerator2.Current;
          width = (int) Math.Round(current.x9b0739496f8b5475, 0);
          current.x123e054dab107457 = new Rectangle(left, this.xd2fe3b65e7e0ab37.Bottom - this.x38870620fd380a6b.TabControlTabHeight, width, this.x38870620fd380a6b.TabControlTabHeight);
          if ((uint) num1 - (uint) width > uint.MaxValue)
            ;
          left += width - this.x38870620fd380a6b.TabControlTabExtra;
        }
      }
      finally
      {
        IDisposable disposable = enumerator2 as IDisposable;
        if ((uint) left > uint.MaxValue || disposable != null)
          disposable.Dispose();
      }
      if (this.Controls.Count != 0)
      {
        left += this.x38870620fd380a6b.TabControlTabExtra;
        int num2;
        if ((uint) num2 - (uint) left > uint.MaxValue)
          return;
        goto label_17;
      }
      else
        goto label_17;
label_36:;
    }

    private void x9ad45a8b0cdc25f7()
    {
      this.xd022f7303b745a62((IList) this.Controls, false);
      int left = this.xd2fe3b65e7e0ab37.Left;
      IEnumerator enumerator = this.Controls.GetEnumerator();
      int width;
      try
      {
        while (enumerator.MoveNext())
        {
          TabPage current;
          do
          {
            current = (TabPage) enumerator.Current;
            width = (int) Math.Round(current.x9b0739496f8b5475, 0);
          }
          while ((width & 0) != 0);
          current.x123e054dab107457 = new Rectangle(left, this.xd2fe3b65e7e0ab37.Bottom - this.x38870620fd380a6b.TabControlTabHeight, width, this.x38870620fd380a6b.TabControlTabHeight);
          left += width - this.x38870620fd380a6b.TabControlTabExtra;
        }
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        while (disposable != null)
        {
          disposable.Dispose();
          if ((uint) width + (uint) width >= 0U)
            break;
        }
      }
    }

    private void xd022f7303b745a62(IList xc06f388a56e1a8e4, bool x12583168cc11d7a7)
    {
      int width = this.xd2fe3b65e7e0ab37.Width;
      double num1 = 0.0;
      foreach (TabPage tabPage in (IEnumerable) xc06f388a56e1a8e4)
        num1 += tabPage.x9b0739496f8b5475;
      if (xc06f388a56e1a8e4.Count >= 1)
        goto label_26;
label_17:
      if (num1 > (double) width)
        goto label_18;
label_1:
      if (!x12583168cc11d7a7)
        return;
      double num2;
      if (num1 >= (double) width)
      {
        if ((uint) num2 - (uint) width <= uint.MaxValue)
          return;
        goto label_14;
      }
      else
        goto label_9;
label_5:
      int index1;
      double num3;
      double num4;
      for (; index1 < xc06f388a56e1a8e4.Count; ++index1)
      {
        TabPage tabPage = (TabPage) xc06f388a56e1a8e4[index1];
        double num5 = index1 != 0 ? tabPage.x9b0739496f8b5475 - (double) this.x38870620fd380a6b.TabControlTabExtra : tabPage.x9b0739496f8b5475;
        if ((uint) num1 >= 0U)
        {
          num3 = num5 / num1;
          double num6 = num5 + num2 * num3;
          tabPage.x9b0739496f8b5475 = index1 == 0 ? num6 : num6 + (double) this.x38870620fd380a6b.TabControlTabExtra;
          if ((uint) num4 + (uint) num6 <= uint.MaxValue)
          {
            if (false)
              return;
          }
          else
            goto label_17;
        }
        else
          goto label_9;
      }
      if ((uint) num3 >= 0U)
        return;
      goto label_1;
label_9:
      num2 = (double) width - num1;
      index1 = 0;
      goto label_5;
label_14:
      double num7;
      for (int index2 = 0; index2 < xc06f388a56e1a8e4.Count; ++index2)
      {
        TabPage tabPage = (TabPage) xc06f388a56e1a8e4[index2];
        num4 = index2 != 0 ? tabPage.x9b0739496f8b5475 - (double) this.x38870620fd380a6b.TabControlTabExtra : tabPage.x9b0739496f8b5475;
        if ((uint) index1 <= uint.MaxValue)
        {
          double num5 = num4 / num1;
          double num6 = num4 - num7 * num5;
          tabPage.xcfac6723d8a41375 = true;
          tabPage.x9b0739496f8b5475 = index2 == 0 ? num6 : num6 + (double) this.x38870620fd380a6b.TabControlTabExtra;
        }
        else
          goto label_5;
      }
      return;
label_18:
      num7 = num1 - (double) width;
      goto label_14;
label_26:
      num1 -= (double) ((xc06f388a56e1a8e4.Count - 1) * this.x38870620fd380a6b.TabControlTabExtra);
      goto label_17;
    }

    internal x0a9f5257a10031b2 x1f43ebe301d1df45
    {
      get
      {
        return this.x216b0c2912ae7c6a;
      }
      set
      {
        if (value == this.x216b0c2912ae7c6a)
          return;
        if (this.x216b0c2912ae7c6a != null)
          this.Invalidate(this.xd2fe3b65e7e0ab37);
        this.x216b0c2912ae7c6a = value;
        if (this.x216b0c2912ae7c6a == null)
          return;
        this.Invalidate(this.xd2fe3b65e7e0ab37);
        if (false)
          ;
      }
    }

    private void xd11b6d3bf98020cb()
    {
      this.x5d56ae798b9cdf38.Enabled = false;
      this.x1f43ebe301d1df45 = (x0a9f5257a10031b2) null;
      this.xfa5e20eb950b9ee1 = false;
      this.Invalidate(this.xd2fe3b65e7e0ab37);
    }

    private void xcf8b319f2bffca87()
    {
      this.x5d56ae798b9cdf38.Enabled = true;
      this.xcaf19fd9570f4eb4((object) this.x5d56ae798b9cdf38, EventArgs.Empty);
    }

    private void x523c1f22a806032d(int xa00f04d8b3a6664c)
    {
      this.x200b7f5a9d983ba4 += xa00f04d8b3a6664c;
      if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
        goto label_4;
label_1:
      if (this.x200b7f5a9d983ba4 < 0)
      {
        this.x200b7f5a9d983ba4 = 0;
        this.xd11b6d3bf98020cb();
        if ((uint) xa00f04d8b3a6664c - (uint) xa00f04d8b3a6664c < 0U)
          ;
      }
      this.x436f6f3ee14607e0();
      return;
label_4:
      this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
      this.xd11b6d3bf98020cb();
      goto label_1;
    }

    private void xcaf19fd9570f4eb4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      if (this.x1f43ebe301d1df45 != this.x49dae83181e41d72)
      {
        if (this.x1f43ebe301d1df45 == this.xa8ae81960654bc0b)
          this.x523c1f22a806032d(15);
        else
          this.xd11b6d3bf98020cb();
      }
      else
        this.x523c1f22a806032d(-15);
    }

    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);
      this.x436f6f3ee14607e0();
      this.PerformLayout();
    }

    public TabPage GetTabPageAt(System.Drawing.Point position)
    {
      IEnumerator enumerator = this.Controls.GetEnumerator();
      try
      {
label_2:
        if (enumerator.MoveNext())
        {
          TabPage current = (TabPage) enumerator.Current;
          Rectangle x123e054dab107457 = current.x123e054dab107457;
          while (!x123e054dab107457.Contains(position))
          {
            if (true || true)
              goto label_2;
          }
          return current;
        }
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
      return (TabPage) null;
    }

    protected override void OnMouseLeave(EventArgs e)
    {
      this.x1f43ebe301d1df45 = (x0a9f5257a10031b2) null;
      this.xfa5e20eb950b9ee1 = false;
      base.OnMouseLeave(e);
    }

    private x0a9f5257a10031b2 x07083a4bfd59263d(
      int x08db3aeabb253cb1,
      int x1e218ceaee1bb583)
    {
      if (this.x49dae83181e41d72.x364c1e3b189d47fe && this.x49dae83181e41d72.x2fef7d841879a711)
        goto label_8;
label_1:
      if (!this.xa8ae81960654bc0b.x364c1e3b189d47fe)
        goto label_10;
label_2:
      if (this.xa8ae81960654bc0b.x2fef7d841879a711 && this.xa8ae81960654bc0b.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
        return this.xa8ae81960654bc0b;
      goto label_10;
label_8:
      if (this.x49dae83181e41d72.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
        return this.x49dae83181e41d72;
      if (false)
      {
        if ((uint) x1e218ceaee1bb583 <= uint.MaxValue)
          goto label_1;
      }
      else if (true)
      {
        if (true)
          goto label_1;
        else
          goto label_2;
      }
label_10:
      return (x0a9f5257a10031b2) null;
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      while (this.TabLayout == TabLayout.SingleLineScrollable)
      {
        this.x1f43ebe301d1df45 = this.x07083a4bfd59263d(e.X, e.Y);
        if (true)
          break;
      }
    }

    private void x11e90588eb0baaf1(x0a9f5257a10031b2 x128517d7ded59312)
    {
      if (x128517d7ded59312 != this.x49dae83181e41d72 && x128517d7ded59312 != this.xa8ae81960654bc0b)
        return;
      this.xcf8b319f2bffca87();
    }

    private void xa82f7b310984e03e(x0a9f5257a10031b2 x128517d7ded59312)
    {
      if (x128517d7ded59312 != this.x49dae83181e41d72 && x128517d7ded59312 != this.xa8ae81960654bc0b)
        return;
      this.xd11b6d3bf98020cb();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
      if (this.x266365ea27fa7af8.Locked)
        return;
      do
      {
        if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
        {
          if (this.x1f43ebe301d1df45 == null)
          {
            if (false)
              ;
          }
          else
          {
            this.xa82f7b310984e03e(this.x1f43ebe301d1df45);
            if (true)
            {
              this.xfa5e20eb950b9ee1 = false;
              if (true)
                this.Invalidate(this.xd2fe3b65e7e0ab37);
              else
                goto label_8;
            }
            else
              continue;
          }
        }
        base.OnMouseUp(e);
      }
      while (false);
      return;
label_8:;
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
      if (this.x266365ea27fa7af8.Locked)
        return;
      if (e.Button == MouseButtons.Left)
        goto label_10;
label_3:
      base.OnMouseDown(e);
      return;
label_10:
      while (this.x1f43ebe301d1df45 != null)
      {
        this.xfa5e20eb950b9ee1 = true;
        this.Invalidate(this.xd2fe3b65e7e0ab37);
        if (true)
        {
          if (true)
          {
            this.x11e90588eb0baaf1(this.x1f43ebe301d1df45);
            return;
          }
          goto label_8;
        }
      }
      TabPage tabPageAt = this.GetTabPageAt(new System.Drawing.Point(e.X, e.Y));
      if (false)
        return;
label_8:
      if (tabPageAt != null)
      {
        while (true)
        {
          if (this.SelectedPage != tabPageAt)
          {
            this.xf8af240c2d768134(tabPageAt, true);
            if (true)
              goto label_18;
          }
          else
            goto label_4;
        }
        goto label_17;
label_4:
        this.Focus();
        return;
label_17:
        if (true)
          goto label_4;
label_18:
        if (true)
          ;
      }
      else
        goto label_3;
    }

    private void xf8af240c2d768134(TabPage xbbe2f7d7c86e0379, bool x17cc8f73454a0462)
    {
      this.SelectedPage = xbbe2f7d7c86e0379;
      int num;
      Rectangle xd2fe3b65e7e0ab37;
      do
      {
        if (x17cc8f73454a0462)
          goto label_19;
label_16:
        if (this.TabLayout == TabLayout.SingleLineScrollable)
        {
          xd2fe3b65e7e0ab37 = this.xd2fe3b65e7e0ab37;
          xd2fe3b65e7e0ab37.Width -= this.xd2fe3b65e7e0ab37.Right - this.x49dae83181e41d72.xda73fcb97c77d998.Left;
          continue;
        }
        goto label_20;
label_19:
        this.SelectedPage.SelectNextControl((Control) null, true, true, true, true);
        if ((uint) x17cc8f73454a0462 - (uint) x17cc8f73454a0462 >= 0U)
          goto label_16;
        else
          break;
      }
      while ((uint) num + (uint) num < 0U);
      Rectangle x123e054dab107457 = xbbe2f7d7c86e0379.x123e054dab107457;
      int xa00f04d8b3a6664c;
      if ((uint) num + (uint) x17cc8f73454a0462 <= uint.MaxValue)
      {
        while (xd2fe3b65e7e0ab37.Contains(x123e054dab107457))
        {
          if (true)
          {
            if (true)
            {
              if ((uint) x17cc8f73454a0462 <= uint.MaxValue && (num | -1) != 0)
                return;
            }
            else
              goto label_6;
          }
          else if (false)
            goto label_11;
          else
            goto label_6;
        }
        xa00f04d8b3a6664c = 0;
label_11:
        if (x123e054dab107457.Right <= xd2fe3b65e7e0ab37.Right)
        {
          if (x123e054dab107457.Left < xd2fe3b65e7e0ab37.Left)
          {
            xa00f04d8b3a6664c = x123e054dab107457.Left - xd2fe3b65e7e0ab37.Left - 20;
            if ((xa00f04d8b3a6664c & 0) != 0)
              goto label_7;
          }
        }
        else
          xa00f04d8b3a6664c = x123e054dab107457.Right - xd2fe3b65e7e0ab37.Right + 20;
      }
label_6:
      if (xa00f04d8b3a6664c == 0)
        return;
label_7:
      this.x523c1f22a806032d(xa00f04d8b3a6664c);
      return;
label_20:;
    }

    protected override bool IsInputKey(Keys keyData)
    {
      switch (keyData)
      {
        case Keys.Left:
        case Keys.Up:
        case Keys.Right:
        case Keys.Down:
          return true;
        default:
          return base.IsInputKey(keyData);
      }
    }

    protected override void OnGotFocus(EventArgs e)
    {
      base.OnGotFocus(e);
      this.Invalidate(this.TabStripBounds);
    }

    protected override void OnLostFocus(EventArgs e)
    {
      base.OnLostFocus(e);
      this.Invalidate(this.TabStripBounds);
    }

    protected override bool ProcessMnemonic(char charCode)
    {
      foreach (TabPage control in (ArrangedElementCollection) this.Controls)
      {
        if (Control.IsMnemonic(charCode, control.Text))
        {
          this.xf8af240c2d768134(control, true);
          return true;
        }
      }
      return base.ProcessMnemonic(charCode);
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      Keys keyCode = e.KeyCode;
label_12:
      switch (keyCode)
      {
        case Keys.Left:
          this.xa3038751b16f6cc8(-1, false, false);
          return;
        case Keys.Up:
label_6:
          if (this.TabLayout == TabLayout.MultipleLine)
          {
            this.x35cf6ce73d51ebeb(-1, false);
            return;
          }
          if (true)
          {
            if (true)
            {
              if (true)
                return;
              break;
            }
            goto label_5;
          }
          else
            goto label_12;
        case Keys.Right:
          this.xa3038751b16f6cc8(1, false, false);
          return;
        case Keys.Down:
          return;
        default:
          base.OnKeyDown(e);
          goto label_5;
      }
label_3:
      if (true)
        return;
      goto label_6;
label_5:
      if (true)
        goto label_3;
      else
        goto label_6;
    }

    private void x35cf6ce73d51ebeb(int x23e85093ba3a7d1d, bool x17cc8f73454a0462)
    {
      if (this.SelectedPage == null)
        return;
      int num1;
      int num2;
      int num3;
      if ((num1 & 0) == 0)
      {
        Rectangle x123e054dab107457 = this.SelectedPage.x123e054dab107457;
        num2 = x123e054dab107457.X + x123e054dab107457.Width / 2;
        num3 = this.SelectedPage.xa806b754814b9ae0 + x23e85093ba3a7d1d;
      }
      IEnumerator enumerator = this.Controls.GetEnumerator();
      try
      {
        while (enumerator.MoveNext() || (num2 | 1) == 0)
        {
          TabPage current = (TabPage) enumerator.Current;
          Rectangle x123e054dab107457 = current.x123e054dab107457;
          if (current.xa806b754814b9ae0 == num3 && (x123e054dab107457.X <= num2 && x123e054dab107457.Right >= num2))
          {
            this.xf8af240c2d768134(current, x17cc8f73454a0462);
            break;
          }
        }
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
    }

    private void xa3038751b16f6cc8(
      int x23e85093ba3a7d1d,
      bool x17cc8f73454a0462,
      bool x878956783d1decb2)
    {
      if (this.SelectedPage == null)
        return;
      int index = this.Controls.IndexOf((Control) this.SelectedPage) + x23e85093ba3a7d1d;
      if (index > this.Controls.Count - 1)
        goto label_11;
label_1:
      if (index < 0)
        goto label_8;
label_2:
      this.xf8af240c2d768134((TabPage) this.Controls[index], x17cc8f73454a0462);
      if ((uint) x17cc8f73454a0462 <= uint.MaxValue)
      {
        if ((uint) x23e85093ba3a7d1d >= 0U)
          return;
      }
      else
        goto label_5;
label_4:
      if (((x878956783d1decb2 ? 1 : 0) | int.MaxValue) != 0)
        goto label_6;
label_5:
      if ((uint) x23e85093ba3a7d1d > uint.MaxValue)
        goto label_8;
label_6:
      int num = this.Controls.Count - 1;
label_7:
      index = num;
      goto label_2;
label_8:
      if (!x878956783d1decb2)
      {
        num = 0;
        goto label_7;
      }
      else
        goto label_4;
label_11:
      index = x878956783d1decb2 ? 0 : this.Controls.Count - 1;
      goto label_1;
    }

    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
      Keys keys = keyData;
      if (keys != (Keys.Tab | Keys.Control))
        goto label_3;
label_2:
      this.xa3038751b16f6cc8(1, true, true);
      return true;
label_3:
      switch (keys)
      {
        case Keys.Prior | Keys.Control:
        case Keys.Tab | Keys.Shift | Keys.Control:
          this.xa3038751b16f6cc8(-1, true, true);
          return true;
        case Keys.Next | Keys.Control:
          goto label_2;
        default:
          return base.ProcessCmdKey(ref msg, keyData);
      }
    }

    protected override void OnFontChanged(EventArgs e)
    {
      this.x436f6f3ee14607e0();
      this.PerformLayout();
      base.OnFontChanged(e);
    }

    protected virtual void OnSelectedPageChanged(EventArgs e)
    {
      if (this.x5c05af982a207d77 == null)
        return;
      this.x5c05af982a207d77((object) this, e);
    }

    [Category("Behavior")]
    [Description("How the tabs of child controls are laid out.")]
    [DefaultValue(typeof (TabLayout), "SingleLineScrollable")]
    public TabLayout TabLayout
    {
      get
      {
        return this.xcd09bc4ebc470051;
      }
      set
      {
        this.xcd09bc4ebc470051 = value;
        this.x436f6f3ee14607e0();
        this.PerformLayout();
      }
    }

    [Category("Appearance")]
    [TypeConverter(typeof (xdc4dfd9427bbb983))]
    [Description("The renderer used to calculate object metrics and draw contents.")]
    [RefreshProperties(RefreshProperties.All)]
    public ITabControlRenderer Renderer
    {
      get
      {
        return this.x38870620fd380a6b;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException();
        if (this.x38870620fd380a6b is IDisposable)
          goto label_19;
label_17:
        if (this.x38870620fd380a6b is RendererBase)
          goto label_21;
label_18:
        this.x38870620fd380a6b = value;
        if (false)
          goto label_10;
        else
          goto label_14;
label_1:
        if (this.x38870620fd380a6b is RendererBase)
          goto label_5;
label_2:
        this.x436f6f3ee14607e0();
        this.PerformLayout();
        return;
label_5:
        ((RendererBase) this.x38870620fd380a6b).MetricsChanged += new EventHandler(this.xadaf245f129714e2);
        goto label_2;
label_6:
        if (value.ShouldDrawControlBorder)
        {
          if (true)
          {
            if (true)
            {
              if (true)
                goto label_1;
              else
                goto label_5;
            }
          }
          else if (false)
            goto label_12;
        }
        else
          goto label_12;
label_9:
        if (false)
          goto label_6;
        else
          goto label_1;
label_10:
        if (this.BorderStyle != TD.SandDock.Rendering.BorderStyle.None)
        {
          if (true)
            goto label_6;
        }
        else
        {
          this.BorderStyle = TD.SandDock.Rendering.BorderStyle.Flat;
          if (false)
            goto label_19;
          else
            goto label_1;
        }
label_12:
        if (this.BorderStyle != TD.SandDock.Rendering.BorderStyle.None)
        {
          this.BorderStyle = TD.SandDock.Rendering.BorderStyle.None;
          goto label_9;
        }
        else
          goto label_1;
label_14:
        if (true)
        {
          if (!value.ShouldDrawControlBorder)
            goto label_6;
          else
            goto label_10;
        }
        else
          goto label_5;
label_21:
        ((RendererBase) this.x38870620fd380a6b).MetricsChanged -= new EventHandler(this.xadaf245f129714e2);
        goto label_18;
label_19:
        ((IDisposable) this.x38870620fd380a6b).Dispose();
        goto label_17;
      }
    }

    private void xadaf245f129714e2(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      this.x436f6f3ee14607e0();
      this.PerformLayout();
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Obsolete("Use the TabLayout property instead.")]
    public bool AllowScrolling
    {
      get
      {
        return true;
      }
      set
      {
      }
    }

    public override Rectangle DisplayRectangle
    {
      get
      {
        Rectangle displayRectangle = base.DisplayRectangle;
        do
        {
          switch (this.xacfbd7a08ba56c78)
          {
            case TD.SandDock.Rendering.BorderStyle.Flat:
            case TD.SandDock.Rendering.BorderStyle.RaisedThin:
            case TD.SandDock.Rendering.BorderStyle.SunkenThin:
              goto label_1;
            case TD.SandDock.Rendering.BorderStyle.RaisedThick:
            case TD.SandDock.Rendering.BorderStyle.SunkenThick:
              do
              {
                displayRectangle.Inflate(-2, -2);
              }
              while (false);
              continue;
            default:
              goto label_5;
          }
        }
        while (false);
        goto label_5;
label_1:
        displayRectangle.Inflate(-1, -1);
label_5:
        return displayRectangle;
      }
    }

    [Description("The type of border to be drawn around the control.")]
    [DefaultValue(typeof (TD.SandDock.Rendering.BorderStyle), "Flat")]
    [Category("Appearance")]
    public TD.SandDock.Rendering.BorderStyle BorderStyle
    {
      get
      {
        return this.xacfbd7a08ba56c78;
      }
      set
      {
        this.xacfbd7a08ba56c78 = value;
        this.x436f6f3ee14607e0();
        this.PerformLayout();
      }
    }

    [Category("Behavior")]
    [Description("A collection of TabPage controls belonging to this control.")]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public TabControl.TabPageCollection TabPages
    {
      get
      {
        return this.xc13824d17c0efae4;
      }
    }

    protected override System.Drawing.Size DefaultSize
    {
      get
      {
        return new System.Drawing.Size(300, 200);
      }
    }

    [Browsable(false)]
    public override string Text
    {
      get
      {
        return base.Text;
      }
      set
      {
        base.Text = value;
      }
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public int SelectedIndex
    {
      get
      {
        return this.TabPages.IndexOf(this.SelectedPage);
      }
      set
      {
        this.SelectedPage = this.TabPages[value];
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    public TabPage SelectedPage
    {
      get
      {
        return this.x980c1bf410aee986;
      }
      set
      {
        if (value == null)
        {
          if (true)
            goto label_16;
          else
            goto label_12;
        }
label_11:
        if (!this.Controls.Contains((Control) value))
          throw new ArgumentException("Specified TabPage does not belong to this TabControl.");
        goto label_13;
label_12:
        if (false)
          goto label_11;
label_13:
        this.x980c1bf410aee986 = value;
        this.x436f6f3ee14607e0();
        if (true)
          goto label_3;
label_2:
        this.OnSelectedPageChanged(EventArgs.Empty);
        if (true)
        {
          if (true)
            return;
          goto label_16;
        }
        else
          goto label_12;
label_3:
        this.SuspendLayout();
        foreach (TabPage tabPage in this.TabPages)
          tabPage.Visible = tabPage == this.x980c1bf410aee986;
        this.ResumeLayout();
        goto label_2;
label_16:
        throw new ArgumentNullException();
      }
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    [Browsable(false)]
    [Obsolete]
    public SplitLayoutSystem LayoutSystem
    {
      get
      {
        return (SplitLayoutSystem) null;
      }
      set
      {
      }
    }

    [Browsable(false)]
    public Rectangle TabStripBounds
    {
      get
      {
        return this.xd2fe3b65e7e0ab37;
      }
    }

    public class TabPageCollection : IList, ICollection, IEnumerable
    {
      private TabControl xb6a159a84cb992d6;

      internal TabPageCollection(TabControl parent)
      {
        this.xb6a159a84cb992d6 = parent;
      }

      bool IList.xfc2a190cd9d7a9e2
      {
        get
        {
          return false;
        }
      }

      object IList.get_xe6d4b1b411ed94b5(int xc0c4c459c6ccbd00)
      {
        return (object) this[xc0c4c459c6ccbd00];
      }

      void IList.set_xe6d4b1b411ed94b5(int xc0c4c459c6ccbd00, object xbcea506a33cf9111)
      {
      }

      public void SetChildIndex(TabPage tabPage, int index)
      {
        this.xb6a159a84cb992d6.Controls.SetChildIndex((Control) tabPage, index);
      }

      public void RemoveAt(int index)
      {
        this.xb6a159a84cb992d6.Controls.RemoveAt(index);
      }

      void IList.x87c211383e3062d5(int xc0c4c459c6ccbd00, object xbcea506a33cf9111)
      {
        throw new NotSupportedException();
      }

      void IList.x7d6f7f540d2a814d(object xbcea506a33cf9111)
      {
        if (!(xbcea506a33cf9111 is TabPage))
          return;
        this.Remove((TabPage) xbcea506a33cf9111);
      }

      bool IList.x6532c18338cc2620(object xbcea506a33cf9111)
      {
        if (xbcea506a33cf9111 is TabPage)
          return this.Contains((TabPage) xbcea506a33cf9111);
        return false;
      }

      public void Clear()
      {
        this.xb6a159a84cb992d6.Controls.Clear();
      }

      int IList.x104b91678c6b7dff(object xbcea506a33cf9111)
      {
        if (xbcea506a33cf9111 is TabPage)
          return this.IndexOf((TabPage) xbcea506a33cf9111);
        return -1;
      }

      int IList.xae8b83d75f3358b9(object xbcea506a33cf9111)
      {
        if (!(xbcea506a33cf9111 is TabPage))
          throw new NotSupportedException();
        this.xb6a159a84cb992d6.Controls.Add((Control) xbcea506a33cf9111);
        return this.IndexOf((TabPage) xbcea506a33cf9111);
      }

      bool IList.xe4fa55b25bbd2be4
      {
        get
        {
          return false;
        }
      }

      bool ICollection.x92a0b60a6509c47e
      {
        get
        {
          return false;
        }
      }

      public int Count
      {
        get
        {
          return this.xb6a159a84cb992d6.Controls.Count;
        }
      }

      void ICollection.x21912c843ee261be(Array x9d5750eb2d6373bc, int xc0c4c459c6ccbd00)
      {
        if (!(x9d5750eb2d6373bc is TabPage[]))
          return;
        this.CopyTo((TabPage[]) x9d5750eb2d6373bc, xc0c4c459c6ccbd00);
      }

      object ICollection.x1efa7fe50de1e184
      {
        get
        {
          return (object) this;
        }
      }

      public IEnumerator GetEnumerator()
      {
        TabPage[] array = new TabPage[this.Count];
        this.CopyTo(array, 0);
        return array.GetEnumerator();
      }

      public void CopyTo(TabPage[] array, int index)
      {
        this.xb6a159a84cb992d6.Controls.CopyTo((Array) array, index);
      }

      public TabPage this[int index]
      {
        get
        {
          return (TabPage) this.xb6a159a84cb992d6.Controls[index];
        }
      }

      public bool Contains(TabPage tabPage)
      {
        return this.xb6a159a84cb992d6.Controls.Contains((Control) tabPage);
      }

      public void AddRange(TabPage[] tabPages)
      {
        this.xb6a159a84cb992d6.Controls.AddRange((Control[]) tabPages);
      }

      public void Remove(TabPage tabPage)
      {
        this.xb6a159a84cb992d6.Controls.Remove((Control) tabPage);
      }

      public int IndexOf(TabPage tabPage)
      {
        return this.xb6a159a84cb992d6.Controls.IndexOf((Control) tabPage);
      }

      public void Add(TabPage tabPage)
      {
        this.xb6a159a84cb992d6.Controls.Add((Control) tabPage);
      }
    }

    internal class x9e8d5fa1ed8fe66b : Control.ControlCollection
    {
      private TabControl xb6a159a84cb992d6;

      public x9e8d5fa1ed8fe66b(TabControl owner)
        : base((Control) owner)
      {
        this.xb6a159a84cb992d6 = owner;
      }

      public override void Add(Control value)
      {
        if (value is TabPage)
        {
          value.Visible = false;
          base.Add(value);
          while (this.Count == 1)
          {
            this.xb6a159a84cb992d6.SelectedPage = (TabPage) value;
            if (true)
            {
              if (true)
                break;
              goto label_7;
            }
          }
          return;
        }
label_7:
        throw new ArgumentException("Only TabPage controls can be added to a TabControl control.");
      }
    }
  }
}
