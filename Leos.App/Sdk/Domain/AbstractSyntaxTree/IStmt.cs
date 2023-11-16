using Leos.App.Sdk.Enums;

namespace Leos.App.Sdk.Domain.AbstractSyntaxTree;

public interface IStmt
{
    public ENodeType Kind { get; }
}