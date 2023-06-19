using AutoMapper;
using Elkadeem.TicketManagement.Presentation.Services.Base;
using Elkadeem.TicketManagement.Presentation.ViewModels;

namespace Elkadeem.TicketManagement.Presentation.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<CategoryItemModel, CategoryViewModel>();
            CreateMap<CategoryItemWithEventsModel, CategoryWithEventsViewModel>();
            CreateMap<EventItemModel, EventNestedViewModel>();
        }
    }
}
