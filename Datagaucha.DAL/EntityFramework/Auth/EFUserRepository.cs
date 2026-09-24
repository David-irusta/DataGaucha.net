using Datagaucha.DAL.interfaces.Auth;
using Datagaucha.Domain.Auth;
using Microsoft.EntityFrameworkCore;
namespace Datagaucha.DAL.EntityFramework.Auth;

public class EFUserRepository : IUserRepository
{
    private DatagauchaDbContext dbContext;
    public EFUserRepository(DatagauchaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> Create(User user)
    {
        await this.dbContext.Users.AddAsync(user);
        return true;
    }

    public async Task<User?> GetuserByUserName(string userName)
    {
        List<User> users = await this.dbContext.Users.Where(u => u.UserName.ToUpper().Equals(userName.ToUpper())).ToListAsync();

        if (users != null && users.Count > 0) return users[0];

        return null;
    }
}