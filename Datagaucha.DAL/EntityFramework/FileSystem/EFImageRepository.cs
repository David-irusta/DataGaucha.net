using Datagaucha.DAL.interfaces.FileSystem;
namespace Datagaucha.DAL.EntityFramework.FileSystem;

public class EFImageRepository : IImageRepository
{
    private DatagauchaDbContext dbContext;
    public EFImageRepository(DatagauchaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
}