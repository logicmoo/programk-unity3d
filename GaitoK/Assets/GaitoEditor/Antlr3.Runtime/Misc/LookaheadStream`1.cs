// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.Misc.LookaheadStream`1
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;

namespace Antlr.Runtime.Misc
{
  public abstract class LookaheadStream<T> : FastQueue<T> where T : class
  {
    private T _eof = default (T);
    private int _currentElementIndex;
    private T _previousElement;
    private int _lastMarker;
    private int _markDepth;

    public T EndOfFile
    {
      get
      {
        return this._eof;
      }
      protected set
      {
        this._eof = value;
      }
    }

    public override void Clear()
    {
      base.Clear();
      this._currentElementIndex = 0;
      this._p = 0;
      this._previousElement = default (T);
    }

    public abstract T NextElement();

    public abstract bool IsEndOfFile(T o);

    public override T Dequeue()
    {
      T obj = this[0];
      ++this._p;
      if (this._p == this._data.Count && this._markDepth == 0)
        this.Clear();
      return obj;
    }

    public virtual void Consume()
    {
      this.SyncAhead(1);
      this._previousElement = this.Dequeue();
      ++this._currentElementIndex;
    }

    protected virtual void SyncAhead(int need)
    {
      int n = this._p + need - 1 - this._data.Count + 1;
      if (n <= 0)
        return;
      this.Fill(n);
    }

    public virtual void Fill(int n)
    {
      for (int index = 0; index < n; ++index)
      {
        T o = this.NextElement();
        if (this.IsEndOfFile(o))
          this._eof = o;
        this._data.Add(o);
      }
    }

    public override int Count
    {
      get
      {
        throw new NotSupportedException("streams are of unknown size");
      }
    }

    public virtual T LT(int k)
    {
      if (k == 0)
        return default (T);
      if (k < 0)
        return this.LB(-k);
      this.SyncAhead(k);
      if (this._p + k - 1 > this._data.Count)
        return this._eof;
      return this[k - 1];
    }

    public virtual int Index
    {
      get
      {
        return this._currentElementIndex;
      }
    }

    public virtual int Mark()
    {
      ++this._markDepth;
      this._lastMarker = this._p;
      return this._lastMarker;
    }

    public virtual void Release(int marker)
    {
      --this._markDepth;
    }

    public virtual void Rewind(int marker)
    {
      this.Seek(marker);
      this.Release(marker);
    }

    public virtual void Rewind()
    {
      this.Seek(this._lastMarker);
    }

    public virtual void Seek(int index)
    {
      this._p = index;
    }

    protected virtual T LB(int k)
    {
      if (k == 1)
        return this._previousElement;
      throw new ArgumentException("can't look backwards more than one token in this stream");
    }
  }
}
