// Decompiled with JetBrains decompiler
// Type: TD.SandDock.DocumentLayoutSystem
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
  public class DocumentLayoutSystem : ControlLayoutSystem
  {
    private const int x1e9b7c427b6c44fa = 14;
    private const int x26539fe4604823df = 15;
    private const int x088e2ac38f89d005 = 17;
    private int x200b7f5a9d983ba4;
    private int x4f8ccd50477a481e;
    private Timer x5d56ae798b9cdf38;
    private DockControl x9241b98e8e24ab0c;
    private x0a9f5257a10031b2 x49dae83181e41d72;
    private x0a9f5257a10031b2 xa8ae81960654bc0b;
    private x0a9f5257a10031b2 x26e80f23e22a05ae;
    private x0a9f5257a10031b2 x361886ff08483890;

    public DocumentLayoutSystem()
    {
      this.x49dae83181e41d72 = new x0a9f5257a10031b2();
      this.xa8ae81960654bc0b = new x0a9f5257a10031b2();
      do
      {
        this.x26e80f23e22a05ae = new x0a9f5257a10031b2();
        this.x361886ff08483890 = new x0a9f5257a10031b2();
        this.x5d56ae798b9cdf38 = new Timer();
        this.x5d56ae798b9cdf38.Interval = 20;
        this.x5d56ae798b9cdf38.Tick += new EventHandler(this.xcaf19fd9570f4eb4);
      }
      while (false);
    }

    public DocumentLayoutSystem(int desiredWidth, int desiredHeight)
      : this()
    {
      this.WorkingSize = new SizeF((float) desiredWidth, (float) desiredHeight);
    }

    [Obsolete("Use the constructor that takes a SizeF instead.")]
    public DocumentLayoutSystem(
      int desiredWidth,
      int desiredHeight,
      DockControl[] controls,
      DockControl selectedControl)
      : this(desiredWidth, desiredHeight)
    {
      if (true)
      {
        this.Controls.AddRange(controls);
        if (selectedControl == null)
          return;
      }
      this.SelectedControl = selectedControl;
    }

    public DocumentLayoutSystem(
      SizeF workingSize,
      DockControl[] windows,
      DockControl selectedWindow)
      : this()
    {
      if (true)
        goto label_4;
label_1:
      this.Controls.AddRange(windows);
      if (selectedWindow == null)
        return;
      this.SelectedControl = selectedWindow;
      return;
label_4:
      this.WorkingSize = workingSize;
      goto label_1;
    }

    private DocumentOverflowMode x7d2c5325d16e569d
    {
      get
      {
        DocumentContainer dockContainer = this.DockContainer as DocumentContainer;
        if (dockContainer != null)
          return dockContainer.x7d2c5325d16e569d;
        return DocumentOverflowMode.Scrollable;
      }
    }

    private bool xa957e8f86f5e6115
    {
      get
      {
        DocumentContainer dockContainer = this.DockContainer as DocumentContainer;
        if (dockContainer != null)
          return dockContainer.xa957e8f86f5e6115;
        return false;
      }
    }

    private DockControl xfccaf77d66322943
    {
      get
      {
        return this.x9241b98e8e24ab0c;
      }
      set
      {
        if (value == this.x9241b98e8e24ab0c)
          return;
        if (this.DockContainer == null)
          goto label_7;
label_6:
        if (this.x9241b98e8e24ab0c != null)
          this.DockContainer.Invalidate(this.x9241b98e8e24ab0c.x123e054dab107457);
label_7:
        this.x9241b98e8e24ab0c = value;
        while (this.DockContainer != null)
        {
          while (this.x9241b98e8e24ab0c == null)
          {
            if (true)
              return;
            if (true)
              goto label_6;
          }
          this.DockContainer.Invalidate(this.x9241b98e8e24ab0c.x123e054dab107457);
          if (true)
            break;
        }
      }
    }

    protected internal override void OnMouseMove(MouseEventArgs e)
    {
      base.OnMouseMove(e);
      if (e.Button != MouseButtons.None)
        return;
      this.xfccaf77d66322943 = this.GetControlAt(new System.Drawing.Point(e.X, e.Y));
    }

    protected internal override void OnMouseLeave()
    {
      base.OnMouseLeave();
      this.xfccaf77d66322943 = (DockControl) null;
    }

    public Rectangle LeftScrollButtonBounds
    {
      get
      {
        return this.x49dae83181e41d72.xda73fcb97c77d998;
      }
    }

    public Rectangle RightScrollButtonBounds
    {
      get
      {
        return this.xa8ae81960654bc0b.xda73fcb97c77d998;
      }
    }

    internal override string xe0e7b93bedab6c05(System.Drawing.Point x13d4cb8d1bd20347)
    {
      x0a9f5257a10031b2 x0a9f5257a10031b2 = this.x07083a4bfd59263d(x13d4cb8d1bd20347.X, x13d4cb8d1bd20347.Y);
      if (true)
      {
        if (x0a9f5257a10031b2 == this.x49dae83181e41d72)
          return SandDockLanguage.ScrollLeftText;
        if (false)
          ;
        if (x0a9f5257a10031b2 == this.xa8ae81960654bc0b)
          return SandDockLanguage.ScrollRightText;
        if (x0a9f5257a10031b2 == this.x26e80f23e22a05ae)
          return SandDockLanguage.CloseText;
        if (x0a9f5257a10031b2 == this.x361886ff08483890)
          return SandDockLanguage.ActiveFilesText;
      }
      return base.xe0e7b93bedab6c05(x13d4cb8d1bd20347);
    }

    internal override void x46ff430ed3944e0f(xedb4922162c60d3d.DockTarget x11d58b056c032b03)
    {
      base.x46ff430ed3944e0f(x11d58b056c032b03);
      do
      {
        if (x11d58b056c032b03 == null)
          goto label_8;
        else
          goto label_7;
label_1:
        if (true)
        {
          if (true)
            continue;
          goto label_10;
        }
label_3:
        if (this.IsInContainer)
          goto label_10;
        else
          goto label_11;
label_7:
        if (x11d58b056c032b03.type != xedb4922162c60d3d.DockTargetType.None)
          goto label_1;
label_8:
        if (this.SelectedControl == null)
          goto label_12;
        else
          goto label_3;
label_10:
        this.DockContainer.x8ba6fce4f4601549(new ShowControlContextMenuEventArgs(this.SelectedControl, this.SelectedControl.PointToClient(Cursor.Position), ContextMenuContext.Other));
        if (true)
        {
          if (false)
            goto label_1;
          else
            goto label_9;
        }
        else
          goto label_7;
      }
      while (false);
      goto label_13;
label_11:
      return;
label_9:
      return;
label_13:
      return;
label_12:;
    }

    internal override void x11e90588eb0baaf1(x0a9f5257a10031b2 x128517d7ded59312)
    {
      if (x128517d7ded59312 != this.x49dae83181e41d72 && x128517d7ded59312 != this.xa8ae81960654bc0b)
        return;
      this.xcf8b319f2bffca87();
    }

    internal override void xa82f7b310984e03e(x0a9f5257a10031b2 x128517d7ded59312)
    {
      if (x128517d7ded59312 == this.x26e80f23e22a05ae)
      {
        if (false)
        {
          if (false)
            goto label_8;
        }
        else
        {
          this.OnCloseButtonClick((EventArgs) new CancelEventArgs());
          return;
        }
      }
      else
        goto label_11;
label_2:
      if (x128517d7ded59312 != this.x361886ff08483890)
      {
        if (true)
          return;
        goto label_15;
      }
label_8:
      if (this.DockContainer == null || this.DockContainer.Manager == null)
        return;
      DockControl[] dockControlArray = new DockControl[this.Controls.Count];
      this.Controls.CopyTo(dockControlArray, 0);
      this.DockContainer.Manager.OnShowActiveFilesList(new ActiveFilesListEventArgs(dockControlArray, (Control) this.DockContainer, new System.Drawing.Point(this.x361886ff08483890.xda73fcb97c77d998.X, this.x361886ff08483890.xda73fcb97c77d998.Bottom)));
      if (true)
      {
        if (true)
          return;
        goto label_2;
      }
      else if (false)
        goto label_15;
label_11:
      if (x128517d7ded59312 != this.x49dae83181e41d72)
        goto label_15;
label_12:
      this.xd11b6d3bf98020cb();
      return;
label_15:
      if (x128517d7ded59312 != this.xa8ae81960654bc0b)
        goto label_2;
      else
        goto label_12;
    }

    internal override x0a9f5257a10031b2 x07083a4bfd59263d(
      int x08db3aeabb253cb1,
      int x1e218ceaee1bb583)
    {
      if (!this.x49dae83181e41d72.x364c1e3b189d47fe)
        goto label_9;
      else
        goto label_10;
label_6:
      if (this.x361886ff08483890.x364c1e3b189d47fe && (this.x361886ff08483890.x2fef7d841879a711 && this.x361886ff08483890.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583)))
        return this.x361886ff08483890;
      if (this.x26e80f23e22a05ae.x364c1e3b189d47fe && this.x26e80f23e22a05ae.x2fef7d841879a711)
      {
        if (this.x26e80f23e22a05ae.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
          return this.x26e80f23e22a05ae;
        if (false)
        {
          if ((x08db3aeabb253cb1 & 0) == 0 || (x1e218ceaee1bb583 & 0) != 0)
            goto label_10;
          else
            goto label_9;
        }
      }
      return (x0a9f5257a10031b2) null;
label_9:
      if ((this.xa8ae81960654bc0b.x364c1e3b189d47fe || (uint) x08db3aeabb253cb1 + (uint) x1e218ceaee1bb583 > uint.MaxValue) && (this.xa8ae81960654bc0b.x2fef7d841879a711 && this.xa8ae81960654bc0b.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583)))
        return this.xa8ae81960654bc0b;
      goto label_6;
label_10:
      if (!this.x49dae83181e41d72.x2fef7d841879a711)
      {
        if ((uint) x1e218ceaee1bb583 - (uint) x08db3aeabb253cb1 > uint.MaxValue)
          goto label_6;
        else
          goto label_9;
      }
      else
      {
        if (this.x49dae83181e41d72.xda73fcb97c77d998.Contains(x08db3aeabb253cb1, x1e218ceaee1bb583))
          return this.x49dae83181e41d72;
        goto label_9;
      }
    }

    internal override void xd541e2fc281b554b()
    {
      if (this.DockContainer == null)
        return;
      this.DockContainer.Invalidate(this.xa358da7dd5364cab);
    }

    internal override void x84b6f3c22477dacb(
      RendererBase x38870620fd380a6b,
      Graphics x41347a961b838962,
      Font x26094932cf7a9139)
    {
      x38870620fd380a6b.DrawDocumentStripBackground(x41347a961b838962, this.xa358da7dd5364cab);
      if (true)
        goto label_15;
      else
        goto label_20;
label_4:
      if (this.xa957e8f86f5e6115)
        goto label_6;
label_5:
      int index;
      Region clip;
      do
      {
        x41347a961b838962.Clip = clip;
        if (!this.xa957e8f86f5e6115)
        {
          this.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.x26e80f23e22a05ae, SandDockButtonType.Close, true);
          if ((index & 0) != 0)
            goto label_15;
        }
        else
          break;
      }
      while (false);
      this.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.xa8ae81960654bc0b, SandDockButtonType.ScrollRight, this.xa8ae81960654bc0b.x2fef7d841879a711);
      this.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.x49dae83181e41d72, SandDockButtonType.ScrollLeft, this.x49dae83181e41d72.x2fef7d841879a711);
      this.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.x361886ff08483890, SandDockButtonType.ActiveFiles, true);
      if (true)
        return;
      goto label_13;
label_6:
      this.xb30ec7cfdf3e5c19(x41347a961b838962, x38870620fd380a6b, this.x26e80f23e22a05ae, SandDockButtonType.Close, true);
      goto label_5;
label_7:
      this.xc33f5f7a18a754cb(x38870620fd380a6b, x41347a961b838962, this.SelectedControl.Font, this.SelectedControl);
      goto label_4;
label_13:
      do
      {
        clip = x41347a961b838962.Clip;
      }
      while ((index & 0) != 0);
      Rectangle xa358da7dd5364cab = this.xa358da7dd5364cab;
      xa358da7dd5364cab.X += this.LeftPadding;
      xa358da7dd5364cab.Width -= this.LeftPadding;
      xa358da7dd5364cab.Width -= this.RightPadding;
      x41347a961b838962.SetClip(xa358da7dd5364cab);
      for (index = this.Controls.Count - 1; index >= 0; --index)
      {
        DockControl control = this.Controls[index];
        this.xc33f5f7a18a754cb(x38870620fd380a6b, x41347a961b838962, control.Font, control);
      }
      if (this.SelectedControl == null)
      {
        if (false)
          return;
        goto label_4;
      }
      else
        goto label_7;
label_15:
      if (this.SelectedControl == null)
      {
        if (true)
        {
          x38870620fd380a6b.DrawDocumentClientBackground(x41347a961b838962, this.x21ed2ecc088ef4e4, SystemColors.Control);
          goto label_13;
        }
        else
          goto label_7;
      }
label_20:
      x38870620fd380a6b.DrawDocumentClientBackground(x41347a961b838962, this.x21ed2ecc088ef4e4, this.SelectedControl.BackColor);
      if ((uint) index - (uint) index >= 0U)
        goto label_13;
    }

    private void xc33f5f7a18a754cb(
      RendererBase x38870620fd380a6b,
      Graphics x41347a961b838962,
      Font x26094932cf7a9139,
      DockControl x43bec302f92080b9)
    {
      DrawItemState state = DrawItemState.Default;
label_33:
      if (this.SelectedControl == x43bec302f92080b9)
        goto label_36;
      else
        goto label_28;
label_1:
      Rectangle tabBounds;
      bool drawSeparator;
      x38870620fd380a6b.DrawDocumentStripTab(x41347a961b838962, x43bec302f92080b9.x123e054dab107457, tabBounds, x43bec302f92080b9.TabImage, x43bec302f92080b9.TabText, x26094932cf7a9139, x43bec302f92080b9.BackColor, x43bec302f92080b9.ForeColor, state, drawSeparator);
      if ((uint) drawSeparator >= 0U)
      {
        if (true)
          return;
        if (true)
          goto label_33;
        else
          goto label_28;
      }
      else
        goto label_9;
label_2:
      if ((state & DrawItemState.Focus) == DrawItemState.Focus)
      {
        using (Font font = new Font(x26094932cf7a9139, FontStyle.Bold))
        {
          x38870620fd380a6b.DrawDocumentStripTab(x41347a961b838962, x43bec302f92080b9.x123e054dab107457, tabBounds, x43bec302f92080b9.TabImage, x43bec302f92080b9.TabText, font, x43bec302f92080b9.BackColor, x43bec302f92080b9.ForeColor, state, drawSeparator);
          return;
        }
      }
      else
        goto label_1;
label_8:
      tabBounds.Width -= 17;
      goto label_2;
label_9:
      tabBounds = x43bec302f92080b9.TabBounds;
      if (!this.xa957e8f86f5e6115 || !x43bec302f92080b9.AllowClose)
        goto label_2;
      else
        goto label_8;
label_22:
      if (this.x9241b98e8e24ab0c == x43bec302f92080b9)
        goto label_21;
label_19:
      if (!x43bec302f92080b9.Enabled)
        goto label_18;
label_13:
      do
      {
        drawSeparator = true;
        if ((uint) drawSeparator >= 0U)
        {
          if (this.SelectedControl != null)
          {
            if (true)
            {
              if ((uint) drawSeparator - (uint) drawSeparator <= uint.MaxValue && this.Controls.IndexOf(x43bec302f92080b9) == this.Controls.IndexOf(this.SelectedControl) - 1)
              {
                drawSeparator = false;
                if (true)
                {
                  if (true)
                    goto label_9;
                }
                else
                  goto label_35;
              }
              else
                goto label_9;
            }
            else
              break;
          }
          else
            goto label_9;
        }
        else
          goto label_28;
      }
      while (false);
      if ((uint) drawSeparator + (uint) drawSeparator <= uint.MaxValue)
      {
        if ((uint) drawSeparator - (uint) drawSeparator <= uint.MaxValue)
          goto label_18;
      }
      else
        goto label_2;
label_35:
      if (false)
        goto label_1;
      else
        goto label_36;
label_18:
      state |= DrawItemState.Disabled;
      goto label_13;
label_21:
      state |= DrawItemState.HotLight;
      goto label_19;
label_24:
      if ((uint) drawSeparator + (uint) drawSeparator < 0U)
        goto label_29;
      else
        goto label_22;
label_28:
      if ((uint) drawSeparator > uint.MaxValue)
        goto label_34;
      else
        goto label_24;
label_29:
      if (true)
      {
        if (((drawSeparator ? 1 : 0) | 8) != 0)
        {
          if (false)
            goto label_24;
          else
            goto label_22;
        }
        else if (true)
        {
          if ((uint) drawSeparator > uint.MaxValue)
            goto label_8;
          else
            goto label_24;
        }
        else
          goto label_33;
      }
      else
        goto label_28;
label_34:
      if (this.DockContainer.Manager.ActiveTabbedDocument == x43bec302f92080b9)
      {
        state |= DrawItemState.Focus;
        goto label_22;
      }
      else
        goto label_29;
label_36:
      state |= DrawItemState.Selected;
      if (this.DockContainer.Manager == null)
        goto label_22;
      else
        goto label_34;
    }

    public override DockControl GetControlAt(System.Drawing.Point position)
    {
      if (this.xa358da7dd5364cab.Contains(position) && (position.X < this.xa358da7dd5364cab.X + this.LeftPadding || position.X > this.xa358da7dd5364cab.Right - this.RightPadding))
        return (DockControl) null;
      return base.GetControlAt(position);
    }

    public override bool Collapsed
    {
      get
      {
        return false;
      }
      set
      {
      }
    }

    protected virtual int LeftPadding
    {
      get
      {
        return 0;
      }
    }

    protected virtual int RightPadding
    {
      get
      {
        if (this.x49dae83181e41d72.x364c1e3b189d47fe)
          return this.Bounds.Right - this.x49dae83181e41d72.xda73fcb97c77d998.Left;
        if (this.x361886ff08483890.x364c1e3b189d47fe)
          return this.Bounds.Right - this.x361886ff08483890.xda73fcb97c77d998.Left;
        if (this.x26e80f23e22a05ae.x364c1e3b189d47fe)
          return this.Bounds.Right - this.x26e80f23e22a05ae.xda73fcb97c77d998.Left;
        return 0;
      }
    }

    protected override void CalculateLayout(
      RendererBase renderer,
      Rectangle bounds,
      bool floating,
      out Rectangle titlebarBounds,
      out Rectangle tabstripBounds,
      out Rectangle clientBounds,
      out Rectangle joinCatchmentBounds)
    {
      titlebarBounds = Rectangle.Empty;
      tabstripBounds = bounds;
      if (true)
      {
        tabstripBounds.Height = renderer.DocumentTabStripSize;
        bounds.Offset(0, renderer.DocumentTabStripSize);
      }
      bounds.Height -= renderer.DocumentTabStripSize;
      clientBounds = bounds;
      joinCatchmentBounds = tabstripBounds;
    }

    protected internal override void Layout(
      RendererBase renderer,
      Graphics graphics,
      Rectangle bounds,
      bool floating)
    {
      base.Layout(renderer, graphics, bounds, floating);
      this.xd00751399198ecd1(renderer, graphics, this.xa358da7dd5364cab);
      this.x5d6e30ce9634c49e(renderer, graphics, this.xa358da7dd5364cab);
    }

    private void xd00751399198ecd1(
      RendererBase x38870620fd380a6b,
      Graphics x41347a961b838962,
      Rectangle xa358da7dd5364cab)
    {
      int y = xa358da7dd5364cab.Top + xa358da7dd5364cab.Height / 2 - 7;
      int num1;
      if ((uint) num1 < 0U)
        goto label_11;
      else
        goto label_15;
label_1:
      int num2;
      this.x361886ff08483890.xda73fcb97c77d998 = new Rectangle(num2 - 14, y, 14, 15);
      num2 -= 15;
      if (true)
        return;
label_7:
      DocumentOverflowMode x7d2c5325d16e569d;
      do
      {
        switch (x7d2c5325d16e569d)
        {
          case DocumentOverflowMode.Scrollable:
            goto label_6;
          case DocumentOverflowMode.Menu:
            this.x361886ff08483890.x364c1e3b189d47fe = true;
            continue;
          default:
            goto label_2;
        }
      }
      while ((uint) y + (uint) y > uint.MaxValue);
      goto label_1;
label_6:
      this.xa8ae81960654bc0b.x364c1e3b189d47fe = true;
      this.xa8ae81960654bc0b.xda73fcb97c77d998 = new Rectangle(num2 - 14, y, 14, 15);
      num2 -= 15;
      if ((uint) num2 - (uint) y >= 0U)
      {
        this.x49dae83181e41d72.x364c1e3b189d47fe = true;
        this.x49dae83181e41d72.xda73fcb97c77d998 = new Rectangle(num2 - 14, y, 14, 15);
        if (false)
          return;
        num1 = num2 - 15;
        return;
      }
      goto label_12;
label_2:
      return;
label_10:
      this.xa8ae81960654bc0b.x364c1e3b189d47fe = false;
      this.x49dae83181e41d72.x364c1e3b189d47fe = false;
      this.x361886ff08483890.x364c1e3b189d47fe = false;
      x7d2c5325d16e569d = this.x7d2c5325d16e569d;
      goto label_7;
label_11:
      this.x26e80f23e22a05ae.xda73fcb97c77d998 = new Rectangle(num2 - 14, y, 14, 15);
label_12:
      num2 -= 15;
      goto label_10;
label_15:
      if ((y | 15) == 0)
        return;
      num2 = xa358da7dd5364cab.Right - 2;
      if (this.SelectedControl == null && (uint) y - (uint) num2 >= 0U || (!this.SelectedControl.AllowClose || this.xa957e8f86f5e6115))
      {
        this.x26e80f23e22a05ae.x364c1e3b189d47fe = false;
        if ((uint) y + (uint) num2 > uint.MaxValue)
          goto label_1;
        else
          goto label_10;
      }
      else
      {
        this.x26e80f23e22a05ae.x364c1e3b189d47fe = true;
        goto label_11;
      }
    }

    private void x5d6e30ce9634c49e(
      RendererBase x38870620fd380a6b,
      Graphics x41347a961b838962,
      Rectangle xa358da7dd5364cab)
    {
      int x = 3;
      if (true)
        goto label_21;
label_12:
      if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
        this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
      this.x49dae83181e41d72.x2fef7d841879a711 = this.x200b7f5a9d983ba4 > 0;
      this.xa8ae81960654bc0b.x2fef7d841879a711 = this.x200b7f5a9d983ba4 < this.x4f8ccd50477a481e;
      IEnumerator enumerator = this.Controls.GetEnumerator();
      int num1;
      try
      {
label_6:
        if (enumerator.MoveNext())
        {
          DockControl current = (DockControl) enumerator.Current;
          do
          {
            Rectangle x123e054dab107457 = current.x123e054dab107457;
            x123e054dab107457.Offset(xa358da7dd5364cab.Left + this.LeftPadding - this.x200b7f5a9d983ba4, 0);
            current.x123e054dab107457 = x123e054dab107457;
          }
          while ((num1 | (int) byte.MaxValue) == 0);
          goto label_6;
        }
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
      if (!this.xa957e8f86f5e6115 || (this.SelectedControl == null || !this.SelectedControl.AllowClose && (uint) num1 + (uint) num1 <= uint.MaxValue))
        return;
      this.x26e80f23e22a05ae.x364c1e3b189d47fe = true;
      if ((uint) x > uint.MaxValue)
        ;
      Rectangle x123e054dab107457_1 = this.SelectedControl.x123e054dab107457;
      this.x26e80f23e22a05ae.xda73fcb97c77d998 = new Rectangle(x123e054dab107457_1.Right - 17, x123e054dab107457_1.Top + 2, 14, x123e054dab107457_1.Height - 3);
      if ((uint) x >= 0U)
        return;
label_21:
      int num2;
      foreach (DockControl control in (CollectionBase) this.Controls)
      {
        control.xcfac6723d8a41375 = false;
        DrawItemState state = DrawItemState.Default;
        if (this.SelectedControl != control)
          goto label_42;
        else
          goto label_43;
label_23:
        control.x123e054dab107457 = new Rectangle(x, xa358da7dd5364cab.Bottom - x38870620fd380a6b.DocumentTabSize, num1, x38870620fd380a6b.DocumentTabSize);
        x += num1 - x38870620fd380a6b.DocumentTabExtra + 1;
        continue;
label_25:
        if (control.MaximumTabWidth == 0)
          goto label_23;
label_26:
        if (control.MaximumTabWidth >= num1)
        {
          if ((uint) num2 + (uint) num2 >= 0U)
          {
            if ((num1 | 8) != 0)
              goto label_23;
            else
              break;
          }
          else
            goto label_37;
        }
label_31:
        num1 = control.MaximumTabWidth;
        goto label_35;
label_33:
        if (control.MinimumTabWidth != 0)
        {
          num1 = Math.Max(num1, control.MinimumTabWidth);
          goto label_25;
        }
        else if ((uint) x - (uint) x <= uint.MaxValue)
        {
          if ((uint) x + (uint) x >= 0U)
            goto label_25;
          else
            goto label_26;
        }
label_35:
        if ((x & 0) == 0)
        {
          control.xcfac6723d8a41375 = true;
          goto label_23;
        }
        else if ((uint) num1 >= 0U)
          goto label_25;
        else
          break;
label_37:
        if (control.AllowClose)
        {
          num1 += 17;
          if ((uint) num2 - (uint) num1 > uint.MaxValue)
            goto label_31;
          else
            goto label_33;
        }
        else
          goto label_33;
label_42:
        System.Drawing.Size size = x38870620fd380a6b.MeasureDocumentStripTab(x41347a961b838962, control.TabImage, control.TabText, control.Font, state);
        if ((uint) num1 >= 0U)
          goto label_40;
        else
          goto label_38;
label_36:
        if (!this.xa957e8f86f5e6115)
          goto label_33;
        else
          goto label_37;
label_38:
        if ((uint) num2 >= 0U)
          goto label_36;
        else
          goto label_33;
label_40:
        num1 = size.Width;
        goto label_36;
label_43:
        state |= DrawItemState.Selected;
        if (((uint) num2 - (uint) x < 0U || this.DockContainer.Manager != null) && this.DockContainer.Manager.ActiveTabbedDocument == control)
        {
          if ((uint) x + (uint) num1 <= uint.MaxValue)
          {
            state |= DrawItemState.Focus;
            goto label_42;
          }
          else
            goto label_26;
        }
        else
          goto label_42;
      }
      while (this.Controls.Count != 0)
      {
        x += x38870620fd380a6b.DocumentTabExtra;
        if ((uint) x >= 0U)
          break;
      }
      x += 3;
      num2 = xa358da7dd5364cab.Width - this.LeftPadding - this.RightPadding;
label_17:
      this.x4f8ccd50477a481e = x - num2;
      while (this.x4f8ccd50477a481e < 0)
      {
        this.x4f8ccd50477a481e = 0;
        if ((uint) x <= uint.MaxValue)
        {
          if (true)
            break;
          goto label_17;
        }
      }
      goto label_12;
    }

    public override DockControl SelectedControl
    {
      get
      {
        return base.SelectedControl;
      }
      set
      {
        base.SelectedControl = value;
        if (value == null)
          return;
        this.xd4949976eef9c304(value);
      }
    }

    private void xd4949976eef9c304(DockControl x43bec302f92080b9)
    {
      if (this.x4f8ccd50477a481e <= 0)
        return;
      int num1;
      if ((num1 | 1) != 0)
        goto label_10;
label_3:
      int num2;
      if ((uint) num2 + (uint) num2 < 0U)
        ;
label_6:
      int xa00f04d8b3a6664c;
      if (xa00f04d8b3a6664c == 0)
        return;
      this.x523c1f22a806032d(xa00f04d8b3a6664c);
      return;
label_10:
      Rectangle x123e054dab107457 = x43bec302f92080b9.x123e054dab107457;
      int num3 = this.xa358da7dd5364cab.Right - this.RightPadding;
      int num4 = this.xa358da7dd5364cab.Left + this.LeftPadding;
      num2 = num3 - num4;
      xa00f04d8b3a6664c = 0;
      if (x123e054dab107457.Right > num3)
        goto label_8;
label_5:
      if (x123e054dab107457.Left < num4)
      {
        xa00f04d8b3a6664c = x123e054dab107457.Left - num4 - 30;
        goto label_3;
      }
      else
        goto label_6;
label_8:
      xa00f04d8b3a6664c = x123e054dab107457.Right - num2 + 30;
      goto label_5;
    }

    private void xd11b6d3bf98020cb()
    {
      this.x5d56ae798b9cdf38.Enabled = false;
      this.x1f43ebe301d1df45 = (x0a9f5257a10031b2) null;
      this.xfa5e20eb950b9ee1 = false;
      this.xd541e2fc281b554b();
    }

    private void xcf8b319f2bffca87()
    {
      this.x5d56ae798b9cdf38.Enabled = true;
      this.xcaf19fd9570f4eb4((object) this.x5d56ae798b9cdf38, EventArgs.Empty);
    }

    private void x523c1f22a806032d(int xa00f04d8b3a6664c)
    {
      this.x200b7f5a9d983ba4 += xa00f04d8b3a6664c;
label_8:
      if (this.x200b7f5a9d983ba4 > this.x4f8ccd50477a481e)
        goto label_6;
      else
        goto label_9;
label_1:
      if (this.x200b7f5a9d983ba4 >= 0)
      {
        if (false)
          goto label_6;
      }
      else
        goto label_5;
label_3:
      this.x3e0280cae730d1f2();
      return;
label_5:
      this.x200b7f5a9d983ba4 = 0;
      this.xd11b6d3bf98020cb();
      goto label_3;
label_6:
      this.x200b7f5a9d983ba4 = this.x4f8ccd50477a481e;
      this.xd11b6d3bf98020cb();
      if (false)
        ;
      if ((xa00f04d8b3a6664c & 0) != 0)
        goto label_8;
      else
        goto label_1;
label_9:
      if (true)
        goto label_1;
    }

    private void xcaf19fd9570f4eb4(object xe0292b9ed559da7d, EventArgs xfbf34718e704c6bc)
    {
      if (this.x1f43ebe301d1df45 != this.x49dae83181e41d72)
      {
        if (this.x1f43ebe301d1df45 == this.xa8ae81960654bc0b)
        {
          this.x523c1f22a806032d(15);
          if (false)
            ;
          return;
        }
        this.xd11b6d3bf98020cb();
        if (true)
          return;
      }
      this.x523c1f22a806032d(-15);
    }
  }
}
