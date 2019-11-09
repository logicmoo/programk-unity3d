// Decompiled with JetBrains decompiler
// Type: Jint.ExecutionVisitor
// Assembly: Jint, Version=0.9.2.0, Culture=neutral, PublicKeyToken=null
// MVID: 571329D7-6C81-45D7-9D41-B17A701B759E
// Assembly location: C:\Users\Administrator\AppData\Local\Apps\2.0\AMK4CRNH.1P0\83OD2GAZ.QLB\gait..tion_0000000000000000_0002.000a_0f204e9a356efc4e\Jint.dll

using Jint.Debugger;
using Jint.Expressions;
using Jint.Native;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security;
using System.Text;

namespace Jint
{
  public class ExecutionVisitor : IStatementVisitor, IJintVisitor
  {
    protected Stack<JsScope> Scopes = new Stack<JsScope>();
    private StringBuilder typeFullname = new StringBuilder();
    private string lastIdentifier = string.Empty;
    private Stack<ExecutionVisitor.ResultInfo> stackResults = new Stack<ExecutionVisitor.ResultInfo>();
    protected ContinueStatement continueStatement = (ContinueStatement) null;
    protected BreakStatement breakStatement = (BreakStatement) null;
    protected internal ITypeResolver typeResolver;
    protected bool exit;
    protected JsInstance returnInstance;
    protected int recursionLevel;
    private ExecutionVisitor.ResultInfo lastResult;

    public IGlobal Global { get; private set; }

    public JsScope GlobalScope { get; private set; }

    public event EventHandler<DebugInformation> Step;

    public Stack<string> CallStack { get; set; }

    public Statement CurrentStatement { get; set; }

    public bool DebugMode { get; set; }

    public int MaxRecursions { get; set; }

    public JsInstance Returned
    {
      get
      {
        return this.returnInstance;
      }
    }

    public bool AllowClr { get; set; }

    public PermissionSet PermissionSet { get; set; }

    public JsDictionaryObject CallTarget
    {
      get
      {
        return this.lastResult.baseObject;
      }
    }

    public JsInstance Result
    {
      get
      {
        return this.lastResult.result;
      }
      set
      {
        this.lastResult.result = value;
        this.lastResult.baseObject = (JsDictionaryObject) null;
      }
    }

    public void SetResult(JsInstance value, JsDictionaryObject baseObject)
    {
      this.lastResult.result = value;
      this.lastResult.baseObject = baseObject;
    }

    public ExecutionVisitor(Options options)
    {
      this.typeResolver = (ITypeResolver) CachedTypeResolver.Default;
      this.Global = (IGlobal) new JsGlobal(this, options);
      this.GlobalScope = new JsScope((JsDictionaryObject) (this.Global as JsObject));
      this.EnterScope(this.GlobalScope);
      this.CallStack = new Stack<string>();
    }

    public ExecutionVisitor(IGlobal GlobalObject, JsScope Scope)
    {
      if (GlobalObject == null)
        throw new ArgumentNullException(nameof (GlobalObject));
      if (Scope == null)
        throw new ArgumentNullException(nameof (Scope));
      this.typeResolver = (ITypeResolver) CachedTypeResolver.Default;
      this.Global = GlobalObject;
      this.GlobalScope = Scope.Global;
      this.MaxRecursions = 500;
      this.EnterScope(Scope);
      this.CallStack = new Stack<string>();
    }

    public void OnStep(DebugInformation info)
    {
      if (this.Step == null || info.CurrentStatement == null || info.CurrentStatement.Source == null)
        return;
      this.Step((object) this, info);
    }

    public DebugInformation CreateDebugInformation(Statement statement)
    {
      DebugInformation debugInformation = new DebugInformation();
      debugInformation.CurrentStatement = statement;
      debugInformation.CallStack = this.CallStack;
      debugInformation.Locals = (JsDictionaryObject) new JsObject((JsObject) JsNull.Instance);
      this.DebugMode = false;
      foreach (string key in this.CurrentScope.GetKeys())
        debugInformation.Locals[key] = this.CurrentScope[key];
      this.DebugMode = true;
      return debugInformation;
    }

    public JsScope CurrentScope
    {
      get
      {
        return this.Scopes.Peek();
      }
    }

    protected void EnterScope(JsDictionaryObject scope)
    {
      this.Scopes.Push(new JsScope(this.CurrentScope, scope));
    }

    protected void EnterScope(JsScope scope)
    {
      this.Scopes.Push(scope);
    }

    protected void ExitScope()
    {
      this.Scopes.Pop();
    }

    public void Visit(Program program)
    {
      this.typeFullname = new StringBuilder();
      this.exit = false;
      this.lastIdentifier = string.Empty;
      foreach (Statement statement in program.Statements)
      {
        this.CurrentStatement = statement;
        if (this.DebugMode)
          this.OnStep(this.CreateDebugInformation(statement));
        this.Result = (JsInstance) null;
        statement.Accept((IStatementVisitor) this);
        if (this.exit)
        {
          this.exit = false;
          break;
        }
      }
    }

    public void Visit(AssignmentExpression statement)
    {
      switch (statement.AssignmentOperator)
      {
        case AssignmentOperator.Assign:
          statement.Right.Accept((IStatementVisitor) this);
          break;
        case AssignmentOperator.Multiply:
          new BinaryExpression(BinaryExpressionType.Times, statement.Left, statement.Right).Accept((IStatementVisitor) this);
          break;
        case AssignmentOperator.Divide:
          new BinaryExpression(BinaryExpressionType.Div, statement.Left, statement.Right).Accept((IStatementVisitor) this);
          break;
        case AssignmentOperator.Modulo:
          new BinaryExpression(BinaryExpressionType.Modulo, statement.Left, statement.Right).Accept((IStatementVisitor) this);
          break;
        case AssignmentOperator.Add:
          new BinaryExpression(BinaryExpressionType.Plus, statement.Left, statement.Right).Accept((IStatementVisitor) this);
          break;
        case AssignmentOperator.Substract:
          new BinaryExpression(BinaryExpressionType.Minus, statement.Left, statement.Right).Accept((IStatementVisitor) this);
          break;
        case AssignmentOperator.ShiftLeft:
          new BinaryExpression(BinaryExpressionType.LeftShift, statement.Left, statement.Right).Accept((IStatementVisitor) this);
          break;
        case AssignmentOperator.ShiftRight:
          new BinaryExpression(BinaryExpressionType.RightShift, statement.Left, statement.Right).Accept((IStatementVisitor) this);
          break;
        case AssignmentOperator.UnsignedRightShift:
          new BinaryExpression(BinaryExpressionType.UnsignedRightShift, statement.Left, statement.Right).Accept((IStatementVisitor) this);
          break;
        case AssignmentOperator.And:
          new BinaryExpression(BinaryExpressionType.BitwiseAnd, statement.Left, statement.Right).Accept((IStatementVisitor) this);
          break;
        case AssignmentOperator.Or:
          new BinaryExpression(BinaryExpressionType.BitwiseOr, statement.Left, statement.Right).Accept((IStatementVisitor) this);
          break;
        case AssignmentOperator.XOr:
          new BinaryExpression(BinaryExpressionType.BitwiseXOr, statement.Left, statement.Right).Accept((IStatementVisitor) this);
          break;
        default:
          throw new NotSupportedException();
      }
      JsInstance result = this.Result;
      this.Assign(statement.Left as MemberExpression ?? new MemberExpression(statement.Left, (Expression) null), result);
      this.Result = result;
    }

    public void Assign(MemberExpression left, JsInstance value)
    {
      Descriptor result = (Descriptor) null;
      if (!(left.Member is IAssignable))
        throw new JintException("The left member of an assignment must be a member");
      this.EnsureIdentifierIsDefined((object) value);
      JsDictionaryObject dictionaryObject;
      if (left.Previous != null)
      {
        left.Previous.Accept((IStatementVisitor) this);
        dictionaryObject = this.Result as JsDictionaryObject;
        if (dictionaryObject == null)
          throw new JintException("Attempt to assign to an undefined variable.");
      }
      else
      {
        dictionaryObject = (JsDictionaryObject) this.CurrentScope;
        this.CurrentScope.TryGetDescriptor(((Identifier) left.Member).Text, out result);
      }
      if (left.Member is Identifier)
      {
        string text = ((Identifier) left.Member).Text;
        this.Result = dictionaryObject[text] = value;
      }
      else
      {
        (left.Member as Indexer).Index.Accept((IStatementVisitor) this);
        if (dictionaryObject is JsObject)
        {
          JsObject jsObject = dictionaryObject as JsObject;
          if (jsObject.Indexer != null)
          {
            jsObject.Indexer.set((JsInstance) jsObject, this.Result, value);
            this.Result = value;
            return;
          }
        }
        this.Result = dictionaryObject[this.Result] = value;
      }
    }

    public void Visit(CommaOperatorStatement statement)
    {
      foreach (Statement statement1 in statement.Statements)
      {
        if (this.DebugMode)
          this.OnStep(this.CreateDebugInformation(statement1));
        statement1.Accept((IStatementVisitor) this);
        if (this.StopStatementFlow())
          break;
      }
    }

    public void Visit(BlockStatement statement)
    {
      Statement currentStatement = this.CurrentStatement;
      foreach (Statement statement1 in statement.Statements)
      {
        this.CurrentStatement = statement1;
        if (this.DebugMode)
          this.OnStep(this.CreateDebugInformation(statement1));
        this.Result = (JsInstance) null;
        statement1.Accept((IStatementVisitor) this);
        if (this.StopStatementFlow())
          return;
      }
      this.CurrentStatement = currentStatement;
    }

    public void Visit(ContinueStatement statement)
    {
      this.continueStatement = statement;
    }

    public void Visit(BreakStatement statement)
    {
      this.breakStatement = statement;
    }

    public void Visit(DoWhileStatement statement)
    {
      do
      {
        statement.Statement.Accept((IStatementVisitor) this);
        this.ResetContinueIfPresent(statement.Label);
        if (this.StopStatementFlow())
        {
          if (this.breakStatement != null && statement.Label == this.breakStatement.Label)
          {
            this.breakStatement = (BreakStatement) null;
            return;
          }
          goto label_6;
        }
        else
        {
          statement.Condition.Accept((IStatementVisitor) this);
          this.EnsureIdentifierIsDefined((object) this.Result);
        }
      }
      while (this.Result.ToBoolean());
      goto label_4;
label_6:
      return;
label_4:;
    }

    public void Visit(EmptyStatement statement)
    {
    }

    [DebuggerStepThrough]
    public void Visit(ExpressionStatement statement)
    {
      statement.Expression.Accept((IStatementVisitor) this);
    }

    public void Visit(ForEachInStatement statement)
    {
      bool flag = true;
      string empty = string.Empty;
      string index1;
      if (statement.InitialisationStatement is VariableDeclarationStatement)
      {
        flag = ((VariableDeclarationStatement) statement.InitialisationStatement).Global;
        index1 = ((VariableDeclarationStatement) statement.InitialisationStatement).Identifier;
      }
      else
      {
        if (!(statement.InitialisationStatement is Identifier))
          throw new NotSupportedException("Only variable declaration are allowed in a for in loop");
        flag = true;
        index1 = ((Identifier) statement.InitialisationStatement).Text;
      }
      statement.Expression.Accept((IStatementVisitor) this);
      JsDictionaryObject result = this.Result as JsDictionaryObject;
      if (this.Result.Value is IEnumerable)
      {
        foreach (object obj in (IEnumerable) this.Result.Value)
        {
          this.CurrentScope[index1] = (JsInstance) this.Global.WrapClr(obj);
          statement.Statement.Accept((IStatementVisitor) this);
          this.ResetContinueIfPresent(statement.Label);
          if (this.StopStatementFlow())
          {
            if (this.breakStatement == null || !(statement.Label == this.breakStatement.Label))
              break;
            this.breakStatement = (BreakStatement) null;
            break;
          }
          this.ResetContinueIfPresent(statement.Label);
        }
      }
      else
      {
        if (result == null)
          throw new InvalidOperationException("The property can't be enumerated");
        List<string> stringList = new List<string>(result.GetKeys());
        for (int index2 = 0; index2 < stringList.Count; ++index2)
        {
          string str = stringList[index2];
          this.CurrentScope[index1] = (JsInstance) this.Global.StringClass.New(str);
          statement.Statement.Accept((IStatementVisitor) this);
          this.ResetContinueIfPresent(statement.Label);
          if (this.StopStatementFlow())
          {
            if (this.breakStatement == null || !(statement.Label == this.breakStatement.Label))
              break;
            this.breakStatement = (BreakStatement) null;
            break;
          }
          this.ResetContinueIfPresent(statement.Label);
        }
      }
    }

    public void Visit(WithStatement statement)
    {
      statement.Expression.Accept((IStatementVisitor) this);
      if (!(this.Result is JsDictionaryObject))
        throw new JsException((JsInstance) this.Global.StringClass.New("Invalid expression in 'with' statement"));
      this.EnterScope((JsDictionaryObject) this.Result);
      try
      {
        statement.Statement.Accept((IStatementVisitor) this);
      }
      finally
      {
        this.ExitScope();
      }
    }

    public void Visit(ForStatement statement)
    {
      if (statement.InitialisationStatement != null)
        statement.InitialisationStatement.Accept((IStatementVisitor) this);
      if (statement.ConditionExpression != null)
        statement.ConditionExpression.Accept((IStatementVisitor) this);
      else
        this.Result = (JsInstance) this.Global.BooleanClass.New(true);
      this.EnsureIdentifierIsDefined((object) this.Result);
      while (this.Result.ToBoolean())
      {
        statement.Statement.Accept((IStatementVisitor) this);
        this.ResetContinueIfPresent(statement.Label);
        if (this.StopStatementFlow())
        {
          if (this.breakStatement == null || !(statement.Label == this.breakStatement.Label))
            break;
          this.breakStatement = (BreakStatement) null;
          break;
        }
        if (statement.IncrementExpression != null)
          statement.IncrementExpression.Accept((IStatementVisitor) this);
        if (statement.ConditionExpression != null)
          statement.ConditionExpression.Accept((IStatementVisitor) this);
        else
          this.Result = (JsInstance) this.Global.BooleanClass.New(true);
      }
    }

    public JsFunction CreateFunction(IFunctionDeclaration functionDeclaration)
    {
      JsFunction jsFunction = this.Global.FunctionClass.New();
      jsFunction.Statement = functionDeclaration.Statement;
      jsFunction.Name = functionDeclaration.Name;
      jsFunction.Scope = this.CurrentScope;
      jsFunction.Arguments = functionDeclaration.Parameters;
      if (this.HasOption(Options.Strict))
      {
        foreach (string str in jsFunction.Arguments)
        {
          if (str == "eval" || str == "arguments")
            throw new JsException((JsInstance) this.Global.StringClass.New("The parameters do not respect strict mode"));
        }
      }
      return jsFunction;
    }

    public void Visit(FunctionDeclarationStatement statement)
    {
      JsFunction function = this.CreateFunction((IFunctionDeclaration) statement);
      this.CurrentScope.DefineOwnProperty(statement.Name, (JsInstance) function);
    }

    public void Visit(IfStatement statement)
    {
      statement.Expression.Accept((IStatementVisitor) this);
      this.EnsureIdentifierIsDefined((object) this.Result);
      if (this.Result.ToBoolean())
        statement.Then.Accept((IStatementVisitor) this);
      else if (statement.Else != null)
        statement.Else.Accept((IStatementVisitor) this);
    }

    public void Visit(ReturnStatement statement)
    {
      this.returnInstance = (JsInstance) null;
      if (statement.Expression != null)
      {
        statement.Expression.Accept((IStatementVisitor) this);
        this.Return(this.Result);
      }
      this.exit = true;
    }

    public JsInstance Return(JsInstance instance)
    {
      this.returnInstance = instance;
      return this.returnInstance;
    }

    public void Visit(SwitchStatement statement)
    {
      this.CurrentStatement = statement.Expression;
      bool flag = false;
      if (statement.CaseClauses != null)
      {
        foreach (CaseClause caseClause in statement.CaseClauses)
        {
          this.CurrentStatement = (Statement) caseClause.Expression;
          if (flag)
          {
            caseClause.Statements.Accept((IStatementVisitor) this);
            if (this.exit)
              break;
          }
          else
          {
            new BinaryExpression(BinaryExpressionType.Equal, (Expression) statement.Expression, caseClause.Expression).Accept((IStatementVisitor) this);
            if (this.Result.ToBoolean())
            {
              caseClause.Statements.Accept((IStatementVisitor) this);
              flag = true;
              if (this.exit)
                break;
            }
          }
          if (this.breakStatement != null)
          {
            this.breakStatement = (BreakStatement) null;
            break;
          }
        }
      }
      if (flag || statement.DefaultStatements == null)
        return;
      statement.DefaultStatements.Accept((IStatementVisitor) this);
      if (this.breakStatement != null)
        this.breakStatement = (BreakStatement) null;
    }

    public void Visit(ThrowStatement statement)
    {
      this.Result = (JsInstance) JsUndefined.Instance;
      if (statement.Expression != null)
        statement.Expression.Accept((IStatementVisitor) this);
      throw new JsException(this.Result);
    }

    public void Visit(TryStatement statement)
    {
      try
      {
        statement.Statement.Accept((IStatementVisitor) this);
      }
      catch (Exception ex)
      {
        if (statement.Catch != null)
        {
          JsException jsException = ex as JsException ?? new JsException((JsInstance) this.Global.ErrorClass.New(ex.Message));
          if (statement.Catch.Identifier != null)
            this.Assign(new MemberExpression((Expression) new PropertyExpression(statement.Catch.Identifier), (Expression) null), jsException.Value);
          statement.Catch.Statement.Accept((IStatementVisitor) this);
        }
        else
          throw;
      }
      finally
      {
        if (statement.Finally != null)
        {
          JsObject jsObject = new JsObject();
          statement.Finally.Statement.Accept((IStatementVisitor) this);
        }
      }
    }

    public void Visit(VariableDeclarationStatement statement)
    {
      this.Result = (JsInstance) JsUndefined.Instance;
      if (statement.Expression != null)
      {
        statement.Expression.Accept((IStatementVisitor) this);
        if (statement.Global)
          throw new InvalidOperationException("Cant declare a global variable");
        if (!this.CurrentScope.HasOwnProperty(statement.Identifier))
          this.CurrentScope.DefineOwnProperty(statement.Identifier, this.Result);
        else
          this.CurrentScope[statement.Identifier] = this.Result;
      }
      else if (!this.CurrentScope.HasOwnProperty(statement.Identifier))
        this.CurrentScope.DefineOwnProperty(statement.Identifier, (JsInstance) JsUndefined.Instance);
    }

    public void Visit(WhileStatement statement)
    {
      statement.Condition.Accept((IStatementVisitor) this);
      this.EnsureIdentifierIsDefined((object) this.Result);
      while (this.Result.ToBoolean())
      {
        statement.Statement.Accept((IStatementVisitor) this);
        this.ResetContinueIfPresent(statement.Label);
        if (this.StopStatementFlow())
        {
          if (this.breakStatement == null || !(statement.Label == this.breakStatement.Label))
            break;
          this.breakStatement = (BreakStatement) null;
          break;
        }
        statement.Condition.Accept((IStatementVisitor) this);
      }
    }

    public void Visit(NewExpression expression)
    {
      this.Result = (JsInstance) null;
      expression.Expression.Accept((IStatementVisitor) this);
      if (this.Result == JsUndefined.Instance && this.typeFullname.Length > 0 && expression.Generics.Count > 0)
      {
        string str = this.typeFullname.ToString();
        this.typeFullname = new StringBuilder();
        Type[] typeArray = new Type[expression.Generics.Count];
        try
        {
          int index = 0;
          foreach (Statement generic in expression.Generics)
          {
            generic.Accept((IStatementVisitor) this);
            typeArray[index] = this.Global.Marshaller.MarshalJsValue<Type>(this.Result);
            ++index;
          }
        }
        catch (Exception ex)
        {
          throw new JintException("A type parameter is required", ex);
        }
        this.Result = this.Global.Marshaller.MarshalClrValue<Type>(this.typeResolver.ResolveType(str + "`" + (object) typeArray.Length).MakeGenericType(typeArray));
      }
      if (this.Result == null || !(this.Result is JsFunction))
        throw new JsException((JsInstance) this.Global.ErrorClass.New("Function expected."));
      JsFunction result = (JsFunction) this.Result;
      JsInstance[] parameters = new JsInstance[expression.Arguments.Count];
      for (int index = 0; index < expression.Arguments.Count; ++index)
      {
        expression.Arguments[index].Accept((IStatementVisitor) this);
        parameters[index] = this.Result;
      }
      this.Result = (JsInstance) result.Construct(parameters, (Type[]) null, (IJintVisitor) this);
    }

    public void Visit(TernaryExpression expression)
    {
      this.Result = (JsInstance) null;
      expression.LeftExpression.Accept((IStatementVisitor) this);
      JsInstance result = this.Result;
      this.Result = (JsInstance) null;
      this.EnsureIdentifierIsDefined((object) result);
      if (result.ToBoolean())
        expression.MiddleExpression.Accept((IStatementVisitor) this);
      else
        expression.RightExpression.Accept((IStatementVisitor) this);
    }

    public static bool IsNullOrUndefined(JsInstance o)
    {
      return o == JsUndefined.Instance || o == JsNull.Instance || o.IsClr && o.Value == null;
    }

    public JsBoolean Compare(JsInstance x, JsInstance y)
    {
      if (x.IsClr && y.IsClr)
        return this.Global.BooleanClass.New(x.Value.Equals(y.Value));
      if (x.IsClr)
        return this.Compare(x.ToPrimitive(this.Global), y);
      if (y.IsClr)
        return this.Compare(x, y.ToPrimitive(this.Global));
      if (x.Type == y.Type)
      {
        if (x == JsUndefined.Instance || x == JsNull.Instance)
          return this.Global.BooleanClass.True;
        if (x.Type == "number")
        {
          if (x.ToNumber() == double.NaN || y.ToNumber() == double.NaN || x.ToNumber() != y.ToNumber())
            return this.Global.BooleanClass.False;
          return this.Global.BooleanClass.True;
        }
        if (x.Type == "string")
          return this.Global.BooleanClass.New(x.ToString() == y.ToString());
        if (x.Type == "boolean")
          return this.Global.BooleanClass.New(x.ToBoolean() == y.ToBoolean());
        if (x.Type == "object")
          return this.Global.BooleanClass.New(x == y);
        return this.Global.BooleanClass.New(x.Value.Equals(y.Value));
      }
      if (x == JsNull.Instance && y == JsUndefined.Instance || x == JsUndefined.Instance && y == JsNull.Instance)
        return this.Global.BooleanClass.True;
      if (x.Type == "number" && y.Type == "string" || x.Type == "string" && y.Type == "number" || (x.Type == "boolean" || y.Type == "boolean"))
        return this.Global.BooleanClass.New(x.ToNumber() == y.ToNumber());
      if (y.Type == "object" && (x.Type == "string" || x.Type == "number"))
        return this.Compare(x, y.ToPrimitive(this.Global));
      if (x.Type == "object" && (y.Type == "string" || y.Type == "number"))
        return this.Compare(x.ToPrimitive(this.Global), y);
      return this.Global.BooleanClass.False;
    }

    public bool CompareTo(JsInstance x, JsInstance y, out int result)
    {
      result = 0;
      if (x.IsClr && y.IsClr)
      {
        IComparable comparable = x.Value as IComparable;
        if (comparable == null || y.Value == null || comparable.GetType() != y.Value.GetType())
          return false;
        result = comparable.CompareTo(y.Value);
      }
      else
      {
        double number1 = x.ToNumber();
        double number2 = y.ToNumber();
        if (double.IsNaN(number1) || double.IsNaN(number2))
          return false;
        result = number1 >= number2 ? (number1 != number2 ? 1 : 0) : -1;
      }
      return true;
    }

    public void Visit(BinaryExpression expression)
    {
      expression.LeftExpression.Accept((IStatementVisitor) this);
      this.EnsureIdentifierIsDefined((object) this.Result);
      JsInstance result1 = this.Result;
      if (expression.Type == BinaryExpressionType.And && !result1.ToBoolean())
        this.Result = result1;
      else if (expression.Type == BinaryExpressionType.Or && result1.ToBoolean())
      {
        this.Result = result1;
      }
      else
      {
        expression.RightExpression.Accept((IStatementVisitor) this);
        this.EnsureIdentifierIsDefined((object) this.Result);
        JsInstance result2 = this.Result;
        switch (expression.Type)
        {
          case BinaryExpressionType.And:
            if (result1.ToBoolean())
            {
              this.Result = result2;
              break;
            }
            this.Result = (JsInstance) this.Global.BooleanClass.False;
            break;
          case BinaryExpressionType.Or:
            if (result1.ToBoolean())
            {
              this.Result = result1;
              break;
            }
            this.Result = result2;
            break;
          case BinaryExpressionType.NotEqual:
            this.Result = (JsInstance) this.Global.BooleanClass.New(!this.Compare(result1, result2).ToBoolean());
            break;
          case BinaryExpressionType.LesserOrEqual:
            int result3;
            this.Result = !this.CompareTo(result1, result2, out result3) || result3 > 0 ? (JsInstance) this.Global.BooleanClass.False : (JsInstance) this.Global.BooleanClass.True;
            break;
          case BinaryExpressionType.GreaterOrEqual:
            int result4;
            this.Result = !this.CompareTo(result1, result2, out result4) || result4 < 0 ? (JsInstance) this.Global.BooleanClass.False : (JsInstance) this.Global.BooleanClass.True;
            break;
          case BinaryExpressionType.Lesser:
            int result5;
            this.Result = !this.CompareTo(result1, result2, out result5) || result5 >= 0 ? (JsInstance) this.Global.BooleanClass.False : (JsInstance) this.Global.BooleanClass.True;
            break;
          case BinaryExpressionType.Greater:
            int result6;
            this.Result = !this.CompareTo(result1, result2, out result6) || result6 <= 0 ? (JsInstance) this.Global.BooleanClass.False : (JsInstance) this.Global.BooleanClass.True;
            break;
          case BinaryExpressionType.Equal:
            this.Result = (JsInstance) this.Compare(result1, result2);
            break;
          case BinaryExpressionType.Minus:
            this.Result = (JsInstance) this.Global.NumberClass.New(result1.ToNumber() - result2.ToNumber());
            break;
          case BinaryExpressionType.Plus:
            if (result1.Class == "String" || result2.Class == "String")
            {
              this.Result = (JsInstance) this.Global.StringClass.New(result1.ToString() + result2.ToString());
              break;
            }
            this.Result = (JsInstance) this.Global.NumberClass.New(result1.ToNumber() + result2.ToNumber());
            break;
          case BinaryExpressionType.Modulo:
            if (result2 == this.Global.NumberClass["NEGATIVE_INFINITY"] || result2 == this.Global.NumberClass["POSITIVE_INFINITY"])
            {
              this.Result = this.Global.NumberClass["POSITIVE_INFINITY"];
              break;
            }
            if (result2.ToNumber() == 0.0)
            {
              this.Result = this.Global.NumberClass["NaN"];
              break;
            }
            this.Result = (JsInstance) this.Global.NumberClass.New(result1.ToNumber() % result2.ToNumber());
            break;
          case BinaryExpressionType.Div:
            double number1 = result2.ToNumber();
            double number2 = result1.ToNumber();
            if (result2 == this.Global.NumberClass["NEGATIVE_INFINITY"] || result2 == this.Global.NumberClass["POSITIVE_INFINITY"])
            {
              this.Result = (JsInstance) this.Global.NumberClass.New(0.0);
              break;
            }
            if (number1 == 0.0)
            {
              this.Result = number2 > 0.0 ? this.Global.NumberClass["POSITIVE_INFINITY"] : this.Global.NumberClass["NEGATIVE_INFINITY"];
              break;
            }
            this.Result = (JsInstance) this.Global.NumberClass.New(number2 / number1);
            break;
          case BinaryExpressionType.Times:
            this.Result = (JsInstance) this.Global.NumberClass.New(result1.ToNumber() * result2.ToNumber());
            break;
          case BinaryExpressionType.Pow:
            this.Result = (JsInstance) this.Global.NumberClass.New(Math.Pow(result1.ToNumber(), result2.ToNumber()));
            break;
          case BinaryExpressionType.BitwiseAnd:
            if (result1 == JsUndefined.Instance || result2 == JsUndefined.Instance)
            {
              this.Result = (JsInstance) this.Global.NumberClass.New(0.0);
              break;
            }
            this.Result = (JsInstance) this.Global.NumberClass.New((double) (Convert.ToInt64(result1.ToNumber()) & Convert.ToInt64(result2.ToNumber())));
            break;
          case BinaryExpressionType.BitwiseOr:
            if (result1 == JsUndefined.Instance)
            {
              if (result2 == JsUndefined.Instance)
              {
                this.Result = (JsInstance) this.Global.NumberClass.New(1.0);
                break;
              }
              this.Result = (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result2.ToNumber()));
              break;
            }
            if (result2 == JsUndefined.Instance)
            {
              this.Result = (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result1.ToNumber()));
              break;
            }
            this.Result = (JsInstance) this.Global.NumberClass.New((double) (Convert.ToInt64(result1.ToNumber()) | Convert.ToInt64(result2.ToNumber())));
            break;
          case BinaryExpressionType.BitwiseXOr:
            if (result1 == JsUndefined.Instance)
            {
              if (result2 == JsUndefined.Instance)
              {
                this.Result = (JsInstance) this.Global.NumberClass.New(1.0);
                break;
              }
              this.Result = (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result2.ToNumber()));
              break;
            }
            if (result2 == JsUndefined.Instance)
            {
              this.Result = (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result1.ToNumber()));
              break;
            }
            this.Result = (JsInstance) this.Global.NumberClass.New((double) (Convert.ToInt64(result1.ToNumber()) ^ Convert.ToInt64(result2.ToNumber())));
            break;
          case BinaryExpressionType.Same:
            if (result1.Type != result2.Type)
            {
              this.Result = (JsInstance) this.Global.BooleanClass.False;
              break;
            }
            if (result1 is JsUndefined)
            {
              this.Result = (JsInstance) this.Global.BooleanClass.True;
              break;
            }
            if (result1 is JsNull)
            {
              this.Result = (JsInstance) this.Global.BooleanClass.True;
              break;
            }
            if (result1.Type == "number")
            {
              if (result1 == this.Global.NumberClass["NaN"] || result2 == this.Global.NumberClass["NaN"])
              {
                this.Result = (JsInstance) this.Global.BooleanClass.False;
                break;
              }
              if (result1.ToNumber() == result2.ToNumber())
              {
                this.Result = (JsInstance) this.Global.BooleanClass.True;
                break;
              }
              this.Result = (JsInstance) this.Global.BooleanClass.False;
              break;
            }
            if (result1.Type == "string")
            {
              this.Result = (JsInstance) this.Global.BooleanClass.New(result1.ToString() == result2.ToString());
              break;
            }
            if (result1.Type == "boolean")
            {
              this.Result = (JsInstance) this.Global.BooleanClass.New(result1.ToBoolean() == result2.ToBoolean());
              break;
            }
            if (result1 == result2)
            {
              this.Result = (JsInstance) this.Global.BooleanClass.True;
              break;
            }
            this.Result = (JsInstance) this.Global.BooleanClass.False;
            break;
          case BinaryExpressionType.NotSame:
            new BinaryExpression(BinaryExpressionType.Same, expression.LeftExpression, expression.RightExpression).Accept((IStatementVisitor) this);
            this.Result = (JsInstance) this.Global.BooleanClass.New(!this.Result.ToBoolean());
            break;
          case BinaryExpressionType.LeftShift:
            if (result1 == JsUndefined.Instance)
            {
              this.Result = (JsInstance) this.Global.NumberClass.New(0.0);
              break;
            }
            if (result2 == JsUndefined.Instance)
            {
              this.Result = (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result1.ToNumber()));
              break;
            }
            this.Result = (JsInstance) this.Global.NumberClass.New((double) (Convert.ToInt64(result1.ToNumber()) << (int) Convert.ToUInt16(result2.ToNumber())));
            break;
          case BinaryExpressionType.RightShift:
            if (result1 == JsUndefined.Instance)
            {
              this.Result = (JsInstance) this.Global.NumberClass.New(0.0);
              break;
            }
            if (result2 == JsUndefined.Instance)
            {
              this.Result = (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result1.ToNumber()));
              break;
            }
            this.Result = (JsInstance) this.Global.NumberClass.New((double) (Convert.ToInt64(result1.ToNumber()) >> (int) Convert.ToUInt16(result2.ToNumber())));
            break;
          case BinaryExpressionType.UnsignedRightShift:
            if (result1 == JsUndefined.Instance)
            {
              this.Result = (JsInstance) this.Global.NumberClass.New(0.0);
              break;
            }
            if (result2 == JsUndefined.Instance)
            {
              this.Result = (JsInstance) this.Global.NumberClass.New((double) Convert.ToInt64(result1.ToNumber()));
              break;
            }
            this.Result = (JsInstance) this.Global.NumberClass.New((double) (Convert.ToInt64(result1.ToNumber()) >> (int) Convert.ToUInt16(result2.ToNumber())));
            break;
          case BinaryExpressionType.InstanceOf:
            JsFunction jsFunction = result2 as JsFunction;
            JsObject inst = result1 as JsObject;
            if (jsFunction == null)
              throw new JsException((JsInstance) this.Global.TypeErrorClass.New("Right argument should be a function: " + expression.RightExpression.ToString()));
            if (inst == null)
              throw new JsException((JsInstance) this.Global.TypeErrorClass.New("Left argument should be an object: " + expression.LeftExpression.ToString()));
            this.Result = (JsInstance) this.Global.BooleanClass.New(jsFunction.HasInstance(inst));
            break;
          case BinaryExpressionType.In:
            if (result2 is ILiteral)
              throw new JsException((JsInstance) this.Global.ErrorClass.New("Cannot apply 'in' operator to the specified member."));
            this.Result = (JsInstance) this.Global.BooleanClass.New(((JsDictionaryObject) result2).HasProperty(result1));
            break;
          default:
            throw new NotSupportedException("Unkown binary operator");
        }
      }
    }

    public void Visit(UnaryExpression expression)
    {
      switch (expression.Type)
      {
        case UnaryExpressionType.TypeOf:
          expression.Expression.Accept((IStatementVisitor) this);
          if (this.Result == null)
          {
            this.Result = (JsInstance) this.Global.StringClass.New(JsUndefined.Instance.Type);
            break;
          }
          if (this.Result is JsNull)
          {
            this.Result = (JsInstance) this.Global.StringClass.New("object");
            break;
          }
          if (this.Result is JsFunction)
          {
            this.Result = (JsInstance) this.Global.StringClass.New("function");
            break;
          }
          this.Result = (JsInstance) this.Global.StringClass.New(this.Result.Type);
          break;
        case UnaryExpressionType.Not:
          expression.Expression.Accept((IStatementVisitor) this);
          this.EnsureIdentifierIsDefined((object) this.Result);
          this.Result = (JsInstance) this.Global.BooleanClass.New(!this.Result.ToBoolean());
          break;
        case UnaryExpressionType.Negate:
          expression.Expression.Accept((IStatementVisitor) this);
          this.EnsureIdentifierIsDefined((object) this.Result);
          this.Result = (JsInstance) this.Global.NumberClass.New(-this.Result.ToNumber());
          break;
        case UnaryExpressionType.Positive:
          expression.Expression.Accept((IStatementVisitor) this);
          this.EnsureIdentifierIsDefined((object) this.Result);
          this.Result = (JsInstance) this.Global.NumberClass.New(this.Result.ToNumber());
          break;
        case UnaryExpressionType.PrefixPlusPlus:
          expression.Expression.Accept((IStatementVisitor) this);
          this.EnsureIdentifierIsDefined((object) this.Result);
          JsInstance jsInstance1 = (JsInstance) this.Global.NumberClass.New(this.Result.ToNumber() + 1.0);
          this.Assign(expression.Expression as MemberExpression ?? new MemberExpression(expression.Expression, (Expression) null), jsInstance1);
          break;
        case UnaryExpressionType.PrefixMinusMinus:
          expression.Expression.Accept((IStatementVisitor) this);
          this.EnsureIdentifierIsDefined((object) this.Result);
          JsInstance jsInstance2 = (JsInstance) this.Global.NumberClass.New(this.Result.ToNumber() - 1.0);
          this.Assign(expression.Expression as MemberExpression ?? new MemberExpression(expression.Expression, (Expression) null), jsInstance2);
          break;
        case UnaryExpressionType.PostfixPlusPlus:
          expression.Expression.Accept((IStatementVisitor) this);
          this.EnsureIdentifierIsDefined((object) this.Result);
          JsInstance result1 = this.Result;
          this.Assign(expression.Expression as MemberExpression ?? new MemberExpression(expression.Expression, (Expression) null), (JsInstance) this.Global.NumberClass.New(result1.ToNumber() + 1.0));
          this.Result = result1;
          break;
        case UnaryExpressionType.PostfixMinusMinus:
          expression.Expression.Accept((IStatementVisitor) this);
          this.EnsureIdentifierIsDefined((object) this.Result);
          JsInstance result2 = this.Result;
          this.Assign(expression.Expression as MemberExpression ?? new MemberExpression(expression.Expression, (Expression) null), (JsInstance) this.Global.NumberClass.New(result2.ToNumber() - 1.0));
          this.Result = result2;
          break;
        case UnaryExpressionType.Delete:
          MemberExpression expression1 = expression.Expression as MemberExpression;
          if (expression1 == null)
            throw new NotImplementedException("delete");
          expression1.Previous.Accept((IStatementVisitor) this);
          this.EnsureIdentifierIsDefined((object) this.Result);
          JsInstance result3 = this.Result;
          string index = (string) null;
          if (expression1.Member is PropertyExpression)
            index = ((Identifier) expression1.Member).Text;
          if (expression1.Member is Indexer)
          {
            ((Indexer) expression1.Member).Index.Accept((IStatementVisitor) this);
            index = this.Result.ToString();
          }
          if (string.IsNullOrEmpty(index))
            throw new JsException((JsInstance) this.Global.TypeErrorClass.New());
          try
          {
            ((JsDictionaryObject) result3).Delete(index);
          }
          catch (JintException ex)
          {
            throw new JsException((JsInstance) this.Global.TypeErrorClass.New());
          }
          this.Result = result3;
          break;
        case UnaryExpressionType.Void:
          expression.Expression.Accept((IStatementVisitor) this);
          this.Result = (JsInstance) JsUndefined.Instance;
          break;
        case UnaryExpressionType.Inv:
          expression.Expression.Accept((IStatementVisitor) this);
          this.EnsureIdentifierIsDefined((object) this.Result);
          this.Result = (JsInstance) this.Global.NumberClass.New(0.0 - this.Result.ToNumber() - 1.0);
          break;
      }
    }

    public void Visit(ValueExpression expression)
    {
      switch (expression.TypeCode)
      {
        case TypeCode.Boolean:
          this.Result = (JsInstance) this.Global.BooleanClass.New((bool) expression.Value);
          break;
        case TypeCode.Int32:
        case TypeCode.Single:
        case TypeCode.Double:
          this.Result = (JsInstance) this.Global.NumberClass.New(Convert.ToDouble(expression.Value));
          break;
        case TypeCode.String:
          this.Result = (JsInstance) this.Global.StringClass.New((string) expression.Value);
          break;
        default:
          this.Result = expression.Value as JsInstance;
          break;
      }
    }

    public void Visit(FunctionExpression fe)
    {
      this.Result = (JsInstance) this.CreateFunction((IFunctionDeclaration) fe);
    }

    public void Visit(Statement expression)
    {
      throw new NotImplementedException();
    }

    public void Visit(MemberExpression expression)
    {
      if (expression.Previous != null)
        expression.Previous.Accept((IStatementVisitor) this);
      expression.Member.Accept((IStatementVisitor) this);
      if (this.Result != JsUndefined.Instance || this.typeFullname.Length <= 0)
        return;
      this.EnsureClrAllowed();
      Type type = this.typeResolver.ResolveType(this.typeFullname.ToString());
      if (type != null)
      {
        this.Result = (JsInstance) this.Global.WrapClr((object) type);
        this.typeFullname = new StringBuilder();
      }
    }

    public void EnsureIdentifierIsDefined(object value)
    {
      if (value == null)
        throw new JsException((JsInstance) this.Global.ReferenceErrorClass.New(this.lastIdentifier + " is not defined"));
    }

    public void Visit(Indexer indexer)
    {
      this.EnsureIdentifierIsDefined((object) this.Result);
      JsObject result = (JsObject) this.Result;
      indexer.Index.Accept((IStatementVisitor) this);
      if (result.IsClr)
        this.EnsureClrAllowed();
      if (result.Class == "String")
        this.SetResult((JsInstance) this.Global.StringClass.New(result.ToString()[Convert.ToInt32(this.Result.ToNumber())].ToString()), (JsDictionaryObject) result);
      else if (result.Indexer != null)
        this.SetResult(result.Indexer.get((JsInstance) result, this.Result), (JsDictionaryObject) result);
      else
        this.SetResult(result[this.Result], (JsDictionaryObject) result);
    }

    public void Visit(MethodCall methodCall)
    {
      JsDictionaryObject callTarget = this.CallTarget;
      JsInstance result = this.Result;
      if ((result == JsUndefined.Instance || this.Result == null) && string.IsNullOrEmpty(this.lastIdentifier))
        throw new JsException((JsInstance) this.Global.TypeErrorClass.New("Method isn't defined"));
      Type[] genericParameters = (Type[]) null;
      if (methodCall.Generics.Count > 0)
      {
        genericParameters = new Type[methodCall.Generics.Count];
        try
        {
          int index = 0;
          foreach (Statement generic in methodCall.Generics)
          {
            generic.Accept((IStatementVisitor) this);
            genericParameters[index] = this.Global.Marshaller.MarshalJsValue<Type>(this.Result);
            ++index;
          }
        }
        catch (Exception ex)
        {
          throw new JintException("A type parameter is required", ex);
        }
      }
      JsInstance[] parameters = new JsInstance[methodCall.Arguments.Count];
      if (methodCall.Arguments.Count > 0)
      {
        for (int index = 0; index < methodCall.Arguments.Count; ++index)
        {
          methodCall.Arguments[index].Accept((IStatementVisitor) this);
          parameters[index] = this.Result;
        }
      }
      if (!(result is JsFunction))
        throw new JsException((JsInstance) this.Global.ErrorClass.New("Function expected."));
      JsFunction function = (JsFunction) result;
      if (this.DebugMode)
      {
        string str = function.Name + "(";
        string[] strArray = new string[parameters.Length];
        for (int index = 0; index < parameters.Length; ++index)
          strArray[index] = parameters[index] == null ? "null" : parameters[index].ToSource();
        this.CallStack.Push(str + string.Join(", ", strArray) + ")");
      }
      this.returnInstance = (JsInstance) JsUndefined.Instance;
      JsInstance[] jsInstanceArray = new JsInstance[parameters.Length];
      parameters.CopyTo((Array) jsInstanceArray, 0);
      this.ExecuteFunction(function, callTarget, parameters, genericParameters);
      for (int index = 0; index < jsInstanceArray.Length; ++index)
      {
        if (jsInstanceArray[index] != parameters[index])
        {
          if (methodCall.Arguments[index] is MemberExpression && ((MemberExpression) methodCall.Arguments[index]).Member is IAssignable)
            this.Assign((MemberExpression) methodCall.Arguments[index], parameters[index]);
          else if (methodCall.Arguments[index] is Identifier)
            this.Assign(new MemberExpression(methodCall.Arguments[index], (Expression) null), parameters[index]);
        }
      }
      if (this.DebugMode)
        this.CallStack.Pop();
      this.Result = this.returnInstance;
      this.returnInstance = (JsInstance) JsUndefined.Instance;
    }

    public void ExecuteFunction(
      JsFunction function,
      JsDictionaryObject that,
      JsInstance[] parameters)
    {
      this.ExecuteFunction(function, that, parameters, (Type[]) null);
    }

    public void ExecuteFunction(
      JsFunction function,
      JsDictionaryObject that,
      JsInstance[] parameters,
      Type[] genericParameters)
    {
      if (function == null)
        return;
      if (this.recursionLevel++ > this.MaxRecursions)
        throw new JsException((JsInstance) this.Global.ErrorClass.New("Too many recursions in the script."));
      JsArguments jsArguments = new JsArguments(this.Global, function, parameters);
      JsScope scope = new JsScope(function.Scope ?? this.GlobalScope);
      for (int index = 0; index < function.Arguments.Count; ++index)
      {
        if (index < parameters.Length)
          scope.DefineOwnProperty((Descriptor) new LinkedDescriptor((JsDictionaryObject) scope, function.Arguments[index], jsArguments.GetDescriptor(index.ToString()), (JsDictionaryObject) jsArguments));
        else
          scope.DefineOwnProperty((Descriptor) new ValueDescriptor((JsDictionaryObject) scope, function.Arguments[index], (JsInstance) JsUndefined.Instance));
      }
      if (this.HasOption(Options.Strict))
        scope.DefineOwnProperty(JsScope.ARGUMENTS, (JsInstance) jsArguments);
      else
        jsArguments.DefineOwnProperty(JsScope.ARGUMENTS, (JsInstance) jsArguments);
      if (that != null)
        scope.DefineOwnProperty(JsScope.THIS, (JsInstance) that);
      else
        scope.DefineOwnProperty(JsScope.THIS, (JsInstance) (that = (JsDictionaryObject) (this.Global as JsObject)));
      this.EnterScope(scope);
      try
      {
        this.PermissionSet.PermitOnly();
        this.Result = genericParameters == null || (uint) genericParameters.Length <= 0U ? function.Execute((IJintVisitor) this, that, parameters) : function.Execute((IJintVisitor) this, that, parameters, genericParameters);
        if (!this.exit)
          return;
        this.exit = false;
      }
      finally
      {
        this.ExitScope();
        CodeAccessPermission.RevertPermitOnly();
        --this.recursionLevel;
      }
    }

    private bool HasOption(Options options)
    {
      return this.Global.HasOption(options);
    }

    public void Visit(PropertyExpression expression)
    {
      JsDictionaryObject result1 = this.Result as JsDictionaryObject;
      this.Result = (JsInstance) null;
      string index = this.lastIdentifier = expression.Text;
      JsInstance result2 = (JsInstance) null;
      if (result1 != null && result1.TryGetProperty(index, out result2))
      {
        this.SetResult(result2, result1);
      }
      else
      {
        if (this.Result == null && this.typeFullname.Length > 0)
          this.typeFullname.Append('.').Append(index);
        this.SetResult((JsInstance) JsUndefined.Instance, result1);
      }
    }

    public void Visit(PropertyDeclarationExpression expression)
    {
      JsDictionaryObject result = this.Result as JsDictionaryObject;
      switch (expression.Mode)
      {
        case PropertyExpressionType.Data:
          expression.Expression.Accept((IStatementVisitor) this);
          result.DefineOwnProperty((Descriptor) new ValueDescriptor(result, expression.Name, this.Result));
          break;
        case PropertyExpressionType.Get:
        case PropertyExpressionType.Set:
          JsFunction jsFunction1 = (JsFunction) null;
          JsFunction jsFunction2 = (JsFunction) null;
          if (expression.GetExpression != null)
          {
            expression.GetExpression.Accept((IStatementVisitor) this);
            jsFunction1 = (JsFunction) this.Result;
          }
          if (expression.SetExpression != null)
          {
            expression.SetExpression.Accept((IStatementVisitor) this);
            jsFunction2 = (JsFunction) this.Result;
          }
          JsDictionaryObject dictionaryObject = result;
          PropertyDescriptor propertyDescriptor = new PropertyDescriptor(this.Global, result, expression.Name);
          propertyDescriptor.GetFunction = jsFunction1;
          propertyDescriptor.SetFunction = jsFunction2;
          propertyDescriptor.Enumerable = true;
          dictionaryObject.DefineOwnProperty((Descriptor) propertyDescriptor);
          break;
      }
    }

    public void Visit(Identifier expression)
    {
      this.Result = (JsInstance) null;
      string index = this.lastIdentifier = expression.Text;
      Descriptor result = (Descriptor) null;
      if (this.CurrentScope.TryGetDescriptor(index, out result))
      {
        if (!result.isReference)
        {
          this.Result = result.Get((JsDictionaryObject) this.CurrentScope);
        }
        else
        {
          LinkedDescriptor linkedDescriptor = result as LinkedDescriptor;
          this.SetResult(linkedDescriptor.Get((JsDictionaryObject) this.CurrentScope), linkedDescriptor.targetObject);
        }
        if (this.Result != null)
          return;
      }
      if (index == "null")
        this.Result = (JsInstance) JsNull.Instance;
      if (index == "undefined")
        this.Result = (JsInstance) JsUndefined.Instance;
      if (this.Result != null)
        return;
      this.typeFullname.Append(index);
    }

    private void EnsureClrAllowed()
    {
      if (!this.AllowClr)
        throw new SecurityException("Use of Clr is not allowed");
    }

    public void Visit(JsonExpression json)
    {
      JsObject jsObject = this.Global.ObjectClass.New();
      foreach (KeyValuePair<string, Expression> keyValuePair in json.Values)
      {
        this.Result = (JsInstance) jsObject;
        keyValuePair.Value.Accept((IStatementVisitor) this);
      }
      this.Result = (JsInstance) jsObject;
    }

    protected void ResetContinueIfPresent(string label)
    {
      if (this.continueStatement == null || !(this.continueStatement.Label == label))
        return;
      this.continueStatement = (ContinueStatement) null;
    }

    protected bool StopStatementFlow()
    {
      return this.exit || this.breakStatement != null || this.continueStatement != null;
    }

    public void Visit(ArrayDeclaration expression)
    {
      JsArray jsArray = this.Global.ArrayClass.New();
      JsInstance[] jsInstanceArray = new JsInstance[expression.Parameters.Count];
      for (int index = 0; index < expression.Parameters.Count; ++index)
      {
        expression.Parameters[index].Accept((IStatementVisitor) this);
        jsArray[index.ToString()] = this.Result;
      }
      this.Result = (JsInstance) jsArray;
    }

    public void Visit(RegexpExpression expression)
    {
      this.Result = (JsInstance) this.Global.RegExpClass.New(expression.Regexp, expression.Options.Contains("g"), expression.Options.Contains("i"), expression.Options.Contains("m"));
    }

    public void OnDeserialization(object sender)
    {
      this.typeResolver = (ITypeResolver) new CachedTypeResolver();
    }

    private struct ResultInfo
    {
      public JsDictionaryObject baseObject;
      public JsInstance result;
    }
  }
}
