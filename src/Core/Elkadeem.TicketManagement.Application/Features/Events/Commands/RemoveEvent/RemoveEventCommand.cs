using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Events.Commands.RemoveEvent
{
    public class RemoveEventCommand : IRequest
    {
        public Guid EventId { get; set; }
    }
}
