using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Categories.Queries.GetCategoriesListWithEventsQuery
{
    public class GetCategoriesListWithEventsQuery : IRequest<List<CategoryItemWithEventsModel>>
    {
        public bool IncludeHistory { get; set; }
    }
}
