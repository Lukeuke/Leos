using Leos.App.Enums;

namespace Leos.App.Domain.AbstractSyntaxTree;

public class BinaryExpr : IExpr
{
    public ENodeType Kind { get; } = ENodeType.BinaryExpr;
    public IExpr Left { get; set; }
    public IExpr Right { get; set; }
    public string Operator { get; set; }
}