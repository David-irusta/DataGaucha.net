using Datagaucha.Domain.FileSystem;
namespace Datagaucha.DAL.interfaces.FileSystem;

public interface IFileRepository
{
    Task<Datagaucha.Domain.FileSystem.File?> GetById(long id);
    Task<Domain.FileSystem.File?> GetByName(string id);
}