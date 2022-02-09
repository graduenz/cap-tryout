using AutoMapper;
using CapTryout.Domain;
using CapTryout.Domain.Dto;
using CapTryout.Domain.Models;
using DotNetCore.CAP;

namespace CapTryout.Consumer;
[CapSubscribe("services.meal")]
public class MealSub : ICapSubscribe
{
    private readonly AppDbContext _dbContext;
    private readonly ICapPublisher _capBus;
    private readonly IMapper _mapper;

    public MealSub(AppDbContext dbContext, ICapPublisher capPublisher, IMapper mapper)
    {
        _dbContext = dbContext;
        _capBus = capPublisher;
        _mapper = mapper;
    }

    [CapSubscribe("add", isPartial: true)]
    public async Task MealAdd(MealDto mealDto)
    {
        Console.WriteLine("Adding meal to database");
        var entity = _mapper.Map<Meal>(mealDto);
        await _dbContext.Meals.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        Console.WriteLine("Meal added to database");

        await _capBus.PublishAsync("services.meal.added", mealDto);
        Console.WriteLine("meal.added event published");
    }

    [CapSubscribe("added", isPartial: true, Group = "Cache")]
    public void AddToCache(MealDto mealDto)
    {
        Console.WriteLine("Adding meal to cache");
        // TODO: Maybe implement this for real?
        // For now, we are just testing CAP stuff
        Console.WriteLine("Meal added to cache");
    }

    [CapSubscribe("added", isPartial: true, Group = "Elastic")]
    public void AddToElastic(MealDto mealDto)
    {
        Console.WriteLine("Adding meal to elastic");
        // TODO: Maybe implement this for real?
        // For now, we are just testing CAP stuff
        Console.WriteLine("Meal added to elastic");
    }
}