namespace Leos.App.Runtime.Domain.Exceptions;

public class RuntimeException : Exception
{
    public RuntimeException(string msg) : base(msg)
    {
        msg = "Runtime Exception: " + msg;
    }
}