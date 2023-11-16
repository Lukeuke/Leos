namespace Leos.App.Domain;

public class UnrecognisedCharacterException : Exception
{
    public UnrecognisedCharacterException(char c) : base($"Unrecognised character found: '{c}'.")
    {
        
    }
}