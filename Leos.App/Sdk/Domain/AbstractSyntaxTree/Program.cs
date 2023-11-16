using System.Text;
using Leos.App.Sdk.Enums;

namespace Leos.App.Sdk.Domain.AbstractSyntaxTree;

public class Program : IStmt
{
    public ENodeType Kind { get; } = ENodeType.Program;
    public List<IStmt> Body { get; set; }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.Append("{ Kind: Program, Body: [");
        foreach (var stmt in Body)
        {
            switch (stmt.Kind)
            {
                case ENodeType.Program:
                    break;
                case ENodeType.NumericLiteral:
                    var numericLiteral = (NumericLiteral)stmt;
                    sb.Append(numericLiteral);
                    sb.Append(',');
                    break;
                case ENodeType.NullLiteral:
                    var nullLiteral = (NullLiteral)stmt;
                    sb.Append(nullLiteral);
                    sb.Append(',');
                    break;
                case ENodeType.Identifier:
                    var identifier = (Identifier)stmt;
                    sb.Append(identifier);
                    sb.Append(',');
                    break;
                case ENodeType.BinaryExpr:
                    var expr = (BinaryExpr)stmt;
                    sb.Append(expr);
                    sb.Append(',');
                    break;
                case ENodeType.CallExpr:
                    break;
                case ENodeType.UnaryExpr:
                    break;
                case ENodeType.FunctionDeclaration:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        sb.Append("] }");

        return sb.ToString();
    }
}