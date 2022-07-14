using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreDemo.Data.Entities;

public class Blog : EntityBase
{
    public string? Url { get; set; }
    public IEnumerable<Post>? Posts { get; set; }

    public class Configuration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
        }
    }
}