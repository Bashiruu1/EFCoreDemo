namespace EFCoreDemo.Models;

public interface IEntity
{
    public DateTime CreationTime { get; set; }
    public DateTime UpdatedTime { get; set; }
}