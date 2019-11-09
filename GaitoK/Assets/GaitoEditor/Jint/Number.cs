// Decompiled with JetBrains decompiler
// Type: Jint.Number
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using System;

namespace Jint
{
  public class Number
  {
    public static object Add(object a, object b)
    {
      TypeCode typeCode1 = Type.GetTypeCode(a.GetType());
      TypeCode typeCode2 = Type.GetTypeCode(b.GetType());
      switch (typeCode1)
      {
        case TypeCode.SByte:
          switch (typeCode2)
          {
            case TypeCode.SByte:
              return (object) ((int) (sbyte) a + (int) (sbyte) b);
            case TypeCode.Int16:
              return (object) ((int) (sbyte) a + (int) (short) b);
            case TypeCode.UInt16:
              return (object) ((int) (sbyte) a + (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (sbyte) a + (int) b);
            case TypeCode.UInt32:
              return (object) ((long) (sbyte) a + (long) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (sbyte) a + (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '+' can't be applied to operands of types 'sbyte' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (sbyte) a + (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (sbyte) a + (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((sbyte) a) + (Decimal) b);
          }
        case TypeCode.Byte:
          switch (typeCode2)
          {
            case TypeCode.SByte:
              return (object) ((int) (byte) a + (int) (sbyte) b);
            case TypeCode.Int16:
              return (object) ((int) (byte) a + (int) (short) b);
            case TypeCode.UInt16:
              return (object) ((int) (byte) a + (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (byte) a + (int) b);
            case TypeCode.UInt32:
              return (object) (uint) ((int) (byte) a + (int) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (byte) a + (long) b);
            case TypeCode.UInt64:
              return (object) (ulong) ((long) (byte) a + (long) (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (byte) a + (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (byte) a + (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((byte) a) + (Decimal) b);
          }
        case TypeCode.Int16:
          switch (typeCode2)
          {
            case TypeCode.Int16:
              return (object) ((int) (short) a + (int) (short) b);
            case TypeCode.UInt16:
              return (object) ((int) (short) a + (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (short) a + (int) b);
            case TypeCode.UInt32:
              return (object) ((long) (short) a + (long) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (short) a + (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '+' can't be applied to operands of types 'short' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (short) a + (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (short) a + (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((short) a) + (Decimal) b);
          }
        case TypeCode.UInt16:
          switch (typeCode2)
          {
            case TypeCode.UInt16:
              return (object) ((int) (ushort) a + (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (ushort) a + (int) b);
            case TypeCode.UInt32:
              return (object) (uint) ((int) (ushort) a + (int) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (ushort) a + (long) b);
            case TypeCode.UInt64:
              return (object) (ulong) ((long) (ushort) a + (long) (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (ushort) a + (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (ushort) a + (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((ushort) a) + (Decimal) b);
          }
        case TypeCode.Int32:
          switch (typeCode2)
          {
            case TypeCode.Int32:
              return (object) ((int) a + (int) b);
            case TypeCode.UInt32:
              return (object) ((long) (int) a + (long) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (int) a + (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '+' can't be applied to operands of types 'int' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (int) a + (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (int) a + (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((int) a) + (Decimal) b);
          }
        case TypeCode.UInt32:
          switch (typeCode2)
          {
            case TypeCode.UInt32:
              return (object) (uint) ((int) (uint) a + (int) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (uint) a + (long) b);
            case TypeCode.UInt64:
              return (object) (ulong) ((long) (uint) a + (long) (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (uint) a + (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (uint) a + (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((uint) a) + (Decimal) b);
          }
        case TypeCode.Int64:
          switch (typeCode2)
          {
            case TypeCode.Int64:
              return (object) ((long) a + (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '+' can't be applied to operands of types 'long' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (long) a + (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (long) a + (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((long) a) + (Decimal) b);
          }
        case TypeCode.UInt64:
          switch (typeCode2)
          {
            case TypeCode.UInt64:
              return (object) (ulong) ((long) (ulong) a + (long) (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (ulong) a + (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (ulong) a + (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((ulong) a) + (Decimal) b);
          }
        case TypeCode.Single:
          switch (typeCode2)
          {
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '+' can't be applied to operands of types 'float' and 'decimal'");
            case TypeCode.Single:
              return (object) (float) ((double) (float) a + (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (float) a + (double) b);
          }
        case TypeCode.Double:
          switch (typeCode2)
          {
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '+' can't be applied to operands of types 'double' and 'decimal'");
            case TypeCode.Double:
              return (object) ((double) a + (double) b);
          }
        case TypeCode.Decimal:
          if (typeCode2 == TypeCode.Decimal)
            return (object) ((Decimal) a + (Decimal) b);
          break;
      }
      return (object) null;
    }

    public static object Soustract(object a, object b)
    {
      TypeCode typeCode1 = Type.GetTypeCode(a.GetType());
      TypeCode typeCode2 = Type.GetTypeCode(b.GetType());
      switch (typeCode1)
      {
        case TypeCode.SByte:
          switch (typeCode2)
          {
            case TypeCode.SByte:
              return (object) ((int) (sbyte) a - (int) (sbyte) b);
            case TypeCode.Int16:
              return (object) ((int) (sbyte) a - (int) (short) b);
            case TypeCode.UInt16:
              return (object) ((int) (sbyte) a - (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (sbyte) a - (int) b);
            case TypeCode.UInt32:
              return (object) ((long) (sbyte) a - (long) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (sbyte) a - (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '-' can't be applied to operands of types 'sbyte' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (sbyte) a - (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (sbyte) a - (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((sbyte) a) - (Decimal) b);
          }
        case TypeCode.Byte:
          switch (typeCode2)
          {
            case TypeCode.SByte:
              return (object) ((int) (byte) a - (int) (sbyte) b);
            case TypeCode.Int16:
              return (object) ((int) (byte) a - (int) (short) b);
            case TypeCode.UInt16:
              return (object) ((int) (byte) a - (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (byte) a - (int) b);
            case TypeCode.UInt32:
              return (object) (uint) ((int) (byte) a - (int) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (byte) a - (long) b);
            case TypeCode.UInt64:
              return (object) (ulong) ((long) (byte) a - (long) (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (byte) a - (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (byte) a - (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((byte) a) - (Decimal) b);
          }
        case TypeCode.Int16:
          switch (typeCode2)
          {
            case TypeCode.Int16:
              return (object) ((int) (short) a - (int) (short) b);
            case TypeCode.UInt16:
              return (object) ((int) (short) a - (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (short) a - (int) b);
            case TypeCode.UInt32:
              return (object) ((long) (short) a - (long) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (short) a - (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '-' can't be applied to operands of types 'short' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (short) a - (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (short) a - (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((short) a) - (Decimal) b);
          }
        case TypeCode.UInt16:
          switch (typeCode2)
          {
            case TypeCode.UInt16:
              return (object) ((int) (ushort) a - (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (ushort) a - (int) b);
            case TypeCode.UInt32:
              return (object) (uint) ((int) (ushort) a - (int) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (ushort) a - (long) b);
            case TypeCode.UInt64:
              return (object) (ulong) ((long) (ushort) a - (long) (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (ushort) a - (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (ushort) a - (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((ushort) a) - (Decimal) b);
          }
        case TypeCode.Int32:
          switch (typeCode2)
          {
            case TypeCode.Int32:
              return (object) ((int) a - (int) b);
            case TypeCode.UInt32:
              return (object) ((long) (int) a - (long) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (int) a - (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '-' can't be applied to operands of types 'int' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (int) a - (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (int) a - (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((int) a) - (Decimal) b);
          }
        case TypeCode.UInt32:
          switch (typeCode2)
          {
            case TypeCode.UInt32:
              return (object) (uint) ((int) (uint) a - (int) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (uint) a - (long) b);
            case TypeCode.UInt64:
              return (object) (ulong) ((long) (uint) a - (long) (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (uint) a - (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (uint) a - (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((uint) a) - (Decimal) b);
          }
        case TypeCode.Int64:
          switch (typeCode2)
          {
            case TypeCode.Int64:
              return (object) ((long) a - (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '-' can't be applied to operands of types 'long' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (long) a - (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (long) a - (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((long) a) - (Decimal) b);
          }
        case TypeCode.UInt64:
          switch (typeCode2)
          {
            case TypeCode.UInt64:
              return (object) (ulong) ((long) (ulong) a - (long) (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (ulong) a - (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (ulong) a - (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((ulong) a) - (Decimal) b);
          }
        case TypeCode.Single:
          switch (typeCode2)
          {
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '-' can't be applied to operands of types 'float' and 'decimal'");
            case TypeCode.Single:
              return (object) (float) ((double) (float) a - (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (float) a - (double) b);
          }
        case TypeCode.Double:
          switch (typeCode2)
          {
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '-' can't be applied to operands of types 'double' and 'decimal'");
            case TypeCode.Double:
              return (object) ((double) a - (double) b);
          }
        case TypeCode.Decimal:
          if (typeCode2 == TypeCode.Decimal)
            return (object) ((Decimal) ((byte) a) - (Decimal) b);
          break;
      }
      return (object) null;
    }

    public static object Multiply(object a, object b)
    {
      TypeCode typeCode1 = Type.GetTypeCode(a.GetType());
      TypeCode typeCode2 = Type.GetTypeCode(b.GetType());
      switch (typeCode1)
      {
        case TypeCode.SByte:
          switch (typeCode2)
          {
            case TypeCode.SByte:
              return (object) ((int) (sbyte) a * (int) (sbyte) b);
            case TypeCode.Int16:
              return (object) ((int) (sbyte) a * (int) (short) b);
            case TypeCode.UInt16:
              return (object) ((int) (sbyte) a * (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (sbyte) a * (int) b);
            case TypeCode.UInt32:
              return (object) ((long) (sbyte) a * (long) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (sbyte) a * (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '*' can't be applied to operands of types 'sbyte' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (sbyte) a * (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (sbyte) a * (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((sbyte) a) * (Decimal) b);
          }
        case TypeCode.Byte:
          switch (typeCode2)
          {
            case TypeCode.SByte:
              return (object) ((int) (byte) a * (int) (sbyte) b);
            case TypeCode.Int16:
              return (object) ((int) (byte) a * (int) (short) b);
            case TypeCode.UInt16:
              return (object) ((int) (byte) a * (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (byte) a * (int) b);
            case TypeCode.UInt32:
              return (object) (uint) ((int) (byte) a * (int) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (byte) a * (long) b);
            case TypeCode.UInt64:
              return (object) (ulong) ((long) (byte) a * (long) (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (byte) a * (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (byte) a * (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((byte) a) * (Decimal) b);
          }
        case TypeCode.Int16:
          switch (typeCode2)
          {
            case TypeCode.Int16:
              return (object) ((int) (short) a * (int) (short) b);
            case TypeCode.UInt16:
              return (object) ((int) (short) a * (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (short) a * (int) b);
            case TypeCode.UInt32:
              return (object) ((long) (short) a * (long) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (short) a * (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '*' can't be applied to operands of types 'short' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (short) a * (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (short) a * (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((short) a) * (Decimal) b);
          }
        case TypeCode.UInt16:
          switch (typeCode2)
          {
            case TypeCode.UInt16:
              return (object) ((int) (ushort) a * (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (ushort) a * (int) b);
            case TypeCode.UInt32:
              return (object) (uint) ((int) (ushort) a * (int) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (ushort) a * (long) b);
            case TypeCode.UInt64:
              return (object) (ulong) ((long) (ushort) a * (long) (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (ushort) a * (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (ushort) a * (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((ushort) a) * (Decimal) b);
          }
        case TypeCode.Int32:
          switch (typeCode2)
          {
            case TypeCode.Int32:
              return (object) ((int) a * (int) b);
            case TypeCode.UInt32:
              return (object) ((long) (int) a * (long) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (int) a * (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '*' can't be applied to operands of types 'int' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (int) a * (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (int) a * (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((int) a) * (Decimal) b);
          }
        case TypeCode.UInt32:
          switch (typeCode2)
          {
            case TypeCode.UInt32:
              return (object) (uint) ((int) (uint) a * (int) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (uint) a * (long) b);
            case TypeCode.UInt64:
              return (object) (ulong) ((long) (uint) a * (long) (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (uint) a * (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (uint) a * (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((uint) a) * (Decimal) b);
          }
        case TypeCode.Int64:
          switch (typeCode2)
          {
            case TypeCode.Int64:
              return (object) ((long) a * (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '*' can't be applied to operands of types 'long' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (long) a * (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (long) a * (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((long) a) * (Decimal) b);
          }
        case TypeCode.UInt64:
          switch (typeCode2)
          {
            case TypeCode.UInt64:
              return (object) (ulong) ((long) (ulong) a * (long) (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (ulong) a * (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (ulong) a * (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((ulong) a) * (Decimal) b);
          }
        case TypeCode.Single:
          switch (typeCode2)
          {
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '*' can't be applied to operands of types 'float' and 'decimal'");
            case TypeCode.Single:
              return (object) (float) ((double) (float) a * (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (float) a * (double) b);
          }
        case TypeCode.Double:
          switch (typeCode2)
          {
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '*' can't be applied to operands of types 'double' and 'decimal'");
            case TypeCode.Double:
              return (object) ((double) a * (double) b);
          }
        case TypeCode.Decimal:
          if (typeCode2 == TypeCode.Decimal)
            return (object) ((Decimal) ((byte) a) * (Decimal) b);
          break;
      }
      return (object) null;
    }

    public static object Divide(object a, object b)
    {
      TypeCode typeCode1 = Type.GetTypeCode(a.GetType());
      TypeCode typeCode2 = Type.GetTypeCode(b.GetType());
      switch (typeCode1)
      {
        case TypeCode.SByte:
          switch (typeCode2)
          {
            case TypeCode.SByte:
              return (object) ((int) (sbyte) a / (int) (sbyte) b);
            case TypeCode.Int16:
              return (object) ((int) (sbyte) a / (int) (short) b);
            case TypeCode.UInt16:
              return (object) ((int) (sbyte) a / (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (sbyte) a / (int) b);
            case TypeCode.UInt32:
              return (object) ((long) (sbyte) a / (long) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (sbyte) a / (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '/' can't be applied to operands of types 'sbyte' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (sbyte) a / (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (sbyte) a / (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((sbyte) a) / (Decimal) b);
          }
        case TypeCode.Byte:
          switch (typeCode2)
          {
            case TypeCode.SByte:
              return (object) ((int) (byte) a / (int) (sbyte) b);
            case TypeCode.Int16:
              return (object) ((int) (byte) a / (int) (short) b);
            case TypeCode.UInt16:
              return (object) ((int) (byte) a / (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (byte) a / (int) b);
            case TypeCode.UInt32:
              return (object) ((uint) (byte) a / (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (byte) a / (long) b);
            case TypeCode.UInt64:
              return (object) ((ulong) (byte) a / (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (byte) a / (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (byte) a / (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((byte) a) / (Decimal) b);
          }
        case TypeCode.Int16:
          switch (typeCode2)
          {
            case TypeCode.Int16:
              return (object) ((int) (short) a / (int) (short) b);
            case TypeCode.UInt16:
              return (object) ((int) (short) a / (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (short) a / (int) b);
            case TypeCode.UInt32:
              return (object) ((long) (short) a / (long) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (short) a / (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '/' can't be applied to operands of types 'short' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (short) a / (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (short) a / (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((short) a) / (Decimal) b);
          }
        case TypeCode.UInt16:
          switch (typeCode2)
          {
            case TypeCode.UInt16:
              return (object) ((int) (ushort) a / (int) (ushort) b);
            case TypeCode.Int32:
              return (object) ((int) (ushort) a / (int) b);
            case TypeCode.UInt32:
              return (object) ((uint) (ushort) a / (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (ushort) a / (long) b);
            case TypeCode.UInt64:
              return (object) ((ulong) (ushort) a / (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (ushort) a / (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (ushort) a / (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((ushort) a) / (Decimal) b);
          }
        case TypeCode.Int32:
          switch (typeCode2)
          {
            case TypeCode.Int32:
              return (object) ((int) a / (int) b);
            case TypeCode.UInt32:
              return (object) ((long) (int) a / (long) (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (int) a / (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '/' can't be applied to operands of types 'int' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (int) a / (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (int) a / (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((int) a) / (Decimal) b);
          }
        case TypeCode.UInt32:
          switch (typeCode2)
          {
            case TypeCode.UInt32:
              return (object) ((uint) a / (uint) b);
            case TypeCode.Int64:
              return (object) ((long) (uint) a / (long) b);
            case TypeCode.UInt64:
              return (object) ((ulong) (uint) a / (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (uint) a / (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (uint) a / (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((uint) a) / (Decimal) b);
          }
        case TypeCode.Int64:
          switch (typeCode2)
          {
            case TypeCode.Int64:
              return (object) ((long) a / (long) b);
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '/' can't be applied to operands of types 'long' and 'ulong'");
            case TypeCode.Single:
              return (object) (float) ((double) (long) a / (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (long) a / (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((long) a) / (Decimal) b);
          }
        case TypeCode.UInt64:
          switch (typeCode2)
          {
            case TypeCode.UInt64:
              return (object) ((ulong) a / (ulong) b);
            case TypeCode.Single:
              return (object) (float) ((double) (ulong) a / (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (ulong) a / (double) b);
            case TypeCode.Decimal:
              return (object) ((Decimal) ((ulong) a) / (Decimal) b);
          }
        case TypeCode.Single:
          switch (typeCode2)
          {
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '/' can't be applied to operands of types 'float' and 'decimal'");
            case TypeCode.Single:
              return (object) (float) ((double) (float) a / (double) (float) b);
            case TypeCode.Double:
              return (object) ((double) (float) a / (double) b);
          }
        case TypeCode.Double:
          switch (typeCode2)
          {
            case TypeCode.UInt64:
              throw new InvalidOperationException("Operator '/' can't be applied to operands of types 'double' and 'decimal'");
            case TypeCode.Double:
              return (object) ((double) a / (double) b);
          }
        case TypeCode.Decimal:
          if (typeCode2 == TypeCode.Decimal)
            return (object) ((Decimal) ((byte) a) / (Decimal) b);
          break;
      }
      return (object) null;
    }

    public static object Max(object a, object b)
    {
      if (a == null && b == null)
        return (object) null;
      if (a == null)
        return b;
      if (b == null)
        return a;
      TypeCode typeCode = Type.GetTypeCode(a.GetType());
      Type.GetTypeCode(b.GetType());
      switch (typeCode)
      {
        case TypeCode.SByte:
          return (object) Math.Max((sbyte) a, Convert.ToSByte(b));
        case TypeCode.Byte:
          return (object) Math.Max((byte) a, Convert.ToByte(b));
        case TypeCode.Int16:
          return (object) Math.Max((short) a, Convert.ToInt16(b));
        case TypeCode.UInt16:
          return (object) Math.Max((ushort) a, Convert.ToUInt16(b));
        case TypeCode.Int32:
          return (object) Math.Max((int) a, Convert.ToInt32(b));
        case TypeCode.UInt32:
          return (object) Math.Max((uint) a, Convert.ToUInt32(b));
        case TypeCode.Int64:
          return (object) Math.Max((long) a, Convert.ToInt64(b));
        case TypeCode.UInt64:
          return (object) Math.Max((ulong) a, Convert.ToUInt64(b));
        case TypeCode.Single:
          return (object) Math.Max((float) a, Convert.ToSingle(b));
        case TypeCode.Double:
          return (object) Math.Max((double) a, Convert.ToDouble(b));
        case TypeCode.Decimal:
          return (object) Math.Max((Decimal) a, Convert.ToDecimal(b));
        default:
          return (object) null;
      }
    }

    public static object Min(object a, object b)
    {
      if (a == null && b == null)
        return (object) null;
      if (a == null)
        return b;
      if (b == null)
        return a;
      TypeCode typeCode = Type.GetTypeCode(a.GetType());
      Type.GetTypeCode(b.GetType());
      switch (typeCode)
      {
        case TypeCode.SByte:
          return (object) Math.Min((sbyte) a, Convert.ToSByte(b));
        case TypeCode.Byte:
          return (object) Math.Min((byte) a, Convert.ToByte(b));
        case TypeCode.Int16:
          return (object) Math.Min((short) a, Convert.ToInt16(b));
        case TypeCode.UInt16:
          return (object) Math.Min((ushort) a, Convert.ToUInt16(b));
        case TypeCode.Int32:
          return (object) Math.Min((int) a, Convert.ToInt32(b));
        case TypeCode.UInt32:
          return (object) Math.Min((uint) a, Convert.ToUInt32(b));
        case TypeCode.Int64:
          return (object) Math.Min((long) a, Convert.ToInt64(b));
        case TypeCode.UInt64:
          return (object) Math.Min((ulong) a, Convert.ToUInt64(b));
        case TypeCode.Single:
          return (object) Math.Min((float) a, Convert.ToSingle(b));
        case TypeCode.Double:
          return (object) Math.Min((double) a, Convert.ToDouble(b));
        case TypeCode.Decimal:
          return (object) Math.Min((Decimal) a, Convert.ToDecimal(b));
        default:
          return (object) null;
      }
    }
  }
}
