using EFCoreDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreDemo.Controllers;

[ApiController]
[Route("public/[controller]")]
public class BloggingController : ControllerBase
{
    private readonly ILogger<BloggingController> _logger;
    private readonly IDbService _service;

    public BloggingController(ILogger<BloggingController> logger, IDbService service)
    {
        _logger = logger;
        _service = service;
    }
}
