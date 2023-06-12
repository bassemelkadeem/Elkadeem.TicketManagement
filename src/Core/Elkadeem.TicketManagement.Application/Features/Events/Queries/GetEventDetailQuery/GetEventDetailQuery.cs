using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventDetailQuery
{
    public class GetEventDetailQuery : IRequest<EventDetailModel>
    {
        public Guid EventId { get; set; }
    }
}
