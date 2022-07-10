using EFCoreDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Data;

public class BloggingContext : DbContext
{
    public BloggingContext(DbContextOptions options) : base(options) {}
    public DbSet<Blog>? Blogs { get; set; }
    public DbSet<Post>? Posts { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var changedEntity in ChangeTracker.Entries())
        {
            if(changedEntity.Entity is IEntity entity)
            {
                var now = DateTime.UtcNow;
                switch(changedEntity.State)
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
}