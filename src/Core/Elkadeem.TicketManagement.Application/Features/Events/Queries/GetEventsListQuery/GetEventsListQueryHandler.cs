using AutoMapper;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventsListQuery
{
    public class GetEventsListQueryHandler : IRequestHandler<GetEventsListQuery, List<EventListItemModel>>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;

        public GetEventsListQueryHandler(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<EventListItemModel>> Handle(GetEventsListQuery request, CancellationToken cancellationToken)
        {
            var events = (await _eventRepository.GetAllAsync())
                .OrderByDescending(a => a.CreatedOn);
            return _mapper.Map<List<EventListItemModel>>(events);
        }
    }
}
