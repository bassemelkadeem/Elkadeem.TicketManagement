using Elkadeem.TicketManagement.Application.Exceptions;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence.Tickets;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Events.Commands.RemoveEvent
{
    public class RemoveEventCommandHandler : IRequestHandler<RemoveEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public RemoveEventCommandHandler(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
        }

        public async Task Handle(RemoveEventCommand request, CancellationToken cancellationToken)
        {
            var eventToDelete = await _eventRepository.GetByIdAsync(request.EventId);
            if (eventToDelete == null)
            {
                throw new NotFoundException(nameof(eventToDelete), request.EventId);
            }

            _eventRepository.Delete(eventToDelete);
            await _eventRepository.SaveAsync();
        }
    }
}
