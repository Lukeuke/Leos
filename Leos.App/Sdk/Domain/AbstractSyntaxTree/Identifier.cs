using Leos.App.Sdk.Enums;
using Newtonsoft.Json;

namespace Leos.App.Sdk.Domain.AbstractSyntaxTree;

public class Identifier : IExpr
{
    public Identifier(string symbol)
    {
        Symbol = symbol;
    }
    
    public ENodeType Kind { get; } = ENodeType.Identifier;
    public string Symbol { get; }
    
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
        return '{' + $" Kind: {Kind}, Symbol: {Symbol} " + '}';
    }
}