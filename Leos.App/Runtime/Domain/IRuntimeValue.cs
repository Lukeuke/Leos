using Leos.App.Runtime.Enums;

namespace Leos.App.Runtime.Domain;

public interface IRuntimeValue
{
    public EValueType Type { get; }
}