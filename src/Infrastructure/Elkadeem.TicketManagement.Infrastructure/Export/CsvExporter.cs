using CsvHelper;
using Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventsExportQuery;
using Elkadeem.TicketManagement.Application.Interfaces.Infrastructure.Export;
using System.Globalization;

namespace Elkadeem.TicketManagement.Infrastructure.Export
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDto)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                csWriter.WriteRecords(eventExportDto);
            }


            return memoryStream.ToArray();
        }
    }
}
