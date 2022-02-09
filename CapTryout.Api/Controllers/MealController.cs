using AutoMapper;
using CapTryout.Domain;
using CapTryout.Domain.Dto;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CapTryout.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MealController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly ICapPublisher _capBus;
    private readonly IMapper _mapper;

    public MealController(AppDbContext dbContext, ICapPublisher capPublisher, IMapper mapper)
    {
        _dbContext = dbContext;
        _capBus = capPublisher;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetMany()
    {
        var result = _dbContext.Meals?.Select(_mapper.Map<MealDto>).ToList();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetOne([FromRoute] Guid id)
    {
        var entity = await _dbContext.Meals?.FirstOrDefaultAsync(m => m.Id == id);
        
        if (entity == null) return NotFound();

        return Ok(_mapper.Map<MealDto>(entity));
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] MealDto mealDto)
    {
        mealDto.Id = mealDto.Id == Guid.Empty ? Guid.NewGuid() : mealDto.Id;
        mealDto.CreatedAt = DateTimeOffset.UtcNow;

        using (var transaction = _dbContext.Database.BeginTransaction(_capBus, autoCommit: true))
        {
            await _capBus.PublishAsync("services.meal.add", mealDto);
        }

        return CreatedAtAction(nameof(GetOne), new { id = mealDto.Id }, mealDto);
    }
}
