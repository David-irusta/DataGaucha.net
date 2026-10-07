using Datagaucha.Domain.Auth;

namespace Datagaucha.DAL.interfaces.Post;

public interface IPostRepository
{
    Task<List<Domain.Post.Post>> GetPosts(User user,
        int currentPage,
        int pageSize,
        string orderBy,
        string orderDirection,
        string? search);
}