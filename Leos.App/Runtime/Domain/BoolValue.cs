using Leos.App.Runtime.Enums;

namespace Leos.App.Runtime.Domain;

public class BoolValue : IRuntimeValue
{
    public BoolValue(bool value = true)
    {
        Value = value;
    }

    public EValueType Type { get; } = EValueType.Bool;
    public bool Value { get; }
}