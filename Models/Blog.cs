namespace EFCoreDemo.Models;

public class Blog : EntityBase
{
    public string? Url { get; set; }
    public IEnumerable<Post>? Posts { get; set; }
}