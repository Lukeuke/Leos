using Leos.App.Runtime.Domain;
using Leos.App.Runtime.Enums;
using Leos.App.Sdk.Domain.AbstractSyntaxTree;
using Leos.App.Sdk.Enums;
using Program2 = Leos.App.Sdk.Domain.AbstractSyntaxTree.Program;

namespace Leos.App.Runtime;

public static class Interpreter
{
    public static IRuntimeValue Evaluate(IStmt ast)
    {
        switch (ast.Kind)
        {
            case ENodeType.Program:
                return EvaluateProgram((Program2) ast);
            case ENodeType.NumericLiteral:
                var numLit = (NumericLiteral)ast;
                return new NumberValue(numLit.Value);
            case ENodeType.NullLiteral:
                return new NullValue();
            case ENodeType.BinaryExpr:
                return EvaluateBinaryExpression((BinaryExpr) ast);
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    private static IRuntimeValue EvaluateBinaryExpression(BinaryExpr binOp)
    {
        var left = Evaluate(binOp.Left);
        var right = Evaluate(binOp.Right);

        if (left.Type == EValueType.Number && right.Type == EValueType.Number)
        {
            return EvaluateNumericBinaryExpression((NumberValue)left, (NumberValue)right, binOp.Operator);
        }

        return new NullValue();
    }

    private static NumberValue EvaluateNumericBinaryExpression(NumberValue left, NumberValue right, string @operator)
    {
        if (right.Value is 0 && @operator is "/" or "%") throw new DivideByZeroException();
        
        var result = @operator switch
        {
            "+" => left.Value + right.Value,
            "-" => left.Value - right.Value,
            "*" => left.Value * right.Value,
            "/" => left.Value / right.Value,
            "%" => left.Value % right.Value,
            _ => 0F
        };

        return new NumberValue(result);
    }

    private static IRuntimeValue EvaluateProgram(Program2 program)
    {
        IRuntimeValue lastEvaluated = new NullValue();

        foreach (var stmt in program.Body)
        {
            lastEvaluated = Evaluate(stmt);
        }
        
        return lastEvaluated;
    }
}