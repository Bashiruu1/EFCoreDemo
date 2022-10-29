using EFCoreDemo.Data.Contexts;
using EFCoreDemo.Data.Entities;

namespace EFCoreDemo.GraphQL.Resolvers;

public class Resolvers
{
    public class BlogType : ObjectType<Blog>
    {
        protected override void Configure(IObjectTypeDescriptor<Blog> descriptor)
        {
            descriptor.Description("Represents any sort of blog which has many posts");
            descriptor
                .Field(b => b.Posts)
                .ResolveWith<Resolvers>(p => p.GetPosts(default!, default!))
                .UseDbContext<BloggingContext>()
                .Description("This is the list of posts associated with the given blog");

        }

        private class Resolvers
        {
            public IQueryable<Post> GetPosts(Blog blog, [ScopedService] BloggingContext context)
            {
                return context.Posts.Where(p => p.BlogId == blog.Id);
            }
        }
    }


    public class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            descriptor.Description("Represents a post that is assigned to a blog");
            descriptor
                .Field(b => b.Blog)
                .ResolveWith<Resolvers>(p => p.GetBlogs(default!, default!))
                .UseDbContext<BloggingContext>()
                .Description("This is the list of posts associated with the given blog");

        }

        private class Resolvers
        {
            public Blog GetBlogs(Post post, [ScopedService] BloggingContext context)
            {
                return context.Blogs.FirstOrDefault(b => b.Id == post.BlogId);
            }
        }
    }

}
