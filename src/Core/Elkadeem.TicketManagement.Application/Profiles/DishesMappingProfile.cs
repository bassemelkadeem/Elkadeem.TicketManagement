using AutoMapper;
using Elkadeem.TicketManagement.Application.Features.Dishes.Queries.GetDishesListQuery.Dtos;
using Elkadeem.TicketManagement.Domain.Dishes;

namespace Elkadeem.TicketManagement.Application.Profiles
{
    public class DishesMappingProfile : Profile
    {
        public DishesMappingProfile()
        {
            CreateMap<Dish, DishListItemDto>();
        }
    }
}
