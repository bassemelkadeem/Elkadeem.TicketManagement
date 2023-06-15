using AutoMapper;
using Elkadeem.TicketManagement.Application.Features.Categories.Commands.CreateCategoryCommand;
using Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListQuery;
using Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEventsQuery;
using Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoryDetailsQuery;
using Elkadeem.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using Elkadeem.TicketManagement.Application.Features.Events.Commands.UpdateEvent;
using Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventDetailQuery;
using Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventsListQuery;
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
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreatedCategoryDto>();

            // Events
            CreateMap<Event, EventDetailModel>();
            CreateMap<Event, EventItemModel>();
            CreateMap<Event, EventListItemModel>();
            CreateMap<CreateEventCommand, Event>();
            CreateMap<UpdateEventCommand, Event>();
        }
    }
}
