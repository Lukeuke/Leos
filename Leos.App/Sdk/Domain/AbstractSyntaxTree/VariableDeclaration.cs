using Leos.App.Sdk.Enums;
using Newtonsoft.Json;

namespace Leos.App.Sdk.Domain.AbstractSyntaxTree;

public class VariableDeclaration : IStmt
{
    public VariableDeclaration(bool constant, string identifier, IExpr? value = null)
    {
        Constant = constant;
        Identifier = identifier;
        Value = value;
    }
    
    public ENodeType Kind { get; } = ENodeType.VariableDeclaration;
    public bool Constant { get; }
    public string Identifier { get; }
    public IExpr? Value { get; }
    
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}