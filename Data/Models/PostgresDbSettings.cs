namespace EFCoreDemo.Data.Models;

public class PostgresDbSettings
{
    public string? Host { get; set; }
    public string? DbName { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }

    public string ConnectionString 
    { 
        get
        {
            return $"Host={Host};Database={DbName};Username={Username};Password={Password}";
        }
    }
}