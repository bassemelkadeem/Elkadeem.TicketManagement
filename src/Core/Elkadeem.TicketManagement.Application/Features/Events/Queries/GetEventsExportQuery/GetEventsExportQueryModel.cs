namespace Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventsExportQuery
{
    public class GetEventsExportQueryModel
    {
        public byte[]? Data { get; set; }

        public string ContentType { get; set; } = string.Empty;

        public string EventExportFileName { get; set; } = string.Empty;
    }
}
