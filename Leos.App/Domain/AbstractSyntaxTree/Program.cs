using Leos.App.Enums;

namespace Leos.App.Domain.AbstractSyntaxTree;

public class Program : IStmt
{
    public ENodeType Kind { get; } = ENodeType.Program;
    public List<IStmt> Body { get; set; }
}