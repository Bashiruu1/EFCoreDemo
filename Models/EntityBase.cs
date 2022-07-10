namespace EFCoreDemo.Models;

public abstract class EntityBase : IEntity
{
    public Guid Id { get; set; }
    public virtual DateTime CreationTime { get ; set; }
    public virtual DateTime UpdatedTime { get; set; }
}