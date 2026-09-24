using Datagaucha.DAL.interfaces.FileSystem;

namespace Datagaucha.DAL.EntityFramework.FileSystem;

public class EFFileRepository : IFileRepository
{
    private DatagauchaDbContext dbContext;
    public EFFileRepository(DatagauchaDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
}