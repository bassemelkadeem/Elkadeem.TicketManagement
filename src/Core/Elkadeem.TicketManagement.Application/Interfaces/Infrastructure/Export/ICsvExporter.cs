using Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventsExportQuery;

namespace Elkadeem.TicketManagement.Application.Interfaces.Infrastructure.Export
{
    public interface ICsvExporter
    {
        byte[] ExportEventsToCsv(List<EventExportDto> eventExportDto);
    }
}
