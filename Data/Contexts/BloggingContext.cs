using EFCoreDemo.Data.Entities;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace EFCoreDemo.Data.Contexts;

public class BloggingContext : DbContext
{
    private readonly IClock _clock;
    public BloggingContext(DbContextOptions options, IClock clock) : base(options)
    {
        _clock = clock;
    }

    public DbSet<Blog>? Blogs { get; set; }
    public DbSet<Post>? Posts { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var changedEntity in ChangeTracker.Entries())
        {
            if (changedEntity.Entity is EntityBase entity)
            {
                var now = DateTime.UtcNow;
                switch (changedEntity.State)
                {
                    case EntityState.Added:
                        entity.CreationTime = now;
                        entity.UpdatedTime = now;
                        break;
                    case EntityState.Modified:
                        entity.UpdatedTime = now;
                        break;
                }
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Blog.Configuration());
        modelBuilder.ApplyConfiguration(new Post.Configuration());
    }
}
