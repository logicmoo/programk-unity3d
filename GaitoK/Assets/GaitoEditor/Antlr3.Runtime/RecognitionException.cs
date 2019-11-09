// Decompiled with JetBrains decompiler
// Type: Antlr.Runtime.RecognitionException
// Assembly: Antlr3.Runtime, Version=3.3.1.7705, Culture=neutral, PublicKeyToken=eb42632606e9261f
// MVID: 32AD83F8-F3A2-49B2-A367-4235D6D28D9A
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Antlr3.Runtime.dll

using Antlr.Runtime.Tree;
using System;
using System.Runtime.Serialization;

namespace Antlr.Runtime
{
  [Serializable]
  public class RecognitionException : Exception
  {
    private IIntStream _input;
    private int _index;
    private IToken _token;
    private object _node;
    private int _c;
    private int _line;
    private int _charPositionInLine;
    private bool _approximateLineInfo;

    public RecognitionException()
      : this("A recognition error occurred.", (IIntStream) null, (Exception) null)
    {
    }

    public RecognitionException(IIntStream input)
      : this("A recognition error occurred.", input, (Exception) null)
    {
    }

    public RecognitionException(string message)
      : this(message, (IIntStream) null, (Exception) null)
    {
    }

    public RecognitionException(string message, IIntStream input)
      : this(message, input, (Exception) null)
    {
    }

    public RecognitionException(string message, Exception innerException)
      : this(message, (IIntStream) null, innerException)
    {
    }

    public RecognitionException(string message, IIntStream input, Exception innerException)
      : base(message, innerException)
    {
      this._input = input;
      if (input == null)
        return;
      this._index = input.Index;
      if (input is ITokenStream)
      {
        this._token = ((ITokenStream) input).LT(1);
        this._line = this._token.Line;
        this._charPositionInLine = this._token.CharPositionInLine;
      }
      ITreeNodeStream input1 = input as ITreeNodeStream;
      if (input1 != null)
        this.ExtractInformationFromTreeNodeStream(input1);
      else if (input is ICharStream)
      {
        this._c = input.LA(1);
        this._line = ((ICharStream) input).Line;
        this._charPositionInLine = ((ICharStream) input).CharPositionInLine;
      }
      else
        this._c = input.LA(1);
    }

    protected RecognitionException(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      this._index = info.GetInt32(nameof (Index));
      this._c = info.GetInt32("C");
      this._line = info.GetInt32(nameof (Line));
      this._charPositionInLine = info.GetInt32(nameof (CharPositionInLine));
      this._approximateLineInfo = info.GetBoolean(nameof (ApproximateLineInfo));
    }

    public virtual int UnexpectedType
    {
      get
      {
        if (this._input is ITokenStream)
          return this._token.Type;
        ITreeNodeStream input = this._input as ITreeNodeStream;
        if (input != null)
          return input.TreeAdaptor.GetType(this._node);
        return this._c;
      }
    }

    public bool ApproximateLineInfo
    {
      get
      {
        return this._approximateLineInfo;
      }
      protected set
      {
        this._approximateLineInfo = value;
      }
    }

    public IIntStream Input
    {
      get
      {
        return this._input;
      }
      protected set
      {
        this._input = value;
      }
    }

    public IToken Token
    {
      get
      {
        return this._token;
      }
      set
      {
        this._token = value;
      }
    }

    public object Node
    {
      get
      {
        return this._node;
      }
      protected set
      {
        this._node = value;
      }
    }

    public int Character
    {
      get
      {
        return this._c;
      }
      protected set
      {
        this._c = value;
      }
    }

    public int Index
    {
      get
      {
        return this._index;
      }
      protected set
      {
        this._index = value;
      }
    }

    public int Line
    {
      get
      {
        return this._line;
      }
      set
      {
        this._line = value;
      }
    }

    public int CharPositionInLine
    {
      get
      {
        return this._charPositionInLine;
      }
      set
      {
        this._charPositionInLine = value;
      }
    }

    public override void GetObjectData(SerializationInfo info, StreamingContext context)
    {
      if (info == null)
        throw new ArgumentNullException(nameof (info));
      base.GetObjectData(info, context);
      info.AddValue("Index", this._index);
      info.AddValue("C", this._c);
      info.AddValue("Line", this._line);
      info.AddValue("CharPositionInLine", this._charPositionInLine);
      info.AddValue("ApproximateLineInfo", this._approximateLineInfo);
    }

    protected virtual void ExtractInformationFromTreeNodeStream(ITreeNodeStream input)
    {
      this._node = input.LT(1);
      ITokenStreamInformation streamInformation = input as ITokenStreamInformation;
      if (streamInformation != null)
      {
        IToken lastToken = streamInformation.LastToken;
        IToken lastRealToken = streamInformation.LastRealToken;
        if (lastRealToken == null)
          return;
        this._token = lastRealToken;
        this._line = lastRealToken.Line;
        this._charPositionInLine = lastRealToken.CharPositionInLine;
        this._approximateLineInfo = lastRealToken.Equals((object) lastToken);
      }
      else
      {
        ITreeAdaptor treeAdaptor = input.TreeAdaptor;
        IToken token1 = treeAdaptor.GetToken(this._node);
        if (token1 != null)
        {
          this._token = token1;
          if (token1.Line <= 0)
          {
            int k = -1;
            object t = input.LT(k);
            while (t != null)
            {
              IToken token2 = treeAdaptor.GetToken(t);
              if (token2 != null && token2.Line > 0)
              {
                this._line = token2.Line;
                this._charPositionInLine = token2.CharPositionInLine;
                this._approximateLineInfo = true;
                break;
              }
              --k;
              try
              {
                t = input.LT(k);
              }
              catch (ArgumentException ex)
              {
                t = (object) null;
              }
            }
          }
          else
          {
            this._line = token1.Line;
            this._charPositionInLine = token1.CharPositionInLine;
          }
        }
        else if (this._node is ITree)
        {
          this._line = ((ITree) this._node).Line;
          this._charPositionInLine = ((ITree) this._node).CharPositionInLine;
          if (!(this._node is CommonTree))
            return;
          this._token = ((CommonTree) this._node).Token;
        }
        else
          this._token = (IToken) new CommonToken(treeAdaptor.GetType(this._node), treeAdaptor.GetText(this._node));
      }
    }
  }
}
