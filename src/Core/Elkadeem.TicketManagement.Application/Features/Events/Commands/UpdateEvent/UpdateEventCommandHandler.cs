using AutoMapper;
using Elkadeem.TicketManagement.Application.Exceptions;
using Elkadeem.TicketManagement.Application.Extensions;
using Elkadeem.TicketManagement.Application.Features.Events.Commands.CreateEvent;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence;
using Elkadeem.TicketManagement.Domain.Events;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Events.Commands.UpdateEvent
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var @eventToUpdate = await _eventRepository.GetByIdAsync(request.Id);
            if (@eventToUpdate == null)
            {
                throw new NotFoundException(nameof(@eventToUpdate), request.Id);
            }

            var validator = new UpdateEventCommandValidator(_eventRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
                throw new ValidationException(validationResult);

            _mapper.Map(request, @eventToUpdate, typeof(UpdateEventCommand), typeof(Event));
            _eventRepository.Update(eventToUpdate);
            await _eventRepository.SaveAsync();
        }
    }
}
