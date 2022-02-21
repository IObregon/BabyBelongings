using backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BelongingsController : ControllerBase
{
    private readonly ILogger<BelongingsController> _logger;
    private readonly BabyBelongingsContext _dbContext;

    public BelongingsController(
        ILogger<BelongingsController> logger,
        BabyBelongingsContext context)
    {
        _logger = logger;
        _dbContext = context;
    }

    [HttpGet(Name = "GetAllBelongings")]
    public async Task<IEnumerable<Belonging>> Get()
    {
        return await _dbContext.Belongings.ToListAsync();
    }
}