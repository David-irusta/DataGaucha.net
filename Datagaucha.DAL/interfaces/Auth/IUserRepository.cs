using Datagaucha.Domain.Auth;

namespace Datagaucha.DAL.interfaces.Auth;

public interface IUserRepository
{
    Task<User?> GetuserByUserName(string userName);

    Task<bool> Create(User user);
    Task<User?> GetuserById(long userId);
}