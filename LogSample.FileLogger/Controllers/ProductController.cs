using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LogSample.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ILogger<ProductController> _logger;
    private readonly ILogger _logger2;

    public ProductController(ILogger<ProductController> logger, ILoggerFactory loggerFactory)
    {
        _logger = logger;
        _logger2 = loggerFactory.CreateLogger("ProductComponents");
    }

    [HttpGet("/Product")]
    public ActionResult GetProduct(int id)
    {
        _logger.LogInformation("Request for Product With {ID} Responed",id);
        _logger2.LogInformation("Request for Product With {ID} Responed",id);
        return Ok(new
        {
            ProductId = id,
            ProductName = $"Product {id}"
        });
    }
}

