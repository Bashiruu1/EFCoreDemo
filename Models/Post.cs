namespace EFCoreDemo.Models;

public class Post : EntityBase
{
    public string? Title { get; set; }
    public string? Content { get; set; }
    public Blog? Blog { get; set; }
}