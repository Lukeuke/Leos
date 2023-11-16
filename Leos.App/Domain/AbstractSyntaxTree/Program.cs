using System.Text;
using Leos.App.Enums;

namespace Leos.App.Domain.AbstractSyntaxTree;

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
                case ENodeType.Identifier:
                    var identifier = (Identifier)stmt;
                    sb.Append(identifier);
                    sb.Append(',');
                    break;
                case ENodeType.BinaryExpr:
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