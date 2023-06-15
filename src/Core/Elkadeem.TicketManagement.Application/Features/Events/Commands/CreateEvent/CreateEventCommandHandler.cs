using AutoMapper;
using Elkadeem.TicketManagement.Application.Exceptions;
using Elkadeem.TicketManagement.Application.Interfaces.Infrastructure.Mail;
using Elkadeem.TicketManagement.Application.Interfaces.Infrastructure.Mail.Models;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence;
using Elkadeem.TicketManagement.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Elkadeem.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly ILogger<CreateEventCommandHandler> _logger;

        public CreateEventCommandHandler(
            IEventRepository eventRepository,
            IMapper mapper,
            IEmailService emailService,
            ILogger<CreateEventCommandHandler> logger)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
            await _eventRepository.SaveAsync();

            //Sending email notification to admin address
            var email = new Email() { To = "bassem.elkadeem@hotmail.com", Body = $"A new event was created: {request}", Subject = "A new event was created" };

            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {
                //this shouldn't stop the API from doing else so this can be logged
                _logger.LogError($"Mailing about event {@event.Id} failed due to an error with the mail service: {ex.Message}");
            }

            return @event.Id;
        }
    }
}
