namespace EFCoreDemo.Models;

public abstract class EntityBase : IEntity
{
    public Guid Id { get; set; }
    public virtual DateTime CreatedDate { get ; set; }
    public virtual DateTime UpdatedDate { get; set; }
}