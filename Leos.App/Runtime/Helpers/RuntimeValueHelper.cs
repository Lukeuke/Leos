using Leos.App.Runtime.Domain;
using Leos.App.Runtime.Enums;
using Newtonsoft.Json;

namespace Leos.App.Runtime.Helpers;

public static class RuntimeValueHelper
{
    public static object? GetValue(this IRuntimeValue value)
    {
        switch (value.Type)
        {
            case EValueType.Null:
                return null;
            case EValueType.Number:
                var numberValue = (NumberValue)value;
                return numberValue.Value;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public static string RuntimeValueToString(this IRuntimeValue value)
    {
        object? result = null!;
        
        switch (value.Type)
        {
            case EValueType.Null:
                result = new NullValue();
                result = result as NullValue;
                break;
            case EValueType.Number:
                result = (NumberValue)value;
                result = result as NumberValue;
                break;
            case EValueType.Bool:
                result = (BoolValue)value;
                result = result as BoolValue;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return JsonConvert.SerializeObject(result);
    }
}