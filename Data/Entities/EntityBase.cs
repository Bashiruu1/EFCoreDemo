using NodaTime;

namespace EFCoreDemo.Data.Entities;

public abstract class EntityBase
{
  public long Id { get; set; }
  public DateTime CreationTime { get; set; }
  public DateTime UpdatedTime { get; set; }
}
