using Leos.App.Runtime.Enums;

namespace Leos.App.Runtime.Domain;

public class NumberValue : IRuntimeValue
{
    public NumberValue(float value)
    {
        Value = value;
    }
    
    public EValueType Type { get; } = EValueType.Number;
    public float Value { get; }
}