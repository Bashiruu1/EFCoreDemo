using EFCoreDemo.Models;
using EFCoreDemo.Services;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Data;

public class BloggingContext : DbContext
{
    private readonly IClockService _clock;
    public BloggingContext(DbContextOptions options, IClockService clock) : base(options) 
    {
        _clock = clock;
    }
    
    public DbSet<Blog>? Blogs { get; set; }
    public DbSet<Post>? Posts { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var changedEntity in ChangeTracker.Entries())
        {
            if(changedEntity.Entity is IEntity entity)
            {
                var now = _clock.Now;
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