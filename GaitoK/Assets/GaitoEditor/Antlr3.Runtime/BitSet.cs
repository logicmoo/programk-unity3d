// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.BitSet
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Collections.Generic;
using System.Text;

namespace Antlr.Runtime
{
  [Serializable]
  public sealed class BitSet : ICloneable
  {
    private const int BITS = 64;
    private const int LOG_BITS = 6;
    private const int MOD_MASK = 63;
    private ulong[] _bits;

    public BitSet()
      : this(64)
    {
    }

    [CLSCompliant(false)]
    public BitSet(ulong[] bits)
    {
      this._bits = bits;
    }

    public BitSet(IEnumerable<int> items)
      : this()
    {
      foreach (int el in items)
        this.Add(el);
    }

    public BitSet(int nbits)
    {
      this._bits = new ulong[(nbits - 1 >> 6) + 1];
    }

    public static BitSet Of(int el)
    {
      BitSet bitSet = new BitSet(el + 1);
      bitSet.Add(el);
      return bitSet;
    }

    public static BitSet Of(int a, int b)
    {
      BitSet bitSet = new BitSet(Math.Max(a, b) + 1);
      bitSet.Add(a);
      bitSet.Add(b);
      return bitSet;
    }

    public static BitSet Of(int a, int b, int c)
    {
      BitSet bitSet = new BitSet();
      bitSet.Add(a);
      bitSet.Add(b);
      bitSet.Add(c);
      return bitSet;
    }

    public static BitSet Of(int a, int b, int c, int d)
    {
      BitSet bitSet = new BitSet();
      bitSet.Add(a);
      bitSet.Add(b);
      bitSet.Add(c);
      bitSet.Add(d);
      return bitSet;
    }

    public BitSet Or(BitSet a)
    {
      if (a == null)
        return this;
      BitSet bitSet = (BitSet) this.Clone();
      bitSet.OrInPlace(a);
      return bitSet;
    }

    public void Add(int el)
    {
      int index = BitSet.WordNumber(el);
      if (index >= this._bits.Length)
        this.GrowToInclude(el);
      this._bits[index] |= BitSet.BitMask(el);
    }

    public void GrowToInclude(int bit)
    {
      this.SetSize(Math.Max(this._bits.Length << 1, BitSet.NumWordsToHold(bit)));
    }

    public void OrInPlace(BitSet a)
    {
      if (a == null)
        return;
      if (a._bits.Length > this._bits.Length)
        this.SetSize(a._bits.Length);
      for (int index = Math.Min(this._bits.Length, a._bits.Length) - 1; index >= 0; --index)
        this._bits[index] |= a._bits[index];
    }

    private void SetSize(int nwords)
    {
      Array.Resize<ulong>(ref this._bits, nwords);
    }

    private static ulong BitMask(int bitNumber)
    {
      return 1UL << bitNumber;
    }

    public object Clone()
    {
      return (object) new BitSet((ulong[]) this._bits.Clone());
    }

    public int Size()
    {
      int num = 0;
      for (int index1 = this._bits.Length - 1; index1 >= 0; --index1)
      {
        ulong bit = this._bits[index1];
        if (bit != 0UL)
        {
          for (int index2 = 63; index2 >= 0; --index2)
          {
            if (((long) bit & 1L << index2) != 0L)
              ++num;
          }
        }
      }
      return num;
    }

    public override int GetHashCode()
    {
      throw new NotImplementedException();
    }

    public override bool Equals(object other)
    {
      if (other == null || !(other is BitSet))
        return false;
      BitSet bitSet = (BitSet) other;
      int num = Math.Min(this._bits.Length, bitSet._bits.Length);
      for (int index = 0; index < num; ++index)
      {
        if ((long) this._bits[index] != (long) bitSet._bits[index])
          return false;
      }
      if (this._bits.Length > num)
      {
        for (int index = num + 1; index < this._bits.Length; ++index)
        {
          if (this._bits[index] != 0UL)
            return false;
        }
      }
      else if (bitSet._bits.Length > num)
      {
        for (int index = num + 1; index < bitSet._bits.Length; ++index)
        {
          if (bitSet._bits[index] != 0UL)
            return false;
        }
      }
      return true;
    }

    public bool Member(int el)
    {
      if (el < 0)
        return false;
      int index = BitSet.WordNumber(el);
      if (index >= this._bits.Length)
        return false;
      return ((long) this._bits[index] & (long) BitSet.BitMask(el)) != 0L;
    }

    public void Remove(int el)
    {
      int index = BitSet.WordNumber(el);
      if (index >= this._bits.Length)
        return;
      this._bits[index] &= ~BitSet.BitMask(el);
    }

    public bool IsNil()
    {
      for (int index = this._bits.Length - 1; index >= 0; --index)
      {
        if (this._bits[index] != 0UL)
          return false;
      }
      return true;
    }

    private static int NumWordsToHold(int el)
    {
      return (el >> 6) + 1;
    }

    public int NumBits()
    {
      return this._bits.Length << 6;
    }

    public int LengthInLongWords()
    {
      return this._bits.Length;
    }

    public int[] ToArray()
    {
      int[] numArray = new int[this.Size()];
      int num = 0;
      for (int el = 0; el < this._bits.Length << 6; ++el)
      {
        if (this.Member(el))
          numArray[num++] = el;
      }
      return numArray;
    }

    private static int WordNumber(int bit)
    {
      return bit >> 6;
    }

    public override string ToString()
    {
      return this.ToString((string[]) null);
    }

    public string ToString(string[] tokenNames)
    {
      StringBuilder stringBuilder = new StringBuilder();
      string str = ",";
      bool flag = false;
      stringBuilder.Append('{');
      for (int el = 0; el < this._bits.Length << 6; ++el)
      {
        if (this.Member(el))
        {
          if (el > 0 && flag)
            stringBuilder.Append(str);
          if (tokenNames != null)
            stringBuilder.Append(tokenNames[el]);
          else
            stringBuilder.Append(el);
          flag = true;
        }
      }
      stringBuilder.Append('}');
      return stringBuilder.ToString();
    }
  }
}
