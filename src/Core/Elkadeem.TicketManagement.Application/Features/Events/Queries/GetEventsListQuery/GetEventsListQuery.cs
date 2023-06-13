using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventsListQuery
{
    public class GetEventsListQuery : IRequest<List<EventListItemModel>>
    {
    }
}
