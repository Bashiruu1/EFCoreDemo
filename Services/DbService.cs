using EFCoreDemo.Data;
using EFCoreDemo.Data.Entities;
using EFCoreDemo.Data.Contexts;

namespace EFCoreDemo.Services;

public interface IDbService
{
    Task<Blog> GetBlogAsync(Guid id);
    Task CreateBlogAsync(Blog item);
    Task CreatePostAsync(long blogId, Post post);
}

public class DbService : IDbService
{
    private readonly BloggingContext _dbContext;
    public DbService(BloggingContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task CreateBlogAsync(Blog item)
    {
        throw new NotImplementedException();
    }

    public Task CreatePostAsync(long blogId, Post post)
    {
        throw new NotImplementedException();
    }

    public Task<Blog> GetBlogAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}