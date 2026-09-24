using Datagaucha.Domain.Exceptions;
namespace Datagaucha.Domain.Exceptions;

public class BusinessNotFoundException : BusinessException
{
    public BusinessNotFoundException(string message)
        : base(message)
    {
    }
}