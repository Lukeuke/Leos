using Leos.App.Sdk.Enums;
using Newtonsoft.Json;

namespace Leos.App.Sdk.Domain.AbstractSyntaxTree;

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
        return JsonConvert.SerializeObject(this);
        return '{' + $" Kind: {Kind}, Left: {Left}, Right: {Right}, Operator: '{Operator}' " + '}';
    }
}