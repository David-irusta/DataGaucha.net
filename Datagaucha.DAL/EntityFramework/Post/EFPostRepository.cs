namespace Datagaucha.DAL.EntityFramework.Post;

using Datagaucha.DAL.interfaces.Post;
public class EFPostRepository : IPostRepository
{
    private DatagauchaDbContext dbContext;
    public EFPostRepository(DatagauchaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
}