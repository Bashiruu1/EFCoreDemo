using NodaTime;

namespace EFCoreDemo.Models;

public interface IEntity
{
    public Instant CreationTime { get; set; }
    public Instant UpdatedTime { get; set; }
}