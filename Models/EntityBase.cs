using NodaTime;

namespace EFCoreDemo.Models;

public abstract class EntityBase : IEntity
{
    public Guid Id { get; set; }
    public virtual Instant CreationTime { get ; set; }
    public virtual Instant UpdatedTime { get; set; }
}