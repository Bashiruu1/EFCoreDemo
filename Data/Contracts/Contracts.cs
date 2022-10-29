namespace EFCoreDemo.Data.Contracts;

public record BlogDto(string? Url, IEnumerable<PostDto> Posts);
public record PostDto(string? Title, string? Content);