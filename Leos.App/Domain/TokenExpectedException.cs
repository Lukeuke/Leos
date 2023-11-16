namespace Leos.App.Domain;

public class TokenExpectedException : Exception
{
    public TokenExpectedException(string message) : base(message)
    {
        
    }
}