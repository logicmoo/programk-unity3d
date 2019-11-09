// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.DFA
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using System;
using System.Diagnostics;

namespace Antlr.Runtime
{
  public class DFA
  {
    protected short[] eot;
    protected short[] eof;
    protected char[] min;
    protected char[] max;
    protected short[] accept;
    protected short[] special;
    protected short[][] transition;
    protected int decisionNumber;
    protected BaseRecognizer recognizer;
    public readonly bool debug;

    public DFA()
      : this(new SpecialStateTransitionHandler(DFA.SpecialStateTransitionDefault))
    {
    }

    public DFA(
      SpecialStateTransitionHandler specialStateTransition)
    {
      this.SpecialStateTransition = specialStateTransition ?? new SpecialStateTransitionHandler(DFA.SpecialStateTransitionDefault);
    }

    public virtual string Description
    {
      get
      {
        return "n/a";
      }
    }

    public virtual int Predict(IIntStream input)
    {
      if (this.debug)
        Console.Error.WriteLine("Enter DFA.predict for decision " + (object) this.decisionNumber);
      int marker = input.Mark();
      int s1 = 0;
      try
      {
        char ch;
        while (true)
        {
          if (this.debug)
            Console.Error.WriteLine("DFA " + (object) this.decisionNumber + " state " + (object) s1 + " LA(1)=" + (object) (char) input.LA(1) + "(" + (object) input.LA(1) + "), index=" + (object) input.Index);
          int s2 = (int) this.special[s1];
          if (s2 >= 0)
          {
            if (this.debug)
              Console.Error.WriteLine("DFA " + (object) this.decisionNumber + " state " + (object) s1 + " is special state " + (object) s2);
            s1 = this.SpecialStateTransition(this, s2, input);
            if (this.debug)
              Console.Error.WriteLine("DFA " + (object) this.decisionNumber + " returns from special state " + (object) s2 + " to " + (object) s1);
            if (s1 != -1)
              input.Consume();
            else
              break;
          }
          else if (this.accept[s1] < (short) 1)
          {
            ch = (char) input.LA(1);
            if ((int) ch >= (int) this.min[s1] && (int) ch <= (int) this.max[s1])
            {
              int num = (int) this.transition[s1][(int) ch - (int) this.min[s1]];
              if (num < 0)
              {
                if (this.eot[s1] >= (short) 0)
                {
                  if (this.debug)
                    Console.Error.WriteLine("EOT transition");
                  s1 = (int) this.eot[s1];
                  input.Consume();
                }
                else
                  goto label_23;
              }
              else
              {
                s1 = num;
                input.Consume();
              }
            }
            else if (this.eot[s1] >= (short) 0)
            {
              if (this.debug)
                Console.Error.WriteLine("EOT transition");
              s1 = (int) this.eot[s1];
              input.Consume();
            }
            else
              goto label_29;
          }
          else
            goto label_14;
        }
        this.NoViableAlt(s1, input);
        return 0;
label_14:
        if (this.debug)
          Console.Error.WriteLine("accept; predict " + (object) this.accept[s1] + " from state " + (object) s1);
        return (int) this.accept[s1];
label_23:
        this.NoViableAlt(s1, input);
        return 0;
label_29:
        if (ch == char.MaxValue && this.eof[s1] >= (short) 0)
        {
          if (this.debug)
            Console.Error.WriteLine("accept via EOF; predict " + (object) this.accept[(int) this.eof[s1]] + " from " + (object) this.eof[s1]);
          return (int) this.accept[(int) this.eof[s1]];
        }
        if (this.debug)
        {
          Console.Error.WriteLine("min[" + (object) s1 + "]=" + (object) this.min[s1]);
          Console.Error.WriteLine("max[" + (object) s1 + "]=" + (object) this.max[s1]);
          Console.Error.WriteLine("eot[" + (object) s1 + "]=" + (object) this.eot[s1]);
          Console.Error.WriteLine("eof[" + (object) s1 + "]=" + (object) this.eof[s1]);
          for (int index = 0; index < this.transition[s1].Length; ++index)
            Console.Error.Write(((int) this.transition[s1][index]).ToString() + " ");
          Console.Error.WriteLine();
        }
        this.NoViableAlt(s1, input);
        return 0;
      }
      finally
      {
        input.Rewind(marker);
      }
    }

    protected virtual void NoViableAlt(int s, IIntStream input)
    {
      if (this.recognizer.state.backtracking > 0)
      {
        this.recognizer.state.failed = true;
      }
      else
      {
        NoViableAltException nvae = new NoViableAltException(this.Description, this.decisionNumber, s, input);
        this.Error(nvae);
        throw nvae;
      }
    }

    public virtual void Error(NoViableAltException nvae)
    {
    }

    public SpecialStateTransitionHandler SpecialStateTransition { get; private set; }

    private static int SpecialStateTransitionDefault(DFA dfa, int s, IIntStream input)
    {
      return -1;
    }

    public static short[] UnpackEncodedString(string encodedString)
    {
      int length = 0;
      for (int index = 0; index < encodedString.Length; index += 2)
        length += (int) encodedString[index];
      short[] numArray = new short[length];
      int num = 0;
      for (int index1 = 0; index1 < encodedString.Length; index1 += 2)
      {
        char ch1 = encodedString[index1];
        char ch2 = encodedString[index1 + 1];
        for (int index2 = 1; index2 <= (int) ch1; ++index2)
          numArray[num++] = (short) ch2;
      }
      return numArray;
    }

    public static char[] UnpackEncodedStringToUnsignedChars(string encodedString)
    {
      int length = 0;
      for (int index = 0; index < encodedString.Length; index += 2)
        length += (int) encodedString[index];
      char[] chArray = new char[length];
      int num = 0;
      for (int index1 = 0; index1 < encodedString.Length; index1 += 2)
      {
        char ch1 = encodedString[index1];
        char ch2 = encodedString[index1 + 1];
        for (int index2 = 1; index2 <= (int) ch1; ++index2)
          chArray[num++] = ch2;
      }
      return chArray;
    }

    [Conditional("ANTLR_DEBUG")]
    protected virtual void DebugRecognitionException(RecognitionException ex)
    {
      this.recognizer.DebugListener?.RecognitionException(ex);
    }
  }
}
