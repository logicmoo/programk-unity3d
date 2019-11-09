// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Tree.BaseTree
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Antlr.Runtime.Tree
{
  [DebuggerTypeProxy(typeof (AntlrRuntime_BaseTreeDebugView))]
  [Serializable]
  public abstract class BaseTree : ITree
  {
    private IList<ITree> _children;

    public BaseTree()
    {
    }

    public BaseTree(ITree node)
    {
    }

    public virtual IList<ITree> Children
    {
      get
      {
        return this._children;
      }
      private set
      {
        this._children = value;
      }
    }

    public virtual int ChildCount
    {
      get
      {
        if (this.Children == null)
          return 0;
        return this.Children.Count;
      }
    }

    public virtual ITree Parent
    {
      get
      {
        return (ITree) null;
      }
      set
      {
      }
    }

    public virtual int ChildIndex
    {
      get
      {
        return 0;
      }
      set
      {
      }
    }

    public virtual bool IsNil
    {
      get
      {
        return false;
      }
    }

    public abstract int TokenStartIndex { get; set; }

    public abstract int TokenStopIndex { get; set; }

    public abstract int Type { get; set; }

    public abstract string Text { get; set; }

    public virtual int Line { get; set; }

    public virtual int CharPositionInLine { get; set; }

    public virtual ITree GetChild(int i)
    {
      if (i < 0)
        throw new ArgumentOutOfRangeException();
      if (this.Children == null || i >= this.Children.Count)
        return (ITree) null;
      return this.Children[i];
    }

    public virtual ITree GetFirstChildWithType(int type)
    {
      foreach (ITree child in (IEnumerable<ITree>) this.Children)
      {
        if (child.Type == type)
          return child;
      }
      return (ITree) null;
    }

    public virtual void AddChild(ITree t)
    {
      if (t == null)
        return;
      if (t.IsNil)
      {
        BaseTree baseTree = t as BaseTree;
        if (baseTree != null && this.Children != null && this.Children == baseTree.Children)
          throw new Exception("attempt to add child list to itself");
        if (t.ChildCount <= 0)
          return;
        if (this.Children != null || baseTree == null)
        {
          if (this.Children == null)
            this.Children = this.CreateChildrenList();
          int childCount = t.ChildCount;
          for (int i = 0; i < childCount; ++i)
          {
            ITree child = t.GetChild(i);
            this.Children.Add(child);
            child.Parent = (ITree) this;
            child.ChildIndex = this.Children.Count - 1;
          }
        }
        else
        {
          this.Children = baseTree.Children;
          this.FreshenParentAndChildIndexes();
        }
      }
      else
      {
        if (this.Children == null)
          this.Children = this.CreateChildrenList();
        this.Children.Add(t);
        t.Parent = (ITree) this;
        t.ChildIndex = this.Children.Count - 1;
      }
    }

    public virtual void AddChildren(IEnumerable<ITree> kids)
    {
      if (kids == null)
        throw new ArgumentNullException(nameof (kids));
      foreach (ITree kid in kids)
        this.AddChild(kid);
    }

    public virtual void SetChild(int i, ITree t)
    {
      if (i < 0)
        throw new ArgumentOutOfRangeException(nameof (i));
      if (t == null)
        return;
      if (t.IsNil)
        throw new ArgumentException("Can't set single child to a list");
      if (this.Children == null)
        this.Children = this.CreateChildrenList();
      this.Children[i] = t;
      t.Parent = (ITree) this;
      t.ChildIndex = i;
    }

    public virtual object DeleteChild(int i)
    {
      if (i < 0)
        throw new ArgumentOutOfRangeException(nameof (i));
      if (i >= this.ChildCount)
        throw new ArgumentException();
      if (this.Children == null)
        return (object) null;
      ITree child = this.Children[i];
      this.Children.RemoveAt(i);
      this.FreshenParentAndChildIndexes(i);
      return (object) child;
    }

    public virtual void ReplaceChildren(int startChildIndex, int stopChildIndex, object t)
    {
      if (startChildIndex < 0)
        throw new ArgumentOutOfRangeException();
      if (stopChildIndex < 0)
        throw new ArgumentOutOfRangeException();
      if (t == null)
        throw new ArgumentNullException(nameof (t));
      if (stopChildIndex < startChildIndex)
        throw new ArgumentException();
      if (this.Children == null)
        throw new ArgumentException("indexes invalid; no children in list");
      int num1 = stopChildIndex - startChildIndex + 1;
      ITree tree1 = (ITree) t;
      IList<ITree> treeList;
      if (tree1.IsNil)
      {
        BaseTree baseTree = tree1 as BaseTree;
        if (baseTree != null && baseTree.Children != null)
        {
          treeList = baseTree.Children;
        }
        else
        {
          treeList = this.CreateChildrenList();
          int childCount = tree1.ChildCount;
          for (int i = 0; i < childCount; ++i)
            treeList.Add(tree1.GetChild(i));
        }
      }
      else
      {
        treeList = (IList<ITree>) new List<ITree>(1);
        treeList.Add(tree1);
      }
      int count1 = treeList.Count;
      int count2 = treeList.Count;
      int num2 = num1 - count1;
      if (num2 == 0)
      {
        int index1 = 0;
        for (int index2 = startChildIndex; index2 <= stopChildIndex; ++index2)
        {
          ITree tree2 = treeList[index1];
          this.Children[index2] = tree2;
          tree2.Parent = (ITree) this;
          tree2.ChildIndex = index2;
          ++index1;
        }
      }
      else if (num2 > 0)
      {
        for (int index = 0; index < count2; ++index)
          this.Children[startChildIndex + index] = treeList[index];
        int index1 = startChildIndex + count2;
        for (int index2 = index1; index2 <= stopChildIndex; ++index2)
          this.Children.RemoveAt(index1);
        this.FreshenParentAndChildIndexes(startChildIndex);
      }
      else
      {
        for (int index = 0; index < num1; ++index)
          this.Children[startChildIndex + index] = treeList[index];
        for (int index = num1; index < count1; ++index)
          this.Children.Insert(startChildIndex + index, treeList[index]);
        this.FreshenParentAndChildIndexes(startChildIndex);
      }
    }

    protected virtual IList<ITree> CreateChildrenList()
    {
      return (IList<ITree>) new List<ITree>();
    }

    public virtual void FreshenParentAndChildIndexes()
    {
      this.FreshenParentAndChildIndexes(0);
    }

    public virtual void FreshenParentAndChildIndexes(int offset)
    {
      int childCount = this.ChildCount;
      for (int i = offset; i < childCount; ++i)
      {
        ITree child = this.GetChild(i);
        child.ChildIndex = i;
        child.Parent = (ITree) this;
      }
    }

    public virtual void SanityCheckParentAndChildIndexes()
    {
      this.SanityCheckParentAndChildIndexes((ITree) null, -1);
    }

    public virtual void SanityCheckParentAndChildIndexes(ITree parent, int i)
    {
      if (parent != this.Parent)
        throw new InvalidOperationException("parents don't match; expected " + (object) parent + " found " + (object) this.Parent);
      if (i != this.ChildIndex)
        throw new InvalidOperationException("child indexes don't match; expected " + (object) i + " found " + (object) this.ChildIndex);
      int childCount = this.ChildCount;
      for (int i1 = 0; i1 < childCount; ++i1)
        ((BaseTree) this.GetChild(i1)).SanityCheckParentAndChildIndexes((ITree) this, i1);
    }

    public virtual bool HasAncestor(int ttype)
    {
      return this.GetAncestor(ttype) != null;
    }

    public virtual ITree GetAncestor(int ttype)
    {
      for (ITree parent = this.Parent; parent != null; parent = parent.Parent)
      {
        if (parent.Type == ttype)
          return parent;
      }
      return (ITree) null;
    }

    public virtual IList<ITree> GetAncestors()
    {
      if (this.Parent == null)
        return (IList<ITree>) null;
      List<ITree> treeList = new List<ITree>();
      for (ITree parent = this.Parent; parent != null; parent = parent.Parent)
        treeList.Insert(0, parent);
      return (IList<ITree>) treeList;
    }

    public virtual string ToStringTree()
    {
      if (this.Children == null || this.Children.Count == 0)
        return this.ToString();
      StringBuilder stringBuilder = new StringBuilder();
      if (!this.IsNil)
      {
        stringBuilder.Append("(");
        stringBuilder.Append(this.ToString());
        stringBuilder.Append(' ');
      }
      for (int index = 0; this.Children != null && index < this.Children.Count; ++index)
      {
        ITree child = this.Children[index];
        if (index > 0)
          stringBuilder.Append(' ');
        stringBuilder.Append(child.ToStringTree());
      }
      if (!this.IsNil)
        stringBuilder.Append(")");
      return stringBuilder.ToString();
    }

    public abstract override string ToString();

    public abstract ITree DupNode();
  }
}
