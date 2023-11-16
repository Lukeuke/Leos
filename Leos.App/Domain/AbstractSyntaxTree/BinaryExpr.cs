using Leos.App.Enums;

namespace Leos.App.Domain.AbstractSyntaxTree;

public class BinaryExpr : IExpr
{
    public BinaryExpr(IExpr left, IExpr right, string @operator)
    {
        Left = left;
        Right = right;
        Operator = @operator;
    }
    
    public ENodeType Kind { get; } = ENodeType.BinaryExpr;
    public IExpr Left { get; set; }
    public IExpr Right { get; set; }
    public string Operator { get; set; }
    
    public override string ToString()
    {
        return '{' + $" Kind: {Kind}, Left: {Left}, Right: {Right}, Operator: '{Operator}' " + '}';
    }
}