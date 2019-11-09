// Decompiled with JetBrains decompiler
// Type: TD.SandDock.SandDockManager
// Assembly: SandDock, Version=3.0.5.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3
// MVID: 9FE0BBF2-384E-4D66-8EFA-4A1DD4A32257
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\SandDock.dll

using Divelements.Util.Registration;
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.Layout;
using System.Xml;
using TD.SandDock.Rendering;

namespace TD.SandDock
{
  [DefaultEvent("ActiveTabbedDocumentChanged")]
  [ToolboxBitmap(typeof (SandDockManager))]
  [Designer("TD.SandDock.Design.SandDockManagerDesigner, SandDock.Design, Version=1.0.0.1, Culture=neutral, PublicKeyToken=75b7ec17dd7c14c3")]
  public class SandDockManager : Component
  {
    private DockingHints x48cee1d69929b4fe = DockingHints.TranslucentFill;
    private DockingManager x531514c39973cbc6 = DockingManager.Whidbey;
    private int xdca928fc295dbb2a = 30;
    private int xb3f3aa0fff672c52 = 500;
    private bool xf702e23ec6dfb474 = true;
    private bool xab09a805ddd3c3a1 = true;
    private bool xd76156c80fb2abda = true;
    private bool x46d0951c16d6ad61 = true;
    private TD.SandDock.Rendering.BorderStyle xacfbd7a08ba56c78 = TD.SandDock.Rendering.BorderStyle.Flat;
    private DocumentOverflowMode x8362acb4106ff84c = DocumentOverflowMode.Scrollable;
    private DocumentContainerWindowOpenPosition xf57f78376726d093 = DocumentContainerWindowOpenPosition.Last;
    internal ArrayList xd27fa35d10494112;
    internal ArrayList xa90af1bb0ada0f53;
    private Hashtable x8fb2a5bf0df0416f;
    private DockControl x4daa1b665423612a;
    private RendererBase x38870620fd380a6b;
    private bool xcc4067ee19f6f422;
    private bool xac286b48606510c1;
    private bool xb379517eb20fde45;
    private bool x2b7e44f0a217252e;
    private bool x26be2ab374407894;
    private DocumentContainer x1f1a3b29d7ed7776;
    private bool x1bb166050445ea16;
    private Form x9492ad63ba3e62cf;
    private Control x7478f4855b6bd03d;

    public event EventHandler DockingStarted;

    public event EventHandler DockingFinished;

    public event ShowControlContextMenuEventHandler ShowControlContextMenu;

    public event DockControlEventHandler DockControlActivated;

    public event DockControlEventHandler DockControlAdded;

    public event DockControlEventHandler DockControlRemoved;

    public event ResolveDockControlEventHandler ResolveDockControl;

    public event EventHandler ActiveTabbedDocumentChanged;

    public event DockControlClosingEventHandler DockControlClosing;

    public event ActiveFilesListEventHandler ShowActiveFilesList;

    public SandDockManager()
    {
      this.x38870620fd380a6b = (RendererBase) new WhidbeyRenderer();
      this.xd27fa35d10494112 = new ArrayList();
      this.x8fb2a5bf0df0416f = new Hashtable();
      this.xa90af1bb0ada0f53 = new ArrayList();
    }

    public DockControl FindMostRecentlyUsedWindow()
    {
      return this.FindMostRecentlyUsedWindow(~DockSituation.None);
    }

    public DockControl FindMostRecentlyUsedWindow(DockSituation dockSituation)
    {
      return this.FindMostRecentlyUsedWindow(dockSituation, (DockControl) null);
    }

    internal DockControl FindMostRecentlyUsedWindow(
      DockSituation dockSituation,
      DockControl notThisOne)
    {
      DateTime dateTime = DateTime.MinValue;
      int index;
      DockControl dockControl1;
      do
      {
        dockControl1 = (DockControl) null;
        DockControl[] dockControls = this.GetDockControls();
        if ((index & 0) == 0)
          goto label_14;
        else
          goto label_9;
label_1:
        DockControl dockControl2;
        if (dockControl2.MetaData.LastFocused >= dateTime)
          goto label_11;
label_3:
        ++index;
label_4:
        if (index < dockControls.Length)
        {
          dockControl2 = dockControls[index];
          goto label_9;
        }
        else
          goto label_13;
label_5:
        if (dockControl2 != notThisOne)
        {
          if ((uint) index - (uint) index <= uint.MaxValue)
            goto label_1;
          else
            goto label_13;
        }
        else
          goto label_3;
label_8:
        dockControl1 = dockControl2;
        goto label_3;
label_9:
        if ((uint) index <= uint.MaxValue)
        {
          if (true)
            goto label_5;
          else
            goto label_1;
        }
        else
          goto label_8;
label_11:
        if (dockSituation != ~DockSituation.None)
          goto label_12;
label_7:
        dateTime = dockControl2.MetaData.LastFocused;
        goto label_8;
label_12:
        if (true)
        {
          if (dockControl2.DockSituation == dockSituation)
            goto label_7;
          else
            goto label_3;
        }
        else
          goto label_5;
label_13:
        continue;
label_14:
        if ((index & 0) != 0 || true)
        {
          index = 0;
          goto label_4;
        }
        else
          goto label_11;
      }
      while ((uint) index + (uint) index < 0U);
      return dockControl1;
    }

    protected internal virtual void OnShowActiveFilesList(ActiveFilesListEventArgs e)
    {
      if (this.x310e5e7c96407793 == null)
        return;
      this.x310e5e7c96407793((object) this, e);
    }

    [Browsable(false)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public DockControl ActiveTabbedDocument
    {
      get
      {
        return this.x4daa1b665423612a;
      }
    }

    private void SetActiveTabbedDocument(DockControl value)
    {
      if (value != null)
        goto label_14;
label_3:
      while (value != this.x4daa1b665423612a)
      {
        if (this.x4daa1b665423612a == null)
          goto label_6;
        else
          goto label_11;
label_2:
        this.OnActiveTabbedDocumentChanged(EventArgs.Empty);
        return;
label_6:
        this.x4daa1b665423612a = value;
        if (true)
        {
          if (true)
          {
            if (false)
              goto label_5;
label_1:
            if (this.x4daa1b665423612a == null)
              goto label_2;
label_5:
            this.x4daa1b665423612a.DockSituationChanged += new EventHandler(this.OnActiveTabbedDocumentDockSituationChanged);
            this.x4daa1b665423612a.x7735d9a753c63a0a();
            if (false)
              goto label_1;
            else
              goto label_2;
          }
          else
            break;
        }
        else
          continue;
label_11:
        if (true)
        {
          this.x4daa1b665423612a.DockSituationChanged -= new EventHandler(this.OnActiveTabbedDocumentDockSituationChanged);
          if (false)
            goto label_2;
        }
        this.x4daa1b665423612a.x7735d9a753c63a0a();
        goto label_6;
      }
      if (true)
        return;
label_14:
      if (value.DockSituation != DockSituation.Document)
        throw new ArgumentException("The specified window is not currently being displayed as a document, therefore it cannot be set as the active document.", nameof (value));
      goto label_3;
    }

    private void OnActiveTabbedDocumentDockSituationChanged(object sender, EventArgs e)
    {
      if (((DockControl) sender).DockSituation == DockSituation.Document)
        return;
      this.SetActiveTabbedDocument(this.FindMostRecentlyUsedWindow(DockSituation.Document));
    }

    [Category("Behavior")]
    [Description("Indicates whether an empty container is left when all tabbed documents have been removed.")]
    [DefaultValue(false)]
    public bool EnableEmptyEnvironment
    {
      get
      {
        return this.xac286b48606510c1;
      }
      set
      {
        this.xac286b48606510c1 = value;
      }
    }

    [Description("The type of border to be drawn around the tabbed document area.")]
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
        if (this.DocumentContainer == null)
          return;
        this.DocumentContainer.x64b4c49ed703037e = this.xacfbd7a08ba56c78;
      }
    }

    [Browsable(false)]
    public DocumentContainer DocumentContainer
    {
      get
      {
        return this.x1f1a3b29d7ed7776;
      }
    }

    [Description("Determines how document tabs that overflow past the visible area are accessed.")]
    [Category("Behavior")]
    [DefaultValue(typeof (DocumentOverflowMode), "Scrollable")]
    public DocumentOverflowMode DocumentOverflow
    {
      get
      {
        return this.x8362acb4106ff84c;
      }
      set
      {
        if (value == this.x8362acb4106ff84c)
          return;
        this.x8362acb4106ff84c = value;
        if (this.DocumentContainer == null)
          return;
        this.DocumentContainer.x7d2c5325d16e569d = this.DocumentOverflow;
      }
    }

    [Description("Specifies whether documents are opened at the first position or the last.")]
    [Category("Behavior")]
    [DefaultValue(typeof (DocumentContainerWindowOpenPosition), "Last")]
    public DocumentContainerWindowOpenPosition DocumentOpenPosition
    {
      get
      {
        return this.xf57f78376726d093;
      }
      set
      {
        this.xf57f78376726d093 = value;
      }
    }

    [Description("Indicates whether the close button is displayed inside the active tab.")]
    [Category("Behavior")]
    [DefaultValue(false)]
    public bool IntegralClose
    {
      get
      {
        return this.x26be2ab374407894;
      }
      set
      {
        if (value == this.x26be2ab374407894)
          return;
        this.x26be2ab374407894 = value;
        while (this.DocumentContainer != null)
        {
          this.DocumentContainer.xa957e8f86f5e6115 = this.IntegralClose;
          if (true)
            break;
        }
      }
    }

    [Description("Indicates whether tabbed documents can be shown in the centre of the container.")]
    [DefaultValue(true)]
    [Category("Behavior")]
    public bool EnableTabbedDocuments
    {
      get
      {
        return this.xd76156c80fb2abda;
      }
      set
      {
        if (this.FindDockedContainer(DockStyle.Fill) != null)
          throw new InvalidOperationException("This property can only be changed when there are no DockControls being shown in the centre of the container.");
        this.xd76156c80fb2abda = value;
      }
    }

    [Browsable(false)]
    [Obsolete("Use the GetDockControls method passing DockSituation.Document instead.")]
    public DockControl[] Documents
    {
      get
      {
        return this.GetDockControls(DockSituation.Document);
      }
    }

    [DefaultValue(false)]
    [Description("Indicates whether the user-configured window layout is automatically persisted.")]
    [Category("Behavior")]
    public bool AutoSaveLayout
    {
      get
      {
        return this.x2b7e44f0a217252e;
      }
      set
      {
        this.x2b7e44f0a217252e = value;
      }
    }

    [Description("Indicates whether the user will be able to use the keyboard to navigate between tabbed documents and dockable windows.")]
    [DefaultValue(true)]
    [Category("Behavior")]
    public bool AllowKeyboardNavigation
    {
      get
      {
        return this.xab09a805ddd3c3a1;
      }
      set
      {
        this.xab09a805ddd3c3a1 = value;
      }
    }

    [Category("Behavior")]
    [Description("Indicates whether the middle mouse button can be used to close windows by their tabs.")]
    [DefaultValue(true)]
    public bool AllowMiddleButtonClosure
    {
      get
      {
        return this.x46d0951c16d6ad61;
      }
      set
      {
        this.x46d0951c16d6ad61 = value;
      }
    }

    [Description("Indicates whether standard validation events are fired when the user changes tabs.")]
    [Category("Behavior")]
    [DefaultValue(false)]
    public bool RaiseValidationEvents
    {
      get
      {
        return this.xcc4067ee19f6f422;
      }
      set
      {
        this.xcc4067ee19f6f422 = value;
      }
    }

    [DefaultValue(false)]
    [Category("Behavior")]
    [Description("Indicates whether window groups will respond when an OLE drag operation occurs over their tabs.")]
    public bool SelectTabsOnDrag
    {
      get
      {
        return this.xb379517eb20fde45;
      }
      set
      {
        this.xb379517eb20fde45 = value;
        foreach (Control control in this.xd27fa35d10494112)
          control.AllowDrop = value;
        foreach (Control control in this.xa90af1bb0ada0f53)
          control.AllowDrop = value;
      }
    }

    [Description("Indicates whether tabbed document layout will be serialized alongside dockable window layout.")]
    [Category("Serialization")]
    [DefaultValue(false)]
    public bool SerializeTabbedDocuments
    {
      get
      {
        return this.x1bb166050445ea16;
      }
      set
      {
        this.x1bb166050445ea16 = value;
      }
    }

    [DefaultValue(true)]
    [Description("Indicates whether DockContainers can be resized by the user.")]
    [Category("Behavior")]
    public bool AllowDockContainerResize
    {
      get
      {
        return this.xf702e23ec6dfb474;
      }
      set
      {
        this.xf702e23ec6dfb474 = value;
        DockContainer[] dockContainerList = this.GetOrderedDockedDockContainerList();
        int index = 0;
        while (true)
        {
          DockContainer dockContainer;
          if (index >= dockContainerList.Length)
          {
            if ((uint) index - (uint) index >= 0U)
              break;
          }
          else
            dockContainer = dockContainerList[index];
          dockContainer.CalculateAllMetricsAndLayout();
          ++index;
        }
      }
    }

    internal x10ac79a4257c7f52 GetAutoHideBar(DockStyle dock)
    {
      if (dock == DockStyle.Fill || dock == DockStyle.None)
        return (x10ac79a4257c7f52) null;
      IEnumerator enumerator = this.xa90af1bb0ada0f53.GetEnumerator();
      x10ac79a4257c7f52 x10ac79a4257c7f52_1;
      try
      {
        while (enumerator.MoveNext())
        {
          x10ac79a4257c7f52 current = (x10ac79a4257c7f52) enumerator.Current;
          if (false)
            ;
          if (current.Dock == dock)
          {
            x10ac79a4257c7f52_1 = current;
            goto label_16;
          }
        }
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        if (true)
          goto label_10;
label_9:
        disposable.Dispose();
        if (true)
          goto label_11;
label_10:
        if (disposable != null)
          goto label_9;
label_11:;
      }
      this.DockSystemContainer.SuspendLayout();
      try
      {
        x10ac79a4257c7f52 x10ac79a4257c7f52_2 = new x10ac79a4257c7f52();
        x10ac79a4257c7f52_2.x460ab163f44a604d = this;
        x10ac79a4257c7f52_2.Dock = dock;
        if (true)
        {
          x10ac79a4257c7f52_2.Parent = this.DockSystemContainer;
          this.DockSystemContainer.Controls.SetChildIndex((Control) x10ac79a4257c7f52_2, this.GetOutsideControlIndex(this.DockSystemContainer, dock));
          x10ac79a4257c7f52_1 = x10ac79a4257c7f52_2;
        }
      }
      finally
      {
        this.DockSystemContainer.ResumeLayout();
      }
label_16:
      return x10ac79a4257c7f52_1;
    }

    protected virtual DockContainer CreateNewDockContainerCore(
      ContainerDockLocation dockLocation)
    {
      if (dockLocation == ContainerDockLocation.Center && this.EnableTabbedDocuments)
        return (DockContainer) new DocumentContainer();
      return new DockContainer();
    }

    public DockContainer CreateNewDockContainer(
      ContainerDockLocation dockLocation,
      ContainerDockEdge edge,
      int contentSize)
    {
      this.EnsureDockSystemContainer();
      this.DockSystemContainer.SuspendLayout();
      try
      {
        DockContainer dockContainerCore = this.CreateNewDockContainerCore(dockLocation);
label_19:
        dockContainerCore.Manager = this;
        DockStyle dockStyle = LayoutUtilities.xf8330a3964a419ba(dockLocation);
        dockContainerCore.Dock = dockStyle;
        dockContainerCore.ContentSize = contentSize;
        IntPtr handle = dockContainerCore.Handle;
        int newIndex;
        if ((uint) newIndex + (uint) contentSize > uint.MaxValue || dockLocation != ContainerDockLocation.Center)
        {
          while (edge == ContainerDockEdge.Inside)
          {
            newIndex = this.GetInsideControlIndex(this.DockSystemContainer);
            if ((uint) contentSize + (uint) newIndex < 0U)
            {
              if ((uint) newIndex - (uint) newIndex < 0U)
                goto label_19;
            }
            else
              goto label_15;
          }
          newIndex = this.GetOutsideControlIndex(this.DockSystemContainer, dockStyle);
        }
        else
          goto label_16;
label_15:
        this.DockSystemContainer.Controls.Add((Control) dockContainerCore);
        this.DockSystemContainer.Controls.SetChildIndex((Control) dockContainerCore, newIndex);
        foreach (Control control in (ArrangedElementCollection) this.DockSystemContainer.Controls)
        {
          x87cf4de36131799d x87cf4de36131799d;
          do
          {
            x87cf4de36131799d = control as x87cf4de36131799d;
            if (false)
              ;
            if (x87cf4de36131799d != null)
              goto label_4;
          }
          while ((uint) newIndex + (uint) newIndex > uint.MaxValue);
          goto label_8;
label_4:
          x87cf4de36131799d.BringToFront();
          continue;
label_8:
          if ((uint) newIndex + (uint) newIndex > uint.MaxValue)
            break;
        }
        return dockContainerCore;
label_16:
        newIndex = 0;
        goto label_15;
      }
      finally
      {
        this.DockSystemContainer.ResumeLayout();
      }
    }

    private int GetInsideControlIndex(Control container)
    {
      int num = int.MaxValue;
      int index = container.Controls.Count - 1;
label_1:
      while (index >= 0)
      {
        Control control = container.Controls[index];
        if (control.Dock != DockStyle.Fill)
          goto label_7;
label_3:
        --index;
        continue;
label_7:
        while (control.Dock != DockStyle.None)
        {
          if ((uint) index - (uint) num <= uint.MaxValue)
          {
            if ((uint) index + (uint) index >= 0U)
            {
              while (index < num)
              {
                num = index;
                if ((uint) index - (uint) num >= 0U)
                {
                  if ((uint) num > uint.MaxValue)
                    goto label_7;
                  else
                    break;
                }
              }
              break;
            }
          }
          else
            goto label_1;
        }
        goto label_3;
      }
      return num;
    }

    internal DockContainer[] GetDockContainers(DockStyle dockStyle)
    {
      if (dockStyle == DockStyle.Fill)
        goto label_13;
label_10:
      while (this.DockSystemContainer != null)
      {
        int length;
        DockContainer[] dockContainerArray1;
        if (true)
        {
          dockContainerArray1 = new DockContainer[this.DockSystemContainer.Controls.Count];
          length = 0;
        }
        int index;
        if ((uint) index - (uint) index >= 0U)
          goto label_7;
label_1:
        while (index >= 0)
        {
          DockContainer control = this.DockSystemContainer.Controls[index] as DockContainer;
          if (control != null && ((length & 0) != 0 || control.Dock == dockStyle))
            goto label_5;
label_3:
          --index;
          if ((uint) index <= uint.MaxValue)
            goto label_6;
          else
            continue;
label_5:
          dockContainerArray1[length++] = control;
          if ((index | int.MinValue) != 0)
            goto label_3;
label_6:
          if ((length & 0) != 0)
            goto label_10;
        }
        DockContainer[] dockContainerArray2 = new DockContainer[length];
        Array.Copy((Array) dockContainerArray1, (Array) dockContainerArray2, length);
        if ((length & 0) == 0)
          return dockContainerArray2;
        goto label_13;
label_7:
        index = this.DockSystemContainer.Controls.Count - 1;
        if (true)
          goto label_1;
      }
      return new DockContainer[0];
label_13:
      if (true)
        throw new ArgumentException(nameof (dockStyle));
      goto label_10;
    }

    private int GetOutsideControlIndex(Control container, DockStyle dockStyle)
    {
      int num = container.Controls.Count;
      int index = container.Controls.Count - 1;
      while (true)
      {
        Control control;
        do
        {
          if (index < 0)
          {
            if ((uint) index > uint.MaxValue)
            {
              if (true)
                goto label_11;
            }
            else
              goto label_14;
          }
          else
            goto label_13;
label_9:
          continue;
label_11:
          if (!(control is DockContainer))
          {
            if ((uint) num + (uint) num > uint.MaxValue)
              goto label_14;
            else
              goto label_9;
          }
          else
            goto label_2;
label_13:
          control = container.Controls[index];
          if (control.Dock != DockStyle.Fill || control is MdiClient)
            goto label_11;
          else
            goto label_1;
        }
        while ((uint) index > uint.MaxValue);
        goto label_10;
label_1:
        if ((num & 0) == 0)
          break;
        goto label_3;
label_2:
        if (!(control is DockContainer))
          goto label_5;
label_3:
        if (control.Dock == dockStyle)
        {
          if ((uint) num < 0U)
            goto label_2;
          else
            break;
        }
label_5:
        --index;
        continue;
label_10:
        num = index;
        goto label_2;
      }
label_14:
      return num;
    }

    private void EnsureDockSystemContainer()
    {
      if (this.DockSystemContainer == null)
        throw new InvalidOperationException("This SandDockManager does not have its DockSystemContainer property set.");
    }

    [Description("The control that will act as a container for all docked windows. You should rarely, if ever, need to change this property.")]
    [Category("Advanced")]
    public Control DockSystemContainer
    {
      get
      {
        return this.x7478f4855b6bd03d;
      }
      set
      {
        if (value == null)
          throw new ArgumentNullException(nameof (value));
        if (value is DockContainer)
          throw new ArgumentException("A DockContainer cannot act as a host for a SandDock layout.");
        if (value == this.x7478f4855b6bd03d)
          return;
        ArrayList arrayList = new ArrayList();
        foreach (DockContainer dockContainer in this.xd27fa35d10494112)
        {
          do
          {
            if (true)
            {
              if (dockContainer.Parent != null)
                goto label_8;
            }
            else
              goto label_11;
          }
          while (false);
          goto label_10;
label_8:
          if (dockContainer.Parent != value)
            goto label_12;
          else
            continue;
label_10:
          if (false)
          {
            if (true)
              goto label_8;
            else
              break;
          }
          else
            continue;
label_11:
          if (true)
            goto label_8;
label_12:
          arrayList.Add((object) dockContainer);
        }
        if (this.x7478f4855b6bd03d != null)
          goto label_20;
label_4:
        this.x7478f4855b6bd03d = value;
        if (this.x7478f4855b6bd03d != null)
          goto label_2;
label_1:
        value.Controls.AddRange((Control[]) arrayList.ToArray(typeof (Control)));
        return;
label_2:
        this.x7478f4855b6bd03d.Resize += new EventHandler(this.OnDockSystemContainerResize);
        goto label_1;
label_20:
        this.x7478f4855b6bd03d.Resize -= new EventHandler(this.OnDockSystemContainerResize);
        if (true)
          goto label_4;
      }
    }

    protected internal virtual void OnShowControlContextMenu(ShowControlContextMenuEventArgs e)
    {
      if (this.x8956f13386ebab05 == null)
        return;
      this.x8956f13386ebab05((object) this, e);
    }

    internal void RegisterWindow(DockControl control)
    {
      this.x8fb2a5bf0df0416f[(object) control.Guid] = (object) control;
      this.OnDockControlAdded(new DockControlEventArgs(control));
    }

    internal void ReRegisterWindow(DockControl control, Guid oldGuid)
    {
      if (this.x8fb2a5bf0df0416f.Contains((object) oldGuid))
        this.x8fb2a5bf0df0416f.Remove((object) oldGuid);
      this.x8fb2a5bf0df0416f[(object) control.Guid] = (object) control;
    }

    internal void UnregisterWindow(DockControl control)
    {
      this.x8fb2a5bf0df0416f.Remove((object) control.Guid);
      this.OnDockControlRemoved(new DockControlEventArgs(control));
    }

    protected virtual void OnDockControlAdded(DockControlEventArgs e)
    {
      if (this.x528e78a16a92fb41 == null)
        return;
      this.x528e78a16a92fb41((object) this, e);
    }

    protected virtual void OnDockControlRemoved(DockControlEventArgs e)
    {
      if (this.xbc613baf913a9f51 == null)
        return;
      this.xbc613baf913a9f51((object) this, e);
    }

    protected internal virtual void OnDockControlActivated(DockControlEventArgs e)
    {
      if (this.x505fd87f59cc2876 != null)
        this.x505fd87f59cc2876((object) this, e);
      if (e.DockControl.DockSituation != DockSituation.Document)
        return;
      this.SetActiveTabbedDocument(e.DockControl);
    }

    [Description("Indicates the type of visual artifacts drawn to the screen to indicate size and position while docking.")]
    [DefaultValue(typeof (DockingHints), "TranslucentFill")]
    [Category("Appearance")]
    public DockingHints DockingHints
    {
      get
      {
        return this.x48cee1d69929b4fe;
      }
      set
      {
        this.x48cee1d69929b4fe = value;
      }
    }

    [DefaultValue(30)]
    [Category("Behavior")]
    [Description("Indicates the minimum size of a docked strip of toolwindows.")]
    public int MinimumDockContainerSize
    {
      get
      {
        return this.xdca928fc295dbb2a;
      }
      set
      {
        this.xdca928fc295dbb2a = value;
      }
    }

    [Description("Indicates the maximum size of a docked strip of toolwindows.")]
    [Category("Behavior")]
    [DefaultValue(500)]
    public int MaximumDockContainerSize
    {
      get
      {
        return this.xb3f3aa0fff672c52;
      }
      set
      {
        this.xb3f3aa0fff672c52 = value;
      }
    }

    [Category("Behavior")]
    [Description("Indicates the method of user interaction during a docking operation.")]
    [DefaultValue(typeof (DockingManager), "Whidbey")]
    public DockingManager DockingManager
    {
      get
      {
        return this.x531514c39973cbc6;
      }
      set
      {
        this.x531514c39973cbc6 = value;
      }
    }

    private void EnsureHandles()
    {
    }

    public void SetLayout(string layout)
    {
      this.EnsureDockSystemContainer();
      int num1;
      int num2;
      ArrayList arrayList;
      x410f3612b9a8f9de[] dockContainerList1;
      int num3;
      DockContainer[] dockContainerList2;
      XmlDocument xmlDocument;
      do
      {
        this.EnsureHandles();
        xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(layout);
        do
        {
          this.GetLayout();
          dockContainerList2 = this.GetOrderedDockedDockContainerList();
        }
        while ((uint) num1 > uint.MaxValue);
        dockContainerList1 = this.GetFloatingDockContainerList();
        num3 = 0;
        num1 = 0;
        arrayList = new ArrayList((ICollection) dockContainerList2);
        arrayList.AddRange((ICollection) dockContainerList1);
      }
      while ((uint) num1 - (uint) num2 > uint.MaxValue);
      DocumentContainer documentContainer = (DocumentContainer) null;
      if (this.SerializeTabbedDocuments)
        documentContainer = this.FindDockedContainer(DockStyle.Fill) as DocumentContainer;
      if (documentContainer != null)
        arrayList.Add((object) documentContainer);
      int index1;
      try
      {
        IEnumerator enumerator1 = arrayList.GetEnumerator();
        try
        {
          while (enumerator1.MoveNext())
            ((DockContainer) enumerator1.Current).x272ed7848e373c56();
        }
        finally
        {
          IDisposable disposable = enumerator1 as IDisposable;
          if ((uint) num2 > uint.MaxValue || disposable != null)
            disposable.Dispose();
        }
        int index2;
        do
        {
          this.DockSystemContainer.SuspendLayout();
label_30:
          XmlNode xmlNode = xmlDocument.GetElementsByTagName("Layout")[0];
label_31:
          IEnumerator enumerator2 = xmlNode.ChildNodes.GetEnumerator();
          int index3;
          try
          {
            do
            {
              if (enumerator2.MoveNext())
                goto label_68;
              else
                goto label_39;
label_33:
              if ((uint) index3 - (uint) num1 <= uint.MaxValue)
                continue;
label_36:
              XmlNode current;
              if (current.HasChildNodes)
              {
                x410f3612b9a8f9de container = (x410f3612b9a8f9de) null;
                if (num1 < dockContainerList1.Length)
                {
                  if (true)
                    container = dockContainerList1[num1++];
                  else
                    goto label_57;
                }
                this.ReadFloatingContainerProperties(current, container);
                if (true)
                  continue;
              }
              else
                continue;
label_37:
              if (current.NodeType != XmlNodeType.Element)
                continue;
label_38:
              if (!(current.Name == "FloatingContainer"))
              {
                if ((uint) num3 + (uint) index3 < 0U)
                  goto label_47;
                else
                  goto label_33;
              }
              else
                goto label_36;
label_39:
              if ((uint) index3 >= 0U)
                break;
              goto label_56;
label_47:
              if ((uint) num1 - (uint) index3 > uint.MaxValue)
                goto label_54;
label_48:
              if (!(current.Name == "DocumentContainer"))
                goto label_37;
label_49:
              DockContainer container1;
              if (!current.HasChildNodes)
              {
                if (false)
                {
                  if ((uint) index3 <= uint.MaxValue)
                  {
                    if ((num1 & 0) == 0)
                    {
                      if ((uint) index3 - (uint) num1 < 0U)
                        goto label_48;
                    }
                    else
                      goto label_47;
                  }
                  if (true)
                    goto label_37;
                  else
                    goto label_48;
                }
                else
                  goto label_37;
              }
              else
              {
                container1 = (DockContainer) null;
                if ((uint) index1 <= uint.MaxValue && !(current.Name == "DocumentContainer"))
                {
                  if (current.Name == "Container" && num3 < dockContainerList2.Length)
                    goto label_56;
                }
                else
                  goto label_57;
              }
label_53:
              this.ReadContainerProperties(current, container1);
              continue;
label_54:
              if (current.Name == "Container")
                goto label_49;
              else
                goto label_48;
label_56:
              container1 = dockContainerList2[num3++];
              if (false)
                goto label_33;
              else
                goto label_53;
label_57:
              if (documentContainer != null)
              {
                container1 = (DockContainer) documentContainer;
                documentContainer = (DocumentContainer) null;
                goto label_53;
              }
              else
                goto label_53;
label_68:
              current = (XmlNode) enumerator2.Current;
              while (current.NodeType != XmlNodeType.Element)
              {
                if ((uint) index2 < 0U)
                {
                  if ((uint) num1 - (uint) index1 > uint.MaxValue)
                  {
                    if ((index1 | 1) != 0)
                      ;
                  }
                  else
                    break;
                }
                else
                  goto label_63;
              }
              goto label_66;
label_63:
              if (current.NodeType != XmlNodeType.Element)
                goto label_37;
              else
                goto label_54;
label_66:
              if (current.Name == "Window")
              {
                this.ReadWindowProperties(current);
                if (false)
                {
                  if (true)
                    goto label_38;
                  else
                    goto label_36;
                }
              }
              else
                goto label_63;
            }
            while (true);
          }
          finally
          {
            (enumerator2 as IDisposable)?.Dispose();
          }
          for (index3 = num3; index3 < dockContainerList2.Length; ++index3)
            dockContainerList2[index3].Dispose();
          do
          {
            for (index1 = num1; index1 < dockContainerList1.Length; ++index1)
            {
              dockContainerList1[index1].Dispose();
              if ((uint) num1 < 0U)
                goto label_30;
            }
            if ((uint) index1 - (uint) index2 <= uint.MaxValue)
            {
              if ((uint) index3 + (uint) index1 <= uint.MaxValue)
              {
                documentContainer?.Dispose();
                DockControl[] dockControls = this.GetDockControls();
                for (index2 = 0; index2 < dockControls.Length; ++index2)
                {
                  DockControl dockControl = dockControls[index2];
                  if (!dockControl.x1a9802d2d8708515 && dockControl.CloseAction == DockControlCloseAction.Dispose)
                    dockControl.Dispose();
                }
              }
              if ((uint) num3 - (uint) index3 >= 0U)
                goto label_72;
            }
            else
              goto label_31;
          }
          while ((uint) num3 + (uint) num3 < 0U);
          goto label_30;
label_72:;
        }
        while ((uint) index2 > uint.MaxValue);
      }
      catch (Exception ex)
      {
        throw new ArgumentException("The layout information provided could not be interpreted.", ex);
      }
      finally
      {
        IEnumerator enumerator = arrayList.GetEnumerator();
        try
        {
label_80:
          if (!enumerator.MoveNext())
          {
            if (true)
              goto label_88;
          }
          DockContainer current = (DockContainer) enumerator.Current;
          if ((num1 | 1) == 0)
            goto label_83;
label_77:
          if (current == null)
          {
            if ((uint) num1 - (uint) index1 >= 0U)
              goto label_80;
          }
          else
            goto label_83;
label_79:
          if (false)
            goto label_77;
          else
            goto label_80;
label_83:
          if (!current.IsDisposed)
          {
            current.xfe00f14c7d278916();
            goto label_79;
          }
          else
            goto label_80;
        }
        finally
        {
          (enumerator as IDisposable)?.Dispose();
        }
label_88:
        this.DockSystemContainer.ResumeLayout();
      }
    }

    private bool ConvertStringToBool(string str)
    {
      return !(str == "0");
    }

    private System.Drawing.Point ConvertStringToPoint(string str)
    {
      return (System.Drawing.Point) TypeDescriptor.GetConverter(typeof (System.Drawing.Point)).ConvertFrom((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) str);
    }

    private System.Drawing.Size ConvertStringToSize(string str)
    {
      return (System.Drawing.Size) TypeDescriptor.GetConverter(typeof (System.Drawing.Size)).ConvertFrom((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) str);
    }

    internal static SizeF ConvertStringToSizeF(string str)
    {
      return (SizeF) TypeDescriptor.GetConverter(typeof (SizeF)).ConvertFrom((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) str);
    }

    private Rectangle ConvertStringToRectangle(string str)
    {
      return (Rectangle) TypeDescriptor.GetConverter(typeof (Rectangle)).ConvertFrom((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) str);
    }

    private void ReadWindowProperties(XmlNode node)
    {
      x245a5abec1c73d3a.x0a680eda7ec8bd81(this, node);
    }

    private void ReadFloatingContainerProperties(XmlNode node, x410f3612b9a8f9de container)
    {
      Rectangle rectangle = this.ConvertStringToRectangle(node.Attributes["Bounds"].Value);
label_19:
      Guid guid = Guid.NewGuid();
      if (true)
        goto label_16;
label_1:
      if (true)
        goto label_3;
label_2:
      if (container == null)
      {
        container = new x410f3612b9a8f9de(this, guid);
        goto label_1;
      }
label_3:
      IEnumerator enumerator = node.ChildNodes.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
        {
          XmlNode current = (XmlNode) enumerator.Current;
          if (current.NodeType == XmlNodeType.Element && current.Name == "SplitLayoutSystem")
          {
            do
            {
              SplitLayoutSystem splitLayoutSystem = this.ReadSplitLayoutSystem(current, (DockContainer) container);
              if (splitLayoutSystem != null)
                container.LayoutSystem = splitLayoutSystem;
              else
                goto label_9;
            }
            while (false);
            continue;
label_9:
            container.Dispose();
            return;
          }
        }
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        while (disposable != null)
        {
          disposable.Dispose();
          if (true)
            break;
        }
      }
      container.x159713d3b60fae0c(rectangle, true, false);
      if (true)
        return;
      if (true)
        goto label_19;
label_16:
      if (node.Attributes["Guid"] != null)
      {
        guid = new Guid(node.Attributes["Guid"].Value);
        goto label_2;
      }
      else
        goto label_2;
    }

    private void ReadContainerProperties(XmlNode containerNode, DockContainer container)
    {
      DockStyle xca9af438b5818619 = (DockStyle) int.Parse(containerNode.Attributes["Dock"].Value);
      int contentSize = 0;
      if (containerNode.Attributes["ContentSize"] != null)
        goto label_18;
label_1:
      if (container == null)
        goto label_14;
label_2:
      container.Dock = xca9af438b5818619;
      container.ContentSize = contentSize;
      IEnumerator enumerator = containerNode.ChildNodes.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
        {
          XmlNode current = (XmlNode) enumerator.Current;
          if (current.NodeType == XmlNodeType.Element && current.Name == "SplitLayoutSystem")
          {
            if (false)
              break;
            SplitLayoutSystem splitLayoutSystem = this.ReadSplitLayoutSystem(current, container);
            if (splitLayoutSystem != null)
            {
              container.LayoutSystem = splitLayoutSystem;
              break;
            }
            container.Dispose();
            if ((uint) contentSize + (uint) contentSize <= uint.MaxValue)
              break;
          }
        }
        return;
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
label_14:
      container = this.CreateNewDockContainer(LayoutUtilities.x3650f3b579b2b4d2(xca9af438b5818619), ContainerDockEdge.Outside, contentSize);
label_15:
      if ((uint) contentSize - (uint) contentSize < 0U)
        goto label_14;
      else
        goto label_2;
label_18:
      contentSize = int.Parse(containerNode.Attributes["ContentSize"].Value);
      if ((uint) contentSize + (uint) contentSize <= uint.MaxValue)
      {
        if (true)
          goto label_1;
        else
          goto label_14;
      }
      else
        goto label_15;
    }

    private SplitLayoutSystem ReadSplitLayoutSystem(
      XmlNode splitNode,
      DockContainer container)
    {
      SizeF sizeF = SandDockManager.ConvertStringToSizeF(splitNode.Attributes["WorkingSize"].Value);
      sizeF.Width = Math.Max(sizeF.Width, 1f);
      ArrayList arrayList;
      Orientation splitMode;
      while (true)
      {
        sizeF.Height = Math.Max(sizeF.Height, 1f);
        splitMode = (Orientation) int.Parse(splitNode.Attributes["SplitMode"].Value);
        arrayList = new ArrayList();
        IEnumerator enumerator = splitNode.ChildNodes.GetEnumerator();
        try
        {
label_10:
          while (true)
          {
            if (enumerator.MoveNext())
              goto label_23;
label_22:
            if (true)
              break;
label_23:
            XmlNode current = (XmlNode) enumerator.Current;
            if (current.NodeType == XmlNodeType.Element && current.Name == "SplitLayoutSystem")
              goto label_24;
label_12:
            if (current.NodeType == XmlNodeType.Element)
            {
              if (false)
              {
                if (false)
                  continue;
              }
              else if (true)
              {
                while (current.Name == "ControlLayoutSystem")
                {
                  ControlLayoutSystem controlLayoutSystem = this.ReadControlLayoutSystem(current, container);
                  if (true)
                  {
                    if (controlLayoutSystem != null)
                    {
                      arrayList.Add((object) controlLayoutSystem);
                      goto label_10;
                    }
                    else
                      goto label_10;
                  }
                }
                if (true)
                {
                  if (true)
                    continue;
                }
                else
                  goto label_22;
              }
              else
                continue;
            }
            else
              continue;
label_15:
            SplitLayoutSystem splitLayoutSystem;
            if (splitLayoutSystem == null)
            {
              if (false)
                goto label_12;
              else
                continue;
            }
            else
            {
              arrayList.Add((object) splitLayoutSystem);
              continue;
            }
label_24:
            if (true)
            {
              splitLayoutSystem = this.ReadSplitLayoutSystem(current, container);
              goto label_15;
            }
            else
              break;
          }
        }
        finally
        {
          (enumerator as IDisposable)?.Dispose();
        }
        if (arrayList.Count == 0)
        {
          if (true)
            return (SplitLayoutSystem) null;
        }
        else
          break;
      }
      return new SplitLayoutSystem(sizeF, splitMode, (LayoutSystemBase[]) arrayList.ToArray(typeof (LayoutSystemBase)));
    }

    private ControlLayoutSystem ReadControlLayoutSystem(
      XmlNode controlNode,
      DockContainer container)
    {
      Guid guid = Guid.Empty;
      if (true)
        goto label_36;
label_34:
      if (controlNode.Attributes["SelectedControl"] != null)
        goto label_35;
      else
        goto label_7;
label_1:
      ControlLayoutSystem newLayoutSystem;
      return newLayoutSystem;
label_7:
      bool flag;
      while (controlNode.Attributes["Guid"] != null)
      {
        guid = new Guid(controlNode.Attributes["Guid"].Value);
        if (((flag ? 1 : 0) & 0) == 0)
          break;
      }
      ArrayList arrayList = new ArrayList();
      foreach (XmlNode childNode in controlNode.ChildNodes)
      {
        if (childNode.NodeType == XmlNodeType.Element && childNode.Name == "Controls")
        {
          IEnumerator enumerator = childNode.ChildNodes.GetEnumerator();
          try
          {
label_13:
            if (!enumerator.MoveNext())
            {
              if ((uint) flag - (uint) flag >= 0U)
                continue;
            }
            XmlNode current = (XmlNode) enumerator.Current;
            while (current.NodeType == XmlNodeType.Element)
            {
              if (current.Name == "Control")
                goto label_23;
              else
                goto label_20;
label_15:
              DockControl control;
              if (control == null)
              {
                if ((uint) flag + (uint) flag > uint.MaxValue)
                  continue;
                break;
              }
label_17:
              arrayList.Add((object) control);
              break;
label_20:
              if (true)
              {
                if (true)
                  break;
                goto label_15;
              }
              else
                goto label_17;
label_23:
              control = this.FindControl(new Guid(current.Attributes["Guid"].Value));
              goto label_15;
            }
            goto label_13;
          }
          finally
          {
            IDisposable disposable = enumerator as IDisposable;
            while (disposable != null)
            {
              disposable.Dispose();
              if ((uint) flag + (uint) flag <= uint.MaxValue)
                break;
            }
          }
        }
      }
      DockControl dockControl;
      SizeF sizeF;
      if (arrayList.Count != 0)
      {
        newLayoutSystem = container.CreateNewLayoutSystem(sizeF);
        newLayoutSystem.Controls.AddRange((DockControl[]) arrayList.ToArray(typeof (DockControl)));
        if (dockControl != null)
          goto label_6;
label_5:
        newLayoutSystem.Collapsed = flag;
        if (true)
        {
          if (guid != Guid.Empty)
          {
            newLayoutSystem.x0217cda8370c1f17 = guid;
            goto label_1;
          }
          else
            goto label_1;
        }
        else
          goto label_37;
label_6:
        newLayoutSystem.SelectedControl = dockControl;
        goto label_5;
      }
label_37:
      return (ControlLayoutSystem) null;
label_35:
      dockControl = this.FindControl(new Guid(controlNode.Attributes["SelectedControl"].Value));
      if (false)
        goto label_1;
      else
        goto label_7;
label_36:
      sizeF = SandDockManager.ConvertStringToSizeF(controlNode.Attributes["WorkingSize"].Value);
      flag = this.ConvertStringToBool(controlNode.Attributes["Collapsed"].Value);
      dockControl = (DockControl) null;
      goto label_34;
    }

    public DockControl FindControl(Guid guid)
    {
      DockControl dockControl = (DockControl) this.x8fb2a5bf0df0416f[(object) guid];
      if (dockControl != null)
        return dockControl;
      ResolveDockControlEventArgs e;
      do
      {
        e = new ResolveDockControlEventArgs(guid);
        this.OnResolveDockControl(e);
        if (e.DockControl != null)
          goto label_2;
      }
      while (false);
      goto label_5;
label_2:
      e.DockControl.Manager = this;
      return e.DockControl;
label_5:
      return (DockControl) null;
    }

    private DockContainer[] GetOrderedDockedDockContainerList()
    {
      if (this.DockSystemContainer == null)
        return new DockContainer[0];
      ArrayList arrayList = new ArrayList();
      int index = 0;
      if ((index | 8) == 0)
        goto label_2;
label_1:
      if (index >= this.DockSystemContainer.Controls.Count)
        return (DockContainer[]) arrayList.ToArray(typeof (DockContainer));
      Control control = this.DockSystemContainer.Controls[index];
      if ((uint) index - (uint) index <= uint.MaxValue && !this.xd27fa35d10494112.Contains((object) control) || control is DocumentContainer)
        goto label_3;
label_2:
      arrayList.Add((object) control);
label_3:
      ++index;
      goto label_1;
    }

    private x410f3612b9a8f9de[] GetFloatingDockContainerList()
    {
      ArrayList arrayList = new ArrayList();
      foreach (DockContainer dockContainer in this.xd27fa35d10494112)
      {
        if (dockContainer.IsFloating)
        {
          arrayList.Add((object) dockContainer);
          if (false)
            break;
        }
      }
      return (x410f3612b9a8f9de[]) arrayList.ToArray(typeof (x410f3612b9a8f9de));
    }

    private string ConvertBoolToString(bool b)
    {
      return !b ? "0" : "1";
    }

    private string ConvertSizeToString(System.Drawing.Size size)
    {
      return (string) TypeDescriptor.GetConverter(typeof (System.Drawing.Size)).ConvertTo((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) size, typeof (string));
    }

    internal static string ConvertSizeFToString(SizeF size)
    {
      return (string) TypeDescriptor.GetConverter(typeof (SizeF)).ConvertTo((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) size, typeof (string));
    }

    private string ConvertPointToString(System.Drawing.Point point)
    {
      return (string) TypeDescriptor.GetConverter(typeof (System.Drawing.Point)).ConvertTo((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) point, typeof (string));
    }

    private string ConvertRectangleToString(Rectangle rectangle)
    {
      return (string) TypeDescriptor.GetConverter(typeof (Rectangle)).ConvertTo((ITypeDescriptorContext) null, CultureInfo.InvariantCulture, (object) rectangle, typeof (string));
    }

    private string GetSettingsKey()
    {
      if (this.OwnerForm != null)
        return this.OwnerForm.GetType().FullName;
      return "default";
    }

    public void SaveLayout()
    {
      new LayoutSettings(this.GetSettingsKey())
      {
        LayoutXml = this.GetLayout()
      }.Save();
    }

    public void LoadLayout()
    {
      LayoutSettings layoutSettings = new LayoutSettings(this.GetSettingsKey());
      if (layoutSettings.IsDefault)
        return;
      while (layoutSettings.LayoutXml != null && layoutSettings.LayoutXml.Length != 0)
      {
        if (true)
        {
          this.SetLayout(layoutSettings.LayoutXml);
          break;
        }
      }
    }

    public string GetLayout()
    {
      this.EnsureDockSystemContainer();
      XmlTextWriter writer;
      int index1;
      DocumentContainer dockedContainer;
      int index2;
      StringWriter stringWriter;
      do
      {
        stringWriter = new StringWriter();
label_27:
        writer = new XmlTextWriter((TextWriter) stringWriter);
        writer.Formatting = Formatting.Indented;
        writer.WriteStartDocument();
        writer.WriteStartElement("Layout");
        IEnumerator enumerator = this.x8fb2a5bf0df0416f.Values.GetEnumerator();
        try
        {
          while (true)
          {
            DockControl current;
            do
            {
              if (!enumerator.MoveNext())
              {
                if ((uint) index2 >= 0U)
                  goto label_25;
              }
              current = (DockControl) enumerator.Current;
            }
            while (!current.PersistState);
            this.SaveWindowLayout(current, writer);
          }
        }
        finally
        {
          (enumerator as IDisposable)?.Dispose();
        }
label_25:
        DockContainer[] dockContainerList1 = this.GetOrderedDockedDockContainerList();
        index1 = 0;
        x410f3612b9a8f9de[] dockContainerList2;
        do
        {
          if (index1 >= dockContainerList1.Length)
          {
            dockContainerList2 = this.GetFloatingDockContainerList();
            index2 = 0;
            goto label_12;
          }
          else
          {
            DockContainer container = dockContainerList1[index1];
            if ((index1 & 0) == 0)
            {
              if (container.LayoutSystem.x56005f23d6948487)
              {
                this.SaveContainerLayout(container, writer);
                if (false)
                  goto label_8;
              }
              ++index1;
            }
            else
              goto label_36;
          }
        }
        while ((index2 | 3) != 0);
        goto label_11;
label_10:
        ++index2;
        if (false)
          goto label_3;
label_11:
        if ((index1 | 15) == 0)
          goto label_27;
label_12:
        DockContainer container1;
        if (index2 >= dockContainerList2.Length)
        {
          dockedContainer = this.FindDockedContainer(DockStyle.Fill) as DocumentContainer;
          if (dockedContainer == null)
          {
            if ((uint) index2 + (uint) index2 > uint.MaxValue)
              continue;
            goto label_4;
          }
          else
            goto label_3;
        }
        else
        {
          container1 = (DockContainer) dockContainerList2[index2];
          if (container1.LayoutSystem.x56005f23d6948487)
            goto label_17;
          else
            goto label_10;
        }
label_15:
        if ((uint) index2 < 0U)
          goto label_4;
        else
          goto label_10;
label_17:
        this.SaveContainerLayout(container1, writer);
        goto label_15;
label_36:
        if (true)
          goto label_17;
        else
          goto label_15;
      }
      while ((uint) index2 + (uint) index1 > uint.MaxValue);
      goto label_5;
label_1:
      writer.Flush();
      writer.Close();
      if ((uint) index1 <= uint.MaxValue)
        return stringWriter.ToString();
      if (true)
        goto label_5;
      else
        goto label_4;
label_3:
      if (this.SerializeTabbedDocuments || (index1 & 0) != 0)
        goto label_6;
label_4:
      writer.WriteEndElement();
      writer.WriteEndDocument();
      goto label_1;
label_5:
      if ((index1 & 0) == 0)
        goto label_3;
label_6:
      if (!dockedContainer.LayoutSystem.x56005f23d6948487)
      {
        if ((index2 & 0) == 0)
          goto label_4;
        else
          goto label_1;
      }
      else
        goto label_9;
label_8:
      if ((uint) index2 + (uint) index1 <= uint.MaxValue)
        goto label_6;
label_9:
      this.SaveContainerLayout((DockContainer) dockedContainer, writer);
      goto label_4;
    }

    private void SaveContainerLayout(DockContainer container, XmlTextWriter writer)
    {
      if (container is x410f3612b9a8f9de)
        goto label_18;
label_10:
      if (container is DocumentContainer)
        goto label_9;
      else
        goto label_11;
label_3:
      this.SaveLayoutSystem((LayoutSystemBase) container.LayoutSystem, writer);
      if (true)
        writer.WriteEndElement();
      int contentSize;
      if ((uint) contentSize >= 0U)
        return;
      goto label_16;
label_4:
      XmlTextWriter xmlTextWriter1 = writer;
      int dock = (int) container.Dock;
      string str1 = dock.ToString();
      xmlTextWriter1.WriteAttributeString("Dock", str1);
      if (true)
      {
        if (container.Dock == DockStyle.Fill)
          goto label_3;
      }
      else
        goto label_9;
label_5:
      if (container.Dock != DockStyle.None)
      {
        XmlTextWriter xmlTextWriter2 = writer;
        contentSize = container.ContentSize;
        string str2 = contentSize.ToString();
        xmlTextWriter2.WriteAttributeString("ContentSize", str2);
        goto label_3;
      }
      else
        goto label_3;
label_9:
      writer.WriteStartElement("DocumentContainer");
      goto label_4;
label_11:
      if ((uint) contentSize - (uint) dock >= 0U)
      {
        if ((uint) contentSize >= 0U)
        {
          if ((uint) contentSize - (uint) dock <= uint.MaxValue)
          {
            writer.WriteStartElement("Container");
            goto label_4;
          }
          else
            goto label_5;
        }
        else
          goto label_4;
      }
label_12:
      if (true)
        return;
      goto label_10;
label_16:
      writer.WriteStartElement("FloatingContainer");
      x410f3612b9a8f9de x410f3612b9a8f9de;
      writer.WriteAttributeString("Bounds", this.ConvertRectangleToString(x410f3612b9a8f9de.x5de6fa99acd93adb));
      writer.WriteAttributeString("Guid", x410f3612b9a8f9de.x0217cda8370c1f17.ToString());
      this.SaveLayoutSystem((LayoutSystemBase) container.LayoutSystem, writer);
      writer.WriteEndElement();
      goto label_12;
label_18:
      x410f3612b9a8f9de = (x410f3612b9a8f9de) container;
      goto label_16;
    }

    private void SaveLayoutSystem(LayoutSystemBase layoutSystem, XmlTextWriter writer)
    {
      if (!(layoutSystem is SplitLayoutSystem))
        goto label_30;
      else
        goto label_28;
label_1:
      int num;
      ControlLayoutSystem controlLayoutSystem;
      if (layoutSystem is ControlLayoutSystem)
      {
        controlLayoutSystem = (ControlLayoutSystem) layoutSystem;
        writer.WriteAttributeString("Guid", controlLayoutSystem.x0217cda8370c1f17.ToString());
        writer.WriteAttributeString("Collapsed", this.ConvertBoolToString(controlLayoutSystem.Collapsed));
        if ((uint) num + (uint) num < 0U || controlLayoutSystem.SelectedControl != null)
        {
          if (controlLayoutSystem.SelectedControl.PersistState)
            goto label_15;
          else
            goto label_3;
        }
        else
          goto label_4;
      }
label_2:
      writer.WriteEndElement();
      return;
label_3:
      if ((num | int.MinValue) == 0)
        goto label_15;
label_4:
      writer.WriteStartElement("Controls");
      foreach (DockControl control in (CollectionBase) controlLayoutSystem.Controls)
      {
        if (control.PersistState)
        {
          writer.WriteStartElement("Control");
          writer.WriteAttributeString("Guid", control.Guid.ToString());
          if ((uint) num + (uint) num <= uint.MaxValue)
            writer.WriteEndElement();
        }
      }
      writer.WriteEndElement();
      if (false)
        goto label_1;
      else
        goto label_2;
label_15:
      writer.WriteAttributeString("SelectedControl", controlLayoutSystem.SelectedControl.Guid.ToString());
      goto label_4;
label_26:
      writer.WriteAttributeString("WorkingSize", SandDockManager.ConvertSizeFToString(layoutSystem.WorkingSize));
      if (layoutSystem is SplitLayoutSystem)
      {
        SplitLayoutSystem splitLayoutSystem = (SplitLayoutSystem) layoutSystem;
        XmlTextWriter xmlTextWriter = writer;
        int splitMode = (int) splitLayoutSystem.SplitMode;
        string str = splitMode.ToString();
        xmlTextWriter.WriteAttributeString("SplitMode", str);
        IEnumerator enumerator = splitLayoutSystem.LayoutSystems.GetEnumerator();
        try
        {
          while (enumerator.MoveNext())
          {
            LayoutSystemBase current = (LayoutSystemBase) enumerator.Current;
            if ((uint) splitMode - (uint) splitMode <= uint.MaxValue)
            {
              if (current.x56005f23d6948487)
                this.SaveLayoutSystem(current, writer);
            }
            else
              break;
          }
          goto label_2;
        }
        finally
        {
          IDisposable disposable = enumerator as IDisposable;
          while (disposable != null)
          {
            disposable.Dispose();
            if ((uint) splitMode + (uint) splitMode >= 0U)
              break;
          }
        }
      }
      else
        goto label_1;
label_28:
      writer.WriteStartElement("SplitLayoutSystem");
      if (false)
        goto label_3;
      else
        goto label_26;
label_30:
      if (!(layoutSystem is ControlLayoutSystem))
        return;
      writer.WriteStartElement("ControlLayoutSystem");
      goto label_26;
    }

    private void SaveWindowLayout(DockControl control, XmlTextWriter writer)
    {
      x245a5abec1c73d3a.x4229d31a884b2577(control, writer);
    }

    [Browsable(false)]
    public Form OwnerForm
    {
      get
      {
        return this.x9492ad63ba3e62cf;
      }
      set
      {
        if (this.x9492ad63ba3e62cf != null && this.x9492ad63ba3e62cf == value)
          return;
        if (this.x9492ad63ba3e62cf == null)
          goto label_5;
        else
          goto label_9;
label_3:
        this.x9492ad63ba3e62cf.Load += new EventHandler(this.OnOwnerFormLoad);
        this.x9492ad63ba3e62cf.Closing += new CancelEventHandler(this.OnOwnerFormClosing);
        return;
label_5:
        this.x9492ad63ba3e62cf = value;
        while (this.x9492ad63ba3e62cf == null)
        {
          if (true)
            return;
        }
        this.x9492ad63ba3e62cf.Activated += new EventHandler(this.OnOwnerFormActivated);
        this.x9492ad63ba3e62cf.Deactivate += new EventHandler(this.OnOwnerFormDeactivated);
        goto label_3;
label_9:
        if (true)
        {
          this.x9492ad63ba3e62cf.Activated -= new EventHandler(this.OnOwnerFormActivated);
          if (false)
            return;
          this.x9492ad63ba3e62cf.Deactivate -= new EventHandler(this.OnOwnerFormDeactivated);
          this.x9492ad63ba3e62cf.Load -= new EventHandler(this.OnOwnerFormLoad);
          this.x9492ad63ba3e62cf.Closing -= new CancelEventHandler(this.OnOwnerFormClosing);
          goto label_5;
        }
        else
          goto label_3;
      }
    }

    private void OnOwnerFormClosing(object sender, CancelEventArgs e)
    {
      if (!this.AutoSaveLayout)
        return;
      this.SaveLayout();
    }

    private void OnOwnerFormLoad(object sender, EventArgs e)
    {
      if (!this.AutoSaveLayout)
        return;
      this.LoadLayout();
    }

    public DockControl[] GetDockControls()
    {
      DockControl[] dockControlArray = new DockControl[this.x8fb2a5bf0df0416f.Count];
      this.x8fb2a5bf0df0416f.Values.CopyTo((Array) dockControlArray, 0);
      return dockControlArray;
    }

    public DockControl[] GetDockControls(DockSituation dockSituation)
    {
      ArrayList arrayList = new ArrayList();
      foreach (DockControl dockControl in (IEnumerable) this.x8fb2a5bf0df0416f.Values)
      {
        if (dockControl.DockSituation == dockSituation)
          arrayList.Add((object) dockControl);
      }
      return (DockControl[]) arrayList.ToArray(typeof (DockControl));
    }

    public DockContainer[] GetDockContainers()
    {
      return (DockContainer[]) this.xd27fa35d10494112.ToArray(typeof (DockContainer));
    }

    [Description("The renderer used to calculate object metrics and draw contents.")]
    [Category("Appearance")]
    public RendererBase Renderer
    {
      get
      {
        return this.x38870620fd380a6b;
      }
      set
      {
        if (value != null)
        {
          if (this.x38870620fd380a6b != null)
            goto label_2;
label_1:
          this.x38870620fd380a6b = value;
          this.x38870620fd380a6b.MetricsChanged += new EventHandler(this.OnRendererMetricsChanged);
          this.PropagateNewRenderer();
          return;
label_2:
          this.x38870620fd380a6b.MetricsChanged -= new EventHandler(this.OnRendererMetricsChanged);
          if (true)
          {
            this.x38870620fd380a6b.Dispose();
            goto label_1;
          }
        }
        throw new ArgumentNullException();
      }
    }

    private bool ShouldSerializeRenderer()
    {
      return !(this.x38870620fd380a6b is WhidbeyRenderer);
    }

    private void OnRendererMetricsChanged(object sender, EventArgs e)
    {
      this.PropagateNewRenderer();
    }

    private void PropagateNewRenderer()
    {
      IEnumerator enumerator = this.xd27fa35d10494112.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
          ((DockContainer) enumerator.Current).x4481febbc2e58301();
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        if (true)
          goto label_8;
        else
          goto label_7;
label_6:
        if (false)
          goto label_8;
        else
          goto label_9;
label_7:
        disposable.Dispose();
        goto label_6;
label_8:
        if (disposable == null)
        {
          if (false)
            goto label_6;
        }
        else
          goto label_7;
label_9:;
      }
      foreach (x10ac79a4257c7f52 x10ac79a4257c7f52 in this.xa90af1bb0ada0f53)
        x10ac79a4257c7f52.x4481febbc2e58301();
    }

    internal void RegisterDockContainer(DockContainer container)
    {
      if (!(container is DocumentContainer))
        goto label_11;
      else
        goto label_16;
label_3:
      container.AllowDrop = this.SelectTabsOnDrag;
      if (container is DocumentContainer)
      {
        this.x1f1a3b29d7ed7776 = (DocumentContainer) container;
        this.x1f1a3b29d7ed7776.x64b4c49ed703037e = this.BorderStyle;
        this.x1f1a3b29d7ed7776.x7d2c5325d16e569d = this.DocumentOverflow;
        this.x1f1a3b29d7ed7776.xa957e8f86f5e6115 = this.IntegralClose;
        return;
      }
      if (true)
        return;
      if (true)
        goto label_13;
      else
        goto label_11;
label_4:
      if (this.DockSystemContainer == null)
      {
        if (container.Parent is ContainerControl && !container.IsFloating)
        {
          if (true)
          {
            this.DockSystemContainer = container.Parent;
            goto label_3;
          }
        }
        else
          goto label_3;
      }
      else if (false)
        goto label_3;
      else
        goto label_3;
label_8:
      if (true)
        goto label_4;
label_11:
      if (this.xd27fa35d10494112.Contains((object) container))
      {
        if (true)
          goto label_4;
        else
          goto label_8;
      }
label_13:
      this.xd27fa35d10494112.Add((object) container);
      goto label_8;
label_16:
      if (this.x1f1a3b29d7ed7776 != null)
        throw new InvalidOperationException("Only one DocumentContainer can exist in a SandDock layout.");
      if (false)
        goto label_3;
      else
        goto label_11;
    }

    internal void UnregisterDockContainer(DockContainer container)
    {
      if (this.xd27fa35d10494112.Contains((object) container))
        this.xd27fa35d10494112.Remove((object) container);
      if (this.x1f1a3b29d7ed7776 != container)
        return;
      this.x1f1a3b29d7ed7776 = (DocumentContainer) null;
    }

    internal void RegisterAutoHideBar(x10ac79a4257c7f52 bar)
    {
      if (!this.xa90af1bb0ada0f53.Contains((object) bar))
        this.xa90af1bb0ada0f53.Add((object) bar);
      bar.AllowDrop = this.SelectTabsOnDrag;
    }

    internal void UnregisterAutoHideBar(x10ac79a4257c7f52 bar)
    {
      if (!this.xa90af1bb0ada0f53.Contains((object) bar))
        return;
      this.xa90af1bb0ada0f53.Remove((object) bar);
    }

    internal DockContainer FindDockedContainer(DockStyle dockStyle)
    {
      IEnumerator enumerator = this.xd27fa35d10494112.GetEnumerator();
      DockContainer dockContainer;
      try
      {
        DockContainer current;
        do
        {
          if (enumerator.MoveNext())
          {
            current = (DockContainer) enumerator.Current;
            if (false)
              goto label_9;
          }
          else
            goto label_9;
        }
        while (current.Dock != dockStyle || current.IsFloating);
        dockContainer = current;
        if (true)
          goto label_10;
      }
      finally
      {
        (enumerator as IDisposable)?.Dispose();
      }
label_9:
      return (DockContainer) null;
label_10:
      return dockContainer;
    }

    public DockContainer FindDockContainer(ContainerDockLocation location)
    {
      return this.FindDockedContainer(LayoutUtilities.xf8330a3964a419ba(location));
    }

    internal x410f3612b9a8f9de FindFloatingDockContainer(Guid guid)
    {
      x410f3612b9a8f9de[] dockContainerList = this.GetFloatingDockContainerList();
      int num;
      if ((uint) num + (uint) num >= 0U)
        goto label_9;
label_1:
      int index;
      do
      {
        ++index;
        if (true)
          goto label_2;
      }
      while (true);
      goto label_5;
label_2:
      while (index >= dockContainerList.Length)
      {
        if (true)
          return (x410f3612b9a8f9de) null;
      }
      x410f3612b9a8f9de x410f3612b9a8f9de = dockContainerList[index];
      if (true)
      {
        if ((uint) index - (uint) index > uint.MaxValue)
          goto label_8;
      }
      else
        goto label_1;
label_5:
      if (!(x410f3612b9a8f9de.x0217cda8370c1f17 == guid))
        goto label_1;
label_8:
      return x410f3612b9a8f9de;
label_9:
      index = 0;
      goto label_2;
    }

    public override ISite Site
    {
      get
      {
        return base.Site;
      }
      set
      {
        base.Site = value;
        if (value == null)
          return;
label_19:
        IDesignerHost service = (IDesignerHost) this.GetService(typeof (IDesignerHost));
label_16:
        if (service != null)
          goto label_12;
label_1:
        while (service != null)
        {
          if (true)
          {
            if (true)
            {
              if (service.RootComponent is Control)
              {
                if (this.DockSystemContainer != null)
                  break;
                this.DockSystemContainer = this.FindDockSystemContainer(service, (Control) service.RootComponent);
                if (true)
                  break;
                if (false)
                  goto label_14;
              }
              else
              {
                if (true)
                  break;
                if (true)
                  goto label_16;
                else
                  goto label_12;
              }
            }
            else
              goto label_12;
          }
          else
            goto label_19;
        }
        return;
label_12:
        if (true)
          goto label_14;
label_13:
        this.x9492ad63ba3e62cf = (Form) service.RootComponent;
        goto label_1;
label_14:
        if (service.RootComponent is Form)
          goto label_13;
        else
          goto label_1;
      }
    }

    private Control FindDockSystemContainer(IDesignerHost designerHost, Control parent)
    {
      foreach (Control control in (ArrangedElementCollection) parent.Controls)
      {
        if (control.Dock == DockStyle.Fill)
        {
          if (control.Site == null)
          {
            if (false)
              ;
          }
          else if (control.Site.DesignMode && !control.Controls.IsReadOnly)
            return this.FindDockSystemContainer(designerHost, control);
        }
      }
      return parent;
    }

    protected override void Dispose(bool disposing)
    {
      if (disposing)
        goto label_15;
label_2:
      base.Dispose(disposing);
      return;
label_15:
      DockContainer[] dockContainerArray1 = new DockContainer[this.xd27fa35d10494112.Count];
      int num1;
      if ((num1 & 0) == 0)
        goto label_14;
label_8:
      x10ac79a4257c7f52[] x10ac79a4257c7f52Array1;
      this.xa90af1bb0ada0f53.CopyTo((Array) x10ac79a4257c7f52Array1);
      x10ac79a4257c7f52[] x10ac79a4257c7f52Array2 = x10ac79a4257c7f52Array1;
label_6:
      int index1;
      int index2;
      for (index1 = 0; index1 < x10ac79a4257c7f52Array2.Length; ++index1)
      {
        x10ac79a4257c7f52Array2[index1].Dispose();
        if ((index1 | 1) != 0)
        {
          if ((uint) index1 + (uint) index2 < 0U)
            goto label_6;
        }
        else
          goto label_13;
      }
      if ((uint) index1 - (uint) index1 < 0U)
        return;
      this.xa90af1bb0ada0f53.Clear();
      goto label_2;
label_9:
      DockContainer[] dockContainerArray2;
      if (index2 >= dockContainerArray2.Length)
      {
        this.xd27fa35d10494112.Clear();
        x10ac79a4257c7f52Array1 = new x10ac79a4257c7f52[this.xa90af1bb0ada0f53.Count];
        goto label_8;
      }
      else
        dockContainerArray2[index2].Dispose();
label_12:
      ++index2;
label_13:
      if ((uint) disposing < 0U)
        goto label_12;
      else
        goto label_9;
label_14:
      this.xd27fa35d10494112.CopyTo((Array) dockContainerArray1);
      dockContainerArray2 = dockContainerArray1;
      index2 = 0;
      int num2;
      if ((uint) num2 + (uint) index2 >= 0U)
        goto label_9;
      else
        goto label_9;
    }

    protected internal virtual void OnDockControlClosing(DockControlClosingEventArgs e)
    {
      if (this.x81beccfee80d0f84 == null)
        return;
      this.x81beccfee80d0f84((object) this, e);
    }

    protected internal virtual void OnDockingStarted(EventArgs e)
    {
      if (this.xc5f1fda5242cf905 == null)
        return;
      this.xc5f1fda5242cf905((object) this, e);
    }

    protected internal virtual void OnDockingFinished(EventArgs e)
    {
      if (this.x2556ec4d28ceecee == null)
        return;
      this.x2556ec4d28ceecee((object) this, e);
    }

    protected virtual void OnResolveDockControl(ResolveDockControlEventArgs e)
    {
      if (this.x745fd7b95ab555c4 == null)
        return;
      this.x745fd7b95ab555c4((object) this, e);
    }

    protected internal virtual void OnActiveTabbedDocumentChanged(EventArgs e)
    {
      if (this.x9e34f522d048dee6 == null)
        return;
      this.x9e34f522d048dee6((object) this, e);
    }

    private void OnDockSystemContainerResize(object sender, EventArgs e)
    {
      int num1;
      if (this.OwnerForm != null && ((num1 | int.MaxValue) == 0 || this.OwnerForm.WindowState == FormWindowState.Minimized))
        return;
      if (this.DockSystemContainer == null)
        goto label_44;
      else
        goto label_75;
label_1:
      int num2;
      if (num2 <= 0)
        return;
      ArrayList arrayList1 = new ArrayList();
      int num3 = 0;
      IEnumerator enumerator1 = this.xd27fa35d10494112.GetEnumerator();
      int num4;
      try
      {
        while (true)
        {
          DockContainer current;
          do
          {
            if (!enumerator1.MoveNext())
            {
              if ((num4 & 0) == 0)
                goto label_12;
            }
            current = (DockContainer) enumerator1.Current;
          }
          while (current.Dock != DockStyle.Top && current.Dock != DockStyle.Bottom);
          num3 += current.Height;
          if ((uint) num3 - (uint) num3 > uint.MaxValue)
            ;
          arrayList1.Add((object) current);
        }
      }
      finally
      {
        IDisposable disposable = enumerator1 as IDisposable;
        if ((uint) num1 + (uint) num3 > uint.MaxValue || disposable != null)
          disposable.Dispose();
      }
label_12:
      if (num3 <= 0)
        return;
      IEnumerator enumerator2 = arrayList1.GetEnumerator();
      try
      {
        while (enumerator2.MoveNext())
        {
          DockContainer current = (DockContainer) enumerator2.Current;
          int int32;
          if ((uint) num2 - (uint) int32 < 0U)
            break;
          int32 = Convert.ToInt32((double) current.Height / (double) num3 * (double) num2);
          num3 -= current.Height;
          num2 -= int32;
          current.ContentSize -= int32;
          if (num3 == 0)
            break;
        }
        return;
      }
      finally
      {
        (enumerator2 as IDisposable)?.Dispose();
      }
label_22:
      IEnumerator enumerator3 = this.xd27fa35d10494112.GetEnumerator();
      int num5;
      ArrayList arrayList2;
      int num6;
      try
      {
        while (true)
        {
          DockContainer current;
          do
          {
            if (!enumerator3.MoveNext())
            {
              if ((uint) num1 + (uint) num5 >= 0U)
              {
                if (true)
                  goto label_21;
              }
              else
                goto label_28;
            }
            current = (DockContainer) enumerator3.Current;
            if (current.Dock == DockStyle.Left)
              break;
label_28:;
          }
          while (current.Dock != DockStyle.Right);
          num4 += current.Width;
          arrayList2.Add((object) current);
        }
      }
      finally
      {
        IDisposable disposable = enumerator3 as IDisposable;
        if ((uint) num2 - (uint) num6 > uint.MaxValue || disposable != null)
          disposable.Dispose();
      }
label_21:
      if (num4 > 0)
      {
        IEnumerator enumerator4 = arrayList2.GetEnumerator();
        try
        {
          while (enumerator4.MoveNext())
          {
            DockContainer current = (DockContainer) enumerator4.Current;
            if (true)
            {
              int int32 = Convert.ToInt32((double) current.Width / (double) num4 * (double) num6);
              num4 -= current.Width;
              num6 -= int32;
              current.ContentSize -= int32;
              if (num4 == 0)
                break;
            }
          }
          goto label_1;
        }
        finally
        {
          (enumerator4 as IDisposable)?.Dispose();
        }
      }
      else
        goto label_1;
label_41:
      if (num6 > 0)
      {
        arrayList2 = new ArrayList();
        num4 = 0;
        goto label_22;
      }
      else
        goto label_1;
label_44:
      Rectangle rectangle = xedb4922162c60d3d.x41c62f474d3fb367(this.DockSystemContainer);
      num6 = -rectangle.Width;
      num2 = -rectangle.Height;
      if (this.DockSystemContainer is ToolStripContentPanel && (rectangle.Width <= 0 || rectangle.Height <= 0))
        return;
      goto label_41;
label_75:
      int num7;
      if ((num7 | int.MaxValue) != 0)
        goto label_69;
label_62:
      int num8;
      if ((uint) num8 < 0U)
        goto label_63;
label_49:
      Form form1;
      if (form1 == null)
        goto label_44;
label_63:
      int num9;
      if (form1.WindowState == FormWindowState.Minimized)
      {
        if (true)
          return;
        goto label_70;
      }
      else if (form1.Parent != null)
      {
        if (true)
        {
          Form form2 = form1.Parent.FindForm();
          if (form2 != null)
          {
            if (form2.WindowState == FormWindowState.Minimized)
              return;
            int num10;
            do
            {
              if (form2.ActiveMdiChild == null)
              {
                if ((uint) num1 - (uint) num8 >= 0U)
                  goto label_44;
              }
              else if (form2.ActiveMdiChild != form1)
              {
                if ((uint) num1 + (uint) num7 >= 0U)
                {
                  if (form2.ActiveMdiChild.WindowState == FormWindowState.Maximized)
                    return;
                  goto label_47;
                }
              }
              else
                goto label_44;
            }
            while ((uint) num10 + (uint) num1 > uint.MaxValue);
label_45:
            if ((uint) num5 + (uint) num9 >= 0U)
            {
              if ((num5 | (int) byte.MaxValue) != 0 && (uint) num1 - (uint) num8 >= 0U)
                goto label_44;
            }
            else
              goto label_49;
label_47:
            if ((num10 | 1) == 0)
              goto label_45;
            else
              goto label_44;
          }
          else
            goto label_44;
        }
        else
          goto label_41;
      }
      else
        goto label_44;
label_69:
      form1 = this.DockSystemContainer.FindForm();
label_70:
      if ((uint) num9 <= uint.MaxValue)
      {
        if ((uint) num9 + (uint) num7 <= uint.MaxValue)
          goto label_62;
      }
      else
        goto label_22;
    }

    private void OnOwnerFormActivated(object sender, EventArgs e)
    {
      IEnumerator enumerator = this.xd27fa35d10494112.GetEnumerator();
      try
      {
        while (enumerator.MoveNext())
        {
          DockContainer current = (DockContainer) enumerator.Current;
          if (!current.IsFloating)
            current.xa2414c47d888068e(sender, e);
        }
      }
      finally
      {
        IDisposable disposable = enumerator as IDisposable;
        if (true)
          goto label_7;
label_6:
        disposable.Dispose();
        if (true)
          goto label_9;
label_7:
        if (disposable != null)
          goto label_6;
label_9:;
      }
    }

    private void OnOwnerFormDeactivated(object sender, EventArgs e)
    {
      foreach (DockContainer dockContainer in this.xd27fa35d10494112)
      {
        do
          ;
        while (false);
        if (!dockContainer.IsFloating)
          dockContainer.x19e788b09b195d4f(sender, e);
      }
    }

    public static void ActivateProduct(string licenseKey)
    {
      x294bd621a33dc533.ActivateProduct(licenseKey);
    }
  }
}
