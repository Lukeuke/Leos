using Leos.App.Enums;

namespace Leos.App.Domain.AbstractSyntaxTree;

public class Identifier : IExpr
{
    public Identifier(string symbol)
    {
        Symbol = symbol;
    }
    
    public ENodeType Kind { get; } = ENodeType.Identifier;
    public string Symbol { get; }
}