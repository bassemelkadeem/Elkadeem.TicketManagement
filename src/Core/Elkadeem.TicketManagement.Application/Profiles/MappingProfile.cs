using AutoMapper;
using Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListQuery;
using Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEventsQuery;
using Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoryDetailsQuery;
using Elkadeem.TicketManagement.Domain.Events;

namespace Elkadeem.TicketManagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Categories
            CreateMap<Category, CategoryItemModel>();
            CreateMap<Category, CategoryItemWithEventsModel>();
            CreateMap<Category, CategoryDetailsItemModel>();

            // Events
            CreateMap<Event, EventItemModel>();
        }
    }
}
