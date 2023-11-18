namespace Leos.App.Sdk.Domain.Exceptions;

public class UnrecognisedCharacterException : Exception
{
    public UnrecognisedCharacterException(char c) : base($"Unrecognised character found: '{c}'.")
    {
        
    }
}