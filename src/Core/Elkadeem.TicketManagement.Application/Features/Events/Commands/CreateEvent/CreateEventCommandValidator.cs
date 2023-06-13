using Elkadeem.TicketManagement.Application.Interfaces.Persistence;
using FluentValidation;

namespace Elkadeem.TicketManagement.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
    {
        private readonly IEventRepository _eventRepository;

        public CreateEventCommandValidator(
            IEventRepository eventRepository)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));

            RuleFor(a => a.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(a => a.Date)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull()
                .GreaterThan(DateTime.Now);

            RuleFor(a => a.Price)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .GreaterThan(0);

            RuleFor(a => a)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and date already exists.");
        }

        private async Task<bool> EventNameAndDateUnique(CreateEventCommand e, CancellationToken cancellationToken)
        {
            var isEventNameAndDateUnique = await _eventRepository.IsEventNameAndDateUniqueAsync(e.Name, e.Date);
            return !isEventNameAndDateUnique;
        }
    }
}
