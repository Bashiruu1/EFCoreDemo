using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Data.Entities;

public class Post : EntityBase
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public long BlogId { get; set; }
    public Blog? Blog { get; set; }

    public class Configuration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasIndex(p => new {p.Id, p.BlogId});
        }
    }
}

