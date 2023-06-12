using AutoMapper;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventDetailQuery
{
    public class GetEventDetailQueryHandler : IRequestHandler<GetEventDetailQuery, EventDetailModel>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventDetailQueryHandler(IEventRepository eventRepository
            , IMapper mapper)
        {
            _eventRepository = eventRepository
                ?? throw new ArgumentNullException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<EventDetailModel> Handle(GetEventDetailQuery request, CancellationToken cancellationToken)
        {
            var eventItem = await _eventRepository.GetByIdAsync(request.EventId);
            return _mapper.Map<EventDetailModel>(eventItem);
        }
    }
}
