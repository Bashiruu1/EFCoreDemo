using EFCoreDemo.Data.Contexts;
using EFCoreDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.GraphQL;

public class Query
{

    private readonly DateOnly dateOnly;

    [UseDbContext(typeof(BloggingContext))]
    [UseProjection]
    public IQueryable<Blog> GetBlog([Service] BloggingContext context, int blogId)
    {
        return context.Blogs.Where(x => x.Id == blogId).Include(x => x.Posts);
    }

    [UseDbContext(typeof(BloggingContext))]
    [UseProjection]
    public IQueryable<Post> GetPost([Service] BloggingContext context, int postId)
    {
        return context.Posts.Where(x => x.Id == postId);
    }
}
