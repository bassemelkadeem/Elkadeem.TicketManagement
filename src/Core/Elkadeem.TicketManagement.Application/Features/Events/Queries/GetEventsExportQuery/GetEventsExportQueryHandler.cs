using AutoMapper;
using Elkadeem.TicketManagement.Application.Interfaces.Infrastructure.Export;
using Elkadeem.TicketManagement.Application.Interfaces.Persistence;
using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventsExportQuery
{
    public class GetEventsExportQueryHandler : IRequestHandler<GetEventsExportQuery, GetEventsExportQueryModel>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;
        private readonly ICsvExporter _csvExporter;

        public GetEventsExportQueryHandler(IEventRepository eventRepository,
            IMapper mapper, ICsvExporter csvExporter)
        {
            _eventRepository = eventRepository ?? throw new ArgumentNullException(nameof(eventRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _csvExporter = csvExporter;
        }

        public async Task<GetEventsExportQueryModel> Handle(GetEventsExportQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await _eventRepository.GetAllAsync()).OrderBy(x => x.Date);
            var events = _mapper.Map<List<EventExportDto>>(allEvents);

            var fileData = _csvExporter.ExportEventsToCsv(events);

            var eventExportFileDto = new GetEventsExportQueryModel
            {
                Data = fileData,
                ContentType = "text/csv",
                EventExportFileName = $"{Guid.NewGuid()}.csv"
            };

            return eventExportFileDto;
        }
    }
}
