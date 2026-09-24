using Datagaucha.DAL.EntityFramework.Auth;
using Datagaucha.DAL.EntityFramework.FileSystem;
using Datagaucha.DAL.EntityFramework.Post;
using Datagaucha.DAL.EntityFramework.Social;
using Datagaucha.DAL.interfaces;
using Datagaucha.DAL.interfaces.Auth;
using Datagaucha.DAL.interfaces.FileSystem;
using Datagaucha.DAL.interfaces.Post;
using Datagaucha.DAL.interfaces.Social;
using Microsoft.EntityFrameworkCore;

namespace Datagaucha.DAL.EntityFramework;

public class EFUnitOfWork(DatagauchaDbContext context) : IUnitOfWork
{
    private readonly DatagauchaDbContext _context = context;

    private IUserRepository? userRepository;

    public IUserRepository UserRepository
    {
        get
        {
            if (this.userRepository is null)
            {
                this.userRepository = new EFUserRepository(_context);
            }
            return this.userRepository;
        }
    }

    private IFileRepository? fileRepository;

    public IFileRepository FileRepository
    {
        get
        {
            if (this.fileRepository is null)
            {
                this.fileRepository = new EFFileRepository(_context);
            }
            return this.fileRepository;
        }
    }

    private IImageRepository? imageRepository;

    public IImageRepository ImageRepository
    {
        get
        {
            if (this.imageRepository is null)
            {
                this.imageRepository = new EFImageRepository(_context);
            }
            return this.imageRepository;
        }
    }

    private IPostRepository? postRepository;

    public IPostRepository PostRepository
    {
        get
        {
            if (this.postRepository is null)
            {
                this.postRepository = new EFPostRepository(_context);
            }
            return this.postRepository;
        }
    }

    private IFollowRepository? followRepository;

    public IFollowRepository FollowRepository    {
        get
        {
            if (this.followRepository is null)
            {
                this.followRepository = new EFFollowRepository(_context);
            }
            return this.followRepository;
        }
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}