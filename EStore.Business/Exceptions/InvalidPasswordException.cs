using System.Security.Authentication;

namespace EStore.Business.Exceptions;

public class InvalidPasswordException : AuthenticationException
{
    public InvalidPasswordException()
    {
    }

    public InvalidPasswordException(string? message) : base(message)
    {
    }

    public InvalidPasswordException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}