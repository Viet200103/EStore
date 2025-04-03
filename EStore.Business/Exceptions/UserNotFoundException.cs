using System.Security.Authentication;

namespace EStore.Business.Exceptions;

public class UserNotFoundException : AuthenticationException
{
    public UserNotFoundException()
    {
    }

    public UserNotFoundException(string? message) : base(message)
    {
    }

    public UserNotFoundException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}