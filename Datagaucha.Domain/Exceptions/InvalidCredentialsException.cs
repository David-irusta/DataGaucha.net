using Datagaucha.Domain.Exceptions;
namespace Datagaucha.Domain.Exceptions;

public class InvalidCredentialsException : BusinessException
{
    public InvalidCredentialsException(string message)
        : base(message)
    {
    }
}