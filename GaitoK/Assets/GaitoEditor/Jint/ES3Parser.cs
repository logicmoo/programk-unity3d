// Decompiled with JetBrains decompiler
// Type: ES3Parser
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Antlr.Runtime;
using Antlr.Runtime.Tree;
using Jint.Debugger;
using Jint.Expressions;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

[GeneratedCode("ANTLR", "3.3.1.7705")]
[CLSCompliant(false)]
public class ES3Parser : Parser
{
  internal static readonly string[] tokenNames = new string[171]{ "<invalid>", "<EOR>", "<DOWN>", "<UP>", nameof (ABSTRACT), nameof (ADD), nameof (ADDASS), nameof (AND), nameof (ANDASS), nameof (ARGS), nameof (ARRAY), nameof (ASSIGN), nameof (BLOCK), nameof (BOOLEAN), nameof (BREAK), nameof (BSLASH), nameof (BYFIELD), nameof (BYINDEX), nameof (BYTE), nameof (BackslashSequence), nameof (CALL), nameof (CASE), nameof (CATCH), nameof (CEXPR), nameof (CHAR), nameof (CLASS), nameof (COLON), nameof (COMMA), nameof (CONST), nameof (CONTINUE), nameof (CR), nameof (CharacterEscapeSequence), nameof (DEBUGGER), nameof (DEC), nameof (DEFAULT), nameof (DELETE), nameof (DIV), nameof (DIVASS), nameof (DO), nameof (DOT), nameof (DOUBLE), nameof (DQUOTE), nameof (DecimalDigit), nameof (DecimalIntegerLiteral), nameof (DecimalLiteral), nameof (ELSE), nameof (ENUM), nameof (EOL), nameof (EQ), nameof (EXPORT), nameof (EXPR), nameof (EXTENDS), nameof (EscapeSequence), nameof (ExponentPart), nameof (FALSE), nameof (FF), nameof (FINAL), nameof (FINALLY), nameof (FLOAT), nameof (FOR), nameof (FORITER), nameof (FORSTEP), nameof (FUNCTION), nameof (GOTO), nameof (GT), nameof (GTE), nameof (HexDigit), nameof (HexEscapeSequence), nameof (HexIntegerLiteral), nameof (IF), nameof (IMPLEMENTS), nameof (IMPORT), nameof (IN), nameof (INC), nameof (INSTANCEOF), nameof (INT), nameof (INTERFACE), nameof (INV), nameof (ITEM), nameof (Identifier), nameof (IdentifierNameASCIIStart), nameof (IdentifierPart), nameof (IdentifierStartASCII), nameof (LABELLED), nameof (LAND), nameof (LBRACE), nameof (LBRACK), nameof (LF), nameof (LONG), nameof (LOR), nameof (LPAREN), nameof (LS), nameof (LT), nameof (LTE), nameof (LineTerminator), nameof (MOD), nameof (MODASS), nameof (MUL), nameof (MULASS), nameof (MultiLineComment), nameof (NAMEDVALUE), nameof (NATIVE), nameof (NBSP), nameof (NEG), nameof (NEQ), nameof (NEW), nameof (NOT), nameof (NSAME), nameof (NULL), nameof (OBJECT), nameof (OR), nameof (ORASS), nameof (OctalDigit), nameof (OctalEscapeSequence), nameof (OctalIntegerLiteral), nameof (PACKAGE), nameof (PAREXPR), nameof (PDEC), nameof (PINC), nameof (POS), nameof (PRIVATE), nameof (PROTECTED), nameof (PS), nameof (PUBLIC), nameof (QUE), nameof (RBRACE), nameof (RBRACK), nameof (RETURN), nameof (RPAREN), nameof (RegularExpressionChar), nameof (RegularExpressionFirstChar), nameof (RegularExpressionLiteral), nameof (SAME), nameof (SEMIC), nameof (SHL), nameof (SHLASS), nameof (SHORT), nameof (SHR), nameof (SHRASS), nameof (SHU), nameof (SHUASS), nameof (SP), nameof (SQUOTE), nameof (STATIC), nameof (SUB), nameof (SUBASS), nameof (SUPER), nameof (SWITCH), nameof (SYNCHRONIZED), nameof (SingleLineComment), nameof (StringLiteral), nameof (TAB), nameof (THIS), nameof (THROW), nameof (THROWS), nameof (TRANSIENT), nameof (TRUE), nameof (TRY), nameof (TYPEOF), nameof (USP), nameof (UnicodeEscapeSequence), nameof (VAR), nameof (VOID), nameof (VOLATILE), nameof (VT), nameof (WHILE), nameof (WITH), nameof (WhiteSpace), nameof (XOR), nameof (XORASS), nameof (ZeroToThree) };
  private static NumberFormatInfo numberFormatInfo = new NumberFormatInfo();
  private static Encoding Latin1 = Encoding.GetEncoding("iso-8859-1");
  private LinkedList<Statement> _currentBody = (LinkedList<Statement>) null;
  private bool _newExpressionIsUnary = false;
  private string[] script = new string[0];
  public const int EOF = -1;
  public const int ABSTRACT = 4;
  public const int ADD = 5;
  public const int ADDASS = 6;
  public const int AND = 7;
  public const int ANDASS = 8;
  public const int ARGS = 9;
  public const int ARRAY = 10;
  public const int ASSIGN = 11;
  public const int BLOCK = 12;
  public const int BOOLEAN = 13;
  public const int BREAK = 14;
  public const int BSLASH = 15;
  public const int BYFIELD = 16;
  public const int BYINDEX = 17;
  public const int BYTE = 18;
  public const int BackslashSequence = 19;
  public const int CALL = 20;
  public const int CASE = 21;
  public const int CATCH = 22;
  public const int CEXPR = 23;
  public const int CHAR = 24;
  public const int CLASS = 25;
  public const int COLON = 26;
  public const int COMMA = 27;
  public const int CONST = 28;
  public const int CONTINUE = 29;
  public const int CR = 30;
  public const int CharacterEscapeSequence = 31;
  public const int DEBUGGER = 32;
  public const int DEC = 33;
  public const int DEFAULT = 34;
  public const int DELETE = 35;
  public const int DIV = 36;
  public const int DIVASS = 37;
  public const int DO = 38;
  public const int DOT = 39;
  public const int DOUBLE = 40;
  public const int DQUOTE = 41;
  public const int DecimalDigit = 42;
  public const int DecimalIntegerLiteral = 43;
  public const int DecimalLiteral = 44;
  public const int ELSE = 45;
  public const int ENUM = 46;
  public const int EOL = 47;
  public const int EQ = 48;
  public const int EXPORT = 49;
  public const int EXPR = 50;
  public const int EXTENDS = 51;
  public const int EscapeSequence = 52;
  public const int ExponentPart = 53;
  public const int FALSE = 54;
  public const int FF = 55;
  public const int FINAL = 56;
  public const int FINALLY = 57;
  public const int FLOAT = 58;
  public const int FOR = 59;
  public const int FORITER = 60;
  public const int FORSTEP = 61;
  public const int FUNCTION = 62;
  public const int GOTO = 63;
  public const int GT = 64;
  public const int GTE = 65;
  public const int HexDigit = 66;
  public const int HexEscapeSequence = 67;
  public const int HexIntegerLiteral = 68;
  public const int IF = 69;
  public const int IMPLEMENTS = 70;
  public const int IMPORT = 71;
  public const int IN = 72;
  public const int INC = 73;
  public const int INSTANCEOF = 74;
  public const int INT = 75;
  public const int INTERFACE = 76;
  public const int INV = 77;
  public const int ITEM = 78;
  public const int Identifier = 79;
  public const int IdentifierNameASCIIStart = 80;
  public const int IdentifierPart = 81;
  public const int IdentifierStartASCII = 82;
  public const int LABELLED = 83;
  public const int LAND = 84;
  public const int LBRACE = 85;
  public const int LBRACK = 86;
  public const int LF = 87;
  public const int LONG = 88;
  public const int LOR = 89;
  public const int LPAREN = 90;
  public const int LS = 91;
  public const int LT = 92;
  public const int LTE = 93;
  public const int LineTerminator = 94;
  public const int MOD = 95;
  public const int MODASS = 96;
  public const int MUL = 97;
  public const int MULASS = 98;
  public const int MultiLineComment = 99;
  public const int NAMEDVALUE = 100;
  public const int NATIVE = 101;
  public const int NBSP = 102;
  public const int NEG = 103;
  public const int NEQ = 104;
  public const int NEW = 105;
  public const int NOT = 106;
  public const int NSAME = 107;
  public const int NULL = 108;
  public const int OBJECT = 109;
  public const int OR = 110;
  public const int ORASS = 111;
  public const int OctalDigit = 112;
  public const int OctalEscapeSequence = 113;
  public const int OctalIntegerLiteral = 114;
  public const int PACKAGE = 115;
  public const int PAREXPR = 116;
  public const int PDEC = 117;
  public const int PINC = 118;
  public const int POS = 119;
  public const int PRIVATE = 120;
  public const int PROTECTED = 121;
  public const int PS = 122;
  public const int PUBLIC = 123;
  public const int QUE = 124;
  public const int RBRACE = 125;
  public const int RBRACK = 126;
  public const int RETURN = 127;
  public const int RPAREN = 128;
  public const int RegularExpressionChar = 129;
  public const int RegularExpressionFirstChar = 130;
  public const int RegularExpressionLiteral = 131;
  public const int SAME = 132;
  public const int SEMIC = 133;
  public const int SHL = 134;
  public const int SHLASS = 135;
  public const int SHORT = 136;
  public const int SHR = 137;
  public const int SHRASS = 138;
  public const int SHU = 139;
  public const int SHUASS = 140;
  public const int SP = 141;
  public const int SQUOTE = 142;
  public const int STATIC = 143;
  public const int SUB = 144;
  public const int SUBASS = 145;
  public const int SUPER = 146;
  public const int SWITCH = 147;
  public const int SYNCHRONIZED = 148;
  public const int SingleLineComment = 149;
  public const int StringLiteral = 150;
  public const int TAB = 151;
  public const int THIS = 152;
  public const int THROW = 153;
  public const int THROWS = 154;
  public const int TRANSIENT = 155;
  public const int TRUE = 156;
  public const int TRY = 157;
  public const int TYPEOF = 158;
  public const int USP = 159;
  public const int UnicodeEscapeSequence = 160;
  public const int VAR = 161;
  public const int VOID = 162;
  public const int VOLATILE = 163;
  public const int VT = 164;
  public const int WHILE = 165;
  public const int WITH = 166;
  public const int WhiteSpace = 167;
  public const int XOR = 168;
  public const int XORASS = 169;
  public const int ZeroToThree = 170;
  private ITreeAdaptor adaptor;
  private const char BS = '\\';
  private ES3Parser.DFA57 dfa57;
  private ES3Parser.DFA58 dfa58;
  private ES3Parser.DFA88 dfa88;

  public ES3Parser(ITokenStream input)
    : this(input, new RecognizerSharedState())
  {
  }

  public ES3Parser(ITokenStream input, RecognizerSharedState state)
    : base(input, state)
  {
    this.TreeAdaptor = (ITreeAdaptor) null ?? (ITreeAdaptor) new CommonTreeAdaptor();
  }

  public ITreeAdaptor TreeAdaptor
  {
    get
    {
      return this.adaptor;
    }
    set
    {
      this.adaptor = value;
    }
  }

  public override string[] TokenNames
  {
    get
    {
      return ES3Parser.tokenNames;
    }
  }

  public override string GrammarFileName
  {
    get
    {
      return "C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g";
    }
  }

  private bool IsLeftHandSideAssign(Expression lhs, object[] cached)
  {
    if (cached[0] != null)
      return Convert.ToBoolean(cached[0]);
    bool flag;
    if (ES3Parser.IsLeftHandSideExpression(lhs))
    {
      switch (this.input.LA(1))
      {
        case 6:
        case 8:
        case 11:
        case 37:
        case 96:
        case 98:
        case 111:
        case 135:
        case 138:
        case 140:
        case 145:
        case 169:
          flag = true;
          break;
        default:
          flag = false;
          break;
      }
    }
    else
      flag = false;
    cached[0] = (object) flag;
    return flag;
  }

  private static bool IsLeftHandSideExpression(Expression lhs)
  {
    if (lhs == null)
      return true;
    return lhs is Jint.Expressions.Identifier || lhs is PropertyExpression || lhs is MemberExpression;
  }

  private bool IsLeftHandSideIn(Expression lhs, object[] cached)
  {
    if (cached[0] != null)
      return Convert.ToBoolean(cached[0]);
    bool flag = ES3Parser.IsLeftHandSideExpression(lhs) && this.input.LA(1) == 72;
    cached[0] = (object) flag;
    return flag;
  }

  private void PromoteEOL(ParserRuleReturnScope<IToken> rule)
  {
    IToken token1 = this.input.LT(1);
    int type = token1.Type;
    int num;
    switch (type)
    {
      case -1:
      case 47:
      case 125:
      case 133:
        num = 0;
        break;
      default:
        num = type != 99 ? 1 : 0;
        break;
    }
    if (num == 0)
      return;
    for (int i = token1.TokenIndex - 1; i > 0; --i)
    {
      IToken token2 = this.input.Get(i);
      if (token2.Channel != 0)
      {
        if (token2.Type == 47 || token2.Type == 99 && (token2.Text.EndsWith("\r") || token2.Text.EndsWith("\n")))
        {
          token2.Channel = 0;
          this.input.Seek(token2.TokenIndex);
          if (rule != null)
          {
            rule.Start = token2;
            break;
          }
          break;
        }
      }
      else
        break;
    }
  }

  private string extractRegExpPattern(string text)
  {
    return text.Substring(1, text.LastIndexOf('/') - 1);
  }

  private string extractRegExpOption(string text)
  {
    if (text[text.Length - 1] != '/')
      return text.Substring(text.LastIndexOf('/') + 1);
    return string.Empty;
  }

  private string extractString(string text)
  {
    StringBuilder stringBuilder = new StringBuilder(text.Length);
    int startIndex = 1;
    int num;
    for (; (num = text.IndexOf('\\', startIndex)) != -1; startIndex = num)
    {
      stringBuilder.Append(text.Substring(startIndex, num - startIndex));
      char ch1 = text[num + 1];
      switch (ch1)
      {
        case '\n':
          num += 2;
          break;
        case '\r':
          if (text[num + 2] == '\n')
          {
            num += 3;
            break;
          }
          break;
        case '"':
          stringBuilder.Append('"');
          num += 2;
          break;
        case '\'':
          stringBuilder.Append('\'');
          num += 2;
          break;
        case '0':
        case '1':
        case '2':
        case '3':
        case '4':
        case '5':
        case '6':
        case '7':
        case '8':
        case '9':
          string str1 = text.Substring(num + 1, 3);
          char ch2 = ES3Parser.Latin1.GetChars(new byte[1]{ Convert.ToByte(str1, 8) })[0];
          stringBuilder.Append(ch2);
          num += 4;
          break;
        case '\\':
          stringBuilder.Append('\\');
          num += 2;
          break;
        case 'b':
          stringBuilder.Append('\b');
          num += 2;
          break;
        case 'f':
          stringBuilder.Append('\f');
          num += 2;
          break;
        case 'n':
          stringBuilder.Append('\n');
          num += 2;
          break;
        case 'r':
          stringBuilder.Append('\r');
          num += 2;
          break;
        case 't':
          stringBuilder.Append('\t');
          num += 2;
          break;
        case 'u':
          char ch3 = Convert.ToChar(int.Parse(text.Substring(num + 2, 4), NumberStyles.AllowHexSpecifier));
          stringBuilder.Append(ch3);
          num += 6;
          break;
        case 'v':
          stringBuilder.Append('\v');
          num += 2;
          break;
        case 'x':
          string str2 = text.Substring(num + 2, 2);
          char ch4 = ES3Parser.Latin1.GetChars(new byte[1]{ Convert.ToByte(str2, 16) })[0];
          stringBuilder.Append(ch4);
          num += 4;
          break;
        default:
          stringBuilder.Append(ch1);
          num += 2;
          break;
      }
    }
    if (stringBuilder.Length == 0)
      return text.Substring(1, text.Length - 2);
    stringBuilder.Append(text.Substring(startIndex, text.Length - startIndex - 1));
    return stringBuilder.ToString();
  }

  public List<string> Errors { get; private set; }

  public override void DisplayRecognitionError(string[] tokenNames, RecognitionException e)
  {
    base.DisplayRecognitionError(tokenNames, e);
    if (this.Errors == null)
      this.Errors = new List<string>();
    string errorHeader = this.GetErrorHeader(e);
    this.Errors.Add(this.GetErrorMessage(e, tokenNames) + " at " + errorHeader);
  }

  public bool DebugMode { get; set; }

  private SourceCodeDescriptor ExtractSourceCode(
    CommonToken start,
    CommonToken stop)
  {
    if (!this.DebugMode)
      return new SourceCodeDescriptor(start.Line, start.CharPositionInLine, stop.Line, stop.CharPositionInLine, "No source code available.");
    try
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = start.Line - 1; index <= stop.Line - 1; ++index)
      {
        int startIndex = 0;
        int num = this.script[index].Length;
        if (index == start.Line - 1)
          startIndex = start.CharPositionInLine;
        if (index == stop.Line - 1)
          num = stop.CharPositionInLine;
        int length = num - startIndex;
        stringBuilder.Append(this.script[index].Substring(startIndex, length)).Append(Environment.NewLine);
      }
      return new SourceCodeDescriptor(start.Line, start.CharPositionInLine, stop.Line, stop.CharPositionInLine, stringBuilder.ToString());
    }
    catch
    {
      return new SourceCodeDescriptor(start.Line, start.CharPositionInLine, stop.Line, stop.CharPositionInLine, "No source code available.");
    }
  }

  public AssignmentOperator ResolveAssignmentOperator(string op)
  {
    switch (op)
    {
      case "%=":
        return AssignmentOperator.Modulo;
      case "&=":
        return AssignmentOperator.And;
      case "*=":
        return AssignmentOperator.Multiply;
      case "+=":
        return AssignmentOperator.Add;
      case "-=":
        return AssignmentOperator.Substract;
      case "/=":
        return AssignmentOperator.Divide;
      case "<<=":
        return AssignmentOperator.ShiftLeft;
      case "=":
        return AssignmentOperator.Assign;
      case ">>=":
        return AssignmentOperator.ShiftRight;
      case ">>>=":
        return AssignmentOperator.UnsignedRightShift;
      case "^=":
        return AssignmentOperator.XOr;
      case "|=":
        return AssignmentOperator.Or;
      default:
        throw new NotSupportedException("Invalid assignment operator: " + op);
    }
  }

  [GrammarRule("token")]
  private ES3Parser.token_return token()
  {
    ES3Parser.token_return tokenReturn = new ES3Parser.token_return(this);
    tokenReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 5;
        try
        {
          switch (this.input.LA(1))
          {
            case 4:
            case 13:
            case 14:
            case 18:
            case 21:
            case 22:
            case 24:
            case 25:
            case 28:
            case 29:
            case 32:
            case 34:
            case 35:
            case 38:
            case 40:
            case 45:
            case 46:
            case 49:
            case 51:
            case 54:
            case 56:
            case 57:
            case 58:
            case 59:
            case 62:
            case 63:
            case 69:
            case 70:
            case 71:
            case 72:
            case 74:
            case 75:
            case 76:
            case 88:
            case 101:
            case 105:
            case 108:
            case 115:
            case 120:
            case 121:
            case 123:
            case (int) sbyte.MaxValue:
            case 136:
            case 143:
            case 146:
            case 147:
            case 148:
            case 152:
            case 153:
            case 154:
            case 155:
            case 156:
            case 157:
            case 158:
            case 161:
            case 162:
            case 163:
            case 165:
            case 166:
              num = 1;
              break;
            case 5:
            case 6:
            case 7:
            case 8:
            case 11:
            case 26:
            case 27:
            case 33:
            case 36:
            case 37:
            case 39:
            case 48:
            case 64:
            case 65:
            case 73:
            case 77:
            case 84:
            case 85:
            case 86:
            case 89:
            case 90:
            case 92:
            case 93:
            case 95:
            case 96:
            case 97:
            case 98:
            case 104:
            case 106:
            case 107:
            case 110:
            case 111:
            case 124:
            case 125:
            case 126:
            case 128:
            case 132:
            case 133:
            case 134:
            case 135:
            case 137:
            case 138:
            case 139:
            case 140:
            case 144:
            case 145:
            case 168:
            case 169:
              num = 3;
              break;
            case 44:
            case 68:
            case 114:
              num = 4;
              break;
            case 79:
              num = 2;
              break;
            case 150:
              num = 5;
              break;
            default:
              throw new NoViableAltException("", 1, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._reservedWord_in_token1748);
            ES3Parser.reservedWord_return reservedWordReturn = this.reservedWord();
            this.PopFollow();
            this.adaptor.AddChild(obj, reservedWordReturn.Tree);
            break;
          case 2:
            obj = this.adaptor.Nil();
            object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_token1753));
            this.adaptor.AddChild(obj, child1);
            break;
          case 3:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._punctuator_in_token1758);
            ES3Parser.punctuator_return punctuatorReturn = this.punctuator();
            this.PopFollow();
            this.adaptor.AddChild(obj, punctuatorReturn.Tree);
            break;
          case 4:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._numericLiteral_in_token1763);
            ES3Parser.numericLiteral_return numericLiteralReturn = this.numericLiteral();
            this.PopFollow();
            this.adaptor.AddChild(obj, numericLiteralReturn.Tree);
            break;
          case 5:
            obj = this.adaptor.Nil();
            object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 150, ES3Parser.Follow._StringLiteral_in_token1768));
            this.adaptor.AddChild(obj, child2);
            break;
        }
        tokenReturn.Stop = this.input.LT(-1);
        tokenReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(tokenReturn.Tree, tokenReturn.Start, tokenReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        tokenReturn.Tree = this.adaptor.ErrorNode(this.input, tokenReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return tokenReturn;
  }

  [GrammarRule("reservedWord")]
  private ES3Parser.reservedWord_return reservedWord()
  {
    ES3Parser.reservedWord_return reservedWordReturn1 = new ES3Parser.reservedWord_return(this);
    reservedWordReturn1.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 4;
        try
        {
          switch (this.input.LA(1))
          {
            case 4:
            case 13:
            case 18:
            case 24:
            case 25:
            case 28:
            case 32:
            case 40:
            case 46:
            case 49:
            case 51:
            case 56:
            case 58:
            case 63:
            case 70:
            case 71:
            case 75:
            case 76:
            case 88:
            case 101:
            case 115:
            case 120:
            case 121:
            case 123:
            case 136:
            case 143:
            case 146:
            case 148:
            case 154:
            case 155:
            case 163:
              num = 2;
              break;
            case 14:
            case 21:
            case 22:
            case 29:
            case 34:
            case 35:
            case 38:
            case 45:
            case 57:
            case 59:
            case 62:
            case 69:
            case 72:
            case 74:
            case 105:
            case (int) sbyte.MaxValue:
            case 147:
            case 152:
            case 153:
            case 157:
            case 158:
            case 161:
            case 162:
            case 165:
            case 166:
              num = 1;
              break;
            case 54:
            case 156:
              num = 4;
              break;
            case 108:
              num = 3;
              break;
            default:
              throw new NoViableAltException("", 2, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._keyword_in_reservedWord1781);
            ES3Parser.keyword_return keywordReturn = this.keyword();
            this.PopFollow();
            this.adaptor.AddChild(obj, keywordReturn.Tree);
            break;
          case 2:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._futureReservedWord_in_reservedWord1786);
            ES3Parser.futureReservedWord_return reservedWordReturn2 = this.futureReservedWord();
            this.PopFollow();
            this.adaptor.AddChild(obj, reservedWordReturn2.Tree);
            break;
          case 3:
            obj = this.adaptor.Nil();
            object child = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 108, ES3Parser.Follow._NULL_in_reservedWord1791));
            this.adaptor.AddChild(obj, child);
            break;
          case 4:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._booleanLiteral_in_reservedWord1796);
            ES3Parser.booleanLiteral_return booleanLiteralReturn = this.booleanLiteral();
            this.PopFollow();
            this.adaptor.AddChild(obj, booleanLiteralReturn.Tree);
            break;
        }
        reservedWordReturn1.Stop = this.input.LT(-1);
        reservedWordReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(reservedWordReturn1.Tree, reservedWordReturn1.Start, reservedWordReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        reservedWordReturn1.Tree = this.adaptor.ErrorNode(this.input, reservedWordReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return reservedWordReturn1;
  }

  [GrammarRule("keyword")]
  private ES3Parser.keyword_return keyword()
  {
    ES3Parser.keyword_return keywordReturn = new ES3Parser.keyword_return(this);
    keywordReturn.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        IToken payload = this.input.LT(1);
        if (this.input.LA(1) != 14 && (this.input.LA(1) < 21 || this.input.LA(1) > 22) && (this.input.LA(1) != 29 && (this.input.LA(1) < 34 || this.input.LA(1) > 35)) && (this.input.LA(1) != 38 && this.input.LA(1) != 45 && (this.input.LA(1) != 57 && this.input.LA(1) != 59) && (this.input.LA(1) != 62 && this.input.LA(1) != 69 && (this.input.LA(1) != 72 && this.input.LA(1) != 74))) && (this.input.LA(1) != 105 && this.input.LA(1) != (int) sbyte.MaxValue && this.input.LA(1) != 147 && ((this.input.LA(1) < 152 || this.input.LA(1) > 153) && (this.input.LA(1) < 157 || this.input.LA(1) > 158)) && (this.input.LA(1) < 161 || this.input.LA(1) > 162)) && (this.input.LA(1) < 165 || this.input.LA(1) > 166))
          throw new MismatchedSetException((BitSet) null, (IIntStream) this.input);
        this.input.Consume();
        this.adaptor.AddChild(obj, this.adaptor.Create(payload));
        this.state.errorRecovery = false;
        keywordReturn.Stop = this.input.LT(-1);
        keywordReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(keywordReturn.Tree, keywordReturn.Start, keywordReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        keywordReturn.Tree = this.adaptor.ErrorNode(this.input, keywordReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return keywordReturn;
  }

  [GrammarRule("futureReservedWord")]
  private ES3Parser.futureReservedWord_return futureReservedWord()
  {
    ES3Parser.futureReservedWord_return reservedWordReturn = new ES3Parser.futureReservedWord_return(this);
    reservedWordReturn.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        IToken payload = this.input.LT(1);
        if (this.input.LA(1) != 4 && this.input.LA(1) != 13 && this.input.LA(1) != 18 && ((this.input.LA(1) < 24 || this.input.LA(1) > 25) && (this.input.LA(1) != 28 && this.input.LA(1) != 32)) && (this.input.LA(1) != 40 && this.input.LA(1) != 46 && (this.input.LA(1) != 49 && this.input.LA(1) != 51) && (this.input.LA(1) != 56 && this.input.LA(1) != 58 && this.input.LA(1) != 63)) && ((this.input.LA(1) < 70 || this.input.LA(1) > 71) && (this.input.LA(1) < 75 || this.input.LA(1) > 76) && (this.input.LA(1) != 88 && this.input.LA(1) != 101 && this.input.LA(1) != 115) && ((this.input.LA(1) < 120 || this.input.LA(1) > 121) && (this.input.LA(1) != 123 && this.input.LA(1) != 136) && (this.input.LA(1) != 143 && this.input.LA(1) != 146 && this.input.LA(1) != 148))) && (this.input.LA(1) < 154 || this.input.LA(1) > 155) && this.input.LA(1) != 163)
          throw new MismatchedSetException((BitSet) null, (IIntStream) this.input);
        this.input.Consume();
        this.adaptor.AddChild(obj, this.adaptor.Create(payload));
        this.state.errorRecovery = false;
        reservedWordReturn.Stop = this.input.LT(-1);
        reservedWordReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(reservedWordReturn.Tree, reservedWordReturn.Start, reservedWordReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        reservedWordReturn.Tree = this.adaptor.ErrorNode(this.input, reservedWordReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return reservedWordReturn;
  }

  [GrammarRule("punctuator")]
  private ES3Parser.punctuator_return punctuator()
  {
    ES3Parser.punctuator_return punctuatorReturn = new ES3Parser.punctuator_return(this);
    punctuatorReturn.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        IToken payload = this.input.LT(1);
        if ((this.input.LA(1) < 5 || this.input.LA(1) > 8) && this.input.LA(1) != 11 && ((this.input.LA(1) < 26 || this.input.LA(1) > 27) && this.input.LA(1) != 33) && ((this.input.LA(1) < 36 || this.input.LA(1) > 37) && (this.input.LA(1) != 39 && this.input.LA(1) != 48) && ((this.input.LA(1) < 64 || this.input.LA(1) > 65) && (this.input.LA(1) != 73 && this.input.LA(1) != 77))) && ((this.input.LA(1) < 84 || this.input.LA(1) > 86) && (this.input.LA(1) < 89 || this.input.LA(1) > 90) && ((this.input.LA(1) < 92 || this.input.LA(1) > 93) && (this.input.LA(1) < 95 || this.input.LA(1) > 98)) && (this.input.LA(1) != 104 && (this.input.LA(1) < 106 || this.input.LA(1) > 107) && ((this.input.LA(1) < 110 || this.input.LA(1) > 111) && (this.input.LA(1) < 124 || this.input.LA(1) > 126)))) && (this.input.LA(1) != 128 && (this.input.LA(1) < 132 || this.input.LA(1) > 135) && ((this.input.LA(1) < 137 || this.input.LA(1) > 140) && (this.input.LA(1) < 144 || this.input.LA(1) > 145))) && (this.input.LA(1) < 168 || this.input.LA(1) > 169))
          throw new MismatchedSetException((BitSet) null, (IIntStream) this.input);
        this.input.Consume();
        this.adaptor.AddChild(obj, this.adaptor.Create(payload));
        this.state.errorRecovery = false;
        punctuatorReturn.Stop = this.input.LT(-1);
        punctuatorReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(punctuatorReturn.Tree, punctuatorReturn.Start, punctuatorReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        punctuatorReturn.Tree = this.adaptor.ErrorNode(this.input, punctuatorReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return punctuatorReturn;
  }

  [GrammarRule("literal")]
  private ES3Parser.literal_return literal()
  {
    ES3Parser.literal_return literalReturn = new ES3Parser.literal_return(this);
    literalReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 5;
        try
        {
          switch (this.input.LA(1))
          {
            case 44:
            case 68:
            case 114:
              num = 3;
              break;
            case 54:
            case 156:
              num = 2;
              break;
            case 108:
              num = 1;
              break;
            case 131:
              num = 5;
              break;
            case 150:
              num = 4;
              break;
            default:
              throw new NoViableAltException("", 3, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            IToken payload1 = (IToken) this.Match((IIntStream) this.input, 108, ES3Parser.Follow._NULL_in_literal2483);
            object child1 = this.adaptor.Create(payload1);
            this.adaptor.AddChild(obj, child1);
            literalReturn.value = (Expression) new Jint.Expressions.Identifier(payload1.Text);
            break;
          case 2:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._booleanLiteral_in_literal2492);
            ES3Parser.booleanLiteral_return booleanLiteralReturn = this.booleanLiteral();
            this.PopFollow();
            this.adaptor.AddChild(obj, booleanLiteralReturn.Tree);
            literalReturn.value = (Expression) new ValueExpression((object) booleanLiteralReturn.value, TypeCode.Boolean);
            break;
          case 3:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._numericLiteral_in_literal2501);
            ES3Parser.numericLiteral_return numericLiteralReturn = this.numericLiteral();
            this.PopFollow();
            this.adaptor.AddChild(obj, numericLiteralReturn.Tree);
            literalReturn.value = (Expression) new ValueExpression((object) numericLiteralReturn.value, TypeCode.Double);
            break;
          case 4:
            obj = this.adaptor.Nil();
            IToken payload2 = (IToken) this.Match((IIntStream) this.input, 150, ES3Parser.Follow._StringLiteral_in_literal2510);
            object child2 = this.adaptor.Create(payload2);
            this.adaptor.AddChild(obj, child2);
            literalReturn.value = (Expression) new ValueExpression((object) this.extractString(payload2.Text), TypeCode.String);
            break;
          case 5:
            obj = this.adaptor.Nil();
            IToken payload3 = (IToken) this.Match((IIntStream) this.input, 131, ES3Parser.Follow._RegularExpressionLiteral_in_literal2520);
            object child3 = this.adaptor.Create(payload3);
            this.adaptor.AddChild(obj, child3);
            literalReturn.value = (Expression) new RegexpExpression(this.extractRegExpPattern(payload3.Text), this.extractRegExpOption(payload3.Text));
            break;
        }
        literalReturn.Stop = this.input.LT(-1);
        literalReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(literalReturn.Tree, literalReturn.Start, literalReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        literalReturn.Tree = this.adaptor.ErrorNode(this.input, literalReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return literalReturn;
  }

  [GrammarRule("booleanLiteral")]
  private ES3Parser.booleanLiteral_return booleanLiteral()
  {
    ES3Parser.booleanLiteral_return booleanLiteralReturn = new ES3Parser.booleanLiteral_return(this);
    booleanLiteralReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 2;
        try
        {
          switch (this.input.LA(1))
          {
            case 54:
              num = 2;
              break;
            case 156:
              num = 1;
              break;
            default:
              throw new NoViableAltException("", 4, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 156, ES3Parser.Follow._TRUE_in_booleanLiteral2537));
            this.adaptor.AddChild(obj, child1);
            booleanLiteralReturn.value = true;
            break;
          case 2:
            obj = this.adaptor.Nil();
            object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 54, ES3Parser.Follow._FALSE_in_booleanLiteral2544));
            this.adaptor.AddChild(obj, child2);
            booleanLiteralReturn.value = false;
            break;
        }
        booleanLiteralReturn.Stop = this.input.LT(-1);
        booleanLiteralReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(booleanLiteralReturn.Tree, booleanLiteralReturn.Start, booleanLiteralReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        booleanLiteralReturn.Tree = this.adaptor.ErrorNode(this.input, booleanLiteralReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return booleanLiteralReturn;
  }

  [GrammarRule("numericLiteral")]
  private ES3Parser.numericLiteral_return numericLiteral()
  {
    ES3Parser.numericLiteral_return numericLiteralReturn = new ES3Parser.numericLiteral_return(this);
    numericLiteralReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 3;
        try
        {
          switch (this.input.LA(1))
          {
            case 44:
              num = 1;
              break;
            case 68:
              num = 3;
              break;
            case 114:
              num = 2;
              break;
            default:
              throw new NoViableAltException("", 5, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            IToken payload1 = (IToken) this.Match((IIntStream) this.input, 44, ES3Parser.Follow._DecimalLiteral_in_numericLiteral2755);
            object child1 = this.adaptor.Create(payload1);
            this.adaptor.AddChild(obj, child1);
            numericLiteralReturn.value = double.Parse(payload1.Text, NumberStyles.Float, (IFormatProvider) ES3Parser.numberFormatInfo);
            break;
          case 2:
            obj = this.adaptor.Nil();
            IToken payload2 = (IToken) this.Match((IIntStream) this.input, 114, ES3Parser.Follow._OctalIntegerLiteral_in_numericLiteral2764);
            object child2 = this.adaptor.Create(payload2);
            this.adaptor.AddChild(obj, child2);
            numericLiteralReturn.value = (double) Convert.ToInt64(payload2.Text, 8);
            break;
          case 3:
            obj = this.adaptor.Nil();
            IToken payload3 = (IToken) this.Match((IIntStream) this.input, 68, ES3Parser.Follow._HexIntegerLiteral_in_numericLiteral2773);
            object child3 = this.adaptor.Create(payload3);
            this.adaptor.AddChild(obj, child3);
            numericLiteralReturn.value = (double) Convert.ToInt64(payload3.Text, 16);
            break;
        }
        numericLiteralReturn.Stop = this.input.LT(-1);
        numericLiteralReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(numericLiteralReturn.Tree, numericLiteralReturn.Start, numericLiteralReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        numericLiteralReturn.Tree = this.adaptor.ErrorNode(this.input, numericLiteralReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return numericLiteralReturn;
  }

  [GrammarRule("primaryExpression")]
  private ES3Parser.primaryExpression_return primaryExpression()
  {
    ES3Parser.primaryExpression_return expressionReturn1 = new ES3Parser.primaryExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 6;
        try
        {
          switch (this.input.LA(1))
          {
            case 44:
            case 54:
            case 68:
            case 108:
            case 114:
            case 131:
            case 150:
            case 156:
              num = 3;
              break;
            case 79:
              num = 2;
              break;
            case 85:
              num = 5;
              break;
            case 86:
              num = 4;
              break;
            case 90:
              num = 6;
              break;
            case 152:
              num = 1;
              break;
            default:
              throw new NoViableAltException("", 6, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            IToken payload1 = (IToken) this.Match((IIntStream) this.input, 152, ES3Parser.Follow._THIS_in_primaryExpression3175);
            object child1 = this.adaptor.Create(payload1);
            this.adaptor.AddChild(obj, child1);
            expressionReturn1.value = (Expression) new Jint.Expressions.Identifier(payload1.Text);
            break;
          case 2:
            obj = this.adaptor.Nil();
            IToken payload2 = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_primaryExpression3184);
            object child2 = this.adaptor.Create(payload2);
            this.adaptor.AddChild(obj, child2);
            expressionReturn1.value = (Expression) new Jint.Expressions.Identifier(payload2.Text);
            break;
          case 3:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._literal_in_primaryExpression3193);
            ES3Parser.literal_return literalReturn = this.literal();
            this.PopFollow();
            this.adaptor.AddChild(obj, literalReturn.Tree);
            expressionReturn1.value = literalReturn.value;
            break;
          case 4:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._arrayLiteral_in_primaryExpression3202);
            ES3Parser.arrayLiteral_return arrayLiteralReturn = this.arrayLiteral();
            this.PopFollow();
            this.adaptor.AddChild(obj, arrayLiteralReturn.Tree);
            expressionReturn1.value = (Expression) arrayLiteralReturn.value;
            break;
          case 5:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._objectLiteral_in_primaryExpression3211);
            ES3Parser.objectLiteral_return objectLiteralReturn = this.objectLiteral();
            this.PopFollow();
            this.adaptor.AddChild(obj, objectLiteralReturn.Tree);
            expressionReturn1.value = (Expression) objectLiteralReturn.value;
            break;
          case 6:
            obj = this.adaptor.Nil();
            object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_primaryExpression3220));
            this.adaptor.AddChild(obj, child3);
            this.PushFollow(ES3Parser.Follow._expression_in_primaryExpression3224);
            ES3Parser.expression_return expressionReturn2 = this.expression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn2.Tree);
            object child4 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 128, ES3Parser.Follow._RPAREN_in_primaryExpression3227));
            this.adaptor.AddChild(obj, child4);
            expressionReturn1.value = expressionReturn2.value;
            this._newExpressionIsUnary = expressionReturn2.value is NewExpression;
            break;
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("arrayLiteral")]
  private ES3Parser.arrayLiteral_return arrayLiteral()
  {
    ES3Parser.arrayLiteral_return arrayLiteralReturn = new ES3Parser.arrayLiteral_return(this);
    arrayLiteralReturn.Start = this.input.LT(1);
    arrayLiteralReturn.value = new ArrayDeclaration();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 86, ES3Parser.Follow._LBRACK_in_arrayLiteral3253));
        this.adaptor.AddChild(obj, child1);
        int num1 = 2;
        try
        {
          try
          {
            int num2 = this.input.LA(1);
            if (num2 == 5 || num2 == 27 || (num2 == 33 || num2 == 35) || (num2 == 44 || num2 == 54 || (num2 == 62 || num2 == 68)) || (num2 == 73 || num2 == 77 || num2 == 79 || (num2 >= 85 && num2 <= 86 || num2 == 90)) || (num2 >= 105 && num2 <= 106 || (num2 == 108 || num2 == 114) || (num2 == 131 || num2 == 144 || (num2 == 150 || num2 == 152)) || (num2 == 156 || num2 == 158)) || num2 == 162)
              num1 = 1;
            else if (num2 == 126)
            {
              this.input.LA(2);
              if (this.input.LA(1) == 27 || this.input.LA(1) == 126)
                num1 = 1;
            }
          }
          finally
          {
          }
          if (num1 == 1)
          {
            this.PushFollow(ES3Parser.Follow._arrayItem_in_arrayLiteral3259);
            ES3Parser.arrayItem_return arrayItemReturn1 = this.arrayItem();
            this.PopFollow();
            this.adaptor.AddChild(obj, arrayItemReturn1.Tree);
            if (arrayItemReturn1.value != null)
              arrayLiteralReturn.value.Parameters.Add(arrayItemReturn1.value);
            try
            {
              while (true)
              {
                int num2 = 2;
                try
                {
                  if (this.input.LA(1) == 27)
                    num2 = 1;
                }
                finally
                {
                }
                if (num2 == 1)
                {
                  object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_arrayLiteral3265));
                  this.adaptor.AddChild(obj, child2);
                  this.PushFollow(ES3Parser.Follow._arrayItem_in_arrayLiteral3269);
                  ES3Parser.arrayItem_return arrayItemReturn2 = this.arrayItem();
                  this.PopFollow();
                  this.adaptor.AddChild(obj, arrayItemReturn2.Tree);
                  if (arrayItemReturn2.value != null)
                    arrayLiteralReturn.value.Parameters.Add(arrayItemReturn2.value);
                }
                else
                  break;
              }
            }
            finally
            {
            }
          }
        }
        finally
        {
        }
        object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 126, ES3Parser.Follow._RBRACK_in_arrayLiteral3279));
        this.adaptor.AddChild(obj, child3);
        arrayLiteralReturn.Stop = this.input.LT(-1);
        arrayLiteralReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(arrayLiteralReturn.Tree, arrayLiteralReturn.Start, arrayLiteralReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        arrayLiteralReturn.Tree = this.adaptor.ErrorNode(this.input, arrayLiteralReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return arrayLiteralReturn;
  }

  [GrammarRule("arrayItem")]
  private ES3Parser.arrayItem_return arrayItem()
  {
    ES3Parser.arrayItem_return arrayItemReturn = new ES3Parser.arrayItem_return(this);
    arrayItemReturn.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        int num = 3;
        try
        {
          try
          {
            switch (this.input.LA(1))
            {
              case 5:
              case 33:
              case 35:
              case 44:
              case 54:
              case 62:
              case 68:
              case 73:
              case 77:
              case 79:
              case 85:
              case 86:
              case 90:
              case 105:
              case 106:
              case 108:
              case 114:
              case 131:
              case 144:
              case 150:
              case 152:
              case 156:
              case 158:
              case 162:
                num = 1;
                break;
              case 27:
                this.input.LA(2);
                if (this.input.LA(1) == 27)
                {
                  num = 2;
                  break;
                }
                if (this.input.LA(1) != 126)
                  throw new NoViableAltException("", 9, 2, (IIntStream) this.input);
                num = 3;
                break;
              case 126:
                this.input.LA(2);
                if (this.input.LA(1) == 27)
                {
                  num = 2;
                  break;
                }
                if (this.input.LA(1) != 126)
                  throw new NoViableAltException("", 9, 3, (IIntStream) this.input);
                num = 3;
                break;
              default:
                throw new NoViableAltException("", 9, 0, (IIntStream) this.input);
            }
          }
          finally
          {
          }
          switch (num)
          {
            case 1:
              this.PushFollow(ES3Parser.Follow._assignmentExpression_in_arrayItem3300);
              ES3Parser.assignmentExpression_return expressionReturn = this.assignmentExpression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn.Tree);
              arrayItemReturn.value = (Statement) expressionReturn.value;
              break;
            case 2:
              if (this.input.LA(1) != 27)
                throw new FailedPredicateException((IIntStream) this.input, nameof (arrayItem), " input.LA(1) == COMMA ");
              arrayItemReturn.value = (Statement) new Jint.Expressions.Identifier("undefined");
              break;
            case 3:
              if (this.input.LA(1) != 126)
                throw new FailedPredicateException((IIntStream) this.input, nameof (arrayItem), " input.LA(1) == RBRACK ");
              arrayItemReturn.value = (Statement) null;
              break;
          }
        }
        finally
        {
        }
        arrayItemReturn.Stop = this.input.LT(-1);
        arrayItemReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(arrayItemReturn.Tree, arrayItemReturn.Start, arrayItemReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        arrayItemReturn.Tree = this.adaptor.ErrorNode(this.input, arrayItemReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return arrayItemReturn;
  }

  [GrammarRule("objectLiteral")]
  private ES3Parser.objectLiteral_return objectLiteral()
  {
    ES3Parser.objectLiteral_return objectLiteralReturn = new ES3Parser.objectLiteral_return(this);
    objectLiteralReturn.Start = this.input.LT(1);
    objectLiteralReturn.value = new JsonExpression();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 85, ES3Parser.Follow._LBRACE_in_objectLiteral3341));
        this.adaptor.AddChild(obj, child1);
        int num1 = 2;
        try
        {
          try
          {
            int num2 = this.input.LA(1);
            int num3;
            switch (num2)
            {
              case 44:
              case 68:
              case 79:
              case 114:
                num3 = 1;
                break;
              default:
                num3 = num2 == 150 ? 1 : 0;
                break;
            }
            if (num3 != 0)
              num1 = 1;
          }
          finally
          {
          }
          if (num1 == 1)
          {
            this.PushFollow(ES3Parser.Follow._propertyAssignment_in_objectLiteral3347);
            ES3Parser.propertyAssignment_return assignmentReturn1 = this.propertyAssignment();
            this.PopFollow();
            this.adaptor.AddChild(obj, assignmentReturn1.Tree);
            objectLiteralReturn.value.Push(assignmentReturn1.value);
            try
            {
              while (true)
              {
                int num2 = 2;
                try
                {
                  if (this.input.LA(1) == 27)
                    num2 = 1;
                }
                finally
                {
                }
                if (num2 == 1)
                {
                  object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_objectLiteral3354));
                  this.adaptor.AddChild(obj, child2);
                  this.PushFollow(ES3Parser.Follow._propertyAssignment_in_objectLiteral3358);
                  ES3Parser.propertyAssignment_return assignmentReturn2 = this.propertyAssignment();
                  this.PopFollow();
                  this.adaptor.AddChild(obj, assignmentReturn2.Tree);
                  objectLiteralReturn.value.Push(assignmentReturn2.value);
                }
                else
                  break;
              }
            }
            finally
            {
            }
          }
        }
        finally
        {
        }
        object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 125, ES3Parser.Follow._RBRACE_in_objectLiteral3368));
        this.adaptor.AddChild(obj, child3);
        objectLiteralReturn.Stop = this.input.LT(-1);
        objectLiteralReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(objectLiteralReturn.Tree, objectLiteralReturn.Start, objectLiteralReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        objectLiteralReturn.Tree = this.adaptor.ErrorNode(this.input, objectLiteralReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return objectLiteralReturn;
  }

  [GrammarRule("propertyAssignment")]
  private ES3Parser.propertyAssignment_return propertyAssignment()
  {
    ES3Parser.propertyAssignment_return assignmentReturn = new ES3Parser.propertyAssignment_return(this);
    assignmentReturn.Start = this.input.LT(1);
    object obj = (object) null;
    assignmentReturn.value = new PropertyDeclarationExpression();
    FunctionExpression functionExpression = new FunctionExpression();
    try
    {
      try
      {
        int num1 = 2;
        try
        {
          int num2 = this.input.LA(1);
          int num3;
          switch (num2)
          {
            case 44:
            case 68:
            case 114:
              num3 = 1;
              break;
            case 79:
              int num4 = this.input.LA(2);
              int num5;
              switch (num4)
              {
                case 44:
                case 68:
                case 79:
                case 114:
                  num5 = 1;
                  break;
                default:
                  num5 = num4 == 150 ? 1 : 0;
                  break;
              }
              if (num5 != 0)
              {
                num1 = 1;
                goto label_18;
              }
              else
              {
                if (num4 != 26)
                  throw new NoViableAltException("", 13, 1, (IIntStream) this.input);
                num1 = 2;
                goto label_18;
              }
            default:
              num3 = num2 == 150 ? 1 : 0;
              break;
          }
          if (num3 == 0)
            throw new NoViableAltException("", 13, 0, (IIntStream) this.input);
          num1 = 2;
        }
        finally
        {
        }
label_18:
        switch (num1)
        {
          case 1:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._accessor_in_propertyAssignment3391);
            ES3Parser.accessor_return accessorReturn = this.accessor();
            this.PopFollow();
            this.adaptor.AddChild(obj, accessorReturn.Tree);
            assignmentReturn.value.Mode = accessorReturn.value;
            assignmentReturn.value.Expression = (Expression) functionExpression;
            this.PushFollow(ES3Parser.Follow._propertyName_in_propertyAssignment3399);
            ES3Parser.propertyName_return propertyNameReturn1 = this.propertyName();
            this.PopFollow();
            this.adaptor.AddChild(obj, propertyNameReturn1.Tree);
            assignmentReturn.value.Name = functionExpression.Name = propertyNameReturn1.value;
            int num6 = 2;
            try
            {
              try
              {
                if (this.input.LA(1) == 90)
                  num6 = 1;
              }
              finally
              {
              }
              if (num6 == 1)
              {
                this.PushFollow(ES3Parser.Follow._formalParameterList_in_propertyAssignment3406);
                ES3Parser.formalParameterList_return parameterListReturn = this.formalParameterList();
                this.PopFollow();
                this.adaptor.AddChild(obj, parameterListReturn.Tree);
                functionExpression.Parameters.AddRange((IEnumerable<string>) parameterListReturn.value);
              }
            }
            finally
            {
            }
            this.PushFollow(ES3Parser.Follow._functionBody_in_propertyAssignment3414);
            ES3Parser.functionBody_return functionBodyReturn = this.functionBody();
            this.PopFollow();
            this.adaptor.AddChild(obj, functionBodyReturn.Tree);
            functionExpression.Statement = (Statement) functionBodyReturn.value;
            break;
          case 2:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._propertyName_in_propertyAssignment3424);
            ES3Parser.propertyName_return propertyNameReturn2 = this.propertyName();
            this.PopFollow();
            this.adaptor.AddChild(obj, propertyNameReturn2.Tree);
            assignmentReturn.value.Name = propertyNameReturn2.value;
            object child = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 26, ES3Parser.Follow._COLON_in_propertyAssignment3428));
            this.adaptor.AddChild(obj, child);
            this.PushFollow(ES3Parser.Follow._assignmentExpression_in_propertyAssignment3432);
            ES3Parser.assignmentExpression_return expressionReturn = this.assignmentExpression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn.Tree);
            assignmentReturn.value.Expression = expressionReturn.value;
            break;
        }
        assignmentReturn.Stop = this.input.LT(-1);
        assignmentReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(assignmentReturn.Tree, assignmentReturn.Start, assignmentReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        assignmentReturn.Tree = this.adaptor.ErrorNode(this.input, assignmentReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return assignmentReturn;
  }

  [GrammarRule("accessor")]
  private ES3Parser.accessor_return accessor()
  {
    ES3Parser.accessor_return accessorReturn = new ES3Parser.accessor_return(this);
    accessorReturn.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        IToken payload = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_accessor3452);
        object child = this.adaptor.Create(payload);
        this.adaptor.AddChild(obj, child);
        if (!(payload.Text == "get") && !(payload.Text == "set"))
          throw new FailedPredicateException((IIntStream) this.input, nameof (accessor), " ex1.Text==\"get\" || ex1.Text==\"set\" ");
        if (payload.Text == "get")
          accessorReturn.value = PropertyExpressionType.Get;
        if (payload.Text == "set")
          accessorReturn.value = PropertyExpressionType.Set;
        accessorReturn.Stop = this.input.LT(-1);
        accessorReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(accessorReturn.Tree, accessorReturn.Start, accessorReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        accessorReturn.Tree = this.adaptor.ErrorNode(this.input, accessorReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return accessorReturn;
  }

  [GrammarRule("propertyName")]
  private ES3Parser.propertyName_return propertyName()
  {
    ES3Parser.propertyName_return propertyNameReturn = new ES3Parser.propertyName_return(this);
    propertyNameReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 3;
        try
        {
          switch (this.input.LA(1))
          {
            case 44:
            case 68:
            case 114:
              num = 3;
              break;
            case 79:
              num = 1;
              break;
            case 150:
              num = 2;
              break;
            default:
              throw new NoViableAltException("", 14, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            IToken payload1 = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_propertyName3474);
            object child1 = this.adaptor.Create(payload1);
            this.adaptor.AddChild(obj, child1);
            propertyNameReturn.value = payload1.Text;
            break;
          case 2:
            obj = this.adaptor.Nil();
            IToken payload2 = (IToken) this.Match((IIntStream) this.input, 150, ES3Parser.Follow._StringLiteral_in_propertyName3483);
            object child2 = this.adaptor.Create(payload2);
            this.adaptor.AddChild(obj, child2);
            propertyNameReturn.value = this.extractString(payload2.Text);
            break;
          case 3:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._numericLiteral_in_propertyName3492);
            ES3Parser.numericLiteral_return numericLiteralReturn = this.numericLiteral();
            this.PopFollow();
            this.adaptor.AddChild(obj, numericLiteralReturn.Tree);
            propertyNameReturn.value = numericLiteralReturn.value.ToString();
            break;
        }
        propertyNameReturn.Stop = this.input.LT(-1);
        propertyNameReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(propertyNameReturn.Tree, propertyNameReturn.Start, propertyNameReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        propertyNameReturn.Tree = this.adaptor.ErrorNode(this.input, propertyNameReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return propertyNameReturn;
  }

  [GrammarRule("memberExpression")]
  private ES3Parser.memberExpression_return memberExpression()
  {
    ES3Parser.memberExpression_return expressionReturn1 = new ES3Parser.memberExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 3;
        try
        {
          switch (this.input.LA(1))
          {
            case 44:
            case 54:
            case 68:
            case 79:
            case 85:
            case 86:
            case 90:
            case 108:
            case 114:
            case 131:
            case 150:
            case 152:
            case 156:
              num = 1;
              break;
            case 62:
              num = 2;
              break;
            case 105:
              num = 3;
              break;
            default:
              throw new NoViableAltException("", 15, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._primaryExpression_in_memberExpression3518);
            ES3Parser.primaryExpression_return expressionReturn2 = this.primaryExpression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn2.Tree);
            expressionReturn1.value = expressionReturn2.value;
            break;
          case 2:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._functionExpression_in_memberExpression3527);
            ES3Parser.functionExpression_return expressionReturn3 = this.functionExpression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn3.Tree);
            expressionReturn1.value = (Expression) expressionReturn3.value;
            break;
          case 3:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._newExpression_in_memberExpression3536);
            ES3Parser.newExpression_return expressionReturn4 = this.newExpression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn4.Tree);
            expressionReturn1.value = (Expression) expressionReturn4.value;
            break;
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("newExpression")]
  private ES3Parser.newExpression_return newExpression()
  {
    ES3Parser.newExpression_return expressionReturn1 = new ES3Parser.newExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      try
      {
        object oldRoot = this.adaptor.Nil();
        object obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 105, ES3Parser.Follow._NEW_in_newExpression3553)), oldRoot);
        this.PushFollow(ES3Parser.Follow._memberExpression_in_newExpression3558);
        ES3Parser.memberExpression_return expressionReturn2 = this.memberExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = new NewExpression(expressionReturn2.value);
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("arguments")]
  private ES3Parser.arguments_return arguments()
  {
    ES3Parser.arguments_return argumentsReturn = new ES3Parser.arguments_return(this);
    argumentsReturn.Start = this.input.LT(1);
    argumentsReturn.value = new List<Expression>();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_arguments3581));
        this.adaptor.AddChild(obj, child1);
        int num1 = 2;
        try
        {
          try
          {
            int num2 = this.input.LA(1);
            if (num2 == 5 || num2 == 33 || (num2 == 35 || num2 == 44) || (num2 == 54 || num2 == 62 || (num2 == 68 || num2 == 73)) || (num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || (num2 == 90 || num2 >= 105 && num2 <= 106)) || (num2 == 108 || num2 == 114 || (num2 == 131 || num2 == 144) || (num2 == 150 || num2 == 152 || (num2 == 156 || num2 == 158))) || num2 == 162)
              num1 = 1;
          }
          finally
          {
          }
          if (num1 == 1)
          {
            this.PushFollow(ES3Parser.Follow._assignmentExpression_in_arguments3587);
            ES3Parser.assignmentExpression_return expressionReturn1 = this.assignmentExpression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn1.Tree);
            argumentsReturn.value.Add(expressionReturn1.value);
            try
            {
              while (true)
              {
                int num2 = 2;
                try
                {
                  if (this.input.LA(1) == 27)
                    num2 = 1;
                }
                finally
                {
                }
                if (num2 == 1)
                {
                  object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_arguments3593));
                  this.adaptor.AddChild(obj, child2);
                  this.PushFollow(ES3Parser.Follow._assignmentExpression_in_arguments3597);
                  ES3Parser.assignmentExpression_return expressionReturn2 = this.assignmentExpression();
                  this.PopFollow();
                  this.adaptor.AddChild(obj, expressionReturn2.Tree);
                  argumentsReturn.value.Add(expressionReturn2.value);
                }
                else
                  break;
              }
            }
            finally
            {
            }
          }
        }
        finally
        {
        }
        object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 128, ES3Parser.Follow._RPAREN_in_arguments3606));
        this.adaptor.AddChild(obj, child3);
        argumentsReturn.Stop = this.input.LT(-1);
        argumentsReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(argumentsReturn.Tree, argumentsReturn.Start, argumentsReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        argumentsReturn.Tree = this.adaptor.ErrorNode(this.input, argumentsReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return argumentsReturn;
  }

  [GrammarRule("generics")]
  private ES3Parser.generics_return generics()
  {
    ES3Parser.generics_return genericsReturn = new ES3Parser.generics_return(this);
    genericsReturn.Start = this.input.LT(1);
    genericsReturn.value = new List<Expression>();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 85, ES3Parser.Follow._LBRACE_in_generics3628));
        this.adaptor.AddChild(obj, child1);
        int num1 = 2;
        try
        {
          try
          {
            int num2 = this.input.LA(1);
            if (num2 == 5 || num2 == 33 || (num2 == 35 || num2 == 44) || (num2 == 54 || num2 == 62 || (num2 == 68 || num2 == 73)) || (num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || (num2 == 90 || num2 >= 105 && num2 <= 106)) || (num2 == 108 || num2 == 114 || (num2 == 131 || num2 == 144) || (num2 == 150 || num2 == 152 || (num2 == 156 || num2 == 158))) || num2 == 162)
              num1 = 1;
          }
          finally
          {
          }
          if (num1 == 1)
          {
            this.PushFollow(ES3Parser.Follow._assignmentExpression_in_generics3634);
            ES3Parser.assignmentExpression_return expressionReturn1 = this.assignmentExpression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn1.Tree);
            genericsReturn.value.Add(expressionReturn1.value);
            try
            {
              while (true)
              {
                int num2 = 2;
                try
                {
                  if (this.input.LA(1) == 27)
                    num2 = 1;
                }
                finally
                {
                }
                if (num2 == 1)
                {
                  object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_generics3640));
                  this.adaptor.AddChild(obj, child2);
                  this.PushFollow(ES3Parser.Follow._assignmentExpression_in_generics3644);
                  ES3Parser.assignmentExpression_return expressionReturn2 = this.assignmentExpression();
                  this.PopFollow();
                  this.adaptor.AddChild(obj, expressionReturn2.Tree);
                  genericsReturn.value.Add(expressionReturn2.value);
                }
                else
                  break;
              }
            }
            finally
            {
            }
          }
        }
        finally
        {
        }
        object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 125, ES3Parser.Follow._RBRACE_in_generics3653));
        this.adaptor.AddChild(obj, child3);
        genericsReturn.Stop = this.input.LT(-1);
        genericsReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(genericsReturn.Tree, genericsReturn.Start, genericsReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        genericsReturn.Tree = this.adaptor.ErrorNode(this.input, genericsReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return genericsReturn;
  }

  [GrammarRule("leftHandSideExpression")]
  private ES3Parser.leftHandSideExpression_return leftHandSideExpression()
  {
    ES3Parser.leftHandSideExpression_return expressionReturn1 = new ES3Parser.leftHandSideExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    List<Expression> expressionList = new List<Expression>();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._memberExpression_in_leftHandSideExpression3689);
        ES3Parser.memberExpression_return expressionReturn2 = this.memberExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        try
        {
          while (true)
          {
            int num1 = 4;
            try
            {
              switch (this.input.LA(1))
              {
                case 39:
                  num1 = 3;
                  break;
                case 85:
                case 90:
                  num1 = 1;
                  break;
                case 86:
                  num1 = 2;
                  break;
              }
            }
            finally
            {
            }
            switch (num1)
            {
              case 1:
                int num2 = 2;
                try
                {
                  try
                  {
                    if (this.input.LA(1) == 85)
                      num2 = 1;
                  }
                  finally
                  {
                  }
                  if (num2 == 1)
                  {
                    this.PushFollow(ES3Parser.Follow._generics_in_leftHandSideExpression3705);
                    ES3Parser.generics_return genericsReturn = this.generics();
                    this.PopFollow();
                    this.adaptor.AddChild(obj, genericsReturn.Tree);
                    expressionList = genericsReturn.value;
                  }
                }
                finally
                {
                }
                this.PushFollow(ES3Parser.Follow._arguments_in_leftHandSideExpression3714);
                ES3Parser.arguments_return argumentsReturn = this.arguments();
                this.PopFollow();
                this.adaptor.AddChild(obj, argumentsReturn.Tree);
                if (expressionReturn1.value is NewExpression && !this._newExpressionIsUnary)
                {
                  ((NewExpression) expressionReturn1.value).Generics = expressionList;
                  ((NewExpression) expressionReturn1.value).Arguments = argumentsReturn.value;
                  expressionReturn1.value = (Expression) new MemberExpression(expressionReturn1.value, (Expression) null);
                  break;
                }
                expressionReturn1.value = (Expression) new MemberExpression((Expression) new MethodCall(argumentsReturn.value)
                {
                  Generics = expressionList
                }, expressionReturn1.value);
                break;
              case 2:
                object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 86, ES3Parser.Follow._LBRACK_in_leftHandSideExpression3725));
                this.adaptor.AddChild(obj, child1);
                this.PushFollow(ES3Parser.Follow._expression_in_leftHandSideExpression3729);
                ES3Parser.expression_return expressionReturn3 = this.expression();
                this.PopFollow();
                this.adaptor.AddChild(obj, expressionReturn3.Tree);
                object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 126, ES3Parser.Follow._RBRACK_in_leftHandSideExpression3731));
                this.adaptor.AddChild(obj, child2);
                expressionReturn1.value = (Expression) new MemberExpression((Expression) new Indexer(expressionReturn3.value), expressionReturn1.value);
                break;
              case 3:
                object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 39, ES3Parser.Follow._DOT_in_leftHandSideExpression3744));
                this.adaptor.AddChild(obj, child3);
                IToken payload = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_leftHandSideExpression3748);
                object child4 = this.adaptor.Create(payload);
                this.adaptor.AddChild(obj, child4);
                if (expressionReturn1.value is NewExpression && !this._newExpressionIsUnary)
                {
                  ((NewExpression) expressionReturn1.value).Expression = (Expression) new MemberExpression((Expression) new PropertyExpression(payload.Text), ((NewExpression) expressionReturn1.value).Expression);
                  break;
                }
                expressionReturn1.value = (Expression) new MemberExpression((Expression) new PropertyExpression(payload.Text), expressionReturn1.value);
                break;
              default:
                goto label_28;
            }
          }
        }
        finally
        {
        }
label_28:
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
        expressionReturn1.value.Source = this.ExtractSourceCode((CommonToken) expressionReturn1.Start, (CommonToken) expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("postfixExpression")]
  private ES3Parser.postfixExpression_return postfixExpression()
  {
    ES3Parser.postfixExpression_return expressionReturn1 = new ES3Parser.postfixExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._leftHandSideExpression_in_postfixExpression3782);
        ES3Parser.leftHandSideExpression_return expressionReturn2 = this.leftHandSideExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        if (this.input.LA(1) == 73 || this.input.LA(1) == 33)
          this.PromoteEOL((ParserRuleReturnScope<IToken>) null);
        int num1 = 2;
        try
        {
          try
          {
            int num2 = this.input.LA(1);
            if (num2 == 33 || num2 == 73)
              num1 = 1;
          }
          finally
          {
          }
          if (num1 == 1)
          {
            this.PushFollow(ES3Parser.Follow._postfixOperator_in_postfixExpression3790);
            ES3Parser.postfixOperator_return postfixOperatorReturn = this.postfixOperator();
            this.PopFollow();
            obj = this.adaptor.BecomeRoot(postfixOperatorReturn.Tree, obj);
            expressionReturn1.value = (Expression) new UnaryExpression(postfixOperatorReturn.value, expressionReturn1.value);
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("postfixOperator")]
  private ES3Parser.postfixOperator_return postfixOperator()
  {
    ES3Parser.postfixOperator_return postfixOperatorReturn = new ES3Parser.postfixOperator_return(this);
    postfixOperatorReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 2;
        try
        {
          switch (this.input.LA(1))
          {
            case 33:
              num = 2;
              break;
            case 73:
              num = 1;
              break;
            default:
              throw new NoViableAltException("", 23, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            IToken payload1 = (IToken) this.Match((IIntStream) this.input, 73, ES3Parser.Follow._INC_in_postfixOperator3813);
            object child1 = this.adaptor.Create(payload1);
            this.adaptor.AddChild(obj, child1);
            payload1.Type = 118;
            postfixOperatorReturn.value = UnaryExpressionType.PostfixPlusPlus;
            break;
          case 2:
            obj = this.adaptor.Nil();
            IToken payload2 = (IToken) this.Match((IIntStream) this.input, 33, ES3Parser.Follow._DEC_in_postfixOperator3822);
            object child2 = this.adaptor.Create(payload2);
            this.adaptor.AddChild(obj, child2);
            payload2.Type = 117;
            postfixOperatorReturn.value = UnaryExpressionType.PostfixMinusMinus;
            break;
        }
        postfixOperatorReturn.Stop = this.input.LT(-1);
        postfixOperatorReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(postfixOperatorReturn.Tree, postfixOperatorReturn.Start, postfixOperatorReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        postfixOperatorReturn.Tree = this.adaptor.ErrorNode(this.input, postfixOperatorReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return postfixOperatorReturn;
  }

  [GrammarRule("unaryExpression")]
  private ES3Parser.unaryExpression_return unaryExpression()
  {
    ES3Parser.unaryExpression_return expressionReturn1 = new ES3Parser.unaryExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num1 = 2;
        try
        {
          int num2 = this.input.LA(1);
          if (num2 == 44 || num2 == 54 || (num2 == 62 || num2 == 68) || (num2 == 79 || num2 >= 85 && num2 <= 86) || (num2 == 90 || num2 == 105 || (num2 == 108 || num2 == 114) || (num2 == 131 || num2 == 150 || num2 == 152)) || num2 == 156)
          {
            num1 = 1;
          }
          else
          {
            if (num2 != 5 && num2 != 33 && (num2 != 35 && num2 != 73) && (num2 != 77 && num2 != 106 && (num2 != 144 && num2 != 158)) && num2 != 162)
              throw new NoViableAltException("", 24, 0, (IIntStream) this.input);
            num1 = 2;
          }
        }
        finally
        {
        }
        switch (num1)
        {
          case 1:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._postfixExpression_in_unaryExpression3845);
            ES3Parser.postfixExpression_return expressionReturn2 = this.postfixExpression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn2.Tree);
            expressionReturn1.value = expressionReturn2.value;
            break;
          case 2:
            object oldRoot = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._unaryOperator_in_unaryExpression3854);
            ES3Parser.unaryOperator_return unaryOperatorReturn = this.unaryOperator();
            this.PopFollow();
            obj = this.adaptor.BecomeRoot(unaryOperatorReturn.Tree, oldRoot);
            this.PushFollow(ES3Parser.Follow._unaryExpression_in_unaryExpression3859);
            ES3Parser.unaryExpression_return expressionReturn3 = this.unaryExpression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn3.Tree);
            expressionReturn1.value = (Expression) new UnaryExpression(unaryOperatorReturn.value, expressionReturn3.value);
            break;
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("unaryOperator")]
  private ES3Parser.unaryOperator_return unaryOperator()
  {
    ES3Parser.unaryOperator_return unaryOperatorReturn = new ES3Parser.unaryOperator_return(this);
    unaryOperatorReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 9;
        try
        {
          switch (this.input.LA(1))
          {
            case 5:
              num = 6;
              break;
            case 33:
              num = 5;
              break;
            case 35:
              num = 1;
              break;
            case 73:
              num = 4;
              break;
            case 77:
              num = 8;
              break;
            case 106:
              num = 9;
              break;
            case 144:
              num = 7;
              break;
            case 158:
              num = 3;
              break;
            case 162:
              num = 2;
              break;
            default:
              throw new NoViableAltException("", 25, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 35, ES3Parser.Follow._DELETE_in_unaryOperator3877));
            this.adaptor.AddChild(obj, child1);
            unaryOperatorReturn.value = UnaryExpressionType.Delete;
            break;
          case 2:
            obj = this.adaptor.Nil();
            object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 162, ES3Parser.Follow._VOID_in_unaryOperator3884));
            this.adaptor.AddChild(obj, child2);
            unaryOperatorReturn.value = UnaryExpressionType.Void;
            break;
          case 3:
            obj = this.adaptor.Nil();
            object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 158, ES3Parser.Follow._TYPEOF_in_unaryOperator3891));
            this.adaptor.AddChild(obj, child3);
            unaryOperatorReturn.value = UnaryExpressionType.TypeOf;
            break;
          case 4:
            obj = this.adaptor.Nil();
            object child4 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 73, ES3Parser.Follow._INC_in_unaryOperator3898));
            this.adaptor.AddChild(obj, child4);
            unaryOperatorReturn.value = UnaryExpressionType.PrefixPlusPlus;
            break;
          case 5:
            obj = this.adaptor.Nil();
            object child5 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 33, ES3Parser.Follow._DEC_in_unaryOperator3905));
            this.adaptor.AddChild(obj, child5);
            unaryOperatorReturn.value = UnaryExpressionType.PrefixMinusMinus;
            break;
          case 6:
            obj = this.adaptor.Nil();
            IToken payload1 = (IToken) this.Match((IIntStream) this.input, 5, ES3Parser.Follow._ADD_in_unaryOperator3914);
            object child6 = this.adaptor.Create(payload1);
            this.adaptor.AddChild(obj, child6);
            payload1.Type = 119;
            unaryOperatorReturn.value = UnaryExpressionType.Positive;
            break;
          case 7:
            obj = this.adaptor.Nil();
            IToken payload2 = (IToken) this.Match((IIntStream) this.input, 144, ES3Parser.Follow._SUB_in_unaryOperator3923);
            object child7 = this.adaptor.Create(payload2);
            this.adaptor.AddChild(obj, child7);
            payload2.Type = 103;
            unaryOperatorReturn.value = UnaryExpressionType.Negate;
            break;
          case 8:
            obj = this.adaptor.Nil();
            object child8 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 77, ES3Parser.Follow._INV_in_unaryOperator3930));
            this.adaptor.AddChild(obj, child8);
            unaryOperatorReturn.value = UnaryExpressionType.Inv;
            break;
          case 9:
            obj = this.adaptor.Nil();
            object child9 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 106, ES3Parser.Follow._NOT_in_unaryOperator3937));
            this.adaptor.AddChild(obj, child9);
            unaryOperatorReturn.value = UnaryExpressionType.Not;
            break;
        }
        unaryOperatorReturn.Stop = this.input.LT(-1);
        unaryOperatorReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(unaryOperatorReturn.Tree, unaryOperatorReturn.Start, unaryOperatorReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        unaryOperatorReturn.Tree = this.adaptor.ErrorNode(this.input, unaryOperatorReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return unaryOperatorReturn;
  }

  [GrammarRule("multiplicativeExpression")]
  private ES3Parser.multiplicativeExpression_return multiplicativeExpression()
  {
    ES3Parser.multiplicativeExpression_return expressionReturn1 = new ES3Parser.multiplicativeExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._unaryExpression_in_multiplicativeExpression3965);
        ES3Parser.unaryExpression_return expressionReturn2 = this.unaryExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        try
        {
          while (true)
          {
            int num1 = 2;
            try
            {
              int num2 = this.input.LA(1);
              int num3;
              switch (num2)
              {
                case 36:
                case 95:
                  num3 = 1;
                  break;
                default:
                  num3 = num2 == 97 ? 1 : 0;
                  break;
              }
              if (num3 != 0)
                num1 = 1;
            }
            finally
            {
            }
            if (num1 == 1)
            {
              int num2 = 3;
              try
              {
                try
                {
                  switch (this.input.LA(1))
                  {
                    case 36:
                      num2 = 2;
                      break;
                    case 95:
                      num2 = 3;
                      break;
                    case 97:
                      num2 = 1;
                      break;
                    default:
                      throw new NoViableAltException("", 26, 0, (IIntStream) this.input);
                  }
                }
                finally
                {
                }
                switch (num2)
                {
                  case 1:
                    object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 97, ES3Parser.Follow._MUL_in_multiplicativeExpression3976));
                    this.adaptor.AddChild(obj, child1);
                    type = BinaryExpressionType.Times;
                    break;
                  case 2:
                    object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 36, ES3Parser.Follow._DIV_in_multiplicativeExpression3985));
                    this.adaptor.AddChild(obj, child2);
                    type = BinaryExpressionType.Div;
                    break;
                  case 3:
                    object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 95, ES3Parser.Follow._MOD_in_multiplicativeExpression3993));
                    this.adaptor.AddChild(obj, child3);
                    type = BinaryExpressionType.Modulo;
                    break;
                }
              }
              finally
              {
              }
              this.PushFollow(ES3Parser.Follow._unaryExpression_in_multiplicativeExpression4004);
              ES3Parser.unaryExpression_return expressionReturn3 = this.unaryExpression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn3.Tree);
              expressionReturn1.value = (Expression) new BinaryExpression(type, expressionReturn1.value, expressionReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("additiveExpression")]
  private ES3Parser.additiveExpression_return additiveExpression()
  {
    ES3Parser.additiveExpression_return expressionReturn1 = new ES3Parser.additiveExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._multiplicativeExpression_in_additiveExpression4034);
        ES3Parser.multiplicativeExpression_return expressionReturn2 = this.multiplicativeExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        try
        {
          while (true)
          {
            int num1 = 2;
            try
            {
              int num2 = this.input.LA(1);
              if (num2 == 5 || num2 == 144)
                num1 = 1;
            }
            finally
            {
            }
            if (num1 == 1)
            {
              int num2 = 2;
              try
              {
                try
                {
                  switch (this.input.LA(1))
                  {
                    case 5:
                      num2 = 1;
                      break;
                    case 144:
                      num2 = 2;
                      break;
                    default:
                      throw new NoViableAltException("", 28, 0, (IIntStream) this.input);
                  }
                }
                finally
                {
                }
                switch (num2)
                {
                  case 1:
                    object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 5, ES3Parser.Follow._ADD_in_additiveExpression4045));
                    this.adaptor.AddChild(obj, child1);
                    type = BinaryExpressionType.Plus;
                    break;
                  case 2:
                    object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 144, ES3Parser.Follow._SUB_in_additiveExpression4053));
                    this.adaptor.AddChild(obj, child2);
                    type = BinaryExpressionType.Minus;
                    break;
                }
              }
              finally
              {
              }
              this.PushFollow(ES3Parser.Follow._multiplicativeExpression_in_additiveExpression4064);
              ES3Parser.multiplicativeExpression_return expressionReturn3 = this.multiplicativeExpression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn3.Tree);
              expressionReturn1.value = (Expression) new BinaryExpression(type, expressionReturn1.value, expressionReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("shiftExpression")]
  private ES3Parser.shiftExpression_return shiftExpression()
  {
    ES3Parser.shiftExpression_return expressionReturn1 = new ES3Parser.shiftExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._additiveExpression_in_shiftExpression4095);
        ES3Parser.additiveExpression_return expressionReturn2 = this.additiveExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        try
        {
          while (true)
          {
            int num1 = 2;
            try
            {
              int num2 = this.input.LA(1);
              int num3;
              switch (num2)
              {
                case 134:
                case 137:
                  num3 = 1;
                  break;
                default:
                  num3 = num2 == 139 ? 1 : 0;
                  break;
              }
              if (num3 != 0)
                num1 = 1;
            }
            finally
            {
            }
            if (num1 == 1)
            {
              int num2 = 3;
              try
              {
                try
                {
                  switch (this.input.LA(1))
                  {
                    case 134:
                      num2 = 1;
                      break;
                    case 137:
                      num2 = 2;
                      break;
                    case 139:
                      num2 = 3;
                      break;
                    default:
                      throw new NoViableAltException("", 30, 0, (IIntStream) this.input);
                  }
                }
                finally
                {
                }
                switch (num2)
                {
                  case 1:
                    object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 134, ES3Parser.Follow._SHL_in_shiftExpression4106));
                    this.adaptor.AddChild(obj, child1);
                    type = BinaryExpressionType.LeftShift;
                    break;
                  case 2:
                    object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 137, ES3Parser.Follow._SHR_in_shiftExpression4114));
                    this.adaptor.AddChild(obj, child2);
                    type = BinaryExpressionType.RightShift;
                    break;
                  case 3:
                    object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 139, ES3Parser.Follow._SHU_in_shiftExpression4122));
                    this.adaptor.AddChild(obj, child3);
                    type = BinaryExpressionType.UnsignedRightShift;
                    break;
                }
              }
              finally
              {
              }
              this.PushFollow(ES3Parser.Follow._additiveExpression_in_shiftExpression4133);
              ES3Parser.additiveExpression_return expressionReturn3 = this.additiveExpression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn3.Tree);
              expressionReturn1.value = (Expression) new BinaryExpression(type, expressionReturn1.value, expressionReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("relationalExpression")]
  private ES3Parser.relationalExpression_return relationalExpression()
  {
    ES3Parser.relationalExpression_return expressionReturn1 = new ES3Parser.relationalExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._shiftExpression_in_relationalExpression4164);
        ES3Parser.shiftExpression_return expressionReturn2 = this.shiftExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        try
        {
          while (true)
          {
            int num1 = 2;
            try
            {
              int num2 = this.input.LA(1);
              if (num2 >= 64 && num2 <= 65 || (num2 == 72 || num2 == 74) || num2 >= 92 && num2 <= 93)
                num1 = 1;
            }
            finally
            {
            }
            if (num1 == 1)
            {
              int num2 = 6;
              try
              {
                try
                {
                  switch (this.input.LA(1))
                  {
                    case 64:
                      num2 = 2;
                      break;
                    case 65:
                      num2 = 4;
                      break;
                    case 72:
                      num2 = 6;
                      break;
                    case 74:
                      num2 = 5;
                      break;
                    case 92:
                      num2 = 1;
                      break;
                    case 93:
                      num2 = 3;
                      break;
                    default:
                      throw new NoViableAltException("", 32, 0, (IIntStream) this.input);
                  }
                }
                finally
                {
                }
                switch (num2)
                {
                  case 1:
                    object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 92, ES3Parser.Follow._LT_in_relationalExpression4175));
                    this.adaptor.AddChild(obj, child1);
                    type = BinaryExpressionType.Lesser;
                    break;
                  case 2:
                    object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 64, ES3Parser.Follow._GT_in_relationalExpression4183));
                    this.adaptor.AddChild(obj, child2);
                    type = BinaryExpressionType.Greater;
                    break;
                  case 3:
                    object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 93, ES3Parser.Follow._LTE_in_relationalExpression4191));
                    this.adaptor.AddChild(obj, child3);
                    type = BinaryExpressionType.LesserOrEqual;
                    break;
                  case 4:
                    object child4 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 65, ES3Parser.Follow._GTE_in_relationalExpression4199));
                    this.adaptor.AddChild(obj, child4);
                    type = BinaryExpressionType.GreaterOrEqual;
                    break;
                  case 5:
                    object child5 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 74, ES3Parser.Follow._INSTANCEOF_in_relationalExpression4207));
                    this.adaptor.AddChild(obj, child5);
                    type = BinaryExpressionType.InstanceOf;
                    break;
                  case 6:
                    object child6 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 72, ES3Parser.Follow._IN_in_relationalExpression4215));
                    this.adaptor.AddChild(obj, child6);
                    type = BinaryExpressionType.In;
                    break;
                }
              }
              finally
              {
              }
              this.PushFollow(ES3Parser.Follow._shiftExpression_in_relationalExpression4226);
              ES3Parser.shiftExpression_return expressionReturn3 = this.shiftExpression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn3.Tree);
              expressionReturn1.value = (Expression) new BinaryExpression(type, expressionReturn1.value, expressionReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("relationalExpressionNoIn")]
  private ES3Parser.relationalExpressionNoIn_return relationalExpressionNoIn()
  {
    ES3Parser.relationalExpressionNoIn_return expressionNoInReturn = new ES3Parser.relationalExpressionNoIn_return(this);
    expressionNoInReturn.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._shiftExpression_in_relationalExpressionNoIn4252);
        ES3Parser.shiftExpression_return expressionReturn1 = this.shiftExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn1.Tree);
        expressionNoInReturn.value = expressionReturn1.value;
        try
        {
          while (true)
          {
            int num1 = 2;
            try
            {
              int num2 = this.input.LA(1);
              if (num2 >= 64 && num2 <= 65 || num2 == 74 || num2 >= 92 && num2 <= 93)
                num1 = 1;
            }
            finally
            {
            }
            if (num1 == 1)
            {
              int num2 = 5;
              try
              {
                try
                {
                  switch (this.input.LA(1))
                  {
                    case 64:
                      num2 = 2;
                      break;
                    case 65:
                      num2 = 4;
                      break;
                    case 74:
                      num2 = 5;
                      break;
                    case 92:
                      num2 = 1;
                      break;
                    case 93:
                      num2 = 3;
                      break;
                    default:
                      throw new NoViableAltException("", 34, 0, (IIntStream) this.input);
                  }
                }
                finally
                {
                }
                switch (num2)
                {
                  case 1:
                    object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 92, ES3Parser.Follow._LT_in_relationalExpressionNoIn4263));
                    this.adaptor.AddChild(obj, child1);
                    type = BinaryExpressionType.Lesser;
                    break;
                  case 2:
                    object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 64, ES3Parser.Follow._GT_in_relationalExpressionNoIn4271));
                    this.adaptor.AddChild(obj, child2);
                    type = BinaryExpressionType.Greater;
                    break;
                  case 3:
                    object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 93, ES3Parser.Follow._LTE_in_relationalExpressionNoIn4279));
                    this.adaptor.AddChild(obj, child3);
                    type = BinaryExpressionType.LesserOrEqual;
                    break;
                  case 4:
                    object child4 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 65, ES3Parser.Follow._GTE_in_relationalExpressionNoIn4287));
                    this.adaptor.AddChild(obj, child4);
                    type = BinaryExpressionType.GreaterOrEqual;
                    break;
                  case 5:
                    object child5 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 74, ES3Parser.Follow._INSTANCEOF_in_relationalExpressionNoIn4295));
                    this.adaptor.AddChild(obj, child5);
                    type = BinaryExpressionType.InstanceOf;
                    break;
                }
              }
              finally
              {
              }
              this.PushFollow(ES3Parser.Follow._shiftExpression_in_relationalExpressionNoIn4307);
              ES3Parser.shiftExpression_return expressionReturn2 = this.shiftExpression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn2.Tree);
              expressionNoInReturn.value = (Expression) new BinaryExpression(type, expressionNoInReturn.value, expressionReturn2.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionNoInReturn.Stop = this.input.LT(-1);
        expressionNoInReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionNoInReturn.Tree, expressionNoInReturn.Start, expressionNoInReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionNoInReturn.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionNoInReturn;
  }

  [GrammarRule("equalityExpression")]
  private ES3Parser.equalityExpression_return equalityExpression()
  {
    ES3Parser.equalityExpression_return expressionReturn1 = new ES3Parser.equalityExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._relationalExpression_in_equalityExpression4338);
        ES3Parser.relationalExpression_return expressionReturn2 = this.relationalExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        try
        {
          while (true)
          {
            int num1 = 2;
            try
            {
              int num2 = this.input.LA(1);
              int num3;
              switch (num2)
              {
                case 48:
                case 104:
                case 107:
                  num3 = 1;
                  break;
                default:
                  num3 = num2 == 132 ? 1 : 0;
                  break;
              }
              if (num3 != 0)
                num1 = 1;
            }
            finally
            {
            }
            if (num1 == 1)
            {
              int num2 = 4;
              try
              {
                try
                {
                  switch (this.input.LA(1))
                  {
                    case 48:
                      num2 = 1;
                      break;
                    case 104:
                      num2 = 2;
                      break;
                    case 107:
                      num2 = 4;
                      break;
                    case 132:
                      num2 = 3;
                      break;
                    default:
                      throw new NoViableAltException("", 36, 0, (IIntStream) this.input);
                  }
                }
                finally
                {
                }
                switch (num2)
                {
                  case 1:
                    object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 48, ES3Parser.Follow._EQ_in_equalityExpression4349));
                    this.adaptor.AddChild(obj, child1);
                    type = BinaryExpressionType.Equal;
                    break;
                  case 2:
                    object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 104, ES3Parser.Follow._NEQ_in_equalityExpression4357));
                    this.adaptor.AddChild(obj, child2);
                    type = BinaryExpressionType.NotEqual;
                    break;
                  case 3:
                    object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 132, ES3Parser.Follow._SAME_in_equalityExpression4365));
                    this.adaptor.AddChild(obj, child3);
                    type = BinaryExpressionType.Same;
                    break;
                  case 4:
                    object child4 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 107, ES3Parser.Follow._NSAME_in_equalityExpression4373));
                    this.adaptor.AddChild(obj, child4);
                    type = BinaryExpressionType.NotSame;
                    break;
                }
              }
              finally
              {
              }
              this.PushFollow(ES3Parser.Follow._relationalExpression_in_equalityExpression4384);
              ES3Parser.relationalExpression_return expressionReturn3 = this.relationalExpression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn3.Tree);
              expressionReturn1.value = (Expression) new BinaryExpression(type, expressionReturn1.value, expressionReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("equalityExpressionNoIn")]
  private ES3Parser.equalityExpressionNoIn_return equalityExpressionNoIn()
  {
    ES3Parser.equalityExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.equalityExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    BinaryExpressionType type = BinaryExpressionType.Unknown;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._relationalExpressionNoIn_in_equalityExpressionNoIn4410);
        ES3Parser.relationalExpressionNoIn_return expressionNoInReturn2 = this.relationalExpressionNoIn();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
        expressionNoInReturn1.value = expressionNoInReturn2.value;
        try
        {
          while (true)
          {
            int num1 = 2;
            try
            {
              int num2 = this.input.LA(1);
              int num3;
              switch (num2)
              {
                case 48:
                case 104:
                case 107:
                  num3 = 1;
                  break;
                default:
                  num3 = num2 == 132 ? 1 : 0;
                  break;
              }
              if (num3 != 0)
                num1 = 1;
            }
            finally
            {
            }
            if (num1 == 1)
            {
              int num2 = 4;
              try
              {
                try
                {
                  switch (this.input.LA(1))
                  {
                    case 48:
                      num2 = 1;
                      break;
                    case 104:
                      num2 = 2;
                      break;
                    case 107:
                      num2 = 4;
                      break;
                    case 132:
                      num2 = 3;
                      break;
                    default:
                      throw new NoViableAltException("", 38, 0, (IIntStream) this.input);
                  }
                }
                finally
                {
                }
                switch (num2)
                {
                  case 1:
                    object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 48, ES3Parser.Follow._EQ_in_equalityExpressionNoIn4421));
                    this.adaptor.AddChild(obj, child1);
                    type = BinaryExpressionType.Equal;
                    break;
                  case 2:
                    object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 104, ES3Parser.Follow._NEQ_in_equalityExpressionNoIn4429));
                    this.adaptor.AddChild(obj, child2);
                    type = BinaryExpressionType.NotEqual;
                    break;
                  case 3:
                    object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 132, ES3Parser.Follow._SAME_in_equalityExpressionNoIn4437));
                    this.adaptor.AddChild(obj, child3);
                    type = BinaryExpressionType.Same;
                    break;
                  case 4:
                    object child4 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 107, ES3Parser.Follow._NSAME_in_equalityExpressionNoIn4445));
                    this.adaptor.AddChild(obj, child4);
                    type = BinaryExpressionType.NotSame;
                    break;
                }
              }
              finally
              {
              }
              this.PushFollow(ES3Parser.Follow._relationalExpressionNoIn_in_equalityExpressionNoIn4456);
              ES3Parser.relationalExpressionNoIn_return expressionNoInReturn3 = this.relationalExpressionNoIn();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
              expressionNoInReturn1.value = (Expression) new BinaryExpression(type, expressionNoInReturn1.value, expressionNoInReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionNoInReturn1.Stop = this.input.LT(-1);
        expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("bitwiseANDExpression")]
  private ES3Parser.bitwiseANDExpression_return bitwiseANDExpression()
  {
    ES3Parser.bitwiseANDExpression_return expressionReturn1 = new ES3Parser.bitwiseANDExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._equalityExpression_in_bitwiseANDExpression4483);
        ES3Parser.equalityExpression_return expressionReturn2 = this.equalityExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        try
        {
          while (true)
          {
            int num = 2;
            try
            {
              if (this.input.LA(1) == 7)
                num = 1;
            }
            finally
            {
            }
            if (num == 1)
            {
              obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 7, ES3Parser.Follow._AND_in_bitwiseANDExpression4489)), obj);
              this.PushFollow(ES3Parser.Follow._equalityExpression_in_bitwiseANDExpression4494);
              ES3Parser.equalityExpression_return expressionReturn3 = this.equalityExpression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn3.Tree);
              expressionReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.BitwiseAnd, expressionReturn1.value, expressionReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("bitwiseANDExpressionNoIn")]
  private ES3Parser.bitwiseANDExpressionNoIn_return bitwiseANDExpressionNoIn()
  {
    ES3Parser.bitwiseANDExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.bitwiseANDExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4515);
        ES3Parser.equalityExpressionNoIn_return expressionNoInReturn2 = this.equalityExpressionNoIn();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
        expressionNoInReturn1.value = expressionNoInReturn2.value;
        try
        {
          while (true)
          {
            int num = 2;
            try
            {
              if (this.input.LA(1) == 7)
                num = 1;
            }
            finally
            {
            }
            if (num == 1)
            {
              obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 7, ES3Parser.Follow._AND_in_bitwiseANDExpressionNoIn4521)), obj);
              this.PushFollow(ES3Parser.Follow._equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4526);
              ES3Parser.equalityExpressionNoIn_return expressionNoInReturn3 = this.equalityExpressionNoIn();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
              expressionNoInReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.BitwiseAnd, expressionNoInReturn1.value, expressionNoInReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionNoInReturn1.Stop = this.input.LT(-1);
        expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("bitwiseXORExpression")]
  private ES3Parser.bitwiseXORExpression_return bitwiseXORExpression()
  {
    ES3Parser.bitwiseXORExpression_return expressionReturn1 = new ES3Parser.bitwiseXORExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._bitwiseANDExpression_in_bitwiseXORExpression4549);
        ES3Parser.bitwiseANDExpression_return expressionReturn2 = this.bitwiseANDExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        try
        {
          while (true)
          {
            int num = 2;
            try
            {
              if (this.input.LA(1) == 168)
                num = 1;
            }
            finally
            {
            }
            if (num == 1)
            {
              obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 168, ES3Parser.Follow._XOR_in_bitwiseXORExpression4555)), obj);
              this.PushFollow(ES3Parser.Follow._bitwiseANDExpression_in_bitwiseXORExpression4560);
              ES3Parser.bitwiseANDExpression_return expressionReturn3 = this.bitwiseANDExpression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn3.Tree);
              expressionReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.BitwiseXOr, expressionReturn1.value, expressionReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("bitwiseXORExpressionNoIn")]
  private ES3Parser.bitwiseXORExpressionNoIn_return bitwiseXORExpressionNoIn()
  {
    ES3Parser.bitwiseXORExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.bitwiseXORExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4583);
        ES3Parser.bitwiseANDExpressionNoIn_return expressionNoInReturn2 = this.bitwiseANDExpressionNoIn();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
        expressionNoInReturn1.value = expressionNoInReturn2.value;
        try
        {
          while (true)
          {
            int num = 2;
            try
            {
              if (this.input.LA(1) == 168)
                num = 1;
            }
            finally
            {
            }
            if (num == 1)
            {
              obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 168, ES3Parser.Follow._XOR_in_bitwiseXORExpressionNoIn4589)), obj);
              this.PushFollow(ES3Parser.Follow._bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4594);
              ES3Parser.bitwiseANDExpressionNoIn_return expressionNoInReturn3 = this.bitwiseANDExpressionNoIn();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
              expressionNoInReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.BitwiseXOr, expressionNoInReturn1.value, expressionNoInReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionNoInReturn1.Stop = this.input.LT(-1);
        expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("bitwiseORExpression")]
  private ES3Parser.bitwiseORExpression_return bitwiseORExpression()
  {
    ES3Parser.bitwiseORExpression_return expressionReturn1 = new ES3Parser.bitwiseORExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._bitwiseXORExpression_in_bitwiseORExpression4616);
        ES3Parser.bitwiseXORExpression_return expressionReturn2 = this.bitwiseXORExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        try
        {
          while (true)
          {
            int num = 2;
            try
            {
              if (this.input.LA(1) == 110)
                num = 1;
            }
            finally
            {
            }
            if (num == 1)
            {
              obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 110, ES3Parser.Follow._OR_in_bitwiseORExpression4622)), obj);
              this.PushFollow(ES3Parser.Follow._bitwiseXORExpression_in_bitwiseORExpression4627);
              ES3Parser.bitwiseXORExpression_return expressionReturn3 = this.bitwiseXORExpression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn3.Tree);
              expressionReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.BitwiseOr, expressionReturn1.value, expressionReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("bitwiseORExpressionNoIn")]
  private ES3Parser.bitwiseORExpressionNoIn_return bitwiseORExpressionNoIn()
  {
    ES3Parser.bitwiseORExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.bitwiseORExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4649);
        ES3Parser.bitwiseXORExpressionNoIn_return expressionNoInReturn2 = this.bitwiseXORExpressionNoIn();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
        expressionNoInReturn1.value = expressionNoInReturn2.value;
        try
        {
          while (true)
          {
            int num = 2;
            try
            {
              if (this.input.LA(1) == 110)
                num = 1;
            }
            finally
            {
            }
            if (num == 1)
            {
              obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 110, ES3Parser.Follow._OR_in_bitwiseORExpressionNoIn4655)), obj);
              this.PushFollow(ES3Parser.Follow._bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4660);
              ES3Parser.bitwiseXORExpressionNoIn_return expressionNoInReturn3 = this.bitwiseXORExpressionNoIn();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
              expressionNoInReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.BitwiseOr, expressionNoInReturn1.value, expressionNoInReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionNoInReturn1.Stop = this.input.LT(-1);
        expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("logicalANDExpression")]
  private ES3Parser.logicalANDExpression_return logicalANDExpression()
  {
    ES3Parser.logicalANDExpression_return expressionReturn1 = new ES3Parser.logicalANDExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._bitwiseORExpression_in_logicalANDExpression4686);
        ES3Parser.bitwiseORExpression_return expressionReturn2 = this.bitwiseORExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        try
        {
          while (true)
          {
            int num = 2;
            try
            {
              if (this.input.LA(1) == 84)
                num = 1;
            }
            finally
            {
            }
            if (num == 1)
            {
              obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 84, ES3Parser.Follow._LAND_in_logicalANDExpression4692)), obj);
              this.PushFollow(ES3Parser.Follow._bitwiseORExpression_in_logicalANDExpression4697);
              ES3Parser.bitwiseORExpression_return expressionReturn3 = this.bitwiseORExpression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn3.Tree);
              expressionReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.And, expressionReturn1.value, expressionReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("logicalANDExpressionNoIn")]
  private ES3Parser.logicalANDExpressionNoIn_return logicalANDExpressionNoIn()
  {
    ES3Parser.logicalANDExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.logicalANDExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4718);
        ES3Parser.bitwiseORExpressionNoIn_return expressionNoInReturn2 = this.bitwiseORExpressionNoIn();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
        expressionNoInReturn1.value = expressionNoInReturn2.value;
        try
        {
          while (true)
          {
            int num = 2;
            try
            {
              if (this.input.LA(1) == 84)
                num = 1;
            }
            finally
            {
            }
            if (num == 1)
            {
              obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 84, ES3Parser.Follow._LAND_in_logicalANDExpressionNoIn4724)), obj);
              this.PushFollow(ES3Parser.Follow._bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4729);
              ES3Parser.bitwiseORExpressionNoIn_return expressionNoInReturn3 = this.bitwiseORExpressionNoIn();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
              expressionNoInReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.And, expressionNoInReturn1.value, expressionNoInReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionNoInReturn1.Stop = this.input.LT(-1);
        expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("logicalORExpression")]
  private ES3Parser.logicalORExpression_return logicalORExpression()
  {
    ES3Parser.logicalORExpression_return expressionReturn1 = new ES3Parser.logicalORExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._logicalANDExpression_in_logicalORExpression4751);
        ES3Parser.logicalANDExpression_return expressionReturn2 = this.logicalANDExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        try
        {
          while (true)
          {
            int num = 2;
            try
            {
              if (this.input.LA(1) == 89)
                num = 1;
            }
            finally
            {
            }
            if (num == 1)
            {
              obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 89, ES3Parser.Follow._LOR_in_logicalORExpression4757)), obj);
              this.PushFollow(ES3Parser.Follow._logicalANDExpression_in_logicalORExpression4762);
              ES3Parser.logicalANDExpression_return expressionReturn3 = this.logicalANDExpression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn3.Tree);
              expressionReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.Or, expressionReturn1.value, expressionReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("logicalORExpressionNoIn")]
  private ES3Parser.logicalORExpressionNoIn_return logicalORExpressionNoIn()
  {
    ES3Parser.logicalORExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.logicalORExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._logicalANDExpressionNoIn_in_logicalORExpressionNoIn4784);
        ES3Parser.logicalANDExpressionNoIn_return expressionNoInReturn2 = this.logicalANDExpressionNoIn();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
        expressionNoInReturn1.value = expressionNoInReturn2.value;
        try
        {
          while (true)
          {
            int num = 2;
            try
            {
              if (this.input.LA(1) == 89)
                num = 1;
            }
            finally
            {
            }
            if (num == 1)
            {
              obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 89, ES3Parser.Follow._LOR_in_logicalORExpressionNoIn4790)), obj);
              this.PushFollow(ES3Parser.Follow._logicalANDExpressionNoIn_in_logicalORExpressionNoIn4795);
              ES3Parser.logicalANDExpressionNoIn_return expressionNoInReturn3 = this.logicalANDExpressionNoIn();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
              expressionNoInReturn1.value = (Expression) new BinaryExpression(BinaryExpressionType.Or, expressionNoInReturn1.value, expressionNoInReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionNoInReturn1.Stop = this.input.LT(-1);
        expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("conditionalExpression")]
  private ES3Parser.conditionalExpression_return conditionalExpression()
  {
    ES3Parser.conditionalExpression_return expressionReturn1 = new ES3Parser.conditionalExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    IToken token = (IToken) null;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._logicalORExpression_in_conditionalExpression4822);
        ES3Parser.logicalORExpression_return expressionReturn2 = this.logicalORExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        int num = 2;
        try
        {
          try
          {
            if (this.input.LA(1) == 124)
              num = 1;
          }
          finally
          {
          }
          if (num == 1)
          {
            obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 124, ES3Parser.Follow._QUE_in_conditionalExpression4828)), obj);
            this.PushFollow(ES3Parser.Follow._assignmentExpression_in_conditionalExpression4833);
            ES3Parser.assignmentExpression_return expressionReturn3 = this.assignmentExpression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn3.Tree);
            token = (IToken) this.Match((IIntStream) this.input, 26, ES3Parser.Follow._COLON_in_conditionalExpression4835);
            this.PushFollow(ES3Parser.Follow._assignmentExpression_in_conditionalExpression4840);
            ES3Parser.assignmentExpression_return expressionReturn4 = this.assignmentExpression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn4.Tree);
            expressionReturn1.value = (Expression) new TernaryExpression(expressionReturn2.value, expressionReturn3.value, expressionReturn4.value);
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("conditionalExpressionNoIn")]
  private ES3Parser.conditionalExpressionNoIn_return conditionalExpressionNoIn()
  {
    ES3Parser.conditionalExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.conditionalExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    IToken token = (IToken) null;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._logicalORExpressionNoIn_in_conditionalExpressionNoIn4861);
        ES3Parser.logicalORExpressionNoIn_return expressionNoInReturn2 = this.logicalORExpressionNoIn();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
        expressionNoInReturn1.value = expressionNoInReturn2.value;
        int num = 2;
        try
        {
          try
          {
            if (this.input.LA(1) == 124)
              num = 1;
          }
          finally
          {
          }
          if (num == 1)
          {
            obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 124, ES3Parser.Follow._QUE_in_conditionalExpressionNoIn4867)), obj);
            this.PushFollow(ES3Parser.Follow._assignmentExpressionNoIn_in_conditionalExpressionNoIn4872);
            ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn3 = this.assignmentExpressionNoIn();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
            token = (IToken) this.Match((IIntStream) this.input, 26, ES3Parser.Follow._COLON_in_conditionalExpressionNoIn4874);
            this.PushFollow(ES3Parser.Follow._assignmentExpressionNoIn_in_conditionalExpressionNoIn4879);
            ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn4 = this.assignmentExpressionNoIn();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionNoInReturn4.Tree);
            expressionNoInReturn1.value = (Expression) new TernaryExpression(expressionNoInReturn2.value, expressionNoInReturn3.value, expressionNoInReturn4.value);
          }
        }
        finally
        {
        }
        expressionNoInReturn1.Stop = this.input.LT(-1);
        expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("assignmentExpression")]
  private ES3Parser.assignmentExpression_return assignmentExpression()
  {
    ES3Parser.assignmentExpression_return expressionReturn1 = new ES3Parser.assignmentExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    object[] cached = new object[1];
    AssignmentExpression assignmentExpression = new AssignmentExpression();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._conditionalExpression_in_assignmentExpression4912);
        ES3Parser.conditionalExpression_return expressionReturn2 = this.conditionalExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = assignmentExpression.Left = expressionReturn2.value;
        int num1 = 2;
        try
        {
          try
          {
            int num2 = this.input.LA(1);
            int num3;
            switch (num2)
            {
              case 6:
              case 8:
              case 11:
              case 37:
              case 96:
              case 98:
              case 111:
              case 135:
              case 138:
              case 140:
              case 145:
                num3 = 1;
                break;
              default:
                num3 = num2 == 169 ? 1 : 0;
                break;
            }
            if (num3 != 0)
            {
              this.input.LA(2);
              if (this.IsLeftHandSideAssign(expressionReturn2.value, cached))
                num1 = 1;
            }
          }
          finally
          {
          }
          if (num1 == 1)
          {
            if (!this.IsLeftHandSideAssign(expressionReturn2.value, cached))
              throw new FailedPredicateException((IIntStream) this.input, nameof (assignmentExpression), " IsLeftHandSideAssign(lhs.value, isLhs) ");
            this.PushFollow(ES3Parser.Follow._assignmentOperator_in_assignmentExpression4924);
            ES3Parser.assignmentOperator_return assignmentOperatorReturn = this.assignmentOperator();
            this.PopFollow();
            obj = this.adaptor.BecomeRoot(assignmentOperatorReturn.Tree, obj);
            assignmentExpression.AssignmentOperator = this.ResolveAssignmentOperator(assignmentOperatorReturn != null ? this.input.ToString(assignmentOperatorReturn.Start, assignmentOperatorReturn.Stop) : (string) null);
            this.PushFollow(ES3Parser.Follow._assignmentExpression_in_assignmentExpression4931);
            ES3Parser.assignmentExpression_return expressionReturn3 = this.assignmentExpression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn3.Tree);
            assignmentExpression.Right = expressionReturn3.value;
            expressionReturn1.value = (Expression) assignmentExpression;
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("assignmentOperator")]
  private ES3Parser.assignmentOperator_return assignmentOperator()
  {
    ES3Parser.assignmentOperator_return assignmentOperatorReturn = new ES3Parser.assignmentOperator_return(this);
    assignmentOperatorReturn.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        IToken payload = this.input.LT(1);
        if (this.input.LA(1) != 6 && this.input.LA(1) != 8 && (this.input.LA(1) != 11 && this.input.LA(1) != 37) && (this.input.LA(1) != 96 && this.input.LA(1) != 98 && (this.input.LA(1) != 111 && this.input.LA(1) != 135)) && (this.input.LA(1) != 138 && this.input.LA(1) != 140 && this.input.LA(1) != 145) && this.input.LA(1) != 169)
          throw new MismatchedSetException((BitSet) null, (IIntStream) this.input);
        this.input.Consume();
        this.adaptor.AddChild(obj, this.adaptor.Create(payload));
        this.state.errorRecovery = false;
        assignmentOperatorReturn.Stop = this.input.LT(-1);
        assignmentOperatorReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(assignmentOperatorReturn.Tree, assignmentOperatorReturn.Start, assignmentOperatorReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        assignmentOperatorReturn.Tree = this.adaptor.ErrorNode(this.input, assignmentOperatorReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return assignmentOperatorReturn;
  }

  [GrammarRule("assignmentExpressionNoIn")]
  private ES3Parser.assignmentExpressionNoIn_return assignmentExpressionNoIn()
  {
    ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn1 = new ES3Parser.assignmentExpressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    object[] cached = new object[1];
    AssignmentExpression assignmentExpression = new AssignmentExpression();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._conditionalExpressionNoIn_in_assignmentExpressionNoIn5026);
        ES3Parser.conditionalExpressionNoIn_return expressionNoInReturn2 = this.conditionalExpressionNoIn();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
        assignmentExpression.Left = expressionNoInReturn1.value = expressionNoInReturn2?.value;
        int num1 = 2;
        try
        {
          try
          {
            int num2 = this.input.LA(1);
            int num3;
            switch (num2)
            {
              case 6:
              case 8:
              case 11:
              case 37:
              case 96:
              case 98:
              case 111:
              case 135:
              case 138:
              case 140:
              case 145:
                num3 = 1;
                break;
              default:
                num3 = num2 == 169 ? 1 : 0;
                break;
            }
            if (num3 != 0)
            {
              this.input.LA(2);
              if (this.IsLeftHandSideAssign(expressionNoInReturn2.value, cached))
                num1 = 1;
            }
          }
          finally
          {
          }
          if (num1 == 1)
          {
            if (!this.IsLeftHandSideAssign(expressionNoInReturn2.value, cached))
              throw new FailedPredicateException((IIntStream) this.input, nameof (assignmentExpressionNoIn), " IsLeftHandSideAssign(lhs.value, isLhs) ");
            this.PushFollow(ES3Parser.Follow._assignmentOperator_in_assignmentExpressionNoIn5038);
            ES3Parser.assignmentOperator_return assignmentOperatorReturn = this.assignmentOperator();
            this.PopFollow();
            obj = this.adaptor.BecomeRoot(assignmentOperatorReturn.Tree, obj);
            assignmentExpression.AssignmentOperator = this.ResolveAssignmentOperator(assignmentOperatorReturn != null ? this.input.ToString(assignmentOperatorReturn.Start, assignmentOperatorReturn.Stop) : (string) null);
            this.PushFollow(ES3Parser.Follow._assignmentExpressionNoIn_in_assignmentExpressionNoIn5045);
            ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn3 = this.assignmentExpressionNoIn();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
            assignmentExpression.Right = expressionNoInReturn3.value;
            expressionNoInReturn1.value = (Expression) assignmentExpression;
          }
        }
        finally
        {
        }
        expressionNoInReturn1.Stop = this.input.LT(-1);
        expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("expression")]
  private ES3Parser.expression_return expression()
  {
    ES3Parser.expression_return expressionReturn1 = new ES3Parser.expression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    CommaOperatorStatement operatorStatement = new CommaOperatorStatement();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._assignmentExpression_in_expression5077);
        ES3Parser.assignmentExpression_return expressionReturn2 = this.assignmentExpression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn2.Tree);
        expressionReturn1.value = expressionReturn2.value;
        try
        {
          while (true)
          {
            int num = 2;
            try
            {
              if (this.input.LA(1) == 27)
                num = 1;
            }
            finally
            {
            }
            if (num == 1)
            {
              object child = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_expression5083));
              this.adaptor.AddChild(obj, child);
              if (operatorStatement.Statements.Count == 0)
              {
                operatorStatement.Statements.Add((Statement) expressionReturn1.value);
                expressionReturn1.value = (Expression) operatorStatement;
              }
              this.PushFollow(ES3Parser.Follow._assignmentExpression_in_expression5089);
              ES3Parser.assignmentExpression_return expressionReturn3 = this.assignmentExpression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn3.Tree);
              operatorStatement.Statements.Add((Statement) expressionReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("expressionNoIn")]
  private ES3Parser.expressionNoIn_return expressionNoIn()
  {
    ES3Parser.expressionNoIn_return expressionNoInReturn1 = new ES3Parser.expressionNoIn_return(this);
    expressionNoInReturn1.Start = this.input.LT(1);
    CommaOperatorStatement operatorStatement = new CommaOperatorStatement();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._assignmentExpressionNoIn_in_expressionNoIn5117);
        ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn2 = this.assignmentExpressionNoIn();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionNoInReturn2.Tree);
        expressionNoInReturn1.value = expressionNoInReturn2.value;
        try
        {
          while (true)
          {
            int num = 2;
            try
            {
              if (this.input.LA(1) == 27)
                num = 1;
            }
            finally
            {
            }
            if (num == 1)
            {
              object child = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_expressionNoIn5123));
              this.adaptor.AddChild(obj, child);
              if (operatorStatement.Statements.Count == 0)
              {
                operatorStatement.Statements.Add((Statement) expressionNoInReturn1.value);
                expressionNoInReturn1.value = (Expression) operatorStatement;
              }
              this.PushFollow(ES3Parser.Follow._assignmentExpressionNoIn_in_expressionNoIn5129);
              ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn3 = this.assignmentExpressionNoIn();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionNoInReturn3.Tree);
              operatorStatement.Statements.Add((Statement) expressionNoInReturn3.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        expressionNoInReturn1.Stop = this.input.LT(-1);
        expressionNoInReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionNoInReturn1.Tree, expressionNoInReturn1.Start, expressionNoInReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionNoInReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionNoInReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionNoInReturn1;
  }

  [GrammarRule("semic")]
  private ES3Parser.semic_return semic()
  {
    ES3Parser.semic_return semicReturn = new ES3Parser.semic_return(this);
    semicReturn.Start = this.input.LT(1);
    object obj = (object) null;
    int marker = this.input.Mark();
    this.PromoteEOL((ParserRuleReturnScope<IToken>) semicReturn);
    try
    {
      try
      {
        int num = 5;
        try
        {
          switch (this.input.LA(1))
          {
            case -1:
              num = 2;
              break;
            case 47:
              num = 4;
              break;
            case 99:
              num = 5;
              break;
            case 125:
              num = 3;
              break;
            case 133:
              num = 1;
              break;
            default:
              throw new NoViableAltException("", 56, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_semic5163));
            this.adaptor.AddChild(obj, child1);
            break;
          case 2:
            obj = this.adaptor.Nil();
            object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, -1, ES3Parser.Follow._EOF_in_semic5168));
            this.adaptor.AddChild(obj, child2);
            break;
          case 3:
            obj = this.adaptor.Nil();
            object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 125, ES3Parser.Follow._RBRACE_in_semic5173));
            this.adaptor.AddChild(obj, child3);
            this.input.Rewind(marker);
            break;
          case 4:
            obj = this.adaptor.Nil();
            object child4 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 47, ES3Parser.Follow._EOL_in_semic5180));
            this.adaptor.AddChild(obj, child4);
            break;
          case 5:
            obj = this.adaptor.Nil();
            object child5 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 99, ES3Parser.Follow._MultiLineComment_in_semic5184));
            this.adaptor.AddChild(obj, child5);
            break;
        }
        semicReturn.Stop = this.input.LT(-1);
        semicReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(semicReturn.Tree, semicReturn.Start, semicReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        semicReturn.Tree = this.adaptor.ErrorNode(this.input, semicReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return semicReturn;
  }

  [GrammarRule("statement")]
  private ES3Parser.statement_return statement()
  {
    ES3Parser.statement_return statementReturn = new ES3Parser.statement_return(this);
    statementReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 3;
        try
        {
          num = this.dfa57.Predict((IIntStream) this.input);
        }
        catch (NoViableAltException ex)
        {
          throw;
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            if (this.input.LA(1) != 85)
              throw new FailedPredicateException((IIntStream) this.input, nameof (statement), " input.LA(1) == LBRACE ");
            this.PushFollow(ES3Parser.Follow._block_in_statement5218);
            ES3Parser.block_return blockReturn = this.block();
            this.PopFollow();
            this.adaptor.AddChild(obj, blockReturn.Tree);
            statementReturn.value = (Statement) blockReturn?.value;
            break;
          case 2:
            obj = this.adaptor.Nil();
            if (this.input.LA(1) != 62)
              throw new FailedPredicateException((IIntStream) this.input, nameof (statement), " input.LA(1) == FUNCTION ");
            this.PushFollow(ES3Parser.Follow._functionDeclaration_in_statement5229);
            ES3Parser.functionDeclaration_return declarationReturn = this.functionDeclaration();
            this.PopFollow();
            this.adaptor.AddChild(obj, declarationReturn.Tree);
            statementReturn.value = declarationReturn.value;
            break;
          case 3:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._statementTail_in_statement5236);
            ES3Parser.statementTail_return statementTailReturn = this.statementTail();
            this.PopFollow();
            this.adaptor.AddChild(obj, statementTailReturn.Tree);
            statementReturn.value = statementTailReturn?.value;
            break;
        }
        statementReturn.Stop = this.input.LT(-1);
        statementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(statementReturn.Tree, statementReturn.Start, statementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        statementReturn.Tree = this.adaptor.ErrorNode(this.input, statementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return statementReturn;
  }

  [GrammarRule("statementTail")]
  private ES3Parser.statementTail_return statementTail()
  {
    ES3Parser.statementTail_return statementTailReturn = new ES3Parser.statementTail_return(this);
    statementTailReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 13;
        try
        {
          num = this.dfa58.Predict((IIntStream) this.input);
        }
        catch (NoViableAltException ex)
        {
          throw;
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._variableStatement_in_statementTail5259);
            ES3Parser.variableStatement_return variableStatementReturn = this.variableStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, variableStatementReturn.Tree);
            statementTailReturn.value = variableStatementReturn?.value;
            break;
          case 2:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._emptyStatement_in_statementTail5266);
            ES3Parser.emptyStatement_return emptyStatementReturn = this.emptyStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, emptyStatementReturn.Tree);
            statementTailReturn.value = emptyStatementReturn?.value;
            break;
          case 3:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._expressionStatement_in_statementTail5273);
            ES3Parser.expressionStatement_return expressionStatementReturn = this.expressionStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionStatementReturn.Tree);
            statementTailReturn.value = expressionStatementReturn?.value;
            break;
          case 4:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._ifStatement_in_statementTail5280);
            ES3Parser.ifStatement_return ifStatementReturn = this.ifStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, ifStatementReturn.Tree);
            statementTailReturn.value = ifStatementReturn?.value;
            break;
          case 5:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._iterationStatement_in_statementTail5287);
            ES3Parser.iterationStatement_return iterationStatementReturn = this.iterationStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, iterationStatementReturn.Tree);
            statementTailReturn.value = iterationStatementReturn?.value;
            break;
          case 6:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._continueStatement_in_statementTail5294);
            ES3Parser.continueStatement_return continueStatementReturn = this.continueStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, continueStatementReturn.Tree);
            statementTailReturn.value = continueStatementReturn?.value;
            break;
          case 7:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._breakStatement_in_statementTail5301);
            ES3Parser.breakStatement_return breakStatementReturn = this.breakStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, breakStatementReturn.Tree);
            statementTailReturn.value = breakStatementReturn?.value;
            break;
          case 8:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._returnStatement_in_statementTail5308);
            ES3Parser.returnStatement_return returnStatementReturn = this.returnStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, returnStatementReturn.Tree);
            statementTailReturn.value = (Statement) returnStatementReturn?.value;
            break;
          case 9:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._withStatement_in_statementTail5315);
            ES3Parser.withStatement_return withStatementReturn = this.withStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, withStatementReturn.Tree);
            statementTailReturn.value = withStatementReturn?.value;
            break;
          case 10:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._labelledStatement_in_statementTail5322);
            ES3Parser.labelledStatement_return labelledStatementReturn = this.labelledStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, labelledStatementReturn.Tree);
            statementTailReturn.value = labelledStatementReturn?.value;
            break;
          case 11:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._switchStatement_in_statementTail5329);
            ES3Parser.switchStatement_return switchStatementReturn = this.switchStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, switchStatementReturn.Tree);
            statementTailReturn.value = switchStatementReturn?.value;
            break;
          case 12:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._throwStatement_in_statementTail5336);
            ES3Parser.throwStatement_return throwStatementReturn = this.throwStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, throwStatementReturn.Tree);
            statementTailReturn.value = throwStatementReturn?.value;
            break;
          case 13:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._tryStatement_in_statementTail5343);
            ES3Parser.tryStatement_return tryStatementReturn = this.tryStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, tryStatementReturn.Tree);
            statementTailReturn.value = (Statement) tryStatementReturn?.value;
            break;
        }
        statementTailReturn.Stop = this.input.LT(-1);
        statementTailReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(statementTailReturn.Tree, statementTailReturn.Start, statementTailReturn.Stop);
        if (!(statementTailReturn.value is ForStatement) && !(statementTailReturn.value is BlockStatement) && (!(statementTailReturn.value is WhileStatement) && !(statementTailReturn.value is DoWhileStatement)) && (!(statementTailReturn.value is SwitchStatement) && !(statementTailReturn.value is TryStatement)) && !(statementTailReturn.value is IfStatement))
          statementTailReturn.value.Source = this.ExtractSourceCode((CommonToken) statementTailReturn.Start, (CommonToken) statementTailReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        statementTailReturn.Tree = this.adaptor.ErrorNode(this.input, statementTailReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return statementTailReturn;
  }

  [GrammarRule("block")]
  private ES3Parser.block_return block()
  {
    ES3Parser.block_return blockReturn = new ES3Parser.block_return(this);
    blockReturn.Start = this.input.LT(1);
    blockReturn.value = new BlockStatement();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 85, ES3Parser.Follow._LBRACE_in_block5373));
        this.adaptor.AddChild(obj, child1);
        try
        {
          while (true)
          {
            int num1 = 2;
            try
            {
              int num2 = this.input.LA(1);
              if (num2 == 5 || num2 == 14 || (num2 == 29 || num2 == 33) || (num2 == 35 || num2 == 38 || (num2 == 44 || num2 == 54)) || (num2 == 59 || num2 == 62 || num2 >= 68 && num2 <= 69 || (num2 == 73 || num2 == 77 || num2 == 79)) || (num2 >= 85 && num2 <= 86 || num2 == 90 || (num2 >= 105 && num2 <= 106 || (num2 == 108 || num2 == 114)) || (num2 == (int) sbyte.MaxValue || num2 == 131 || (num2 == 133 || num2 == 144) || (num2 == 147 || num2 == 150 || num2 >= 152 && num2 <= 153))) || (num2 >= 156 && num2 <= 158 || num2 >= 161 && num2 <= 162) || num2 >= 165 && num2 <= 166)
                num1 = 1;
            }
            finally
            {
            }
            if (num1 == 1)
            {
              this.PushFollow(ES3Parser.Follow._statement_in_block5376);
              ES3Parser.statement_return statementReturn = this.statement();
              this.PopFollow();
              this.adaptor.AddChild(obj, statementReturn.Tree);
              blockReturn.value.Statements.AddLast(statementReturn?.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 125, ES3Parser.Follow._RBRACE_in_block5382));
        this.adaptor.AddChild(obj, child2);
        blockReturn.Stop = this.input.LT(-1);
        blockReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(blockReturn.Tree, blockReturn.Start, blockReturn.Stop);
        blockReturn.value.Source = this.ExtractSourceCode((CommonToken) blockReturn.Start, (CommonToken) blockReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        blockReturn.Tree = this.adaptor.ErrorNode(this.input, blockReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return blockReturn;
  }

  [GrammarRule("variableStatement")]
  private ES3Parser.variableStatement_return variableStatement()
  {
    ES3Parser.variableStatement_return variableStatementReturn = new ES3Parser.variableStatement_return(this);
    variableStatementReturn.Start = this.input.LT(1);
    CommaOperatorStatement operatorStatement = new CommaOperatorStatement();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 161, ES3Parser.Follow._VAR_in_variableStatement5412));
        this.adaptor.AddChild(obj, child1);
        this.PushFollow(ES3Parser.Follow._variableDeclaration_in_variableStatement5416);
        ES3Parser.variableDeclaration_return declarationReturn1 = this.variableDeclaration();
        this.PopFollow();
        this.adaptor.AddChild(obj, declarationReturn1.Tree);
        declarationReturn1.value.Global = false;
        variableStatementReturn.value = (Statement) declarationReturn1.value;
        try
        {
          while (true)
          {
            int num = 2;
            try
            {
              if (this.input.LA(1) == 27)
                num = 1;
            }
            finally
            {
            }
            if (num == 1)
            {
              object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_variableStatement5422));
              this.adaptor.AddChild(obj, child2);
              if (operatorStatement.Statements.Count == 0)
              {
                operatorStatement.Statements.Add(variableStatementReturn.value);
                variableStatementReturn.value = (Statement) operatorStatement;
              }
              this.PushFollow(ES3Parser.Follow._variableDeclaration_in_variableStatement5428);
              ES3Parser.variableDeclaration_return declarationReturn2 = this.variableDeclaration();
              this.PopFollow();
              this.adaptor.AddChild(obj, declarationReturn2.Tree);
              operatorStatement.Statements.Add((Statement) declarationReturn2.value);
              declarationReturn2.value.Global = false;
            }
            else
              break;
          }
        }
        finally
        {
        }
        this.PushFollow(ES3Parser.Follow._semic_in_variableStatement5436);
        ES3Parser.semic_return semicReturn = this.semic();
        this.PopFollow();
        this.adaptor.AddChild(obj, semicReturn.Tree);
        variableStatementReturn.Stop = this.input.LT(-1);
        variableStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(variableStatementReturn.Tree, variableStatementReturn.Start, variableStatementReturn.Stop);
        if (operatorStatement.Statements.Count > 0)
        {
          foreach (Statement statement in operatorStatement.Statements)
            this._currentBody.AddFirst((Statement) new VariableDeclarationStatement()
            {
              Global = false,
              Identifier = ((VariableDeclarationStatement) statement).Identifier
            });
        }
        else
          this._currentBody.AddFirst((Statement) new VariableDeclarationStatement()
          {
            Global = false,
            Identifier = declarationReturn1.value.Identifier
          });
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        variableStatementReturn.Tree = this.adaptor.ErrorNode(this.input, variableStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return variableStatementReturn;
  }

  [GrammarRule("variableDeclaration")]
  private ES3Parser.variableDeclaration_return variableDeclaration()
  {
    ES3Parser.variableDeclaration_return declarationReturn = new ES3Parser.variableDeclaration_return(this);
    declarationReturn.Start = this.input.LT(1);
    declarationReturn.value = new VariableDeclarationStatement();
    declarationReturn.value.Global = true;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        IToken payload = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_variableDeclaration5460);
        object child = this.adaptor.Create(payload);
        this.adaptor.AddChild(obj, child);
        declarationReturn.value.Identifier = payload.Text;
        int num = 2;
        try
        {
          try
          {
            if (this.input.LA(1) == 11)
              num = 1;
          }
          finally
          {
          }
          if (num == 1)
          {
            obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 11, ES3Parser.Follow._ASSIGN_in_variableDeclaration5466)), obj);
            this.PushFollow(ES3Parser.Follow._assignmentExpression_in_variableDeclaration5471);
            ES3Parser.assignmentExpression_return expressionReturn = this.assignmentExpression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn.Tree);
            declarationReturn.value.Expression = expressionReturn.value;
          }
        }
        finally
        {
        }
        declarationReturn.Stop = this.input.LT(-1);
        declarationReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(declarationReturn.Tree, declarationReturn.Start, declarationReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        declarationReturn.Tree = this.adaptor.ErrorNode(this.input, declarationReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return declarationReturn;
  }

  [GrammarRule("variableDeclarationNoIn")]
  private ES3Parser.variableDeclarationNoIn_return variableDeclarationNoIn()
  {
    ES3Parser.variableDeclarationNoIn_return declarationNoInReturn = new ES3Parser.variableDeclarationNoIn_return(this);
    declarationNoInReturn.Start = this.input.LT(1);
    declarationNoInReturn.value = new VariableDeclarationStatement();
    declarationNoInReturn.value.Global = true;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        IToken payload = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_variableDeclarationNoIn5499);
        object child = this.adaptor.Create(payload);
        this.adaptor.AddChild(obj, child);
        declarationNoInReturn.value.Identifier = payload.Text;
        int num = 2;
        try
        {
          try
          {
            if (this.input.LA(1) == 11)
              num = 1;
          }
          finally
          {
          }
          if (num == 1)
          {
            obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 11, ES3Parser.Follow._ASSIGN_in_variableDeclarationNoIn5505)), obj);
            this.PushFollow(ES3Parser.Follow._assignmentExpressionNoIn_in_variableDeclarationNoIn5510);
            ES3Parser.assignmentExpressionNoIn_return expressionNoInReturn = this.assignmentExpressionNoIn();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionNoInReturn.Tree);
            declarationNoInReturn.value.Expression = expressionNoInReturn.value;
          }
        }
        finally
        {
        }
        declarationNoInReturn.Stop = this.input.LT(-1);
        declarationNoInReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(declarationNoInReturn.Tree, declarationNoInReturn.Start, declarationNoInReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        declarationNoInReturn.Tree = this.adaptor.ErrorNode(this.input, declarationNoInReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return declarationNoInReturn;
  }

  [GrammarRule("emptyStatement")]
  private ES3Parser.emptyStatement_return emptyStatement()
  {
    ES3Parser.emptyStatement_return emptyStatementReturn = new ES3Parser.emptyStatement_return(this);
    emptyStatementReturn.Start = this.input.LT(1);
    IToken token = (IToken) null;
    try
    {
      try
      {
        object root = this.adaptor.Nil();
        token = (IToken) this.Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_emptyStatement5535);
        emptyStatementReturn.value = (Statement) new EmptyStatement();
        emptyStatementReturn.Stop = this.input.LT(-1);
        emptyStatementReturn.Tree = this.adaptor.RulePostProcessing(root);
        this.adaptor.SetTokenBoundaries(emptyStatementReturn.Tree, emptyStatementReturn.Start, emptyStatementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        emptyStatementReturn.Tree = this.adaptor.ErrorNode(this.input, emptyStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return emptyStatementReturn;
  }

  [GrammarRule("expressionStatement")]
  private ES3Parser.expressionStatement_return expressionStatement()
  {
    ES3Parser.expressionStatement_return expressionStatementReturn = new ES3Parser.expressionStatement_return(this);
    expressionStatementReturn.Start = this.input.LT(1);
    ES3Parser.semic_return semicReturn = (ES3Parser.semic_return) null;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._expression_in_expressionStatement5560);
        ES3Parser.expression_return expressionReturn = this.expression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn.Tree);
        this.PushFollow(ES3Parser.Follow._semic_in_expressionStatement5562);
        semicReturn = this.semic();
        this.PopFollow();
        expressionStatementReturn.value = (Statement) new ExpressionStatement(expressionReturn?.value);
        expressionStatementReturn.Stop = this.input.LT(-1);
        expressionStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionStatementReturn.Tree, expressionStatementReturn.Start, expressionStatementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionStatementReturn.Tree = this.adaptor.ErrorNode(this.input, expressionStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionStatementReturn;
  }

  [GrammarRule("ifStatement")]
  private ES3Parser.ifStatement_return ifStatement()
  {
    ES3Parser.ifStatement_return ifStatementReturn = new ES3Parser.ifStatement_return(this);
    ifStatementReturn.Start = this.input.LT(1);
    IfStatement ifStatement = new IfStatement();
    ifStatementReturn.value = (Statement) ifStatement;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 69, ES3Parser.Follow._IF_in_ifStatement5591));
        this.adaptor.AddChild(obj, child1);
        object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_ifStatement5593));
        this.adaptor.AddChild(obj, child2);
        this.PushFollow(ES3Parser.Follow._expression_in_ifStatement5595);
        ES3Parser.expression_return expressionReturn = this.expression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn.Tree);
        ifStatement.Expression = expressionReturn?.value;
        object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 128, ES3Parser.Follow._RPAREN_in_ifStatement5599));
        this.adaptor.AddChild(obj, child3);
        this.PushFollow(ES3Parser.Follow._statement_in_ifStatement5603);
        ES3Parser.statement_return statementReturn1 = this.statement();
        this.PopFollow();
        this.adaptor.AddChild(obj, statementReturn1.Tree);
        ifStatement.Then = statementReturn1?.value;
        int num = 2;
        try
        {
          try
          {
            if (this.input.LA(1) == 45)
            {
              this.input.LA(2);
              if (this.input.LA(1) == 45)
                num = 1;
            }
          }
          finally
          {
          }
          if (num == 1)
          {
            if (this.input.LA(1) != 45)
              throw new FailedPredicateException((IIntStream) this.input, nameof (ifStatement), " input.LA(1) == ELSE ");
            object child4 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 45, ES3Parser.Follow._ELSE_in_ifStatement5611));
            this.adaptor.AddChild(obj, child4);
            this.PushFollow(ES3Parser.Follow._statement_in_ifStatement5615);
            ES3Parser.statement_return statementReturn2 = this.statement();
            this.PopFollow();
            this.adaptor.AddChild(obj, statementReturn2.Tree);
            ifStatement.Else = statementReturn2?.value;
          }
        }
        finally
        {
        }
        ifStatementReturn.Stop = this.input.LT(-1);
        ifStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(ifStatementReturn.Tree, ifStatementReturn.Start, ifStatementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        ifStatementReturn.Tree = this.adaptor.ErrorNode(this.input, ifStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return ifStatementReturn;
  }

  [GrammarRule("iterationStatement")]
  private ES3Parser.iterationStatement_return iterationStatement()
  {
    ES3Parser.iterationStatement_return iterationStatementReturn = new ES3Parser.iterationStatement_return(this);
    iterationStatementReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 3;
        try
        {
          switch (this.input.LA(1))
          {
            case 38:
              num = 1;
              break;
            case 59:
              num = 3;
              break;
            case 165:
              num = 2;
              break;
            default:
              throw new NoViableAltException("", 64, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._doStatement_in_iterationStatement5645);
            ES3Parser.doStatement_return doStatementReturn = this.doStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, doStatementReturn.Tree);
            iterationStatementReturn.value = doStatementReturn.value;
            break;
          case 2:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._whileStatement_in_iterationStatement5654);
            ES3Parser.whileStatement_return whileStatementReturn = this.whileStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, whileStatementReturn.Tree);
            iterationStatementReturn.value = whileStatementReturn.value;
            break;
          case 3:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._forStatement_in_iterationStatement5664);
            ES3Parser.forStatement_return forStatementReturn = this.forStatement();
            this.PopFollow();
            this.adaptor.AddChild(obj, forStatementReturn.Tree);
            iterationStatementReturn.value = (Statement) forStatementReturn.value;
            break;
        }
        iterationStatementReturn.Stop = this.input.LT(-1);
        iterationStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(iterationStatementReturn.Tree, iterationStatementReturn.Start, iterationStatementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        iterationStatementReturn.Tree = this.adaptor.ErrorNode(this.input, iterationStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return iterationStatementReturn;
  }

  [GrammarRule("doStatement")]
  private ES3Parser.doStatement_return doStatement()
  {
    ES3Parser.doStatement_return doStatementReturn = new ES3Parser.doStatement_return(this);
    doStatementReturn.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 38, ES3Parser.Follow._DO_in_doStatement5683));
        this.adaptor.AddChild(obj, child1);
        this.PushFollow(ES3Parser.Follow._statement_in_doStatement5685);
        ES3Parser.statement_return statementReturn = this.statement();
        this.PopFollow();
        this.adaptor.AddChild(obj, statementReturn.Tree);
        object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 165, ES3Parser.Follow._WHILE_in_doStatement5687));
        this.adaptor.AddChild(obj, child2);
        object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_doStatement5689));
        this.adaptor.AddChild(obj, child3);
        this.PushFollow(ES3Parser.Follow._expression_in_doStatement5691);
        ES3Parser.expression_return expressionReturn = this.expression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn.Tree);
        object child4 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 128, ES3Parser.Follow._RPAREN_in_doStatement5693));
        this.adaptor.AddChild(obj, child4);
        this.PushFollow(ES3Parser.Follow._semic_in_doStatement5695);
        ES3Parser.semic_return semicReturn = this.semic();
        this.PopFollow();
        this.adaptor.AddChild(obj, semicReturn.Tree);
        doStatementReturn.value = (Statement) new DoWhileStatement(expressionReturn?.value, statementReturn?.value);
        doStatementReturn.Stop = this.input.LT(-1);
        doStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(doStatementReturn.Tree, doStatementReturn.Start, doStatementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        doStatementReturn.Tree = this.adaptor.ErrorNode(this.input, doStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return doStatementReturn;
  }

  [GrammarRule("whileStatement")]
  private ES3Parser.whileStatement_return whileStatement()
  {
    ES3Parser.whileStatement_return whileStatementReturn = new ES3Parser.whileStatement_return(this);
    whileStatementReturn.Start = this.input.LT(1);
    IToken token1 = (IToken) null;
    IToken token2 = (IToken) null;
    try
    {
      try
      {
        object oldRoot = this.adaptor.Nil();
        object obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 165, ES3Parser.Follow._WHILE_in_whileStatement5715)), oldRoot);
        token1 = (IToken) this.Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_whileStatement5718);
        this.PushFollow(ES3Parser.Follow._expression_in_whileStatement5721);
        ES3Parser.expression_return expressionReturn = this.expression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn.Tree);
        token2 = (IToken) this.Match((IIntStream) this.input, 128, ES3Parser.Follow._RPAREN_in_whileStatement5723);
        this.PushFollow(ES3Parser.Follow._statement_in_whileStatement5726);
        ES3Parser.statement_return statementReturn = this.statement();
        this.PopFollow();
        this.adaptor.AddChild(obj, statementReturn.Tree);
        whileStatementReturn.value = (Statement) new WhileStatement(expressionReturn?.value, statementReturn?.value);
        whileStatementReturn.Stop = this.input.LT(-1);
        whileStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(whileStatementReturn.Tree, whileStatementReturn.Start, whileStatementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        whileStatementReturn.Tree = this.adaptor.ErrorNode(this.input, whileStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return whileStatementReturn;
  }

  [GrammarRule("forStatement")]
  private ES3Parser.forStatement_return forStatement()
  {
    ES3Parser.forStatement_return forStatementReturn = new ES3Parser.forStatement_return(this);
    forStatementReturn.Start = this.input.LT(1);
    IToken token1 = (IToken) null;
    IToken token2 = (IToken) null;
    try
    {
      try
      {
        object oldRoot = this.adaptor.Nil();
        object obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 59, ES3Parser.Follow._FOR_in_forStatement5745)), oldRoot);
        token1 = (IToken) this.Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_forStatement5748);
        this.PushFollow(ES3Parser.Follow._forControl_in_forStatement5753);
        ES3Parser.forControl_return forControlReturn = this.forControl();
        this.PopFollow();
        this.adaptor.AddChild(obj, forControlReturn.Tree);
        forStatementReturn.value = forControlReturn.value;
        token2 = (IToken) this.Match((IIntStream) this.input, 128, ES3Parser.Follow._RPAREN_in_forStatement5758);
        this.PushFollow(ES3Parser.Follow._statement_in_forStatement5763);
        ES3Parser.statement_return statementReturn = this.statement();
        this.PopFollow();
        this.adaptor.AddChild(obj, statementReturn.Tree);
        forStatementReturn.value.Statement = statementReturn.value;
        forStatementReturn.Stop = this.input.LT(-1);
        forStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(forStatementReturn.Tree, forStatementReturn.Start, forStatementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        forStatementReturn.Tree = this.adaptor.ErrorNode(this.input, forStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return forStatementReturn;
  }

  [GrammarRule("forControl")]
  private ES3Parser.forControl_return forControl()
  {
    ES3Parser.forControl_return forControlReturn = new ES3Parser.forControl_return(this);
    forControlReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 3;
        try
        {
          switch (this.input.LA(1))
          {
            case 5:
            case 33:
            case 35:
            case 44:
            case 54:
            case 62:
            case 68:
            case 73:
            case 77:
            case 79:
            case 85:
            case 86:
            case 90:
            case 105:
            case 106:
            case 108:
            case 114:
            case 131:
            case 144:
            case 150:
            case 152:
            case 156:
            case 158:
            case 162:
              num = 2;
              break;
            case 133:
              num = 3;
              break;
            case 161:
              num = 1;
              break;
            default:
              throw new NoViableAltException("", 65, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._forControlVar_in_forControl5782);
            ES3Parser.forControlVar_return controlVarReturn = this.forControlVar();
            this.PopFollow();
            this.adaptor.AddChild(obj, controlVarReturn.Tree);
            forControlReturn.value = controlVarReturn.value;
            break;
          case 2:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._forControlExpression_in_forControl5791);
            ES3Parser.forControlExpression_return expressionReturn = this.forControlExpression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn.Tree);
            forControlReturn.value = expressionReturn.value;
            break;
          case 3:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._forControlSemic_in_forControl5800);
            ES3Parser.forControlSemic_return controlSemicReturn = this.forControlSemic();
            this.PopFollow();
            this.adaptor.AddChild(obj, controlSemicReturn.Tree);
            forControlReturn.value = (IForStatement) controlSemicReturn.value;
            break;
        }
        forControlReturn.Stop = this.input.LT(-1);
        forControlReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(forControlReturn.Tree, forControlReturn.Start, forControlReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        forControlReturn.Tree = this.adaptor.ErrorNode(this.input, forControlReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return forControlReturn;
  }

  [GrammarRule("forControlVar")]
  private ES3Parser.forControlVar_return forControlVar()
  {
    ES3Parser.forControlVar_return controlVarReturn = new ES3Parser.forControlVar_return(this);
    controlVarReturn.Start = this.input.LT(1);
    ForStatement forStatement = new ForStatement();
    ForEachInStatement forEachInStatement = new ForEachInStatement();
    CommaOperatorStatement operatorStatement = new CommaOperatorStatement();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 161, ES3Parser.Follow._VAR_in_forControlVar5828));
        this.adaptor.AddChild(obj, child1);
        this.PushFollow(ES3Parser.Follow._variableDeclarationNoIn_in_forControlVar5832);
        ES3Parser.variableDeclarationNoIn_return declarationNoInReturn1 = this.variableDeclarationNoIn();
        this.PopFollow();
        this.adaptor.AddChild(obj, declarationNoInReturn1.Tree);
        forEachInStatement.InitialisationStatement = forStatement.InitialisationStatement = (Statement) declarationNoInReturn1.value;
        declarationNoInReturn1.value.Global = false;
        int num1 = 2;
        try
        {
          try
          {
            int num2 = this.input.LA(1);
            int num3;
            switch (num2)
            {
              case 27:
                num3 = 1;
                break;
              case 72:
                num1 = 1;
                goto label_12;
              default:
                num3 = num2 == 133 ? 1 : 0;
                break;
            }
            if (num3 == 0)
              throw new NoViableAltException("", 69, 0, (IIntStream) this.input);
            num1 = 2;
          }
          finally
          {
          }
label_12:
          switch (num1)
          {
            case 1:
              object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 72, ES3Parser.Follow._IN_in_forControlVar5846));
              this.adaptor.AddChild(obj, child2);
              this.PushFollow(ES3Parser.Follow._expression_in_forControlVar5850);
              ES3Parser.expression_return expressionReturn1 = this.expression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn1.Tree);
              controlVarReturn.value = (IForStatement) forEachInStatement;
              forEachInStatement.Expression = expressionReturn1?.value;
              break;
            case 2:
              try
              {
                while (true)
                {
                  int num2 = 2;
                  try
                  {
                    if (this.input.LA(1) == 27)
                      num2 = 1;
                  }
                  finally
                  {
                  }
                  if (num2 == 1)
                  {
                    object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_forControlVar5875));
                    this.adaptor.AddChild(obj, child3);
                    if (operatorStatement.Statements.Count == 0)
                    {
                      forEachInStatement.InitialisationStatement = forStatement.InitialisationStatement = (Statement) operatorStatement;
                      operatorStatement.Statements.Add((Statement) declarationNoInReturn1.value);
                    }
                    this.PushFollow(ES3Parser.Follow._variableDeclarationNoIn_in_forControlVar5881);
                    ES3Parser.variableDeclarationNoIn_return declarationNoInReturn2 = this.variableDeclarationNoIn();
                    this.PopFollow();
                    this.adaptor.AddChild(obj, declarationNoInReturn2.Tree);
                    declarationNoInReturn2.value.Global = false;
                    operatorStatement.Statements.Add((Statement) declarationNoInReturn2.value);
                  }
                  else
                    break;
                }
              }
              finally
              {
              }
              object child4 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_forControlVar5892));
              this.adaptor.AddChild(obj, child4);
              int num4 = 2;
              try
              {
                try
                {
                  int num2 = this.input.LA(1);
                  if (num2 == 5 || num2 == 33 || (num2 == 35 || num2 == 44) || (num2 == 54 || num2 == 62 || (num2 == 68 || num2 == 73)) || (num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || (num2 == 90 || num2 >= 105 && num2 <= 106)) || (num2 == 108 || num2 == 114 || (num2 == 131 || num2 == 144) || (num2 == 150 || num2 == 152 || (num2 == 156 || num2 == 158))) || num2 == 162)
                    num4 = 1;
                }
                finally
                {
                }
                if (num4 == 1)
                {
                  this.PushFollow(ES3Parser.Follow._expression_in_forControlVar5898);
                  ES3Parser.expression_return expressionReturn2 = this.expression();
                  this.PopFollow();
                  this.adaptor.AddChild(obj, expressionReturn2.Tree);
                  forStatement.ConditionExpression = (Statement) expressionReturn2?.value;
                }
              }
              finally
              {
              }
              object child5 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_forControlVar5906));
              this.adaptor.AddChild(obj, child5);
              int num5 = 2;
              try
              {
                try
                {
                  int num2 = this.input.LA(1);
                  if (num2 == 5 || num2 == 33 || (num2 == 35 || num2 == 44) || (num2 == 54 || num2 == 62 || (num2 == 68 || num2 == 73)) || (num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || (num2 == 90 || num2 >= 105 && num2 <= 106)) || (num2 == 108 || num2 == 114 || (num2 == 131 || num2 == 144) || (num2 == 150 || num2 == 152 || (num2 == 156 || num2 == 158))) || num2 == 162)
                    num5 = 1;
                }
                finally
                {
                }
                if (num5 == 1)
                {
                  this.PushFollow(ES3Parser.Follow._expression_in_forControlVar5911);
                  ES3Parser.expression_return expressionReturn2 = this.expression();
                  this.PopFollow();
                  this.adaptor.AddChild(obj, expressionReturn2.Tree);
                  forStatement.IncrementExpression = (Statement) expressionReturn2?.value;
                }
              }
              finally
              {
              }
              controlVarReturn.value = (IForStatement) forStatement;
              break;
          }
        }
        finally
        {
        }
        controlVarReturn.Stop = this.input.LT(-1);
        controlVarReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(controlVarReturn.Tree, controlVarReturn.Start, controlVarReturn.Stop);
        if (operatorStatement.Statements.Count > 0)
        {
          foreach (Statement statement in operatorStatement.Statements)
            this._currentBody.AddFirst((Statement) new VariableDeclarationStatement()
            {
              Global = false,
              Identifier = ((VariableDeclarationStatement) statement).Identifier
            });
        }
        else
          this._currentBody.AddFirst((Statement) new VariableDeclarationStatement()
          {
            Global = false,
            Identifier = declarationNoInReturn1.value.Identifier
          });
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        controlVarReturn.Tree = this.adaptor.ErrorNode(this.input, controlVarReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return controlVarReturn;
  }

  [GrammarRule("forControlExpression")]
  private ES3Parser.forControlExpression_return forControlExpression()
  {
    ES3Parser.forControlExpression_return expressionReturn1 = new ES3Parser.forControlExpression_return(this);
    expressionReturn1.Start = this.input.LT(1);
    ForStatement forStatement = new ForStatement();
    ForEachInStatement forEachInStatement = new ForEachInStatement();
    object[] cached = new object[1];
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        this.PushFollow(ES3Parser.Follow._expressionNoIn_in_forControlExpression5950);
        ES3Parser.expressionNoIn_return expressionNoInReturn = this.expressionNoIn();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionNoInReturn.Tree);
        forEachInStatement.InitialisationStatement = forStatement.InitialisationStatement = (Statement) expressionNoInReturn.value;
        int num1 = 2;
        try
        {
          try
          {
            switch (this.input.LA(1))
            {
              case 72:
                num1 = 1;
                break;
              case 133:
                num1 = 2;
                break;
              default:
                throw new NoViableAltException("", 72, 0, (IIntStream) this.input);
            }
          }
          finally
          {
          }
          switch (num1)
          {
            case 1:
              if (!this.IsLeftHandSideIn(expressionNoInReturn.value, cached))
                throw new FailedPredicateException((IIntStream) this.input, nameof (forControlExpression), " IsLeftHandSideIn(ex1.value, isLhs) ");
              object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 72, ES3Parser.Follow._IN_in_forControlExpression5967));
              this.adaptor.AddChild(obj, child1);
              this.PushFollow(ES3Parser.Follow._expression_in_forControlExpression5971);
              ES3Parser.expression_return expressionReturn2 = this.expression();
              this.PopFollow();
              this.adaptor.AddChild(obj, expressionReturn2.Tree);
              expressionReturn1.value = (IForStatement) forEachInStatement;
              forEachInStatement.Expression = expressionReturn2.value;
              break;
            case 2:
              object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_forControlExpression5994));
              this.adaptor.AddChild(obj, child2);
              int num2 = 2;
              try
              {
                try
                {
                  int num3 = this.input.LA(1);
                  if (num3 == 5 || num3 == 33 || (num3 == 35 || num3 == 44) || (num3 == 54 || num3 == 62 || (num3 == 68 || num3 == 73)) || (num3 == 77 || num3 == 79 || num3 >= 85 && num3 <= 86 || (num3 == 90 || num3 >= 105 && num3 <= 106)) || (num3 == 108 || num3 == 114 || (num3 == 131 || num3 == 144) || (num3 == 150 || num3 == 152 || (num3 == 156 || num3 == 158))) || num3 == 162)
                    num2 = 1;
                }
                finally
                {
                }
                if (num2 == 1)
                {
                  this.PushFollow(ES3Parser.Follow._expression_in_forControlExpression6000);
                  ES3Parser.expression_return expressionReturn3 = this.expression();
                  this.PopFollow();
                  this.adaptor.AddChild(obj, expressionReturn3.Tree);
                  forStatement.ConditionExpression = (Statement) expressionReturn3.value;
                }
              }
              finally
              {
              }
              object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_forControlExpression6008));
              this.adaptor.AddChild(obj, child3);
              int num4 = 2;
              try
              {
                try
                {
                  int num3 = this.input.LA(1);
                  if (num3 == 5 || num3 == 33 || (num3 == 35 || num3 == 44) || (num3 == 54 || num3 == 62 || (num3 == 68 || num3 == 73)) || (num3 == 77 || num3 == 79 || num3 >= 85 && num3 <= 86 || (num3 == 90 || num3 >= 105 && num3 <= 106)) || (num3 == 108 || num3 == 114 || (num3 == 131 || num3 == 144) || (num3 == 150 || num3 == 152 || (num3 == 156 || num3 == 158))) || num3 == 162)
                    num4 = 1;
                }
                finally
                {
                }
                if (num4 == 1)
                {
                  this.PushFollow(ES3Parser.Follow._expression_in_forControlExpression6013);
                  ES3Parser.expression_return expressionReturn3 = this.expression();
                  this.PopFollow();
                  this.adaptor.AddChild(obj, expressionReturn3.Tree);
                  forStatement.IncrementExpression = (Statement) expressionReturn3.value;
                }
              }
              finally
              {
              }
              expressionReturn1.value = (IForStatement) forStatement;
              break;
          }
        }
        finally
        {
        }
        expressionReturn1.Stop = this.input.LT(-1);
        expressionReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn1.Tree, expressionReturn1.Start, expressionReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn1.Tree = this.adaptor.ErrorNode(this.input, expressionReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn1;
  }

  [GrammarRule("forControlSemic")]
  private ES3Parser.forControlSemic_return forControlSemic()
  {
    ES3Parser.forControlSemic_return controlSemicReturn = new ES3Parser.forControlSemic_return(this);
    controlSemicReturn.Start = this.input.LT(1);
    controlSemicReturn.value = new ForStatement();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_forControlSemic6049));
        this.adaptor.AddChild(obj, child1);
        int num1 = 2;
        try
        {
          try
          {
            int num2 = this.input.LA(1);
            if (num2 == 5 || num2 == 33 || (num2 == 35 || num2 == 44) || (num2 == 54 || num2 == 62 || (num2 == 68 || num2 == 73)) || (num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || (num2 == 90 || num2 >= 105 && num2 <= 106)) || (num2 == 108 || num2 == 114 || (num2 == 131 || num2 == 144) || (num2 == 150 || num2 == 152 || (num2 == 156 || num2 == 158))) || num2 == 162)
              num1 = 1;
          }
          finally
          {
          }
          if (num1 == 1)
          {
            this.PushFollow(ES3Parser.Follow._expression_in_forControlSemic6055);
            ES3Parser.expression_return expressionReturn = this.expression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn.Tree);
            controlSemicReturn.value.ConditionExpression = (Statement) expressionReturn.value;
          }
        }
        finally
        {
        }
        object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 133, ES3Parser.Follow._SEMIC_in_forControlSemic6063));
        this.adaptor.AddChild(obj, child2);
        int num3 = 2;
        try
        {
          try
          {
            int num2 = this.input.LA(1);
            if (num2 == 5 || num2 == 33 || (num2 == 35 || num2 == 44) || (num2 == 54 || num2 == 62 || (num2 == 68 || num2 == 73)) || (num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || (num2 == 90 || num2 >= 105 && num2 <= 106)) || (num2 == 108 || num2 == 114 || (num2 == 131 || num2 == 144) || (num2 == 150 || num2 == 152 || (num2 == 156 || num2 == 158))) || num2 == 162)
              num3 = 1;
          }
          finally
          {
          }
          if (num3 == 1)
          {
            this.PushFollow(ES3Parser.Follow._expression_in_forControlSemic6068);
            ES3Parser.expression_return expressionReturn = this.expression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn.Tree);
            controlSemicReturn.value.IncrementExpression = (Statement) expressionReturn.value;
          }
        }
        finally
        {
        }
        controlSemicReturn.Stop = this.input.LT(-1);
        controlSemicReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(controlSemicReturn.Tree, controlSemicReturn.Start, controlSemicReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        controlSemicReturn.Tree = this.adaptor.ErrorNode(this.input, controlSemicReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return controlSemicReturn;
  }

  [GrammarRule("continueStatement")]
  private ES3Parser.continueStatement_return continueStatement()
  {
    ES3Parser.continueStatement_return continueStatementReturn1 = new ES3Parser.continueStatement_return(this);
    continueStatementReturn1.Start = this.input.LT(1);
    ES3Parser.semic_return semicReturn = (ES3Parser.semic_return) null;
    string str = string.Empty;
    try
    {
      try
      {
        object oldRoot = this.adaptor.Nil();
        object obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 29, ES3Parser.Follow._CONTINUE_in_continueStatement6102)), oldRoot);
        if (this.input.LA(1) == 79)
          this.PromoteEOL((ParserRuleReturnScope<IToken>) null);
        int num = 2;
        try
        {
          try
          {
            if (this.input.LA(1) == 79)
              num = 1;
          }
          finally
          {
          }
          if (num == 1)
          {
            IToken payload = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_continueStatement6110);
            object child = this.adaptor.Create(payload);
            this.adaptor.AddChild(obj, child);
            str = payload.Text;
          }
        }
        finally
        {
        }
        this.PushFollow(ES3Parser.Follow._semic_in_continueStatement6117);
        semicReturn = this.semic();
        this.PopFollow();
        ES3Parser.continueStatement_return continueStatementReturn2 = continueStatementReturn1;
        ContinueStatement continueStatement = new ContinueStatement();
        continueStatement.Label = str;
        continueStatementReturn2.value = (Statement) continueStatement;
        continueStatementReturn1.Stop = this.input.LT(-1);
        continueStatementReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(continueStatementReturn1.Tree, continueStatementReturn1.Start, continueStatementReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        continueStatementReturn1.Tree = this.adaptor.ErrorNode(this.input, continueStatementReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return continueStatementReturn1;
  }

  [GrammarRule("breakStatement")]
  private ES3Parser.breakStatement_return breakStatement()
  {
    ES3Parser.breakStatement_return breakStatementReturn1 = new ES3Parser.breakStatement_return(this);
    breakStatementReturn1.Start = this.input.LT(1);
    ES3Parser.semic_return semicReturn = (ES3Parser.semic_return) null;
    string str = string.Empty;
    try
    {
      try
      {
        object oldRoot = this.adaptor.Nil();
        object obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 14, ES3Parser.Follow._BREAK_in_breakStatement6147)), oldRoot);
        if (this.input.LA(1) == 79)
          this.PromoteEOL((ParserRuleReturnScope<IToken>) null);
        int num = 2;
        try
        {
          try
          {
            if (this.input.LA(1) == 79)
              num = 1;
          }
          finally
          {
          }
          if (num == 1)
          {
            IToken payload = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_breakStatement6155);
            object child = this.adaptor.Create(payload);
            this.adaptor.AddChild(obj, child);
            str = payload.Text;
          }
        }
        finally
        {
        }
        this.PushFollow(ES3Parser.Follow._semic_in_breakStatement6162);
        semicReturn = this.semic();
        this.PopFollow();
        ES3Parser.breakStatement_return breakStatementReturn2 = breakStatementReturn1;
        BreakStatement breakStatement = new BreakStatement();
        breakStatement.Label = str;
        breakStatementReturn2.value = (Statement) breakStatement;
        breakStatementReturn1.Stop = this.input.LT(-1);
        breakStatementReturn1.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(breakStatementReturn1.Tree, breakStatementReturn1.Start, breakStatementReturn1.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        breakStatementReturn1.Tree = this.adaptor.ErrorNode(this.input, breakStatementReturn1.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return breakStatementReturn1;
  }

  [GrammarRule("returnStatement")]
  private ES3Parser.returnStatement_return returnStatement()
  {
    ES3Parser.returnStatement_return returnStatementReturn = new ES3Parser.returnStatement_return(this);
    returnStatementReturn.Start = this.input.LT(1);
    ES3Parser.semic_return semicReturn = (ES3Parser.semic_return) null;
    returnStatementReturn.value = new ReturnStatement();
    try
    {
      try
      {
        object oldRoot = this.adaptor.Nil();
        object obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, (int) sbyte.MaxValue, ES3Parser.Follow._RETURN_in_returnStatement6192)), oldRoot);
        this.PromoteEOL((ParserRuleReturnScope<IToken>) null);
        int num1 = 2;
        try
        {
          try
          {
            int num2 = this.input.LA(1);
            if (num2 == 5 || num2 == 33 || (num2 == 35 || num2 == 44) || (num2 == 54 || num2 == 62 || (num2 == 68 || num2 == 73)) || (num2 == 77 || num2 == 79 || num2 >= 85 && num2 <= 86 || (num2 == 90 || num2 >= 105 && num2 <= 106)) || (num2 == 108 || num2 == 114 || (num2 == 131 || num2 == 144) || (num2 == 150 || num2 == 152 || (num2 == 156 || num2 == 158))) || num2 == 162)
              num1 = 1;
          }
          finally
          {
          }
          if (num1 == 1)
          {
            this.PushFollow(ES3Parser.Follow._expression_in_returnStatement6200);
            ES3Parser.expression_return expressionReturn = this.expression();
            this.PopFollow();
            this.adaptor.AddChild(obj, expressionReturn.Tree);
            returnStatementReturn.value.Expression = expressionReturn.value;
          }
        }
        finally
        {
        }
        this.PushFollow(ES3Parser.Follow._semic_in_returnStatement6206);
        semicReturn = this.semic();
        this.PopFollow();
        returnStatementReturn.Stop = this.input.LT(-1);
        returnStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(returnStatementReturn.Tree, returnStatementReturn.Start, returnStatementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        returnStatementReturn.Tree = this.adaptor.ErrorNode(this.input, returnStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return returnStatementReturn;
  }

  [GrammarRule("withStatement")]
  private ES3Parser.withStatement_return withStatement()
  {
    ES3Parser.withStatement_return withStatementReturn = new ES3Parser.withStatement_return(this);
    withStatementReturn.Start = this.input.LT(1);
    IToken token1 = (IToken) null;
    IToken token2 = (IToken) null;
    try
    {
      try
      {
        object oldRoot = this.adaptor.Nil();
        object obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 166, ES3Parser.Follow._WITH_in_withStatement6227)), oldRoot);
        token1 = (IToken) this.Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_withStatement6230);
        this.PushFollow(ES3Parser.Follow._expression_in_withStatement6235);
        ES3Parser.expression_return expressionReturn = this.expression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn.Tree);
        token2 = (IToken) this.Match((IIntStream) this.input, 128, ES3Parser.Follow._RPAREN_in_withStatement6237);
        this.PushFollow(ES3Parser.Follow._statement_in_withStatement6242);
        ES3Parser.statement_return statementReturn = this.statement();
        this.PopFollow();
        this.adaptor.AddChild(obj, statementReturn.Tree);
        withStatementReturn.value = (Statement) new WithStatement(expressionReturn.value, statementReturn.value);
        withStatementReturn.Stop = this.input.LT(-1);
        withStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(withStatementReturn.Tree, withStatementReturn.Start, withStatementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        withStatementReturn.Tree = this.adaptor.ErrorNode(this.input, withStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return withStatementReturn;
  }

  [GrammarRule("switchStatement")]
  private ES3Parser.switchStatement_return switchStatement()
  {
    ES3Parser.switchStatement_return switchStatementReturn = new ES3Parser.switchStatement_return(this);
    switchStatementReturn.Start = this.input.LT(1);
    SwitchStatement switchStatement = new SwitchStatement();
    switchStatementReturn.value = (Statement) switchStatement;
    int num1 = 0;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 147, ES3Parser.Follow._SWITCH_in_switchStatement6269));
        this.adaptor.AddChild(obj, child1);
        object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_switchStatement6271));
        this.adaptor.AddChild(obj, child2);
        this.PushFollow(ES3Parser.Follow._expression_in_switchStatement6273);
        ES3Parser.expression_return expressionReturn = this.expression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn.Tree);
        switchStatement.Expression = (Statement) expressionReturn?.value;
        object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 128, ES3Parser.Follow._RPAREN_in_switchStatement6277));
        this.adaptor.AddChild(obj, child3);
        object child4 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 85, ES3Parser.Follow._LBRACE_in_switchStatement6282));
        this.adaptor.AddChild(obj, child4);
        try
        {
          while (true)
          {
            int num2 = 3;
            try
            {
              int num3 = this.input.LA(1);
              if (num3 == 34 && num1 == 0)
                num2 = 1;
              else if (num3 == 21)
                num2 = 2;
            }
            finally
            {
            }
            switch (num2)
            {
              case 1:
                if ((uint) num1 <= 0U)
                {
                  this.PushFollow(ES3Parser.Follow._defaultClause_in_switchStatement6289);
                  ES3Parser.defaultClause_return defaultClauseReturn = this.defaultClause();
                  this.PopFollow();
                  this.adaptor.AddChild(obj, defaultClauseReturn.Tree);
                  ++num1;
                  switchStatement.DefaultStatements = (Statement) defaultClauseReturn?.value;
                  break;
                }
                goto label_11;
              case 2:
                this.PushFollow(ES3Parser.Follow._caseClause_in_switchStatement6295);
                ES3Parser.caseClause_return caseClauseReturn = this.caseClause();
                this.PopFollow();
                this.adaptor.AddChild(obj, caseClauseReturn.Tree);
                switchStatement.CaseClauses.Add(caseClauseReturn?.value);
                break;
              default:
                goto label_17;
            }
          }
label_11:
          throw new FailedPredicateException((IIntStream) this.input, nameof (switchStatement), " defaultClauseCount == 0 ");
        }
        finally
        {
        }
label_17:
        object child5 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 125, ES3Parser.Follow._RBRACE_in_switchStatement6302));
        this.adaptor.AddChild(obj, child5);
        switchStatementReturn.Stop = this.input.LT(-1);
        switchStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(switchStatementReturn.Tree, switchStatementReturn.Start, switchStatementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        switchStatementReturn.Tree = this.adaptor.ErrorNode(this.input, switchStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return switchStatementReturn;
  }

  [GrammarRule("caseClause")]
  private ES3Parser.caseClause_return caseClause()
  {
    ES3Parser.caseClause_return caseClauseReturn = new ES3Parser.caseClause_return(this);
    caseClauseReturn.Start = this.input.LT(1);
    IToken token = (IToken) null;
    caseClauseReturn.value = new CaseClause();
    try
    {
      try
      {
        object oldRoot = this.adaptor.Nil();
        object obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 21, ES3Parser.Follow._CASE_in_caseClause6325)), oldRoot);
        this.PushFollow(ES3Parser.Follow._expression_in_caseClause6328);
        ES3Parser.expression_return expressionReturn = this.expression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn.Tree);
        caseClauseReturn.value.Expression = expressionReturn?.value;
        token = (IToken) this.Match((IIntStream) this.input, 26, ES3Parser.Follow._COLON_in_caseClause6332);
        try
        {
          while (true)
          {
            int num1 = 2;
            try
            {
              int num2 = this.input.LA(1);
              if (num2 == 5 || num2 == 14 || (num2 == 29 || num2 == 33) || (num2 == 35 || num2 == 38 || (num2 == 44 || num2 == 54)) || (num2 == 59 || num2 == 62 || num2 >= 68 && num2 <= 69 || (num2 == 73 || num2 == 77 || num2 == 79)) || (num2 >= 85 && num2 <= 86 || num2 == 90 || (num2 >= 105 && num2 <= 106 || (num2 == 108 || num2 == 114)) || (num2 == (int) sbyte.MaxValue || num2 == 131 || (num2 == 133 || num2 == 144) || (num2 == 147 || num2 == 150 || num2 >= 152 && num2 <= 153))) || (num2 >= 156 && num2 <= 158 || num2 >= 161 && num2 <= 162) || num2 >= 165 && num2 <= 166)
                num1 = 1;
            }
            finally
            {
            }
            if (num1 == 1)
            {
              this.PushFollow(ES3Parser.Follow._statement_in_caseClause6336);
              ES3Parser.statement_return statementReturn = this.statement();
              this.PopFollow();
              this.adaptor.AddChild(obj, statementReturn.Tree);
              caseClauseReturn.value.Statements.Statements.AddLast(statementReturn?.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        caseClauseReturn.Stop = this.input.LT(-1);
        caseClauseReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(caseClauseReturn.Tree, caseClauseReturn.Start, caseClauseReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        caseClauseReturn.Tree = this.adaptor.ErrorNode(this.input, caseClauseReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return caseClauseReturn;
  }

  [GrammarRule("defaultClause")]
  private ES3Parser.defaultClause_return defaultClause()
  {
    ES3Parser.defaultClause_return defaultClauseReturn = new ES3Parser.defaultClause_return(this);
    defaultClauseReturn.Start = this.input.LT(1);
    IToken token = (IToken) null;
    defaultClauseReturn.value = new BlockStatement();
    try
    {
      try
      {
        object oldRoot = this.adaptor.Nil();
        object obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 34, ES3Parser.Follow._DEFAULT_in_defaultClause6361)), oldRoot);
        token = (IToken) this.Match((IIntStream) this.input, 26, ES3Parser.Follow._COLON_in_defaultClause6364);
        try
        {
          while (true)
          {
            int num1 = 2;
            try
            {
              int num2 = this.input.LA(1);
              if (num2 == 5 || num2 == 14 || (num2 == 29 || num2 == 33) || (num2 == 35 || num2 == 38 || (num2 == 44 || num2 == 54)) || (num2 == 59 || num2 == 62 || num2 >= 68 && num2 <= 69 || (num2 == 73 || num2 == 77 || num2 == 79)) || (num2 >= 85 && num2 <= 86 || num2 == 90 || (num2 >= 105 && num2 <= 106 || (num2 == 108 || num2 == 114)) || (num2 == (int) sbyte.MaxValue || num2 == 131 || (num2 == 133 || num2 == 144) || (num2 == 147 || num2 == 150 || num2 >= 152 && num2 <= 153))) || (num2 >= 156 && num2 <= 158 || num2 >= 161 && num2 <= 162) || num2 >= 165 && num2 <= 166)
                num1 = 1;
            }
            finally
            {
            }
            if (num1 == 1)
            {
              this.PushFollow(ES3Parser.Follow._statement_in_defaultClause6368);
              ES3Parser.statement_return statementReturn = this.statement();
              this.PopFollow();
              this.adaptor.AddChild(obj, statementReturn.Tree);
              defaultClauseReturn.value.Statements.AddLast(statementReturn?.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        defaultClauseReturn.Stop = this.input.LT(-1);
        defaultClauseReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(defaultClauseReturn.Tree, defaultClauseReturn.Start, defaultClauseReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        defaultClauseReturn.Tree = this.adaptor.ErrorNode(this.input, defaultClauseReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return defaultClauseReturn;
  }

  [GrammarRule("labelledStatement")]
  private ES3Parser.labelledStatement_return labelledStatement()
  {
    ES3Parser.labelledStatement_return labelledStatementReturn = new ES3Parser.labelledStatement_return(this);
    labelledStatementReturn.Start = this.input.LT(1);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        IToken payload = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_labelledStatement6395);
        object child1 = this.adaptor.Create(payload);
        this.adaptor.AddChild(obj, child1);
        object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 26, ES3Parser.Follow._COLON_in_labelledStatement6397));
        this.adaptor.AddChild(obj, child2);
        this.PushFollow(ES3Parser.Follow._statement_in_labelledStatement6401);
        ES3Parser.statement_return statementReturn = this.statement();
        this.PopFollow();
        this.adaptor.AddChild(obj, statementReturn.Tree);
        labelledStatementReturn.value = statementReturn.value;
        labelledStatementReturn.value.Label = payload.Text;
        labelledStatementReturn.Stop = this.input.LT(-1);
        labelledStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(labelledStatementReturn.Tree, labelledStatementReturn.Start, labelledStatementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        labelledStatementReturn.Tree = this.adaptor.ErrorNode(this.input, labelledStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return labelledStatementReturn;
  }

  [GrammarRule("throwStatement")]
  private ES3Parser.throwStatement_return throwStatement()
  {
    ES3Parser.throwStatement_return throwStatementReturn = new ES3Parser.throwStatement_return(this);
    throwStatementReturn.Start = this.input.LT(1);
    ES3Parser.semic_return semicReturn = (ES3Parser.semic_return) null;
    try
    {
      try
      {
        object oldRoot = this.adaptor.Nil();
        object obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 153, ES3Parser.Follow._THROW_in_throwStatement6427)), oldRoot);
        this.PromoteEOL((ParserRuleReturnScope<IToken>) null);
        this.PushFollow(ES3Parser.Follow._expression_in_throwStatement6434);
        ES3Parser.expression_return expressionReturn = this.expression();
        this.PopFollow();
        this.adaptor.AddChild(obj, expressionReturn.Tree);
        throwStatementReturn.value = (Statement) new ThrowStatement(expressionReturn.value);
        this.PushFollow(ES3Parser.Follow._semic_in_throwStatement6438);
        semicReturn = this.semic();
        this.PopFollow();
        throwStatementReturn.Stop = this.input.LT(-1);
        throwStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(throwStatementReturn.Tree, throwStatementReturn.Start, throwStatementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        throwStatementReturn.Tree = this.adaptor.ErrorNode(this.input, throwStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return throwStatementReturn;
  }

  [GrammarRule("tryStatement")]
  private ES3Parser.tryStatement_return tryStatement()
  {
    ES3Parser.tryStatement_return tryStatementReturn = new ES3Parser.tryStatement_return(this);
    tryStatementReturn.Start = this.input.LT(1);
    tryStatementReturn.value = new TryStatement();
    try
    {
      try
      {
        object oldRoot = this.adaptor.Nil();
        object obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 157, ES3Parser.Follow._TRY_in_tryStatement6463)), oldRoot);
        this.PushFollow(ES3Parser.Follow._block_in_tryStatement6468);
        ES3Parser.block_return blockReturn = this.block();
        this.PopFollow();
        this.adaptor.AddChild(obj, blockReturn.Tree);
        tryStatementReturn.value.Statement = (Statement) blockReturn.value;
        int num1 = 2;
        try
        {
          try
          {
            switch (this.input.LA(1))
            {
              case 22:
                num1 = 1;
                break;
              case 57:
                num1 = 2;
                break;
              default:
                throw new NoViableAltException("", 82, 0, (IIntStream) this.input);
            }
          }
          finally
          {
          }
          switch (num1)
          {
            case 1:
              this.PushFollow(ES3Parser.Follow._catchClause_in_tryStatement6477);
              ES3Parser.catchClause_return catchClauseReturn = this.catchClause();
              this.PopFollow();
              this.adaptor.AddChild(obj, catchClauseReturn.Tree);
              tryStatementReturn.value.Catch = catchClauseReturn.value;
              int num2 = 2;
              try
              {
                try
                {
                  if (this.input.LA(1) == 57)
                    num2 = 1;
                }
                finally
                {
                }
                if (num2 == 1)
                {
                  this.PushFollow(ES3Parser.Follow._finallyClause_in_tryStatement6484);
                  ES3Parser.finallyClause_return finallyClauseReturn = this.finallyClause();
                  this.PopFollow();
                  this.adaptor.AddChild(obj, finallyClauseReturn.Tree);
                  tryStatementReturn.value.Finally = finallyClauseReturn.value;
                  break;
                }
                break;
              }
              finally
              {
              }
            case 2:
              this.PushFollow(ES3Parser.Follow._finallyClause_in_tryStatement6494);
              ES3Parser.finallyClause_return finallyClauseReturn1 = this.finallyClause();
              this.PopFollow();
              this.adaptor.AddChild(obj, finallyClauseReturn1.Tree);
              tryStatementReturn.value.Finally = finallyClauseReturn1.value;
              break;
          }
        }
        finally
        {
        }
        tryStatementReturn.Stop = this.input.LT(-1);
        tryStatementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(tryStatementReturn.Tree, tryStatementReturn.Start, tryStatementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        tryStatementReturn.Tree = this.adaptor.ErrorNode(this.input, tryStatementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return tryStatementReturn;
  }

  [GrammarRule("catchClause")]
  private ES3Parser.catchClause_return catchClause()
  {
    ES3Parser.catchClause_return catchClauseReturn = new ES3Parser.catchClause_return(this);
    catchClauseReturn.Start = this.input.LT(1);
    IToken token1 = (IToken) null;
    IToken token2 = (IToken) null;
    try
    {
      try
      {
        object oldRoot = this.adaptor.Nil();
        object obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 22, ES3Parser.Follow._CATCH_in_catchClause6514)), oldRoot);
        token1 = (IToken) this.Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_catchClause6517);
        IToken payload = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_catchClause6522);
        object child = this.adaptor.Create(payload);
        this.adaptor.AddChild(obj, child);
        token2 = (IToken) this.Match((IIntStream) this.input, 128, ES3Parser.Follow._RPAREN_in_catchClause6524);
        this.PushFollow(ES3Parser.Follow._block_in_catchClause6527);
        ES3Parser.block_return blockReturn = this.block();
        this.PopFollow();
        this.adaptor.AddChild(obj, blockReturn.Tree);
        catchClauseReturn.value = new CatchClause(payload?.Text, (Statement) blockReturn?.value);
        catchClauseReturn.Stop = this.input.LT(-1);
        catchClauseReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(catchClauseReturn.Tree, catchClauseReturn.Start, catchClauseReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        catchClauseReturn.Tree = this.adaptor.ErrorNode(this.input, catchClauseReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return catchClauseReturn;
  }

  [GrammarRule("finallyClause")]
  private ES3Parser.finallyClause_return finallyClause()
  {
    ES3Parser.finallyClause_return finallyClauseReturn = new ES3Parser.finallyClause_return(this);
    finallyClauseReturn.Start = this.input.LT(1);
    try
    {
      try
      {
        object oldRoot = this.adaptor.Nil();
        object obj = this.adaptor.BecomeRoot(this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 57, ES3Parser.Follow._FINALLY_in_finallyClause6545)), oldRoot);
        this.PushFollow(ES3Parser.Follow._block_in_finallyClause6548);
        ES3Parser.block_return blockReturn = this.block();
        this.PopFollow();
        this.adaptor.AddChild(obj, blockReturn.Tree);
        finallyClauseReturn.value = new FinallyClause((Statement) blockReturn?.value);
        finallyClauseReturn.Stop = this.input.LT(-1);
        finallyClauseReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(finallyClauseReturn.Tree, finallyClauseReturn.Start, finallyClauseReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        finallyClauseReturn.Tree = this.adaptor.ErrorNode(this.input, finallyClauseReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return finallyClauseReturn;
  }

  [GrammarRule("functionDeclaration")]
  private ES3Parser.functionDeclaration_return functionDeclaration()
  {
    ES3Parser.functionDeclaration_return declarationReturn = new ES3Parser.functionDeclaration_return(this);
    declarationReturn.Start = this.input.LT(1);
    FunctionDeclarationStatement declarationStatement = new FunctionDeclarationStatement();
    declarationReturn.value = (Statement) new EmptyStatement();
    this._currentBody.AddFirst((Statement) declarationStatement);
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 62, ES3Parser.Follow._FUNCTION_in_functionDeclaration6580));
        this.adaptor.AddChild(obj, child1);
        IToken payload = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_functionDeclaration6585);
        object child2 = this.adaptor.Create(payload);
        this.adaptor.AddChild(obj, child2);
        declarationStatement.Name = payload.Text;
        this.PushFollow(ES3Parser.Follow._formalParameterList_in_functionDeclaration6595);
        ES3Parser.formalParameterList_return parameterListReturn = this.formalParameterList();
        this.PopFollow();
        this.adaptor.AddChild(obj, parameterListReturn.Tree);
        declarationStatement.Parameters.AddRange((IEnumerable<string>) parameterListReturn.value);
        this.PushFollow(ES3Parser.Follow._functionBody_in_functionDeclaration6604);
        ES3Parser.functionBody_return functionBodyReturn = this.functionBody();
        this.PopFollow();
        this.adaptor.AddChild(obj, functionBodyReturn.Tree);
        declarationStatement.Statement = (Statement) functionBodyReturn.value;
        declarationReturn.Stop = this.input.LT(-1);
        declarationReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(declarationReturn.Tree, declarationReturn.Start, declarationReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        declarationReturn.Tree = this.adaptor.ErrorNode(this.input, declarationReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return declarationReturn;
  }

  [GrammarRule("functionExpression")]
  private ES3Parser.functionExpression_return functionExpression()
  {
    ES3Parser.functionExpression_return expressionReturn = new ES3Parser.functionExpression_return(this);
    expressionReturn.Start = this.input.LT(1);
    expressionReturn.value = new FunctionExpression();
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 62, ES3Parser.Follow._FUNCTION_in_functionExpression6631));
        this.adaptor.AddChild(obj, child1);
        int num = 2;
        try
        {
          try
          {
            if (this.input.LA(1) == 79)
              num = 1;
          }
          finally
          {
          }
          if (num == 1)
          {
            IToken payload = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_functionExpression6636);
            object child2 = this.adaptor.Create(payload);
            this.adaptor.AddChild(obj, child2);
            expressionReturn.value.Name = payload.Text;
          }
        }
        finally
        {
        }
        this.PushFollow(ES3Parser.Follow._formalParameterList_in_functionExpression6643);
        ES3Parser.formalParameterList_return parameterListReturn = this.formalParameterList();
        this.PopFollow();
        this.adaptor.AddChild(obj, parameterListReturn.Tree);
        expressionReturn.value.Parameters.AddRange((IEnumerable<string>) parameterListReturn?.value);
        this.PushFollow(ES3Parser.Follow._functionBody_in_functionExpression6647);
        ES3Parser.functionBody_return functionBodyReturn = this.functionBody();
        this.PopFollow();
        this.adaptor.AddChild(obj, functionBodyReturn.Tree);
        expressionReturn.value.Statement = (Statement) functionBodyReturn?.value;
        expressionReturn.Stop = this.input.LT(-1);
        expressionReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(expressionReturn.Tree, expressionReturn.Start, expressionReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        expressionReturn.Tree = this.adaptor.ErrorNode(this.input, expressionReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return expressionReturn;
  }

  [GrammarRule("formalParameterList")]
  private ES3Parser.formalParameterList_return formalParameterList()
  {
    ES3Parser.formalParameterList_return parameterListReturn = new ES3Parser.formalParameterList_return(this);
    parameterListReturn.Start = this.input.LT(1);
    List<string> stringList = new List<string>();
    parameterListReturn.value = stringList;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 90, ES3Parser.Follow._LPAREN_in_formalParameterList6672));
        this.adaptor.AddChild(obj, child1);
        int num1 = 2;
        try
        {
          try
          {
            if (this.input.LA(1) == 79)
              num1 = 1;
          }
          finally
          {
          }
          if (num1 == 1)
          {
            IToken payload1 = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_formalParameterList6678);
            object child2 = this.adaptor.Create(payload1);
            this.adaptor.AddChild(obj, child2);
            stringList.Add(payload1?.Text);
            try
            {
              while (true)
              {
                int num2 = 2;
                try
                {
                  if (this.input.LA(1) == 27)
                    num2 = 1;
                }
                finally
                {
                }
                if (num2 == 1)
                {
                  object child3 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 27, ES3Parser.Follow._COMMA_in_formalParameterList6684));
                  this.adaptor.AddChild(obj, child3);
                  IToken payload2 = (IToken) this.Match((IIntStream) this.input, 79, ES3Parser.Follow._Identifier_in_formalParameterList6688);
                  object child4 = this.adaptor.Create(payload2);
                  this.adaptor.AddChild(obj, child4);
                  stringList.Add(payload2?.Text);
                }
                else
                  break;
              }
            }
            finally
            {
            }
          }
        }
        finally
        {
        }
        object child5 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 128, ES3Parser.Follow._RPAREN_in_formalParameterList6699));
        this.adaptor.AddChild(obj, child5);
        parameterListReturn.Stop = this.input.LT(-1);
        parameterListReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(parameterListReturn.Tree, parameterListReturn.Start, parameterListReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        parameterListReturn.Tree = this.adaptor.ErrorNode(this.input, parameterListReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return parameterListReturn;
  }

  [GrammarRule("functionBody")]
  private ES3Parser.functionBody_return functionBody()
  {
    ES3Parser.functionBody_return functionBodyReturn = new ES3Parser.functionBody_return(this);
    functionBodyReturn.Start = this.input.LT(1);
    BlockStatement blockStatement = new BlockStatement();
    LinkedList<Statement> currentBody = this._currentBody;
    this._currentBody = blockStatement.Statements;
    functionBodyReturn.value = blockStatement;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        object child1 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 85, ES3Parser.Follow._LBRACE_in_functionBody6726));
        this.adaptor.AddChild(obj, child1);
        try
        {
          while (true)
          {
            int num1 = 2;
            try
            {
              int num2 = this.input.LA(1);
              if (num2 == 5 || num2 == 14 || (num2 == 29 || num2 == 33) || (num2 == 35 || num2 == 38 || (num2 == 44 || num2 == 54)) || (num2 == 59 || num2 == 62 || num2 >= 68 && num2 <= 69 || (num2 == 73 || num2 == 77 || num2 == 79)) || (num2 >= 85 && num2 <= 86 || num2 == 90 || (num2 >= 105 && num2 <= 106 || (num2 == 108 || num2 == 114)) || (num2 == (int) sbyte.MaxValue || num2 == 131 || (num2 == 133 || num2 == 144) || (num2 == 147 || num2 == 150 || num2 >= 152 && num2 <= 153))) || (num2 >= 156 && num2 <= 158 || num2 >= 161 && num2 <= 162) || num2 >= 165 && num2 <= 166)
                num1 = 1;
            }
            finally
            {
            }
            if (num1 == 1)
            {
              this.PushFollow(ES3Parser.Follow._sourceElement_in_functionBody6729);
              ES3Parser.sourceElement_return sourceElementReturn = this.sourceElement();
              this.PopFollow();
              this.adaptor.AddChild(obj, sourceElementReturn.Tree);
              blockStatement.Statements.AddLast(sourceElementReturn?.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        object child2 = this.adaptor.Create((IToken) this.Match((IIntStream) this.input, 125, ES3Parser.Follow._RBRACE_in_functionBody6736));
        this.adaptor.AddChild(obj, child2);
        functionBodyReturn.Stop = this.input.LT(-1);
        functionBodyReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(functionBodyReturn.Tree, functionBodyReturn.Start, functionBodyReturn.Stop);
        this._currentBody = currentBody;
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        functionBodyReturn.Tree = this.adaptor.ErrorNode(this.input, functionBodyReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return functionBodyReturn;
  }

  [GrammarRule("program")]
  public ES3Parser.program_return program()
  {
    ES3Parser.program_return programReturn = new ES3Parser.program_return(this);
    programReturn.Start = this.input.LT(1);
    this.script = this.input.ToString().Split('\n');
    Program program = new Program();
    this._currentBody = program.Statements;
    try
    {
      try
      {
        object obj = this.adaptor.Nil();
        try
        {
          while (true)
          {
            int num1 = 2;
            try
            {
              int num2 = this.input.LA(1);
              if (num2 == 5 || num2 == 14 || (num2 == 29 || num2 == 33) || (num2 == 35 || num2 == 38 || (num2 == 44 || num2 == 54)) || (num2 == 59 || num2 == 62 || num2 >= 68 && num2 <= 69 || (num2 == 73 || num2 == 77 || num2 == 79)) || (num2 >= 85 && num2 <= 86 || num2 == 90 || (num2 >= 105 && num2 <= 106 || (num2 == 108 || num2 == 114)) || (num2 == (int) sbyte.MaxValue || num2 == 131 || (num2 == 133 || num2 == 144) || (num2 == 147 || num2 == 150 || num2 >= 152 && num2 <= 153))) || (num2 >= 156 && num2 <= 158 || num2 >= 161 && num2 <= 162) || num2 >= 165 && num2 <= 166)
                num1 = 1;
            }
            finally
            {
            }
            if (num1 == 1)
            {
              this.PushFollow(ES3Parser.Follow._sourceElement_in_program6765);
              ES3Parser.sourceElement_return sourceElementReturn = this.sourceElement();
              this.PopFollow();
              this.adaptor.AddChild(obj, sourceElementReturn.Tree);
              program.Statements.AddLast(sourceElementReturn.value);
            }
            else
              break;
          }
        }
        finally
        {
        }
        programReturn.value = program;
        programReturn.Stop = this.input.LT(-1);
        programReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(programReturn.Tree, programReturn.Start, programReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        programReturn.Tree = this.adaptor.ErrorNode(this.input, programReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return programReturn;
  }

  [GrammarRule("sourceElement")]
  private ES3Parser.sourceElement_return sourceElement()
  {
    ES3Parser.sourceElement_return sourceElementReturn = new ES3Parser.sourceElement_return(this);
    sourceElementReturn.Start = this.input.LT(1);
    object obj = (object) null;
    try
    {
      try
      {
        int num = 2;
        try
        {
          num = this.dfa88.Predict((IIntStream) this.input);
        }
        catch (NoViableAltException ex)
        {
          throw;
        }
        finally
        {
        }
        switch (num)
        {
          case 1:
            obj = this.adaptor.Nil();
            if (this.input.LA(1) != 62)
              throw new FailedPredicateException((IIntStream) this.input, nameof (sourceElement), " input.LA(1) == FUNCTION ");
            this.PushFollow(ES3Parser.Follow._functionDeclaration_in_sourceElement6806);
            ES3Parser.functionDeclaration_return declarationReturn = this.functionDeclaration();
            this.PopFollow();
            this.adaptor.AddChild(obj, declarationReturn.Tree);
            sourceElementReturn.value = declarationReturn.value;
            break;
          case 2:
            obj = this.adaptor.Nil();
            this.PushFollow(ES3Parser.Follow._statement_in_sourceElement6815);
            ES3Parser.statement_return statementReturn = this.statement();
            this.PopFollow();
            this.adaptor.AddChild(obj, statementReturn.Tree);
            sourceElementReturn.value = statementReturn.value;
            break;
        }
        sourceElementReturn.Stop = this.input.LT(-1);
        sourceElementReturn.Tree = this.adaptor.RulePostProcessing(obj);
        this.adaptor.SetTokenBoundaries(sourceElementReturn.Tree, sourceElementReturn.Start, sourceElementReturn.Stop);
      }
      catch (RecognitionException ex)
      {
        this.ReportError(ex);
        this.Recover((IIntStream) this.input, ex);
        sourceElementReturn.Tree = this.adaptor.ErrorNode(this.input, sourceElementReturn.Start, this.input.LT(-1), ex);
      }
      finally
      {
      }
    }
    finally
    {
    }
    return sourceElementReturn;
  }

  protected override void InitDFAs()
  {
    base.InitDFAs();
    this.dfa57 = new ES3Parser.DFA57((BaseRecognizer) this, new SpecialStateTransitionHandler(this.SpecialStateTransition57));
    this.dfa58 = new ES3Parser.DFA58((BaseRecognizer) this);
    this.dfa88 = new ES3Parser.DFA88((BaseRecognizer) this, new SpecialStateTransitionHandler(this.SpecialStateTransition88));
  }

  private int SpecialStateTransition57(DFA dfa, int s, IIntStream _input)
  {
    ITokenStream tokenStream = (ITokenStream) _input;
    int stateNumber = s;
    switch (s)
    {
      case 0:
        tokenStream.LA(1);
        int index1 = tokenStream.Index;
        tokenStream.Rewind();
        s = -1;
        if (tokenStream.LA(1) == 85)
          s = 38;
        else
          s = 3;
        tokenStream.Seek(index1);
        if (s >= 0)
          return s;
        break;
      case 1:
        tokenStream.LA(1);
        int index2 = tokenStream.Index;
        tokenStream.Rewind();
        s = -1;
        if (tokenStream.LA(1) == 62)
          s = 39;
        else
          s = 3;
        tokenStream.Seek(index2);
        if (s >= 0)
          return s;
        break;
    }
    NoViableAltException nvae = new NoViableAltException(dfa.Description, 57, stateNumber, (IIntStream) tokenStream);
    dfa.Error(nvae);
    throw nvae;
  }

  private int SpecialStateTransition88(DFA dfa, int s, IIntStream _input)
  {
    ITokenStream tokenStream = (ITokenStream) _input;
    int stateNumber = s;
    if (s == 0)
    {
      tokenStream.LA(1);
      int index = tokenStream.Index;
      tokenStream.Rewind();
      s = -1;
      if (tokenStream.LA(1) == 62)
        s = 38;
      else
        s = 2;
      tokenStream.Seek(index);
      if (s >= 0)
        return s;
    }
    NoViableAltException nvae = new NoViableAltException(dfa.Description, 88, stateNumber, (IIntStream) tokenStream);
    dfa.Error(nvae);
    throw nvae;
  }

  private sealed class token_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public token_return(ES3Parser grammar)
    {
    }
  }

  private sealed class reservedWord_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public reservedWord_return(ES3Parser grammar)
    {
    }
  }

  private sealed class keyword_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public keyword_return(ES3Parser grammar)
    {
    }
  }

  private sealed class futureReservedWord_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public futureReservedWord_return(ES3Parser grammar)
    {
    }
  }

  private sealed class punctuator_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public punctuator_return(ES3Parser grammar)
    {
    }
  }

  private sealed class literal_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public literal_return(ES3Parser grammar)
    {
    }
  }

  private sealed class booleanLiteral_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public bool value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public booleanLiteral_return(ES3Parser grammar)
    {
    }
  }

  private sealed class numericLiteral_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public double value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public numericLiteral_return(ES3Parser grammar)
    {
    }
  }

  private sealed class primaryExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public primaryExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class arrayLiteral_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public ArrayDeclaration value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public arrayLiteral_return(ES3Parser grammar)
    {
    }
  }

  private sealed class arrayItem_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public arrayItem_return(ES3Parser grammar)
    {
    }
  }

  private sealed class objectLiteral_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public JsonExpression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public objectLiteral_return(ES3Parser grammar)
    {
    }
  }

  private sealed class propertyAssignment_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public PropertyDeclarationExpression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public propertyAssignment_return(ES3Parser grammar)
    {
    }
  }

  private sealed class accessor_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public PropertyExpressionType value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public accessor_return(ES3Parser grammar)
    {
    }
  }

  private sealed class propertyName_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public string value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public propertyName_return(ES3Parser grammar)
    {
    }
  }

  private sealed class memberExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public memberExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class newExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public NewExpression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public newExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class arguments_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public List<Expression> value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public arguments_return(ES3Parser grammar)
    {
    }
  }

  private sealed class generics_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public List<Expression> value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public generics_return(ES3Parser grammar)
    {
    }
  }

  private sealed class leftHandSideExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public leftHandSideExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class postfixExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public postfixExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class postfixOperator_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public UnaryExpressionType value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public postfixOperator_return(ES3Parser grammar)
    {
    }
  }

  private sealed class unaryExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public unaryExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class unaryOperator_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public UnaryExpressionType value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public unaryOperator_return(ES3Parser grammar)
    {
    }
  }

  private sealed class multiplicativeExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public multiplicativeExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class additiveExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public additiveExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class shiftExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public shiftExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class relationalExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public relationalExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class relationalExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public relationalExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class equalityExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public equalityExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class equalityExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public equalityExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class bitwiseANDExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public bitwiseANDExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class bitwiseANDExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public bitwiseANDExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class bitwiseXORExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public bitwiseXORExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class bitwiseXORExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public bitwiseXORExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class bitwiseORExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public bitwiseORExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class bitwiseORExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public bitwiseORExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class logicalANDExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public logicalANDExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class logicalANDExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public logicalANDExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class logicalORExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public logicalORExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class logicalORExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public logicalORExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class conditionalExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public conditionalExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class conditionalExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public conditionalExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class assignmentExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public assignmentExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class assignmentOperator_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public assignmentOperator_return(ES3Parser grammar)
    {
    }
  }

  private sealed class assignmentExpressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public assignmentExpressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class expression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public expression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class expressionNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Expression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public expressionNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class semic_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public semic_return(ES3Parser grammar)
    {
    }
  }

  private sealed class statement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public statement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class statementTail_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public statementTail_return(ES3Parser grammar)
    {
    }
  }

  private sealed class block_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public BlockStatement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public block_return(ES3Parser grammar)
    {
    }
  }

  private sealed class variableStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public variableStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class variableDeclaration_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public VariableDeclarationStatement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public variableDeclaration_return(ES3Parser grammar)
    {
    }
  }

  private sealed class variableDeclarationNoIn_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public VariableDeclarationStatement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public variableDeclarationNoIn_return(ES3Parser grammar)
    {
    }
  }

  private sealed class emptyStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public emptyStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class expressionStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public expressionStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class ifStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public ifStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class iterationStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public iterationStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class doStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public doStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class whileStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public whileStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class forStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public IForStatement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public forStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class forControl_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public IForStatement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public forControl_return(ES3Parser grammar)
    {
    }
  }

  private sealed class forControlVar_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public IForStatement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public forControlVar_return(ES3Parser grammar)
    {
    }
  }

  private sealed class forControlExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public IForStatement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public forControlExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class forControlSemic_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public ForStatement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public forControlSemic_return(ES3Parser grammar)
    {
    }
  }

  private sealed class continueStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public continueStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class breakStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public breakStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class returnStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public ReturnStatement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public returnStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class withStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public withStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class switchStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public switchStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class caseClause_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public CaseClause value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public caseClause_return(ES3Parser grammar)
    {
    }
  }

  private sealed class defaultClause_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public BlockStatement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public defaultClause_return(ES3Parser grammar)
    {
    }
  }

  private sealed class labelledStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public labelledStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class throwStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public throwStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class tryStatement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public TryStatement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public tryStatement_return(ES3Parser grammar)
    {
    }
  }

  private sealed class catchClause_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public CatchClause value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public catchClause_return(ES3Parser grammar)
    {
    }
  }

  private sealed class finallyClause_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public FinallyClause value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public finallyClause_return(ES3Parser grammar)
    {
    }
  }

  private sealed class functionDeclaration_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public functionDeclaration_return(ES3Parser grammar)
    {
    }
  }

  private sealed class functionExpression_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public FunctionExpression value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public functionExpression_return(ES3Parser grammar)
    {
    }
  }

  private sealed class formalParameterList_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public List<string> value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public formalParameterList_return(ES3Parser grammar)
    {
    }
  }

  private sealed class functionBody_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public BlockStatement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public functionBody_return(ES3Parser grammar)
    {
    }
  }

  public sealed class program_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Program value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public program_return(ES3Parser grammar)
    {
    }
  }

  private sealed class sourceElement_return : ParserRuleReturnScope<IToken>, IAstRuleReturnScope<object>, IAstRuleReturnScope, IRuleReturnScope
  {
    public Statement value;
    private object _tree;

    public object Tree
    {
      get
      {
        return this._tree;
      }
      set
      {
        this._tree = value;
      }
    }

    object IAstRuleReturnScope.Tree
    {
      get
      {
        return this.Tree;
      }
    }

    public sourceElement_return(ES3Parser grammar)
    {
    }
  }

  private class DFA57 : DFA
  {
    private static readonly string[] DFA57_transitionS = new string[40]{ "\x0001\x0003\b\xFFFF\x0001\x0003\x000E\xFFFF\x0001\x0003\x0003\xFFFF\x0001\x0003\x0001\xFFFF\x0001\x0003\x0002\xFFFF\x0001\x0003\x0005\xFFFF\x0001\x0003\t\xFFFF\x0001\x0003\x0004\xFFFF\x0001\x0003\x0002\xFFFF\x0001\x0002\x0005\xFFFF\x0002\x0003\x0003\xFFFF\x0001\x0003\x0003\xFFFF\x0001\x0003\x0001\xFFFF\x0001\x0003\x0005\xFFFF\x0001\x0001\x0001\x0003\x0003\xFFFF\x0001\x0003\x000E\xFFFF\x0002\x0003\x0001\xFFFF\x0001\x0003\x0005\xFFFF\x0001\x0003\f\xFFFF\x0001\x0003\x0003\xFFFF\x0001\x0003\x0001\xFFFF\x0001\x0003\n\xFFFF\x0001\x0003\x0002\xFFFF\x0001\x0003\x0002\xFFFF\x0001\x0003\x0001\xFFFF\x0002\x0003\x0002\xFFFF\x0003\x0003\x0002\xFFFF\x0002\x0003\x0002\xFFFF\x0002\x0003", "\x0001\xFFFF", "\x0001\xFFFF", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
    private static readonly short[] DFA57_eot = DFA.UnpackEncodedString("(\xFFFF");
    private static readonly short[] DFA57_eof = DFA.UnpackEncodedString("(\xFFFF");
    private static readonly char[] DFA57_min = DFA.UnpackEncodedStringToUnsignedChars("\x0001\x0005\x0002\0%\xFFFF");
    private static readonly char[] DFA57_max = DFA.UnpackEncodedStringToUnsignedChars("\x0001¦\x0002\0%\xFFFF");
    private static readonly short[] DFA57_accept = DFA.UnpackEncodedString("\x0003\xFFFF\x0001\x0003\"\xFFFF\x0001\x0001\x0001\x0002");
    private static readonly short[] DFA57_special = DFA.UnpackEncodedString("\x0001\xFFFF\x0001\0\x0001\x0001%\xFFFF}>");
    private const string DFA57_eotS = "(\xFFFF";
    private const string DFA57_eofS = "(\xFFFF";
    private const string DFA57_minS = "\x0001\x0005\x0002\0%\xFFFF";
    private const string DFA57_maxS = "\x0001¦\x0002\0%\xFFFF";
    private const string DFA57_acceptS = "\x0003\xFFFF\x0001\x0003\"\xFFFF\x0001\x0001\x0001\x0002";
    private const string DFA57_specialS = "\x0001\xFFFF\x0001\0\x0001\x0001%\xFFFF}>";
    private static readonly short[][] DFA57_transition;

    static DFA57()
    {
      int length = ES3Parser.DFA57.DFA57_transitionS.Length;
      ES3Parser.DFA57.DFA57_transition = new short[length][];
      for (int index = 0; index < length; ++index)
        ES3Parser.DFA57.DFA57_transition[index] = DFA.UnpackEncodedString(ES3Parser.DFA57.DFA57_transitionS[index]);
    }

    public DFA57(
      BaseRecognizer recognizer,
      SpecialStateTransitionHandler specialStateTransition)
      : base(specialStateTransition)
    {
      this.recognizer = recognizer;
      this.decisionNumber = 57;
      this.eot = ES3Parser.DFA57.DFA57_eot;
      this.eof = ES3Parser.DFA57.DFA57_eof;
      this.min = ES3Parser.DFA57.DFA57_min;
      this.max = ES3Parser.DFA57.DFA57_max;
      this.accept = ES3Parser.DFA57.DFA57_accept;
      this.special = ES3Parser.DFA57.DFA57_special;
      this.transition = ES3Parser.DFA57.DFA57_transition;
    }

    public override string Description
    {
      get
      {
        return "1420:1: statement returns [Statement value] options {k=1; } : ({...}? block |{...}?func= functionDeclaration | statementTail );";
      }
    }

    public override void Error(NoViableAltException nvae)
    {
    }
  }

  private class DFA58 : DFA
  {
    private static readonly string[] DFA58_transitionS = new string[15]{ "\x0001\x0003\b\xFFFF\x0001\b\x000E\xFFFF\x0001\a\x0003\xFFFF\x0001\x0003\x0001\xFFFF\x0001\x0003\x0002\xFFFF\x0001\x0006\x0005\xFFFF\x0001\x0003\t\xFFFF\x0001\x0003\x0004\xFFFF\x0001\x0006\x0002\xFFFF\x0001\x0003\x0005\xFFFF\x0001\x0003\x0001\x0005\x0003\xFFFF\x0001\x0003\x0003\xFFFF\x0001\x0003\x0001\xFFFF\x0001\x0004\x0005\xFFFF\x0002\x0003\x0003\xFFFF\x0001\x0003\x000E\xFFFF\x0002\x0003\x0001\xFFFF\x0001\x0003\x0005\xFFFF\x0001\x0003\f\xFFFF\x0001\t\x0003\xFFFF\x0001\x0003\x0001\xFFFF\x0001\x0002\n\xFFFF\x0001\x0003\x0002\xFFFF\x0001\v\x0002\xFFFF\x0001\x0003\x0001\xFFFF\x0001\x0003\x0001\f\x0002\xFFFF\x0001\x0003\x0001\r\x0001\x0003\x0002\xFFFF\x0001\x0001\x0001\x0003\x0002\xFFFF\x0001\x0006\x0001\n", "", "", "", "\x0004\x0003\x0002\xFFFF\x0001\x0003\x000E\xFFFF\x0001\x000E\x0001\x0003\x0005\xFFFF\x0001\x0003\x0002\xFFFF\x0002\x0003\x0001\xFFFF\x0001\x0003\a\xFFFF\x0002\x0003\x000F\xFFFF\x0002\x0003\x0006\xFFFF\x0003\x0003\t\xFFFF\x0003\x0003\x0002\xFFFF\x0002\x0003\x0001\xFFFF\x0002\x0003\x0001\xFFFF\x0005\x0003\x0004\xFFFF\x0001\x0003\x0002\xFFFF\x0001\x0003\x0002\xFFFF\x0002\x0003\f\xFFFF\x0002\x0003\x0006\xFFFF\x0004\x0003\x0001\xFFFF\x0004\x0003\x0003\xFFFF\x0002\x0003\x0016\xFFFF\x0002\x0003", "", "", "", "", "", "", "", "", "", "" };
    private static readonly short[] DFA58_eot = DFA.UnpackEncodedString("\x000F\xFFFF");
    private static readonly short[] DFA58_eof = DFA.UnpackEncodedString("\x0004\xFFFF\x0001\x0003\n\xFFFF");
    private static readonly char[] DFA58_min = DFA.UnpackEncodedStringToUnsignedChars("\x0001\x0005\x0003\xFFFF\x0001\x0005\n\xFFFF");
    private static readonly char[] DFA58_max = DFA.UnpackEncodedStringToUnsignedChars("\x0001¦\x0003\xFFFF\x0001©\n\xFFFF");
    private static readonly short[] DFA58_accept = DFA.UnpackEncodedString("\x0001\xFFFF\x0001\x0001\x0001\x0002\x0001\x0003\x0001\xFFFF\x0001\x0004\x0001\x0005\x0001\x0006\x0001\a\x0001\b\x0001\t\x0001\v\x0001\f\x0001\r\x0001\n");
    private static readonly short[] DFA58_special = DFA.UnpackEncodedString("\x000F\xFFFF}>");
    private const string DFA58_eotS = "\x000F\xFFFF";
    private const string DFA58_eofS = "\x0004\xFFFF\x0001\x0003\n\xFFFF";
    private const string DFA58_minS = "\x0001\x0005\x0003\xFFFF\x0001\x0005\n\xFFFF";
    private const string DFA58_maxS = "\x0001¦\x0003\xFFFF\x0001©\n\xFFFF";
    private const string DFA58_acceptS = "\x0001\xFFFF\x0001\x0001\x0001\x0002\x0001\x0003\x0001\xFFFF\x0001\x0004\x0001\x0005\x0001\x0006\x0001\a\x0001\b\x0001\t\x0001\v\x0001\f\x0001\r\x0001\n";
    private const string DFA58_specialS = "\x000F\xFFFF}>";
    private static readonly short[][] DFA58_transition;

    static DFA58()
    {
      int length = ES3Parser.DFA58.DFA58_transitionS.Length;
      ES3Parser.DFA58.DFA58_transition = new short[length][];
      for (int index = 0; index < length; ++index)
        ES3Parser.DFA58.DFA58_transition[index] = DFA.UnpackEncodedString(ES3Parser.DFA58.DFA58_transitionS[index]);
    }

    public DFA58(BaseRecognizer recognizer)
    {
      this.recognizer = recognizer;
      this.decisionNumber = 58;
      this.eot = ES3Parser.DFA58.DFA58_eot;
      this.eof = ES3Parser.DFA58.DFA58_eof;
      this.min = ES3Parser.DFA58.DFA58_min;
      this.max = ES3Parser.DFA58.DFA58_max;
      this.accept = ES3Parser.DFA58.DFA58_accept;
      this.special = ES3Parser.DFA58.DFA58_special;
      this.transition = ES3Parser.DFA58.DFA58_transition;
    }

    public override string Description
    {
      get
      {
        return "1431:1: statementTail returns [Statement value] : ( variableStatement | emptyStatement | expressionStatement | ifStatement | iterationStatement | continueStatement | breakStatement | returnStatement | withStatement | labelledStatement | switchStatement | throwStatement | tryStatement );";
      }
    }

    public override void Error(NoViableAltException nvae)
    {
    }
  }

  private class DFA88 : DFA
  {
    private static readonly string[] DFA88_transitionS = new string[39]{ "\x0001\x0002\b\xFFFF\x0001\x0002\x000E\xFFFF\x0001\x0002\x0003\xFFFF\x0001\x0002\x0001\xFFFF\x0001\x0002\x0002\xFFFF\x0001\x0002\x0005\xFFFF\x0001\x0002\t\xFFFF\x0001\x0002\x0004\xFFFF\x0001\x0002\x0002\xFFFF\x0001\x0001\x0005\xFFFF\x0002\x0002\x0003\xFFFF\x0001\x0002\x0003\xFFFF\x0001\x0002\x0001\xFFFF\x0001\x0002\x0005\xFFFF\x0002\x0002\x0003\xFFFF\x0001\x0002\x000E\xFFFF\x0002\x0002\x0001\xFFFF\x0001\x0002\x0005\xFFFF\x0001\x0002\f\xFFFF\x0001\x0002\x0003\xFFFF\x0001\x0002\x0001\xFFFF\x0001\x0002\n\xFFFF\x0001\x0002\x0002\xFFFF\x0001\x0002\x0002\xFFFF\x0001\x0002\x0001\xFFFF\x0002\x0002\x0002\xFFFF\x0003\x0002\x0002\xFFFF\x0002\x0002\x0002\xFFFF\x0002\x0002", "\x0001\xFFFF", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
    private static readonly short[] DFA88_eot = DFA.UnpackEncodedString("'\xFFFF");
    private static readonly short[] DFA88_eof = DFA.UnpackEncodedString("'\xFFFF");
    private static readonly char[] DFA88_min = DFA.UnpackEncodedStringToUnsignedChars("\x0001\x0005\x0001\0%\xFFFF");
    private static readonly char[] DFA88_max = DFA.UnpackEncodedStringToUnsignedChars("\x0001¦\x0001\0%\xFFFF");
    private static readonly short[] DFA88_accept = DFA.UnpackEncodedString("\x0002\xFFFF\x0001\x0002#\xFFFF\x0001\x0001");
    private static readonly short[] DFA88_special = DFA.UnpackEncodedString("\x0001\xFFFF\x0001\0%\xFFFF}>");
    private const string DFA88_eotS = "'\xFFFF";
    private const string DFA88_eofS = "'\xFFFF";
    private const string DFA88_minS = "\x0001\x0005\x0001\0%\xFFFF";
    private const string DFA88_maxS = "\x0001¦\x0001\0%\xFFFF";
    private const string DFA88_acceptS = "\x0002\xFFFF\x0001\x0002#\xFFFF\x0001\x0001";
    private const string DFA88_specialS = "\x0001\xFFFF\x0001\0%\xFFFF}>";
    private static readonly short[][] DFA88_transition;

    static DFA88()
    {
      int length = ES3Parser.DFA88.DFA88_transitionS.Length;
      ES3Parser.DFA88.DFA88_transition = new short[length][];
      for (int index = 0; index < length; ++index)
        ES3Parser.DFA88.DFA88_transition[index] = DFA.UnpackEncodedString(ES3Parser.DFA88.DFA88_transitionS[index]);
    }

    public DFA88(
      BaseRecognizer recognizer,
      SpecialStateTransitionHandler specialStateTransition)
      : base(specialStateTransition)
    {
      this.recognizer = recognizer;
      this.decisionNumber = 88;
      this.eot = ES3Parser.DFA88.DFA88_eot;
      this.eof = ES3Parser.DFA88.DFA88_eof;
      this.min = ES3Parser.DFA88.DFA88_min;
      this.max = ES3Parser.DFA88.DFA88_max;
      this.accept = ES3Parser.DFA88.DFA88_accept;
      this.special = ES3Parser.DFA88.DFA88_special;
      this.transition = ES3Parser.DFA88.DFA88_transition;
    }

    public override string Description
    {
      get
      {
        return "1909:1: sourceElement returns [Statement value] options {k=1; } : ({...}?func= functionDeclaration |stat= statement );";
      }
    }

    public override void Error(NoViableAltException nvae)
    {
    }
  }

  private static class Follow
  {
    public static readonly BitSet _reservedWord_in_token1748 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _Identifier_in_token1753 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _punctuator_in_token1758 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _numericLiteral_in_token1763 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _StringLiteral_in_token1768 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _keyword_in_reservedWord1781 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _futureReservedWord_in_reservedWord1786 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _NULL_in_reservedWord1791 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _booleanLiteral_in_reservedWord1796 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _set_in_keyword1810 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _set_in_futureReservedWord1945 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _set_in_punctuator2225 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _NULL_in_literal2483 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _booleanLiteral_in_literal2492 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _numericLiteral_in_literal2501 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _StringLiteral_in_literal2510 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _RegularExpressionLiteral_in_literal2520 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _TRUE_in_booleanLiteral2537 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _FALSE_in_booleanLiteral2544 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _DecimalLiteral_in_numericLiteral2755 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _OctalIntegerLiteral_in_numericLiteral2764 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _HexIntegerLiteral_in_numericLiteral2773 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _THIS_in_primaryExpression3175 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _Identifier_in_primaryExpression3184 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _literal_in_primaryExpression3193 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _arrayLiteral_in_primaryExpression3202 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _objectLiteral_in_primaryExpression3211 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _LPAREN_in_primaryExpression3220 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_primaryExpression3224 = new BitSet(new ulong[3]{ 0UL, 0UL, 1UL });
    public static readonly BitSet _RPAREN_in_primaryExpression3227 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _LBRACK_in_arrayLiteral3253 = new BitSet(new ulong[3]{ 4629718052206805024UL, 4612836107663483408UL, 18543083528UL });
    public static readonly BitSet _arrayItem_in_arrayLiteral3259 = new BitSet(new ulong[2]{ 134217728UL, 4611686018427387904UL });
    public static readonly BitSet _COMMA_in_arrayLiteral3265 = new BitSet(new ulong[3]{ 4629718052206805024UL, 4612836107663483408UL, 18543083528UL });
    public static readonly BitSet _arrayItem_in_arrayLiteral3269 = new BitSet(new ulong[2]{ 134217728UL, 4611686018427387904UL });
    public static readonly BitSet _RBRACK_in_arrayLiteral3279 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _assignmentExpression_in_arrayItem3300 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _LBRACE_in_objectLiteral3341 = new BitSet(new ulong[3]{ 17592186044416UL, 2306968909120569360UL, 4194304UL });
    public static readonly BitSet _propertyAssignment_in_objectLiteral3347 = new BitSet(new ulong[2]{ 134217728UL, 2305843009213693952UL });
    public static readonly BitSet _COMMA_in_objectLiteral3354 = new BitSet(new ulong[3]{ 17592186044416UL, 1125899906875408UL, 4194304UL });
    public static readonly BitSet _propertyAssignment_in_objectLiteral3358 = new BitSet(new ulong[2]{ 134217728UL, 2305843009213693952UL });
    public static readonly BitSet _RBRACE_in_objectLiteral3368 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _accessor_in_propertyAssignment3391 = new BitSet(new ulong[3]{ 17592186044416UL, 1125899906875408UL, 4194304UL });
    public static readonly BitSet _propertyName_in_propertyAssignment3399 = new BitSet(new ulong[2]{ 0UL, 69206016UL });
    public static readonly BitSet _formalParameterList_in_propertyAssignment3406 = new BitSet(new ulong[2]{ 0UL, 69206016UL });
    public static readonly BitSet _functionBody_in_propertyAssignment3414 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _propertyName_in_propertyAssignment3424 = new BitSet(new ulong[1]{ 67108864UL });
    public static readonly BitSet _COLON_in_propertyAssignment3428 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _assignmentExpression_in_propertyAssignment3432 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _Identifier_in_accessor3452 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _Identifier_in_propertyName3474 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _StringLiteral_in_propertyName3483 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _numericLiteral_in_propertyName3492 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _primaryExpression_in_memberExpression3518 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _functionExpression_in_memberExpression3527 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _newExpression_in_memberExpression3536 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _NEW_in_newExpression3553 = new BitSet(new ulong[3]{ 4629718009122914304UL, 1145691189575696UL, 289406984UL });
    public static readonly BitSet _memberExpression_in_newExpression3558 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _LPAREN_in_arguments3581 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083529UL });
    public static readonly BitSet _assignmentExpression_in_arguments3587 = new BitSet(new ulong[3]{ 134217728UL, 0UL, 1UL });
    public static readonly BitSet _COMMA_in_arguments3593 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _assignmentExpression_in_arguments3597 = new BitSet(new ulong[3]{ 134217728UL, 0UL, 1UL });
    public static readonly BitSet _RPAREN_in_arguments3606 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _LBRACE_in_generics3628 = new BitSet(new ulong[3]{ 4629718052072587296UL, 2306993098449789456UL, 18543083528UL });
    public static readonly BitSet _assignmentExpression_in_generics3634 = new BitSet(new ulong[2]{ 134217728UL, 2305843009213693952UL });
    public static readonly BitSet _COMMA_in_generics3640 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _assignmentExpression_in_generics3644 = new BitSet(new ulong[2]{ 134217728UL, 2305843009213693952UL });
    public static readonly BitSet _RBRACE_in_generics3653 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _memberExpression_in_leftHandSideExpression3689 = new BitSet(new ulong[2]{ 549755813890UL, 73400320UL });
    public static readonly BitSet _generics_in_leftHandSideExpression3705 = new BitSet(new ulong[2]{ 0UL, 69206016UL });
    public static readonly BitSet _arguments_in_leftHandSideExpression3714 = new BitSet(new ulong[2]{ 549755813890UL, 73400320UL });
    public static readonly BitSet _LBRACK_in_leftHandSideExpression3725 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_leftHandSideExpression3729 = new BitSet(new ulong[2]{ 0UL, 4611686018427387904UL });
    public static readonly BitSet _RBRACK_in_leftHandSideExpression3731 = new BitSet(new ulong[2]{ 549755813890UL, 73400320UL });
    public static readonly BitSet _DOT_in_leftHandSideExpression3744 = new BitSet(new ulong[2]{ 0UL, 32768UL });
    public static readonly BitSet _Identifier_in_leftHandSideExpression3748 = new BitSet(new ulong[2]{ 549755813890UL, 73400320UL });
    public static readonly BitSet _leftHandSideExpression_in_postfixExpression3782 = new BitSet(new ulong[2]{ 8589934594UL, 512UL });
    public static readonly BitSet _postfixOperator_in_postfixExpression3790 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _INC_in_postfixOperator3813 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _DEC_in_postfixOperator3822 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _postfixExpression_in_unaryExpression3845 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _unaryOperator_in_unaryExpression3854 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _unaryExpression_in_unaryExpression3859 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _DELETE_in_unaryOperator3877 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _VOID_in_unaryOperator3884 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _TYPEOF_in_unaryOperator3891 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _INC_in_unaryOperator3898 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _DEC_in_unaryOperator3905 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _ADD_in_unaryOperator3914 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _SUB_in_unaryOperator3923 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _INV_in_unaryOperator3930 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _NOT_in_unaryOperator3937 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _unaryExpression_in_multiplicativeExpression3965 = new BitSet(new ulong[2]{ 68719476738UL, 10737418240UL });
    public static readonly BitSet _MUL_in_multiplicativeExpression3976 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _DIV_in_multiplicativeExpression3985 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _MOD_in_multiplicativeExpression3993 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _unaryExpression_in_multiplicativeExpression4004 = new BitSet(new ulong[2]{ 68719476738UL, 10737418240UL });
    public static readonly BitSet _multiplicativeExpression_in_additiveExpression4034 = new BitSet(new ulong[3]{ 34UL, 0UL, 65536UL });
    public static readonly BitSet _ADD_in_additiveExpression4045 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _SUB_in_additiveExpression4053 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _multiplicativeExpression_in_additiveExpression4064 = new BitSet(new ulong[3]{ 34UL, 0UL, 65536UL });
    public static readonly BitSet _additiveExpression_in_shiftExpression4095 = new BitSet(new ulong[3]{ 2UL, 0UL, 2624UL });
    public static readonly BitSet _SHL_in_shiftExpression4106 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _SHR_in_shiftExpression4114 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _SHU_in_shiftExpression4122 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _additiveExpression_in_shiftExpression4133 = new BitSet(new ulong[3]{ 2UL, 0UL, 2624UL });
    public static readonly BitSet _shiftExpression_in_relationalExpression4164 = new BitSet(new ulong[2]{ 2UL, 805307651UL });
    public static readonly BitSet _LT_in_relationalExpression4175 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _GT_in_relationalExpression4183 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _LTE_in_relationalExpression4191 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _GTE_in_relationalExpression4199 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _INSTANCEOF_in_relationalExpression4207 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _IN_in_relationalExpression4215 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _shiftExpression_in_relationalExpression4226 = new BitSet(new ulong[2]{ 2UL, 805307651UL });
    public static readonly BitSet _shiftExpression_in_relationalExpressionNoIn4252 = new BitSet(new ulong[2]{ 2UL, 805307395UL });
    public static readonly BitSet _LT_in_relationalExpressionNoIn4263 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _GT_in_relationalExpressionNoIn4271 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _LTE_in_relationalExpressionNoIn4279 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _GTE_in_relationalExpressionNoIn4287 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _INSTANCEOF_in_relationalExpressionNoIn4295 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _shiftExpression_in_relationalExpressionNoIn4307 = new BitSet(new ulong[2]{ 2UL, 805307395UL });
    public static readonly BitSet _relationalExpression_in_equalityExpression4338 = new BitSet(new ulong[3]{ 281474976710658UL, 9895604649984UL, 16UL });
    public static readonly BitSet _EQ_in_equalityExpression4349 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _NEQ_in_equalityExpression4357 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _SAME_in_equalityExpression4365 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _NSAME_in_equalityExpression4373 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _relationalExpression_in_equalityExpression4384 = new BitSet(new ulong[3]{ 281474976710658UL, 9895604649984UL, 16UL });
    public static readonly BitSet _relationalExpressionNoIn_in_equalityExpressionNoIn4410 = new BitSet(new ulong[3]{ 281474976710658UL, 9895604649984UL, 16UL });
    public static readonly BitSet _EQ_in_equalityExpressionNoIn4421 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _NEQ_in_equalityExpressionNoIn4429 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _SAME_in_equalityExpressionNoIn4437 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _NSAME_in_equalityExpressionNoIn4445 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _relationalExpressionNoIn_in_equalityExpressionNoIn4456 = new BitSet(new ulong[3]{ 281474976710658UL, 9895604649984UL, 16UL });
    public static readonly BitSet _equalityExpression_in_bitwiseANDExpression4483 = new BitSet(new ulong[1]{ 130UL });
    public static readonly BitSet _AND_in_bitwiseANDExpression4489 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _equalityExpression_in_bitwiseANDExpression4494 = new BitSet(new ulong[1]{ 130UL });
    public static readonly BitSet _equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4515 = new BitSet(new ulong[1]{ 130UL });
    public static readonly BitSet _AND_in_bitwiseANDExpressionNoIn4521 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _equalityExpressionNoIn_in_bitwiseANDExpressionNoIn4526 = new BitSet(new ulong[1]{ 130UL });
    public static readonly BitSet _bitwiseANDExpression_in_bitwiseXORExpression4549 = new BitSet(new ulong[3]{ 2UL, 0UL, 1099511627776UL });
    public static readonly BitSet _XOR_in_bitwiseXORExpression4555 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _bitwiseANDExpression_in_bitwiseXORExpression4560 = new BitSet(new ulong[3]{ 2UL, 0UL, 1099511627776UL });
    public static readonly BitSet _bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4583 = new BitSet(new ulong[3]{ 2UL, 0UL, 1099511627776UL });
    public static readonly BitSet _XOR_in_bitwiseXORExpressionNoIn4589 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _bitwiseANDExpressionNoIn_in_bitwiseXORExpressionNoIn4594 = new BitSet(new ulong[3]{ 2UL, 0UL, 1099511627776UL });
    public static readonly BitSet _bitwiseXORExpression_in_bitwiseORExpression4616 = new BitSet(new ulong[2]{ 2UL, 70368744177664UL });
    public static readonly BitSet _OR_in_bitwiseORExpression4622 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _bitwiseXORExpression_in_bitwiseORExpression4627 = new BitSet(new ulong[2]{ 2UL, 70368744177664UL });
    public static readonly BitSet _bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4649 = new BitSet(new ulong[2]{ 2UL, 70368744177664UL });
    public static readonly BitSet _OR_in_bitwiseORExpressionNoIn4655 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _bitwiseXORExpressionNoIn_in_bitwiseORExpressionNoIn4660 = new BitSet(new ulong[2]{ 2UL, 70368744177664UL });
    public static readonly BitSet _bitwiseORExpression_in_logicalANDExpression4686 = new BitSet(new ulong[2]{ 2UL, 1048576UL });
    public static readonly BitSet _LAND_in_logicalANDExpression4692 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _bitwiseORExpression_in_logicalANDExpression4697 = new BitSet(new ulong[2]{ 2UL, 1048576UL });
    public static readonly BitSet _bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4718 = new BitSet(new ulong[2]{ 2UL, 1048576UL });
    public static readonly BitSet _LAND_in_logicalANDExpressionNoIn4724 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _bitwiseORExpressionNoIn_in_logicalANDExpressionNoIn4729 = new BitSet(new ulong[2]{ 2UL, 1048576UL });
    public static readonly BitSet _logicalANDExpression_in_logicalORExpression4751 = new BitSet(new ulong[2]{ 2UL, 33554432UL });
    public static readonly BitSet _LOR_in_logicalORExpression4757 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _logicalANDExpression_in_logicalORExpression4762 = new BitSet(new ulong[2]{ 2UL, 33554432UL });
    public static readonly BitSet _logicalANDExpressionNoIn_in_logicalORExpressionNoIn4784 = new BitSet(new ulong[2]{ 2UL, 33554432UL });
    public static readonly BitSet _LOR_in_logicalORExpressionNoIn4790 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _logicalANDExpressionNoIn_in_logicalORExpressionNoIn4795 = new BitSet(new ulong[2]{ 2UL, 33554432UL });
    public static readonly BitSet _logicalORExpression_in_conditionalExpression4822 = new BitSet(new ulong[2]{ 2UL, 1152921504606846976UL });
    public static readonly BitSet _QUE_in_conditionalExpression4828 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _assignmentExpression_in_conditionalExpression4833 = new BitSet(new ulong[1]{ 67108864UL });
    public static readonly BitSet _COLON_in_conditionalExpression4835 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _assignmentExpression_in_conditionalExpression4840 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _logicalORExpressionNoIn_in_conditionalExpressionNoIn4861 = new BitSet(new ulong[2]{ 2UL, 1152921504606846976UL });
    public static readonly BitSet _QUE_in_conditionalExpressionNoIn4867 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _assignmentExpressionNoIn_in_conditionalExpressionNoIn4872 = new BitSet(new ulong[1]{ 67108864UL });
    public static readonly BitSet _COLON_in_conditionalExpressionNoIn4874 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _assignmentExpressionNoIn_in_conditionalExpressionNoIn4879 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _conditionalExpression_in_assignmentExpression4912 = new BitSet(new ulong[3]{ 137438955842UL, 140758963191808UL, 2199023391872UL });
    public static readonly BitSet _assignmentOperator_in_assignmentExpression4924 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _assignmentExpression_in_assignmentExpression4931 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _set_in_assignmentOperator4946 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _conditionalExpressionNoIn_in_assignmentExpressionNoIn5026 = new BitSet(new ulong[3]{ 137438955842UL, 140758963191808UL, 2199023391872UL });
    public static readonly BitSet _assignmentOperator_in_assignmentExpressionNoIn5038 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _assignmentExpressionNoIn_in_assignmentExpressionNoIn5045 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _assignmentExpression_in_expression5077 = new BitSet(new ulong[1]{ 134217730UL });
    public static readonly BitSet _COMMA_in_expression5083 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _assignmentExpression_in_expression5089 = new BitSet(new ulong[1]{ 134217730UL });
    public static readonly BitSet _assignmentExpressionNoIn_in_expressionNoIn5117 = new BitSet(new ulong[1]{ 134217730UL });
    public static readonly BitSet _COMMA_in_expressionNoIn5123 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _assignmentExpressionNoIn_in_expressionNoIn5129 = new BitSet(new ulong[1]{ 134217730UL });
    public static readonly BitSet _SEMIC_in_semic5163 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _EOF_in_semic5168 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _RBRACE_in_semic5173 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _EOL_in_semic5180 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _MultiLineComment_in_semic5184 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _block_in_statement5218 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _functionDeclaration_in_statement5229 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _statementTail_in_statement5236 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _variableStatement_in_statementTail5259 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _emptyStatement_in_statementTail5266 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _expressionStatement_in_statementTail5273 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _ifStatement_in_statementTail5280 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _iterationStatement_in_statementTail5287 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _continueStatement_in_statementTail5294 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _breakStatement_in_statementTail5301 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _returnStatement_in_statementTail5308 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _withStatement_in_statementTail5315 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _labelledStatement_in_statementTail5322 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _switchStatement_in_statementTail5329 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _throwStatement_in_statementTail5336 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _tryStatement_in_statementTail5343 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _LBRACE_in_block5373 = new BitSet(new ulong[3]{ 5206179079790805024UL, 11530365135304565296UL, 440020828200UL });
    public static readonly BitSet _statement_in_block5376 = new BitSet(new ulong[3]{ 5206179079790805024UL, 11530365135304565296UL, 440020828200UL });
    public static readonly BitSet _RBRACE_in_block5382 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _VAR_in_variableStatement5412 = new BitSet(new ulong[2]{ 0UL, 32768UL });
    public static readonly BitSet _variableDeclaration_in_variableStatement5416 = new BitSet(new ulong[3]{ 140737622573056UL, 2305843043573432320UL, 32UL });
    public static readonly BitSet _COMMA_in_variableStatement5422 = new BitSet(new ulong[2]{ 0UL, 32768UL });
    public static readonly BitSet _variableDeclaration_in_variableStatement5428 = new BitSet(new ulong[3]{ 140737622573056UL, 2305843043573432320UL, 32UL });
    public static readonly BitSet _semic_in_variableStatement5436 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _Identifier_in_variableDeclaration5460 = new BitSet(new ulong[1]{ 2050UL });
    public static readonly BitSet _ASSIGN_in_variableDeclaration5466 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _assignmentExpression_in_variableDeclaration5471 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _Identifier_in_variableDeclarationNoIn5499 = new BitSet(new ulong[1]{ 2050UL });
    public static readonly BitSet _ASSIGN_in_variableDeclarationNoIn5505 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _assignmentExpressionNoIn_in_variableDeclarationNoIn5510 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _SEMIC_in_emptyStatement5535 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _expression_in_expressionStatement5560 = new BitSet(new ulong[3]{ 140737622573056UL, 2305843043573432320UL, 32UL });
    public static readonly BitSet _semic_in_expressionStatement5562 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _IF_in_ifStatement5591 = new BitSet(new ulong[2]{ 0UL, 67108864UL });
    public static readonly BitSet _LPAREN_in_ifStatement5593 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_ifStatement5595 = new BitSet(new ulong[3]{ 0UL, 0UL, 1UL });
    public static readonly BitSet _RPAREN_in_ifStatement5599 = new BitSet(new ulong[3]{ 5206179079790805024UL, 9224522126090871344UL, 440020828200UL });
    public static readonly BitSet _statement_in_ifStatement5603 = new BitSet(new ulong[1]{ 35184372088834UL });
    public static readonly BitSet _ELSE_in_ifStatement5611 = new BitSet(new ulong[3]{ 5206179079790805024UL, 9224522126090871344UL, 440020828200UL });
    public static readonly BitSet _statement_in_ifStatement5615 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _doStatement_in_iterationStatement5645 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _whileStatement_in_iterationStatement5654 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _forStatement_in_iterationStatement5664 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _DO_in_doStatement5683 = new BitSet(new ulong[3]{ 5206179079790805024UL, 9224522126090871344UL, 440020828200UL });
    public static readonly BitSet _statement_in_doStatement5685 = new BitSet(new ulong[3]{ 0UL, 0UL, 137438953472UL });
    public static readonly BitSet _WHILE_in_doStatement5687 = new BitSet(new ulong[2]{ 0UL, 67108864UL });
    public static readonly BitSet _LPAREN_in_doStatement5689 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_doStatement5691 = new BitSet(new ulong[3]{ 0UL, 0UL, 1UL });
    public static readonly BitSet _RPAREN_in_doStatement5693 = new BitSet(new ulong[3]{ 140737622573056UL, 2305843043573432320UL, 32UL });
    public static readonly BitSet _semic_in_doStatement5695 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _WHILE_in_whileStatement5715 = new BitSet(new ulong[2]{ 0UL, 67108864UL });
    public static readonly BitSet _LPAREN_in_whileStatement5718 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_whileStatement5721 = new BitSet(new ulong[3]{ 0UL, 0UL, 1UL });
    public static readonly BitSet _RPAREN_in_whileStatement5723 = new BitSet(new ulong[3]{ 5206179079790805024UL, 9224522126090871344UL, 440020828200UL });
    public static readonly BitSet _statement_in_whileStatement5726 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _FOR_in_forStatement5745 = new BitSet(new ulong[2]{ 0UL, 67108864UL });
    public static readonly BitSet _LPAREN_in_forStatement5748 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 27133018152UL });
    public static readonly BitSet _forControl_in_forStatement5753 = new BitSet(new ulong[3]{ 0UL, 0UL, 1UL });
    public static readonly BitSet _RPAREN_in_forStatement5758 = new BitSet(new ulong[3]{ 5206179079790805024UL, 9224522126090871344UL, 440020828200UL });
    public static readonly BitSet _statement_in_forStatement5763 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _forControlVar_in_forControl5782 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _forControlExpression_in_forControl5791 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _forControlSemic_in_forControl5800 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _VAR_in_forControlVar5828 = new BitSet(new ulong[2]{ 0UL, 32768UL });
    public static readonly BitSet _variableDeclarationNoIn_in_forControlVar5832 = new BitSet(new ulong[3]{ 134217728UL, 256UL, 32UL });
    public static readonly BitSet _IN_in_forControlVar5846 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_forControlVar5850 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _COMMA_in_forControlVar5875 = new BitSet(new ulong[2]{ 0UL, 32768UL });
    public static readonly BitSet _variableDeclarationNoIn_in_forControlVar5881 = new BitSet(new ulong[3]{ 134217728UL, 0UL, 32UL });
    public static readonly BitSet _SEMIC_in_forControlVar5892 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083560UL });
    public static readonly BitSet _expression_in_forControlVar5898 = new BitSet(new ulong[3]{ 0UL, 0UL, 32UL });
    public static readonly BitSet _SEMIC_in_forControlVar5906 = new BitSet(new ulong[3]{ 4629718052072587298UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_forControlVar5911 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _expressionNoIn_in_forControlExpression5950 = new BitSet(new ulong[3]{ 0UL, 256UL, 32UL });
    public static readonly BitSet _IN_in_forControlExpression5967 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_forControlExpression5971 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _SEMIC_in_forControlExpression5994 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083560UL });
    public static readonly BitSet _expression_in_forControlExpression6000 = new BitSet(new ulong[3]{ 0UL, 0UL, 32UL });
    public static readonly BitSet _SEMIC_in_forControlExpression6008 = new BitSet(new ulong[3]{ 4629718052072587298UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_forControlExpression6013 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _SEMIC_in_forControlSemic6049 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083560UL });
    public static readonly BitSet _expression_in_forControlSemic6055 = new BitSet(new ulong[3]{ 0UL, 0UL, 32UL });
    public static readonly BitSet _SEMIC_in_forControlSemic6063 = new BitSet(new ulong[3]{ 4629718052072587298UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_forControlSemic6068 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _CONTINUE_in_continueStatement6102 = new BitSet(new ulong[3]{ 140737622573056UL, 2305843043573465088UL, 32UL });
    public static readonly BitSet _Identifier_in_continueStatement6110 = new BitSet(new ulong[3]{ 140737622573056UL, 2305843043573432320UL, 32UL });
    public static readonly BitSet _semic_in_continueStatement6117 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _BREAK_in_breakStatement6147 = new BitSet(new ulong[3]{ 140737622573056UL, 2305843043573465088UL, 32UL });
    public static readonly BitSet _Identifier_in_breakStatement6155 = new BitSet(new ulong[3]{ 140737622573056UL, 2305843043573432320UL, 32UL });
    public static readonly BitSet _semic_in_breakStatement6162 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _RETURN_in_returnStatement6192 = new BitSet(new ulong[3]{ 4629858789695160352UL, 2306993132809527824UL, 18543083560UL });
    public static readonly BitSet _expression_in_returnStatement6200 = new BitSet(new ulong[3]{ 140737622573056UL, 2305843043573432320UL, 32UL });
    public static readonly BitSet _semic_in_returnStatement6206 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _WITH_in_withStatement6227 = new BitSet(new ulong[2]{ 0UL, 67108864UL });
    public static readonly BitSet _LPAREN_in_withStatement6230 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_withStatement6235 = new BitSet(new ulong[3]{ 0UL, 0UL, 1UL });
    public static readonly BitSet _RPAREN_in_withStatement6237 = new BitSet(new ulong[3]{ 5206179079790805024UL, 9224522126090871344UL, 440020828200UL });
    public static readonly BitSet _statement_in_withStatement6242 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _SWITCH_in_switchStatement6269 = new BitSet(new ulong[2]{ 0UL, 67108864UL });
    public static readonly BitSet _LPAREN_in_switchStatement6271 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_switchStatement6273 = new BitSet(new ulong[3]{ 0UL, 0UL, 1UL });
    public static readonly BitSet _RPAREN_in_switchStatement6277 = new BitSet(new ulong[2]{ 0UL, 2097152UL });
    public static readonly BitSet _LBRACE_in_switchStatement6282 = new BitSet(new ulong[2]{ 17181966336UL, 2305843009213693952UL });
    public static readonly BitSet _defaultClause_in_switchStatement6289 = new BitSet(new ulong[2]{ 17181966336UL, 2305843009213693952UL });
    public static readonly BitSet _caseClause_in_switchStatement6295 = new BitSet(new ulong[2]{ 17181966336UL, 2305843009213693952UL });
    public static readonly BitSet _RBRACE_in_switchStatement6302 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _CASE_in_caseClause6325 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_caseClause6328 = new BitSet(new ulong[1]{ 67108864UL });
    public static readonly BitSet _COLON_in_caseClause6332 = new BitSet(new ulong[3]{ 5206179079790805026UL, 9224522126090871344UL, 440020828200UL });
    public static readonly BitSet _statement_in_caseClause6336 = new BitSet(new ulong[3]{ 5206179079790805026UL, 9224522126090871344UL, 440020828200UL });
    public static readonly BitSet _DEFAULT_in_defaultClause6361 = new BitSet(new ulong[1]{ 67108864UL });
    public static readonly BitSet _COLON_in_defaultClause6364 = new BitSet(new ulong[3]{ 5206179079790805026UL, 9224522126090871344UL, 440020828200UL });
    public static readonly BitSet _statement_in_defaultClause6368 = new BitSet(new ulong[3]{ 5206179079790805026UL, 9224522126090871344UL, 440020828200UL });
    public static readonly BitSet _Identifier_in_labelledStatement6395 = new BitSet(new ulong[1]{ 67108864UL });
    public static readonly BitSet _COLON_in_labelledStatement6397 = new BitSet(new ulong[3]{ 5206179079790805024UL, 9224522126090871344UL, 440020828200UL });
    public static readonly BitSet _statement_in_labelledStatement6401 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _THROW_in_throwStatement6427 = new BitSet(new ulong[3]{ 4629718052072587296UL, 1150089236095504UL, 18543083528UL });
    public static readonly BitSet _expression_in_throwStatement6434 = new BitSet(new ulong[3]{ 140737622573056UL, 2305843043573432320UL, 32UL });
    public static readonly BitSet _semic_in_throwStatement6438 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _TRY_in_tryStatement6463 = new BitSet(new ulong[2]{ 0UL, 2097152UL });
    public static readonly BitSet _block_in_tryStatement6468 = new BitSet(new ulong[1]{ 144115188080050176UL });
    public static readonly BitSet _catchClause_in_tryStatement6477 = new BitSet(new ulong[1]{ 144115188080050178UL });
    public static readonly BitSet _finallyClause_in_tryStatement6484 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _finallyClause_in_tryStatement6494 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _CATCH_in_catchClause6514 = new BitSet(new ulong[2]{ 0UL, 67108864UL });
    public static readonly BitSet _LPAREN_in_catchClause6517 = new BitSet(new ulong[2]{ 0UL, 32768UL });
    public static readonly BitSet _Identifier_in_catchClause6522 = new BitSet(new ulong[3]{ 0UL, 0UL, 1UL });
    public static readonly BitSet _RPAREN_in_catchClause6524 = new BitSet(new ulong[2]{ 0UL, 2097152UL });
    public static readonly BitSet _block_in_catchClause6527 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _FINALLY_in_finallyClause6545 = new BitSet(new ulong[2]{ 0UL, 2097152UL });
    public static readonly BitSet _block_in_finallyClause6548 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _FUNCTION_in_functionDeclaration6580 = new BitSet(new ulong[2]{ 0UL, 32768UL });
    public static readonly BitSet _Identifier_in_functionDeclaration6585 = new BitSet(new ulong[2]{ 0UL, 67108864UL });
    public static readonly BitSet _formalParameterList_in_functionDeclaration6595 = new BitSet(new ulong[2]{ 0UL, 69206016UL });
    public static readonly BitSet _functionBody_in_functionDeclaration6604 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _FUNCTION_in_functionExpression6631 = new BitSet(new ulong[2]{ 0UL, 67141632UL });
    public static readonly BitSet _Identifier_in_functionExpression6636 = new BitSet(new ulong[2]{ 0UL, 67108864UL });
    public static readonly BitSet _formalParameterList_in_functionExpression6643 = new BitSet(new ulong[2]{ 0UL, 69206016UL });
    public static readonly BitSet _functionBody_in_functionExpression6647 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _LPAREN_in_formalParameterList6672 = new BitSet(new ulong[3]{ 0UL, 32768UL, 1UL });
    public static readonly BitSet _Identifier_in_formalParameterList6678 = new BitSet(new ulong[3]{ 134217728UL, 0UL, 1UL });
    public static readonly BitSet _COMMA_in_formalParameterList6684 = new BitSet(new ulong[2]{ 0UL, 32768UL });
    public static readonly BitSet _Identifier_in_formalParameterList6688 = new BitSet(new ulong[3]{ 134217728UL, 0UL, 1UL });
    public static readonly BitSet _RPAREN_in_formalParameterList6699 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _LBRACE_in_functionBody6726 = new BitSet(new ulong[3]{ 5206179079790805024UL, 11530365135304565296UL, 440020828200UL });
    public static readonly BitSet _sourceElement_in_functionBody6729 = new BitSet(new ulong[3]{ 5206179079790805024UL, 11530365135304565296UL, 440020828200UL });
    public static readonly BitSet _RBRACE_in_functionBody6736 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _sourceElement_in_program6765 = new BitSet(new ulong[3]{ 5206179079790805026UL, 9224522126090871344UL, 440020828200UL });
    public static readonly BitSet _functionDeclaration_in_sourceElement6806 = new BitSet(new ulong[1]{ 2UL });
    public static readonly BitSet _statement_in_sourceElement6815 = new BitSet(new ulong[1]{ 2UL });
  }
}
