using Leos.App.Runtime.Enums;

namespace Leos.App.Runtime.Domain;

public class NullValue : IRuntimeValue
{
    public EValueType Type { get; } = EValueType.Null;
    public string Value { get; } = "Null";
}