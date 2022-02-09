using AutoMapper;
using CapTryout.Domain;
using CapTryout.Domain.Dto;
using CapTryout.Domain.Models;
using DotNetCore.CAP;

namespace CapTryout.Consumer;
public class MealAddSub : ICapSubscribe
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    public MealAddSub(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    [CapSubscribe("services.meal.add")]
    public async Task Run(MealDto mealDto)
    {
        var entity = _mapper.Map<Meal>(mealDto);
        await _dbContext.Meals.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
    }
}