using EFCoreDemo.Data;

namespace EFCoreDemo.Services;

public interface IDbService
{

}

public class DbService : IDbService
{
    private readonly BloggingContext _dbContext;
    public DbService(BloggingContext dbContext)
    {
        _dbContext = dbContext;
    }
}