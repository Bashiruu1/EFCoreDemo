using NodaTime;

namespace EFCoreDemo.Data.Entities;

public abstract class EntityBase
{
    public long Id { get; set; }
    public Instant CreationTime { get ; set; }
    public Instant UpdatedTime { get; set; }
}