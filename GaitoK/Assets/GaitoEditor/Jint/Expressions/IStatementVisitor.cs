// Decompiled with JetBrains decompiler
// Type: Jint.Expressions.IStatementVisitor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

namespace Jint.Expressions
{
  public interface IStatementVisitor
  {
    void Visit(Program expression);

    void Visit(AssignmentExpression expression);

    void Visit(BlockStatement expression);

    void Visit(BreakStatement expression);

    void Visit(ContinueStatement expression);

    void Visit(DoWhileStatement expression);

    void Visit(EmptyStatement expression);

    void Visit(ExpressionStatement expression);

    void Visit(ForEachInStatement expression);

    void Visit(ForStatement expression);

    void Visit(FunctionDeclarationStatement expression);

    void Visit(IfStatement expression);

    void Visit(ReturnStatement expression);

    void Visit(SwitchStatement expression);

    void Visit(WithStatement expression);

    void Visit(ThrowStatement expression);

    void Visit(TryStatement expression);

    void Visit(VariableDeclarationStatement expression);

    void Visit(WhileStatement expression);

    void Visit(ArrayDeclaration expression);

    void Visit(CommaOperatorStatement expression);

    void Visit(FunctionExpression expression);

    void Visit(MemberExpression expression);

    void Visit(MethodCall expression);

    void Visit(Indexer expression);

    void Visit(PropertyExpression expression);

    void Visit(PropertyDeclarationExpression expression);

    void Visit(Identifier expression);

    void Visit(JsonExpression expression);

    void Visit(NewExpression expression);

    void Visit(BinaryExpression expression);

    void Visit(TernaryExpression expression);

    void Visit(UnaryExpression expression);

    void Visit(ValueExpression expression);

    void Visit(RegexpExpression expression);

    void Visit(Statement expression);
  }
}
