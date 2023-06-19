using MediatR;

namespace Elkadeem.TicketManagement.Application.Features.Events.Queries.GetEventsExportQuery
{
    public record GetEventsExportQuery() : IRequest<GetEventsExportQueryModel>;
}
