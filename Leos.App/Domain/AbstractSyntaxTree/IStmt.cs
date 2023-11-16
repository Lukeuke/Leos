using Leos.App.Enums;

namespace Leos.App.Domain.AbstractSyntaxTree;

public interface IStmt
{
    public ENodeType Kind { get; }
}