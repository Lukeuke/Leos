using Leos.App.Enums;

namespace Leos.App.Domain.AbstractSyntaxTree;

public class NumericLiteral : IExpr
{
    public NumericLiteral(float value)
    {
        Value = value;
    }
    
    public ENodeType Kind { get; } = ENodeType.NumericLiteral;
    public float Value { get; set; }

    public override string ToString()
    {
        return '{' + $" Kind: {Kind}, Value: {Value} " + '}';
    }
}