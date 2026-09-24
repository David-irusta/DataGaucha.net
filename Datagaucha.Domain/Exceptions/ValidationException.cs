using Datagaucha.Domain.Exceptions;
namespace Datagaucha.Domain.Exceptions;

public class ValidationException : BusinessException
{
    public ValidationException(string message)
        : base(message)
    {
    }
}