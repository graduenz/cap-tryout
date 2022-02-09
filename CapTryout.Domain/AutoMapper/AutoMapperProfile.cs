using AutoMapper;
using CapTryout.Domain.Dto;
using CapTryout.Domain.Models;

namespace CapTryout.Domain.AutoMapper;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        DomainToDto();
        DtoToDomain();
    }

    private void DomainToDto()
    {
        CreateMap<Meal, MealDto>();
    }

    private void DtoToDomain()
    {
        CreateMap<MealDto, Meal>();
    }
}