using AutoMapper;
using Elkadeem.TicketManagement.Application.Exceptions;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence;
using Elkadeem.TicketManagement.Domain.Events;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Count > 0)
            {
                throw new ValidationException(validationResult);
            }

            var @event = _mapper.Map<Event>(request);
            @event = await _eventRepository.AddAsync(@event);

            return @event.Id;
        }
    }
}
