using EFCoreDemo.Data.Contexts;
using EFCoreDemo.Data.Entities;
using EFCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers;

[ApiController]
[Route("public/[controller]")]
public class BloggingController : ControllerBase
{
    private readonly ILogger<BloggingController> _logger;
    private readonly BloggingContext _context;
    // TODO:: Fix me up please
    public BloggingController(ILogger<BloggingController> logger, BloggingContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Blog>> GetBlogsAsync()
    {
        return _context.Blogs;
    }
}
