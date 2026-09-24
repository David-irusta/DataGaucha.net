using Datagaucha.Domain.Exceptions;
namespace Datagaucha.Domain.Exceptions;

public class BusinessConflictException : BusinessException
{
    public BusinessConflictException(string message)
        : base(message)
    {
    }
}