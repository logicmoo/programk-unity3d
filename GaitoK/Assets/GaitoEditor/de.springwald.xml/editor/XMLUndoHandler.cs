// Decompiled with JetBrains decompiler
// Type: de.springwald.xml.editor.XMLUndoHandler
// Assembly: de.springwald.xml, Version=1.0.6109.32918, Culture=neutral, PublicKeyToken=null
// MVID: E0639A9E-FDB8-4648-8B2D-87540A66FC25
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\de.springwald.xml.dll

using de.springwald.xml.cursor;
using System;
using System.Collections.Generic;
using System.Xml;

namespace de.springwald.xml.editor
{
  public class XMLUndoHandler : IDisposable
  {
    private bool _disposed = false;
    private int _pos = 0;
    private bool _interneVeraenderungLaeuft = false;
    private XmlNode _rootNode;
    private XmlDocument _dokument;
    private List<XMLUndoSchritt> _undoSchritte;

    private int VorherigeSnapshotPos
    {
      get
      {
        int pos = this._pos;
        do
        {
          --pos;
        }
        while (pos > 0 && !this._undoSchritte[pos].IstSnapshot);
        return pos;
      }
    }

    public XmlNode RootNode
    {
      get
      {
        return this._rootNode;
      }
    }

    public bool UndoMoeglich
    {
      get
      {
        return this._pos > 0;
      }
    }

    public string NextUndoSnapshotName
    {
      get
      {
        if (this.UndoMoeglich)
          return string.Format(ResReader.Reader.GetString("NameUndoSchritt"), (object) this._undoSchritte[this.VorherigeSnapshotPos].SnapShotName);
        return ResReader.Reader.GetString("KeinUndoSchrittVerfuegbar");
      }
    }

    public XMLUndoHandler(XmlNode rootNode)
    {
      this._undoSchritte = new List<XMLUndoSchritt>();
      this._undoSchritte.Add(new XMLUndoSchritt());
      this._rootNode = rootNode;
      this._dokument = this._rootNode.OwnerDocument;
      this._dokument.NodeChanging += new XmlNodeChangedEventHandler(this._dokument_NodeChanging);
      this._dokument.NodeInserted += new XmlNodeChangedEventHandler(this._dokument_NodeInserted);
      this._dokument.NodeRemoving += new XmlNodeChangedEventHandler(this._dokument_NodeRemoving);
    }

    public void SnapshotSetzen(string snapShotName, XMLCursor cursor)
    {
      this._undoSchritte[this._pos].SnapShotName = snapShotName;
      this._undoSchritte[this._pos].CursorVorher = cursor;
    }

    public XMLCursor Undo()
    {
      if (!this.UndoMoeglich)
        return (XMLCursor) null;
      this._interneVeraenderungLaeuft = true;
      do
      {
        this._undoSchritte[this._pos].UnDo();
        --this._pos;
      }
      while (this._pos != 0 && !this._undoSchritte[this._pos].IstSnapshot);
      this._interneVeraenderungLaeuft = false;
      return this._undoSchritte[this._pos].CursorVorher;
    }

    private void _dokument_NodeRemoving(object sender, XmlNodeChangedEventArgs e)
    {
      if (this._interneVeraenderungLaeuft)
        return;
      if (e.Node is XmlAttribute)
        this.NeuenUndoSchrittAnhaengen((XMLUndoSchritt) new XMLUndoSchrittAttributRemoved((XmlAttribute) e.Node));
      else
        this.NeuenUndoSchrittAnhaengen((XMLUndoSchritt) new XMLUndoSchrittNodeRemoved(e.Node));
    }

    private void _dokument_NodeChanging(object sender, XmlNodeChangedEventArgs e)
    {
      if (this._interneVeraenderungLaeuft)
        return;
      this.NeuenUndoSchrittAnhaengen((XMLUndoSchritt) new XMLUndoSchrittNodeChanged(e.Node, e.OldValue));
    }

    private void _dokument_NodeInserted(object sender, XmlNodeChangedEventArgs e)
    {
      if (this._interneVeraenderungLaeuft)
        return;
      this.NeuenUndoSchrittAnhaengen((XMLUndoSchritt) new XMLUndoSchrittNodeInserted(e.Node, e.NewParent));
    }

    public void Dispose()
    {
      if (this._disposed)
        return;
      this._dokument.NodeChanging -= new XmlNodeChangedEventHandler(this._dokument_NodeChanging);
      this._dokument.NodeInserted -= new XmlNodeChangedEventHandler(this._dokument_NodeInserted);
      this._dokument.NodeRemoving -= new XmlNodeChangedEventHandler(this._dokument_NodeRemoving);
      this._disposed = true;
    }

    private void NeuenUndoSchrittAnhaengen(XMLUndoSchritt neuerUndoSchritt)
    {
      List<XMLUndoSchritt> xmlUndoSchrittList = new List<XMLUndoSchritt>();
      for (int index = this._pos + 1; index < this._undoSchritte.Count; ++index)
        xmlUndoSchrittList.Add(this._undoSchritte[index]);
      foreach (XMLUndoSchritt xmlUndoSchritt in xmlUndoSchrittList)
        this._undoSchritte.Remove(xmlUndoSchritt);
      this._undoSchritte.Add(neuerUndoSchritt);
      ++this._pos;
      if (this._pos != this._undoSchritte.Count - 1)
        throw new Exception("Undo-Pos sollte mit undoSchritte.Count-1 übereinstimmen. Statt dessen pos: " + (object) this._pos + ", _undoSchritte.Count -1:" + (object) (this._undoSchritte.Count - 1));
    }
  }
}
