using Datagaucha.DAL.interfaces.Social;
namespace Datagaucha.DAL.EntityFramework.Social;

public class EFFollowRepository : IFollowRepository
{
    private DatagauchaDbContext dbContext;
    public EFFollowRepository(DatagauchaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
}