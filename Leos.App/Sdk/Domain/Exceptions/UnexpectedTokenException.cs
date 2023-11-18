namespace Leos.App.Sdk.Domain.Exceptions;

public class UnexpectedTokenException : Exception
{
    public UnexpectedTokenException(Token token) : base($"Unexpected token found while parsing: {token}")
    {
        
    }
}