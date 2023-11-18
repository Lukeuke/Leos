using System.Text;
using Leos.App.Sdk.Enums;
using Newtonsoft.Json;

namespace Leos.App.Sdk.Domain.AbstractSyntaxTree;

public class Program : IStmt
{
    public ENodeType Kind { get; } = ENodeType.Program;
    public List<IStmt> Body { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}