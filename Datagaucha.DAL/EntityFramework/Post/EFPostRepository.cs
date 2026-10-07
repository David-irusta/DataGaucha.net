namespace Datagaucha.DAL.EntityFramework.Post;

using System.Collections.Generic;
using System.Threading.Tasks;
using Datagaucha.DAL.interfaces.Post;
using Datagaucha.Domain.Auth;
using Datagaucha.Domain.Post;
using Microsoft.EntityFrameworkCore;

public class EFPostRepository(DatagauchaDbContext dbContext) : IPostRepository
{
    private readonly DatagauchaDbContext dbContext = dbContext;

    public async Task<List<Post>>GetPosts(
        User user,
        int currentPage,
        int pageSize,
        string orderBy,
        string orderDirection,
        string? search)
    {
        //Listado de Id's de gente que yo sigo
        IQueryable<long> followedUserIds = dbContext.Follows
            .Where(follow => follow.Following.Id == user.Id)
            .Select(follow => follow.Follower.Id);

        IQueryable<Datagaucha.Domain.Post.Post> posts = dbContext.Posts
            .Where(post => post.User.Id == user.Id || followedUserIds.Contains(post.User.Id));

        if (!String.IsNullOrEmpty(search))
        {
            posts = posts.Where(post => post.Body.Contains(search));
        }

        AddOrder(ref orderBy, ref orderDirection, posts);
        posts = posts
                .Skip((currentPage - 1) * pageSize)
                .Take(pageSize);

        return await posts.ToListAsync();
    }

    private static void AddOrder(ref string orderBy, ref string orderDirection, IQueryable<Post> posts)
    {
        if (String.IsNullOrEmpty(orderBy)) orderBy = "CREATEDAT";
        if (String.IsNullOrEmpty(orderDirection)) orderDirection = "DESC";

        if (orderBy.ToUpper().Equals("CREATEDAT"))
        {
            if (orderDirection.ToUpper().Equals("ASC"))
            {
                posts.OrderBy(post => post.Id);
            }
            else
            {
                posts.OrderByDescending(post => post.Id);
            }
        }
        else if (orderBy.ToUpper().Equals("BODY"))
        {
            if (orderDirection.ToUpper().Equals("ASC"))
            {
                posts.OrderBy(post => post.Body);
            }
            else
            {
                posts.OrderByDescending(post => post.Body);
            }
        }
        else
        {
            if (orderDirection.ToUpper().Equals("ASC"))
            {
                posts.OrderBy(post => post.Id);
            }
            else
            {
                posts.OrderByDescending(post => post.Id);
            }
        }
    }

    public Task<List<Post>> GetPosts(User user, object currentPage, object pageSize, object orderBy, object orderDirection, object search) => throw new NotImplementedException();
}