using Leos.App.Sdk.Enums;

namespace Leos.App.Sdk.Domain.AbstractSyntaxTree;

public class NullLiteral : IExpr
{
    public ENodeType Kind { get; } = ENodeType.NullLiteral;
    public string Value { get; } = "Null";

    public override string ToString()
    {
        return '{' + $" Kind: {Kind}, Value: {Value} " + '}';
    }
}