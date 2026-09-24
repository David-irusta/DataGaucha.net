using Datagaucha.DAL.interfaces.Auth;
using Datagaucha.DAL.interfaces.FileSystem;
using Datagaucha.DAL.interfaces.Post;
using Datagaucha.DAL.interfaces.Social;

namespace Datagaucha.DAL.interfaces;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    IUserRepository UserRepository { get; }

    IFileRepository FileRepository { get; }

    IImageRepository ImageRepository { get; }

    IPostRepository PostRepository { get; }

    IFollowRepository FollowRepository { get; }
}