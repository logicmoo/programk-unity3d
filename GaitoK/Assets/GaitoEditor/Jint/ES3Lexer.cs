// Decompiled with JetBrains decompiler
// Type: ES3Lexer
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Antlr.Runtime;
using System;
using System.CodeDom.Compiler;

[GeneratedCode("ANTLR", "3.3.1.7705")]
[CLSCompliant(false)]
public class ES3Lexer : Lexer
{
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
  private IToken last;
  private ES3Lexer.DFA18 dfa18;
  private ES3Lexer.DFA32 dfa32;

  private bool AreRegularExpressionsEnabled()
  {
    if (this.last == null)
      return true;
    switch (this.last.Type)
    {
      case 44:
      case 54:
      case 68:
      case 79:
      case 108:
      case 114:
      case 126:
      case 128:
      case 150:
      case 152:
      case 156:
        return false;
      default:
        return true;
    }
  }

  private void ConsumeIdentifierUnicodeStart()
  {
    if (!this.IsIdentifierStartUnicode(this.input.LA(1)))
      throw new NoViableAltException();
    this.MatchAny();
    while (true)
    {
      int ch = this.input.LA(1);
      if (ch == 36 || ch >= 48 && ch <= 57 || (ch >= 65 && ch <= 90 || (ch == 92 || ch == 95)) || ch >= 97 && ch <= 122 || this.IsIdentifierPartUnicode(ch))
        this.mIdentifierPart();
      else
        break;
    }
  }

  private bool IsIdentifierPartUnicode(int ch)
  {
    return char.IsLetterOrDigit((char) ch);
  }

  private bool IsIdentifierStartUnicode(int ch)
  {
    return char.IsLetter((char) ch);
  }

  public override IToken NextToken()
  {
    IToken token = base.NextToken();
    if (token.Channel == 0)
      this.last = token;
    return token;
  }

  public ES3Lexer()
  {
  }

  public ES3Lexer(ICharStream input)
    : this(input, new RecognizerSharedState())
  {
  }

  public ES3Lexer(ICharStream input, RecognizerSharedState state)
    : base(input, state)
  {
  }

  public override string GrammarFileName
  {
    get
    {
      return "C:\\Users\\sebros\\My Projects\\Jint\\Jint\\ES3.g";
    }
  }

  [GrammarRule("ABSTRACT")]
  private void mABSTRACT()
  {
    try
    {
      int num1 = 4;
      int num2 = 0;
      this.Match("abstract");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("ADD")]
  private void mADD()
  {
    try
    {
      int num1 = 5;
      int num2 = 0;
      this.Match(43);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("ADDASS")]
  private void mADDASS()
  {
    try
    {
      int num1 = 6;
      int num2 = 0;
      this.Match("+=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("AND")]
  private void mAND()
  {
    try
    {
      int num1 = 7;
      int num2 = 0;
      this.Match(38);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("ANDASS")]
  private void mANDASS()
  {
    try
    {
      int num1 = 8;
      int num2 = 0;
      this.Match("&=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("ASSIGN")]
  private void mASSIGN()
  {
    try
    {
      int num1 = 11;
      int num2 = 0;
      this.Match(61);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("BOOLEAN")]
  private void mBOOLEAN()
  {
    try
    {
      int num1 = 13;
      int num2 = 0;
      this.Match("boolean");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("BREAK")]
  private void mBREAK()
  {
    try
    {
      int num1 = 14;
      int num2 = 0;
      this.Match("break");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("BYTE")]
  private void mBYTE()
  {
    try
    {
      int num1 = 18;
      int num2 = 0;
      this.Match("byte");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("CASE")]
  private void mCASE()
  {
    try
    {
      int num1 = 21;
      int num2 = 0;
      this.Match("case");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("CATCH")]
  private void mCATCH()
  {
    try
    {
      int num1 = 22;
      int num2 = 0;
      this.Match("catch");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("CHAR")]
  private void mCHAR()
  {
    try
    {
      int num1 = 24;
      int num2 = 0;
      this.Match("char");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("CLASS")]
  private void mCLASS()
  {
    try
    {
      int num1 = 25;
      int num2 = 0;
      this.Match("class");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("COLON")]
  private void mCOLON()
  {
    try
    {
      int num1 = 26;
      int num2 = 0;
      this.Match(58);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("COMMA")]
  private void mCOMMA()
  {
    try
    {
      int num1 = 27;
      int num2 = 0;
      this.Match(44);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("CONST")]
  private void mCONST()
  {
    try
    {
      int num1 = 28;
      int num2 = 0;
      this.Match("const");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("CONTINUE")]
  private void mCONTINUE()
  {
    try
    {
      int num1 = 29;
      int num2 = 0;
      this.Match("continue");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("DEBUGGER")]
  private void mDEBUGGER()
  {
    try
    {
      int num1 = 32;
      int num2 = 0;
      this.Match("debugger");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("DEC")]
  private void mDEC()
  {
    try
    {
      int num1 = 33;
      int num2 = 0;
      this.Match("--");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("DEFAULT")]
  private void mDEFAULT()
  {
    try
    {
      int num1 = 34;
      int num2 = 0;
      this.Match("default");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("DELETE")]
  private void mDELETE()
  {
    try
    {
      int num1 = 35;
      int num2 = 0;
      this.Match("delete");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("DIV")]
  private void mDIV()
  {
    try
    {
      int num1 = 36;
      int num2 = 0;
      this.Match(47);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("DIVASS")]
  private void mDIVASS()
  {
    try
    {
      int num1 = 37;
      int num2 = 0;
      this.Match("/=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("DO")]
  private void mDO()
  {
    try
    {
      int num1 = 38;
      int num2 = 0;
      this.Match("do");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("DOT")]
  private void mDOT()
  {
    try
    {
      int num1 = 39;
      int num2 = 0;
      this.Match(46);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("DOUBLE")]
  private void mDOUBLE()
  {
    try
    {
      int num1 = 40;
      int num2 = 0;
      this.Match("double");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("ELSE")]
  private void mELSE()
  {
    try
    {
      int num1 = 45;
      int num2 = 0;
      this.Match("else");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("ENUM")]
  private void mENUM()
  {
    try
    {
      int num1 = 46;
      int num2 = 0;
      this.Match("enum");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("EQ")]
  private void mEQ()
  {
    try
    {
      int num1 = 48;
      int num2 = 0;
      this.Match("==");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("EXPORT")]
  private void mEXPORT()
  {
    try
    {
      int num1 = 49;
      int num2 = 0;
      this.Match("export");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("EXTENDS")]
  private void mEXTENDS()
  {
    try
    {
      int num1 = 51;
      int num2 = 0;
      this.Match("extends");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("FALSE")]
  private void mFALSE()
  {
    try
    {
      int num1 = 54;
      int num2 = 0;
      this.Match("false");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("FINAL")]
  private void mFINAL()
  {
    try
    {
      int num1 = 56;
      int num2 = 0;
      this.Match("final");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("FINALLY")]
  private void mFINALLY()
  {
    try
    {
      int num1 = 57;
      int num2 = 0;
      this.Match("finally");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("FLOAT")]
  private void mFLOAT()
  {
    try
    {
      int num1 = 58;
      int num2 = 0;
      this.Match("float");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("FOR")]
  private void mFOR()
  {
    try
    {
      int num1 = 59;
      int num2 = 0;
      this.Match("for");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("FUNCTION")]
  private void mFUNCTION()
  {
    try
    {
      int num1 = 62;
      int num2 = 0;
      this.Match("function");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("GOTO")]
  private void mGOTO()
  {
    try
    {
      int num1 = 63;
      int num2 = 0;
      this.Match("goto");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("GT")]
  private void mGT()
  {
    try
    {
      int num1 = 64;
      int num2 = 0;
      this.Match(62);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("GTE")]
  private void mGTE()
  {
    try
    {
      int num1 = 65;
      int num2 = 0;
      this.Match(">=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("IF")]
  private void mIF()
  {
    try
    {
      int num1 = 69;
      int num2 = 0;
      this.Match("if");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("IMPLEMENTS")]
  private void mIMPLEMENTS()
  {
    try
    {
      int num1 = 70;
      int num2 = 0;
      this.Match("implements");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("IMPORT")]
  private void mIMPORT()
  {
    try
    {
      int num1 = 71;
      int num2 = 0;
      this.Match("import");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("IN")]
  private void mIN()
  {
    try
    {
      int num1 = 72;
      int num2 = 0;
      this.Match("in");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("INC")]
  private void mINC()
  {
    try
    {
      int num1 = 73;
      int num2 = 0;
      this.Match("++");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("INSTANCEOF")]
  private void mINSTANCEOF()
  {
    try
    {
      int num1 = 74;
      int num2 = 0;
      this.Match("instanceof");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("INT")]
  private void mINT()
  {
    try
    {
      int num1 = 75;
      int num2 = 0;
      this.Match("int");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("INTERFACE")]
  private void mINTERFACE()
  {
    try
    {
      int num1 = 76;
      int num2 = 0;
      this.Match("interface");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("INV")]
  private void mINV()
  {
    try
    {
      int num1 = 77;
      int num2 = 0;
      this.Match(126);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("LAND")]
  private void mLAND()
  {
    try
    {
      int num1 = 84;
      int num2 = 0;
      this.Match("&&");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("LBRACE")]
  private void mLBRACE()
  {
    try
    {
      int num1 = 85;
      int num2 = 0;
      this.Match(123);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("LBRACK")]
  private void mLBRACK()
  {
    try
    {
      int num1 = 86;
      int num2 = 0;
      this.Match(91);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("LONG")]
  private void mLONG()
  {
    try
    {
      int num1 = 88;
      int num2 = 0;
      this.Match("long");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("LOR")]
  private void mLOR()
  {
    try
    {
      int num1 = 89;
      int num2 = 0;
      this.Match("||");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("LPAREN")]
  private void mLPAREN()
  {
    try
    {
      int num1 = 90;
      int num2 = 0;
      this.Match(40);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("LT")]
  private void mLT()
  {
    try
    {
      int num1 = 92;
      int num2 = 0;
      this.Match(60);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("LTE")]
  private void mLTE()
  {
    try
    {
      int num1 = 93;
      int num2 = 0;
      this.Match("<=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("MOD")]
  private void mMOD()
  {
    try
    {
      int num1 = 95;
      int num2 = 0;
      this.Match(37);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("MODASS")]
  private void mMODASS()
  {
    try
    {
      int num1 = 96;
      int num2 = 0;
      this.Match("%=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("MUL")]
  private void mMUL()
  {
    try
    {
      int num1 = 97;
      int num2 = 0;
      this.Match(42);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("MULASS")]
  private void mMULASS()
  {
    try
    {
      int num1 = 98;
      int num2 = 0;
      this.Match("*=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("NATIVE")]
  private void mNATIVE()
  {
    try
    {
      int num1 = 101;
      int num2 = 0;
      this.Match("native");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("NEQ")]
  private void mNEQ()
  {
    try
    {
      int num1 = 104;
      int num2 = 0;
      this.Match("!=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("NEW")]
  private void mNEW()
  {
    try
    {
      int num1 = 105;
      int num2 = 0;
      this.Match("new");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("NOT")]
  private void mNOT()
  {
    try
    {
      int num1 = 106;
      int num2 = 0;
      this.Match(33);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("NSAME")]
  private void mNSAME()
  {
    try
    {
      int num1 = 107;
      int num2 = 0;
      this.Match("!==");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("NULL")]
  private void mNULL()
  {
    try
    {
      int num1 = 108;
      int num2 = 0;
      this.Match("null");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("OR")]
  private void mOR()
  {
    try
    {
      int num1 = 110;
      int num2 = 0;
      this.Match(124);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("ORASS")]
  private void mORASS()
  {
    try
    {
      int num1 = 111;
      int num2 = 0;
      this.Match("|=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("PACKAGE")]
  private void mPACKAGE()
  {
    try
    {
      int num1 = 115;
      int num2 = 0;
      this.Match("package");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("PRIVATE")]
  private void mPRIVATE()
  {
    try
    {
      int num1 = 120;
      int num2 = 0;
      this.Match("private");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("PROTECTED")]
  private void mPROTECTED()
  {
    try
    {
      int num1 = 121;
      int num2 = 0;
      this.Match("protected");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("PUBLIC")]
  private void mPUBLIC()
  {
    try
    {
      int num1 = 123;
      int num2 = 0;
      this.Match("public");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("QUE")]
  private void mQUE()
  {
    try
    {
      int num1 = 124;
      int num2 = 0;
      this.Match(63);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("RBRACE")]
  private void mRBRACE()
  {
    try
    {
      int num1 = 125;
      int num2 = 0;
      this.Match(125);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("RBRACK")]
  private void mRBRACK()
  {
    try
    {
      int num1 = 126;
      int num2 = 0;
      this.Match(93);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("RETURN")]
  private void mRETURN()
  {
    try
    {
      int maxValue = (int) sbyte.MaxValue;
      int num = 0;
      this.Match("return");
      this.state.type = maxValue;
      this.state.channel = num;
    }
    finally
    {
    }
  }

  [GrammarRule("RPAREN")]
  private void mRPAREN()
  {
    try
    {
      int num1 = 128;
      int num2 = 0;
      this.Match(41);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SAME")]
  private void mSAME()
  {
    try
    {
      int num1 = 132;
      int num2 = 0;
      this.Match("===");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SEMIC")]
  private void mSEMIC()
  {
    try
    {
      int num1 = 133;
      int num2 = 0;
      this.Match(59);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SHL")]
  private void mSHL()
  {
    try
    {
      int num1 = 134;
      int num2 = 0;
      this.Match("<<");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SHLASS")]
  private void mSHLASS()
  {
    try
    {
      int num1 = 135;
      int num2 = 0;
      this.Match("<<=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SHORT")]
  private void mSHORT()
  {
    try
    {
      int num1 = 136;
      int num2 = 0;
      this.Match("short");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SHR")]
  private void mSHR()
  {
    try
    {
      int num1 = 137;
      int num2 = 0;
      this.Match(">>");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SHRASS")]
  private void mSHRASS()
  {
    try
    {
      int num1 = 138;
      int num2 = 0;
      this.Match(">>=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SHU")]
  private void mSHU()
  {
    try
    {
      int num1 = 139;
      int num2 = 0;
      this.Match(">>>");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SHUASS")]
  private void mSHUASS()
  {
    try
    {
      int num1 = 140;
      int num2 = 0;
      this.Match(">>>=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("STATIC")]
  private void mSTATIC()
  {
    try
    {
      int num1 = 143;
      int num2 = 0;
      this.Match("static");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SUB")]
  private void mSUB()
  {
    try
    {
      int num1 = 144;
      int num2 = 0;
      this.Match(45);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SUBASS")]
  private void mSUBASS()
  {
    try
    {
      int num1 = 145;
      int num2 = 0;
      this.Match("-=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SUPER")]
  private void mSUPER()
  {
    try
    {
      int num1 = 146;
      int num2 = 0;
      this.Match("super");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SWITCH")]
  private void mSWITCH()
  {
    try
    {
      int num1 = 147;
      int num2 = 0;
      this.Match("switch");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("SYNCHRONIZED")]
  private void mSYNCHRONIZED()
  {
    try
    {
      int num1 = 148;
      int num2 = 0;
      this.Match("synchronized");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("THIS")]
  private void mTHIS()
  {
    try
    {
      int num1 = 152;
      int num2 = 0;
      this.Match("this");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("THROW")]
  private void mTHROW()
  {
    try
    {
      int num1 = 153;
      int num2 = 0;
      this.Match("throw");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("THROWS")]
  private void mTHROWS()
  {
    try
    {
      int num1 = 154;
      int num2 = 0;
      this.Match("throws");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("TRANSIENT")]
  private void mTRANSIENT()
  {
    try
    {
      int num1 = 155;
      int num2 = 0;
      this.Match("transient");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("TRUE")]
  private void mTRUE()
  {
    try
    {
      int num1 = 156;
      int num2 = 0;
      this.Match("true");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("TRY")]
  private void mTRY()
  {
    try
    {
      int num1 = 157;
      int num2 = 0;
      this.Match("try");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("TYPEOF")]
  private void mTYPEOF()
  {
    try
    {
      int num1 = 158;
      int num2 = 0;
      this.Match("typeof");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("VAR")]
  private void mVAR()
  {
    try
    {
      int num1 = 161;
      int num2 = 0;
      this.Match("var");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("VOID")]
  private void mVOID()
  {
    try
    {
      int num1 = 162;
      int num2 = 0;
      this.Match("void");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("VOLATILE")]
  private void mVOLATILE()
  {
    try
    {
      int num1 = 163;
      int num2 = 0;
      this.Match("volatile");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("WHILE")]
  private void mWHILE()
  {
    try
    {
      int num1 = 165;
      int num2 = 0;
      this.Match("while");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("WITH")]
  private void mWITH()
  {
    try
    {
      int num1 = 166;
      int num2 = 0;
      this.Match("with");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("XOR")]
  private void mXOR()
  {
    try
    {
      int num1 = 168;
      int num2 = 0;
      this.Match(94);
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("XORASS")]
  private void mXORASS()
  {
    try
    {
      int num1 = 169;
      int num2 = 0;
      this.Match("^=");
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("BSLASH")]
  private void mBSLASH()
  {
    try
    {
      this.Match(92);
    }
    finally
    {
    }
  }

  [GrammarRule("DQUOTE")]
  private void mDQUOTE()
  {
    try
    {
      this.Match(34);
    }
    finally
    {
    }
  }

  [GrammarRule("SQUOTE")]
  private void mSQUOTE()
  {
    try
    {
      this.Match(39);
    }
    finally
    {
    }
  }

  [GrammarRule("TAB")]
  private void mTAB()
  {
    try
    {
      this.Match(9);
    }
    finally
    {
    }
  }

  [GrammarRule("VT")]
  private void mVT()
  {
    try
    {
      this.Match(11);
    }
    finally
    {
    }
  }

  [GrammarRule("FF")]
  private void mFF()
  {
    try
    {
      this.Match(12);
    }
    finally
    {
    }
  }

  [GrammarRule("SP")]
  private void mSP()
  {
    try
    {
      this.Match(32);
    }
    finally
    {
    }
  }

  [GrammarRule("NBSP")]
  private void mNBSP()
  {
    try
    {
      this.Match(160);
    }
    finally
    {
    }
  }

  [GrammarRule("USP")]
  private void mUSP()
  {
    try
    {
      if (this.input.LA(1) == 5760 || this.input.LA(1) == 6158 || this.input.LA(1) >= 8192 && this.input.LA(1) <= 8202 || (this.input.LA(1) == 8239 || this.input.LA(1) == 8287) || this.input.LA(1) == 12288)
      {
        this.input.Consume();
      }
      else
      {
        MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
        this.Recover((RecognitionException) mismatchedSetException);
        throw mismatchedSetException;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("WhiteSpace")]
  private void mWhiteSpace()
  {
    try
    {
      int num1 = 167;
      int num2 = 0;
      try
      {
        while (true)
        {
          int num3 = 2;
          try
          {
            int num4 = this.input.LA(1);
            if (num4 == 9 || num4 >= 11 && num4 <= 12 || (num4 == 32 || num4 == 160 || (num4 == 5760 || num4 == 6158)) || (num4 >= 8192 && num4 <= 8202 || (num4 == 8239 || num4 == 8287)) || num4 == 12288)
              num3 = 1;
          }
          finally
          {
          }
          if (num3 == 1)
          {
            this.input.Consume();
            ++num2;
          }
          else
            break;
        }
        if (num2 < 1)
          throw new EarlyExitException(1, (IIntStream) this.input);
      }
      finally
      {
      }
      int num5 = 99;
      this.state.type = num1;
      this.state.channel = num5;
    }
    finally
    {
    }
  }

  [GrammarRule("LF")]
  private void mLF()
  {
    try
    {
      this.Match(10);
    }
    finally
    {
    }
  }

  [GrammarRule("CR")]
  private void mCR()
  {
    try
    {
      this.Match(13);
    }
    finally
    {
    }
  }

  [GrammarRule("LS")]
  private void mLS()
  {
    try
    {
      this.Match(8232);
    }
    finally
    {
    }
  }

  [GrammarRule("PS")]
  private void mPS()
  {
    try
    {
      this.Match(8233);
    }
    finally
    {
    }
  }

  [GrammarRule("LineTerminator")]
  private void mLineTerminator()
  {
    try
    {
      if (this.input.LA(1) == 10 || this.input.LA(1) == 13 || this.input.LA(1) >= 8232 && this.input.LA(1) <= 8233)
      {
        this.input.Consume();
      }
      else
      {
        MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
        this.Recover((RecognitionException) mismatchedSetException);
        throw mismatchedSetException;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("EOL")]
  private void mEOL()
  {
    try
    {
      int num1 = 47;
      int num2 = 4;
      try
      {
        try
        {
          switch (this.input.LA(1))
          {
            case 10:
              num2 = 2;
              break;
            case 13:
              num2 = 1;
              break;
            case 8232:
              num2 = 3;
              break;
            case 8233:
              num2 = 4;
              break;
            default:
              throw new NoViableAltException("", 2, 0, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num2)
        {
          case 1:
            this.mCR();
            this.mLF();
            break;
          case 2:
            this.mLF();
            break;
          case 3:
            this.mLS();
            break;
          case 4:
            this.mPS();
            break;
        }
      }
      finally
      {
      }
      int num3 = 99;
      this.state.type = num1;
      this.state.channel = num3;
    }
    finally
    {
    }
  }

  [GrammarRule("MultiLineComment")]
  private void mMultiLineComment()
  {
    try
    {
      int num1 = 99;
      this.Match("/*");
      try
      {
        while (true)
        {
          int num2 = 2;
          try
          {
            int num3 = this.input.LA(1);
            if (num3 == 42)
            {
              int num4 = this.input.LA(2);
              if (num4 == 47)
                num2 = 2;
              else if (num4 >= 0 && num4 <= 46 || num4 >= 48 && num4 <= (int) ushort.MaxValue)
                num2 = 1;
            }
            else if (num3 >= 0 && num3 <= 41 || num3 >= 43 && num3 <= (int) ushort.MaxValue)
              num2 = 1;
          }
          finally
          {
          }
          if (num2 == 1)
            this.MatchAny();
          else
            break;
        }
      }
      finally
      {
      }
      this.Match("*/");
      int num5 = 99;
      this.state.type = num1;
      this.state.channel = num5;
    }
    finally
    {
    }
  }

  [GrammarRule("SingleLineComment")]
  private void mSingleLineComment()
  {
    try
    {
      int num1 = 149;
      this.Match("//");
      try
      {
        while (true)
        {
          int num2 = 2;
          try
          {
            int num3 = this.input.LA(1);
            if (num3 >= 0 && num3 <= 9 || num3 >= 11 && num3 <= 12 || num3 >= 14 && num3 <= 8231 || num3 >= 8234 && num3 <= (int) ushort.MaxValue)
              num2 = 1;
          }
          finally
          {
          }
          if (num2 == 1)
            this.input.Consume();
          else
            break;
        }
      }
      finally
      {
      }
      int num4 = 99;
      this.state.type = num1;
      this.state.channel = num4;
    }
    finally
    {
    }
  }

  [GrammarRule("IdentifierStartASCII")]
  private void mIdentifierStartASCII()
  {
    try
    {
      int num = 5;
      try
      {
        switch (this.input.LA(1))
        {
          case 36:
            num = 3;
            break;
          case 65:
          case 66:
          case 67:
          case 68:
          case 69:
          case 70:
          case 71:
          case 72:
          case 73:
          case 74:
          case 75:
          case 76:
          case 77:
          case 78:
          case 79:
          case 80:
          case 81:
          case 82:
          case 83:
          case 84:
          case 85:
          case 86:
          case 87:
          case 88:
          case 89:
          case 90:
            num = 2;
            break;
          case 92:
            num = 5;
            break;
          case 95:
            num = 4;
            break;
          case 97:
          case 98:
          case 99:
          case 100:
          case 101:
          case 102:
          case 103:
          case 104:
          case 105:
          case 106:
          case 107:
          case 108:
          case 109:
          case 110:
          case 111:
          case 112:
          case 113:
          case 114:
          case 115:
          case 116:
          case 117:
          case 118:
          case 119:
          case 120:
          case 121:
          case 122:
            num = 1;
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
          this.MatchRange(97, 122);
          break;
        case 2:
          this.MatchRange(65, 90);
          break;
        case 3:
          this.Match(36);
          break;
        case 4:
          this.Match(95);
          break;
        case 5:
          this.mBSLASH();
          this.Match(117);
          this.mHexDigit();
          this.mHexDigit();
          this.mHexDigit();
          this.mHexDigit();
          break;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("IdentifierPart")]
  private void mIdentifierPart()
  {
    try
    {
      int num = 3;
      try
      {
        switch (this.input.LA(1))
        {
          case 36:
          case 65:
          case 66:
          case 67:
          case 68:
          case 69:
          case 70:
          case 71:
          case 72:
          case 73:
          case 74:
          case 75:
          case 76:
          case 77:
          case 78:
          case 79:
          case 80:
          case 81:
          case 82:
          case 83:
          case 84:
          case 85:
          case 86:
          case 87:
          case 88:
          case 89:
          case 90:
          case 92:
          case 95:
          case 97:
          case 98:
          case 99:
          case 100:
          case 101:
          case 102:
          case 103:
          case 104:
          case 105:
          case 106:
          case 107:
          case 108:
          case 109:
          case 110:
          case 111:
          case 112:
          case 113:
          case 114:
          case 115:
          case 116:
          case 117:
          case 118:
          case 119:
          case 120:
          case 121:
          case 122:
            num = 2;
            break;
          case 48:
          case 49:
          case 50:
          case 51:
          case 52:
          case 53:
          case 54:
          case 55:
          case 56:
          case 57:
            num = 1;
            break;
          default:
            num = 3;
            break;
        }
      }
      finally
      {
      }
      switch (num)
      {
        case 1:
          this.mDecimalDigit();
          break;
        case 2:
          this.mIdentifierStartASCII();
          break;
        case 3:
          if (!this.IsIdentifierPartUnicode(this.input.LA(1)))
            throw new FailedPredicateException((IIntStream) this.input, "IdentifierPart", " IsIdentifierPartUnicode(input.LA(1)) ");
          this.MatchAny();
          break;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("IdentifierNameASCIIStart")]
  private void mIdentifierNameASCIIStart()
  {
    try
    {
      this.mIdentifierStartASCII();
      try
      {
        while (true)
        {
          int num1 = 2;
          try
          {
            int num2 = this.input.LA(1);
            if (num2 == 36 || num2 >= 48 && num2 <= 57 || (num2 >= 65 && num2 <= 90 || (num2 == 92 || num2 == 95)) || num2 >= 97 && num2 <= 122)
              num1 = 1;
            else if (this.IsIdentifierPartUnicode(this.input.LA(1)))
              num1 = 1;
          }
          finally
          {
          }
          if (num1 == 1)
            this.mIdentifierPart();
          else
            break;
        }
      }
      finally
      {
      }
    }
    finally
    {
    }
  }

  [GrammarRule("Identifier")]
  private void mIdentifier()
  {
    try
    {
      int num1 = 79;
      int num2 = 0;
      int num3 = 2;
      try
      {
        int num4 = this.input.LA(1);
        num3 = num4 != 36 && (num4 < 65 || num4 > 90) && (num4 != 92 && num4 != 95) && (num4 < 97 || num4 > 122) ? 2 : 1;
      }
      finally
      {
      }
      switch (num3)
      {
        case 1:
          this.mIdentifierNameASCIIStart();
          break;
        case 2:
          this.ConsumeIdentifierUnicodeStart();
          break;
      }
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("DecimalDigit")]
  private void mDecimalDigit()
  {
    try
    {
      if (this.input.LA(1) >= 48 && this.input.LA(1) <= 57)
      {
        this.input.Consume();
      }
      else
      {
        MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
        this.Recover((RecognitionException) mismatchedSetException);
        throw mismatchedSetException;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("HexDigit")]
  private void mHexDigit()
  {
    try
    {
      if (this.input.LA(1) >= 48 && this.input.LA(1) <= 57 || this.input.LA(1) >= 65 && this.input.LA(1) <= 70 || this.input.LA(1) >= 97 && this.input.LA(1) <= 102)
      {
        this.input.Consume();
      }
      else
      {
        MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
        this.Recover((RecognitionException) mismatchedSetException);
        throw mismatchedSetException;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("OctalDigit")]
  private void mOctalDigit()
  {
    try
    {
      if (this.input.LA(1) >= 48 && this.input.LA(1) <= 55)
      {
        this.input.Consume();
      }
      else
      {
        MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
        this.Recover((RecognitionException) mismatchedSetException);
        throw mismatchedSetException;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("ExponentPart")]
  private void mExponentPart()
  {
    try
    {
      if (this.input.LA(1) == 69 || this.input.LA(1) == 101)
      {
        this.input.Consume();
        int num1 = 2;
        try
        {
          try
          {
            int num2 = this.input.LA(1);
            if (num2 == 43 || num2 == 45)
              num1 = 1;
          }
          finally
          {
          }
          if (num1 == 1)
            this.input.Consume();
        }
        finally
        {
        }
        int num3 = 0;
        try
        {
          while (true)
          {
            int num2 = 2;
            try
            {
              int num4 = this.input.LA(1);
              if (num4 >= 48 && num4 <= 57)
                num2 = 1;
            }
            finally
            {
            }
            if (num2 == 1)
            {
              this.input.Consume();
              ++num3;
            }
            else
              break;
          }
          if (num3 < 1)
            throw new EarlyExitException(10, (IIntStream) this.input);
        }
        finally
        {
        }
      }
      else
      {
        MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
        this.Recover((RecognitionException) mismatchedSetException);
        throw mismatchedSetException;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("DecimalIntegerLiteral")]
  private void mDecimalIntegerLiteral()
  {
    try
    {
      int num1 = 2;
      try
      {
        int num2 = this.input.LA(1);
        if (num2 == 48)
        {
          num1 = 1;
        }
        else
        {
          if (num2 < 49 || num2 > 57)
            throw new NoViableAltException("", 12, 0, (IIntStream) this.input);
          num1 = 2;
        }
      }
      finally
      {
      }
      switch (num1)
      {
        case 1:
          this.Match(48);
          break;
        case 2:
          this.MatchRange(49, 57);
          try
          {
            while (true)
            {
              int num2 = 2;
              try
              {
                int num3 = this.input.LA(1);
                if (num3 >= 48 && num3 <= 57)
                  num2 = 1;
              }
              finally
              {
              }
              if (num2 == 1)
                this.input.Consume();
              else
                break;
            }
            break;
          }
          finally
          {
          }
      }
    }
    finally
    {
    }
  }

  [GrammarRule("DecimalLiteral")]
  private void mDecimalLiteral()
  {
    try
    {
      int num1 = 44;
      int num2 = 0;
      int num3 = 3;
      try
      {
        num3 = this.dfa18.Predict((IIntStream) this.input);
      }
      catch (NoViableAltException ex)
      {
        throw;
      }
      finally
      {
      }
      switch (num3)
      {
        case 1:
          this.mDecimalIntegerLiteral();
          this.Match(46);
          try
          {
            while (true)
            {
              int num4 = 2;
              try
              {
                int num5 = this.input.LA(1);
                if (num5 >= 48 && num5 <= 57)
                  num4 = 1;
              }
              finally
              {
              }
              if (num4 == 1)
                this.input.Consume();
              else
                break;
            }
          }
          finally
          {
          }
          int num6 = 2;
          try
          {
            try
            {
              int num4 = this.input.LA(1);
              if (num4 == 69 || num4 == 101)
                num6 = 1;
            }
            finally
            {
            }
            if (num6 == 1)
            {
              this.mExponentPart();
              break;
            }
            break;
          }
          finally
          {
          }
        case 2:
          this.Match(46);
          int num7 = 0;
          try
          {
            while (true)
            {
              int num4 = 2;
              try
              {
                int num5 = this.input.LA(1);
                if (num5 >= 48 && num5 <= 57)
                  num4 = 1;
              }
              finally
              {
              }
              if (num4 == 1)
              {
                this.input.Consume();
                ++num7;
              }
              else
                break;
            }
            if (num7 < 1)
              throw new EarlyExitException(15, (IIntStream) this.input);
          }
          finally
          {
          }
          int num8 = 2;
          try
          {
            try
            {
              int num4 = this.input.LA(1);
              if (num4 == 69 || num4 == 101)
                num8 = 1;
            }
            finally
            {
            }
            if (num8 == 1)
            {
              this.mExponentPart();
              break;
            }
            break;
          }
          finally
          {
          }
        case 3:
          this.mDecimalIntegerLiteral();
          int num9 = 2;
          try
          {
            try
            {
              int num4 = this.input.LA(1);
              if (num4 == 69 || num4 == 101)
                num9 = 1;
            }
            finally
            {
            }
            if (num9 == 1)
            {
              this.mExponentPart();
              break;
            }
            break;
          }
          finally
          {
          }
      }
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("OctalIntegerLiteral")]
  private void mOctalIntegerLiteral()
  {
    try
    {
      int num1 = 114;
      int num2 = 0;
      this.Match(48);
      int num3 = 0;
      try
      {
        while (true)
        {
          int num4 = 2;
          try
          {
            int num5 = this.input.LA(1);
            if (num5 >= 48 && num5 <= 55)
              num4 = 1;
          }
          finally
          {
          }
          if (num4 == 1)
          {
            this.input.Consume();
            ++num3;
          }
          else
            break;
        }
        if (num3 < 1)
          throw new EarlyExitException(19, (IIntStream) this.input);
      }
      finally
      {
      }
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("HexIntegerLiteral")]
  private void mHexIntegerLiteral()
  {
    try
    {
      int num1 = 68;
      int num2 = 0;
      int num3 = 2;
      try
      {
        try
        {
          if (this.input.LA(1) != 48)
            throw new NoViableAltException("", 20, 0, (IIntStream) this.input);
          switch (this.input.LA(2))
          {
            case 88:
              num3 = 2;
              break;
            case 120:
              num3 = 1;
              break;
            default:
              throw new NoViableAltException("", 20, 1, (IIntStream) this.input);
          }
        }
        finally
        {
        }
        switch (num3)
        {
          case 1:
            this.Match("0x");
            break;
          case 2:
            this.Match("0X");
            break;
        }
      }
      finally
      {
      }
      int num4 = 0;
      try
      {
        while (true)
        {
          int num5 = 2;
          try
          {
            int num6 = this.input.LA(1);
            if (num6 >= 48 && num6 <= 57 || num6 >= 65 && num6 <= 70 || num6 >= 97 && num6 <= 102)
              num5 = 1;
          }
          finally
          {
          }
          if (num5 == 1)
          {
            this.input.Consume();
            ++num4;
          }
          else
            break;
        }
        if (num4 < 1)
          throw new EarlyExitException(21, (IIntStream) this.input);
      }
      finally
      {
      }
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("CharacterEscapeSequence")]
  private void mCharacterEscapeSequence()
  {
    try
    {
      if (this.input.LA(1) >= 0 && this.input.LA(1) <= 9 || this.input.LA(1) >= 11 && this.input.LA(1) <= 12 || (this.input.LA(1) >= 14 && this.input.LA(1) <= 47 || this.input.LA(1) >= 58 && this.input.LA(1) <= 116) || (this.input.LA(1) >= 118 && this.input.LA(1) <= 119 || this.input.LA(1) >= 121 && this.input.LA(1) <= 8231) || this.input.LA(1) >= 8234 && this.input.LA(1) <= (int) ushort.MaxValue)
      {
        this.input.Consume();
      }
      else
      {
        MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
        this.Recover((RecognitionException) mismatchedSetException);
        throw mismatchedSetException;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("ZeroToThree")]
  private void mZeroToThree()
  {
    try
    {
      if (this.input.LA(1) >= 48 && this.input.LA(1) <= 51)
      {
        this.input.Consume();
      }
      else
      {
        MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
        this.Recover((RecognitionException) mismatchedSetException);
        throw mismatchedSetException;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("OctalEscapeSequence")]
  private void mOctalEscapeSequence()
  {
    try
    {
      int num1 = 4;
      try
      {
        int num2 = this.input.LA(1);
        if (num2 >= 48 && num2 <= 51)
        {
          int num3 = this.input.LA(2);
          if (num3 >= 48 && num3 <= 55)
          {
            int num4 = this.input.LA(3);
            num1 = num4 < 48 || num4 > 55 ? 2 : 4;
          }
          else
            num1 = 1;
        }
        else
        {
          if (num2 < 52 || num2 > 55)
            throw new NoViableAltException("", 22, 0, (IIntStream) this.input);
          int num3 = this.input.LA(2);
          num1 = num3 < 48 || num3 > 55 ? 1 : 3;
        }
      }
      finally
      {
      }
      switch (num1)
      {
        case 1:
          this.mOctalDigit();
          break;
        case 2:
          this.mZeroToThree();
          this.mOctalDigit();
          break;
        case 3:
          this.MatchRange(52, 55);
          this.mOctalDigit();
          break;
        case 4:
          this.mZeroToThree();
          this.mOctalDigit();
          this.mOctalDigit();
          break;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("HexEscapeSequence")]
  private void mHexEscapeSequence()
  {
    try
    {
      this.Match(120);
      this.mHexDigit();
      this.mHexDigit();
    }
    finally
    {
    }
  }

  [GrammarRule("UnicodeEscapeSequence")]
  private void mUnicodeEscapeSequence()
  {
    try
    {
      this.Match(117);
      this.mHexDigit();
      this.mHexDigit();
      this.mHexDigit();
      this.mHexDigit();
    }
    finally
    {
    }
  }

  [GrammarRule("EscapeSequence")]
  private void mEscapeSequence()
  {
    try
    {
      this.mBSLASH();
      int num1 = 5;
      try
      {
        try
        {
          int num2 = this.input.LA(1);
          if (num2 >= 0 && num2 <= 9 || num2 >= 11 && num2 <= 12 || (num2 >= 14 && num2 <= 47 || num2 >= 58 && num2 <= 116) || (num2 >= 118 && num2 <= 119 || num2 >= 121 && num2 <= 8231) || num2 >= 8234 && num2 <= (int) ushort.MaxValue)
            num1 = 1;
          else if (num2 >= 48 && num2 <= 55)
          {
            num1 = 2;
          }
          else
          {
            int num3;
            switch (num2)
            {
              case 10:
                num3 = 1;
                break;
              case 117:
                num1 = 4;
                goto label_16;
              case 120:
                num1 = 3;
                goto label_16;
              default:
                num3 = num2 == 13 ? 1 : 0;
                break;
            }
            if (num3 == 0)
              throw new NoViableAltException("", 24, 0, (IIntStream) this.input);
            num1 = 5;
          }
        }
        finally
        {
        }
label_16:
        switch (num1)
        {
          case 1:
            this.mCharacterEscapeSequence();
            break;
          case 2:
            this.mOctalEscapeSequence();
            break;
          case 3:
            this.mHexEscapeSequence();
            break;
          case 4:
            this.mUnicodeEscapeSequence();
            break;
          case 5:
            int num4 = 2;
            try
            {
              try
              {
                if (this.input.LA(1) == 13)
                  num4 = 1;
              }
              finally
              {
              }
              if (num4 == 1)
                this.input.Consume();
            }
            finally
            {
            }
            this.mLF();
            break;
        }
      }
      finally
      {
      }
    }
    finally
    {
    }
  }

  [GrammarRule("StringLiteral")]
  private void mStringLiteral()
  {
    try
    {
      int num1 = 150;
      int num2 = 0;
      int num3 = 2;
      try
      {
        switch (this.input.LA(1))
        {
          case 34:
            num3 = 2;
            break;
          case 39:
            num3 = 1;
            break;
          default:
            throw new NoViableAltException("", 27, 0, (IIntStream) this.input);
        }
      }
      finally
      {
      }
      switch (num3)
      {
        case 1:
          this.mSQUOTE();
          try
          {
            while (true)
            {
              int num4 = 3;
              try
              {
                int num5 = this.input.LA(1);
                if (num5 >= 0 && num5 <= 9 || num5 >= 11 && num5 <= 12 || (num5 >= 14 && num5 <= 38 || num5 >= 40 && num5 <= 91) || num5 >= 93 && num5 <= 8231 || num5 >= 8234 && num5 <= (int) ushort.MaxValue)
                  num4 = 1;
                else if (num5 == 92)
                  num4 = 2;
              }
              finally
              {
              }
              switch (num4)
              {
                case 1:
                  this.input.Consume();
                  break;
                case 2:
                  this.mEscapeSequence();
                  break;
                default:
                  goto label_21;
              }
            }
          }
          finally
          {
          }
label_21:
          this.mSQUOTE();
          break;
        case 2:
          this.mDQUOTE();
          try
          {
            while (true)
            {
              int num4 = 3;
              try
              {
                int num5 = this.input.LA(1);
                if (num5 >= 0 && num5 <= 9 || num5 >= 11 && num5 <= 12 || (num5 >= 14 && num5 <= 33 || num5 >= 35 && num5 <= 91) || num5 >= 93 && num5 <= 8231 || num5 >= 8234 && num5 <= (int) ushort.MaxValue)
                  num4 = 1;
                else if (num5 == 92)
                  num4 = 2;
              }
              finally
              {
              }
              switch (num4)
              {
                case 1:
                  this.input.Consume();
                  break;
                case 2:
                  this.mEscapeSequence();
                  break;
                default:
                  goto label_35;
              }
            }
          }
          finally
          {
          }
label_35:
          this.mDQUOTE();
          break;
      }
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  [GrammarRule("BackslashSequence")]
  private void mBackslashSequence()
  {
    try
    {
      this.mBSLASH();
      if (this.input.LA(1) >= 0 && this.input.LA(1) <= 9 || this.input.LA(1) >= 11 && this.input.LA(1) <= 12 || this.input.LA(1) >= 14 && this.input.LA(1) <= 8231 || this.input.LA(1) >= 8234 && this.input.LA(1) <= (int) ushort.MaxValue)
      {
        this.input.Consume();
      }
      else
      {
        MismatchedSetException mismatchedSetException = new MismatchedSetException((BitSet) null, (IIntStream) this.input);
        this.Recover((RecognitionException) mismatchedSetException);
        throw mismatchedSetException;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("RegularExpressionFirstChar")]
  private void mRegularExpressionFirstChar()
  {
    try
    {
      int num1 = 2;
      try
      {
        int num2 = this.input.LA(1);
        if (num2 >= 0 && num2 <= 9 || num2 >= 11 && num2 <= 12 || (num2 >= 14 && num2 <= 41 || num2 >= 43 && num2 <= 46) || (num2 >= 48 && num2 <= 91 || num2 >= 93 && num2 <= 8231) || num2 >= 8234 && num2 <= (int) ushort.MaxValue)
        {
          num1 = 1;
        }
        else
        {
          if (num2 != 92)
            throw new NoViableAltException("", 28, 0, (IIntStream) this.input);
          num1 = 2;
        }
      }
      finally
      {
      }
      switch (num1)
      {
        case 1:
          this.input.Consume();
          break;
        case 2:
          this.mBackslashSequence();
          break;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("RegularExpressionChar")]
  private void mRegularExpressionChar()
  {
    try
    {
      int num1 = 2;
      try
      {
        int num2 = this.input.LA(1);
        if (num2 >= 0 && num2 <= 9 || num2 >= 11 && num2 <= 12 || (num2 >= 14 && num2 <= 46 || num2 >= 48 && num2 <= 91) || num2 >= 93 && num2 <= 8231 || num2 >= 8234 && num2 <= (int) ushort.MaxValue)
        {
          num1 = 1;
        }
        else
        {
          if (num2 != 92)
            throw new NoViableAltException("", 29, 0, (IIntStream) this.input);
          num1 = 2;
        }
      }
      finally
      {
      }
      switch (num1)
      {
        case 1:
          this.input.Consume();
          break;
        case 2:
          this.mBackslashSequence();
          break;
      }
    }
    finally
    {
    }
  }

  [GrammarRule("RegularExpressionLiteral")]
  private void mRegularExpressionLiteral()
  {
    try
    {
      int num1 = 131;
      int num2 = 0;
      if (!this.AreRegularExpressionsEnabled())
        throw new FailedPredicateException((IIntStream) this.input, "RegularExpressionLiteral", " AreRegularExpressionsEnabled() ");
      this.mDIV();
      this.mRegularExpressionFirstChar();
      try
      {
        while (true)
        {
          int num3 = 2;
          try
          {
            int num4 = this.input.LA(1);
            if (num4 >= 0 && num4 <= 9 || num4 >= 11 && num4 <= 12 || (num4 >= 14 && num4 <= 46 || num4 >= 48 && num4 <= 8231) || num4 >= 8234 && num4 <= (int) ushort.MaxValue)
              num3 = 1;
          }
          finally
          {
          }
          if (num3 == 1)
            this.mRegularExpressionChar();
          else
            break;
        }
      }
      finally
      {
      }
      this.mDIV();
      try
      {
        while (true)
        {
          int num3 = 2;
          try
          {
            int num4 = this.input.LA(1);
            if (num4 == 36 || num4 >= 48 && num4 <= 57 || (num4 >= 65 && num4 <= 90 || (num4 == 92 || num4 == 95)) || num4 >= 97 && num4 <= 122)
              num3 = 1;
            else if (this.IsIdentifierPartUnicode(this.input.LA(1)))
              num3 = 1;
          }
          finally
          {
          }
          if (num3 == 1)
            this.mIdentifierPart();
          else
            break;
        }
      }
      finally
      {
      }
      this.state.type = num1;
      this.state.channel = num2;
    }
    finally
    {
    }
  }

  public override void mTokens()
  {
    int num = 117;
    try
    {
      num = this.dfa32.Predict((IIntStream) this.input);
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
        this.mABSTRACT();
        break;
      case 2:
        this.mADD();
        break;
      case 3:
        this.mADDASS();
        break;
      case 4:
        this.mAND();
        break;
      case 5:
        this.mANDASS();
        break;
      case 6:
        this.mASSIGN();
        break;
      case 7:
        this.mBOOLEAN();
        break;
      case 8:
        this.mBREAK();
        break;
      case 9:
        this.mBYTE();
        break;
      case 10:
        this.mCASE();
        break;
      case 11:
        this.mCATCH();
        break;
      case 12:
        this.mCHAR();
        break;
      case 13:
        this.mCLASS();
        break;
      case 14:
        this.mCOLON();
        break;
      case 15:
        this.mCOMMA();
        break;
      case 16:
        this.mCONST();
        break;
      case 17:
        this.mCONTINUE();
        break;
      case 18:
        this.mDEBUGGER();
        break;
      case 19:
        this.mDEC();
        break;
      case 20:
        this.mDEFAULT();
        break;
      case 21:
        this.mDELETE();
        break;
      case 22:
        this.mDIV();
        break;
      case 23:
        this.mDIVASS();
        break;
      case 24:
        this.mDO();
        break;
      case 25:
        this.mDOT();
        break;
      case 26:
        this.mDOUBLE();
        break;
      case 27:
        this.mELSE();
        break;
      case 28:
        this.mENUM();
        break;
      case 29:
        this.mEQ();
        break;
      case 30:
        this.mEXPORT();
        break;
      case 31:
        this.mEXTENDS();
        break;
      case 32:
        this.mFALSE();
        break;
      case 33:
        this.mFINAL();
        break;
      case 34:
        this.mFINALLY();
        break;
      case 35:
        this.mFLOAT();
        break;
      case 36:
        this.mFOR();
        break;
      case 37:
        this.mFUNCTION();
        break;
      case 38:
        this.mGOTO();
        break;
      case 39:
        this.mGT();
        break;
      case 40:
        this.mGTE();
        break;
      case 41:
        this.mIF();
        break;
      case 42:
        this.mIMPLEMENTS();
        break;
      case 43:
        this.mIMPORT();
        break;
      case 44:
        this.mIN();
        break;
      case 45:
        this.mINC();
        break;
      case 46:
        this.mINSTANCEOF();
        break;
      case 47:
        this.mINT();
        break;
      case 48:
        this.mINTERFACE();
        break;
      case 49:
        this.mINV();
        break;
      case 50:
        this.mLAND();
        break;
      case 51:
        this.mLBRACE();
        break;
      case 52:
        this.mLBRACK();
        break;
      case 53:
        this.mLONG();
        break;
      case 54:
        this.mLOR();
        break;
      case 55:
        this.mLPAREN();
        break;
      case 56:
        this.mLT();
        break;
      case 57:
        this.mLTE();
        break;
      case 58:
        this.mMOD();
        break;
      case 59:
        this.mMODASS();
        break;
      case 60:
        this.mMUL();
        break;
      case 61:
        this.mMULASS();
        break;
      case 62:
        this.mNATIVE();
        break;
      case 63:
        this.mNEQ();
        break;
      case 64:
        this.mNEW();
        break;
      case 65:
        this.mNOT();
        break;
      case 66:
        this.mNSAME();
        break;
      case 67:
        this.mNULL();
        break;
      case 68:
        this.mOR();
        break;
      case 69:
        this.mORASS();
        break;
      case 70:
        this.mPACKAGE();
        break;
      case 71:
        this.mPRIVATE();
        break;
      case 72:
        this.mPROTECTED();
        break;
      case 73:
        this.mPUBLIC();
        break;
      case 74:
        this.mQUE();
        break;
      case 75:
        this.mRBRACE();
        break;
      case 76:
        this.mRBRACK();
        break;
      case 77:
        this.mRETURN();
        break;
      case 78:
        this.mRPAREN();
        break;
      case 79:
        this.mSAME();
        break;
      case 80:
        this.mSEMIC();
        break;
      case 81:
        this.mSHL();
        break;
      case 82:
        this.mSHLASS();
        break;
      case 83:
        this.mSHORT();
        break;
      case 84:
        this.mSHR();
        break;
      case 85:
        this.mSHRASS();
        break;
      case 86:
        this.mSHU();
        break;
      case 87:
        this.mSHUASS();
        break;
      case 88:
        this.mSTATIC();
        break;
      case 89:
        this.mSUB();
        break;
      case 90:
        this.mSUBASS();
        break;
      case 91:
        this.mSUPER();
        break;
      case 92:
        this.mSWITCH();
        break;
      case 93:
        this.mSYNCHRONIZED();
        break;
      case 94:
        this.mTHIS();
        break;
      case 95:
        this.mTHROW();
        break;
      case 96:
        this.mTHROWS();
        break;
      case 97:
        this.mTRANSIENT();
        break;
      case 98:
        this.mTRUE();
        break;
      case 99:
        this.mTRY();
        break;
      case 100:
        this.mTYPEOF();
        break;
      case 101:
        this.mVAR();
        break;
      case 102:
        this.mVOID();
        break;
      case 103:
        this.mVOLATILE();
        break;
      case 104:
        this.mWHILE();
        break;
      case 105:
        this.mWITH();
        break;
      case 106:
        this.mXOR();
        break;
      case 107:
        this.mXORASS();
        break;
      case 108:
        this.mWhiteSpace();
        break;
      case 109:
        this.mEOL();
        break;
      case 110:
        this.mMultiLineComment();
        break;
      case 111:
        this.mSingleLineComment();
        break;
      case 112:
        this.mIdentifier();
        break;
      case 113:
        this.mDecimalLiteral();
        break;
      case 114:
        this.mOctalIntegerLiteral();
        break;
      case 115:
        this.mHexIntegerLiteral();
        break;
      case 116:
        this.mStringLiteral();
        break;
      case 117:
        this.mRegularExpressionLiteral();
        break;
    }
  }

  protected override void InitDFAs()
  {
    base.InitDFAs();
    this.dfa18 = new ES3Lexer.DFA18((BaseRecognizer) this);
    this.dfa32 = new ES3Lexer.DFA32((BaseRecognizer) this, new SpecialStateTransitionHandler(this.SpecialStateTransition32));
  }

  private int SpecialStateTransition32(DFA dfa, int s, IIntStream _input)
  {
    IIntStream input = _input;
    int stateNumber = s;
    switch (s)
    {
      case 0:
        int num1 = input.LA(1);
        int index1 = input.Index;
        input.Rewind();
        s = -1;
        switch (num1)
        {
          case 42:
            s = 69;
            break;
          case 47:
            s = 70;
            break;
          case 61:
            s = 68;
            break;
          default:
            s = (num1 < 0 || num1 > 9) && (num1 < 11 || num1 > 12) && ((num1 < 14 || num1 > 41) && (num1 < 43 || num1 > 46)) && ((num1 < 48 || num1 > 60) && (num1 < 62 || num1 > 8231) && (num1 < 8234 || num1 > (int) ushort.MaxValue)) || !this.AreRegularExpressionsEnabled() ? 71 : 72;
            break;
        }
        input.Seek(index1);
        if (s >= 0)
          return s;
        break;
      case 1:
        int num2 = input.LA(1);
        int index2 = input.Index;
        input.Rewind();
        s = -1;
        s = (num2 < 0 || num2 > 9) && (num2 < 11 || num2 > 12) && ((num2 < 14 || num2 > 8231) && (num2 < 8234 || num2 > (int) ushort.MaxValue)) || !this.AreRegularExpressionsEnabled() ? 141 : 72;
        input.Seek(index2);
        if (s >= 0)
          return s;
        break;
    }
    NoViableAltException nvae = new NoViableAltException(dfa.Description, 32, stateNumber, input);
    dfa.Error(nvae);
    throw nvae;
  }

  private class DFA18 : DFA
  {
    private static readonly string[] DFA18_transitionS = new string[7]{ "\x0001\x0003\x0001\xFFFF\x0001\x0001\t\x0002", "\x0001\x0005", "\x0001\x0005\x0001\xFFFF\n\x0006", "", "", "", "\x0001\x0005\x0001\xFFFF\n\x0006" };
    private static readonly short[] DFA18_eot = DFA.UnpackEncodedString("\x0001\xFFFF\x0002\x0004\x0003\xFFFF\x0001\x0004");
    private static readonly short[] DFA18_eof = DFA.UnpackEncodedString("\a\xFFFF");
    private static readonly char[] DFA18_min = DFA.UnpackEncodedStringToUnsignedChars("\x0003.\x0003\xFFFF\x0001.");
    private static readonly char[] DFA18_max = DFA.UnpackEncodedStringToUnsignedChars("\x00019\x0001.\x00019\x0003\xFFFF\x00019");
    private static readonly short[] DFA18_accept = DFA.UnpackEncodedString("\x0003\xFFFF\x0001\x0002\x0001\x0003\x0001\x0001\x0001\xFFFF");
    private static readonly short[] DFA18_special = DFA.UnpackEncodedString("\a\xFFFF}>");
    private const string DFA18_eotS = "\x0001\xFFFF\x0002\x0004\x0003\xFFFF\x0001\x0004";
    private const string DFA18_eofS = "\a\xFFFF";
    private const string DFA18_minS = "\x0003.\x0003\xFFFF\x0001.";
    private const string DFA18_maxS = "\x00019\x0001.\x00019\x0003\xFFFF\x00019";
    private const string DFA18_acceptS = "\x0003\xFFFF\x0001\x0002\x0001\x0003\x0001\x0001\x0001\xFFFF";
    private const string DFA18_specialS = "\a\xFFFF}>";
    private static readonly short[][] DFA18_transition;

    static DFA18()
    {
      int length = ES3Lexer.DFA18.DFA18_transitionS.Length;
      ES3Lexer.DFA18.DFA18_transition = new short[length][];
      for (int index = 0; index < length; ++index)
        ES3Lexer.DFA18.DFA18_transition[index] = DFA.UnpackEncodedString(ES3Lexer.DFA18.DFA18_transitionS[index]);
    }

    public DFA18(BaseRecognizer recognizer)
    {
      this.recognizer = recognizer;
      this.decisionNumber = 18;
      this.eot = ES3Lexer.DFA18.DFA18_eot;
      this.eof = ES3Lexer.DFA18.DFA18_eof;
      this.min = ES3Lexer.DFA18.DFA18_min;
      this.max = ES3Lexer.DFA18.DFA18_max;
      this.accept = ES3Lexer.DFA18.DFA18_accept;
      this.special = ES3Lexer.DFA18.DFA18_special;
      this.transition = ES3Lexer.DFA18.DFA18_transition;
    }

    public override string Description
    {
      get
      {
        return "889:1: DecimalLiteral : ( DecimalIntegerLiteral '.' ( DecimalDigit )* ( ExponentPart )? | '.' ( DecimalDigit )+ ( ExponentPart )? | DecimalIntegerLiteral ( ExponentPart )? );";
      }
    }

    public override void Error(NoViableAltException nvae)
    {
    }
  }

  private class DFA32 : DFA
  {
    private static readonly string[] DFA32_transitionS = new string[400]{ "\x0001)\x0001*\x0002)\x0001*\x0012\xFFFF\x0001)\x0001\x001C\x0001.\x0002\xFFFF\x0001\x0019\x0001\x0003\x0001.\x0001\x0017\x0001\"\x0001\x001A\x0001\x0002\x0001\b\x0001\n\x0001\f\x0001\v\x0001,\t-\x0001\a\x0001#\x0001\x0018\x0001\x0004\x0001\x0010\x0001\x001E\x001B\xFFFF\x0001\x0014\x0001\xFFFF\x0001 \x0001(\x0002\xFFFF\x0001\x0001\x0001\x0005\x0001\x0006\x0001\t\x0001\r\x0001\x000E\x0001\x000F\x0001\xFFFF\x0001\x0011\x0002\xFFFF\x0001\x0015\x0001\xFFFF\x0001\x001B\x0001\xFFFF\x0001\x001D\x0001\xFFFF\x0001!\x0001$\x0001%\x0001\xFFFF\x0001&\x0001'\x0003\xFFFF\x0001\x0013\x0001\x0016\x0001\x001F\x0001\x0012!\xFFFF\x0001)ᗟ\xFFFF\x0001)ƍ\xFFFF\x0001)߱\xFFFF\v)\x001D\xFFFF\x0002*\x0005\xFFFF\x0001)/\xFFFF\x0001)ྠ\xFFFF\x0001)", "\x0001/", "\x00011\x0011\xFFFF\x00010", "\x00014\x0016\xFFFF\x00013", "\x00016", "\x00018\x0002\xFFFF\x00019\x0006\xFFFF\x0001:", "\x0001;\x0006\xFFFF\x0001<\x0003\xFFFF\x0001=\x0002\xFFFF\x0001>", "", "", "\x0001?\t\xFFFF\x0001@", "\x0001A\x000F\xFFFF\x0001B", "\nH\x0001\xFFFF\x0002H\x0001\xFFFF\x001CH\x0001E\x0004H\x0001F\rH\x0001DῪH\x0002\xFFFF\xDFD6H", "\n-", "\x0001J\x0001\xFFFF\x0001K\t\xFFFF\x0001L", "\x0001M\a\xFFFF\x0001N\x0002\xFFFF\x0001O\x0002\xFFFF\x0001P\x0005\xFFFF\x0001Q", "\x0001R", "\x0001S\x0001T", "\x0001V\x0006\xFFFF\x0001W\x0001X", "", "", "", "\x0001Y", "\x0001[>\xFFFF\x0001Z", "", "\x0001^\x0001]", "\x0001`", "\x0001b", "\x0001d\x0003\xFFFF\x0001e\x000F\xFFFF\x0001f", "\x0001g", "\x0001i\x0010\xFFFF\x0001j\x0002\xFFFF\x0001k", "", "", "", "\x0001l", "", "", "\x0001m\v\xFFFF\x0001n\x0001o\x0001\xFFFF\x0001p\x0001\xFFFF\x0001q", "\x0001r\t\xFFFF\x0001s\x0006\xFFFF\x0001t", "\x0001u\r\xFFFF\x0001v", "\x0001w\x0001x", "\x0001y", "", "", "", "\b| \xFFFF\x0001{\x001F\xFFFF\x0001{", "", "", "\x0001}", "", "", "", "", "", "", "\x0001~", "", "\x0001\x0080", "\x0001\x0081", "\x0001\x0082", "\x0001\x0083\x0001\x0084", "\x0001\x0085", "\x0001\x0086", "\x0001\x0087", "\x0001\x0088\x0003\xFFFF\x0001\x0089\x0005\xFFFF\x0001\x008A", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x0014+\x0001\x008B\x0005+", "", "", "", "\nH\x0001\xFFFF\x0002H\x0001\xFFFF‚H\x0002\xFFFF\xDFD6H", "", "", "", "", "", "\x0001\x008E", "\x0001\x008F", "\x0001\x0090\x0003\xFFFF\x0001\x0091", "\x0001\x0092", "\x0001\x0093", "\x0001\x0094", "\x0001\x0095", "\x0001\x0096", "\x0001\x0097", "", "\x0001\x0098\x0001\x0099", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001\x009C", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x0012+\x0001\x009D\x0001\x009E\x0006+", "\x0001 ", "", "", "", "", "\x0001¡", "", "", "", "", "", "\x0001£", "\x0001¤", "\x0001¥", "\x0001¦", "", "\x0001¨", "\x0001©\x0005\xFFFF\x0001ª", "\x0001«", "\x0001¬", "\x0001\x00AD", "\x0001®", "\x0001¯", "\x0001°", "\x0001±", "\x0001\x00B2\b\xFFFF\x0001\x00B3", "\x0001´\x0013\xFFFF\x0001µ\x0003\xFFFF\x0001¶", "\x0001·", "\x0001¸", "\x0001\x00B9\x0002\xFFFF\x0001º", "\x0001»", "\x0001\x00BC", "", "", "", "", "\x0001\x00BD", "", "", "\x0001\x00BE", "\x0001¿", "\x0001À", "\x0001Á", "\x0001Â", "\x0001Ã", "\x0001Ä", "\x0001Å\x0001Æ", "\x0001Ç", "\x0001È", "\x0001É", "\x0001Ê", "", "", "\x0001Ë", "\x0001Ì", "\x0001Í", "\x0001Î", "\x0001Ï", "\x0001Ð", "\x0001Ñ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001Ó", "\x0001Ô", "", "\x0001Õ", "", "", "\x0001×\x0002\xFFFF\x0001Ø", "\x0001Ù", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x0004+\x0001Ú\x0015+", "", "\x0001Ü", "", "", "\x0001Ý", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001ß", "", "", "\x0001à", "\x0001á", "\x0001â", "\x0001ã", "\x0001ä", "\x0001å", "\x0001æ", "\x0001ç", "\x0001è", "\x0001é", "\x0001ê", "\x0001ë", "\x0001ì", "\x0001í", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001ï", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001ñ", "\x0001ò", "\x0001ó", "\x0001ô", "\x0001õ", "\x0001ö", "\x0001÷", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001ú", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001ü", "\x0001ý", "\x0001þ", "\x0001ÿ", "\x0001Ā", "\x0001ā", "\x0001Ă", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001ą", "\x0001Ć", "\x0001ć", "\x0001Ĉ", "\x0001ĉ", "", "\x0001Ċ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "", "\x0001Č", "\x0001č", "\x0001Ď", "\x0001ď", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001đ", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001ē", "\x0001Ĕ", "\x0001ĕ", "\x0001Ė", "\x0001ė", "\x0001Ę", "\x0001ę", "\x0001Ě", "\x0001ě", "\x0001Ĝ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001Ğ", "\x0001ğ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "\x0001ġ", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001ģ", "\x0001Ĥ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001Ħ", "\x0001ħ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001Ĭ", "\x0001ĭ", "\x0001Į", "\x0001į", "\x0001İ", "", "", "\x0001ı", "\x0001Ĳ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\v+\x0001Ĵ\x000E+", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001ķ", "", "\x0001ĸ", "\x0001Ĺ", "\x0001ĺ", "\x0001Ļ", "", "\x0001ļ", "", "\x0001Ľ", "\x0001ľ", "\x0001Ŀ", "\x0001ŀ", "\x0001Ł", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001Ń", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001Ņ", "\x0001ņ", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x0012+\x0001Ň\a+", "\x0001ŉ", "", "\x0001Ŋ", "", "\x0001ŋ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "\x0001ō", "\x0001Ŏ", "", "", "", "", "\x0001ŏ", "\x0001Ő", "\x0001ő", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001ŕ", "", "\x0001Ŗ", "", "", "\x0001ŗ", "\x0001Ř", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001Ś", "\x0001ś", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001ŝ", "\x0001Ş", "\x0001ş", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001Ť", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "\x0001Ŧ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001Ũ", "", "\x0001ũ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001ū", "\x0001Ŭ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001Ű", "\x0001ű", "", "\x0001Ų", "\x0001ų", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001Ŷ", "", "", "", "", "\x0001ŷ", "", "\x0001Ÿ", "", "\x0001Ź", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001ž", "\x0001ſ", "\x0001ƀ", "", "", "\x0001Ɓ", "\x0001Ƃ", "\x0001ƃ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "", "", "", "\x0001ƅ", "\x0001Ɔ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001Ɖ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "", "", "\x0001ƍ", "", "", "", "\x0001Ǝ", "\x0001+\v\xFFFF\n+\a\xFFFF\x001A+\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001\xFFFF\x001A+", "" };
    private static readonly short[] DFA32_eot = DFA.UnpackEncodedString("\x0002+\x00012\x00015\x00017\x0002+\x0002\xFFFF\x0001+\x0001C\x0001G\x0001I\x0003+\x0001U\x0001+\x0003\xFFFF\x0001+\x0001\\\x0001\xFFFF\x0001_\x0001a\x0001c\x0001+\x0001h\x0001+\x0003\xFFFF\x0001+\x0002\xFFFF\x0004+\x0001z\x0003\xFFFF\x0001-\x0002\xFFFF\x0001+\x0006\xFFFF\x0001\x007F\x0001\xFFFF\b+\x0001\x008C\x0003\xFFFF\x0001\x008D\x0005\xFFFF\t+\x0001\xFFFF\x0001\x009A\x0001\xFFFF\x0001\x009B\x0001+\x0001\x009F\x0001+\x0004\xFFFF\x0001¢\x0005\xFFFF\x0003+\x0001§\x0001\xFFFF\x0010+\x0004\xFFFF\x0001+\x0002\xFFFF\f+\x0002\xFFFF\a+\x0001Ò\x0002+\x0001\xFFFF\x0001Ö\x0002\xFFFF\x0002+\x0001Û\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001Þ\x0001+\x0002\xFFFF\x000E+\x0001î\x0001+\x0001ð\a+\x0001ø\x0001ù\x0001+\x0001û\a+\x0001ă\x0001Ą\x0005+\x0001\xFFFF\x0001+\x0001ċ\x0002\xFFFF\x0004+\x0001\xFFFF\x0001Đ\x0001+\x0001\xFFFF\x0001Ē\n+\x0001ĝ\x0002+\x0001Ġ\x0001\xFFFF\x0001+\x0001\xFFFF\x0001Ģ\x0002+\x0001ĥ\x0002+\x0001Ĩ\x0002\xFFFF\x0001ĩ\x0001\xFFFF\x0001Ī\x0001ī\x0005+\x0002\xFFFF\x0002+\x0001ĳ\x0001ĵ\x0001Ķ\x0001+\x0001\xFFFF\x0004+\x0001\xFFFF\x0001+\x0001\xFFFF\x0005+\x0001ł\x0001+\x0001ń\x0002+\x0001\xFFFF\x0001ň\x0001+\x0001\xFFFF\x0001+\x0001\xFFFF\x0001+\x0001Ō\x0001\xFFFF\x0002+\x0004\xFFFF\x0003+\x0001Œ\x0001œ\x0001Ŕ\x0001+\x0001\xFFFF\x0001+\x0002\xFFFF\x0002+\x0001ř\x0002+\x0001Ŝ\x0003+\x0001Š\x0001š\x0001\xFFFF\x0001Ţ\x0001\xFFFF\x0001ţ\x0001+\x0001ť\x0001\xFFFF\x0001+\x0001ŧ\x0001+\x0001\xFFFF\x0001+\x0001Ū\x0002+\x0001ŭ\x0003\xFFFF\x0001Ů\x0001ů\x0002+\x0001\xFFFF\x0002+\x0001\xFFFF\x0001Ŵ\x0001ŵ\x0001+\x0004\xFFFF\x0001+\x0001\xFFFF\x0001+\x0001\xFFFF\x0001+\x0001ź\x0001\xFFFF\x0001Ż\x0001ż\x0003\xFFFF\x0001Ž\x0003+\x0002\xFFFF\x0003+\x0001Ƅ\x0004\xFFFF\x0002+\x0001Ƈ\x0001ƈ\x0001+\x0001Ɗ\x0001\xFFFF\x0001Ƌ\x0001ƌ\x0002\xFFFF\x0001+\x0003\xFFFF\x0001+\x0001Ə\x0001\xFFFF");
    private static readonly short[] DFA32_eof = DFA.UnpackEncodedString("Ɛ\xFFFF");
    private static readonly char[] DFA32_min = DFA.UnpackEncodedStringToUnsignedChars("\x0001\t\x0001b\x0001+\x0001&\x0001=\x0001o\x0001a\x0002\xFFFF\x0001e\x0001-\x0001\0\x00010\x0001l\x0001a\x0001o\x0001=\x0001f\x0003\xFFFF\x0001o\x0001=\x0001\xFFFF\x0001<\x0002=\x0001a\x0001=\x0001a\x0003\xFFFF\x0001e\x0002\xFFFF\x0002h\x0001a\x0001h\x0001=\x0003\xFFFF\x00010\x0002\xFFFF\x0001s\x0006\xFFFF\x0001=\x0001\xFFFF\x0001o\x0001e\x0001t\x0001s\x0002a\x0001n\x0001b\x0001$\x0003\xFFFF\x0001\0\x0005\xFFFF\x0001s\x0001u\x0001p\x0001l\x0001n\x0001o\x0001r\x0001n\x0001t\x0001\xFFFF\x0001=\x0001\xFFFF\x0001$\x0001p\x0001$\x0001n\x0004\xFFFF\x0001=\x0005\xFFFF\x0001t\x0001w\x0001l\x0001=\x0001\xFFFF\x0001c\x0001i\x0001b\x0001t\x0001o\x0001a\x0001p\x0001i\x0001n\x0001i\x0001a\x0001p\x0001r\x0002i\x0001t\x0004\xFFFF\x0001t\x0002\xFFFF\x0001l\x0001a\x0002e\x0001c\x0001r\x0002s\x0001u\x0001a\x0001e\x0001b\x0002\xFFFF\x0001e\x0001m\x0001o\x0001e\x0001s\x0002a\x0001$\x0001c\x0001o\x0001\xFFFF\x0001=\x0002\xFFFF\x0001l\x0001t\x0001$\x0001\xFFFF\x0001g\x0002\xFFFF\x0001i\x0001$\x0001l\x0002\xFFFF\x0001k\x0001v\x0001t\x0001l\x0001u\x0001r\x0001t\x0001e\x0001t\x0001c\x0001s\x0001o\x0001n\x0001e\x0001$\x0001e\x0001$\x0001d\x0001a\x0001l\x0001h\x0001r\x0001e\x0001k\x0002$\x0001h\x0001$\x0001s\x0001t\x0001i\x0001g\x0001u\x0001t\x0001l\x0002$\x0001r\x0001n\x0001e\x0001l\x0001t\x0001\xFFFF\x0001t\x0001$\x0002\xFFFF\x0001e\x0001r\x0001a\x0001r\x0001\xFFFF\x0001$\x0001v\x0001\xFFFF\x0001$\x0002a\x0001e\x0001i\x0001r\x0001t\x0001i\x0001r\x0001c\x0001h\x0001$\x0001w\x0001s\x0001$\x0001\xFFFF\x0001o\x0001\xFFFF\x0001$\x0001t\x0001e\x0001$\x0002a\x0001$\x0002\xFFFF\x0001$\x0001\xFFFF\x0002$\x0001n\x0001g\x0001l\x0002e\x0002\xFFFF\x0001t\x0001d\x0003$\x0001i\x0001\xFFFF\x0001m\x0001t\x0001n\x0001f\x0001\xFFFF\x0001e\x0001\xFFFF\x0001g\x0001t\x0002c\x0001n\x0001$\x0001c\x0001$\x0001h\x0001r\x0001\xFFFF\x0001$\x0001i\x0001\xFFFF\x0001f\x0001\xFFFF\x0001i\x0001$\x0001\xFFFF\x0001c\x0001n\x0004\xFFFF\x0001u\x0001e\x0001t\x0003$\x0001s\x0001\xFFFF\x0001y\x0002\xFFFF\x0001o\x0001e\x0001$\x0001c\x0001a\x0001$\x0002e\x0001t\x0002$\x0001\xFFFF\x0001$\x0001\xFFFF\x0001$\x0001o\x0001$\x0001\xFFFF\x0001e\x0001$\x0001l\x0001\xFFFF\x0001t\x0001$\x0001e\x0001r\x0001$\x0003\xFFFF\x0002$\x0002n\x0001\xFFFF\x0001e\x0001c\x0001\xFFFF\x0002$\x0001e\x0004\xFFFF\x0001n\x0001\xFFFF\x0001n\x0001\xFFFF\x0001e\x0001$\x0001\xFFFF\x0002$\x0003\xFFFF\x0001$\x0001t\x0001o\x0001e\x0002\xFFFF\x0001d\x0001i\x0001t\x0001$\x0004\xFFFF\x0001s\x0001f\x0002$\x0001z\x0001$\x0001\xFFFF\x0002$\x0002\xFFFF\x0001e\x0003\xFFFF\x0001d\x0001$\x0001\xFFFF");
    private static readonly char[] DFA32_max = DFA.UnpackEncodedStringToUnsignedChars("\x0001　\x0001b\x0003=\x0001y\x0001o\x0002\xFFFF\x0001o\x0001=\x0001\xFFFF\x00019\x0001x\x0001u\x0001o\x0001>\x0001n\x0003\xFFFF\x0001o\x0001|\x0001\xFFFF\x0003=\x0001u\x0001=\x0001u\x0003\xFFFF\x0001e\x0002\xFFFF\x0002y\x0001o\x0001i\x0001=\x0003\xFFFF\x0001x\x0002\xFFFF\x0001s\x0006\xFFFF\x0001=\x0001\xFFFF\x0001o\x0001e\x0002t\x0002a\x0001n\x0001l\x0001z\x0003\xFFFF\x0001\xFFFF\x0005\xFFFF\x0001s\x0001u\x0001t\x0001l\x0001n\x0001o\x0001r\x0001n\x0001t\x0001\xFFFF\x0001>\x0001\xFFFF\x0001z\x0001p\x0001z\x0001n\x0004\xFFFF\x0001=\x0005\xFFFF\x0001t\x0001w\x0001l\x0001=\x0001\xFFFF\x0001c\x0001o\x0001b\x0001t\x0001o\x0001a\x0001p\x0001i\x0001n\x0001r\x0001y\x0001p\x0001r\x0001l\x0001i\x0001t\x0004\xFFFF\x0001t\x0002\xFFFF\x0001l\x0001a\x0002e\x0001c\x0001r\x0001s\x0001t\x0001u\x0001a\x0001e\x0001b\x0002\xFFFF\x0001e\x0001m\x0001o\x0001e\x0001s\x0002a\x0001z\x0001c\x0001o\x0001\xFFFF\x0001=\x0002\xFFFF\x0001o\x0001t\x0001z\x0001\xFFFF\x0001g\x0002\xFFFF\x0001i\x0001z\x0001l\x0002\xFFFF\x0001k\x0001v\x0001t\x0001l\x0001u\x0001r\x0001t\x0001e\x0001t\x0001c\x0001s\x0001o\x0001n\x0001e\x0001z\x0001e\x0001z\x0001d\x0001a\x0001l\x0001h\x0001r\x0001e\x0001k\x0002z\x0001h\x0001z\x0001s\x0001t\x0001i\x0001g\x0001u\x0001t\x0001l\x0002z\x0001r\x0001n\x0001e\x0001l\x0001t\x0001\xFFFF\x0001t\x0001z\x0002\xFFFF\x0001e\x0001r\x0001a\x0001r\x0001\xFFFF\x0001z\x0001v\x0001\xFFFF\x0001z\x0002a\x0001e\x0001i\x0001r\x0001t\x0001i\x0001r\x0001c\x0001h\x0001z\x0001w\x0001s\x0001z\x0001\xFFFF\x0001o\x0001\xFFFF\x0001z\x0001t\x0001e\x0001z\x0002a\x0001z\x0002\xFFFF\x0001z\x0001\xFFFF\x0002z\x0001n\x0001g\x0001l\x0002e\x0002\xFFFF\x0001t\x0001d\x0003z\x0001i\x0001\xFFFF\x0001m\x0001t\x0001n\x0001f\x0001\xFFFF\x0001e\x0001\xFFFF\x0001g\x0001t\x0002c\x0001n\x0001z\x0001c\x0001z\x0001h\x0001r\x0001\xFFFF\x0001z\x0001i\x0001\xFFFF\x0001f\x0001\xFFFF\x0001i\x0001z\x0001\xFFFF\x0001c\x0001n\x0004\xFFFF\x0001u\x0001e\x0001t\x0003z\x0001s\x0001\xFFFF\x0001y\x0002\xFFFF\x0001o\x0001e\x0001z\x0001c\x0001a\x0001z\x0002e\x0001t\x0002z\x0001\xFFFF\x0001z\x0001\xFFFF\x0001z\x0001o\x0001z\x0001\xFFFF\x0001e\x0001z\x0001l\x0001\xFFFF\x0001t\x0001z\x0001e\x0001r\x0001z\x0003\xFFFF\x0002z\x0002n\x0001\xFFFF\x0001e\x0001c\x0001\xFFFF\x0002z\x0001e\x0004\xFFFF\x0001n\x0001\xFFFF\x0001n\x0001\xFFFF\x0001e\x0001z\x0001\xFFFF\x0002z\x0003\xFFFF\x0001z\x0001t\x0001o\x0001e\x0002\xFFFF\x0001d\x0001i\x0001t\x0001z\x0004\xFFFF\x0001s\x0001f\x0004z\x0001\xFFFF\x0002z\x0002\xFFFF\x0001e\x0003\xFFFF\x0001d\x0001z\x0001\xFFFF");
    private static readonly short[] DFA32_accept = DFA.UnpackEncodedString("\a\xFFFF\x0001\x000E\x0001\x000F\t\xFFFF\x00011\x00013\x00014\x0002\xFFFF\x00017\x0006\xFFFF\x0001J\x0001K\x0001L\x0001\xFFFF\x0001N\x0001P\x0005\xFFFF\x0001l\x0001m\x0001p\x0001\xFFFF\x0001q\x0001t\x0001\xFFFF\x0001\x0003\x0001-\x0001\x0002\x0001\x0005\x00012\x0001\x0004\x0001\xFFFF\x0001\x0006\t\xFFFF\x0001\x0013\x0001Z\x0001Y\x0001\xFFFF\x0001n\x0001o\x0001\x0016\x0001u\x0001\x0019\t\xFFFF\x0001(\x0001\xFFFF\x0001'\x0004\xFFFF\x00016\x0001E\x0001D\x00019\x0001\xFFFF\x00018\x0001;\x0001:\x0001=\x0001<\x0004\xFFFF\x0001A\x0010\xFFFF\x0001k\x0001j\x0001s\x0001r\x0001\xFFFF\x0001O\x0001\x001D\f\xFFFF\x0001\x0018\x0001\x0017\n\xFFFF\x0001U\x0001\xFFFF\x0001T\x0001)\x0003\xFFFF\x0001,\x0001\xFFFF\x0001R\x0001Q\x0003\xFFFF\x0001B\x0001?*\xFFFF\x0001$\x0002\xFFFF\x0001W\x0001V\x0004\xFFFF\x0001/\x0002\xFFFF\x0001@\x000F\xFFFF\x0001c\x0001\xFFFF\x0001e\a\xFFFF\x0001\t\x0001\n\x0001\xFFFF\x0001\f\a\xFFFF\x0001\x001B\x0001\x001C\x0006\xFFFF\x0001&\x0004\xFFFF\x00015\x0001\xFFFF\x0001C\n\xFFFF\x0001^\x0002\xFFFF\x0001b\x0001\xFFFF\x0001f\x0002\xFFFF\x0001i\x0002\xFFFF\x0001\b\x0001\v\x0001\r\x0001\x0010\a\xFFFF\x0001 \x0001\xFFFF\x0001!\x0001#\v\xFFFF\x0001S\x0001\xFFFF\x0001[\x0003\xFFFF\x0001_\x0003\xFFFF\x0001h\x0005\xFFFF\x0001\x0015\x0001\x001A\x0001\x001E\x0004\xFFFF\x0001+\x0002\xFFFF\x0001>\x0003\xFFFF\x0001I\x0001M\x0001X\x0001\\\x0001\xFFFF\x0001`\x0001\xFFFF\x0001d\x0002\xFFFF\x0001\a\x0002\xFFFF\x0001\x0014\x0001\x001F\x0001\"\x0004\xFFFF\x0001F\x0001G\x0004\xFFFF\x0001\x0001\x0001\x0011\x0001\x0012\x0001%\x0006\xFFFF\x0001g\x0002\xFFFF\x00010\x0001H\x0001\xFFFF\x0001a\x0001*\x0001.\x0002\xFFFF\x0001]");
    private static readonly short[] DFA32_special = DFA.UnpackEncodedString("\v\xFFFF\x0001\08\xFFFF\x0001\x0001ŋ\xFFFF}>");
    private const string DFA32_eotS = "\x0002+\x00012\x00015\x00017\x0002+\x0002\xFFFF\x0001+\x0001C\x0001G\x0001I\x0003+\x0001U\x0001+\x0003\xFFFF\x0001+\x0001\\\x0001\xFFFF\x0001_\x0001a\x0001c\x0001+\x0001h\x0001+\x0003\xFFFF\x0001+\x0002\xFFFF\x0004+\x0001z\x0003\xFFFF\x0001-\x0002\xFFFF\x0001+\x0006\xFFFF\x0001\x007F\x0001\xFFFF\b+\x0001\x008C\x0003\xFFFF\x0001\x008D\x0005\xFFFF\t+\x0001\xFFFF\x0001\x009A\x0001\xFFFF\x0001\x009B\x0001+\x0001\x009F\x0001+\x0004\xFFFF\x0001¢\x0005\xFFFF\x0003+\x0001§\x0001\xFFFF\x0010+\x0004\xFFFF\x0001+\x0002\xFFFF\f+\x0002\xFFFF\a+\x0001Ò\x0002+\x0001\xFFFF\x0001Ö\x0002\xFFFF\x0002+\x0001Û\x0001\xFFFF\x0001+\x0002\xFFFF\x0001+\x0001Þ\x0001+\x0002\xFFFF\x000E+\x0001î\x0001+\x0001ð\a+\x0001ø\x0001ù\x0001+\x0001û\a+\x0001ă\x0001Ą\x0005+\x0001\xFFFF\x0001+\x0001ċ\x0002\xFFFF\x0004+\x0001\xFFFF\x0001Đ\x0001+\x0001\xFFFF\x0001Ē\n+\x0001ĝ\x0002+\x0001Ġ\x0001\xFFFF\x0001+\x0001\xFFFF\x0001Ģ\x0002+\x0001ĥ\x0002+\x0001Ĩ\x0002\xFFFF\x0001ĩ\x0001\xFFFF\x0001Ī\x0001ī\x0005+\x0002\xFFFF\x0002+\x0001ĳ\x0001ĵ\x0001Ķ\x0001+\x0001\xFFFF\x0004+\x0001\xFFFF\x0001+\x0001\xFFFF\x0005+\x0001ł\x0001+\x0001ń\x0002+\x0001\xFFFF\x0001ň\x0001+\x0001\xFFFF\x0001+\x0001\xFFFF\x0001+\x0001Ō\x0001\xFFFF\x0002+\x0004\xFFFF\x0003+\x0001Œ\x0001œ\x0001Ŕ\x0001+\x0001\xFFFF\x0001+\x0002\xFFFF\x0002+\x0001ř\x0002+\x0001Ŝ\x0003+\x0001Š\x0001š\x0001\xFFFF\x0001Ţ\x0001\xFFFF\x0001ţ\x0001+\x0001ť\x0001\xFFFF\x0001+\x0001ŧ\x0001+\x0001\xFFFF\x0001+\x0001Ū\x0002+\x0001ŭ\x0003\xFFFF\x0001Ů\x0001ů\x0002+\x0001\xFFFF\x0002+\x0001\xFFFF\x0001Ŵ\x0001ŵ\x0001+\x0004\xFFFF\x0001+\x0001\xFFFF\x0001+\x0001\xFFFF\x0001+\x0001ź\x0001\xFFFF\x0001Ż\x0001ż\x0003\xFFFF\x0001Ž\x0003+\x0002\xFFFF\x0003+\x0001Ƅ\x0004\xFFFF\x0002+\x0001Ƈ\x0001ƈ\x0001+\x0001Ɗ\x0001\xFFFF\x0001Ƌ\x0001ƌ\x0002\xFFFF\x0001+\x0003\xFFFF\x0001+\x0001Ə\x0001\xFFFF";
    private const string DFA32_eofS = "Ɛ\xFFFF";
    private const string DFA32_minS = "\x0001\t\x0001b\x0001+\x0001&\x0001=\x0001o\x0001a\x0002\xFFFF\x0001e\x0001-\x0001\0\x00010\x0001l\x0001a\x0001o\x0001=\x0001f\x0003\xFFFF\x0001o\x0001=\x0001\xFFFF\x0001<\x0002=\x0001a\x0001=\x0001a\x0003\xFFFF\x0001e\x0002\xFFFF\x0002h\x0001a\x0001h\x0001=\x0003\xFFFF\x00010\x0002\xFFFF\x0001s\x0006\xFFFF\x0001=\x0001\xFFFF\x0001o\x0001e\x0001t\x0001s\x0002a\x0001n\x0001b\x0001$\x0003\xFFFF\x0001\0\x0005\xFFFF\x0001s\x0001u\x0001p\x0001l\x0001n\x0001o\x0001r\x0001n\x0001t\x0001\xFFFF\x0001=\x0001\xFFFF\x0001$\x0001p\x0001$\x0001n\x0004\xFFFF\x0001=\x0005\xFFFF\x0001t\x0001w\x0001l\x0001=\x0001\xFFFF\x0001c\x0001i\x0001b\x0001t\x0001o\x0001a\x0001p\x0001i\x0001n\x0001i\x0001a\x0001p\x0001r\x0002i\x0001t\x0004\xFFFF\x0001t\x0002\xFFFF\x0001l\x0001a\x0002e\x0001c\x0001r\x0002s\x0001u\x0001a\x0001e\x0001b\x0002\xFFFF\x0001e\x0001m\x0001o\x0001e\x0001s\x0002a\x0001$\x0001c\x0001o\x0001\xFFFF\x0001=\x0002\xFFFF\x0001l\x0001t\x0001$\x0001\xFFFF\x0001g\x0002\xFFFF\x0001i\x0001$\x0001l\x0002\xFFFF\x0001k\x0001v\x0001t\x0001l\x0001u\x0001r\x0001t\x0001e\x0001t\x0001c\x0001s\x0001o\x0001n\x0001e\x0001$\x0001e\x0001$\x0001d\x0001a\x0001l\x0001h\x0001r\x0001e\x0001k\x0002$\x0001h\x0001$\x0001s\x0001t\x0001i\x0001g\x0001u\x0001t\x0001l\x0002$\x0001r\x0001n\x0001e\x0001l\x0001t\x0001\xFFFF\x0001t\x0001$\x0002\xFFFF\x0001e\x0001r\x0001a\x0001r\x0001\xFFFF\x0001$\x0001v\x0001\xFFFF\x0001$\x0002a\x0001e\x0001i\x0001r\x0001t\x0001i\x0001r\x0001c\x0001h\x0001$\x0001w\x0001s\x0001$\x0001\xFFFF\x0001o\x0001\xFFFF\x0001$\x0001t\x0001e\x0001$\x0002a\x0001$\x0002\xFFFF\x0001$\x0001\xFFFF\x0002$\x0001n\x0001g\x0001l\x0002e\x0002\xFFFF\x0001t\x0001d\x0003$\x0001i\x0001\xFFFF\x0001m\x0001t\x0001n\x0001f\x0001\xFFFF\x0001e\x0001\xFFFF\x0001g\x0001t\x0002c\x0001n\x0001$\x0001c\x0001$\x0001h\x0001r\x0001\xFFFF\x0001$\x0001i\x0001\xFFFF\x0001f\x0001\xFFFF\x0001i\x0001$\x0001\xFFFF\x0001c\x0001n\x0004\xFFFF\x0001u\x0001e\x0001t\x0003$\x0001s\x0001\xFFFF\x0001y\x0002\xFFFF\x0001o\x0001e\x0001$\x0001c\x0001a\x0001$\x0002e\x0001t\x0002$\x0001\xFFFF\x0001$\x0001\xFFFF\x0001$\x0001o\x0001$\x0001\xFFFF\x0001e\x0001$\x0001l\x0001\xFFFF\x0001t\x0001$\x0001e\x0001r\x0001$\x0003\xFFFF\x0002$\x0002n\x0001\xFFFF\x0001e\x0001c\x0001\xFFFF\x0002$\x0001e\x0004\xFFFF\x0001n\x0001\xFFFF\x0001n\x0001\xFFFF\x0001e\x0001$\x0001\xFFFF\x0002$\x0003\xFFFF\x0001$\x0001t\x0001o\x0001e\x0002\xFFFF\x0001d\x0001i\x0001t\x0001$\x0004\xFFFF\x0001s\x0001f\x0002$\x0001z\x0001$\x0001\xFFFF\x0002$\x0002\xFFFF\x0001e\x0003\xFFFF\x0001d\x0001$\x0001\xFFFF";
    private const string DFA32_maxS = "\x0001　\x0001b\x0003=\x0001y\x0001o\x0002\xFFFF\x0001o\x0001=\x0001\xFFFF\x00019\x0001x\x0001u\x0001o\x0001>\x0001n\x0003\xFFFF\x0001o\x0001|\x0001\xFFFF\x0003=\x0001u\x0001=\x0001u\x0003\xFFFF\x0001e\x0002\xFFFF\x0002y\x0001o\x0001i\x0001=\x0003\xFFFF\x0001x\x0002\xFFFF\x0001s\x0006\xFFFF\x0001=\x0001\xFFFF\x0001o\x0001e\x0002t\x0002a\x0001n\x0001l\x0001z\x0003\xFFFF\x0001\xFFFF\x0005\xFFFF\x0001s\x0001u\x0001t\x0001l\x0001n\x0001o\x0001r\x0001n\x0001t\x0001\xFFFF\x0001>\x0001\xFFFF\x0001z\x0001p\x0001z\x0001n\x0004\xFFFF\x0001=\x0005\xFFFF\x0001t\x0001w\x0001l\x0001=\x0001\xFFFF\x0001c\x0001o\x0001b\x0001t\x0001o\x0001a\x0001p\x0001i\x0001n\x0001r\x0001y\x0001p\x0001r\x0001l\x0001i\x0001t\x0004\xFFFF\x0001t\x0002\xFFFF\x0001l\x0001a\x0002e\x0001c\x0001r\x0001s\x0001t\x0001u\x0001a\x0001e\x0001b\x0002\xFFFF\x0001e\x0001m\x0001o\x0001e\x0001s\x0002a\x0001z\x0001c\x0001o\x0001\xFFFF\x0001=\x0002\xFFFF\x0001o\x0001t\x0001z\x0001\xFFFF\x0001g\x0002\xFFFF\x0001i\x0001z\x0001l\x0002\xFFFF\x0001k\x0001v\x0001t\x0001l\x0001u\x0001r\x0001t\x0001e\x0001t\x0001c\x0001s\x0001o\x0001n\x0001e\x0001z\x0001e\x0001z\x0001d\x0001a\x0001l\x0001h\x0001r\x0001e\x0001k\x0002z\x0001h\x0001z\x0001s\x0001t\x0001i\x0001g\x0001u\x0001t\x0001l\x0002z\x0001r\x0001n\x0001e\x0001l\x0001t\x0001\xFFFF\x0001t\x0001z\x0002\xFFFF\x0001e\x0001r\x0001a\x0001r\x0001\xFFFF\x0001z\x0001v\x0001\xFFFF\x0001z\x0002a\x0001e\x0001i\x0001r\x0001t\x0001i\x0001r\x0001c\x0001h\x0001z\x0001w\x0001s\x0001z\x0001\xFFFF\x0001o\x0001\xFFFF\x0001z\x0001t\x0001e\x0001z\x0002a\x0001z\x0002\xFFFF\x0001z\x0001\xFFFF\x0002z\x0001n\x0001g\x0001l\x0002e\x0002\xFFFF\x0001t\x0001d\x0003z\x0001i\x0001\xFFFF\x0001m\x0001t\x0001n\x0001f\x0001\xFFFF\x0001e\x0001\xFFFF\x0001g\x0001t\x0002c\x0001n\x0001z\x0001c\x0001z\x0001h\x0001r\x0001\xFFFF\x0001z\x0001i\x0001\xFFFF\x0001f\x0001\xFFFF\x0001i\x0001z\x0001\xFFFF\x0001c\x0001n\x0004\xFFFF\x0001u\x0001e\x0001t\x0003z\x0001s\x0001\xFFFF\x0001y\x0002\xFFFF\x0001o\x0001e\x0001z\x0001c\x0001a\x0001z\x0002e\x0001t\x0002z\x0001\xFFFF\x0001z\x0001\xFFFF\x0001z\x0001o\x0001z\x0001\xFFFF\x0001e\x0001z\x0001l\x0001\xFFFF\x0001t\x0001z\x0001e\x0001r\x0001z\x0003\xFFFF\x0002z\x0002n\x0001\xFFFF\x0001e\x0001c\x0001\xFFFF\x0002z\x0001e\x0004\xFFFF\x0001n\x0001\xFFFF\x0001n\x0001\xFFFF\x0001e\x0001z\x0001\xFFFF\x0002z\x0003\xFFFF\x0001z\x0001t\x0001o\x0001e\x0002\xFFFF\x0001d\x0001i\x0001t\x0001z\x0004\xFFFF\x0001s\x0001f\x0004z\x0001\xFFFF\x0002z\x0002\xFFFF\x0001e\x0003\xFFFF\x0001d\x0001z\x0001\xFFFF";
    private const string DFA32_acceptS = "\a\xFFFF\x0001\x000E\x0001\x000F\t\xFFFF\x00011\x00013\x00014\x0002\xFFFF\x00017\x0006\xFFFF\x0001J\x0001K\x0001L\x0001\xFFFF\x0001N\x0001P\x0005\xFFFF\x0001l\x0001m\x0001p\x0001\xFFFF\x0001q\x0001t\x0001\xFFFF\x0001\x0003\x0001-\x0001\x0002\x0001\x0005\x00012\x0001\x0004\x0001\xFFFF\x0001\x0006\t\xFFFF\x0001\x0013\x0001Z\x0001Y\x0001\xFFFF\x0001n\x0001o\x0001\x0016\x0001u\x0001\x0019\t\xFFFF\x0001(\x0001\xFFFF\x0001'\x0004\xFFFF\x00016\x0001E\x0001D\x00019\x0001\xFFFF\x00018\x0001;\x0001:\x0001=\x0001<\x0004\xFFFF\x0001A\x0010\xFFFF\x0001k\x0001j\x0001s\x0001r\x0001\xFFFF\x0001O\x0001\x001D\f\xFFFF\x0001\x0018\x0001\x0017\n\xFFFF\x0001U\x0001\xFFFF\x0001T\x0001)\x0003\xFFFF\x0001,\x0001\xFFFF\x0001R\x0001Q\x0003\xFFFF\x0001B\x0001?*\xFFFF\x0001$\x0002\xFFFF\x0001W\x0001V\x0004\xFFFF\x0001/\x0002\xFFFF\x0001@\x000F\xFFFF\x0001c\x0001\xFFFF\x0001e\a\xFFFF\x0001\t\x0001\n\x0001\xFFFF\x0001\f\a\xFFFF\x0001\x001B\x0001\x001C\x0006\xFFFF\x0001&\x0004\xFFFF\x00015\x0001\xFFFF\x0001C\n\xFFFF\x0001^\x0002\xFFFF\x0001b\x0001\xFFFF\x0001f\x0002\xFFFF\x0001i\x0002\xFFFF\x0001\b\x0001\v\x0001\r\x0001\x0010\a\xFFFF\x0001 \x0001\xFFFF\x0001!\x0001#\v\xFFFF\x0001S\x0001\xFFFF\x0001[\x0003\xFFFF\x0001_\x0003\xFFFF\x0001h\x0005\xFFFF\x0001\x0015\x0001\x001A\x0001\x001E\x0004\xFFFF\x0001+\x0002\xFFFF\x0001>\x0003\xFFFF\x0001I\x0001M\x0001X\x0001\\\x0001\xFFFF\x0001`\x0001\xFFFF\x0001d\x0002\xFFFF\x0001\a\x0002\xFFFF\x0001\x0014\x0001\x001F\x0001\"\x0004\xFFFF\x0001F\x0001G\x0004\xFFFF\x0001\x0001\x0001\x0011\x0001\x0012\x0001%\x0006\xFFFF\x0001g\x0002\xFFFF\x00010\x0001H\x0001\xFFFF\x0001a\x0001*\x0001.\x0002\xFFFF\x0001]";
    private const string DFA32_specialS = "\v\xFFFF\x0001\08\xFFFF\x0001\x0001ŋ\xFFFF}>";
    private static readonly short[][] DFA32_transition;

    static DFA32()
    {
      int length = ES3Lexer.DFA32.DFA32_transitionS.Length;
      ES3Lexer.DFA32.DFA32_transition = new short[length][];
      for (int index = 0; index < length; ++index)
        ES3Lexer.DFA32.DFA32_transition[index] = DFA.UnpackEncodedString(ES3Lexer.DFA32.DFA32_transitionS[index]);
    }

    public DFA32(
      BaseRecognizer recognizer,
      SpecialStateTransitionHandler specialStateTransition)
      : base(specialStateTransition)
    {
      this.recognizer = recognizer;
      this.decisionNumber = 32;
      this.eot = ES3Lexer.DFA32.DFA32_eot;
      this.eof = ES3Lexer.DFA32.DFA32_eof;
      this.min = ES3Lexer.DFA32.DFA32_min;
      this.max = ES3Lexer.DFA32.DFA32_max;
      this.accept = ES3Lexer.DFA32.DFA32_accept;
      this.special = ES3Lexer.DFA32.DFA32_special;
      this.transition = ES3Lexer.DFA32.DFA32_transition;
    }

    public override string Description
    {
      get
      {
        return "1:1: Tokens : ( ABSTRACT | ADD | ADDASS | AND | ANDASS | ASSIGN | BOOLEAN | BREAK | BYTE | CASE | CATCH | CHAR | CLASS | COLON | COMMA | CONST | CONTINUE | DEBUGGER | DEC | DEFAULT | DELETE | DIV | DIVASS | DO | DOT | DOUBLE | ELSE | ENUM | EQ | EXPORT | EXTENDS | FALSE | FINAL | FINALLY | FLOAT | FOR | FUNCTION | GOTO | GT | GTE | IF | IMPLEMENTS | IMPORT | IN | INC | INSTANCEOF | INT | INTERFACE | INV | LAND | LBRACE | LBRACK | LONG | LOR | LPAREN | LT | LTE | MOD | MODASS | MUL | MULASS | NATIVE | NEQ | NEW | NOT | NSAME | NULL | OR | ORASS | PACKAGE | PRIVATE | PROTECTED | PUBLIC | QUE | RBRACE | RBRACK | RETURN | RPAREN | SAME | SEMIC | SHL | SHLASS | SHORT | SHR | SHRASS | SHU | SHUASS | STATIC | SUB | SUBASS | SUPER | SWITCH | SYNCHRONIZED | THIS | THROW | THROWS | TRANSIENT | TRUE | TRY | TYPEOF | VAR | VOID | VOLATILE | WHILE | WITH | XOR | XORASS | WhiteSpace | EOL | MultiLineComment | SingleLineComment | Identifier | DecimalLiteral | OctalIntegerLiteral | HexIntegerLiteral | StringLiteral | RegularExpressionLiteral );";
      }
    }

    public override void Error(NoViableAltException nvae)
    {
    }
  }
}
